using ECommons.Logging;
using ExplorersIcebox.Util.PathCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util;

public static class IslandHelper
{
    public static int MaxTotalLoops = 0;
    public static int MinimumPossibleLoops = 999;
    public static int CurrentLoopCount = 0;
    public static KeyValuePair<string, RouteClass.RouteUtil> CurrentRoute;
    public static Dictionary<int, int> SellItems = new();

    public static Vector3 BaseStart = new Vector3(-268, 40, 226);

    public class ItemGathered
    {
        public int Amount { get; set; }
        public int ItemId { get; set; }
        public HashSet<string> GatherNodes { get; set; } = new();
        public bool IgnoreNode { get; set; }
    }

    public static Dictionary<string, ItemGathered> RouteItems = new();
    public static Dictionary<string, HashSet<ItemData.GatheringNode>> ItemNodeMap = new();

    /// <summary>
    /// Returns the maximum amount of loops that you can do for this route in one set.
    /// <para> Used to check/set that your loop counter isn't more than what if feasable.
    /// </para>
    /// </summary>
    /// <param name="loopAmountGathered"></param>
    /// <returns> [Int] Max Loop Amount</returns>
    public static int IslandLoopCalc(int loopAmountGathered)
    {
        if (loopAmountGathered == 0)
            return 0; // safety to make sure that the amount gathered per loop isn't an invalid number

        int MaxLoops = 0; // Initial start of the maximum amount of loops you can do
        int MinItemKeep = C.MinimumItemKeep; // Minimum amount of items you want to keep (global)
        int MaxAmount = 999; // Maximum amount of items that you can gather

        int ItemCap = MaxAmount - MinItemKeep; // 999 - 500 for example, which would make the max gatherable items 499
        MaxLoops = ItemCap / loopAmountGathered; // 499 / 6 for example. 

        return MaxLoops;
    }

    /// <summary>
    /// Check for how many loops in general that is needed
    /// </summary>
    /// <param name="amountWanted"></param>
    /// <param name="loopAmountGathered"></param>
    /// <returns> [Int] Minimum Amount of Loops </returns>
    public static int MinimumLoopCalc(int amountWanted, int loopAmountGathered)
    {
        return (amountWanted + loopAmountGathered - 1) / loopAmountGathered;
    }

    public static int SellAmount(int loopAmount, int amountGathered, int itemId)
    {
        const int itemCap = 999;
        int keepAmount = C.MinimumItemKeep;
        int itemSell = 0;

        if (PlayerHelper.GetItemCount(itemId, out int currentCount))
        {
            int plannedGatherAmount = loopAmount * amountGathered;
            int totalAfterGather = currentCount + plannedGatherAmount;

            if (totalAfterGather > itemCap)
            {
                int excess = totalAfterGather - itemCap;
                int surplus = currentCount - keepAmount;

                // Sell only the excess, but also not below keepAmount
                itemSell = Math.Min(excess, Math.Max(0, surplus));
            }
        }

        return itemSell;
    }

    public static void UpdateNumbers()
    {
        RouteItems.Clear();
        ItemNodeMap.Clear();

        foreach (var wp in CurrentRoute.Value.RouteWaypoints)
        {
            if (wp.TargetId != 0)
            {
                var Node = ItemData.IslandNodeInfo.Where(x => x.Nodes.Contains(wp.TargetId)).FirstOrDefault();
                if (Node != null)
                {
                    foreach (var item in Node.ItemIds)
                    {
                        string itemName = ItemData.IslandItems[item].ItemName;
                        if (!RouteItems.ContainsKey(itemName))
                        {
                            RouteItems[itemName] = new ItemGathered
                            {
                                Amount = 1,
                                ItemId = item,
                                GatherNodes = { Node.GatherName },
                                IgnoreNode = false
                            };
                        }
                        else
                        {
                            RouteItems[itemName].Amount += 1;
                            RouteItems[itemName].GatherNodes.Add(Node.GatherName);
                        }

                        if (!ItemNodeMap.ContainsKey(itemName))
                            ItemNodeMap[itemName] = new();

                        ItemNodeMap[itemName].Add(Node);
                    }
                }
            }
        }

        // Used to update each of the values to check and see what can be ignored
        foreach (var kvp in RouteItems)
        {
            var itemName = kvp.Key;
            var gathered = kvp.Value;

            if (!ItemNodeMap.TryGetValue(itemName, out var nodes)) continue;

            if (nodes.Count <= 1)
            {
                gathered.IgnoreNode = false;
            }
            else
            {
                // Ignore only if ANY of the nodes contains other items too
                gathered.IgnoreNode = nodes.Count > 1 && nodes.All(n => n.ItemIds.Count > 1);
            }
        }

        foreach (var kvp in RouteItems)
        {
            var itemName = kvp.Key;
            var gathered = kvp.Value;

            if (gathered.IgnoreNode)
                continue;
            else
            {
                var AmountWanted = C.ItemGatherAmount[itemName];

                MaxTotalLoops = Math.Max(MaxTotalLoops, MinimumLoopCalc(AmountWanted, gathered.Amount)); // 200 Loops
                MinimumPossibleLoops = Math.Min(MinimumPossibleLoops, IslandLoopCalc(gathered.Amount)); // 65
            }
        }
    }

    public static void UpdateCounters(Dictionary<string, ItemGathered> routeItems)
    {
        MaxTotalLoops = 0;
        MinimumPossibleLoops = 999;

        foreach (var kvp in routeItems)
        {
            var itemName = kvp.Key;
            var gathered = kvp.Value;

            if (gathered.IgnoreNode)
                continue;
            else
            {
                var AmountWanted = C.ItemGatherAmount[itemName];

                MaxTotalLoops = Math.Max(MaxTotalLoops, MinimumLoopCalc(AmountWanted, gathered.Amount));
                MinimumPossibleLoops = Math.Min(MinimumPossibleLoops, IslandLoopCalc(gathered.Amount));
            }
        }
    }

    public static void UpdateShopCallback()
    {
        PluginLog.Debug("- - - Starting to update callbacks - - - ");
        var callback = 0;
        foreach (var item in ItemData.IslandItems)
        {
            if (Utils.IsNodeVisible("MJIPouch", 1, 8, item.Value.NodeId, 2))
            {
                item.Value.SellSlot = callback;
                callback += 1;
                PluginLog.Debug($"Updated {item.Key} | {ItemData.IslandItems[item.Key].ItemName} callback to {item.Value.SellSlot}");
            }
            else
            {
                item.Value.SellSlot = 0;
                PluginLog.Debug($"No value was found for {item.Key}, setting to 0");
            }
        }
    }
}
