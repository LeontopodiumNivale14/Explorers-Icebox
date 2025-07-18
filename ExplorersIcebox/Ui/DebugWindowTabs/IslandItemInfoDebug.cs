using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class IslandItemInfoDebug
    {
        private static readonly Dictionary<string, HashSet<ulong>> GatherNodeIds = new()
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

        private static Dictionary<string, int> ItemCount = new();

        public static void Draw()
        {
            foreach (var item in Util.ItemData.IslandItems)
            {
                if (!ItemCount.ContainsKey(item.Value.ItemName))
                {
                    ItemCount.Add(item.Value.ItemName, 0);
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
                        string itemName = IslandItems[type].ItemName;
                        ItemCount[itemName] += amount;
                    }
                }
            }

            ImGui.SameLine();

            if (ImGui.Button("Clear"))
            {
                ItemCount.Clear();
            }

            if (ImGui.BeginTable("###ListofNodes", 2, ImGuiTableFlags.RowBg))
            {
                ImGui.TableSetupColumn("Item");
                ImGui.TableSetupColumn("Amount");

                ImGui.TableHeadersRow();

                foreach (var item in ItemCount)
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
    }
}
