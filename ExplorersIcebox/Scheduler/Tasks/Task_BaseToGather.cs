using Dalamud.Game.ClientState.Conditions;
using ECommons.Throttlers;
using ExplorersIcebox.Util;
using FFXIVClientStructs.FFXIV.Client.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_BaseToGather
    {
        public static void Enqueue(List<Vector3> BaseWPList, bool mount, bool fly)
        {
            P.taskManager.Enqueue(() => BaseToGather(BaseWPList, mount, fly), "Moving from base -> gather point", Utils.TaskConfig);
        }

        internal static unsafe bool? BaseToGather(List<Vector3> BaseWPList, bool mount, bool fly)
        {
            var lastWP = BaseWPList.Last();
            bool PlayerMounted = Svc.Condition[ConditionFlag.Mounted]; // Quick and easy way to just access if you are mounted quickly

            if (PlayerHelper.GetDistanceToPlayer(lastWP) < 0.5f)
            {
                return true;
            }
            else if (!P.navmesh.IsRunning())
            {
                if (fly)
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
                            P.navmesh.MoveTo(new List<Vector3>(BaseWPList), fly);
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
                    if (EzThrottler.Throttle($"MoveToQueue_Ground_{lastWP}"))
                    {
                        Svc.Log.Debug("Telling Navmesh to move through the list");
                        Svc.Log.Debug($"List Count: {BaseWPList.Count}");
                        Svc.Log.Debug($"Fly: {fly}");
                        P.navmesh.MoveTo(new List<Vector3>(BaseWPList), fly);
                    }
                }
            }

            return false;
        }
    }
}
