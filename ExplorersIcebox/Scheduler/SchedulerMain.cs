using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Scheduler.Tasks.GroupTask;
using ExplorersIcebox.Util.IslandData;

namespace ExplorersIcebox.Scheduler
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
            LoopAmount = 0;
            CurrentLoop = 0;
            UpdatedShop = false;
            return true;
        }
        internal static bool DisablePlugin()
        {
            EnableTicking = false;
            P.taskManager.Abort();
            P.visland.StopRoute();
            P.navmesh.Stop();
            return true;
        }
        private static int LoopAmount = 0;
        private static int CurrentLoop = 0;
        internal static string CurrentProcess = "";
        internal static bool UpdatedShop = false;

        internal static void Tick()
        {
            if (AreWeTicking)
            {
                if (GenericThrottle)
                {
                    if (!P.taskManager.IsBusy)
                    {
                        if (!UpdatedShop && !C.everythingUnlocked)
                        {
                            TaskUpdateShopID.Enqueue();
                            UpdatedShop = true;
                        }
                        else
                        {
                            if (C.runInfinite || (!C.runInfinite && C.runAmount > CurrentLoop))
                            {
                                LoopAmount = 0;
                                if (!atEntrance)
                                    TaskReturn.Enqueue();
                                UpdateTableDict();
                                TableSellUpdate(currentTable);
                                if (TotalSellItems(currentTable) > 0)
                                {
                                    GroupMammetTask.Enqueue(currentTable);
                                }
                                TaskVislandTemp.Enqueue(RouteDataPoint[C.routeSelected].Location, RouteDataPoint[C.routeSelected].Name);
                                while (LoopAmount < RouteAmount(C.routeSelected))
                                {
                                    P.taskManager.Enqueue(() => CurrentProcess = $"Running Visland Route. On {LoopAmount} / {RouteAmount(C.routeSelected)}");
                                    TaskVislandTemp.Enqueue(RouteDataPoint[C.routeSelected].Base64Export, $"Enabling the following Route: {RouteDataPoint[C.routeSelected].Name}");
                                    P.taskManager.EnqueueDelay(100);
                                    P.taskManager.Enqueue(() => P.visland.IsRouteRunning() == false, $"{RouteDataPoint[C.routeSelected].Name} is currently running", configuration: DConfig);
                                    LoopAmount++;
                                }
                                P.taskManager.Enqueue(() => PluginLog("A full cycle has been completed!"));
                                CurrentLoop = CurrentLoop + 1;
                            }
                            else
                            {
                                DisablePlugin();
                            }
                        }
                    }
                }
            }
        }
    }
}
