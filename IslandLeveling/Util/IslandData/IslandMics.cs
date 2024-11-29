namespace IslandLeveling.Util.IslandData;

public class IslandMics
{
    //NPC ID's
    public const uint Baldin = 1043621; // NPC that leads to the IS
    public const uint ExportMammet = 3758096384; // Exports Mammet, used to trade your items -> Cowries

    //Test bool 
    public static bool CanFly = false;

    //This is the current cap of items on Island Sanctuary Items, just so I can quickly pull it at all times
    public const int MaxItems = 999;
    
    // Route Loop Amounts
    public static int Route1Amount => RouteAmountCalc(Route1Table, C.QuartzWorkshop, C.IronOreWorkshop, C.DuriumSandWorkshop, C.LeucograniteWorkshop, 0);
    public static int Route2Amount => RouteAmountCalc(Route2Table, C.ClayWorkshop, C.TinsandWorkshop, C.MarbleWorkshop, C.LimestoneWorkshop, C.BranchWorkshop, C.LogWorkshop, C.ResinWorkshop, 0);
    
    // Tables to be used for Island Sanctuary information
    
    // Route Tables
    // Has: Amount Gathered | ID | Send | Sell | Can sell to full amount (true/false) | Pcall value
    public static int[,] Route1Table = new[,] // FlyingXP Route
    {
        { 6, QuartzID, 0, 0, 0, 25},
        { 3, IronOreID, 0, 0, 0, 24},
        { 3, DuriumSandID, 0, 0, 0, 39},
        { 2, LeucograniteID, 0, 0, 0, 26},
        { 11, StoneID, 0, 0, 1, 2}
    };

    public static int[,] Route2Table = new[,] // GroundXP Route
    {
        { 7, ClayID, 0, 0, 0},
        { 2, TinsandID, 0, 0, 0},
        { 1, MarbleID, 0, 0, 0},
        { 1, LimestoneID, 0, 0, 0},
        { 1, BranchID, 0, 0, 0},
        { 1, LogID, 0, 0, 0},
        { 1, ResinID, 0, 0, 0},
        { 10, SandID, 0, 0, 1},
    };
}
