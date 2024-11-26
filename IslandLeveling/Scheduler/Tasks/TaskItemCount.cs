using IslandLeveling.Scheduler.Handers;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class ItemCounter
    {
        internal static void Enqueue()
        {
            P.taskManager.Enqueue(() => IslandSancHanders.CurrentIslandItem());
        }
    }
}
