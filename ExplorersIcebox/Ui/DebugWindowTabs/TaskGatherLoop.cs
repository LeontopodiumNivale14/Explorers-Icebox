using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal static class TaskGatherLoop
    {
        public static void Enqueue()
        {
            Task_GatherMode.Enqueue();
            foreach (var wpList in IslandHelper.CurrentRoute.Value.BaseToLocation)
            {
                Task_BaseToGather.Enqueue(wpList.Waypoints, wpList.Mount, wpList.Fly);
            }

            int totalLoops = Math.Min(IslandHelper.MaxTotalLoops, IslandHelper.MinimumPossibleLoops) - IslandHelper.CurrentLoopCount;
            P.taskManager.Enqueue(() => LoopCountUpdate(IslandHelper.CurrentLoopCount));
            for (int i = 0; i < totalLoops; i++)
            {
                foreach (var entry in IslandHelper.CurrentRoute.Value.RouteWaypoints)
                {
                    Task_IslandInteract.Enqueue(entry.Waypoints, entry.TargetId, entry.Mount, entry.Fly);
                }
                IslandHelper.CurrentLoopCount += 1;
            }
            P.taskManager.Enqueue(() => CheckLoopCount(), "Checking loop count");
        }

        internal static bool? LoopCountUpdate(int currentLoops)
        {
            Svc.Log.Debug($"Maximum loop count: {IslandHelper.MaxTotalLoops}");
            Svc.Log.Debug($"Minimum Possible Loops: {IslandHelper.MinimumPossibleLoops}");
            Svc.Log.Debug($"Current loop count: {currentLoops}");
            int totalLoops = Math.Min(IslandHelper.MaxTotalLoops, IslandHelper.MinimumPossibleLoops) - currentLoops;
            Svc.Log.Debug($"Total loops expected: {totalLoops}");

            return true;
        }

        internal static bool? CheckLoopCount()
        {
            Svc.Log.Debug($"Current loop count: {IslandHelper.CurrentLoopCount}");
            Svc.Log.Debug($"Max total loops: {IslandHelper.MaxTotalLoops}");
            if (IslandHelper.CurrentLoopCount >= IslandHelper.MaxTotalLoops)
            {
                SchedulerMain.State = Enums.IceBoxState.EndProcess;
            }
            else
            {
                SchedulerMain.State = Enums.IceBoxState.Start;
            }

            return true;
        }
    }
}
