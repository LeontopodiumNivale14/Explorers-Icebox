using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Util;
using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class MiscInfoDebug
    {

        private static string InputValue = "0"; // The uint value to be edited
        private static ulong Result;

        public static void Draw()
        {
            // Input box
            ImGui.InputText("Enter a number", ref InputValue, 20);

            if (ImGui.Button("Submit"))
            {
                // Try to parse the input to a ulong
                if (ulong.TryParse(InputValue, out Result))
                {
                    ImGui.Text($"Valid input! Parsed ulong: {Result}");
                }
                else
                {
                    ImGui.Text("Invalid input. Please enter a valid number.");
                }
            }

            ImGui.Text($"Current Value: {InputValue}");

            if (ImGui.Button("Update NodeIds"))
            {
                IslandHelper.UpdateShopCallback();
            }

            ImGui.SameLine();
            if (ImGui.Button("Update NodeId Task"))
            {
                Task_UpdateShop.Enqueue();
            }

            if (GenericHelpers.TryGetAddonMaster<MJIHud>("MJIHud", out var hud) && hud.IsAddonReady)
            {
                if (ImGui.Button("Open IsleInventory"))
                {
                    hud.Isleventory();
                }

                ImGui.SameLine();
                if (ImGui.Button("Open Crafting Log"))
                {
                    hud.SanctuaryCraftingLog();
                }

                ImGui.SameLine();
                if (ImGui.Button("Open Gathering Log"))
                {
                    hud.SanctuaryGatheringLog();
                }

                ImGui.SameLine();
                if (ImGui.Button("Manage Hideaway"))
                {
                    hud.ManageHideaway();
                }

                ImGui.SameLine();
                if (ImGui.Button("Material Allocation"))
                {
                    hud.MaterialAllocation();
                }

                ImGui.SameLine();
                if (ImGui.Button("Manage Minions"))
                {
                    hud.ManageMinions();
                }

                ImGui.SameLine();
                if (ImGui.Button("Manage Furnishing"))
                {
                    hud.ManageFurnishing();
                }

                ImGui.SameLine();
                if (ImGui.Button("Guide"))
                {
                    hud.Guide();
                }
            }

            if (ImGui.BeginTable("Callback Values", 2, ImGuiTableFlags.SizingFixedFit))
            {
                ImGui.TableSetupColumn("Item");
                ImGui.TableSetupColumn("Callback");

                ImGui.TableHeadersRow();

                foreach (var item in ItemData.IslandItems)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(item.Value.ItemName);
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.Text($"{item.Key}");
                        ImGui.EndTooltip();
                    }

                    ImGui.TableNextColumn();
                    ImGui.Text($"{item.Value.SellSlot}");
                }

                ImGui.EndTable();
            }
        }
    }
}
