using Dalamud.Plugin.Services;
using ExplorersIcebox.Config;

namespace ExplorersIcebox
{
    internal class Service
    {
        internal static GeneralConfig Configuration { get; set; } = null!;
        internal static IDalamudPluginInterface PluginInterface { get; set; } = null!;
        public static IObjectTable ObjectTable { get; private set; } = null!;
    }
}
