using ExplorersIcebox.Util;

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
            CurrentLoop = 0;
            UpdatedShop = false;
            return true;
        }
        internal static bool DisablePlugin()
        {
            EnableTicking = false;
            P.taskManager.Abort();
            P.navmesh.Stop();
            return true;
        }
        private static int CurrentLoop = 0;
        internal static string CurrentProcess = "";
        internal static bool UpdatedShop = false;
        internal static bool WorkshopSelected = true;

        internal static void Tick()
        {
            if (AreWeTicking)
            {
                if (Throttles.GenericThrottle)
                {

                }
            }
        }
    }
}
