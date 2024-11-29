using Dalamud.Interface.Utility.Raii;
using ECommons.Configuration;
using FFXIVClientStructs.FFXIV.Client.Game;
using System.Runtime.CompilerServices;

namespace IslandLeveling.Windows
{
    internal class SettingMenu : Window ,IDisposable
    {
        public new static readonly string WindowName = "Islanc Sanc Workshop Amounts";
        public SettingMenu() : base(WindowName)
        {
            Flags = ImGuiWindowFlags.NoCollapse;
            ImGui.SetNextWindowSize(new Vector2(450, 0), ImGuiCond.Always);
        }
        
        public void Dispose() { }


        public override void Draw()
        {
            static int AmountSet(int input)
            {
                if (input < 0) input = 0;
                else if (input > 999) input = 999;
                EzConfig.Save();
                return input;
            }

            float windowWidth = ImGui.GetWindowContentRegionMax().X; // Get the usable width of the window
            float inputWidth = 100.0f; // Desired width of the input field
            float offset = windowWidth - inputWidth; // Calculate position to hug the right wall

            ImGui.PushItemWidth(100);
            ImGui.PopItemWidth();
            ImGui.TextWrapped("Island Sanctuary Items to keep. Please input how many of them you need for workshop");
            ImGui.Separator();
            
            ImGui.Text($"Palm Leaf (Have: {PalmLeafAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Leaf", ref C.PalmLeafWorkshop))
            {
                C.PalmLeafWorkshop = AmountSet(C.PalmLeafWorkshop);
            }
            
            ImGui.Text($"Branch (Have: {BranchAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Branch Send", ref C.BranchWorkshop))
            {
                C.BranchWorkshop = AmountSet(C.BranchWorkshop);
            }
            
            ImGui.Text($"Stone (Have: {StoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Stone Send", ref C.StoneWorkshop))
            {
                C.StoneWorkshop = AmountSet(C.StoneWorkshop);
            }

            ImGui.Text($"Clam (Have: {ClamAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clam Send", ref C.ClamWorkshop))
            {
                C.ClamWorkshop = AmountSet(C.ClamWorkshop);
            }

            ImGui.Text($"Laver (Have: {LaverAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Laver Send", ref C.LaverWorkshop))
            {
                C.LaverWorkshop = AmountSet(C.LaverWorkshop);
            }
            
            ImGui.Text($"Coral (Have: {CoralAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coral Send", ref C.CoralWorkshop))
            {
                C.CoralWorkshop = AmountSet(C.CoralWorkshop);
            }

            ImGui.Text($"Islewort (Have: {IslewortAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islewort Send", ref C.IslewortWorkshop))
            {
                C.IslewortWorkshop = AmountSet(C.IslewortWorkshop);
            }

            ImGui.Text($"Sand (Have: {SandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sand Send", ref C.SandWorkshop))
            {
                C.SandWorkshop = AmountSet(C.SandWorkshop);
            }

            ImGui.Text($"Vine (Have: {VineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Vine Send", ref C.VineWorkshop))
            {
                C.VineWorkshop = AmountSet(C.VineWorkshop);
            }

            ImGui.Text($"Sap (Have: {SapAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sap Send", ref C.SapWorkshop))
            {
                C.SapWorkshop = AmountSet(C.SapWorkshop);
            }

            ImGui.Text($"Apple (Have: {AppleAmount})");
            ImGui.SameLine(); 
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Apple Send", ref C.AppleWorkshop))
            {
                C.AppleWorkshop = AmountSet(C.AppleWorkshop);
            }

            ImGui.Text($"Log (Have: {LogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Log Send", ref C.LogWorkshop))
            {
                C.LogWorkshop = AmountSet(C.LogWorkshop);
            }
            
            ImGui.Text($"Palm Log (Have: {PalmLogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Log Send", ref C.PalmLogWorkshop))
            {
                C.PalmLogWorkshop = AmountSet(C.PalmLogWorkshop);
            }

            ImGui.Text($"Copper (Have: {CopperAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Copper Send", ref C.CopperWorkshop))
            {
                C.CopperWorkshop = AmountSet(C.CopperWorkshop);
            }

            ImGui.Text($"Limestone (Have: {LimestoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Limestone Send", ref C.LimestoneWorkshop))
            {
                C.LimestoneWorkshop = AmountSet(C.LimestoneWorkshop);
            }

            ImGui.Text($"Rock Salt (Have: {RockSaltAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Rock Salt Send", ref C.RockSaltWorkshop))
            {
                C.RockSaltWorkshop = AmountSet(C.RockSaltWorkshop);
            }

            ImGui.Text($"Clay (Have: {ClayAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clay Send", ref C.ClayWorkshop))
            {
                C.ClayWorkshop = AmountSet(C.ClayWorkshop);
            }

            ImGui.Text($"Tinsand (Have: {TinsandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Tinsand Send", ref C.TinsandWorkshop))
            {
                C.TinsandWorkshop = AmountSet(C.TinsandWorkshop);
            }

            ImGui.Text($"Sugarcane (Have: {SugarcaneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sugarcane Send", ref C.SugarcaneWorkshop))
            {
                C.SugarcaneWorkshop = AmountSet(C.SugarcaneWorkshop);
            }

            ImGui.Text($"Cotton (Have: {CottonAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Cotton Send", ref C.CottonWorkshop))
            {
                C.CottonWorkshop = AmountSet(C.CottonWorkshop);
            }

            ImGui.Text($"Hemp (Have: {HempAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hemp Send", ref C.HempWorkshop))
            {
                C.HempWorkshop = AmountSet(C.HempWorkshop);
            }

            ImGui.Text($"Islefish (Have: {IslefishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islefish Send", ref C.IslefishWorkshop))
            {
                C.IslefishWorkshop = AmountSet(C.IslefishWorkshop);
            }

            ImGui.Text($"Squid (Have: {SquidAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Squid Send", ref C.SquidWorkshop))
            {
                C.SquidWorkshop = AmountSet(C.SquidWorkshop);
            }

            ImGui.Text($"Jellyfish (Have: {JellyfishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Jellyfish Send", ref C.JellyfishWorkshop))
            {
                C.JellyfishWorkshop = AmountSet(C.JellyfishWorkshop);
            }

            ImGui.Text($"Iron Ore (Have: {IronOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Iron Ore Send", ref C.IronOreWorkshop))
            {
                C.IronOreWorkshop = AmountSet(C.IronOreWorkshop);
            }

            ImGui.Text($"Quartz (Have: {QuartzAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Quartz Send", ref C.QuartzWorkshop))
            {
                C.QuartzWorkshop = AmountSet(C.QuartzWorkshop);
            }

            ImGui.Text($"Leucogranite (Have: {LeucograniteAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Leucogranite Send", ref C.LeucograniteWorkshop))
            {
                C.LeucograniteWorkshop = AmountSet(C.LeucograniteWorkshop);
            }

            ImGui.Text($"Multicolored Isleblooms (Have: {MulticoloredIslebloomsAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Multicolored Isleblooms Send", ref C.MulticoloredIslebloomsWorkshop))
            {
                C.MulticoloredIslebloomsWorkshop = AmountSet(C.MulticoloredIslebloomsWorkshop);
            }

            ImGui.Text($"Resin (Have: {ResinAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Resin Send", ref C.ResinWorkshop))
            {
                C.ResinWorkshop = AmountSet(C.ResinWorkshop);
            }

            ImGui.Text($"Coconut (Have: {CoconutAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coconut Send", ref C.CoconutWorkshop))
            {
                C.LaverWorkshop = AmountSet(C.CoconutWorkshop);
            }

            ImGui.Text($"Beehive (Have: {BeehiveAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Beehive Send", ref C.BeehiveWorkshop))
            {
                C.BeehiveWorkshop = AmountSet(C.BeehiveWorkshop);
            }

            ImGui.Text($"Wood Opal (Have: {WoodOpalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Wood Opal Send", ref C.WoodOpalWorkshop))
            {
                C.WoodOpalWorkshop = AmountSet(C.WoodOpalWorkshop);
            }

            ImGui.Text($"Coal (Have: {CoalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coal Send", ref C.CoalWorkshop))
            {
                C.CoalWorkshop = AmountSet(C.CoalWorkshop);
            }

            ImGui.Text($"Glimshroom (Have: {GlimshroomAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Glimshroom Send", ref C.GlimshroomWorkshop))
            {
                C.GlimshroomWorkshop = AmountSet(C.GlimshroomWorkshop);
            }

            ImGui.Text($"Effervescent Water (Have: {EffervescentWaterAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Effervescent Water Send", ref C.EffervescentWaterWorkshop))
            {
                C.EffervescentWaterWorkshop = AmountSet(C.EffervescentWaterWorkshop);
            }

            ImGui.Text($"Shale (Have: {ShaleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Shale Send", ref C.ShaleWorkshop))
            {
                C.ShaleWorkshop = AmountSet(C.ShaleWorkshop);
            }

            ImGui.Text($"Marble (Have: {MarbleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Marble Send", ref C.MarbleWorkshop))
            {
                C.MarbleWorkshop = AmountSet(C.MarbleWorkshop);
            }

            ImGui.Text($"Mythril Ore (Have: {MythrilOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Mythril Ore Send", ref C.MythrilOreWorkshop))
            {
                C.MythrilOreWorkshop = AmountSet(C.MythrilOreWorkshop);
            }

            ImGui.Text($"Spectrine (Have: {SpectrineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Spectrine Send", ref C.SpectrineWorkshop))
            {
                C.SpectrineWorkshop = AmountSet(C.SpectrineWorkshop);
            }

            ImGui.Text($"Durium Sand (Have: {DuriumSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Durium Sand Send", ref C.DuriumSandWorkshop))
            {
                C.DuriumSandWorkshop = AmountSet(C.DuriumSandWorkshop);
            }

            ImGui.Text($"Yellow Copper Ore (Have: {YellowCopperOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Yellow Copper Ore Send", ref C.YellowCopperOreWorkshop))
            {
                C.YellowCopperOreWorkshop = AmountSet(C.YellowCopperOreWorkshop);
            }

            ImGui.Text($"Gold Ore (Have: {GoldOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Gold Ore Send", ref C.GoldOreWorkshop))
            {
               C.GoldOreWorkshop = AmountSet(C.GoldOreWorkshop);
            }

            ImGui.Text($"Hawk's Eye Sand (Have: {HawksEyeSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hawk's Eye Sand Send", ref C.HawksEyeSandWorkshop))
            {
                C.HawksEyeSandWorkshop = AmountSet(C.HawksEyeSandWorkshop);
            }

            ImGui.Text($"Crystal Formation (Have: {CrystalFormationAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Crystal Formation Send", ref C.CrystalFormationWorkshop))
            {
                C.CrystalFormationWorkshop = AmountSet(C.CrystalFormationWorkshop);
            }
        }
    }
}

