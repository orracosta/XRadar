using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionNetwork2D
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
                //Console.WriteLine("https://render.albiononline.com/v1/item/" + item["UniqueName"] + ".png?size=80");
            }
        }
        public static PlayerItem getItem(int itemID)
        {
            return listItems.FirstOrDefault(i => i.id == itemID);
        }
        public static string getLocalizedNameItem(int itemID)
        {
            PlayerItem item = listItems.FirstOrDefault(i => i.id == itemID);

            if (item != null)
                return item.localizedNames;
            else
                return "NONE";
        }
        public static bool isRanged(int itemID)
        {
            PlayerItem item = listItems.FirstOrDefault(i => i.id == itemID);
            if (item != null && (item.uniqueName.Contains("BOW") || item.uniqueName.Contains("STAFF")))
                return true;
            else
                return false;
        }
        public static bool isTwoHandded(int itemID)
        {
            PlayerItem item = listItems.FirstOrDefault(i => i.id == itemID);
            if (item != null && item.uniqueName.Contains("2H_"))
                return true;
            else
                return false;
        }
        public static Image getItemImage(int itemID)
        {
            PlayerItem item = listItems.FirstOrDefault(i => i.id == itemID);

            if(item == null || itemID == 0)
                return new Bitmap(1, 1);

            TextInfo myTI = new CultureInfo("pt-BR", false).TextInfo;

            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = Path.GetDirectoryName(strExeFilePath);
            var itemImage = Path.Combine(strWorkPath, "Assets\\" + myTI.ToLower(item.uniqueName) + ".png");

            if (File.Exists(itemImage))
            {
                return Image.FromFile(itemImage);
            }
            else
            {
                //System.Net.WebRequest request = System.Net.WebRequest.Create("https://render.albiononline.com/v1/item1/" + item.uniqueName + ".png?size=80");
                //System.Net.WebResponse response = request.GetResponse();
                //Stream responseStream = response.GetResponseStream();

                return new Bitmap(1,1);
            }
        }
    }
}
