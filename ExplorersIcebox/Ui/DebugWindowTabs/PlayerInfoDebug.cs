using Dalamud.Interface.Colors;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class PlayerInfoDebug
    {
        private static string AddonName = "default";

        public static void Draw()
        {
            ImGui.Text($"General Information");
            ImGui.Text($"TerritoryID: " + Svc.ClientState.TerritoryType);
            ImGui.Text($"Target: " + Svc.Targets.Target);
            ImGui.InputText("##Addon Visible", ref AddonName, 100);
            ImGui.SameLine();
            ImGui.Text($"Addon Visible: ");
            ImGui.SameLine();
            if (AddonHelper.IsAddonActive(AddonName))
            {
                FontAwesome.Print(ImGuiColors.HealerGreen, FontAwesome.Check);
            }
            else if (!AddonHelper.IsAddonActive(AddonName))
            {
                FontAwesome.Print(ImGuiColors.DalamudRed, FontAwesome.Cross);
            }
            ImGui.Text($"Navmesh information");
            var player = Svc.ClientState.LocalPlayer;
            if (player != null)
            {
                ImGui.Text($"PlayerPos: " + player.Position);
            }
            ImGui.Text($"Navmesh BuildProgress :" + P.navmesh.BuildProgress());//working ipc
            ImGui.Text($"Current task time remaining is: {P.taskManager.RemainingTimeMS}");
            ImGui.Text($"Current task is: {P.taskManager.CurrentTask}");
            ImGui.Text($"Current task count: {P.taskManager.NumQueuedTasks}");
            if (ImGui.Button("Swap to island mode"))
            {
                Task_GatherMode.Enqueue();
            }

        }
    }
}
