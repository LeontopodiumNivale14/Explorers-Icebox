using ECommons.Throttlers;
using IslandLeveling.Scheduler.Handers;
using IslandLeveling.Scheduler.Tasks;
using IslandLeveling.Scheduler.Tasks.GroupTask;
using IslandLeveling.Util.IslandData;
using Lumina.Excel.Sheets;
using System.Linq.Expressions;

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

        private static bool RunRoute = false;
        private static int LoopAmount = 0;

        internal static void Tick()
        {
            if (AreWeTicking)
            {
                if (GenericThrottle)
                {
                    if (!P.taskManager.IsBusy)
                    {
                        UpdateTableDict();
                        TableSellUpdate(currentTable);
                        if (TotalSellItems(currentTable) > 0 && !RunRoute)
                        {
                            GroupMammetTask.Enqueue(currentTable);
                        }
                        P.taskManager.Enqueue(() => RunRoute = true);
                        if (RunRoute)
                        {
                            TaskVislandTemp.Enqueue(RouteDataPoint[C.routeSelected].Location, RouteDataPoint[C.routeSelected].Name);
                            while (LoopAmount < RouteAmount(C.routeSelected))
                            {
                                TaskVislandTemp.Enqueue(VislandRoutes.QuartzVisland, $"{RouteDataPoint[C.routeSelected].Name}'s Route is running currently");
                                LoopAmount++;
                            }
                            P.taskManager.Enqueue(() => RunRoute = false, "Changing Runroute to false");
                            P.taskManager.Enqueue(() => PluginLog("Setting Run Route to false"));
                        }

                    }
                }
            }
        }
    }
}
