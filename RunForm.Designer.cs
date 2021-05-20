namespace XShort
{
    partial class RunForm
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
            if (disposing)
            {
                if (_filter != null)
                    _filter.Dispose();

                // this part is added by Visual Studio designer
                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunForm));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxRun = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAsAdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.panelSuggestions = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAsAdministratorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerSuggestions = new System.Windows.Forms.Timer(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxRun
            // 
            resources.ApplyResources(this.comboBoxRun, "comboBoxRun");
            this.comboBoxRun.ContextMenuStrip = this.contextMenuStrip1;
            this.comboBoxRun.ForeColor = System.Drawing.Color.DodgerBlue;
            this.comboBoxRun.FormattingEnabled = true;
            this.comboBoxRun.Name = "comboBoxRun";
            this.comboBoxRun.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            this.comboBoxRun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            this.comboBoxRun.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
            this.comboBoxRun.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboBox1_PreviewKeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAsAdministratorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // openAsAdministratorToolStripMenuItem
            // 
            this.openAsAdministratorToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.openAsAdministratorToolStripMenuItem.Name = "openAsAdministratorToolStripMenuItem";
            resources.ApplyResources(this.openAsAdministratorToolStripMenuItem, "openAsAdministratorToolStripMenuItem");
            this.openAsAdministratorToolStripMenuItem.Click += new System.EventHandler(this.openAsAdministratorToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelInstruction
            // 
            resources.ApplyResources(this.labelInstruction, "labelInstruction");
            this.labelInstruction.ForeColor = System.Drawing.Color.Gray;
            this.labelInstruction.Name = "labelInstruction";
            // 
            // panelSuggestions
            // 
            resources.ApplyResources(this.panelSuggestions, "panelSuggestions");
            this.panelSuggestions.Name = "panelSuggestions";
            this.panelSuggestions.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSuggestions_Paint);
            // 
            // listViewResult
            // 
            this.listViewResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            resources.ApplyResources(this.listViewResult, "listViewResult");
            this.listViewResult.FullRowSelect = true;
            this.listViewResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewResult.HideSelection = false;
            this.listViewResult.MultiSelect = false;
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.SmallImageList = this.imageList1;
            this.listViewResult.TabStop = false;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            this.listViewResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewResult_MouseClick);
            this.listViewResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewResult_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openAsAdministratorToolStripMenuItem1,
            this.openFileLocationToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openAsAdministratorToolStripMenuItem1
            // 
            this.openAsAdministratorToolStripMenuItem1.Name = "openAsAdministratorToolStripMenuItem1";
            resources.ApplyResources(this.openAsAdministratorToolStripMenuItem1, "openAsAdministratorToolStripMenuItem1");
            this.openAsAdministratorToolStripMenuItem1.Click += new System.EventHandler(this.openAsAdministratorToolStripMenuItem1_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            resources.ApplyResources(this.openFileLocationToolStripMenuItem, "openFileLocationToolStripMenuItem");
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // timerSuggestions
            // 
            this.timerSuggestions.Enabled = true;
            this.timerSuggestions.Interval = 600000;
            this.timerSuggestions.Tick += new System.EventHandler(this.timerSuggestions_Tick);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageList2, "imageList2");
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // RunForm
            // 
            this.AcceptButton = this.button1;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.button2;
            this.Controls.Add(this.listViewResult);
            this.Controls.Add(this.panelSuggestions);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxRun);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.Deactivate += new System.EventHandler(this.RunForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RunForm_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxRun;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelInstruction;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openAsAdministratorToolStripMenuItem;
        private System.Windows.Forms.Panel panelSuggestions;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAsAdministratorToolStripMenuItem1;
        private System.Windows.Forms.Timer timerSuggestions;
        private System.Windows.Forms.ImageList imageList2;
    }
}