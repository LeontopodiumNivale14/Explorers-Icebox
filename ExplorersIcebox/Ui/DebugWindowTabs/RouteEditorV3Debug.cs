using Dalamud.Game.ClientState.Objects.Types;
using ECommons.GameHelpers;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using ExplorersIcebox.Util.PathCreation;
using Pictomancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExplorersIcebox.Util.PathCreation.RouteClass;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class RouteEditorV3Debug
    {
        private static string NewRouteName = "";
        private static List<Vector3> WaypointList = new();
        private static bool AllWaypoints = false;
        private static bool ShowTargets = false;
        private static bool ShowTargetsName = false;

        private static int SelectedRouteIndex = 0;
        private static List<string> routeNames => G.OldRoutes.Keys.ToList();

        private static string RenamePopupInput = "";
        private static string RenamePopupOldName = "";
        private static bool RenamePopupOpen = false;

        public class ItemGathered
        {
            public int Amount { get; set; }
            public HashSet<string> GatherNodes { get; set; } = new();
            public bool IgnoreNode { get; set; }
        }
        private static Dictionary<string, ItemGathered> RouteItems = new();

        public static bool RenameRoute(string oldName, string newName)
        {
            if (G.OldRoutes.ContainsKey(oldName) && !G.OldRoutes.ContainsKey(newName))
            {
                G.OldRoutes[newName] = G.OldRoutes[oldName];
                G.OldRoutes.Remove(oldName);
                return true;
            }
            return false;
        }

        public static void Draw()
        {
            ImGui.Text("Route Editor");

            // Input for creating a new route
            ImGui.InputText("New Route Name", ref NewRouteName, 64);
            if (ImGui.Button("Add Route") && !string.IsNullOrWhiteSpace(NewRouteName))
            {
                if (!G.OldRoutes.ContainsKey(NewRouteName))
                {
                    G.OldRoutes[NewRouteName] = new List<RouteClass.WaypointUtil> { new RouteClass.WaypointUtil() };
                    G.Save();
                }
                NewRouteName = "";
            }

            if (routeNames.Count > 0)
            {
                ImGui.SameLine();

                ImGui.SetNextItemWidth(222);
                if (ImGui.BeginCombo("Select Route", routeNames[SelectedRouteIndex]))
                {
                    for (int i = 0; i < routeNames.Count; i++)
                    {
                        bool isSelected = (i == SelectedRouteIndex);
                        if (ImGui.Selectable(routeNames[i], isSelected))
                        {
                            SelectedRouteIndex = i;
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
                    var Route = G.OldRoutes.Where(x => x.Key == routeNames[SelectedRouteIndex]).FirstOrDefault();
                    G.OldRoutes.Remove(Route);
                    SelectedRouteIndex -= 1;
                    G.Save();
                }
            }

            ImGui.Separator();

            // Selected Route Details

            var routeSelected = G.OldRoutes.Where(x => x.Key == routeNames[SelectedRouteIndex]).FirstOrDefault();

            if (G.OldRoutes.ContainsKey(routeSelected.Key))
            {
                ImGui.Checkbox("Display WP's", ref AllWaypoints);

                ImGui.SameLine();

                ImGui.Checkbox("Show Targets", ref ShowTargets);
                if (ShowTargets)
                {
                    ImGui.SameLine();
                    ImGui.Checkbox("Show Target Name", ref ShowTargetsName);
                }

                if (ImGui.Button("Test Route"))
                {
                    List<Vector3> locationWP = new List<Vector3>();
                    bool Mount = false;
                    bool Fly = false;

                    foreach (var wp in routeSelected.Value)
                    {
                        locationWP.Add(wp.ToVector3());
                        Mount |= wp.Mount;
                        Fly |= wp.Fly;

                        if (wp.Target != 0)
                        {
                            Task_IslandInteract.Enqueue(new List<Vector3>(locationWP), wp.Target, Mount, Fly);
                            locationWP.Clear();
                            Mount = false;
                            Fly = false;
                        }
                    }

                    if (locationWP.Count > 0)
                    {
                        Task_IslandInteract.Enqueue(new List<Vector3>(locationWP), 0, Mount, Fly);
                    }
                }

                ImGui.SameLine();

                if (ImGui.Button("Stop"))
                {
                    P.taskManager.Abort();
                }

                if (ImGui.Button("Rename Selected Route") && routeNames.Count > SelectedRouteIndex)
                {
                    RenamePopupOldName = routeNames[SelectedRouteIndex];
                    RenamePopupInput = RenamePopupOldName;
                    ImGui.OpenPopup("RenameRoutePopup");
                    RenamePopupOpen = true;
                }

                if (ImGui.BeginPopup("RenameRoutePopup"))
                {
                    ImGui.Text("Enter new route name:");
                    ImGui.InputText("##RenameInput", ref RenamePopupInput, 64, ImGuiInputTextFlags.EnterReturnsTrue);

                    bool enterPressed = ImGui.IsItemDeactivatedAfterEdit();

                    if (ImGui.Button("Confirm Rename") || enterPressed)
                    {
                        if (!string.IsNullOrWhiteSpace(RenamePopupInput) &&
                            RenamePopupInput != RenamePopupOldName &&
                            !G.OldRoutes.ContainsKey(RenamePopupInput))
                        {
                            // Do the rename
                            G.OldRoutes[RenamePopupInput] = G.OldRoutes[RenamePopupOldName];
                            G.OldRoutes.Remove(RenamePopupOldName);

                            // Update your routeNames list if needed
                            routeNames[SelectedRouteIndex] = RenamePopupInput;

                            ImGui.CloseCurrentPopup();
                            RenamePopupOpen = false;
                            G.Save();
                        }
                    }

                    ImGui.SameLine();
                    if (ImGui.Button("Cancel"))
                    {
                        ImGui.CloseCurrentPopup();
                        RenamePopupOpen = false;
                    }

                    ImGui.EndPopup();
                }

                if (AllWaypoints)
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
                }

                Vector3 playerPos = Svc.ClientState.LocalPlayer?.Position ?? new Vector3(0, 0, 0);
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
                                    string itemName = ItemData.IslandItems[item].ItemName;
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
    }
}
