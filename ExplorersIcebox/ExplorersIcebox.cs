using System.ComponentModel.Design;
using System.IO;
using ECommons.Automation.NeoTaskManager;
using ECommons.Configuration;
using ECommons.Reflection;
using ECommons.SimpleGui;
using ExplorersIcebox.IPC;
using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Windows;

namespace ExplorersIcebox;

public sealed class ExplorersIcebox : IDalamudPlugin
{
    private const string Command = "/explorersicebox";
    private static string[] Aliases => ["/picebox", "/icebox"];

    internal static ExplorersIcebox P = null!;
    private readonly Config config;

    public static Config C => P.config;

    internal TaskManager taskManager;
    internal LifestreamIPC lifestream;
    internal NavmeshIPC navmesh;
    internal VislandIPC visland;

    public ExplorersIcebox(IDalamudPluginInterface pluginInterface)
    {
        P = this;
        ECommonsMain.Init(pluginInterface, P, ECommons.Module.DalamudReflector, ECommons.Module.ObjectFunctions);
        config = EzConfig.Init<Config>();

        EzConfigGui.Init(new MainWindow().Draw);
        MainWindow.SetWindowProperties();
        EzConfigGui.WindowSystem.AddWindow(new SettingMenu());
        EzConfigGui.WindowSystem.AddWindow(new DebugWindow());
        EzCmd.Add(Command, OnCommand, "Open Interface");
        Aliases.ToList().ForEach(a => EzCmd.Add(a, OnCommand, $"{Command} Alias"));

        taskManager = new();
        lifestream = new();
        navmesh = new();
        visland = new();
        Svc.Framework.Update += Tick;
    }
    private void Tick(object _)
    {
        if (SchedulerMain.AreWeTicking && Svc.ClientState.LocalPlayer != null)
        {
            SchedulerMain.Tick();
        }
    }
    public void Dispose()
    {
        Safe(() => Svc.Framework.Update -= Tick);
        ECommonsMain.Dispose();
    }
    private void OnCommand(string command, string args)
    {
        if (args == "debug")
        {
            EzConfigGui.WindowSystem.Windows.FirstOrDefault(w => w.WindowName == DebugWindow.WindowName)!.IsOpen ^= true;
        }
        else if (args.StartsWith("s"))
            EzConfigGui.WindowSystem.Windows.First(w => w is SettingMenu).IsOpen ^= true;
        else
            EzConfigGui.Window.IsOpen = !EzConfigGui.Window.IsOpen;
    }
}
