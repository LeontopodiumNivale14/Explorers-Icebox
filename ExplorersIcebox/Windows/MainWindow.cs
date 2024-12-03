using ECommons.SimpleGui;
using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util.IslandData;

namespace ExplorersIcebox.Windows
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

        private string CurrentTask()
        {
            if (P.taskManager.NumQueuedTasks > 0 && P.taskManager.CurrentTask != null)
            {
                return P.taskManager.CurrentTask.Name?.ToString() ?? "None";
            }
            return "None";
        }

        private int amount = 0;

        public override void Draw()
        {
            ImGui.Text($"Route Selected: {RouteDataPoint[C.routeSelected].Name}");
            if (ImGui.RadioButton("Ground XP Route", C.routeSelected == 8))
            {
                C.routeSelected = 8; // Sets the option to 1 (Option #2)
                PluginLog("Changed the selected route to Clay/Sand [Ground XP Loop]");
            }
            if (ImGui.RadioButton("Flying/Fast XP Route", C.routeSelected == 19))
            {
                C.routeSelected = 19; // Sets the option to 0 (Option #1)
                PluginLog("Changed the selected route to Quartz [Mountain XP Loop]");
            }
            ImGui.Text($"Navmesh BuildProgress :" + P.navmesh.BuildProgress());//working ipc
            ImGui.Text($"Current task is: {CurrentTask()}");
            ImGui.Text($"Number of task: {P.taskManager.NumQueuedTasks}");
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
            if (ImGuiEx.IconButton(FontAwesomeIcon.Wrench, "Workshop"))
                EzConfigGui.WindowSystem.Windows.FirstOrDefault(w => w.WindowName == SettingMenu.WindowName)!.IsOpen ^= true;
            // this is kinda neat, there's...a HUGE section of icons. But not gonna fuck with this rn. Things to mess w/ later
            // if (ImGuiEx.IconButton(FontAwesomeIcon.))
            if (ImGui.Button("Mount up!"))
            {
                P.taskManager.Enqueue(() => TaskMountUp.Enqueue());
            }
            ImGui.SameLine();
            if (ImGui.Button("Target Test"))
            {
                while (amount < RouteAmount(C.routeSelected))
                {
                    TaskVislandTemp.Enqueue(VislandRoutes.QuartzVisland, $"{RouteDataPoint[C.routeSelected].Name}'s Route is running currently");
                    amount++;
                }
            }
        }
    }
}
