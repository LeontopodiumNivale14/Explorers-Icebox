using IslandLeveling.Scheduler.Handers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskCallback
    {
        public static void Enqueue(string AddonName, bool visibilty, params int[] callback_fires)
        {
            P.taskManager.Enqueue(() => GenericHandlers.FireCallback(AddonName, visibilty, callback_fires));
        }
    }
}
