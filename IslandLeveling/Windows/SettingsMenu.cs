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
            int palmleafWS = C.PalmLeafWS;
            int branchWS = C.BranchWS;
            int stoneWS = C.StoneWS;
            int clamWS = C.ClamWS;
            int laverWS = C.LaverWS;
            int coralWS = C.CoralWS;
            int islewortWS = C.IslewortWS;
            int sandWS = C.SandWS;
            int vineWS = C.VineWS;
            int sapWS = C.SapWS;
            int appleWS = C.AppleWS;
            int logWS = C.LogWS;
            int palmlogWS = C.PalmLogWS;
            int copperWS = C.CopperWS;
            int limestoneWS = C.LimestoneWS;
            int rocksaltWS = C.RockSaltWS;
            int clayWS = C.ClayWS;
            int tinsandWS = C.TinsandWS;
            int sugarcaneWS = C.SugarcaneWS;
            int cottonWS = C.CottonWS;
            int hempWS = C.HempWS;
            int islefishWS = C.IslefishWS;
            int squidWS = C.SquidWS;
            int jellyfishWS = C.JellyfishWS;
            int ironoreWS = C.IronOreWS;
            int quartzWS = C.QuartzWS;
            int leucograniteWS = C.LeucograniteWS;
            int multicoloredislebloomsWS = C.MulticoloredIslebloomsWS;
            int resinWS = C.ResinWS;
            int coconutWS = C.CoconutWS;
            int beehiveWS = C.BeehiveWS;
            int woodopalWS = C.WoodOpalWS;
            int coalWS = C.CoalWS;
            int glimshroomWS = C.GlimshroomWS;
            int effervescentwaterWS = C.EffervescentWaterWS;
            int shaleWS = C.ShaleWS;
            int marbleWS = C.MarbleWS;
            int mythriloreWS = C.MythrilOreWS;
            int spectrineWS = C.SpectrineWS;
            int duriumsandWS = C.DuriumSandWS;
            int yellowcopperoreWS = C.YellowCopperOreWS;
            int goldoreWS = C.GoldOreWS;
            int hawkseyesandWS = C.HawksEyeSandWS;
            int crystalformationWS = C.CrystalFormationWS;

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
                C.PalmLeafWS = palmleafWS;
            }
            
            ImGui.Text($"Branch (Have: {BranchAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Branch Send", ref branchWS))
            {
                if (branchWS < 0) branchWS = 0;
                C.BranchWS = branchWS;
            }
            
            ImGui.Text($"Stone (Have: {StoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Stone Send", ref stoneWS))
            {
                if (stoneWS < 0) stoneWS = 0;
                C.StoneWS = stoneWS;
            }

            ImGui.Text($"Clam (Have: {ClamAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clam Send", ref clamWS))
            {
                if (clamWS < 0) clamWS = 0;
                C.ClamWS = clamWS;
            }

            ImGui.Text($"Laver (Have: {LaverAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Laver Send", ref laverWS))
            {
                if (laverWS < 0) laverWS = 0;
                C.LaverWS = laverWS;
            }
            
            ImGui.Text($"Coral (Have: {CoralAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coral Send", ref coralWS))
            {
                if (coralWS < 0) coralWS = 0;
                C.CoralWS = coralWS;
            }

            ImGui.Text($"Islewort (Have: {IslewortAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islewort Send", ref islewortWS))
            {
                if (islewortWS < 0) islewortWS = 0;
                C.IslewortWS = islewortWS;
            }

            ImGui.Text($"Sand (Have: {SandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sand Send", ref sandWS))
            {
                if (sandWS < 0) sandWS = 0;
                C.SandWS = sandWS;
            }

            ImGui.Text($"Vine (Have: {VineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Vine Send", ref vineWS))
            {
                if (vineWS < 0) vineWS = 0;
                C.VineWS = vineWS;
            }

            ImGui.Text($"Sap (Have: {SapAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sap Send", ref sapWS))
            {
                if (sapWS < 0) sapWS = 0;
                C.SapWS = sapWS;
            }

            ImGui.Text($"Apple (Have: {AppleAmount})");
            ImGui.SameLine(); 
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Apple Send", ref appleWS))
            {
                if (appleWS < 0) appleWS = 0;
                C.AppleWS = appleWS;
            }

            ImGui.Text($"Log (Have: {LogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Log Send", ref logWS))
            {
                if (logWS < 0) logWS = 0;
                C.LogWS = logWS;
            }
            
            ImGui.Text($"Palm Log (Have: {PalmLogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Log Send", ref palmlogWS))
            {
                if (palmlogWS < 0) palmlogWS = 0;
                C.PalmLogWS = palmlogWS;
            }

            ImGui.Text($"Copper (Have: {CopperAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Copper Send", ref copperWS))
            {
                if (copperWS < 0) copperWS = 0;
                C.CopperWS = copperWS;
            }

            ImGui.Text($"Limestone (Have: {LimestoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Limestone Send", ref limestoneWS))
            {
                if (limestoneWS < 0) limestoneWS = 0;
                C.LimestoneWS = limestoneWS;
            }

            ImGui.Text($"Rock Salt (Have: {RockSaltAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Rock Salt Send", ref rocksaltWS))
            {
                if (rocksaltWS < 0) rocksaltWS = 0;
                C.RockSaltWS = rocksaltWS;
            }

            ImGui.Text($"Clay (Have: {ClayAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clay Send", ref clayWS))
            {
                if (clayWS < 0) clayWS = 0;
                C.ClayWS = clayWS;
            }

            ImGui.Text($"Tinsand (Have: {TinsandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Tinsand Send", ref tinsandWS))
            {
                if (tinsandWS < 0) tinsandWS = 0;
                C.TinsandWS = tinsandWS;
            }

            ImGui.Text($"Sugarcane (Have: {SugarcaneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sugarcane Send", ref sugarcaneWS))
            {
                if (sugarcaneWS < 0) sugarcaneWS = 0;
                C.SugarcaneWS = sugarcaneWS;
            }

            ImGui.Text($"Cotton (Have: {CottonAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Cotton Send", ref cottonWS))
            {
                if (cottonWS < 0) cottonWS = 0;
                C.CottonWS = cottonWS;
            }

            ImGui.Text($"Hemp (Have: {HempAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hemp Send", ref hempWS))
            {
                if (hempWS < 0) hempWS = 0;
                C.HempWS = hempWS;
            }

            ImGui.Text($"Islefish (Have: {IslefishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islefish Send", ref islefishWS))
            {
                if (islefishWS < 0) islefishWS = 0;
                C.IslefishWS = islefishWS;
            }

            ImGui.Text($"Squid (Have: {SquidAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Squid Send", ref squidWS))
            {
                if (squidWS < 0) squidWS = 0;
                C.SquidWS = squidWS;
            }

            ImGui.Text($"Jellyfish (Have: {JellyfishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Jellyfish Send", ref jellyfishWS))
            {
                if (jellyfishWS < 0) jellyfishWS = 0;
                C.JellyfishWS = jellyfishWS;
            }

            ImGui.Text($"Iron Ore (Have: {IronOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Iron Ore Send", ref ironoreWS))
            {
                if (ironoreWS < 0) ironoreWS = 0;
                C.IronOreWS = ironoreWS;
            }

            ImGui.Text($"Quartz (Have: {QuartzAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Quartz Send", ref quartzWS))
            {
                if (quartzWS < 0) quartzWS = 0;
                C.QuartzWS = quartzWS;
            }

            ImGui.Text($"Leucogranite (Have: {LeucograniteAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Leucogranite Send", ref leucograniteWS))
            {
                if (leucograniteWS < 0) leucograniteWS = 0;
                C.LeucograniteWS = leucograniteWS;
            }

            ImGui.Text($"Multicolored Isleblooms (Have: {MulticoloredIslebloomsAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Multicolored Isleblooms Send", ref multicoloredislebloomsWS))
            {
                if (multicoloredislebloomsWS < 0) multicoloredislebloomsWS = 0;
                C.MulticoloredIslebloomsWS = multicoloredislebloomsWS;
            }

            ImGui.Text($"Resin (Have: {ResinAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Resin Send", ref resinWS))
            {
                if (resinWS < 0) resinWS = 0;
                C.ResinWS = resinWS;
            }

            ImGui.Text($"Coconut (Have: {CoconutAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coconut Send", ref coconutWS))
            {
                if (coconutWS < 0) coconutWS = 0;
                C.CoconutWS = coconutWS;
            }

            ImGui.Text($"Beehive (Have: {BeehiveAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Beehive Send", ref beehiveWS))
            {
                if (beehiveWS < 0) beehiveWS = 0;
                C.BeehiveWS = beehiveWS;
            }

            ImGui.Text($"Wood Opal (Have: {WoodOpalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Wood Opal Send", ref woodopalWS))
            {
                if (woodopalWS < 0) woodopalWS = 0;
                C.WoodOpalWS = woodopalWS;
            }

            ImGui.Text($"Coal (Have: {CoalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coal Send", ref coalWS))
            {
                if (coalWS < 0) coalWS = 0;
                C.CoalWS = coalWS;
            }

            ImGui.Text($"Glimshroom (Have: {GlimshroomAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Glimshroom Send", ref glimshroomWS))
            {
                if (glimshroomWS < 0) glimshroomWS = 0;
                C.GlimshroomWS = glimshroomWS;
            }

            ImGui.Text($"Effervescent Water (Have: {EffervescentWaterAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Effervescent Water Send", ref effervescentwaterWS))
            {
                if (effervescentwaterWS < 0) effervescentwaterWS = 0;
                C.EffervescentWaterWS = effervescentwaterWS;
            }

            ImGui.Text($"Shale (Have: {ShaleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Shale Send", ref shaleWS))
            {
                if (shaleWS < 0) shaleWS = 0;
                C.ShaleWS = shaleWS;
            }

            ImGui.Text($"Marble (Have: {MarbleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Marble Send", ref marbleWS))
            {
                if (marbleWS < 0) marbleWS = 0;
                C.MarbleWS = marbleWS;
            }

            ImGui.Text($"Mythril Ore (Have: {MythrilOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Mythril Ore Send", ref mythriloreWS))
            {
                if (mythriloreWS < 0) mythriloreWS = 0;
                C.MythrilOreWS = mythriloreWS;
            }

            ImGui.Text($"Spectrine (Have: {SpectrineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Spectrine Send", ref spectrineWS))
            {
                if (spectrineWS < 0) spectrineWS = 0;
                C.SpectrineWS = spectrineWS;
            }

            ImGui.Text($"Durium Sand (Have: {DuriumSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Durium Sand Send", ref duriumsandWS))
            {
                if (duriumsandWS < 0) duriumsandWS = 0;
                C.DuriumSandWS = duriumsandWS;
            }

            ImGui.Text($"Yellow Copper Ore (Have: {YellowCopperOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Yellow Copper Ore Send", ref yellowcopperoreWS))
            {
                if (yellowcopperoreWS < 0) yellowcopperoreWS = 0;
                C.YellowCopperOreWS = yellowcopperoreWS;
            }

            ImGui.Text($"Gold Ore (Have: {GoldOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Gold Ore Send", ref goldoreWS))
            {
                if (goldoreWS < 0) goldoreWS = 0;
                C.GoldOreWS = goldoreWS;
            }

            ImGui.Text($"Hawk's Eye Sand (Have: {HawksEyeSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hawk's Eye Sand Send", ref hawkseyesandWS))
            {
                if (hawkseyesandWS < 0) hawkseyesandWS = 0;
                C.HawksEyeSandWS = hawkseyesandWS;
            }

            ImGui.Text($"Crystal Formation (Have: {CrystalFormationAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offset);
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Crystal Formation Send", ref crystalformationWS))
            {
                if (crystalformationWS < 0) crystalformationWS = 0;
                C.CrystalFormationWS = crystalformationWS;
            }
        }
    }
}

