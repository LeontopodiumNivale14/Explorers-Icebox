using System.Collections.Generic;
using System.IO;

namespace ExplorersIcebox.Config;

public class GeneralConfig : IYamlConfig
{
    public int CurrentConfigVersion { get; set; } = 0;
    public int ModeSelected { get; set; } = 0;
    public int routeSelected { get; set; } = 0;

    // The minimum amount of items you want to keep in your inventory
    public int MinimumItemKeep { get; set; } = 500;
    public bool SkipSell { get; set; } = false;
    public bool DryTest { get; set; } = false;
    public bool RunMaxLoops { get; set; } = false;
    public bool RunMultiple { get; set; } = false;
    /// <summary>
    /// Amount of times you want to run this route
    /// </summary>
    public int RunAmount { get; set; } = 0;

    public Dictionary<string, int> ItemGatherAmount { get; set; } = new ()
    {
        { "Palm Leaf", 0 },
        { "Apple", 0 },
        { "Branch", 0 },
        { "Stone", 0 },
        { "Clam", 0 },
        { "Laver", 0 },
        { "Coral", 0 },
        { "Islewort", 0 },
        { "Sand", 0 },
        { "Log", 0 },
        { "Palm Log", 0 },
        { "Vine", 0 },
        { "Sap", 0 },
        { "Copper", 0 },
        { "Limestone", 0 },
        { "Rock Salt", 0 },
        { "Sugarcane", 0 },
        { "Cotton", 0 },
        { "Hemp", 0 },
        { "Clay", 0 },
        { "Tinsand", 0 },
        { "Iron Ore", 0 },
        { "Quartz", 0 },
        { "Leucogranite", 0 },
        { "Islefish", 0 },
        { "Squid", 0 },
        { "Jellyfish", 0 },
        { "Resin", 0 },
        { "Coconut", 0 },
        { "Beehive", 0 },
        { "Wood Opal", 0 },
        { "Multicolored Isleblooms", 0 },
        { "Coal", 0 },
        { "Shale", 0 },
        { "Glimshroom", 0 },
        { "Marble", 0 },
        { "Mythril Ore", 0 },
        { "Effervescent Water", 0 },
        { "Spectrine", 0 },
        { "Durium Sand", 0 },
        { "Yellow Copper Ore", 0 },
        { "Gold Ore", 0 },
        { "Hawk's Eye Sand", 0 },
        { "Crystal Formation", 0 },
        { "Cabbage Seed", 0},
        { "Pumpkin Seed", 0},
        { "Parsnip Seed", 0},
        { "Popoto Seed", 0}
    };

    // Debug Stuff
    public uint PictoCircleColor { get; set; } = 0;
    public uint PictoLineColor { get; set; } = 0;
    public uint PictoWPColor { get; set; } = 0;
    public uint PictoTextCol { get; set; } = 0;
    public float DotRadius { get; set; } = 0f;
    public float LineWidth { get; set; } = 0f;
    public Vector2 DonutRadius { get; set; } = new Vector2(0.7f, 1.4f);
    public Vector2 FanPosition { get; set; } = new Vector2(0.0f, 6.283f);
    public float TextFloatPlus { get; set; } = 0.0f;

    // General Save

    public static string ConfigPath => Path.Combine(Svc.PluginInterface.ConfigDirectory.FullName, "ExplorersConfig.yaml");
    public void Save() => YamlConfig.Save(this, ConfigPath);
}
