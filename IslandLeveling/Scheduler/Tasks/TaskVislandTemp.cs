using IslandLeveling.Scheduler.Handers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskVislandTemp
    {
        internal unsafe static void Enqueue(string VRoute)
        {
            P.taskManager.Enqueue(() => VislandExec(VRoute));
        }
        internal unsafe static bool? VislandExec(string VRoute)
        {
            if (P.visland.IsRouteRunning() == false)
            {
                P.visland.StartRoute(VRoute, true);
                return true;
            }

            if (P.visland.IsRouteRunning() || PlayerHandlers.IsMoving()) return false;
            return false;
        }
    }
}
