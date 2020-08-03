using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class PlayerItem
    {
        public static List<PlayerItem> listItems = new List<PlayerItem>();

        int id;
        string uniqueName;
        string localizedNames;

        PlayerItem(int id, string uniqueName, string localizedNames)
        {
            this.id = id;
            this.uniqueName = uniqueName;
            this.localizedNames = localizedNames;
        }
        public static void loadItemList()
        {
            dynamic jsonArray = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(Properties.Resources.items));
            foreach (var item in jsonArray)
            {
                var localizedName = item["LocalizedNames"] != null ? item["LocalizedNames"]["PT-BR"] : "";
                listItems.Add(new PlayerItem((int)item["Index"], (string)item["UniqueName"], (string)localizedName));
            }
        }
        public static PlayerItem getItem(int itemID)
        {
            return listItems.FirstOrDefault(i => i.id == itemID);
        }
        public static bool isRanged(int itemID)
        {
            PlayerItem item = listItems.FirstOrDefault(i => i.id == itemID);
            if (item.uniqueName.Contains("BOW") || item.uniqueName.Contains("STAFF"))
                return true;
            else
                return false;
        }
        public static bool isTwoHandded(int itemID)
        {
            PlayerItem item = listItems.FirstOrDefault(i => i.id == itemID);
            if (item.uniqueName.Contains("2H_"))
                return true;
            else
                return false;
        }
        public static string getItemName(int itemID)
        {
            PlayerItem item = listItems.FirstOrDefault(i => i.id == itemID);
            string tier;
            string enchant;

            if (itemID == 0)
                return "Nenhum Item";

            if (item.uniqueName.Contains("T1_"))
                tier = "T1";
            else if (item.uniqueName.Contains("T2_"))
                tier = "T2";
            else if (item.uniqueName.Contains("T3_"))
                tier = "T3";
            else if (item.uniqueName.Contains("T4_"))
                tier = "T4";
            else if (item.uniqueName.Contains("T5_"))
                tier = "T5";
            else if (item.uniqueName.Contains("T6_"))
                tier = "T6";
            else if (item.uniqueName.Contains("T7_"))
                tier = "T7";
            else if (item.uniqueName.Contains("T8_"))
                tier = "T8";
            else
                tier = "";

            if (item.uniqueName.Contains("@1"))
                enchant = ".1";
            else if (item.uniqueName.Contains("@2"))
                enchant = ".2";
            else if (item.uniqueName.Contains("@3"))
                enchant = ".3";
            else
                enchant = "";

            if (tier == "" && enchant == "")
                return item.localizedNames;
            else
                return "[" + tier + enchant + "] " + item.localizedNames;
        }
    }
}
