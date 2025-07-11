using ExplorersIcebox.Util;
using System.Collections.Generic;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_SellCheck
    {
        internal static bool SellToShop = false;

        public static void Enqueue()
        {
            P.taskManager.Enqueue(() => SellCheck());
        }

        internal static void SellCheck()
        {
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
                SchedulerMain.State = Enums.IceBoxState.RunRoute;
            }
            else if (C.DryTest)
            {
                SchedulerMain.State = Enums.IceBoxState.Idle;
            }
            else
            {
                SchedulerMain.State = Enums.IceBoxState.NPCSell;
            }
                
        }
    }
}
