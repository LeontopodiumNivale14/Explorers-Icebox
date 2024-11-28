using Dalamud.Game.ClientState.Conditions;
using ECommons.Throttlers;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace IslandLeveling.Scheduler.Handers;

internal static unsafe class PlayerHandlers
{
    // Mounting up on... well a mount. 
    internal static bool? MountUp()
    {
        if (Svc.Condition[ConditionFlag.Mounted] && PlayerNotBusy()) return true;

        if (CurrentTerritory() == 1055)
        {
            if (!Svc.Condition[ConditionFlag.Casting] && !Svc.Condition[ConditionFlag.Unknown57])
            {
                ActionManager.Instance()->UseAction(ActionType.GeneralAction, 24);
            }
        }
        return false;
    }

    internal static bool? InteractObject(uint dataID)
    {
        uint npc_ID = dataID;
        if (Service.ObjectTable.TryGetFirst(e => e.DataId == dataID, out var obj))
        {
            if (TargetSystem.Instance()->Target == (GameObject*)obj.Address)
            {
                TargetSystem.Instance()->InteractWithObject((GameObject*)obj.Address);
                return true;
            }
            if (EzThrottler.Throttle($"Interact + {npc_ID}", 100))
            {
                TargetSystem.Instance()->Target = (GameObject*)obj.Address;
                return false;
            }
        }
        return false;
    }
}
