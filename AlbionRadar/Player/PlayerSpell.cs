using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class PlayerSpell
    {
        public static List<PlayerSpell> listSpells = new List<PlayerSpell>();

        int id;
        string uniqueName;

        PlayerSpell(int id, string uniqueName)
        {
            this.id = id;
            this.uniqueName = uniqueName;
        }
        public static void loadSpellsList()
        {
            int index = 0;
            dynamic jsonArray = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(Properties.Resources.spells));
            foreach (var item in jsonArray["spells"]["passivespell"])
            {
                listSpells.Add(new PlayerSpell(index, (string)item["@uniquename"]));

                index++;
            }
            foreach (var item in jsonArray["spells"]["activespell"])
            {
                listSpells.Add(new PlayerSpell(index, (string)item["@uniquename"]));

                index++;
            }
            foreach (var item in jsonArray["spells"]["togglespell"])
            {
                listSpells.Add(new PlayerSpell(index, (string)item["@uniquename"]));

                index++;
            }
        }
        public static PlayerSpell getSpell(int id)
        {
            return listSpells.FirstOrDefault(i => i.id == id);
        }
        public static string getSpellImage(int itemID)
        {
            PlayerSpell spell = listSpells.FirstOrDefault(i => i.id == itemID);

            if (spell != null)
                return "https://render.albiononline.com/v1/spell/" + spell.uniqueName + ".png?size=80";
            else
                return "";
        }
    }
}
