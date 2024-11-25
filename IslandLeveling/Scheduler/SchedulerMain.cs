namespace IslandLeveling.Scheduler;

internal static unsafe class SchedulerMain
{
    internal static bool PluginEnabledInternal;
    internal static bool PluginEnabled
    {
        get => PluginEnabledInternal; // && !IPCSuppressed
        private set => PluginEnabledInternal = value;
    }
    internal static bool IsEnabled // Public property which reacts to true/false
    {
        get => PluginEnabled;
        set
        {
            PluginEnabled = value;
            if (PluginEnabled)
            {
                EnablePlugin();
            }
            else
            {
                DisablePlugin();
            }
        }
    }
    private static void EnablePlugin()
    {
        PluginEnabled = true;
    }
    private static void DisablePlugin()
    {
        PluginEnabled = false;
    }
    internal static void Tick()
    {
        if (PluginEnabled)
        {
            /* this is where I would add code to check for things
            / So esentially where to start the looping process of it all (going to sell things, actually moving, ect)
            / Need to code this in a way to make sure that it performs each task sequentially... but that's thoughts for later
            */
            
            TaskMount.Enqueue();
        }
    }
}
