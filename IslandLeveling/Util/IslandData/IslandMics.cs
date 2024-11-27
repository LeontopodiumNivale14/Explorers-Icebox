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
    // Has: Amount Gathered | ID | Amount | Send | Sell | Can sell to full amount | Pcall value
    public static int[,] Route1Table = new[,]
    {
        { 6, QuartzID, QuartzAmount, 0, 0, 0, 25},
        { 3, IronOreID, IronOreAmount, 0, 0, 0, 24},
        { 3, DuriumSandID, DuriumSandAmount, 0, 0, 0, 39},
        { 2, LeucograniteID, LeucograniteAmount, 0, 0, 0, 26},
        { 11, StoneID, StoneAmount, 1, 1, 1, 2}
    };

    public static int[,] Route2Table = new[,]
    {
        { 7, ClayID, ClayAmount, 0, 0, 0},
        { 2, TinsandID, TinsandAmount, 0, 0, 0},
        { 1, MarbleID, MarbleAmount, 0, 0, 0},
        { 1, LimestoneID, LimestoneAmount, 0, 0, 0},
        { 1, BranchID, BranchAmount, 0, 0, 0},
        { 1, LogID, LogAmount, 0, 0, 0},
        { 1, ResinID, ResinAmount, 0, 0, 0},
        { 10, SandID, SandAmount, 0, 0, 1},
    };
}
