namespace IslandLeveling
{
    internal class Service
    {
        internal static ISLeveling IsLeveling { get; set; } = null!;
        internal static Config Configuration { get; set; } = null!;
        internal static IDalamudPluginInterface PluginInterface { get; set; } = null!;
    }
}
