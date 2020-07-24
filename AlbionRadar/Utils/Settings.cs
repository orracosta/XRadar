using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    public static class Settings
    {
        public static void saveSettings(Options form)
        {
            AppSettings s = new AppSettings();

            String[] guildsList = new string[form.lbTrustGuilds.Items.Count];
            String[] allianceList = new string[form.lbTrustAlliances.Items.Count];

            form.lbTrustGuilds.Items.CopyTo(guildsList, 0);
            form.lbTrustAlliances.Items.CopyTo(allianceList, 0);

            s.trustGuilds = JsonConvert.SerializeObject(guildsList.ToArray());
            s.TrustAlliances = JsonConvert.SerializeObject(allianceList.ToArray());

            s.radarPosX = (int)form.nRadarPosX.Value;
            s.radarPosY = (int)form.nRadarPosY.Value;
            s.showRadar = form.cbShowRadar.Checked;

            s.Save();

        }
        public static void loadSettings(Options form)
        {
            AppSettings s = new AppSettings();

            foreach (String guild in JsonConvert.DeserializeObject<List<string>>(s.trustGuilds)) form.lbTrustGuilds.Items.Add(guild);
            foreach (String alliance in JsonConvert.DeserializeObject<List<string>>(s.TrustAlliances)) form.lbTrustAlliances.Items.Add(alliance);

            form.nRadarPosX.Value = s.radarPosX;
            form.nRadarPosY.Value = s.radarPosY;
            form.cbShowRadar.Checked = s.showRadar;
        }
    }
}
