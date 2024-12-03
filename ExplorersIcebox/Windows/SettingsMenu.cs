using Dalamud.Interface.Utility.Raii;
using ECommons.Configuration;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.Havok.Common.Base.Container.String;
using System.Runtime.CompilerServices;

namespace ExplorersIcebox.Windows
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

        private string[] options = { "All Items", "RouteGround", "RouteFly" }; // Dropdown options
        private string currentOption = "All Items"; // Currently selected option

        public override void Draw()
        {
            // Display dropdown menu
            if (ImGui.BeginCombo("##Dropdown", currentOption))
            {
                foreach (var option in options)
                {
                    // If this option is selected
                    if (ImGui.Selectable(option, option == currentOption))
                    {
                        currentOption = option;
                    }

                    // Set focus to the selected item for better UX
                    if (option == currentOption)
                    {
                        ImGui.SetItemDefaultFocus();
                    }
                }

                ImGui.EndCombo();
            }

            // Render content based on selected option
            switch (currentOption)
            {
                case "All Items":
                    RenderAllItems();
                    break;
                case "RouteGround":
                    RenderRouteGround();
                    break;
                case "RouteFly":
                    RenderRouteFly();
                    break;
            }
        }

        static int AmountSet(int input)
        {
            if (input < 0) input = 0;
            else if (input > 999) input = 999;
            EzConfig.Save();
            UpdateTableDict();
            return input;
        }

        private void RenderAllItems()
        {
            ImGui.Text("Displaying all items.");
            // Add code to display "All Items" content

            PalmLeafImgui();
            BranchImgui();
            StoneImgui();
            ClamImgui();
            LaverImgui();
            CoralImgui();
            IslewortImgui();
            SandImgui();
            VineImgui();
            SapImgui();
            AppleImgui();
            LogImgui();
            PalmLogImgui();
            CopperImgui();
            LimestoneImgui();
            RockSaltImgui();
            ClayImgui();
            TinsandImgui();
            SugarcaneImgui();
            CottonImgui();
            HempImgui();
            IslefishImgui();
            SquidImgui();
            JellyfishImgui();
            IronOreImgui();
            QuartzImgui();
            LeucograniteImgui();
            MulticoloredIslebloomsImgui();
            ResinImgui();
            CoconutImgui();
            BeehiveImgui();
            WoodOpalImgui();
            CoalImgui();
            GlimshroomImgui();
            EffervescentWaterImgui();
            ShaleImgui();
            MarbleImgui();
            MythrilOreImgui();
            SpectrineImgui();
            DuriumSandImgui();
            YellowCopperOreImgui();
            GoldOreImgui();
            HawksEyeSandImgui();
            CrystalFormationImgui();
        }

        private void RenderRouteGround()
        {
            ImGui.Text("Displaying Ground XP Route Items.");
            ImGui.Text($"Current maximum loop amount (Ground Route): {Route8Amount}");
            ClayImgui();
            TinsandImgui();
            MarbleImgui();
            LimestoneImgui();
            BranchImgui();
            LogImgui();
            ResinImgui();
            SandImgui();
        }

        private void RenderRouteFly()
        {
            ImGui.Text("Displaying RouteFly items.");
            ImGui.Text($"Current maximum loop amount (Fly Route): {Route19Amount}");
            // Add code to display "RouteFly" content
            ImGui.NewLine();
            QuartzImgui();
            IronOreImgui();
            DuriumSandImgui();
            LeucograniteImgui();
            StoneImgui();
        }

        private float offSet()
        {
            float windowWidth = ImGui.GetWindowContentRegionMax().X; // Get the usable width of the window
            float inputWidth = 100.0f; // Desired width of the input field
            float offset = windowWidth - inputWidth; // Calculate position to hug the right wall
            return offset;
        }

        private void PalmLeafImgui()
        {
            ImGui.Text($"Palm Leaf (Have: {PalmLeafAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Leaf Send", ref C.PalmLeafWorkshop))
            {
                C.PalmLeafWorkshop = AmountSet(C.PalmLeafWorkshop);
                IslandSancDictionary[PalmLeafID].Workshop = C.PalmLeafWorkshop;
            }
        }

        private void BranchImgui()
        {
            ImGui.Text($"Branch (Have: {BranchAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Branch Send", ref C.BranchWorkshop))
            {
                C.BranchWorkshop = AmountSet(C.BranchWorkshop);
                IslandSancDictionary[BranchID].Workshop = C.BranchWorkshop;
            }
        }

        private void StoneImgui()
        {
            ImGui.Text($"Stone (Have: {StoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Stone Send", ref C.StoneWorkshop))
            {
                C.StoneWorkshop = AmountSet(C.StoneWorkshop);
                IslandSancDictionary[StoneID].Workshop = C.StoneWorkshop;
            }
        }

        private void ClamImgui()
        {
            ImGui.Text($"Clam (Have: {ClamAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clam Send", ref C.ClamWorkshop))
            {
                C.ClamWorkshop = AmountSet(C.ClamWorkshop);
                IslandSancDictionary[ClamID].Workshop = C.ClamWorkshop;
            }
        }

        private void LaverImgui()
        {
            ImGui.Text($"Laver (Have: {LaverAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Laver Send", ref C.LaverWorkshop))
            {
                C.LaverWorkshop = AmountSet(C.LaverWorkshop);
                IslandSancDictionary[LaverID].Workshop= C.LaverWorkshop;
            }
        }

        private void CoralImgui()
        {
            ImGui.Text($"Coral (Have: {CoralAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coral Send", ref C.CoralWorkshop))
            {
                C.CoralWorkshop = AmountSet(C.CoralWorkshop);
                IslandSancDictionary[CoralID].Workshop =(C.CoralWorkshop);
            }
        }

        private void IslewortImgui()
        {
            ImGui.Text($"Islewort (Have: {IslewortAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islewort Send", ref C.IslewortWorkshop))
            {
                C.IslewortWorkshop = AmountSet(C.IslewortWorkshop);
                IslandSancDictionary[IslewortID].Workshop = C.IslewortWorkshop;
            }
        }

        private void SandImgui()
        {
            ImGui.Text($"Sand (Have: {SandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sand Send", ref C.SandWorkshop))
            {
                C.SandWorkshop = AmountSet(C.SandWorkshop);
                IslandSancDictionary[SandID].Workshop=(C.SandWorkshop);
            }
        }

        private void VineImgui()
        {
            ImGui.Text($"Vine (Have: {VineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Vine Send", ref C.VineWorkshop))
            {
                C.VineWorkshop = AmountSet(C.VineWorkshop);
                IslandSancDictionary[VineID].Workshop =(C.VineWorkshop);
            }
        }

        private void SapImgui()
        {
            ImGui.Text($"Sap (Have: {SapAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sap Send", ref C.SapWorkshop))
            {
                C.SapWorkshop = AmountSet(C.SapWorkshop);
                IslandSancDictionary[SapID].Workshop = (C.SapWorkshop);
            }
        }

        private void AppleImgui()
        {
            ImGui.Text($"Apple (Have: {AppleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Apple Send", ref C.AppleWorkshop))
            {
                C.AppleWorkshop = AmountSet(C.AppleWorkshop);
                IslandSancDictionary[AppleID].Workshop = (C.AppleWorkshop);
            }
        }

        private void LogImgui()
        {
            ImGui.Text($"Log (Have: {LogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Log Send", ref C.LogWorkshop))
            {
                C.LogWorkshop = AmountSet(C.LogWorkshop);
                IslandSancDictionary[LogID].Workshop= (C.LogWorkshop);
            }
        }

        private void PalmLogImgui()
        {
            ImGui.Text($"Palm Log (Have: {PalmLogAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Palm Log Send", ref C.PalmLogWorkshop))
            {
                C.PalmLogWorkshop = AmountSet(C.PalmLogWorkshop);
                IslandSancDictionary[LogID].Workshop=(C.PalmLogWorkshop);
            }
        }

        private void CopperImgui()
        {
            ImGui.Text($"Copper (Have: {CopperAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Copper Send", ref C.CopperWorkshop))
            {
                C.CopperWorkshop = AmountSet(C.CopperWorkshop);
                IslandSancDictionary[CopperID].Workshop =(C.CopperWorkshop);
            }
        }

        private void LimestoneImgui()
        {
            ImGui.Text($"Limestone (Have: {LimestoneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Limestone Send", ref C.LimestoneWorkshop))
            {
                C.LimestoneWorkshop = AmountSet(C.LimestoneWorkshop);
                IslandSancDictionary[LimestoneID].Workshop = (C.LimestoneWorkshop);
            }
        }

        private void RockSaltImgui()
        {
            ImGui.Text($"Rock Salt (Have: {RockSaltAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Rock Salt Send", ref C.RockSaltWorkshop))
            {
                C.RockSaltWorkshop = AmountSet(C.RockSaltWorkshop);
                IslandSancDictionary[RockSaltID].Workshop= (C.RockSaltWorkshop);
            }
        }

        private void ClayImgui()
        {
            ImGui.Text($"Clay (Have: {ClayAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Clay Send", ref C.ClayWorkshop))
            {
                C.ClayWorkshop = AmountSet(C.ClayWorkshop);
                IslandSancDictionary[ClayID].Workshop =(C.ClayWorkshop);
            }
        }

        private void TinsandImgui()
        {
            ImGui.Text($"Tinsand (Have: {TinsandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Tinsand Send", ref C.TinsandWorkshop))
            {
                C.TinsandWorkshop = AmountSet(C.TinsandWorkshop);
                IslandSancDictionary[TinsandID].Workshop = (C.TinsandWorkshop);
            }
        }

        private void SugarcaneImgui()
        {
            ImGui.Text($"Sugarcane (Have: {SugarcaneAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Sugarcane Send", ref C.SugarcaneWorkshop))
            {
                C.SugarcaneWorkshop = AmountSet(C.SugarcaneWorkshop);
                IslandSancDictionary[SugarcaneID].Workshop = C.SugarcaneWorkshop;
            }
        }

        private void CottonImgui()
        {
            ImGui.Text($"Cotton (Have: {CottonAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Cotton Send", ref C.CottonWorkshop))
            {
                C.CottonWorkshop = AmountSet(C.CottonWorkshop);
                IslandSancDictionary[CottonID].Workshop= C.CottonWorkshop;
            }
        }

        private void HempImgui()
        {
            ImGui.Text($"Hemp (Have: {HempAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hemp Send", ref C.HempWorkshop))
            {
                C.HempWorkshop = AmountSet(C.HempWorkshop);
                IslandSancDictionary[HempID].Workshop = C.HempWorkshop;
            }
        }

        private void IslefishImgui()
        {
            ImGui.Text($"Islefish (Have: {IslefishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Islefish Send", ref C.IslefishWorkshop))
            {
                C.IslefishWorkshop = AmountSet(C.IslefishWorkshop);
                IslandSancDictionary[IslefishID].Workshop = C.IslefishWorkshop;
            }
        }

        private void SquidImgui()
        {
            ImGui.Text($"Squid (Have: {SquidAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Squid Send", ref C.SquidWorkshop))
            {
                C.SquidWorkshop = AmountSet(C.SquidWorkshop);
                IslandSancDictionary[SquidID].Workshop= C.SquidWorkshop;
            }
        }

        private void JellyfishImgui()
        {
            ImGui.Text($"Jellyfish (Have: {JellyfishAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Jellyfish Send", ref C.JellyfishWorkshop))
            {
                C.JellyfishWorkshop = AmountSet(C.JellyfishWorkshop);
                IslandSancDictionary[SquidID].Workshop = C.JellyfishWorkshop;
            }
        }

        private void IronOreImgui()
        {
            ImGui.Text($"IronOre (Have: {IronOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##IronOre Send", ref C.IronOreWorkshop))
            {
                C.IronOreWorkshop = AmountSet(C.IronOreWorkshop);
                IslandSancDictionary[IronOreID].Workshop = C.IronOreWorkshop;
            }
        }

        private void QuartzImgui()
        {
            ImGui.Text($"Quartz (Have: {QuartzAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Quartz Send", ref C.QuartzWorkshop))
            {
                C.QuartzWorkshop = AmountSet(C.QuartzWorkshop);
                IslandSancDictionary[QuartzID].Workshop = C.QuartzWorkshop;
            }
        }

        private void LeucograniteImgui()
        {
            ImGui.Text($"Leucogranite (Have: {LeucograniteAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Leucogranite Send", ref C.LeucograniteWorkshop))
            {
                C.LeucograniteWorkshop = AmountSet(C.LeucograniteWorkshop);
                IslandSancDictionary[LeucograniteID].Workshop = C.LeucograniteWorkshop;
            }
        }

        private void MulticoloredIslebloomsImgui()
        {
            ImGui.Text($"Multicolored Isleblooms (Have: {MulticoloredIslebloomsAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Multicolored Isleblooms Send", ref C.MulticoloredIslebloomsWorkshop))
            {
                C.MulticoloredIslebloomsWorkshop = AmountSet(C.MulticoloredIslebloomsWorkshop);
                IslandSancDictionary[MulticoloredIslebloomsID].Workshop = C.MulticoloredIslebloomsWorkshop;
            }
        }

        private void ResinImgui()
        {
            ImGui.Text($"Resin (Have: {ResinAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Resin Send", ref C.ResinWorkshop))
            {
                C.ResinWorkshop = AmountSet(C.ResinWorkshop);
                IslandSancDictionary[ResinID].Workshop = C.ResinWorkshop;
            }
        }

        private void CoconutImgui()
        {
            ImGui.Text($"Coconut (Have: {CoconutAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coconut Send", ref C.CoconutWorkshop))
            {
                C.CoconutWorkshop = AmountSet(C.CoconutWorkshop);
                IslandSancDictionary[CoconutID].Workshop= C.CoconutWorkshop;
            }
        }

        private void BeehiveImgui()
        {
            ImGui.Text($"Beehive (Have: {BeehiveAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Beehive Send", ref C.BeehiveWorkshop))
            {
                C.BeehiveWorkshop = AmountSet(C.BeehiveWorkshop);
                IslandSancDictionary[BeehiveID].Workshop = C.BeehiveWorkshop;
            }
        }

        private void WoodOpalImgui()
        {
            ImGui.Text($"Wood Opal (Have: {WoodOpalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Wood Opal Send", ref C.WoodOpalWorkshop))
            {
                C.WoodOpalWorkshop = AmountSet(C.WoodOpalWorkshop);
                IslandSancDictionary[WoodOpalID].Workshop = C.WoodOpalWorkshop;
            }
        }

        private void CoalImgui()
        {
            ImGui.Text($"Coal (Have: {CoalAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Coal Send", ref C.CoalWorkshop))
            {
                C.CoalWorkshop = AmountSet(C.CoalWorkshop);
                IslandSancDictionary[CoalID].Workshop = C.CoalWorkshop;
            }
        }

        private void GlimshroomImgui()
        {
            ImGui.Text($"Glimshroom (Have: {GlimshroomAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Glimshroom Send", ref C.GlimshroomWorkshop))
            {
                C.GlimshroomWorkshop = AmountSet(C.GlimshroomWorkshop);
                IslandSancDictionary[GlimshroomID].Workshop= C.GlimshroomWorkshop;
            }
        }

        private void EffervescentWaterImgui()
        {
            ImGui.Text($"Effervescent Water (Have: {EffervescentWaterAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Effervescent Water Send", ref C.EffervescentWaterWorkshop))
            {
                C.EffervescentWaterWorkshop = AmountSet(C.EffervescentWaterWorkshop);
                IslandSancDictionary[EffervescentWaterID].Workshop = C.EffervescentWaterWorkshop;
            }
        }

        private void ShaleImgui()
        {
            ImGui.Text($"Shale (Have: {ShaleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Shale Send", ref C.ShaleWorkshop))
            {
                C.ShaleWorkshop = AmountSet(C.ShaleWorkshop);
                IslandSancDictionary[ShaleID].Workshop = C.ShaleWorkshop;
            }
        }

        private void MarbleImgui()
        {
            ImGui.Text($"Marble (Have: {MarbleAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Marble Send", ref C.MarbleWorkshop))
            {
                C.MarbleWorkshop = AmountSet(C.MarbleWorkshop);
                IslandSancDictionary[MarbleID].Workshop = C.MarbleWorkshop;
            }
        }

        private void MythrilOreImgui()
        {
            ImGui.Text($"Mythril Ore (Have: {MythrilOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Mythril Ore Send", ref C.MythrilOreWorkshop))
            {
                C.MythrilOreWorkshop = AmountSet(C.MythrilOreWorkshop);
                IslandSancDictionary[MythrilOreID].Workshop = C.MythrilOreWorkshop;
            }
        }

        private void SpectrineImgui()
        {
            ImGui.Text($"Spectrine (Have: {SpectrineAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Spectrine Send", ref C.SpectrineWorkshop))
            {
                C.SpectrineWorkshop = AmountSet(C.SpectrineWorkshop);
                IslandSancDictionary[SpectrineID].Workshop= C.SpectrineWorkshop;
            }
        }

        private void DuriumSandImgui()
        {
            ImGui.Text($"Durium Sand (Have: {DuriumSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Durium Sand Send", ref C.DuriumSandWorkshop))
            {
                C.DuriumSandWorkshop = AmountSet(C.DuriumSandWorkshop);
                IslandSancDictionary[DuriumSandID].Workshop = C.DuriumSandWorkshop;
            }
        }

        private void YellowCopperOreImgui()
        {
            ImGui.Text($"Yellow Copper Ore (Have: {YellowCopperOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Yellow Copper Ore Send", ref C.YellowCopperOreWorkshop))
            {
                C.YellowCopperOreWorkshop = AmountSet(C.YellowCopperOreWorkshop);
                IslandSancDictionary[YellowCopperOreID].Workshop = C.YellowCopperOreWorkshop;
            }
        }

        private void GoldOreImgui()
        {
            ImGui.Text($"Gold Ore (Have: {GoldOreAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Gold Ore Send", ref C.GoldOreWorkshop))
            {
                C.GoldOreWorkshop = AmountSet(C.GoldOreWorkshop);
                IslandSancDictionary[GoldOreID].Workshop= C.GoldOreWorkshop;
            }
        }

        private void HawksEyeSandImgui()
        {
            ImGui.Text($"Hawks Eye Sand (Have: {HawksEyeSandAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Hawks Eye Sand Send", ref C.HawksEyeSandWorkshop))
            {
                C.HawksEyeSandWorkshop = AmountSet(C.HawksEyeSandWorkshop);
                IslandSancDictionary[HawksEyeSandID].Workshop = C.HawksEyeSandWorkshop;
            }
        }

        private void CrystalFormationImgui()
        {
            ImGui.Text($"Crystal Formation (Have: {CrystalFormationAmount})");
            ImGui.SameLine();
            ImGui.SetCursorPosX(offSet());
            ImGui.SetNextItemWidth(100);
            if (ImGui.InputInt("##Crystal Formation Send", ref C.CrystalFormationWorkshop))
            {
                C.CrystalFormationWorkshop = AmountSet(C.CrystalFormationWorkshop);
                IslandSancDictionary[CrystalFormationID].Workshop = C.CrystalFormationWorkshop;
            }
        }

    }
}

