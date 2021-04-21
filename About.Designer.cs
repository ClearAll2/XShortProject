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
            this.buttonCheckUpdate = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxChangelog = new System.Windows.Forms.GroupBox();
            this.textBoxChangelog = new System.Windows.Forms.TextBox();
            this.panelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxChangelog.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAbout
            // 
            this.panelAbout.BackColor = System.Drawing.Color.White;
            this.panelAbout.Controls.Add(this.groupBoxChangelog);
            this.panelAbout.Controls.Add(this.buttonCheckUpdate);
            this.panelAbout.Controls.Add(this.labelInfo);
            this.panelAbout.Controls.Add(this.pictureBox1);
            this.panelAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAbout.Location = new System.Drawing.Point(0, 0);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Size = new System.Drawing.Size(384, 400);
            this.panelAbout.TabIndex = 29;
            // 
            // buttonCheckUpdate
            // 
            this.buttonCheckUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCheckUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonCheckUpdate.FlatAppearance.BorderSize = 0;
            this.buttonCheckUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckUpdate.Location = new System.Drawing.Point(112, 152);
            this.buttonCheckUpdate.Name = "buttonCheckUpdate";
            this.buttonCheckUpdate.Size = new System.Drawing.Size(178, 28);
            this.buttonCheckUpdate.TabIndex = 24;
            this.buttonCheckUpdate.Text = "Check for update";
            this.buttonCheckUpdate.UseVisualStyleBackColor = false;
            this.buttonCheckUpdate.Click += new System.EventHandler(this.buttonCheckUpdate_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.Black;
            this.labelInfo.Location = new System.Drawing.Point(120, 55);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(131, 57);
            this.labelInfo.TabIndex = 23;
            this.labelInfo.Text = "XShort v1.0\r\nCopyright ©  2017\r\nClear All Soft";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XShort.Properties.Resources.Core;
            this.pictureBox1.Location = new System.Drawing.Point(26, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Bokehlicia-Captiva-Browser-web.ico");
            // 
            // groupBoxChangelog
            // 
            this.groupBoxChangelog.Controls.Add(this.textBoxChangelog);
            this.groupBoxChangelog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxChangelog.Location = new System.Drawing.Point(26, 207);
            this.groupBoxChangelog.Name = "groupBoxChangelog";
            this.groupBoxChangelog.Size = new System.Drawing.Size(332, 181);
            this.groupBoxChangelog.TabIndex = 25;
            this.groupBoxChangelog.TabStop = false;
            this.groupBoxChangelog.Text = "Changelog";
            // 
            // textBoxChangelog
            // 
            this.textBoxChangelog.BackColor = System.Drawing.Color.White;
            this.textBoxChangelog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxChangelog.Location = new System.Drawing.Point(3, 18);
            this.textBoxChangelog.Multiline = true;
            this.textBoxChangelog.Name = "textBoxChangelog";
            this.textBoxChangelog.ReadOnly = true;
            this.textBoxChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxChangelog.Size = new System.Drawing.Size(326, 160);
            this.textBoxChangelog.TabIndex = 0;
            this.textBoxChangelog.TabStop = false;
            this.textBoxChangelog.Text = "#0.7.0.0\r\n-We added update feature.\r\n-We added changelog to About window.\r\n-We fi" +
    "xed a bug related to display of Run box result.\r\n";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 400);
            this.Controls.Add(this.panelAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.About_FormClosing);
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxChangelog.ResumeLayout(false);
            this.groupBoxChangelog.PerformLayout();
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