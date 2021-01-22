using Microsoft.Win32;
using Shell32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace XShort
{

    public partial class MainForm : Form
    {
        KeyboardHook hook = new KeyboardHook();
        List<String> sName = new List<String>();
        List<String> sPath = new List<String>();
        List<String> sPara = new List<String>();
        List<String> dir = new List<String>();
        ObservableCollection<String> startup = new ObservableCollection<string>();
        global::ModifierKeys gmk;
        Keys k;
        RunForm f2;
        ProgressForm f3;
        RegistryKey r;
        string old_Name = String.Empty;
        string old_Path = String.Empty;
        string old_Para = String.Empty;
        string yet = String.Empty;
        string what = String.Empty;
        string text = String.Empty;
        string dataPath;
        string pass = "asdewefcasdsafasfajldsjlsjakldjohfoiajskdlsakljncnalskjdlkjslka";
        bool exit = false;
        bool edit = false;
        
        bool ggs = false;
        bool dontload = false;

        bool detect = false;
        bool hide = false;
        bool cases = false;
        bool start = false;
        BackgroundWorker bw;
        BackgroundWorker bw2;
        int back;

        ImageList img;
        ImageList img2;

        public MainForm()
        {

            InitializeComponent();

            // label3.Visible = false;
            dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
            System.IO.Directory.CreateDirectory(dataPath);

            contextMenuStrip5.ImageList = imageList1;
            aboutToolStripMenuItem1.ImageIndex = 1;
            settingsToolStripMenuItem1.ImageIndex = 2;
            exportToolStripMenuItem1.ImageIndex = 13;
            importToolStripMenuItem1.ImageIndex = 12;
            reloadDataToolStripMenuItem.ImageIndex = 5;
            exitToolStripMenuItem2.ImageIndex = 6;


            bw = new BackgroundWorker();
            //bw.DoWork += Bw_DoWork;


            bw2 = new BackgroundWorker();
            bw2.DoWork += Bw2_DoWork;
            bw2.RunWorkerCompleted += Bw2_RunWorkerCompleted;

            img = new ImageList();
            img.ColorDepth = ColorDepth.Depth32Bit;

            img2 = new ImageList();
            img2.ColorDepth = ColorDepth.Depth32Bit;



            f3 = new ProgressForm(true);
            f2 = new RunForm(1);
           

            loadSettings();

            //BackgroundWorker bwu = new BackgroundWorker();
            //bwu.DoWork += Bwu_DoWork;
            //bwu.RunWorkerAsync();

            for (int i = 0; i < listView1.Columns.Count; i++)
                listView1.Columns[i].Width = listView1.Width / listView1.Columns.Count;

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
            
            if (r.GetValue("DontLoad") != null)
            {
                dontload = true;

                buttonSave.Enabled = false;
                buttonAddApp.Enabled = false;
                buttonAddDir.Enabled = false;
                buttonAddURL.Enabled = false;
                appToolStripMenuItem.Enabled = false;

            }
            else
            {
                dontload = false;
                buttonSave.Enabled = true;
                buttonAddApp.Enabled = true;
                buttonAddDir.Enabled = true;
                buttonAddURL.Enabled = true;
                appToolStripMenuItem.Enabled = true;
            }

           
            r.Close();
            r.Dispose();


            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (r.GetValue("XShort") != null)
            {
                if (r.GetValue("XShort").ToString().Contains(Application.ExecutablePath))
                {
                    start = true;
                }
                else
                    start = false;
            }
            r.Close();
            r.Dispose();

            if (f2 != null && f2.IsDisposed != true)
            {
                if (ggs)
                {
                    f2.changeGGSeach(true);
                }
                else
                {
                    f2.changeGGSeach(false);
                }
            }
            if (f2 != null && f2.IsDisposed != true)
            {
                if (cases)
                {
                    f2.changeSensitive(true);
                }
                else
                {
                    f2.changeSensitive(false);
                }
            }
        }

        private void Bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (File.Exists(dataPath + "\\data1.data"))
                bw.RunWorkerAsync();
            else
            {
                button2_Click_2(null, null);

            }
        }

        private string GetProductVersion(string s)
        {
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(s);
            return myFileVersionInfo.ProductVersion;
        }

        //update the updater
        private void Bwu_DoWork(object sender, DoWorkEventArgs e)
        {
            string ver = "https://download-cas.000webhostapp.com/download/updater.txt"; //version on the internet
            string curr_ver;
            if (checkValid(Application.StartupPath + "\\XShort Updater.exe") != -1)
                curr_ver = GetProductVersion(Application.StartupPath + "\\XShort Updater.exe"); //version of updater
            else
                curr_ver = "0.0.0.0";
            //MessageBox.Show(curr_ver);         
            WebClient wc = new WebClient();
            try
            {
                string sver = wc.DownloadString(ver);
                int isLatest = curr_ver.CompareTo(sver);
                if (isLatest < 0)
                {
                    wc.DownloadFile(new Uri("https://drive.google.com/uc?export=download&id=164dpM8f4uOTyWIaLvf8OIiZ-K8PS459l"), Application.StartupPath + "\\XShort Updater.exe");
                }

            }
            catch
            {
                wc.Dispose();
                //return;
            }
            wc.Dispose();
            
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }



        //load data
        private void Bw2_DoWork(object sender, DoWorkEventArgs e)
        {
            //load data files
            ProfileOptimization.StartProfile("Startup.Profile");
            if (File.Exists(Path.Combine(dataPath, "data1.data")) && !dontload)
            {
                try
                {
                    back = LoadData();
                }
                catch
                {
                    back = loadData();
                }
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
                    for (int j = 0; j < listView1.Items.Count; j++)
                    {
                        if (startup[i] == listView1.Items[j].SubItems[0].Text)
                        {
                            listView1.Items[j].ForeColor = Color.SlateBlue;
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
            for (int i = 0; i < sName.Count; i++)
            {
                if (s == sName[i])
                {
                    if (sPara[i] != "None" && sPara[i] != "Not Available")
                        Process.Start(sPath[i], sPara[i]);
                    else
                        Process.Start(sPath[i]);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
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
                if (!f3.Visible)
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
            listView1.SmallImageList = img;
            img.ImageSize = new Size(25, 25);
            for (int i = 0; i < sPath.Count; i++)
            {
                try
                {
                    img.Images.Add(Icon.ExtractAssociatedIcon(sPath[i]));
                }
                catch
                {
                    if (sPath[i].Contains("http"))
                        img.Images.Add(Properties.Resources.internet);
                    else if (sPath[i].Contains("\\"))
                    {
                        if (checkValid(sPath[i]) == 0)
                            img.Images.Add(Properties.Resources.dir);
                        else
                            img.Images.Add(Properties.Resources.error);
                    }
                    else
                    {
                        img.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }

                }
                listView1.Items[i].ImageIndex = i;
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
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (!sPath[i].Contains("http"))
                    if (checkValid(sPath[i]) == -1)
                        changeColorListViewItem(Color.Red, i);


            }
        }

        private void changeColorListViewItem(Color cl, int i)
        {
            listView1.Items[i].ForeColor = cl;
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

        //no cipher
        private int loadData()
        {
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

                sName.Add(sr.ReadLine());


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

                sPath.Add(sr.ReadLine());

            }
            fs.Close();
            sr.Close();

            //
            f3.changeDisplay(3);
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



            for (int j = 0; j < sName.Count; j++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { sName[j], sPath[j], sPara[j] }));

            }
            return 1;
        }
        //cipher data
        private int LoadData()
        {

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

                sName.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
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
                sPath.Add(StringCipher.Decrypt(sr.ReadLine(), pass));
            }
            fs.Close();
            sr.Close();

            //
            f3.changeDisplay(3);
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


            listView1.Items.Clear();
            for (int j = 0; j < sName.Count; j++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { sName[j], sPath[j], sPara[j] }));
            }
            return 1;
        }

        private int importData(string path)
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
                sName.Add(sr.ReadLine());
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
                sPath.Add(sr.ReadLine());
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
                sPara.Add(sr.ReadLine());
            }
            fs.Close();
            sr.Close();

            return 1;
        }

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
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[0].Text == textBoxName.Text)
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
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[0].Text == textBoxName.Text && listView1.FocusedItem.Index != i)
                        {
                            if (MessageBox.Show("This name is already taken?!\nDo you want to rename? The program will open the first name appear in table", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    listView1.FocusedItem.SubItems[0].Text = textBoxName.Text;
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
                        listView1.Items.Add(new ListViewItem(new string[] { textBoxName.Text, textBoxPath.Text, "None" }));
                        yet = "app";

                    }
                    else
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { textBoxName.Text, textBoxPath.Text, textBoxPara.Text }));
                        yet = "dir";

                    }
                    panel2.Hide();
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[0].Text == textBoxName.Text)
                        {
                            listView1.Focus();
                            listView1.Items[i].Selected = true;
                            listView1.EnsureVisible(i);

                            return;
                        }
                    }

                }
                else
                {
                    listView1.FocusedItem.SubItems[1].Text = textBoxPath.Text;
                    if (what == "app")
                    {
                        if (textBoxPara.Text == String.Empty)
                        {

                            listView1.FocusedItem.SubItems[2].Text = "None";
                        }
                        else
                        {
                            listView1.FocusedItem.SubItems[2].Text = textBoxPara.Text;
                        }
                    }
                    else
                    {
                        listView1.FocusedItem.SubItems[2].Text = textBoxPara.Text;
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
                        listView1.Items.Add(new ListViewItem(new string[] { textBoxName.Text, textBoxPath.Text, textBoxPara.Text }));
                    else
                        listView1.Items.Add(new ListViewItem(new string[] { textBoxName.Text, "http://" + textBoxPath.Text, textBoxPara.Text }));
                    panel2.Hide();
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[0].Text == textBoxName.Text)
                        {
                            listView1.Focus();
                            listView1.Items[i].Selected = true;
                            listView1.EnsureVisible(i);
                            return;
                        }
                    }

                }
                else
                {
                    if (textBoxPath.Text.Contains("http"))
                        listView1.FocusedItem.SubItems[1].Text = textBoxPath.Text;
                    else
                        listView1.FocusedItem.SubItems[1].Text = "http://" + textBoxPath.Text;
                    listView1.FocusedItem.SubItems[2].Text = textBoxPara.Text;

                    //check changes
                    if (textBoxPath.Text != old_Path || textBoxPara.Text != old_Para)
                    {
                        yet = "edit";
                    }
                }
            }
            if (edit)
            {
                panel2.Hide();
                edit = false;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.Hide();
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
            panel2.Show();
            textBoxName.Focus();
            textBoxName.Text = String.Empty;
            textBoxPath.Text = String.Empty;
            textBoxPara.Text = String.Empty;
            
        }

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            edit = false;
            comboBox1.SelectedIndex = 1;
            panel2.Show();
            textBoxName.Focus();
            textBoxName.Text = String.Empty;
            textBoxPath.Text = String.Empty;

            
        }

        private void addURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = false;
            comboBox1.SelectedIndex = 2;
            panel2.Show();
            textBoxName.Focus();
            textBoxName.Text = String.Empty;
            textBoxPath.Text = "http://";
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                listView1.Items.Remove(listView1.FocusedItem);
                yet = "rm";

            }
        }


        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip2.Show(Cursor.Position);
                    if (listView1.FocusedItem.SubItems[2].Text == "Not Available")
                    {
                        openAsAdministratorToolStripMenuItem.Enabled = false;

                    }
                    else
                    {
                        openAsAdministratorToolStripMenuItem.Enabled = true;
                    }
                    if (listView1.FocusedItem.SubItems[1].Text.Contains("http") || listView1.FocusedItem.SubItems[1].Text.Contains("www"))
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
                            if (listView1.FocusedItem.SubItems[0].Text == s)
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
            sName.Clear();
            sPath.Clear();
            sPara.Clear();
            File.WriteAllText(Path.Combine(dataPath, "data1.data"), string.Empty);
            File.WriteAllText(Path.Combine(dataPath, "data2.data"), string.Empty);
            File.WriteAllText(Path.Combine(dataPath, "data3.data"), string.Empty);

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sName.Add(listView1.Items[i].SubItems[0].Text);
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sPath.Add(listView1.Items[i].SubItems[1].Text);
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[2].Text != "")
                    sPara.Add(listView1.Items[i].SubItems[2].Text);
                else
                    sPara.Add("None");
            }
            FileStream fs = new FileStream(Path.Combine(dataPath, "data1.data"), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sw.WriteLine(StringCipher.Encrypt(sName[i], pass));
                //sName.Add(listView1.Items[i].SubItems[0].Text);
            }
            sw.Close();
            fs.Close();

            //

            FileStream fs1 = new FileStream(Path.Combine(dataPath, "data2.data"), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw1 = new StreamWriter(fs1);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sw1.WriteLine(StringCipher.Encrypt(sPath[i], pass));
                //sPath.Add(listView1.Items[i].SubItems[1].Text);
            }
            sw1.Close();
            fs1.Close();

            //
            FileStream fs2 = new FileStream(Path.Combine(dataPath, "data3.data"), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw2 = new StreamWriter(fs2);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sw2.WriteLine(StringCipher.Encrypt(sPara[i], pass));
                //sPath.Add(listView1.Items[i].SubItems[1].Text);
            }
            sw2.Close();
            fs2.Close();

            listView1.Items.Clear();
            for (int j = 0; j < sName.Count; j++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { sName[j], sPath[j], sPara[j] }));

            }

            if (detect)
                autoCheckValid();

            //reload startup shortcuts
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < startup.Count; j++)
                {
                    if (startup[j] == listView1.Items[i].SubItems[0].Text)
                    {
                        listView1.Items[i].ForeColor = Color.SlateBlue;
                    }
                }
            }



            if (f2 != null)
            {
                f2.LoadData();
                
            }
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
            notifyIcon1.ShowBalloonTip(1000, "XShort Core", "XShort Core is running in background\nPress " + gmk.ToString() + " + " + k.ToString() + " to open run box", ToolTipIcon.None);
           
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
               
                f2 = new RunForm(1);
                f2.Show();
                f2.Activate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://myfreedom.cf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
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
            WindowState = FormWindowState.Normal;
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
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView1.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listView1.Sorting);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit != true)
            {
                e.Cancel = true;
                minimizeToolStripMenuItem_Click(null, null);
                return;
            }


        }





        private void checkValidPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem.SubItems[1].Text.Contains("\\"))
            {
                if (File.Exists(listView1.FocusedItem.SubItems[1].Text))
                {
                    MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " is a valid path.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Directory.Exists(listView1.FocusedItem.SubItems[1].Text))
                    {
                        MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " is a valid path.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " is an invalid path.\nDo you want to remove it from list now?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            listView1.FocusedItem.Remove();
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
            if (panel2.Visible)
            {
                if (MessageBox.Show("You are editing something, you want to quit?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    panel2.Hide();
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
            CreateShortcut(listView1.FocusedItem.SubItems[0].Text, listView1.FocusedItem.SubItems[1].Text, listView1.FocusedItem.SubItems[2].Text);
        }


        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(new ListViewItem(new string[] { listView1.FocusedItem.SubItems[0].Text + "_clone", listView1.FocusedItem.SubItems[1].Text, listView1.FocusedItem.SubItems[2].Text }));
            listView1.Focus();
            listView1.Items[listView1.Items.Count - 1].Selected = true;
            listView1.EnsureVisible(listView1.Items.Count - 1);
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
                                listView1.Items.Add(new ListViewItem(new string[] { targetPath, targetPath, "Not Available" }));
                                listView1.Focus();
                                listView1.Items[listView1.Items.Count - 1].Selected = true;
                                listView1.EnsureVisible(listView1.Items.Count - 1);
                                yet = "app";
                            }
                            else
                            {
                                listView1.Items.Add(new ListViewItem(new string[] { targetPath, targetPath, "None" }));
                                listView1.Focus();
                                listView1.Items[listView1.Items.Count - 1].Selected = true;
                                listView1.EnsureVisible(listView1.Items.Count - 1);
                                yet = "app";
                            }
                        }
                    }
                    else if (Path.GetExtension(docPath[0]) == String.Empty)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { docPath[0], docPath[0], "Not Available" }));
                        listView1.Focus();
                        listView1.Items[listView1.Items.Count - 1].Selected = true;
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                        yet = "dir";
                        
                    }
                    else
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { docPath[0].Substring(docPath[0].LastIndexOf("\\") + 1), docPath[0], "None" }));
                        listView1.Focus();
                        listView1.Items[listView1.Items.Count - 1].Selected = true;
                        listView1.EnsureVisible(listView1.Items.Count - 1);
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
                try
                {
                    ret = ImportData(fb.SelectedPath);
                }
                catch
                {
                    ret = importData(fb.SelectedPath);
                }

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
                try
                {
                    File.WriteAllText(Path.Combine(fd.SelectedPath, "data1.data"), string.Empty);
                    File.WriteAllText(Path.Combine(fd.SelectedPath, "data2.data"), string.Empty);
                    File.WriteAllText(Path.Combine(fd.SelectedPath, "data3.data"), string.Empty);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Error");
                    
                    MessageBox.Show("Fail to export data!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;
                }

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sName.Add(listView1.Items[i].SubItems[0].Text);
                }
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sPath.Add(listView1.Items[i].SubItems[1].Text);
                }
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[2].Text != "")
                        sPara.Add(listView1.Items[i].SubItems[2].Text);
                    else
                        sPara.Add("None");
                }
                FileStream fs = new FileStream(Path.Combine(fd.SelectedPath, "data1.data"), FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sw.WriteLine(StringCipher.Encrypt(sName[i], pass));
                    //sName.Add(listView1.Items[i].SubItems[0].Text);
                }
                sw.Close();
                fs.Close();

                //

                FileStream fs1 = new FileStream(Path.Combine(fd.SelectedPath, "data2.data"), FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw1 = new StreamWriter(fs1);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sw1.WriteLine(StringCipher.Encrypt(sPath[i], pass));
                    //sPath.Add(listView1.Items[i].SubItems[1].Text);
                }
                sw1.Close();
                fs1.Close();

                //
                FileStream fs2 = new FileStream(Path.Combine(fd.SelectedPath, "data3.data"), FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw2 = new StreamWriter(fs2);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sw2.WriteLine(StringCipher.Encrypt(sPara[i], pass));
                    //sPath.Add(listView1.Items[i].SubItems[1].Text);
                }
                sw2.Close();
                fs2.Close();

               
                MessageBox.Show("Export data done!\n The data are 3 files: data1, data2, data3.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

       
        private void button2_Click_2(object sender, EventArgs e)
        {
           
            panel2.Show();


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
            if (listView1.FocusedItem.SubItems[2].Text == "Not Available")
            {
                if (listView1.FocusedItem.SubItems[1].Text.Contains("http"))
                    comboBox1.SelectedIndex = 2;
                else
                    comboBox1.SelectedIndex = 1;
            }
            else
            {
                comboBox1.SelectedIndex = 0;
            }
            textBoxName.Text = listView1.FocusedItem.SubItems[0].Text;
            textBoxPath.Text = listView1.FocusedItem.SubItems[1].Text;
            textBoxPara.Text = listView1.FocusedItem.SubItems[2].Text;

            //this for checking changes in edit
            old_Name = textBoxName.Text;
            old_Para = textBoxPara.Text;
            old_Path = textBoxPath.Text;

            panel2.Show();
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
                    textBoxPath.Text = "http://";
            }


        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                if (listView1.FocusedItem.SubItems[2].Text != "None" && listView1.FocusedItem.SubItems[2].Text != "Not Available")
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listView1.FocusedItem.SubItems[1].Text;
                    proc.WorkingDirectory = Path.GetDirectoryName(proc.FileName);
                    proc.Arguments = listView1.FocusedItem.SubItems[2].Text;
                    Process.Start(proc);
                }
                else
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listView1.FocusedItem.SubItems[1].Text;
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
            ShowFileProperties(listView1.FocusedItem.SubItems[1].Text);
        }


        private void openAtWindowsStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openAtWindowsStartupToolStripMenuItem.Checked != true)
            {
                openAtWindowsStartupToolStripMenuItem.Checked = true;
                startup.Add(listView1.FocusedItem.SubItems[0].Text);
                listView1.FocusedItem.ForeColor = Color.SlateBlue;
            }
            else
            {
                openAtWindowsStartupToolStripMenuItem.Checked = false;
                startup.Remove(listView1.FocusedItem.SubItems[0].Text);
                if (this.BackColor == Color.White)
                    listView1.FocusedItem.ForeColor = Color.Black;
                else
                    listView1.FocusedItem.ForeColor = Color.White;
            }
        }



        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openToolStripMenuItem1_Click(null, null);
        }


        private void openAsAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.FocusedItem.SubItems[2].Text != "None" && listView1.FocusedItem.SubItems[2].Text != "Not Available")
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listView1.FocusedItem.SubItems[1].Text;
                    proc.WorkingDirectory = Path.GetDirectoryName(proc.FileName);
                    proc.Arguments = listView1.FocusedItem.SubItems[2].Text;
                    proc.Verb = "runas";
                    Process.Start(proc);
                }
                else
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listView1.FocusedItem.SubItems[1].Text;
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
            Settings stt = new Settings();
            stt.FormClosed += Stt_FormClosed;
            stt.ShowDialog();
        }

        private void Stt_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadSettings();
            //if (!dontload)
            //{
            //    BackgroundWorker worker = new BackgroundWorker();
            //    worker.DoWork += Worker_DoWork;
            //    worker.RunWorkerAsync();
            //}
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void buttonBuildIndex_Click(object sender, EventArgs e)
        {
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip5.Show(ptLowerLeft);
        }


        private void openFileLocationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string argument = "/select, \"" + listView1.FocusedItem.SubItems[1].Text + "\"";
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
                sName.Clear();
                sPara.Clear();
                sPath.Clear();
                listView1.Items.Clear();
                listView1.Enabled = false;
                if (File.Exists(Path.Combine(dataPath, "data1.data")))
                {
                    try
                    {
                        back = LoadData();
                    }
                    catch
                    {
                        back = loadData();
                    }
                    if (back == -1)
                    {
                       
                        MessageBox.Show("Missing data to complete operation", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                listView1.Enabled = true;
                f3.Show();
                f3.Hide();
                loadIcon();

                //load startup file
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    for (int j = 0; j < startup.Count; j++)
                    {
                        if (startup[j] == listView1.Items[i].SubItems[0].Text)
                        {
                            listView1.Items[i].ForeColor = Color.SlateBlue;
                        }
                    }
                }



                buttonSave.Enabled = true;
                buttonAddApp.Enabled = true;
                buttonAddDir.Enabled = true;
                buttonAddURL.Enabled = true;
                appToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Something is not right!? Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Columns.Count; i++)
                listView1.Columns[i].Width = listView1.Width / listView1.Columns.Count;
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

    //slide effect
    public static class Util
    {
        public enum Effect { Roll, Slide, Center, Blend }

        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {
            int flags = effmap[(int)effect];
            if (ctl.Visible) { flags |= 0x10000; angle += 180; }
            else
            {
                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();
            }
            flags |= dirmap[(angle % 360) / 45];
            bool ok = AnimateWindow(ctl.Handle, msec, flags);
            if (!ok) throw new Exception("Animation failed");
            ctl.Visible = !ctl.Visible;
        }

        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
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

}
