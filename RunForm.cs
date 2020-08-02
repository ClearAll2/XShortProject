﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XShort
{
    public partial class RunForm : Form
    {
        private int index = 0;
        private int rel = 0;
        private List<String> dir = new List<String>();
        private List<String> sName = new List<String>();
        private List<String> sPath = new List<String>();
        private List<String> sPara = new List<String>();
        private ImageList sImage = new ImageList();
        private List<Suggestions> suggestions = new List<Suggestions>();
        private RegistryKey r;
        private string dataPath;
        private bool ggSearch = true;
        private bool csen = false;
        private string text = String.Empty;
        private string text1, part = String.Empty;
        private string pass = "asdewefcasdsafasfajldsjlsjakldjohfoiajskdlsakljncnalskjdlkjslka";
        private string[] sysCmd = { "utilman", "control access.cpl", "hdwwiz", "appwiz.cpl", "control admintools", "netplwz", "azman.msc", "control wuaucpl.cpl", "sdctl", "fsquirt", "calc", "certmgr.msc", "charmap", "chkdsk", "cttune", "colorcpl.exe", "cmd", "dcomcnfg", "comexp.msc", "CompMgmtLauncher.exe", "compmgmt.msc", "control", "credwiz", "SystemPropertiesDataExecutionPrevention", "timedate.cpl", "hdwwiz", "devmgmt.msc", "DevicePairingWizard", "tabcal", "directx.cpl", "dxdiag", "cleanmgr", "dfrgui", "diskmgmt.msc", "diskpart", "dccw", "dpiscaling", "control desktop", "desk.cpl", "control color", "documents", "downloads", "verifier", "dvdplay", "sysdm.cpl", "	rekeywiz", "eventvwr.msc", "sigverif", "%systemroot%\\system32\\migwiz\\migwiz.exe", "firewall.cpl", "control folders", "control fonts", "joy.cpl", "gpedit.msc", "inetcpl.cpl", "ipconfig", "iscsicpl", "control keyboard", "lpksetup", "secpol.msc", "lusrmgr.msc", "logoff", "mrt", "mmc", "mspaint", "msdt", "control mouse", "main.cpl", "control netconnections", "ncpa.cpl", "notepad", "perfmon.msc", "powercfg.cpl", "control printers", "regedit", "snippingtool", "wscui.cpl", "services.msc", "mmsys.cpl", "mmsys.cpl", "sndvol", "msconfig", "sfc", "msinfo32", "sysdm.cpl", "taskmgr", "explorer", "firewall.cpl", "wf.msc", "magnify", "powershell", "winver", "telnet", "rstrui" };
        private BackgroundWorker bw;

        public RunForm(int en)
        {
            InitializeComponent();
            dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
            sImage.ImageSize = new Size(30, 30);
            sImage.ColorDepth = ColorDepth.Depth32Bit;

            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r == null)
                r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\Data");
            if (r.GetValue("ggSearch") != null)
            {
                ggSearch = true;
            }
            else
            {
                ggSearch = false;
            }

            if (r.GetValue("Case-sen") != null)
            {
                csen = true;
            }
            else
            {
                csen = false;
            }
            
          
            r.Close();
            r.Dispose();

            comboBox1.Focus();
            comboBox1.SelectAll();

            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            

        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadSuggestions();
        }

        private void LoadIcon()
        {
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

        private int CheckExistSuggestion(string loc)
        {
            for (int i = 0; i < suggestions.Count; i++)
            {
                if (loc.Equals(suggestions[i].loc))
                {
                    return i;
                }
            }
            return -1;
        }


        private void ReloadSuggestions()
        {
            rel = 0;
            panelSuggestions.Controls.Clear();
            if (suggestions.Count > 0)
            {
                for (int i = 0; i < suggestions.Count; i++)
                {
                    AddNewSuggestionsItems(suggestions[i].loc);
                    if (rel >= 6)
                        break;
                }

            }
        }

        private void LoadSuggestions()
        {
            List<string> addedSuggestion = new List<string>();
            if (System.IO.File.Exists(dataPath + "\\suggestions"))
            {
                FileStream fs = new FileStream(dataPath + "\\suggestions", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string read = sr.ReadLine();
                    string[] cut = read.Split('|');
                    if (!addedSuggestion.Contains(cut[0]))
                    {
                        suggestions.Add(new Suggestions(cut[0], Int32.Parse(cut[1]), DateTime.Parse(cut[2])));
                        if (rel < 6)//fixed only load 6 items from file
                        {
                            AddNewSuggestionsItems(cut[0]);
                            addedSuggestion.Add(cut[0]);
                        }
                    }
                }
                sr.Close();
                fs.Close();
            }

        }

        private void AddNewSuggestionsItems(string text)
        {
            int recentWidth = panelSuggestions.Height * 3;
            Button newsuggestion = new Button
            {
                ForeColor = SystemColors.ControlDarkDark,
                BackColor = System.Drawing.Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            newsuggestion.FlatAppearance.BorderSize = 0;
            newsuggestion.FlatAppearance.BorderColor = Color.White;
            newsuggestion.ImageList = sImage;
            newsuggestion.ImageIndex = sName.IndexOf(text);
            newsuggestion.Left = rel * recentWidth;
            newsuggestion.Text = text;
            newsuggestion.TabStop = false;
            newsuggestion.ContextMenuStrip = contextMenuStrip1;
            newsuggestion.TextImageRelation = TextImageRelation.ImageBeforeText;
            if (newsuggestion.Text.Length >= 16)
            {
                newsuggestion.TextImageRelation = TextImageRelation.Overlay;
                newsuggestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                newsuggestion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            }

            newsuggestion.Width = recentWidth;
            newsuggestion.Height = panelSuggestions.Height;
            toolTip1.SetToolTip(newsuggestion, sPath[newsuggestion.ImageIndex]);
            newsuggestion.Click += Newsuggestion_Click;
            newsuggestion.MouseDown += Newsuggestion_MouseDown;
            panelSuggestions.Controls.Add(newsuggestion);
            rel += 1;
        }

        private void Newsuggestion_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            string location = toolTip1.GetToolTip(button);
            if (e.Button == MouseButtons.Middle)
            {
                try
                {
                    string argument = "/select, \"" + location + "\"";
                    Process.Start("explorer.exe", argument);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Newsuggestion_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            SimpleRun(button.Text);
            ReloadSuggestions();
        }

        private void SortSuggestions()
        {
            if (suggestions.Count > 1)
            {
                for (int i = 0; i < suggestions.Count - 1; i++)//sort by number for all items first
                {
                    for (int j = i + 1; j < suggestions.Count; j++)
                    {
                        if (suggestions[i].count < suggestions[j].count)
                        {
                            Suggestions temp = suggestions[i];
                            suggestions[i] = suggestions[j];
                            suggestions[j] = temp;
                        }
                        else if (suggestions[i].count == suggestions[j].count)
                        {
                            if (suggestions[i].lasttime.CompareTo(suggestions[j].lasttime) < 0)
                            {
                                Suggestions temp = suggestions[i];
                                suggestions[i] = suggestions[j];
                                suggestions[j] = temp;
                            }
                        }
                    }
                }
                if (suggestions.Count >= 5)//fix recent < 5
                {
                    for (int i = 0; i < 4; i++)//sort by time for 5 first items
                    {
                        for (int j = i + 1; j < 5; j++)
                        {
                            if (suggestions[i].lasttime.CompareTo(suggestions[j].lasttime) < 0)
                            {
                                Suggestions temp = suggestions[i];
                                suggestions[i] = suggestions[j];
                                suggestions[j] = temp;
                            }
                        }
                    }
                }
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {
                loadData();
            }
            LoadIcon();
            if (File.Exists(Path.Combine(dataPath, "startup.txt")))
            {
                List<string> startup = new List<string>();
                FileStream fs;
                StreamReader sr;
                fs = new FileStream(Path.Combine(dataPath, "startup.txt"), FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    startup.Add(sr.ReadLine());
                }
                sr.Close();
                fs.Close();
                sr.Dispose();
                fs.Dispose();

                for (int i=0;i<startup.Count;i++)
                {
                    if (Program.FileName == "startup")//manual open -> no FileName
                    {
                        SimpleRun(startup[i]);
                    }
                }
            }
        }

        private void SimpleRun(string s)
        {
            for (int i = 0; i < sName.Count; i++)
            {
                if (s == sName[i])
                {
                    if (sPara[i] != "None" && sPara[i] != "Not Available")
                        Process.Start(sPath[i], sPara[i]);
                    else
                        Process.Start(sPath[i]);

                    //for suggestions
                    if (suggestions.Count > 0)
                    {
                        int position = CheckExistSuggestion(sName[i]);
                        if (position != -1)
                        {
                            suggestions[position].count += 1;
                            suggestions[position].lasttime = DateTime.Now;
                        }
                        else
                            suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                    }
                    else
                        suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                    SortSuggestions();
                }
            }
        }

        public void changeGGSeach(bool gg)
        {
            ggSearch = gg;
        }

        public void changeSensitive(bool Csen)
        {
            csen = Csen;
        }

        private int loadData()
        {
            comboBox1.Items.Clear();
            sName.Clear();
            sPara.Clear(); //fucking forget to clear haha
            sPath.Clear();

            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "data1.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return 0;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {

                sName.Add(sr.ReadLine());


            }
            fs.Close();
            sr.Close();

            //
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "data2.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return -1;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {

                sPath.Add(sr.ReadLine());

            }
            fs.Close();
            sr.Close();

            //
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "data3.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return -1;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {

                sPara.Add(sr.ReadLine());

            }
            fs.Close();
            sr.Close();


            for (int i = 0; i < sName.Count; i++)
            {
                comboBox1.Items.Add(sName[i]);
            }

            return 1;
        }



        public int LoadData()
        {
            comboBox1.Items.Clear();
            sName.Clear();
            sPara.Clear(); //fucking forget to clear haha
            sPath.Clear();

            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "data1.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return 0;
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
                return -1;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                sPath.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();


            try
            {
                fs = new FileStream(Path.Combine(dataPath, "data3.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return -1;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                sPara.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();


            for (int i = 0; i < sName.Count; i++)
            {
                comboBox1.Items.Add(sName[i]);
            }

            return 1;

        }

        private void Run(string tmp, bool runas)
        {
            if (comboBox1.Text == String.Empty) //do nothing if comboBox is empty
                return;
            if (sysCmd.Contains(tmp))
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = "C:\\Windows\\System32\\cmd.exe";
                proc.WorkingDirectory = Path.GetDirectoryName("C:\\Windows\\System32\\cmd.exe");
                proc.Arguments = "/c " + tmp;
                if (runas)
                    proc.Verb = "runas";
                Process.Start(proc);
                this.Hide();
                return;
            }
            if (tmp.Contains("!") != true)
            {
                for (int i = 0; i < sName.Count; i++)
                {
                    if (csen == true) //if case-sensitive is true
                    {
                        if (tmp == sName[i])
                        {
                            try
                            {
                                if (sPara[i] == "None" || sPara[i] == "Not Available")
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    //proc.Arguments = sPara[i];
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                else
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    proc.Arguments = sPara[i];
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                this.Hide();

                                //for suggestions
                                if (suggestions.Count > 0)
                                {
                                    int position = CheckExistSuggestion(sName[i]);
                                    if (position != -1)
                                    {
                                        suggestions[position].count += 1;
                                        suggestions[position].lasttime = DateTime.Now;
                                    }
                                    else
                                        suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                SortSuggestions();
                            }
                            catch
                            {
                                return;
                            }
                            return;
                        }
                    }
                    else
                    {
                        if (tmp.ToLower() == sName[i].ToLower())
                        {
                            try
                            {
                                if (sPara[i] == "None" || sPara[i] == "Not Available")
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    //proc.Arguments = sPara[i];
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                else
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    proc.Arguments = sPara[i];
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                this.Hide();

                                //for suggestions
                                if (suggestions.Count > 0)
                                {
                                    int position = CheckExistSuggestion(sName[i]);
                                    if (position != -1)
                                    {
                                        suggestions[position].count += 1;
                                        suggestions[position].lasttime = DateTime.Now;
                                    }
                                    else
                                        suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                SortSuggestions();
                            }
                            catch
                            {
                                return;
                            }
                            return;
                        }
                    }
                }
                for (int i = 0; i < sName.Count; i++)
                {
                    if (sName[i].Contains(tmp))
                    {
                        try
                        {
                            if (sPara[i] == "None" || sPara[i] == "Not Available")
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                //proc.Arguments = sPara[i];
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);
                            }
                            else
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                proc.Arguments = sPara[i];
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);

                            }

                            this.Hide();

                            //for suggestions
                            if (suggestions.Count > 0)
                            {
                                int position = CheckExistSuggestion(sName[i]);
                                if (position != -1)
                                {
                                    suggestions[position].count += 1;
                                    suggestions[position].lasttime = DateTime.Now;
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            }
                            else
                                suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            SortSuggestions();

                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }

                for (int i = 0; i < sPath.Count; i++)
                {
                    if (sPath[i].Contains(tmp))
                    {
                        try
                        {
                            if (sPara[i] == "None" || sPara[i] == "Not Available")
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);
                            }
                            else
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                proc.Arguments = sPara[i];
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);
                            }

                            this.Hide();

                            //for suggestions
                            if (suggestions.Count > 0)
                            {
                                int position = CheckExistSuggestion(sName[i]);
                                if (position != -1)
                                {
                                    suggestions[position].count += 1;
                                    suggestions[position].lasttime = DateTime.Now;
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            }
                            else
                                suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            SortSuggestions();

                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
            }
            else //if contain !
            {
                string[] pieces = tmp.Split('!');
                string tmp2 = pieces[0].Trim(' ');
                string tmp3 = pieces[1].Trim(' ');

                for (int i = 0; i < sName.Count; i++)
                {
                    if (csen == true)
                    {
                        if (tmp2 == sName[i])
                        {
                            try
                            {
                                if (sPara[i] != "Not Available")
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    proc.Arguments = tmp3;
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                else
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                this.Hide();

                                //for suggestions
                                if (suggestions.Count > 0)
                                {
                                    int position = CheckExistSuggestion(sName[i]);
                                    if (position != -1)
                                    {
                                        suggestions[position].count += 1;
                                        suggestions[position].lasttime = DateTime.Now;
                                    }
                                    else
                                        suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                SortSuggestions();
                                return;
                            }
                            catch
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (tmp2.ToLower() == sName[i].ToLower())
                        {
                            try
                            {
                                if (sPara[i] != "Not Available")
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    proc.Arguments = tmp3;
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                else
                                {
                                    ProcessStartInfo proc = new ProcessStartInfo();
                                    proc.FileName = sPath[i];
                                    proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                    if (runas)
                                        proc.Verb = "runas";
                                    Process.Start(proc);
                                }
                                this.Hide();

                                //for suggestions
                                if (suggestions.Count > 0)
                                {
                                    int position = CheckExistSuggestion(sName[i]);
                                    if (position != -1)
                                    {
                                        suggestions[position].count += 1;
                                        suggestions[position].lasttime = DateTime.Now;
                                    }
                                    else
                                        suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                                SortSuggestions();
                                return;
                            }
                            catch
                            {
                                return;
                            }
                        }
                    }
                }
                for (int i = 0; i < sName.Count; i++)
                {
                    if (sName[i].Contains(tmp2))
                    {
                        try
                        {
                            if (sPara[i] != "Not Available")
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                proc.Arguments = tmp3;
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);
                            }
                            else
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);
                            }

                            this.Hide();
                            //for suggestions
                            if (suggestions.Count > 0)
                            {
                                int position = CheckExistSuggestion(sName[i]);
                                if (position != -1)
                                {
                                    suggestions[position].count += 1;
                                    suggestions[position].lasttime = DateTime.Now;
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            }
                            else
                                suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            SortSuggestions();
                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }

                for (int i = 0; i < sPath.Count; i++)
                {
                    if (sPath[i].Contains(tmp2))
                    {
                        try
                        {
                            if (sPara[i] != "Not Available")
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                proc.Arguments = tmp3;
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);
                            }
                            else
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.FileName = sPath[i];
                                proc.WorkingDirectory = Path.GetDirectoryName(sPath[i]);
                                if (runas)
                                    proc.Verb = "runas";
                                Process.Start(proc);
                            }

                            this.Hide();
                            //for suggestions
                            if (suggestions.Count > 0)
                            {
                                int position = CheckExistSuggestion(sName[i]);
                                if (position != -1)
                                {
                                    suggestions[position].count += 1;
                                    suggestions[position].lasttime = DateTime.Now;
                                }
                                else
                                    suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            }
                            else
                                suggestions.Add(new Suggestions(sName[i], 1, DateTime.Now));
                            SortSuggestions();
                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
            }
            if (tmp.Contains("\\"))
            {
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = tmp;
                    proc.WorkingDirectory = Path.GetDirectoryName(tmp);
                    if (runas)
                        proc.Verb = "runas";
                    Process.Start(proc);
                    this.Hide();
                    return;
                }
                catch
                {
                    ///
                }

            }
            if (tmp.Contains(">"))
            {
                string[] cut = tmp.Split('>');
                this.Hide();
                if (cut[1] != String.Empty)
                    TranslateText(cut[0], cut[1]);
                else
                    TranslateText(cut[0], "en|vi");
                return;
            }
            if (tmp.Contains("http://"))
            {
                //tmp = "http://" + tmp;
                try
                {
                    Process.Start(tmp);
                    this.Hide();
                    return;
                }
                catch
                {
                    ///
                }
            }
            if (ggSearch == true)
            {

                try
                {
                    Process.Start("https://www.google.com/search?q=" + tmp);
                    this.Hide();
                    return;

                }
                catch
                {
                    //
                }

            }
            MessageBox.Show("Unavailable shortcut name!?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void TranslateText(string input, string languagePair)
        {
            string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
            Process.Start(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker tbw = new BackgroundWorker();
            tbw.DoWork += Tbw_DoWork;
            tbw.RunWorkerAsync(false);
            tbw.RunWorkerCompleted += Tbw_RunWorkerCompleted;
        }

        private void Tbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ReloadSuggestions();
        }

        private void Tbw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool runas = (bool)e.Argument;
            string dfl = comboBox1.Text;
            if (dfl.Contains("#"))
                dfl = dfl.Substring(1);//remove first # character
            if (dfl.Contains("+"))
            {
                string[] piece = dfl.Split('+');
                foreach (string s in piece)
                {
                    Run(s.Trim(' '), runas);
                }
            }
            else if (dfl.Contains("!") && dfl.Contains("\\") != true)
            {

                string[] pieces = dfl.Split('!');
                for (int i = 0; i < sName.Count; i++)
                {
                    if (pieces[1].Trim(' ') == sName[i])
                    {
                        Run(pieces[0] + "!" + sPath[i], runas);
                        comboBox1.Text = String.Empty;
                        return;
                    }
                }
                for (int i = 0; i < sName.Count; i++)
                {
                    if (sName[i].Contains(pieces[1].Trim(' ')))
                    {
                        Run(pieces[0] + "!" + sPath[i], runas);
                        comboBox1.Text = String.Empty;
                        return;
                    }
                }
                Run(dfl, runas);
                comboBox1.Text = String.Empty;
                return;
            }

            else
                Run(dfl, runas);
            comboBox1.Text = String.Empty;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (suggestions.Count > 0)
            {
                System.IO.File.WriteAllText(dataPath + "\\suggestions", String.Empty);
                if (suggestions.Count > 20)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        System.IO.File.AppendAllText(dataPath + "\\suggestions", suggestions[i].loc + "|" + suggestions[i].count + "|" + suggestions[i].lasttime + Environment.NewLine);
                    }
                }
                else
                {
                    for (int i = 0; i < suggestions.Count; i++)
                    {
                        System.IO.File.AppendAllText(dataPath + "\\suggestions", suggestions[i].loc + "|" + suggestions[i].count + "|" + suggestions[i].lasttime + Environment.NewLine);
                    }
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            comboBox1.Focus();
            comboBox1.SelectAll();
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (text.Contains("#"))
                {
                    for (int i = index + 1; i < sysCmd.Count(); i++)
                    {
                        if (sysCmd[i].Contains(part))
                        {

                            comboBox1.Text = text1 + sysCmd[i];
                            index = i;
                            //select text which not belong to "text"
                            comboBox1.SelectionStart = comboBox1.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                            comboBox1.SelectionLength = comboBox1.Text.Length - part.Length; //length = length of combobox text - length of "text"
                            return;

                        }
                    }

                    //reset if not 
                    comboBox1.Text = text;
                    comboBox1.SelectionStart = comboBox1.Text.Length;
                    comboBox1.SelectionLength = 0;
                    index = -1; //-1 for index + 1 = 0 //fucking nice
                }
                if (text.Contains("\\") != true) //if not contain \
                {
                    if (text.Contains("+") != true && text.Contains("!") != true) //if not contain , and !
                    {
                        for (int i = index + 1; i < sName.Count; i++)
                        {
                            if (sName[i].Contains(text))
                            {
                                comboBox1.Text = sName[i];
                                index = i;
                                comboBox1.SelectionStart = comboBox1.Text.Length;
                                comboBox1.SelectionLength = 0;

                                return;
                            }
                        }

                        //reset if not 
                        comboBox1.Text = text;
                        comboBox1.SelectionStart = comboBox1.Text.Length;
                        comboBox1.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") == true && text.Contains("!") != true)
                    {
                        for (int i = index + 1; i < sName.Count; i++)
                        {
                            if (sName[i].Contains(part))
                            {
                                comboBox1.Text = text1 + " " + sName[i];
                                index = i;
                                comboBox1.SelectionStart = comboBox1.Text.Length;
                                comboBox1.SelectionLength = 0;



                                return;
                            }
                        }

                        //reset if not 
                        comboBox1.Text = text;
                        comboBox1.SelectionStart = comboBox1.Text.Length;
                        comboBox1.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") != true && text.Contains("!") == true)
                    {
                        for (int i = index + 1; i < sName.Count; i++)
                        {
                            if (sName[i].Contains(part))
                            {
                                comboBox1.Text = text1 + " " + sName[i];
                                index = i;
                                comboBox1.SelectionStart = comboBox1.Text.Length;
                                comboBox1.SelectionLength = 0;



                                return;
                            }
                        }

                        //reset if not 
                        comboBox1.Text = text;
                        comboBox1.SelectionStart = comboBox1.Text.Length;
                        comboBox1.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }

                }
                else if (text.Contains("\\"))
                {
                    if (text.Contains("+") != true && text.Contains("!") != true) //if not contain , and !
                    {
                        for (int i = index + 1; i < dir.Count; i++)
                        {
                            if (dir[i].Contains(text))
                            {
                                comboBox1.Text = dir[i];
                                index = i;
                                //select text which not belong to "text"
                                comboBox1.SelectionStart = comboBox1.Text.IndexOf(text) + text.Length; //index of "text" + length => position to start selection
                                comboBox1.SelectionLength = comboBox1.Text.Length - text.Length; //length = length of combobox text - length of "text"
                                return;
                            }
                        }
                        //reset if not
                        comboBox1.Text = text;
                        comboBox1.SelectionStart = comboBox1.Text.Length;
                        comboBox1.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") == true && text.Contains("!") != true)
                    {
                        if (part.Contains("\\"))
                        {
                            for (int i = index + 1; i < dir.Count; i++)
                            {
                                if (dir[i].Contains(part))
                                {
                                    comboBox1.Text = text1 + " " + dir[i];
                                    index = i;
                                    //select text which not belong to "text"
                                    comboBox1.SelectionStart = comboBox1.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                                    comboBox1.SelectionLength = comboBox1.Text.Length - part.Length; //length = length of combobox text - length of "text"
                                    return;
                                }
                            }
                            //reset if not
                            comboBox1.Text = text;
                            comboBox1.SelectionStart = comboBox1.Text.Length;
                            comboBox1.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                        else //if not contain \ in part
                        {
                            for (int i = index + 1; i < sName.Count; i++)
                            {
                                if (sName[i].Contains(part))
                                {
                                    comboBox1.Text = text1 + " " + sName[i];
                                    index = i;
                                    comboBox1.SelectionStart = comboBox1.Text.Length;
                                    comboBox1.SelectionLength = 0;
                                    return;
                                }
                            }

                            //reset if not 
                            comboBox1.Text = text;
                            comboBox1.SelectionStart = comboBox1.Text.Length;
                            comboBox1.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                    }
                    else if (text.Contains("+") != true && text.Contains("!") == true)
                    {
                        if (part.Contains("\\"))
                        {
                            for (int i = index + 1; i < dir.Count; i++)
                            {
                                if (dir[i].Contains(part))
                                {
                                    comboBox1.Text = text1 + " " + dir[i];
                                    index = i;
                                    //select text which not belong to "text"
                                    comboBox1.SelectionStart = comboBox1.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                                    comboBox1.SelectionLength = comboBox1.Text.Length - part.Length; //length = length of combobox text - length of "text"
                                    return;
                                }
                            }
                            //reset if not
                            comboBox1.Text = text;
                            comboBox1.SelectionStart = comboBox1.Text.Length;
                            comboBox1.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                        else //if not contain \ in part
                        {
                            for (int i = index + 1; i < sName.Count; i++)
                            {
                                if (sName[i].Contains(part))
                                {
                                    comboBox1.Text = text1 + " " + sName[i];
                                    index = i;
                                    comboBox1.SelectionStart = comboBox1.Text.Length;
                                    comboBox1.SelectionLength = 0;
                                    return;
                                }
                            }

                            //reset if not 
                            comboBox1.Text = text;
                            comboBox1.SelectionStart = comboBox1.Text.Length;
                            comboBox1.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                    }
                }
            }

        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Tab)
            {
                if (comboBox1.Text.Contains("#"))
                {
                    text = comboBox1.Text;
                    text1 = text.Substring(0, text.IndexOf("#") + 1); //from 0 to last index of ,
                    part = text.Substring(text.IndexOf("#") + 1); //from last index of ,

                    part = part.Trim();
                    index = -1;
                }
                if (comboBox1.Text.Contains("+") != true && comboBox1.Text.Contains("!") != true)
                {
                    text = comboBox1.Text;
                    index = -1;
                    if (text.Contains("\\")) //if input is a directory or a file
                    {
                        try
                        {
                            searchDir(text);
                        }
                        catch //in case user input a pre-directory text
                        {
                            dir.Clear();
                            string cut = text.Substring(0, text.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            try
                            {
                                searchDir(cut);

                            }
                            catch
                            {
                                dir.Clear();
                            }
                        }
                    }
                }
                else if (comboBox1.Text.Contains("+") && comboBox1.Text.Contains("!") != true)
                {

                    text = comboBox1.Text;
                    text1 = text.Substring(0, text.LastIndexOf("+") + 1); //from 0 to last index of ,
                    part = text.Substring(text.LastIndexOf("+") + 1); //from last index of ,

                    part = part.Trim();
                    index = -1;
                    if (part.Contains("\\")) //if input is a directory or a file
                    {
                        try
                        {
                            searchDir(part);

                        }
                        catch //in case user input a pre-directory text
                        {
                            dir.Clear();
                            string cut = part.Substring(0, part.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            try
                            {
                                searchDir(cut);

                            }
                            catch
                            {
                                dir.Clear();
                            }
                        }
                    }

                }
                else if (comboBox1.Text.Contains("+") != true && comboBox1.Text.Contains("!"))
                {

                    text = comboBox1.Text;
                    text1 = text.Substring(0, text.LastIndexOf("!") + 1); //from 0 to last index of !
                    part = text.Substring(text.LastIndexOf("!") + 1); //from last index of !
                    //MessageBox.Show(text + " " + text1 + " " + part);
                    part = part.Trim();
                    index = -1;
                    if (part.Contains("\\")) //if input is a directory or a file
                    {
                        try
                        {
                            searchDir(part);

                        }
                        catch //in case user input a pre-directory text
                        {
                            dir.Clear();
                            string cut = part.Substring(0, part.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            try
                            {
                                searchDir(cut);

                            }
                            catch
                            {
                                dir.Clear();
                            }
                        }
                    }
                }


            }
            if (e.KeyCode == Keys.Left) //set pointer to end of text 
            {
                if (comboBox1.SelectionStart == 0)
                    comboBox1.SelectionStart = comboBox1.Text.Length;
            }

        }

        private void searchDir(string _path)
        {
            string[] dirArray = Directory.GetDirectories(_path);
            for (int i = 0; i < dirArray.Length; i++)
            {
                if (((File.GetAttributes(dirArray[i]) & FileAttributes.Hidden) != FileAttributes.Hidden))
                    dir.Add(dirArray[i]);
            }
            string[] fileArray = Directory.GetFiles(_path);
            for (int i = 0; i < fileArray.Length; i++)
            {
                if (((File.GetAttributes(fileArray[i]) & FileAttributes.Hidden) != FileAttributes.Hidden))
                    dir.Add(fileArray[i]);
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //comboBox1.DroppedDown = true;
            if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Space && e.KeyCode != Keys.Delete)
            {
                if (comboBox1.SelectionLength != 0)
                {
                    comboBox1.SelectionStart = comboBox1.Text.Length;


                }

            }
            if (e.KeyCode == Keys.ControlKey)
            {
                for (int i = 0; i < sName.Count; i++)
                {
                    if (comboBox1.Text == sName[i])
                    {
                        comboBox1.Text = sPath[i];
                        comboBox1.SelectAll();
                        Clipboard.SetText(comboBox1.Text);
                        return;
                    }
                }
                for (int i = 0; i < sPath.Count; i++)
                {
                    if (comboBox1.Text == sPath[i])
                    {
                        comboBox1.Text = sName[i];
                        comboBox1.SelectAll();

                        return;
                    }
                }
            }

            if (e.KeyCode == Keys.Alt | e.KeyCode == Keys.Enter)
            {
                openAsAdministratorToolStripMenuItem_Click(null, null);
            }

        }

        private void RunForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void RunForm_Paint(object sender, PaintEventArgs e)
        {
            Form frm = (Form)sender;
            ControlPaint.DrawBorder(e.Graphics, frm.ClientRectangle,
            Color.LightBlue, 1, ButtonBorderStyle.Solid,
            Color.LightBlue, 1, ButtonBorderStyle.Solid,
            Color.LightBlue, 1, ButtonBorderStyle.Solid,
            Color.LightBlue, 1, ButtonBorderStyle.Solid);
            
        }

        private void openAsAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    if (sourceControl != comboBox1)
                    {
                        Button btt = (Button)sourceControl;
                        comboBox1.Text = btt.Text;
                    }

                }
            }

            BackgroundWorker tbw = new BackgroundWorker();
            tbw.DoWork += Tbw_DoWork;
            tbw.RunWorkerAsync(true);
        }

       
    }
}
