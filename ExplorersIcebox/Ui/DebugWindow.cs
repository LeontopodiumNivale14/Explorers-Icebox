using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using ECommons.GameHelpers;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using ExplorersIcebox.Util.PathCreation;
using Pictomancy;
using System.Collections.Generic;
using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;
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

    private string[] debugTypes = ["Player Info", "Navmesh Debug", "Misc Info", "Route Sell", "Target Info", "Imgui Testing", "Island Node Finder", "Island Item Info", "Route Creator V3", "Picto Testing"];
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
                case 5: TestGuiDebug(); EcommonsUpdate(); break;
                case 6: GatherPointID(); break;
                case 7: IslandItemInfo(); break;
                case 8: RouteEditorV3(); break;
                case 9: PictoTest(); break;
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
        if (ImGui.Button("Swap to island mode"))
        {
            Task_GatherMode.Enqueue();
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

    private int position = 0;
    private string popupText = string.Empty;

    private void TestGuiDebug()
    {
        if (ImGui.Button("Return to Island Base"))
        {
            Task_ReturnToBase.Enqueue();
        }

        if (ImGui.Button("Open Player Search"))
        {
            Utils.OpenPlayerSearch(15);
        }
        if (ImGui.Button("Open Friends"))
        {
            Utils.OpenPlayerSearch(13);
        }
        ImGui.SetNextItemWidth(100);
        ImGui.InputInt("###Position", ref position);
        ImGui.SameLine();
        ImGui.SetNextItemWidth(100);
        ImGui.InputText("###TextTest", ref popupText, 100);

        if (ImGui.Button("Test Text"))
        {
            Utils.ShowText(position, popupText);
        }
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
    private bool allWaypoints = false;
    private bool ShowTargets = false;
    private bool ShowTargetsName = false;

    private Dictionary<string, bool> editingRoutes = new();
    private Dictionary<string, string> tempNames = new();

    private int selectedRouteIndex = 0;
    private List<string> routeNames => G.Routes.Keys.ToList();
    private int currentGroup = 0;

    private bool PopupOpen = false;

    public class ItemGathered
    {
        public int Amount { get; set; }
        public HashSet<string> GatherNodes { get; set; } = new();
        public bool IgnoreNode { get; set; }
    }
    private Dictionary<string, ItemGathered> RouteItems = new();

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
                    }

                    if (isSelected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndCombo();
            }

            ImGui.SameLine();
            if (ImGui.Button("Remove Route"))
            {
                var Route = G.Routes.Where(x => x.Key == routeNames[selectedRouteIndex]).FirstOrDefault();
                G.Routes.Remove(Route);
                selectedRouteIndex -= 1;
                G.Save();
            }
        }

        ImGui.Separator();

        // Selected Route Details

        var routeSelected = G.Routes.Where(x => x.Key == routeNames[selectedRouteIndex]).FirstOrDefault();

        if (G.Routes.ContainsKey(routeSelected.Key))
        {
            ImGui.Checkbox("Display WP's", ref allWaypoints);

            ImGui.SameLine();

            ImGui.Checkbox("Show Targets", ref ShowTargets);
            if (ShowTargets)
            {
                ImGui.SameLine();
                ImGui.Checkbox("Show Target Name", ref ShowTargetsName);
            }

            if (ImGui.Button("Test Route"))
            {
                foreach (var wp in routeSelected.Value)
                {
                    List<Vector3> locationWP = new List<Vector3>();
                    locationWP.Add(wp.ToVector3());

                    Task_IslandInteract.Enqueue(locationWP, wp.Target, wp.Mount, wp.Fly);
                }
            }

            if (ImGui.Button("Stop"))
            {
                P.taskManager.Abort();
            }

            if (allWaypoints)
            {
                using (var drawList = PictoService.Draw())
                {
                    for (int i = 0; i < routeSelected.Value.Count; i++)
                    {
                        var wp = routeSelected.Value[i];

                        if (drawList == null)
                            return;

                        if (i < routeSelected.Value.Count - 1)
                        {
                            var nextWp = routeSelected.Value[i + 1];
                            drawList.AddLine(wp.ToVector3(), nextWp.ToVector3(), C.LineWidth, C.PictoLineColor);
                        }
                        drawList.AddDot(wp.ToVector3(), C.DotRadius, C.PictoWPColor);
                        Vector3 WPText = new Vector3(wp.X, wp.Y + C.TextFloatPlus, wp.Z);
                        drawList.AddText(WPText, C.PictoTextCol, $"{i + 1}", 0);

                        if (ShowTargets && wp.Target != 0)
                        {
                            IGameObject? target = Svc.Objects.Where(x => x.GameObjectId == wp.Target).FirstOrDefault();

                            if (target != null)
                            {
                                drawList.AddFanFilled(target.Position, C.DonutRadius.X, C.DonutRadius.Y, C.FanPosition.X, C.FanPosition.Y, C.PictoCircleColor);
                                if (ShowTargetsName)
                                {
                                    Vector3 TextPos = new Vector3(target.Position.X, target.Position.Y + C.TextFloatPlus, target.Position.Z);
                                    drawList.AddText(TextPos, C.PictoTextCol, $"{wp.Name}", 10.0f);
                                }
                            }
                        }
                    }
                }

                /*
                List<Vector3> newWPs = new List<Vector3>();
                foreach (var wp in routeSelected.Value)
                {
                    newWPs.Add(new Vector3(wp.X, wp.Y, wp.Z));
                }

                if (waypointList != newWPs)
                {
                    waypointList = newWPs;
                }

                SplatoonManager.RenderPath(waypointList, addPlayer: showTetherToPoint, addNumbers: true);
                */
            }

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

            if (ImGui.CollapsingHeader("Item Count"))
            {
                Dictionary<string, ItemGathered> tempRouteItems = new();
                Dictionary<string, HashSet<ItemData.GatheringNode>> tempItemNodeMap = new();

                foreach (var wp in routeSelected.Value)
                {
                    if (wp.Target != 0)
                    {
                        var Node = ItemData.IslandNodeInfo.Where(x => x.Nodes.Contains(wp.Target)).FirstOrDefault();
                        if (Node != null)
                        {
                            foreach (var item in Node.ItemIds)
                            {
                                string itemName = ItemData.IslandItems[item];
                                if (!tempRouteItems.ContainsKey(itemName))
                                {
                                    tempRouteItems[itemName] = new ItemGathered
                                    {
                                        Amount = 1,
                                        GatherNodes = { Node.GatherName },
                                        IgnoreNode = false
                                    };
                                }
                                else
                                {
                                    tempRouteItems[itemName].Amount += 1;
                                    tempRouteItems[itemName].GatherNodes.Add(Node.GatherName);
                                }

                                if (!tempItemNodeMap.ContainsKey(itemName))
                                    tempItemNodeMap[itemName] = new();

                                tempItemNodeMap[itemName].Add(Node);
                            }
                        }
                    }
                }

                foreach (var kvp in tempRouteItems)
                {
                    var itemName = kvp.Key;
                    var gathered = kvp.Value;

                    if (!tempItemNodeMap.TryGetValue(itemName, out var nodes)) continue;

                    if (nodes.Count <= 1)
                    {
                        gathered.IgnoreNode = false;
                    }
                    else
                    {
                        // Ignore only if ANY of the nodes contains other items too
                        gathered.IgnoreNode = nodes.Count > 1 && nodes.All(n => n.ItemIds.Count > 1);
                    }
                }

                if (RouteItems != tempRouteItems)
                    RouteItems = tempRouteItems;

                if (ImGui.BeginTable("Gathered Items", 5, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
                {
                    ImGui.TableSetupColumn("Item");
                    ImGui.TableSetupColumn("Amount");
                    ImGui.TableSetupColumn("Node Count");
                    ImGui.TableSetupColumn("Ignore");

                    ImGui.TableHeadersRow();

                    foreach (var item in RouteItems)
                    {
                        ImGui.TableNextRow();

                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text($"{item.Key}");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{item.Value.Amount}");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{item.Value.GatherNodes.Count}");

                        ImGui.TableNextColumn();
                        Utils.FancyCheckmark(item.Value.IgnoreNode);

                        ImGui.TableNextColumn();
                        var entry = tempItemNodeMap[item.Key];
                        string nodeNames = string.Empty;
                        foreach (var node in entry)
                        {
                            nodeNames += $"{node.GatherName} [{node.ItemIds.Count}], ";
                        }
                        ImGui.Text(nodeNames);
                        
                    }

                    ImGui.EndTable();
                }
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

                if (ImGui.CollapsingHeader(treeName, ImGuiTreeNodeFlags.None))
                {
                    if (ImGui.Button($"Test WP##Test_WP_{i}"))
                    {
                        List<Vector3> wpTest = new List<Vector3>();
                        wpTest.Add(path.ToVector3());

                        Task_IslandInteract.Enqueue(wpTest, path.Target, path.Mount, path.Fly);
                    }

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
                    bool Fly = path.Fly;

                    if (ImGui.Checkbox("Mount", ref Mount))
                    {
                        path.Mount = Mount;
                        if (!Mount && Fly)
                        {
                            Fly = false;
                            path.Fly = Fly;
                        }
                        G.Save();
                    }

                    ImGui.SameLine();
                    if (ImGui.Checkbox("Fly", ref Fly))
                    {
                        path.Fly = Fly;
                        if (!path.Mount)
                        {
                            path.Mount = true;
                        }

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

    private static uint ToUintABGR(Vector4 col)
    {
        byte a = (byte)(col.W * 255);
        byte b = (byte)(col.Z * 255);
        byte g = (byte)(col.Y * 255);
        byte r = (byte)(col.X * 255);
        return (uint)((a << 24) | (b << 16) | (g << 8) | r);
    }

    private static Vector4 FromUintABGR(uint color)
    {
        float a = ((color >> 24) & 0xFF) / 255f;
        float b = ((color >> 16) & 0xFF) / 255f;
        float g = ((color >> 8) & 0xFF) / 255f;
        float r = (color & 0xFF) / 255f;
        return new Vector4(r, g, b, a);
    }

    private static Vector4 ImGuiCircleCol = FromUintABGR(C.PictoCircleColor); // ABGR Red
    private static Vector4 ImGuiDotColor = FromUintABGR(C.PictoWPColor); // ABGR Red
    private static Vector4 ImGuiLineColor = FromUintABGR(C.PictoLineColor); // ABGR Red
    private static Vector4 ImGuiTextColor = FromUintABGR(C.PictoTextCol); // ABGR Red
    private static bool ShowDot = false;
    private static float DotRadius = C.DotRadius;
    private static bool ShowLine = false;
    private static float LineWidth = C.LineWidth;
    private static bool ShowCircle = false;
    private static bool ShowCircleOutline = false;
    private static bool ShowDonut = false;
    private static Vector2 DonutRadius = C.DonutRadius;
    private static Vector2 FanPosition = C.FanPosition;
    private static bool ShowVFX = false;
    private static bool ShowName = false;
    private static float FloatDistance = C.TextFloatPlus;
    private static float FloatTextScale = 0.0f;

    public void PictoTest()
    {
        ImGui.Text("Select a color:");

        if (ImGui.ColorEdit4("Circle Color", ref ImGuiCircleCol))
        {
            C.PictoCircleColor = ToUintABGR(ImGuiCircleCol);
            C.Save();
        }
        if (ImGui.ColorEdit4("Dot Color", ref ImGuiDotColor))
        {
            C.PictoWPColor = ToUintABGR(ImGuiDotColor);
            C.Save();
        }
        if (ImGui.ColorEdit4("Line Color", ref ImGuiLineColor))
        {
            C.PictoLineColor = ToUintABGR(ImGuiLineColor);
            C.Save();
        }
        if (ImGui.ColorEdit4("Text Color", ref ImGuiTextColor))
        {
            C.PictoTextCol = ToUintABGR(ImGuiTextColor);
            C.Save();
        }

        IGameObject? target = Svc.Targets.Target;
        var PlayerPos = Svc.ClientState.LocalPlayer?.Position ?? new Vector3(0);

        if (target != null)
        {
            using (var drawList = PictoService.Draw())
            {
                if (drawList == null)
                    return;
                // Draw a circle around a GameObject's hitbox
                Vector3 worldPosition = target.Position;
                float radius = target.HitboxRadius;

                ImGui.Checkbox("Show Dot", ref ShowDot);
                ImGui.SameLine();
                ImGui.SetNextItemWidth(100);

                if (ImGui.DragFloat("Dot Size", ref DotRadius, 0.2f))
                {
                    C.DotRadius = DotRadius;
                    C.Save();
                }
                ImGui.Checkbox("Show Line", ref ShowLine);
                ImGui.SameLine();
                ImGui.SetNextItemWidth(100);
                if (ImGui.DragFloat("Line Width", ref LineWidth, 0.1f))
                {
                    C.LineWidth = LineWidth;
                    C.Save();
                }
                ImGui.Checkbox("Show Circle", ref ShowCircle);
                ImGui.Checkbox("Show Circle Outline", ref ShowCircleOutline);
                ImGui.Checkbox("Show Fan/Donut", ref ShowDonut);
                ImGui.SetNextItemWidth(100);
                if (ImGui.DragFloat2("Inner | Outer Radius", ref DonutRadius, 0.1f))
                {
                    C.DonutRadius = DonutRadius;
                    C.Save();
                }
                ImGui.SetNextItemWidth(100);
                if (ImGui.DragFloat2("Start/End Position", ref FanPosition, 0.1f))
                {
                    C.FanPosition = FanPosition;
                    C.Save();
                }
                ImGui.Checkbox("Show VFX", ref ShowVFX);
                ImGui.Checkbox("Show Name", ref ShowName);
                ImGui.SameLine();
                ImGui.SetNextItemWidth(100);
                if (ImGui.DragFloat("Float Name", ref FloatDistance))
                {
                    C.TextFloatPlus = FloatDistance;
                    C.Save();
                }
                ImGui.SameLine();
                ImGui.SetNextItemWidth(100);
                ImGui.DragFloat("Scale", ref FloatTextScale);


                if (ShowDot)
                    drawList.AddDot(worldPosition, DotRadius, C.PictoWPColor);
                if (ShowLine && (PlayerPos != new Vector3(0)))
                    drawList.AddLine(PlayerPos, worldPosition, LineWidth, C.PictoLineColor);
                if (ShowCircle)
                    drawList.AddCircle(worldPosition, radius, C.PictoCircleColor);
                if (ShowCircleOutline)
                    drawList.AddCircleFilled(worldPosition, radius, C.PictoCircleColor);
                if (ShowDonut)
                    drawList.AddFanFilled(worldPosition, DonutRadius.X, DonutRadius.Y, FanPosition.X, FanPosition.Y, C.PictoCircleColor);
                if (ShowVFX)
                    PictoService.VfxRenderer.AddFan("TestId", worldPosition, DonutRadius.X, DonutRadius.Y, FanPosition.X, FanPosition.Y, ImGuiCircleCol);
                if (ShowName)
                {
                    Vector3 textWorldPosition = new Vector3(worldPosition.X, worldPosition.Y + FloatDistance, worldPosition.Z);
                    drawList.AddText(textWorldPosition, C.PictoTextCol, $"{target.Name.ToString()}", FloatTextScale);
                }
            }
        }
    }

    public void EcommonsUpdate()
    {
        if (GenericHelpers.TryGetAddonMaster<MJIHud>("MJIHud", out var mjiHud) && mjiHud.IsAddonReady)
        {
            ImGui.Text($"Current Level: {mjiHud.SanctuaryRank}");
            ImGui.Text($"Current Island XP: {mjiHud.CurrentIslandXP} | {mjiHud.NextIslandLevelXP}");
            ImGui.Text($"Island Cowries: {mjiHud.IslandersCowrie}");
            ImGui.Text($"Seafarers Cowries: {mjiHud.SeafarersCowrie}");
        }
    }
}
