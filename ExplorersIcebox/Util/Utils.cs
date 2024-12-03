using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Types;
using ECommons.Automation.NeoTaskManager;
using ECommons.GameHelpers;
using ECommons.Reflection;
using ECommons.Throttlers;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI;
using System.Collections.Generic;

namespace ExplorersIcebox.Util;

public static unsafe class Utils
{
    public static bool PluginInstalled(string name)
    {
        return DalamudReflector.TryGetDalamudPlugin(name, out _, false, true);
    }

    public static unsafe int GetItemCount(int itemID, bool includeHq = true)
        => includeHq ? InventoryManager.Instance()->GetInventoryItemCount((uint)itemID, true) 
        + InventoryManager.Instance()->GetInventoryItemCount((uint)itemID) + InventoryManager.Instance()->GetInventoryItemCount((uint)itemID + 500_000)
        : InventoryManager.Instance()->GetInventoryItemCount((uint)itemID) + InventoryManager.Instance()->GetInventoryItemCount((uint)itemID + 500_000);

    public static bool ExecuteTeleport(uint aetheryteId) => UIState.Instance()->Telepo.Teleport(aetheryteId, 0);
    internal static unsafe float GetDistanceToPlayer(Vector3 v3) => Vector3.Distance(v3, Player.GameObject->Position);
    internal static unsafe float GetDistanceToPlayer(IGameObject gameObject) => GetDistanceToPlayer(gameObject.Position);
    internal static IGameObject? GetObjectByName(string name) => Svc.Objects.OrderBy(GetDistanceToPlayer).FirstOrDefault(o => o.Name.TextValue.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    public static float GetDistanceToPoint(float x, float y, float z) => Vector3.Distance(Svc.ClientState.LocalPlayer?.Position ?? Vector3.Zero, new Vector3(x, y, z));
    public static float GetDistanceToPointV(Vector3 targetPoint) => Vector3.Distance(Svc.ClientState.LocalPlayer?.Position ?? Vector3.Zero, targetPoint);
    private static readonly unsafe nint PronounModule = (nint)Framework.Instance()->GetUIModule()->GetPronounModule();
    private static readonly unsafe delegate* unmanaged<nint, uint, GameObject*> getGameObjectFromPronounID = (delegate* unmanaged<nint, uint, GameObject*>)Svc.SigScanner.ScanText("E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 0F 85 ?? ?? ?? ?? 8D 4F DD");
    public static unsafe GameObject* GetGameObjectFromPronounID(uint id) => getGameObjectFromPronounID(PronounModule, id);
    public static bool IsBetweenAreas => (Svc.Condition[ConditionFlag.BetweenAreas] || Svc.Condition[ConditionFlag.BetweenAreas51]);
    internal static bool GenericThrottle => FrameThrottler.Throttle("AutoRetainerGenericThrottle", 10);
    public static TaskManagerConfiguration DConfig => new(timeLimitMS: 10 * 60 * 1000, abortOnTimeout: false);

    public static void PluginLog(string message) => ECommons.Logging.PluginLog.Information(message);

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

    public static float GetPlayerRawXPos(string character = "")
    {
        if (!character.IsNullOrEmpty())
        {
            unsafe
            {
                if (int.TryParse(character, out var p))
                {
                    var go = Utils.GetGameObjectFromPronounID((uint)(p + 42));
                    return go != null ? go->Position.X : -1;
                }
                else return Svc.Objects.Where(x => x.IsTargetable).FirstOrDefault(x => x.Name.ToString().Equals(character))?.Position.X ?? -1;
            }
        }
        return Svc.ClientState.LocalPlayer!.Position.X;
    }

    public static float GetPlayerRawYPos(string character = "")
    {
        if (!character.IsNullOrEmpty())
        {
            unsafe
            {
                if (int.TryParse(character, out var p))
                {
                    var go = Utils.GetGameObjectFromPronounID((uint)(p + 42));
                    return go != null ? go->Position.Y : -1;
                }
                else return Svc.Objects.Where(x => x.IsTargetable).FirstOrDefault(x => x.Name.ToString().Equals(character))?.Position.Y ?? -1;
            }
        }
        return Svc.ClientState.LocalPlayer!.Position.Y;
    }

    public static float GetPlayerRawZPos(string character = "")
    {
        if (!character.IsNullOrEmpty())
        {
            unsafe
            {
                if (int.TryParse(character, out var p))
                {
                    var go = Utils.GetGameObjectFromPronounID((uint)(p + 42));
                    return go != null ? go->Position.Z : -1;
                }
                else return Svc.Objects.Where(x => x.IsTargetable).FirstOrDefault(x => x.Name.ToString().Equals(character))?.Position.Z ?? -1;
            }
        }
        return Svc.ClientState.LocalPlayer!.Position.Z;
    }

    // Calulators for Island Sanctuary Routes

    public static void UpdateTableDict()
    {
        foreach (var item in IslandSancDictionary.Keys.ToList())
        {
            IslandSancDictionary[item].Amount = GetItemCount(item);
        }
    }
}
