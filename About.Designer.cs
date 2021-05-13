namespace XShort
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.panelAbout = new System.Windows.Forms.Panel();
            this.groupBoxChangelog = new System.Windows.Forms.GroupBox();
            this.textBoxChangelog = new System.Windows.Forms.TextBox();
            this.buttonCheckUpdate = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelAbout.SuspendLayout();
            this.groupBoxChangelog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAbout
            // 
            resources.ApplyResources(this.panelAbout, "panelAbout");
            this.panelAbout.BackColor = System.Drawing.Color.White;
            this.panelAbout.Controls.Add(this.groupBoxChangelog);
            this.panelAbout.Controls.Add(this.buttonCheckUpdate);
            this.panelAbout.Controls.Add(this.labelInfo);
            this.panelAbout.Controls.Add(this.pictureBox1);
            this.panelAbout.Name = "panelAbout";
            // 
            // groupBoxChangelog
            // 
            resources.ApplyResources(this.groupBoxChangelog, "groupBoxChangelog");
            this.groupBoxChangelog.Controls.Add(this.textBoxChangelog);
            this.groupBoxChangelog.Name = "groupBoxChangelog";
            this.groupBoxChangelog.TabStop = false;
            // 
            // textBoxChangelog
            // 
            resources.ApplyResources(this.textBoxChangelog, "textBoxChangelog");
            this.textBoxChangelog.BackColor = System.Drawing.Color.White;
            this.textBoxChangelog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxChangelog.Name = "textBoxChangelog";
            this.textBoxChangelog.ReadOnly = true;
            this.textBoxChangelog.TabStop = false;
            // 
            // buttonCheckUpdate
            // 
            resources.ApplyResources(this.buttonCheckUpdate, "buttonCheckUpdate");
            this.buttonCheckUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCheckUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonCheckUpdate.FlatAppearance.BorderSize = 0;
            this.buttonCheckUpdate.Name = "buttonCheckUpdate";
            this.buttonCheckUpdate.UseVisualStyleBackColor = false;
            this.buttonCheckUpdate.Click += new System.EventHandler(this.buttonCheckUpdate_Click);
            // 
            // labelInfo
            // 
            resources.ApplyResources(this.labelInfo, "labelInfo");
            this.labelInfo.ForeColor = System.Drawing.Color.Black;
            this.labelInfo.Name = "labelInfo";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::XShort.Properties.Resources.Core;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Bokehlicia-Captiva-Browser-web.ico");
            // 
            // About
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.About_FormClosing);
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            this.groupBoxChangelog.ResumeLayout(false);
            this.groupBoxChangelog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAbout;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonCheckUpdate;
        private System.Windows.Forms.GroupBox groupBoxChangelog;
        private System.Windows.Forms.TextBox textBoxChangelog;
    }
}