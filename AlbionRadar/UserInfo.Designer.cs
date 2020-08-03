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
            this.label6 = new System.Windows.Forms.Label();
            this.pFWeapon = new System.Windows.Forms.Label();
            this.pSWeapon = new System.Windows.Forms.Label();
            this.pHelm = new System.Windows.Forms.Label();
            this.pArmor = new System.Windows.Forms.Label();
            this.pBoot = new System.Windows.Forms.Label();
            this.updatePlayerList = new System.Windows.Forms.Timer(this.components);
            this.pCape = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPlayersInRange
            // 
            this.lbPlayersInRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.lbPlayersInRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPlayersInRange.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayersInRange.ForeColor = System.Drawing.Color.White;
            this.lbPlayersInRange.FormattingEnabled = true;
            this.lbPlayersInRange.Location = new System.Drawing.Point(12, 99);
            this.lbPlayersInRange.Name = "lbPlayersInRange";
            this.lbPlayersInRange.Size = new System.Drawing.Size(210, 65);
            this.lbPlayersInRange.TabIndex = 9;
            this.lbPlayersInRange.SelectedIndexChanged += new System.EventHandler(this.lbPlayersInRange_SelectedIndexChanged);
            // 
            // materialDivider3
            // 
            this.materialDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Location = new System.Drawing.Point(7, 91);
            this.materialDivider3.Margin = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Padding = new System.Windows.Forms.Padding(5);
            this.materialDivider3.Size = new System.Drawing.Size(221, 80);
            this.materialDivider3.TabIndex = 10;
            this.materialDivider3.Text = "materialDivider3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Jogadores:";
            // 
            // pFWeapon
            // 
            this.pFWeapon.AutoSize = true;
            this.pFWeapon.BackColor = System.Drawing.Color.Transparent;
            this.pFWeapon.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pFWeapon.ForeColor = System.Drawing.Color.White;
            this.pFWeapon.Location = new System.Drawing.Point(4, 181);
            this.pFWeapon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pFWeapon.Name = "pFWeapon";
            this.pFWeapon.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pFWeapon.Size = new System.Drawing.Size(68, 13);
            this.pFWeapon.TabIndex = 12;
            this.pFWeapon.Text = "Jogadores:";
            // 
            // pSWeapon
            // 
            this.pSWeapon.AutoSize = true;
            this.pSWeapon.BackColor = System.Drawing.Color.Transparent;
            this.pSWeapon.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pSWeapon.ForeColor = System.Drawing.Color.White;
            this.pSWeapon.Location = new System.Drawing.Point(4, 199);
            this.pSWeapon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pSWeapon.Name = "pSWeapon";
            this.pSWeapon.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pSWeapon.Size = new System.Drawing.Size(68, 13);
            this.pSWeapon.TabIndex = 13;
            this.pSWeapon.Text = "Jogadores:";
            // 
            // pHelm
            // 
            this.pHelm.AutoSize = true;
            this.pHelm.BackColor = System.Drawing.Color.Transparent;
            this.pHelm.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pHelm.ForeColor = System.Drawing.Color.White;
            this.pHelm.Location = new System.Drawing.Point(4, 217);
            this.pHelm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pHelm.Name = "pHelm";
            this.pHelm.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pHelm.Size = new System.Drawing.Size(68, 13);
            this.pHelm.TabIndex = 14;
            this.pHelm.Text = "Jogadores:";
            // 
            // pArmor
            // 
            this.pArmor.AutoSize = true;
            this.pArmor.BackColor = System.Drawing.Color.Transparent;
            this.pArmor.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pArmor.ForeColor = System.Drawing.Color.White;
            this.pArmor.Location = new System.Drawing.Point(4, 235);
            this.pArmor.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pArmor.Name = "pArmor";
            this.pArmor.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pArmor.Size = new System.Drawing.Size(68, 13);
            this.pArmor.TabIndex = 15;
            this.pArmor.Text = "Jogadores:";
            // 
            // pBoot
            // 
            this.pBoot.AutoSize = true;
            this.pBoot.BackColor = System.Drawing.Color.Transparent;
            this.pBoot.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pBoot.ForeColor = System.Drawing.Color.White;
            this.pBoot.Location = new System.Drawing.Point(4, 253);
            this.pBoot.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pBoot.Name = "pBoot";
            this.pBoot.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pBoot.Size = new System.Drawing.Size(68, 13);
            this.pBoot.TabIndex = 16;
            this.pBoot.Text = "Jogadores:";
            // 
            // updatePlayerList
            // 
            this.updatePlayerList.Tick += new System.EventHandler(this.updatePlayerList_Tick);
            // 
            // pCape
            // 
            this.pCape.AutoSize = true;
            this.pCape.BackColor = System.Drawing.Color.Transparent;
            this.pCape.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pCape.ForeColor = System.Drawing.Color.White;
            this.pCape.Location = new System.Drawing.Point(4, 271);
            this.pCape.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pCape.Name = "pCape";
            this.pCape.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pCape.Size = new System.Drawing.Size(68, 13);
            this.pCape.TabIndex = 17;
            this.pCape.Text = "Jogadores:";
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(234, 294);
            this.Controls.Add(this.pCape);
            this.Controls.Add(this.pBoot);
            this.Controls.Add(this.pArmor);
            this.Controls.Add(this.pHelm);
            this.Controls.Add(this.pSWeapon);
            this.Controls.Add(this.pFWeapon);
            this.Controls.Add(this.label6);
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
            this.Text = "UserInfo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lbPlayersInRange;
        private MaterialSkin.Controls.MaterialDivider materialDivider3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label pFWeapon;
        private System.Windows.Forms.Label pSWeapon;
        private System.Windows.Forms.Label pHelm;
        private System.Windows.Forms.Label pArmor;
        private System.Windows.Forms.Label pBoot;
        private System.Windows.Forms.Timer updatePlayerList;
        private System.Windows.Forms.Label pCape;
    }
}