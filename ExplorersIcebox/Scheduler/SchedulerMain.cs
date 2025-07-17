using ECommons.Throttlers;
using ExplorersIcebox.Enums;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Ui.DebugWindowTabs;
using ExplorersIcebox.Util;
using static ExplorersIcebox.Enums.IceBoxState;

namespace ExplorersIcebox.Scheduler
{
    internal static unsafe class SchedulerMain
    {
        internal static bool EnablePlugin()
        {
            IslandHelper.CurrentLoopCount = 0;
            State = Start;
            return true;
        }
        internal static bool DisablePlugin()
        {
            IslandHelper.CurrentLoopCount = 0;
            P.taskManager.Abort();
            P.navmesh.Stop();
            State = Idle;
            return true;
        }

        internal static IceBoxState State = Idle;

        internal static void Tick()
        {
            if (Throttles.GenericThrottle && P.taskManager.NumQueuedTasks == 0 && State != Idle)
            {
                switch (State)
                {
                    case IceBoxState.Start:
                        Task_ReturnToBase.Enqueue();
                        break;
                    case IceBoxState.CheckSell:
                        Task_SellCheck.Enqueue();
                        Task_UpdateShop.Enqueue();
                        break;
                    case IceBoxState.SellToNpc:
                        Svc.Log.Information($"NPC Sell State Active");
                        Task_SellItems.Enqueue();
                        break;
                    case IceBoxState.RunRoute:
                        Svc.Log.Information("Run Route State");
                        TaskGatherLoop.Enqueue();
                        break;
                    default:
                        Svc.Log.Information("Route has been completed, stopping");
                        DisablePlugin();
                        break;
                }
            }
        }
    }
}
