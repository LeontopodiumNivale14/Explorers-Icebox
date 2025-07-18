using ECommons.Throttlers;
using ExplorersIcebox.Util;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_UpdateShop
    {
        public static void Enqueue()
        {
            P.taskManager.Enqueue(() => OpenPouch(), "Opening MJI Pouch");
            P.taskManager.Enqueue(() => UpdateCallbacks(), "Updating item callbacks");
            P.taskManager.Enqueue(() => ClosePouch(), "Closing MJI Pouch");
        }

        internal static unsafe bool? OpenPouch()
        {
            if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIPouch", out var mjiPouch) && GenericHelpers.IsAddonReady(mjiPouch))
            {
                return true;
            }
            else if (GenericHelpers.TryGetAddonMaster<MJIHud>("MJIHud", out var mjiHud) && mjiHud.IsAddonReady)
            {
                if (EzThrottler.Throttle("Open MJI Inventory Pouch"))
                {
                    mjiHud.Isleventory();
                }
            }

            return false;
        }

        internal static unsafe bool? UpdateCallbacks()
        {
            if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIPouch", out var mjiPouch) && GenericHelpers.IsAddonReady(mjiPouch))
            {
                IslandHelper.UpdateShopCallback();
                return true;
            }

            return false;
        }

        internal static unsafe bool? ClosePouch()
        {
            if (GenericHelpers.TryGetAddonByName<AtkUnitBase>("MJIPouch", out var mjiPouch))
            {
                if (GenericHelpers.IsAddonReady(mjiPouch))
                {
                    if (EzThrottler.Throttle("Closing the pouch"))
                        ECommons.Automation.Callback.Fire(mjiPouch, true, 1);
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
