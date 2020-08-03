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

        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            options.hideInfoUser();
            e.Cancel = true;
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

                if (!lbPlayersInRange.Items.Contains(p.Nickname))
                    lbPlayersInRange.Items.Add(p.Nickname);
            }

        }

        private void lbPlayersInRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = ((ListBox)sender).SelectedItem;

            if (selectedItem == null)
                return;

            Player player = options.PlayerHandler.PlayersInRange.FirstOrDefault(x => x.Value.Nickname == selectedItem.ToString()).Value;
            if (player != null)
            {
                pFWeapon.Text = PlayerItem.getItemName(player.Weapon);
                if (PlayerItem.isTwoHandded(player.Weapon))
                    pSWeapon.Text = PlayerItem.getItemName(player.Weapon);
                else
                    pSWeapon.Text = PlayerItem.getItemName(player.SecundaryWeapon);

                pHelm.Text = PlayerItem.getItemName(player.Helm);
                pArmor.Text = PlayerItem.getItemName(player.Armor);
                pBoot.Text = PlayerItem.getItemName(player.Boot);
                pCape.Text = PlayerItem.getItemName(player.Cape);
            }
        }
    }
}
