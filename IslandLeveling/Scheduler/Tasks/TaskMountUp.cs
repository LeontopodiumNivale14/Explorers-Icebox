using IslandLeveling.Scheduler.Handers;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskMountUp
    {
        internal static void Enqueue()
        {
            P.taskManager.Enqueue(PlayerHandlers.MountUp);
        }
    }
}    
