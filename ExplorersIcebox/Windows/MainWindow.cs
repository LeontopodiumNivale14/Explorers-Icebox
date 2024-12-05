using Dalamud.Interface.Components;
using ECommons.Configuration;
using ECommons.SimpleGui;
using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util.IslandData;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

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
            if (ImGui.BeginTabBar("Test Tab Bar"))
            {
                if (ImGui.BeginTabItem("Current Window"))
                {
                    CurrentWindow();
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Test Tab"))
                {
                    ImGui.Text("Test tab is operational");
                    CurrentWindowV2();
                    ImGui.EndTabItem();
                }
                ImGui.EndTabBar();
            }
        }

        private void CurrentWindow()
        {
            ImGui.Text($"Route Selected: {RouteDataPoint[C.routeSelected].Name}");
            if (ImGui.RadioButton("Ground XP Route", C.routeSelected == 8))
            {
                C.routeSelected = 8; // Sets the option to 8 (Option #1)
                PluginLog("Changed the selected route to Clay/Sand [Ground XP Loop]");
            }
            if (ImGui.RadioButton("Flying/Fast XP Route", C.routeSelected == 19))
            {
                C.routeSelected = 19; // Sets the option to 19 (Option #2)
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
        private void CurrentWindowV2()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(4, 4));
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(4, 4));

            ImGui.Text("XP | Cowries Grind");
            if (ImGui.RadioButton("Ground Loop ", C.routeSelected == 8))
            {
                C.routeSelected = 8; // Sets the option to 8 (Option #1)
                PluginLog("Changed the selected route to Clay/Sand [Ground XP Loop]");
            }
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Best to use from lv. 5 -> Lv. 10 \nThe slower of the two options, but doesn't require flying to be unlocked");
            ImGui.SameLine();
            ImGui.Text("                   ");
            ImGui.SameLine();
            if (ImGui.RadioButton("Run Infinitely", C.runInfinite == true))
            {
                C.runInfinite = true;
                EzConfig.Save();
            }
            if (ImGui.RadioButton("Flying/Fast XP Route", C.routeSelected == 19))
            {
                C.routeSelected = 19; // Sets the option to 19 (Option #2)
                PluginLog("Changed the selected route to Quartz [Mountain XP Loop]");
            }
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Faster leveling route. Best use from Lv. 10+ \nFlying is REQUIRED to do this one.");
            ImGui.SameLine();
            ImGui.Text("    ");
            ImGui.SameLine();
            if (ImGui.RadioButton("Run x times", C.runInfinite == false))
            {
                C.runInfinite = false;
                EzConfig.Save();
            }
            if (!C.runInfinite)
            {
                ImGui.SameLine();
                ImGui.SetNextItemWidth(85);
                if (ImGui.InputInt("##RunAmount", ref C.runAmount))
                {
                    EzConfig.Save();
                }
            }
            ImGui.NewLine();
            ImGui.Text("Workshop Items");
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Input the amount of items that you want to keep from this loop.\nThis will automatically adjust how many loops of this route it can do.");

            if (C.routeSelected == 8)
            {
                ClayImgui();
                TinsandImgui();
                MarbleImgui();
                LimestoneImgui();
                BranchImgui();
                LogImgui();
                ResinImgui();
                SandImgui();
            }
            else if (C.routeSelected == 19)
            {
                QuartzImgui();
                IronOreImgui();
                DuriumSandImgui();
                LeucograniteImgui();
                StoneImgui();
            }
        }
    }
}
