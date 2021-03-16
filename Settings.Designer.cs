﻿namespace XShort
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panelSetting = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelBlocklist = new System.Windows.Forms.Panel();
            this.listViewBlocklist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSaveBlocklist = new System.Windows.Forms.Button();
            this.buttonBlocklist = new System.Windows.Forms.Button();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.checkBoxSearchResult = new System.Windows.Forms.CheckBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.checkBoxSuggestions = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelHotkey = new System.Windows.Forms.Panel();
            this.radioButtonShift = new System.Windows.Forms.RadioButton();
            this.radioButtonControl = new System.Windows.Forms.RadioButton();
            this.radioButtonAlt = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.labelHotKeyConfig = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxExcludeResultSuggestion = new System.Windows.Forms.CheckBox();
            this.panelSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelBlocklist.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelHotkey.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.White;
            this.panelSetting.Controls.Add(this.groupBox2);
            this.panelSetting.Controls.Add(this.groupBox1);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(544, 531);
            this.panelSetting.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelBlocklist);
            this.groupBox2.Controls.Add(this.buttonBlocklist);
            this.groupBox2.Controls.Add(this.labelInfo1);
            this.groupBox2.Controls.Add(this.checkBoxSearchResult);
            this.groupBox2.Controls.Add(this.labelInfo);
            this.groupBox2.Controls.Add(this.checkBoxSuggestions);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 245);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Suggestions";
            // 
            // panelBlocklist
            // 
            this.panelBlocklist.Controls.Add(this.checkBoxExcludeResultSuggestion);
            this.panelBlocklist.Controls.Add(this.listViewBlocklist);
            this.panelBlocklist.Controls.Add(this.buttonSaveBlocklist);
            this.panelBlocklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBlocklist.Location = new System.Drawing.Point(3, 20);
            this.panelBlocklist.Name = "panelBlocklist";
            this.panelBlocklist.Size = new System.Drawing.Size(482, 222);
            this.panelBlocklist.TabIndex = 15;
            this.panelBlocklist.Visible = false;
            // 
            // listViewBlocklist
            // 
            this.listViewBlocklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewBlocklist.CheckBoxes = true;
            this.listViewBlocklist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewBlocklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBlocklist.FullRowSelect = true;
            this.listViewBlocklist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewBlocklist.HideSelection = false;
            this.listViewBlocklist.Location = new System.Drawing.Point(20, 19);
            this.listViewBlocklist.Name = "listViewBlocklist";
            this.listViewBlocklist.Size = new System.Drawing.Size(449, 153);
            this.listViewBlocklist.TabIndex = 17;
            this.listViewBlocklist.UseCompatibleStateImageBehavior = false;
            this.listViewBlocklist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 427;
            // 
            // buttonSaveBlocklist
            // 
            this.buttonSaveBlocklist.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSaveBlocklist.FlatAppearance.BorderSize = 0;
            this.buttonSaveBlocklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveBlocklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveBlocklist.ForeColor = System.Drawing.Color.White;
            this.buttonSaveBlocklist.Location = new System.Drawing.Point(376, 178);
            this.buttonSaveBlocklist.Name = "buttonSaveBlocklist";
            this.buttonSaveBlocklist.Size = new System.Drawing.Size(93, 29);
            this.buttonSaveBlocklist.TabIndex = 15;
            this.buttonSaveBlocklist.Text = "Close";
            this.buttonSaveBlocklist.UseVisualStyleBackColor = false;
            this.buttonSaveBlocklist.Click += new System.EventHandler(this.buttonSaveBlocklist_Click);
            // 
            // buttonBlocklist
            // 
            this.buttonBlocklist.FlatAppearance.BorderSize = 0;
            this.buttonBlocklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBlocklist.Location = new System.Drawing.Point(23, 196);
            this.buttonBlocklist.Name = "buttonBlocklist";
            this.buttonBlocklist.Size = new System.Drawing.Size(449, 31);
            this.buttonBlocklist.TabIndex = 14;
            this.buttonBlocklist.Text = "Blocklist";
            this.buttonBlocklist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonBlocklist, "List of shortcuts that you don\'t want them in Suggestions.");
            this.buttonBlocklist.UseVisualStyleBackColor = true;
            this.buttonBlocklist.Click += new System.EventHandler(this.buttonBlocklist_Click);
            // 
            // labelInfo1
            // 
            this.labelInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelInfo1.Location = new System.Drawing.Point(20, 74);
            this.labelInfo1.Name = "labelInfo1";
            this.labelInfo1.Size = new System.Drawing.Size(452, 26);
            this.labelInfo1.TabIndex = 13;
            this.labelInfo1.Text = "Result suggestions are based on your input.";
            // 
            // checkBoxSearchResult
            // 
            this.checkBoxSearchResult.AutoSize = true;
            this.checkBoxSearchResult.Location = new System.Drawing.Point(23, 39);
            this.checkBoxSearchResult.Name = "checkBoxSearchResult";
            this.checkBoxSearchResult.Size = new System.Drawing.Size(268, 22);
            this.checkBoxSearchResult.TabIndex = 12;
            this.checkBoxSearchResult.Text = "Show result suggestions while typing";
            this.checkBoxSearchResult.UseVisualStyleBackColor = true;
            this.checkBoxSearchResult.CheckedChanged += new System.EventHandler(this.checkBoxSearchResult_CheckedChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelInfo.Location = new System.Drawing.Point(20, 147);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(452, 46);
            this.labelInfo.TabIndex = 11;
            this.labelInfo.Text = "Shortcut suggestions are based on your recently called shortcuts, most-called sho" +
    "rtcuts and routines.";
            // 
            // checkBoxSuggestions
            // 
            this.checkBoxSuggestions.AutoSize = true;
            this.checkBoxSuggestions.Location = new System.Drawing.Point(23, 113);
            this.checkBoxSuggestions.Name = "checkBoxSuggestions";
            this.checkBoxSuggestions.Size = new System.Drawing.Size(207, 22);
            this.checkBoxSuggestions.TabIndex = 10;
            this.checkBoxSuggestions.Text = "Show shortcut suggestions";
            this.checkBoxSuggestions.UseVisualStyleBackColor = true;
            this.checkBoxSuggestions.CheckedChanged += new System.EventHandler(this.checkBoxSuggestions_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panelHotkey);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(27, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 247);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // panelHotkey
            // 
            this.panelHotkey.Controls.Add(this.radioButtonShift);
            this.panelHotkey.Controls.Add(this.radioButtonControl);
            this.panelHotkey.Controls.Add(this.radioButtonAlt);
            this.panelHotkey.Controls.Add(this.comboBox2);
            this.panelHotkey.Controls.Add(this.label10);
            this.panelHotkey.Controls.Add(this.button15);
            this.panelHotkey.Controls.Add(this.button14);
            this.panelHotkey.Controls.Add(this.label9);
            this.panelHotkey.Controls.Add(this.labelHotKeyConfig);
            this.panelHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHotkey.Location = new System.Drawing.Point(3, 20);
            this.panelHotkey.Name = "panelHotkey";
            this.panelHotkey.Size = new System.Drawing.Size(482, 224);
            this.panelHotkey.TabIndex = 7;
            this.panelHotkey.Visible = false;
            // 
            // radioButtonShift
            // 
            this.radioButtonShift.AutoSize = true;
            this.radioButtonShift.Location = new System.Drawing.Point(338, 47);
            this.radioButtonShift.Name = "radioButtonShift";
            this.radioButtonShift.Size = new System.Drawing.Size(55, 22);
            this.radioButtonShift.TabIndex = 14;
            this.radioButtonShift.TabStop = true;
            this.radioButtonShift.Text = "Shift";
            this.radioButtonShift.UseVisualStyleBackColor = true;
            this.radioButtonShift.CheckedChanged += new System.EventHandler(this.radioButtonShift_CheckedChanged);
            // 
            // radioButtonControl
            // 
            this.radioButtonControl.AutoSize = true;
            this.radioButtonControl.Location = new System.Drawing.Point(243, 47);
            this.radioButtonControl.Name = "radioButtonControl";
            this.radioButtonControl.Size = new System.Drawing.Size(75, 22);
            this.radioButtonControl.TabIndex = 13;
            this.radioButtonControl.TabStop = true;
            this.radioButtonControl.Text = "Control";
            this.radioButtonControl.UseVisualStyleBackColor = true;
            this.radioButtonControl.CheckedChanged += new System.EventHandler(this.radioButtonControl_CheckedChanged);
            // 
            // radioButtonAlt
            // 
            this.radioButtonAlt.AutoSize = true;
            this.radioButtonAlt.Location = new System.Drawing.Point(172, 47);
            this.radioButtonAlt.Name = "radioButtonAlt";
            this.radioButtonAlt.Size = new System.Drawing.Size(42, 22);
            this.radioButtonAlt.TabIndex = 12;
            this.radioButtonAlt.TabStop = true;
            this.radioButtonAlt.Text = "Alt";
            this.radioButtonAlt.UseVisualStyleBackColor = true;
            this.radioButtonAlt.CheckedChanged += new System.EventHandler(this.radioButtonAlt_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.comboBox2.Location = new System.Drawing.Point(192, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(96, 26);
            this.comboBox2.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(113, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = "Keys:";
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.DodgerBlue;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(376, 166);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(93, 29);
            this.button15.TabIndex = 6;
            this.button15.Text = "Cancel";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.DodgerBlue;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(265, 166);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(93, 29);
            this.button14.TabIndex = 5;
            this.button14.Text = "Apply";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Modifiers:";
            // 
            // labelHotKeyConfig
            // 
            this.labelHotKeyConfig.AutoSize = true;
            this.labelHotKeyConfig.Location = new System.Drawing.Point(130, 5);
            this.labelHotKeyConfig.Name = "labelHotKeyConfig";
            this.labelHotKeyConfig.Size = new System.Drawing.Size(228, 18);
            this.labelHotKeyConfig.TabIndex = 1;
            this.labelHotKeyConfig.Text = "XShort Run Hotkey Configuration";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(399, 38);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(73, 18);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Hotkey>>";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(23, 118);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(268, 22);
            this.checkBox7.TabIndex = 5;
            this.checkBox7.Text = "Automatically detect invalid shortcuts";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(23, 174);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(117, 22);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Hide tray icon";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(23, 146);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(124, 22);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Case-sensitive";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(185, 22);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Run at Windows startup";
            this.toolTip1.SetToolTip(this.checkBox1, "Automatically run this application when you start Windows");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(23, 62);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(220, 22);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Hide this dialog box at startup";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(23, 90);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(280, 22);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Automatically search Google if no data";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(23, 202);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(217, 22);
            this.checkBox8.TabIndex = 9;
            this.checkBox8.Text = "Don\'t load main list at startup";
            this.toolTip1.SetToolTip(this.checkBox8, "This will improve loading time");
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBoxExcludeResultSuggestion
            // 
            this.checkBoxExcludeResultSuggestion.AutoSize = true;
            this.checkBoxExcludeResultSuggestion.Location = new System.Drawing.Point(20, 181);
            this.checkBoxExcludeResultSuggestion.Name = "checkBoxExcludeResultSuggestion";
            this.checkBoxExcludeResultSuggestion.Size = new System.Drawing.Size(269, 22);
            this.checkBoxExcludeResultSuggestion.TabIndex = 18;
            this.checkBoxExcludeResultSuggestion.Text = "Also exclude from result suggestions";
            this.checkBoxExcludeResultSuggestion.UseVisualStyleBackColor = true;
            this.checkBoxExcludeResultSuggestion.CheckedChanged += new System.EventHandler(this.checkBoxExcludeResultSuggestion_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 531);
            this.Controls.Add(this.panelSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.panelSetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelBlocklist.ResumeLayout(false);
            this.panelBlocklist.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelHotkey.ResumeLayout(false);
            this.panelHotkey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelHotkey;
        private System.Windows.Forms.RadioButton radioButtonShift;
        private System.Windows.Forms.RadioButton radioButtonControl;
        private System.Windows.Forms.RadioButton radioButtonAlt;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelHotKeyConfig;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.CheckBox checkBoxSuggestions;
        private System.Windows.Forms.CheckBox checkBoxSearchResult;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.Button buttonBlocklist;
        private System.Windows.Forms.Panel panelBlocklist;
        private System.Windows.Forms.Button buttonSaveBlocklist;
        private System.Windows.Forms.ListView listViewBlocklist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox checkBoxExcludeResultSuggestion;
    }
}