using Dalamud.Game.ClientState.Conditions;
using FFXIVClientStructs.FFXIV.Client.Game;
using IslandLeveling.Scheduler.Handers;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static unsafe class TaskMountUp
    {
        public static void Enqueue()
        {
            P.taskManager.Enqueue(PlayerHandlers.MountUp);
        }
    }
}
