using ExplorersIcebox.Scheduler;

namespace ExplorersIcebox.Ui.MainWindow;

internal class MainWindow : Window
{
    public MainWindow() :
        base($"Explorer's Icebox {P.GetType().Assembly.GetName().Version}")
    {
        Flags = ImGuiWindowFlags.None;
        SizeConstraints = new()
        {
            MinimumSize = new Vector2(300, 300),
            MaximumSize = new Vector2(2000, 2000)
        };
        P.windowSystem.AddWindow(this);
        AllowPinning = false;
    }

    private const uint SidebarWidth = 275;
    public void Dispose() { }

    public static string currentlyDoing = SchedulerMain.CurrentProcess;
    private bool copyButton = false;

    public override void Draw()
    {
        if (IPC.NavmeshIPC.Installed && IPC.VislandIPC.Installed)
        {
            ImGuiEx.EzTabBar("EIB tabbar",
                            ("XPGrind/Item Gathering", GrindModeUi.GrindModeUi.Draw, null, true),
                            ("Help", HelpUi.Draw, null, true),
                            ("Version Notes", VersionNotesUi.Draw, null, true)
                            );
        }
        else if (IPC.NavmeshIPC.Installed && !IPC.VislandIPC.Installed)
        {
            ImGui.TextWrapped("You seem to be missing Visland. This is required to be installed");
            ImGui.Text("You can grab it by pressing the button here to copy the clipboard");
            if (ImGui.Button(copyButton ? "Copied Successfully" : "Copy Visland Link"))
            {
                ImGui.SetClipboardText("https://puni.sh/api/repository/veyn");
                copyButton = true;
            }

        }
        else if (!IPC.NavmeshIPC.Installed && IPC.VislandIPC.Installed)
        {
            ImGui.TextWrapped("You seem to be missing VNavmesh. This is required to be installed");
            ImGui.Text("You can grab it by pressing the button here to copy the clipboard");
            if (ImGui.Button(copyButton ? "Copied Successfully" : "Copy Navmesh Link"))
            {
                ImGui.SetClipboardText("https://puni.sh/api/repository/veyn");
                copyButton = true;
            }
        }
        else
        {
            ImGui.TextWrapped("You seem to be missing VNavmesh AND Visland. This is required to be installed");
            ImGui.Text("You can grab it by pressing the button here to copy the clipboard");
            if (ImGui.Button(copyButton ? "Copied Successfully" : "Copy Visland AND Navmesh Link"))
            {
                ImGui.SetClipboardText("https://puni.sh/api/repository/veyn");
                copyButton = true;
            }
        }

    }
}
