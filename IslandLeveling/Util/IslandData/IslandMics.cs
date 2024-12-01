using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using System.Collections.Generic;

namespace IslandLeveling.Util.IslandData;

public class IslandMics
{
    //NPC ID's
    public const uint Baldin = 1043621; // NPC that leads to the IS
    public const uint ExportMammet = 3758096384; // Exports Mammet, used to trade your items -> Cowries

    //Test bool 
    public static bool CanFly = false;
    public static bool atEntrance => (GetDistanceToPointV(workshopEntrance) <= 5);

    // Table selection

    public static object table => GetTable(C.routeSelected);

    public static object GetTable(int tableNumber)
    {
        return tableNumber switch
        {
            8 => Route8Table,// Ground XP Route, great for starting out/if you don't have flying unlocked
            19 => Route19Table,// Flying Required | Best XP per hour
            _ => throw new ArgumentException("Invalid number. Not sure how you got this but..."),
        };
    }

    public static int RouteAmount(int routeSelected)
    {
        return routeSelected switch
        {
            8 => Route8Amount,
            19 => Route19Amount,
            _ => 0
        };
    }

    //This is the current cap of items on Island Sanctuary Items, just so I can quickly pull it at all times
    public const int MaxItems = 999;

    // Route Loop Amounts
    public static int Route8Amount => RouteAmountCalc(Route8Table, C.ClayWorkshop, C.TinsandWorkshop, C.MarbleWorkshop, C.LimestoneWorkshop, C.BranchWorkshop, C.LogWorkshop, C.ResinWorkshop, 0);
    public static int Route19Amount => RouteAmountCalc(Route19Table, C.QuartzWorkshop, C.IronOreWorkshop, C.DuriumSandWorkshop, C.LeucograniteWorkshop, 0);

    // Tables to be used for Island Sanctuary information

    // Route Tables
    // Has: Amount Gathered | ID | Sell | Can sell to full amount (true/false)      | Pcall value
    //                                  | 1 = true (skip in calcuation) : 0 = false |
    public static int[,] Route8Table = new[,] // GroundXP Route
    {
        { 7, ClayID, 0, 0, 1},
        { 2, TinsandID, 0, 0, 3},
        { 1, MarbleID, 0, 0, 4},
        { 1, LimestoneID, 0, 0, 5},
        { 1, BranchID, 0, 0, 6},
        { 1, LogID, 0, 0, 7},
        { 1, ResinID, 0, 0, 8},
        { 10, SandID, 0, 1, 9},
    };
    public static int[,] Route19Table = new[,] // FlyingXP Route
    {
        { 6, QuartzID, 0, 0, 25},
        { 3, IronOreID, 0, 0, 24},
        { 3, DuriumSandID, 0, 0, 39},
        { 2, LeucograniteID, 0, 0, 26},
        { 11, StoneID, 0, 1, 3}
    };

    public class ItemData
    {
        public int Workshop { get; set; }
        public int Amount { get; set; }
    }

    public static Dictionary<int, ItemData> IslandSancDictionary = new()
    {
        { PalmLeafID, new ItemData { Workshop = C.PalmLeafWorkshop, Amount = GetItemCount(PalmLeafID) } },
        { BranchID, new ItemData { Workshop = C.BranchWorkshop, Amount = GetItemCount(BranchID) } },
        { StoneID, new ItemData { Workshop = C.StoneWorkshop, Amount = GetItemCount(StoneID) } },
        { ClamID, new ItemData { Workshop = C.ClamWorkshop, Amount = GetItemCount(ClamID) } },
        { LaverID, new ItemData { Workshop = C.LaverWorkshop, Amount = GetItemCount(LaverID) } },
        { CoralID, new ItemData { Workshop = C.CoralWorkshop, Amount = GetItemCount(CoralID) } },
        { IslewortID, new ItemData { Workshop = C.IslewortWorkshop, Amount = GetItemCount(IslewortID) } },
        { SandID, new ItemData { Workshop = C.SandWorkshop, Amount = GetItemCount(SandID) } },
        { VineID, new ItemData { Workshop = C.VineWorkshop, Amount = GetItemCount(VineID) } },
        { SapID, new ItemData { Workshop = C.SapWorkshop, Amount = GetItemCount(SapID) } },
        { AppleID, new ItemData { Workshop = C.AppleWorkshop, Amount = GetItemCount(AppleID) } },
        { LogID, new ItemData { Workshop = C.LogWorkshop, Amount = GetItemCount(LogID) } },
        { PalmLogID, new ItemData { Workshop = C.PalmLogWorkshop, Amount = GetItemCount(PalmLogID) } },
        { CopperID, new ItemData { Workshop = C.CopperWorkshop, Amount = GetItemCount(CopperID) } },
        { LimestoneID, new ItemData { Workshop = C.LimestoneWorkshop, Amount = GetItemCount(LimestoneID) } },
        { RockSaltID, new ItemData { Workshop = C.RockSaltWorkshop, Amount = GetItemCount(RockSaltID) } },
        { ClayID, new ItemData { Workshop = C.ClayWorkshop, Amount = GetItemCount(ClayID) } },
        { TinsandID, new ItemData { Workshop = C.TinsandWorkshop, Amount = GetItemCount(TinsandID) } },
        { SugarcaneID, new ItemData { Workshop = C.SugarcaneWorkshop, Amount = GetItemCount(SugarcaneID) } },
        { CottonID, new ItemData { Workshop = C.CottonWorkshop, Amount = GetItemCount(CottonID) } },
        { HempID, new ItemData { Workshop = C.HempWorkshop, Amount = GetItemCount(HempID) } },
        { IslefishID, new ItemData { Workshop = C.IslefishWorkshop, Amount = GetItemCount(IslefishID) } },
        { SquidID, new ItemData { Workshop = C.SquidWorkshop, Amount = GetItemCount(SquidID) } },
        { JellyfishID, new ItemData { Workshop = C.JellyfishWorkshop, Amount = GetItemCount(JellyfishID) } },
        { IronOreID, new ItemData { Workshop = C.IronOreWorkshop, Amount = GetItemCount(IronOreID) } },
        { QuartzID, new ItemData { Workshop = C.QuartzWorkshop, Amount = GetItemCount(QuartzID) } },
        { LeucograniteID, new ItemData { Workshop = C.LeucograniteWorkshop, Amount = GetItemCount(LeucograniteID) } },
        { MulticoloredIslebloomsID, new ItemData { Workshop = C.MulticoloredIslebloomsWorkshop, Amount = GetItemCount(MulticoloredIslebloomsID) } },
        { ResinID, new ItemData { Workshop = C.ResinWorkshop, Amount = GetItemCount(ResinID) } },
        { CoconutID, new ItemData { Workshop = C.CoconutWorkshop, Amount = GetItemCount(CoconutID) } },
        { BeehiveID, new ItemData { Workshop = C.BeehiveWorkshop, Amount = GetItemCount(BeehiveID) } },
        { WoodOpalID, new ItemData { Workshop = C.WoodOpalWorkshop, Amount = GetItemCount(WoodOpalID) } },
        { CoalID, new ItemData { Workshop = C.CoalWorkshop, Amount = GetItemCount(CoalID) } },
        { GlimshroomID, new ItemData { Workshop = C.GlimshroomWorkshop, Amount = GetItemCount(GlimshroomID) } },
        { EffervescentWaterID, new ItemData { Workshop = C.EffervescentWaterWorkshop, Amount = GetItemCount(EffervescentWaterID) } },
        { ShaleID, new ItemData { Workshop = C.ShaleWorkshop, Amount = GetItemCount(ShaleID) } },
        { MarbleID, new ItemData { Workshop = C.MarbleWorkshop, Amount = GetItemCount(MarbleID) } },
        { MythrilOreID, new ItemData { Workshop = C.MythrilOreWorkshop, Amount = GetItemCount(MythrilOreID) } },
        { SpectrineID, new ItemData { Workshop = C.SpectrineWorkshop, Amount = GetItemCount(SpectrineID) } },
        { DuriumSandID, new ItemData { Workshop = C.DuriumSandWorkshop, Amount = GetItemCount(DuriumSandID) } },
        { YellowCopperOreID, new ItemData { Workshop = C.YellowCopperOreWorkshop, Amount = GetItemCount(YellowCopperOreID) } },
        { GoldOreID, new ItemData { Workshop = C.GoldOreWorkshop, Amount = GetItemCount(GoldOreID) } },
        { HawksEyeSandID, new ItemData { Workshop = C.HawksEyeSandWorkshop, Amount = GetItemCount(HawksEyeSandID) } },
        { CrystalFormationID, new ItemData { Workshop = C.CrystalFormationWorkshop, Amount = GetItemCount(CrystalFormationID) } },
    };
}
