using ECommons.Configuration;
using System.Collections.Generic;

namespace ExplorersIcebox.Util;

internal class IslandData
{
    #region Island Item ID's + Counts
    // List of all the Island Sanctuary Items ID's, organized in the order they pop up in the menu
    public const int PalmLeafID = 37551;
    public const int BranchID = 37553;
    public const int StoneID = 37554;
    public const int ClamID = 37555;
    public const int LaverID = 37556;
    public const int CoralID = 37557;
    public const int IslewortID = 37558;
    public const int SandID = 37559;
    public const int VineID = 37562;
    public const int SapID = 37563;
    public const int AppleID = 37552;
    public const int LogID = 37560;
    public const int PalmLogID = 37561;
    public const int CopperID = 37564;
    public const int LimestoneID = 37565;
    public const int RockSaltID = 37566;
    public const int ClayID = 37570;
    public const int TinsandID = 37571;
    public const int SugarcaneID = 37567;
    public const int CottonID = 37568;
    public const int HempID = 37569;
    public const int IslefishID = 37575;
    public const int SquidID = 37576;
    public const int JellyfishID = 37577;
    public const int IronOreID = 37572;
    public const int QuartzID = 37573;
    public const int LeucograniteID = 37574;
    public const int MulticoloredIslebloomsID = 39228;
    public const int ResinID = 39224;
    public const int CoconutID = 39225;
    public const int BeehiveID = 39226;
    public const int WoodOpalID = 39227;
    public const int CoalID = 39887;
    public const int GlimshroomID = 39889;
    public const int EffervescentWaterID = 39892;
    public const int ShaleID = 39888;
    public const int MarbleID = 39890;
    public const int MythrilOreID = 39891;
    public const int SpectrineID = 39893;
    public const int DuriumSandID = 41630;
    public const int YellowCopperOreID = 41631;
    public const int GoldOreID = 41632;
    public const int HawksEyeSandID = 41633;
    public const int CrystalFormationID = 41634;

    public static int[] ListitemIDs = new int[]
    {
        PalmLeafID, BranchID, StoneID, ClamID, LaverID, CoralID, IslewortID,
        SandID, VineID, SapID, AppleID, LogID, PalmLogID, CopperID, LimestoneID,
        RockSaltID, ClayID, TinsandID, SugarcaneID, CottonID, HempID, IslefishID,
        SquidID, JellyfishID, IronOreID, QuartzID, LeucograniteID,
        MulticoloredIslebloomsID, ResinID, CoconutID, BeehiveID, WoodOpalID,
        CoalID, GlimshroomID, EffervescentWaterID, ShaleID, MarbleID,
        MythrilOreID, SpectrineID, DuriumSandID, YellowCopperOreID,
        GoldOreID, HawksEyeSandID, CrystalFormationID
    };

    // Gets the current amount of the island sanctuary item that you have
    public static int PalmLeafAmount => GetItemCount(PalmLeafID);
    public static int BranchAmount => GetItemCount(BranchID);
    public static int StoneAmount => GetItemCount(StoneID);
    public static int ClamAmount => GetItemCount(ClamID);
    public static int LaverAmount => GetItemCount(LaverID);
    public static int CoralAmount => GetItemCount(CoralID);
    public static int IslewortAmount => GetItemCount(IslewortID);
    public static int SandAmount => GetItemCount(SandID);
    public static int VineAmount => GetItemCount(VineID);
    public static int SapAmount => GetItemCount(SapID);
    public static int AppleAmount => GetItemCount(AppleID);
    public static int LogAmount => GetItemCount(LogID);
    public static int PalmLogAmount => GetItemCount(PalmLogID);
    public static int CopperAmount => GetItemCount(CopperID);
    public static int LimestoneAmount => GetItemCount(LimestoneID);
    public static int RockSaltAmount => GetItemCount(RockSaltID);
    public static int ClayAmount => GetItemCount(ClayID);
    public static int TinsandAmount => GetItemCount(TinsandID);
    public static int SugarcaneAmount => GetItemCount(SugarcaneID);
    public static int CottonAmount => GetItemCount(CottonID);
    public static int HempAmount => GetItemCount(HempID);
    public static int IslefishAmount => GetItemCount(IslefishID);
    public static int SquidAmount => GetItemCount(SquidID);
    public static int JellyfishAmount => GetItemCount(JellyfishID);
    public static int IronOreAmount => GetItemCount(IronOreID);
    public static int QuartzAmount => GetItemCount(QuartzID);
    public static int LeucograniteAmount => GetItemCount(LeucograniteID);
    public static int MulticoloredIslebloomsAmount => GetItemCount(MulticoloredIslebloomsID);
    public static int ResinAmount => GetItemCount(ResinID);
    public static int CoconutAmount => GetItemCount(CoconutID);
    public static int BeehiveAmount => GetItemCount(BeehiveID);
    public static int WoodOpalAmount => GetItemCount(WoodOpalID);
    public static int CoalAmount => GetItemCount(CoalID);
    public static int GlimshroomAmount => GetItemCount(GlimshroomID);
    public static int EffervescentWaterAmount => GetItemCount(EffervescentWaterID);
    public static int ShaleAmount => GetItemCount(ShaleID);
    public static int MarbleAmount => GetItemCount(MarbleID);
    public static int MythrilOreAmount => GetItemCount(MythrilOreID);
    public static int SpectrineAmount => GetItemCount(SpectrineID);
    public static int DuriumSandAmount => GetItemCount(DuriumSandID);
    public static int YellowCopperOreAmount => GetItemCount(YellowCopperOreID);
    public static int GoldOreAmount => GetItemCount(GoldOreID);
    public static int HawksEyeSandAmount => GetItemCount(HawksEyeSandID);
    public static int CrystalFormationAmount => GetItemCount(CrystalFormationID);
    #endregion

    //NPC ID's
    public const uint BaldinID = 1043621; // NPC that leads to the IS
    public const uint ExportMammetID = 1043464; // Exports Mammet, used to trade your items -> Cowries
    //Test bool 
    public static bool CanFly = false;
    public static bool atEntrance => (GetDistanceToPointV(workshopEntrancePos) <= 2);
    public static string displayCurrentTask = "";
    public static string displayCurrentRoute = "";

    // Location Info
    public static uint LowerLimsaAether = 10;
    public static uint LowerLimsaZoneID = 135;
    public static uint BaldinNPCID = 1043621;

    public static uint IslandSancZoneID = 1055;

    public static void UpdateDisplayText(string text)
    {
        displayCurrentTask = text;
    }

    public static int RouteAmount(int routeSelected)
    {
        return routeSelected switch
        {
            0 => Route0Amount,
            1 => Route1Amount,
            2 => Route2Amount,
            3 => Route3Amount,
            4 => Route4Amount,
            5 => Route5Amount,
            6 => Route6Amount,
            7 => Route7Amount,
            8 => Route8Amount,
            9 => Route9Amount,
            10 => Route10Amount,
            11 => Route11Amount,
            12 => Route12Amount,
            13 => Route13Amount,
            14 => Route14Amount,
            15 => Route15Amount,
            16 => Route16Amount,
            17 => Route17Amount,
            18 => Route18Amount,
            19 => Route19Amount,
            20 => Route20Amount,
            21 => Route21Amount,
            _ => 0
        };
    }

    //This is the current cap of items on Island Sanctuary Items, just so I can quickly pull it at all times
    public const int MaxItems = 999;

    #region Route Min Amounts
    public static int Route0Amount => RouteMaxCalc(Routes.Route0Table,
                                                      Math.Min(IslandItemDict[IslefishID].Workshop, IslandItemDict[ClamID].Workshop), 0,
                                                      Math.Min(IslandItemDict[SquidID].Workshop, IslandItemDict[LaverID].Workshop), 0);
    public static int Route1Amount => RouteMaxCalc(Routes.Route1Table, IslandItemDict[IslewortID].Workshop);
    public static int Route2Amount => RouteMaxCalc(Routes.Route2Table,
                                                      Math.Min(IslandItemDict[SugarcaneID].Workshop, IslandItemDict[VineID].Workshop), 0);
    public static int Route3Amount => RouteMaxCalc(Routes.Route3Table,
                                                      Math.Min(IslandItemDict[TinsandID].Workshop, IslandItemDict[SandID].Workshop), 0,
                                                      Math.Min(Math.Min(IslandItemDict[MarbleID].Workshop, IslandItemDict[LimestoneID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0);
    public static int Route4Amount => RouteMaxCalc(Routes.Route4Table,
                                                      Math.Min(Math.Min(IslandItemDict[AppleID].Workshop, IslandItemDict[BeehiveID].Workshop), IslandItemDict[VineID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[SapID].Workshop, IslandItemDict[WoodOpalID].Workshop), 0,
                                                      Math.Min(IslandItemDict[BranchID].Workshop, IslandItemDict[ResinID].Workshop), 0,
                                                      Math.Min(IslandItemDict[SandID].Workshop, IslandItemDict[ClamID].Workshop), 0, 0);
    public static int Route5Amount => RouteMaxCalc(Routes.Route5Table,
                                                      Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLeafID].Workshop), 0, 0,
                                                      Math.Min(Math.Min(IslandItemDict[LimestoneID].Workshop, IslandItemDict[MarbleID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0);
    public static int Route6Amount => RouteMaxCalc(Routes.Route6Table,
                                                      IslandItemDict[CottonID].Workshop,
                                                      IslandItemDict[HempID].Workshop,
                                                      Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLogID].Workshop), IslandItemDict[PalmLeafID].Workshop), 0, 0, 0);
    public static int Route7Amount => RouteMaxCalc(Routes.Route7Table,
                                                      Math.Min(IslandItemDict[ClayID].Workshop, IslandItemDict[TinsandID].Workshop), 0,
                                                      Math.Min(Math.Min(IslandItemDict[MarbleID].Workshop, IslandItemDict[LimestoneID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0,
                                                      Math.Min(Math.Min(IslandItemDict[BranchID].Workshop, IslandItemDict[LogID].Workshop), IslandItemDict[ResinID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[SugarcaneID].Workshop, IslandItemDict[VineID].Workshop), 0, ShovelCheck());
    public static int Route8Amount => RouteMaxCalc(Routes.Route8Table,
                                                      Math.Min(Math.Min(IslandItemDict[MarbleID].Workshop, IslandItemDict[LimestoneID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[SugarcaneID].Workshop, IslandItemDict[VineID].Workshop), 0,
                                                      Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLogID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[TinsandID].Workshop, IslandItemDict[SandID].Workshop), 0,
                                                      Math.Min(IslandItemDict[HempID].Workshop, IslandItemDict[IslewortID].Workshop), 0
    );
    public static int Route9Amount => RouteMaxCalc(Routes.Route9Table,
                                                      Math.Min(IslandItemDict[BranchID].Workshop, IslandItemDict[ResinID].Workshop), 0,
                                                      Math.Min(IslandItemDict[SapID].Workshop, IslandItemDict[WoodOpalID].Workshop), 0,
                                                      Math.Min(IslandItemDict[ClayID].Workshop, IslandItemDict[SandID].Workshop), 0, 0);
    public static int Route10Amount => RouteMaxCalc(Routes.Route10Table,
                                                       Math.Min(Math.Min(IslandItemDict[CopperID].Workshop, IslandItemDict[MythrilOreID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0,
                                                       IslandItemDict[HempID].Workshop,
                                                       Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLogID].Workshop), 0, 0,
                                                       IslandItemDict[CottonID].Workshop,
                                                       IslandItemDict[IslewortID].Workshop
    );
    public static int Route11Amount => RouteMaxCalc(Routes.Route11Table,
                                                       Math.Min(Math.Min(IslandItemDict[SapID].Workshop, IslandItemDict[WoodOpalID].Workshop), IslandItemDict[LogID].Workshop), 0, 0,
                                                       IslandItemDict[HempID].Workshop,
                                                       IslandItemDict[IslewortID].Workshop);
    public static int Route12Amount => RouteMaxCalc(Routes.Route12Table,
                                                       Math.Min(IslandItemDict[HempID].Workshop, IslandItemDict[IslewortID].Workshop), 0,
                                                       Math.Min(IslandItemDict[SandID].Workshop, IslandItemDict[ClayID].Workshop), 0,
                                                       Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLogID].Workshop), 0, 0);
    public static int Route13Amount => RouteMaxCalc(Routes.Route13Table,
                                                       IslandItemDict[MulticoloredIslebloomsID].Workshop,
                                                       IslandItemDict[QuartzID].Workshop,
                                                       Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[DuriumSandID].Workshop), 0,
                                                       IslandItemDict[LeucograniteID].Workshop, 0);
    public static int Route14Amount => RouteMaxCalc(Routes.Route14Table,
                                                       Math.Min(Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[StoneID].Workshop), IslandItemDict[DuriumSandID].Workshop), 0, 0);
    public static int Route15Amount => RouteMaxCalc(Routes.Route15Table,
                                                       Math.Min(IslandItemDict[LaverID].Workshop, IslandItemDict[SquidID].Workshop), 0,
                                                       Math.Min(IslandItemDict[JellyfishID].Workshop, IslandItemDict[CoralID].Workshop), 0
    );
    public static int Route16Amount => RouteMaxCalc(Routes.Route16Table,
                                                       Math.Min(IslandItemDict[RockSaltID].Workshop, IslandItemDict[StoneID].Workshop), 0,
                                                       Math.Min(IslandItemDict[ClayID].Workshop, IslandItemDict[SandID].Workshop), 0,
                                                       Math.Min(IslandItemDict[IslewortID].Workshop, IslandItemDict[HempID].Workshop), 0);
    public static int Route17Amount => RouteMaxCalc(Routes.Route17Table,
                                                       IslandItemDict[LeucograniteID].Workshop,
                                                       Math.Min(IslandItemDict[CopperID].Workshop, IslandItemDict[MythrilOreID].Workshop), 0,
                                                       Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[DuriumSandID].Workshop), 0, 0);
    public static int Route18Amount => RouteMaxCalc(Routes.Route18Table,
                                                       IslandItemDict[QuartzID].Workshop,
                                                       Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[DuriumSandID].Workshop), 0,
                                                       IslandItemDict[LeucograniteID].Workshop, 0);
    public static int Route19Amount => RouteMaxCalc(Routes.Route19Table,
                                                       IslandItemDict[GlimshroomID].Workshop,
                                                       Math.Min(Math.Min(IslandItemDict[ShaleID].Workshop, IslandItemDict[CoalID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0);
    public static int Route20Amount => RouteMaxCalc(Routes.Route20Table,
                                                       Math.Min(IslandItemDict[EffervescentWaterID].Workshop, IslandItemDict[SpectrineID].Workshop), 0,
                                                       Math.Min(IslandItemDict[ShaleID].Workshop, IslandItemDict[CoalID].Workshop), 0, 0);
    public static int Route21Amount => RouteMaxCalc(Routes.Route21Table,
                                                       Math.Min(IslandItemDict[YellowCopperOreID].Workshop, IslandItemDict[GoldOreID].Workshop), 0,
                                                       Math.Min(IslandItemDict[CrystalFormationID].Workshop, IslandItemDict[HawksEyeSandID].Workshop), 0,
                                                       IslandItemDict[GlimshroomID].Workshop,
                                                       Math.Min(IslandItemDict[EffervescentWaterID].Workshop, IslandItemDict[SpectrineID].Workshop), 0,
                                                       Math.Min(IslandItemDict[ShaleID].Workshop, IslandItemDict[CoalID].Workshop), 0, 0);
    #endregion

    public static int ShovelCheck()
    {
        if (!CheckIfItemLocked(2))
        {
            return 0;
        }
        else
        {
            return IslandItemDict[SandID].Workshop;
        }
    }

    public static void UpdateXPTable()
    {
        if (!CheckIfItemLocked(2))
        {
            Routes.Route7Table[10].CanSellFullAmount = true;
        }
        else
        {
            Routes.Route7Table[10].CanSellFullAmount = false;
        }
    }

    public class GatheringPointPos
    {
        public int Pos { get; set; }
    }

    #region Route Tables
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

    #endregion

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

    #region Gathering Point Data
    public class GatheringPointData
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Base64Export { get; set; }
        public bool GatherRoute { get; set; }
        public int MaxLoops { get; set; }
    }

    // Routes 1-7, 9-18, 20-22 still need to be properly updated, This is just setting up the basework so i can go back and edit this after...
    public static Dictionary<int, GatheringPointData> RouteDataPoint = new Dictionary<int, GatheringPointData>
    {
        { 0, new GatheringPointData {Name = "Clam | Islefish", Location = Base2Clam, Base64Export = ClamVisland, GatherRoute = C.Route0, MaxLoops = 124} },
        { 1, new GatheringPointData {Name = "Islewort", Location = Base2Islewort, Base64Export = IslewortVisland, GatherRoute = C.Route1, MaxLoops = 71} },
        { 2, new GatheringPointData {Name = "Sugarcane | Vine", Location = Base2Sugarcane, Base64Export = SugarcaneVisland, GatherRoute = C.Route2, MaxLoops = 90} },
        { 3, new GatheringPointData {Name = "Tinsand | Sand", Location = Base2Ttinsand, Base64Export = TinsandVisland, GatherRoute = C.Route3, MaxLoops = 142} },
        { 4, new GatheringPointData {Name = "Apple| Beehive | Vine", Location = Base2Apple, Base64Export = AppleVisland, GatherRoute = C.Route4, MaxLoops = 199} },
        { 5, new GatheringPointData {Name = "Coconut | Palm Log | Palm Leaf", Location = Base2Coconut, Base64Export = CoconutVisland, GatherRoute = C.Route5, MaxLoops = 142} },
        { 6, new GatheringPointData {Name = "Cotton", Location = Base2Cotton, Base64Export = CottonVisland, GatherRoute = C.Route6, MaxLoops = 142} },
        { 7, new GatheringPointData {Name = "Clay | Sand [Ground XP Loop]", Location = Base2Clay, Base64Export = ClayVisland, GatherRoute = C.Route7, MaxLoops = 142} }, // done
        { 8, new GatheringPointData {Name = "Marble | Limestone | (Stone)", Location = Base2Marble, Base64Export = MarbleVisland, GatherRoute = C.Route8, MaxLoops = 142} },
        { 9, new GatheringPointData {Name = "Branch | Resin | (Log)", Location = Base2Branch, Base64Export = BranchVisland, GatherRoute = C.Route9, MaxLoops = 124} },
        { 10, new GatheringPointData {Name = "Copper / Mythril", Location = Base2Copper, Base64Export = CopperVisland, GatherRoute = C.Route10, MaxLoops = 142} },
        { 11, new GatheringPointData {Name = "Opal / Log / Sap", Location = Base2Opal, Base64Export = OpalVisland, GatherRoute = C.Route11, MaxLoops = 124} },
        { 12, new GatheringPointData {Name = "Hemp", Location = Base2Hemp, Base64Export = HempVisland, GatherRoute = C.Route12, MaxLoops = 111} },
        { 13, new GatheringPointData {Name = "Multicolored Isleblooms", Location = Base2MultiColor, Base64Export = MulticoloredVisland, GatherRoute = C.Route13, MaxLoops = 249} },
        { 14, new GatheringPointData {Name = "Iron Ore", Location = Base2Iron, Base64Export = IronVisland, GatherRoute = C.Route14, MaxLoops = 90} },
        { 15, new GatheringPointData {Name = "Laver / Squid | Jellyfish / Coral", Location = Base2Laver, Base64Export = LaverJellyfishVisland, GatherRoute = C.Route15, MaxLoops = 166} },
        { 16, new GatheringPointData {Name = "Rocksalt", Location = Base2RockSalt, Base64Export = RocksaltVisland, GatherRoute = C.Route16, MaxLoops = 166} },
        { 17, new GatheringPointData {Name = "Leucogranite", Location = Base2Leucogranite, Base64Export = LeucograniteVisland, GatherRoute = C.Route17, MaxLoops = 142} },
        { 18, new GatheringPointData {Name = "Quartz [Mountain XP Loop]", Location = Base2Quartz, Base64Export = QuartzVisland, GatherRoute = C.Route18, MaxLoops = 166} }, // done
        { 19, new GatheringPointData {Name = "Coal / Shale | Glimshroom", Location = Base2Glimshroom, Base64Export = CoalVisland, GatherRoute = C.Route19, MaxLoops = 124} },
        { 20, new GatheringPointData {Name = "Effervescent Water", Location = Base2Water, Base64Export = WaterVisland, GatherRoute = C.Route20, MaxLoops = 99} },
        { 21, new GatheringPointData {Name = "Crystal / Hawk Sand | Yelow Copper / Gold Ore", Location = Base2Crystal, Base64Export = CrystalVisland, GatherRoute = C.Route21, MaxLoops = 249} },
    };
    #endregion

    public static int RouteMaxCalc(List<RouteEntry> routeEntries, params int[] workshops)
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
