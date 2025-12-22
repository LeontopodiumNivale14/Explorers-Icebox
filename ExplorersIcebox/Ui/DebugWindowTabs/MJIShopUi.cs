using ECommons.UIHelpers.AddonMasterImplementations;
using ExplorersIcebox.Util;
using Lumina.Excel.Sheets;
using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class MJIShopUi
    {
        public static void Draw()
        {
            if (TryGetAddonMaster<MJIDisposeShop>("MJIDisposeShop", out var mjishop) && mjishop.IsAddonReady)
            {
                if (ImGui.BeginTable("MJI Shop Item Demo", 6, ImGuiTableFlags.Borders | ImGuiTableFlags.SizingFixedFit))
                {
                    ImGui.TableSetupColumn("ItemId");
                    ImGui.TableSetupColumn("Item Name");
                    ImGui.TableSetupColumn("Value");
                    ImGui.TableSetupColumn("Inventory Amount");
                    ImGui.TableSetupColumn("Allocated Amount");
                    ImGui.TableSetupColumn("Select Item");

                    ImGui.TableHeadersRow();

                    for (int i = 0; i < mjishop.NumEntries; i++)
                    {
                        var entry = mjishop.ExportItems[i];
                        var itemName = entry.ItemName;
                        var Value = entry.Value;
                        var InventoryAmount = entry.Inventory;
                        var allocatedAmount = entry.Allocated;
                        var itemId = OnPluginLoad.IslandItemInfo.Where(x => x.Value == itemName).FirstOrDefault().Key;

                        ImGui.TableNextRow();
                        ImGui.PushID(itemName);

                        ImGui.TableSetColumnIndex(0);
                        if (itemId != 0)
                        {
                            ImGui.Text($"{itemId}");
                        }

                        ImGui.TableNextColumn();
                        ImGui.Text($"{itemName}");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{Value}");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{InventoryAmount}");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{allocatedAmount}");

                        ImGui.TableNextColumn();
                        if (ImGui.Button("Select Item"))
                        {
                            entry.Select();
                        }
                        ImGui.PopID();
                    }

                    ImGui.EndTable();
                }
            }
        }
    }
}
