using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Types;
using ECommons.GameHelpers;
using ECommons.Reflection;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace IslandLeveling.Util;

public static unsafe class Utils
{
    public static bool PluginInstalled(string name)
    {
        return DalamudReflector.TryGetDalamudPlugin(name, out _, false, true);
    }

    public static unsafe int GetItemCount(int itemID, bool includeHq = true)
        => includeHq ? InventoryManager.Instance()->GetInventoryItemCount((uint)itemID, true) + InventoryManager.Instance()->GetInventoryItemCount((uint)itemID) + InventoryManager.Instance()->GetInventoryItemCount((uint)itemID + 500_000)
               : InventoryManager.Instance()->GetInventoryItemCount((uint)itemID) + InventoryManager.Instance()->GetInventoryItemCount((uint)itemID + 500_000);
    public static bool ExecuteTeleport(uint aetheryteId) => UIState.Instance()->Telepo.Teleport(aetheryteId, 0);
    internal static unsafe float GetDistanceToPlayer(Vector3 v3) => Vector3.Distance(v3, Player.GameObject->Position);
    internal static unsafe float GetDistanceToPlayer(IGameObject gameObject) => GetDistanceToPlayer(gameObject.Position);
    internal static IGameObject? GetObjectByName(string name) => Svc.Objects.OrderBy(GetDistanceToPlayer).FirstOrDefault(o => o.Name.TextValue.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    public static float GetDistanceToPoint(float x, float y, float z) => Vector3.Distance(Svc.ClientState.LocalPlayer?.Position ?? Vector3.Zero, new Vector3(x, y, z));

    public static bool PlayerNotBusy()
    {
        return Player.Available
               && Player.Object.CastActionId == 0
               && !IsOccupied()
               && !Svc.Condition[ConditionFlag.Jumping]
               && Player.Object.IsTargetable;
    }

    public static (ulong id, Vector3 pos) FindAetheryte(uint id)
    {
        foreach (var obj in GameObjectManager.Instance()->Objects.IndexSorted)
            if (obj.Value != null && obj.Value->ObjectKind == ObjectKind.Aetheryte && obj.Value->BaseId == id)
                return (obj.Value->GetGameObjectId(), *obj.Value->GetPosition());
        return (0, default);
    }

    public static GameObject* LPlayer() => GameObjectManager.Instance()->Objects.IndexSorted[0].Value;

    public static Vector3 PlayerPosition()
    {
        var player = LPlayer();
        return player != null ? player->Position : default;
    }

    public static uint CurrentTerritory() => GameMain.Instance()->CurrentTerritoryTypeId;

    public static bool IsAddonActive(string AddonName) // Used to see if the addon is active/ready to be fired on
    {
        var addon = RaptureAtkUnitManager.Instance()->GetAddonByName(AddonName);
        return addon != null && addon->IsVisible && addon->IsReady;
    }

    // Calulators for Island Sanctuary Routes

    // How many items are you sending for this loop?
    public static int ShopCalc(int itemAmount, int workshopKeep, int loopItemAmount, int loopAmount, int itemSellSafe)
    {
        var routeGathAmount = MaxItems - (loopItemAmount * loopAmount); // Calculate RouteGathAmount

        if (routeGathAmount < 0) routeGathAmount = 0; // Ensure RouteGathAmount doesn't go below 0

        var itemSend = itemAmount - routeGathAmount; // Calculate ItemSend based on RouteGathAmount

        if (itemSend > MaxItems) itemSend = MaxItems; // Ensure ItemSend does not exceed ItemMax

        if (itemSellSafe == 1) itemSend -= workshopKeep; // Adjust ItemSend if ItemSellSafe is true (aka, if you can sell to workshop amount and be fine)

        return itemSend; // Return the calculated value
    }

    // Calcuator for how many loops you're doing for this route
    private static int CalculateRouteLoopAmount(int workshopKeep, int itemPerLoop, int maxAmount)
    {
        // Calculate the base maximum loop
            // baseMax =  999/6
        var baseMaxLoop = maxAmount / itemPerLoop;

        // Calculate the adjusted route loop amount
           // 6 > 0 
        if (workshopKeep > 0)
        {

            var workshopKeepLoop = (int)Math.Ceiling((double)workshopKeep / itemPerLoop);
            return baseMaxLoop = baseMaxLoop - workshopKeepLoop;
        }
        else
        {
            // If no workshop items, return the base loop amount
            return baseMaxLoop;
        }
    }

    public static int RouteAmountCalc(int[,] table, params int[] workshops)
    {
        var CurrentMax = 999;

        for (var i = 0; i < table.GetLength(0); i++) // Iterate through rows
        {
            var itemMax = MaxItems;
            var itemPerLoop = table[i, 0];
            var workshopKeep = workshops[i];
            var skip = table[i, 4];

            // Calculate the loop amount
            if (skip == 0) 
            {
                var NewMax = CalculateRouteLoopAmount(workshopKeep, itemPerLoop, itemMax);
                if (NewMax < CurrentMax) CurrentMax = NewMax;
            }
        }

        return CurrentMax;
    }
}
