using ECommons.SplatoonAPI;
using System.Collections.Generic;

namespace ExplorersIcebox.IPC;
public class SplatoonCache
{
    public List<Element> WaymarkLineCache = [];
    public int WaymarkLinePos = 0;
    public List<Element> WaymarkPointCache = [];
    public int WaymarkPointPos = 0;
}

