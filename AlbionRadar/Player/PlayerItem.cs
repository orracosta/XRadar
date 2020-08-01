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
                var localizedName = item["LocalizedNames"] != null ? item["LocalizedNames"]["PT_BR"] : "";
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
    }
}
