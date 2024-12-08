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
    public static int Route0Amount => RouteAmountCalc(Routes.Route0Table, C.IslefishWorkshop, C.ClamWorkshop, C.SquidWorkshop, C.LaverWorkshop);
    public static int Route1Amount => RouteAmountCalc(Routes.Route1Table, C.IslewortWorkshop);
    public static int Route2Amount => RouteAmountCalc(Routes.Route2Table, C.SugarcaneWorkshop, C.VineWorkshop);
    public static int Route3Amount => RouteAmountCalc(Routes.Route3Table, C.TinsandWorkshop, C.SandWorkshop, C.MarbleWorkshop, C.LimestoneWorkshop, C.StoneWorkshop);
    public static int Route4Amount => RouteAmountCalc(Routes.Route4Table, C.AppleWorkshop, C.BeehiveWorkshop, C.VineWorkshop, C.SapWorkshop, C.WoodOpalWorkshop, C.BranchWorkshop, C.ResinWorkshop, C.SandWorkshop, C.ClamWorkshop, 0);
    public static int Route5Amount => RouteAmountCalc(Routes.Route5Table, C.CoconutWorkshop, C.PalmLeafWorkshop, C.PalmLeafWorkshop, C.LimestoneWorkshop, C.MarbleWorkshop, C.StoneWorkshop);
    public static int Route6Amount => RouteAmountCalc(Routes.Route6Table, C.CottonWorkshop, C.HempWorkshop, C.CoconutWorkshop, C.PalmLogWorkshop, C.PalmLeafWorkshop, C.IslewortWorkshop);
    public static int Route7Amount => RouteAmountCalc(Routes.Route7Table, C.ClayWorkshop, C.TinsandWorkshop, C.MarbleWorkshop, C.LimestoneWorkshop, C.StoneWorkshop, C.BranchWorkshop, C.LogWorkshop, C.ResinWorkshop, C.SugarcaneWorkshop, C.VineWorkshop, 0);
    public static int Route8Amount => RouteAmountCalc(Routes.Route8Table, C.MarbleWorkshop, C.LimestoneWorkshop, 0, C.SugarcaneWorkshop, C.VineWorkshop, C.CoconutWorkshop, C.PalmLeafWorkshop, C.PalmLogWorkshop, C.TinsandWorkshop, C.SandWorkshop, C.HempWorkshop, C.IslewortWorkshop);
    public static int Route9Amount => RouteAmountCalc(Routes.Route9Table, C.BranchWorkshop, C.ResinWorkshop, C.SapWorkshop, C.WoodOpalWorkshop, C.LogWorkshop, C.ClayWorkshop, C.SandWorkshop, 0);
    public static int Route10Amount => RouteAmountCalc(Routes.Route10Table, C.CopperWorkshop, C.MythrilOreWorkshop, C.HempWorkshop, C.PalmLogWorkshop, C.PalmLeafWorkshop, C.CottonWorkshop, C.IslewortWorkshop, 0);
    public static int Route11Amount => RouteAmountCalc(Routes.Route11Table, C.SapWorkshop, C.WoodOpalWorkshop, 0, C.HempWorkshop, C.IslewortWorkshop);
    public static int Route12Amount => RouteAmountCalc(Routes.Route12Table, C.HempWorkshop, 0, C.SandWorkshop, C.ClayWorkshop, C.CoconutWorkshop, C.PalmLogWorkshop, C.PalmLeafWorkshop);
    public static int Route13Amount => RouteAmountCalc(Routes.Route13Table, C.MulticoloredIslebloomsWorkshop, C.QuartzWorkshop, C.IronOreWorkshop, C.DuriumSandWorkshop, C.LeucograniteWorkshop, 0);
    public static int Route14Amount => RouteAmountCalc(Routes.Route14Table, C.IronOreWorkshop, 0);
    public static int Route15Amount => RouteAmountCalc(Routes.Route15Table, C.LaverWorkshop, C.SquidWorkshop, C.JellyfishWorkshop, C.CoralWorkshop);
    public static int Route16Amount => RouteAmountCalc(Routes.Route16Table, C.RockSaltWorkshop, 0, C.ClayWorkshop, C.SandWorkshop, C.SandWorkshop, C.IslewortWorkshop, C.HempWorkshop);
    public static int Route17Amount => RouteAmountCalc(Routes.Route17Table, C.LeucograniteWorkshop, C.CopperWorkshop, C.MythrilOreWorkshop, C.IronOreWorkshop, C.DuriumSandWorkshop, 0);
    public static int Route18Amount => RouteAmountCalc(Routes.Route18Table, C.QuartzWorkshop, C.IronOreWorkshop, C.DuriumSandWorkshop, C.LeucograniteWorkshop, 0);
    public static int Route19Amount => RouteAmountCalc(Routes.Route19Table, C.GlimshroomWorkshop, C.ShaleWorkshop, C.CoalWorkshop, 0);
    public static int Route20Amount => RouteAmountCalc(Routes.Route20Table, C.EffervescentWaterWorkshop, C.SpectrineWorkshop, C.ShaleWorkshop, C.CoalWorkshop, 0);
    public static int Route21Amount => RouteAmountCalc(Routes.Route21Table, C.YellowCopperOreWorkshop, C.GoldOreWorkshop, C.CrystalFormationWorkshop, C.HawksEyeSandWorkshop, C.GlimshroomWorkshop, C.EffervescentWaterWorkshop, C.SpectrineWorkshop, C.ShaleWorkshop, C.CoalWorkshop, 0);


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
