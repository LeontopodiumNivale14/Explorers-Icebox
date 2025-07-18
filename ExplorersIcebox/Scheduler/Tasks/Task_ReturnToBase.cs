using ECommons.GameHelpers;
using ECommons.Throttlers;
using FFXIVClientStructs.FFXIV.Client.Game;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_ReturnToBase
    {
        public static void Enqueue()
        {
            P.taskManager.Enqueue(() => TeleportCheck(), "Returning to base");
        }

        internal unsafe static bool? TeleportCheck()
        {
            if (Player.DistanceTo(new Vector3(-268, 40, 226)) < 5)
            {
                Svc.Log.Debug("Teleport has completed, moving onto check sell");
                SchedulerMain.State = Enums.IceBoxState.CheckSell;
                return true;
            }
            else
            {
                if (!Player.IsBusy)
                {
                    if (EzThrottler.Throttle("Returning to base"))
                    {
                        Svc.Log.Information("Launching action to return to base");
                        ActionManager.Instance()->UseAction(ActionType.GeneralAction, 27);
                    }
                }
            }

            return false;
        }
    }
}
