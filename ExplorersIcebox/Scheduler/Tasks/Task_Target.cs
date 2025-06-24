using Dalamud.Game.ClientState.Objects.Types;
using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_Target
    {
        public static void Enqueue(ulong gameObjectId)
        {
            P.taskManager.Enqueue(() => TargetObject(gameObjectId));
        }

        internal static void TargetObject(ulong gameObjectId)
        {
            IGameObject? gameObject = null;
            Utils.TryGetObjectByGameObjectId(gameObjectId, out gameObject);

            if (gameObject == null)
            {
                Svc.Chat.Print("Target Doesn't Exist");
            }
            else
            {
                Svc.Chat.Print("Target does exist!");
                Utils.TargetgameObject(gameObject);
            }
        }
    }
}
