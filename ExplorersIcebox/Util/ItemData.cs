using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util;

public static class ItemData
{
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
    public const int CopperOre_ID = 37564;
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

    public class IslandItemInfo
    {
        public string ItemName { get; set; } = "";
        public int SellSlot { get; set; } = 0;
        public int NodeId { get; set; } = 0;
    }

    public static Dictionary<int, IslandItemInfo> IslandItems = new()
    {
        { PalmLeaf_ID, new IslandItemInfo { ItemName = "Palm Leaf", SellSlot = 0, NodeId = 10 } },
        { Apple_ID, new IslandItemInfo { ItemName = "Apple", SellSlot = 0, NodeId = 100001 } },
        { Branch_ID, new IslandItemInfo { ItemName = "Branch", SellSlot = 0, NodeId = 100002 } },
        { Stone_ID, new IslandItemInfo { ItemName = "Stone", SellSlot = 0, NodeId = 100003 } },
        { Clam_ID, new IslandItemInfo { ItemName = "Clam", SellSlot = 0, NodeId = 100004 } },
        { Laver_ID, new IslandItemInfo { ItemName = "Laver", SellSlot = 0, NodeId = 100005 } },
        { Coral_ID, new IslandItemInfo { ItemName = "Coral", SellSlot = 0, NodeId = 100006 } },
        { Islewort_ID, new IslandItemInfo { ItemName = "Islewort", SellSlot = 0, NodeId = 100007 } },
        { Sand_ID, new IslandItemInfo { ItemName = "Sand", SellSlot = 0, NodeId = 100008 } },
        { Log_ID, new IslandItemInfo { ItemName = "Log", SellSlot = 0, NodeId = 100009 } },
        { PalmLog_ID, new IslandItemInfo { ItemName = "Palm Log", SellSlot = 0, NodeId = 100010 } },
        { Vine_ID, new IslandItemInfo { ItemName = "Vine", SellSlot = 0, NodeId = 100011 } },
        { Sap_ID, new IslandItemInfo { ItemName = "Sap", SellSlot = 0, NodeId = 100012 } },
        { CopperOre_ID, new IslandItemInfo { ItemName = "Copper", SellSlot = 0, NodeId = 100013 } },
        { Limestone_ID, new IslandItemInfo { ItemName = "Limestone", SellSlot = 0, NodeId = 100014 } },
        { RockSalt_ID, new IslandItemInfo { ItemName = "Rock Salt", SellSlot = 0, NodeId = 100015 } },
        { Sugarcane_ID, new IslandItemInfo { ItemName = "Sugarcane", SellSlot = 0, NodeId = 100016 } },
        { Cotton_ID, new IslandItemInfo { ItemName = "Cotton", SellSlot = 0, NodeId = 100017 } },
        { Hemp_ID, new IslandItemInfo { ItemName = "Hemp", SellSlot = 0, NodeId = 100018 } },
        { Clay_ID, new IslandItemInfo { ItemName = "Clay", SellSlot = 0, NodeId = 100019 } },
        { Tinsand_ID, new IslandItemInfo { ItemName = "Tinsand", SellSlot = 0, NodeId = 100020 } },
        { IronOre_ID, new IslandItemInfo { ItemName = "Iron Ore", SellSlot = 0, NodeId = 100021 } },
        { Quartz_ID, new IslandItemInfo { ItemName = "Quartz", SellSlot = 0, NodeId = 100022 } },
        { Leucogranite_ID, new IslandItemInfo { ItemName = "Leucogranite", SellSlot = 0, NodeId = 100023 } },
        { Islefish_ID, new IslandItemInfo { ItemName = "Islefish", SellSlot = 0, NodeId = 100024 } },
        { Squid_ID, new IslandItemInfo { ItemName = "Squid", SellSlot = 0, NodeId = 100025 } },
        { Jellyfish_ID, new IslandItemInfo { ItemName = "Jellyfish", SellSlot = 0, NodeId = 100026 } },
        { Resin_ID, new IslandItemInfo { ItemName = "Resin", SellSlot = 0, NodeId = 100027 } },
        { Coconut_ID, new IslandItemInfo { ItemName = "Coconut", SellSlot = 0, NodeId = 100028 } },
        { Beehive_ID, new IslandItemInfo { ItemName = "Beehive", SellSlot = 0, NodeId = 100029 } },
        { WoodOpal_ID, new IslandItemInfo { ItemName = "Wood Opal", SellSlot = 0, NodeId = 100030 } },
        { MulticoloredIsleblooms_ID, new IslandItemInfo { ItemName = "Multicolored Isleblooms", SellSlot = 0, NodeId = 100031 } },
        { Coal_ID, new IslandItemInfo { ItemName = "Coal", SellSlot = 0, NodeId = 100032 } },
        { Shale_ID, new IslandItemInfo { ItemName = "Shale", SellSlot = 0, NodeId = 100033 } },
        { Glimshroom_ID, new IslandItemInfo { ItemName = "Glimshroom", SellSlot = 0, NodeId = 100034 } },
        { Marble_ID, new IslandItemInfo { ItemName = "Marble", SellSlot = 0, NodeId = 100035 } },
        { MythrilOre_ID, new IslandItemInfo { ItemName = "Mythril Ore", SellSlot = 0, NodeId = 100036 } },
        { EffervescentWater_ID, new IslandItemInfo { ItemName = "Effervescent Water", SellSlot = 0, NodeId = 100037 } },
        { Spectrine_ID, new IslandItemInfo { ItemName = "Spectrine", SellSlot = 0, NodeId = 100038 } },
        { DuriumSand_ID, new IslandItemInfo { ItemName = "Durium Sand", SellSlot = 0, NodeId = 100039 } },
        { YellowCopperOre_ID, new IslandItemInfo { ItemName = "Yellow Copper Ore", SellSlot = 0, NodeId = 100040 } },
        { GoldOre_ID, new IslandItemInfo { ItemName = "Gold Ore", SellSlot = 0, NodeId = 100041 } },
        { HawksEyeSand_ID, new IslandItemInfo { ItemName = "Hawk's Eye Sand", SellSlot = 0, NodeId = 100042 } },
        { CrystalFormation_ID, new IslandItemInfo { ItemName = "Crystal Formation", SellSlot = 0, NodeId = 100043 } },
    };


    public class GatheringNode
    {
        public required string GatherName { get; set; }
        public required HashSet<ulong> Nodes { get; set; }
        public List<int> ItemIds { get; set; } = new();
    }

    public static List<GatheringNode> IslandNodeInfo = new()
    {
        {
            new GatheringNode
            {
                GatherName = "Agave Plant",
                Nodes = [4304375926, 4304375927, 4304410708, 4304375925, 4304375923, 4304375924, 4304411400, 4304410707, 4304375919, 4304375922, 4304411399, 4304410705, 4304410706, 4304411398, 4304375921, 4304410704, 4304410700, 4304410703, 4304375910, 4304375911, 4304375913, 4304375907, 4304375914, 4304375908, 4304375909, 4304375915, 4304375912, 4304375917, 4304411395, 4304411396, 4304411397, 4304375916, 4304375918, 4304411401],
                ItemIds = { Islewort_ID, Hemp_ID }
            },
            new GatheringNode
            {
                GatherName = "Bluish Rock",
                Nodes = [4304326164, 4304326168, 4304326162, 4304326171, 4304326169, 4304326165, 4304326170, 4304326206, 4304326203, 4304326210, 4304326207, 4304326209, 4304326180, 4304326185, 4304326179, 4304326193, 4304326182, 4304326189, 4304326175, 4304326173],
                ItemIds = { Stone_ID, CopperOre_ID, MythrilOre_ID }
            },
            new GatheringNode
            {
                GatherName = "Composite Rock",
                Nodes = [4304896887, 4304896888, 4304896865, 4304896867, 4304896889, 4304896866, 4304896864, 4304896878, 4305015976, 4304896863, 4305015974, 4305015973, 4304896861, 4305015975, 4304896862, 4304896879, 4304896880],
                ItemIds = { Stone_ID, Coal_ID, Shale_ID }
            },
            new GatheringNode
            {
                GatherName = "Coral Formation",
                Nodes = [4304373953, 4304373952, 4304373949, 4304373950, 4304373951, 4304373955, 4304373948, 4304373954],
                ItemIds = { Coral_ID, Jellyfish_ID }
            },
            new GatheringNode
            {
                GatherName = "Cotton Plant",
                Nodes = [4304410629, 4304410655, 4304410659, 4304410661, 4304410657, 4304410652, 4304410628, 4304410650, 4304410651, 4304372605, 4304410653, 4304372568, 4304372559, 4304372610, 4304372563, 4304372579, 4304372584, 4304372572, 4304372606, 4304372576, 4304372607, 4304372608, 4304372518, 4304372526, 4304372504, 4304372501, 4304372517, 4304372506, 4304372524, 4304372609],
                ItemIds = { Islewort_ID, Cotton_ID }
            },
            new GatheringNode
            {
                GatherName = "Crystal-banded Rock", 
                Nodes = [4304326263, 4304326260, 4304326262, 4304326261, 4304326266, 4304326270, 4304326268, 4304326265, 4304326267, 4304326264],
                ItemIds = { Stone_ID, RockSalt_ID }
            },
            new GatheringNode
            {
                GatherName = "Glowing Fungus", 
                Nodes = [4304896857, 4304896858, 4304896855, 4304896856, 4304870828, 4304896859, 4304896854, 4304896884, 4304896853, 4304896851, 4304895774, 4304895773, 4304896850, 4304896883, 4304896882, 4304896881],
                ItemIds = { Glimshroom_ID }
            },
            new GatheringNode
            {
                GatherName = "Island Apple Tree", 
                Nodes = [4304258720, 4304258722, 4304258750, 4304291977, 4304291975, 4304291974, 4304291973, 4304291972, 4304258738, 4304258754, 4304258747, 4304258752, 4304258741, 4304258749, 4304258760, 4304258755, 4304258774, 4304258761, 4304258770, 4304258759],
                ItemIds = { Vine_ID, Apple_ID, Beehive_ID }
            },
            new GatheringNode
            {
                GatherName = "Island Crystal Cluster", 
                Nodes = [4305155138, 4305155139, 4305155141, 4305155140],
                ItemIds = { HawksEyeSand_ID, CrystalFormation_ID}
            },
            new GatheringNode
            {
                GatherName = "Large Shell", 
                Nodes = [4304373944, 4304373946, 4304373912, 4304373941, 4304373913, 4304373940, 4304373911, 4304373945],
                ItemIds = { Sand_ID, Clam_ID, Islefish_ID}
            },
            new GatheringNode
            {
                GatherName = "Lightly Gnawed Pumpkin", 
                Nodes = [4304298101, 4304298100, 4304298099, 4304298098, 4304298102, 4304298105, 4304298107, 4304298106, 4304298103, 4304298104],
                ItemIds = { /* PumpkinSeeds*/}
            },
            new GatheringNode
            {
                GatherName = "Mahogany Tree", 
                Nodes = [4304267412, 4304267408, 4304267401, 4304267417, 4304267400, 4304267403, 4304267409, 4304258785, 4304267415, 4304411429, 4304267448, 4304267410, 4304267421, 4304267418, 4304267426, 4304267456, 4304258782, 4304258784, 4304258780, 4304258783, 4304267419],
                ItemIds = { Sap_ID, Log_ID, WoodOpal_ID }
            },
            new GatheringNode
            {
                GatherName = "Mound of Dirt", 
                Nodes = [4304375900, 4304375899, 4304375902, 4304375903, 4304375901, 4304375904, 4304375905, 4304375906, 4304375898, 4304375897, 4304375890, 4304411870, 4304375894, 4304375893, 4304411871, 4304375891, 4304375892],
                ItemIds = { Sand_ID, Clay_ID},
            },
            new GatheringNode
            {
                GatherName = "Multicolored Isleblooms", 
                Nodes = [4304649074, 4304649073, 4304649061, 4304649062, 4304649072, 4304649068, 4304649069, 4304649070, 4304649065, 4304649063, 4304649066],
                ItemIds = { MulticoloredIsleblooms_ID}
            },
            new GatheringNode
            {
                GatherName = "Palm Tree", 
                Nodes = [4304257882, 4304257924, 4304257900, 4304257926, 4304257887, 4304257927, 4304257897, 4304257923, 4304257886, 4304257925, 4304258603, 4304258604, 4304258601, 4304258569, 4304258602, 4304411424, 4304411425, 4304411426, 4304258608, 4304258607, 4304258606, 4304258609, 4304258605, 4304411427, 4304411428],
                ItemIds = { PalmLeaf_ID, PalmLog_ID, Coconut_ID}
            },
            new GatheringNode
            {
                GatherName = "Partially Consumed Cabbage", 
                Nodes = [4304386365, 4304390290, 4304390287, 4304390289, 4304390288, 4304390291],
                ItemIds = { /* Cabbage Seeds */}
            },
            new GatheringNode
            {
                GatherName = "Quartz Formation", 
                Nodes = [4304373928, 4304373929, 4304373927, 4304373930, 4304373931, 4304373919, 4304373920, 4304373918, 4304373924, 4304373923, 4304373932, 4304373925, 4304373921, 4304373922],
                ItemIds = { Stone_ID, Quartz_ID }
            },
            new GatheringNode
            {
                GatherName = "Rough Black Rock", 
                Nodes = [4304411438, 4304373965, 4304411439, 4304373966, 4304373956, 4304373960, 4304373958, 4304373964, 4304373959, 4304373961, 4304373962, 4304373957, 4304410589, 4304410588, 4304410587, 4304373963, 4304373937, 4304373938, 4304373936],
                ItemIds = { Stone_ID, IronOre_ID, DuriumSand_ID }
            },
            new GatheringNode
            {
                GatherName = "Seaweed Tangle", 
                Nodes = [4304373905, 4304373910, 4304373906, 4304373904, 4304373907, 4304373909, 4304373908, 4304373901, 4304373902, 4304373899, 4304373898, 4304373900, 4304373897, 4304373895, 4304373896],
                ItemIds = { Laver_ID, Squid_ID}
            },
            new GatheringNode
            {
                GatherName = "Smooth White Rock", 
                Nodes = [4304326246, 4304326253, 4304326255, 4304326256, 4304326250, 4304410546, 4304410548, 4304410547, 4304326259, 4304326247, 4304326215, 4304326216, 4304326217, 4304326225, 4304326224, 4304326222, 4304326228, 4304411433, 4304411432, 4304411434, 4304411435, 4304411431, 4304326244, 4304326240, 4304326241, 4304326236, 4304326242, 4304326234, 4304410552],
                ItemIds = { Stone_ID, Limestone_ID, Marble_ID }
            },
            new GatheringNode
            {
                GatherName = "Speckled Rock", 
                Nodes = [4304410584, 4304410583, 4304410582, 4304410581, 4304410579, 4304410577, 4304410571, 4304373972, 4304373973, 4304373971, 4304373974, 4304373975, 4304373977, 4304373968, 4304373976, 4304373969, 4304373970, 4304373935, 4304373934],
                ItemIds = { Stone_ID, Leucogranite_ID }
            },
            new GatheringNode
            {
                GatherName = "Stalagmite", 
                Nodes = [4304896869, 4304896870, 4304896868, 4304896874, 4304896873, 4304896872, 4304896877, 4304896875, 4304896876, 4304896871],
                ItemIds = { Stone_ID, EffervescentWater_ID, Spectrine_ID }
            },
            new GatheringNode
            {
                GatherName = "Submerged Sand", 
                Nodes = [4304372618, 4304372620, 4304372615, 4304372617, 4304372621, 4304372613, 4304372623, 4304411873, 4304411874, 4304411875, 4304372933, 4304411882, 4304372934, 4304372935, 4304372932, 4304372625, 4304372624],
                ItemIds = { Sand_ID, Tinsand_ID }
            },
            new GatheringNode
            {
                GatherName = "Sugarcane", 
                Nodes = [4304373891, 4304373892, 4304373887, 4304373884, 4304373885, 4304373886, 4304373874, 4304373876, 4304373877, 4304373879, 4304373878, 4304373880, 4304373881, 4304410699, 4304373893, 4304410696, 4304410698],
                ItemIds = { Vine_ID, Sugarcane_ID}
            },
            new GatheringNode
            {
                GatherName = "Tualong Tree", 
                Nodes = [4304410667, 4304410668, 4304410676, 4304410673, 4304258701, 4304258702, 4304410684, 4304410681, 4304410682, 4304258709, 4304258711, 4304410672, 4304410669, 4304258710, 4304258712, 4304410670, 4304258715, 4304410671, 4304258718, 4304258716, 4304410683, 4304410680, 4304410679, 4304258696, 4304258691, 4304258699, 4304258689, 4304258692, 4304258703, 4304410686, 4304258690, 4304258695, 4304258719, 4304258704, 4304258707],
                ItemIds = { Branch_ID, Log_ID, Resin_ID }
            },
            new GatheringNode
            {
                GatherName = "Wild Parsnip", 
                Nodes = [4304326318, 4304411405, 4304326319, 4304326303, 4304326305, 4304326304, 4304326320, 4304326300, 4304326296, 4304326298, 4304326301, 4304326310, 4304326313, 4304326307, 4304326311, 4304326308, 4304326314, 4304411409, 4304326312, 4304411408, 4304411407, 4304326317, 4304326315, 4304411406, 4304326316],
                ItemIds = { Islewort_ID /* Parsnip Seeds */ }
            },
            new GatheringNode
            {
                GatherName = "Wild Popoto", 
                Nodes = [4304326291, 4304326292, 4304326293, 4304326275, 4304326276, 4304326272, 4304326277, 4304326274, 4304326278, 4304326273, 4304326288, 4304326289, 4304326287, 4304326283, 4304326280, 4304326290, 4304326282, 4304326281, 4304326294, 4304326295],
                ItemIds = { /* Popoto Seeds */}
            },
            new GatheringNode
            {
                GatherName = "Yellowish Rock", 
                Nodes = [4305155135, 4305155133, 4305155137, 4305155136, 4305155134, 4305302599, 4305155132],
                ItemIds = { Stone_ID, YellowCopperOre_ID, GoldOre_ID }
            }
        }
    };
}
