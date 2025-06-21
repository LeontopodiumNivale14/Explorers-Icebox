using ExplorersIcebox.Scheduler;

namespace ExplorersIcebox.Ui.MainWindow;

internal class MainWindow : Window
{
    public MainWindow() :
        base($"Explorer's Icebox {P.GetType().Assembly.GetName().Version} ###Explorer'sIceboxMainWindow")
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

    public void Dispose() { }

    public int selectedRoute = C.routeSelected;

    public override void Draw()
    {
        if (ImGui.DragInt("Selected Route", ref selectedRoute, 1))
        {
            if (C.routeSelected != selectedRoute)
            {
                C.routeSelected = selectedRoute;
                C.Save();
            }
        }
    }
}
