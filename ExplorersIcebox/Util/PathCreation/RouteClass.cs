using ExplorersIcebox.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util.PathCreation;

public static class RouteClass
{
    public enum WaypointAction
    {
        None,
        IslandInteract
    }

    public class WaypointUtil
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3 ToVector3() => new(X, Y, Z);
        public static WaypointUtil FromVector3(Vector3 vec)
            => new() { X = vec.X, Y = vec.Y, Z = vec.Z };
    }

    public class WaypointGroup
    {
        public string Name { get; set; } = "New Group";
        public WaypointAction Action { get; set; } = WaypointAction.None;
        public List<WaypointUtil> Waypoints { get; set; } = new();
    }
}
