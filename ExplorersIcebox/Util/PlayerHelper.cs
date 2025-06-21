using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Types;
using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util;

public class PlayerHelper
{
    public static bool IsInZone(uint zoneID) => Svc.ClientState.TerritoryType == zoneID;
    public static unsafe uint CurrentTerritory() => GameMain.Instance()->CurrentTerritoryTypeId;

    public static bool IsBetweenAreas => Svc.Condition[ConditionFlag.BetweenAreas] || Svc.Condition[ConditionFlag.BetweenAreas51];

    public static bool IsPlayerNotBusy()
    {
        return Player.Available
               && Player.Object.CastActionId == 0
               && !GenericHelpers.IsOccupied()
               && !Player.IsJumping
               && Player.Object.IsTargetable
               && !Player.IsAnimationLocked;
    }

    public static unsafe float GetDistanceToPlayer(Vector3 v3) => Vector3.Distance(v3, Player.GameObject->Position);
    public static unsafe float GetDistanceToPlayer(IGameObject gameObject) => GetDistanceToPlayer(gameObject.Position);

    public static unsafe bool GetItemCount(int itemID, out int count, bool includeHq = true, bool includeNq = true)
    {
        try
        {
            itemID = itemID >= 1_000_000 ? itemID - 1_000_000 : itemID;
            count = 0;
            if (includeHq)
                count += InventoryManager.Instance()->GetInventoryItemCount((uint)itemID, true);
            if (includeNq)
                count += InventoryManager.Instance()->GetInventoryItemCount((uint)itemID, false);
            count += InventoryManager.Instance()->GetInventoryItemCount((uint)itemID + 500_000);
            return true;
        }
        catch
        {
            count = 0;
            return false;
        }
    }
}
