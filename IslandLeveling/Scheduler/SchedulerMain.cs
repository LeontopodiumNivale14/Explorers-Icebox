using ECommons.Throttlers;
using IslandLeveling.Scheduler.Handers;
using IslandLeveling.Scheduler.Tasks;

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
            return true;
        }

        private static bool Yes = false;
        internal static void Tick()
        {
            if (AreWeTicking)
            {
                if (GenericThrottle)
                {
                    if (!P.taskManager.IsBusy)
                    {
                        if (!atEntrance)
                        {
                            if (EzThrottler.Throttle("Return to base?", 5000))
                            {
                                TaskReturn.Enqueue();
                                PluginLog("Just a test... to see if this works properly");
                            }
                        }
                    }
                }
            }
        }
    }
}
