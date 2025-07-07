using Dalamud.Interface.Utility.Raii;
using ExplorersIcebox.Scheduler;
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
    private List<string> routeNames => G.Routes.Keys.ToList();
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

        var routeSelected = G.Routes.Where(x => x.Key == routeNames[selectedRouteIndex]).FirstOrDefault();

        if (G.Routes.ContainsKey(routeSelected.Key))
        {
            if (ImGui.Button("Start Route"))
            {
                IslandHelper.CurrentRoute = routeSelected;
                IslandHelper.TotalLoops = 0;
                IslandHelper.CurrentLoopCount = 0;
            }

            Dictionary<string, IslandHelper.ItemGathered> routeItems = new();
            Dictionary<string, HashSet<ItemData.GatheringNode>> itemNodeMap = new();

            foreach (var wp in routeSelected.Value)
            {
                if (wp.Target != 0) // General check to make sure we're not looking for a null item
                {
                    var Node = ItemData.IslandNodeInfo.Where(x => x.Nodes.Contains(wp.Target)).FirstOrDefault();
                    if (Node != null)
                    {
                        foreach (var item in Node.ItemIds)
                        {
                            string itemName = ItemData.IslandItems[item];
                            if (!routeItems.ContainsKey(itemName))
                            {
                                routeItems[itemName] = new IslandHelper.ItemGathered()
                                {
                                    Amount = 1,
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

            if (ImGui.BeginTable("Gathered items", 4, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("Item");
                ImGui.TableSetupColumn("Amount");
                ImGui.TableSetupColumn("Node Count");
                ImGui.TableSetupColumn("Ignore");

                ImGui.TableHeadersRow();

                foreach (var item in routeItems)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"{item.Key}");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{item.Value.Amount}");

                    ImGui.TableNextColumn();
                    Utils.FancyCheckmark(item.Value.IgnoreNode);
                }

                ImGui.EndTable();
            }
        }
    }
}
