using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Utility.Raii;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util.PathCreation;
using Pictomancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExplorersIcebox.Util.PathCreation.RouteClass;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class RouteEditorV4Debug
    {
        private static string NewRouteName = "";
        private static List<Vector3> WaypointList = new();
        private static bool RouteWP = false;
        private static bool PathWP = false;
        private static bool ShowTargets = false;
        private static bool ShowTargetsName = false;

        private static int SelectedRouteIndex = 0;
        private static List<string> routeNames => G.Routes.Keys.ToList();

        private static string RenamePopupInput = "";
        private static string RenamePopupOldName = "";
        private static bool RenamePopupOpen = false;
        private class ItemGathered
        {
            public int Amount { get; set; }
            public HashSet<string> GatherNodes { get; set; } = new();
            public bool IgnoreNode { get; set; }
        }
        private static Dictionary<string, ItemGathered> RouteItems = new();

        private static bool RenameRoute(string oldName, string newName)
        {
            if (G.Routes.ContainsKey(oldName) && !G.Routes.ContainsKey(newName))
            {
                G.Routes[newName] = G.Routes[oldName];
                G.Routes.Remove(oldName);
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
                var newRoute = new RouteClass.RouteUtil();

                newRoute.BaseToLocation.Add(new RouteClass.InteractionUtil
                {
                    Name = "Base Start",
                    Waypoints = new List<Vector3>
                    {
                        new Vector3(0, 0, 0),
                    },
                    Action = RouteClass.WaypointAction.None,
                    TargetId = 0,
                    Mount = false,
                    Fly = false,
                });

                newRoute.RouteWaypoints.Add(new RouteClass.InteractionUtil
                {
                    Name = string.Empty,
                    Waypoints = new List<Vector3>
                    {
                        new Vector3(0, 0, 0),
                    },
                    Action = RouteClass.WaypointAction.None,
                    TargetId = 0,
                    Mount = false,
                    Fly = false,
                });

                G.Routes[NewRouteName] = newRoute;
                G.Save();
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
                    var Route = G.Routes.Where(x => x.Key == routeNames[SelectedRouteIndex]).FirstOrDefault();
                    G.Routes.Remove(Route);
                    SelectedRouteIndex -= 1;
                    G.Save();
                }
            }

            ImGui.Separator();

            var routeSelected = G.Routes.Where(x => x.Key == routeNames[SelectedRouteIndex]).FirstOrDefault();

            if (G.Routes.ContainsKey(routeSelected.Key))
            {
                ImGui.Checkbox("Display Route WP", ref RouteWP);
                ImGui.SameLine();
                ImGui.Checkbox("Display Path WP", ref PathWP);

                if (ImGui.Checkbox("Show Targets", ref ShowTargets))
                {
                    if (!ShowTargets && ShowTargetsName)
                    {
                        ShowTargetsName = false;
                    }
                }
                using (ImRaii.Disabled(!ShowTargets))
                {
                    ImGui.SameLine();
                    ImGui.Checkbox("Show Target Names", ref ShowTargetsName);
                }

                if (ImGui.Button("Base -> Gatherpoint"))
                {
                    foreach (var entry in routeSelected.Value.BaseToLocation)
                    {
                        List<Vector3> chainWPs = entry.Waypoints;
                        ulong targetId = entry.TargetId;
                        bool mount = entry.Mount;
                        bool fly = entry.Fly;

                        Task_IslandInteract.Enqueue(chainWPs, targetId, mount, fly);
                    }
                }

                ImGui.SameLine();

                if (ImGui.Button("Test Route"))
                {
                    foreach (var entry in routeSelected.Value.RouteWaypoints)
                    {
                        List<Vector3> chainWPs = entry.Waypoints;
                        ulong targetId = entry.TargetId;
                        bool mount = entry.Mount;
                        bool fly = entry.Fly;

                        Task_IslandInteract.Enqueue(chainWPs, targetId, mount, fly);
                    }
                }

                if (ImGui.Button("Stop"))
                {
                    P.taskManager.Abort();
                    P.navmesh.Stop();
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
                            !G.Routes.ContainsKey(RenamePopupInput))
                        {
                            // Do the rename
                            G.Routes[RenamePopupInput] = G.Routes[RenamePopupOldName];
                            G.Routes.Remove(RenamePopupOldName);

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

                if (PathWP || RouteWP)
                {
                    int wpNumber = 0;

                    using (var drawList = PictoService.Draw())
                    {
                        if (PathWP)
                        {
                            for (int i = 0; i < routeSelected.Value.BaseToLocation.Count; i++)
                            {
                                var baseWPs = routeSelected.Value.BaseToLocation;

                                var wpList = baseWPs[i];
                                if (drawList == null)
                                    return;

                                for (int x = 0; x < wpList.Waypoints.Count; x++) 
                                {
                                    var wp = wpList.Waypoints[x];

                                    if (x < wpList.Waypoints.Count - 1)
                                    {
                                        var nextWp = wpList.Waypoints[x + 1];
                                        drawList.AddLine(wp, nextWp, C.LineWidth, C.PictoLineColor);
                                    }

                                    drawList.AddDot(wp, C.DotRadius, C.PictoWPColor);
                                    Vector3 WpText = new Vector3(wp.X, wp.Y + C.TextFloatPlus, wp.Z);
                                    wpNumber++;
                                    drawList.AddText(WpText, C.PictoTextCol, $"{wpNumber}", 0);

                                    if (ShowTargets && wpList.TargetId != 0)
                                    {
                                        IGameObject? target = Svc.Objects.Where(x => x.GameObjectId == wpList.TargetId).FirstOrDefault();

                                        if (target != null)
                                        {
                                            drawList.AddFanFilled(target.Position, C.DonutRadius.X, C.DonutRadius.Y, C.FanPosition.X, C.FanPosition.Y, C.PictoCircleColor);
                                            if (ShowTargetsName)
                                            {
                                                Vector3 TextPos = new Vector3(target.Position.X, target.Position.Y + C.TextFloatPlus, target.Position.Z);
                                                drawList.AddText(TextPos, C.PictoTextCol, $"{wpList.Name}", 10.0f);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Vector3 playerPos = Svc.ClientState.LocalPlayer?.Position ?? new Vector3(0, 0, 0);
                ImGui.Text($"Player POS: {playerPos.X:F1}, {playerPos.Y:F1}, {playerPos.Z:F1}");

                for (int i = 0; i < routeSelected.Value.BaseToLocation.Count; i++)
                {
                    var BaseList = routeSelected.Value.BaseToLocation[i];

                    if (ImGui.CollapsingHeader($"Base -> Location #{i} ###Base_Location_{i}"))
                    {
                        if (ImGui.Button("Add WP"))
                        {
                            BaseList.Waypoints.Add(playerPos);
                            G.Save();
                        }

                        bool Mount = BaseList.Mount;
                        bool Fly = BaseList.Fly;

                        if (ImGui.Checkbox("Mount", ref Mount))
                        {
                            BaseList.Mount = Mount;
                            if (Mount == false)
                                BaseList.Fly = false;
                            G.Save();
                        }
                        ImGui.SameLine();
                        if (ImGui.Checkbox("Fly", ref Fly))
                        {
                            BaseList.Fly = Fly;
                            if (Fly)
                                BaseList.Mount = true;
                            G.Save();
                        }

                        ImGui.AlignTextToFramePadding();
                        ImGui.AlignTextToFramePadding();
                        ImGui.Text("Action:");
                        ImGui.SameLine();
                        ImGui.SetNextItemWidth(150);
                        if (ImGui.BeginCombo($"##Action{i}", BaseList.Action.ToString()))
                        {
                            foreach (WaypointAction action in Enum.GetValues(typeof(WaypointAction)))
                            {
                                if (ImGui.Selectable(action.ToString(), action == BaseList.Action))
                                {
                                    BaseList.Action = action;
                                    G.Save();
                                }
                            }
                            ImGui.EndCombo();
                        }

                        if (BaseList.Action == WaypointAction.IslandInteract)
                        {
                            ImGui.AlignTextToFramePadding();
                            ImGui.Text($"Target: {BaseList.Name} | ID: {BaseList.TargetId}");
                            ImGui.SameLine();
                            if (ImGui.Button("Adjust Target"))
                            {
                                var newTarget = Svc.ClientState.LocalPlayer;
                                if (newTarget != null && newTarget.TargetObjectId != 0)
                                {
                                    BaseList.TargetId = newTarget.TargetObjectId;
                                    BaseList.Name = Svc.Targets.Target?.Name.ToString() ?? "??";

                                    G.Save();
                                }
                            }
                        }

                        if (ImGui.BeginTable($"Base -> Location #{i}", 5, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
                        {
                            ImGui.TableSetupColumn("#");
                            ImGui.TableSetupColumn("Position");
                            ImGui.TableSetupColumn("###Adjust");
                            ImGui.TableSetupColumn("Move WP");
                            ImGui.TableSetupColumn("Remove");

                            ImGui.TableHeadersRow();

                            for (int j = 0; j < BaseList.Waypoints.Count; j++)
                            {
                                ImGui.TableNextRow();

                                var wp = BaseList.Waypoints[j];

                                // Waypoint Info
                                ImGui.TableSetColumnIndex(0);
                                ImGui.AlignTextToFramePadding();
                                ImGui.Text($"{j + 1}");

                                // Waypoint Position
                                ImGui.TableNextColumn();
                                ImGui.AlignTextToFramePadding();
                                ImGui.Text($"{wp.X:N2} {wp.Y:N2} {wp.Z:N2}");

                                // Adjust Button
                                ImGui.TableNextColumn();
                                if (ImGui.Button($"Adjust##Adjust_{i}_{j}"))
                                {
                                    BaseList.Waypoints[j] = playerPos;
                                    G.Save();
                                }

                                // Move WP's Up | Down
                                ImGui.TableNextColumn();
                                if (j > 0)
                                {
                                    if (ImGui.ArrowButton($"UP##{j}", ImGuiDir.Up))
                                    {
                                        (BaseList.Waypoints[j - 1], BaseList.Waypoints[j]) = (BaseList.Waypoints[j], BaseList.Waypoints[j - 1]);
                                        G.Save();
                                    }
                                }

                                if (j < BaseList.Waypoints.Count - 1)
                                {
                                    ImGui.SameLine();
                                    if (ImGui.ArrowButton($"Down##{j}", ImGuiDir.Down))
                                    {
                                        (BaseList.Waypoints[j + 1], BaseList.Waypoints[j]) = (BaseList.Waypoints[j], BaseList.Waypoints[j + 1]);
                                        G.Save();
                                    }
                                }

                                // Remove the WP
                                ImGui.TableNextColumn();
                                if (ImGui.Button($"Remove##Remove_{i}_{j}"))
                                {
                                    BaseList.Waypoints.RemoveAt(j);
                                    G.Save();
                                    j--;
                                }
                            }

                            ImGui.EndTable();
                        }
                    }
                }
            }
        }
    }
}
