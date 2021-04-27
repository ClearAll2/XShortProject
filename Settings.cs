using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Linq;

namespace XShort
{
    public partial class Settings : Form
    {
        private RegistryKey r;
        private RegistryKey r1;
        private global::ModifierKeys gmk;
        private Keys k;
        private List<String> sName = new List<string>();
        private List<String> sPath = new List<String>();
        private ImageList sImage = new ImageList();
        private List<String> blockList = new List<string>();
        private List<String> exclusion = new List<string>();
        private string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
        private string pass = "asdewefcasdsafasfajldsjlsjakldjohfoiajskdlsakljncnalskjdlkjslka";
        private string[] sysCmd = { "utilman", "hdwwiz", "appwiz.cpl", "netplwz", "azman.msc", "sdctl", "fsquirt", "calc", "certmgr.msc", "charmap", "chkdsk", "cttune", "colorcpl.exe", "cmd", "dcomcnfg", "comexp.msc", "compmgmt.msc", "control", "credwiz", "timedate.cpl", "hdwwiz", "devmgmt.msc", "tabcal", "directx.cpl", "dxdiag", "cleanmgr", "dfrgui", "diskmgmt.msc", "diskpart", "dccw", "dpiscaling", "control desktop", "desk.cpl", "control color", "documents", "downloads", "verifier", "dvdplay", "sysdm.cpl", "	rekeywiz", "eventvwr.msc", "sigverif", "control folders", "control fonts", "joy.cpl", "gpedit.msc", "inetcpl.cpl", "ipconfig", "iscsicpl", "control keyboard", "lpksetup", "secpol.msc", "lusrmgr.msc", "logoff", "mrt", "mmc", "mspaint", "msdt", "control mouse", "main.cpl", "ncpa.cpl", "notepad", "perfmon.msc", "powercfg.cpl", "control printers", "regedit", "snippingtool", "wscui.cpl", "services.msc", "mmsys.cpl", "mmsys.cpl", "sndvol", "msconfig", "sfc", "msinfo32", "sysdm.cpl", "taskmgr", "explorer", "firewall.cpl", "wf.msc", "magnify", "powershell", "winver", "telnet", "rstrui" };

        public Settings()
        {
            InitializeComponent();
            sImage.ImageSize = new Size(20, 20);
            sImage.ColorDepth = ColorDepth.Depth32Bit;
            listViewBlocklist.SmallImageList = sImage;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerAsync();
            LoadSettings();
            if (!File.Exists(Path.Combine(Application.StartupPath, "XShortCoreIndex.exe")))
            {
                checkBoxUseIndex.Enabled = false;
                labelBuildIndexInterval.Enabled = false;
                numericUpDownInterval.Enabled = false;
                labelError.Show();
            }
            if (File.Exists(Path.Combine(dataPath, "index")))
            {
                labelLastUpdate.Text = "Last update: " + new FileInfo(Path.Combine(dataPath, "index")).LastWriteTime;
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
            ReloadBlocklist();
            LoadIcon();

        }

        private void LoadExclusion()
        {
            exclusion.Clear();
            listViewExclusion.Items.Clear();

            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "exclusion"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                exclusion.Add(sr.ReadLine());
                listViewExclusion.Items.Add(new ListViewItem(exclusion[exclusion.Count - 1]));
            }
            fs.Close();
            sr.Close();

           
        }

        private void LoadIcon()
        {
            sImage.Images.Clear();
            for (int i = 0; i < sPath.Count; i++)
            {
                try
                {
                    sImage.Images.Add(Icon.ExtractAssociatedIcon(sPath[i]));
                }
                catch
                {
                    if (sPath[i].Contains("http"))
                        sImage.Images.Add(Properties.Resources.internet);
                    else if (sPath[i].Contains("\\"))
                    {
                        if (Directory.Exists(sPath[i]))
                            sImage.Images.Add(Properties.Resources.dir);
                        else
                            sImage.Images.Add(Properties.Resources.error);
                    }
                    else
                    {
                        sImage.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }

                }

            }
        }

        private void LoadRunningProcesses()
        {
            comboBoxRunningProcesses.Items.Clear();
            Process[] localAll = Process.GetProcesses();
            for (int i=0;i<localAll.Length;i++)
            {
                if (!comboBoxRunningProcesses.Items.Contains(localAll[i].ProcessName))
                    comboBoxRunningProcesses.Items.Add(localAll[i].ProcessName);
            }
        }

        public void LoadData()
        {
            sName.Clear();

            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "data1.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                sName.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();

            try
            {
                fs = new FileStream(Path.Combine(dataPath, "data2.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                sPath.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();
        }

        private void ReloadBlocklist()
        {
            blockList.Clear();

            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "blocklist"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string read = sr.ReadLine();
                if (sName.Contains(read) || sysCmd.Contains(read))
                    blockList.Add(read);
            }
            fs.Close();
            sr.Close();

            if (blockList.Count > 0)
                buttonBlocklist.Text = "Blocklist - " + blockList.Count.ToString() + " shortcut(s) selected";
            else
                buttonBlocklist.Text = "Blocklist";
        }

        private void LoadSettings()
        {
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r == null)
                r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\Data");

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));

            //new register hook key
            if (r.GetValue("HKey") != null)
            {
                string hkey = (string)r.GetValue("HKey");
                k = (Keys)converter.ConvertFromString(hkey);
                for (int i = 0; i < comboBoxHotkey.Items.Count; i++)
                {
                    if (comboBoxHotkey.Items[i].ToString() == hkey)
                    {
                        comboBoxHotkey.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                k = Keys.A;
                for (int i = 0; i < comboBoxHotkey.Items.Count; i++)
                {
                    if (comboBoxHotkey.Items[i].ToString() == "A")
                    {
                        comboBoxHotkey.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (r.GetValue("Alt") != null)
            {
                radioButtonAlt.Checked = true;
                // hook.RegisterHotKey(global::ModifierKeys.Alt, k);
                gmk = global::ModifierKeys.Alt;
            }
            else if (r.GetValue("Shift") != null)
            {
                radioButtonShift.Checked = true;
                //hook.RegisterHotKey(global::ModifierKeys.Shift, k);
                gmk = global::ModifierKeys.Shift;
            }
            else if (r.GetValue("Ctrl") != null)
            {
                radioButtonControl.Checked = true;
                //hook.RegisterHotKey(global::ModifierKeys.Control, k);
                gmk = global::ModifierKeys.Control;
            }
            else //default value
            {
                radioButtonAlt.Checked = true;
                // hook.RegisterHotKey(global::ModifierKeys.Alt, k);
                gmk = global::ModifierKeys.Alt;
            }
            //
            if (r.GetValue("Hide") != null)
                checkBox2.Checked = true;
            if (r.GetValue("ggSearch") != null)
                checkBox3.Checked = true;
            if (r.GetValue("Case-sen") != null)
                checkBox4.Checked = true;
            if (r.GetValue("Tray") != null)
                checkBox5.Checked = true;
            if (r.GetValue("Detect") != null)
                checkBox7.Checked = true;
            if (r.GetValue("DontLoad") != null)
                checkBox8.Checked = true;
            if (r.GetValue("Suggestions") != null)
                checkBoxSuggestions.Checked = true;
            if (r.GetValue("ShowResult") != null)
                checkBoxSearchResult.Checked = true;
            if (r.GetValue("ExcludeResult") != null)
                checkBoxExcludeResultSuggestion.Checked = true;
            if (r.GetValue("MaxSuggest") != null)
            {
                numericUpDownMaxSuggestNum.Value = Decimal.Parse((string)r.GetValue("MaxSuggest"));
            }
            if (r.GetValue("UseIndex") != null)
                checkBoxUseIndex.Checked = true;

            if (r.GetValue("Interval") != null)
            {
                numericUpDownInterval.Value = Decimal.Parse((string)r.GetValue("Interval"));
            }

            r.Close();
            r.Dispose();


            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (r.GetValue("XShort") != null)
            {
                if (r.GetValue("XShort").ToString().Contains(Application.ExecutablePath))
                {
                    checkBox1.Checked = true;
                }
            }
            r.Close();
            r.Dispose();

        }


        private void radioButtonAlt_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButtonAlt.Checked)
            {
                r1.SetValue("Alt", true);
                r1.DeleteValue("Ctrl", false);
                r1.DeleteValue("Shift", false);
            }

            r1.Close();
            r1.Dispose();
        }

        private void radioButtonControl_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButtonControl.Checked)
            {
                r1.SetValue("Ctrl", true);
                r1.DeleteValue("Alt", false);
                r1.DeleteValue("Shift", false);
            }

            r1.Close();
            r1.Dispose();
        }

        private void radioButtonShift_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButtonShift.Checked)
            {
                r1.SetValue("Shift", true);
                r1.DeleteValue("Ctrl", false);
                r1.DeleteValue("Alt", false);
            }

            r1.Close();
            r1.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string cmd = Application.ExecutablePath + " startup";
            if (checkBox1.Checked)
            {
                r1.SetValue("XShort", cmd);
            }
            else
            {
                r1.DeleteValue("XShort", false);

            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox2.Checked)
            {
                r1.SetValue("Hide", true);
            }
            else
            {
                r1.DeleteValue("Hide", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox3.Checked)
            {
                r1.SetValue("ggSearch", true);
            }
            else
            {
                r1.DeleteValue("ggSearch", false);
            }
            r1.Close();
            r1.Dispose();

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox4.Checked)
            {
                r1.SetValue("Case-sen", true);
            }
            else
            {
                r1.DeleteValue("Case-sen", false);
            }
            r1.Close();
            r1.Dispose();

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox5.Checked)
            {
                //notifyIcon1.Visible = false;
                r1.SetValue("Tray", true);
            }
            else
            {
                //notifyIcon1.Visible = true;
                r1.DeleteValue("Tray", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox7.Checked)
            {
                r1.SetValue("Detect", true);

            }
            else
            {
                r1.DeleteValue("Detect", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox8.Checked)
            {
                r1.SetValue("DontLoad", true);

            }
            else
            {
                r1.DeleteValue("DontLoad", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBoxSuggestions_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBoxSuggestions.Checked)
            {
                r1.SetValue("Suggestions", true);
            }
            else
            {
                r1.DeleteValue("Suggestions", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBoxSearchResult_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBoxSearchResult.Checked)
            {
                r1.SetValue("ShowResult", true);
            }
            else
            {
                r1.DeleteValue("ShowResult", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void buttonBlocklist_Click(object sender, EventArgs e)
        {
            listViewBlocklist.Items.Clear();
            for (int i = 0; i < sName.Count; i++)
            {
                listViewBlocklist.Items.Add(new ListViewItem(sName[i]));
                listViewBlocklist.Items[i].ImageIndex = i;
                if (blockList.Contains(listViewBlocklist.Items[i].Text))
                    listViewBlocklist.Items[i].Checked = true;
            }
            Util.Animate(panelBlocklist, Util.Effect.Center, 100, 180);
        }

        private void buttonSaveBlocklist_Click(object sender, EventArgs e)
        {
            Util.Animate(panelBlocklist, Util.Effect.Center, 100, 180);
            File.WriteAllText(Path.Combine(dataPath, "blocklist"), String.Empty);
            for (int i = 0; i < listViewBlocklist.Items.Count; i++)
            {
                if (listViewBlocklist.Items[i].Checked)
                    File.AppendAllText(Path.Combine(dataPath, "blocklist"), listViewBlocklist.Items[i].Text + Environment.NewLine);
            }
            ReloadBlocklist();
        }

        private void checkBoxExcludeResultSuggestion_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBoxExcludeResultSuggestion.Checked)
            {
                r1.SetValue("ExcludeResult", true);
            }
            else
            {
                r1.DeleteValue("ExcludeResult", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void buttonCancelBlocklist_Click(object sender, EventArgs e)
        {
            Util.Animate(panelBlocklist, Util.Effect.Center, 100, 180);
        }


        private void checkBoxUseIndex_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBoxUseIndex.Checked)
            {
                r1.SetValue("UseIndex", true);
            }
            else
            {
                r1.DeleteValue("UseIndex", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            r1.SetValue("Interval", numericUpDownInterval.Value);
            r1.SetValue("MaxSuggest", numericUpDownMaxSuggestNum.Value);
            r1.Close();
            r1.Dispose();
            File.WriteAllText(Path.Combine(dataPath, "interval"), String.Empty);
            
        }

        private void linkLabelHotKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.Animate(panelHotkey, Util.Effect.Center, 100, 180);
        }

        private void buttonHotkeyCancel_Click(object sender, EventArgs e)
        {
            Util.Animate(panelHotkey, Util.Effect.Center, 100, 180);
        }

        private void buttonApplyHotkey_Click(object sender, EventArgs e)
        {
            Util.Animate(panelHotkey, Util.Effect.Center, 100, 180);
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            r1.SetValue("HKey", comboBoxHotkey.Text);
            r1.Close();
            r1.Dispose();
        }

        private void buttonBrowseExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.CheckFileExists = true;
            of.CheckPathExists = true;
            of.Filter = "Executable (*.exe*)|*.exe*";
            of.Title = "Select your file...";

            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in of.SafeFileNames)
                {
                    listViewExclusion.Items.Add(new ListViewItem(file.Replace(".exe", String.Empty)));
                }
            }

            of.Dispose();
        }

        private void listViewExclusion_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveEx.Enabled = listViewExclusion.FocusedItem != null;
        }

        private void comboBoxRunningProcesses_TextChanged(object sender, EventArgs e)
        {
            buttonAddEx.Enabled = comboBoxRunningProcesses.Text.Length > 0;
        }

        private void buttonRemoveEx_Click(object sender, EventArgs e)
        {
            if (listViewExclusion.FocusedItem != null)
            {
                if (MessageBox.Show("Are you sure want to remove " + listViewExclusion.FocusedItem.Text + " from the list?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listViewExclusion.Items.RemoveAt(listViewExclusion.FocusedItem.Index);
                }
            }
        }

        private void buttonAddEx_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewExclusion.Items.Count; i++)
            {
                if (listViewExclusion.Items[i].Text == comboBoxRunningProcesses.Text)
                {
                    MessageBox.Show("This application is already in exclusion list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            listViewExclusion.Items.Add(new ListViewItem(comboBoxRunningProcesses.Text));
            comboBoxRunningProcesses.Text = String.Empty;
        }

        private void buttonExclusionList_Click(object sender, EventArgs e)
        {
            Util.Animate(panelExIntro, Util.Effect.Center, 100, 180);
            LoadRunningProcesses();
            LoadExclusion();
        }

        private void buttonExBack_Click(object sender, EventArgs e)
        {
            Util.Animate(panelExIntro, Util.Effect.Center, 100, 180);
            File.WriteAllText(Path.Combine(dataPath, "exclusion"), String.Empty);
            for (int i = 0; i < listViewExclusion.Items.Count; i++)
            {
                File.AppendAllText(Path.Combine(dataPath, "exclusion"), listViewExclusion.Items[i].Text + Environment.NewLine);
            }
        }
    }
}
