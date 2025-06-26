using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Types;
using ECommons.Throttlers;
using ExplorersIcebox.Util;
using ExplorersIcebox.Util.PathCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_MoveAction
    {
        public static void Enqueue(List<Vector3> List, ulong gameObjectId, RouteClass.WaypointAction action = RouteClass.WaypointAction.None, bool mount = false, bool fly = false)
        {
            switch (action)
            {
                case RouteClass.WaypointAction.Jump:
                    P.taskManager.Enqueue(() => QueueNavmesh(List, mount, fly));
                    P.taskManager.Enqueue(() => JumpTask());
                    P.taskManager.Enqueue(() => FinishRoute());
                    break;

                case RouteClass.WaypointAction.IslandInteract:
                    P.taskManager.Enqueue(() => QueueNavmesh(List, mount, fly));
                    P.taskManager.Enqueue(() => FinishRoute());
                    P.taskManager.Enqueue(() => Target(gameObjectId));
                    P.taskManager.Enqueue(() => GatherInteract(gameObjectId));
                break;

                case RouteClass.WaypointAction.None:
                    P.taskManager.Enqueue(() => QueueNavmesh(List, mount, fly));
                    P.taskManager.Enqueue(() => FinishRoute());
                    break;
                default:
                    break;
            }
        }

        internal static bool? QueueNavmesh(List<Vector3> List, bool mount, bool fly)
        {
            // Things to note:
            // List is there to queue up all the waypoints that are created
            // Mount is optional by default, as well as flying (in the Enqueue task itself, just to keep it simple)
            // Will kick to true whenever Navmesh is detected as running

            if (P.navmesh.IsRunning())
            {
                return true;
            }
            else
            {
                if (fly)
                {
                    if (!Svc.Condition[ConditionFlag.Mounted])
                    {
                        // insert check here to mount
                    }
                    else
                    {
                        if (EzThrottler.Throttle("MoveToQueue"))
                            P.navmesh.MoveTo(new List<Vector3>(List), fly);
                    }
                }
                else
                {
                    if (EzThrottler.Throttle("MoveToQueue_Ground"))
                    {
                        P.navmesh.MoveTo(new List<Vector3>(List), fly);
                        if (mount)
                        {
                            // Insert mount logic here, just need to start the cast mid run
                        }
                    }
                }
            }

            return false;
        }

        internal static bool? FinishRoute()
        {
            // pretty much a failsafe to make sure that navmesh isn't running. 
            // could clump with other code but, could also use this as a series of wp's for specific things
            // like jumping in the future...

            if (P.navmesh.IsRunning() == false)
            {
                return true;
            }

            return false;
        }

        internal static void Target(ulong gameObjectId)
        {
            // set as a void instead of a bool to make sure that if it fails to target, it just continues on
            // moreso set for users sake so they don't go "wait how am I interacting w/o targeting!!!"
            // because I know this will be something some peeps will freak out about

            IGameObject? gameObject = null;
            Utils.TryGetObjectByGameObjectId(gameObjectId, out gameObject);
            Utils.TargetgameObject(gameObject);
        }

        internal static bool? GatherInteract(ulong gameObjectId)
        {
            // Actual interaction itself
            // If a target exist and can be interacted with, will do so. Probably should add a safety distance check to this for users...

            IGameObject? gameObject = null;
            Utils.TryGetObjectByGameObjectId(gameObjectId, out gameObject);

            if (gameObject == null || !gameObject.IsTargetable)
            {
                // no object was found, exiting code and continuing route
                return true;
            }
            else if (!Svc.Condition[ConditionFlag.OccupiedInQuestEvent])
            {
                if (EzThrottler.Throttle("Interacting with Island Object"))
                {
                    Utils.InteractWithObject(gameObject);
                }
            }

            return false;
        }

        internal static bool? JumpTask()
        {
            if (ECommons.GameHelpers.Player.IsJumping)
                return true;
            else
            {
                // insert jumping action here
            }

            return false;
        }
    }
}
