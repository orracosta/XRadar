using AlbionRada.Player;
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionRadar
{
    public partial class Options : MaterialForm
    {
        RadarMap radarMap = new RadarMap();
        PlayerHandler playerHandler = new PlayerHandler();
        PhotonParser photonParser;

        public Options()
        {

            InitializeComponent();
            Settings.loadSettings(this);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, (Accent)Primary.BlueGrey500, TextShade.WHITE);

            radarMap.Show();

            radarMap.Left = (int)nRadarPosX.Value;
            radarMap.Top = (int)nRadarPosY.Value;
        }
        private void Options_Load(object sender, EventArgs e)
        {
            photonParser = new PacketHandler(playerHandler);

            Thread photonThread = new Thread(() => createListener());
            photonThread.Priority = ThreadPriority.Highest;
            photonThread.Start();

            Thread radarThread = new Thread(() => drawerThread());
            radarThread.Priority = ThreadPriority.Highest;
            radarThread.Start();

            AllyListTimer.Start();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        
        #region RadarMap
        private void drawerThread()
        {
            Single localX;
            Single localY;

            Pen linePen = new Pen(Color.FromArgb(155, 255, 255, 0), 2);
            Font font = new Font("Calibri", 3f, FontStyle.Regular);
            
            float scale = 2.6f;
            int HEIGHT = 350,
                WIDTH = 350;

            Bitmap bitmap = new Bitmap(WIDTH, HEIGHT);
            bitmap.SetResolution(100, 100);

            while (true)
            {
                bitmap = new Bitmap(WIDTH, HEIGHT);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.Transparent);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    g.InterpolationMode = InterpolationMode.High;

                    g.TranslateTransform(WIDTH / 2, HEIGHT / 2);
                    g.FillEllipse(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), -(WIDTH - 5) / 2, -(HEIGHT - 5) / 2, WIDTH - 5, HEIGHT - 5);
                    g.FillEllipse(Brushes.Yellow, -2, -2, 4, 4);
                    g.DrawEllipse(linePen, -(WIDTH - 250) / 2, -(HEIGHT - 250) / 2, (WIDTH - 250), (HEIGHT - 250));
                    g.DrawEllipse(linePen, -(WIDTH - 125) / 2, -(HEIGHT - 125) / 2, (WIDTH - 125), (HEIGHT - 125));
                    g.DrawEllipse(linePen, -(WIDTH - 4) / 2, -(HEIGHT - 4) / 2, WIDTH - 4, HEIGHT - 4);

                    g.ScaleTransform(scale, scale);

                    // Se for para mostrar os players
                    if (cbShowPlayers.Checked)
                    {
                        localX = playerHandler.localPlayerPosX();
                        localY = playerHandler.localPlayerPosY();

                        List<Player> pList = new List<Player>();
                        lock (this.playerHandler.PlayersInRange)
                        {
                            try
                            {
                                pList = this.playerHandler.PlayersInRange.ToList();
                            }
                            catch (Exception e2) { }
                        }

                        foreach (Player p in pList)
                        {
                            if (p == null)
                                continue;

                            Single hX = -1 * p.PosX + localX;
                            Single hY = p.PosY - localY;

                            Brush playerBrush = !playerHandler.playerIsMounted(p.Id) ? Brushes.Red : Brushes.IndianRed;

                            if (lbTrustGuilds.Items.Contains(p.Guild) || lbTrustAlliances.Items.Contains(p.Alliance))
                                playerBrush = !playerHandler.playerIsMounted(p.Id) ? Brushes.Green : Brushes.DarkOliveGreen;

                            g.FillEllipse(playerBrush, hX, hY, 3f, 3f);

                            g.TranslateTransform(hX, hY);
                            g.RotateTransform(135f);

                            g.DrawString(p.Nickname, font, Brushes.White, 2, -5);

                            g.RotateTransform(-135f);
                            g.TranslateTransform(-hX, -hY);
                        }
                    }

                    if (radarMap.InvokeRequired)
                    {
                        radarMap.Invoke((Action)(() =>
                        {
                            radarMap.SelectBitmap(RadarMap.RotateImage(bitmap, 225f));
                        }));
                    }
                }
                
                Thread.Sleep(50);
            }
        }
        #endregion

        #region OptionEvents
        private void AllyListTimer_Tick(object sender, EventArgs e)
        {
            String[] guildsList = new string[lbGuildsInRange.Items.Count];
            String[] allianceList = new string[lbAlliancesInRange.Items.Count];

            lbGuildsInRange.Items.CopyTo(guildsList, 0);
            lbAlliancesInRange.Items.CopyTo(allianceList, 0);

            foreach (String guild in guildsList)
            {
                if (playerHandler.PlayersInRange.FirstOrDefault(x => x.Guild == guild) != null)
                    continue;
                else
                    lbGuildsInRange.Items.Remove(guild);
            }

            foreach (String alliance in allianceList)
            {
                if (playerHandler.PlayersInRange.FirstOrDefault(x => x.Alliance == alliance) != null)
                    continue;
                else
                    lbAlliancesInRange.Items.Remove(alliance);
            }

            playerHandler.PlayersInRange.ForEach(p =>
            {
                if (p.Guild.Length > 0 && !lbGuildsInRange.Items.Contains(p.Guild) && !lbTrustGuilds.Items.Contains(p.Guild))
                    lbGuildsInRange.Items.Add(p.Guild);

                if (p.Alliance.Length > 0 && !lbAlliancesInRange.Items.Contains(p.Alliance) && !lbTrustAlliances.Items.Contains(p.Alliance))
                    lbAlliancesInRange.Items.Add(p.Alliance);
            });
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
        private void others_CheckedChanged(object sender, EventArgs e)
        {
            Settings.saveSettings(this);
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

                            // Compile o filtro
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
            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;

            if (udp == null || (udp.SourcePort != 5056 && udp.DestinationPort != 5056))
            {
                return;
            }

            photonParser.ReceivePacket(udp.Payload.ToArray());
        }
        #endregion

        
    }
}
