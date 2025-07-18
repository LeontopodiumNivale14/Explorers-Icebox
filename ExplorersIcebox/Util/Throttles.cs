using ECommons.Throttlers;

namespace ExplorersIcebox.Util;
internal class Throttles
{
    internal static bool GenericThrottle => FrameThrottler.Throttle("ExplorersIceboxThrottle", 10);
    internal static bool OneSecondThrottle => EzThrottler.Throttle("TurninThrottle", 1000);
}
