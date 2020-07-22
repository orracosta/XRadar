using AlbionRada.Player;
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
    public partial class Options : Form
    {
        RadarMap radarMap = new RadarMap();
        PlayerHandler playerHandler = new PlayerHandler();
        PhotonParser photonParser;

        public Options()
        {
            InitializeComponent();

            radarMap.Show();
            radarMap.Left = 50;
            radarMap.Top = 50;
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

        }
        #region RadarMap
        private void drawerThread()
        {
            Single localX;
            Single localY;

            Pen linePen = new Pen(Color.FromArgb(155, 255, 255, 0), 2);
            Font font = new Font("Arial", 2.8f, FontStyle.Regular);
            
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
                    if (true)
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
