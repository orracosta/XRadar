using AlbionNetwork2D.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionNetwork2D
{
    public partial class RadarMap : PerPixelAlphaForm
    {
        Thread radarThread;
        Options options;
        PlayerHandler playerHandler;
        MobsHandler mobsHandler;
        HarvestableHandler harvestableHandler;
        DungeonHandler dungeonHandler;

        #region Radar Variables
        SolidBrush[] harvestBrushes = {
                new SolidBrush(Color.FromArgb(200, 52, 52, 52)),
                new SolidBrush(Color.FromArgb(200, 99, 83, 73)),
                new SolidBrush(Color.FromArgb(200, 63, 81, 49)),
                new SolidBrush(Color.FromArgb(200, 48, 54, 98)),
                new SolidBrush(Color.FromArgb(200, 119, 34, 26)),
                new SolidBrush(Color.FromArgb(200, 192, 107, 42)),
                new SolidBrush(Color.FromArgb(200, 209, 176, 68)),
                new SolidBrush(Color.FromArgb(200, 208, 208, 208))
            };

        Player localPlayer;

        int localScale = 0;

        float scale = 2.6f;
        int HEIGHT = 350,
            WIDTH = 350;

        Bitmap bitmap = new Bitmap(350, 350);
        #endregion

        Pen linePen = new Pen(Color.FromArgb(155, 255, 255, 0), 2);
        Font font = new Font("Calibri", 3.5f, FontStyle.Regular);


        public RadarMap(Options options, PlayerHandler playerHandler, MobsHandler mobsHandler, HarvestableHandler harvestableHandler, DungeonHandler dungeonHandler)
        {
            this.options = options;
            this.playerHandler = playerHandler;
            this.mobsHandler = mobsHandler;
            this.harvestableHandler = harvestableHandler;
            this.dungeonHandler = dungeonHandler;

            InitializeComponent();
        }
        private void RadarMap_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;

            try
            {
                radarThread = new Thread(() =>
                {
                    long timestamp;
                    long timeElapsed;

                    while (true)
                    {
                        timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                        if (options.cbShowRadar.Checked)
                            drawerThread();

                        timeElapsed = DateTimeOffset.Now.ToUnixTimeMilliseconds() - timestamp;

                        if (timeElapsed < 40)
                            Thread.Sleep(40 - (int)timeElapsed);
                    }
                });

                radarThread.Priority = ThreadPriority.Highest;
                radarThread.Start();
            }
            catch (Exception ea)
            {
                Console.WriteLine(ea.ToString());
            }
        }
        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }
        #region RadarMap
        private void drawerThread()
        {
            if (options.nMapScale.Value == 1)
            {
                HEIGHT = 200;
                WIDTH = 200;
                scale = 1.6f;
            }
            else
            {
                scale = 2.6f;
                HEIGHT = 350;
                WIDTH = 350;
            }

            if (localScale != (int)options.nMapScale.Value)
            {
                localScale = (int)options.nMapScale.Value;
                bitmap.SetResolution(100, 100);
                bitmap = new Bitmap(WIDTH, HEIGHT);
            }

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.InterpolationMode = InterpolationMode.High;

                g.TranslateTransform(WIDTH / 2, HEIGHT / 2);
                g.FillEllipse(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), -(WIDTH - 5) / 2, -(HEIGHT - 5) / 2, WIDTH - 5, HEIGHT - 5);
                g.FillEllipse(Brushes.Yellow, -2, -2, 4, 4);

                if (options.nMapScale.Value == 1)
                {
                    g.DrawEllipse(linePen, -(WIDTH - 135) / 2, -(HEIGHT - 135) / 2, (WIDTH - 135), (HEIGHT - 135));
                    g.DrawEllipse(linePen, -(WIDTH - 65) / 2, -(HEIGHT - 65) / 2, (WIDTH - 65), (HEIGHT - 65));
                    g.DrawEllipse(linePen, -(WIDTH - 4) / 2, -(HEIGHT - 4) / 2, WIDTH - 4, HEIGHT - 4);
                }
                else
                {
                    g.DrawEllipse(linePen, -(WIDTH - 250) / 2, -(HEIGHT - 250) / 2, (WIDTH - 250), (HEIGHT - 250));
                    g.DrawEllipse(linePen, -(WIDTH - 125) / 2, -(HEIGHT - 125) / 2, (WIDTH - 125), (HEIGHT - 125));
                    g.DrawEllipse(linePen, -(WIDTH - 4) / 2, -(HEIGHT - 4) / 2, WIDTH - 4, HEIGHT - 4);
                }

                g.ScaleTransform(scale, scale);

                localPlayer = playerHandler.getLocalPlayer();

                if (options.cbShowHarvestable.Checked)
                {
                    foreach (var item in harvestableHandler.HarvestableList)
                    {
                        var h = item.Value;

                        if (h == null)
                            continue;

                        if (h.Size == 0)
                            continue;

                        TextInfo myTI = new CultureInfo("pt-BR", false).TextInfo;

                        String cbName = "cbShowTier" + h.Tier;
                        String cbEnch = "cbShowEnch" + h.Charges;
                        String cbNameFilter = "cbResourceFilter" + myTI.ToTitleCase(h.getMapInfo());

                        var canShowTier = options.pTierList.Controls.OfType<MaterialSkin.Controls.MaterialCheckBox>()
                            .FirstOrDefault(r => r.Name == cbName);

                        var canShowEnch = options.pEnchList.Controls.OfType<MaterialSkin.Controls.MaterialCheckBox>()
                            .FirstOrDefault(r => r.Name == cbEnch);

                        var canShowResource = options.pFilterResource.Controls.OfType<MaterialSkin.Controls.MaterialCheckBox>()
                            .FirstOrDefault(r => r.Name == cbNameFilter);

                        if (canShowTier != null && !canShowTier.Checked)
                            continue;

                        if (canShowEnch != null && !canShowEnch.Checked)
                            continue;

                        if (canShowResource != null && !canShowResource.Checked)
                            continue;

                        String iconName = h.getMapInfo() + "_" + h.Charges;
                        Bitmap iconImage = (Bitmap)Resources.ResourceManager.GetObject(iconName);

                        if (iconImage == null)
                            continue;

                        float iconWidth = iconImage.Width / 20;
                        float iconHeight = iconImage.Height / 20;

                        Single hX = -1 * h.PosX + localPlayer.PosX;
                        Single hY = h.PosY - localPlayer.PosY;

                        if (options.cbResourceFilterAmount.Checked && h.Tier != 1)
                        {
                            g.TranslateTransform(hX, hY);
                            g.RotateTransform(135f);

                            int charges = (h.Size * HarvestableSizes.charges[h.Tier]);
                            int size = charges > 9 ? charges : HarvestableSizes.sizes[h.Tier];

                            g.DrawString(charges + "/" + size, font, Brushes.White, 5, -3.5f);

                            g.RotateTransform(-135f);
                            g.TranslateTransform(-hX, -hY);
                        }

                        g.FillEllipse(harvestBrushes[h.Tier - 1], (float)(hX - iconHeight / 2.4), (float)(hY - iconHeight / 2.4), (float)(iconWidth / 1.2), (float)(iconHeight / 1.2));
                        g.DrawImage(iconImage, hX - iconHeight / 2, hY - iconHeight / 2, iconWidth, iconHeight);
                    }
                }

                if (options.cbShowMobs.Checked || options.cbShowHarvestable.Checked)
                {
                    foreach (var item in mobsHandler.MobList)
                    {
                        var m = item.Value;

                        if (m == null)
                            continue;

                        Single hX = -1 * m.PosX + localPlayer.PosX;
                        Single hY = m.PosY - localPlayer.PosY;

                        if (options.cbShowMobs.Checked)
                        {
                            Brush mobBrush = Brushes.LightGray;
                            g.FillEllipse(mobBrush, hX, hY, 1.5f, 1.5f);
                        }

                        if (options.cbShowHarvestable.Checked && m.MobInfo != null)
                        {
                            TextInfo myTI = new CultureInfo("pt-BR", false).TextInfo;

                            String cbName = "cbShowTier" + m.MobInfo.Tier;
                            String cbEnch = "cbShowEnch" + m.EnchantmentLevel;
                            String cbNameFilter = "cbMobFilter" + myTI.ToTitleCase(m.MobInfo.getMapInfo(m.TypeId));

                            var canShowTier = options.pTierList.Controls.OfType<MaterialSkin.Controls.MaterialCheckBox>()
                                .FirstOrDefault(r => r.Name == cbName);

                            var canShowEnch = options.pEnchList.Controls.OfType<MaterialSkin.Controls.MaterialCheckBox>()
                                .FirstOrDefault(r => r.Name == cbEnch);

                            var canShowResource = options.pFilterMobResource.Controls.OfType<MaterialSkin.Controls.MaterialCheckBox>()
                                .FirstOrDefault(r => r.Name == cbNameFilter);

                            if (canShowTier != null && !canShowTier.Checked)
                                continue;

                            if (canShowEnch != null && !canShowEnch.Checked)
                                continue;

                            if (canShowResource != null && !canShowResource.Checked)
                                continue;

                            String iconName = m.MobInfo.getMapInfo(m.TypeId) + "_" + m.EnchantmentLevel;
                            Bitmap iconImage = (Bitmap)Resources.ResourceManager.GetObject(iconName);

                            if (iconImage == null)
                                continue;

                            float iconWidth = iconImage.Width / 20;
                            float iconHeight = iconImage.Height / 20;

                            string mobName = null;

                            if (m.MobInfo.Dangerstate == "elite")
                                mobName = "Elite";
                            else if (m.MobInfo.Dangerstate == "veteran")
                                mobName = "Veteran";
                            else if (m.MobInfo.Tier > 6 && (m.MobInfo.HarvestableMobType == HarvestableType.HIDE_FOREST || m.MobInfo.HarvestableMobType == HarvestableType.HIDE_STEPPE))
                                mobName = "Big";

                            if (mobName != null)
                            {
                                g.TranslateTransform(hX, hY);
                                g.RotateTransform(135f);

                                g.DrawString(mobName, font, Brushes.White, 5, -3.5f);

                                g.RotateTransform(-135f);
                                g.TranslateTransform(-hX, -hY);
                            }

                            g.FillEllipse(harvestBrushes[m.MobInfo.Tier - 1], (float)(hX - iconHeight / 2.4), (float)(hY - iconHeight / 2.4), (float)(iconWidth / 1.2), (float)(iconHeight / 1.2));
                            g.DrawImage(iconImage, hX - iconHeight / 2, hY - iconHeight / 2, iconWidth, iconHeight);
                        }
                    }
                }

                if (options.cbShowDungeon.Checked)
                {
                    foreach (var item in dungeonHandler.DungeonList)
                    {
                        var d = item.Value;

                        Single hX = -1 * d.PosX + localPlayer.PosX;
                        Single hY = d.PosY - localPlayer.PosY;

                        var type = d.getType();
                        string typeName = "group";

                        if (type == "SOLO")
                            typeName = "solo";
                        else if (type == "CORRUPT")
                            typeName = "corrupt";
                        else if (type == "ELITE")
                            typeName = "elite";

                        String iconName = "dg_" + typeName;
                        Bitmap iconImage = (Bitmap)Resources.ResourceManager.GetObject(iconName);

                        if (iconImage == null)
                            continue;

                        if (type == "GROUP")
                        {
                            string dungeonName;

                            if (item.Value.Type.Contains("_MOR"))
                                dungeonName = options.dungeons["morgana"];
                            else if (item.Value.Type.Contains("_UND"))
                                dungeonName = options.dungeons["undead"];
                            else if (item.Value.Type.Contains("_KPR"))
                                dungeonName = options.dungeons["keeper"];
                            else if (item.Value.Type.Contains("_HER"))
                                dungeonName = options.dungeons["heretic"];
                            else if (item.Value.Type.Contains("_LEGACY"))
                                dungeonName = options.dungeons["legacy"];
                            else
                                dungeonName = options.dungeons["portal"];

                            g.TranslateTransform(hX, hY);
                            g.RotateTransform(135f);

                            g.DrawString(dungeonName, font, Brushes.White, 4, -3.5f);

                            g.RotateTransform(-135f);
                            g.TranslateTransform(-hX, -hY);
                        }

                        float iconWidth = iconImage.Width / 4;
                        float iconHeight = iconImage.Height / 4;

                        g.DrawImage(iconImage, hX - iconHeight / 2, hY - iconHeight / 2, iconWidth, iconHeight);

                    }
                }

                if (options.cbShowPlayers.Checked)
                {
                    foreach (var item in playerHandler.PlayersInRange)
                    {
                        var p = item.Value;

                        Single hX = -1 * p.PosX + localPlayer.PosX;
                        Single hY = p.PosY - localPlayer.PosY;

                        Brush playerBrush = !playerHandler.PlayerIsMounted(p.Id) ? Brushes.Red : Brushes.IndianRed;

                        bool isAlly = false;

                        if (options.lbTrustGuilds.Items.Contains(p.Guild) || options.lbTrustAlliances.Items.Contains(p.Alliance))
                            isAlly = true;

                        if (localPlayer.Alliance.Length > 1 && localPlayer.Alliance == p.Alliance || localPlayer.Guild.Length > 1 && localPlayer.Guild == p.Guild)
                            isAlly = true;

                        if (isAlly)
                        {
                            playerBrush = !playerHandler.PlayerIsMounted(p.Id) ? Brushes.Green : Brushes.DarkOliveGreen;
                        }
                        else
                        {
                            if (options.cbRoyalContinent.Checked && playerHandler.isAllyRoyal(p.Faction))
                            {
                                playerBrush = !playerHandler.PlayerIsMounted(p.Id) ? Brushes.Green : Brushes.DarkOliveGreen;
                                isAlly = true;
                            }
                            else
                            {
                                if (options.cbRangedMelee.Checked)
                                {
                                    if (PlayerItem.isRanged(p.Items[0]))
                                        playerBrush = !playerHandler.PlayerIsMounted(p.Id) ? Brushes.Yellow : Brushes.Orange;
                                }
                            }
                        }

                        g.FillEllipse(playerBrush, hX, hY, 3f, 3f);

                        if (!options.cbNone.Checked && (isAlly && options.cbTagAllys.Checked || !isAlly && options.cbTagEnemies.Checked))
                        {
                            g.TranslateTransform(hX, hY);
                            g.RotateTransform(135f);

                            if (options.cbName.Checked)
                            {
                                g.DrawString(p.Nickname, font, Brushes.White, 2, -5.5f);
                            }
                            else
                            {
                                if (p.Alliance != "")
                                    g.DrawString("[" + p.Alliance + "]" + p.Guild, font, Brushes.White, 2, -5.5f);
                                else
                                    g.DrawString(p.Guild, font, Brushes.White, 2, -5.5f);
                            }

                            g.RotateTransform(-135f);
                            g.TranslateTransform(-hX, -hY);
                        }
                    }
                }

                if (this.InvokeRequired)
                {
                    this.Invoke((Action)(() =>
                    {
                        Task t = this.SelectBitmap(RadarMap.RotateImage(bitmap, 225f));
                        t.Wait();
                    }));
                }

            }
        }
        #endregion
    }
}
