using ExplorersIcebox.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace ExplorersIcebox.Scheduler.Tasks
{
    internal static class Task_SellItems
    {
        public static void Enqueue()
        {
            P.taskManager.Enqueue(() => MoveToNpc(), "Moving to NPC");
            P.taskManager.Enqueue(() => InteractWithShop(), "Interacting w/ the material seller vendor");
            foreach (var item in IslandHelper.SellItems)
            {
                var itemId = item.Key;
                var sellAmount = item.Value;

                P.taskManager.Enqueue(() => SellToNpc(itemId, sellAmount), $"Selling {itemId}");
                P.taskManager.EnqueueDelay(300);
            }
        }

        internal static bool? MoveToNpc()
        {
            // Insert the logic here post return to move to NPC

            return false;
        }

        internal static bool? InteractWithShop()
        {
            // Just a way for me to interact w/ the shop -> getting the window open

            return false;
        }

        internal static bool? SellToNpc(int itemId, int sellAmount)
        {
            // Make sure that addon list is open


            return false;
        }
    }
}
