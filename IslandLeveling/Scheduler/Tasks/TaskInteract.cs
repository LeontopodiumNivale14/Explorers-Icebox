using IslandLeveling.Scheduler.Handers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskInteract
    {
        public static void Enqueue(uint dataID)
        {
            P.taskManager.Enqueue(() => PlayerHandlers.InteractObject(dataID), "Interacting");
            PluginLog($"Interacting with target. DataID is: {dataID}");
        }
    }
}
