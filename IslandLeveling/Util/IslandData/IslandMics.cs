namespace IslandLeveling.Util.IslandData;

public class IslandMics
{
    //This is the current cap of items on Island Sanctuary Items, just so I can quickly pull it at all times
    public const int MaxItems = 999;
    
    // Route Loop Amounts
    public static int Route1Amount { get; set; }
    public static int Route2Amount { get; set; }
    
    // Tables to be used for Island Sanctuary information
    
    // This is so I can run a for if i = 1 statement to update the values of all the gatherable items
    public static int[,] IslandGatherablesTable = new[,]
    {
        { PalmLeafID, PalmLeafAmount },
        { BranchID, BranchAmount },
        { StoneID, StoneAmount },
        { ClamID, ClamAmount },
        { LaverID, LaverAmount },
        { CoralID, CoralAmount },
        { IslewortID, IslewortAmount }, { SandID, SandAmount },
        { VineID, VineAmount },
        { SapID, SapAmount },
        { AppleID, AppleAmount },
        { LogID, LogAmount },
        { PalmLogID, PalmLogAmount },
        { CopperID, CopperAmount },
        { LimestoneID, LimestoneAmount },
        { RockSaltID, RockSaltAmount },
        { ClayID, ClayAmount },
        { TinsandID, TinsandAmount },
        { SugarcaneID, SugarcaneAmount },
        { CottonID, CottonAmount },
        { HempID, HempAmount },
        { IslefishID, IslefishAmount },
        { SquidID, SquidAmount },
        { JellyfishID, JellyfishAmount },
        { IronOreID, IronOreAmount },
        { QuartzID, QuartzAmount },
        { LeucograniteID, LeucograniteAmount },
        { MulticoloredIslebloomsID, MulticoloredIslebloomsAmount },
        { ResinID, ResinAmount },
        { CoconutID, CoconutAmount },
        { BeehiveID, BeehiveAmount },
        { WoodOpalID, WoodOpalAmount },
        { CoalID, CoalAmount },
        { GlimshroomID, GlimshroomAmount },
        { EffervescentWaterID, EffervescentWaterAmount },
        { ShaleID, ShaleAmount },
        { MarbleID, MarbleAmount },
        { MythrilOreID, MythrilOreAmount },
        { SpectrineID, SpectrineAmount },
        { DuriumSandID, DuriumSandAmount },
        { YellowCopperOreID, YellowCopperOreAmount },
        { GoldOreID, GoldOreAmount },
        { HawksEyeSandID, HawksEyeSandAmount },
        { CrystalFormationID, CrystalFormationAmount }
    };
    
    // Route Tables
    // Has: Amount Gathered | ID | Amount | Workshop | Send | Sell | Can sell to full amount | Pcall value | Amount of loops per loop 
    public static int[,] Route1Table = new[,]
    {
        { 6, QuartzID, QuartzAmount, QuartzWorkshop, QuartzSend, QuartzSell, 0, 25, Route1Amount},
        { 3, IronOreID, IronOreAmount, IronOreWorkshop, IronOreSend, IronOreSell, 0, 24, Route1Amount},
        { 3, DuriumSandID, DuriumSandAmount, DuriumSandWorkshop, DuriumSandSend, DuriumSandSell, 0, 39, Route1Amount},
        { 2, LeucograniteID, LeucograniteAmount, LeucograniteWorkshop, LeucograniteSend, LeucograniteSell, 0, 26, Route1Amount},
        { 11, StoneID, StoneAmount, StoneWorkshop, StoneSend, StoneSell, 1, 2, Route1Amount}
    };

    public static int[,] Route2Table = new[,]
    {
        { 7, ClayID, ClayAmount, ClayWorkshop, ClaySend, ClaySell, 0},
        { 2, TinsandID, TinsandAmount, TinsandWorkshop, TinsandSend, TinsandSell, 0},
        { 1, MarbleID, MarbleAmount, MarbleWorkshop, MarbleSend, MarbleSell, 0},
        { 1, LimestoneID, LimestoneAmount, LimestoneWorkshop, LimestoneSend, LimestoneSell, 0},
        { 1, BranchID, BranchAmount, BranchWorkshop, BranchSend, BranchSell, 0},
        { 1, LogID, LogAmount, LogWorkshop, LogSend, LogSell, 0},
        { 1, ResinID, ResinAmount, ResinWorkshop, ResinSend, ResinSell, 0},
        { 10, SandID, SandAmount, SandWorkshop, SandSend, SandSell, 1},
    };
}
