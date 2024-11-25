using Dalamud.Configuration;
using ECommons.Configuration;

namespace IslandLeveling;

[Serializable]
public class Config : IPluginConfiguration, IEzConfig
{
    public int Version { get; set; } = 0;

    public bool IsConfigWindowMovable { get; set; } = true;
    public bool SomePropertyToBeSavedAndWithADefault { get; set; } = true;

    // the below exist just to make saving less cumbersome
    internal void Save() => Svc.PluginInterface.SavePluginConfig(this);
}
