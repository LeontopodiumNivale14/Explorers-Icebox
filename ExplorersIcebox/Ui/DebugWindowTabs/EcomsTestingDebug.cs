using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class EcomsTestingDebug
    {
        public static void Draw()
        {
            if (GenericHelpers.TryGetAddonMaster<MJIHud>("MJIHud", out var mjiHud) && mjiHud.IsAddonReady)
            {
                ImGui.Text($"Current Level: {mjiHud.SanctuaryRank}");
                ImGui.Text($"Current Island XP: {mjiHud.CurrentIslandXP} | {mjiHud.NextIslandLevelXP}");
                ImGui.Text($"Island Cowries: {mjiHud.IslandersCowrie}");
                ImGui.Text($"Seafarers Cowries: {mjiHud.SeafarersCowrie}");
            }
        }
    }
}
