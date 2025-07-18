namespace ExplorersIcebox.Enums
{
    [Flags]
    internal enum IceBoxState
    {
        Idle = 0,
        Start = 1,
        CheckSell = 2,
        SellToNpc = 3,
        RunRoute = 4,
        EndProcess = 5,
    }
}
