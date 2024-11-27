using System.Text.Json.Serialization;
using ECommons.Configuration;

namespace IslandLeveling;

public class Config : IEzConfig
{
    [JsonIgnore]
    public const int CurrentConfigVersion = 1;
        
    // Send Amounts (to be grabbed for the tables)
    public int PalmLeafWS { get; set; } = 0;
    public int BranchWS { get; set; } = 0;
    public int StoneWS { get; set; } = 0;
    public int ClamWS { get; set; } = 0;
    public int LaverWS { get; set; } = 0;
    public int CoralWS { get; set; } = 0;
    public int IslewortWS { get; set; } = 0;
    public int SandWS { get; set; } = 0;
    public int VineWS { get; set; } = 0;
    public int SapWS { get; set; } = 0;
    public int AppleWS { get; set; } = 0;
    public int LogWS { get; set; } = 0;
    public int PalmLogWS { get; set; } = 0;
    public int CopperWS { get; set; } = 0;
    public int LimestoneWS { get; set; } = 0;
    public int RockSaltWS { get; set; } = 0;
    public int ClayWS { get; set; } = 0;
    public int TinsandWS { get; set; } = 0;
    public int SugarcaneWS { get; set; } = 0;
    public int CottonWS { get; set; } = 0;
    public int HempWS { get; set; } = 0;
    public int IslefishWS { get; set; } = 0;
    public int SquidWS { get; set; } = 0;
    public int JellyfishWS { get; set; } = 0;
    public int IronOreWS { get; set; } = 0;
    public int QuartzWS { get; set; } = 0;
    public int LeucograniteWS { get; set; } = 0;
    public int MulticoloredIslebloomsWS { get; set; } = 0;
    public int ResinWS { get; set; } = 0;
    public int CoconutWS { get; set; } = 0;
    public int BeehiveWS { get; set; } = 0;
    public int WoodOpalWS { get; set; } = 0;
    public int CoalWS { get; set; } = 0;
    public int GlimshroomWS { get; set; } = 0;
    public int EffervescentWaterWS { get; set; } = 0;
    public int ShaleWS { get; set; } = 0;
    public int MarbleWS { get; set; } = 0;
    public int MythrilOreWS { get; set; } = 0;
    public int SpectrineWS { get; set; } = 0;
    public int DuriumSandWS { get; set; } = 0;
    public int YellowCopperOreWS { get; set; } = 0;
    public int GoldOreWS { get; set; } = 0;
    public int HawksEyeSandWS { get; set; } = 0;
    public int CrystalFormationWS { get; set; } = 0;        
}
