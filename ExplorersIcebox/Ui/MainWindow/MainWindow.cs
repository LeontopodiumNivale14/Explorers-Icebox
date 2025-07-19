using Dalamud.Interface.Utility.Raii;
using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using System.Collections.Generic;

namespace ExplorersIcebox.Ui.MainWindow;

internal class MainWindow : Window
{
    public MainWindow() :
        base($"Explorer's Icebox {P.GetType().Assembly.GetName().Version} ###Explorer'sIceboxMainWindow")
    {
        Flags = ImGuiWindowFlags.None;
        SizeConstraints = new()
        {
            MinimumSize = new Vector2(300, 300),
            MaximumSize = new Vector2(2000, 2000)
        };
        P.windowSystem.AddWindow(this);
        AllowPinning = false;
    }

    public void Dispose() { }

    private static int ExtractNumber(string input)
    {
        // Use regex to find digits in the string
        var match = System.Text.RegularExpressions.Regex.Match(input, @"\d+");
        return match.Success ? int.Parse(match.Value) : int.MinValue; // or 0 if you prefer
    }

    public int selectedRoute = C.routeSelected;

    private readonly List<string> modeSelect = ["Ground XP", "Flying XP", "Material Grind"];
    private int selectedModeIndex = C.ModeSelected;
    private List<string> routeNames => EmbedRoutes.Routes.Keys.OrderBy(name => ExtractNumber(name)).ToList();

    public override void Draw()
    {
        ImGui.SetNextItemWidth(200);
        if (ImGui.BeginCombo("Select Mode", modeSelect[selectedModeIndex]))
        {
            for (int i = 0; i < modeSelect.Count; i++)
            {
                bool isSelected = (i == selectedModeIndex);
                if (ImGui.Selectable(modeSelect[i], isSelected))
                {
                    C.ModeSelected = i;
                    selectedModeIndex = i;
                    C.Save();
                }

                if (isSelected)
                {
                    ImGui.SetItemDefaultFocus();
                }
            }

            ImGui.EndCombo();
        }

        bool DisableSelection = selectedModeIndex < modeSelect.Count - 1;

        int selectedRouteIndex = C.routeSelected;

        if (selectedModeIndex == 2)
        {
            using (ImRaii.Disabled(DisableSelection))
            {
                ImGui.SetNextItemWidth(200);
                if (ImGui.BeginCombo("Select Route", routeNames[selectedRouteIndex]))
                {
                    for (int i = 0; i < routeNames.Count; i++)
                    {
                        bool isSelected = (i == selectedRouteIndex);
                        if (ImGui.Selectable(routeNames[i], isSelected))
                        {
                            selectedRouteIndex = i;
                            C.routeSelected = i;
                            C.Save();
                        }

                        if (isSelected)
                        {
                            ImGui.SetItemDefaultFocus();
                        }
                    }
                    ImGui.EndCombo();
                }
            }
        }

        if (selectedModeIndex == 0)
            selectedRouteIndex = 7;
        else if (selectedModeIndex == 1)
            selectedRouteIndex = 18;

        var routeSelected = EmbedRoutes.Routes.Where(x => x.Key == routeNames[selectedRouteIndex]).FirstOrDefault();

        if (EmbedRoutes.Routes.ContainsKey(routeSelected.Key))
        {
            Dictionary<string, IslandHelper.ItemGathered> routeItems = new();
            Dictionary<string, HashSet<ItemData.GatheringNode>> itemNodeMap = new();

            IslandHelper.CurrentRoute = routeSelected;

            foreach (var wp in routeSelected.Value.RouteWaypoints)
            {
                if (wp.TargetId != 0) // General check to make sure we're not looking for a null item
                {
                    var Node = ItemData.IslandNodeInfo.Where(x => x.Nodes.Contains(wp.TargetId)).FirstOrDefault();
                    if (Node != null)
                    {
                        foreach (var item in Node.ItemIds)
                        {
                            string itemName = ItemData.IslandItems[item].ItemName;
                            if (!routeItems.ContainsKey(itemName))
                            {
                                routeItems[itemName] = new IslandHelper.ItemGathered()
                                {
                                    Amount = 1,
                                    ItemId = item,
                                    GatherNodes = { Node.GatherName },
                                    IgnoreNode = false
                                };
                            }
                            else
                            {
                                routeItems[itemName].Amount += 1;
                                routeItems[itemName].GatherNodes.Add(Node.GatherName);
                            }

                            if (!itemNodeMap.ContainsKey(itemName))
                                itemNodeMap[itemName] = new();

                            itemNodeMap[itemName].Add(Node);
                        }
                    }
                }
            }

            foreach (var kvp in routeItems)
            {
                var itemName = kvp.Key;
                var gathered = kvp.Value;

                if (!itemNodeMap.TryGetValue(itemName, out var nodes)) continue;

                if (nodes.Count <= 1)
                {
                    gathered.IgnoreNode = false;
                }
                else
                {
                    gathered.IgnoreNode = nodes.Count > 1 && nodes.All(n => n.ItemIds.Count > 1);
                }
            }

            bool SkipSell = C.SkipSell;
            if (ImGui.Checkbox("Skip Selling Items", ref SkipSell))
            {
                C.SkipSell = SkipSell;
                C.Save();
            }

            bool RunMaxLoops = C.RunMaxLoops;
            if (ImGui.Checkbox("Run Maximum Loops", ref RunMaxLoops))
            {
                C.RunMaxLoops = RunMaxLoops;
                C.Save();
            }
            if (RunMaxLoops)
                IslandHelper.GoalLoopAmount = IslandHelper.MaxRouteLoops;

            bool runMultiple = C.RunMultiple;
            if (ImGui.Checkbox("Run multiple loops", ref runMultiple))
            {
                C.RunMultiple = runMultiple;
                C.Save();
            }
            if (runMultiple)
            {
                ImGui.SameLine();
                int RunAmount = C.RunAmount;
                ImGui.SetNextItemWidth(100);
                if (ImGui.InputInt("###RunMultipleAmount", ref RunAmount))
                {
                    C.RunAmount = RunAmount;
                    C.Save();
                }
            }

            int MinItemKeep = C.MinimumItemKeep;

            using (ImRaii.Disabled(SkipSell))
            {
                ImGui.SetNextItemWidth(100);
                if (ImGui.SliderInt("Keep this many items", ref MinItemKeep, 0, 999))
                {
                    C.MinimumItemKeep = MinItemKeep;
                    C.Save();
                }
            }
            bool DisableButtons = IslandHelper.GoalLoopAmount > IslandHelper.MaxRouteLoops || IslandHelper.MaxRouteLoops == 0;

            using (ImRaii.Disabled(DisableButtons))
            {
                if (ImGui.Button("Start"))
                {
                    SchedulerMain.EnablePlugin();
                }

                ImGui.SameLine();
                if (ImGui.Button("Stop"))
                {
                    SchedulerMain.DisablePlugin();
                }
            }

            if (DisableButtons)
            {
                ImGui.SameLine();
                ImGui.AlignTextToFramePadding();
                ImGuiEx.IconWithTooltip(FontAwesomeIcon.ExclamationTriangle, "The current setup is not possible without causing issues. \n" +
                    "Please adjust either how many items to keep, or how many you want to gather. ");
                ImGui.Spacing();
            }

            if (ImGui.BeginTable("Loop Info", 2, ImGuiTableFlags.SizingFixedFit))
            {
                ImGui.TableSetupColumn("Loop Amount");
                ImGui.TableSetupColumn("Maximum Possible Loops");

                ImGui.TableHeadersRow();

                // Table Body
                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.Text($"{IslandHelper.GoalLoopAmount}");

                ImGui.TableNextColumn();
                ImGui.Text($"{IslandHelper.MaxRouteLoops}");

                ImGui.EndTable();
            }

            ImGui.Separator();
            // Route Information

            IslandHelper.UpdateCounters(routeItems);

            if (ImGui.BeginTable("Gathered items", 5, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("Item");
                ImGui.TableSetupColumn("Item Per Loop");
                ImGui.TableSetupColumn("Ignore");
                ImGui.TableSetupColumn("Gather Amount");
                ImGui.TableSetupColumn("Current Amount");

                ImGui.TableHeadersRow();

                foreach (var item in routeItems)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"{item.Key}");
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.Text($"{item.Value.ItemId}");
                        ImGui.EndTooltip();
                    }

                    ImGui.TableNextColumn();
                    ImGui.Text($"{item.Value.Amount}");

                    ImGui.TableNextColumn();
                    Utils.FancyCheckmark(item.Value.IgnoreNode);

                    ImGui.TableNextColumn();
                    var GatherAmount = C.ItemGatherAmount[item.Key];
                    ImGui.SetNextItemWidth(200);
                    using (ImRaii.Disabled(RunMaxLoops))
                    {
                        if (ImGui.SliderInt($"###GatherAmount_{item.Key}", ref GatherAmount, 0, 999))
                        {
                            C.ItemGatherAmount[item.Key] = GatherAmount;
                            C.Save();
                        }
                    }

                    ImGui.TableNextColumn();
                    if (PlayerHelper.GetItemCount(item.Value.ItemId, out var count))
                        ImGui.Text($"{count}");

                }

                ImGui.EndTable();
            }
        }

#if DEBUG
        foreach (var item in IslandHelper.SellItems)
        {
            ImGui.Text($"{ItemData.IslandItems[item.Key].ItemName} | {item.Value}");
        }
#endif
    }
}
