using Dalamud.Interface.Utility.Raii;
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

    public int selectedRoute = C.routeSelected;

    private readonly List<string> modeSelect = ["Ground XP", "Flying XP", "Material Grind"];
    private int selectedModeIndex = C.ModeSelected;
    private List<string> routeNames => G.OldRoutes.Keys.ToList();
    private int selectedRouteIndex = 0;

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
                    }

                    if (isSelected)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndCombo();
            }
        }

        var routeSelected = G.OldRoutes.Where(x => x.Key == routeNames[selectedRouteIndex]).FirstOrDefault();

        if (G.OldRoutes.ContainsKey(routeSelected.Key))
        {
            Dictionary<string, IslandHelper.ItemGathered> routeItems = new();
            Dictionary<string, HashSet<ItemData.GatheringNode>> itemNodeMap = new();

            IslandHelper.CurrentRoute = routeSelected;

            foreach (var wp in routeSelected.Value)
            {
                if (wp.Target != 0) // General check to make sure we're not looking for a null item
                {
                    var Node = ItemData.IslandNodeInfo.Where(x => x.Nodes.Contains(wp.Target)).FirstOrDefault();
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

            int MinItemKeep = C.MinimumItemKeep;
            ImGui.SetNextItemWidth(100);
            if (ImGui.SliderInt("Keep this many items", ref MinItemKeep, 0, 999))
            {
                C.MinimumItemKeep = MinItemKeep;
                C.Save();
            }

            ImGui.Text($"Total Loops Amount: {IslandHelper.MaxTotalLoops}");
            ImGui.Text($"Max Loops Per Trip: {IslandHelper.MinimumPossibleLoops}");

            ImGui.SameLine();

            IslandHelper.UpdateCounters(routeItems);
            if (ImGui.Button("Calculate Root Sell"))
            {
                Task_SellCheck.Enqueue();
                if (IslandHelper.SellItems.Count > 0)
                {
                    foreach (var item in IslandHelper.SellItems)
                    {
                        var itemEntry = ItemData.IslandItems.Where(x => x.Key == item.Key).FirstOrDefault();
                    }
                }
            }

            if (ImGui.BeginTable("Gathered items", 5, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("Item");
                ImGui.TableSetupColumn("Item Per Loop");
                ImGui.TableSetupColumn("Ignore");
                ImGui.TableSetupColumn("Gather Amount");
                ImGui.TableSetupColumn("Sell Column");

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
                    if (ImGui.SliderInt($"###GatherAmount_{item.Key}", ref GatherAmount, 0, 999))
                    {
                        C.ItemGatherAmount[item.Key] = GatherAmount;
                        C.Save();
                    }

                    ImGui.TableNextColumn();
                    if (IslandHelper.SellItems.TryGetValue(item.Value.ItemId, out var sellAmount))
                    {
                        ImGui.Text($"{sellAmount}");
                    }
                    else
                    {
                        ImGui.Text($"0");
                    }

                }

                ImGui.EndTable();
            }
        }
    }
}
