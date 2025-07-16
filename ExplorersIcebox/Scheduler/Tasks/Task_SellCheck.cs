using ExplorersIcebox.Util;
using System.Collections.Generic;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_SellCheck
    {
        internal static bool SellToShop = false;

        public static void Enqueue()
        {
            P.taskManager.Enqueue(() => SellCheck(), "Checking if need to sell to vendor");
        }

        internal static bool? SellCheck()
        {
            Svc.Log.Information("Starting Sell Check");
            IslandHelper.SellItems.Clear();
            SellToShop = false;
            int LoopCount = Math.Min(IslandHelper.MaxTotalLoops, IslandHelper.MinimumPossibleLoops);
            LoopCount = LoopCount - IslandHelper.CurrentLoopCount;

            IslandHelper.UpdateNumbers();
            foreach (var item in IslandHelper.RouteItems)
            {
                if (item.Value.IgnoreNode == true)
                    continue;

                string itemName = item.Key;
                int gatherAmount = IslandHelper.RouteItems[itemName].Amount;
                int itemId = item.Value.ItemId;

                int ItemSell = IslandHelper.SellAmount(LoopCount, gatherAmount, itemId);
                if (ItemSell > 0)
                {
                    IslandHelper.SellItems.Add(itemId, ItemSell);
                    SellToShop = true;
                }
            }

            if (C.SkipSell || !SellToShop)
            {
                Svc.Log.Debug($"Skip Sell Enabled? {C.SkipSell}");
                Svc.Log.Debug($"Sell to Shop? {SellToShop}");
                Svc.Log.Debug($"Changing state to run route");
                SchedulerMain.State = Enums.IceBoxState.RunRoute;
            }
            else if (SellToShop)
            {
                Svc.Log.Debug($"Items were found to be sold, swapping to NPC Sell");
                SchedulerMain.State = Enums.IceBoxState.SellToNpc;
            }
            else if (C.DryTest)
            {
                Svc.Log.Debug("Dry test was enabled, switching back to idle mode");
                SchedulerMain.State = Enums.IceBoxState.Idle;
            }
            else
            {
                Svc.Log.Debug("this shouldn't of happen. Swapping to idle");
                SchedulerMain.State = Enums.IceBoxState.Idle;
            }

            Svc.Log.Information($"Sell check is complete. State is: {SchedulerMain.State}");
            return true;
        }
    }
}
