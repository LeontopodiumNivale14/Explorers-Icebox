using System.Text.Json.Serialization;
using ECommons.Configuration;

namespace IslandLeveling;

public class Config : IEzConfig
{
    [JsonIgnore]
    public const int CurrentConfigVersion = 1;
        
    // Send Amounts (to be grabbed for the tables)
    public int PalmLeafSend { get; set; } = 0;
    public int BranchSend { get; set; } = 0;
    public int StoneSend { get; set; } = 0;
    public int ClamSend { get; set; } = 0;
    public int LaverSend { get; set; } = 0;
    public int CoralSend { get; set; } = 0;
    public int IslewortSend { get; set; } = 0;
    public int SandSend { get; set; } = 0;
    public int VineSend { get; set; } = 0;
    public int SapSend { get; set; } = 0;
    public int AppleSend { get; set; } = 0;
    public int LogSend { get; set; } = 0;
    public int PalmLogSend { get; set; } = 0;
    public int CopperSend { get; set; } = 0;
    public int LimestoneSend { get; set; } = 0;
    public int RockSaltSend { get; set; } = 0;
    public int ClaySend { get; set; } = 0;
    public int TinsandSend { get; set; } = 0;
    public int SugarcaneSend { get; set; } = 0;
    public int CottonSend { get; set; } = 0;
    public int HempSend { get; set; } = 0;
    public int IslefishSend { get; set; } = 0;
    public int SquidSend { get; set; } = 0;
    public int JellyfishSend { get; set; } = 0;
    public int IronOreSend { get; set; } = 0;
    public int QuartzSend { get; set; } = 0;
    public int LeucograniteSend { get; set; } = 0;
    public int MulticoloredIslebloomsSend { get; set; } = 0;
    public int ResinSend { get; set; } = 0;
    public int CoconutSend { get; set; } = 0;
    public int BeehiveSend { get; set; } = 0;
    public int WoodOpalSend { get; set; } = 0;
    public int CoalSend { get; set; } = 0;
    public int GlimshroomSend { get; set; } = 0;
    public int EffervescentWaterSend { get; set; } = 0;
    public int ShaleSend { get; set; } = 0;
    public int MarbleSend { get; set; } = 0;
    public int MythrilOreSend { get; set; } = 0;
    public int SpectrineSend { get; set; } = 0;
    public int DuriumSandSend { get; set; } = 0;
    public int YellowCopperOreSend { get; set; } = 0;
    public int GoldOreSend { get; set; } = 0;
    public int HawksEyeSandSend { get; set; } = 0;
    public int CrystalFormationSend { get; set; } = 0;        
}
