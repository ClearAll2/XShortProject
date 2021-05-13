namespace XShort
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openAsAdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkValidPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openAtWindowsStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createShortcutOnDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button13 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vietnameseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelData = new System.Windows.Forms.Panel();
            this.panelEditShortcut = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelPara = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxPara = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.labelShortcutType = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonAddURL = new System.Windows.Forms.Button();
            this.buttonAddDir = new System.Windows.Forms.Button();
            this.buttonAddApp = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelEditShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.mainWindowToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.runBoxToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolTip1.SetToolTip(this.contextMenuStrip1, resources.GetString("contextMenuStrip1.ToolTip"));
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainWindowToolStripMenuItem
            // 
            resources.ApplyResources(this.mainWindowToolStripMenuItem, "mainWindowToolStripMenuItem");
            this.mainWindowToolStripMenuItem.Name = "mainWindowToolStripMenuItem";
            this.mainWindowToolStripMenuItem.Click += new System.EventHandler(this.mainWindowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // runBoxToolStripMenuItem
            // 
            resources.ApplyResources(this.runBoxToolStripMenuItem, "runBoxToolStripMenuItem");
            this.runBoxToolStripMenuItem.Name = "runBoxToolStripMenuItem";
            this.runBoxToolStripMenuItem.Click += new System.EventHandler(this.runBoxToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // contextMenuStrip2
            // 
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            this.contextMenuStrip2.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openAsAdministratorToolStripMenuItem,
            this.openFileLocationToolStripMenuItem1,
            this.toolStripSeparator3,
            this.detailsToolStripMenuItem,
            this.checkValidPathToolStripMenuItem,
            this.toolStripSeparator4,
            this.openAtWindowsStartupToolStripMenuItem,
            this.createShortcutOnDesktopToolStripMenuItem,
            this.toolStripSeparator6,
            this.cloneToolStripMenuItem,
            this.addToolStripMenuItem1,
            this.toolStripSeparator5,
            this.propertiesToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolTip1.SetToolTip(this.contextMenuStrip2, resources.GetString("contextMenuStrip2.ToolTip"));
            // 
            // openToolStripMenuItem1
            // 
            resources.ApplyResources(this.openToolStripMenuItem1, "openToolStripMenuItem1");
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // openAsAdministratorToolStripMenuItem
            // 
            resources.ApplyResources(this.openAsAdministratorToolStripMenuItem, "openAsAdministratorToolStripMenuItem");
            this.openAsAdministratorToolStripMenuItem.Name = "openAsAdministratorToolStripMenuItem";
            this.openAsAdministratorToolStripMenuItem.Click += new System.EventHandler(this.openAsAdministratorToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem1
            // 
            resources.ApplyResources(this.openFileLocationToolStripMenuItem1, "openFileLocationToolStripMenuItem1");
            this.openFileLocationToolStripMenuItem1.Name = "openFileLocationToolStripMenuItem1";
            this.openFileLocationToolStripMenuItem1.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // detailsToolStripMenuItem
            // 
            resources.ApplyResources(this.detailsToolStripMenuItem, "detailsToolStripMenuItem");
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // checkValidPathToolStripMenuItem
            // 
            resources.ApplyResources(this.checkValidPathToolStripMenuItem, "checkValidPathToolStripMenuItem");
            this.checkValidPathToolStripMenuItem.Name = "checkValidPathToolStripMenuItem";
            this.checkValidPathToolStripMenuItem.Click += new System.EventHandler(this.checkValidPathToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // openAtWindowsStartupToolStripMenuItem
            // 
            resources.ApplyResources(this.openAtWindowsStartupToolStripMenuItem, "openAtWindowsStartupToolStripMenuItem");
            this.openAtWindowsStartupToolStripMenuItem.Name = "openAtWindowsStartupToolStripMenuItem";
            this.openAtWindowsStartupToolStripMenuItem.Click += new System.EventHandler(this.openAtWindowsStartupToolStripMenuItem_Click);
            // 
            // createShortcutOnDesktopToolStripMenuItem
            // 
            resources.ApplyResources(this.createShortcutOnDesktopToolStripMenuItem, "createShortcutOnDesktopToolStripMenuItem");
            this.createShortcutOnDesktopToolStripMenuItem.Name = "createShortcutOnDesktopToolStripMenuItem";
            this.createShortcutOnDesktopToolStripMenuItem.Click += new System.EventHandler(this.createShortcutOnDesktopToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // cloneToolStripMenuItem
            // 
            resources.ApplyResources(this.cloneToolStripMenuItem, "cloneToolStripMenuItem");
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem1
            // 
            resources.ApplyResources(this.addToolStripMenuItem1, "addToolStripMenuItem1");
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // propertiesToolStripMenuItem
            // 
            resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // button13
            // 
            resources.ApplyResources(this.button13, "button13");
            this.button13.BackColor = System.Drawing.Color.DodgerBlue;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Name = "button13";
            this.button13.TabStop = false;
            this.toolTip1.SetToolTip(this.button13, resources.GetString("button13.ToolTip"));
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.appToolStripMenuItem,
            this.actToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.aboutToolStripMenuItem2});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolTip1.SetToolTip(this.menuStrip1, resources.GetString("menuStrip1.ToolTip"));
            // 
            // controlToolStripMenuItem
            // 
            resources.ApplyResources(this.controlToolStripMenuItem, "controlToolStripMenuItem");
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeHideToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            // 
            // minimizeHideToolStripMenuItem
            // 
            resources.ApplyResources(this.minimizeHideToolStripMenuItem, "minimizeHideToolStripMenuItem");
            this.minimizeHideToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.minimizeHideToolStripMenuItem.Name = "minimizeHideToolStripMenuItem";
            this.minimizeHideToolStripMenuItem.Click += new System.EventHandler(this.button7_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // appToolStripMenuItem
            // 
            resources.ApplyResources(this.appToolStripMenuItem, "appToolStripMenuItem");
            this.appToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAppToolStripMenuItem,
            this.addDirToolStripMenuItem,
            this.addUrlToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.appToolStripMenuItem.Name = "appToolStripMenuItem";
            // 
            // addAppToolStripMenuItem
            // 
            resources.ApplyResources(this.addAppToolStripMenuItem, "addAppToolStripMenuItem");
            this.addAppToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addAppToolStripMenuItem.Name = "addAppToolStripMenuItem";
            this.addAppToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addDirToolStripMenuItem
            // 
            resources.ApplyResources(this.addDirToolStripMenuItem, "addDirToolStripMenuItem");
            this.addDirToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addDirToolStripMenuItem.Name = "addDirToolStripMenuItem";
            this.addDirToolStripMenuItem.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // addUrlToolStripMenuItem
            // 
            resources.ApplyResources(this.addUrlToolStripMenuItem, "addUrlToolStripMenuItem");
            this.addUrlToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addUrlToolStripMenuItem.Name = "addUrlToolStripMenuItem";
            this.addUrlToolStripMenuItem.Click += new System.EventHandler(this.addURLToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveShortcutsToolStripMenuItem_Click);
            // 
            // actToolStripMenuItem
            // 
            resources.ApplyResources(this.actToolStripMenuItem, "actToolStripMenuItem");
            this.actToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadDataToolStripMenuItem1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.openSettingsToolStripMenuItem});
            this.actToolStripMenuItem.Name = "actToolStripMenuItem";
            // 
            // reloadDataToolStripMenuItem1
            // 
            resources.ApplyResources(this.reloadDataToolStripMenuItem1, "reloadDataToolStripMenuItem1");
            this.reloadDataToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.reloadDataToolStripMenuItem1.Name = "reloadDataToolStripMenuItem1";
            this.reloadDataToolStripMenuItem1.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // importToolStripMenuItem
            // 
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // exportToolStripMenuItem
            // 
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // openSettingsToolStripMenuItem
            // 
            resources.ApplyResources(this.openSettingsToolStripMenuItem, "openSettingsToolStripMenuItem");
            this.openSettingsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.vietnameseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // vietnameseToolStripMenuItem
            // 
            resources.ApplyResources(this.vietnameseToolStripMenuItem, "vietnameseToolStripMenuItem");
            this.vietnameseToolStripMenuItem.Name = "vietnameseToolStripMenuItem";
            this.vietnameseToolStripMenuItem.Click += new System.EventHandler(this.vietnameseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem2
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem2, "aboutToolStripMenuItem2");
            this.aboutToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homepageToolStripMenuItem,
            this.openAboutToolStripMenuItem});
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            // 
            // homepageToolStripMenuItem
            // 
            resources.ApplyResources(this.homepageToolStripMenuItem, "homepageToolStripMenuItem");
            this.homepageToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // openAboutToolStripMenuItem
            // 
            resources.ApplyResources(this.openAboutToolStripMenuItem, "openAboutToolStripMenuItem");
            this.openAboutToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.openAboutToolStripMenuItem.Name = "openAboutToolStripMenuItem";
            this.openAboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listViewData
            // 
            resources.ApplyResources(this.listViewData, "listViewData");
            this.listViewData.AllowDrop = true;
            this.listViewData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewData.FullRowSelect = true;
            this.listViewData.HideSelection = false;
            this.listViewData.MultiSelect = false;
            this.listViewData.Name = "listViewData";
            this.listViewData.ShowItemToolTips = true;
            this.listViewData.TabStop = false;
            this.toolTip1.SetToolTip(this.listViewData, resources.GetString("listViewData.ToolTip"));
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            this.listViewData.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listViewData.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listViewData.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listViewData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listViewData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
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
            // panelData
            // 
            resources.ApplyResources(this.panelData, "panelData");
            this.panelData.Controls.Add(this.listViewData);
            this.panelData.Name = "panelData";
            this.toolTip1.SetToolTip(this.panelData, resources.GetString("panelData.ToolTip"));
            // 
            // panelEditShortcut
            // 
            resources.ApplyResources(this.panelEditShortcut, "panelEditShortcut");
            this.panelEditShortcut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditShortcut.Controls.Add(this.comboBox1);
            this.panelEditShortcut.Controls.Add(this.button13);
            this.panelEditShortcut.Controls.Add(this.labelPara);
            this.panelEditShortcut.Controls.Add(this.labelPath);
            this.panelEditShortcut.Controls.Add(this.labelName);
            this.panelEditShortcut.Controls.Add(this.textBoxPara);
            this.panelEditShortcut.Controls.Add(this.textBoxPath);
            this.panelEditShortcut.Controls.Add(this.textBoxName);
            this.panelEditShortcut.Controls.Add(this.button12);
            this.panelEditShortcut.Controls.Add(this.button10);
            this.panelEditShortcut.Controls.Add(this.labelShortcutType);
            this.panelEditShortcut.Name = "panelEditShortcut";
            this.toolTip1.SetToolTip(this.panelEditShortcut, resources.GetString("panelEditShortcut.ToolTip"));
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.comboBox1, resources.GetString("comboBox1.ToolTip"));
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelPara
            // 
            resources.ApplyResources(this.labelPara, "labelPara");
            this.labelPara.Name = "labelPara";
            this.toolTip1.SetToolTip(this.labelPara, resources.GetString("labelPara.ToolTip"));
            // 
            // labelPath
            // 
            resources.ApplyResources(this.labelPath, "labelPath");
            this.labelPath.Name = "labelPath";
            this.toolTip1.SetToolTip(this.labelPath, resources.GetString("labelPath.ToolTip"));
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            this.toolTip1.SetToolTip(this.labelName, resources.GetString("labelName.ToolTip"));
            // 
            // textBoxPara
            // 
            resources.ApplyResources(this.textBoxPara, "textBoxPara");
            this.textBoxPara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPara.Name = "textBoxPara";
            this.textBoxPara.TabStop = false;
            this.toolTip1.SetToolTip(this.textBoxPara, resources.GetString("textBoxPara.ToolTip"));
            // 
            // textBoxPath
            // 
            resources.ApplyResources(this.textBoxPath, "textBoxPath");
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.TabStop = false;
            this.toolTip1.SetToolTip(this.textBoxPath, resources.GetString("textBoxPath.ToolTip"));
            // 
            // textBoxName
            // 
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.TabStop = false;
            this.toolTip1.SetToolTip(this.textBoxName, resources.GetString("textBoxName.ToolTip"));
            // 
            // button12
            // 
            resources.ApplyResources(this.button12, "button12");
            this.button12.BackColor = System.Drawing.Color.DodgerBlue;
            this.button12.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Name = "button12";
            this.button12.TabStop = false;
            this.toolTip1.SetToolTip(this.button12, resources.GetString("button12.ToolTip"));
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            resources.ApplyResources(this.button10, "button10");
            this.button10.BackColor = System.Drawing.Color.DodgerBlue;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Name = "button10";
            this.button10.TabStop = false;
            this.toolTip1.SetToolTip(this.button10, resources.GetString("button10.ToolTip"));
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // labelShortcutType
            // 
            resources.ApplyResources(this.labelShortcutType, "labelShortcutType");
            this.labelShortcutType.Name = "labelShortcutType";
            this.toolTip1.SetToolTip(this.labelShortcutType, resources.GetString("labelShortcutType.ToolTip"));
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.ImageList = this.imageList1;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonSave, resources.GetString("buttonSave.ToolTip"));
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.saveShortcutsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home2.png");
            this.imageList1.Images.SetKeyName(1, "info.png");
            this.imageList1.Images.SetKeyName(2, "setting.png");
            this.imageList1.Images.SetKeyName(3, "menu2.png");
            this.imageList1.Images.SetKeyName(4, "back.png");
            this.imageList1.Images.SetKeyName(5, "refresh-512.png");
            this.imageList1.Images.SetKeyName(6, "exit.png");
            this.imageList1.Images.SetKeyName(7, "Bokehlicia-Captiva-Browser-web.ico");
            this.imageList1.Images.SetKeyName(8, "folder.png");
            this.imageList1.Images.SetKeyName(9, "save.png");
            this.imageList1.Images.SetKeyName(10, "link.png");
            this.imageList1.Images.SetKeyName(11, "app.png");
            this.imageList1.Images.SetKeyName(12, "import.png");
            this.imageList1.Images.SetKeyName(13, "export.png");
            this.imageList1.Images.SetKeyName(14, "info.png");
            this.imageList1.Images.SetKeyName(15, "search.png");
            this.imageList1.Images.SetKeyName(16, "log.png");
            this.imageList1.Images.SetKeyName(17, "list.png");
            // 
            // buttonAddURL
            // 
            resources.ApplyResources(this.buttonAddURL, "buttonAddURL");
            this.buttonAddURL.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddURL.FlatAppearance.BorderSize = 0;
            this.buttonAddURL.ForeColor = System.Drawing.Color.Black;
            this.buttonAddURL.ImageList = this.imageList1;
            this.buttonAddURL.Name = "buttonAddURL";
            this.buttonAddURL.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonAddURL, resources.GetString("buttonAddURL.ToolTip"));
            this.buttonAddURL.UseVisualStyleBackColor = true;
            this.buttonAddURL.Click += new System.EventHandler(this.addURLToolStripMenuItem_Click);
            // 
            // buttonAddDir
            // 
            resources.ApplyResources(this.buttonAddDir, "buttonAddDir");
            this.buttonAddDir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddDir.FlatAppearance.BorderSize = 0;
            this.buttonAddDir.ForeColor = System.Drawing.Color.Black;
            this.buttonAddDir.ImageList = this.imageList1;
            this.buttonAddDir.Name = "buttonAddDir";
            this.buttonAddDir.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonAddDir, resources.GetString("buttonAddDir.ToolTip"));
            this.buttonAddDir.UseVisualStyleBackColor = true;
            this.buttonAddDir.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // buttonAddApp
            // 
            resources.ApplyResources(this.buttonAddApp, "buttonAddApp");
            this.buttonAddApp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddApp.FlatAppearance.BorderSize = 0;
            this.buttonAddApp.ForeColor = System.Drawing.Color.Black;
            this.buttonAddApp.ImageList = this.imageList1;
            this.buttonAddApp.Name = "buttonAddApp";
            this.buttonAddApp.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonAddApp, resources.GetString("buttonAddApp.ToolTip"));
            this.buttonAddApp.UseVisualStyleBackColor = true;
            this.buttonAddApp.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelEditShortcut);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAddURL);
            this.Controls.Add(this.buttonAddDir);
            this.Controls.Add(this.buttonAddApp);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelEditShortcut.ResumeLayout(false);
            this.panelEditShortcut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkValidPathToolStripMenuItem;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem createShortcutOnDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem appToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAtWindowsStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAsAdministratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panelEditShortcut;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label labelPara;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxPara;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label labelShortcutType;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddURL;
        private System.Windows.Forms.Button buttonAddDir;
        private System.Windows.Forms.Button buttonAddApp;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vietnameseToolStripMenuItem;
    }
}

