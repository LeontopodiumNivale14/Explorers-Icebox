using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Ui.DebugWindowTabs
{
    internal class MiscInfoDebug
    {

        private static string InputValue = "0"; // The uint value to be edited
        private static ulong Result;

        public static void Draw()
        {
            // Input box
            ImGui.InputText("Enter a number", ref InputValue, 20);

            if (ImGui.Button("Submit"))
            {
                // Try to parse the input to a ulong
                if (ulong.TryParse(InputValue, out Result))
                {
                    ImGui.Text($"Valid input! Parsed ulong: {Result}");
                }
                else
                {
                    ImGui.Text("Invalid input. Please enter a valid number.");
                }
            }

            ImGui.Text($"Current Value: {InputValue}");
        }
    }
}
