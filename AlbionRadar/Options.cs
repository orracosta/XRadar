using AlbionNetwork2D.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PhotonPackageParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionNetwork2D
{
    public partial class Options : MaterialForm
    {
        const int MYACTION_HOTKEY_ID = 1;
        const int MYACTION_HOTKEY_ID2 = 2;
        const int MYACTION_HOTKEY_ID3 = 3;

        public Dictionary<string, string> dungeons = new Dictionary<string, string>
        {
            ["portal"] = "Portal",
            ["morgana"] = "Morgana",
            ["heretic"] = "Heretic",
            ["keeper"] = "Keeper",
            ["undead"] = "Undead",
            ["legacy"] = "Legacy"
        };

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        RadarMap radarMap;
        LootLog lootLog;
        UserInfo userInfo;
        PlayerHandler playerHandler = new PlayerHandler();
        MobsHandler mobsHandler = new MobsHandler();
        HarvestableHandler harvestableHandler = new HarvestableHandler();
        DungeonHandler dungeonHandler = new DungeonHandler();
        PhotonParser photonParser;

        Thread photonThread;

        public Options()
        {
            InitializeComponent();

            Settings.loadSettings(this);
            MobInfo.loadMobList();
            PlayerItem.loadItemList();
            //PlayerSpell.loadSpellsList();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, (Accent)Primary.BlueGrey500, TextShade.WHITE);
        }

        private void Options_Load(object sender, EventArgs e)
        {
            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 2, (int)Keys.D1);
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID2, 2, (int)Keys.D2);
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID3, 2, (int)Keys.D3);

            photonParser = new PacketHandler(playerHandler, mobsHandler, harvestableHandler, dungeonHandler);

            if (Settings.languageSelected != "EN")
            {
                dungeons = new Dictionary<string, string>
                {
                    ["portal"] = "Portal",
                    ["morgana"] = "Morgana",
                    ["heretic"] = "Minas",
                    ["keeper"] = "Gigantes",
                    ["undead"] = "Mortos Vivos",
                    ["legacy"] = "Legado"
                };
            }

            radarMap = new RadarMap(this, playerHandler, mobsHandler, harvestableHandler, dungeonHandler);
            radarMap.Show();
            radarMap.Left = (int)nRadarPosX.Value;
            radarMap.Top = (int)nRadarPosY.Value;

            try
            {
                photonThread = new Thread(() => createListener());
                photonThread.Priority = ThreadPriority.Highest;
                photonThread.Start();
            }
            catch (Exception ea)
            {
                Console.WriteLine(ea.ToString());
            }

            AllyListTimer.Start();            
        }
        public PlayerHandler PlayerHandler { get => playerHandler; }

        #region OptionEvents
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Settings.saveSettings(this);
            Environment.Exit(0);
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (lootLog == null || !lootLog.Visible)
            {
                lootLog = new LootLog();
                PlayerLoot.canAdd = true;
                lootLog.Show();
            }
        }
        private void exportAllysButton_Click(object sender, EventArgs e)
        {
            string alliances = JsonConvert.SerializeObject(lbTrustAlliances.Items);
            string guilds = JsonConvert.SerializeObject(lbTrustGuilds.Items);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JSON|*.json";
            if(Settings.languageSelected != "EN")
                saveFileDialog1.Title = "Exportar guildas / alianças amigáveis";
            else
                saveFileDialog1.Title = "Export friendly guilds/alliances";
            saveFileDialog1.FileName = "allys.json";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                StreamWriter writer = new StreamWriter(fs);

                writer.Write("{\n \"guilds\": " + guilds + ", \n \"alliances\": " + alliances + "\n}");
                writer.Close();

                fs.Close();
            }
        }

        private void importAllysButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "JSON|*.json";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    dynamic trustAlliances = JsonConvert.DeserializeObject(fileContent);
                    foreach (var item in trustAlliances)
                    {
                        if (item.Name == "guilds")
                        {
                            lbTrustGuilds.Items.Clear();

                            foreach (var guild in item.Value)
                                lbTrustGuilds.Items.Add(guild.Value);
                        }
                        else if (item.Name == "alliances")
                        {
                            lbTrustAlliances.Items.Clear();

                            foreach (var alliance in item.Value)
                                lbTrustAlliances.Items.Add(alliance.Value);
                        }
                    }

                    Settings.saveSettings(this);
                }
            }
        }
        private void AllyListTimer_Tick(object sender, EventArgs e)
        {
            String[] guildsList = new string[lbGuildsInRange.Items.Count];
            String[] allianceList = new string[lbAlliancesInRange.Items.Count];

            lbGuildsInRange.Items.CopyTo(guildsList, 0);
            lbAlliancesInRange.Items.CopyTo(allianceList, 0);

            foreach (String guild in guildsList)
            {
                if (playerHandler.PlayersInRange.Any(x => x.Value.Guild == guild))
                    continue;
                else
                    lbGuildsInRange.Items.Remove(guild);
            }

            foreach (String alliance in allianceList)
            {
                if (playerHandler.PlayersInRange.Any(x => x.Value.Alliance == alliance))
                    continue;
                else
                    lbAlliancesInRange.Items.Remove(alliance);
            }

            foreach (var item in playerHandler.PlayersInRange)
            {
                var p = item.Value;

                if (p.Guild.Length > 0 && !lbGuildsInRange.Items.Contains(p.Guild) && !lbTrustGuilds.Items.Contains(p.Guild))
                    lbGuildsInRange.Items.Add(p.Guild);

                if (p.Alliance.Length > 0 && !lbAlliancesInRange.Items.Contains(p.Alliance) && !lbTrustAlliances.Items.Contains(p.Alliance))
                    lbAlliancesInRange.Items.Add(p.Alliance);
            }
        }

        private void addGuild_Click(object sender, EventArgs e)
        {
            var guild = lbGuildsInRange.SelectedItem;

            if (guild != null)
            {
                lbTrustGuilds.Items.Add(guild);
                lbGuildsInRange.Items.Remove(guild);

                Settings.saveSettings(this);
            }
        }

        private void addAlliance_Click(object sender, EventArgs e)
        {
            var alliance = lbAlliancesInRange.SelectedItem;

            if (alliance != null)
            {
                lbTrustAlliances.Items.Add(alliance);
                lbAlliancesInRange.Items.Remove(alliance);

                Settings.saveSettings(this);
            }
        }

        private void removeGuild_Click(object sender, EventArgs e)
        {
            var guild = lbTrustGuilds.SelectedItem;

            if (guild != null)
            {
                lbGuildsInRange.Items.Add(guild);
                lbTrustGuilds.Items.Remove(guild);

                Settings.saveSettings(this);
            }
        }

        private void removeAlliance_Click(object sender, EventArgs e)
        {
            var alliance = lbTrustAlliances.SelectedItem;

            if (alliance != null)
            {
                lbAlliancesInRange.Items.Add(alliance);
                lbTrustAlliances.Items.Remove(alliance);

                Settings.saveSettings(this);
            }
        }
        private void MoveRadarValueChanged(object sender, EventArgs e)
        {
            if (radarMap == null)
                return;

            if (radarMap.InvokeRequired)
            {
                radarMap.Invoke((Action)(() =>
                {
                    radarMap.Left = int.Parse(nRadarPosX.Value.ToString());
                    radarMap.Top = int.Parse(nRadarPosY.Value.ToString());
                }));
            }
            else
            {
                radarMap.Left = int.Parse(nRadarPosX.Value.ToString());
                radarMap.Top = int.Parse(nRadarPosY.Value.ToString());
            }
            Settings.saveSettings(this);
        }
        private void showRadar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbShowRadar.Checked)
                radarMap.Show();
            else
                radarMap.Hide();

            Settings.saveSettings(this);
        }
        private void userInfoWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbUserInfoWindow.Checked)
            {
                userInfo = new UserInfo(this);
                userInfo.Show();
            }
            else
            {
                userInfo.Close();
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                if (this.cbUserInfoWindow.Checked)
                {
                    userInfo.Close();
                    this.cbUserInfoWindow.Checked = false;
                }
                else
                {
                    userInfo = new UserInfo(this);
                    this.cbUserInfoWindow.Checked = true;
                    userInfo.Show();
                }
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID2)
            {
                if (this.cbShowRadar.Checked)
                {
                    radarMap.Hide();
                    this.cbShowRadar.Checked = false;
                }
                else
                {
                    radarMap.Show();
                    this.cbShowRadar.Checked = true;
                }
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID3)
            {
                this.cbAlertSound.Checked = !cbAlertSound.Checked;
            }

            base.WndProc(ref m);
        }
        public void hideInfoUser ()
        {
            this.cbUserInfoWindow.Checked = false;
        }
        private void others_CheckedChanged(object sender, EventArgs e)
        {
            Settings.saveSettings(this);
        }
        private void selectLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            Settings.languageSelected = comboBox.SelectedItem.ToString();
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.languageSelected);

            Settings.saveSettings(this);

            if (userInfo != null && !userInfo.IsDisposed)
                userInfo.Close();

            if (lootLog != null && !lootLog.IsDisposed)
                lootLog.Close();

            #if (!DEBUG)
            Application.Restart();
            Environment.Exit(0);
            #endif
        }
        #endregion

        #region photonPackageParser
        private void createListener()
        {
            // Pegue a lista de dispositivos da máquina local.
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
            if (allDevices.Count == 0)
            {
                throw new Exception("No interfaces found! Make sure WinPcap is installed.");
            }

            // Escute todos os dispositivos da maquina local.
            foreach (LivePacketDevice deviceSelected in allDevices.ToList())
            {
                Thread tPackets = new Thread(() =>
                {
                    using (PacketCommunicator communicator = deviceSelected.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
                    {
                        try
                        {
                            // Verifique a camada de link. Caso o adaptador não seja Ethernet, ignore.
                            if (communicator.DataLink.Kind != DataLinkKind.Ethernet)
                                return;

                            // Compila o filtro
                            using (BerkeleyPacketFilter filter = communicator.CreateFilter("ip and udp"))
                                communicator.SetFilter(filter);

                            communicator.ReceivePackets(0, PacketHandler);
                        }
                        catch (Exception e)
                        {
                            // Apenas ignore se der erro
                        }
                    }
                });

                tPackets.Priority = ThreadPriority.Highest;
                tPackets.Start();
            }
        }
        private void PacketHandler(Packet packet)
        {
            try
            {
                IpV4Datagram ip = packet.Ethernet.IpV4;
                UdpDatagram udp = ip.Udp;

                if (udp == null || (udp.SourcePort != 5056 && udp.DestinationPort != 5056))
                {
                    return;
                }

                photonParser.ReceivePacket(udp.Payload.ToArray());
            }
            catch (Exception e)
            {
                return;
            }
        }
        #endregion
    }
}
