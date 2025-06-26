using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using ECommons.SplatoonAPI;
using ECommons.Throttlers;
using ExplorersIcebox.Config;
using ExplorersIcebox.IPC;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using ExplorersIcebox.Util.PathCreation;
using System;
using System.Collections.Generic;
using static ExplorersIcebox.Util.PathCreation.RouteClass;

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

    private string[] debugTypes = ["Player Info", "Navmesh Debug", "Misc Info", "Route Sell", "Target Info", "Imgui Testing", "Island Node Finder", "Island Item Info", "Route Creator V2"];
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
                case 1: ImGui.Text("Need to fix navmesh info"); break;
                case 2: MiscInfoDebug(); break;
                case 3: RouteSellDebug(); break;
                case 4: TargetInfo(); break;
                case 5: TestGuiDebug(); break;
                case 6: GatherPointID(); break;
                case 7: IslandItemInfo(); break;
                case 8: DrawRouteEditorV2(); break;
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
        if (AddonHelper.IsAddonActive(addonName))
        {
            FontAwesome.Print(ImGuiColors.HealerGreen, FontAwesome.Check);
        }
        else if (!AddonHelper.IsAddonActive(addonName))
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
    }

    private void TestGuiDebug()
    {

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
            if (PlayerHelper.GetDistanceToPlayer(obj.Position) > distance)
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
                    if (PlayerHelper.GetDistanceToPlayer(obj.Position) > distance)
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
                    ImGui.Text($"{PlayerHelper.GetDistanceToPlayer(obj.Position)}");

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

    private Dictionary<string, int> itemCount = new();

    private void IslandItemInfo()
    {
        foreach (var item in ItemData.IslandItems)
        {
            if (!itemCount.ContainsKey(item.Value))
            {
                itemCount.Add(item.Value, 0);
            }
        }

        if (ImGui.Button("Update Item Amounts"))
        {
            var IslandItems = Util.ItemData.IslandItems;

            foreach (var gatherable in Util.ItemData.IslandNodeInfo)
            {
                int amount = gatherable.Nodes.Count;
                foreach (var type in gatherable.ItemIds)
                {
                    string itemName = IslandItems[type];
                    itemCount[itemName] += amount;
                }
            }
        }

        ImGui.SameLine();

        if (ImGui.Button("Clear"))
        {
            itemCount.Clear();
        }

        if (ImGui.BeginTable("###ListofNodes", 2, ImGuiTableFlags.RowBg))
        {
            ImGui.TableSetupColumn("Item");
            ImGui.TableSetupColumn("Amount");

            ImGui.TableHeadersRow();

            foreach (var item in itemCount)
            {
                ImGui.TableNextRow();

                ImGui.TableSetColumnIndex(0);
                ImGui.Text(item.Key);

                ImGui.TableNextColumn();
                ImGui.Text(item.Value.ToString());
            }

            ImGui.EndTable();
        }
    }

    private string newRouteName = "";
    private List<Vector3> waypointList = new();
    private bool RefreshList = true;

    private Dictionary<string, bool> editingRoutes = new();
    private Dictionary<string, string> tempNames = new();

    private int selectedRouteIndex = 0;
    private List<string> routeNames => G.Routes.Keys.ToList();
    private int currentGroup = 0;
    private bool allWaypoints = true;

    private bool allWPs = false;
    private bool onlyGroupWps = false;

    public class ItemGathered
    {
        public int Amount { get; set; }
        public List<string> GatherNodes { get; set; } = new();
    }

    public void DrawRouteEditorV2()
    {
        ImGui.Text("Route Editor");

        // Input for creating a new route
        ImGui.InputText("New Route Name", ref newRouteName, 64);
        if (ImGui.Button("Add Route") && !string.IsNullOrWhiteSpace(newRouteName))
        {
            if (!G.Routes.ContainsKey(newRouteName))
            {
                G.Routes[newRouteName] = new List<RouteClass.WaypointGroup> { new RouteClass.WaypointGroup() };
                G.Save();
            }
            newRouteName = "";
        }

        ImGui.SameLine();

        ImGui.SetNextItemWidth(222);
        if (ImGui.BeginCombo("Select Route", routeNames[selectedRouteIndex]))
        {
            for (int i = 0; i < routeNames.Count; i++)
            {
                bool isSelected = (i == selectedRouteIndex);
                if (ImGui.Selectable(routeNames[i], isSelected))
                {
                    selectedRouteIndex = i;

                    // These are to reset the group selection so code doesn't break
                    currentGroup = 0;
                    allWaypoints = true;
                }

                if (isSelected)
                {
                    ImGui.SetItemDefaultFocus();
                }
            }
            ImGui.EndCombo();
        }

        var routeSelected = G.Routes.Where(x => x.Key == routeNames[selectedRouteIndex]).FirstOrDefault();
        var SelectedGroup = routeSelected.Value[currentGroup];

        if (G.Routes.ContainsKey(routeSelected.Key))
        {
            List<string> groups = new List<string>();
            foreach (var group in routeSelected.Value)
            {
                groups.Add(group.Name);
            }

            float GroupWindowText = ImGui.CalcTextSize("All Waypoints").X;
            float padding = 20.0f;

            ImGui.Dummy(new(0, 5));

            if (ImGui.BeginChild("Group Selection", new Vector2(GroupWindowText + padding, ImGui.GetContentRegionAvail().Y), true))
            {
                if (ImGui.Selectable("All Waypoints"))
                {
                    allWaypoints = true;
                }

                ImGui.Separator();

                for (int groupIndex = 0; groupIndex < routeSelected.Value.Count; groupIndex++)
                {
                    if (ImGui.Selectable($"Group {groupIndex + 1}"))
                    {
                        allWaypoints = false;
                        currentGroup = groupIndex;
                    }
                }

                ImGui.EndChild();
            }

            ImGui.SameLine();

            if (ImGui.BeginChild("View Group Contents", new Vector2(0, ImGui.GetContentRegionAvail().Y), true))
            {
                if (ImGui.Checkbox("Show All WP's", ref allWPs))
                {
                    if (onlyGroupWps)
                        onlyGroupWps = false;
                }
                ImGui.SameLine();
                if (ImGui.Checkbox("Only Groups WPs", ref onlyGroupWps))
                {
                    if (allWPs)
                        allWPs = false;
                }
                if (ImGui.Button($"Add Group##{routeSelected.Key}"))
                {
                    routeSelected.Value.Add(new WaypointGroup
                    {
                        Waypoints = new()
                    });
                    G.Save();
                }

                if (allWaypoints)
                {
                    int index = 0;
                    ImGui.Text("All Waypoints");

                    if (ImGui.Button("Test Route"))
                    {
                        P.navmesh.MoveTo(new List<Vector3>(waypointList), false);
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Test Interact Route"))
                    {
                        foreach (var entry in routeSelected.Value)
                        {
                            foreach (var wp in entry.Waypoints)
                            {
                                List<Vector3> wpList = new List<Vector3>();
                                wpList.Add(wp.ToVector3());

                                Task_MoveAction.Enqueue(wpList, wp.Target);
                            }
                        }
                    }

                    ImGui.Checkbox("Refresh List", ref RefreshList);
                    if (RefreshList)
                    {
                        if (EzThrottler.Throttle("List Refresh_Debug", 1000))
                        {
                            List<Vector3> tempList = new List<Vector3>();
                            foreach (var entry in routeSelected.Value)
                            {
                                foreach (var wp in entry.Waypoints)
                                {
                                    if (!tempList.Contains(wp.ToVector3()))
                                        tempList.Add(wp.ToVector3());
                                }
                            }

                            if (waypointList != tempList)
                            {
                                waypointList = tempList;
                            }
                        }
                    }

                    if (ImGui.CollapsingHeader($"Waypoints###Waypoints_{routeSelected.Key}"))
                    {
                        foreach (var wp in waypointList)
                        {
                            index++;
                            ImGui.Text($"[{index}] X: {wp.X} | Y: {wp.Y} | Z: {wp.Z}");
                        }
                    }

                    if (ImGui.CollapsingHeader($"Items Gathered###Items_Gathered_{routeSelected.Key}"))
                    {
                        Dictionary<string, ItemGathered> ItemList = new();
                        foreach (var entry in routeSelected.Value)
                        {
                            foreach (var wp in entry.Waypoints)
                            {
                                if (wp.Target != 0)
                                {
                                    var node = ItemData.IslandNodeInfo.Where(x => x.Nodes.Contains(wp.Target)).FirstOrDefault();

                                    if (node != null)
                                    {
                                        foreach (var item in node.ItemIds)
                                        {
                                            string itemName = ItemData.IslandItems[item];
                                            string nodeName = node.GatherName;

                                            if (!ItemList.ContainsKey(itemName))
                                            {
                                                ItemList[itemName] = new ItemGathered()
                                                {
                                                    Amount = 1,
                                                    GatherNodes = new List<string>() { nodeName }
                                                };
                                            }
                                            else if (ItemList.ContainsKey(itemName))
                                            {
                                                ItemList[itemName].Amount += 1;
                                                if (!ItemList[itemName].GatherNodes.ContainsAny(nodeName))
                                                {
                                                    ItemList[itemName].GatherNodes.Add(nodeName);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (ImGui.BeginTable("###Items_Gathered_Table", 3, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
                        {
                            foreach (var entry in ItemList)
                            {
                                ImGui.TableNextRow();

                                ImGui.TableSetColumnIndex(0);

                                ImGui.Text($"{entry.Key} ");

                                ImGui.TableNextColumn();

                                ImGui.Text($"{entry.Value.Amount}");

                                ImGui.TableNextColumn();
                                ImGui.Text($"{entry.Value.GatherNodes.Count}");
                            }

                            ImGui.EndTable();
                        }
                    }

                    SplatoonManager.RenderPath(waypointList, addNumbers: true);
                }
                else
                {
                    ImGui.SameLine();

                    if (ImGui.Button($"Remove Group###{routeSelected.Key}"))
                    {
                        routeSelected.Value.Remove(SelectedGroup);
                        currentGroup = 0;
                        allWaypoints = true;
                        G.Save();
                    }

                    ImGui.Text($"Group: {currentGroup + 1}");

                    /*

                    if (ImGui.BeginCombo("Action", SelectedGroup ))
                    {
                        foreach (WaypointAction action in Enum.GetValues(typeof(WaypointAction)))
                        {
                            if (ImGui.Selectable(action.ToString(), action == SelectedGroup.Action))
                            {
                                SelectedGroup.Action = action;
                                G.Save();
                            }
                        }
                        ImGui.EndCombo();
                    }

                    if (SelectedGroup.Action == WaypointAction.IslandInteract)
                    {
                        if (SelectedGroup.Target == 0)
                        {
                            ImGui.AlignTextToFramePadding();
                            ImGui.Text("No Target Selected");
                            if (Svc.Targets?.Target != null)
                            {
                                ImGui.SameLine();
                                if (ImGui.Button($"Add Target: {Svc.Targets.Target.Name.ToString()}"))
                                {
                                    SelectedGroup.Target = Svc.Targets.Target.GameObjectId;
                                    G.Save();
                                }
                            }
                        }
                        else
                        {
                            ImGui.AlignTextToFramePadding();
                            ImGui.Text($"TargetId: {SelectedGroup.Target}");
                            ImGui.SameLine();
                            if (ImGui.Button("Clear Target"))
                            {
                                SelectedGroup.Target = 0;
                                G.Save();
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("Target Object"))
                            {
                                Task_Target.Enqueue(SelectedGroup.Target);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("Interact"))
                            {
                                IGameObject? gameObject = null;
                                Utils.TryGetObjectByGameObjectId(SelectedGroup.Target, out gameObject);
                                Utils.InteractWithObject(gameObject);
                            }
                        }
                    }

                    */

                    Vector3 playerPos = Svc.ClientState.LocalPlayer?.Position ?? Vector3.Zero;
                    ImGui.Text($"Player POS: {playerPos.X:F1}, {playerPos.Y:F1}, {playerPos.Z:F1}");

                    if (ImGui.Button($"Add Current Pos##Add_Pos_{routeSelected.Key}"))
                    {
                        SelectedGroup.Waypoints.Add(WaypointUtil.FromVector3(playerPos));
                        G.Save();
                    }

                    ImGui.Dummy(new Vector2(0, 2));

                    ImGui.Separator();

                    ImGui.Dummy(new Vector2(0, 2));

                    if (ImGui.BeginTable("WaypointTable", 8, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
                    {
                        // Dynamically-sized columns
                        ImGui.TableSetupColumn("#");
                        ImGui.TableSetupColumn("X");
                        ImGui.TableSetupColumn("Y");
                        ImGui.TableSetupColumn("Z");
                        ImGui.TableSetupColumn("Adjust");
                        ImGui.TableSetupColumn("MoveTo");
                        ImGui.TableSetupColumn("↕"); // Up/Down
                        ImGui.TableSetupColumn("🗑"); // Trash

                        // Custom header row
                        ImGui.TableNextRow(ImGuiTableRowFlags.Headers);

                        ImGui.TableSetColumnIndex(0); ImGui.Text("#");
                        ImGui.TableNextColumn(); ImGui.Text("X");
                        ImGui.TableNextColumn(); ImGui.Text("Y");
                        ImGui.TableNextColumn(); ImGui.Text("Z");
                        ImGui.TableNextColumn(); ImGui.Text("Adjust");
                        ImGui.TableNextColumn(); ImGui.Text("MoveTo");

                        ImGui.TableNextColumn();
                        ImGui.PushFont(UiBuilder.IconFont);
                        ImGui.Text(FontAwesomeIcon.ArrowsUpDown.ToIconString()); // or whichever FontAwesome icon matches ↕
                        ImGui.PopFont();

                        ImGui.TableNextColumn();
                        ImGui.PushFont(UiBuilder.IconFont);
                        ImGui.Text(FontAwesomeIcon.Trash.ToIconString());
                        ImGui.PopFont();


                        for (int i = 0; i < SelectedGroup.Waypoints.Count; i++)
                        {
                            var wp = SelectedGroup.Waypoints[i];
                            ImGui.TableNextRow();

                            // Column 0: Index
                            ImGui.TableNextColumn();
                            ImGui.Text($"{i + 1}");

                            // Column 1: X
                            ImGui.TableNextColumn();
                            ImGui.Text($"{wp.X:F1}");

                            // Column 2: Y
                            ImGui.TableNextColumn();
                            ImGui.Text($"{wp.Y:F1}");

                            // Column 3: Z
                            ImGui.TableNextColumn();
                            ImGui.Text($"{wp.Z:F1}");

                            // Column 4: Adjust to current PoS
                            ImGui.TableNextColumn();
                            if (ImGui.Button($"Adjust###Adjust_{i+1}_{SelectedGroup.Name}"))
                            {
                                playerPos = Svc.ClientState.LocalPlayer?.Position ?? Vector3.Zero;
                                wp.X = playerPos.X;
                                wp.Y = playerPos.Y;
                                wp.Z = playerPos.Z;
                                G.Save();
                                break;
                            }

                            ImGui.TableNextColumn();
                            if (ImGui.Button($"MoveTo###MoveTo_{i+1}_{SelectedGroup.Name}"))
                            {
                                List<Vector3> moveToPoint = new List<Vector3>() { wp.ToVector3() };
                                P.navmesh.MoveTo(moveToPoint, false);
                            }

                            // Column 6: Up/Down Arrows
                            ImGui.TableNextColumn();
                            ImGui.PushFont(UiBuilder.IconFont);

                            bool moved = false;

                            if (i > 0 && ImGui.Button($"{FontAwesomeIcon.ArrowUp.ToIconString()}##Up_{routeSelected.Key}_{i}"))
                            {
                                (SelectedGroup.Waypoints[i - 1], SelectedGroup.Waypoints[i]) = (SelectedGroup.Waypoints[i], SelectedGroup.Waypoints[i - 1]);
                                G.Save();
                                moved = true;
                            }

                            if (!moved && i < SelectedGroup.Waypoints.Count - 1 && ImGui.Button($"{FontAwesomeIcon.ArrowDown.ToIconString()}##Down_{routeSelected.Key}_{i}"))
                            {
                                (SelectedGroup.Waypoints[i + 1], SelectedGroup.Waypoints[i]) = (SelectedGroup.Waypoints[i], SelectedGroup.Waypoints[i + 1]);
                                G.Save();
                            }

                            ImGui.PopFont();

                            // Column 7: Delete
                            ImGui.TableNextColumn();
                            ImGui.PushFont(UiBuilder.IconFont);
                            if (ImGui.Button($"{FontAwesomeIcon.Trash.ToIconString()}##Delete_{routeSelected.Key}_{i}"))
                            {
                                SelectedGroup.Waypoints.RemoveAt(i);
                                G.Save();
                                ImGui.PopFont();
                                break;
                            }
                            ImGui.PopFont();
                        }

                        ImGui.EndTable();
                    }
                }

                ImGui.EndChild();
            }
        }
    }
}
