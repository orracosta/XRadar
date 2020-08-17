namespace AlbionNetwork2D
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
            this.tbfilterNames = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lvLootLog.Location = new System.Drawing.Point(189, 74);
            this.lvLootLog.Name = "lvLootLog";
            this.lvLootLog.Size = new System.Drawing.Size(476, 326);
            this.lvLootLog.TabIndex = 0;
            this.lvLootLog.UseCompatibleStateImageBehavior = false;
            this.lvLootLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Usuário";
            this.columnHeader1.Width = 143;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item";
            this.columnHeader2.Width = 228;
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
            this.copyList.Location = new System.Drawing.Point(545, 406);
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
            this.materialRaisedButton1.Location = new System.Drawing.Point(419, 406);
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
            // tbfilterNames
            // 
            this.tbfilterNames.Location = new System.Drawing.Point(12, 94);
            this.tbfilterNames.Multiline = true;
            this.tbfilterNames.Name = "tbfilterNames";
            this.tbfilterNames.Size = new System.Drawing.Size(171, 306);
            this.tbfilterNames.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Filtro de Jogadores:";
            // 
            // LootLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbfilterNames);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.copyList);
            this.Controls.Add(this.lvLootLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
        private System.Windows.Forms.TextBox tbfilterNames;
        private System.Windows.Forms.Label label1;
    }
}