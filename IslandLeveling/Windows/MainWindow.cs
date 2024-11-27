using ECommons.SimpleGui;
using IslandLeveling.Scheduler;
using IslandLeveling.Scheduler.Handers;

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

        public override void Draw()
        {
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
                P.taskManager.Enqueue(PlayerHandlers.MountUp);
            }
        }
    }
}
