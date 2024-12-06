using System.Collections.Generic;
using Dalamud.Game.ClientState.Conditions;

namespace ExplorersIcebox.Scheduler.Tasks.GroupTask
{
    internal static class GroupMammetTask
    {
        internal unsafe static void Enqueue(List<RouteEntry> routeEntries)
        {
            if (Svc.Condition[ConditionFlag.Mounted])
                TaskDisMount.Enqueue();
            P.taskManager.Enqueue(() => SchedulerMain.CurrentProcess = "Selling Items to Mammet");
            TaskMoveTo.Enqueue(mammetExportPos, "Mammet Export", false, 1);
            // TaskSellTo.Enqueue(); old targeting code, keeping it here for reference
            TaskTargetV2.Enqueue(ExportMammetID);
            TaskCallback.Enqueue("SelectString", true, 0);
            for (var i = 0; i < routeEntries.Count; i++)
            {
                if (routeEntries[i].Sell > 0)
                {
                    var itemID = routeEntries[i].ID;
                    PluginLog($"{itemID} has enough to sell");
                    PluginLog($"{routeEntries[i].Sell} <-- selling this much");
                    P.taskManager.EnqueueDelay(100);
                    TaskCallback.Enqueue("MJIDisposeShop", true, 12, IslandSancDictionary[itemID].Callback);
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
            P.taskManager.Enqueue(() => SchedulerMain.CurrentProcess = "Back to entrance");
            TaskMoveTo.Enqueue(workshopExitPos, "Entrance of shop", false, 1);
        }
    }
}
