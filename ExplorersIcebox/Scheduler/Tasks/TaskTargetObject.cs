using Dalamud.Game.ClientState.Objects.Types;
using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal class TaskTargetObject
    {
        public static void Enqueue(ulong ObjectID)
        {
            IGameObject? gameObject = null;
            P.taskManager.Enqueue(() => TargetUtil.TryGetObjectByObjectId(ObjectID, out gameObject));
            P.taskManager.Enqueue(() => TargetUtil.TargetByID(gameObject));
        }
    }
}
