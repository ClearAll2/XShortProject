using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Win32;

namespace XShort
{
    public partial class Form2 : Form
    {
        int index = 0;
        List<String> dir = new List<String>();
        List<String> sName = new List<String>();
        List<String> sPath = new List<String>();
        List<String> sPara = new List<String>();
        RegistryKey r;
        string dataPath;
        string keyword = String.Empty;
        bool ggSearch = true;
        bool csen = false;
        string text = String.Empty;
        string text1, part = String.Empty;
        int newx, newy;
        string pass = "asdewefcasdsafasfajldsjlsjakldjohfoiajskdlsakljncnalskjdlkjslka";
        BackgroundWorker bw;
        public Form2(int en)
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
            if (r.GetValue("Dark") != null)
            {
                changeSkin(true);
            }
            else if (r.GetValue("Light") != null)
            {
                changeSkin(false);
            }
            else
            {
                changeSkin(false);
            }
            if (r.GetValue("xfind") != null)
            {
                checkBox1.Checked = true;
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

            //if (File.Exists(Application.StartupPath + "\\xfind.exe"))
            //    checkBox1.Show();
            //else
            //    checkBox1.Hide();

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
            
        }

        public void changeGGSeach(bool gg)
        {
            ggSearch = gg;
        }

        public void changeSensitive(bool Csen)
        {
            csen = Csen;
        }

        public void changeLanguages(int en)
        {
            if (en == 0)
            {
                label1.Text = "Mở ứng dụng/đường dẫn/địa chỉ (kể cả không có dữ liệu)";
                label2.Text = "Không cần điền tên đầy đủ, ứng dụng sẽ nhận diện tự động";
                button2.Text = "Hủy";
                label4.Text = "Nếu bạn đã tạo mục lục, bạn có thể tìm kiếm tất cả ở đây";
                checkBox1.Text = "Sử dụng XFind";
                openAsAdministratorToolStripMenuItem.Text = "Mở dưới quyền người quản trị";
            }
            else
            {
                label1.Text = "Open app/directory/url (even not in database):";
                label2.Text = "No need to write full call name, app will detect automatically";
                label4.Text = "If you built index files, you can search files and folders here";
                button2.Text = "Cancel";
                checkBox1.Text = "Use XFind";
                openAsAdministratorToolStripMenuItem.Text = "Open as Administrator";
            }
        }

        public void changeSkin(bool dark)
        {
            if (dark)
            {
                this.BackColor = Color.FromArgb(45, 45, 45);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.Yellow;
                //label3.ForeColor = Color.White;
                button1.ForeColor = Color.White;
                button2.ForeColor = Color.White;
                checkBox1.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Blue;
                //label3.ForeColor = Color.Black;
                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;
            }
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
                    if (File.Exists(dataPath + "\\indexFol"))
                    {
                        if (File.Exists(dataPath + "\\indexFil"))
                        {
                            keyword = tmp;
                            this.Hide();
                            return;
                        }
                    }
                        
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
            if (keyword != String.Empty)
            {
                Search sch = new Search(keyword);
                sch.Show();
                keyword = String.Empty;
            }
        }

        private void Tbw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool runas = (bool)e.Argument;
            string dfl = comboBox1.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox1.Checked)
            {
                r.SetValue("xfind", true);
            }
            else
            {
                r.DeleteValue("xfind", false);

            }
            r.Close();
            r.Dispose();
        }

        private void openAsAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundWorker tbw = new BackgroundWorker();
            tbw.DoWork += Tbw_DoWork;
            tbw.RunWorkerAsync(true);
            tbw.RunWorkerCompleted += Tbw_RunWorkerCompleted;
        }
        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newx = e.X;
                newy = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left = Left + (e.X - newx);
                Top = Top + (e.Y - newy);
            }
        }
    }
}
