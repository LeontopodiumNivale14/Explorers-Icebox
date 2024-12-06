using System.Collections.Generic;
using System.Xml.Linq;

namespace ExplorersIcebox.Util.IslandData;

internal class IslandTables
{

    // Values for the Tables below. 
    public class RouteEntry
    {
        public int AmountGatherable { get; set; }
        public int ID { get; set; }
        public int Sell { get; set; }
        public bool CanSellFullAmount { get; set; }

        // Optional: Add a constructor for easier initialization
        public RouteEntry(int amountGatherable, int id, int sell, bool canSellFullAmount)
        {
            AmountGatherable = amountGatherable;
            ID = id;
            Sell = sell;
            CanSellFullAmount = canSellFullAmount;
        }
    }

    public static class Routes
    {
        // Clay | Sand Route [Ground XP Route]
        public static List<RouteEntry> Route8Table =
        [
            new RouteEntry(7, ClayID, 0, false),
            new RouteEntry(2, TinsandID, 0, false),
            new RouteEntry(1, MarbleID, 0, false),
            new RouteEntry(1, LimestoneID, 0, false),
            new RouteEntry(1, StoneID, 0, false),
            new RouteEntry(1, BranchID, 0, false),
            new RouteEntry(1, LogID, 0, false),
            new RouteEntry(1, ResinID, 0, false),
            new RouteEntry(1, SugarcaneID, 0, false),
            new RouteEntry(1, VineID, 0, false),
            new RouteEntry(10, SandID, 0, true),
        ];

        //Quartz Route [Flying XP Route]
        public static List<RouteEntry> Route19Table =
        [
            new RouteEntry(6, QuartzID, 0, false),
            new RouteEntry(3, IronOreID, 0, false),
            new RouteEntry(3, DuriumSandID, 0, false),
            new RouteEntry(2, LeucograniteID, 0, false),
            new RouteEntry(11, StoneID, 0, true),
        ];
    }

    // Dictionary for items, contains the Workshop amount + ItemID
    public class ItemData
    {
        public int Workshop { get; set; }
        public int Amount { get; set; }
        public int Callback { get; set; }
    }

    public static Dictionary<int, ItemData> IslandSancDictionary = new()
    {
        { PalmLeafID, new ItemData { Workshop = C.PalmLeafWorkshop, Amount = GetItemCount(PalmLeafID), Callback = 0 } },
        { BranchID, new ItemData { Workshop = C.BranchWorkshop, Amount = GetItemCount(BranchID), Callback = 1 } },
        { StoneID, new ItemData { Workshop = C.StoneWorkshop, Amount = GetItemCount(StoneID), Callback = 2 } },
        { ClamID, new ItemData { Workshop = C.ClamWorkshop, Amount = GetItemCount(ClamID), Callback = 3 } },
        { LaverID, new ItemData { Workshop = C.LaverWorkshop, Amount = GetItemCount(LaverID), Callback = 4 } },
        { CoralID, new ItemData { Workshop = C.CoralWorkshop, Amount = GetItemCount(CoralID), Callback = 5 } },
        { IslewortID, new ItemData { Workshop = C.IslewortWorkshop, Amount = GetItemCount(IslewortID), Callback = 6 } },
        { SandID, new ItemData { Workshop = C.SandWorkshop, Amount = GetItemCount(SandID), Callback = 7 } },
        { VineID, new ItemData { Workshop = C.VineWorkshop, Amount = GetItemCount(VineID), Callback = 8 } },
        { SapID, new ItemData { Workshop = C.SapWorkshop, Amount = GetItemCount(SapID), Callback = 9 } },
        { AppleID, new ItemData { Workshop = C.AppleWorkshop, Amount = GetItemCount(AppleID), Callback = 10 } },
        { LogID, new ItemData { Workshop = C.LogWorkshop, Amount = GetItemCount(LogID), Callback = 11 } },
        { PalmLogID, new ItemData { Workshop = C.PalmLogWorkshop, Amount = GetItemCount(PalmLogID), Callback = 12 } },
        { CopperID, new ItemData { Workshop = C.CopperWorkshop, Amount = GetItemCount(CopperID), Callback = 13 } },
        { LimestoneID, new ItemData { Workshop = C.LimestoneWorkshop, Amount = GetItemCount(LimestoneID), Callback = 14 } },
        { RockSaltID, new ItemData { Workshop = C.RockSaltWorkshop, Amount = GetItemCount(RockSaltID), Callback = 15 } },
        { ClayID, new ItemData { Workshop = C.ClayWorkshop, Amount = GetItemCount(ClayID), Callback = 16 } },
        { TinsandID, new ItemData { Workshop = C.TinsandWorkshop, Amount = GetItemCount(TinsandID), Callback = 17 } },
        { SugarcaneID, new ItemData { Workshop = C.SugarcaneWorkshop, Amount = GetItemCount(SugarcaneID), Callback = 18 } },
        { CottonID, new ItemData { Workshop = C.CottonWorkshop, Amount = GetItemCount(CottonID), Callback = 19 } },
        { HempID, new ItemData { Workshop = C.HempWorkshop, Amount = GetItemCount(HempID), Callback = 20 } },
        { IslefishID, new ItemData { Workshop = C.IslefishWorkshop, Amount = GetItemCount(IslefishID), Callback = 21 } },
        { SquidID, new ItemData { Workshop = C.SquidWorkshop, Amount = GetItemCount(SquidID), Callback = 22 } },
        { JellyfishID, new ItemData { Workshop = C.JellyfishWorkshop, Amount = GetItemCount(JellyfishID), Callback = 23 } },
        { IronOreID, new ItemData { Workshop = C.IronOreWorkshop, Amount = GetItemCount(IronOreID), Callback = 24 } },
        { QuartzID, new ItemData { Workshop = C.QuartzWorkshop, Amount = GetItemCount(QuartzID), Callback = 25 } },
        { LeucograniteID, new ItemData { Workshop = C.LeucograniteWorkshop, Amount = GetItemCount(LeucograniteID), Callback = 26 } },
        { MulticoloredIslebloomsID, new ItemData { Workshop = C.MulticoloredIslebloomsWorkshop, Amount = GetItemCount(MulticoloredIslebloomsID), Callback = 27 } },
        { ResinID, new ItemData { Workshop = C.ResinWorkshop, Amount = GetItemCount(ResinID), Callback = 28 } },
        { CoconutID, new ItemData { Workshop = C.CoconutWorkshop, Amount = GetItemCount(CoconutID), Callback = 29 } },
        { BeehiveID, new ItemData { Workshop = C.BeehiveWorkshop, Amount = GetItemCount(BeehiveID), Callback = 30 } },
        { WoodOpalID, new ItemData { Workshop = C.WoodOpalWorkshop, Amount = GetItemCount(WoodOpalID), Callback = 31 } },
        { CoalID, new ItemData { Workshop = C.CoalWorkshop, Amount = GetItemCount(CoalID), Callback = 32 } },
        { GlimshroomID, new ItemData { Workshop = C.GlimshroomWorkshop, Amount = GetItemCount(GlimshroomID), Callback = 33 } },
        { EffervescentWaterID, new ItemData { Workshop = C.EffervescentWaterWorkshop, Amount = GetItemCount(EffervescentWaterID), Callback = 34 } },
        { ShaleID, new ItemData { Workshop = C.ShaleWorkshop, Amount = GetItemCount(ShaleID), Callback = 35 } },
        { MarbleID, new ItemData { Workshop = C.MarbleWorkshop, Amount = GetItemCount(MarbleID), Callback = 36 } },
        { MythrilOreID, new ItemData { Workshop = C.MythrilOreWorkshop, Amount = GetItemCount(MythrilOreID), Callback = 37 } },
        { SpectrineID, new ItemData { Workshop = C.SpectrineWorkshop, Amount = GetItemCount(SpectrineID), Callback = 38 } },
        { DuriumSandID, new ItemData { Workshop = C.DuriumSandWorkshop, Amount = GetItemCount(DuriumSandID), Callback = 39 } },
        { YellowCopperOreID, new ItemData { Workshop = C.YellowCopperOreWorkshop, Amount = GetItemCount(YellowCopperOreID), Callback = 40 } },
        { GoldOreID, new ItemData { Workshop = C.GoldOreWorkshop, Amount = GetItemCount(GoldOreID), Callback = 41 } },
        { HawksEyeSandID, new ItemData { Workshop = C.HawksEyeSandWorkshop, Amount = GetItemCount(HawksEyeSandID), Callback = 42 } },
        { CrystalFormationID, new ItemData { Workshop = C.CrystalFormationWorkshop, Amount = GetItemCount(CrystalFormationID), Callback = 43 } },
    };

    // quick way to access everything for routes
    public class GatheringPointData
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Base64Export { get; set; }
    }

    // Routes 1-7, 9-18, 20-22 still need to be properly updated, This is just setting up the basework so i can go back and edit this after...
    public static Dictionary<int, GatheringPointData> RouteDataPoint = new Dictionary<int, GatheringPointData>
    {
        { 1, new GatheringPointData {Name = "Clam/Islefish", Location = DummyVisland, Base64Export = DummyVisland} },
        { 2, new GatheringPointData {Name = "Islewort", Location = DummyVisland, Base64Export = DummyVisland} },
        { 3, new GatheringPointData {Name = "Sugarcane", Location = DummyVisland, Base64Export = DummyVisland} },
        { 4, new GatheringPointData {Name = "Tinsand", Location = DummyVisland, Base64Export = DummyVisland} },
        { 5, new GatheringPointData {Name = "Coconut", Location = DummyVisland, Base64Export = DummyVisland} },
        { 6, new GatheringPointData {Name = "Apple", Location = DummyVisland, Base64Export = DummyVisland} },
        { 7, new GatheringPointData {Name = "Marble | Limestone", Location = DummyVisland, Base64Export = DummyVisland} },
        { 8, new GatheringPointData {Name = "Clay | Sand [Ground XP Loop]", Location = Base2Clay, Base64Export = ClayVisland} }, // done
        { 9, new GatheringPointData {Name = "Cotton", Location = DummyVisland, Base64Export = DummyVisland} },
        { 10, new GatheringPointData {Name = "Branch | Log | Resin", Location = DummyVisland, Base64Export = DummyVisland} },
        { 11, new GatheringPointData {Name = "Copper / Mythril", Location = DummyVisland, Base64Export = DummyVisland} },
        { 12, new GatheringPointData {Name = "Opal / Log / Sap", Location = DummyVisland, Base64Export = DummyVisland} },
        { 13, new GatheringPointData {Name = "Hemp", Location = DummyVisland, Base64Export = DummyVisland} },
        { 14, new GatheringPointData {Name = "Multicolored Isleblooms", Location = DummyVisland, Base64Export = DummyVisland} },
        { 15, new GatheringPointData {Name = "Iron Ore", Location = DummyVisland, Base64Export = DummyVisland} },
        { 16, new GatheringPointData {Name = "Laver / Squid | Jellyfish / Coral", Location = DummyVisland, Base64Export = DummyVisland} },
        { 17, new GatheringPointData {Name = "Rocksalt", Location = DummyVisland, Base64Export = DummyVisland} },
        { 18, new GatheringPointData {Name = "Leucogranite", Location = DummyVisland, Base64Export = DummyVisland} },
        { 19, new GatheringPointData {Name = "Quartz [Mountain XP Loop]", Location = Base2Quartz, Base64Export = QuartzVisland} }, // done
        { 20, new GatheringPointData {Name = "Coal / Shale | Glimshroom", Location = DummyVisland, Base64Export = DummyVisland} },
        { 21, new GatheringPointData {Name = "Effervescent Water", Location = DummyVisland, Base64Export = DummyVisland} },
        { 22, new GatheringPointData {Name = "Crystal / Hawk Sand | Yelow Copper / Gold Ore[x2]", Location = DummyVisland, Base64Export = DummyVisland} },
    };

    public static int RouteAmountCalc(List<RouteEntry> routeEntries, params int[] workshops)
    {
        var CurrentMax = 999; // Ceiling to always start at

        for (var i = 0; i < routeEntries.Count; i++) // Iterate through the entries
        {
            var itemPerLoop = routeEntries[i].AmountGatherable;
            var workshopKeep = workshops[i];
            var canSkip = routeEntries[i].CanSellFullAmount; // Assuming this replaces 'skip'

            // Calculate the loop amount
            if (!canSkip) // If the route cannot skip
            {
                var NewMax = CalculateRouteLoopAmount(workshopKeep, itemPerLoop);
                if (NewMax < CurrentMax) CurrentMax = NewMax;
            }
        }

        return CurrentMax;
    }

    public static void TableSellUpdate(List<RouteEntry> routeEntries)
    {
        foreach (var entry in routeEntries)
        {
            var itemPerLoop = entry.AmountGatherable;
            var itemID = entry.ID;
            var sellAmount = entry.Sell;
            var itemSellSafe = entry.CanSellFullAmount;
            var routeTotal = RouteAmount(C.routeSelected); // Ensure RouteAmount is updated for new structure
            var itemAmount = IslandSancDictionary[itemID].Amount;
            var itemWorkshop = IslandSancDictionary[itemID].Workshop;

            // Update the sell amount
            entry.Sell = ShopCalc(itemAmount, itemWorkshop, itemPerLoop, routeTotal, itemSellSafe);
            PluginLog($"Item sell amount has been updated to: {entry.Sell}");
        }
    }

    public static int TotalSellItems(List<RouteEntry> routeEntries)
    {
        int totalSellItems = 0;
        foreach (var entry in routeEntries)
        {
            if (entry.Sell > 0)
            {
                totalSellItems += entry.Sell;
            }
        }
        return totalSellItems;
    }
    
    public static List<RouteEntry> currentTable => C.routeSelected switch
    {
        8 => Routes.Route8Table,
        19 => Routes.Route19Table,
        _ => throw new InvalidOperationException("Invalid table index")
    };

    public static int ShopCalc(int itemAmount, int workshopKeep, int loopItemAmount, int loopAmount, bool itemSellSafe)
    {
        var amountGathered = (loopItemAmount * loopAmount);
        if (amountGathered > 999) amountGathered = 999;
        var newAmount = MaxItems - amountGathered;
        var itemSend = itemAmount - newAmount;
        if (itemSellSafe == true)
        {
            itemSend = itemSend - workshopKeep;
        }
        return itemSend;
    }

    public static int CalculateRouteLoopAmount(int workshopKeep, int itemPerLoop)
    {
        var baseMaxLoop = (int)Math.Floor((double)MaxItems / itemPerLoop); // Maximum loops possible
        if (workshopKeep > 0)
        {
            var workshopKeepItems = MaxItems - workshopKeep; // Items available after reserving workshop items
            var adjustedLoops = (int)Math.Floor((double)workshopKeepItems / itemPerLoop); // Adjusted loops possible
            return Math.Max(0, adjustedLoops); // Ensure result is not negative
        }
        else
        {
            return baseMaxLoop; // No workshop items, return base loops
        }
    }
}
