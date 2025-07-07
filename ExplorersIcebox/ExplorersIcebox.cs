using ECommons.Automation.NeoTaskManager;
using ECommons.Configuration;
using ECommons.Logging;
using ExplorersIcebox.Config;
using ExplorersIcebox.IPC;
using ExplorersIcebox.Scheduler;
using ExplorersIcebox.Ui;
using ExplorersIcebox.Ui.MainWindow;
using Pictomancy;

namespace ExplorersIcebox;

public sealed class ExplorersIcebox : IDalamudPlugin
{
    public string Name => "ExplorersIcebox";

    private static GeneralConfig? Config;
    private static GatherRoutes? GatherRoutesConfig;

    // Lazy-loaded static config accessor
    public static GeneralConfig C => Config ??= LoadConfig<GeneralConfig>();
    public static GatherRoutes G => GatherRoutesConfig ??= LoadConfig<GatherRoutes>();

    private static T LoadConfig<T>() where T : IYamlConfig, new()
    {
        var path = typeof(T).GetProperty("ConfigPath")!.GetValue(null)!.ToString()!;
        var config = YamlConfig.Load<T>(path);

        if (config == null)
        {
            PluginLog.Warning($"[{typeof(T).Name}] Config was null. Creating new default.");
            config = new T();
            YamlConfig.Save(config, path);
        }

        PluginLog.Information($"[{typeof(T).Name}] Loaded from {path}");
        return config;
    }


    internal static ExplorersIcebox P = null!;

    // Window Systems for the plugin (nice and neatly)
    internal WindowSystem windowSystem;
    internal MainWindow mainWindow;
    internal DebugWindow debugWindow;

    // Taskmanager from Ecommons (bless)
    internal TaskManager taskManager;

    // Internal IPC's from other plugins
    internal LifestreamIPC lifestream;
    internal NavmeshIPC navmesh;

    public ExplorersIcebox(IDalamudPluginInterface pi)
    {
        P = this;
        ECommonsMain.Init(pi, P, ECommons.Module.DalamudReflector, ECommons.Module.ObjectFunctions, Module.SplatoonAPI);

        PictoService.Initialize(pi);

        //IPC's that are used
        taskManager = new();
        lifestream = new();
        navmesh = new();

        // all the windows
        windowSystem = new();
        mainWindow = new();
        debugWindow = new();

        Svc.PluginInterface.UiBuilder.Draw += windowSystem.Draw;
        Svc.PluginInterface.UiBuilder.OpenMainUi += () =>
        {
            mainWindow.IsOpen = true;
        };
        Svc.PluginInterface.UiBuilder.OpenConfigUi += () =>
        {
            
        };
        EzCmd.Add("/explorersicebox", OnCommand, """
            Open plugin interface
            /icebox - alias for /explorersicebox
            /explorersicebox s|settings - Opens the workshop menu
            """);
        EzCmd.Add("/icebox", OnCommand);

        taskManager = new(new(abortOnTimeout: true, timeLimitMS: 20000, showDebug: true));

        Init();
    }

    public void Init()
    {
        
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
        Safe(() => Svc.PluginInterface.UiBuilder.Draw -= windowSystem.Draw);
        ECommonsMain.Dispose();
        PictoService.Dispose();
    }

    private void OnCommand(string command, string args)
    {
        if (args.EqualsIgnoreCaseAny("d", "debug"))
        {
            debugWindow.IsOpen = !debugWindow.IsOpen;
        }
        else if (args.EqualsIgnoreCaseAny("s", "settings"))
        {
            
        }
        else
        {
            mainWindow.IsOpen = !mainWindow.IsOpen;
        }
    }
}
