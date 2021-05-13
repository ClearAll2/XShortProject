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
            this.panelExIntro = new System.Windows.Forms.Panel();
            this.buttonExclusionList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonExBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRunningProcesses = new System.Windows.Forms.ComboBox();
            this.buttonRemoveEx = new System.Windows.Forms.Button();
            this.buttonAddEx = new System.Windows.Forms.Button();
            this.buttonBrowseExe = new System.Windows.Forms.Button();
            this.listViewExclusion = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelBlocklist = new System.Windows.Forms.Panel();
            this.labelExplainBlocklist = new System.Windows.Forms.Label();
            this.labelExplainBlocklistBlockResult = new System.Windows.Forms.Label();
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
            this.panelHotkey = new System.Windows.Forms.Panel();
            this.buttonHotkeyCancel = new System.Windows.Forms.Button();
            this.buttonApplyHotkey = new System.Windows.Forms.Button();
            this.labelInfoForNewHotkey = new System.Windows.Forms.Label();
            this.radioButtonShift = new System.Windows.Forms.RadioButton();
            this.radioButtonControl = new System.Windows.Forms.RadioButton();
            this.radioButtonAlt = new System.Windows.Forms.RadioButton();
            this.comboBoxHotkey = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.buttonHotkeySetting = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelSetting.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panelExIntro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelBlocklist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSuggestNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelHotkey.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSetting
            // 
            resources.ApplyResources(this.panelSetting, "panelSetting");
            this.panelSetting.BackColor = System.Drawing.Color.White;
            this.panelSetting.Controls.Add(this.groupBox4);
            this.panelSetting.Controls.Add(this.groupBox3);
            this.panelSetting.Controls.Add(this.groupBox2);
            this.panelSetting.Controls.Add(this.groupBox1);
            this.panelSetting.Name = "panelSetting";
            this.toolTip1.SetToolTip(this.panelSetting, resources.GetString("panelSetting.ToolTip"));
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.numericUpDownInterval);
            this.groupBox4.Controls.Add(this.labelBuildIndexInterval);
            this.groupBox4.Controls.Add(this.labelLastUpdate);
            this.groupBox4.Controls.Add(this.labelError);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.checkBoxUseIndex);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // numericUpDownInterval
            // 
            resources.ApplyResources(this.numericUpDownInterval, "numericUpDownInterval");
            this.numericUpDownInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownInterval.DecimalPlaces = 1;
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.toolTip1.SetToolTip(this.numericUpDownInterval, resources.GetString("numericUpDownInterval.ToolTip"));
            this.numericUpDownInterval.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // labelBuildIndexInterval
            // 
            resources.ApplyResources(this.labelBuildIndexInterval, "labelBuildIndexInterval");
            this.labelBuildIndexInterval.Name = "labelBuildIndexInterval";
            this.toolTip1.SetToolTip(this.labelBuildIndexInterval, resources.GetString("labelBuildIndexInterval.ToolTip"));
            // 
            // labelLastUpdate
            // 
            resources.ApplyResources(this.labelLastUpdate, "labelLastUpdate");
            this.labelLastUpdate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.toolTip1.SetToolTip(this.labelLastUpdate, resources.GetString("labelLastUpdate.ToolTip"));
            // 
            // labelError
            // 
            resources.ApplyResources(this.labelError, "labelError");
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Name = "labelError";
            this.toolTip1.SetToolTip(this.labelError, resources.GetString("labelError.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // checkBoxUseIndex
            // 
            resources.ApplyResources(this.checkBoxUseIndex, "checkBoxUseIndex");
            this.checkBoxUseIndex.Name = "checkBoxUseIndex";
            this.toolTip1.SetToolTip(this.checkBoxUseIndex, resources.GetString("checkBoxUseIndex.ToolTip"));
            this.checkBoxUseIndex.UseVisualStyleBackColor = true;
            this.checkBoxUseIndex.CheckedChanged += new System.EventHandler(this.checkBoxUseIndex_CheckedChanged);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.panelExIntro);
            this.groupBox3.Controls.Add(this.buttonExBack);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBoxRunningProcesses);
            this.groupBox3.Controls.Add(this.buttonRemoveEx);
            this.groupBox3.Controls.Add(this.buttonAddEx);
            this.groupBox3.Controls.Add(this.buttonBrowseExe);
            this.groupBox3.Controls.Add(this.listViewExclusion);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // panelExIntro
            // 
            resources.ApplyResources(this.panelExIntro, "panelExIntro");
            this.panelExIntro.Controls.Add(this.buttonExclusionList);
            this.panelExIntro.Controls.Add(this.label3);
            this.panelExIntro.Name = "panelExIntro";
            this.toolTip1.SetToolTip(this.panelExIntro, resources.GetString("panelExIntro.ToolTip"));
            // 
            // buttonExclusionList
            // 
            resources.ApplyResources(this.buttonExclusionList, "buttonExclusionList");
            this.buttonExclusionList.BackColor = System.Drawing.Color.White;
            this.buttonExclusionList.FlatAppearance.BorderSize = 0;
            this.buttonExclusionList.ForeColor = System.Drawing.Color.Black;
            this.buttonExclusionList.Name = "buttonExclusionList";
            this.toolTip1.SetToolTip(this.buttonExclusionList, resources.GetString("buttonExclusionList.ToolTip"));
            this.buttonExclusionList.UseVisualStyleBackColor = false;
            this.buttonExclusionList.Click += new System.EventHandler(this.buttonExclusionList_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // buttonExBack
            // 
            resources.ApplyResources(this.buttonExBack, "buttonExBack");
            this.buttonExBack.BackColor = System.Drawing.SystemColors.Control;
            this.buttonExBack.FlatAppearance.BorderSize = 0;
            this.buttonExBack.ForeColor = System.Drawing.Color.Black;
            this.buttonExBack.Name = "buttonExBack";
            this.toolTip1.SetToolTip(this.buttonExBack, resources.GetString("buttonExBack.ToolTip"));
            this.buttonExBack.UseVisualStyleBackColor = false;
            this.buttonExBack.Click += new System.EventHandler(this.buttonExBack_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // comboBoxRunningProcesses
            // 
            resources.ApplyResources(this.comboBoxRunningProcesses, "comboBoxRunningProcesses");
            this.comboBoxRunningProcesses.FormattingEnabled = true;
            this.comboBoxRunningProcesses.Name = "comboBoxRunningProcesses";
            this.toolTip1.SetToolTip(this.comboBoxRunningProcesses, resources.GetString("comboBoxRunningProcesses.ToolTip"));
            this.comboBoxRunningProcesses.TextChanged += new System.EventHandler(this.comboBoxRunningProcesses_TextChanged);
            // 
            // buttonRemoveEx
            // 
            resources.ApplyResources(this.buttonRemoveEx, "buttonRemoveEx");
            this.buttonRemoveEx.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRemoveEx.FlatAppearance.BorderSize = 0;
            this.buttonRemoveEx.ForeColor = System.Drawing.Color.Black;
            this.buttonRemoveEx.Name = "buttonRemoveEx";
            this.toolTip1.SetToolTip(this.buttonRemoveEx, resources.GetString("buttonRemoveEx.ToolTip"));
            this.buttonRemoveEx.UseVisualStyleBackColor = false;
            this.buttonRemoveEx.Click += new System.EventHandler(this.buttonRemoveEx_Click);
            // 
            // buttonAddEx
            // 
            resources.ApplyResources(this.buttonAddEx, "buttonAddEx");
            this.buttonAddEx.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAddEx.FlatAppearance.BorderSize = 0;
            this.buttonAddEx.ForeColor = System.Drawing.Color.Black;
            this.buttonAddEx.Name = "buttonAddEx";
            this.toolTip1.SetToolTip(this.buttonAddEx, resources.GetString("buttonAddEx.ToolTip"));
            this.buttonAddEx.UseVisualStyleBackColor = false;
            this.buttonAddEx.Click += new System.EventHandler(this.buttonAddEx_Click);
            // 
            // buttonBrowseExe
            // 
            resources.ApplyResources(this.buttonBrowseExe, "buttonBrowseExe");
            this.buttonBrowseExe.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBrowseExe.FlatAppearance.BorderSize = 0;
            this.buttonBrowseExe.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseExe.Name = "buttonBrowseExe";
            this.toolTip1.SetToolTip(this.buttonBrowseExe, resources.GetString("buttonBrowseExe.ToolTip"));
            this.buttonBrowseExe.UseVisualStyleBackColor = false;
            this.buttonBrowseExe.Click += new System.EventHandler(this.buttonBrowseExe_Click);
            // 
            // listViewExclusion
            // 
            resources.ApplyResources(this.listViewExclusion, "listViewExclusion");
            this.listViewExclusion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewExclusion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewExclusion.FullRowSelect = true;
            this.listViewExclusion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewExclusion.HideSelection = false;
            this.listViewExclusion.MultiSelect = false;
            this.listViewExclusion.Name = "listViewExclusion";
            this.toolTip1.SetToolTip(this.listViewExclusion, resources.GetString("listViewExclusion.ToolTip"));
            this.listViewExclusion.UseCompatibleStateImageBehavior = false;
            this.listViewExclusion.View = System.Windows.Forms.View.Details;
            this.listViewExclusion.SelectedIndexChanged += new System.EventHandler(this.listViewExclusion_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.panelBlocklist);
            this.groupBox2.Controls.Add(this.numericUpDownMaxSuggestNum);
            this.groupBox2.Controls.Add(this.labelMaxSuggest);
            this.groupBox2.Controls.Add(this.buttonBlocklist);
            this.groupBox2.Controls.Add(this.labelInfo1);
            this.groupBox2.Controls.Add(this.checkBoxSearchResult);
            this.groupBox2.Controls.Add(this.labelInfo);
            this.groupBox2.Controls.Add(this.checkBoxSuggestions);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // panelBlocklist
            // 
            resources.ApplyResources(this.panelBlocklist, "panelBlocklist");
            this.panelBlocklist.Controls.Add(this.labelExplainBlocklist);
            this.panelBlocklist.Controls.Add(this.labelExplainBlocklistBlockResult);
            this.panelBlocklist.Controls.Add(this.buttonCancelBlocklist);
            this.panelBlocklist.Controls.Add(this.checkBoxExcludeResultSuggestion);
            this.panelBlocklist.Controls.Add(this.listViewBlocklist);
            this.panelBlocklist.Controls.Add(this.buttonSaveBlocklist);
            this.panelBlocklist.Name = "panelBlocklist";
            this.toolTip1.SetToolTip(this.panelBlocklist, resources.GetString("panelBlocklist.ToolTip"));
            // 
            // labelExplainBlocklist
            // 
            resources.ApplyResources(this.labelExplainBlocklist, "labelExplainBlocklist");
            this.labelExplainBlocklist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExplainBlocklist.Name = "labelExplainBlocklist";
            this.toolTip1.SetToolTip(this.labelExplainBlocklist, resources.GetString("labelExplainBlocklist.ToolTip"));
            // 
            // labelExplainBlocklistBlockResult
            // 
            resources.ApplyResources(this.labelExplainBlocklistBlockResult, "labelExplainBlocklistBlockResult");
            this.labelExplainBlocklistBlockResult.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExplainBlocklistBlockResult.Name = "labelExplainBlocklistBlockResult";
            this.toolTip1.SetToolTip(this.labelExplainBlocklistBlockResult, resources.GetString("labelExplainBlocklistBlockResult.ToolTip"));
            // 
            // buttonCancelBlocklist
            // 
            resources.ApplyResources(this.buttonCancelBlocklist, "buttonCancelBlocklist");
            this.buttonCancelBlocklist.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancelBlocklist.FlatAppearance.BorderSize = 0;
            this.buttonCancelBlocklist.ForeColor = System.Drawing.Color.Black;
            this.buttonCancelBlocklist.Name = "buttonCancelBlocklist";
            this.toolTip1.SetToolTip(this.buttonCancelBlocklist, resources.GetString("buttonCancelBlocklist.ToolTip"));
            this.buttonCancelBlocklist.UseVisualStyleBackColor = false;
            this.buttonCancelBlocklist.Click += new System.EventHandler(this.buttonCancelBlocklist_Click);
            // 
            // checkBoxExcludeResultSuggestion
            // 
            resources.ApplyResources(this.checkBoxExcludeResultSuggestion, "checkBoxExcludeResultSuggestion");
            this.checkBoxExcludeResultSuggestion.Name = "checkBoxExcludeResultSuggestion";
            this.toolTip1.SetToolTip(this.checkBoxExcludeResultSuggestion, resources.GetString("checkBoxExcludeResultSuggestion.ToolTip"));
            this.checkBoxExcludeResultSuggestion.UseVisualStyleBackColor = true;
            this.checkBoxExcludeResultSuggestion.CheckedChanged += new System.EventHandler(this.checkBoxExcludeResultSuggestion_CheckedChanged);
            // 
            // listViewBlocklist
            // 
            resources.ApplyResources(this.listViewBlocklist, "listViewBlocklist");
            this.listViewBlocklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewBlocklist.CheckBoxes = true;
            this.listViewBlocklist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewBlocklist.FullRowSelect = true;
            this.listViewBlocklist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewBlocklist.HideSelection = false;
            this.listViewBlocklist.MultiSelect = false;
            this.listViewBlocklist.Name = "listViewBlocklist";
            this.toolTip1.SetToolTip(this.listViewBlocklist, resources.GetString("listViewBlocklist.ToolTip"));
            this.listViewBlocklist.UseCompatibleStateImageBehavior = false;
            this.listViewBlocklist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // buttonSaveBlocklist
            // 
            resources.ApplyResources(this.buttonSaveBlocklist, "buttonSaveBlocklist");
            this.buttonSaveBlocklist.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSaveBlocklist.FlatAppearance.BorderSize = 0;
            this.buttonSaveBlocklist.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveBlocklist.Name = "buttonSaveBlocklist";
            this.toolTip1.SetToolTip(this.buttonSaveBlocklist, resources.GetString("buttonSaveBlocklist.ToolTip"));
            this.buttonSaveBlocklist.UseVisualStyleBackColor = false;
            this.buttonSaveBlocklist.Click += new System.EventHandler(this.buttonSaveBlocklist_Click);
            // 
            // numericUpDownMaxSuggestNum
            // 
            resources.ApplyResources(this.numericUpDownMaxSuggestNum, "numericUpDownMaxSuggestNum");
            this.numericUpDownMaxSuggestNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.numericUpDownMaxSuggestNum.TabStop = false;
            this.toolTip1.SetToolTip(this.numericUpDownMaxSuggestNum, resources.GetString("numericUpDownMaxSuggestNum.ToolTip"));
            this.numericUpDownMaxSuggestNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelMaxSuggest
            // 
            resources.ApplyResources(this.labelMaxSuggest, "labelMaxSuggest");
            this.labelMaxSuggest.Name = "labelMaxSuggest";
            this.toolTip1.SetToolTip(this.labelMaxSuggest, resources.GetString("labelMaxSuggest.ToolTip"));
            // 
            // buttonBlocklist
            // 
            resources.ApplyResources(this.buttonBlocklist, "buttonBlocklist");
            this.buttonBlocklist.FlatAppearance.BorderSize = 0;
            this.buttonBlocklist.Name = "buttonBlocklist";
            this.toolTip1.SetToolTip(this.buttonBlocklist, resources.GetString("buttonBlocklist.ToolTip"));
            this.buttonBlocklist.UseVisualStyleBackColor = true;
            this.buttonBlocklist.Click += new System.EventHandler(this.buttonBlocklist_Click);
            // 
            // labelInfo1
            // 
            resources.ApplyResources(this.labelInfo1, "labelInfo1");
            this.labelInfo1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelInfo1.Name = "labelInfo1";
            this.toolTip1.SetToolTip(this.labelInfo1, resources.GetString("labelInfo1.ToolTip"));
            // 
            // checkBoxSearchResult
            // 
            resources.ApplyResources(this.checkBoxSearchResult, "checkBoxSearchResult");
            this.checkBoxSearchResult.Name = "checkBoxSearchResult";
            this.toolTip1.SetToolTip(this.checkBoxSearchResult, resources.GetString("checkBoxSearchResult.ToolTip"));
            this.checkBoxSearchResult.UseVisualStyleBackColor = true;
            this.checkBoxSearchResult.CheckedChanged += new System.EventHandler(this.checkBoxSearchResult_CheckedChanged);
            // 
            // labelInfo
            // 
            resources.ApplyResources(this.labelInfo, "labelInfo");
            this.labelInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelInfo.Name = "labelInfo";
            this.toolTip1.SetToolTip(this.labelInfo, resources.GetString("labelInfo.ToolTip"));
            // 
            // checkBoxSuggestions
            // 
            resources.ApplyResources(this.checkBoxSuggestions, "checkBoxSuggestions");
            this.checkBoxSuggestions.Name = "checkBoxSuggestions";
            this.toolTip1.SetToolTip(this.checkBoxSuggestions, resources.GetString("checkBoxSuggestions.ToolTip"));
            this.checkBoxSuggestions.UseVisualStyleBackColor = true;
            this.checkBoxSuggestions.CheckedChanged += new System.EventHandler(this.checkBoxSuggestions_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panelHotkey);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.buttonHotkeySetting);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // panelHotkey
            // 
            resources.ApplyResources(this.panelHotkey, "panelHotkey");
            this.panelHotkey.Controls.Add(this.buttonHotkeyCancel);
            this.panelHotkey.Controls.Add(this.buttonApplyHotkey);
            this.panelHotkey.Controls.Add(this.labelInfoForNewHotkey);
            this.panelHotkey.Controls.Add(this.radioButtonShift);
            this.panelHotkey.Controls.Add(this.radioButtonControl);
            this.panelHotkey.Controls.Add(this.radioButtonAlt);
            this.panelHotkey.Controls.Add(this.comboBoxHotkey);
            this.panelHotkey.Controls.Add(this.label10);
            this.panelHotkey.Controls.Add(this.label9);
            this.panelHotkey.Name = "panelHotkey";
            this.toolTip1.SetToolTip(this.panelHotkey, resources.GetString("panelHotkey.ToolTip"));
            // 
            // buttonHotkeyCancel
            // 
            resources.ApplyResources(this.buttonHotkeyCancel, "buttonHotkeyCancel");
            this.buttonHotkeyCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonHotkeyCancel.FlatAppearance.BorderSize = 0;
            this.buttonHotkeyCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonHotkeyCancel.Name = "buttonHotkeyCancel";
            this.toolTip1.SetToolTip(this.buttonHotkeyCancel, resources.GetString("buttonHotkeyCancel.ToolTip"));
            this.buttonHotkeyCancel.UseVisualStyleBackColor = false;
            this.buttonHotkeyCancel.Click += new System.EventHandler(this.buttonHotkeyCancel_Click);
            // 
            // buttonApplyHotkey
            // 
            resources.ApplyResources(this.buttonApplyHotkey, "buttonApplyHotkey");
            this.buttonApplyHotkey.BackColor = System.Drawing.SystemColors.Control;
            this.buttonApplyHotkey.FlatAppearance.BorderSize = 0;
            this.buttonApplyHotkey.ForeColor = System.Drawing.Color.Black;
            this.buttonApplyHotkey.Name = "buttonApplyHotkey";
            this.toolTip1.SetToolTip(this.buttonApplyHotkey, resources.GetString("buttonApplyHotkey.ToolTip"));
            this.buttonApplyHotkey.UseVisualStyleBackColor = false;
            this.buttonApplyHotkey.Click += new System.EventHandler(this.buttonApplyHotkey_Click);
            // 
            // labelInfoForNewHotkey
            // 
            resources.ApplyResources(this.labelInfoForNewHotkey, "labelInfoForNewHotkey");
            this.labelInfoForNewHotkey.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelInfoForNewHotkey.Name = "labelInfoForNewHotkey";
            this.toolTip1.SetToolTip(this.labelInfoForNewHotkey, resources.GetString("labelInfoForNewHotkey.ToolTip"));
            // 
            // radioButtonShift
            // 
            resources.ApplyResources(this.radioButtonShift, "radioButtonShift");
            this.radioButtonShift.Name = "radioButtonShift";
            this.radioButtonShift.TabStop = true;
            this.toolTip1.SetToolTip(this.radioButtonShift, resources.GetString("radioButtonShift.ToolTip"));
            this.radioButtonShift.UseVisualStyleBackColor = true;
            this.radioButtonShift.CheckedChanged += new System.EventHandler(this.radioButtonShift_CheckedChanged);
            // 
            // radioButtonControl
            // 
            resources.ApplyResources(this.radioButtonControl, "radioButtonControl");
            this.radioButtonControl.Name = "radioButtonControl";
            this.radioButtonControl.TabStop = true;
            this.toolTip1.SetToolTip(this.radioButtonControl, resources.GetString("radioButtonControl.ToolTip"));
            this.radioButtonControl.UseVisualStyleBackColor = true;
            this.radioButtonControl.CheckedChanged += new System.EventHandler(this.radioButtonControl_CheckedChanged);
            // 
            // radioButtonAlt
            // 
            resources.ApplyResources(this.radioButtonAlt, "radioButtonAlt");
            this.radioButtonAlt.Name = "radioButtonAlt";
            this.radioButtonAlt.TabStop = true;
            this.toolTip1.SetToolTip(this.radioButtonAlt, resources.GetString("radioButtonAlt.ToolTip"));
            this.radioButtonAlt.UseVisualStyleBackColor = true;
            this.radioButtonAlt.CheckedChanged += new System.EventHandler(this.radioButtonAlt_CheckedChanged);
            // 
            // comboBoxHotkey
            // 
            resources.ApplyResources(this.comboBoxHotkey, "comboBoxHotkey");
            this.comboBoxHotkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHotkey.FormattingEnabled = true;
            this.comboBoxHotkey.Items.AddRange(new object[] {
            resources.GetString("comboBoxHotkey.Items"),
            resources.GetString("comboBoxHotkey.Items1"),
            resources.GetString("comboBoxHotkey.Items2"),
            resources.GetString("comboBoxHotkey.Items3"),
            resources.GetString("comboBoxHotkey.Items4"),
            resources.GetString("comboBoxHotkey.Items5"),
            resources.GetString("comboBoxHotkey.Items6"),
            resources.GetString("comboBoxHotkey.Items7"),
            resources.GetString("comboBoxHotkey.Items8"),
            resources.GetString("comboBoxHotkey.Items9"),
            resources.GetString("comboBoxHotkey.Items10"),
            resources.GetString("comboBoxHotkey.Items11"),
            resources.GetString("comboBoxHotkey.Items12"),
            resources.GetString("comboBoxHotkey.Items13"),
            resources.GetString("comboBoxHotkey.Items14"),
            resources.GetString("comboBoxHotkey.Items15"),
            resources.GetString("comboBoxHotkey.Items16"),
            resources.GetString("comboBoxHotkey.Items17"),
            resources.GetString("comboBoxHotkey.Items18"),
            resources.GetString("comboBoxHotkey.Items19"),
            resources.GetString("comboBoxHotkey.Items20"),
            resources.GetString("comboBoxHotkey.Items21"),
            resources.GetString("comboBoxHotkey.Items22"),
            resources.GetString("comboBoxHotkey.Items23"),
            resources.GetString("comboBoxHotkey.Items24"),
            resources.GetString("comboBoxHotkey.Items25"),
            resources.GetString("comboBoxHotkey.Items26"),
            resources.GetString("comboBoxHotkey.Items27"),
            resources.GetString("comboBoxHotkey.Items28"),
            resources.GetString("comboBoxHotkey.Items29"),
            resources.GetString("comboBoxHotkey.Items30"),
            resources.GetString("comboBoxHotkey.Items31"),
            resources.GetString("comboBoxHotkey.Items32"),
            resources.GetString("comboBoxHotkey.Items33"),
            resources.GetString("comboBoxHotkey.Items34"),
            resources.GetString("comboBoxHotkey.Items35")});
            this.comboBoxHotkey.Name = "comboBoxHotkey";
            this.toolTip1.SetToolTip(this.comboBoxHotkey, resources.GetString("comboBoxHotkey.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            this.toolTip1.SetToolTip(this.label10, resources.GetString("label10.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            this.toolTip1.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // checkBox7
            // 
            resources.ApplyResources(this.checkBox7, "checkBox7");
            this.checkBox7.Name = "checkBox7";
            this.toolTip1.SetToolTip(this.checkBox7, resources.GetString("checkBox7.ToolTip"));
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox5
            // 
            resources.ApplyResources(this.checkBox5, "checkBox5");
            this.checkBox5.Name = "checkBox5";
            this.toolTip1.SetToolTip(this.checkBox5, resources.GetString("checkBox5.ToolTip"));
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            resources.ApplyResources(this.checkBox4, "checkBox4");
            this.checkBox4.Name = "checkBox4";
            this.toolTip1.SetToolTip(this.checkBox4, resources.GetString("checkBox4.ToolTip"));
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.toolTip1.SetToolTip(this.checkBox1, resources.GetString("checkBox1.ToolTip"));
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.toolTip1.SetToolTip(this.checkBox2, resources.GetString("checkBox2.ToolTip"));
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.Name = "checkBox3";
            this.toolTip1.SetToolTip(this.checkBox3, resources.GetString("checkBox3.ToolTip"));
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox8
            // 
            resources.ApplyResources(this.checkBox8, "checkBox8");
            this.checkBox8.Name = "checkBox8";
            this.toolTip1.SetToolTip(this.checkBox8, resources.GetString("checkBox8.ToolTip"));
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // buttonHotkeySetting
            // 
            resources.ApplyResources(this.buttonHotkeySetting, "buttonHotkeySetting");
            this.buttonHotkeySetting.BackColor = System.Drawing.Color.White;
            this.buttonHotkeySetting.FlatAppearance.BorderSize = 0;
            this.buttonHotkeySetting.ForeColor = System.Drawing.Color.Black;
            this.buttonHotkeySetting.Name = "buttonHotkeySetting";
            this.toolTip1.SetToolTip(this.buttonHotkeySetting, resources.GetString("buttonHotkeySetting.ToolTip"));
            this.buttonHotkeySetting.UseVisualStyleBackColor = false;
            this.buttonHotkeySetting.Click += new System.EventHandler(this.buttonHotkeySetting_Click);
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.panelSetting.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panelExIntro.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelBlocklist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSuggestNum)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBoxHotkey;
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
        private System.Windows.Forms.Button buttonHotkeyCancel;
        private System.Windows.Forms.Button buttonApplyHotkey;
        private System.Windows.Forms.Label labelExplainBlocklist;
        private System.Windows.Forms.Label labelExplainBlocklistBlockResult;
        private System.Windows.Forms.ListView listViewExclusion;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonRemoveEx;
        private System.Windows.Forms.Button buttonAddEx;
        private System.Windows.Forms.Button buttonBrowseExe;
        private System.Windows.Forms.ComboBox comboBoxRunningProcesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelExIntro;
        private System.Windows.Forms.Button buttonExclusionList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExBack;
        private System.Windows.Forms.Button buttonHotkeySetting;
    }
}