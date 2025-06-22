using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Types;
using ECommons.Throttlers;
using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_IslandInteract
    {
        public static void Enqueue(List<Vector3> List, ulong gameObjectId, bool mount = false, bool fly = false)
        {
            P.taskManager.Enqueue(() => QueueNavmesh(List, mount, fly));
            P.taskManager.Enqueue(() => FinishRoute());
            P.taskManager.Enqueue(() => GatherInteract(gameObjectId));
        }

        internal static bool? QueueNavmesh(List<Vector3> List, bool mount, bool fly)
        {
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
            if (P.navmesh.IsRunning() == false)
            {
                return true;
            }
            
            return false;
        }

        internal static bool? GatherInteract(ulong gameObjectId)
        {
            IGameObject gameobject = null;
            Utils.TryGetObjectByGameObjectId(gameObjectId, out var gameObject);

            if (gameobject == null)
            {
                // no object was found, exiting code and continuing route
                return true;
            }
            else
            {
                // gameObject was found, targeting -> interacting
                if (Svc.Targets.Target != gameobject)
                {
                    if (EzThrottler.Throttle($"Targeting: {gameobject.Name}"))
                    {
                        Utils.TargetgameObject(gameobject);
                    }
                }
                else
                {
                    if (EzThrottler.Throttle("Interacting with Island Object") && !Svc.Condition[ConditionFlag.OccupiedInCutSceneEvent])
                        Utils.InteractWithObject(gameobject);
                }
            }

            return false;
        }
    }
}
