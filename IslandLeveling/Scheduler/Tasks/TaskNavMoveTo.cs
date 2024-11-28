using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using IslandLeveling.Scheduler.Handers;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskMoveTo
    {
        private static float Distance(this Vector3 v, Vector3 v2)
        {
            return new Vector2(v.X - v2.X, v.Z - v2.Z).Length();
        }
        private static unsafe bool IsMoving()
        {
            return AgentMap.Instance()->IsPlayerMoving == 1;
        }
        internal unsafe static void Enqueue(Vector3 targetPosition, float toleranceDistance = 3f)
        {
            P.taskManager.Enqueue(() => MoveTo(targetPosition, toleranceDistance));
        }
        internal unsafe static bool? MoveTo(Vector3 targetPosition, float toleranceDistance = 3f)
        {
            if (targetPosition.Distance(Player.GameObject->Position) <= toleranceDistance)
            {
                P.navmesh.Stop();
                return true;
            }
            if (P.navmesh.PathfindInProgress() || P.navmesh.IsRunning() || IsMoving()) return false;

            P.navmesh.PathfindAndMoveTo(targetPosition, false);
            P.navmesh.SetAlignCamera(true);
            return false;
        }
    }
}
