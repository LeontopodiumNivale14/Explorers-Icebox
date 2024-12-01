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
        internal unsafe static void Enqueue(int[,] table)
        {
            if (!atEntrance) TaskReturn.Enqueue();
            TaskMoveTo.Enqueue(mammetExportPos, "Mammet Export", 1);
            TaskSellTo.Enqueue();
            TaskCallback.Enqueue("SelectString", true, 0);
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (table[i, 2] > 0)
                {
                    PluginLog($"{table[i, 1]} has enough to sell");
                    PluginLog($"{table[i, 2]} <-- selling this much");
                    P.taskManager.EnqueueDelay(100);
                    TaskCallback.Enqueue("MJIDisposeShop", true, 12, table[i, 4]);
                    P.taskManager.EnqueueDelay(100);
                    TaskCallback.Enqueue("MJIDisposeShopShipping", true, 11, table[i, 2]);
                    P.taskManager.EnqueueDelay(100);
                    P.taskManager.Enqueue(() => !IsAddonActive("MJIDisposeShopShipping"));
                    P.taskManager.Enqueue(() => UpdateTableDict());
                    P.taskManager.Enqueue(() => TableSellUpdate(CurrentRouteTable));
                    P.taskManager.EnqueueDelay(500);
                }
            }
            P.taskManager.EnqueueDelay(20);
            TaskCallback.Enqueue("MJIDisposeShop", true, 1);
            P.taskManager.Enqueue(() => !IsAddonActive("MJIDisposeShop"));
            P.taskManager.EnqueueDelay(20);
            TaskMoveTo.Enqueue(workshopEntrance, "Entrance of shop", 1);
        }
    }
}
