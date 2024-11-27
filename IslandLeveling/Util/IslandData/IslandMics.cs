namespace IslandLeveling.Util.IslandData;

public class IslandMics
{
    //This is the current cap of items on Island Sanctuary Items, just so I can quickly pull it at all times
    public const int MaxItems = 999;
    
    // Route Loop Amounts
    public static int Route1Amount { get; set; }
    public static int Route2Amount { get; set; }
    
    // Tables to be used for Island Sanctuary information
    
    // Route Tables
    // Has: Amount Gathered | ID | Amount | Workshop | Send | Sell | Can sell to full amount | Pcall value | Amount of loops per loop 
    public static int[,] Route1Table = new[,]
    {
        { 6, QuartzID, QuartzAmount, QuartzWorkshop, 0, 0, 0, 25, Route1Amount},
        { 3, IronOreID, IronOreAmount, IronOreWorkshop, 0, 0, 0, 24, Route1Amount},
        { 3, DuriumSandID, DuriumSandAmount, DuriumSandWorkshop, 0, 0, 0, 39, Route1Amount},
        { 2, LeucograniteID, LeucograniteAmount, LeucograniteWorkshop, 0, 0, 0, 26, Route1Amount},
        { 11, StoneID, StoneAmount, StoneWorkshop, 0, 0, 1, 2, Route1Amount}
    };

    public static int[,] Route2Table = new[,]
    {
        { 7, ClayID, ClayAmount, ClayWorkshop, 0, 0, 0},
        { 2, TinsandID, TinsandAmount, TinsandWorkshop, 0, 0, 0},
        { 1, MarbleID, MarbleAmount, MarbleWorkshop, 0, 0, 0},
        { 1, LimestoneID, LimestoneAmount, LimestoneWorkshop, 0, 0, 0},
        { 1, BranchID, BranchAmount, BranchWorkshop, 0, 0, 0},
        { 1, LogID, LogAmount, LogWorkshop, 0, 0, 0},
        { 1, ResinID, ResinAmount, ResinWorkshop, 0, 0, 0},
        { 10, SandID, SandAmount, SandWorkshop, 0, 0, 1},
    };
}
