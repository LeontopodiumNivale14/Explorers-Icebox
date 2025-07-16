using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ExplorersIcebox.Util.PathCreation;

public static class RouteClass
{
    public enum WaypointAction
    {
        None,
        IslandInteract,
        Jump
    }

    public class RouteUtil
    {
        public List<InteractionUtil> BaseToLocation { get; set; } = new();
        public List<InteractionUtil> RouteWaypoints { get; set; } = new();
    }

    public class InteractionUtil
    {
        public string Name { get; set; } = string.Empty;
        public List<Vector3> Waypoints { get; set; } = new();
        public WaypointAction Action { get; set; } = WaypointAction.None;
        public ulong TargetId { get; set; } = 0;
        public bool Mount { get; set; } = false;
        public bool Fly { get; set; } = false;
    }
}
