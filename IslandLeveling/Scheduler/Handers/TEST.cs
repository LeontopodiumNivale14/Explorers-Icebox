namespace IslandLeveling.Scheduler.Handers
{
    internal static unsafe class TEST
    {
        internal static bool? Test()
        {
            GenericHandlers.Throttle("Test Throttle",100);
            Svc.Chat.Print("Test12");
            Svc.Chat.Print("499488");
            return true;
        }
    }
}

