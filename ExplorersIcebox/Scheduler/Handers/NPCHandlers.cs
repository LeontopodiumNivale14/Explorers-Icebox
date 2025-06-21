using FFXIVClientStructs.FFXIV.Client.Game.Control;
using ECommons.GameFunctions;
using ExplorersIcebox.Util;

namespace ExplorersIcebox.Scheduler.Handers
{
    internal static unsafe class NPCHandlers
    {
        internal static bool? InteractShopNpc()
        {
            var OpenedShopAddonName = "ShopExchangeItem";
            var target = Svc.Targets.Target;
            if (target != default)
            {
                if (AddonHelper.IsAddonActive("SelectString") || AddonHelper.IsAddonActive("SelectIconString") || AddonHelper.IsAddonActive(OpenedShopAddonName))
                    return true;
                unsafe { TargetSystem.Instance()->InteractWithObject(target.Struct(), false); }
            }
            return false;
        }
    }
}
