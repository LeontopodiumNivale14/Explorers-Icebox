using ECommons.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util.IslandData;

internal class IslandUiWindows
{

    public static int AmountSet(int input)
    {
        if (input < 0) input = 0;
        else if (input > 999) input = 999;
        EzConfig.Save();
        UpdateTableDict();
        return input;
    }

    public static float offSet(float value)
    {
        float windowWidth = ImGui.GetWindowContentRegionMax().X; // Get the usable width of the window
        float inputWidth = value; // Desired width of the input field
        float offset = windowWidth - inputWidth; // Calculate position to hug the right wall
        return offset;
    }

    public static void ItemImGui(int itemId)
    {
        int WorkshopInput = IslandItemDict[itemId].Workshop;
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"{IslandItemDict[itemId].Name} | Have: {GetItemCount(itemId)}");
        ImGui.SameLine();
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt($"##ItemImGui + {IslandItemDict[itemId].Name}", ref WorkshopInput))
        {
            WorkshopInput = AmountSet(WorkshopInput);
            IslandItemDict[itemId].Workshop = WorkshopInput;
        }
    }

    public static void Route0WorkshopGui()
    {
        ImGui.TextWrapped($"Route 0 is set to run -> {Route0Amount} loops");
        ItemImGui(IslefishID);
        ItemImGui(ClamID);
        ItemImGui(SquidID);
        ItemImGui(LaverID);
    }

    public static void Route1WorkshopGui()
    {
        ImGui.TextWrapped($"Route 1 is set to run -> {Route1Amount} loops");
        ItemImGui(IslewortID);
    }

    public static void Route2WorkshopGui()
    {
        ImGui.TextWrapped($"Route 2 is set to run -> {Route2Amount} loops");
        ItemImGui(SugarcaneID);
        ItemImGui(VineID);
    }

    public static void Route3WorkshopGui()
    {
        ImGui.TextWrapped($"Route 3 is set to run -> {Route3Amount} loops");
        ItemImGui(TinsandID);
        ItemImGui(SandID);
        ItemImGui(MarbleID);
        ItemImGui(LimestoneID);
        ItemImGui(StoneID);
    }

    public static void Route4WorkshopGui()
    {
        ImGui.TextWrapped($"Route 4 is set to run -> {Route4Amount} loops");
        ItemImGui(AppleID);
        ItemImGui(BeehiveID);
        ItemImGui(VineID);
        ItemImGui(SapID);
        ItemImGui(WoodOpalID);
        ItemImGui(BranchID);
        ItemImGui(ResinID);
        ItemImGui(SandID);
        ItemImGui(ClayID);
        ItemImGui(LogID);

    }

    public static void Route5WorkshopGui()
    {
        ImGui.TextWrapped($"Route 5 is set to run -> {Route5Amount} loops");
        ItemImGui(CoconutID);
        ItemImGui(PalmLogID);
        ItemImGui(PalmLeafID);
        ItemImGui(LimestoneID);
        ItemImGui(MarbleID);
        ItemImGui(StoneID);
    }

    public static void Route6WorkshopGui()
    {
        ImGui.TextWrapped($"Route 6 is set to run -> {Route6Amount} loops");
        ItemImGui(CottonID); 
        ItemImGui(HempID);
        ItemImGui(CoconutID);
        ItemImGui(PalmLogID);
        ItemImGui(PalmLeafID);
        ItemImGui(IslewortID);
    }

    public static void Route7WorkshopGui()
    {
        ImGui.Text($"Route 7 is set to run -> {Route7Amount} loops");
        ItemImGui(ClayID);
        ItemImGui(TinsandID);
        ItemImGui(MarbleID);
        ItemImGui(LimestoneID);
        ItemImGui(StoneID);
        ItemImGui(BranchID);
        ItemImGui(LogID);
        ItemImGui(ResinID);
        ItemImGui(SandID);
    }

    public static void Route8WorkshopGui()
    {
        ImGui.Text($"Route 8 is set to run -> {Route8Amount} loops");
        ItemImGui(MarbleID); 
        ItemImGui(LimestoneID);
        ItemImGui(StoneID);
        ItemImGui(SugarcaneID);
        ItemImGui(VineID);
        ItemImGui(CoconutID);
        ItemImGui(PalmLeafID);
        ItemImGui(PalmLogID);
        ItemImGui(TinsandID);
        ItemImGui(SandID);
        ItemImGui(HempID);
        ItemImGui(IslefishID);
    }

    public static void Route9WorkshopGui()
    {
        ImGui.Text($"Route 9 is set to run -> {Route9Amount} loops");
        ItemImGui(BranchID);
        ItemImGui(ResinID);
        ItemImGui(SapID);
        ItemImGui(WoodOpalID);
        ItemImGui(LogID);
        ItemImGui(ClayID);
        ItemImGui(SandID);
        ItemImGui(LogID);
    }

    public static void Route10WorkshopGui()
    {
        ImGui.Text($"Route 10 is set to run -> {Route10Amount} loops");
        ItemImGui(CopperID);
        ItemImGui(MythrilOreID);
        ItemImGui(HempID);
        ItemImGui(CoconutID);
        ItemImGui(PalmLogID);
        ItemImGui(PalmLeafID);
        ItemImGui(CottonID);
        ItemImGui(IslewortID);
        ItemImGui(StoneID);
    }

    public static void Route11WorkshopGui()
    {
        ImGui.Text($"Route 11 is set to run -> {Route11Amount} loops");
        ItemImGui(SapID);
        ItemImGui(WoodOpalID);
        ItemImGui(LogID);
        ItemImGui(HempID);
        ItemImGui(IslewortID);
    }

    public static void Route12WorkshopGui()
    {
        ImGui.Text($"Route 12 is set to run -> {Route12Amount} loops");
        ItemImGui(HempID);
        ItemImGui(IslewortID);
        ItemImGui(SandID);
        ItemImGui(ClayID);
        ItemImGui(CoconutID);
        ItemImGui(PalmLogID);
        ItemImGui(PalmLeafID);
    }

    public static void Route13WorkshopGui()
    {
        ImGui.Text($"Route 13 is set to run -> {Route13Amount} loops");
        ItemImGui(MulticoloredIslebloomsID);
        ItemImGui(QuartzID);
        ItemImGui(IronOreID);
        ItemImGui(DuriumSandID);
        ItemImGui(LeucograniteID);
        ItemImGui(StoneID);
    }

    public static void Route14WorkshopGui()
    {
        ImGui.Text($"Route 14 is set to run -> {Route14Amount} loops");
        ItemImGui(IronOreID);
        ItemImGui(DuriumSandID);
        ItemImGui(StoneID);
    }

    public static void Route15WorkshopGui()
    {
        ImGui.Text($"Route 15 is set to run -> {Route15Amount} loops");
        ItemImGui(LaverID);
        ItemImGui(SquidID);
        ItemImGui(JellyfishID);
        ItemImGui(CoralID);
    }

    public static void Route16WorkshopGui()
    {
        ImGui.Text($"Route 16 is set to run -> {Route16Amount} loops");
        ItemImGui(RockSaltID);
        ItemImGui(StoneID);
        ItemImGui(ClayID);
        ItemImGui(SandID);
        ItemImGui(IslewortID);
        ItemImGui(HempID);
    }

    public static void Route17WorkshopGui()
    {
        ImGui.Text($"Route 17 is set to run -> {Route17Amount} loops");
        ItemImGui(LeucograniteID);
        ItemImGui(CopperID);
        ItemImGui(MythrilOreID);
        ItemImGui(IronOreID);
        ItemImGui(DuriumSandID);
        ItemImGui(StoneID);
    }

    public static void Route18WorkshopGui()
    {
        ImGui.Text($"Route 18 is set to run -> {Route18Amount} loops");
        ItemImGui(QuartzID);
        ItemImGui(IronOreID);
        ItemImGui(DuriumSandID);
        ItemImGui(LeucograniteID);
        ItemImGui(StoneID);
    }

    public static void Route19WorkshopGui()
    {
        ImGui.Text($"Route 19 is set to run -> {Route19Amount} loops");
        ItemImGui(GlimshroomID);
        ItemImGui(ShaleID);
        ItemImGui(CoalID);
        ItemImGui(StoneID);
    }

    public static void Route20WorkshopGui()
    {
        ImGui.Text($"Route 20 is set to run -> {Route20Amount} loops");
        ItemImGui(EffervescentWaterID);
        ItemImGui(SpectrineID);
        ItemImGui(ShaleID);
        ItemImGui(CoalID);
        ItemImGui(StoneID);
    }

    public static void Route21WorkshopGui()
    {
        ImGui.Text($"Route 21 is set to run -> {Route21Amount} loops");
        ItemImGui(YellowCopperOreID);
        ItemImGui(GoldOreID);
        ItemImGui(CrystalFormationID);
        ItemImGui(HawksEyeSandID);
        ItemImGui(GlimshroomID);
        ItemImGui(EffervescentWaterID);
        ItemImGui(SpectrineID);
        ItemImGui(ShaleID);
        ItemImGui(CoalID);
        ItemImGui(StoneID);
    }
}
