using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using Dalamud.Plugin.Services;
using Lumina.Excel.Sheets;
using ECommons.Throttlers;
using Dalamud.Game.ClientState.Objects.Types;
using ExplorersIcebox.Util;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class TaskTarget
    {
        public static void Enqueue(uint dataID)
        {
            IGameObject? gameObject = null;
            P.taskManager.Enqueue(() => TargetUtil.TryGetObjectByDataId(dataID, out gameObject));
            P.taskManager.Enqueue(() => TargetUtil.TargetByID(gameObject));
        }
    }
}
