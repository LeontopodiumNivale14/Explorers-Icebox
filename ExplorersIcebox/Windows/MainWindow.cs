using Dalamud.Interface.Components;
using ECommons.Configuration;
using ECommons.SimpleGui;
using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util.IslandData;
using Lumina.Excel.Sheets;
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

        private string[] options = { "Infinite", "x Times", "How to" }; // Dropdown options
        public static string runOptions = "Infinite";
        public static string currentlyDoing = SchedulerMain.CurrentProcess;

        public override void Draw()
        {
            if (ImGui.BeginTabBar("Main Menu Bar"))
            {
                if (ImGui.BeginTabItem("XP/Cowries Grind"))
                {
                    ImGui.Text("XP | Cowries Grind     ");
                    ImGui.SameLine();
                    ImGui.Text($"{currentlyDoing}");
                    ImGui.Spacing();
                    bool isRunning = SchedulerMain.AreWeTicking;
                    if (ImGui.Checkbox(" Enable Farm", ref isRunning))
                    {
                        if (isRunning)
                        {
                            SchedulerMain.EnablePlugin();
                        }
                        else
                        {
                            SchedulerMain.DisablePlugin();
                        }
                    }
                    ImGui.AlignTextToFramePadding();
                    ImGui.Text("Run Setting:   ");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(125);
                    if (ImGui.BeginCombo("##RunSettings", runOptions))
                    {
                        foreach (var option in options)
                        {
                            if (ImGui.Selectable(option, option == runOptions))
                            {
                                runOptions = option;
                            }
                            if (option == runOptions)
                            {
                                ImGui.SetItemDefaultFocus();
                            }
                        }
                        ImGui.EndCombo();
                    }
                    if (runOptions == options[0])
                    {
                        C.runInfinite = true;
                        EzConfig.Save();
                    }
                    else if (runOptions == options[1])
                    {
                        C.runInfinite = false;
                        ImGui.SameLine();
                        ImGui.SetNextItemWidth(100);
                        ImGui.InputInt("##RunAmount", ref C.runAmount);
                    }
                    ImGui.Spacing();
                    if (ImGui.RadioButton("Ground Loop ", C.routeSelected == 8))
                    {
                        C.routeSelected = 8; // Sets the option to 8 (Option #1)
                        PluginLog("Changed the selected route to Clay/Sand [Ground XP Loop]");
                    }
                    ImGui.SameLine();
                    ImGuiComponents.HelpMarker("Best to use from lv. 5 -> Lv. 10 \nThe slower of the two options, but doesn't require flying to be unlocked");
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
                        StoneImgui();
                        BranchImgui();
                        LogImgui();
                        ResinImgui();
                        SugarcaneImgui();
                        VineImgui();
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
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Max Island Materials"))
                {
                    ImGui.Text("This is where you'll be able to select what routes to run/what all you need to cap on");
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("How to"))
                {
                    ImGui.Text("XP | Cowries Grind");
                    ImGui.Text("The purpose of this mode is one of two reasons.");
                    ImGui.TextWrapped("-> Reason 1: A quick and surefire way to level up your characters. This uses what Overseas Casuals (aka Island Sanctuary Discord) consideres/have figured to be the best XP Routes.");
                    ImGui.TextWrapped("-> Reason 2: if you want to get green Cowries for things, this is also great! Personally use this to refill my cordial stash");
                    ImGui.NewLine();
                    ImGui.EndTabItem();
                }
                ImGui.EndTabBar();
            }
        }
        private void SettingImgui()
        {
            //Unused Settings, DON'T DELETE THIS... Need to figure where to place
            if (ImGuiEx.IconButton(FontAwesomeIcon.Wrench, "Workshop"))
                EzConfigGui.WindowSystem.Windows.FirstOrDefault(w => w.WindowName == SettingMenu.WindowName)!.IsOpen ^= true;
        }
    }
}
