using ECommons.Configuration;
using FFXIVClientStructs.FFXIV.Client.Game.MJI;
using Lumina.Excel.Sheets;
using System.Collections.Generic;
using System.Xml.Linq;


namespace ExplorersIcebox.Util.IslandData;

internal class IslandTables
{

    // Values for the Tables below. 
    public class RouteEntry
    {
        public int AmountGatherable { get; set; }
        public ushort ID { get; set; }
        public int Sell { get; set; }
        public bool CanSellFullAmount { get; set; }

        // Optional: Add a constructor for easier initialization
        public RouteEntry(int amountGatherable, ushort id, int sell, bool canSellFullAmount)
        {
            AmountGatherable = amountGatherable;
            ID = id;
            Sell = sell;
            CanSellFullAmount = canSellFullAmount;
        }
    }

    public static class Routes
    {
        // Islefish/Clam | Laver Squid
        public static List<RouteEntry> Route0Table =
        [
            new RouteEntry(8, IslefishID, 0, false),
            new RouteEntry(8, ClamID, 0, false),
            new RouteEntry(4, SquidID, 0, false),
            new RouteEntry(4, LaverID, 0, false),
        ];

        // Islewort (Yes... just Islewort)
        public static List<RouteEntry> Route1Table =
        [
            new RouteEntry(14, IslewortID, 0, false),
        ];

        // Sugarcane/Vine Route
        public static List<RouteEntry> Route2Table =
        [
            new RouteEntry(11, SugarcaneID, 0, false),
            new RouteEntry(11, VineID, 0, false),
        ];

        // Tinsand/Sand Route
        public static List<RouteEntry> Route3Table =
        [
            new RouteEntry(7, TinsandID, 0, false),
            new RouteEntry(7, SandID, 0, false),
            new RouteEntry(4, MarbleID, 0, false),
            new RouteEntry(4, LimestoneID, 0, false),
            new RouteEntry(4, StoneID, 0, false),
        ];

        // Apple/Beehive/Vine Route
        public static List<RouteEntry> Route4Table =
        [
            new RouteEntry(5, AppleID, 0, false),
            new RouteEntry(5, BeehiveID, 0, false),
            new RouteEntry(5, VineID, 0, false),
            new RouteEntry(3, SapID, 0, false),
            new RouteEntry(3, WoodOpalID, 0, false),
            new RouteEntry(2, BranchID, 0, false),
            new RouteEntry(2, ResinID, 0, false),
            new RouteEntry(1, SandID, 0, false),
            new RouteEntry(1, ClayID, 0, false),
            new RouteEntry(5, LogID, 0, false),
        ];

        // Coconut/PalmLog/PalmLeaf
        public static List<RouteEntry> Route5Table =
        [
            new RouteEntry(7, CoconutID, 0, false),
            new RouteEntry(7, PalmLogID, 0, false),
            new RouteEntry(7, PalmLeafID, 0, false),
            new RouteEntry(4, LimestoneID, 0, false),
            new RouteEntry(4, MarbleID, 0, false),
            new RouteEntry(4, StoneID, 0, false),
        ];

        // Cotton Route
        public static List<RouteEntry> Route6Table =
        [
            new RouteEntry(7, CottonID, 0, false),
            new RouteEntry(3, HempID, 0, false),
            new RouteEntry(1, CoconutID, 0, false),
            new RouteEntry(1, PalmLogID, 0, false),
            new RouteEntry(1, PalmLeafID, 0, false),
            new RouteEntry(1, IslewortID, 0, true)
        ];

        // Clay | Sand Route [Ground XP Route]
        public static List<RouteEntry> Route7Table =
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

        // Marble | Limestone | Stone
        public static List<RouteEntry> Route8Table =
        [
            new RouteEntry(7, MarbleID, 0, false),
            new RouteEntry(7, LimestoneID, 0, false),
            new RouteEntry(7, StoneID, 0, false),
            new RouteEntry(1, SugarcaneID, 0, false),
            new RouteEntry(1, VineID, 0, false),
            new RouteEntry(1, CoconutID, 0, false),
            new RouteEntry(1, PalmLeafID, 0, false),
            new RouteEntry(1, PalmLogID, 0, false),
            new RouteEntry(1, TinsandID, 0, false),
            new RouteEntry(1, SandID, 0, false),
            new RouteEntry(1, HempID, 0, false),
            new RouteEntry(1, IslewortID, 0, false),
        ];

        // Branch | Sap | Log
        public static List<RouteEntry> Route9Table =
        [
            new RouteEntry(8, BranchID, 0, false),
            new RouteEntry(8, ResinID, 0, false),
            new RouteEntry(1, SapID, 0, false),
            new RouteEntry(1, WoodOpalID, 0, false),
            new RouteEntry(2, ClayID, 0, false),
            new RouteEntry(2, SandID, 0, false),
            new RouteEntry(9, LogID, 0, true),
        ];

        // Copper | Mythril
        public static List<RouteEntry> Route10Table =
        [
            new RouteEntry(7, CopperID, 0, false),
            new RouteEntry(7, MythrilOreID, 0, false),
            new RouteEntry(7, StoneID, 0, false),
            new RouteEntry(2, HempID, 0, false),
            new RouteEntry(1, CoconutID, 0, false),
            new RouteEntry(1, PalmLogID, 0, false),
            new RouteEntry(1, PalmLeafID, 0, false),
            new RouteEntry(1, CottonID, 0, false),
            new RouteEntry(3, IslewortID, 0, false),
        ];

        // Opal | Sap | (Log)
        public static List<RouteEntry> Route11Table =
        [
            new RouteEntry(8, SapID, 0, false),
            new RouteEntry(8, WoodOpalID, 0, false),
            new RouteEntry(8, LogID, 0, false),
            new RouteEntry(1, HempID, 0, false),
            new RouteEntry(3, IslewortID, 0, false),
        ];

        //Hemp
        public static List<RouteEntry> Route12Table =
        [
            new RouteEntry(9, HempID, 0, false),
            new RouteEntry(9, IslewortID, 0, false),
            new RouteEntry(1, SandID, 0, false),
            new RouteEntry(1, ClayID, 0, false),
            new RouteEntry(1, CoconutID, 0, false),
            new RouteEntry(1, PalmLogID, 0, false),
            new RouteEntry(1, PalmLeafID, 0, false),
        ];

        // Multicolorblooms
        public static List<RouteEntry> Route13Table =
        [
            new RouteEntry(4, MulticoloredIslebloomsID, 0, false),
            new RouteEntry(4, QuartzID, 0, false),
            new RouteEntry(2, IronOreID, 0, false),
            new RouteEntry(2, DuriumSandID, 0, false),
            new RouteEntry(1, LeucograniteID, 0, false),
            new RouteEntry(7, StoneID, 0, true),
        ];

        // Iron Ore | Durium Sand
        public static List<RouteEntry> Route14Table =
        [
            new RouteEntry(11, IronOreID, 0, false),
            new RouteEntry(11, DuriumSandID, 0, false),
            new RouteEntry(11, StoneID, 0, false),
        ];

        // Laver | Squid / Jellyfish | Coral
        public static List<RouteEntry> Route15Table =
        [
            new RouteEntry(6, LaverID, 0, false),
            new RouteEntry(6, SquidID, 0, false),
            new RouteEntry(6, JellyfishID, 0, false),
            new RouteEntry(6, CoralID, 0, false),
        ];

        // Rocksalt
        public static List<RouteEntry> Route16Table =
        [
            new RouteEntry(6, RockSaltID, 0, false),
            new RouteEntry(6, StoneID, 0, false),
            new RouteEntry(2, ClayID, 0, false),
            new RouteEntry(2, SandID, 0, false),
            new RouteEntry(3, IslewortID, 0, false),
            new RouteEntry(3, HempID, 0, false),
        ];

        // Leucogranite
        public static List<RouteEntry> Route17Table =
        [
            new RouteEntry(7, LeucograniteID, 0, false),
            new RouteEntry(2, CopperID, 0, false),
            new RouteEntry(2, MythrilOreID, 0, false),
            new RouteEntry(2, IronOreID, 0, false),
            new RouteEntry(2, DuriumSandID, 0, false),
            new RouteEntry(11, StoneID, 0, true),
        ];

        //Quartz Route [Flying XP Route]
        public static List<RouteEntry> Route18Table =
        [
            new RouteEntry(6, QuartzID, 0, false),
            new RouteEntry(3, IronOreID, 0, false),
            new RouteEntry(3, DuriumSandID, 0, false),
            new RouteEntry(2, LeucograniteID, 0, false),
            new RouteEntry(11, StoneID, 0, true),
        ];

        // Glimshroom | Shale / Coal 
        public static List<RouteEntry> Route19Table =
        [
            new RouteEntry(8, GlimshroomID, 0, false),
            new RouteEntry(8, ShaleID, 0, false),
            new RouteEntry(8, CoalID, 0, false),
            new RouteEntry(8, StoneID, 0, false),
        ];

        // Effervescent Water / Spectrine
        public static List<RouteEntry> Route20Table =
        [
            new RouteEntry(10, EffervescentWaterID, 0, false),
            new RouteEntry(10, SpectrineID, 0, false),
            new RouteEntry(1, ShaleID, 0, false),
            new RouteEntry(1, CoalID, 0, false),
            new RouteEntry(11, StoneID, 0, true),
        ];

        // Yellow Copper Ore / Gold Ore | Crystal Formation | HawksEyeSand
        public static List<RouteEntry> Route21Table =
        [
            new RouteEntry(4, YellowCopperOreID, 0, false),
            new RouteEntry(4, GoldOreID, 0, false),
            new RouteEntry(4, CrystalFormationID, 0, false),
            new RouteEntry(4, HawksEyeSandID, 0, false),
            new RouteEntry(1, GlimshroomID, 0, false),
            new RouteEntry(1, EffervescentWaterID, 0, false),
            new RouteEntry(1, SpectrineID, 0, false),
            new RouteEntry(1, ShaleID, 0, false),
            new RouteEntry(1, CoalID, 0, false),
            new RouteEntry(6, StoneID, 0, true),
        ];
    }

    // Dictionary for items, contains the Workshop amount + ItemID
    public class ItemData
    {
        public required string Name { get; set; }
        public int Workshop { get; set; }
        public int Amount { get; set; }
        public int Callback { get; set; }
        public int NodeID { get; set; } // the node that it's checking to see if you have items (/tweaks debug for this)
    }

    public static Dictionary<int, ItemData> IslandItemDict = new()
    {
        { PalmLeafID, new ItemData { Name = "Palm Leaf", Workshop = 0, Amount = GetItemCount(PalmLeafID), Callback = 0, NodeID = 10 } },
        { BranchID, new ItemData { Name = "Branch", Workshop = 0, Amount = GetItemCount(BranchID), Callback = 1, NodeID = 100001 } },
        { StoneID, new ItemData { Name = "Stone", Workshop = 0, Amount = GetItemCount(StoneID), Callback = 2, NodeID = 100002 } },
        { ClamID, new ItemData { Name = "Clam", Workshop = 0, Amount = GetItemCount(ClamID), Callback = 3, NodeID = 100003 } },
        { LaverID, new ItemData { Name = "Laver", Workshop = 0, Amount = GetItemCount(LaverID), Callback = 4, NodeID = 100004 } },
        { CoralID, new ItemData { Name = "Coral", Workshop = 0, Amount = GetItemCount(CoralID), Callback = 5, NodeID = 100005 } },
        { IslewortID, new ItemData { Name = "Islewort", Workshop = 0, Amount = GetItemCount(IslewortID), Callback = 6, NodeID = 100006 } },
        { SandID, new ItemData { Name = "Sand", Workshop = 0, Amount = GetItemCount(SandID), Callback = 7, NodeID = 100007 } },
        { VineID, new ItemData { Name = "Vine", Workshop = 0, Amount = GetItemCount(VineID), Callback = 8, NodeID = 100008 } },
        { SapID, new ItemData { Name = "Sap", Workshop = 0, Amount = GetItemCount(SapID), Callback = 9, NodeID = 100009 } },
        { AppleID, new ItemData { Name = "Apple", Workshop = 0, Amount = GetItemCount(AppleID), Callback = 10, NodeID = 100010 } },
        { LogID, new ItemData {Name = "Log", Workshop = 0, Amount = GetItemCount(LogID), Callback = 11, NodeID = 100011 } },
        { PalmLogID, new ItemData {Name = "Palm Log", Workshop = 0, Amount = GetItemCount(PalmLogID), Callback = 12, NodeID = 100012 } },
        { CopperID, new ItemData {Name = "Copper", Workshop = 0, Amount = GetItemCount(CopperID), Callback = 13, NodeID = 100013 } },
        { LimestoneID, new ItemData {Name = "Limestone", Workshop = 0, Amount = GetItemCount(LimestoneID), Callback = 14, NodeID = 100014 } },
        { RockSaltID, new ItemData {Name = "Rock Salt", Workshop = 0, Amount = GetItemCount(RockSaltID), Callback = 15, NodeID = 100015 } },
        { ClayID, new ItemData {Name = "Clay", Workshop = 0, Amount = GetItemCount(ClayID), Callback = 16, NodeID = 100016 } },
        { TinsandID, new ItemData {Name = "Tinsand", Workshop = 0, Amount = GetItemCount(TinsandID), Callback = 17, NodeID = 100017 } },
        { SugarcaneID, new ItemData {Name = "Sugarcane", Workshop = 0, Amount = GetItemCount(SugarcaneID), Callback = 18, NodeID = 100018 } },
        { CottonID, new ItemData {Name = "Cotton", Workshop = 0, Amount = GetItemCount(CottonID), Callback = 19, NodeID = 100019 } },
        { HempID, new ItemData {Name = "Hemp", Workshop = 0, Amount = GetItemCount(HempID), Callback = 20, NodeID = 100020 } },
        { IslefishID, new ItemData {Name = "Islefish", Workshop = 0, Amount = GetItemCount(IslefishID), Callback = 21, NodeID = 100021 } },
        { SquidID, new ItemData {Name = "Squid", Workshop = 0, Amount = GetItemCount(SquidID), Callback = 22, NodeID = 100022 } },
        { JellyfishID, new ItemData {Name = "Jellyfish", Workshop = 0, Amount = GetItemCount(JellyfishID), Callback = 23, NodeID = 100023 } },
        { IronOreID, new ItemData {Name = "Iron Ore", Workshop = 0, Amount = GetItemCount(IronOreID), Callback = 24, NodeID = 100024 } },
        { QuartzID, new ItemData {Name = "Quartz", Workshop = 0, Amount = GetItemCount(QuartzID), Callback = 25, NodeID = 100025 } },
        { LeucograniteID, new ItemData {Name = "Leucogranite",  Workshop = 0, Amount = GetItemCount(LeucograniteID), Callback = 26, NodeID = 100026 } },
        { MulticoloredIslebloomsID, new ItemData {Name = "Multicolored Isleblooms", Workshop = 0, Amount = GetItemCount(MulticoloredIslebloomsID), Callback = 27, NodeID = 100027 } },
        { ResinID, new ItemData {Name = "Resin", Workshop = 0, Amount = GetItemCount(ResinID), Callback = 28, NodeID = 100028 } },
        { CoconutID, new ItemData {Name = "Coconut", Workshop = 0, Amount = GetItemCount(CoconutID), Callback = 29, NodeID = 100029 } },
        { BeehiveID, new ItemData {Name = "Beehive", Workshop = 0, Amount = GetItemCount(BeehiveID), Callback = 30, NodeID = 100030 } },
        { WoodOpalID, new ItemData {Name = "Wood Opal", Workshop = 0, Amount = GetItemCount(WoodOpalID), Callback = 31, NodeID = 100031 } },
        { CoalID, new ItemData {Name = "Coal", Workshop = 0, Amount = GetItemCount(CoalID), Callback = 32, NodeID = 100032 } },
        { GlimshroomID, new ItemData {Name = "Glimshroom", Workshop = 0, Amount = GetItemCount(GlimshroomID), Callback = 33, NodeID = 100033 } },
        { EffervescentWaterID, new ItemData {Name = "Effervesent Water", Workshop = 0, Amount = GetItemCount(EffervescentWaterID), Callback = 34, NodeID = 100034 } },
        { ShaleID, new ItemData {Name = "Shale", Workshop = 0, Amount = GetItemCount(ShaleID), Callback = 35, NodeID = 100035 } },
        { MarbleID, new ItemData {Name = "Marble", Workshop = 0, Amount = GetItemCount(MarbleID), Callback = 36, NodeID = 100036 } },
        { MythrilOreID, new ItemData {Name = "Mythril", Workshop = 0, Amount = GetItemCount(MythrilOreID), Callback = 37, NodeID = 100037 } },
        { SpectrineID, new ItemData {Name = "Spectrine", Workshop = 0, Amount = GetItemCount(SpectrineID), Callback = 38, NodeID = 100038 } },
        { DuriumSandID, new ItemData {Name = "Durium", Workshop = 0, Amount = GetItemCount(DuriumSandID), Callback = 39, NodeID = 100039 } },
        { YellowCopperOreID, new ItemData {Name = "Yellow Copper Ore", Workshop = 0, Amount = GetItemCount(YellowCopperOreID), Callback = 40, NodeID = 100040 } },
        { GoldOreID, new ItemData {Name = "Gold Ore",  Workshop = 0, Amount = GetItemCount(GoldOreID), Callback = 41, NodeID = 100041 } },
        { HawksEyeSandID, new ItemData {Name = "Hawks Eye Sand", Workshop = 0, Amount = GetItemCount(HawksEyeSandID), Callback = 42, NodeID = 100042 } },
        { CrystalFormationID, new ItemData {Name = "Crystal Formation", Workshop = 0, Amount = GetItemCount(CrystalFormationID), Callback = 43, NodeID = 100043 } },
    };

    // quick way to access everything for routes
    public class GatheringPointData
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Base64Export { get; set; }
        public bool GatherRoute { get; set; }
    }

    // Routes 1-7, 9-18, 20-22 still need to be properly updated, This is just setting up the basework so i can go back and edit this after...
    public static Dictionary<int, GatheringPointData> RouteDataPoint = new Dictionary<int, GatheringPointData>
    {
        { 0, new GatheringPointData {Name = "Clam | Islefish", Location = Base2Clam, Base64Export = ClamVisland, GatherRoute = C.Route0} },
        { 1, new GatheringPointData {Name = "Islewort", Location = Base2Islewort, Base64Export = IslewortVisland, GatherRoute = C.Route1} },
        { 2, new GatheringPointData {Name = "Sugarcane | Vine", Location = Base2Sugarcane, Base64Export = SugarcaneVisland, GatherRoute = C.Route2} },
        { 3, new GatheringPointData {Name = "Tinsand | Sand", Location = Base2Ttinsand, Base64Export = TinsandVisland, GatherRoute = C.Route3} },
        { 4, new GatheringPointData {Name = "Apple| Beehive | Vine", Location = Base2Apple, Base64Export = AppleVisland, GatherRoute = C.Route4} },
        { 5, new GatheringPointData {Name = "Coconut | Palm Log | Palm Leaf", Location = Base2Coconut, Base64Export = CoconutVisland, GatherRoute = C.Route5} },
        { 6, new GatheringPointData {Name = "Cotton", Location = Base2Cotton, Base64Export = CottonVisland, GatherRoute = C.Route6} },
        { 7, new GatheringPointData {Name = "Clay | Sand [Ground XP Loop]", Location = Base2Clay, Base64Export = ClayVisland, GatherRoute = C.Route7} }, // done
        { 8, new GatheringPointData {Name = "Marble | Limestone | (Stone)", Location = Base2Marble, Base64Export = MarbleVisland, GatherRoute = C.Route8} },
        { 9, new GatheringPointData {Name = "Branch | Resin | (Log)", Location = Base2Branch, Base64Export = BranchVisland, GatherRoute = C.Route9} },
        { 10, new GatheringPointData {Name = "Copper / Mythril", Location = Base2Copper, Base64Export = CopperVisland, GatherRoute = C.Route10} },
        { 11, new GatheringPointData {Name = "Opal / Log / Sap", Location = Base2Opal, Base64Export = OpalVisland, GatherRoute = C.Route11} },
        { 12, new GatheringPointData {Name = "Hemp", Location = Base2Hemp, Base64Export = HempVisland, GatherRoute = C.Route12} },
        { 13, new GatheringPointData {Name = "Multicolored Isleblooms", Location = Base2MultiColor, Base64Export = MulticoloredVisland, GatherRoute = C.Route13} },
        { 14, new GatheringPointData {Name = "Iron Ore", Location = Base2Iron, Base64Export = IronVisland, GatherRoute = C.Route14} },
        { 15, new GatheringPointData {Name = "Laver / Squid | Jellyfish / Coral", Location = Base2Laver, Base64Export = LaverJellyfishVisland, GatherRoute = C.Route15} },
        { 16, new GatheringPointData {Name = "Rocksalt", Location = Base2RockSalt, Base64Export = RocksaltVisland, GatherRoute = C.Route16} },
        { 17, new GatheringPointData {Name = "Leucogranite", Location = Base2Leucogranite, Base64Export = LeucograniteVisland, GatherRoute = C.Route17} },
        { 18, new GatheringPointData {Name = "Quartz [Mountain XP Loop]", Location = Base2Quartz, Base64Export = QuartzVisland, GatherRoute = C.Route18} }, // done
        { 19, new GatheringPointData {Name = "Coal / Shale | Glimshroom", Location = Base2Glimshroom, Base64Export = CoalVisland, GatherRoute = C.Route19} },
        { 20, new GatheringPointData {Name = "Effervescent Water", Location = Base2Water, Base64Export = WaterVisland, GatherRoute = C.Route20} },
        { 21, new GatheringPointData {Name = "Crystal / Hawk Sand | Yelow Copper / Gold Ore", Location = Base2Crystal, Base64Export = CrystalVisland, GatherRoute = C.Route21} },
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
            var itemAmount = IslandItemDict[itemID].Amount;
            var itemWorkshop = IslandItemDict[itemID].Workshop;

            // Update the sell amount
            entry.Sell = ShopCalc(itemAmount, itemWorkshop, itemPerLoop, routeTotal, itemSellSafe);
            PluginLog($"Item sell amount has been updated to: {entry.Sell}");
        }
    }

    public static void GatherAllUpdate()
    {
        RouteDataPoint[0].GatherRoute = C.Route0;
        RouteDataPoint[1].GatherRoute = C.Route1;
        RouteDataPoint[2].GatherRoute = C.Route2;
        RouteDataPoint[3].GatherRoute = C.Route3;
        RouteDataPoint[4].GatherRoute = C.Route4;
        RouteDataPoint[5].GatherRoute = C.Route5;
        RouteDataPoint[6].GatherRoute = C.Route6;
        RouteDataPoint[7].GatherRoute = C.Route7;
        RouteDataPoint[8].GatherRoute = C.Route8;
        RouteDataPoint[9].GatherRoute = C.Route9;
        RouteDataPoint[10].GatherRoute = C.Route10;
        RouteDataPoint[11].GatherRoute = C.Route11;
        RouteDataPoint[12].GatherRoute = C.Route12;
        RouteDataPoint[13].GatherRoute = C.Route13;
        RouteDataPoint[14].GatherRoute = C.Route14;
        RouteDataPoint[15].GatherRoute = C.Route15;
        RouteDataPoint[16].GatherRoute = C.Route16;
        RouteDataPoint[17].GatherRoute = C.Route17;
        RouteDataPoint[18].GatherRoute = C.Route18;
        RouteDataPoint[19].GatherRoute = C.Route19;
        RouteDataPoint[20].GatherRoute = C.Route20;
        RouteDataPoint[21].GatherRoute = C.Route21;
        EzConfig.Save();
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
        0 => Routes.Route0Table,
        1 => Routes.Route1Table,
        2 => Routes.Route2Table,
        3 => Routes.Route3Table,
        4 => Routes.Route4Table,
        5 => Routes.Route5Table,
        6 => Routes.Route6Table,
        7 => Routes.Route7Table,
        8 => Routes.Route8Table,
        9 => Routes.Route9Table,
        10 => Routes.Route10Table,
        11 => Routes.Route11Table,
        12 => Routes.Route12Table,
        13 => Routes.Route13Table,
        14 => Routes.Route14Table,
        15 => Routes.Route15Table,
        16 => Routes.Route16Table,
        17 => Routes.Route17Table,
        18 => Routes.Route18Table,
        19 => Routes.Route19Table,
        20 => Routes.Route20Table,
        21 => Routes.Route21Table,
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

    // For Gathering Every Item, checks to see what routes are set to true. And then outputs the value
    public static int? CheckGatherRoutes(Dictionary<int, GatheringPointData> routeDataPoint, out bool allFalse)
    {
        allFalse = true; // Start assuming all are false

        foreach (var kvp in routeDataPoint)
        {
            if (kvp.Value.GatherRoute)
            {
                allFalse = false; // Found at least one true value
                return kvp.Key;   // Return the key where GatherRoute is true
            }
        }
        return null; // If none are true, return null
    }
}
