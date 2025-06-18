using Dalamud.Interface.Colors;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility.Raii;
using ECommons.Automation.LegacyTaskManager;
using ExplorersIcebox.Scheduler.Tasks;
using System.Collections.Generic;
using System.IO;
using static FFXIVClientStructs.FFXIV.Client.Graphics.Kernel.VertexShader;

namespace ExplorersIcebox.Ui;

internal class DebugWindow : Window
{
    public DebugWindow() :
        base($"Explorer's Icebox Debug {P.GetType().Assembly.GetName().Version}###Explorer's Icebox Debug")
    {
        Flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoCollapse;
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(100, 100),
            MaximumSize = new Vector2(2000, 2000)
        };
        P.windowSystem.AddWindow(this);
    }

    public void Dispose() { }

    // variables that hold the "ref"s for ImGui
    private string addonName = "default";
    private float xPos = 0;
    private float yPos = 0;
    private float zPos = 0;
    private int tolerance = 0;

    private bool callbackbool = false;
    private string testRoute = "";
    private int inputbox = 0;
    private ushort itemID = 0;
    private string inputValue = "0"; // The uint value to be edited
    private static ulong Result;
    private uint aetherID = 0;
    private uint aetherZone = 0;

    private string[] debugTypes = ["Player Info", "Navmesh Debug", "Misc Info", "Route Sell", "Target Info", "Imgui Testing", "Island Node Finder"];
    int selectedDebugIndex = 0; // This should be stored somewhere persistent

    public override void Draw()
    {
        float spacing = 10f;
        float leftPanelWidth = 200f;
        float rightPanelWidth = ImGui.GetContentRegionAvail().X - leftPanelWidth - spacing;
        float childHeight = ImGui.GetContentRegionAvail().Y;

        if (ImGui.BeginChild("DebugSelector", new System.Numerics.Vector2(leftPanelWidth, childHeight), true))
        {
            for (int i = 0; i < debugTypes.Length; i++)
            {
                bool isSelected = (selectedDebugIndex == i);
                string label = isSelected ? $"→ {debugTypes[i]}" : $"   {debugTypes[i]}"; // Add space for alignment

                if (ImGui.Selectable(label, isSelected))
                {
                    selectedDebugIndex = i;
                }
            }
            ImGui.EndChild();
        }

        ImGui.SameLine(0, spacing);

        if (ImGui.BeginChild("DebugContent", new System.Numerics.Vector2(rightPanelWidth, childHeight), true))
        {
            switch (selectedDebugIndex)
            {
                case 0: PlayerInfoDubug(); break;
                case 1: NavmeshInfoDebug(); break;
                case 2: MiscInfoDebug(); break;
                case 3: RouteSellDebug(); break;
                case 4: TargetInfo(); break;
                case 5: TestGuiDebug(); break;
                case 6: GatherPointID(); break;
                default: ImGui.Text("Unknown Debug View"); break;
            }

            ImGui.EndChild();
        }
    }

    private void PlayerInfoDubug()
    {
        ImGui.Text($"General Information");
        ImGui.Text($"TerritoryID: " + Svc.ClientState.TerritoryType);
        ImGui.Text($"Target: " + Svc.Targets.Target);
        ImGui.InputText("##Addon Visible", ref addonName, 100);
        ImGui.SameLine();
        ImGui.Text($"Addon Visible: ");
        ImGui.SameLine();
        if (IsAddonActive(addonName))
        {
            FontAwesome.Print(ImGuiColors.HealerGreen, FontAwesome.Check);
        }
        else if (!IsAddonActive(addonName))
        {
            FontAwesome.Print(ImGuiColors.DalamudRed, FontAwesome.Cross);
        }
        ImGui.Text($"Navmesh information");
        ImGui.Text($"PlayerPos: " + PlayerPosition());
        ImGui.Text($"Navmesh BuildProgress :" + P.navmesh.BuildProgress());//working ipc
        ImGui.Text($"Current task time remaining is: {P.taskManager.RemainingTimeMS}");
        ImGui.Text($"Current task is: {P.taskManager.CurrentTask}");

    }

    private void NavmeshInfoDebug()
    {
        ImGui.Text($"PlayerPos: " + PlayerPosition());
        ImGui.Text("X:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth(75);
        if (ImGui.InputFloat("##X Position", ref xPos))
        {
            xPos = (float)Math.Round(xPos, 2);
        }
        ImGui.SameLine();
        ImGui.Text("Y:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth(75);
        if (ImGui.InputFloat("##Y Position", ref yPos))
        {
            yPos = (float)Math.Round(yPos, 2);
        }
        ImGui.SameLine();
        ImGui.Text("Z:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth(75);
        if (ImGui.InputFloat("##Z Position", ref zPos))
        {
            zPos = (float)Math.Round(zPos, 2);
        }
        ImGui.SameLine();
        ImGui.Text("Tolerance:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth(100);
        ImGui.InputInt("##Tolerance", ref tolerance);
        if (ImGui.Button("Set to Current"))
        {
            xPos = (float)Math.Round(GetPlayerRawXPos(), 2);
            yPos = (float)Math.Round(GetPlayerRawYPos(), 2);
            zPos = (float)Math.Round(GetPlayerRawZPos(), 2);
        }
        ImGui.SameLine();
        if (ImGui.Button("Copy to clipboard"))
        {
            var clipboardText = $"{xPos}f, {yPos}f, {zPos}f";
            ImGui.SetClipboardText(clipboardText);
        }
        if (ImGui.Button("Copy Current POS to Clipboard"))
        {
            var currentXPos = (float)Math.Round(GetPlayerRawXPos(), 2);
            var currentYPos = (float)Math.Round(GetPlayerRawYPos(), 2);
            var currentZPos = (float)Math.Round(GetPlayerRawZPos(), 2);
            var clipboardText = $"new Vector3({currentXPos}f, {currentYPos}f, {currentZPos}f),";
            ImGui.SetClipboardText(clipboardText);
        }
        if (ImGui.Button("Vnav Moveto!"))
        {
            P.taskManager.Enqueue(() => TaskMoveTo.Enqueue(new Vector3(xPos, yPos, zPos), "Interact string", false, tolerance));
            ECommons.Logging.InternalLog.Information("Firing off Vnav Moveto");
        }
        if (ImGui.Button("Test Points"))
        {
            P.navmesh.MoveTo(new List<Vector3>(testPoints), false);
        }
        if (ImGui.Button("Test Points 2"))
        {
            TaskListMove.Enqueue(testPoints2, false);
        }
        if (ImGui.Button("Fly to Quartz Mountain"))
        {
            TaskListMove.Enqueue(Base2IslewortVnav, false);
        }
    }

    private void RouteSellDebug()
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

    private void MiscInfoDebug()
    {
        ImGui.Text("Callback Test");
        // Standard checkbox for a boolean variable
        ImGui.Checkbox("1st Item | 2nd Item", ref callbackbool);
        if (ImGui.Button("Addon Fire Test"))
        {
            if (callbackbool)
            {
                TaskCallback.Enqueue("MJIDisposeShop", true, 12, 0);
            }
            else if (callbackbool == false)
            {
                TaskCallback.Enqueue("MJIDisposeShop", true, 12, 1);
            }
        }
        ImGui.InputText("Route Base64", ref testRoute, 2000);
        if (ImGui.Button("Visland Test"))
        {
            TaskVislandTemp.Enqueue(testRoute, "Test Base64 Route");
        }
        ImGui.Text($"Quartz sell = {GetTable(C.routeSelected)[0].Sell}");
        if (ImGui.Button("Calculate sell"))
        {
            TableSellUpdate(GetTable(C.routeSelected));
        }

        // Input box
        ImGui.InputText("Enter a number", ref inputValue, 20);

        if (ImGui.Button("Submit"))
        {
            // Try to parse the input to a ulong
            if (ulong.TryParse(inputValue, out Result))
            {
                ImGui.Text($"Valid input! Parsed ulong: {Result}");
            }
            else
            {
                ImGui.Text("Invalid input. Please enter a valid number.");
            }
        }

        ImGui.Text($"Current Value: {inputValue}");

        if (ImGui.Button("Testing Targeting"))
        {
            TaskTarget.Enqueue(Result);
        }

        if (ImGui.Button("Testing ObjectID Target"))
        {
            TaskTargetObject.Enqueue(Result);
        }

        if (ImGui.Button("Teleport to POTD"))
        {
            TaskTeleport.Enqueue(5, 153);
        }

    }

    private void TestGuiDebug()
    {
        var unlocked = CheckIfItemLocked(itemID);
        ImGui.Text("Kinda where I just test all the gui things to see what they look like");
        ImGui.Text("Tree Nodes");
        if (ImGui.TreeNode("Settings")) // Example of treenode, note that these must end in TreePop();
        {
            ImGui.Text("Option 1");
            ImGui.Text("Option 2");
            if (ImGui.TreeNode("Example of a tree in a tree"))
            {
                ImGui.Text("Surprise tree");
                ImGui.TreePop();
            }
            ImGui.TreePop();
        }
        ImGui.Text($"Item {itemID} is {(unlocked ? "locked" : "unlocked")}");
        if (ImGui.InputInt("##ItemIDforText", ref inputbox))
        {
            inputbox = Math.Clamp(inputbox, ushort.MinValue, ushort.MaxValue);
            itemID = (ushort)inputbox;
        }
        if (ImGui.Button("Update Callback"))
        {
            TaskUpdateShopID.Enqueue();
        }
    }

    private void CheckMark()
    {
        var buttonColor = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];
        var buttonHovered = ImGui.GetStyle().Colors[(int)ImGuiCol.ButtonHovered];
        var buttonActive = ImGui.GetStyle().Colors[(int)ImGuiCol.ButtonActive];
        var windowBgColor = ImGui.GetStyle().Colors[(int)ImGuiCol.WindowBg];

        // Override the button colors to match the window background
        ImGui.PushStyleColor(ImGuiCol.Button, windowBgColor);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, windowBgColor);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, windowBgColor);

        using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.HealerGreen))
            ImGuiEx.IconButton(FontAwesomeIcon.Check);
        ImGui.PopStyleColor(3);
    }

    private void DisabledMark()
    {
        var buttonColor = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];
        var buttonHovered = ImGui.GetStyle().Colors[(int)ImGuiCol.ButtonHovered];
        var buttonActive = ImGui.GetStyle().Colors[(int)ImGuiCol.ButtonActive];
        var windowBgColor = ImGui.GetStyle().Colors[(int)ImGuiCol.WindowBg];

        // Override the button colors to match the window background
        ImGui.PushStyleColor(ImGuiCol.Button, windowBgColor);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, windowBgColor);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, windowBgColor);

        using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.DPSRed))
            ImGuiEx.IconButton(FontAwesomeIcon.FileCircleXmark);
        ImGui.PopStyleColor(3);
    }

    private void TargetInfo()
    {
        var target = Svc.Targets?.Target;

        if (target != null)
        {
            if (ImGui.Button($"Name: {target.Name}"))
            {
                ImGui.SetClipboardText($"GatherName = \"{target.Name}\",");
            }
            if (ImGui.Button($"Object ID: {target.GameObjectId}"))
            {
                ImGui.SetClipboardText($"{target.GameObjectId}");
            }
            if (ImGui.Button($"Data ID: {target.DataId}"))
            {
                ImGui.SetClipboardText($"{target.DataId}");
            }
        }
    }

    public static void DisplayItemData()
    {
        // Iterate over the dictionary
        foreach (var entry in IslandItemDict)
        {
            // Extract the key (Item ID) and value (ItemData)
            var itemId = entry.Key;
            var itemData = entry.Value;

            // Format the display text
            var displayText = $"Item ID: {itemId}, Callback: {itemData.Callback}";

            // Display the text using ImGui
            ImGui.Text(displayText);
        }
    }

    private readonly Dictionary<string, HashSet<ulong>> gatherNodeIds = new()
    {
        ["Agave Plant"] = new(),
        ["Bluish Rock"] = new(),
        ["Composite Rock"] = new(),
        ["Coral Formation"] = new(),
        ["Cotton Plant"] = new(),
        ["Crystal-banded Rock"] = new(),
        ["Glowing Fungus"] = new(),
        ["Island Apple Tree"] = new(),
        ["Island Crystal Cluster"] = new(),
        ["Large Shell"] = new(),
        ["Lightly Gnawed Pumpkin"] = new(),
        ["Mahogany Tree"] = new(),
        ["Mound of Dirt"] = new(),
        ["Multicolored Isleblooms"] = new(),
        ["Palm Tree"] = new(),
        ["Partially Consumed Cabbage"] = new(),
        ["Quartz Formation"] = new(),
        ["Rough Black Rock"] = new(),
        ["Seaweed Tangle"] = new(),
        ["Smooth White Rock"] = new(),
        ["Speckled Rock"] = new(),
        ["Stalagmite"] = new(),
        ["Submerged Sand"] = new(),
        ["Sugarcane"] = new(),
        ["Tualong Tree"] = new(),
        ["Wild Parsnip"] = new(),
        ["Wild Popoto"] = new(),
        ["Yellowish Rock"] = new(),
    };

    private float distance = 50f;
    private int nodeCount = 0;

    private void GatherPointID()
    {
        var objects = Svc.Objects.Where(e => e.ObjectKind == Dalamud.Game.ClientState.Objects.Enums.ObjectKind.CardStand);
        ImGui.DragFloat("Distance to object", ref distance);

        foreach (var obj in objects)
        {
            if (GetDistanceToPlayer(obj.Position) > distance)
            {
                continue;
            }

            if (gatherNodeIds.TryGetValue(obj.Name.ToString(), out var idSet))
            {
                idSet.Add(obj.GameObjectId);
            }
        }

        ImGui.Text($"Total Nodes Found: {nodeCount}");
        if (ImGui.Button("Reset"))
        {
            nodeCount = gatherNodeIds.Sum(pair => pair.Value.Count);
        }

        if (ImGuiEx.TreeNode("List of Nodes"))
        {
            if (ImGui.BeginTable("###ListofNodes", 4, ImGuiTableFlags.RowBg))
            {
                ImGui.TableSetupColumn("Item");
                ImGui.TableSetupColumn("ID");
                ImGui.TableSetupColumn("Distance");

                ImGui.TableHeadersRow();

                foreach (var obj in objects)
                {
                    if (GetDistanceToPlayer(obj.Position) > distance)
                    {
                        continue;
                    }

                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"{obj.Name.ToString()}");

                    ImGui.TableNextColumn();
                    if (ImGui.Selectable($"{obj.DataId}###{obj.Name.ToString()}"))
                    {
                        ImGui.SetClipboardText($"{obj.DataId}");
                    }

                    ImGui.TableNextColumn();
                    ImGui.Text($"{GetDistanceToPlayer(obj.Position)}");

                    ImGui.TableNextColumn();
            }

                ImGui.EndTable();
            }
        }

        if (ImGui.Button("Clear Listing"))
        {
            foreach (var entry in gatherNodeIds)
            {
                entry.Value.Clear();
            }
        }

        foreach (var entry in gatherNodeIds)
        {
            ImGui.AlignTextToFramePadding();
            ImGui.Text($"Item: {entry.Key} | Amount Found: {entry.Value.Count}");
            ImGui.SameLine();
            if (ImGui.Button($"Copy List ###List_{entry.Key}"))
            {
                string nodeIds = string.Empty;
                foreach (var id in entry.Value)
                {
                    nodeIds += id + ", ";
                }
                ImGui.SetClipboardText(nodeIds);
            }
        }
    }
}
