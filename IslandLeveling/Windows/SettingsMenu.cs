using Dalamud.Interface.Utility.Raii;

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
                if (palmleafWS < 0) palmleafWS = 0;
                PalmLeafWorkshop = palmleafWS;
            }
            
            ImGui.Text($"Branch (Have: {BranchAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Branch Send", ref branchWS))
            {
                if (branchWS < 0) branchWS = 0;
                BranchWorkshop = branchWS;
            }
            
            ImGui.Text($"Stone (Have: {StoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Stone Send", ref stoneWS))
            {
                if (stoneWS < 0) stoneWS = 0;
                StoneWorkshop = stoneWS;
            }

            ImGui.Text($"Clam (Have: {ClamAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clam Send", ref clamWS))
            {
                if (clamWS < 0) clamWS = 0;
                ClamWorkshop = clamWS;
            }

            ImGui.Text($"Laver (Have: {LaverAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Laver Send", ref laverWS))
            {
                if (laverWS < 0) laverWS = 0;
                LaverWorkshop = laverWS;
            }
            
            ImGui.Text($"Coral (Have: {CoralAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coral Send", ref coralWS))
            {
                if (coralWS < 0) coralWS = 0;
                CoralWorkshop = coralWS;
            }

            ImGui.Text($"Islewort (Have: {IslewortAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islewort Send", ref islewortWS))
            {
                if (islewortWS < 0) islewortWS = 0;
                IslewortWorkshop = islewortWS;
            }

            ImGui.Text($"Sand (Have: {SandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sand Send", ref sandWS))
            {
                if (sandWS < 0) sandWS = 0;
                SandWorkshop = sandWS;
            }

            ImGui.Text($"Vine (Have: {VineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Vine Send", ref vineWS))
            {
                if (vineWS < 0) vineWS = 0;
                VineWorkshop = vineWS;
            }

            ImGui.Text($"Sap (Have: {SapAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sap Send", ref sapWS))
            {
                if (sapWS < 0) sapWS = 0;
                SapWorkshop = sapWS;
            }

            ImGui.Text($"Apple (Have: {AppleAmount})");
            ImGui.SameLine(); 
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Apple Send", ref appleWS))
            {
                if (appleWS < 0) appleWS = 0;
                AppleWorkshop = appleWS;
            }

            ImGui.Text($"Log (Have: {LogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Log Send", ref logWS))
            {
                if (logWS < 0) logWS = 0;
                LogWorkshop = logWS;
            }
            
            ImGui.Text($"Palm Log (Have: {PalmLogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Log Send", ref palmlogWS))
            {
                if (palmlogWS < 0) palmlogWS = 0;
                PalmLogWorkshop = palmlogWS;
            }

            ImGui.Text($"Copper (Have: {CopperAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Copper Send", ref copperWS))
            {
                if (copperWS < 0) copperWS = 0;
                CopperWorkshop = copperWS;
            }

            ImGui.Text($"Limestone (Have: {LimestoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Limestone Send", ref limestoneWS))
            {
                if (limestoneWS < 0) limestoneWS = 0;
                LimestoneWorkshop = limestoneWS;
            }

            ImGui.Text($"Rock Salt (Have: {RockSaltAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Rock Salt Send", ref rocksaltWS))
            {
                if (rocksaltWS < 0) rocksaltWS = 0;
                RockSaltWorkshop = rocksaltWS;
            }

            ImGui.Text($"Clay (Have: {ClayAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clay Send", ref clayWS))
            {
                if (clayWS < 0) clayWS = 0;
                ClayWorkshop = clayWS;
            }

            ImGui.Text($"Tinsand (Have: {TinsandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Tinsand Send", ref tinsandWS))
            {
                if (tinsandWS < 0) tinsandWS = 0;
                TinsandWorkshop = tinsandWS;
            }

            ImGui.Text($"Sugarcane (Have: {SugarcaneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sugarcane Send", ref sugarcaneWS))
            {
                if (sugarcaneWS < 0) sugarcaneWS = 0;
                SugarcaneWorkshop = sugarcaneWS;
            }

            ImGui.Text($"Cotton (Have: {CottonAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Cotton Send", ref cottonWS))
            {
                if (cottonWS < 0) cottonWS = 0;
                CottonWorkshop = cottonWS;
            }

            ImGui.Text($"Hemp (Have: {HempAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hemp Send", ref hempWS))
            {
                if (hempWS < 0) hempWS = 0;
                HempWorkshop = hempWS;
            }

            ImGui.Text($"Islefish (Have: {IslefishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islefish Send", ref islefishWS))
            {
                if (islefishWS < 0) islefishWS = 0;
                IslefishWorkshop = islefishWS;
            }

            ImGui.Text($"Squid (Have: {SquidAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Squid Send", ref squidWS))
            {
                if (squidWS < 0) squidWS = 0;
                SquidWorkshop = squidWS;
            }

            ImGui.Text($"Jellyfish (Have: {JellyfishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Jellyfish Send", ref jellyfishWS))
            {
                if (jellyfishWS < 0) jellyfishWS = 0;
                JellyfishWorkshop = jellyfishWS;
            }

            ImGui.Text($"Iron Ore (Have: {IronOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Iron Ore Send", ref ironoreWS))
            {
                if (ironoreWS < 0) ironoreWS = 0;
                IronOreWorkshop = ironoreWS;
            }

            ImGui.Text($"Quartz (Have: {QuartzAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Quartz Send", ref quartzWS))
            {
                if (quartzWS < 0) quartzWS = 0;
                QuartzWorkshop = quartzWS;
            }

            ImGui.Text($"Leucogranite (Have: {LeucograniteAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Leucogranite Send", ref leucograniteWS))
            {
                if (leucograniteWS < 0) leucograniteWS = 0;
                LeucograniteWorkshop = leucograniteWS;
            }

            ImGui.Text($"Multicolored Isleblooms (Have: {MulticoloredIslebloomsAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Multicolored Isleblooms Send", ref multicoloredislebloomsWS))
            {
                if (multicoloredislebloomsWS < 0) multicoloredislebloomsWS = 0;
                MulticoloredIslebloomsWorkshop = multicoloredislebloomsWS;
            }

            ImGui.Text($"Resin (Have: {ResinAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Resin Send", ref resinWS))
            {
                if (resinWS < 0) resinWS = 0;
                ResinWorkshop = resinWS;
            }

            ImGui.Text($"Coconut (Have: {CoconutAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coconut Send", ref coconutWS))
            {
                if (coconutWS < 0) coconutWS = 0;
                CoconutWorkshop = coconutWS;
            }

            ImGui.Text($"Beehive (Have: {BeehiveAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Beehive Send", ref beehiveWS))
            {
                if (beehiveWS < 0) beehiveWS = 0;
                BeehiveWorkshop = beehiveWS;
            }

            ImGui.Text($"Wood Opal (Have: {WoodOpalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Wood Opal Send", ref woodopalWS))
            {
                if (woodopalWS < 0) woodopalWS = 0;
                WoodOpalWorkshop = woodopalWS;
            }

            ImGui.Text($"Coal (Have: {CoalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coal Send", ref coalWS))
            {
                if (coalWS < 0) coalWS = 0;
                CoalWorkshop = coalWS;
            }

            ImGui.Text($"Glimshroom (Have: {GlimshroomAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Glimshroom Send", ref glimshroomWS))
            {
                if (glimshroomWS < 0) glimshroomWS = 0;
                GlimshroomWorkshop = glimshroomWS;
            }

            ImGui.Text($"Effervescent Water (Have: {EffervescentWaterAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Effervescent Water Send", ref effervescentwaterWS))
            {
                if (effervescentwaterWS < 0) effervescentwaterWS = 0;
                EffervescentWaterWorkshop = effervescentwaterWS;
            }

            ImGui.Text($"Shale (Have: {ShaleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Shale Send", ref shaleWS))
            {
                if (shaleWS < 0) shaleWS = 0;
                ShaleWorkshop = shaleWS;
            }

            ImGui.Text($"Marble (Have: {MarbleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Marble Send", ref marbleWS))
            {
                if (marbleWS < 0) marbleWS = 0;
                MarbleWorkshop = marbleWS;
            }

            ImGui.Text($"Mythril Ore (Have: {MythrilOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Mythril Ore Send", ref mythriloreWS))
            {
                if (mythriloreWS < 0) mythriloreWS = 0;
                MythrilOreWorkshop = mythriloreWS;
            }

            ImGui.Text($"Spectrine (Have: {SpectrineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Spectrine Send", ref spectrineWS))
            {
                if (spectrineWS < 0) spectrineWS = 0;
                SpectrineWorkshop = spectrineWS;
            }

            ImGui.Text($"Durium Sand (Have: {DuriumSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Durium Sand Send", ref duriumsandWS))
            {
                if (duriumsandWS < 0) duriumsandWS = 0;
                DuriumSandWorkshop = duriumsandWS;
            }

            ImGui.Text($"Yellow Copper Ore (Have: {YellowCopperOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Yellow Copper Ore Send", ref yellowcopperoreWS))
            {
                if (yellowcopperoreWS < 0) yellowcopperoreWS = 0;
                YellowCopperOreWorkshop = yellowcopperoreWS;
            }

            ImGui.Text($"Gold Ore (Have: {GoldOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Gold Ore Send", ref goldoreWS))
            {
                if (goldoreWS < 0) goldoreWS = 0;
                GoldOreWorkshop = goldoreWS;
            }

            ImGui.Text($"Hawk's Eye Sand (Have: {HawksEyeSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hawk's Eye Sand Send", ref hawkseyesandWS))
            {
                if (hawkseyesandWS < 0) hawkseyesandWS = 0;
                HawksEyeSandWorkshop = hawkseyesandWS;
            }

            ImGui.Text($"Crystal Formation (Have: {CrystalFormationAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Crystal Formation Send", ref crystalformationWS))
            {
                if (crystalformationWS < 0) crystalformationWS = 0;
                CrystalFormationWorkshop = crystalformationWS;
            }
        }
    }
}

