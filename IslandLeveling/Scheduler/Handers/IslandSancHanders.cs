namespace IslandLeveling.Scheduler.Handers;

internal static unsafe class IslandSancHanders
{
    internal static bool? CurrentIslandItem()
    {
        for (var i = 0; i < IslandGatherablesTable.GetLength(0); i++)
        {
            var itemID = IslandGatherablesTable[i,0];
            IslandGatherablesTable[i,1] = GetItemCount(itemID);
        }
        return true;
    }
}
