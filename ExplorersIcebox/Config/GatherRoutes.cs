using ExplorersIcebox.Util.PathCreation;
using System.Collections.Generic;
using System.IO;

namespace ExplorersIcebox.Config;

public class GatherRoutes : IYamlConfig
{
    private int Version = 2;

    public static string ConfigPath => Path.Combine(Svc.PluginInterface.ConfigDirectory.FullName, "GatherRoutesConfig.yaml");
    public void Save() => YamlConfig.Save(this, ConfigPath);

    // Each route (e.g., "Route 1") contains a list of waypoint groups (each with its own action + waypoints)
    public Dictionary<string, List<RouteClass.WaypointGroup>> Routes { get; set; } = new();
}
