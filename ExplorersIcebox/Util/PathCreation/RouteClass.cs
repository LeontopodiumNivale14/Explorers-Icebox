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

    public class WaypointUtil
    {
        public string Name { get; set; } = string.Empty;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public WaypointAction Action { get; set; } = WaypointAction.None;
        public ulong Target { get; set; } = 0; // Optional, used if IslandInteract or similar needs a target
        public bool Mount { get; set; } = false;

        public Vector3 ToVector3() => new(X, Y, Z);
        public static WaypointUtil FromVector3(Vector3 vec)
            => new() { X = vec.X, Y = vec.Y, Z = vec.Z };
    }
}
