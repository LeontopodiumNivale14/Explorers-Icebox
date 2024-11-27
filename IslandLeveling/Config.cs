using System.Text.Json.Serialization;
using ECommons.Configuration;

namespace IslandLeveling;

public class Config : IEzConfig
{
    [JsonIgnore]
    public const int CurrentConfigVersion = 1;
        
    // Send Amounts (to be grabbed for the tables)
    // this is currently being updated properly but... (Palm Leaf is atleast)
    // but it's also not re-applying the data. Need to work on that
    public int PalmLeafWS => PalmLeafWorkshop;
    public int BranchWS => BranchWorkshop;
    public int StoneWS => StoneWorkshop;
    public int ClamWS => ClamWorkshop;
    public int LaverWS => LaverWorkshop;
    public int CoralWS => CoralWorkshop;
    public int IslewortWS => IslewortWorkshop;
    public int SandWS => SandWorkshop;
    public int VineWS => VineWorkshop; 
    public int SapWS => SapWorkshop;
    public int AppleWS => AppleWorkshop;
    public int LogWS => LogWorkshop;
    public int PalmLogWS => PalmLogWorkshop;
    public int CopperWS => CopperWorkshop;
    public int LimestoneWS => LimestoneWorkshop;
    public int RockSaltWS => RockSaltWorkshop;
    public int ClayWS => ClayWorkshop; 
    public int TinsandWS => TinsandWorkshop;
    public int SugarcaneWS => SugarcaneWorkshop;
    public int CottonWS => CottonWorkshop;
    public int HempWS => HempWorkshop;
    public int IslefishWS => IslefishWorkshop;
    public int SquidWS => SquidWorkshop;
    public int JellyfishWS => JellyfishWorkshop;
    public int IronOreWS => IronOreWorkshop;
    public int QuartzWS => QuartzWorkshop;
    public int LeucograniteWS => LeucograniteWorkshop;
    public int MulticoloredIslebloomsWS => MulticoloredIslebloomsWorkshop;
    public int ResinWS => ResinWorkshop;
    public int CoconutWS => CoconutWorkshop;
    public int BeehiveWS => BeehiveWorkshop;
    public int WoodOpalWS => WoodOpalWorkshop;
    public int CoalWS => CoalWorkshop;
    public int GlimshroomWS => GlimshroomWorkshop;
    public int EffervescentWaterWS => EffervescentWaterWorkshop;
    public int ShaleWS => ShaleWorkshop;
    public int MarbleWS => MarbleWorkshop;
    public int MythrilOreWS => MythrilOreWorkshop;
    public int SpectrineWS => SpectrineWorkshop;
    public int DuriumSandWS => DuriumSandWorkshop;
    public int YellowCopperOreWS => YellowCopperOreWorkshop;     
    public int GoldOreWS => GoldOreWorkshop;
    public int HawksEyeSandWS => HawksEyeSandWorkshop;
    public int CrystalFormationWS => CrystalFormationWorkshop;
}
