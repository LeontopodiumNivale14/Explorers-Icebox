using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Utility.Raii;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util.PathCreation;
using Pictomancy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class BaseRouteEditor
    {
        private static string NewRouteName = "";
        private static bool RouteWP = false;
        private static bool PathWP = false;
        private static bool ShowTargets = false;
        private static bool ShowTargetsName = false;

        private static int SelectedRouteIndex = 0;
        private static List<string> BaseRouteNames => G.BaseRoutes.Keys.ToList();

        public static void Draw()
        {
            ImGui.Text("Route Editor");

            // Input for creating a new route
            ImGui.InputText("New Route Name", ref NewRouteName, 64);
            if (ImGui.Button("Add Route") && !string.IsNullOrWhiteSpace(NewRouteName))
            {
                var newRoute = new RouteClass.InteractionUtil();

                newRoute.Name = "Base Start";
                newRoute.Waypoints = new List<Vector3>
                {
                    new Vector3(0, 0, 0),
                };
                newRoute.Action = RouteClass.WaypointAction.None;
                newRoute.TargetId = 0;
                newRoute.Mount = false;
                newRoute.Fly = false;

                G.BaseRoutes[NewRouteName] = newRoute;
                G.Save();
            }

            if (BaseRouteNames.Count > 0)
            {
                ImGui.SameLine();

                ImGui.SetNextItemWidth(222);
                if (ImGui.BeginCombo("Select Route", BaseRouteNames[SelectedRouteIndex]))
                {
                    for (int i = 0; i < BaseRouteNames.Count; i++)
                    {
                        bool isSelected = (i == SelectedRouteIndex);
                        if (ImGui.Selectable(BaseRouteNames[i], isSelected))
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
                    var Route = G.Routes.Where(x => x.Key == BaseRouteNames[SelectedRouteIndex]).FirstOrDefault();
                    G.Routes.Remove(Route);
                    SelectedRouteIndex -= 1;
                    G.Save();
                }
            }

            ImGui.Separator();

            var routeSelected = G.BaseRoutes.Where(x => x.Key == BaseRouteNames[SelectedRouteIndex]).FirstOrDefault();

            if (routeSelected.Key != null)
            {
                if (G.BaseRoutes.ContainsKey(routeSelected.Key))
                {
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

                    // - - - - - - - //

                    if (ImGui.Button("Test Route"))
                    {
                        Task_SellItems.Enqueue();
                    }
                    if (ImGui.Button("Reverse Route"))
                    {
                        List<Vector3> wpList = new();
                        foreach (var waypoint in routeSelected.Value.Waypoints)
                        {
                            wpList.Add(waypoint);
                        }
                        wpList.Reverse();
                        Task_IslandInteract.Enqueue(wpList, 0);
                    }

                    ImGui.SameLine();
                    if (ImGui.Button("Stop"))
                    {
                        P.taskManager.Abort();
                        P.navmesh.Stop();
                    }

                    if (PathWP)
                    {
                        int wpNumber = 0;

                        using (var drawList = PictoService.Draw())
                        {
                            if (drawList == null)
                                return;

                            for (int x = 0; x < routeSelected.Value.Waypoints.Count; x++)
                            {
                                var wp = routeSelected.Value.Waypoints[x];

                                if (x < routeSelected.Value.Waypoints.Count - 1)
                                {
                                    var nextWp = routeSelected.Value.Waypoints[x + 1];
                                    drawList.AddLine(wp, nextWp, C.LineWidth, C.PictoLineColor);
                                }

                                drawList.AddDot(wp, C.DotRadius, C.PictoWPColor);
                                Vector3 wpText = new Vector3(wp.X, wp.Y + C.TextFloatPlus, wp.Z);
                                wpNumber++;
                                drawList.AddText(wpText, C.PictoTextCol, $"{wpNumber}", 0);

                                if (ShowTargets && routeSelected.Value.TargetId != 0)
                                {
                                    IGameObject? target = Svc.Objects.Where(x => x.DataId == routeSelected.Value.TargetId).FirstOrDefault();

                                    if (target != null)
                                    {
                                        drawList.AddFanFilled(target.Position, C.DonutRadius.X, C.DonutRadius.Y, C.FanPosition.X, C.FanPosition.Y, C.PictoCircleColor);
                                        if (ShowTargetsName)
                                        {
                                            Vector3 TextPos = new Vector3(target.Position.X, target.Position.Y + C.TextFloatPlus, target.Position.Z);
                                            drawList.AddText(TextPos, C.PictoTextCol, $"{target.Name}", 10.0f);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    ImGui.Separator();

                    Vector3 playerPos = new Vector3(0, 0, 0);
                    ulong targetId = 0;

                    if (Svc.ClientState.LocalPlayer != null)
                        playerPos = Svc.ClientState.LocalPlayer.Position;
                    if (Svc.Targets.Target != null)
                        targetId = Svc.Targets.Target.DataId;

                    ImGui.AlignTextToFramePadding();    
                    ImGui.Text($"Target DatId: {routeSelected.Value.TargetId}");
                    if (routeSelected.Value.TargetId != 0)
                    {
                        ImGui.SameLine();
                        if (ImGui.Button("Clear Target"))
                        {
                            routeSelected.Value.TargetId = 0;
                            G.Save();
                        }
                    }

                    if (targetId != 0)
                    {
                        ImGui.SameLine();
                        if (ImGui.Button($"Set Target: {targetId}"))
                        {
                            routeSelected.Value.TargetId = targetId;
                            G.Save();
                        }
                    }

                    ImGui.Text($"X: {playerPos.X:N2}, Y: {playerPos.Y:N2}, Z: {playerPos.Z:N2}");

                    if (ImGui.Button("Add Current WP"))
                    {
                        routeSelected.Value.Waypoints.Add(playerPos);
                        G.Save();
                    }
                    
                    if (ImGui.BeginTable("Base route waypoints", 6, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
                    {
                        ImGui.TableSetupColumn("#");
                        ImGui.TableSetupColumn("X");
                        ImGui.TableSetupColumn("Y");
                        ImGui.TableSetupColumn("Z");
                        ImGui.TableSetupColumn("Adjust");
                        ImGui.TableSetupColumn("Remove");

                        ImGui.TableHeadersRow();

                        for (int i = 0; i < routeSelected.Value.Waypoints.Count; i++)
                        {
                            var wp = routeSelected.Value.Waypoints[i];

                            ImGui.TableNextRow();
                            ImGui.TableSetColumnIndex(0);

                            ImGui.AlignTextToFramePadding();
                            ImGui.Text($"{i + 1}");

                            ImGui.TableNextColumn();
                            ImGui.AlignTextToFramePadding();
                            ImGui.Text($"{wp.X:N2}");

                            ImGui.TableNextColumn();
                            ImGui.AlignTextToFramePadding();
                            ImGui.Text($"{wp.Y:N2}");

                            ImGui.TableNextColumn();
                            ImGui.AlignTextToFramePadding();
                            ImGui.Text($"{wp.Z:N2}");

                            ImGui.TableNextColumn();
                            if (ImGui.Button($"Adjust ###Adjust_{wp}_{i}"))
                            {
                                routeSelected.Value.Waypoints[i] = playerPos;
                                G.Save();
                            }

                            ImGui.TableNextColumn();
                            if (ImGui.Button($"Remove ###Remove_{wp}_{i}"))
                            {
                                routeSelected.Value.Waypoints.Remove(wp);
                                G.Save();
                                i--;
                            }

                        }

                        ImGui.EndTable();
                    }
                }
            }
        }
    }
}
