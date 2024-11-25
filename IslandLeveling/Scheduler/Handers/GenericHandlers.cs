using ECommons.Throttlers;

namespace IslandLeveling.Scheduler.Handers
{
    internal class GenericHandlers
    {
        internal static bool? Throttle(string name, int ms)
        {
            return EzThrottler.Throttle(name, ms);
        }

        internal static bool? WaitFor(string name, int ms)
        {
            return EzThrottler.Check(name);
        }
    }
}
