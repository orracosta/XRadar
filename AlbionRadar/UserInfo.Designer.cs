namespace AlbionNetwork2D
{
    partial class UserInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            this.lbPlayersInRange = new System.Windows.Forms.ListBox();
            this.materialDivider3 = new MaterialSkin.Controls.MaterialDivider();
            this.updatePlayerList = new System.Windows.Forms.Timer(this.components);
            this.updatePlayerSelected = new System.Windows.Forms.Timer(this.components);
            this.pBootSpell = new System.Windows.Forms.PictureBox();
            this.pChestSpell = new System.Windows.Forms.PictureBox();
            this.pHeadSpell = new System.Windows.Forms.PictureBox();
            this.pWeaponSpell3 = new System.Windows.Forms.PictureBox();
            this.pWeaponSpell2 = new System.Windows.Forms.PictureBox();
            this.pWeaponSpell1 = new System.Windows.Forms.PictureBox();
            this.pBag = new System.Windows.Forms.PictureBox();
            this.pCape = new System.Windows.Forms.PictureBox();
            this.pBoot = new System.Windows.Forms.PictureBox();
            this.pChest = new System.Windows.Forms.PictureBox();
            this.pHead = new System.Windows.Forms.PictureBox();
            this.pSWeapon = new System.Windows.Forms.PictureBox();
            this.pFWeapon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBootSpell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChestSpell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHeadSpell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeaponSpell3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeaponSpell2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeaponSpell1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSWeapon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pFWeapon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPlayersInRange
            // 
            resources.ApplyResources(this.lbPlayersInRange, "lbPlayersInRange");
            this.lbPlayersInRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.lbPlayersInRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPlayersInRange.ForeColor = System.Drawing.Color.White;
            this.lbPlayersInRange.FormattingEnabled = true;
            this.lbPlayersInRange.Name = "lbPlayersInRange";
            this.lbPlayersInRange.SelectedIndexChanged += new System.EventHandler(this.lbPlayersInRange_SelectedIndexChanged);
            // 
            // materialDivider3
            // 
            resources.ApplyResources(this.materialDivider3, "materialDivider3");
            this.materialDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider3.Depth = 0;
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            // 
            // updatePlayerList
            // 
            this.updatePlayerList.Tick += new System.EventHandler(this.updatePlayerList_Tick);
            // 
            // updatePlayerSelected
            // 
            this.updatePlayerSelected.Interval = 1000;
            this.updatePlayerSelected.Tick += new System.EventHandler(this.updatePlayerSelected_Tick);
            // 
            // pBootSpell
            // 
            resources.ApplyResources(this.pBootSpell, "pBootSpell");
            this.pBootSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBootSpell.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pBootSpell.Name = "pBootSpell";
            this.pBootSpell.TabStop = false;
            // 
            // pChestSpell
            // 
            resources.ApplyResources(this.pChestSpell, "pChestSpell");
            this.pChestSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pChestSpell.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pChestSpell.Name = "pChestSpell";
            this.pChestSpell.TabStop = false;
            // 
            // pHeadSpell
            // 
            resources.ApplyResources(this.pHeadSpell, "pHeadSpell");
            this.pHeadSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pHeadSpell.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pHeadSpell.Name = "pHeadSpell";
            this.pHeadSpell.TabStop = false;
            // 
            // pWeaponSpell3
            // 
            resources.ApplyResources(this.pWeaponSpell3, "pWeaponSpell3");
            this.pWeaponSpell3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pWeaponSpell3.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pWeaponSpell3.Name = "pWeaponSpell3";
            this.pWeaponSpell3.TabStop = false;
            // 
            // pWeaponSpell2
            // 
            resources.ApplyResources(this.pWeaponSpell2, "pWeaponSpell2");
            this.pWeaponSpell2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pWeaponSpell2.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pWeaponSpell2.Name = "pWeaponSpell2";
            this.pWeaponSpell2.TabStop = false;
            // 
            // pWeaponSpell1
            // 
            resources.ApplyResources(this.pWeaponSpell1, "pWeaponSpell1");
            this.pWeaponSpell1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pWeaponSpell1.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pWeaponSpell1.Name = "pWeaponSpell1";
            this.pWeaponSpell1.TabStop = false;
            // 
            // pBag
            // 
            resources.ApplyResources(this.pBag, "pBag");
            this.pBag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBag.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pBag.Name = "pBag";
            this.pBag.TabStop = false;
            // 
            // pCape
            // 
            resources.ApplyResources(this.pCape, "pCape");
            this.pCape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pCape.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pCape.Name = "pCape";
            this.pCape.TabStop = false;
            // 
            // pBoot
            // 
            resources.ApplyResources(this.pBoot, "pBoot");
            this.pBoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBoot.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pBoot.Name = "pBoot";
            this.pBoot.TabStop = false;
            // 
            // pChest
            // 
            resources.ApplyResources(this.pChest, "pChest");
            this.pChest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pChest.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pChest.Name = "pChest";
            this.pChest.TabStop = false;
            // 
            // pHead
            // 
            resources.ApplyResources(this.pHead, "pHead");
            this.pHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pHead.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pHead.Name = "pHead";
            this.pHead.TabStop = false;
            // 
            // pSWeapon
            // 
            resources.ApplyResources(this.pSWeapon, "pSWeapon");
            this.pSWeapon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pSWeapon.Name = "pSWeapon";
            this.pSWeapon.TabStop = false;
            // 
            // pFWeapon
            // 
            resources.ApplyResources(this.pFWeapon, "pFWeapon");
            this.pFWeapon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pFWeapon.InitialImage = global::AlbionNetwork2D.Properties.Resources.loading;
            this.pFWeapon.Name = "pFWeapon";
            this.pFWeapon.TabStop = false;
            // 
            // UserInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.pBootSpell);
            this.Controls.Add(this.pChestSpell);
            this.Controls.Add(this.pHeadSpell);
            this.Controls.Add(this.pWeaponSpell3);
            this.Controls.Add(this.pWeaponSpell2);
            this.Controls.Add(this.pWeaponSpell1);
            this.Controls.Add(this.pBag);
            this.Controls.Add(this.pCape);
            this.Controls.Add(this.pBoot);
            this.Controls.Add(this.pChest);
            this.Controls.Add(this.pHead);
            this.Controls.Add(this.pSWeapon);
            this.Controls.Add(this.pFWeapon);
            this.Controls.Add(this.lbPlayersInRange);
            this.Controls.Add(this.materialDivider3);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInfo";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pBootSpell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChestSpell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHeadSpell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeaponSpell3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeaponSpell2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeaponSpell1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSWeapon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pFWeapon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lbPlayersInRange;
        private MaterialSkin.Controls.MaterialDivider materialDivider3;
        private System.Windows.Forms.Timer updatePlayerList;
        private System.Windows.Forms.PictureBox pFWeapon;
        private System.Windows.Forms.PictureBox pSWeapon;
        private System.Windows.Forms.PictureBox pHead;
        private System.Windows.Forms.PictureBox pChest;
        private System.Windows.Forms.PictureBox pBoot;
        private System.Windows.Forms.PictureBox pCape;
        private System.Windows.Forms.PictureBox pBag;
        private System.Windows.Forms.PictureBox pWeaponSpell3;
        private System.Windows.Forms.PictureBox pWeaponSpell2;
        private System.Windows.Forms.PictureBox pWeaponSpell1;
        private System.Windows.Forms.PictureBox pHeadSpell;
        private System.Windows.Forms.PictureBox pChestSpell;
        private System.Windows.Forms.PictureBox pBootSpell;
        private System.Windows.Forms.Timer updatePlayerSelected;
    }
}