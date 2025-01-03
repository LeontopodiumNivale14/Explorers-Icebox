using ECommons.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui;

internal static class SharedWorkshopUI
{
    private static int AmountSet(int input)
    {
        if (input < 0) input = 0;
        else if (input > 999) input = 999;
        EzConfig.Save();
        UpdateTableDict();
        return input;
    }

    private static float offSet(float value)
    {
        var windowWidth = ImGui.GetWindowContentRegionMax().X; // Get the usable width of the window
        var inputWidth = value; // Desired width of the input field
        var offset = windowWidth - inputWidth; // Calculate position to hug the right wall
        return offset;
    }

    internal static void BaseRouteTable(string routeTableName, int RouteAmount, List<RouteEntry> RouteTable)
    {
        if (ImGui.BeginTable(routeTableName, 5, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
        {
            ImGui.TableSetupColumn("Item", ImGuiTableColumnFlags.WidthFixed, 200);
            ImGui.TableSetupColumn("Currently Have", ImGuiTableColumnFlags.WidthFixed, 100);
            ImGui.TableSetupColumn("Items Per Loop", ImGuiTableColumnFlags.WidthFixed, 110);
            ImGui.TableSetupColumn("Amount Gathered per loop");
            ImGui.TableSetupColumn("Amount Want to gather");

            ImGui.TableNextRow(ImGuiTableRowFlags.Headers);

            string[] headers = { "Item", "Currently Have", "Amount Per Loop", "Total Gathered Amount", "Amount to Gather" };
            for (int col = 0; col < headers.Length; col++)
            {
                ImGui.TableSetColumnIndex(col);

                // Calculate the available space and text size
                var header = headers[col];
                var textSize = ImGui.CalcTextSize(header);
                var columnWidth = ImGui.GetColumnWidth();
                var cursorPosX = ImGui.GetCursorPosX();

                // Set the cursor position to center the text
                ImGui.SetCursorPosX(cursorPosX + (columnWidth - textSize.X) / 2.0f);
                ImGui.Text(header);
            }

            for (int i = 0; i < RouteTable.Count; i++)
            {
                int itemID = RouteTable[i].ID;
                int amountPerLoop = RouteTable[i].AmountGatherable;
                int amountGathered = (RouteAmount * amountPerLoop);
                int WorkshopInput = IslandItemDict[itemID].Workshop;

                string[] rowValues =
                [
                $"{IslandItemDict[itemID].Name}",
                $"{GetItemCount(itemID)}",
                $"{RouteTable[i].AmountGatherable}",
                $"{amountGathered}"
                ];

                ImGui.TableNextRow();
                for (int col = 0; col < 5; col++)
                {
                    ImGui.TableSetColumnIndex(col);

                    if (col < 4) // For the first four columns
                    {
                        var text = rowValues[col];
                        var textSize = ImGui.CalcTextSize(text);
                        var columnWidth = ImGui.GetColumnWidth();
                        var cursorPosX = ImGui.GetCursorPosX();

                        ImGui.SetCursorPosX(cursorPosX + (columnWidth - textSize.X) / 2.0f);
                        ImGui.Text(text);
                    }
                    else if (col == 4) // For the 5th column with ImGui.InputInt
                    {
                        var inputLabel = $"##ItemImGui_{IslandItemDict[itemID].Name}";
                        if (ImGui.InputInt(inputLabel, ref WorkshopInput))
                        {
                            WorkshopInput = AmountSet(WorkshopInput);
                            IslandItemDict[itemID].Workshop = WorkshopInput;
                        }
                    }
                }
            }
        }
        ImGui.EndTable();
    }

    internal static void RouteUi(int RouteNumber, int RouteAmount, List<RouteEntry> RouteList)
    {
        string tableName = $"Route {RouteNumber}";
        if (ImGui.BeginTable($"{tableName}_Ui", 2))
        {
            ImGui.TableNextRow();
            ImGui.TableSetColumnIndex(0);
            ImGui.Text($"Route {RouteNumber} is set to run → {RouteAmount}");
            ImGui.TableSetColumnIndex(1);
            ImGui.Text("Dummy Text for now");
        }

        ImGui.EndTable();

        BaseRouteTable(tableName, RouteAmount, RouteList);
    }
}
