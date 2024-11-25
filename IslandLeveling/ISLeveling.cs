using System.IO;
using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using ECommons.Automation.NeoTaskManager;
using ECommons.Configuration;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using IslandLeveling.Scheduler;
using SamplePlugin;
using SamplePlugin.Windows;

namespace IslandLeveling;

public sealed class ISLeveling : IDalamudPlugin
{
    public string Name => "ISLeveling";
    internal static ISLeveling P;
    internal static Config C => P.Config;
    internal TaskManager TaskManager;
    private const string CommandName = "/pmycommand";    

    public ISLeveling(IDalamudPluginInterface pluginInterface)
    {
        {
            P = this;
            ECommonsMain.Init(pluginInterface, this, Module.DalamudReflector);
            new TickScheduler(Load);
        }
    }

    // might need to be fixed.... not sure how
    internal void SetConfig(Config c) => IslandLeveling.Config = c;
    
    public void Load()
    {
        // if for whatever reason this wasn't using EzConfig, this will fix that
        EzConfig.Migrate<Config>();
        
        //Windows that needs to be loaded with the plugin
        // ConfigWindow needs to be fixed....
        ConfigWindow = new();
        TaskManager = new(new(abortOnTimeout: true, timeLimitMS: 20000, showDebug: true));
        Svc.Framework.Update += Tick;
    }
    
    [PluginService] internal static ITextureProvider TextureProvider { get; private set; } = null!;
    [PluginService] internal static ICommandManager CommandManager { get; private set; } = null!;

    public Config Config { get; init; }

    public readonly WindowSystem WindowSystem = new("IslandLeveling");
    private ConfigWindow ConfigWindow { get; init; }
    private MainWindow MainWindow { get; init; }

    // Need to create the ScheulerMain from the other file... /import that over 
    private void Tick(object _)
    {
        if (SchedulerMain.PluginEnabled && Svc.ClientState.LocalPlayer != null)
        {
            SchedulerMain.Tick();
        }
    }

    public void Dispose()
    {
        WindowSystem.RemoveAllWindows();

        ConfigWindow.Dispose();
        MainWindow.Dispose();

        CommandManager.RemoveHandler(CommandName);
    }

    private void OnCommand(string command, string args)
    {
        // in response to the slash command, just toggle the display status of our main ui
        ToggleMainUI();
    }

    private void DrawUI() => WindowSystem.Draw();

    public void ToggleConfigUI() => ConfigWindow.Toggle();
    public void ToggleMainUI() => MainWindow.Toggle();
}
