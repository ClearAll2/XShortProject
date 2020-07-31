using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XShort
{
    public partial class RunForm : Form
    {
        private int index = 0;
        private List<String> dir = new List<String>();
        private List<String> sName = new List<String>();
        private List<String> sPath = new List<String>();
        private List<String> sPara = new List<String>();
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

            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r == null)
                r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\Data");
            if (r.GetValue("Left") != null)
            {
                Top = (int)r.GetValue("Top");
                Left = (int)r.GetValue("Left");
            }
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
            if (en == 0)
            {

                label1.Text = "Mở ứng dụng/đường dẫn/địa chỉ (kể cả không có dữ liệu)";
                label2.Text = "Không cần điền tên đầy đủ, ứng dụng sẽ nhận diện tự động";
                label4.Text = "Nếu bạn đã tạo mục lục, bạn có thể tìm kiếm tất cả ở đây";
                button2.Text = "Hủy";
            }


            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();

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
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r == null)
                r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\Data");
            r.SetValue("Left", this.Left);
            r.SetValue("Top", this.Top);
            r.Close();
            r.Dispose();

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
            if (e.KeyCode != Keys.Back)
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

        private void openAsAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundWorker tbw = new BackgroundWorker();
            tbw.DoWork += Tbw_DoWork;
            tbw.RunWorkerAsync(true);
        }

    }
}
