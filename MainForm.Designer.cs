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
            this.buttonSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonAddURL = new System.Windows.Forms.Button();
            this.buttonAddDir = new System.Windows.Forms.Button();
            this.buttonAddApp = new System.Windows.Forms.Button();
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
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelEditShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Click to open XShort Run";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.mainWindowToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.runBoxToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 114);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainWindowToolStripMenuItem
            // 
            this.mainWindowToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainWindowToolStripMenuItem.Name = "mainWindowToolStripMenuItem";
            this.mainWindowToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.mainWindowToolStripMenuItem.Text = "Main Window";
            this.mainWindowToolStripMenuItem.Click += new System.EventHandler(this.mainWindowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // runBoxToolStripMenuItem
            // 
            this.runBoxToolStripMenuItem.Name = "runBoxToolStripMenuItem";
            this.runBoxToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.runBoxToolStripMenuItem.Text = "Run Box";
            this.runBoxToolStripMenuItem.Click += new System.EventHandler(this.runBoxToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.contextMenuStrip2.Size = new System.Drawing.Size(237, 248);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // openAsAdministratorToolStripMenuItem
            // 
            this.openAsAdministratorToolStripMenuItem.Name = "openAsAdministratorToolStripMenuItem";
            this.openAsAdministratorToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.openAsAdministratorToolStripMenuItem.Text = "Open as administrator";
            this.openAsAdministratorToolStripMenuItem.Click += new System.EventHandler(this.openAsAdministratorToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem1
            // 
            this.openFileLocationToolStripMenuItem1.Name = "openFileLocationToolStripMenuItem1";
            this.openFileLocationToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.openFileLocationToolStripMenuItem1.Text = "Open file location";
            this.openFileLocationToolStripMenuItem1.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(233, 6);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.detailsToolStripMenuItem.Text = "Edit";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // checkValidPathToolStripMenuItem
            // 
            this.checkValidPathToolStripMenuItem.Name = "checkValidPathToolStripMenuItem";
            this.checkValidPathToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.checkValidPathToolStripMenuItem.Text = "Check valid path";
            this.checkValidPathToolStripMenuItem.Click += new System.EventHandler(this.checkValidPathToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(233, 6);
            // 
            // openAtWindowsStartupToolStripMenuItem
            // 
            this.openAtWindowsStartupToolStripMenuItem.Name = "openAtWindowsStartupToolStripMenuItem";
            this.openAtWindowsStartupToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.openAtWindowsStartupToolStripMenuItem.Text = "Open at Windows startup";
            this.openAtWindowsStartupToolStripMenuItem.Click += new System.EventHandler(this.openAtWindowsStartupToolStripMenuItem_Click);
            // 
            // createShortcutOnDesktopToolStripMenuItem
            // 
            this.createShortcutOnDesktopToolStripMenuItem.Name = "createShortcutOnDesktopToolStripMenuItem";
            this.createShortcutOnDesktopToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.createShortcutOnDesktopToolStripMenuItem.Text = "Create shortcut on Desktop";
            this.createShortcutOnDesktopToolStripMenuItem.Click += new System.EventHandler(this.createShortcutOnDesktopToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(233, 6);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.cloneToolStripMenuItem.Text = "Clone shortcut";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(236, 22);
            this.addToolStripMenuItem1.Text = "Remove";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(233, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // button13
            // 
            this.button13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button13.BackColor = System.Drawing.Color.DodgerBlue;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(576, 167);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(27, 22);
            this.button13.TabIndex = 10;
            this.button13.TabStop = false;
            this.button13.Text = "...";
            this.toolTip1.SetToolTip(this.button13, "Browse");
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.ImageIndex = 9;
            this.buttonSave.ImageList = this.imageList1;
            this.buttonSave.Location = new System.Drawing.Point(625, 597);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(111, 28);
            this.buttonSave.TabIndex = 36;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "Save";
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonSave, "Save shortcuts");
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
            this.buttonAddURL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAddURL.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddURL.FlatAppearance.BorderSize = 0;
            this.buttonAddURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddURL.ForeColor = System.Drawing.Color.Black;
            this.buttonAddURL.ImageIndex = 10;
            this.buttonAddURL.ImageList = this.imageList1;
            this.buttonAddURL.Location = new System.Drawing.Point(508, 597);
            this.buttonAddURL.Name = "buttonAddURL";
            this.buttonAddURL.Size = new System.Drawing.Size(111, 28);
            this.buttonAddURL.TabIndex = 35;
            this.buttonAddURL.TabStop = false;
            this.buttonAddURL.Text = "Add URL";
            this.buttonAddURL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonAddURL, "Add URL");
            this.buttonAddURL.UseVisualStyleBackColor = true;
            this.buttonAddURL.Click += new System.EventHandler(this.addURLToolStripMenuItem_Click);
            // 
            // buttonAddDir
            // 
            this.buttonAddDir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAddDir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddDir.FlatAppearance.BorderSize = 0;
            this.buttonAddDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddDir.ForeColor = System.Drawing.Color.Black;
            this.buttonAddDir.ImageIndex = 8;
            this.buttonAddDir.ImageList = this.imageList1;
            this.buttonAddDir.Location = new System.Drawing.Point(375, 597);
            this.buttonAddDir.Name = "buttonAddDir";
            this.buttonAddDir.Size = new System.Drawing.Size(127, 28);
            this.buttonAddDir.TabIndex = 34;
            this.buttonAddDir.TabStop = false;
            this.buttonAddDir.Text = "Add Directory";
            this.buttonAddDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonAddDir, "Add Directory");
            this.buttonAddDir.UseVisualStyleBackColor = true;
            this.buttonAddDir.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // buttonAddApp
            // 
            this.buttonAddApp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAddApp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddApp.FlatAppearance.BorderSize = 0;
            this.buttonAddApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddApp.ForeColor = System.Drawing.Color.Black;
            this.buttonAddApp.ImageIndex = 11;
            this.buttonAddApp.ImageList = this.imageList1;
            this.buttonAddApp.Location = new System.Drawing.Point(251, 597);
            this.buttonAddApp.Name = "buttonAddApp";
            this.buttonAddApp.Size = new System.Drawing.Size(118, 28);
            this.buttonAddApp.TabIndex = 33;
            this.buttonAddApp.TabStop = false;
            this.buttonAddApp.Text = "Add App/File";
            this.buttonAddApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.buttonAddApp, "Add App/File");
            this.buttonAddApp.UseVisualStyleBackColor = true;
            this.buttonAddApp.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.appToolStripMenuItem,
            this.actToolStripMenuItem,
            this.aboutToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(986, 25);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeHideToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // minimizeHideToolStripMenuItem
            // 
            this.minimizeHideToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.minimizeHideToolStripMenuItem.Name = "minimizeHideToolStripMenuItem";
            this.minimizeHideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.minimizeHideToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.minimizeHideToolStripMenuItem.Text = "Minimize and Hide";
            this.minimizeHideToolStripMenuItem.Click += new System.EventHandler(this.button7_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // appToolStripMenuItem
            // 
            this.appToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAppToolStripMenuItem,
            this.addDirToolStripMenuItem,
            this.addUrlToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.appToolStripMenuItem.Name = "appToolStripMenuItem";
            this.appToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.appToolStripMenuItem.Text = "Edit";
            // 
            // addAppToolStripMenuItem
            // 
            this.addAppToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addAppToolStripMenuItem.Name = "addAppToolStripMenuItem";
            this.addAppToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.addAppToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.addAppToolStripMenuItem.Text = "Add App/File";
            this.addAppToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addDirToolStripMenuItem
            // 
            this.addDirToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addDirToolStripMenuItem.Name = "addDirToolStripMenuItem";
            this.addDirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.addDirToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.addDirToolStripMenuItem.Text = "Add Directory";
            this.addDirToolStripMenuItem.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // addUrlToolStripMenuItem
            // 
            this.addUrlToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addUrlToolStripMenuItem.Name = "addUrlToolStripMenuItem";
            this.addUrlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.addUrlToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.addUrlToolStripMenuItem.Text = "Add URL";
            this.addUrlToolStripMenuItem.Click += new System.EventHandler(this.addURLToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.saveToolStripMenuItem.Text = "Save && Apply Shortcuts";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveShortcutsToolStripMenuItem_Click);
            // 
            // actToolStripMenuItem
            // 
            this.actToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadDataToolStripMenuItem1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.openSettingsToolStripMenuItem});
            this.actToolStripMenuItem.Name = "actToolStripMenuItem";
            this.actToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.actToolStripMenuItem.Text = "Tools";
            // 
            // reloadDataToolStripMenuItem1
            // 
            this.reloadDataToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.reloadDataToolStripMenuItem1.Name = "reloadDataToolStripMenuItem1";
            this.reloadDataToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.reloadDataToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.reloadDataToolStripMenuItem1.Text = "Reload data";
            this.reloadDataToolStripMenuItem1.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.importToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.importToolStripMenuItem.Text = "Import data";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.exportToolStripMenuItem.Text = "Export data";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Space)));
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openSettingsToolStripMenuItem.Text = "Settings";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homepageToolStripMenuItem,
            this.openAboutToolStripMenuItem});
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem2.Text = "About";
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.homepageToolStripMenuItem.Text = "Homepage";
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // openAboutToolStripMenuItem
            // 
            this.openAboutToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.openAboutToolStripMenuItem.Name = "openAboutToolStripMenuItem";
            this.openAboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.openAboutToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openAboutToolStripMenuItem.Text = "About";
            this.openAboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listViewData
            // 
            this.listViewData.AllowDrop = true;
            this.listViewData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewData.FullRowSelect = true;
            this.listViewData.HideSelection = false;
            this.listViewData.Location = new System.Drawing.Point(0, 0);
            this.listViewData.MultiSelect = false;
            this.listViewData.Name = "listViewData";
            this.listViewData.ShowItemToolTips = true;
            this.listViewData.Size = new System.Drawing.Size(962, 539);
            this.listViewData.TabIndex = 18;
            this.listViewData.TabStop = false;
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
            this.columnHeader1.Text = "Call Name";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 270;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Parameters";
            this.columnHeader3.Width = 92;
            // 
            // panelData
            // 
            this.panelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelData.Controls.Add(this.listViewData);
            this.panelData.Location = new System.Drawing.Point(12, 47);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(962, 539);
            this.panelData.TabIndex = 30;
            // 
            // panelEditShortcut
            // 
            this.panelEditShortcut.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.panelEditShortcut.Location = new System.Drawing.Point(116, 117);
            this.panelEditShortcut.Name = "panelEditShortcut";
            this.panelEditShortcut.Size = new System.Drawing.Size(748, 425);
            this.panelEditShortcut.TabIndex = 29;
            this.panelEditShortcut.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "App/File",
            "Directory",
            "URL"});
            this.comboBox1.Location = new System.Drawing.Point(230, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(373, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.TabStop = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelPara
            // 
            this.labelPara.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPara.AutoSize = true;
            this.labelPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPara.Location = new System.Drawing.Point(139, 216);
            this.labelPara.Name = "labelPara";
            this.labelPara.Size = new System.Drawing.Size(71, 16);
            this.labelPara.TabIndex = 9;
            this.labelPara.Text = "Parameter";
            // 
            // labelPath
            // 
            this.labelPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPath.Location = new System.Drawing.Point(139, 169);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(35, 16);
            this.labelPath.TabIndex = 8;
            this.labelPath.Text = "Path";
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(139, 122);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(71, 16);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Call Name";
            // 
            // textBoxPara
            // 
            this.textBoxPara.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPara.Location = new System.Drawing.Point(230, 214);
            this.textBoxPara.Name = "textBoxPara";
            this.textBoxPara.Size = new System.Drawing.Size(373, 22);
            this.textBoxPara.TabIndex = 6;
            this.textBoxPara.TabStop = false;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(230, 167);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(340, 22);
            this.textBoxPath.TabIndex = 5;
            this.textBoxPath.TabStop = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(230, 120);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(373, 22);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TabStop = false;
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button12.BackColor = System.Drawing.Color.DodgerBlue;
            this.button12.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(390, 311);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(91, 34);
            this.button12.TabIndex = 3;
            this.button12.TabStop = false;
            this.button12.Text = "&Cancel";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button10.BackColor = System.Drawing.Color.DodgerBlue;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(269, 311);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(91, 34);
            this.button10.TabIndex = 2;
            this.button10.TabStop = false;
            this.button10.Text = "&OK";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // labelShortcutType
            // 
            this.labelShortcutType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelShortcutType.AutoSize = true;
            this.labelShortcutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShortcutType.Location = new System.Drawing.Point(139, 78);
            this.labelShortcutType.Name = "labelShortcutType";
            this.labelShortcutType.Size = new System.Drawing.Size(85, 16);
            this.labelShortcutType.TabIndex = 12;
            this.labelShortcutType.Text = "Shortcut type";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(986, 637);
            this.Controls.Add(this.panelEditShortcut);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAddURL);
            this.Controls.Add(this.buttonAddDir);
            this.Controls.Add(this.buttonAddApp);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XShort Core";
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
    }
}

