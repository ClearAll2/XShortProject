using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace XShort
{
    public partial class RunForm : Form
    {
        private int suggestNum = 4;
        private int index = 0;
        private int rel = 0;
        private List<String> dir = new List<String>();
        private List<Shortcut> Shortcuts;
        private List<String> blockList = new List<string>();
        private ImageList sImage = new ImageList();
        private List<Suggestions> suggestions = new List<Suggestions>();
        private List<Suggestions> timeSuggestions = new List<Suggestions>();
        private string dataPath;
        private bool ggSearch = true;
        private bool csen = false;
        private bool ss = false;
        private bool sr = false;
        private bool er = false;
        private bool ui = false;
        private string text = String.Empty;
        private string text1, part = String.Empty;
        private string[] sysCmd = { "utilman", "hdwwiz", "appwiz.cpl", "netplwz", "azman.msc", "sdctl", "fsquirt", "calc", "certmgr.msc", "charmap", "chkdsk", "cttune", "colorcpl.exe", "cmd", "dcomcnfg", "comexp.msc", "compmgmt.msc", "control", "credwiz", "timedate.cpl", "hdwwiz", "devmgmt.msc", "tabcal", "directx.cpl", "dxdiag", "cleanmgr", "dfrgui", "diskmgmt.msc", "diskpart", "dccw", "dpiscaling", "control desktop", "desk.cpl", "control color", "documents", "downloads", "verifier", "dvdplay", "sysdm.cpl", "	rekeywiz", "eventvwr.msc", "sigverif", "control folders", "control fonts", "joy.cpl", "gpedit.msc", "inetcpl.cpl", "ipconfig", "iscsicpl", "control keyboard", "lpksetup", "secpol.msc", "lusrmgr.msc", "logoff", "mrt", "mmc", "mspaint", "msdt", "control mouse", "main.cpl", "ncpa.cpl", "notepad", "perfmon.msc", "powercfg.cpl", "control printers", "regedit", "snippingtool", "wscui.cpl", "services.msc", "mmsys.cpl", "mmsys.cpl", "sndvol", "msconfig", "sfc", "msinfo32", "sysdm.cpl", "taskmgr", "explorer", "firewall.cpl", "wf.msc", "magnify", "powershell", "winver", "telnet", "rstrui" };
        private string lastcalled = String.Empty;
        private BackgroundWorker bw;
        private int originalSize;
        private List<String> indexData = new List<string>();
        private readonly BackgroundWordFilter _filter;
        private readonly BackgroundWordFilter _getdir;
        private List<String> matches = new List<string>();
        public RunForm(List<Shortcut> shortcuts)
        {
            InitializeComponent();
            Shortcuts = new List<Shortcut>(shortcuts);
            dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
            sImage.ImageSize = new Size(30, 30);
            sImage.ColorDepth = ColorDepth.Depth32Bit;
            comboBoxRun.DropDownHeight = comboBoxRun.Font.Height * 5;
            originalSize = this.Height;

            comboBoxRun.Focus();
            comboBoxRun.SelectAll();

            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            _filter = new BackgroundWordFilter
            (
                items: indexData,
                maxItemsToMatch: 15,
                callback: results => this.Invoke(new Action(() => 
                {
                      matches.Clear();
                      matches = results;
                })),
                imageList: imageResults => this.Invoke(new Action(() =>
                {
                    imageList1.Images.Clear();
                    imageList1 = imageResults;
                }))
            );
            _getdir = new BackgroundWordFilter
            (
                callback: results => this.Invoke(new Action(() =>
                {
                    dir.Clear();
                    dir = results;
                })),
                imageList: imageResults => this.Invoke(new Action(() =>
                {
                    imageList2.Images.Clear();
                    imageList2 = imageResults;
                }))
            );
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadSuggestions();
            MaintainSuggestions();
            comboBoxRun.Enabled = true;
        }

        private void LoadIcon()
        {
            sImage.Images.Clear();
            for (int i = 0; i < Shortcuts.Count; i++)
            {
                try
                {
                    sImage.Images.Add(Icon.ExtractAssociatedIcon(Shortcuts[i].Path));
                }
                catch
                {
                    if (Shortcuts[i].Path.Contains("http"))
                        sImage.Images.Add(Properties.Resources.internet);
                    else if (Shortcuts[i].Path.Contains("\\"))
                    {
                        if (Directory.Exists(Shortcuts[i].Path))
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

        private void LoadIcon(ImageList imageList, List<String> path)
        {
            imageList.Images.Clear();
            for (int i = 0; i < path.Count; i++)
            {
                try
                {
                    imageList.Images.Add(Icon.ExtractAssociatedIcon(path[i]));
                }
                catch
                {
                    if (path[i].Contains("http"))
                        imageList.Images.Add(Properties.Resources.internet);
                    else if (path[i].Contains("\\"))
                    {
                        if (Directory.Exists(path[i]))
                            imageList.Images.Add(Properties.Resources.dir);
                        else
                            imageList.Images.Add(Properties.Resources.error);
                    }
                    else
                    {
                        imageList.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }

                }
            }
        }

        /// <summary>
        /// Check and remove invalid shortcuts from suggestions
        /// </summary>
        public void MaintainSuggestions()
        {
            for (int i = 0; i < suggestions.Count; i++)
            {
                if (Shortcuts.FindIndex(f => f.Name == suggestions[i].loc) < 0 && !sysCmd.Contains(suggestions[i].loc))
                    suggestions.RemoveAt(i);
                if (Shortcuts.FindIndex(f => f.Name == suggestions[i].nextcall) < 0 && !sysCmd.Contains(suggestions[i].nextcall))
                    suggestions[i].nextcall = String.Empty;
            }
            LoadIcon();
            ReloadSuggestions();
        }


        private void timerSuggestions_Tick(object sender, EventArgs e)
        {
            ReloadSuggestions();
        }

        /// <summary>
        /// Build shortcut suggestions from their last time, next called and order
        /// </summary>
        public void ReloadSuggestions()
        {
            if (ss)
            {
                List<String> addedSuggestions = new List<string>();
                rel = 0;
                panelSuggestions.Controls.Clear();
                timeSuggestions.Clear();
                for (int i = 0; i < suggestions.Count; i++)//time-based suggestions
                {
                    if (suggestions[i].lasttime.Hour == DateTime.Now.Hour || suggestions[i].lasttime.Hour == DateTime.Now.Hour + 1 && suggestions[i].lasttime.Minute <= 30 || suggestions[i].lasttime.Hour == DateTime.Now.Hour - 1 && suggestions[i].lasttime.Minute >= 30)
                    {
                        if (!blockList.Contains(suggestions[i].loc))//if it's not in blocklist
                            timeSuggestions.Add(suggestions[i]);
                    }
                }

                if (timeSuggestions.Count > 0)
                {
                    for (int i = 0; i < timeSuggestions.Count; i++)
                    {
                        AddNewSuggestionsItems(timeSuggestions[i].loc, Shortcuts.FindIndex(f => f.Name == timeSuggestions[i].loc) >= 0);
                        addedSuggestions.Add(timeSuggestions[i].loc);
                        if (rel >= suggestNum)
                            break;
                    }
                    if (rel < suggestNum)
                    {
                        int remain = suggestNum - rel;
                        if (suggestions.Count >= remain)
                        {
                            for (int i = 0; i < timeSuggestions.Count; i++)
                            {
                                if (timeSuggestions[i].nextcall != String.Empty)
                                {
                                    if (!addedSuggestions.Contains(timeSuggestions[i].nextcall))//prevent duplicate 
                                    {
                                        if (!blockList.Contains(timeSuggestions[i].nextcall))//if it's not in blocklist
                                        {
                                            AddNewSuggestionsItems(timeSuggestions[i].nextcall, Shortcuts.FindIndex(f => f.Name == timeSuggestions[i].nextcall) >= 0);
                                            addedSuggestions.Add(timeSuggestions[i].nextcall);
                                            if (remain > 0)
                                                remain -= 1;
                                            else
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                if (rel < suggestNum)
                {
                    int remain = suggestNum - rel;
                    if (suggestions.Count >= remain)
                    {
                        for (int i = 0; i < suggestions.Count; i++)
                        {
                            if (!addedSuggestions.Contains(suggestions[i].loc))//prevent duplicate 
                            {
                                if (!blockList.Contains(suggestions[i].loc))//if it's not in blocklist
                                {
                                    AddNewSuggestionsItems(suggestions[i].loc, Shortcuts.FindIndex(f => f.Name == suggestions[i].loc) >= 0);
                                    addedSuggestions.Add(suggestions[i].loc);
                                    if (remain > 0)
                                        remain -= 1;
                                    else
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check if a shortcut is in suggestions list
        /// </summary>
        /// <param name="loc">suggestion loc</param>
        /// <returns></returns>
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


        /// <summary>
        /// Load suggestions list from file
        /// </summary>
        private void LoadSuggestions()
        {
            if (System.IO.File.Exists(dataPath + "\\suggestions"))
            {
                FileStream fs = new FileStream(dataPath + "\\suggestions", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string read = sr.ReadLine();
                    string[] cut = read.Split('|');
                    if (cut.Length == 3)
                        suggestions.Add(new Suggestions(cut[0], Int32.Parse(cut[1]), DateTime.Parse(cut[2])));
                    else
                        suggestions.Add(new Suggestions(cut[0], Int32.Parse(cut[1]), DateTime.Parse(cut[2]), cut[3]));
                }
                sr.Close();
                fs.Close();
                
                ReloadSuggestions();
            }
        }

        /// <summary>
        /// Create new suggestions button on the Run box
        /// </summary>
        /// <param name="text">Display text</param>
        /// <param name="useImageList">Use built-in image list?</param>
        private void AddNewSuggestionsItems(string text, bool useImageList)
        {
            int recentWidth = 1 + (panelSuggestions.Width - 1) / suggestNum;//https://stackoverflow.com/questions/15100685/what-is-the-right-way-to-round-dividing-to-integers
            Button newsuggestion = new Button
            {
                ForeColor = SystemColors.ControlDarkDark,
                BackColor = System.Drawing.Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            newsuggestion.FlatAppearance.BorderSize = 0;
            newsuggestion.FlatAppearance.BorderColor = Color.White;
            newsuggestion.Tag = text;
            if (useImageList)
            {
                newsuggestion.ImageList = sImage;
                newsuggestion.ImageIndex = Shortcuts.FindIndex(f => f.Name == text);
                toolTip1.SetToolTip(newsuggestion, Shortcuts[newsuggestion.ImageIndex].Path);
            }
            else
            {
                Size size = new Size(30, 30);
                if (suggestNum > 6)
                {
                    size.Height = 20;
                    size.Width = 20;
                }
                Image icon = new Bitmap(Properties.Resources.terminal, size);
                newsuggestion.Image = icon;
                toolTip1.SetToolTip(newsuggestion, text);
            }
            newsuggestion.AutoEllipsis = true;
            newsuggestion.Left = rel * recentWidth;
            newsuggestion.Text = text;
            newsuggestion.TabStop = false;
            newsuggestion.ContextMenuStrip = contextMenuStrip1;
            newsuggestion.TextImageRelation = TextImageRelation.ImageBeforeText;
            newsuggestion.Width = recentWidth;
            newsuggestion.Height = panelSuggestions.Height;
            newsuggestion.Click += Newsuggestion_Click;
            newsuggestion.MouseDown += Newsuggestion_MouseDown;
            panelSuggestions.Controls.Add(newsuggestion);
            rel += 1;
        }

        /// <summary>
        /// Create new suggestions button on the Run box
        /// </summary>
        /// <param name="text">Display text</param>
        /// <param name="imageList">Image list</param>
        /// <param name="imageIndex">Image index</param>
        /// <param name="toolTip">Tooltip</param>
        private void AddNewSuggestionsItems(string text, ImageList imageList, int imageIndex, string toolTip)
        {
            int recentWidth = 1 + (panelSuggestions.Width - 1) / suggestNum;//https://stackoverflow.com/questions/15100685/what-is-the-right-way-to-round-dividing-to-integers
            Button newsuggestion = new Button
            {
                ForeColor = SystemColors.ControlDarkDark,
                BackColor = System.Drawing.Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            newsuggestion.FlatAppearance.BorderSize = 0;
            newsuggestion.FlatAppearance.BorderColor = Color.White;
           
            newsuggestion.ImageList = imageList;
            newsuggestion.ImageIndex = imageIndex;
            toolTip1.SetToolTip(newsuggestion, toolTip);
            newsuggestion.AutoEllipsis = true;
            newsuggestion.Left = rel * recentWidth;
            newsuggestion.Tag = text;
            newsuggestion.Text = text;
            newsuggestion.TabStop = false;
            newsuggestion.ContextMenuStrip = contextMenuStrip1;
            newsuggestion.TextImageRelation = TextImageRelation.ImageBeforeText;
            newsuggestion.Width = recentWidth;
            newsuggestion.Height = panelSuggestions.Height;
            newsuggestion.Click += Newsuggestion_Click;
            newsuggestion.MouseDown += Newsuggestion_MouseDown;
            panelSuggestions.Controls.Add(newsuggestion);
            rel += 1;
        }

        /// <summary>
        /// Action of middle mouse button
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Mouse</param>
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
            SimpleRun(button.Tag.ToString(), Shortcuts.FindIndex(f => f.Name == button.Tag.ToString()) >= 0);
            comboBoxRun.Text = String.Empty;
            ReloadSuggestions();
        }

        /// <summary>
        /// Sort suggestions list
        /// </summary>
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
            LoadData();
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
                        SimpleRun(startup[i], true);
                    }
                }
            }
        }

        /// <summary>
        /// Update next called shortcut suggestions
        /// </summary>
        /// <param name="name">Shortcut name</param>
        private void UpdateSuggestions(string name)
        {
            string current;
            if (suggestions.Count > 0)
            {
                int position = CheckExistSuggestion(name);
                if (position != -1)
                {
                    suggestions[position].count += 1;
                    suggestions[position].lasttime = DateTime.Now;
                    current = suggestions[position].loc;
                }
                else
                {
                    suggestions.Add(new Suggestions(name, 1, DateTime.Now));
                    current = name;
                }
            }
            else
            {
                suggestions.Add(new Suggestions(name, 1, DateTime.Now));
                current = name;
            }
            if (lastcalled != String.Empty)
            {
                int previous = CheckExistSuggestion(lastcalled);//find position of last called shorcut
                lastcalled = current;                           //set last called = current called
                if (lastcalled != suggestions[previous].loc)    //prevent next called is itself
                    suggestions[previous].nextcall = lastcalled;    //set last called shortcut's next call = last called = current
            }
            else
            {
                lastcalled = current;
            }
            SortSuggestions();
        }

        private void SimpleRun(string s, bool isInList)
        {
            if (isInList)
            {
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (s == Shortcuts[i].Name)
                    {
                        try
                        {
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                Process.Start(Shortcuts[i].Path, Shortcuts[i].Para);
                            else
                                Process.Start(Shortcuts[i].Path);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);
                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
            }
            else
            {
                if (sysCmd.Contains(s))
                {
                    try
                    {
                        this.Hide();
                        ProcessStartInfo proc = new ProcessStartInfo();
                        proc.FileName = "C:\\Windows\\System32\\cmd.exe";
                        proc.WorkingDirectory = Path.GetDirectoryName("C:\\Windows\\System32\\cmd.exe");
                        proc.Arguments = "/c " + s;
                        Process.Start(proc);

                        //for suggestions
                        UpdateSuggestions(s);
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }


        public void ChangeSetting(bool _gg, bool _csen, bool _ss, bool _sr, bool _er, int maxss, bool _ui)
        {
            if (maxss >= 2 && maxss <= 8)
                suggestNum = maxss;
            else
                suggestNum = 4;
            if (suggestNum > 6)
            {
                sImage.Images.Clear();
                sImage.ImageSize = new Size(20, 20);
                LoadIcon();
            }
            else 
            {
                if (sImage.ImageSize.Height != 30)
                {
                    sImage.Images.Clear();
                    sImage.ImageSize = new Size(30, 30);
                    LoadIcon();
                }
            }
            ggSearch = _gg;
            csen = _csen;
            sr = _sr;
            er = _er;
            ss = _ss;
            ui = _ui;
            if (ss)
                ReloadSuggestions();
            else
            {
                panelSuggestions.Controls.Clear();
            }

            
            
        }


        public int LoadData()
        {
            //comboBoxRun.Items.Clear();
            //Shortcuts.Clear();
            //int i = 0;
            //FileStream fs;
            //StreamReader sr;
            //try
            //{
            //    fs = new FileStream(Path.Combine(dataPath, "data1.data"), FileMode.Open, FileAccess.Read);
            //}
            //catch
            //{
            //    return 0;
            //}
            //sr = new StreamReader(fs);
            //while (!sr.EndOfStream)
            //{
            //    Shortcut shortcut = new Shortcut
            //    {
            //        Name = StringCipher.Decrypt(sr.ReadLine(), pass)
            //    };
            //    Shortcuts.Add(shortcut);
            //}
            //fs.Close();
            //sr.Close();


            //try
            //{
            //    fs = new FileStream(Path.Combine(dataPath, "data2.data"), FileMode.Open, FileAccess.Read);
            //}
            //catch
            //{
            //    return -1;
            //}
            //sr = new StreamReader(fs);
            //while (!sr.EndOfStream)
            //{
            //    Shortcuts[i].Path = StringCipher.Decrypt(sr.ReadLine(), pass);
            //    i++;
            //}
            //fs.Close();
            //sr.Close();

            //i = 0;
            //try
            //{
            //    fs = new FileStream(Path.Combine(dataPath, "data3.data"), FileMode.Open, FileAccess.Read);
            //}
            //catch
            //{
            //    return -1;
            //}
            //sr = new StreamReader(fs);
            //while (!sr.EndOfStream)
            //{
            //    Shortcuts[i].Para = StringCipher.Decrypt(sr.ReadLine(), pass);
            //    i++;
            //}
            //fs.Close();
            //sr.Close();

            LoadIcon();
            LoadBlocklist();

            for (int j = 0; j < Shortcuts.Count; j++)
            {
                comboBoxRun.Items.Add(Shortcuts[j].Name);
            }
            LoadIndex();
            
            return 1;

        }

        public void LoadIndex()
        {
            indexData.Clear();
            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "folders"), FileMode.Open, FileAccess.Read);

            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                indexData.Add(sr.ReadLine());
            }
            fs.Close();
            sr.Close();

            try
            {
                fs = new FileStream(Path.Combine(dataPath, "files"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                indexData.Add(sr.ReadLine());
            }
            fs.Close();
            sr.Close();

        }

        public void LoadBlocklist()
        {
            FileStream fs;
            StreamReader sr;
            blockList.Clear();
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
                if (Shortcuts.FindIndex(f => f.Name == read) >= 0 || sysCmd.Contains(read))//check if it's not an invalid shortcut
                    blockList.Add(read);
            }
            fs.Close();
            sr.Close();
        }

        private void Run(string tmp, bool runas)
        {
            if (comboBoxRun.Text == String.Empty) //do nothing if comboBox is empty
                return;
            if (sysCmd.Contains(tmp))
            {
                this.Hide();
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = "C:\\Windows\\System32\\cmd.exe";
                proc.WorkingDirectory = Path.GetDirectoryName("C:\\Windows\\System32\\cmd.exe");
                proc.Arguments = "/c " + tmp;
                if (runas)
                    proc.Verb = "runas";
                Process.Start(proc);
                //for suggestions
                UpdateSuggestions(tmp);

                return;
            }
            if (tmp.Contains("!") != true)
            {
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (tmp == Shortcuts[i].Name || tmp.ToLower() == Shortcuts[i].Name.ToLower() && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                proc.Arguments = Shortcuts[i].Para;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Name.Contains(tmp) || Shortcuts[i].Name.ToLower().Contains(tmp.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                proc.Arguments = Shortcuts[i].Para;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);
                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);


                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }

                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Path.Contains(tmp) || Shortcuts[i].Path.ToLower().Contains(tmp.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                proc.Arguments = Shortcuts[i].Para;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);


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

                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (tmp2 == Shortcuts[i].Name || tmp2.ToLower() == Shortcuts[i].Name.ToLower() && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "Not Available")
                                proc.Arguments = tmp3;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

                            return;
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Name.Contains(tmp2) || Shortcuts[i].Name.ToLower().Contains(tmp2.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "Not Available")
                                proc.Arguments = tmp3;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }

                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Path.Contains(tmp2) || Shortcuts[i].Path.ToLower().Contains(tmp2.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "Not Available")
                                proc.Arguments = tmp3;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);
                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

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
                    this.Hide();
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = tmp;
                    proc.WorkingDirectory = Path.GetDirectoryName(tmp);
                    if (runas)
                        proc.Verb = "runas";
                    Process.Start(proc);
                    return;
                }
                catch
                {
                    ///
                }

            }
            //deprecated
            //if (tmp.Contains(">"))
            //{
            //    string[] cut = tmp.Split('>');
            //    this.Hide();
            //    if (cut[1] != String.Empty)
            //        TranslateText(cut[0], cut[1]);
            //    else
            //        TranslateText(cut[0], "en|vi");
            //    return;
            //}
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (reg.IsMatch(tmp))
            {
                //tmp = "http://" + tmp;
                try
                {
                    this.Hide();
                    Process.Start(tmp);
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
                    this.Hide();
                    Process.Start("https://www.google.com/search?q=" + tmp);
                    return;

                }
                catch
                {
                    //
                }

            }
            MessageBox.Show("Unavailable shortcut name!?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //
        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="input"></param>
        /// <param name="languagePair"></param>
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
            listViewResult.Items.Clear();
            if (this.Height > listViewResult.Height)
                this.Height -= panelSuggestions.Bottom;
            ReloadSuggestions();
        }

        private void Tbw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool runas = (bool)e.Argument;
            string dfl = comboBoxRun.Text;
            if (dfl.Contains("#"))
                dfl = dfl.Trim('#');//remove first # character
            if (dfl.Contains("+"))
            {
                string[] piece = dfl.Split('+');
                foreach (string s in piece)
                {
                    Run(s.Trim(), runas);
                }
            }
            else if (dfl.Contains("!") && dfl.Contains("\\") != true)
            {

                string[] pieces = dfl.Split('!');
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (pieces[1].Trim() == Shortcuts[i].Name)
                    {
                        Run(pieces[0] + "!" + Shortcuts[i].Path, runas);
                        comboBoxRun.Text = String.Empty;
                        return;
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Name.Contains(pieces[1].Trim()))
                    {
                        Run(pieces[0] + "!" + Shortcuts[i].Path, runas);
                        comboBoxRun.Text = String.Empty;
                        return;
                    }
                }
                Run(dfl, runas);
                comboBoxRun.Text = String.Empty;
                return;
            }

            else
                Run(dfl, runas);
            comboBoxRun.Text = String.Empty;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (suggestions.Count > 0)
            {
                string path = Path.Combine(dataPath, "suggestions");
                System.IO.File.WriteAllText(path, String.Empty);
                for (int i = 0; i < suggestions.Count; i++)
                {
                    string newline = String.Join("", suggestions[i].loc, "|", suggestions[i].count, "|", suggestions[i].lasttime.ToString("F", new CultureInfo("en")), "|", suggestions[i].nextcall, Environment.NewLine);
                    //System.IO.File.AppendAllText(dataPath + "\\suggestions", suggestions[i].loc + "|" + suggestions[i].count + "|" + suggestions[i].lasttime + Environment.NewLine);
                    System.IO.File.AppendAllText(path, newline);
                }
                
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            comboBoxRun.Focus();
            comboBoxRun.SelectAll();
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (text.Contains("#"))
                {
                    for (int i = index + 1; i < sysCmd.Count(); i++)
                    {
                        if (sysCmd[i].Contains(part) || sysCmd[i].ToLower().Contains(part.ToLower()) && !csen)
                        {

                            comboBoxRun.Text = text1 + sysCmd[i];
                            index = i;
                            //select text which not belong to "text"
                            comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                            comboBoxRun.SelectionLength = comboBoxRun.Text.Length - part.Length; //length = length of combobox text - length of "text"
                            return;

                        }
                    }

                    //reset if not 
                    comboBoxRun.Text = text;
                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                    comboBoxRun.SelectionLength = 0;
                    index = -1; //-1 for index + 1 = 0 //fucking nice
                }
                if (text.Contains("\\") != true) //if not contain \
                {
                    if (text.Contains("+") != true && text.Contains("!") != true) //if not contain , and !
                    {
                        for (int i = index + 1; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(text) || Shortcuts[i].Name.ToLower().Contains(text.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = Shortcuts[i].Name;
                                index = i;
                                comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                comboBoxRun.SelectionLength = 0;

                                return;
                            }
                        }

                        //reset if not 
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") == true && text.Contains("!") != true)
                    {
                        for (int i = index + 1; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                index = i;
                                comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                comboBoxRun.SelectionLength = 0;

                                return;
                            }
                        }

                        //reset if not 
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") != true && text.Contains("!") == true)
                    {
                        for (int i = index + 1; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                index = i;
                                comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                comboBoxRun.SelectionLength = 0;

                                return;
                            }
                        }

                        //reset if not 
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    
                }
                else if (text.Contains("\\"))
                {
                    
                    if (text.Contains("+") != true && text.Contains("!") != true) //if not contain , and !
                    {
                        for (int i = index + 1; i < dir.Count; i++)
                        {
                            if (dir[i].Contains(text) || dir[i].ToLower().Contains(text.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = dir[i];
                                index = i;
                                //select text which not belong to "text"
                                comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(text) + text.Length; //index of "text" + length => position to start selection
                                comboBoxRun.SelectionLength = comboBoxRun.Text.Length - text.Length; //length = length of combobox text - length of "text"
                                return;
                            }
                        }
                        //reset if not
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") == true && text.Contains("!") != true)
                    {
                        if (part.Contains("\\") )
                        {
                            for (int i = index + 1; i < dir.Count; i++)
                            {
                                if (dir[i].Contains(part) || dir[i].ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + dir[i];
                                    index = i;
                                    //select text which not belong to "text"
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                                    comboBoxRun.SelectionLength = comboBoxRun.Text.Length - part.Length; //length = length of combobox text - length of "text"
                                    return;
                                }
                            }
                            //reset if not
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                        else //if not contain \ in part
                        {
                            for (int i = index + 1; i < Shortcuts.Count; i++)
                            {
                                if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                    index = i;
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                    comboBoxRun.SelectionLength = 0;
                                    return;
                                }
                            }

                            //reset if not 
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                    }
                    else if (text.Contains("+") != true && text.Contains("!") == true)
                    {
                        if (part.Contains("\\"))
                        {
                            for (int i = index + 1; i < dir.Count; i++)
                            {
                                if (dir[i].Contains(part) || dir[i].ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + dir[i];
                                    index = i;
                                    //select text which not belong to "text"
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                                    comboBoxRun.SelectionLength = comboBoxRun.Text.Length - part.Length; //length = length of combobox text - length of "text"
                                    return;
                                }
                            }
                            //reset if not
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                        else //if not contain \ in part
                        {
                            for (int i = index + 1; i < Shortcuts.Count; i++)
                            {
                                if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                    index = i;
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                    comboBoxRun.SelectionLength = 0;
                                    return;
                                }
                            }

                            //reset if not 
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
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
                if (comboBoxRun.Text.Contains("#"))
                {
                    text = comboBoxRun.Text;
                    text1 = text.Substring(0, text.LastIndexOf("#") + 1); //from 0 to last index of ,
                    part = text.Substring(text.LastIndexOf("#") + 1); //from last index of ,

                    part = part.Trim();
                    index = -1;
                }
                if (comboBoxRun.Text.Contains("+") != true && comboBoxRun.Text.Contains("!") != true)
                {
                    text = comboBoxRun.Text;
                    index = -1;
                    if (text.Contains("\\")) //if input is a directory or a file
                    {
                        if (Directory.Exists(text))
                        {
                            _getdir.SetCurrentEntry(text);
                        }
                        else //in case user input a pre-directory text
                        {
                            string cut = text.Substring(0, text.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            _getdir.SetCurrentEntry(cut);
                        }
                    }
                }
                else if (comboBoxRun.Text.Contains("+") && comboBoxRun.Text.Contains("!") != true)
                {

                    text = comboBoxRun.Text;
                    text1 = text.Substring(0, text.LastIndexOf("+") + 1); //from 0 to last index of ,
                    part = text.Substring(text.LastIndexOf("+") + 1); //from last index of ,

                    part = part.Trim();
                    index = -1;
                    if (part.Contains("\\")) //if input is a directory or a file
                    {
                        if (Directory.Exists(part))
                        {
                            _getdir.SetCurrentEntry(part);
                        }
                        else //in case user input a pre-directory text
                        {
                            string cut = part.Substring(0, part.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            _getdir.SetCurrentEntry(cut);
                            
                        }
                    }

                }
                else if (comboBoxRun.Text.Contains("+") != true && comboBoxRun.Text.Contains("!"))
                {
                    text = comboBoxRun.Text;
                    text1 = text.Substring(0, text.LastIndexOf("!") + 1); //from 0 to last index of !
                    part = text.Substring(text.LastIndexOf("!") + 1); //from last index of !
                    //MessageBox.Show(text + " " + text1 + " " + part);
                    part = part.Trim();
                    index = -1;
                    if (part.Contains("\\")) //if input is a directory or a file
                    {
                        if (Directory.Exists(part))
                        {
                            _getdir.SetCurrentEntry(part);
                        }
                        else //in case user input a pre-directory text
                        {
                            string cut = part.Substring(0, part.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            _getdir.SetCurrentEntry(cut);
                           
                        }
                    }
                }
                ShowResult();
            }
            
            if (e.KeyCode == Keys.Left) //set pointer to end of text 
            {
                if (comboBoxRun.SelectionStart == 0)
                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
            }

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            _filter.SetCurrentEntry(comboBoxRun.Text);
            
            if (comboBoxRun.Text.Length == 0)
            {
                if (this.Height > listViewResult.Height)
                    this.Height = originalSize;
                ReloadSuggestions();
                imageList1.Images.Clear();
            }
        }

        private void ShowResult()
        {
            if (sr)
            {
                bool ifAny = false;
                string cut = comboBoxRun.Text;
                if (cut.Contains("\\"))
                {
                    if (dir.Count > 0)
                    {
                        listViewResult.Items.Clear();
                        listViewResult.SmallImageList = imageList2;
                        for (int i = 0; i < dir.Count; i++)
                        {
                            string item = Path.GetFileNameWithoutExtension(dir[i]);
                            listViewResult.Items.Add(new ListViewItem(item.Substring(item.LastIndexOf("\\") + 1)));
                            listViewResult.Items[i].ImageIndex = i;
                            listViewResult.Items[i].ToolTipText = dir[i];
                        }
                        if (this.Height < listViewResult.Height && listViewResult.Items.Count > 0)
                            this.Height += listViewResult.Height + listViewResult.Height / 10;//fix cutting listview
                    }
                    else
                    {
                        listViewResult.Items.Clear();
                        if (this.Height > listViewResult.Height)
                            this.Height = originalSize;
                    }
                }
                else//find result in index files
                {
                    if (ui)
                    {
                        if (matches.Count > 0)
                        {
                            listViewResult.Items.Clear();
                            listViewResult.SmallImageList = imageList1;
                            for (int i = 0; i < matches.Count; i++)
                            {
                                string item = Path.GetFileNameWithoutExtension(matches[i]);
                                listViewResult.Items.Add(new ListViewItem(item.Substring(item.LastIndexOf("\\") + 1)));
                                listViewResult.Items[i].ImageIndex = i;
                                listViewResult.Items[i].ToolTipText = matches[i];
                            }
                            if (this.Height < listViewResult.Height && listViewResult.Items.Count > 0)
                                this.Height += listViewResult.Height + listViewResult.Height / 10;
                        }
                    }
                }

                if (this.Height > listViewResult.Height && listViewResult.Items.Count == 0)
                    this.Height -= panelSuggestions.Bottom;
                if (cut.Length > 0 && !cut.Contains("#"))
                {
                    if (cut.Contains("!"))
                        cut = cut.Substring(cut.LastIndexOf("!") + 1);
                    else if (comboBoxRun.Text.Contains("+"))
                        cut = cut.Substring(cut.LastIndexOf("+") + 1);
                    cut = cut.Trim();
                    if (cut != String.Empty)
                    {
                        for (int i = 0; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(cut) || Shortcuts[i].Name.ToLower().Contains(cut.ToLower()) && !csen)
                            {
                                if (!ifAny)//prevent reload when nothing match
                                {
                                    ifAny = true;
                                    panelSuggestions.Controls.Clear();
                                    rel = 0;
                                }
                                if (rel < suggestNum)
                                {
                                    if (!er || !blockList.Contains(Shortcuts[i].Name))
                                        AddNewSuggestionsItems(Shortcuts[i].Name, sImage, i, Shortcuts[i].Path);
                                }
                                else//break if no more space => reduce loop time
                                    break;

                            }
                        }
                        if (rel < suggestNum)//add syscmd to search
                        {
                            int remain = suggestNum - rel;
                            for (int i = 0; i < sysCmd.Length; i++)
                            {
                                if (sysCmd[i].Contains(cut) || sysCmd[i].ToLower().Contains(cut.ToLower()) && !csen)
                                {
                                    if (!ifAny)//prevent reload when nothing match
                                    {
                                        ifAny = true;
                                        panelSuggestions.Controls.Clear();
                                        rel = 0;
                                    }
                                    if (remain > 0)
                                    {
                                        AddNewSuggestionsItems(sysCmd[i], false);
                                        remain -= 1;
                                    }
                                    else//break if no more space => reduce loop time
                                        break;
                                }
                            }
                        }
                        if (rel == 0)
                            ReloadSuggestions();

                    }
                }
            }
        }

        private void searchDir(string _path)
        {
            dir.Clear();
            if (Directory.Exists(_path))
            {
                var fileArray = Directory.EnumerateFileSystemEntries(_path);
                IEnumerator<string> enumerator = fileArray.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (((File.GetAttributes(enumerator.Current) & FileAttributes.Hidden) != FileAttributes.Hidden))
                        dir.Add(enumerator.Current);
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //comboBox1.DroppedDown = true;
            if (/*e.KeyCode != Keys.Back && e.KeyCode != Keys.Space && e.KeyCode != Keys.Delete*/e.KeyValue == 220)
            {
                if (comboBoxRun.SelectionLength != 0)
                {
                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;


                }

            }
            if (e.KeyCode == Keys.ControlKey)
            {
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (comboBoxRun.Text == Shortcuts[i].Name)
                    {
                        comboBoxRun.Text = Shortcuts[i].Path;
                        comboBoxRun.SelectAll();
                        Clipboard.SetText(comboBoxRun.Text);
                        return;
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (comboBoxRun.Text == Shortcuts[i].Path)
                    {
                        comboBoxRun.Text = Shortcuts[i].Name;
                        comboBoxRun.SelectAll();

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
            comboBoxRun.Text = String.Empty;
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

        private void panelSuggestions_Paint(object sender, PaintEventArgs e)
        {
            if (ss)
            {
                Panel frm = (Panel)sender;
                ControlPaint.DrawBorder(e.Graphics, frm.ClientRectangle,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 1, ButtonBorderStyle.Solid);
            }
        }

        private void listViewResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (comboBoxRun.Text.Contains("+") != true)
            {
                if (Directory.Exists(listViewResult.FocusedItem.ToolTipText))
                {
                    comboBoxRun.Text += "\\";
                    searchDir(comboBoxRun.Text);
                    ShowResult();
                }
                else
                {
                    try
                    {
                        ProcessStartInfo proc = new ProcessStartInfo();
                        proc.FileName = listViewResult.FocusedItem.ToolTipText;
                        Process.Start(proc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void listViewResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (listViewResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (comboBoxRun.Text.Contains("+") != true && comboBoxRun.Text.Contains("#") != true && comboBoxRun.Text.Contains("!") != true)
                    {
                        if (comboBoxRun.SelectedText.Length > 0)
                            comboBoxRun.SelectedText = listViewResult.FocusedItem.Text;
                        else
                            comboBoxRun.Text = listViewResult.FocusedItem.ToolTipText;
                    }


                }
            }
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = listViewResult.FocusedItem.ToolTipText;
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openAsAdministratorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = listViewResult.FocusedItem.ToolTipText;
                proc.Verb = "runas";
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string argument = "/select, \"" + listViewResult.FocusedItem.ToolTipText + "\"";
                Process.Start("explorer.exe", argument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (sourceControl != comboBoxRun)
                    {
                        Button btt = (Button)sourceControl;
                        comboBoxRun.Text = btt.Text;
                    }

                }
            }

            BackgroundWorker tbw = new BackgroundWorker();
            tbw.DoWork += Tbw_DoWork;
            tbw.RunWorkerAsync(true);
            tbw.RunWorkerCompleted += Tbw_RunWorkerCompleted;
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowFileProperties(listViewResult.FocusedItem.ToolTipText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void buttonBackToParent_Click(object sender, EventArgs e)
        //{
        //    if (!comboBoxRun.Text.Contains("+") && comboBoxRun.Text.Contains("\\"))
        //    {
        //        string currentPath = comboBoxRun.Text;
        //        string parentPath = String.Empty;
        //        if (Path.GetExtension(currentPath) != null && Path.GetExtension(currentPath) != String.Empty)// if it's a file path
        //        {
        //            currentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //            parentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //        }
        //        else//it's a directory
        //        {
        //            if (currentPath.EndsWith("\\"))
        //                currentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //            parentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //        }
        //        comboBoxRun.Text = parentPath;
        //        searchDir(parentPath);
        //        ShowResult();
        //    }
        //}


        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }
        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;

      

        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }

    }
}
