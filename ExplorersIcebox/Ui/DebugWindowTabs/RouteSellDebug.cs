using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class RouteSellDebug
    {
        public static void Draw()
        {
            ImGui.Text("This is where the route sell debug would be... IF I HAD ONE");
            if (IPC.NavmeshIPC.Installed)
            {
                ImGui.Text("Navmesh is installed. Woohoo!");
            }
            else
            {
                ImGui.Text("Navmesh is not installed. BOOOOO");
            }
        }
    }
}
