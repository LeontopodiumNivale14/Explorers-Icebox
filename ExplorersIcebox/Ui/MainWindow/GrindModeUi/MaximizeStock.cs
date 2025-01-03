using Dalamud.Interface.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui.MainWindow.GrindModeUi;

internal static class MaximizeStock
{
    private static string SearchQuery = ""; // private static variable to store the search query
    private static int UpdateAllWS = 0;

    private static bool Route0 = C.Route0;
    private static bool Route1 = C.Route1;
    private static bool Route2 = C.Route2;
    private static bool Route3 = C.Route3;
    private static bool Route4 = C.Route4;
    private static bool Route5 = C.Route5;
    private static bool Route6 = C.Route6;
    private static bool Route7 = C.Route7;
    private static bool Route8 = C.Route8;
    private static bool Route9 = C.Route9;
    private static bool Route10 = C.Route10;
    private static bool Route11 = C.Route11;
    private static bool Route12 = C.Route12;
    private static bool Route13 = C.Route13;
    private static bool Route14 = C.Route14;
    private static bool Route15 = C.Route15;
    private static bool Route16 = C.Route16;
    private static bool Route17 = C.Route17;
    private static bool Route18 = C.Route18;
    private static bool Route19 = C.Route19;
    private static bool Route20 = C.Route20;
    private static bool Route21 = C.Route21;

    private static void UpdateWSImGui()
    {
        var updateAll = UpdateAllWS;
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(106f));
        ImGui.SetNextItemWidth(85);
        if (ImGui.InputInt("##Update All Workshops", ref updateAll))
        {
            UpdateAllWS = AmountSet(updateAll);
            {
                foreach (var item in IslandItemDict.Keys.ToList())
                {
                    IslandItemDict[item].Workshop = AmountSet(updateAll);
                }
            }
        }
        ImGuiComponents.HelpMarker("Quick way to update all workshops to the same value.");
    }

    internal static void Draw()
    {
        ImGui.InputText("Search", ref SearchQuery, 100);
        ImGui.TextWrapped("Select which routes you would like to cap items from:");
        ImGui.Spacing();

        if (ImGui.Button("Enable All Routes"))
        {
            C.Route0 = true;
            C.Route1 = true;
            C.Route2 = true;
            C.Route3 = true;
            C.Route4 = true;
            C.Route5 = true;
            C.Route6 = true;
            C.Route7 = true;
            C.Route8 = true;
            C.Route9 = true;
            C.Route10 = true;
            C.Route11 = true;
            C.Route12 = true;
            C.Route13 = true;
            C.Route14 = true;
            C.Route15 = true;
            C.Route16 = true;
            C.Route17 = true;
            C.Route18 = true;
            C.Route19 = true;
            C.Route20 = true;
            C.Route21 = true;
            GatherAllUpdate();
            PluginLog("Enabled all routes");
        }
        ImGui.SameLine();
        if (ImGui.Button("Disable All Routes"))
        {
            C.Route0 = false;
            C.Route1 = false;
            C.Route2 = false;
            C.Route3 = false;
            C.Route4 = false;
            C.Route5 = false;
            C.Route6 = false;
            C.Route7 = false;
            C.Route8 = false;
            C.Route9 = false;
            C.Route10 = false;
            C.Route11 = false;
            C.Route12 = false;
            C.Route13 = false;
            C.Route14 = false;
            C.Route15 = false;
            C.Route16 = false;
            C.Route17 = false;
            C.Route18 = false;
            C.Route19 = false;
            C.Route20 = false;
            C.Route21 = false;
            GatherAllUpdate();
            PluginLog("Disabled all routes");

        }
        UpdateWSImGui();

        #region SearchQuery
        if (string.IsNullOrEmpty(SearchQuery) || "Islefish | Clam [Route 0]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Islefish | Clam [Route 0]"))
            {
                if (ImGui.Checkbox("Enable Route 0", ref Route0))
                {
                    if (Route0)
                    {
                        C.Route0 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route0 = false;
                        GatherAllUpdate();
                    }
                }
                Route0WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Islewort [Route 1]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying is required, due to how going under water works...");
            if (ImGui.TreeNode("Islewort [Route 1]"))
            {
                if (ImGui.Checkbox("Enable Route 1", ref Route1))
                {
                    if (Route1)
                    {
                        C.Route1 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route1 = false;
                        GatherAllUpdate();
                    }
                }
                Route1WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Sugarcane | Vine [Route 2]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Sugarcane | Vine [Route 2]"))
            {
                if (ImGui.Checkbox("Enable Route 2", ref Route2))
                {
                    if (Route2)
                    {
                        C.Route2 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route2 = false;
                        GatherAllUpdate();
                    }
                }
                Route2WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Tinsand | Sand [Route 3]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Tinsand | Sand [Route 3]"))
            {
                if (ImGui.Checkbox("Enable Route 3", ref Route3))
                {
                    if (Route3)
                    {
                        C.Route3 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route3 = false;
                        GatherAllUpdate();
                    }
                }
                Route3WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Apple | Beehive | Vine [Route 4]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Apple | Beehive | Vine [Route 4]"))
            {
                if (ImGui.Checkbox("Enable Route 4", ref Route4))
                {
                    if (Route4)
                    {
                        C.Route4 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route4 = false;
                        GatherAllUpdate();
                    }
                }
                Route4WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Coconut | Palm Log | Palm leaf [Route 5]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Coconut | Palm Log | Palm leaf [Route 5]"))
            {
                if (ImGui.Checkbox("Enable Route 5", ref Route5))
                {
                    if (Route5)
                    {
                        C.Route5 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route5 = false;
                        GatherAllUpdate();
                    }
                }
                Route5WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Cotton [Route 6]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Cotton [Route 6]"))
            {
                if (ImGui.Checkbox("Enable Route 6", ref Route6))
                {
                    if (Route6)
                    {
                        C.Route6 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route6 = false;
                        GatherAllUpdate();
                    }
                }
                Route6WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Clay | Sand [Route 7]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Clay | Sand [Route 7]"))
            {
                if (ImGui.Checkbox("Enable Route 7", ref Route7))
                {
                    if (Route7)
                    {
                        C.Route7 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route7 = false;
                        GatherAllUpdate();
                    }
                }
                Route7WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Marble | Limestone | Stone [Route 8]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Marble | Limestone | Stone [Route 8]"))
            {
                if (ImGui.Checkbox("Enable Route 8", ref Route8))
                {
                    if (Route8)
                    {
                        C.Route8 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route8 = false;
                        GatherAllUpdate();
                    }
                }
                Route8WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Branch | Resin | Log [Route 9]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Branch | Resin | Log [Route 9]"))
            {
                if (ImGui.Checkbox("Enable Route 9", ref Route9))
                {
                    if (Route9)
                    {
                        C.Route9 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route9 = false;
                        GatherAllUpdate();
                    }
                }
                Route9WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Copper | Mythril [Route 10]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Copper | Mythril [Route 10]"))
            {
                if (ImGui.Checkbox("Enable Route 10", ref Route10))
                {
                    if (Route10)
                    {
                        C.Route10 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route10 = false;
                        GatherAllUpdate();
                    }
                }
                Route10WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Opal | Sap | (Log) [Route 11]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Opal | Sap | (Log) [Route 11]"))
            {
                if (ImGui.Checkbox("Enable Route 11", ref Route11))
                {
                    if (Route11)
                    {
                        C.Route11 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route11 = false;
                        GatherAllUpdate();
                    }
                }
                Route11WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Hemp | (Islewort) [Route 12]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Hemp | (Islewort) [Route 12]"))
            {
                if (ImGui.Checkbox("Enable Route 12", ref Route12))
                {
                    if (Route12)
                    {
                        C.Route12 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route12 = false;
                        GatherAllUpdate();
                    }
                }
                Route12WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Multicolorblooms [Route 13]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Multicolorblooms [Route 13]"))
            {
                if (ImGui.Checkbox("Enable Route 13", ref Route13))
                {
                    if (Route13)
                    {
                        C.Route13 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route13 = false;
                        GatherAllUpdate();
                    }
                }
                Route13WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Iron Ore [Route 14]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying required");
            if (ImGui.TreeNode("Iron Ore [Route 14]"))
            {
                if (ImGui.Checkbox("Enable Route 14", ref Route14))
                {
                    if (Route14)
                    {
                        C.Route14 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route14 = false;
                        GatherAllUpdate();
                    }
                }
                Route14WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Laver | Squid / Jellyfish | Coral [Route 15]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Laver | Squid / Jellyfish | Coral [Route 15]"))
            {
                if (ImGui.Checkbox("Enable Route 15", ref Route15))
                {
                    if (Route15)
                    {
                        C.Route15 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route15 = false;
                        GatherAllUpdate();
                    }
                }
                Route15WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Rocksalt [Route 16]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying is required, due to how going under water works...");
            if (ImGui.TreeNode("Rocksalt [Route 16]"))
            {
                if (ImGui.Checkbox("Enable Route 16", ref Route16))
                {
                    if (Route16)
                    {
                        C.Route16 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route16 = false;
                        GatherAllUpdate();
                    }
                }
                Route16WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Leucogranite [Route 17}".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Leucogranite [Route 17}"))
            {
                if (ImGui.Checkbox("Enable Route 17", ref Route17))
                {
                    if (Route17)
                    {
                        C.Route17 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route17 = false;
                        GatherAllUpdate();
                    }
                }
                Route17WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Quartz | Stone [Route 18]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Quartz | Stone [Route 18]"))
            {
                if (ImGui.Checkbox("Enable Route 18", ref Route18))
                {
                    if (Route18)
                    {
                        C.Route18 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route18 = false;
                        GatherAllUpdate();
                    }
                }
                Route18WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Glimshroom | Shale / Coal [Route 19]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker("Flying is required");
            if (ImGui.TreeNode("Glimshroom | Shale / Coal [Route 19]"))
            {
                if (ImGui.Checkbox("Enable Route 19", ref Route19))
                {
                    if (Route19)
                    {
                        C.Route19 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route19 = false;
                        GatherAllUpdate();
                    }
                }
                Route19WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Effervescent Water / Spectrine [Route 20]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {

            if (ImGui.TreeNode("Effervescent Water / Spectrine [Route 20]"))
            {
                if (ImGui.Checkbox("Enable Route 20", ref Route20))
                {
                    if (Route20)
                    {
                        C.Route20 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route20 = false;
                        GatherAllUpdate();
                    }
                }
                Route20WorkshopGui();
                ImGui.TreePop();
            }
        }
        if (string.IsNullOrEmpty(SearchQuery) || "Yellow Copper | Gold | Crystal Formation | HawksEyeSand [Route 21]".Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        {
            if (ImGui.TreeNode("Yellow Copper | Gold | Crystal Formation | HawksEyeSand [Route 21]"))
            {
                if (ImGui.Checkbox("Enable Route 21", ref Route21))
                {
                    if (Route21)
                    {
                        C.Route21 = true;
                        GatherAllUpdate();
                    }
                    else
                    {
                        C.Route21 = false;
                        GatherAllUpdate();
                    }
                }
                Route21WorkshopGui();
                ImGui.TreePop();
            }
        }
        #endregion
    }
}
