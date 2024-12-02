using Dalamud.Game.ClientState.Conditions;
using ECommons.Automation.NeoTaskManager;
using IslandLeveling.Scheduler.Handers;

namespace IslandLeveling.Scheduler.Tasks
{
    internal static class TaskVislandTemp
    {
        internal unsafe static void Enqueue(string VRoute, string Taskname)
        {
            P.taskManager.Enqueue(() => VislandExec(VRoute), Taskname, configuration: DConfig);
        }
        internal unsafe static bool? VislandExec(string VRoute)
        {
            if (P.visland.IsRouteRunning() == false && !Svc.Condition[ConditionFlag.OccupiedInQuestEvent])
            {
                P.visland.StartRoute(VRoute, true);
                return true;
            }

            if (P.visland.IsRouteRunning() || PlayerHandlers.IsMoving()) return false;
            return false;
        }
        private static TaskManagerConfiguration DConfig => new(timeLimitMS: 10 * 60 * 1000, abortOnTimeout: false);
    }
}
