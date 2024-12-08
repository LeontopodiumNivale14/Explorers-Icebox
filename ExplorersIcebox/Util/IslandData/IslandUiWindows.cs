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

    static int AmountSet(int input)
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

    public static void PalmLeafImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Palm Leaf (Have: {PalmLeafAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Palm Leaf Send", ref C.PalmLeafWorkshop))
        {
            C.PalmLeafWorkshop = AmountSet(C.PalmLeafWorkshop);
            IslandSancDictionary[PalmLeafID].Workshop = C.PalmLeafWorkshop;
        }
    }

    public static void BranchImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Branch (Have: {BranchAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Branch Send", ref C.BranchWorkshop))
        {
            C.BranchWorkshop = AmountSet(C.BranchWorkshop);
            IslandSancDictionary[BranchID].Workshop = C.BranchWorkshop;
        }
    }

    public static void StoneImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Stone (Have: {StoneAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Stone Send", ref C.StoneWorkshop))
        {
            C.StoneWorkshop = AmountSet(C.StoneWorkshop);
            IslandSancDictionary[StoneID].Workshop = C.StoneWorkshop;
        }
    }

    public static void ClamImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Clam (Have: {ClamAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Clam Send", ref C.ClamWorkshop))
        {
            C.ClamWorkshop = AmountSet(C.ClamWorkshop);
            IslandSancDictionary[ClamID].Workshop = C.ClamWorkshop;
        }
    }

    public static void LaverImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Laver (Have: {LaverAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Laver Send", ref C.LaverWorkshop))
        {
            C.LaverWorkshop = AmountSet(C.LaverWorkshop);
            IslandSancDictionary[LaverID].Workshop = C.LaverWorkshop;
        }
    }

    public static void CoralImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Coral (Have: {CoralAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Coral Send", ref C.CoralWorkshop))
        {
            C.CoralWorkshop = AmountSet(C.CoralWorkshop);
            IslandSancDictionary[CoralID].Workshop = (C.CoralWorkshop);
        }
    }

    public static void IslewortImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Islewort (Have: {IslewortAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Islewort Send", ref C.IslewortWorkshop))
        {
            C.IslewortWorkshop = AmountSet(C.IslewortWorkshop);
            IslandSancDictionary[IslewortID].Workshop = C.IslewortWorkshop;
        }
    }

    public static void SandImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Sand (Have: {SandAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Sand Send", ref C.SandWorkshop))
        {
            C.SandWorkshop = AmountSet(C.SandWorkshop);
            IslandSancDictionary[SandID].Workshop = (C.SandWorkshop);
        }
    }

    public static void VineImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Vine (Have: {VineAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Vine Send", ref C.VineWorkshop))
        {
            C.VineWorkshop = AmountSet(C.VineWorkshop);
            IslandSancDictionary[VineID].Workshop = (C.VineWorkshop);
        }
    }

    public static void SapImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Sap (Have: {SapAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Sap Send", ref C.SapWorkshop))
        {
            C.SapWorkshop = AmountSet(C.SapWorkshop);
            IslandSancDictionary[SapID].Workshop = (C.SapWorkshop);
        }
    }

    public static void AppleImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Apple (Have: {AppleAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Apple Send", ref C.AppleWorkshop))
        {
            C.AppleWorkshop = AmountSet(C.AppleWorkshop);
            IslandSancDictionary[AppleID].Workshop = (C.AppleWorkshop);
        }
    }

    public static void LogImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Log (Have: {LogAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Log Send", ref C.LogWorkshop))
        {
            C.LogWorkshop = AmountSet(C.LogWorkshop);
            IslandSancDictionary[LogID].Workshop = (C.LogWorkshop);
        }
    }

    public static void PalmLogImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Palm Log (Have: {PalmLogAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Palm Log Send", ref C.PalmLogWorkshop))
        {
            C.PalmLogWorkshop = AmountSet(C.PalmLogWorkshop);
            IslandSancDictionary[LogID].Workshop = (C.PalmLogWorkshop);
        }
    }

    public static void CopperImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Copper (Have: {CopperAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Copper Send", ref C.CopperWorkshop))
        {
            C.CopperWorkshop = AmountSet(C.CopperWorkshop);
            IslandSancDictionary[CopperID].Workshop = (C.CopperWorkshop);
        }
    }

    public static void LimestoneImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Limestone (Have: {LimestoneAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Limestone Send", ref C.LimestoneWorkshop))
        {
            C.LimestoneWorkshop = AmountSet(C.LimestoneWorkshop);
            IslandSancDictionary[LimestoneID].Workshop = (C.LimestoneWorkshop);
        }
    }

    public static void RockSaltImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Rock Salt (Have: {RockSaltAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Rock Salt Send", ref C.RockSaltWorkshop))
        {
            C.RockSaltWorkshop = AmountSet(C.RockSaltWorkshop);
            IslandSancDictionary[RockSaltID].Workshop = (C.RockSaltWorkshop);
        }
    }

    public static void ClayImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Clay (Have: {ClayAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Clay Send", ref C.ClayWorkshop))
        {
            C.ClayWorkshop = AmountSet(C.ClayWorkshop);
            IslandSancDictionary[ClayID].Workshop = (C.ClayWorkshop);
        }
    }

    public static void TinsandImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Tinsand (Have: {TinsandAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Tinsand Send", ref C.TinsandWorkshop))
        {
            C.TinsandWorkshop = AmountSet(C.TinsandWorkshop);
            IslandSancDictionary[TinsandID].Workshop = (C.TinsandWorkshop);
        }
    }

    public static void SugarcaneImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Sugarcane (Have: {SugarcaneAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Sugarcane Send", ref C.SugarcaneWorkshop))
        {
            C.SugarcaneWorkshop = AmountSet(C.SugarcaneWorkshop);
            IslandSancDictionary[SugarcaneID].Workshop = C.SugarcaneWorkshop;
        }
    }

    public static void CottonImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Cotton (Have: {CottonAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Cotton Send", ref C.CottonWorkshop))
        {
            C.CottonWorkshop = AmountSet(C.CottonWorkshop);
            IslandSancDictionary[CottonID].Workshop = C.CottonWorkshop;
        }
    }

    public static void HempImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Hemp (Have: {HempAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Hemp Send", ref C.HempWorkshop))
        {
            C.HempWorkshop = AmountSet(C.HempWorkshop);
            IslandSancDictionary[HempID].Workshop = C.HempWorkshop;
        }
    }

    public static void IslefishImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Islefish (Have: {IslefishAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Islefish Send", ref C.IslefishWorkshop))
        {
            C.IslefishWorkshop = AmountSet(C.IslefishWorkshop);
            IslandSancDictionary[IslefishID].Workshop = C.IslefishWorkshop;
        }
    }

    public static void SquidImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Squid (Have: {SquidAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Squid Send", ref C.SquidWorkshop))
        {
            C.SquidWorkshop = AmountSet(C.SquidWorkshop);
            IslandSancDictionary[SquidID].Workshop = C.SquidWorkshop;
        }
    }

    public static void JellyfishImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Jellyfish (Have: {JellyfishAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Jellyfish Send", ref C.JellyfishWorkshop))
        {
            C.JellyfishWorkshop = AmountSet(C.JellyfishWorkshop);
            IslandSancDictionary[SquidID].Workshop = C.JellyfishWorkshop;
        }
    }

    public static void IronOreImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"IronOre (Have: {IronOreAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##IronOre Send", ref C.IronOreWorkshop))
        {
            C.IronOreWorkshop = AmountSet(C.IronOreWorkshop);
            IslandSancDictionary[IronOreID].Workshop = C.IronOreWorkshop;
        }
    }

    public static void QuartzImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Quartz (Have: {QuartzAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Quartz Send", ref C.QuartzWorkshop))
        {
            C.QuartzWorkshop = AmountSet(C.QuartzWorkshop);
            IslandSancDictionary[QuartzID].Workshop = C.QuartzWorkshop;
        }
    }

    public static void LeucograniteImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Leucogranite (Have: {LeucograniteAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Leucogranite Send", ref C.LeucograniteWorkshop))
        {
            C.LeucograniteWorkshop = AmountSet(C.LeucograniteWorkshop);
            IslandSancDictionary[LeucograniteID].Workshop = C.LeucograniteWorkshop;
        }
    }

    public static void MulticoloredIslebloomsImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Multicolored Isleblooms (Have: {MulticoloredIslebloomsAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Multicolored Isleblooms Send", ref C.MulticoloredIslebloomsWorkshop))
        {
            C.MulticoloredIslebloomsWorkshop = AmountSet(C.MulticoloredIslebloomsWorkshop);
            IslandSancDictionary[MulticoloredIslebloomsID].Workshop = C.MulticoloredIslebloomsWorkshop;
        }
    }

    public static void ResinImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Resin (Have: {ResinAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Resin Send", ref C.ResinWorkshop))
        {
            C.ResinWorkshop = AmountSet(C.ResinWorkshop);
            IslandSancDictionary[ResinID].Workshop = C.ResinWorkshop;
        }
    }

    public static void CoconutImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Coconut (Have: {CoconutAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Coconut Send", ref C.CoconutWorkshop))
        {
            C.CoconutWorkshop = AmountSet(C.CoconutWorkshop);
            IslandSancDictionary[CoconutID].Workshop = C.CoconutWorkshop;
        }
    }

    public static void BeehiveImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Beehive (Have: {BeehiveAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Beehive Send", ref C.BeehiveWorkshop))
        {
            C.BeehiveWorkshop = AmountSet(C.BeehiveWorkshop);
            IslandSancDictionary[BeehiveID].Workshop = C.BeehiveWorkshop;
        }
    }

    public static void WoodOpalImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Wood Opal (Have: {WoodOpalAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Wood Opal Send", ref C.WoodOpalWorkshop))
        {
            C.WoodOpalWorkshop = AmountSet(C.WoodOpalWorkshop);
            IslandSancDictionary[WoodOpalID].Workshop = C.WoodOpalWorkshop;
        }
    }

    public static void CoalImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Coal (Have: {CoalAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Coal Send", ref C.CoalWorkshop))
        {
            C.CoalWorkshop = AmountSet(C.CoalWorkshop);
            IslandSancDictionary[CoalID].Workshop = C.CoalWorkshop;
        }
    }

    public static void GlimshroomImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Glimshroom (Have: {GlimshroomAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Glimshroom Send", ref C.GlimshroomWorkshop))
        {
            C.GlimshroomWorkshop = AmountSet(C.GlimshroomWorkshop);
            IslandSancDictionary[GlimshroomID].Workshop = C.GlimshroomWorkshop;
        }
    }

    public static void EffervescentWaterImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Effervescent Water (Have: {EffervescentWaterAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Effervescent Water Send", ref C.EffervescentWaterWorkshop))
        {
            C.EffervescentWaterWorkshop = AmountSet(C.EffervescentWaterWorkshop);
            IslandSancDictionary[EffervescentWaterID].Workshop = C.EffervescentWaterWorkshop;
        }
    }

    public static void ShaleImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Shale (Have: {ShaleAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Shale Send", ref C.ShaleWorkshop))
        {
            C.ShaleWorkshop = AmountSet(C.ShaleWorkshop);
            IslandSancDictionary[ShaleID].Workshop = C.ShaleWorkshop;
        }
    }

    public static void MarbleImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Marble (Have: {MarbleAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Marble Send", ref C.MarbleWorkshop))
        {
            C.MarbleWorkshop = AmountSet(C.MarbleWorkshop);
            IslandSancDictionary[MarbleID].Workshop = C.MarbleWorkshop;
        }
    }

    public static void MythrilOreImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Mythril Ore (Have: {MythrilOreAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Mythril Ore Send", ref C.MythrilOreWorkshop))
        {
            C.MythrilOreWorkshop = AmountSet(C.MythrilOreWorkshop);
            IslandSancDictionary[MythrilOreID].Workshop = C.MythrilOreWorkshop;
        }
    }

    public static void SpectrineImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Spectrine (Have: {SpectrineAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Spectrine Send", ref C.SpectrineWorkshop))
        {
            C.SpectrineWorkshop = AmountSet(C.SpectrineWorkshop);
            IslandSancDictionary[SpectrineID].Workshop = C.SpectrineWorkshop;
        }
    }

    public static void DuriumSandImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Durium Sand (Have: {DuriumSandAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Durium Sand Send", ref C.DuriumSandWorkshop))
        {
            C.DuriumSandWorkshop = AmountSet(C.DuriumSandWorkshop);
            IslandSancDictionary[DuriumSandID].Workshop = C.DuriumSandWorkshop;
        }
    }

    public static void YellowCopperOreImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Yellow Copper Ore (Have: {YellowCopperOreAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Yellow Copper Ore Send", ref C.YellowCopperOreWorkshop))
        {
            C.YellowCopperOreWorkshop = AmountSet(C.YellowCopperOreWorkshop);
            IslandSancDictionary[YellowCopperOreID].Workshop = C.YellowCopperOreWorkshop;
        }
    }

    public static void GoldOreImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Gold Ore (Have: {GoldOreAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Gold Ore Send", ref C.GoldOreWorkshop))
        {
            C.GoldOreWorkshop = AmountSet(C.GoldOreWorkshop);
            IslandSancDictionary[GoldOreID].Workshop = C.GoldOreWorkshop;
        }
    }

    public static void HawksEyeSandImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Hawks Eye Sand (Have: {HawksEyeSandAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Hawks Eye Sand Send", ref C.HawksEyeSandWorkshop))
        {
            C.HawksEyeSandWorkshop = AmountSet(C.HawksEyeSandWorkshop);
            IslandSancDictionary[HawksEyeSandID].Workshop = C.HawksEyeSandWorkshop;
        }
    }

    public static void CrystalFormationImgui()
    {
        ImGui.AlignTextToFramePadding();
        ImGui.Text($"Crystal Formation (Have: {CrystalFormationAmount})");
        ImGui.SameLine();
        ImGui.SetCursorPosX(offSet(100.0f));
        ImGui.SetNextItemWidth(100);
        if (ImGui.InputInt("##Crystal Formation Send", ref C.CrystalFormationWorkshop))
        {
            C.CrystalFormationWorkshop = AmountSet(C.CrystalFormationWorkshop);
            IslandSancDictionary[CrystalFormationID].Workshop = C.CrystalFormationWorkshop;
        }
    }

    public static void Route0WorkshopGui()
    {
        ImGui.TextWrapped($"Route 0 is set to run -> {Route0Amount} loops");
        IslefishImgui();
        ClamImgui();
        SquidImgui();
        LaverImgui();
    }

    public static void Route1WorkshopGui()
    {
        ImGui.TextWrapped($"Route 1 is set to run -> {Route1Amount} loops");
        IslewortImgui();
    }

    public static void Route2WorkshopGui()
    {
        ImGui.TextWrapped($"Route 2 is set to run -> {Route2Amount} loops");
        SugarcaneImgui();
        VineImgui();
    }

    public static void Route3WorkshopGui()
    {
        ImGui.TextWrapped($"Route 3 is set to run -> {Route3Amount} loops");
        TinsandImgui();
        SandImgui();
        MarbleImgui();
        LimestoneImgui();
        StoneImgui();
    }

    public static void Route4WorkshopGui()
    {
        ImGui.TextWrapped($"Route 4 is set to run -> {Route4Amount} loops");
        AppleImgui();
        BeehiveImgui();
        VineImgui();
        SapImgui();
        WoodOpalImgui();
        BranchImgui();
        ResinImgui();
        SandImgui();
        ClayImgui();
        LogImgui();
    }

    public static void Route5WorkshopGui()
    {
        ImGui.TextWrapped($"Route 5 is set to run -> {Route5Amount} loops");
        CoconutImgui();
        PalmLogImgui();
        PalmLeafImgui();
        LimestoneImgui();
        MarbleImgui();
        StoneImgui();
    }

    public static void Route6WorkshopGui()
    {
        ImGui.TextWrapped($"Route 6 is set to run -> {Route6Amount} loops");
        CottonImgui();
        HempImgui();
        CoconutImgui();
        PalmLogImgui();
        PalmLeafImgui();
        IslewortImgui();
    }

    public static void Route7WorkshopGui()
    {
        ImGui.Text($"Route 7 is set to run -> {Route7Amount} loops");
        ClayImgui();
        TinsandImgui();
        MarbleImgui();
        LimestoneImgui();
        BranchImgui();
        LogImgui();
        ResinImgui();
        SandImgui();
    }

    public static void Route8WorkshopGui()
    {
        MarbleImgui();
        LimestoneImgui();
        StoneImgui();
        SugarcaneImgui();
        VineImgui();
        CoconutImgui();
        PalmLeafImgui();
        PalmLogImgui();
        TinsandImgui();
        SandImgui();
        HempImgui();
        IslewortImgui();
    }

    public static void Route9WorkshopGui()
    {
        ImGui.Text($"Route 9 is set to run -> {Route9Amount} loops");
        BranchImgui();
        ResinImgui();
        SapImgui();
        WoodOpalImgui();
        LogImgui();
        ClayImgui();
        SandImgui();
        LogImgui();
    }

    public static void Route10WorkshopGui()
    {
        ImGui.Text($"Route 10 is set to run -> {Route10Amount} loops");
        CopperImgui();
        MythrilOreImgui();
        HempImgui();
        CoconutImgui();
        PalmLogImgui();
        PalmLeafImgui();
        CottonImgui();
        IslewortImgui();
        StoneImgui();
    }

    public static void Route11WorkshopGui()
    {
        ImGui.Text($"Route 11 is set to run -> {Route11Amount} loops");
        SapImgui();
        WoodOpalImgui();
        LogImgui();
        HempImgui();
        IslewortImgui();
    }

    public static void Route12WorkshopGui()
    {
        ImGui.Text($"Route 12 is set to run -> {Route12Amount} loops");
        HempImgui();
        IslewortImgui();
        SandImgui();
        ClayImgui();
        CoconutImgui();
        PalmLogImgui();
        PalmLeafImgui();
    }

    public static void Route13WorkshopGui()
    {
        ImGui.Text($"Route 13 is set to run -> {Route13Amount} loops");
        MulticoloredIslebloomsImgui();
        QuartzImgui();
        IronOreImgui();
        DuriumSandImgui();
        LeucograniteImgui();
        StoneImgui();
    }

    public static void Route14WorkshopGui()
    {
        ImGui.Text($"Route 14 is set to run -> {Route14Amount} loops");
        IronOreImgui();
        StoneImgui();
    }

    public static void Route15WorkshopGui()
    {
        ImGui.Text($"Route 15 is set to run -> {Route15Amount} loops");
        LaverImgui();
        SquidImgui();
        JellyfishImgui();
        CoralImgui();
    }

    public static void Route16WorkshopGui()
    {
        ImGui.Text($"Route 16 is set to run -> {Route16Amount} loops");
        RockSaltImgui();
        StoneImgui();
        ClayImgui();
        SandImgui();
        IslewortImgui();
        HempImgui();
    }

    public static void Route17WorkshopGui()
    {
        ImGui.Text($"Route 17 is set to run -> {Route17Amount} loops");
        LeucograniteImgui();
        CopperImgui();
        MythrilOreImgui();
        IronOreImgui();
        DuriumSandImgui();
        StoneImgui();
    }

    public static void Route18WorkshopGui()
    {
        ImGui.Text($"Route 18 is set to run -> {Route18Amount} loops");
        QuartzImgui();
        IronOreImgui();
        DuriumSandImgui();
        LeucograniteImgui();
        StoneImgui();
    }

    public static void Route19WorkshopGui()
    {
        ImGui.Text($"Route 19 is set to run -> {Route19Amount} loops");
        GlimshroomImgui();
        ShaleImgui();
        CoalImgui();
        StoneImgui();
    }

    public static void Route20WorkshopGui()
    {
        ImGui.Text($"Route 20 is set to run -> {Route20Amount} loops");
        EffervescentWaterImgui();
        SpectrineImgui();
        ShaleImgui();
        CoalImgui();
        StoneImgui();
    }

    public static void Route21WorkshopGui()
    {
        ImGui.Text($"Route 21 is set to run -> {Route21Amount} loops");
        YellowCopperOreImgui();
        GoldOreImgui();
        CrystalFormationImgui();
        HawksEyeSandImgui();
        GlimshroomImgui();
        EffervescentWaterImgui();
        SpectrineImgui();
        ShaleImgui();
        CoalImgui();
        StoneImgui();
    }
}
