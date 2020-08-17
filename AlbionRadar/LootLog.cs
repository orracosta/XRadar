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

namespace AlbionNetwork2D
{
    public partial class LootLog : MaterialForm
    {
        public LootLog()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, (Accent)Primary.BlueGrey500, TextShade.WHITE);

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            PlayerLoot.canAdd = false;
        }
        public void addLog(int id, string user, string item, int amount)
        {
            if(tbfilterNames.Lines.Contains(user) || tbfilterNames.Lines.Count() == 0)
            {
                ListViewItem itemLog = new ListViewItem(user);
                itemLog.Name = id.ToString();
                itemLog.SubItems.Add(item);
                itemLog.SubItems.Add(amount.ToString());

                lvLootLog.Items.Add(itemLog);
            }

            PlayerLoot.listLoot.TryRemove(id, out _);
        }

        private void updateLootLog_Tick(object sender, EventArgs e)
        {
            foreach(var item in PlayerLoot.listLoot)
            {
                PlayerLoot loot = item.Value;
                var id = item.Key;

                if (lvLootLog.Items.ContainsKey(id.ToString()))
                    continue;

                addLog(id, loot.User, loot.Item, loot.Amount);
            }
        }

        private void copyList_Click(object sender, EventArgs e)
        {

            String clipText = string.Empty;
            foreach (ListViewItem item in lvLootLog.Items)
            {
                item.Selected = true;
                clipText += item.SubItems[0].Text;
                clipText += "	" + item.SubItems[1].Text;
                clipText += "	" + item.SubItems[2].Text;
                clipText += Environment.NewLine;
            }
            if (!String.IsNullOrEmpty(clipText))
            {
                Clipboard.SetText(clipText);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            PlayerLoot.listLoot.Clear();
            lvLootLog.Items.Clear();
        }
    }
}
