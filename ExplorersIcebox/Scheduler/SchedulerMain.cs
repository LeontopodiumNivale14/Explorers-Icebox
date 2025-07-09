using ExplorersIcebox.Enums;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using static ExplorersIcebox.Enums.IceBoxState;

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
            State = Start;
            return true;
        }
        internal static bool DisablePlugin()
        {
            EnableTicking = false;
            P.taskManager.Abort();
            P.navmesh.Stop();
            return true;
        }

        internal static IceBoxState State = Idle;

        internal static void Tick()
        {
            if (Throttles.GenericThrottle && P.taskManager.Tasks.Count == 0 && State != Idle)
            {
                switch (State)
                {
                    case var s when s.HasFlag(Start):
                        Task_ReturnToBase.Enqueue();
                        break;
                    case var s when s.HasFlag(CheckSell):

                        break;
                    default:

                        break;
                }
            }
        }
    }
}
