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
                if (!P.taskManager.IsBusy)
                {
                    TaskMountUp.Enqueue();
                    if (!Yes)
                    {
                        // more code that can be ran here. Justt need to figure out what...
                    }
                }
            }
        }
    }
}
