namespace rMOD
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStructuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsNewRDB_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsNewData_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsNewScript_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.currentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reload = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.structureDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear = new System.Windows.Forms.ToolStripMenuItem();
            this.close = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.useASCIIBtn = new System.Windows.Forms.ToolStripButton();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reloadToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.structureDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tabsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(818, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.manageStructuresToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejToolStripMenuItem,
            this.sQLToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // ejToolStripMenuItem
            // 
            this.ejToolStripMenuItem.Name = "ejToolStripMenuItem";
            this.ejToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.ejToolStripMenuItem.Text = "File";
            this.ejToolStripMenuItem.Click += new System.EventHandler(this.readFileBtn_Click);
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.sQLToolStripMenuItem.Text = "SQL";
            this.sQLToolStripMenuItem.Click += new System.EventHandler(this.loadSQLBtn_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.sQLToolStripMenuItem1});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(95, 22);
            this.fileToolStripMenuItem1.Text = "File";
            this.fileToolStripMenuItem1.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // sQLToolStripMenuItem1
            // 
            this.sQLToolStripMenuItem1.Name = "sQLToolStripMenuItem1";
            this.sQLToolStripMenuItem1.Size = new System.Drawing.Size(95, 22);
            this.sQLToolStripMenuItem1.Text = "SQL";
            this.sQLToolStripMenuItem1.Click += new System.EventHandler(this.saveSQLBtn_Click);
            // 
            // manageStructuresToolStripMenuItem
            // 
            this.manageStructuresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem});
            this.manageStructuresToolStripMenuItem.Name = "manageStructuresToolStripMenuItem";
            this.manageStructuresToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.manageStructuresToolStripMenuItem.Text = "Manage Structures";
            this.manageStructuresToolStripMenuItem.Click += new System.EventHandler(this.manageStructuresBtn_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // tabsToolStripMenuItem
            // 
            this.tabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.currentToolStripMenuItem});
            this.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem";
            this.tabsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.tabsToolStripMenuItem.Text = "Tabs";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabsNewRDB_btn,
            this.tabsNewData_btn,
            this.tabsNewScript_btn});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newTab_Click);
            // 
            // tabsNewRDB_btn
            // 
            this.tabsNewRDB_btn.Name = "tabsNewRDB_btn";
            this.tabsNewRDB_btn.Size = new System.Drawing.Size(152, 22);
            this.tabsNewRDB_btn.Text = "RDB";
            this.tabsNewRDB_btn.Click += new System.EventHandler(this.newTab_Click);
            // 
            // tabsNewData_btn
            // 
            this.tabsNewData_btn.Enabled = false;
            this.tabsNewData_btn.Name = "tabsNewData_btn";
            this.tabsNewData_btn.Size = new System.Drawing.Size(152, 22);
            this.tabsNewData_btn.Text = "Data";
            this.tabsNewData_btn.Click += new System.EventHandler(this.newTab_Click);
            // 
            // tabsNewScript_btn
            // 
            this.tabsNewScript_btn.Enabled = false;
            this.tabsNewScript_btn.Name = "tabsNewScript_btn";
            this.tabsNewScript_btn.Size = new System.Drawing.Size(152, 22);
            this.tabsNewScript_btn.Text = "Script";
            this.tabsNewScript_btn.Click += new System.EventHandler(this.newTab_Click);
            // 
            // currentToolStripMenuItem
            // 
            this.currentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reload,
            this.clear,
            this.close});
            this.currentToolStripMenuItem.Name = "currentToolStripMenuItem";
            this.currentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.currentToolStripMenuItem.Text = "Current";
            this.currentToolStripMenuItem.MouseEnter += new System.EventHandler(this.currentToolStripMenuItem_MouseEnter);
            // 
            // reload
            // 
            this.reload.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.structureDataToolStripMenuItem});
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(110, 22);
            this.reload.Text = "Reload";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.dataToolStripMenuItem.Text = "Data Only";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.reloadData_Click);
            // 
            // structureDataToolStripMenuItem
            // 
            this.structureDataToolStripMenuItem.Name = "structureDataToolStripMenuItem";
            this.structureDataToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.structureDataToolStripMenuItem.Text = "Structure + Data";
            this.structureDataToolStripMenuItem.Click += new System.EventHandler(this.reload_Click);
            // 
            // clear
            // 
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(110, 22);
            this.clear.Text = "Clear";
            this.clear.Click += new System.EventHandler(this.resetTab_Click);
            // 
            // close
            // 
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(110, 22);
            this.close.Text = "Close";
            this.close.Click += new System.EventHandler(this.closeTab_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsDatabase,
            this.settingsFile});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // settingsDatabase
            // 
            this.settingsDatabase.Name = "settingsDatabase";
            this.settingsDatabase.Size = new System.Drawing.Size(152, 22);
            this.settingsDatabase.Text = "Database";
            this.settingsDatabase.Click += new System.EventHandler(this.settingsDatabase_Click);
            // 
            // settingsFile
            // 
            this.settingsFile.Name = "settingsFile";
            this.settingsFile.Size = new System.Drawing.Size(152, 22);
            this.settingsFile.Text = "File";
            this.settingsFile.Click += new System.EventHandler(this.settingsFile_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.about_Click);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(19, 537);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripButton4,
            this.useASCIIBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(818, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton1.Text = "Load File";
            this.toolStripButton1.Click += new System.EventHandler(this.readFileBtn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton2.Text = "Save File";
            this.toolStripButton2.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton3.Text = "Load SQL";
            this.toolStripButton3.Click += new System.EventHandler(this.loadSQLBtn_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton5.Text = "Save SQL";
            this.toolStripButton5.Click += new System.EventHandler(this.saveSQLBtn_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(110, 22);
            this.toolStripButton4.Text = "Manage Structures";
            this.toolStripButton4.Click += new System.EventHandler(this.manageStructuresBtn_Click);
            // 
            // useASCIIBtn
            // 
            this.useASCIIBtn.BackColor = System.Drawing.SystemColors.Control;
            this.useASCIIBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.useASCIIBtn.Image = ((System.Drawing.Image)(resources.GetObject("useASCIIBtn.Image")));
            this.useASCIIBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.useASCIIBtn.Name = "useASCIIBtn";
            this.useASCIIBtn.Size = new System.Drawing.Size(61, 22);
            this.useASCIIBtn.Text = "Use ASCII";
            this.useASCIIBtn.Click += new System.EventHandler(this.useASCIIBtn_Click);
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Location = new System.Drawing.Point(12, 52);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.ShowToolTips = true;
            this.tabs.Size = new System.Drawing.Size(794, 483);
            this.tabs.TabIndex = 14;
            this.tabs.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabs_ControlRemoved);
            this.tabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabs_MouseClick);
            // 
            // tabContextMenu
            // 
            this.tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem2,
            this.clearToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.tabContextMenu.Name = "tabContextMenu";
            this.tabContextMenu.Size = new System.Drawing.Size(111, 70);
            // 
            // reloadToolStripMenuItem2
            // 
            this.reloadToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataOnlyToolStripMenuItem,
            this.structureDataToolStripMenuItem1});
            this.reloadToolStripMenuItem2.Name = "reloadToolStripMenuItem2";
            this.reloadToolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.reloadToolStripMenuItem2.Text = "Reload";
            // 
            // dataOnlyToolStripMenuItem
            // 
            this.dataOnlyToolStripMenuItem.Name = "dataOnlyToolStripMenuItem";
            this.dataOnlyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.dataOnlyToolStripMenuItem.Text = "Data Only";
            this.dataOnlyToolStripMenuItem.Click += new System.EventHandler(this.reloadData_Click);
            // 
            // structureDataToolStripMenuItem1
            // 
            this.structureDataToolStripMenuItem1.Name = "structureDataToolStripMenuItem1";
            this.structureDataToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.structureDataToolStripMenuItem1.Text = "Structure + Data";
            this.structureDataToolStripMenuItem1.Click += new System.EventHandler(this.reload_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.resetTab_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeTab_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 557);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.KeyPreview = true;
            this.Name = "GUI";
            this.Text = "rMOD ~ iSmokeDrow";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.Shown += new System.EventHandler(this.GUI_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GUI_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsDatabase;
        private System.Windows.Forms.ToolStripMenuItem settingsFile;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        internal System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.ToolStripMenuItem tabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton useASCIIBtn;
        private System.Windows.Forms.ToolStripMenuItem manageStructuresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clear;
        private System.Windows.Forms.ToolStripMenuItem close;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reload;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem structureDataToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dataOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem structureDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tabsNewRDB_btn;
        private System.Windows.Forms.ToolStripMenuItem tabsNewData_btn;
        private System.Windows.Forms.ToolStripMenuItem tabsNewScript_btn;
    }
}

