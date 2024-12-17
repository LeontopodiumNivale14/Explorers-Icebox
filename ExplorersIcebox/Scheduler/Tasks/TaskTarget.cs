using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using Dalamud.Plugin.Services;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class TaskTarget
    {
        public static void Enqueue(uint dataID)
        {
            P.taskManager.Enqueue(() => TargetNPC(npcID), "Trying to target NPC");
        }

        internal static bool? TargetNPC(uint npcID)
        {
            private static uint DataID = npcID
            public static IObjectTable ObjectTable { get; private set; } = null!;
            var target = ObjectTable.FirstOrDefault(o => o.IsTargetable && !o.DataId == npcID)
        }
    }
}
