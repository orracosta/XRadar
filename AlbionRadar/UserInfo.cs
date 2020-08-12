using AlbionRada.Player;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionRadar
{
    public partial class UserInfo : MaterialForm
    {
        Options options;
        public UserInfo(Options options)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, (Accent)Primary.BlueGrey500, TextShade.WHITE);

            this.options = options;
            updatePlayerList.Start();
            updatePlayerSelected.Start();

        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            options.hideInfoUser();
        }

        private void updatePlayerList_Tick(object sender, EventArgs e)
        {
            String[] playerlist = new string[lbPlayersInRange.Items.Count];

            lbPlayersInRange.Items.CopyTo(playerlist, 0);

            foreach (String player in playerlist)
            {
                if (options.PlayerHandler.PlayersInRange.Any(x => x.Value.Nickname == player))
                    continue;
                else
                    lbPlayersInRange.Items.Remove(player);
            }

            foreach (var item in options.PlayerHandler.PlayersInRange)
            {
                var p = item.Value;

                if (options.lbTrustAlliances.Items.Contains(p.Alliance) || options.lbTrustGuilds.Items.Contains(p.Guild))
                    continue;

                if (!lbPlayersInRange.Items.Contains(p.Nickname))
                    lbPlayersInRange.Items.Add(p.Nickname);
            }

        }

        private void lbPlayersInRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPlayerInfo();
        }

        private void showPlayerInfo()
        {
            var selectedItem = lbPlayersInRange.SelectedItem;

            if (selectedItem == null)
                return;

            Player player = options.PlayerHandler.PlayersInRange.FirstOrDefault(x => x.Value.Nickname == selectedItem.ToString()).Value;
            if (player != null)
            {

                pFWeapon.Image = PlayerItem.getItemImage(player.Items[0]);
                if (PlayerItem.isTwoHandded(player.Items[0]))
                    pSWeapon.Image = PlayerItem.getItemImage(player.Items[0]);
                else
                    pSWeapon.Image = PlayerItem.getItemImage(player.Items[1]);

                pHead.Image = PlayerItem.getItemImage(player.Items[2]);
                pChest.Image = PlayerItem.getItemImage(player.Items[3]);
                pBoot.Image = PlayerItem.getItemImage(player.Items[4]);
                pBag.Image = PlayerItem.getItemImage(player.Items[5]);
                pCape.Image = PlayerItem.getItemImage(player.Items[6]);
            }
        }

        private void updatePlayerSelected_Tick(object sender, EventArgs e)
        {
            if (lbPlayersInRange.Items.Count > 0 && lbPlayersInRange.SelectedItem == null)
            {
                lbPlayersInRange.SetSelected(0, true);
            }
            else if(lbPlayersInRange.Items.Count <= 0)
            {
                Image image = new Bitmap(1,1);
                pFWeapon.Image = image;
                pSWeapon.Image = image;
                pHead.Image = image;
                pChest.Image = image;
                pBoot.Image = image;
                pBag.Image = image;
                pCape.Image = image;
            }

            showPlayerInfo();
        }
    }
}
