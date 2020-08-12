namespace AlbionRadar
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
            this.lbPlayersInRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.lbPlayersInRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPlayersInRange.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayersInRange.ForeColor = System.Drawing.Color.White;
            this.lbPlayersInRange.FormattingEnabled = true;
            this.lbPlayersInRange.Location = new System.Drawing.Point(12, 78);
            this.lbPlayersInRange.Name = "lbPlayersInRange";
            this.lbPlayersInRange.Size = new System.Drawing.Size(236, 52);
            this.lbPlayersInRange.TabIndex = 9;
            this.lbPlayersInRange.SelectedIndexChanged += new System.EventHandler(this.lbPlayersInRange_SelectedIndexChanged);
            // 
            // materialDivider3
            // 
            this.materialDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Location = new System.Drawing.Point(7, 70);
            this.materialDivider3.Margin = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Padding = new System.Windows.Forms.Padding(5);
            this.materialDivider3.Size = new System.Drawing.Size(246, 69);
            this.materialDivider3.TabIndex = 10;
            this.materialDivider3.Text = "materialDivider3";
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
            this.pBootSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBootSpell.ImageLocation = "";
            this.pBootSpell.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pBootSpell.Location = new System.Drawing.Point(160, 268);
            this.pBootSpell.Name = "pBootSpell";
            this.pBootSpell.Size = new System.Drawing.Size(30, 30);
            this.pBootSpell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBootSpell.TabIndex = 32;
            this.pBootSpell.TabStop = false;
            // 
            // pChestSpell
            // 
            this.pChestSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pChestSpell.ImageLocation = "";
            this.pChestSpell.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pChestSpell.Location = new System.Drawing.Point(159, 210);
            this.pChestSpell.Name = "pChestSpell";
            this.pChestSpell.Size = new System.Drawing.Size(30, 30);
            this.pChestSpell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pChestSpell.TabIndex = 31;
            this.pChestSpell.TabStop = false;
            // 
            // pHeadSpell
            // 
            this.pHeadSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pHeadSpell.ImageLocation = "";
            this.pHeadSpell.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pHeadSpell.Location = new System.Drawing.Point(160, 152);
            this.pHeadSpell.Name = "pHeadSpell";
            this.pHeadSpell.Size = new System.Drawing.Size(30, 30);
            this.pHeadSpell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pHeadSpell.TabIndex = 30;
            this.pHeadSpell.TabStop = false;
            // 
            // pWeaponSpell3
            // 
            this.pWeaponSpell3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pWeaponSpell3.ImageLocation = "";
            this.pWeaponSpell3.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pWeaponSpell3.Location = new System.Drawing.Point(65, 282);
            this.pWeaponSpell3.Name = "pWeaponSpell3";
            this.pWeaponSpell3.Size = new System.Drawing.Size(30, 30);
            this.pWeaponSpell3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pWeaponSpell3.TabIndex = 29;
            this.pWeaponSpell3.TabStop = false;
            // 
            // pWeaponSpell2
            // 
            this.pWeaponSpell2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pWeaponSpell2.ImageLocation = "";
            this.pWeaponSpell2.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pWeaponSpell2.Location = new System.Drawing.Point(65, 246);
            this.pWeaponSpell2.Name = "pWeaponSpell2";
            this.pWeaponSpell2.Size = new System.Drawing.Size(30, 30);
            this.pWeaponSpell2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pWeaponSpell2.TabIndex = 28;
            this.pWeaponSpell2.TabStop = false;
            // 
            // pWeaponSpell1
            // 
            this.pWeaponSpell1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pWeaponSpell1.ImageLocation = "";
            this.pWeaponSpell1.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pWeaponSpell1.Location = new System.Drawing.Point(65, 210);
            this.pWeaponSpell1.Name = "pWeaponSpell1";
            this.pWeaponSpell1.Size = new System.Drawing.Size(30, 30);
            this.pWeaponSpell1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pWeaponSpell1.TabIndex = 27;
            this.pWeaponSpell1.TabStop = false;
            // 
            // pBag
            // 
            this.pBag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBag.ImageLocation = "";
            this.pBag.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pBag.Location = new System.Drawing.Point(7, 152);
            this.pBag.Name = "pBag";
            this.pBag.Size = new System.Drawing.Size(52, 52);
            this.pBag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBag.TabIndex = 26;
            this.pBag.TabStop = false;
            // 
            // pCape
            // 
            this.pCape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pCape.ImageLocation = "";
            this.pCape.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pCape.Location = new System.Drawing.Point(196, 152);
            this.pCape.Name = "pCape";
            this.pCape.Size = new System.Drawing.Size(52, 52);
            this.pCape.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pCape.TabIndex = 25;
            this.pCape.TabStop = false;
            // 
            // pBoot
            // 
            this.pBoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pBoot.ImageLocation = "";
            this.pBoot.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pBoot.Location = new System.Drawing.Point(101, 268);
            this.pBoot.Name = "pBoot";
            this.pBoot.Size = new System.Drawing.Size(52, 52);
            this.pBoot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoot.TabIndex = 24;
            this.pBoot.TabStop = false;
            // 
            // pChest
            // 
            this.pChest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pChest.ImageLocation = "";
            this.pChest.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pChest.Location = new System.Drawing.Point(101, 210);
            this.pChest.Name = "pChest";
            this.pChest.Size = new System.Drawing.Size(52, 52);
            this.pChest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pChest.TabIndex = 23;
            this.pChest.TabStop = false;
            // 
            // pHead
            // 
            this.pHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pHead.ImageLocation = "";
            this.pHead.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pHead.Location = new System.Drawing.Point(101, 152);
            this.pHead.Name = "pHead";
            this.pHead.Size = new System.Drawing.Size(52, 52);
            this.pHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pHead.TabIndex = 22;
            this.pHead.TabStop = false;
            // 
            // pSWeapon
            // 
            this.pSWeapon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pSWeapon.ImageLocation = "";
            this.pSWeapon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pSWeapon.InitialImage")));
            this.pSWeapon.Location = new System.Drawing.Point(196, 210);
            this.pSWeapon.Name = "pSWeapon";
            this.pSWeapon.Size = new System.Drawing.Size(52, 52);
            this.pSWeapon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pSWeapon.TabIndex = 21;
            this.pSWeapon.TabStop = false;
            // 
            // pFWeapon
            // 
            this.pFWeapon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pFWeapon.ImageLocation = "";
            this.pFWeapon.InitialImage = global::AlbionRadar.Properties.Resources.loading;
            this.pFWeapon.Location = new System.Drawing.Point(7, 210);
            this.pFWeapon.Name = "pFWeapon";
            this.pFWeapon.Size = new System.Drawing.Size(52, 52);
            this.pFWeapon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pFWeapon.TabIndex = 20;
            this.pFWeapon.TabStop = false;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(260, 331);
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
            this.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInfo";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Albion Radar - Inspetor";
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