using System.Text.Json.Serialization;
using ECommons.Configuration;

namespace ExplorersIcebox;

public class Config : IEzConfig
{
    [JsonIgnore]
    public const int CurrentConfigVersion = 1;

    public int routeSelected = 1;
    public bool runInfinite = true;
    public int runAmount = 0;
    public bool everythingUnlocked = true;
    public bool XPGrind = true;

    public bool Route0 = true;
    public bool Route1 = true;
    public bool Route2 = true;
    public bool Route3 = true;
    public bool Route4 = true;
    public bool Route5 = true;
    public bool Route6 = true;
    public bool Route7 = true;
    public bool Route8 = true;
    public bool Route9 = true;
    public bool Route10 = true;
    public bool Route11 = true;
    public bool Route12 = true;
    public bool Route13 = true;
    public bool Route14 = true;
    public bool Route15 = true;
    public bool Route16 = true;
    public bool Route17 = true;
    public bool Route18 = true;
    public bool Route19 = true;
    public bool Route20 = true;
    public bool Route21 = true;

    public void Save()
    {
        EzConfig.Save();
    }
}
