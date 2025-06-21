using System.IO;

namespace ExplorersIcebox.Config;

public class GeneralConfig : IYamlConfig
{
    public const int CurrentConfigVersion = 2;

    public int routeSelected { get; set; } = 1;
    public bool runInfinite { get; set; } = true;
    public int runAmount { get; set; } = 0;
    public bool everythingUnlocked { get; set; } = true;
    public bool XPGrind { get; set; } = true;
    public bool UseTickets { get; set; } = false;
    public bool SkipSell { get; set; } = false;

    public static string ConfigPath => Path.Combine(Svc.PluginInterface.ConfigDirectory.FullName, "ExplorersConfig.yaml");
    public void Save() => YamlConfig.Save(this, ConfigPath);
}
