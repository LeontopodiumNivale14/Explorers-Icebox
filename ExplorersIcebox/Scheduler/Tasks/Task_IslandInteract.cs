using Dalamud.Game.ClientState.Objects.Types;
using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_IslandInteract
    {
        public static void Enqueue(ulong gameObjectId)
        {
            IGameObject? gameObject = null;
            Utils.TryGetObjectByGameObjectId(gameObjectId, out var gameobject);
        }
    }
}
