using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Types;
using ECommons.Throttlers;
using ExplorersIcebox.Util;
using FFXIVClientStructs.FFXIV.Client.Game;
using System.Collections.Generic;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_IslandInteract
    {
        public static void Enqueue(List<Vector3> List, ulong gameObjectId, bool mount = false, bool fly = false)
        {
            P.taskManager.Enqueue(() => QueueNavmesh2(List, mount, fly), "Queueing Navmesh");
            P.taskManager.Enqueue(() => FinishRoute(), "Waiting for Navmesh to Finish");
            if (gameObjectId != 0)
            {
                P.taskManager.Enqueue(() => TargetV2(gameObjectId), $"Checking for target: {gameObjectId}"); // Checking to see if the target exist
                P.taskManager.Enqueue(() => GatherInteract(gameObjectId), $"If target exist, gathering {gameObjectId}");
            }
        }

        internal unsafe static bool? QueueNavmesh2(List<Vector3> List, bool mount, bool fly)
        {
            bool PlayerMounted = Svc.Condition[ConditionFlag.Mounted]; // Quick and easy way to just access if you are mounted quickly
            int count = List.Count - 1;

            if (P.navmesh.IsRunning() && ((PlayerMounted && mount) || !mount))
            {
                return true;
            }
            else if (PlayerHelper.GetDistanceToPlayer(List[count]) < 0.5) // on the off chance that you're RIGHT there... there's no need to move to it
            {
                return true;
            }
            else
            {
                if (EzThrottler.Throttle("Verbose Log Info"))
                {
                    Svc.Log.Info($"Navmesh Running: {P.navmesh.IsRunning()}\n" +
                                 $"&& ( (Player Mounted: {PlayerMounted} && Mount: {mount}) || No Mount: {!mount} )");
                }
                // All conditions are failed, checking to see if you need to fly or if you just need to mount

                if (fly) // Checking if you aim to fly to said point
                {
                    if (!PlayerMounted) // Player not mounted, need to do this before flying can be achieved
                    {
                        if (!Svc.Condition[ConditionFlag.Casting] && !Svc.Condition[ConditionFlag.MountOrOrnamentTransition])
                        {
                            if (EzThrottler.Throttle("Using Mount Action Roulette"))
                            {
                                ActionManager.Instance()->UseAction(ActionType.GeneralAction, 9);
                            }
                        }
                    }
                    else // Player is on a mount, initiating the flying moveto
                    {
                        if (EzThrottler.Throttle("MoveToQueue_FlyMode"))
                            P.navmesh.MoveTo(new List<Vector3>(List), fly);
                    }
                }
                else
                {
                    // Checking to see if you need to mount
                    if (!PlayerMounted && mount)
                    {
                        if (!Svc.Condition[ConditionFlag.Casting] && !Svc.Condition[ConditionFlag.MountOrOrnamentTransition])
                        {
                            if (EzThrottler.Throttle("Using Mount", 250))
                            {
                                Svc.Log.Debug("Using Mount Action");
                                ActionManager.Instance()->UseAction(ActionType.GeneralAction, 9);
                            }
                        }
                    }
                    if (EzThrottler.Throttle($"MoveToQueue_Ground_{List[0]}"))
                    {
                        Svc.Log.Debug("Telling Navmesh to move through the list");
                        Svc.Log.Debug($"List Count: {List.Count}");
                        Svc.Log.Debug($"Fly: {fly}");
                        P.navmesh.MoveTo(new List<Vector3>(List), fly);
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
            if (gameObject != null)
            {
                Utils.TargetgameObject(gameObject);
            }
        }

        internal static bool? TargetV2(ulong gameObjectId)
        {
            IGameObject? gameObject = null;
            var currentTarget = Svc.Targets.Target?.GameObjectId ?? 0;
            Utils.TryGetObjectByGameObjectId(gameObjectId, out gameObject);

#if DEBUG
            Svc.Log.Debug($"GameObject == Null? [GameObject Doesn't exist]: {gameObject == null}");
            if (gameObject != null)
            {
                Svc.Log.Debug($"Gameobject is current target: {gameObject.IsTarget()}");
                Svc.Log.Debug($"GameObject is targetable: {gameObject.IsTargetable}");

            }
#endif

            if (gameObject == null || gameObject.IsTarget() || !gameObject.IsTargetable)
            {
                return true;
            }
            else if (gameObject != null)
            {
                if (EzThrottler.Throttle($"Targeting: {gameObjectId}"))
                {
#if DEBUG
                    Svc.Log.Debug($"Targeting: {gameObject.Name}");
#endif
                    Utils.TargetgameObject(gameObject);
                }
            }

            return false;
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
    }
}
