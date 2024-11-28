using Dalamud.Interface.Utility.Raii;
using System.Runtime.CompilerServices;

namespace IslandLeveling.Windows
{
    internal class SettingMenu : Window ,IDisposable
    {
        public new static readonly string WindowName = "Islanc Sanc Leveling Settings";
        public SettingMenu() : base(WindowName)
        {
            Flags = ImGuiWindowFlags.NoCollapse;
            ImGui.SetNextWindowSize(new Vector2(450, 0), ImGuiCond.Always);
        }
        
        public void Dispose() { }


        public override void Draw()
        {
            int palmleafWS = PalmLeafWorkshop;
            int branchWS = BranchWorkshop;
            int stoneWS = StoneWorkshop;
            int clamWS = ClamWorkshop;
            int laverWS = LaverWorkshop;
            int coralWS = CoralWorkshop;
            int islewortWS = IslewortWorkshop;
            int sandWS = SandWorkshop;
            int vineWS = VineWorkshop;
            int sapWS = SapWorkshop;
            int appleWS = AppleWorkshop;
            int logWS = LogWorkshop;
            int palmlogWS = PalmLogWorkshop;
            int copperWS = CopperWorkshop;
            int limestoneWS = LimestoneWorkshop;
            int rocksaltWS = RockSaltWorkshop;
            int clayWS = ClayWorkshop;
            int tinsandWS = TinsandWorkshop;
            int sugarcaneWS = SugarcaneWorkshop;
            int cottonWS = CottonWorkshop;
            int hempWS = HempWorkshop;
            int islefishWS = IslefishWorkshop;
            int squidWS = SquidWorkshop;
            int jellyfishWS = JellyfishWorkshop;
            int ironoreWS = IronOreWorkshop;
            int quartzWS = QuartzWorkshop;
            int leucograniteWS = LeucograniteWorkshop;
            int multicoloredislebloomsWS = MulticoloredIslebloomsWorkshop;
            int resinWS = ResinWorkshop;
            int coconutWS = CoconutWorkshop;
            int beehiveWS = BeehiveWorkshop;
            int woodopalWS = WoodOpalWorkshop;
            int coalWS = CoalWorkshop;
            int glimshroomWS = GlimshroomWorkshop;
            int effervescentwaterWS = EffervescentWaterWorkshop;
            int shaleWS = ShaleWorkshop;
            int marbleWS = MarbleWorkshop;
            int mythriloreWS = MythrilOreWorkshop;
            int spectrineWS = SpectrineWorkshop;
            int duriumsandWS = DuriumSandWorkshop;
            int yellowcopperoreWS = YellowCopperOreWorkshop;
            int goldoreWS = GoldOreWorkshop;
            int hawkseyesandWS = HawksEyeSandWorkshop;
            int crystalformationWS = CrystalFormationWorkshop;

            static int AmountSet(int input)
            {
                if (input < 0) input = 0;
                else if (input > 999) input = 999;
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
            if (ImGui.InputInt("##Palm Leaf", ref palmleafWS))
            {
                PalmLeafWorkshop = AmountSet(palmleafWS);
            }
            
            ImGui.Text($"Branch (Have: {BranchAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Branch Send", ref branchWS))
            {
                BranchWorkshop = AmountSet(branchWS);
            }
            
            ImGui.Text($"Stone (Have: {StoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Stone Send", ref stoneWS))
            {
                StoneWorkshop = AmountSet(stoneWS);
            }

            ImGui.Text($"Clam (Have: {ClamAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clam Send", ref clamWS))
            {
                ClamWorkshop = AmountSet(clamWS);
            }

            ImGui.Text($"Laver (Have: {LaverAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Laver Send", ref laverWS))
            {
                LaverWorkshop = AmountSet(laverWS);
            }
            
            ImGui.Text($"Coral (Have: {CoralAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coral Send", ref coralWS))
            {
                CoralWorkshop = AmountSet(coralWS);
            }

            ImGui.Text($"Islewort (Have: {IslewortAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islewort Send", ref islewortWS))
            {
                IslewortWorkshop = AmountSet(islewortWS);
            }

            ImGui.Text($"Sand (Have: {SandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sand Send", ref sandWS))
            {
                SandWorkshop = AmountSet(sandWS);
            }

            ImGui.Text($"Vine (Have: {VineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Vine Send", ref vineWS))
            {
                VineWorkshop = AmountSet(vineWS);
            }

            ImGui.Text($"Sap (Have: {SapAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sap Send", ref sapWS))
            {
                SapWorkshop = AmountSet(sapWS);
            }

            ImGui.Text($"Apple (Have: {AppleAmount})");
            ImGui.SameLine(); 
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Apple Send", ref appleWS))
            {
                AppleWorkshop = AmountSet(appleWS);
            }

            ImGui.Text($"Log (Have: {LogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Log Send", ref logWS))
            {
                LogWorkshop = AmountSet(logWS);
            }
            
            ImGui.Text($"Palm Log (Have: {PalmLogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Log Send", ref palmlogWS))
            {
                PalmLogWorkshop = AmountSet(palmlogWS);
            }

            ImGui.Text($"Copper (Have: {CopperAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Copper Send", ref copperWS))
            {
                CopperWorkshop = AmountSet(copperWS);
            }

            ImGui.Text($"Limestone (Have: {LimestoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Limestone Send", ref limestoneWS))
            {
                LimestoneWorkshop = AmountSet(limestoneWS);
            }

            ImGui.Text($"Rock Salt (Have: {RockSaltAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Rock Salt Send", ref rocksaltWS))
            {
                RockSaltWorkshop = AmountSet(rocksaltWS);
            }

            ImGui.Text($"Clay (Have: {ClayAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clay Send", ref clayWS))
            {
                ClayWorkshop = AmountSet(clayWS);
            }

            ImGui.Text($"Tinsand (Have: {TinsandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Tinsand Send", ref tinsandWS))
            {
                TinsandWorkshop = AmountSet(tinsandWS);
            }

            ImGui.Text($"Sugarcane (Have: {SugarcaneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sugarcane Send", ref sugarcaneWS))
            {
                SugarcaneWorkshop = AmountSet(sugarcaneWS);
            }

            ImGui.Text($"Cotton (Have: {CottonAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Cotton Send", ref cottonWS))
            {
                CottonWorkshop = AmountSet(cottonWS);
            }

            ImGui.Text($"Hemp (Have: {HempAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hemp Send", ref hempWS))
            {
                HempWorkshop = AmountSet(hempWS);
            }

            ImGui.Text($"Islefish (Have: {IslefishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islefish Send", ref islefishWS))
            {
                IslefishWorkshop = AmountSet(islefishWS);
            }

            ImGui.Text($"Squid (Have: {SquidAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Squid Send", ref squidWS))
            {
                SquidWorkshop = AmountSet(squidWS);
            }

            ImGui.Text($"Jellyfish (Have: {JellyfishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Jellyfish Send", ref jellyfishWS))
            {
                JellyfishWorkshop = AmountSet(jellyfishWS);
            }

            ImGui.Text($"Iron Ore (Have: {IronOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Iron Ore Send", ref ironoreWS))
            {
                IronOreWorkshop = AmountSet(ironoreWS);
            }

            ImGui.Text($"Quartz (Have: {QuartzAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Quartz Send", ref quartzWS))
            {
                QuartzWorkshop = AmountSet(quartzWS);
            }

            ImGui.Text($"Leucogranite (Have: {LeucograniteAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Leucogranite Send", ref leucograniteWS))
            {
                LeucograniteWorkshop = AmountSet(leucograniteWS);
            }

            ImGui.Text($"Multicolored Isleblooms (Have: {MulticoloredIslebloomsAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Multicolored Isleblooms Send", ref multicoloredislebloomsWS))
            {
                MulticoloredIslebloomsWorkshop = AmountSet(multicoloredislebloomsWS);
            }

            ImGui.Text($"Resin (Have: {ResinAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Resin Send", ref resinWS))
            {
                ResinWorkshop = AmountSet(resinWS);
            }

            ImGui.Text($"Coconut (Have: {CoconutAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coconut Send", ref coconutWS))
            {
                CoconutWorkshop = AmountSet(coconutWS);
            }

            ImGui.Text($"Beehive (Have: {BeehiveAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Beehive Send", ref beehiveWS))
            {
                BeehiveWorkshop = AmountSet(beehiveWS);
            }

            ImGui.Text($"Wood Opal (Have: {WoodOpalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Wood Opal Send", ref woodopalWS))
            {
                WoodOpalWorkshop = AmountSet(woodopalWS);
            }

            ImGui.Text($"Coal (Have: {CoalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coal Send", ref coalWS))
            {
                CoalWorkshop = AmountSet(coalWS);
            }

            ImGui.Text($"Glimshroom (Have: {GlimshroomAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Glimshroom Send", ref glimshroomWS))
            {
                GlimshroomWorkshop = AmountSet(glimshroomWS);
            }

            ImGui.Text($"Effervescent Water (Have: {EffervescentWaterAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Effervescent Water Send", ref effervescentwaterWS))
            {
                EffervescentWaterWorkshop = AmountSet(effervescentwaterWS);
            }

            ImGui.Text($"Shale (Have: {ShaleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Shale Send", ref shaleWS))
            {
                ShaleWorkshop = AmountSet(shaleWS);
            }

            ImGui.Text($"Marble (Have: {MarbleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Marble Send", ref marbleWS))
            {
                MarbleWorkshop = AmountSet(marbleWS);
            }

            ImGui.Text($"Mythril Ore (Have: {MythrilOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Mythril Ore Send", ref mythriloreWS))
            {
                MythrilOreWorkshop = AmountSet(mythriloreWS);
            }

            ImGui.Text($"Spectrine (Have: {SpectrineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Spectrine Send", ref spectrineWS))
            {
                SpectrineWorkshop = AmountSet(spectrineWS);
            }

            ImGui.Text($"Durium Sand (Have: {DuriumSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Durium Sand Send", ref duriumsandWS))
            {
                DuriumSandWorkshop = AmountSet(duriumsandWS);
            }

            ImGui.Text($"Yellow Copper Ore (Have: {YellowCopperOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Yellow Copper Ore Send", ref yellowcopperoreWS))
            {
                YellowCopperOreWorkshop = AmountSet(yellowcopperoreWS);
            }

            ImGui.Text($"Gold Ore (Have: {GoldOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Gold Ore Send", ref goldoreWS))
            {
                GoldOreWorkshop = AmountSet(goldoreWS);
            }

            ImGui.Text($"Hawk's Eye Sand (Have: {HawksEyeSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hawk's Eye Sand Send", ref hawkseyesandWS))
            {
                HawksEyeSandWorkshop = AmountSet(hawkseyesandWS);
            }

            ImGui.Text($"Crystal Formation (Have: {CrystalFormationAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Crystal Formation Send", ref crystalformationWS))
            {
                CrystalFormationWorkshop = AmountSet(crystalformationWS);
            }
        }
    }
}

