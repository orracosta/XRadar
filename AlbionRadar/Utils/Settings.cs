using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlbionRadar
{
    public static class Settings
    {
        private static bool isBeeping = false;

        public static void saveSettings(Options form)
        {
            AppSettings s = new AppSettings();

            String[] guildsList = new string[form.lbTrustGuilds.Items.Count];
            String[] allianceList = new string[form.lbTrustAlliances.Items.Count];

            form.lbTrustGuilds.Items.CopyTo(guildsList, 0);
            form.lbTrustAlliances.Items.CopyTo(allianceList, 0);

            s.trustGuilds = JsonConvert.SerializeObject(guildsList.ToArray());
            s.trustAlliances = JsonConvert.SerializeObject(allianceList.ToArray());

            s.displayOption = form.pCbDisplayOptions.Controls.OfType<MaterialSkin.Controls.MaterialRadioButton>()
                .FirstOrDefault(r => r.Checked).Name;

            // Geral
            s.radarPosX = (int)form.nRadarPosX.Value;
            s.radarPosY = (int)form.nRadarPosY.Value;
            s.showPlayers = form.cbShowPlayers.Checked;
            s.showMobs = form.cbShowMobs.Checked;
            s.alertSound = form.cbAlertSound.Checked;
            s.showHarvestable = form.cbShowHarvestable.Checked;
            s.showDungeon = form.cbShowDungeon.Checked;
            s.tagAllys = form.cbTagAllys.Checked;
            s.tagEnemies = form.cbTagEnemies.Checked;
            s.rangedMelee = form.cbRangedMelee.Checked;

            // Coleta - Tier
            s.showTier1 = form.cbShowTier1.Checked;
            s.showTier2 = form.cbShowTier2.Checked;
            s.showTier3 = form.cbShowTier3.Checked;
            s.showTier4 = form.cbShowTier4.Checked;
            s.showTier5 = form.cbShowTier5.Checked;
            s.showTier6 = form.cbShowTier6.Checked;
            s.showTier7 = form.cbShowTier7.Checked;
            s.showTier8 = form.cbShowTier8.Checked;

            // Coleta - Recursos
            s.mobFilterFibra = form.cbMobFilterFibra.Checked;
            s.mobFilterPedra = form.cbMobFilterPedra.Checked;
            s.mobFilterPelego = form.cbMobFilterPelego.Checked;
            s.mobFilterMinerio = form.cbMobFilterMinerio.Checked;
            s.mobFilterMadeira = form.cbMobFilterMadeira.Checked;

            s.resourceFilterFibra = form.cbResourceFilterFibra.Checked;
            s.resourceFilterPedra = form.cbResourceFilterPedra.Checked;
            s.resourceFilterPelego = form.cbResourceFilterPelego.Checked;
            s.resourceFilterMinerio = form.cbResourceFilterMinerio.Checked;
            s.resourceFilterMadeira = form.cbResourceFilterMadeira.Checked;
            s.resourceFilterAmount = form.cbResourceFilterAmount.Checked;

            s.Save();

        }
        public static void loadSettings(Options form)
        {
            AppSettings s = new AppSettings();

            foreach (String guild in JsonConvert.DeserializeObject<List<string>>(s.trustGuilds))
                form.lbTrustGuilds.Items.Add(guild);

            foreach (String alliance in JsonConvert.DeserializeObject<List<string>>(s.trustAlliances))
                form.lbTrustAlliances.Items.Add(alliance);

            form.pCbDisplayOptions.Controls.OfType<MaterialSkin.Controls.MaterialRadioButton>()
                .FirstOrDefault(r => r.Name == s.displayOption).Checked = true;

            // Geral
            form.nRadarPosX.Value = s.radarPosX;
            form.nRadarPosY.Value = s.radarPosY;
            form.cbShowPlayers.Checked = s.showPlayers;
            form.cbShowMobs.Checked = s.showMobs;
            form.cbAlertSound.Checked = s.alertSound;
            form.cbShowHarvestable.Checked = s.showHarvestable;
            form.cbShowDungeon.Checked = s.showDungeon;
            form.cbTagAllys.Checked = s.tagAllys;
            form.cbTagEnemies.Checked = s.tagEnemies;
            form.cbRangedMelee.Checked = s.rangedMelee;

            // Coleta - Tier
            form.cbShowTier1.Checked = s.showTier1;
            form.cbShowTier2.Checked = s.showTier2;
            form.cbShowTier3.Checked = s.showTier3;
            form.cbShowTier4.Checked = s.showTier4;
            form.cbShowTier5.Checked = s.showTier5;
            form.cbShowTier6.Checked = s.showTier6;
            form.cbShowTier7.Checked = s.showTier7;
            form.cbShowTier8.Checked = s.showTier8;

            // Coleta - Recursos
            form.cbMobFilterFibra.Checked = s.mobFilterFibra;
            form.cbMobFilterPedra.Checked = s.mobFilterPedra;
            form.cbMobFilterPelego.Checked = s.mobFilterPelego;
            form.cbMobFilterMinerio.Checked = s.mobFilterMinerio;
            form.cbMobFilterMadeira.Checked = s.mobFilterMadeira;

            form.cbResourceFilterFibra.Checked = s.resourceFilterFibra;
            form.cbResourceFilterPedra.Checked = s.resourceFilterPedra;
            form.cbResourceFilterPelego.Checked = s.resourceFilterPelego;
            form.cbResourceFilterMinerio.Checked = s.resourceFilterMinerio;
            form.cbResourceFilterMadeira.Checked = s.resourceFilterMadeira;
            form.cbResourceFilterAmount.Checked = s.resourceFilterAmount;
        }

        public static void needBeepSound(String guild, String alliance)
        {
            AppSettings s = new AppSettings();

            List<String> guildList = JsonConvert.DeserializeObject<List<string>>(s.trustGuilds);
            List<String> AllianceList = JsonConvert.DeserializeObject<List<string>>(s.trustGuilds);

            if(s.alertSound && !isBeeping)
            {
                if (!guildList.Contains(guild) || !alliance.Contains(alliance))
                {
                    isBeeping = true;

                    new Thread(() =>
                    {
                        Console.Beep(500, 500);
                        Thread.Sleep(2000);

                        isBeeping = false;
                    }).Start();
                }
            }
        }
    }
}
