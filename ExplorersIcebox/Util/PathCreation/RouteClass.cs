using ExplorersIcebox.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace ExplorersIcebox.Util.PathCreation;

public static class RouteClass
{
    [YamlIgnore] // Optional: Ignore it on *future* serialization
    public static WaypointAction Action { get; set; } = WaypointAction.None;

    [YamlIgnore]
    public static ulong Target { get; set; } = 0;

    public enum WaypointAction
    {
        None,
        IslandInteract,
        Jump
    }

    public class WaypointUtil
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public WaypointAction Action { get; set; } = WaypointAction.None;
        public ulong Target { get; set; } = 0; // Optional, used if IslandInteract or similar needs a target

        public Vector3 ToVector3() => new(X, Y, Z);
        public static WaypointUtil FromVector3(Vector3 vec)
            => new() { X = vec.X, Y = vec.Y, Z = vec.Z };
    }


    public class WaypointGroup
    {
        public string Name { get; set; } = "New Group";
        public bool Mount { get; set; } = false;
        public List<WaypointUtil> Waypoints { get; set; } = new();
    }
}
