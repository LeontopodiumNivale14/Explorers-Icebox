namespace IslandLeveling.Util.IslandUtil;

public class ISVendorUtil
{
    public static int ShopCalc(int itemAmount, int workshopKeep, int loopItemAmount, int loopAmount, int itemSellSafe)
    {
        // Calculate RouteGathAmount
        var routeGathAmount = MaxItems - (loopItemAmount * loopAmount);

        // Ensure RouteGathAmount doesn't go below 0
        if (routeGathAmount < 0)
        {
            routeGathAmount = 0;
        }

        // Calculate ItemSend based on RouteGathAmount
        var itemSend = itemAmount - routeGathAmount;

        // Ensure ItemSend does not exceed ItemMax
        if (itemSend > MaxItems)
        {
            itemSend = MaxItems;
        }

        // Adjust ItemSend if ItemSellSafe is true (aka, if you can sell to workshop amount and be fine)
        if (itemSellSafe == 1)
        {
            itemSend -= workshopKeep;
        }

        // Return the calculated value
        return itemSend;
    }
    
    public static void ProcessTable(int[,] table)
    {
        // Validate the input
        if (table.GetLength(1) < 8)
        {
            throw new ArgumentException("Table must have at least eight columns.");
        }

        for (var i = 0; i < table.GetLength(0); i++) // Iterate through rows
        {
            var workshopKeep = table[i, 4];
            var itemPerLoop = table[i, 1];
            var itemAmount = table[i, 3];

            // Avoid dividing by zero
            if (itemPerLoop <= 0 || itemAmount <= 0)
            {
                Console.WriteLine($"Skipping row {i}: Invalid itemPerLoop or itemAmount.");
                continue;
            }

            // Calculate the loop amount
            table[i, 9] = CalculateRouteLoopAmount(workshopKeep, itemPerLoop, itemAmount);

            // Print or process the calculated route loop amount
            Console.WriteLine($"Row {i}: Calculated Loop Amount = {table[i, 9]}");
        }
    }

    private static int CalculateRouteLoopAmount(int workshopKeep, int itemPerLoop, int itemAmount)
    {
        // Calculate the base maximum loop
        var baseMaxLoop = itemAmount / itemPerLoop;

        // Calculate the adjusted route loop amount
        if (workshopKeep > 0)
        {
            var workshopKeepLoop = (int)Math.Ceiling((double)workshopKeep / itemAmount);
            return baseMaxLoop - workshopKeepLoop;
        }

        // If no workshop items, return the base loop amount
        return baseMaxLoop;
    }    
}
