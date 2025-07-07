using ExplorersIcebox.Util.PathCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util;

public static class IslandHelper
{
    public static int TotalLoops = 0;
    public static int MaxSetLoops = 0;
    public static int CurrentLoopCount = 0;
    public static KeyValuePair<string, List<RouteClass.WaypointUtil>> CurrentRoute;

    public class ItemGathered
    {
        public int Amount { get; set; }
        public HashSet<string> GatherNodes { get; set; } = new();
        public bool IgnoreNode { get; set; }
    }

    public static int IslandLoopCalc(int amountGathered)
    {
        int MaxLoops = 0; // Initial start of the maximum amount of loops you can do
        int MinItemKeep = C.MinimumItemKeep; // Minimum amount of items you want to keep (global)
        int MaxAmount = 999; // Maximum amount of items that you can gather

        int ItemCap = MaxAmount - MinItemKeep; // 999 - 500 for example, which would make the max gatherable items 499
        MaxLoops = ItemCap / amountGathered; // 499 / 6 for example. 

        return MaxLoops;
    }
}
