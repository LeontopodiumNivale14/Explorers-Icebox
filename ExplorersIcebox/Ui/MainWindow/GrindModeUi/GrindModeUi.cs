using Dalamud.Interface.Utility.Raii;
using ExplorersIcebox.Scheduler.Tasks;
using ExplorersIcebox.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalamud.Interface.Components;

namespace ExplorersIcebox.Ui.MainWindow.GrindModeUi;

internal static unsafe class GrindModeUi
{
    private static string[] ModeSelect = { "XP | Cowries Grind", "Island Gathering Mode" };
    private static string CurrentMode = "XP | Cowries Grind";
    private static bool UseTickets = C.UseTickets;
    private static string TicketTooltip = "Check this if you want to use an Aetheryte ticket to teleport to the Island Sanctuary Entrance";

    internal static void Draw()
    {
        UpdateXPTable();
        ImGui.Text($"Current task → {displayCurrentTask}");
        ImGui.SameLine();
        if (P.taskManager.IsBusy)
            ImGui.SetCursorPosX(offSet(42.0f));
        else if (!P.taskManager.IsBusy)
            ImGui.SetCursorPosX(offSet(117.0f));
        if (ImGui.Button(P.taskManager.IsBusy ? "Stop" : "Teleport to Island"))
        {
            if (P.taskManager.IsBusy)
            {
                SchedulerMain.DisablePlugin();
            }
            else
            {
                TaskReturnToIsland.Enqueue();
            }
        }
        ImGui.Text($"Route → {displayCurrentRoute}");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(217.0f));
        ImGui.Text("Use Aetheryte Ticket to return");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(17.0f));
        if (ImGui.Checkbox("##IS Use Teleport Tickets", ref UseTickets))
        {
            if (UseTickets)
            {
                C.UseTickets = true;
            }
            else
            {
                C.UseTickets = false;
            }
        }
        if (ImGui.IsItemHovered())
        {
            ImGui.BeginTooltip();
            ImGui.Text(TicketTooltip);
            ImGui.EndTooltip();
        }
        if (CurrentTerritory() == 1055 && IsAddonActive("MJIHud"))
            ImGui.Text($"Current level is: {GetNodeText("MJIHud", 14)}");
        var isXPRunning = SchedulerMain.AreWeTicking;
        using (ImRaii.Disabled(!IsInZone(IslandSancZoneID)))
        {
            if (ImGui.Checkbox(" Enable Farm", ref isXPRunning))
            {
                if (isXPRunning)
                {
                    PluginLog("Enabling the route Gathering");
                    if (CurrentMode == "Island Gathering Mode") C.XPGrind = false;
                    if (CurrentMode == "XP | Cowries Grind") C.XPGrind = true;
                    SchedulerMain.EnablePlugin();
                    displayCurrentTask = "Currently Running";
                }
                else
                {
                    PluginLog("Disabling the Route gathering");
                    displayCurrentTask = "";
                    SchedulerMain.DisablePlugin();
                }
            }
        }
        ImGui.SetNextItemWidth(175);
        if (ImGui.BeginCombo("##Mode Select Combo", CurrentMode))
        {
            foreach (var option in ModeSelect)
            {
                // If this option is selected
                if (ImGui.Selectable(option, option == CurrentMode))
                {
                    CurrentMode = option;
                }
                // Set focus to the selected item for better UX
                if (option == CurrentMode)
                {
                    ImGui.SetItemDefaultFocus();
                }
            }
            ImGui.EndCombo();
        }
        ImGui.Spacing();
        if (CurrentMode == "XP | Cowries Grind")
        {
            if (C.routeSelected != 7 && C.routeSelected != 18)
            {
                if (int.Parse(GetNodeText("MJIHud", 14)) < 10)
                    C.routeSelected = 7;
                else if (int.Parse(GetNodeText("MJIHud", 14)) >= 10)
                    C.routeSelected = 18;
                else
                    C.routeSelected = 7;
            }
            GrindXP.Draw();
        }
        else if (CurrentMode == "Island Gathering Mode")
        {
            MaximizeStock.Draw();
        }
    }
}
