using System.IO;

namespace ExplorersIcebox.Config;

public class GeneralConfig : IYamlConfig
{
    public const int CurrentConfigVersion = 2;
    public int ModeSelected { get; set; } = 0;
    public int routeSelected { get; set; } = 1;

    // The minimum amount of items you want to keep in your inventory
    public int MinimumItemKeep { get; set; } = 500;

    public uint PictoCircleColor { get; set; } = 0;
    public uint PictoLineColor { get; set; } = 0;
    public uint PictoWPColor { get; set; } = 0;
    public uint PictoTextCol { get; set; } = 0;
    public float DotRadius { get; set; } = 0f;
    public float LineWidth { get; set; } = 0f;
    public Vector2 DonutRadius { get; set; } = new Vector2(0.7f, 1.4f);
    public Vector2 FanPosition { get; set; } = new Vector2(0.0f, 6.283f);

    public float TextFloatPlus { get; set; } = 0.0f;

    public static string ConfigPath => Path.Combine(Svc.PluginInterface.ConfigDirectory.FullName, "ExplorersConfig.yaml");
    public void Save() => YamlConfig.Save(this, ConfigPath);
}
