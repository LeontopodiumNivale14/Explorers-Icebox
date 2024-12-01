using ECommons.Throttlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandLeveling.Scheduler.Tasks.GroupTask
{
    internal static class GroupTaskSellItem
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
                    TaskCallback.Enqueue("MJIDisposeShop", true, 12, table[i, 4]);
                    TaskCallback.Enqueue("MJIDisposeShopShipping", true, 11, table[i, 2]);
                    P.taskManager.Enqueue(() => !IsAddonActive("MJIDisposeShopShipping"));
                    EzThrottler.Throttle("Waiting to fire again", 1000);
                }
            }
        }
    }
}
