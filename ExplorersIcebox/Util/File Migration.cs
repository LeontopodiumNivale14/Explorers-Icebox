using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util
{
    internal static class File_Migration
    {
        public static void UpdateItemConfig()
        {
            if (C.CurrentConfigVersion < 4)
            {
                Svc.Log.Debug("[Config Migration !!] Previous config was below version 4. Updating the config w/ new variables");
                if (!C.ItemGatherAmount.ContainsKey("Cabbage Seed"))
                {
                    C.ItemGatherAmount.Add("Cabbage Seed", 0);
                    C.ItemGatherAmount.Add("Pumpkin Seed", 0);
                    C.ItemGatherAmount.Add("Parsnip Seed", 0);
                    C.ItemGatherAmount.Add("Popoto Seed", 0);
                }

                C.CurrentConfigVersion = 4;
                C.Save();
            }
        }
    }
}
