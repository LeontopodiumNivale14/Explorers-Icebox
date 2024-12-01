using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using IslandLeveling.Scheduler.Handers;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskMoveTo
    {
        internal unsafe static void Enqueue(Vector3 targetPosition, string destination, float toleranceDistance = 3f)
        {
            P.taskManager.Enqueue(() => MoveTo(targetPosition, toleranceDistance), destination);
        }
        internal unsafe static bool? MoveTo(Vector3 targetPosition, float toleranceDistance = 3f)
        {
            if (targetPosition.Distance(Player.GameObject->Position) <= toleranceDistance)
            {
                P.navmesh.Stop();
                return true;
            }
            if (P.navmesh.PathfindInProgress() || P.navmesh.IsRunning() || PlayerHandlers.IsMoving()) return false;

            P.navmesh.PathfindAndMoveTo(targetPosition, false);
            P.navmesh.SetAlignCamera(false);
            return false;
        }
    }
}
