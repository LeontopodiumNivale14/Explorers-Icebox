using ECommons.SimpleGui;
using IslandLeveling.Scheduler;
using IslandLeveling.Scheduler.Handers;
using IslandLeveling.Scheduler.Tasks;

namespace IslandLeveling.Windows
{
    internal class MainWindow : ConfigWindow, IDisposable
    {
        public MainWindow() : base()
        {
            Flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse | ImGuiWindowFlags.NoCollapse;
            SizeConstraints = new WindowSizeConstraints
            {
                MinimumSize = new Vector2(100, 100),
                MaximumSize = new Vector2(800, 600)
            };
        }
        public void Dispose()
        {
        }
        private string addonName = "kpala";
        private float xPos = 0;
        private float yPos = 0;
        private float zPos = 0;
        private int tolerance = 0;

        public override void Draw()
        {
            ImGui.Text($"Quartz WS = {QuartzWorkshop}");
            ImGui.Text($"Route 1 loop amount is: {Route1Amount}");
            ImGui.Text($"Route 2 loop amount is: {Route2Amount}");
            ImGui.Text($"TerritoryID: " + Svc.ClientState.TerritoryType);
            ImGui.SameLine();
            ImGui.Text($"Target: " + Svc.Targets.Target);
            ImGui.InputText("##Addon Visible", ref addonName, 100);
            ImGui.SameLine();
            ImGui.Text($"Addon Visible: " + IsAddonActive(addonName));
            ImGui.Text($"PlayerPos: " + PlayerPosition());
            ImGui.Text($"Navmesh BuildProgress :" + P.navmesh.BuildProgress());//working ipc
            bool isRunning = SchedulerMain.AreWeTicking;
            if (ImGui.Button(isRunning ? "Stop" : "Start"))
            {
                if (isRunning)
                {
                    SchedulerMain.DisablePlugin(); // Call DisablePlugin if running
                }
                else
                {
                    SchedulerMain.EnablePlugin(); // Call EnablePlugin if not running
                }
            }
            ImGui.SameLine();
            if (ImGuiEx.IconButton(FontAwesomeIcon.Wrench, "Settings"))
                EzConfigGui.WindowSystem.Windows.FirstOrDefault(w => w.WindowName == SettingMenu.WindowName)!.IsOpen ^= true;
            // this is kinda neat, there's...a HUGE section of icons. But not gonna fuck with this rn. Things to mess w/ later
            // if (ImGuiEx.IconButton(FontAwesomeIcon.))
            if (ImGui.Button("Mount up!"))
            {
                P.taskManager.Enqueue(() => TaskMountUp.Enqueue());
            }
            ImGui.SameLine();
            if (ImGui.Button("Mammet interact"))
            {
                P.taskManager.Enqueue(NPCHandlers.TargetShopNpc);
            }

            ImGui.Text("X:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(75);
            if (ImGui.InputFloat("##X Position", ref xPos));
            ImGui.SameLine();
            ImGui.Text("Y:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(75);
            if (ImGui.InputFloat("##Y Position", ref yPos));
            ImGui.SameLine();
            ImGui.Text("Z:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(75);
            if (ImGui.InputFloat("##Z Position", ref zPos));
            ImGui.SameLine();
            ImGui.Text("Tolerance:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Tolerance", ref tolerance));
            if (ImGui.Button("Vnav Moveto!"))
            {
                P.taskManager.Enqueue(() => TaskMoveTo.Enqueue(new Vector3(xPos, yPos, zPos), tolerance));
                ECommons.Logging.InternalLog.Information("Firing off Vnav Moveto");
            }
        }
    }
}
