﻿namespace AlbionNetwork2D
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
            this.btnFilterList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lb_players_filter = new System.Windows.Forms.Label();
            this.tbfilterNames = new System.Windows.Forms.TextBox();
            this.btn_clearList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_copyList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lvLootLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateLootLog = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnFilterList
            // 
            resources.ApplyResources(this.btnFilterList, "btnFilterList");
            this.btnFilterList.Depth = 0;
            this.btnFilterList.Icon = null;
            this.btnFilterList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFilterList.Name = "btnFilterList";
            this.btnFilterList.Primary = true;
            this.btnFilterList.UseVisualStyleBackColor = true;
            this.btnFilterList.Click += new System.EventHandler(this.btnFilterList_Click);
            // 
            // lb_players_filter
            // 
            resources.ApplyResources(this.lb_players_filter, "lb_players_filter");
            this.lb_players_filter.ForeColor = System.Drawing.Color.White;
            this.lb_players_filter.Name = "lb_players_filter";
            // 
            // tbfilterNames
            // 
            resources.ApplyResources(this.tbfilterNames, "tbfilterNames");
            this.tbfilterNames.Name = "tbfilterNames";
            // 
            // btn_clearList
            // 
            resources.ApplyResources(this.btn_clearList, "btn_clearList");
            this.btn_clearList.Depth = 0;
            this.btn_clearList.Icon = null;
            this.btn_clearList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_clearList.Name = "btn_clearList";
            this.btn_clearList.Primary = true;
            this.btn_clearList.UseVisualStyleBackColor = true;
            this.btn_clearList.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // btn_copyList
            // 
            resources.ApplyResources(this.btn_copyList, "btn_copyList");
            this.btn_copyList.Depth = 0;
            this.btn_copyList.Icon = null;
            this.btn_copyList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_copyList.Name = "btn_copyList";
            this.btn_copyList.Primary = true;
            this.btn_copyList.UseVisualStyleBackColor = true;
            this.btn_copyList.Click += new System.EventHandler(this.copyList_Click);
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
            resources.ApplyResources(this.lvLootLog, "lvLootLog");
            this.lvLootLog.Name = "lvLootLog";
            this.lvLootLog.UseCompatibleStateImageBehavior = false;
            this.lvLootLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // updateLootLog
            // 
            this.updateLootLog.Enabled = true;
            this.updateLootLog.Interval = 500;
            this.updateLootLog.Tick += new System.EventHandler(this.updateLootLog_Tick);
            // 
            // LootLog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFilterList);
            this.Controls.Add(this.lb_players_filter);
            this.Controls.Add(this.tbfilterNames);
            this.Controls.Add(this.btn_clearList);
            this.Controls.Add(this.btn_copyList);
            this.Controls.Add(this.lvLootLog);
            this.MaximizeBox = false;
            this.Name = "LootLog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnFilterList;
        private System.Windows.Forms.Label lb_players_filter;
        private System.Windows.Forms.TextBox tbfilterNames;
        private MaterialSkin.Controls.MaterialRaisedButton btn_clearList;
        private MaterialSkin.Controls.MaterialRaisedButton btn_copyList;
        private System.Windows.Forms.ListView lvLootLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer updateLootLog;
    }
}