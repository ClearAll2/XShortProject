using Microsoft.Win32;
using Shell32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace XShort
{

    public partial class MainForm : Form
    {
        private KeyboardHook hook = new KeyboardHook();
        private List<Shortcut> Shortcuts = new List<Shortcut>();
        private List<String> exclusion = new List<String>();
        private ObservableCollection<String> startup = new ObservableCollection<string>();
        private global::ModifierKeys gmk;
        private Keys k;
        private RunForm f2;
        private ProgressForm f3;
        private RegistryKey r;
        private string old_Name = String.Empty;
        private string old_Path = String.Empty;
        private string old_Para = String.Empty;
        private string yet = String.Empty;
        private string what = String.Empty;
        private string text = String.Empty;
        private string dataPath;
        private string pass = "asdewefcasdsafasfajldsjlsjakldjohfoiajskdlsakljncnalskjdlkjslka";
        private string lang = String.Empty;
        private bool exit = false;
        private bool edit = false;

        private bool ggs = false;
        private bool dontload = false;
        private bool suggestions = false;
        private bool showResult = false;
        private bool excludeResult = false;
        private bool useIndex = false;

        private bool detect = false;
        private bool hide = false;
        private bool cases = false;
        private bool start = false;
        private double interval = 24;
        private BackgroundWorker bw2;
        private int back;
        private int suggestNum = 4;//default = 4

        private ImageList img;
        private ImageList img2;

        public MainForm()
        {
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r == null)
                r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\Data");
            if (r.GetValue("Lang") != null)
            {
                lang = r.GetValue("Lang").ToString();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            else
            {
                r.SetValue("Lang", "en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
            r.Close();
            InitializeComponent();
            if (lang == "en")
                englishToolStripMenuItem.Checked = true;
            else
                vietnameseToolStripMenuItem.Checked = true;

            dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
            System.IO.Directory.CreateDirectory(dataPath);

            bw2 = new BackgroundWorker();
            bw2.DoWork += Bw2_DoWork;
            bw2.RunWorkerCompleted += Bw2_RunWorkerCompleted;

            img = new ImageList();
            img.ColorDepth = ColorDepth.Depth32Bit;

            img2 = new ImageList();
            img2.ColorDepth = ColorDepth.Depth32Bit;



            f3 = new ProgressForm();
            


            loadSettings();
            if (File.Exists(Path.Combine(Application.StartupPath, "XShortCoreIndex.exe")))
                Process.Start(Path.Combine(Application.StartupPath, "XShortCoreIndex.exe"), dataPath + " " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + " " + interval.ToString());

            for (int i = 0; i < listViewData.Columns.Count; i++)
                listViewData.Columns[i].Width = listViewData.Width / listViewData.Columns.Count;

        }

        private void Bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            f2 = new RunForm(Shortcuts);
            f2.ChangeSetting(ggs, cases, suggestions, showResult, excludeResult, suggestNum, useIndex);
        }

        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
            englishToolStripMenuItem.Checked = true;
            vietnameseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
        }

        private void vietnameseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("vi");
            englishToolStripMenuItem.Checked = false;
            vietnameseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
        }

        private static void ChangeLanguage2(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            foreach (Form frm in Application.OpenForms)
            {
                localizeForm(frm);
            }
        }

        private static void localizeForm(Form frm)
        {
            var manager = new ComponentResourceManager(frm.GetType());
            manager.ApplyResources(frm, "$this");
            applyResources(manager, frm.Controls);
        }

        private static void applyResources(ComponentResourceManager manager, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                manager.ApplyResources(ctl, ctl.Name);
                applyResources(manager, ctl.Controls);
            }
        }

        private void ChangeLanguage(string lang)
        {
            var rm = new ComponentResourceManager(this.GetType());
            var culture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            foreach (Control c in this.AllControls())
            {
                if (c is ToolStrip)
                {
                    var items = ((ToolStrip)c).AllItems().ToList();
                    foreach (var item in items)
                        rm.ApplyResources(item, item.Name);
                }
                rm.ApplyResources(c, c.Name);
            }
            if (!f2.IsDisposed && f2 != null)
            {
                f2.Close();
                f2 = new RunForm(Shortcuts);
                f2.ChangeSetting(ggs, cases, suggestions, showResult, excludeResult, suggestNum, useIndex);

            }
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void loadSettings()
        {
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r == null)
                r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\Data");

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));
            hook.Dispose();
            hook = new KeyboardHook();
            hook.KeyPressed +=
          new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(global::ModifierKeys.Control, Keys.Tab);
            //new register hook key
            if (r.GetValue("HKey") != null)
            {
                string hkey = (string)r.GetValue("HKey");
                k = (Keys)converter.ConvertFromString(hkey);

            }
            else
            {
                k = Keys.A;

            }
            if (r.GetValue("Alt") != null)
            {
                //radioButtonAlt.Checked = true;
                hook.RegisterHotKey(global::ModifierKeys.Alt, k);
                gmk = global::ModifierKeys.Alt;
            }
            else if (r.GetValue("Shift") != null)
            {
                //radioButtonShift.Checked = true;
                hook.RegisterHotKey(global::ModifierKeys.Shift, k);
                gmk = global::ModifierKeys.Shift;
            }
            else if (r.GetValue("Ctrl") != null)
            {
                //radioButtonControl.Checked = true;
                hook.RegisterHotKey(global::ModifierKeys.Control, k);
                gmk = global::ModifierKeys.Control;
            }
            else //default value
            {
                //radioButtonAlt.Checked = true;
                hook.RegisterHotKey(global::ModifierKeys.Alt, k);
                gmk = global::ModifierKeys.Alt;
            }
            //
            if (r.GetValue("Hide") != null)
                hide = true;
            else
                hide = false;
            if (r.GetValue("ggSearch") != null)
                ggs = true;
            else
                ggs = false;
            if (r.GetValue("Case-sen") != null)
            {
                cases = true;
            }
            else
                cases = false;
            if (r.GetValue("Tray") != null)
            {
                notifyIcon1.Visible = false;
            }
            else
                notifyIcon1.Visible = true;
            if (r.GetValue("Detect") != null)
            {
                detect = true;
            }
            else
                detect = false;

            //if (r.GetValue("DontLoad") != null)
            //{
            //    dontload = true;

            //    buttonSave.Enabled = false;
            //    buttonAddApp.Enabled = false;
            //    buttonAddDir.Enabled = false;
            //    buttonAddURL.Enabled = false;
            //    appToolStripMenuItem.Enabled = false;

            //}
            //else
            //{
            //    dontload = false;
            //    buttonSave.Enabled = true;
            //    buttonAddApp.Enabled = true;
            //    buttonAddDir.Enabled = true;
            //    buttonAddURL.Enabled = true;
            //    appToolStripMenuItem.Enabled = true;
            //}
            if (r.GetValue("Suggestions") != null)
                suggestions = true;
            else
                suggestions = false;

            if (r.GetValue("ShowResult") != null)
                showResult = true;
            else
                showResult = false;
            if (r.GetValue("ExcludeResult") != null)
                excludeResult = true;
            else
                excludeResult = false;

            if (r.GetValue("MaxSuggest") != null)
            {
                suggestNum = Int32.Parse((string)r.GetValue("MaxSuggest"));
            }
            if (r.GetValue("UseIndex") != null)
                useIndex = true;
            else
                useIndex = false;
            if (r.GetValue("Interval") != null)
                Double.TryParse((string)r.GetValue("Interval"), out interval);

            r.Close();
            r.Dispose();


            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (r.GetValue("XShort") != null)
            {
                if (r.GetValue("XShort").ToString().Equals(Application.ExecutablePath))
                {
                    start = true;
                }
                else
                    start = false;
            }
            r.Close();
            r.Dispose();

            LoadExclusion();
            if (f2 != null && f2.IsDisposed != true)
            {
                f2.LoadBlocklist();
                f2.ChangeSetting(ggs, cases, suggestions, showResult, excludeResult, suggestNum, useIndex);
            }
        }


        //load data
        private void Bw2_DoWork(object sender, DoWorkEventArgs e)
        {

            //load data files
            ProfileOptimization.StartProfile("Startup.Profile");
            if (File.Exists(Path.Combine(dataPath, "data1.data")) /*&& !dontload*/)
            {
                
                back = LoadData();
                
                if (back == -1)
                {
                    MessageBox.Show("Missing data to complete operation", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //load startup file
            if (File.Exists(Path.Combine(dataPath, "startup.txt")))
            {
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

                startup.CollectionChanged += Startup_CollectionChanged;

                //optimize from foreach
                for (int i = 0; i < startup.Count; i++)
                {
                    for (int j = 0; j < listViewData.Items.Count; j++)
                    {
                        if (startup[i] == listViewData.Items[j].SubItems[0].Text)
                        {
                            listViewData.Items[j].ForeColor = Color.SlateBlue;
                        }
                    }
                }
            }

            f3.Show();
            f3.Hide();
            loadIcon();


        }

        //detect change in startup file
        private void Startup_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            File.WriteAllText(Path.Combine(dataPath, "startup.txt"), string.Empty);
            FileStream fs1;
            StreamWriter sw1;
            fs1 = new FileStream(Path.Combine(dataPath, "startup.txt"), FileMode.Open, FileAccess.Write);
            sw1 = new StreamWriter(fs1);
            for (int i = 0; i < startup.Count; i++)
            {
                sw1.WriteLine(startup[i]);
            }
            sw1.Close();
            fs1.Close();
        }


        private void Run(string s)
        {
            for (int i = 0; i < Shortcuts.Count; i++)
            {
                if (s == Shortcuts[i].Name)
                {
                    if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                        Process.Start(Shortcuts[i].Path, Shortcuts[i].Para);
                    else
                        Process.Start(Shortcuts[i].Path);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            else if (m.Msg == NativeMethods.WM_NEWSETTINGS)
            {
                if (f2.IsDisposed != true && f2 != null)
                {
                    f2.Close();
                    f2 = new RunForm(Shortcuts);
                    f2.ChangeSetting(ggs, cases, suggestions, showResult, excludeResult, suggestNum, useIndex);
                }
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            this.TopMost = true;
            this.Show();
            WindowState = FormWindowState.Normal;
            this.TopMost = false;
        }

        //check for update
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //buttonC4U2.Enabled = false;
            WebClient wc = new WebClient();
            try
            {
                var tmp = wc.DownloadString("https://www.google.com.vn");
            }
            catch
            {
                wc.Dispose();
                return;
                //if (en)
                //    MessageBox.Show("Make sure you have a valid internet connection!", "Can not connect to server", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //else
                //    MessageBox.Show("Hãy đảm bảo bạn có kết nối internet!", "Không thể kết nối tới máy chủ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            string ver = "https://download-cas.000webhostapp.com/download/XShortCore/version";
            string chlog = "https://download-cas.000webhostapp.com/download/XShortCore/changelog";
            string sver = wc.DownloadString(ver);
            string schlog = wc.DownloadString(chlog);
            int isLatest = Application.ProductVersion.CompareTo(sver);
            if (isLatest < 0) //if current version is less than latest version
            {

                if (MessageBox.Show("You are running old version!\nWould you like to download new version?\nChangelog:\n" + schlog, "XShort Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //Process.Start("https://clearallsoft.cf/get/xshort_get");
                    Process.Start(Application.StartupPath + "\\XShort Updater.exe", Application.ExecutablePath);
                    yet = String.Empty;
                    exit = true;
                    exitToolStripMenuItem1_Click(null, null);
                }

            }
            wc.Dispose();
        }


        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Key == k)
            {
                if (!f3.Visible && !exclusion.Contains(GetForegroundProcessName()))
                {
                    SendKeys.Send(""); //do not remove this
                    runBoxToolStripMenuItem_Click(null, null);
                }
            }
            if (e.Key == Keys.Tab)
            {
                mainWindowToolStripMenuItem_Click(null, null);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            bw2.RunWorkerAsync();
            if (hide)
            {
                f3.Show();
                f3.Hide();
                BeginInvoke(new MethodInvoker(delegate { Hide(); }));

            }
            else
            {
                f3.Show();
            }

        }

        private void loadIcon()
        {
            listViewData.SmallImageList = img;
            img.ImageSize = new Size(25, 25);
            for (int i = 0; i < Shortcuts.Count; i++)
            {
                try
                {
                    img.Images.Add(Icon.ExtractAssociatedIcon(Shortcuts[i].Path));
                }
                catch
                {
                    if (Shortcuts[i].Path.Contains("http"))
                        img.Images.Add(Properties.Resources.internet);
                    else if (Shortcuts[i].Path.Contains("\\"))
                    {
                        if (checkValid(Shortcuts[i].Path) == 0)
                            img.Images.Add(Properties.Resources.dir);
                        else
                            img.Images.Add(Properties.Resources.error);
                    }
                    else
                    {
                        img.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }

                }
                listViewData.Items[i].ImageIndex = i;
                //

            }
            if (detect)
                autoCheckValid();

        }

        //auto detect invalid path
        private void autoCheckValid()
        {
            BackgroundWorker abw = new BackgroundWorker();
            abw.DoWork += Abw_DoWork;
            abw.RunWorkerAsync();

        }

        private void Abw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < listViewData.Items.Count; i++)
            {
                if (!Shortcuts[i].Path.Contains("http"))
                    if (checkValid(Shortcuts[i].Path) == -1)
                        changeColorListViewItem(Color.Red, i);


            }
        }

        private void changeColorListViewItem(Color cl, int i)
        {
            listViewData.Items[i].ForeColor = cl;
        }

        private int checkValid(string text)
        {
            if (File.Exists(text))
            {
                return 0;
            }
            else
            {
                if (Directory.Exists(text))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }

        private void LoadExclusion()
        {
            exclusion.Clear();

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
            }
            fs.Close();
            sr.Close();
        }

        //cipher data
        private int LoadData()
        {
            int i = 0;
            FileStream fs;
            StreamReader sr;
            f3.changeDisplay(1);
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
                Shortcut shortcut = new Shortcut
                {
                    Name = StringCipher.Decrypt(sr.ReadLine(), pass)
                };
                Shortcuts.Add(shortcut);
            }
            fs.Close();
            sr.Close();

            //
            f3.changeDisplay(2);
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
                Shortcuts[i].Path = StringCipher.Decrypt(sr.ReadLine(), pass);
                i++;
            }
            fs.Close();
            sr.Close();

            //
            f3.changeDisplay(3);
            i = 0;
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
                Shortcuts[i].Para = StringCipher.Decrypt(sr.ReadLine(), pass);
                i++;
            }
            fs.Close();
            sr.Close();


            listViewData.Items.Clear();
            for (int j = 0; j < Shortcuts.Count; j++)
            {
                listViewData.Items.Add(new ListViewItem(new string[] { Shortcuts[j].Name, Shortcuts[j].Path, Shortcuts[j].Para }));
            }
            return 1;
        }

        //private int LoadData2()
        //{
        //    int i = 0;
        //    FileStream fs;
        //    StreamReader sr;
        //    f3.changeDisplay(1);
        //    try
        //    {
        //        fs = new FileStream(Path.Combine(dataPath, "data1.data"), FileMode.Open, FileAccess.Read);
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //    sr = new StreamReader(fs);

        //    while (!sr.EndOfStream)
        //    {
        //        Shortcut shortcut = new Shortcut
        //        {
        //            Name = sr.ReadLine()
        //        };
        //        Shortcuts.Add(shortcut);
        //    }
        //    fs.Close();
        //    sr.Close();

        //    //
        //    f3.changeDisplay(2);
        //    try
        //    {
        //        fs = new FileStream(Path.Combine(dataPath, "data2.data"), FileMode.Open, FileAccess.Read);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //    sr = new StreamReader(fs);
        //    while (!sr.EndOfStream)
        //    {
        //        Shortcuts[i].Path = sr.ReadLine();
        //        i++;
        //    }
        //    fs.Close();
        //    sr.Close();

        //    //
        //    f3.changeDisplay(3);
        //    i = 0;
        //    try
        //    {
        //        fs = new FileStream(Path.Combine(dataPath, "data3.data"), FileMode.Open, FileAccess.Read);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //    sr = new StreamReader(fs);
        //    while (!sr.EndOfStream)
        //    {
        //        Shortcuts[i].Para = sr.ReadLine();
        //        i++;
        //    }
        //    fs.Close();
        //    sr.Close();


        //    listViewData.Items.Clear();
        //    for (int j = 0; j < Shortcuts.Count; j++)
        //    {
        //        listViewData.Items.Add(new ListViewItem(new string[] { Shortcuts[j].Name, Shortcuts[j].Path, Shortcuts[j].Para }));
        //    }
        //    return 1;
        //}


        private int ImportData(string path)
        {
            List<String> tName = new List<string>();
            List<String> tPath = new List<string>();
            List<String> tPara = new List<string>();
            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(path, "data1.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return 0;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                tName.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();

            //
            try
            {
                fs = new FileStream(Path.Combine(path, "data2.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return -1;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                tPath.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();

            //
            try
            {
                fs = new FileStream(Path.Combine(path, "data3.data"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return -1;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                tPara.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();

            for (int i = 0; i < tName.Count; i++)
            {
                listViewData.Items.Add(new ListViewItem(new string[] { tName[i], tPath[i], tPara[i] }));
            }
            edit = true;
            return 1;
        }

        //ok button of add/edit shortcuts
        private void button10_Click_1(object sender, EventArgs e)
        {
            //name
            if (textBoxName.Text != String.Empty)
            {
                if (textBoxName.Text.Contains("!") || textBoxName.Text.Contains("|") || textBoxName.Text.Contains(">"))
                {
                    MessageBox.Show("Your call name contains character \"! or | or >\"\nPlease rename!", "Special Character", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!edit)
                {
                    for (int i = 0; i < listViewData.Items.Count; i++)
                    {
                        if (listViewData.Items[i].SubItems[0].Text == textBoxName.Text)
                        {
                            if (MessageBox.Show("This name is already taken?!\nDo you want to rename? The program will open the first name appear in table", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                return;
                            }

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < listViewData.Items.Count; i++)
                    {
                        if (listViewData.Items[i].SubItems[0].Text == textBoxName.Text && listViewData.FocusedItem.Index != i)
                        {
                            if (MessageBox.Show("This name is already taken?!\nDo you want to rename? The program will open the first name appear in table", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    listViewData.FocusedItem.SubItems[0].Text = textBoxName.Text;
                    //check changes
                    if (textBoxName.Text != old_Name)
                    {
                        yet = "edit";
                    }
                }
            }
            else
            {
                MessageBox.Show("Your new name is empty?!", "New Name?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //path
            if (textBoxPath.Text == String.Empty)
            {
                MessageBox.Show("You new path is empty?!", "New Path?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (what != "url")
            {
                if (!edit)
                {
                    //para
                    if (textBoxPara.Text == String.Empty)
                    {
                        listViewData.Items.Add(new ListViewItem(new string[] { textBoxName.Text, textBoxPath.Text, "None" }));
                        yet = "app";

                    }
                    else
                    {
                        listViewData.Items.Add(new ListViewItem(new string[] { textBoxName.Text, textBoxPath.Text, textBoxPara.Text }));
                        yet = "dir";

                    }
                    panelEditShortcut.Hide();
                    listViewData.Enabled = true;
                    for (int i = 0; i < listViewData.Items.Count; i++)
                    {
                        if (listViewData.Items[i].SubItems[0].Text == textBoxName.Text)
                        {
                            listViewData.Focus();
                            listViewData.Items[i].Selected = true;
                            listViewData.EnsureVisible(i);

                            return;
                        }
                    }

                }
                else
                {
                    listViewData.FocusedItem.SubItems[1].Text = textBoxPath.Text;
                    if (what == "app")
                    {
                        if (textBoxPara.Text == String.Empty)
                        {

                            listViewData.FocusedItem.SubItems[2].Text = "None";
                        }
                        else
                        {
                            listViewData.FocusedItem.SubItems[2].Text = textBoxPara.Text;
                        }
                    }
                    else
                    {
                        listViewData.FocusedItem.SubItems[2].Text = textBoxPara.Text;
                    }
                    //check changes
                    if (textBoxPath.Text != old_Path || textBoxPara.Text != old_Para)
                    {
                        yet = "edit";
                    }

                }
            }
            else
            {
                if (!edit)
                {
                    yet = "url";
                    if (textBoxPath.Text.Contains("http://") || textBoxPath.Text.Contains("https://"))
                        listViewData.Items.Add(new ListViewItem(new string[] { textBoxName.Text, textBoxPath.Text, textBoxPara.Text }));
                    else
                        listViewData.Items.Add(new ListViewItem(new string[] { textBoxName.Text, "http://" + textBoxPath.Text, textBoxPara.Text }));
                    panelEditShortcut.Hide();
                    listViewData.Enabled = true;
                    for (int i = 0; i < listViewData.Items.Count; i++)
                    {
                        if (listViewData.Items[i].SubItems[0].Text == textBoxName.Text)
                        {
                            listViewData.Focus();
                            listViewData.Items[i].Selected = true;
                            listViewData.EnsureVisible(i);
                            return;
                        }
                    }

                }
                else
                {
                    if (textBoxPath.Text.Contains("http"))
                        listViewData.FocusedItem.SubItems[1].Text = textBoxPath.Text;
                    else
                        listViewData.FocusedItem.SubItems[1].Text = "http://" + textBoxPath.Text;
                    listViewData.FocusedItem.SubItems[2].Text = textBoxPara.Text;

                    //check changes
                    if (textBoxPath.Text != old_Path || textBoxPara.Text != old_Para)
                    {
                        yet = "edit";
                    }
                }
            }
            if (edit)
            {
                panelEditShortcut.Hide();
                listViewData.Enabled = true;
                edit = false;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panelEditShortcut.Hide();
            listViewData.Enabled = true;
            edit = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (what == "app")
            {
                OpenFileDialog of = new OpenFileDialog();
                of.CheckFileExists = true;
                of.CheckPathExists = true;
                of.Filter = "All file type (*.*)|*.*";
                of.Title = "Select your file...";

                of.Multiselect = false;
                if (of.ShowDialog() == DialogResult.OK)
                {
                    textBoxPath.Text = of.FileName;
                }

                of.Dispose();
            }
            else if (what == "dir")
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Select folder...";

                fb.RootFolder = Environment.SpecialFolder.Desktop;
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    textBoxPath.Text = fb.SelectedPath;
                }
                fb.Dispose();
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            edit = false;
            comboBox1.SelectedIndex = 0;
            panelEditShortcut.Show();
            listViewData.Enabled = false;
            textBoxName.Focus();
            textBoxName.Text = String.Empty;
            textBoxPath.Text = String.Empty;
            textBoxPara.Text = String.Empty;

        }

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            edit = false;
            comboBox1.SelectedIndex = 1;
            panelEditShortcut.Show();
            listViewData.Enabled = false;
            textBoxName.Focus();
            textBoxName.Text = String.Empty;
            textBoxPath.Text = String.Empty;


        }

        private void addURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = false;
            comboBox1.SelectedIndex = 2;
            panelEditShortcut.Show();
            listViewData.Enabled = false;
            textBoxName.Focus();
            textBoxName.Text = String.Empty;
            textBoxPath.Text = "https://";
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewData.FocusedItem != null)
            {
                listViewData.Items.Remove(listViewData.FocusedItem);
                yet = "rm";

            }
        }


        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewData.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip2.Show(Cursor.Position);
                    if (listViewData.FocusedItem.SubItems[2].Text == "Not Available")
                    {
                        openAsAdministratorToolStripMenuItem.Enabled = false;

                    }
                    else
                    {
                        openAsAdministratorToolStripMenuItem.Enabled = true;
                    }
                    if (listViewData.FocusedItem.SubItems[1].Text.Contains("http") || listViewData.FocusedItem.SubItems[1].Text.Contains("www"))
                    {
                        checkValidPathToolStripMenuItem.Enabled = false;
                        openFileLocationToolStripMenuItem1.Enabled = false;
                    }
                    else
                    {
                        checkValidPathToolStripMenuItem.Enabled = true;
                        openFileLocationToolStripMenuItem1.Enabled = true;

                    }
                    //startup with windows only active when cb1 is checked
                    if (start)
                    {
                        openAtWindowsStartupToolStripMenuItem.Enabled = true;
                        foreach (string s in startup)
                        {
                            if (listViewData.FocusedItem.SubItems[0].Text == s)
                            {
                                openAtWindowsStartupToolStripMenuItem.Checked = true;
                                return;
                            }
                            else
                            {
                                openAtWindowsStartupToolStripMenuItem.Checked = false;
                            }
                        }
                    }
                    else
                    {
                        openAtWindowsStartupToolStripMenuItem.Checked = false;
                        openAtWindowsStartupToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }


        private void saveShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (buttonSave.Enabled)
            {
                yet = String.Empty;
                f3.changeDisplay(4);
                f3.TopMost = false;
                f3.Show();



                //button11.Enabled = false;

                //button8.Enabled = false;
                //button7.Enabled = false;
                //panelSub.Enabled = false;
                panelData.Enabled = false;

                BackgroundWorker bwt = new BackgroundWorker();
                bwt.DoWork += Bwt_DoWork;
                bwt.RunWorkerAsync();
                bwt.RunWorkerCompleted += Bwt_RunWorkerCompleted;
            }

        }

        private void Bwt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            f2.ReloadSuggestions();
        }

        private void Bwt_DoWork(object sender, DoWorkEventArgs e)
        {
            Shortcuts.Clear();
            File.WriteAllText(Path.Combine(dataPath, "data1.data"), string.Empty);
            File.WriteAllText(Path.Combine(dataPath, "data2.data"), string.Empty);
            File.WriteAllText(Path.Combine(dataPath, "data3.data"), string.Empty);

            for (int i = 0; i < listViewData.Items.Count; i++)
            {
                Shortcut shortcut = new Shortcut
                {
                    Name = listViewData.Items[i].SubItems[0].Text,
                    Path = listViewData.Items[i].SubItems[1].Text,
                };
                if (listViewData.Items[i].SubItems[2].Text != String.Empty)
                    shortcut.Para = listViewData.Items[i].SubItems[2].Text;
                else
                    shortcut.Para = "None";
                Shortcuts.Add(shortcut);
                
            }

            listViewData.Items.Clear();
            for (int j = 0; j < Shortcuts.Count; j++)
            {
                listViewData.Items.Add(new ListViewItem(new string[] { Shortcuts[j].Name, Shortcuts[j].Path, Shortcuts[j].Para }));
                File.AppendAllText(Path.Combine(dataPath, "data1.data"), String.Join("", StringCipher.Encrypt(Shortcuts[j].Name, pass), Environment.NewLine));
                File.AppendAllText(Path.Combine(dataPath, "data2.data"), String.Join("", StringCipher.Encrypt(Shortcuts[j].Path, pass), Environment.NewLine));
                File.AppendAllText(Path.Combine(dataPath, "data3.data"), String.Join("", StringCipher.Encrypt(Shortcuts[j].Para, pass), Environment.NewLine));
                
            }

            if (detect)
                autoCheckValid();

            //reload startup shortcuts
            for (int i = 0; i < listViewData.Items.Count; i++)
            {
                for (int j = 0; j < startup.Count; j++)
                {
                    if (startup[j] == listViewData.Items[i].SubItems[0].Text)
                    {
                        listViewData.Items[i].ForeColor = Color.SlateBlue;
                    }
                }
            }



            if (f2 != null && !f2.IsDisposed)
            {
                f2.Close();
            }
            f2 = new RunForm(Shortcuts);
            f2.ChangeSetting(ggs, cases, suggestions, showResult, excludeResult, suggestNum, useIndex);
            img.Dispose();
            img = new ImageList();
            img.ColorDepth = ColorDepth.Depth32Bit;
            img.Images.Clear();
            loadIcon();

            f3.Hide();

            panelData.Enabled = true;

            if (exit == true)
            {
                exit = true;
                f3.closeForm();
                Application.Exit();
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            //notifyIcon1.ShowBalloonTip(1000, "XShort Core", "XShort Core is running in background\nPress " + gmk.ToString() + " + " + k.ToString() + " to open run box", ToolTipIcon.None);

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (yet != String.Empty)
            {
                bool done = false;
                if (yet == "rm")
                {
                    if (MessageBox.Show("You just remove shortcuts, you need to save the new list. Do you want to save before quiting?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null);
                        done = true;
                    }
                }
                else if (yet == "cl")
                {
                    if (MessageBox.Show("You just clone shortcuts, you need to save the new list. Do you want to save before quiting?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null); done = true;
                    }
                }
                else if (yet == "app")
                {
                    if (MessageBox.Show("You just add new app(s), you need to save the new list. Do you want to save before quiting?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null); done = true;
                    }
                }
                else if (yet == "dir")
                {
                    if (MessageBox.Show("You just add new directories, you need to save the new list. Do you want to save before quiting?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null); done = true;
                    }
                }
                else if (yet == "url")
                {
                    if (MessageBox.Show("You just add new url(s), you need to save the new list. Do you want to save before quiting?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null); done = true;
                    }
                }
                else if (yet == "edit")
                {
                    if (MessageBox.Show("You just edit shortcut(s), you need to save the new list. Do you want to save before quiting?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null); done = true;
                    }
                }
                else if (yet == "undo")
                {
                    if (MessageBox.Show("You just undo something, you need to save the new list. Do you want to save before quiting?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null); done = true;
                    }
                }
                if (done)
                {
                    exit = true;
                }
                else
                {
                    exit = true;
                    f3.closeForm();
                    Application.Exit();
                }

            }
            else
            {

                exit = true;
                f3.closeForm();
                Application.Exit();
            }
        }

        private void mainWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Show();
            this.TopMost = false;
            this.Select();
            buttonData_Click();
        }

        private void runBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f2 != null && f2.IsDisposed != true)
            {
                if (f2.Visible != true)
                {
                    f2.Show();
                    f2.WindowState = FormWindowState.Normal;
                    f2.Activate();
                }
                else
                {
                    f2.Hide();
                }
            }
            else
            {
                f2 = new RunForm(Shortcuts);
                f2.Show();
                f2.Activate();
            }
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            buttonSettings_Click(null, null);


        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            buttonAbout_Click(null, null);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                runBoxToolStripMenuItem_Click(null, null);
        }


        private int sortColumn = -1;
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listViewData.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listViewData.Sorting == SortOrder.Ascending)
                    listViewData.Sorting = SortOrder.Descending;
                else
                    listViewData.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listViewData.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            listViewData.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listViewData.Sorting);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit != true)
            {
                e.Cancel = true;
                minimizeToolStripMenuItem_Click(null, null);
                return;
            }
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (englishToolStripMenuItem.Checked)
                r.SetValue("Lang", "en");
            else
                r.SetValue("Lang", "vi");
            r.Close();

        }

        //https://stackoverflow.com/questions/97283/how-can-i-determine-the-name-of-the-currently-focused-process-in-c-sharp
        // The GetForegroundWindow function returns a handle to the foreground window
        // (the window  with which the user is currently working).
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        // The GetWindowThreadProcessId function retrieves the identifier of the thread
        // that created the specified window and, optionally, the identifier of the
        // process that created the window.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        // Returns the name of the process owning the foreground window.
        private string GetForegroundProcessName()
        {
            IntPtr hwnd = GetForegroundWindow();

            // The foreground window can be NULL in certain circumstances, 
            // such as when a window is losing activation.
            if (hwnd == null)
                return "Unknown";

            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);

            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id == pid)
                    return p.ProcessName;
            }

            return "Unknown";
        }


        private void checkValidPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewData.FocusedItem.SubItems[1].Text.Contains("\\"))
            {
                if (File.Exists(listViewData.FocusedItem.SubItems[1].Text))
                {
                    MessageBox.Show(listViewData.FocusedItem.SubItems[1].Text + " is a valid path.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Directory.Exists(listViewData.FocusedItem.SubItems[1].Text))
                    {
                        MessageBox.Show(listViewData.FocusedItem.SubItems[1].Text + " is a valid path.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show(listViewData.FocusedItem.SubItems[1].Text + " is an invalid path.\nDo you want to remove it from list now?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            listViewData.FocusedItem.Remove();
                        }
                    }
                }
            }

        }


        private void button7_Click(object sender, EventArgs e)
        {

            if (yet != String.Empty)
            {
                if (yet == "rm")
                {
                    if (MessageBox.Show("You just remove shortcuts, you need to save the new list. Do you want to save before hiding?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null);
                    }
                }
                else if (yet == "cl")
                {
                    if (MessageBox.Show("You just clone shortcuts, you need to save the new list. Do you want to save before hiding?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null);
                    }
                }
                else if (yet == "app")
                {
                    if (MessageBox.Show("You just add new app(s), you need to save the new list. Do you want to save before hiding?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null);
                    }
                }
                else if (yet == "dir")
                {
                    if (MessageBox.Show("You just add new directories, you need to save the new list. Do you want to save before hiding?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null);
                    }
                }
                else if (yet == "url")
                {
                    if (MessageBox.Show("You just add new url(s), you need to save the new list. Do you want to save before hiding?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null);
                    }
                }
                else if (yet == "edit")
                {
                    if (MessageBox.Show("You just edit shortcut(s), you need to save the new list. Do you want to save before hiding?", "What say you", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        saveShortcutsToolStripMenuItem_Click(null, null);
                    }
                }

            }
            Application.Exit();

        }

        private void buttonData_Click()
        {
            if (panelEditShortcut.Visible)
            {
                if (MessageBox.Show("You are editing something, you want to quit?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    panelEditShortcut.Hide();
                    listViewData.Enabled = true;
                }
                else
                    return;
            }
        }




        private void CreateShortcut(string name, string path, string para)
        {
            try
            {
                object shDesktop = "Desktop";
                IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + "\\" + name + ".lnk";
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Hotkey = "Ctrl+Shift+N";
                shortcut.Description = name;
                shortcut.TargetPath = path;
                shortcut.Arguments = para;
                shortcut.Save();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void createShortcutOnDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateShortcut(listViewData.FocusedItem.SubItems[0].Text, listViewData.FocusedItem.SubItems[1].Text, listViewData.FocusedItem.SubItems[2].Text);
        }


        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewData.Items.Add(new ListViewItem(new string[] { listViewData.FocusedItem.SubItems[0].Text + "_clone", listViewData.FocusedItem.SubItems[1].Text, listViewData.FocusedItem.SubItems[2].Text }));
            listViewData.Focus();
            listViewData.Items[listViewData.Items.Count - 1].Selected = true;
            listViewData.EnsureVisible(listViewData.Items.Count - 1);
            yet = "cl";
        }

        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                string targetPath = String.Empty;
                if (Path.GetExtension(docPath[0]) != null)
                {
                    if (Path.GetExtension(docPath[0]) == ".lnk" || Path.GetExtension(docPath[0]) == ".LNK")
                    {
                        targetPath = GetShortcutTargetFile(docPath[0]);
                        if (targetPath != String.Empty)
                        {
                            if (Path.GetExtension(targetPath) == String.Empty) //detect shortcut of dir or app
                            {
                                listViewData.Items.Add(new ListViewItem(new string[] { targetPath, targetPath, "Not Available" }));
                                listViewData.Focus();
                                listViewData.Items[listViewData.Items.Count - 1].Selected = true;
                                listViewData.EnsureVisible(listViewData.Items.Count - 1);
                                yet = "app";
                            }
                            else
                            {
                                listViewData.Items.Add(new ListViewItem(new string[] { targetPath, targetPath, "None" }));
                                listViewData.Focus();
                                listViewData.Items[listViewData.Items.Count - 1].Selected = true;
                                listViewData.EnsureVisible(listViewData.Items.Count - 1);
                                yet = "app";
                            }
                        }
                    }
                    else if (Path.GetExtension(docPath[0]) == String.Empty)
                    {
                        listViewData.Items.Add(new ListViewItem(new string[] { docPath[0], docPath[0], "Not Available" }));
                        listViewData.Focus();
                        listViewData.Items[listViewData.Items.Count - 1].Selected = true;
                        listViewData.EnsureVisible(listViewData.Items.Count - 1);
                        yet = "dir";

                    }
                    else
                    {
                        listViewData.Items.Add(new ListViewItem(new string[] { docPath[0].Substring(docPath[0].LastIndexOf("\\") + 1), docPath[0], "None" }));
                        listViewData.Focus();
                        listViewData.Items[listViewData.Items.Count - 1].Selected = true;
                        listViewData.EnsureVisible(listViewData.Items.Count - 1);
                        yet = "app";
                    }
                }

            }

        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Select folder of data you want to import";
            fb.RootFolder = Environment.SpecialFolder.Desktop;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                int ret = 0;
                ret = ImportData(fb.SelectedPath);

               
                if (ret == 0)
                {
                    MessageBox.Show("Fail to import data! Make sure you have a valid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ret == -1)
                {

                    MessageBox.Show("Fail to import data! Make sure you have a valid data!", "Error Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("Import data done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            fd.Description = "Select folder to export";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Path.Combine(dataPath, "data1.data")))
                    File.Copy(Path.Combine(dataPath, "data1.data"), Path.Combine(fd.SelectedPath, "data1.data"));
                if (File.Exists(Path.Combine(dataPath, "data2.data")))
                    File.Copy(Path.Combine(dataPath, "data2.data"), Path.Combine(fd.SelectedPath, "data2.data"));
                if (File.Exists(Path.Combine(dataPath, "data3.data")))
                    File.Copy(Path.Combine(dataPath, "data3.data"), Path.Combine(fd.SelectedPath, "data3.data"));

                MessageBox.Show("Export data done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if (f3.Visible)
            {
                f3.TopMost = true;
                f3.WindowState = FormWindowState.Normal;
                f3.TopMost = false;

            }
        }



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


        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = true;
            if (listViewData.FocusedItem.SubItems[2].Text == "Not Available")
            {
                if (listViewData.FocusedItem.SubItems[1].Text.Contains("http"))
                    comboBox1.SelectedIndex = 2;
                else
                    comboBox1.SelectedIndex = 1;
            }
            else
            {
                comboBox1.SelectedIndex = 0;
            }
            textBoxName.Text = listViewData.FocusedItem.SubItems[0].Text;
            textBoxPath.Text = listViewData.FocusedItem.SubItems[1].Text;
            textBoxPara.Text = listViewData.FocusedItem.SubItems[2].Text;

            //this for checking changes in edit
            old_Name = textBoxName.Text;
            old_Para = textBoxPara.Text;
            old_Path = textBoxPath.Text;

            listViewData.Enabled = false;
            panelEditShortcut.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                what = "app";
                button13.Enabled = true;
                textBoxPara.ReadOnly = false;
                textBoxPara.Text = String.Empty;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                what = "dir";
                button13.Enabled = true;
                textBoxPara.Text = "Not Available";
                textBoxPara.ReadOnly = true;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                what = "url";
                button13.Enabled = false;
                textBoxPara.Text = "Not Available";
                textBoxPara.ReadOnly = true;
                if (textBoxPath.Text == String.Empty)
                    textBoxPath.Text = "https://";
            }


        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                if (listViewData.FocusedItem.SubItems[2].Text != "None" && listViewData.FocusedItem.SubItems[2].Text != "Not Available")
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listViewData.FocusedItem.SubItems[1].Text;
                    proc.WorkingDirectory = Path.GetDirectoryName(proc.FileName);
                    proc.Arguments = listViewData.FocusedItem.SubItems[2].Text;
                    Process.Start(proc);
                }
                else
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listViewData.FocusedItem.SubItems[1].Text;
                    proc.WorkingDirectory = Path.GetDirectoryName(proc.FileName);
                    Process.Start(proc);
                }
            }
            catch
            {
                MessageBox.Show("Fail to start! Check if it is a valid path", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileProperties(listViewData.FocusedItem.SubItems[1].Text);
        }


        private void openAtWindowsStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openAtWindowsStartupToolStripMenuItem.Checked != true)
            {
                openAtWindowsStartupToolStripMenuItem.Checked = true;
                startup.Add(listViewData.FocusedItem.SubItems[0].Text);
                listViewData.FocusedItem.ForeColor = Color.SlateBlue;
            }
            else
            {
                openAtWindowsStartupToolStripMenuItem.Checked = false;
                startup.Remove(listViewData.FocusedItem.SubItems[0].Text);
                if (this.BackColor == Color.White)
                    listViewData.FocusedItem.ForeColor = Color.Black;
                else
                    listViewData.FocusedItem.ForeColor = Color.White;
            }
        }



        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            detailsToolStripMenuItem_Click(null, null);
        }


        private void openAsAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewData.FocusedItem.SubItems[2].Text != "None" && listViewData.FocusedItem.SubItems[2].Text != "Not Available")
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listViewData.FocusedItem.SubItems[1].Text;
                    proc.WorkingDirectory = Path.GetDirectoryName(proc.FileName);
                    proc.Arguments = listViewData.FocusedItem.SubItems[2].Text;
                    proc.Verb = "runas";
                    Process.Start(proc);
                }
                else
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listViewData.FocusedItem.SubItems[1].Text;
                    proc.WorkingDirectory = Path.GetDirectoryName(proc.FileName);
                    proc.Verb = "runas";
                    Process.Start(proc);
                }
            }
            catch
            {
                MessageBox.Show("Fail to start! Check if it is a valid path", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings stt = new Settings(Shortcuts);
            stt.FormClosed += Stt_FormClosed;
            stt.ShowDialog();
        }

        private void Stt_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadSettings();
            if (!dontload && listViewData.Items.Count == 0)
                buttonReload_Click(null, null);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.FormClosed += About_FormClosed;
            about.ShowDialog();
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            About a = (About)sender;
            if (a.exit)
            {
                exitToolStripMenuItem1_Click(null, null);
                Process.Start("update.bat");
            }
        }

        private void openFileLocationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string argument = "/select, \"" + listViewData.FocusedItem.SubItems[1].Text + "\"";
                Process.Start("explorer.exe", argument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!bw2.IsBusy)
            {
                f3.Show();
                Shortcuts.Clear();
                listViewData.Items.Clear();
                listViewData.Enabled = false;
                if (File.Exists(Path.Combine(dataPath, "data1.data")))
                {
                    LoadData();
                    loadIcon();
                }
                listViewData.Enabled = true;
                f3.Show();
                f3.Hide();
                //load startup file
                for (int i = 0; i < listViewData.Items.Count; i++)
                {
                    for (int j = 0; j < startup.Count; j++)
                    {
                        if (startup[j] == listViewData.Items[i].SubItems[0].Text)
                        {
                            listViewData.Items[i].ForeColor = Color.SlateBlue;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Something is not right!? Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewData.Columns.Count; i++)
                listViewData.Columns[i].Width = listViewData.Width / listViewData.Columns.Count;
        }

        private void openAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://clearallsoft.cf");
        }

     
    }

    //this class for sort listview
    class ListViewItemComparer : System.Collections.IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                    ((ListViewItem)y).SubItems[col].Text);
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }

    //this class for 1 instance
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");

        public static readonly int WM_NEWSETTINGS = RegisterWindowMessage("WM_NEWSETTINGS");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }

    //cipher data
    public static class StringCipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }

    //new panel
    public class ExtendedPanel : Panel
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        public ExtendedPanel()
        {
            SetStyle(ControlStyles.Opaque, true);
        }

        private int opacity = 50;
        [DefaultValue(50)]
        public int Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }
    }


    public static class ToolStripExtensions
    {
        public static IEnumerable<ToolStripItem> AllItems(this ToolStrip toolStrip)
        {
            return toolStrip.Items.Flatten();
        }
        public static IEnumerable<ToolStripItem> Flatten(this ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripDropDownItem)
                    foreach (ToolStripItem subitem in
                        ((ToolStripDropDownItem)item).DropDownItems.Flatten())
                        yield return subitem;
                yield return item;
            }
        }
    }

    public static class ControlExtensions
    {
        public static IEnumerable<Control> AllControls(this Control control)
        {
            foreach (Control c in control.Controls)
            {
                yield return c;
                foreach (Control child in c.Controls)
                    yield return child;
            }
        }
    }
}
