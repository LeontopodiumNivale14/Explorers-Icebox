using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using ECommons.SplatoonAPI;
using ExplorersIcebox.Config;
using ExplorersIcebox.IPC;
using ExplorersIcebox.Util;
using ExplorersIcebox.Util.PathCreation;
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

    private string[] debugTypes = ["Player Info", "Navmesh Debug", "Misc Info", "Route Sell", "Target Info", "Imgui Testing", "Island Node Finder", "Island Item Info", "Route Creator"];
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
                case 8: DrawRouteEditor(); break;
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
    private Vector3 newWaypoint = Vector3.Zero;
    private List<Vector3> waypointList = new();

    public void DrawRouteEditor()
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

        // Show's each of the route entries
        foreach (var kvp in G.Routes)
        {
            var routeName = kvp.Key;
            var groups = kvp.Value.FirstOrDefault(); // just using first group

            if (groups == null)
                continue;

            if (ImGui.CollapsingHeader($"{routeName}##Header"))
            {

                if (ImGui.Button($"Add Group##{routeName}"))
                {
                    kvp.Value.Add(new WaypointGroup
                    {
                        Action = WaypointAction.None,
                        Waypoints = new()
                    });
                    G.Save();
                }

                for (int groupIndex = 0; groupIndex < kvp.Value.Count; groupIndex++)
                {
                    var group = kvp.Value[groupIndex];

                    ImGui.PushID($"{routeName}_Group_{groupIndex}");

                    if (ImGui.CollapsingHeader($"Group {groupIndex + 1}"))
                    {
                        ImGui.Text($"Group {groupIndex + 1}");

                        if (ImGui.BeginCombo("Action", group.Action.ToString()))
                        {
                            foreach (WaypointAction action in Enum.GetValues(typeof(WaypointAction)))
                            {
                                if (ImGui.Selectable(action.ToString(), action == group.Action))
                                {
                                    group.Action = action;
                                    G.Save();
                                }
                            }
                            ImGui.EndCombo();
                        }

                        Vector3 playerPos = Svc.ClientState.LocalPlayer?.Position ?? Vector3.Zero;
                        ImGui.Text($"Player POS: {playerPos.X:F1}, {playerPos.Y:F1}, {playerPos.Z:F1}");

                        if (ImGui.Button($"Add Current Pos##Add_Pos_{routeName}"))
                        {
                            group.Waypoints.Add(WaypointUtil.FromVector3(playerPos));
                            G.Save();
                        }

                        ImGui.Separator();

                        for (int i = 0; i < group.Waypoints.Count; i++)
                        {
                            var wp = group.Waypoints[i];

                            ImGui.Text($"#{i + 1}: X:{wp.X:F1} Y:{wp.Y:F1} Z:{wp.Z:F1}");
                            ImGui.SameLine();

                            if (i > 0 && ImGui.Button($"↑##Up_{routeName}_{i}"))
                            {
                                (group.Waypoints[i - 1], group.Waypoints[i]) = (group.Waypoints[i], group.Waypoints[i - 1]);
                                G.Save();
                            }
                            ImGui.SameLine();
                            if (i < group.Waypoints.Count - 1 && ImGui.Button($"↓##Down_{routeName}_{i}"))
                            {
                                (group.Waypoints[i + 1], group.Waypoints[i]) = (group.Waypoints[i], group.Waypoints[i + 1]);
                                G.Save();
                            }
                            ImGui.SameLine();

                            ImGui.PushFont(UiBuilder.IconFont);
                            if (ImGui.Button($"{FontAwesome.Trash}##Delete_{routeName}_{i}")) // need to change this to trash can from ecoms
                            {
                                group.Waypoints.RemoveAt(i);
                                G.Save();
                                ImGui.PopFont();
                                break; // break to avoid index issues
                            }
                            ImGui.PopFont();
                        }
                    }
                    ImGui.PopID();
                }

                int index = 0;

                if (ImGui.CollapsingHeader($"All WP's###WPViewer_{routeName}"))
                {
                    foreach (var entry in kvp.Value)
                    {
                        foreach (var wp in entry.Waypoints)
                        {
                            if (!waypointList.Contains(wp.ToVector3()))
                                waypointList.Add(wp.ToVector3());
                        }
                    }

                    if (ImGui.Button("Remove WP's"))
                    {
                        waypointList.Clear();
                        break;
                    }

                    foreach (var wp in waypointList)
                    {
                        index++;
                        ImGui.Text($"[{index}] X: {wp.X} | Y: {wp.Y} | Z: {wp.Z}");
                    }

                    SplatoonManager.RenderPath(waypointList, addNumbers: true);
                }
            }

            // Remove entire route
            ImGui.Text($"Route: [{routeName}]");
            ImGui.SameLine();
            if (ImGui.Button($"Remove##Remove_{routeName}"))
            {
                G.Routes.Remove(routeName);
                G.Save();
                break; // To avoid modifying collection during foreach
            }

            ImGui.Separator();
        }
    }

}
