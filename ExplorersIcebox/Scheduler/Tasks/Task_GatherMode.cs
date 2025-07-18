using ECommons.Automation;
using ECommons.Throttlers;
using FFXIVClientStructs.FFXIV.Client.Game.MJI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_GatherMode
    {
        // Used to just swap to the gathering mode in island sanctuary. 
        // Trying to lessen the necessity of visland if possible, and just directly call the functions where I can
        public static void Enqueue()
        {
            P.taskManager.Enqueue(() => GatherMode());
        }

        internal unsafe static bool? GatherMode()
        {
            if (MJIManager.Instance()->CurrentMode == 1) // Gather Mode
                return true;
            else
            {
                if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("ContextIconMenu", out var ContextAddon) && GenericHelpers.IsAddonReady(ContextAddon))
                {
                    if (EzThrottler.Throttle("Throttling the ContextIconMenu Callback to not Crash"))
                    {
                        Callback.Fire(ContextAddon, true, 0, 1, 82042, 0, 0);
                        Callback.Fire(ContextAddon, true, -1);
                    }
                }
                else if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIHud", out var MJIAddon) && GenericHelpers.IsAddonReady(MJIAddon))
                {
                    if (EzThrottler.Throttle("Throttling opening the island mode"))
                    {
                        Callback.Fire(MJIAddon, false, 11, 0);
                    }
                }
            }

            return false;
        }
    }
}
