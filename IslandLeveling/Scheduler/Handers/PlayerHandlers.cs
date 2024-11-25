using Dalamud.Game.ClientState.Conditions;
using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.Sheets;

namespace IslandLeveling.Scheduler.Handers;

internal static unsafe class PlayerHandlers
{

    // Mounting up on... well a mount. 
    internal static bool? MountUp()
    {
        if (Svc.Condition[ConditionFlag.Mounted]) return true;

        if (!Svc.Condition[ConditionFlag.Casting] && !Svc.Condition[ConditionFlag.Unknown57])
        {
            unsafe { ActionManager.Instance()->UseAction(ActionType.GeneralAction, 24);}
        }
        return false;
    }
}
