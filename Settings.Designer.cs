namespace XShort
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelBuildIndexInterval = new System.Windows.Forms.Label();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxUseIndex = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelHotkey = new System.Windows.Forms.Panel();
            this.labelInfoForNewHotkey = new System.Windows.Forms.Label();
            this.radioButtonShift = new System.Windows.Forms.RadioButton();
            this.radioButtonControl = new System.Windows.Forms.RadioButton();
            this.radioButtonAlt = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelBlocklist = new System.Windows.Forms.Panel();
            this.buttonCancelBlocklist = new System.Windows.Forms.Button();
            this.checkBoxExcludeResultSuggestion = new System.Windows.Forms.CheckBox();
            this.listViewBlocklist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSaveBlocklist = new System.Windows.Forms.Button();
            this.numericUpDownMaxSuggestNum = new System.Windows.Forms.NumericUpDown();
            this.labelMaxSuggest = new System.Windows.Forms.Label();
            this.buttonBlocklist = new System.Windows.Forms.Button();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.checkBoxSearchResult = new System.Windows.Forms.CheckBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.checkBoxSuggestions = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelSetting.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panelHotkey.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelBlocklist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSuggestNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.White;
            this.panelSetting.Controls.Add(this.groupBox4);
            this.panelSetting.Controls.Add(this.groupBox3);
            this.panelSetting.Controls.Add(this.groupBox2);
            this.panelSetting.Controls.Add(this.groupBox1);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(1069, 602);
            this.panelSetting.TabIndex = 28;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.numericUpDownInterval);
            this.groupBox4.Controls.Add(this.labelBuildIndexInterval);
            this.groupBox4.Controls.Add(this.labelLastUpdate);
            this.groupBox4.Controls.Add(this.labelError);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.checkBoxUseIndex);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(537, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(504, 308);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Index Result";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownInterval.DecimalPlaces = 1;
            this.numericUpDownInterval.Location = new System.Drawing.Point(245, 179);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownInterval.TabIndex = 20;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // labelBuildIndexInterval
            // 
            this.labelBuildIndexInterval.AutoSize = true;
            this.labelBuildIndexInterval.Location = new System.Drawing.Point(23, 178);
            this.labelBuildIndexInterval.Name = "labelBuildIndexInterval";
            this.labelBuildIndexInterval.Size = new System.Drawing.Size(173, 18);
            this.labelBuildIndexInterval.TabIndex = 17;
            this.labelBuildIndexInterval.Text = "Build index every (hours):";
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastUpdate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelLastUpdate.Location = new System.Drawing.Point(23, 224);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(452, 20);
            this.labelLastUpdate.TabIndex = 19;
            this.labelLastUpdate.Text = "Last update: N/A";
            // 
            // labelError
            // 
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelError.Location = new System.Drawing.Point(23, 272);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(194, 20);
            this.labelError.TabIndex = 18;
            this.labelError.Text = "No XShortCoreIndex.exe found!";
            this.labelError.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(23, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 94);
            this.label1.TabIndex = 17;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // checkBoxUseIndex
            // 
            this.checkBoxUseIndex.AutoSize = true;
            this.checkBoxUseIndex.Location = new System.Drawing.Point(26, 39);
            this.checkBoxUseIndex.Name = "checkBoxUseIndex";
            this.checkBoxUseIndex.Size = new System.Drawing.Size(179, 22);
            this.checkBoxUseIndex.TabIndex = 10;
            this.checkBoxUseIndex.Text = "Use XShort Core Index";
            this.checkBoxUseIndex.UseVisualStyleBackColor = true;
            this.checkBoxUseIndex.CheckedChanged += new System.EventHandler(this.checkBoxUseIndex_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.panelHotkey);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(537, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 247);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hotkey";
            // 
            // panelHotkey
            // 
            this.panelHotkey.Controls.Add(this.labelInfoForNewHotkey);
            this.panelHotkey.Controls.Add(this.radioButtonShift);
            this.panelHotkey.Controls.Add(this.radioButtonControl);
            this.panelHotkey.Controls.Add(this.radioButtonAlt);
            this.panelHotkey.Controls.Add(this.comboBox2);
            this.panelHotkey.Controls.Add(this.label10);
            this.panelHotkey.Controls.Add(this.label9);
            this.panelHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHotkey.Location = new System.Drawing.Point(3, 20);
            this.panelHotkey.Name = "panelHotkey";
            this.panelHotkey.Size = new System.Drawing.Size(501, 224);
            this.panelHotkey.TabIndex = 7;
            // 
            // labelInfoForNewHotkey
            // 
            this.labelInfoForNewHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoForNewHotkey.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelInfoForNewHotkey.Location = new System.Drawing.Point(105, 154);
            this.labelInfoForNewHotkey.Name = "labelInfoForNewHotkey";
            this.labelInfoForNewHotkey.Size = new System.Drawing.Size(318, 22);
            this.labelInfoForNewHotkey.TabIndex = 19;
            this.labelInfoForNewHotkey.Text = "New hotkey will be applied after closing this window.";
            // 
            // radioButtonShift
            // 
            this.radioButtonShift.AutoSize = true;
            this.radioButtonShift.Location = new System.Drawing.Point(358, 41);
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
            this.radioButtonControl.Location = new System.Drawing.Point(263, 41);
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
            this.radioButtonAlt.Location = new System.Drawing.Point(192, 41);
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
            this.comboBox2.Location = new System.Drawing.Point(242, 82);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(96, 26);
            this.comboBox2.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = "Keys:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(105, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Modifiers:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.panelBlocklist);
            this.groupBox2.Controls.Add(this.numericUpDownMaxSuggestNum);
            this.groupBox2.Controls.Add(this.labelMaxSuggest);
            this.groupBox2.Controls.Add(this.buttonBlocklist);
            this.groupBox2.Controls.Add(this.labelInfo1);
            this.groupBox2.Controls.Add(this.checkBoxSearchResult);
            this.groupBox2.Controls.Add(this.labelInfo);
            this.groupBox2.Controls.Add(this.checkBoxSuggestions);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(24, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 308);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Suggestions";
            // 
            // panelBlocklist
            // 
            this.panelBlocklist.Controls.Add(this.buttonCancelBlocklist);
            this.panelBlocklist.Controls.Add(this.checkBoxExcludeResultSuggestion);
            this.panelBlocklist.Controls.Add(this.listViewBlocklist);
            this.panelBlocklist.Controls.Add(this.buttonSaveBlocklist);
            this.panelBlocklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBlocklist.Location = new System.Drawing.Point(3, 20);
            this.panelBlocklist.Name = "panelBlocklist";
            this.panelBlocklist.Size = new System.Drawing.Size(482, 285);
            this.panelBlocklist.TabIndex = 15;
            this.panelBlocklist.Visible = false;
            // 
            // buttonCancelBlocklist
            // 
            this.buttonCancelBlocklist.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCancelBlocklist.FlatAppearance.BorderSize = 0;
            this.buttonCancelBlocklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelBlocklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelBlocklist.ForeColor = System.Drawing.Color.White;
            this.buttonCancelBlocklist.Location = new System.Drawing.Point(376, 243);
            this.buttonCancelBlocklist.Name = "buttonCancelBlocklist";
            this.buttonCancelBlocklist.Size = new System.Drawing.Size(93, 29);
            this.buttonCancelBlocklist.TabIndex = 19;
            this.buttonCancelBlocklist.Text = "Cancel";
            this.buttonCancelBlocklist.UseVisualStyleBackColor = false;
            this.buttonCancelBlocklist.Click += new System.EventHandler(this.buttonCancelBlocklist_Click);
            // 
            // checkBoxExcludeResultSuggestion
            // 
            this.checkBoxExcludeResultSuggestion.AutoSize = true;
            this.checkBoxExcludeResultSuggestion.Location = new System.Drawing.Point(13, 246);
            this.checkBoxExcludeResultSuggestion.Name = "checkBoxExcludeResultSuggestion";
            this.checkBoxExcludeResultSuggestion.Size = new System.Drawing.Size(192, 22);
            this.checkBoxExcludeResultSuggestion.TabIndex = 18;
            this.checkBoxExcludeResultSuggestion.Text = "Apply Result suggestions";
            this.toolTip1.SetToolTip(this.checkBoxExcludeResultSuggestion, "Blocklisted shortcuts will not show in result suggestions as well");
            this.checkBoxExcludeResultSuggestion.UseVisualStyleBackColor = true;
            this.checkBoxExcludeResultSuggestion.CheckedChanged += new System.EventHandler(this.checkBoxExcludeResultSuggestion_CheckedChanged);
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
            this.listViewBlocklist.Location = new System.Drawing.Point(13, 19);
            this.listViewBlocklist.Name = "listViewBlocklist";
            this.listViewBlocklist.Size = new System.Drawing.Size(456, 218);
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
            this.buttonSaveBlocklist.Location = new System.Drawing.Point(265, 243);
            this.buttonSaveBlocklist.Name = "buttonSaveBlocklist";
            this.buttonSaveBlocklist.Size = new System.Drawing.Size(93, 29);
            this.buttonSaveBlocklist.TabIndex = 15;
            this.buttonSaveBlocklist.Text = "Save";
            this.buttonSaveBlocklist.UseVisualStyleBackColor = false;
            this.buttonSaveBlocklist.Click += new System.EventHandler(this.buttonSaveBlocklist_Click);
            // 
            // numericUpDownMaxSuggestNum
            // 
            this.numericUpDownMaxSuggestNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownMaxSuggestNum.Location = new System.Drawing.Point(258, 204);
            this.numericUpDownMaxSuggestNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownMaxSuggestNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownMaxSuggestNum.Name = "numericUpDownMaxSuggestNum";
            this.numericUpDownMaxSuggestNum.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownMaxSuggestNum.TabIndex = 16;
            this.numericUpDownMaxSuggestNum.TabStop = false;
            this.numericUpDownMaxSuggestNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.numericUpDownMaxSuggestNum, "Max suggestions items in Run box");
            this.numericUpDownMaxSuggestNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelMaxSuggest
            // 
            this.labelMaxSuggest.AutoSize = true;
            this.labelMaxSuggest.Location = new System.Drawing.Point(20, 203);
            this.labelMaxSuggest.Name = "labelMaxSuggest";
            this.labelMaxSuggest.Size = new System.Drawing.Size(232, 18);
            this.labelMaxSuggest.TabIndex = 15;
            this.labelMaxSuggest.Text = "Max shortcut suggestions number";
            // 
            // buttonBlocklist
            // 
            this.buttonBlocklist.FlatAppearance.BorderSize = 0;
            this.buttonBlocklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBlocklist.Location = new System.Drawing.Point(16, 254);
            this.buttonBlocklist.Name = "buttonBlocklist";
            this.buttonBlocklist.Size = new System.Drawing.Size(457, 31);
            this.buttonBlocklist.TabIndex = 14;
            this.buttonBlocklist.Text = "Blocklist";
            this.buttonBlocklist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.buttonBlocklist, "List of shortcuts that you don\'t want to see them in Suggestions.");
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
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(24, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 247);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1069, 602);
            this.Controls.Add(this.panelSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.panelSetting.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panelHotkey.ResumeLayout(false);
            this.panelHotkey.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelBlocklist.ResumeLayout(false);
            this.panelBlocklist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSuggestNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.Button buttonCancelBlocklist;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSuggestNum;
        private System.Windows.Forms.Label labelMaxSuggest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxUseIndex;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelInfoForNewHotkey;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.Label labelBuildIndexInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
    }
}