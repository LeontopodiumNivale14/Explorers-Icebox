using ExplorersIcebox.Scheduler.Tasks;
using System.IO;

namespace ExplorersIcebox.Windows
{
    internal class DebugWindow : Window, IDisposable
    {
        public new static readonly string WindowName = "Debug";
        public DebugWindow() : base(WindowName)
        {
            Flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse | ImGuiWindowFlags.NoCollapse;
            SizeConstraints = new WindowSizeConstraints
            {
                MinimumSize = new Vector2(100, 100),
                MaximumSize = new Vector2(800, 1200)
            };
        }

        public void Dispose() { }

        // variables that hold the "ref"s for ImGui
        private string addonName = "default";
        private float xPos = 0;
        private float yPos = 0;
        private float zPos = 0;
        private int tolerance = 0;

        private bool callbackbool = false;
        private string testRoute = "";
        private int maxLoops = (int)Math.Floor((double) 999 / 6);
        private int workshopKeepLoop => (int)Math.Ceiling((double)C.QuartzWorkshop / 6);
        private int newLoopTotal => ((int)Math.Floor((double)999 / 6) - (int)Math.Ceiling((double)C.QuartzWorkshop / 6));
        private int quartzGather => (newLoopTotal * 6);
        private int newLoopAmount => CalculateRouteLoopAmount(C.QuartzWorkshop, 6);
        private int inputbox = 0;
        private ushort itemID = 0;


        public override void Draw()
        {
            if (ImGui.BeginTabBar("Test Tab Bar"))
            {
                if (ImGui.BeginTabItem("Player Info"))
                {
                    PlayerInfoDubug();
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Test Tab"))
                {
                    NavmeshInfoDebug();
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Misc Info"))
                {
                    MiscInfoDebug();
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Route Sell"))
                {
                    RouteSellDebug();
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Imgui Test"))
                {
                    TestGuiDebug();
                    DisplayItemData();
                    ImGui.EndTabItem();
                }
                ImGui.EndTabBar();
            }
        }

        private void PlayerInfoDubug()
        {
            ImGui.Text($"General Information");
            ImGui.Text($"TerritoryID: " + Svc.ClientState.TerritoryType);
            ImGui.Text($"Target: " + Svc.Targets.Target);
            ImGui.InputText("##Addon Visible", ref addonName, 100);
            ImGui.SameLine();
            ImGui.Text($"Addon Visible: " + IsAddonActive(addonName));
            ImGui.Text($"Navmesh information");
            ImGui.Text($"PlayerPos: " + PlayerPosition());
            ImGui.Text($"Navmesh BuildProgress :" + P.navmesh.BuildProgress());//working ipc
        }

        private void NavmeshInfoDebug()
        {
            ImGui.Text("X:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(75);
            if (ImGui.InputFloat("##X Position", ref xPos))
            {
                xPos = (float)Math.Round(xPos, 2);
            }
            ImGui.SameLine();
            ImGui.Text("Y:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(75);
            if (ImGui.InputFloat("##Y Position", ref yPos))
            {
                yPos = (float)Math.Round(yPos, 2);
            }
            ImGui.SameLine();
            ImGui.Text("Z:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(75);
            if (ImGui.InputFloat("##Z Position", ref zPos))
            {
                zPos = (float)Math.Round(zPos, 2);
            }
            ImGui.SameLine();
            ImGui.Text("Tolerance:");
            ImGui.SameLine();
            ImGui.SetNextItemWidth(100);
            ImGui.InputInt("##Tolerance", ref tolerance);
            if (ImGui.Button("Set to Current"))
            {
                xPos = (float)Math.Round(GetPlayerRawXPos(), 2);
                yPos = (float)Math.Round(GetPlayerRawYPos(), 2);
                zPos = (float)Math.Round(GetPlayerRawZPos(), 2);
            }
            ImGui.SameLine();
            if (ImGui.Button("Copy to clipboard"))
            {
                string clipboardText = $"{xPos}f, {yPos}f, {zPos}f";
                ImGui.SetClipboardText(clipboardText);
            }
            if (ImGui.Button("Vnav Moveto!"))
            {
                P.taskManager.Enqueue(() => TaskMoveTo.Enqueue(new Vector3(xPos, yPos, zPos), "Interact string", false, tolerance));
                ECommons.Logging.InternalLog.Information("Firing off Vnav Moveto");
            }
        }

        private void RouteSellDebug()
        {
            ImGui.Text("This is where the route sell debug would be... IF I HAD ONE");
        }

        private void MiscInfoDebug()
        {
            ImGui.Text("Callback Test");
            // Standard checkbox for a boolean variable
            ImGui.Checkbox("1st Item | 2nd Item", ref callbackbool);
            if (ImGui.Button("Addon Fire Test"))
            {
                if (callbackbool)
                {
                    TaskCallback.Enqueue("MJIDisposeShop", true, 12, 0);
                }
                else if (callbackbool == false)
                {
                    TaskCallback.Enqueue("MJIDisposeShop", true, 12, 1);
                }
            }
            ImGui.InputText("Route Base64", ref testRoute, 2000);
            if (ImGui.Button("Visland Test"))
            {
                TaskVislandTemp.Enqueue(testRoute, "Test Base64 Route");
            }
            ImGui.Text($"Max loops = {maxLoops}");
            ImGui.Text($"Loops to take off = {workshopKeepLoop}");
            ImGui.Text($"New total loops = {newLoopTotal}");
            ImGui.Text($"Quartz gatherabled amount = {quartzGather}");
            ImGui.Text($"Quartz sell = {currentTable[0].Sell}");
            if (ImGui.Button("Calculate sell"))
            {
                TableSellUpdate(currentTable);
            }
            ImGui.Text($"New Calculated loop amount = {newLoopAmount}");
        }
    
        private void TestGuiDebug()
        {
            bool unlocked = CheckIfItemLocked(itemID);
            ImGui.Text("Kinda where I just test all the gui things to see what they look like");
            ImGui.Text("Tree Nodes");
            if (ImGui.TreeNode("Settings")) // Example of treenode, note that these must end in TreePop();
            {
                ImGui.Text("Option 1");
                ImGui.Text("Option 2");
                if (ImGui.TreeNode("Example of a tree in a tree"))
                {
                    ImGui.Text("Surprise tree");
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
            ImGui.Text($"Item {itemID} is {unlocked}");
            if (ImGui.InputInt("##ItemIDforText", ref inputbox))
            {
                inputbox = Math.Clamp(inputbox, ushort.MinValue, ushort.MaxValue);
                itemID = (ushort)inputbox;
            }
            if (ImGui.Button("Update Callback"))
            {
                TaskUpdateShopID.Enqueue();
            }
        }

        public static void DisplayItemData()
        {
            // Iterate over the dictionary
            foreach (var entry in IslandSancDictionary)
            {
                // Extract the key (Item ID) and value (ItemData)
                var itemId = entry.Key;
                ItemData itemData = entry.Value;

                // Format the display text
                string displayText = $"Item ID: {itemId}, Callback: {itemData.Callback}";

                // Display the text using ImGui
                ImGui.Text(displayText);
            }
        }
    }
}
