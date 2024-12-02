using ECommons.Throttlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandLeveling.Scheduler.Tasks.GroupTask
{
    internal static class GroupMammetTask
    {
        internal unsafe static void Enqueue(List<RouteEntry> routeEntries)
        {
            if (!atEntrance) 
                TaskReturn.Enqueue();
            TaskMoveTo.Enqueue(mammetExportPos, "Mammet Export", false, 1);
            // TaskSellTo.Enqueue(); old targeting code, keeping it here for reference
            TaskTargetV2.Enqueue(ExportMammetID);
            TaskCallback.Enqueue("SelectString", true, 0);
            for (int i = 0; i < routeEntries.Count; i++)
            {
                if (routeEntries[i].Sell > 0)
                {
                    PluginLog($"{routeEntries[i].ID} has enough to sell");
                    PluginLog($"{routeEntries[i].Sell} <-- selling this much");
                    P.taskManager.EnqueueDelay(100);
                    TaskCallback.Enqueue("MJIDisposeShop", true, 12, routeEntries[i].PCallValue);
                    P.taskManager.EnqueueDelay(100);
                    TaskCallback.Enqueue("MJIDisposeShopShipping", true, 11, routeEntries[i].Sell);
                    P.taskManager.EnqueueDelay(100);
                    P.taskManager.Enqueue(() => !IsAddonActive("MJIDisposeShopShipping"));
                    P.taskManager.Enqueue(() => UpdateTableDict());
                    P.taskManager.Enqueue(() => TableSellUpdate(currentTable));
                    P.taskManager.EnqueueDelay(500);
                }
            }
            P.taskManager.EnqueueDelay(20);
            TaskCallback.Enqueue("MJIDisposeShop", true, 1);
            P.taskManager.Enqueue(() => !IsAddonActive("MJIDisposeShop"));
            P.taskManager.EnqueueDelay(20);
            TaskMoveTo.Enqueue(workshopExitPos, "Entrance of shop", false, 1);
        }
    }
}
