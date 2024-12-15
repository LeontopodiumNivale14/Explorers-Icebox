using Dalamud.Game.ClientState.Objects.Types;
using ECommons;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using Lumina.Excel.Sheets;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ExplorersIcebox.Util.IslandData;

public class IslandMics
{
    //NPC ID's
    public const uint BaldinID = 1043621; // NPC that leads to the IS
    public const uint ExportMammetID = 1043464; // Exports Mammet, used to trade your items -> Cowries
    //Test bool 
    public static bool CanFly = false;
    public static bool atEntrance => (GetDistanceToPointV(workshopEntrancePos) <= 2);
    public static string displayCurrentTask = "";
    public static string displayCurrentRoute = "";

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

    // Route Loop Amounts
    public static int Route0Amount => RouteAmountCalc(Routes.Route0Table,
                                                      Math.Min(IslandItemDict[IslefishID].Workshop, IslandItemDict[ClamID].Workshop), 0,
                                                      Math.Min(IslandItemDict[SquidID].Workshop, IslandItemDict[LaverID].Workshop), 0);

    public static int Route1Amount => RouteAmountCalc(Routes.Route1Table, IslandItemDict[IslewortID].Workshop);

    public static int Route2Amount => RouteAmountCalc(Routes.Route2Table, 
                                                      Math.Min(IslandItemDict[SugarcaneID].Workshop, IslandItemDict[VineID].Workshop), 0);
    public static int Route3Amount => RouteAmountCalc(Routes.Route3Table, 
                                                      Math.Min(IslandItemDict[TinsandID].Workshop, IslandItemDict[SandID].Workshop), 0, 
                                                      Math.Min(Math.Min(IslandItemDict[MarbleID].Workshop, IslandItemDict[LimestoneID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0 );

    public static int Route4Amount => RouteAmountCalc(Routes.Route4Table, 
                                                      Math.Min(Math.Min(IslandItemDict[AppleID].Workshop, IslandItemDict[BeehiveID].Workshop), IslandItemDict[VineID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[SapID].Workshop, IslandItemDict[WoodOpalID].Workshop), 0,
                                                      Math.Min(IslandItemDict[BranchID].Workshop, IslandItemDict[ResinID].Workshop), 0,
                                                      Math.Min(IslandItemDict[SandID].Workshop, IslandItemDict[ClamID].Workshop), 0, 0 );

    public static int Route5Amount => RouteAmountCalc(Routes.Route5Table,
                                                      Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLeafID].Workshop), 0, 0,
                                                      Math.Min(Math.Min(IslandItemDict[LimestoneID].Workshop, IslandItemDict[MarbleID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0 );
    public static int Route6Amount => RouteAmountCalc(Routes.Route6Table, 
                                                      IslandItemDict[CottonID].Workshop, 
                                                      IslandItemDict[HempID].Workshop,
                                                      Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLogID].Workshop), IslandItemDict[PalmLeafID].Workshop), 0, 0, 0 );

    public static int Route7Amount => RouteAmountCalc(Routes.Route7Table,
                                                      Math.Min(IslandItemDict[ClayID].Workshop, IslandItemDict[TinsandID].Workshop), 0,
                                                      Math.Min(Math.Min(IslandItemDict[MarbleID].Workshop, IslandItemDict[LimestoneID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0,
                                                      Math.Min(Math.Min(IslandItemDict[BranchID].Workshop, IslandItemDict[LogID].Workshop), IslandItemDict[ResinID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[SugarcaneID].Workshop, IslandItemDict[VineID].Workshop), 0, ShovelCheck() );

    public static int Route8Amount => RouteAmountCalc(Routes.Route8Table,
                                                      Math.Min(Math.Min(IslandItemDict[MarbleID].Workshop, IslandItemDict[LimestoneID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[SugarcaneID].Workshop, IslandItemDict[VineID].Workshop), 0,
                                                      Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLogID].Workshop), 0, 0,
                                                      Math.Min(IslandItemDict[TinsandID].Workshop, IslandItemDict[SandID].Workshop), 0,
                                                      Math.Min(IslandItemDict[HempID].Workshop, IslandItemDict[IslewortID].Workshop), 0
    );

    public static int Route9Amount => RouteAmountCalc(Routes.Route9Table,
                                                      Math.Min(IslandItemDict[BranchID].Workshop, IslandItemDict[ResinID].Workshop), 0,
                                                      Math.Min(IslandItemDict[SapID].Workshop, IslandItemDict[WoodOpalID].Workshop), 0,
                                                      Math.Min(IslandItemDict[ClayID].Workshop, IslandItemDict[SandID].Workshop), 0, 0 );

    public static int Route10Amount => RouteAmountCalc(Routes.Route10Table,
                                                       Math.Min(Math.Min(IslandItemDict[CopperID].Workshop, IslandItemDict[MythrilOreID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0,
                                                       IslandItemDict[HempID].Workshop,
                                                       Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLogID].Workshop), 0, 0,
                                                       IslandItemDict[CottonID].Workshop,
                                                       IslandItemDict[IslewortID].Workshop
    );

    public static int Route11Amount => RouteAmountCalc(Routes.Route11Table,
                                                       Math.Min(Math.Min(IslandItemDict[SapID].Workshop, IslandItemDict[WoodOpalID].Workshop), IslandItemDict[LogID].Workshop), 0, 0,
                                                       IslandItemDict[HempID].Workshop,
                                                       IslandItemDict[IslewortID].Workshop );

    public static int Route12Amount => RouteAmountCalc(Routes.Route12Table,
                                                       Math.Min(IslandItemDict[HempID].Workshop, IslandItemDict[IslewortID].Workshop), 0,
                                                       Math.Min(IslandItemDict[SandID].Workshop, IslandItemDict[ClayID].Workshop), 0,
                                                       Math.Min(Math.Min(IslandItemDict[CoconutID].Workshop, IslandItemDict[PalmLeafID].Workshop), IslandItemDict[PalmLogID].Workshop), 0, 0 );

    public static int Route13Amount => RouteAmountCalc(Routes.Route13Table,
                                                       IslandItemDict[MulticoloredIslebloomsID].Workshop,
                                                       IslandItemDict[QuartzID].Workshop,
                                                       Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[DuriumSandID].Workshop), 0,
                                                       IslandItemDict[LeucograniteID].Workshop, 0 );

    public static int Route14Amount => RouteAmountCalc(Routes.Route14Table,
                                                       Math.Min(Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[StoneID].Workshop), IslandItemDict[DuriumSandID].Workshop), 0, 0 );

    public static int Route15Amount => RouteAmountCalc(Routes.Route15Table,
                                                       Math.Min(IslandItemDict[LaverID].Workshop, IslandItemDict[SquidID].Workshop), 0,
                                                       Math.Min(IslandItemDict[JellyfishID].Workshop, IslandItemDict[CoralID].Workshop), 0
    );

    public static int Route16Amount => RouteAmountCalc(Routes.Route16Table,
                                                       Math.Min(IslandItemDict[RockSaltID].Workshop, IslandItemDict[StoneID].Workshop), 0,
                                                       Math.Min(IslandItemDict[ClayID].Workshop, IslandItemDict[SandID].Workshop), 0,
                                                       Math.Min(IslandItemDict[IslewortID].Workshop, IslandItemDict[HempID].Workshop), 0 );

    public static int Route17Amount => RouteAmountCalc(Routes.Route17Table,
                                                       IslandItemDict[LeucograniteID].Workshop,
                                                       Math.Min(IslandItemDict[CopperID].Workshop, IslandItemDict[MythrilOreID].Workshop), 0,
                                                       Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[DuriumSandID].Workshop), 0, 0 );

    public static int Route18Amount => RouteAmountCalc(Routes.Route18Table,
                                                       IslandItemDict[QuartzID].Workshop,
                                                       Math.Min(IslandItemDict[IronOreID].Workshop, IslandItemDict[DuriumSandID].Workshop), 0,
                                                       IslandItemDict[LeucograniteID].Workshop, 0 );

    public static int Route19Amount => RouteAmountCalc(Routes.Route19Table,
                                                       IslandItemDict[GlimshroomID].Workshop,
                                                       Math.Min(Math.Min(IslandItemDict[ShaleID].Workshop, IslandItemDict[CoalID].Workshop), IslandItemDict[StoneID].Workshop), 0, 0 );

    public static int Route20Amount => RouteAmountCalc(Routes.Route20Table,
                                                       Math.Min(IslandItemDict[EffervescentWaterID].Workshop, IslandItemDict[SpectrineID].Workshop), 0,
                                                       Math.Min(IslandItemDict[ShaleID].Workshop, IslandItemDict[CoalID].Workshop), 0, 0 );

    public static int Route21Amount => RouteAmountCalc(Routes.Route21Table,
                                                       Math.Min(IslandItemDict[YellowCopperOreID].Workshop, IslandItemDict[GoldOreID].Workshop), 0,
                                                       Math.Min(IslandItemDict[CrystalFormationID].Workshop, IslandItemDict[HawksEyeSandID].Workshop), 0,
                                                       IslandItemDict[GlimshroomID].Workshop,
                                                       Math.Min(IslandItemDict[EffervescentWaterID].Workshop, IslandItemDict[SpectrineID].Workshop), 0,
                                                       Math.Min(IslandItemDict[ShaleID].Workshop, IslandItemDict[CoalID].Workshop), 0, 0 );


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

    public class GatheringPointData
    {
        public required string Name { get; set; }
        public Vector3 Position { get; set; }
        public required string Base64Export { get; set; }
    }

    public static Dictionary<int, GatheringPointData> items = new Dictionary<int, GatheringPointData>
    {
        { 8, new GatheringPointData {Name = "Clay | Sand [Ground XP Loop]", Position = Clay_SandRoutePos, Base64Export = VislandRoutes.ClayVisland} },
        { 19, new GatheringPointData {Name = "Quartz [Mountain XP Loop]", Position = QuartzRoutePos, Base64Export = VislandRoutes.QuartzVisland} },
    };
}
