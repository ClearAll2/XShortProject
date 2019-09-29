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
using System.Threading;
using System.Windows.Forms;

namespace XShort
{

    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();
        List<String> sName = new List<String>();
        List<String> sPath = new List<String>();
        List<String> sPara = new List<String>();
        List<String> dir = new List<String>();
        //List<String> sea = new List<String>();
        ObservableCollection<String> history = new ObservableCollection<string>();
        ObservableCollection<String> startup = new ObservableCollection<string>();
        global::ModifierKeys gmk;
        Keys k;
        Form2 f2;
        Form3 f3;
        RegistryKey r;
        string old_Name = String.Empty;
        string old_Path = String.Empty;
        string old_Para = String.Empty;
        string yet = String.Empty;
        string what = String.Empty;
        string text = String.Empty;
        string dataPath;
        string pass = "asdewefcasdsafasfajldsjlsjakldjohfoiajskdlsakljncnalskjdlkjslka";
        bool en = true;
        bool exit = false;
        bool edit = false;
        bool beta = false;
        bool ggs = false;
        bool indexing = false;
        bool dontload = false;

        bool detect = false;
        bool hide = false;
        bool cases = false;
        bool start = false;
        bool dal = false;
        BackgroundWorker bw;
        BackgroundWorker bw2;
        int newx, newy;
        int back;

        ImageList img;
        ImageList img2;

        PerformanceCounter DiskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        PerformanceCounter CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");


        public Form1()
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
            scanToolStripMenuItem.ImageIndex = 15;
            logToolStripMenuItem1.ImageIndex = 16;
            buildIndexToolStripMenuItem.ImageIndex = 17;
            reloadDataToolStripMenuItem.ImageIndex = 5;
            exitToolStripMenuItem2.ImageIndex = 6;


            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;


            bw2 = new BackgroundWorker();
            bw2.DoWork += Bw2_DoWork;
            bw2.RunWorkerCompleted += Bw2_RunWorkerCompleted;

            img = new ImageList();
            img.ColorDepth = ColorDepth.Depth32Bit;

            img2 = new ImageList();
            img2.ColorDepth = ColorDepth.Depth32Bit;



            f3 = new Form3(en);

            if (en == true)
                f2 = new Form2(1);
            else
                f2 = new Form2(0);

            loadSettings();

            BackgroundWorker bwu = new BackgroundWorker();
            bwu.DoWork += Bwu_DoWork;
            bwu.RunWorkerAsync();

            for (int i = 0; i < listView1.Columns.Count; i++)
                listView1.Columns[i].Width = listView1.Width / listView1.Columns.Count;
            for (int i = 0; i < listView2.Columns.Count; i++)
                listView2.Columns[i].Width = listView2.Width / listView2.Columns.Count;

            this.Text += " Beta Test - build " + this.AssemblyDescription;
            buttonData_Click();


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

        private void AutoIndexService_DoWork(object sender, DoWorkEventArgs e)
        {
            int percent = 0;
            if (File.Exists(dataPath + "\\temp.txt"))
            {
                if (File.GetLastWriteTime(dataPath + "\\temp.txt").Date == DateTime.Now.Date)
                {
                    labelAutoIndex.Text = "Completed";
                    return;
                }
            }
            while (indexing != true)
            {
                Thread.Sleep(1000);
                if (exit)
                    return;
            }
            File.WriteAllText(dataPath + "\\temp1", String.Empty);
            File.WriteAllText(dataPath + "\\temp2", String.Empty);
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                fileSmartSearch(d.Name);
                folderSmartSearch(d.Name);
                if (exit)
                    return;

            }
            while (IsFileLocked(new FileInfo(dataPath + "\\indexFol"))) ;
            File.Replace(dataPath + "\\temp1", dataPath + "\\indexFol", null);
            while (IsFileLocked(new FileInfo(dataPath + "\\indexFil"))) ;
            File.Replace(dataPath + "\\temp2", dataPath + "\\indexFil", null);

            File.WriteAllText(dataPath + "\\temp.txt", String.Empty);
            labelAutoIndex.Text = "Completed";

            //goto begin;
        }

        void folderSmartSearch(string dir)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                DirectoryInfo[] dir1 = di.GetDirectories("*" + "*.*");
                string alldir = String.Empty;
                for (int i = 0; i < dir1.Count(); i++)
                {
                    alldir += dir1[i].FullName + Environment.NewLine;

                }
                File.AppendAllText(dataPath + "\\temp1", alldir);

                DirectoryInfo[] dirs = di.GetDirectories();
                if (dirs == null || dirs.Length < 1)
                    return;
                foreach (DirectoryInfo sdir in dirs)
                {
                    folderSmartSearch(sdir.FullName);
                    while (!indexing)
                    {
                        labelAutoIndex.Text = "Off";
                        Thread.Sleep(1000);
                        if (exit)
                            return;
                    }
                    
                    while (true)
                    {
                        float disk = DiskCounter.NextValue();
                        float cpu = CpuCounter.NextValue();
                        if (GetIdleTime() > 10000)
                        {
                            if (cpu > 50 || disk >= 100)
                            {
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                break;
                            }
                            if (exit)
                                return;
                          
                            Thread.Sleep(0);
                        }
                        else
                        {
                            if (cpu > 25 || disk >= 50)
                            {
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                break;
                            }
                            if (exit)
                                return;
                            Thread.Sleep(200);
                        }
                    }
                    labelAutoIndex.Text = sdir.FullName;
                }
            }
            catch
            {
                return;
            }
        }

        void fileSmartSearch(string dir)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                FileInfo[] files = di.GetFiles("*" + "*.*");
                string allfiles = String.Empty;
                for (int i = 0; i < files.Count(); i++)
                {
                    
                    allfiles += files[i].FullName + Environment.NewLine;
                }
                File.AppendAllText(dataPath + "\\temp2", allfiles);
                //Scan recursively
                DirectoryInfo[] dirs = di.GetDirectories();
                if (dirs == null || dirs.Length < 1)
                    return;
                foreach (DirectoryInfo sdir in dirs)
                {
                    fileSmartSearch(sdir.FullName);
                    while (!indexing)
                    {
                        labelAutoIndex.Text = "Off";
                        Thread.Sleep(1000);
                        if (exit)
                            return;
                    }

                    while (true)
                    {
                        float disk = DiskCounter.NextValue();
                        float cpu = CpuCounter.NextValue();
                        if (GetIdleTime() > 10000)
                        {
                            if (cpu > 50 || disk >= 100)
                            {
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                break;
                            }
                            if (exit)
                                return;

                            Thread.Sleep(0);
                        }
                        else
                        {
                            if (cpu > 25 || disk >= 50)
                            {
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                break;
                            }
                            if (exit)
                                return;
                            Thread.Sleep(200);
                        }
                    }
                    labelAutoIndex.Text = sdir.FullName;
                }
            }
            catch
            {
                return;
            }
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
            if (r.GetValue("Indexing") != null)
            {
                indexing = true;
                //labelAutoIndex.Text = "Running";
            }
            else
            {
                indexing = false;
                labelAutoIndex.Text = "Off";
            }
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

            if (r.GetValue("Beta") != null)
            {
                beta = true;

            }
            else
                beta = false;

            dal = false;
            if (r.GetValue("Dark") != null)
            {
                ///radioButton3.Checked = true;

                changeSkin(true);
            }
            else if (r.GetValue("Light") != null)
            {
                changeSkin(false);
            }
            else if (r.GetValue("DaL") != null)
            {
                dal = true;
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


            //never put this to top, must create form before check language!
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);

            if (r.GetValue("EN") != null)
            {
                en = true;
                changeLanguages();
            }
            else
            {
                en = false;
                changeLanguages();
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
                comboBox3.SelectedIndex = 2;
                buttonScan_Click(null, null);

            }


            BackgroundWorker autoIndexService = new BackgroundWorker();
            autoIndexService.DoWork += AutoIndexService_DoWork;
            autoIndexService.RunWorkerAsync();

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
            while (true)
            {
                if (dal)
                {
                    if (DateTime.Now.Hour >= 18 || DateTime.Now.Hour <= 6)
                    {
                        if (this.BackColor == Color.White)
                            changeSkin(true);
                        //make sure for form 2
                        if (f2 != null && f2.IsDisposed != true)
                        {
                            if (f2.BackColor == Color.White)
                                f2.changeSkin(true);
                        }
                    }
                    else
                    {
                        if (this.BackColor != Color.White)
                            changeSkin(false);
                        if (f2 != null && f2.IsDisposed != true)
                        {
                            if (f2.BackColor != Color.White)
                                f2.changeSkin(false);
                        }
                    }
                }
                Thread.Sleep(1000);
            }
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

        //download beta test
        private void Bw3_DoWork(object sender, DoWorkEventArgs e)
        {
            string latest_build = this.AssemblyDescription;
            string ver = "https://download-cas.000webhostapp.com/download/beta.txt";
            WebClient wc = new WebClient();
            try
            {
                string sver = wc.DownloadString(ver);
                int isLatest = latest_build.CompareTo(sver);
                if (isLatest < 0) //if current of build is less than latest build
                {
                    if (en)
                    {
                        if (MessageBox.Show("New build " + sver + " is available. Would you like to download now? ", "Beta Test Program", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //Process.Start("https://clearallsoft.cf/get/xshort_beta_get");
                            Process.Start(Application.StartupPath + "\\XShort Updater.exe", Application.ExecutablePath);
                            exitToolStripMenuItem1_Click(null, null);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Bản thử mới " + sver + " đã có. Bạn có muốn tải ngay không?", "Beta Test Program", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //Process.Start("https://clearallsoft.cf/get/xshort_beta_get");
                            Process.Start(Application.StartupPath + "\\XShort Updater.exe", Application.ExecutablePath);
                            exitToolStripMenuItem1_Click(null, null);
                        }
                    }
                }
            }
            catch (Exception)
            {
                wc.Dispose();
                return;

            }
            wc.Dispose();
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
                    if (en == true)
                        MessageBox.Show("Missing data to complete operation", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show("Thiếu dữ liệu - không thể hoàn thành", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //load log file
            if (File.Exists(Path.Combine(dataPath, "log.txt")))
            {
                FileStream fs;
                StreamReader sr;

                fs = new FileStream(Path.Combine(dataPath, "log.txt"), FileMode.Open, FileAccess.Read);

                sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    history.Add(sr.ReadLine());
                }
                sr.Close();
                fs.Close();
                sr.Dispose();
                fs.Dispose();

                history.CollectionChanged += History_CollectionChanged;

                if (history.Count > 0)
                {
                    if (history[history.Count - 1].Contains("remove") || history[history.Count - 1].Contains("add") || history[history.Count - 1].Contains("import") || history[history.Count - 1].Contains("edit"))
                    {
                        history.Add("[NOTE - DO YOU KNOW?] You didn't save the last time before shutting down the computer");
                    }
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
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    for (int j = 0; j < startup.Count; j++)
                    {
                        if (startup[j] == listView1.Items[i].SubItems[0].Text)
                        {
                            listView1.Items[i].ForeColor = Color.SlateBlue;
                            if (Program.FileName == "startup")//manual open -> no FileName
                            {
                                Run(startup[j]);
                            }
                        }
                    }
                }

            }

            //beta test program
            //if (button3.BackColor == Color.Red)
            //{
            //    BackgroundWorker bw3 = new BackgroundWorker();
            //    bw3.DoWork += Bw3_DoWork;
            //    bw3.RunWorkerAsync();
            //}

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

        //detect change in log file
        private void History_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            FileStream fs;
            StreamWriter sw;
            fs = new FileStream(Path.Combine(dataPath, "log.txt"), FileMode.OpenOrCreate, FileAccess.Write);
            sw = new StreamWriter(fs);
            for (int i = 0; i < history.Count; i++)
            {
                sw.WriteLine(history[i]);
            }
            sw.Close();
            fs.Close();
        }

        private void Run(string s)
        {
            for (int i = 0; i < sName.Count; i++)
            {
                if (s == sName[i])
                {
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
            string ver = "https://drive.google.com/uc?export=download&id=1enOPUAXdYCq6MZNnMJuZ0yqt4eVaJBzr";
            string chlog = "https://drive.google.com/uc?export=download&id=1m8EWUOGwoWY8jTL3BSIYIzLV12A6ruXr";
            string sver = wc.DownloadString(ver);
            string schlog = wc.DownloadString(chlog);
            int isLatest = Application.ProductVersion.CompareTo(sver);
            if (isLatest < 0) //if current version is less than latest version
            {
                if (en)
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
                else
                {
                    if (MessageBox.Show("Bạn đang chạy phiên bản cũ!\nBạn có muốn tải phiên bản mới?\nChangelog:\n" + schlog, "XShort Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //Process.Start("https://clearallsoft.cf/get/xshort_get");
                        Process.Start(Application.StartupPath + "\\XShort Updater.exe", Application.ExecutablePath);
                        yet = String.Empty;
                        exit = true;
                        exitToolStripMenuItem1_Click(null, null);
                    }
                }
            }
            else
            {
                if (!beta)
                {
                    wc.Dispose();
                    return;
                }
                else
                {
                    BackgroundWorker bw3 = new BackgroundWorker();
                    bw3.DoWork += Bw3_DoWork;
                    bw3.RunWorkerAsync();
                }
            }
            wc.Dispose();

            // buttonC4U2.Enabled = true;




        }


        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Key == k)
            {
                SendKeys.Send(""); //do not remove this
                runBoxToolStripMenuItem_Click(null, null);
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


            for (int j = 0; j < tName.Count; j++)
            {
                if (tName[j].Contains("!") || tName[j].Contains(","))
                {
                    listView1.Items.Add(new ListViewItem(new string[] { "Please rename this!", tPath[j], tPara[j] }));
                    history.Add("[" + DateTime.Now + "] " + "You import an item name " + tName[j] + "_need_to_rename" + ", path: " + tPath[j] + ", para: " + tPara[j]);
                }
                else
                {
                    listView1.Items.Add(new ListViewItem(new string[] { tName[j], tPath[j], tPara[j] }));
                    history.Add("[" + DateTime.Now + "] " + "You import an item name " + tName[j] + ", path: " + tPath[j] + ", para: " + tPara[j]);
                }
            }
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


            for (int j = 0; j < tName.Count; j++)
            {
                if (tName[j].Contains("!") || tName[j].Contains(","))
                {
                    listView1.Items.Add(new ListViewItem(new string[] { "Please rename this!", tPath[j], tPara[j] }));
                    history.Add("[" + DateTime.Now + "] " + "You import an item name " + tName[j] + "_need_to_rename" + ", path: " + tPath[j] + ", para: " + tPara[j]);
                }
                else
                {
                    listView1.Items.Add(new ListViewItem(new string[] { tName[j], tPath[j], tPara[j] }));
                    history.Add("[" + DateTime.Now + "] " + "You import an item name " + tName[j] + ", path: " + tPath[j] + ", para: " + tPara[j]);
                }
            }

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
                    if (en)
                    {
                        MessageBox.Show("Your call name contains character \"! or | or >\"\nPlease rename!", "Special Character", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Tên bạn đặt có chứa kí tự \"! hoặc | hoặc >\"\nHãy đổi lại!", "Kí tự đắc biệt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (!edit)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[0].Text == textBoxName.Text)
                        {
                            if (en == true)
                            {
                                if (MessageBox.Show("This name is already taken?!\nDo you want to rename? The program will open the first name appear in table", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("Tên này đã có trong bảng?!\nBạn có muốn đổi tên? Chương trình sẽ mở tên đầu tiên xuất hiện trong bảng", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    return;
                                }
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
                            if (en == true)
                            {
                                if (MessageBox.Show("This name is already taken?!\nDo you want to rename? The program will open the first name appear in table", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("Tên này đã có trong bảng?!\nBạn có muốn đổi tên? Chương trình sẽ mở tên đầu tiên xuất hiện trong bảng", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    listView1.FocusedItem.SubItems[0].Text = textBoxName.Text;
                    //check changes
                    if (textBoxName.Text != old_Name)
                    {
                        history.Add("[" + DateTime.Now + "]" + " You edit name of " + old_Name + " to " + textBoxName.Text);
                        yet = "edit";
                    }
                }
            }
            else
            {
                if (en == true)
                    MessageBox.Show("Your new name is empty?!", "New Name?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Tên mới để trống!?", "Tên mới?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //path
            if (textBoxPath.Text == String.Empty)
            {
                if (en == true)
                    MessageBox.Show("You new path is empty?!", "New Path?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Đường dẫn mới còn trống?!", "Đường dẫn mới?", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    history.Add("[" + DateTime.Now + "] " + "You add an item name " + textBoxName.Text + ", path: " + textBoxPath.Text + ", para: " + textBoxPara.Text);
                    panel2.Hide();
                    panel1.Hide();
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
                        history.Add("[" + DateTime.Now + "]" + " You edit path of " + old_Path + " to " + textBoxPath.Text);
                        history.Add("[" + DateTime.Now + "]" + " You edit para of " + old_Para + " to " + textBoxPara.Text);
                        yet = "edit";
                    }

                }
            }
            else
            {
                if (!edit)
                {
                    yet = "url";
                    history.Add("[" + DateTime.Now + "] " + "You add an item name " + textBoxName.Text + ", path: " + textBoxPath.Text + ", para: " + textBoxPara.Text);
                    if (textBoxPath.Text.Contains("http://") || textBoxPath.Text.Contains("https://"))
                        listView1.Items.Add(new ListViewItem(new string[] { textBoxName.Text, textBoxPath.Text, textBoxPara.Text }));
                    else
                        listView1.Items.Add(new ListViewItem(new string[] { textBoxName.Text, "http://" + textBoxPath.Text, textBoxPara.Text }));
                    panel2.Hide();
                    panel1.Hide();
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
                        history.Add("[" + DateTime.Now + "]" + " You edit path of " + old_Path + " to " + textBoxPath.Text);
                        history.Add("[" + DateTime.Now + "]" + " You edit para of " + old_Para + " to " + textBoxPara.Text);
                        yet = "edit";
                    }
                }
            }
            if (edit)
            {
                panel2.Hide();
                panel1.Hide();
                edit = false;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Hide();
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
                if (en == true)
                    of.Title = "Select your file...";
                else
                    of.Title = "Chọn fle...";
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
                if (en == true)
                    fb.Description = "Select folder...";
                else
                    fb.Description = "Chọn thư mục...";
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
            if (panel1.Visible != true)
            {
                edit = false;
                comboBox1.SelectedIndex = 0;
                panel1.Show();
                panel2.Show();
                textBoxName.Focus();
                textBoxName.Text = String.Empty;
                textBoxPath.Text = String.Empty;
                textBoxPara.Text = String.Empty;
            }
        }

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (/*panelSetting.Visible != true && */panel1.Visible != true)
            {
                edit = false;
                comboBox1.SelectedIndex = 1;
                panel1.Show();
                panel2.Show();
                textBoxName.Focus();
                textBoxName.Text = String.Empty;
                textBoxPath.Text = String.Empty;

            }
        }

        private void addURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible != true)
            {
                edit = false;
                comboBox1.SelectedIndex = 2;
                panel1.Show();
                panel2.Show();
                textBoxName.Focus();
                textBoxName.Text = String.Empty;
                textBoxPath.Text = "http://";
            }

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                history.Add("[" + DateTime.Now + "] " + "You remove an item name " + listView1.FocusedItem.SubItems[0].Text + ", path: " + listView1.FocusedItem.SubItems[1].Text + ", para: " + listView1.FocusedItem.SubItems[2].Text);
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


        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();

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
                history.Add("[" + DateTime.Now + "] " + "You save the new list");
            }
            
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



            // button11.Enabled = true;
            //button8.Enabled = true;
            //button7.Enabled = true;
            //panelSub.Enabled = true;
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
            if (en == true)
                notifyIcon1.ShowBalloonTip(1000, "XShort", "XShort is running in background\nPress " + gmk.ToString() + " + " + k.ToString() + " to open run box", ToolTipIcon.Info);
            else
                notifyIcon1.ShowBalloonTip(1000, "XShort", "XShort đang chạy ẩn\nNhấn " + gmk.ToString() + " + " + k.ToString() + " để mở hộp thoại run", ToolTipIcon.Info);
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
                    history.Add("[" + DateTime.Now + "] " + "You do not save the new list");
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
            this.Show();
            WindowState = FormWindowState.Normal;
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
                if (en == true)
                    f2 = new Form2(1);
                else
                    f2 = new Form2(0);
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



        private void changeLanguages()
        {
            f3.changeLanguge(en);
            if (en == false)
            {
                if (f2 != null && f2.IsDisposed != true)
                {
                    f2.changeLanguages(0);
                }

             
              
                buttonScan.Text = "Quét";
                button2.Text = "Hủy";
                button9.Text = "Thêm";

                //label5.Text = "Tên mở rộng:";
                comboBox3.Items[0] = "Tên mở rộng";
                comboBox3.Items[1] = "Tên tập tin";
                comboBox3.Items[2] = "Chương trình";
                label6.Text = "Thư mục quét:";
                label7.Text = "(exe, mp3,..., * cho tất cả)";

                buttonAddApp.Text = "Thêm App/File";
                buttonAddDir.Text = "Thêm đường dẫn";
                buttonAddURL.Text = "Thêm địa chỉ";
                buttonSave.Text = "Lưu lối tắt";
                buttonDeleteLog.Text = "Xóa ghi chép";


                //groupBox3.Text = "Nền";
                //radioButton3.Text = "Tối";
                //radioButton4.Text = "Sáng";
                //radioButton5.Text = "Tự động";


                labelShortcutType.Text = "Loại";
                labelName.Text = "Tên gọi";
                labelPath.Text = "Đường dẫn";
                labelPara.Text = "Tham số";
                button12.Text = "Hủy";


                listView1.Columns[0].Text = "Tên gọi";
                listView1.Columns[1].Text = "Đường dẫn";
                listView1.Columns[2].Text = "Tham số";

                listView2.Columns[0].Text = "Tên";
                listView2.Columns[1].Text = "Đường dẫn";
                listView2.Columns[2].Text = "Đuôi mở rộng";

                //button1.Text = "Trang chủ";
                button4.Text = "Quay lại";

                //button14.Text = "Áp dụng";
                //button15.Text = "Hủy";
                //labelHotKeyConfig.Text = "Tùy chỉnh phím tắt XShort Run";
                //linkLabel1.Text = "Nâng cao>>";

                //groupBox1.Text = "Cài đặt chung";
                //checkBox1.Text = "Khởi động cùng Windows";
                //checkBox2.Text = "Ẩn hộp thoại này khi khởi động";
                //checkBox3.Text = "Tự động tìm trên mạng nếu không tìm thấy";
                //checkBox4.Text = "Phân biệt hoa thường";
                //checkBox5.Text = "Ẩn biểu tượng khay";
                //checkBox6.Text = "Chọn hết";
                //checkBox7.Text = "Tự động phát hiện lối tắt không hoạt động";

                //groupBox2.Text = "Ngôn ngữ";
                //radioButton1.Text = "Tiếng Anh";
                //radioButton2.Text = "Tiếng Việt";
                openFileLocationToolStripMenuItem1.Text = "Mở thư mục chứa";

                openToolStripMenuItem.Text = "Mở";
                openFileLocationToolStripMenuItem.Text = "Mở thư mục chứa";
                propertyToolStripMenuItem.Text = "Thông tin tập tin";

                addToolStripMenuItem1.Text = "Xoá";
                detailsToolStripMenuItem.Text = "Chỉnh sửa";
                propertiesToolStripMenuItem.Text = "Thông tin chi tiết";
                openToolStripMenuItem1.Text = "Mở";
                openAsAdministratorToolStripMenuItem.Text = "Mở dưới quyền người quản trị";
                checkValidPathToolStripMenuItem.Text = "Kiểm tra đường dẫn";
                createShortcutOnDesktopToolStripMenuItem.Text = "Tạo lối tắt ngoài Desktop";
                cloneToolStripMenuItem.Text = "Tạo bản sao lối tắt";
                openAtWindowsStartupToolStripMenuItem.Text = "Mở cùng Windows";

                aboutToolStripMenuItem.Text = "Giới thiệu";
                mainWindowToolStripMenuItem.Text = "Cửa sổ chính";
                runBoxToolStripMenuItem.Text = "Cửa sổ chạy";
                settingsToolStripMenuItem.Text = "Cài Đặt";
                exitToolStripMenuItem1.Text = "Thoát";

                undoToolStripMenuItem.Text = "Hoàn tác";

                notifyIcon1.Text = "Nhấn Alt + A hoặc bấm vào để mở";
                //toolStripTextBox1.ToolTipText = "Điền địa chỉ sau đó bấm enter để thêm";

                openToolStripMenuItem.Text = "Mở";
                propertyToolStripMenuItem.Text = "Thông tin chi tiết";

                //tabPage1.Text = "Có gì mới";
                //tabPage2.Text = "Phím tắt";

            }
            else
            {

                if (f2 != null && f2.IsDisposed != true)
                {
                    f2.changeLanguages(1);
                }
               
                buttonScan.Text = "Scan";
                button2.Text = "Cancel";
                button9.Text = "Add";

                //label5.Text = "File Extension:";
                comboBox3.Items[0] = "File Extension";
                comboBox3.Items[1] = "File Name";
                comboBox3.Items[2] = "Programs";
                label6.Text = "Scan Folder:";
                label7.Text = "(exe, mp3,..., * for all)";


                buttonAddApp.Text = "Add App/File";
                buttonAddDir.Text = "Add Directory";
                buttonAddURL.Text = "Add URL";
                buttonSave.Text = "Save shortcuts";
                buttonDeleteLog.Text = "Delete log";
                openFileLocationToolStripMenuItem1.Text = "Open file location";

                //groupBox3.Text = "Skin";
                //radioButton3.Text = "Dark";
                //radioButton4.Text = "Light";
                //radioButton5.Text = "Auto";

                labelShortcutType.Text = "Shortcut Type";
                labelName.Text = "Call name";
                labelPath.Text = "Path";
                labelPara.Text = "Parameter";
                button12.Text = "Cancel";


                listView1.Columns[0].Text = "Call name";
                listView1.Columns[1].Text = "Path";
                listView1.Columns[2].Text = "Parameters";

                listView2.Columns[0].Text = "Name";
                listView2.Columns[1].Text = "Path";
                listView2.Columns[2].Text = "Extension";

                //button1.Text = "Homepage";
                button4.Text = "Back";

                //button14.Text = "Apply";
                //button15.Text = "Canel";
                //labelHotKeyConfig.Text = "XShort Run Hotkey Configuration";
                //linkLabel1.Text = "Advanced>>";

                //groupBox1.Text = "General";
                //checkBox1.Text = "Run at Windows startup";
                //checkBox2.Text = "Hide this dialog box at startup";
                //checkBox3.Text = "Automatically search internet if no data";
                //checkBox4.Text = "Case-sensitive";
                //checkBox5.Text = "Hide tray icon";
                //checkBox6.Text = "Select all";
                //checkBox7.Text = "Automatically detect invalid shortcuts";
                //openAtWindowsStartupToolStripMenuItem.Text = "Open at Windows startup";

                //groupBox2.Text = "Languages";
                //radioButton1.Text = "English";
                //radioButton2.Text = "Vietnamese";

                openToolStripMenuItem.Text = "Open";
                propertyToolStripMenuItem.Text = "Properties";


                addToolStripMenuItem1.Text = "Remove";
                detailsToolStripMenuItem.Text = "Edit";
                propertiesToolStripMenuItem.Text = "Properties";
                openToolStripMenuItem1.Text = "Open";
                openAsAdministratorToolStripMenuItem.Text = "Open as administrator";

                checkValidPathToolStripMenuItem.Text = "Check valid path";
                createShortcutOnDesktopToolStripMenuItem.Text = "Create shortcut on Desktop";
                cloneToolStripMenuItem.Text = "Clone shortcut";
                openAtWindowsStartupToolStripMenuItem.Text = "Open at Windows startup";

                aboutToolStripMenuItem.Text = "About";
                mainWindowToolStripMenuItem.Text = "Main Window";
                runBoxToolStripMenuItem.Text = "Run Box";
                settingsToolStripMenuItem.Text = "Settings";
                exitToolStripMenuItem1.Text = "Exit";

                undoToolStripMenuItem.Text = "Undo";

                notifyIcon1.Text = "Press Alt + A or click to run";
                //toolStripTextBox1.ToolTipText = "Type your url here then enter to add";

                openToolStripMenuItem.Text = "Open";
                openFileLocationToolStripMenuItem.Text = "Open file location";
                propertyToolStripMenuItem.Text = "Properties";

                //tabPage1.Text = "Changelog";
                //tabPage2.Text = "Hotkeys";
            }


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
                    if (en)
                        MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " is a valid path.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " là một đường dẫn có tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Directory.Exists(listView1.FocusedItem.SubItems[1].Text))
                    {
                        if (en)
                            MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " is a valid path.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " là một đường dẫn có tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (en)
                        {
                            if (MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " is an invalid path.\nDo you want to remove it from list now?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                listView1.FocusedItem.Remove();
                            }
                        }
                        else
                        {
                            if (MessageBox.Show(listView1.FocusedItem.SubItems[1].Text + " là một đường dẫn không tồn tại.\nBạn có muốn xóa nó khỏi danh sách ngay bây giờ không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                listView1.FocusedItem.Remove();
                            }
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
            if (panel1.Visible || buttonScan.Visible)
            {
                if (en)
                {
                    if (MessageBox.Show("You are editing something, you want to quit?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        panel1.Hide();
                        panel2.Hide();
                    }
                    else
                        return;
                }
                else
                {
                    if (MessageBox.Show("Bạn đang chỉnh sửa một cái gì đó, bạn có chắc muốn dừng việc đó?", "Chắc chưa?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        panel1.Hide();
                        panel2.Hide();
                    }
                    else
                        return;
                }
            }

            panelScan.Hide();




        }


        private void button8_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;

        }

        private void panelControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newx = e.X;
                newy = e.Y;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            exit = true;
            f3.closeForm();
            Application.Exit();
        }







        private void changeSkin(bool dark)
        {
            if (f2 != null && f2.IsDisposed != true)
            {
                f2.changeSkin(dark);
            }
            if (!dark)
            {


                this.BackColor = Color.White;
                //panelControl.BackColor = this.BackColor;
                listView1.BackColor = Color.White;
                listView1.ForeColor = Color.Black;

                listView2.BackColor = Color.White;
                listView2.ForeColor = Color.Black;

                checkBox6.ForeColor = Color.Black;

                labelShortcutType.ForeColor = Color.Black;
                labelName.ForeColor = Color.Black;
                labelPath.ForeColor = Color.Black;
                labelPara.ForeColor = Color.Black;


                buttonAddApp.ForeColor = Color.Black;
                buttonAddDir.ForeColor = Color.Black;
                buttonAddURL.ForeColor = Color.Black;
                buttonSave.ForeColor = Color.Black;



                label2.ForeColor = Color.Black;


                label6.ForeColor = Color.Black;

            }
            else
            {



                this.BackColor = Color.FromArgb(28, 28, 28);
                //panelControl.BackColor = this.BackColor;
                listView1.BackColor = Color.FromArgb(28, 28, 28);
                listView1.ForeColor = Color.White;
                listView2.BackColor = Color.FromArgb(28, 28, 28);
                listView2.ForeColor = Color.White;


                labelShortcutType.ForeColor = Color.White;
                labelName.ForeColor = Color.White;
                labelPath.ForeColor = Color.White;
                labelPara.ForeColor = Color.White;

                buttonAddApp.ForeColor = Color.White;
                buttonAddDir.ForeColor = Color.White;
                buttonAddURL.ForeColor = Color.White;
                buttonSave.ForeColor = Color.White;

                checkBox6.ForeColor = Color.White;

                label2.ForeColor = Color.FromArgb(255, 255, 128);

                //label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;

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
            history.Add("[" + DateTime.Now + "]" + " You create a shortcut on desktop name " + listView1.FocusedItem.SubItems[0].Text + ", path: " + listView1.FocusedItem.SubItems[1].Text + ", para: " + listView1.FocusedItem.SubItems[2].Text);
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeToolStripMenuItem_Click(null, null);
            }
            if (e.KeyCode == Keys.Enter)
            {
                openToolStripMenuItem1_Click(null, null);
            }
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.Add("[" + DateTime.Now + "] " + "You clone a shortcut name " + listView1.FocusedItem.SubItems[0].Text);
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
                                history.Add("[" + DateTime.Now + "] " + "You add an item name " + targetPath + ", path: " + targetPath + ", para: Not Available");
                            }
                            else
                            {
                                listView1.Items.Add(new ListViewItem(new string[] { targetPath, targetPath, "None" }));
                                listView1.Focus();
                                listView1.Items[listView1.Items.Count - 1].Selected = true;
                                listView1.EnsureVisible(listView1.Items.Count - 1);
                                yet = "app";
                                history.Add("[" + DateTime.Now + "] " + "You add an item name " + targetPath + ", path: " + targetPath + ", para: None");
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
                        history.Add("[" + DateTime.Now + "] " + "You add an item name " + docPath[0] + ", path: " + docPath[0] + ", para: Not Available");
                    }
                    else
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { docPath[0].Substring(docPath[0].LastIndexOf("\\") + 1), docPath[0], "None" }));
                        listView1.Focus();
                        listView1.Items[listView1.Items.Count - 1].Selected = true;
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                        yet = "app";
                        history.Add("[" + DateTime.Now + "] " + "You add an item name " + docPath[0].Substring(docPath[0].LastIndexOf("\\") + 1) + ", path: " + docPath[0] + ", para: None");
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
            if (en == true)
                fb.Description = "Select folder of data you want to import";
            else
                fb.Description = "Chọn thư mục có dữ liệu bạn muốn thêm";
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
                    if (en)
                    {
                        MessageBox.Show("Fail to import data! Make sure you have a valid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi đã xảy ra trong lúc thêm dữ liệu! Hãy đảm bảo bạn có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (ret == -1)
                {
                    if (en)
                    {
                        MessageBox.Show("Fail to import data! Make sure you have a valid data!", "Error Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi đã xảy ra trong lúc thêm dữ liệu! Hãy đảm bảo bạn có dữ liệu!", "Lỗi thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (en)
                    {
                        MessageBox.Show("Import data done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hoàn thành thêm dữ liệu", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            if (en)
                fd.Description = "Select folder to export";
            else
                fd.Description = "Chọn thư mục để xuất dữ liệu";
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
                    if (en)
                        MessageBox.Show("Fail to export data!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Xuất dữ liệu thất bại!", "Không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (en)
                    MessageBox.Show("Export data done!\n The data are 3 files: data1, data2, data3.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xuất dữ liệu hoàn thành!\n Dữ liệu là 3 file data1, data2, data3.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                history.Add("[" + DateTime.Now + "] " + "You export your data");
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

        private void buttonFileSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            fd.ShowNewFolderButton = false;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = fd.SelectedPath;
            }
            fd.Dispose();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 0;

            panel1.Show();
            panel2.Show();

            panelScan.Show();

        }


        private void buttonScan_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            //sea.Clear();

            img2.Images.Clear();
            img2.Dispose();
            img2 = new ImageList();
            img2.ColorDepth = ColorDepth.Depth32Bit;
            img2.ImageSize = new Size(25, 25);
            listView2.SmallImageList = img2;
            if (textBox4.Text == String.Empty && comboBox3.SelectedIndex != 2)
            {
                if (en)
                    MessageBox.Show("Scan folder is empty?!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Thư mục để quét trống?!", "Trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (textBox3.Text == String.Empty)
                {
                    textBox3.Text = "*";
                }

                f3.TopMost = false;
                f3.changeDisplay(5);
                f3.Show();




                //button8.Enabled = false;
                //button7.Enabled = false;

                BackgroundWorker bwt = new BackgroundWorker();
                bwt.DoWork += Bwt_DoWork1;
                bwt.RunWorkerAsync();



            }
        }



        private void Bwt_DoWork1(object sender, DoWorkEventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                foreach (string f in Directory.GetFiles(textBox4.Text, "*." + textBox3.Text)) //search its file before search subdir
                {
                    listView2.Items.Add(new ListViewItem(new string[] { f.Substring(f.LastIndexOf("\\") + 1), f, Path.GetExtension(f) }));
                    img2.Images.Add(Icon.ExtractAssociatedIcon(f));
                    label8.Text = "Found " + listView2.Items.Count + " items";
                }

                fileSearch(textBox4.Text);
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                DirectoryInfo info = new DirectoryInfo(textBox4.Text);
                FileInfo[] sfile = info.GetFiles("*" + textBox3.Text + "*.*");
                for (int j = 0; j < sfile.Count(); j++)
                {
                    //sea.Add(sfile[j]);
                    string fullname = sfile[j].FullName;
                    listView2.Items.Add(new ListViewItem(new string[] { fullname.Substring(fullname.LastIndexOf("\\") + 1), fullname, Path.GetExtension(fullname) }));
                    img2.Images.Add(Icon.ExtractAssociatedIcon(fullname));
                    label8.Text = "Found " + listView2.Items.Count + " items";

                }

                nameSearch(textBox4.Text);
            }
            else
            {
                GetPathForExe32();
                getInstalledApps32();
                getInstalledApps32Current();
                getInstalledApps64();
            }

            for (int i = 0; i < listView2.Items.Count; i++)
            {
                listView2.Items[i].ImageIndex = i;
            }
            f3.Show();
            f3.Hide();



            //button8.Enabled = true;
            //button7.Enabled = true;


            label8.Text = "Found " + listView2.Items.Count + " items";


        }

        private bool isInList(string path)
        {
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].SubItems[1].Text == path)
                    return true;
            }
            return false;
        }

        private void GetPathForExe32()
        {
            const string keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(keyBase))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            string apath = sk.GetValue(null).ToString();
                            if (!isInList(apath))
                            {
                                listView2.Items.Add(new ListViewItem(new string[] { apath.Substring(apath.LastIndexOf("\\") + 1), apath, Path.GetExtension(apath) }));
                                img2.Images.Add(Icon.ExtractAssociatedIcon(apath));
                            }
                        }
                        catch { }
                    }
                }
            }

        }

        private void getInstalledApps32()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var displayIcon = sk.GetValue("DisplayIcon");

                            ListViewItem item;
                            if (displayName != null)
                            {
                                if (displayIcon != null)
                                {
                                    if (!isInList(displayIcon.ToString()))
                                    {
                                        item = new ListViewItem(new string[] { displayName.ToString(), displayIcon.ToString(), Path.GetExtension(displayIcon.ToString()) });
                                        img2.Images.Add(Icon.ExtractAssociatedIcon(displayIcon.ToString()));
                                        listView2.Items.Add(item);
                                    }
                                }


                            }
                        }
                        catch
                        { }
                    }
                }

            }
        }

        private void getInstalledApps64()
        {
            string uninstallKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var displayIcon = sk.GetValue("DisplayIcon");

                            ListViewItem item;
                            if (displayName != null)
                            {
                                if (displayIcon != null)
                                {
                                    if (!isInList(displayIcon.ToString()))
                                    {
                                        item = new ListViewItem(new string[] { displayName.ToString(), displayIcon.ToString(), Path.GetExtension(displayIcon.ToString()) });
                                        img2.Images.Add(Icon.ExtractAssociatedIcon(displayIcon.ToString()));
                                        listView2.Items.Add(item);
                                    }
                                }

                            }
                        }
                        catch
                        { }
                    }
                }

            }
        }

        private void getInstalledApps32Current()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var displayIcon = sk.GetValue("DisplayIcon");

                            ListViewItem item;
                            if (displayName != null)
                            {
                                if (displayIcon != null)
                                {
                                    if (!isInList(displayIcon.ToString()))
                                    {
                                        item = new ListViewItem(new string[] { displayName.ToString(), displayIcon.ToString(), Path.GetExtension(displayIcon.ToString()) });
                                        img2.Images.Add(Icon.ExtractAssociatedIcon(displayIcon.ToString()));
                                        listView2.Items.Add(item);
                                    }
                                }

                            }
                        }
                        catch
                        { }
                    }
                }

            }
        }

        void nameSearch(string dir)
        {
            try
            {
                string[] sdir = Directory.GetDirectories(dir);
                for (int i = 0; i < sdir.Count(); i++)
                {
                    DirectoryInfo info = new DirectoryInfo(sdir[i]);
                    FileInfo[] sfile = info.GetFiles("*" + textBox3.Text + "*.*");
                    for (int j = 0; j < sfile.Count(); j++)
                    {
                        //sea.Add(sfile[j]);
                        string fullname = sfile[j].FullName;
                        listView2.Items.Add(new ListViewItem(new string[] { fullname.Substring(fullname.LastIndexOf("\\") + 1), fullname, Path.GetExtension(fullname) }));
                        img2.Images.Add(Icon.ExtractAssociatedIcon(fullname));
                        label8.Text = "Found " + listView2.Items.Count + " items";

                    }
                    nameSearch(sdir[i]);
                }
            }
            catch
            {
                return;
            }
        }

        void fileSearch(string dir)
        {
            try
            {
                string[] sdir = Directory.GetDirectories(dir);
                for (int i = 0; i < sdir.Count(); i++)
                {
                    string[] sfile = Directory.GetFiles(sdir[i], "*." + textBox3.Text);
                    for (int j = 0; j < sfile.Count(); j++)
                    {
                        //sea.Add(sfile[j]);
                        listView2.Items.Add(new ListViewItem(new string[] { sfile[j].Substring(sfile[j].LastIndexOf("\\") + 1), sfile[j], Path.GetExtension(sfile[j]) }));
                        img2.Images.Add(Icon.ExtractAssociatedIcon(sfile[j]));
                        label8.Text = "Found " + listView2.Items.Count + " items";

                    }
                    fileSearch(sdir[i]);
                }
            }
            catch
            {
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (listView2.Items.Count > 0)
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Checked == true)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listView2.Items[i].SubItems[0].Text, listView2.Items[i].SubItems[1].Text, "None" }));
                        count += 1;
                        history.Add("[" + DateTime.Now + "] " + "You add an item name " + listView2.Items[i].SubItems[0].Text + ", path: " + listView2.Items[i].SubItems[1].Text + ", para: ");
                    }
                }
                if (en)
                    MessageBox.Show("Added " + count + " items to database!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Đã thêm " + count + " thứ vào cơ sở dữ liệu", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //buttonData_Click(null, null);
            }
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.Checked)
                {
                    listView2.Items.Remove(item);
                }
            }
        }

        private void scanFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 0;
            panel1.Show();
            panel2.Show();
            panelScan.Show();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                if (listView2.Items.Count != 0)
                {
                    foreach (ListViewItem i in listView2.Items)
                    {
                        i.Checked = true;
                    }
                }
                else
                    checkBox6.Checked = false;
            }
            else
            {
                if (listView2.Items.Count != 0)
                {
                    foreach (ListViewItem i in listView2.Items)
                    {
                        i.Checked = false;
                    }
                }
            }
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView2.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip3.Show(Cursor.Position);

                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(listView2.FocusedItem.SubItems[1].Text);
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

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileProperties(listView2.FocusedItem.SubItems[1].Text);
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

            panel1.Show();
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

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listView2.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView2.Sorting == SortOrder.Ascending)
                    listView2.Sorting = SortOrder.Descending;
                else
                    listView2.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView2.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            listView2.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listView2.Sorting);
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {

            buttonData_Click();
            listBox1.Items.Clear();
            foreach (string s in history)
            {
                listBox1.Items.Add(s);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            panel1.Show();
            panel2.Hide();
        }

        private string[] splitString(string s)
        {
            string[] res = s.Split(',');
            res[0] = res[0].Substring(res[0].IndexOf("name") + 5);
            res[1] = res[1].Substring(res[1].IndexOf(":") + 2);
            res[2] = res[2].Substring(res[2].IndexOf(":") + 2);
            if (res[2] == String.Empty)
            {
                res[2] = "None";
            }
            return res;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] res = splitString(listBox1.Items[listBox1.SelectedIndex].ToString());
            string logLine = listBox1.Items[listBox1.SelectedIndex].ToString();
            if (logLine.Contains("add"))
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.SubItems[0].Text == res[0])
                    {
                        listView1.Items.Remove(i);
                        history.Add("[" + DateTime.Now + "] " + "[Undo Add] You remove an item name " + res[0] + ", path: " + res[1] + ", para: " + res[2]);
                        yet = "undo";
                    }
                }
            }
            else if (logLine.Contains("import"))
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.SubItems[0].Text == res[0])
                    {
                        listView1.Items.Remove(i);
                        history.Add("[" + DateTime.Now + "] " + "[Undo Import] You remove an item name " + res[0] + ", path: " + res[1] + ", para: " + res[2]);
                        yet = "undo";
                    }
                }
            }
            else if (logLine.Contains("remove"))
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.SubItems[0].Text == res[0])
                    {
                        MessageBox.Show("This item is already in the table!?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                listView1.Items.Add(new ListViewItem(new string[] { res[0], res[1], res[2] }));
                history.Add("[" + DateTime.Now + "] " + "[Undo Remove] You add an item name " + res[0] + ", path: " + res[1] + ", para: " + res[2]);
                yet = "undo";
            }
            listBox1.Items.Clear();
            foreach (string s in history)
            {
                listBox1.Items.Add(s);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void listBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            var index = listBox1.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                listBox1.SelectedIndex = index;
                string tmp = listBox1.Items[index].ToString();
                if (tmp.Contains("remove") || tmp.Contains("add") || tmp.Contains("import"))
                    contextMenuStrip4.Show(Cursor.Position);

            }
        }

        //beta test program



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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
                label7.Visible = true;
            else
                label7.Visible = false;
            if (comboBox3.SelectedIndex == 2)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                buttonFileSearch.Enabled = false;
            }
            else
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                buttonFileSearch.Enabled = true;
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string argument = "/select, \"" + listView2.FocusedItem.SubItems[1].Text + "\"";
            Process.Start("explorer.exe", argument);
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

        private void button2_Click_3(object sender, EventArgs e)
        {
            buttonData_Click();
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
            if (!dontload)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += Worker_DoWork;
                worker.RunWorkerAsync();
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void buttonBuildIndex_Click(object sender, EventArgs e)
        {
            indexing = false;
            BuildIndex bid = new BuildIndex(en);
            bid.FormClosed += Bid_FormClosed;
            bid.ShowDialog();
        }

        private void Bid_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadSettings();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip5.Show(ptLowerLeft);
        }

        private void buttonDeleteLog_Click(object sender, EventArgs e)
        {
            history.Clear();
            listBox1.Items.Clear();
            File.WriteAllText(dataPath + "\\log.txt", String.Empty);
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
                        if (en == true)
                            MessageBox.Show("Missing data to complete operation", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                            MessageBox.Show("Thiếu dữ liệu - không thể hoàn thành", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                listView1.Enabled = true;
                f3.Show();
                f3.Hide();
                loadIcon();
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

        private void panelControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left = Left + (e.X - newx);
                Top = Top + (e.Y - newy);
                f3.Location = new Point(this.Location.X + (this.Width - f3.Width) / 2, this.Location.Y + (this.Height - f3.Height) / 2);
            }
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
