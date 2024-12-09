using Dalamud.Interface.Components;
using ECommons.Configuration;
using ECommons.SimpleGui;
using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util.IslandData;
using Lumina.Excel.Sheets;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace ExplorersIcebox.Windows;

public class MainWindow : ConfigWindow, IDisposable
{
    // need to figure out how to change this name for the main window...
    public static new readonly string WindowName = "Explorer's Icebox";

    private const uint SidebarWidth = 275;
    public MainWindow() { }
    public void Dispose() { }
    public static void SetWindowProperties()
    {
        var width = SidebarWidth;

        EzConfigGui.Window.Size = new Vector2(width, 600);
        EzConfigGui.Window.SizeConstraints = new()
        {
            MinimumSize = new Vector2(500, 400),
            MaximumSize = new Vector2(800, 800)
        };

        EzConfigGui.Window.SizeCondition = ImGuiCond.Always;

        EzConfigGui.Window.Flags |= ImGuiWindowFlags.AlwaysAutoResize;
        EzConfigGui.Window.Flags |= ImGuiWindowFlags.NoSavedSettings;

        EzConfigGui.Window.AllowClickthrough = false;
        EzConfigGui.Window.AllowPinning = false;
    }

    private string[] options = { "Infinite", "x Times"}; // Dropdown options
    public static string runOptions = "Infinite";
    private string[] modeSelect = { "XP | Cowries Grind", "Island Gathering Mode" };
    public static string currentMode = "XP | Cowries Grind";
    public static string currentlyDoing = SchedulerMain.CurrentProcess;
    private bool everythingUnlocked = true;
    private bool copyButton = false;
    private int updateAllWS = 0;

    public override void Draw()
    {
        if (IPC.NavmeshIPC.Installed && IPC.VislandIPC.Installed)
        {
            if (ImGui.BeginTabBar("Main Menu Bar"))
            {
                if (ImGui.BeginTabItem("XP/Cowries Grind"))
                {
                    ImGui.Text($"Current task --> {displayCurrentTask}");
                    ImGui.Text($"Route --> {displayCurrentRoute}");
                    bool isXPRunning = SchedulerMain.AreWeTicking;
                    if (ImGui.Checkbox(" Enable Farm", ref isXPRunning))
                    {
                        if (isXPRunning)
                        {
                            PluginLog("Enabling the route Gathering");
                            if (currentMode == "Island Gathering Mode") C.XPGrind = false;
                            if (currentMode == "XP | Cowries Grind") C.XPGrind = true;
                            SchedulerMain.EnablePlugin();
                            displayCurrentTask = "Currently Running";
                        }
                        else
                        {
                            PluginLog("Disabling the Route gathering");
                            displayCurrentTask = "";
                            SchedulerMain.DisablePlugin();
                        }
                    }
                    ImGui.SameLine();
                    ImGui.SetCursorPosX(offSet(140f));
                    if (ImGui.Checkbox("All Items Unlocked", ref everythingUnlocked))
                    {
                        if (everythingUnlocked)
                        {
                            C.everythingUnlocked = true;
                        }
                        else
                        {
                            C.everythingUnlocked = false;
                        }
                    }
                    ImGui.SetNextItemWidth(175);
                    if (ImGui.BeginCombo("##Mode Select Combo", currentMode))
                    {
                        foreach (var option in modeSelect)
                        {
                            // If this option is selected
                            if (ImGui.Selectable(option, option == currentMode))
                            {
                                currentMode = option;
                            }

                            // Set focus to the selected item for better UX
                            if (option == currentMode)
                            {
                                ImGui.SetItemDefaultFocus();
                            }
                        }
                        ImGui.EndCombo();
                    }
                    ImGui.Spacing();
                    if (currentMode == "XP | Cowries Grind")
                    {
                        GrindXPGui();
                        WorkshopImGui();
                    }
                    else if(currentMode == "Island Gathering Mode")
                    {
                        MaxIslandMatsGui();
                    }
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
        else if (IPC.NavmeshIPC.Installed && !IPC.VislandIPC.Installed)
        {
            ImGui.TextWrapped("You seem to be missing Visland. This is required to be installed");
            ImGui.Text("You can grab it by pressing the button here to copy the clipboard");
            if (ImGui.Button(copyButton ? "Copied Successfully" : "Copy Visland Link"))
            {
                ImGui.SetClipboardText("https://puni.sh/api/repository/veyn");
                copyButton = true;
            }

        }
        else if (!IPC.NavmeshIPC.Installed && IPC.VislandIPC.Installed)
        {
            ImGui.TextWrapped("You seem to be missing VNavmesh. This is required to be installed");
            ImGui.Text("You can grab it by pressing the button here to copy the clipboard");
            if (ImGui.Button(copyButton ? "Copied Successfully" : "Copy Navmesh Link"))
            {
                ImGui.SetClipboardText("https://puni.sh/api/repository/veyn");
                copyButton = true;
            }
        }
        else 
        {
            ImGui.TextWrapped("You seem to be missing VNavmesh AND Visland. This is required to be installed");
            ImGui.Text("You can grab it by pressing the button here to copy the clipboard");
            if (ImGui.Button(copyButton ? "Copied Successfully" : "Copy Visland AND Navmesh Link"))
            {
                ImGui.SetClipboardText("https://puni.sh/api/repository/veyn");
                copyButton = true;
            }
        }

    }

    private void GrindXPGui()
    {
        ImGui.Text("XP | Cowries Grind");
        ImGui.AlignTextToFramePadding();
        ImGui.Text("Run Setting:");
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
        if (ImGui.RadioButton("Ground Loop ", C.routeSelected == 7))
        {
            C.routeSelected = 7; // Sets the option to 8 (Option #1)
            PluginLog("Changed the selected route to Clay/Sand [Ground XP Loop]");
        }
        ImGui.SameLine();
        ImGuiComponents.HelpMarker("Best to use from lv. 5 -> Lv. 10 \nThe slower of the two options, but doesn't require flying to be unlocked");
        if (ImGui.RadioButton("Flying/Fast XP Route", C.routeSelected == 18))
        {
            C.routeSelected = 18; // Sets the option to 18 (Option #2)
            PluginLog("Changed the selected route to Quartz [Mountain XP Loop]");
        }
        ImGui.SameLine();
        ImGuiComponents.HelpMarker("Faster leveling route. Best use from Lv. 10+ \nFlying is REQUIRED to do this one.");

    }
    string searchQuery = ""; // Variable to store the search query
    private void MaxIslandMatsGui()
    {
        ImGui.InputText("Search", ref searchQuery, 100);
        ImGui.TextWrapped("Select which routes you would like to cap items from:");
        ImGui.Spacing();
        bool route0 = C.Route0;
        bool route1 = C.Route1;
        bool route2 = C.Route2;
        bool route3 = C.Route3;
        bool route4 = C.Route4;
        bool route5 = C.Route5;
        bool route6 = C.Route6;
        bool route7 = C.Route7;
        bool route8 = C.Route8;
        bool route9 = C.Route9;
        bool route10 = C.Route10;
        bool route11 = C.Route11;
        bool route12 = C.Route12;
        bool route13 = C.Route13;
        bool route14 = C.Route14;
        bool route15 = C.Route15;
        bool route16 = C.Route16;
        bool route17 = C.Route17;
        bool route18 = C.Route18;
        bool route19 = C.Route19;
        bool route20 = C.Route20;
        bool route21 = C.Route21;
        
        if (ImGui.Button("Enable All Routes"))
        {
            C.Route0 = true;
            C.Route1 = true;
            C.Route2 = true;
            C.Route3 = true;
            C.Route4 = true;
            C.Route5 = true;
            C.Route6 = true;
            C.Route7 = true;
            C.Route8 = true;
            C.Route9 = true;
            C.Route10 = true;
            C.Route11 = true;
            C.Route12 = true;
            C.Route13 = true;
            C.Route14 = true;
            C.Route15 = true;
            C.Route16 = true;
            C.Route17 = true;
            C.Route18 = true;
            C.Route19 = true;
            C.Route20 = true;
            C.Route21 = true;
            GatherAllUpdate();
            PluginLog("Enabled all routes");
        }
        ImGui.SameLine();
        if (ImGui.Button("Disable All Routes"))
        {
            C.Route0 = false;
            C.Route1 = false;
            C.Route2 = false;
            C.Route3 = false;
            C.Route4 = false;
            C.Route5 = false;
            C.Route6 = false;
            C.Route7 = false;
            C.Route8 = false;
            C.Route9 = false;
            C.Route10 = false;
            C.Route11 = false;
            C.Route12 = false;
            C.Route13 = false;
            C.Route14 = false;
            C.Route15 = false;
            C.Route16 = false;
            C.Route17 = false;
            C.Route18 = false;
            C.Route19 = false;
            C.Route20 = false;
            C.Route21 = false;
            GatherAllUpdate();
            PluginLog("Disabled all routes");

        }
        UpdateWSImGui();

        if (string.IsNullOrEmpty(searchQuery) || "Islefish | Clam [Route 0]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Islefish | Clam [Route 0]"))
            {
                if (ImGui.Checkbox("Enable Route 0", ref route0))
                {
                    if (route0)
                    {
                        C.Route0 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route0 = false;
                        GatherAllUpdate();
                    }
                }
                Route0WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Islewort [Route 1]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying is required, due to how going under water works...");
            if (ImGui.TreeNode("Islewort [Route 1]"))
            {
                if (ImGui.Checkbox("Enable Route 1", ref route1))
                {
                    if (route1)
                    {
                        C.Route1 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route1 = false;
                        GatherAllUpdate();
                    }
                }
                Route1WorkshopGui();
                ImGui.TreePop();
            }
        }

        if (string.IsNullOrEmpty(searchQuery) || "Sugarcane | Vine [Route 2]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Sugarcane | Vine [Route 2]"))
            {
                if (ImGui.Checkbox("Enable Route 2", ref route2))
                {
                    if (route2)
                    {
                        C.Route2 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route2 = false;
                        GatherAllUpdate();
                    }
                }
                Route2WorkshopGui();
                ImGui.TreePop();
            }
        }

        if (string.IsNullOrEmpty(searchQuery) || "Tinsand | Sand [Route 3]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Tinsand | Sand [Route 3]"))
            {
                if (ImGui.Checkbox("Enable Route 3", ref route3))
                {
                    if (route3)
                    {
                        C.Route3 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route3 = false;
                        GatherAllUpdate();
                    }
                }
                Route3WorkshopGui();
                ImGui.TreePop();
            }
        }

        if (string.IsNullOrEmpty(searchQuery) || "Apple | Beehive | Vine [Route 4]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Apple | Beehive | Vine [Route 4]"))
            {
                if (ImGui.Checkbox("Enable Route 4", ref route4))
                {
                    if (route4)
                    {
                        C.Route4 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route4 = false;
                        GatherAllUpdate();
                    }
                }
                Route4WorkshopGui();
                ImGui.TreePop();
            }
        }

        if (string.IsNullOrEmpty(searchQuery) || "Coconut | Palm Log | Palm leaf [Route 5]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Coconut | Palm Log | Palm leaf [Route 5]"))
            {
                if (ImGui.Checkbox("Enable Route 5", ref route5))
                {
                    if (route5)
                    {
                        C.Route5 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route5 = false;
                        GatherAllUpdate();
                    }
                }
                Route5WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Cotton [Route 6]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Cotton [Route 6]"))
            {
                if (ImGui.Checkbox("Enable Route 6", ref route6))
                {
                    if (route6)
                    {
                        C.Route6 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route6 = false;
                        GatherAllUpdate();
                    }
                }
                Route6WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Clay | Sand [Route 7]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Clay | Sand [Route 7]"))
            {
                if (ImGui.Checkbox("Enable Route 7", ref route7))
                {
                    if (route7)
                    {
                        C.Route7 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route7 = false;
                        GatherAllUpdate();
                    }
                }
                Route7WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Marble | Limestone | Stone [Route 8]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Marble | Limestone | Stone [Route 8]"))
            {
                if (ImGui.Checkbox("Enable Route 8", ref route8))
                {
                    if (route8)
                    {
                        C.Route8 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route8 = false;
                        GatherAllUpdate();
                    }
                }
                Route8WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Branch | Resin | Log [Route 9]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Branch | Resin | Log [Route 9]"))
            {
                if (ImGui.Checkbox("Enable Route 9", ref route9))
                {
                    if (route9)
                    {
                        C.Route9 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route9 = false;
                        GatherAllUpdate();
                    }
                }
                Route9WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Copper | Mythril [Route 10]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Copper | Mythril [Route 10]"))
            {
                if (ImGui.Checkbox("Enable Route 10", ref route10))
                {
                    if (route10)
                    {
                        C.Route10 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route10 = false;
                        GatherAllUpdate();
                    }
                }
                Route10WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Opal | Sap | (Log) [Route 11]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Opal | Sap | (Log) [Route 11]"))
            {
                if (ImGui.Checkbox("Enable Route 11", ref route11))
                {
                    if (route11)
                    {
                        C.Route11 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route11 = false;
                        GatherAllUpdate();
                    }
                }
                Route11WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Hemp | (Islewort) [Route 12]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Hemp | (Islewort) [Route 12]"))
            {
                if (ImGui.Checkbox("Enable Route 12", ref route12))
                {
                    if (route12)
                    {
                        C.Route12 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route12 = false;
                        GatherAllUpdate();
                    }
                }
                Route12WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Multicolorblooms [Route 13]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Multicolorblooms [Route 13]"))
            {
                if (ImGui.Checkbox("Enable Route 13", ref route13))
                {
                    if (route13)
                    {
                        C.Route13 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route13 = false;
                        GatherAllUpdate();
                    }
                }
                Route13WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Iron Ore [Route 14]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying required");
            if (ImGui.TreeNode("Iron Ore [Route 14]"))
            {
                if (ImGui.Checkbox("Enable Route 14", ref route14))
                {
                    if (route14)
                    {
                        C.Route14 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route14 = false;
                        GatherAllUpdate();
                    }
                }
                Route14WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Laver | Squid / Jellyfish | Coral [Route 15]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Laver | Squid / Jellyfish | Coral [Route 15]"))
            {
                if (ImGui.Checkbox("Enable Route 15", ref route15))
                {
                    if (route15)
                    {
                        C.Route15 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route15 = false;
                        GatherAllUpdate();
                    }
                }
                Route15WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Rocksalt [Route 16]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying is required, due to how going under water works...");
            if (ImGui.TreeNode("Rocksalt [Route 16]"))
            {
                if (ImGui.Checkbox("Enable Route 16", ref route16))
                {
                    if (route16)
                    {
                        C.Route16 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route16 = false;
                        GatherAllUpdate();
                    }
                }
                Route16WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Leucogranite [Route 17}".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Leucogranite [Route 17}"))
            {
                if (ImGui.Checkbox("Enable Route 17", ref route17))
                {
                    if (route17)
                    {
                        C.Route17 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route17 = false;
                        GatherAllUpdate();
                    }
                }
                Route17WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Quartz | Stone [Route 18]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Quartz | Stone [Route 18]"))
            {
                if (ImGui.Checkbox("Enable Route 18", ref route18))
                {
                    if (route18)
                    {
                        C.Route18 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route18 = false;
                        GatherAllUpdate();
                    }
                }
                Route18WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Glimshroom | Shale / Coal [Route 19]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying is required");
            if (ImGui.TreeNode("Glimshroom | Shale / Coal [Route 19]"))
            {
                if (ImGui.Checkbox("Enable Route 19", ref route19))
                {
                    if (route19)
                    {
                        C.Route19 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route19 = false;
                        GatherAllUpdate();
                    }
                }
                Route19WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Effervescent Water / Spectrine [Route 20]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {

            if (ImGui.TreeNode("Effervescent Water / Spectrine [Route 20]"))
            {
                if (ImGui.Checkbox("Enable Route 20", ref route20))
                {
                    if (route20)
                    {
                        C.Route20 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route20 = false;
                        GatherAllUpdate();
                    }
                }
                Route20WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(searchQuery) || "Yellow Copper | Gold | Crystal Formation | HawksEyeSand [Route 21]".Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Yellow Copper | Gold | Crystal Formation | HawksEyeSand [Route 21]"))
            {
                if (ImGui.Checkbox("Enable Route 21", ref route21))
                {
                    if (route21)
                    {
                        C.Route21 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route21 = false;
                        GatherAllUpdate();
                    }
                }
                Route21WorkshopGui();
                ImGui.TreePop();
            }
        }   
    }

    private void WorkshopImGui()
    {
        ImGui.Text("Workshop Items");
        ImGui.SameLine();
        ImGuiComponents.HelpMarker("Input the amount of items that you want to keep from this loop.\nThis will automatically adjust how many loops of this route it can do.");
        if (C.routeSelected == 7)
        {
            Route7WorkshopGui();
        }
        else if (C.routeSelected == 18)
        {
            Route18WorkshopGui();
        }
    }

    private void UpdateWSImGui()
    {
        int updateAll = updateAllWS;
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(106f));
        ImGui.SetNextItemWidth(85);
        if (ImGui.InputInt("##Update All Workshops", ref updateAll))
        {
            updateAllWS = updateAll;
            QuickWorkshopKeepUpdate(updateAllWS);
        }
        ImGuiComponents.HelpMarker("Quick way to update all workshops to the same value.");


    }

    private void SettingImgui()
    {
        //Unused Settings, DON'T DELETE THIS... Need to figure where to place
        if (ImGuiEx.IconButton(FontAwesomeIcon.Wrench, "Workshop"))
            EzConfigGui.WindowSystem.Windows.FirstOrDefault(w => w.WindowName == SettingMenu.WindowName)!.IsOpen ^= true;
    }
}
