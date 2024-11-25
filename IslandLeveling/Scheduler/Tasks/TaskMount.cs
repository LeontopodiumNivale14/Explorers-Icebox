using IslandLeveling.Scheduler.Handers;

namespace IslandLeveling.Scheduler.Tasks;

public class TaskMount
{
    internal static void Enqueue()
    {
        ISLeveling.P.TaskManager.Enqueue(TEST.Test);
        //IceBox.TaskManagerIce.Enqueue(PlayerHandlers.PlayerMounted);
    }
}
