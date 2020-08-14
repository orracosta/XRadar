namespace AlbionRadar
{
    partial class LootLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LootLog));
            this.updateLootLog = new System.Windows.Forms.Timer(this.components);
            this.lvLootLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.copyList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // updateLootLog
            // 
            this.updateLootLog.Enabled = true;
            this.updateLootLog.Interval = 500;
            this.updateLootLog.Tick += new System.EventHandler(this.updateLootLog_Tick);
            // 
            // lvLootLog
            // 
            this.lvLootLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvLootLog.FullRowSelect = true;
            this.lvLootLog.GridLines = true;
            this.lvLootLog.HideSelection = false;
            this.lvLootLog.Location = new System.Drawing.Point(12, 76);
            this.lvLootLog.Name = "lvLootLog";
            this.lvLootLog.Size = new System.Drawing.Size(526, 326);
            this.lvLootLog.TabIndex = 0;
            this.lvLootLog.UseCompatibleStateImageBehavior = false;
            this.lvLootLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Usuário";
            this.columnHeader1.Width = 156;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item";
            this.columnHeader2.Width = 218;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantia";
            this.columnHeader3.Width = 92;
            // 
            // copyList
            // 
            this.copyList.AutoSize = true;
            this.copyList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.copyList.Depth = 0;
            this.copyList.Icon = null;
            this.copyList.Location = new System.Drawing.Point(418, 408);
            this.copyList.MinimumSize = new System.Drawing.Size(120, 0);
            this.copyList.MouseState = MaterialSkin.MouseState.HOVER;
            this.copyList.Name = "copyList";
            this.copyList.Primary = true;
            this.copyList.Size = new System.Drawing.Size(120, 36);
            this.copyList.TabIndex = 9;
            this.copyList.Text = "Copiar Lista";
            this.copyList.UseVisualStyleBackColor = true;
            this.copyList.Click += new System.EventHandler(this.copyList_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(292, 408);
            this.materialRaisedButton1.MinimumSize = new System.Drawing.Size(120, 0);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(120, 36);
            this.materialRaisedButton1.TabIndex = 10;
            this.materialRaisedButton1.Text = "Limpar Lista";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // LootLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.copyList);
            this.Controls.Add(this.lvLootLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "LootLog";
            this.Sizable = false;
            this.Text = "Histórico de Loot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer updateLootLog;
        private System.Windows.Forms.ListView lvLootLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MaterialSkin.Controls.MaterialRaisedButton copyList;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}