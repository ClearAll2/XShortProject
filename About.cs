using System;
using System.Reflection;
using System.Windows.Forms;
using System.Net;
using System.ComponentModel;
using System.IO;

namespace XShort
{
    public partial class About : Form
    {
        public bool exit = false;
        private string latest = String.Empty;
        private string changelog = String.Empty;
        public About()
        {
            InitializeComponent();
            labelInfo.Text = "XShort Core v" + Application.ProductVersion + " build " + this.AssemblyDescription + "\nCopyright © 2020 - 2021\nXShort Core Project\nFreedom Software (CAS)";
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

        private void buttonCheckUpdate_Click(object sender, EventArgs e)
        {
            buttonCheckUpdate.Enabled = false;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                MessageBox.Show("No newer version available!\nPlease check again later.", "No update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonCheckUpdate.Enabled = true;
            }
            else
            {
                if (MessageBox.Show(String.Join(" ", "New version is available (", latest, ").\nChangelog:\n", changelog, "\nDo you want to update now?"), "New update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileAsync(new Uri("https://release.clearallsoft.cf/download/XShortCore/xshortcore.zip"), Path.Combine(Application.StartupPath, "xshortcore.zip"));
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                }
                else
                {
                    buttonCheckUpdate.Enabled = true;
                }
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient wc = new WebClient();
            latest = wc.DownloadString("https://release.clearallsoft.cf/download/XShortCore/version");
            changelog = wc.DownloadString("https://release.clearallsoft.cf/download/XShortCore/changelog");
            if (latest.CompareTo(Application.ProductVersion) > 0)
            {
                e.Result = 1;
            }
            else
            {
                e.Result = 0;
            }
            wc.Dispose(); 
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            File.WriteAllText(Application.StartupPath + "\\update.bat", String.Empty);
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\update.bat");
            sw.WriteLine("start powershell.exe" + " " + "Expand-Archive -Force -Path " + Application.StartupPath + "\\xshortcore.zip" + " -DestinationPath " + Application.StartupPath);
            sw.WriteLine("timeout /T 2");
            sw.WriteLine("start " + Application.ExecutablePath);
            sw.WriteLine("del \"xshortcore.zip\"");
            sw.Close();
            exit = true;
            buttonCheckUpdate.Enabled = true;
            this.Close();
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            buttonCheckUpdate.Text = String.Join(" ", "Downloading", e.ProgressPercentage, "%");
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!buttonCheckUpdate.Enabled)
                e.Cancel = true;
        }
    }
}
