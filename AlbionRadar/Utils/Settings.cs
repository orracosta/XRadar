using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlbionNetwork2D
{
    public static class Settings
    {
        private static bool isBeeping = false;
        public static string languageSelected;
        public static List<String> trustGuilds;
        public static List<String> trustAlliances;
        public static bool royalContinent;
        private static bool alertSound;

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

            s.language = languageSelected;

            // Geral
            s.radarPosX = (int)form.nRadarPosX.Value;
            s.radarPosY = (int)form.nRadarPosY.Value;
            s.mapScale = (int)form.nMapScale.Value;
            s.showPlayers = form.cbShowPlayers.Checked;
            s.showMobs = form.cbShowMobs.Checked;
            s.alertSound = form.cbAlertSound.Checked;
            s.showHarvestable = form.cbShowHarvestable.Checked;
            s.showDungeon = form.cbShowDungeon.Checked;
            s.tagAllys = form.cbTagAllys.Checked;
            s.tagEnemies = form.cbTagEnemies.Checked;
            s.rangedMelee = form.cbRangedMelee.Checked;
            s.royalContinent = form.cbRoyalContinent.Checked;

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

            //load variables
            trustGuilds = JsonConvert.DeserializeObject<List<string>>(s.trustGuilds);
            trustAlliances = JsonConvert.DeserializeObject<List<string>>(s.trustAlliances);
            royalContinent = form.cbRoyalContinent.Checked;
            alertSound = form.cbAlertSound.Checked;

            s.Save();

        }
        public static void loadSettings(Options form)
        {
            AppSettings s = new AppSettings();

            trustGuilds = JsonConvert.DeserializeObject<List<string>>(s.trustGuilds);
            trustAlliances = JsonConvert.DeserializeObject<List<string>>(s.trustAlliances);

            foreach (String guild in trustGuilds)
                form.lbTrustGuilds.Items.Add(guild);

            foreach (String alliance in trustAlliances)
                form.lbTrustAlliances.Items.Add(alliance);

            form.pCbDisplayOptions.Controls.OfType<MaterialSkin.Controls.MaterialRadioButton>()
                .FirstOrDefault(r => r.Name == s.displayOption).Checked = true;

            form.selectLanguage.SelectedItem = languageSelected;
            // Geral
            form.nRadarPosX.Value = s.radarPosX;
            form.nRadarPosY.Value = s.radarPosY;
            form.nMapScale.Value = s.mapScale;
            form.cbShowPlayers.Checked = s.showPlayers;
            form.cbShowMobs.Checked = s.showMobs;
            form.cbAlertSound.Checked = s.alertSound;
            form.cbShowHarvestable.Checked = s.showHarvestable;
            form.cbShowDungeon.Checked = s.showDungeon;
            form.cbTagAllys.Checked = s.tagAllys;
            form.cbTagEnemies.Checked = s.tagEnemies;
            form.cbRangedMelee.Checked = s.rangedMelee;
            form.cbRoyalContinent.Checked = s.royalContinent;

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

            royalContinent = form.cbRoyalContinent.Checked;
            alertSound = form.cbAlertSound.Checked;
        }

        public static void loadLanguage()
        {
            AppSettings s = new AppSettings();

            languageSelected = s.language;
        }
        public static void loadLoginSettings(Login form)
        {
            AppSettings s = new AppSettings();

            languageSelected = s.language;

            form.userLogin.Text = s.loginUsername;
            form.passwordLogin.Text = s.loginPassword;
            form.cbRememberPassword.Checked = s.rememberPassword;
        }
        public static void saveLoginSettings(Login form)
        {
            AppSettings s = new AppSettings();

            if (form.cbRememberPassword.Checked)
            {
                s.loginUsername = form.userLogin.Text;
                s.loginPassword = form.passwordLogin.Text;
            }
            else 
            {
                s.loginUsername = "";
                s.loginPassword = "";
            }

            s.rememberPassword = form.cbRememberPassword.Checked;

            s.Save();
        }
        public static void beepSound()
        {
            if(alertSound && !isBeeping)
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
