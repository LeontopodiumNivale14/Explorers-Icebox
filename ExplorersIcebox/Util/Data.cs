using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util;

internal class Data
{
    #region Island Item ID's + Counts

    public const int PalmLeaf_ID = 37551;
    public const int Branch_ID = 37553;
    public const int Stone_ID = 37554;
    public const int Clam_ID = 37555;
    public const int Laver_ID = 37556;
    public const int Coral_ID = 37557;
    public const int Islewort_ID = 37558;
    public const int Sand_ID = 37559;
    public const int Vine_ID = 37562;
    public const int Sap_ID = 37563;
    public const int Apple_ID = 37552;
    public const int Log_ID = 37560;
    public const int PalmLog_ID = 37561;
    public const int Copper_ID = 37564;
    public const int Limestone_ID = 37565;
    public const int RockSalt_ID = 37566;
    public const int Clay_ID = 37570;
    public const int Tinsand_ID = 37571;
    public const int Sugarcane_ID = 37567;
    public const int Cotton_ID = 37568;
    public const int Hemp_ID = 37569;
    public const int Islefish_ID = 37575;
    public const int Squid_ID = 37576;
    public const int Jellyfish_ID = 37577;
    public const int IronOre_ID = 37572;
    public const int Quartz_ID = 37573;
    public const int Leucogranite_ID = 37574;
    public const int MulticoloredIsleblooms_ID = 39228;
    public const int Resin_ID = 39224;
    public const int Coconut_ID = 39225;
    public const int Beehive_ID = 39226;
    public const int WoodOpal_ID = 39227;
    public const int Coal_ID = 39887;
    public const int Glimshroom_ID = 39889;
    public const int EffervescentWater_ID = 39892;
    public const int Shale_ID = 39888;
    public const int Marble_ID = 39890;
    public const int MythrilOre_ID = 39891;
    public const int Spectrine_ID = 39893;
    public const int DuriumSand_ID = 41630;
    public const int YellowCopperOre_ID = 41631;
    public const int GoldOre_ID = 41632;
    public const int HawksEyeSand_ID = 41633;
    public const int CrystalFormation_ID = 41634;

    public static int[] ListitemIDs = new int[]
    {
        PalmLeafID, BranchID, StoneID, ClamID, LaverID, CoralID, IslewortID,
        SandID, VineID, SapID, AppleID, LogID, PalmLogID, CopperID, LimestoneID,
        RockSaltID, ClayID, TinsandID, SugarcaneID, CottonID, HempID, IslefishID,
        SquidID, JellyfishID, IronOreID, QuartzID, LeucograniteID,
        MulticoloredIslebloomsID, ResinID, CoconutID, BeehiveID, WoodOpalID,
        CoalID, GlimshroomID, EffervescentWaterID, ShaleID, MarbleID,
        MythrilOreID, SpectrineID, DuriumSandID, YellowCopperOreID,
        GoldOreID, HawksEyeSandID, CrystalFormationID
    };

    // Gets the current amount of the island sanctuary item that you have
    public static int PalmLeaf_Amount => GetItemCount(PalmLeafID);
    public static int Branch_Amount => GetItemCount(BranchID);
    public static int Stone_Amount => GetItemCount(StoneID);
    public static int Clam_Amount => GetItemCount(ClamID);
    public static int Laver_Amount => GetItemCount(LaverID);
    public static int Coral_Amount => GetItemCount(CoralID);
    public static int Islewort_Amount => GetItemCount(IslewortID);
    public static int Sand_Amount => GetItemCount(SandID);
    public static int Vine_Amount => GetItemCount(VineID);
    public static int Sap_Amount => GetItemCount(SapID);
    public static int Apple_Amount => GetItemCount(AppleID);
    public static int Log_Amount => GetItemCount(LogID);
    public static int PalmLog_Amount => GetItemCount(PalmLogID);
    public static int Copper_Amount => GetItemCount(CopperID);
    public static int Limestone_Amount => GetItemCount(LimestoneID);
    public static int RockSalt_Amount => GetItemCount(RockSaltID);
    public static int Clay_Amount => GetItemCount(ClayID);
    public static int Tinsand_Amount => GetItemCount(TinsandID);
    public static int Sugarcane_Amount => GetItemCount(SugarcaneID);
    public static int Cotton_Amount => GetItemCount(CottonID);
    public static int Hemp_Amount => GetItemCount(HempID);
    public static int Islefish_Amount => GetItemCount(IslefishID);
    public static int Squid_Amount => GetItemCount(SquidID);
    public static int Jellyfish_Amount => GetItemCount(JellyfishID);
    public static int IronOre_Amount => GetItemCount(IronOreID);
    public static int Quartz_Amount => GetItemCount(QuartzID);
    public static int Leucogranite_Amount => GetItemCount(LeucograniteID);
    public static int MulticoloredIsleblooms_Amount => GetItemCount(MulticoloredIslebloomsID);
    public static int Resin_Amount => GetItemCount(ResinID);
    public static int Coconut_Amount => GetItemCount(CoconutID);
    public static int Beehive_Amount => GetItemCount(BeehiveID);
    public static int WoodOpal_Amount => GetItemCount(WoodOpalID);
    public static int Coal_Amount => GetItemCount(CoalID);
    public static int Glimshroom_Amount => GetItemCount(GlimshroomID);
    public static int EffervescentWater_Amount => GetItemCount(EffervescentWaterID);
    public static int Shale_Amount => GetItemCount(ShaleID);
    public static int Marble_Amount => GetItemCount(MarbleID);
    public static int MythrilOre_Amount => GetItemCount(MythrilOreID);
    public static int Spectrine_Amount => GetItemCount(SpectrineID);
    public static int DuriumSand_Amount => GetItemCount(DuriumSandID);
    public static int YellowCopperOre_Amount => GetItemCount(YellowCopperOreID);
    public static int GoldOre_Amount => GetItemCount(GoldOreID);
    public static int HawksEyeSand_Amount => GetItemCount(HawksEyeSandID);
    public static int CrystalFormation_Amount => GetItemCount(CrystalFormationID);

    #endregion

    #region Island Nodes

    public const uint SeaweedTangle = 2012985;
    public const uint LargeShell = 2012985;

    #endregion

    public static Dictionary<uint, List<uint>> Nodes = new()
    {
        { SeaweedTangle, new List<uint> {Laver_ID, Squid_ID } },
        { LargeShell, new List<uint> {Clam_ID, Islefish_ID} }
    };

    public static int RunAmount()
    {
        foreach (var kdp in Nodes)
        {
            var list = kdp.Value;

            foreach (var id in list)
            {

            }
        }
    }
}
