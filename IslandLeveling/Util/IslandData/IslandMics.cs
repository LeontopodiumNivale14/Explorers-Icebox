using Dalamud.Game.ClientState.Objects.Types;
using ECommons;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using System.Collections.Generic;

namespace IslandLeveling.Util.IslandData;

public class IslandMics
{
    //NPC ID's
    public const uint BaldinID = 1043621; // NPC that leads to the IS
    public const uint ExportMammetID = 1043464; // Exports Mammet, used to trade your items -> Cowries
    //Test bool 
    public static bool CanFly = false;
    public static bool atEntrance => (GetDistanceToPointV(workshopEntrancePos) <= 2);

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
    public static int Route8Amount => RouteAmountCalc(Routes.Route8Table, C.ClayWorkshop, C.TinsandWorkshop, C.MarbleWorkshop, C.LimestoneWorkshop, C.BranchWorkshop, C.LogWorkshop, C.ResinWorkshop, 0);
    public static int Route19Amount => RouteAmountCalc(Routes.Route19Table, C.QuartzWorkshop, C.IronOreWorkshop, C.DuriumSandWorkshop, C.LeucograniteWorkshop, 0);


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
