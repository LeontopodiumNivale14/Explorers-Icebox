using Dalamud.Interface.Utility.Raii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandLeveling.Windows
{
    internal class SettingMenu : Window, IDisposable
    {
        public static new readonly string WindowName = "GlobalTurnIn Settings";
        public SettingMenu() : base(WindowName)
        {
            Flags = ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoCollapse;
            ImGui.SetNextWindowSize(new Vector2(450, 0), ImGuiCond.Always);
        }

        public void Dispose() { }


        public override void Draw()
        {
            bool useTicket = C.UseTicket;
            bool maxItem = C.MaxItem;
            bool maxArmory = C.MaxArmory;
            int maxArmoryFreeSlot = C.MaxArmoryFreeSlot;
            bool vendorTurnIn = C.VendorTurnIn;
            bool teleportToFC = C.TeleportToFC;

            ImGui.PushItemWidth(100);
            ImGui.PopItemWidth();
            ImGui.Text("Teleport Settings:");
            ImGui.Separator();

            // UseTicket
            if (ImGui.Checkbox("Use Tickets to Teleport##useticket", ref useTicket))
            {
                C.UseTicket = useTicket;
            }
            if (ImGui.Checkbox("Teleport to FC##teleporttofc", ref teleportToFC))
            {
                C.TeleportToFC = teleportToFC;
            }
            ImGui.NewLine();

            ImGui.Text("Inventory Management:");
            ImGui.Separator();

            // MaxItem
            if (ImGui.Checkbox("Maximize Inventory##maxitem", ref maxItem))
            {
                C.MaxItem = maxItem;
            }
            ImGui.TextWrapped("Maximize inventory by buying one of a single item.");


            using (ImRaii.Disabled(!maxItem))
            {
                if (!maxItem)
                    maxArmory = false;
                if (ImGui.Checkbox("Fill Armory##maxarmory", ref maxArmory))
                {
                    C.MaxArmory = maxArmory;
                }
                if (maxArmory)
                {
                    ImGui.Text("Free Armory Slots:");
                    ImGui.SameLine();
                    ImGui.PushItemWidth(100);
                    if (ImGui.InputInt("##maxarmoryfreeslot", ref maxArmoryFreeSlot))
                    {
                        if (maxArmoryFreeSlot < 0) maxArmoryFreeSlot = 0;
                        C.MaxArmoryFreeSlot = maxArmoryFreeSlot;
                    }
                    ImGui.PopItemWidth();
                }
            }
            ImGui.NewLine();

            ImGui.Text("Turn-in Settings:");
            ImGui.Separator();

            // VendorTurnIn
            if (ImGui.Checkbox("Vendor Turn-in##vendorturnin", ref vendorTurnIn))
            {
                C.VendorTurnIn = vendorTurnIn;
            }
            ImGui.TextWrapped("Stay off the marketboard and sell to your retainer.");
        }
    }
}

