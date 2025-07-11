using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class TestGuiDebug
    {
        private static int Position = 0;
        private static string PopupText = string.Empty;

        public static void Draw()
        {
            if (ImGui.Button("Return to Island Base"))
            {
                Task_ReturnToBase.Enqueue();
            }

            if (ImGui.Button("Open Player Search"))
            {
                Utils.OpenPlayerSearch(15);
            }
            if (ImGui.Button("Open Friends"))
            {
                Utils.OpenPlayerSearch(13);
            }
            ImGui.SetNextItemWidth(100);
            ImGui.InputInt("###Position", ref Position);
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            ImGui.InputText("###TextTest", ref PopupText, 100);

            if (ImGui.Button("Test Text"))
            {
                Utils.ShowText(Position, PopupText);
            }
        }
    }
}
