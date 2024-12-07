using Dalamud.Interface.Utility.Raii;
using ECommons.Configuration;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
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
        
        // dropdown options
        private string[] options = { "All Items", "Route 1: Islefish | Clam", "Route 2: Islewort", "Route 3: Sugarcane | Vine", "Route 4: Tinsand | Sand",
        "Route 5: Apple | Beehive | Vine", "Route 6: Coconut | Palm Log | Palm leaf", "Route 7: Cotton", "Route 8: Clay | Sand [Ground XP Loop",
        "Route 19: Quartz | Stone [Flying XP Loop]"}; 


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
                case "Route 1: Islefish | Clam":
                    Route1WorkshopGui();
                    break;
                case "Route 2: Islewort":
                    Route2WorkshopGui();
                    break;
                case "Route 3: Sugarcane | Vine":
                    Route3WorkshopGui();
                    break;
                case "Route 4: Tinsand | Sand":
                    Route4WorkshopGui();
                    break;
                case "Route 5: Apple | Beehive | Vine":
                    Route5WorkshopGui();
                    break;
                case "Route 6: Coconut | Palm Log | Palm leaf":
                    Route6WorkshopGui();
                    break;
                case "Route 7: Cotton":
                    Route7WorkshopGui();
                    break;
                case "Route 8: Clay | Sand [Ground XP Loop":
                    Route8WorkshopGui();
                    break;
                case "Route 19: Quartz | Stone [Flying XP Loop]":
                    Route19WorkshopGui();
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
    }
}

