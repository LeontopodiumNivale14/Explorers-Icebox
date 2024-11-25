using Dalamud.Game.ClientState.Conditions;
using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.Sheets;

namespace IslandLeveling.Scheduler.Handers;

internal static unsafe class PlayerHandlers
{
    internal static bool? PlayerMounted()
    {
        if (Svc.Data.GetExcelSheet<TerritoryType>()?.GetRow(Player.Territory).Unknown4 != 0)
        {
            if (Svc.Condition[ConditionFlag.Mounted] && Util.Utils.PlayerNotBusy()) return true;
            if (!Svc.Condition[ConditionFlag.Casting] && !Svc.Condition[ConditionFlag.Unknown57])
            {
                ActionManager.Instance()->UseAction(ActionType.GeneralAction, 24);
            }
        }

        return false;
    }
}
