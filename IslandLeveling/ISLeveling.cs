using System.IO;
using ECommons.Automation.NeoTaskManager;
using ECommons.Configuration;
using ECommons.SimpleGui;
using IslandLeveling.IPC;
using IslandLeveling.Scheduler;
using IslandLeveling.Windows;

namespace IslandLeveling;

public sealed class ISLeveling : IDalamudPlugin
{
    private const string Command = "/pIslandLevel";
    private static string[] Aliases => ["/pil"];

    internal static ISLeveling P = null!;
    private readonly Config config;

    public static Config C => P.config;

    internal TaskManager taskManager;
    internal LifestreamIPC lifestream;
    internal NavmeshIPC navmesh;
    internal VislandIPC visland;

    public ISLeveling(IDalamudPluginInterface pluginInterface)
    {
        P = this;
        ECommonsMain.Init(pluginInterface, P, ECommons.Module.DalamudReflector, ECommons.Module.ObjectFunctions);
        config = EzConfig.Init<Config>();


        EzConfigGui.Init(new MainWindow().Draw);
        EzConfigGui.WindowSystem.AddWindow(new SettingMenu());
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
        if (args.StartsWith("s"))
            EzConfigGui.WindowSystem.Windows.First(w => w is SettingMenu).IsOpen ^= true;
        else
            EzConfigGui.Window.IsOpen = !EzConfigGui.Window.IsOpen;
    }
}
