using Dalamud.Game.ClientState.Conditions;
using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game;
using IslandLeveling.Scheduler.Handers;
using System.Runtime.CompilerServices;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskReturn
    {
        internal unsafe static void Enqueue()
        {
            P.taskManager.Enqueue(() => ReturntoBase(), "Returning to base");
        }
        internal unsafe static bool? ReturntoBase()
        {
            if (atEntrance && PlayerNotBusy()) return true;

            if (CurrentTerritory() == 1055 && !atEntrance)
            {
                if (!Svc.Condition[ConditionFlag.Casting] && !IsBetweenAreas)
                {
                    ActionManager.Instance()->UseAction(ActionType.GeneralAction, 27);
                }
            }
            return false;
        }
    }
}
