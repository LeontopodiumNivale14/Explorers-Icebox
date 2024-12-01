using ECommons.Throttlers;
using IslandLeveling.Scheduler.Handers;
using IslandLeveling.Scheduler.Tasks;
using IslandLeveling.Scheduler.Tasks.GroupTask;

namespace IslandLeveling.Scheduler
{
    internal static unsafe class SchedulerMain
    {
        internal static bool AreWeTicking;
        internal static bool EnableTicking
        {
            get => AreWeTicking;
            private set => AreWeTicking = value;
        }
        internal static bool EnablePlugin()
        {
            EnableTicking = true;
            return true;
        }
        internal static bool DisablePlugin()
        {
            EnableTicking = false;
            P.taskManager.Abort();
            RunRoute = false;
            return true;
        }

        private static bool Yes = false;
        private static bool RunRoute = false;

        internal static void Tick()
        {
            if (AreWeTicking)
            {
                if (GenericThrottle)
                {
                    if (!P.taskManager.IsBusy)
                    {
                        UpdateTableDict();
                        TableSellUpdate(CurrentRouteTable);
                        if (TotalSellItems(CurrentRouteTable) > 0 && !RunRoute)
                        {
                            GroupMammetTask.Enqueue(CurrentRouteTable);
                        }
                        RunRoute = true;

                    }
                }
            }
        }
    }
}
