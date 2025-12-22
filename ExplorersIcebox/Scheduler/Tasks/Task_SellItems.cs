using Dalamud.Game.ClientState.Objects.Types;
using ECommons.Automation;
using ECommons.Throttlers;
using ECommons.UIHelpers.AddonMasterImplementations;
using ExplorersIcebox.Util;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Collections.Generic;
using Callback = ECommons.Automation.Callback;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_SellItems
    {
        public static void Enqueue()
        {
            var baseDict = EmbedRoutes.BaseRoutes["Base -> Shopkeep"];
            List<Vector3> waypoints = baseDict.Waypoints;
            ulong dataId = baseDict.TargetId;

            P.taskManager.Enqueue(() => MoveToNpc(waypoints), "Moving to NPC");
            P.taskManager.Enqueue(() => TargetV2(dataId), $"Target task: {dataId}");
            P.taskManager.Enqueue(() => InteractShopKeep(dataId), "Interacting w/ the material seller vendor");
            P.taskManager.Enqueue(() => SellToNpcV2(), "Selling all the items to the npc");
            P.taskManager.EnqueueDelay(16, true);
            P.taskManager.Enqueue(() => LeaveNPC(waypoints), "Leaving the NPC");
        }

        internal static bool? MoveToNpc(List<Vector3> List)
        {
            // Insert the logic here post return to move to NPC
            var LastWP = List.Count - 1;
            if (PlayerHelper.GetDistanceToPlayer(List[LastWP]) < 0.5f)
            {
                return true;
            }
            else
            {
                if (!P.navmesh.IsRunning())
                {
                    if (EzThrottler.Throttle("Telling navmesh to move to spot"))
                    {
                        P.navmesh.MoveTo(new List<Vector3>(List), false);
                    }
                }
            }

            return false;
        }

        internal static unsafe bool? InteractShopKeep(ulong dataId)
        {
            if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIDisposeShop", out var mjiShop) && IsAddonReady(mjiShop))
            {
                return true;
            }
            else if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("SelectString", out var menu) && IsAddonReady(menu))
            {
                if (EzThrottler.Throttle("Selecting Export Materials"))
                {
                    Callback.Fire(menu, true, 0);
                }
            }
            else
            {
                IGameObject? gameObject = null;
                Utils.TryGetObjectByDataId(dataId, out gameObject);
                if (EzThrottler.Throttle($"Interacting w/ shop seller {dataId}"))
                {
                    Utils.InteractWithObject(gameObject);
                }
            }

            return false;
        }

        internal static bool? TargetV2(ulong dataId)
        {
            IGameObject? gameObject = null;
            var currentTarget = Svc.Targets.Target?.GameObjectId ?? 0;
            Utils.TryGetObjectByDataId(dataId, out gameObject);

        #if DEBUG
            Svc.Log.Debug($"GameObject == Null? [GameObject Doesn't exist]: {gameObject == null}");
            if (gameObject != null)
            {
                Svc.Log.Debug($"Gameobject is current target: {gameObject.IsTarget()}");
                Svc.Log.Debug($"GameObject is targetable: {gameObject.IsTargetable}");

            }
        #endif

            if (gameObject == null || gameObject.IsTarget() || !gameObject.IsTargetable)
            {
                return true;
            }
            else if (gameObject != null)
            {
                if (EzThrottler.Throttle($"Targeting: {dataId}"))
                {
                #if DEBUG
                    Svc.Log.Debug($"Targeting: {gameObject.Name}");
                #endif
                    Utils.TargetgameObject(gameObject);
                }
            }

            return false;
        }

        internal static unsafe bool? SellToNpc(int itemId, int sellAmount)
        {
            var callback = ItemData.IslandItems[itemId].SellSlot;

            if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIDisposeShopShipping", out var mjiShip))
            {
                if (EzThrottler.Throttle($"Selling {itemId} | Amount: {sellAmount}"))
                    Callback.Fire(mjiShip, true, 11, sellAmount);

                return true;
            }
            else if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIDisposeShop", out var mjiShop))
            {
                if (EzThrottler.Throttle($"Interacting with {itemId} shop sell"))
                    Callback.Fire(mjiShop, true, 12, callback);
            }

            return false;
        }

        internal static bool? SellToNpcV2()
        {
            foreach (var item in IslandHelper.SellItems)
            {
                var itemId = item.Key;
                var sellAmount = item.Value;
                if (ItemData.AlwaysIgnoreSell.Contains(itemId))
                { continue; }
                if (sellAmount == 0)
                    continue;

                if (TryToSellItem(itemId, sellAmount))
                    return false;
            }

            return true;
        }

        private static unsafe bool TryToSellItem(int itemId, int amount)
        {
            if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIDisposeShopShipping", out var mjiShip) && GenericHelpers.IsAddonReady(mjiShip))
            {
                if (EzThrottler.Throttle($"Selling {itemId}"))
                {
                    Callback.Fire(mjiShip, true, 11, amount);
                    IslandHelper.SellItems[itemId] = 0;
                }
                return true;
            }
            else if (GenericHelpers.TryGetAddonMaster<MJIDisposeShop>("MJIDisposeShop", out var mjiShop) && mjiShop.IsAddonReady)
            {
                var itemName = OnPluginLoad.IslandItemInfo[itemId];
                var entry = mjiShop.ExportItems.Where(x => x.Name == itemName).FirstOrDefault();
                if (EzThrottler.Throttle("Selecting the item to ship", 1500))
                {
                    if (entry != null)
                        entry.Select();
                }
                return true;
            }

            return false;
        }

        internal static unsafe bool? WaitForSell()
        {
            if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIDisposeShopShipping", out var mjiShip))
            {
                if (!GenericHelpers.IsAddonReady(mjiShip))
                    return true;
            }

            return false;
        }

        internal static unsafe bool? LeaveNPC(List<Vector3> List)
        {
            var LastWP = List.Count - 1;
            if (PlayerHelper.GetDistanceToPlayer(IslandHelper.BaseStart) < 0.5f)
            {
                Svc.Log.Information("Leave NPC will complete after this");
                SchedulerMain.State = Enums.IceBoxState.RunRoute;
                return true;
            }
            else if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIDisposeShop", out var mjiShop) && IsAddonReady(mjiShop))
            {
                if (EzThrottler.Throttle("Closing shop"))
                    Callback.Fire(mjiShop, true, 1);
                return false;
            }
            else if (!P.navmesh.IsRunning())
            {
                List<Vector3> reverseWp = new(List);

                reverseWp.Reverse();

                if (EzThrottler.Throttle("Telling navmesh to move to spot"))
                {
                    P.navmesh.MoveTo(new List<Vector3>(reverseWp), false);
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
