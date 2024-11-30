using IslandLeveling.Scheduler.Handers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskVislandMoveTo
    {
        internal unsafe static void Enqueue(string[] cords, bool relativeDir)
        {
            P.taskManager.Enqueue(() => VislandMoveTo(cords, relativeDir));
        }
        internal unsafe static bool? VislandMoveTo(string[] cords, bool relativeDir)
        {
            if (P.visland.IsRouteRunning() == false)
            {
                P.visland.VIsMoveTo(cords, relativeDir);
                ECommons.Logging.PluginLog.Information("Firing Visland Moveto");
                return true;
            }

            if (P.visland.IsRouteRunning() || PlayerHandlers.IsMoving()) return false;
            return false;
        }
    }
}
