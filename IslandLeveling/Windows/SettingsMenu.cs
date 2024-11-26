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
            int palmleafSend = C.PalmLeafSend;
            int branchSend = C.BranchSend;
            int stoneSend = C.StoneSend;
            int clamSend = C.ClamSend;
            int laverSend = C.LaverSend;
            int coralSend = C.CoralSend;
            int islewortSend = C.IslewortSend;
            int sandSend = C.SandSend;
            int vineSend = C.VineSend;
            int sapSend = C.SapSend;
            int appleSend = C.AppleSend;
            int logSend = C.LogSend;
            int palmlogSend = C.PalmLogSend;
            int copperSend = C.CopperSend;
            int limestoneSend = C.LimestoneSend;
            int rocksaltSend = C.RockSaltSend;
            int claySend = C.ClaySend;
            int tinsandSend = C.TinsandSend;
            int sugarcaneSend = C.SugarcaneSend;
            int cottonSend = C.CottonSend;
            int hempSend = C.HempSend;
            int islefishSend = C.IslefishSend;
            int squidSend = C.SquidSend;
            int jellyfishSend = C.JellyfishSend;
            int ironoreSend = C.IronOreSend;
            int quartzSend = C.QuartzSend;
            int leucograniteSend = C.LeucograniteSend;
            int multicoloredislebloomsSend = C.MulticoloredIslebloomsSend;
            int resinSend = C.ResinSend;
            int coconutSend = C.CoconutSend;
            int beehiveSend = C.BeehiveSend;
            int woodopalSend = C.WoodOpalSend;
            int coalSend = C.CoalSend;
            int glimshroomSend = C.GlimshroomSend;
            int effervescentwaterSend = C.EffervescentWaterSend;
            int shaleSend = C.ShaleSend;
            int marbleSend = C.MarbleSend;
            int mythriloreSend = C.MythrilOreSend;
            int spectrineSend = C.SpectrineSend;
            int duriumsandSend = C.DuriumSandSend;
            int yellowcopperoreSend = C.YellowCopperOreSend;
            int goldoreSend = C.GoldOreSend;
            int hawkseyesandSend = C.HawksEyeSandSend;
            int crystalformationSend = C.CrystalFormationSend;


            ImGui.PushItemWidth(100);
            ImGui.PopItemWidth();
            ImGui.TextWrapped("Island Sanctuary Items to keep. Please input how many of them you need for workshop");
            ImGui.Separator();
            
            ImGui.Text($"Palm Leaf (Have: {PalmLeafAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Leaf", ref palmleafSend))
            {
                if (palmleafSend < 0) palmleafSend = 0;
                C.PalmLeafSend = palmleafSend;
            }
            ImGui.NewLine();
            
            ImGui.Text($"Branch (Have: {BranchAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Branch Send", ref branchSend))
            {
                if (branchSend < 0) branchSend = 0;
                C.BranchSend = branchSend;
            }
            ImGui.NewLine();
            
            ImGui.Text($"Stone (Have: {StoneAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Stone Send", ref stoneSend))
            {
                if (stoneSend < 0) stoneSend = 0;
                C.StoneSend = stoneSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Clam (Have: {ClamAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clam Send", ref clamSend))
            {
                if (clamSend < 0) clamSend = 0;
                C.ClamSend = clamSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Laver (Have: {LaverAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Laver Send", ref laverSend))
            {
                if (laverSend < 0) laverSend = 0;
                C.LaverSend = laverSend;
            }
            ImGui.NewLine();
            
            ImGui.Text($"Coral (Have: {CoralAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coral Send", ref coralSend))
            {
                if (coralSend < 0) coralSend = 0;
                C.CoralSend = coralSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Islewort (Have: {IslewortAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islewort Send", ref islewortSend))
            {
                if (islewortSend < 0) islewortSend = 0;
                C.IslewortSend = islewortSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Sand (Have: {SandAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sand Send", ref sandSend))
            {
                if (sandSend < 0) sandSend = 0;
                C.SandSend = sandSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Vine (Have: {VineAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Vine Send", ref vineSend))
            {
                if (vineSend < 0) vineSend = 0;
                C.VineSend = vineSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Sap (Have: {SapAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sap Send", ref sapSend))
            {
                if (sapSend < 0) sapSend = 0;
                C.SapSend = sapSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Apple (Have: {AppleAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Apple Send", ref appleSend))
            {
                if (appleSend < 0) appleSend = 0;
                C.AppleSend = appleSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Log (Have: {LogAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Log Send", ref logSend))
            {
                if (logSend < 0) logSend = 0;
                C.LogSend = logSend;
            }
            ImGui.NewLine();
            
            ImGui.Text($"Palm Log (Have: {PalmLogAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Log Send", ref palmlogSend))
            {
                if (palmlogSend < 0) palmlogSend = 0;
                C.PalmLogSend = palmlogSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Copper (Have: {CopperAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Copper Send", ref copperSend))
            {
                if (copperSend < 0) copperSend = 0;
                C.CopperSend = copperSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Limestone (Have: {LimestoneAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Limestone Send", ref limestoneSend))
            {
                if (limestoneSend < 0) limestoneSend = 0;
                C.LimestoneSend = limestoneSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Rock Salt (Have: {RockSaltAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Rock Salt Send", ref rocksaltSend))
            {
                if (rocksaltSend < 0) rocksaltSend = 0;
                C.RockSaltSend = rocksaltSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Clay (Have: {ClayAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clay Send", ref claySend))
            {
                if (claySend < 0) claySend = 0;
                C.ClaySend = claySend;
            }
            ImGui.NewLine();

            ImGui.Text($"Tinsand (Have: {TinsandAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Tinsand Send", ref tinsandSend))
            {
                if (tinsandSend < 0) tinsandSend = 0;
                C.TinsandSend = tinsandSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Sugarcane (Have: {SugarcaneAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sugarcane Send", ref sugarcaneSend))
            {
                if (sugarcaneSend < 0) sugarcaneSend = 0;
                C.SugarcaneSend = sugarcaneSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Cotton (Have: {CottonAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Cotton Send", ref cottonSend))
            {
                if (cottonSend < 0) cottonSend = 0;
                C.CottonSend = cottonSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Hemp (Have: {HempAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hemp Send", ref hempSend))
            {
                if (hempSend < 0) hempSend = 0;
                C.HempSend = hempSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Islefish (Have: {IslefishAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islefish Send", ref islefishSend))
            {
                if (islefishSend < 0) islefishSend = 0;
                C.IslefishSend = islefishSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Squid (Have: {SquidAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Squid Send", ref squidSend))
            {
                if (squidSend < 0) squidSend = 0;
                C.SquidSend = squidSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Jellyfish (Have: {JellyfishAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Jellyfish Send", ref jellyfishSend))
            {
                if (jellyfishSend < 0) jellyfishSend = 0;
                C.JellyfishSend = jellyfishSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Iron Ore (Have: {IronOreAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Iron Ore Send", ref ironoreSend))
            {
                if (ironoreSend < 0) ironoreSend = 0;
                C.IronOreSend = ironoreSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Quartz (Have: {QuartzAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Quartz Send", ref quartzSend))
            {
                if (quartzSend < 0) quartzSend = 0;
                C.QuartzSend = quartzSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Leucogranite (Have: {LeucograniteAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Leucogranite Send", ref leucograniteSend))
            {
                if (leucograniteSend < 0) leucograniteSend = 0;
                C.LeucograniteSend = leucograniteSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Multicolored Isleblooms (Have: {MulticoloredIslebloomsAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Multicolored Isleblooms Send", ref multicoloredislebloomsSend))
            {
                if (multicoloredislebloomsSend < 0) multicoloredislebloomsSend = 0;
                C.MulticoloredIslebloomsSend = multicoloredislebloomsSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Resin (Have: {ResinAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Resin Send", ref resinSend))
            {
                if (resinSend < 0) resinSend = 0;
                C.ResinSend = resinSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Coconut (Have: {CoconutAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coconut Send", ref coconutSend))
            {
                if (coconutSend < 0) coconutSend = 0;
                C.CoconutSend = coconutSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Beehive (Have: {BeehiveAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Beehive Send", ref beehiveSend))
            {
                if (beehiveSend < 0) beehiveSend = 0;
                C.BeehiveSend = beehiveSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Wood Opal (Have: {WoodOpalAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Wood Opal Send", ref woodopalSend))
            {
                if (woodopalSend < 0) woodopalSend = 0;
                C.WoodOpalSend = woodopalSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Coal (Have: {CoalAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coal Send", ref coalSend))
            {
                if (coalSend < 0) coalSend = 0;
                C.CoalSend = coalSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Glimshroom (Have: {GlimshroomAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Glimshroom Send", ref glimshroomSend))
            {
                if (glimshroomSend < 0) glimshroomSend = 0;
                C.GlimshroomSend = glimshroomSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Effervescent Water (Have: {EffervescentWaterAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Effervescent Water Send", ref effervescentwaterSend))
            {
                if (effervescentwaterSend < 0) effervescentwaterSend = 0;
                C.EffervescentWaterSend = effervescentwaterSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Shale (Have: {ShaleAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Shale Send", ref shaleSend))
            {
                if (shaleSend < 0) shaleSend = 0;
                C.ShaleSend = shaleSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Marble (Have: {MarbleAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Marble Send", ref marbleSend))
            {
                if (marbleSend < 0) marbleSend = 0;
                C.MarbleSend = marbleSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Mythril Ore (Have: {MythrilOreAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Mythril Ore Send", ref mythriloreSend))
            {
                if (mythriloreSend < 0) mythriloreSend = 0;
                C.MythrilOreSend = mythriloreSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Spectrine (Have: {SpectrineAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Spectrine Send", ref spectrineSend))
            {
                if (spectrineSend < 0) spectrineSend = 0;
                C.SpectrineSend = spectrineSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Durium Sand (Have: {DuriumSandAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Durium Sand Send", ref duriumsandSend))
            {
                if (duriumsandSend < 0) duriumsandSend = 0;
                C.DuriumSandSend = duriumsandSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Yellow Copper Ore (Have: {YellowCopperOreAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Yellow Copper Ore Send", ref yellowcopperoreSend))
            {
                if (yellowcopperoreSend < 0) yellowcopperoreSend = 0;
                C.YellowCopperOreSend = yellowcopperoreSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Gold Ore (Have: {GoldOreAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Gold Ore Send", ref goldoreSend))
            {
                if (goldoreSend < 0) goldoreSend = 0;
                C.GoldOreSend = goldoreSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Hawk's Eye Sand (Have: {HawksEyeSandAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hawk's Eye Sand Send", ref hawkseyesandSend))
            {
                if (hawkseyesandSend < 0) hawkseyesandSend = 0;
                C.HawksEyeSandSend = hawkseyesandSend;
            }
            ImGui.NewLine();

            ImGui.Text($"Crystal Formation (Have: {CrystalFormationAmount})");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Crystal Formation Send", ref crystalformationSend))
            {
                if (crystalformationSend < 0) crystalformationSend = 0;
                C.CrystalFormationSend = crystalformationSend;
            }
            ImGui.NewLine();
        }
    }
}

