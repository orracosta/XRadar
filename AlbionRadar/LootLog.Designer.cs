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
            this.btn_copyList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_clearList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tbfilterNames = new System.Windows.Forms.TextBox();
            this.lb_players_filter = new System.Windows.Forms.Label();
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
            // btn_copyList
            // 
            this.btn_copyList.AutoSize = true;
            this.btn_copyList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_copyList.Depth = 0;
            this.btn_copyList.Icon = null;
            this.btn_copyList.Location = new System.Drawing.Point(545, 406);
            this.btn_copyList.MinimumSize = new System.Drawing.Size(120, 0);
            this.btn_copyList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_copyList.Name = "btn_copyList";
            this.btn_copyList.Primary = true;
            this.btn_copyList.Size = new System.Drawing.Size(120, 36);
            this.btn_copyList.TabIndex = 9;
            this.btn_copyList.Text = "Copiar Lista";
            this.btn_copyList.UseVisualStyleBackColor = true;
            this.btn_copyList.Click += new System.EventHandler(this.copyList_Click);
            // 
            // btn_clearList
            // 
            this.btn_clearList.AutoSize = true;
            this.btn_clearList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_clearList.Depth = 0;
            this.btn_clearList.Icon = null;
            this.btn_clearList.Location = new System.Drawing.Point(419, 406);
            this.btn_clearList.MinimumSize = new System.Drawing.Size(120, 0);
            this.btn_clearList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_clearList.Name = "btn_clearList";
            this.btn_clearList.Primary = true;
            this.btn_clearList.Size = new System.Drawing.Size(120, 36);
            this.btn_clearList.TabIndex = 10;
            this.btn_clearList.Text = "Limpar Lista";
            this.btn_clearList.UseVisualStyleBackColor = true;
            this.btn_clearList.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // tbfilterNames
            // 
            this.tbfilterNames.Location = new System.Drawing.Point(12, 94);
            this.tbfilterNames.Multiline = true;
            this.tbfilterNames.Name = "tbfilterNames";
            this.tbfilterNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbfilterNames.Size = new System.Drawing.Size(171, 306);
            this.tbfilterNames.TabIndex = 11;
            // 
            // lb_players_filter
            // 
            this.lb_players_filter.AutoSize = true;
            this.lb_players_filter.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_players_filter.ForeColor = System.Drawing.Color.White;
            this.lb_players_filter.Location = new System.Drawing.Point(9, 74);
            this.lb_players_filter.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.lb_players_filter.Name = "lb_players_filter";
            this.lb_players_filter.Size = new System.Drawing.Size(117, 17);
            this.lb_players_filter.TabIndex = 12;
            this.lb_players_filter.Text = "Filtro de Jogadores:";
            // 
            // LootLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.lb_players_filter);
            this.Controls.Add(this.tbfilterNames);
            this.Controls.Add(this.btn_clearList);
            this.Controls.Add(this.btn_copyList);
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
        private MaterialSkin.Controls.MaterialRaisedButton btn_copyList;
        private MaterialSkin.Controls.MaterialRaisedButton btn_clearList;
        private System.Windows.Forms.TextBox tbfilterNames;
        private System.Windows.Forms.Label lb_players_filter;
    }
}