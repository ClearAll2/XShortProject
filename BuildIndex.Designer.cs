namespace XShort
{
    partial class BuildIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildIndex));
            this.buttonBuildIndexStop = new System.Windows.Forms.Button();
            this.buttonBuildIndex = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPercent = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numberSearchInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.labelFilefound = new System.Windows.Forms.Label();
            this.labelFolderfound = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelHadIndex = new System.Windows.Forms.Label();
            this.buttonDeleteIndex = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberSearchInterval)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBuildIndexStop
            // 
            this.buttonBuildIndexStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonBuildIndexStop.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonBuildIndexStop.Enabled = false;
            this.buttonBuildIndexStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonBuildIndexStop.FlatAppearance.BorderSize = 0;
            this.buttonBuildIndexStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuildIndexStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuildIndexStop.ForeColor = System.Drawing.Color.White;
            this.buttonBuildIndexStop.Location = new System.Drawing.Point(179, 152);
            this.buttonBuildIndexStop.Name = "buttonBuildIndexStop";
            this.buttonBuildIndexStop.Size = new System.Drawing.Size(102, 34);
            this.buttonBuildIndexStop.TabIndex = 19;
            this.buttonBuildIndexStop.Text = "Stop";
            this.buttonBuildIndexStop.UseVisualStyleBackColor = false;
            this.buttonBuildIndexStop.Click += new System.EventHandler(this.buttonBuildIndexStop_Click);
            // 
            // buttonBuildIndex
            // 
            this.buttonBuildIndex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonBuildIndex.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonBuildIndex.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonBuildIndex.FlatAppearance.BorderSize = 0;
            this.buttonBuildIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuildIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuildIndex.ForeColor = System.Drawing.Color.White;
            this.buttonBuildIndex.Location = new System.Drawing.Point(61, 152);
            this.buttonBuildIndex.Name = "buttonBuildIndex";
            this.buttonBuildIndex.Size = new System.Drawing.Size(102, 34);
            this.buttonBuildIndex.TabIndex = 18;
            this.buttonBuildIndex.Text = "Start";
            this.buttonBuildIndex.UseVisualStyleBackColor = false;
            this.buttonBuildIndex.Click += new System.EventHandler(this.buttonBuildIndex_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.labelPercent);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numberSearchInterval);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelFilefound);
            this.groupBox1.Controls.Add(this.labelFolderfound);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 130);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Status";
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(177, 76);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(21, 13);
            this.labelPercent.TabIndex = 7;
            this.labelPercent.Text = "0%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Completed:";
            // 
            // numberSearchInterval
            // 
            this.numberSearchInterval.Location = new System.Drawing.Point(180, 102);
            this.numberSearchInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numberSearchInterval.Name = "numberSearchInterval";
            this.numberSearchInterval.Size = new System.Drawing.Size(48, 20);
            this.numberSearchInterval.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Search Interval:";
            // 
            // labelFilefound
            // 
            this.labelFilefound.AutoSize = true;
            this.labelFilefound.Location = new System.Drawing.Point(177, 49);
            this.labelFilefound.Name = "labelFilefound";
            this.labelFilefound.Size = new System.Drawing.Size(13, 13);
            this.labelFilefound.TabIndex = 3;
            this.labelFilefound.Text = "0";
            // 
            // labelFolderfound
            // 
            this.labelFolderfound.AutoSize = true;
            this.labelFolderfound.Location = new System.Drawing.Point(177, 21);
            this.labelFolderfound.Name = "labelFolderfound";
            this.labelFolderfound.Size = new System.Drawing.Size(13, 13);
            this.labelFolderfound.TabIndex = 2;
            this.labelFolderfound.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Files found:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Folders found:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "When the indexing is complete, you’ll be able to find all your files almost insta" +
    "ntly when you use XShort Run.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 46);
            this.label2.TabIndex = 20;
            this.label2.Text = "It will take about 30 minutes to find all your folders and files. If you have lot" +
    "s of files, it will take longer. The indexing will increase cpu consumption.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(12, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 31);
            this.label3.TabIndex = 21;
            this.label3.Text = "Search interval is the speed of the indexing. You can increase this value for smo" +
    "oth performance of computer.";
            // 
            // labelHadIndex
            // 
            this.labelHadIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHadIndex.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHadIndex.Location = new System.Drawing.Point(12, 197);
            this.labelHadIndex.Name = "labelHadIndex";
            this.labelHadIndex.Size = new System.Drawing.Size(149, 21);
            this.labelHadIndex.TabIndex = 22;
            this.labelHadIndex.Text = "Found no index files";
            // 
            // buttonDeleteIndex
            // 
            this.buttonDeleteIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteIndex.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonDeleteIndex.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteIndex.FlatAppearance.BorderSize = 0;
            this.buttonDeleteIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteIndex.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteIndex.Location = new System.Drawing.Point(177, 190);
            this.buttonDeleteIndex.Name = "buttonDeleteIndex";
            this.buttonDeleteIndex.Size = new System.Drawing.Size(145, 26);
            this.buttonDeleteIndex.TabIndex = 23;
            this.buttonDeleteIndex.Text = "Delete index files";
            this.buttonDeleteIndex.UseVisualStyleBackColor = false;
            this.buttonDeleteIndex.Visible = false;
            this.buttonDeleteIndex.Click += new System.EventHandler(this.buttonDeleteIndex_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(12, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(326, 46);
            this.label8.TabIndex = 24;
            this.label8.Text = "If you want to make it faster, you can turn off real-time protection on your anti" +
    "-virus program. The real-time protection slows down the indexing speed.";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonBuildIndexStop);
            this.panel1.Controls.Add(this.buttonBuildIndex);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 218);
            this.panel1.TabIndex = 25;
            // 
            // BuildIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(347, 447);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonDeleteIndex);
            this.Controls.Add(this.labelHadIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Build Search Index";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberSearchInterval)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBuildIndexStop;
        private System.Windows.Forms.Button buttonBuildIndex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numberSearchInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelFilefound;
        private System.Windows.Forms.Label labelFolderfound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelHadIndex;
        private System.Windows.Forms.Button buttonDeleteIndex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
    }
}