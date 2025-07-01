using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using ECommons;
using ECommons.GameHelpers;
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

    private string[] debugTypes = ["Player Info", "Navmesh Debug", "Misc Info", "Route Sell", "Target Info", "Imgui Testing", "Island Node Finder", "Island Item Info", "Route Creator V3"];
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
                case 8: RouteEditorV3(); break;
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

    private bool PopupOpen = false;

    public class ItemGathered
    {
        public int Amount { get; set; }
        public List<string> GatherNodes { get; set; } = new();
    }

    public void RouteEditorV3() 
    {
        ImGui.Text("Route Editor");

        // Input for creating a new route
        ImGui.InputText("New Route Name", ref newRouteName, 64);
        if (ImGui.Button("Add Route") && !string.IsNullOrWhiteSpace(newRouteName))
        {
            if (!G.Routes.ContainsKey(newRouteName))
            {
                G.Routes[newRouteName] = new List<RouteClass.WaypointUtil> { new RouteClass.WaypointUtil() };
                G.Save();
            }
            newRouteName = "";
        }

        if (routeNames.Count > 0)
        {
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
        }

        ImGui.Separator();

        // Selected Route Details

        var routeSelected = G.Routes.Where(x => x.Key == routeNames[selectedRouteIndex]).FirstOrDefault();

        if (G.Routes.ContainsKey(routeSelected.Key))
        {
            Vector3 playerPos = Svc.ClientState.LocalPlayer?.Position ?? Vector3.Zero;
            ImGui.Text($"Player POS: {playerPos.X:F1}, {playerPos.Y:F1}, {playerPos.Z:F1}");

            if (ImGui.Button("Add Move To"))
            {
                if (playerPos != Vector3.Zero)
                {
                    routeSelected.Value.Add(new WaypointUtil
                    {
                        Action = WaypointAction.None,
                        X = playerPos.X,
                        Y = playerPos.Y,
                        Z = playerPos.Z,
                        Target = 0,
                        Mount = Player.Mounted,
                        Name = string.Empty
                    });
                }
                G.Save();
            }

            ImGui.SameLine();

            if (ImGui.Button("Add Interact"))
            {
                ulong target = Svc.ClientState.LocalPlayer?.TargetObjectId ?? 0;

                if (playerPos != Vector3.Zero)
                {
                    routeSelected.Value.Add(new WaypointUtil
                    {
                        Action = WaypointAction.IslandInteract,
                        X = playerPos.X,
                        Y = playerPos.Y,
                        Z = playerPos.Z,
                        Target = target,
                        Mount = Player.Mounted,
                        Name = Svc.Targets.Target?.Name.ToString() ?? "??"
                    });
                }
                G.Save();
            }

            for (int i = 0; i < routeSelected.Value.Count; i++)
            {
                var path = routeSelected.Value[i];

                string treeName = $"WP: {i + 1}";
                treeName += $" | {path.X:N1}, {path.Y:N1}, {path.Z:N1}";
                if (path.Target != 0 && path.Action == WaypointAction.IslandInteract)
                {
                    treeName += $" | Target: {path.Name}";
                }

                if (ImGui.CollapsingHeader(treeName, ImGuiTreeNodeFlags.DefaultOpen))
                {
                    // Remove WP
                    if (ImGui.Button($"Remove##{i}"))
                    {
                        routeSelected.Value.RemoveAt(i);
                        G.Save();
                        break; // Break loop since modifying collection
                    }

                    // Move Up
                    if (i > 0)
                    {
                        ImGui.SameLine();

                        if (ImGui.ArrowButton($"Up##{i}", ImGuiDir.Up))
                        {
                            var temp = routeSelected.Value[i - 1];
                            routeSelected.Value[i - 1] = routeSelected.Value[i];
                            routeSelected.Value[i] = temp;
                            G.Save();
                            break; // Break to prevent index issues
                        }
                    }

                    // Move Down

                    if (i < routeSelected.Value.Count - 1)
                    {
                        ImGui.SameLine();

                        if (ImGui.ArrowButton($"Down##{i}", ImGuiDir.Down))
                        {
                            var temp = routeSelected.Value[i + 1];
                            routeSelected.Value[i + 1] = routeSelected.Value[i];
                            routeSelected.Value[i] = temp;
                            G.Save();
                            break; // Break to prevent index issues
                        }
                    }

                    // X, Y, and Z Positioning
                    ImGui.AlignTextToFramePadding();

                    float PathX = path.X;
                    float PathY = path.Y;
                    float pathZ = path.Z;
                    float InputWidth = 75;

                    ImGui.Text("X");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(InputWidth);
                    if (ImGui.DragFloat("###X", ref PathX))
                    {
                        path.X = PathX;
                        G.Save();
                    }

                    ImGui.SameLine();

                    ImGui.Text("Y");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(InputWidth);
                    if (ImGui.DragFloat("###Y", ref PathY))
                    {
                        path.Y = PathY;
                        G.Save();
                    }

                    ImGui.SameLine();
                    ImGui.Text("Z");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(InputWidth);
                    if (ImGui.DragFloat("###Z", ref pathZ))
                    {
                        path.Z = pathZ;
                        G.Save();
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Current POS"))
                    {
                        if (playerPos != Vector3.Zero)
                        {
                            path.X = playerPos.X;
                            path.Y = playerPos.Y;
                            path.Z = playerPos.Z;
                            G.Save();
                        }
                    }

                    bool Mount = path.Mount;

                    if (ImGui.Checkbox("Mount", ref Mount))
                    {
                        path.Mount = Mount;
                        G.Save();
                    }

                    ImGui.AlignTextToFramePadding();
                    ImGui.Text("Action:");
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(150);
                    if (ImGui.BeginCombo("##Action", path.Action.ToString()))
                    {
                        foreach (WaypointAction action in Enum.GetValues(typeof(WaypointAction)))
                        {
                            if (ImGui.Selectable(action.ToString(), action == path.Action))
                            {
                                path.Action = action;
                                G.Save();
                            }
                        }
                        ImGui.EndCombo();
                    }

                    if (path.Action == WaypointAction.IslandInteract)
                    {
                        ImGui.AlignTextToFramePadding();
                        ImGui.Text($"Target: {path.Name} | ID: {path.Target}");
                        ImGui.SameLine();
                        if (ImGui.Button("Adjust Target"))
                        {
                            var newTarget = Svc.ClientState.LocalPlayer;
                            if (newTarget != null && newTarget.TargetObjectId != 0)
                            {
                                path.Target = newTarget.TargetObjectId;
                                path.Name = Svc.Targets.Target?.Name.ToString() ?? "??";

                                G.Save();
                            }
                        }
                    }
                }

                string popupId = $"Waypoint Options##{i}";

                if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
                {
                    ImGui.OpenPopup(popupId);
                }
                if (ImGui.BeginPopup(popupId, ImGuiWindowFlags.AlwaysAutoResize))
                {
                    ImGui.AlignTextToFramePadding();
                    ImGui.Text($"Options for WP {i + 1}");

                    if (ImGui.Button("Delete Waypoint"))
                    {
                        routeSelected.Value.RemoveAt(i);
                        G.Save();
                        ImGui.CloseCurrentPopup();
                        break; // Exit loop to avoid index issues
                    }

                    ImGui.SameLine();
                    if (ImGui.Button("Close"))
                    {
                        ImGui.CloseCurrentPopup();
                    }

                    ImGui.EndPopup();
                }
            }

        }
    }
}
