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
        public static string currentOption = "All Items"; // Currently selected option

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
    }
}

