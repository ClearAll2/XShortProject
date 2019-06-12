using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace XShort
{
    public partial class BuildIndex : Form
    {
        bool pause = false;
        bool stop = false;
        int folderNum, fileNum = 0;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");

        public BuildIndex(bool en)
        {
            InitializeComponent();
            if (File.Exists(path + "\\indexFol") && File.Exists(path + "\\indexFil"))
            {
                if (en)
                    labelHadIndex.Text = "Found index files";
                else
                    labelHadIndex.Text = "Tìm thấy tập tin mục lục";
                buttonDeleteIndex.Visible = true;
                buttonBuildIndex.Enabled = false;
                this.Height -= panel1.Height;
                panel1.Visible = false;
            }
            else
            {
                if (en)
                    labelHadIndex.Text = "Found no index files";
                else
                    labelHadIndex.Text = "Không tìm thấy tập tin mục lục";
            }
            changeLang(en);
        }

        private void changeLang(bool en)
        {
            if (en)
            {
                label1.Text = "When the indexing is complete, you’ll be able to find all your files almost instantly when you use XShort Run.";
                label2.Text = "It will take about 30 minutes to find all your folders and files. If you have lots of files, it will take longer. The indexing will increase cpu consumption.";
                label3.Text = "Search interval is the speed of the indexing. You can increase it for smooth performance of computer.";
                label8.Text = "If you want to make it faster, you can temporarily turn off real-time protection on your anti-virus program. The real-time protection slows down the indexing speed.";
                buttonDeleteIndex.Text = "Delete index files";

            }
            else
            {
                label1.Text = "Khi mục lục đã hoàn thành, bạn sẽ có thể tìm kiếm tất cả các tập tin gần như ngay lập tức khi sử dụng XShort Run.";
                label2.Text = "Sẽ mất khoảng 30 phút để có thể tìm tất cả tập tin và thư mục. Nếu bạn có nhiểu tập tin, thời gian sẽ lâu hơn. Việc tạo mục lục sẽ sử dụng nhiều cpu.";
                label3.Text = "Search interval là tốc độ của tạo mục lục. Bạn có thể tăng giá trị để không ảnh hưởng đến hiệu suất máy tính.";
                label8.Text = "Nếu bạn muốn nhanh hơn, bạn có thể tạm thời tắt real-time protection trong chương trình diệt virus của bạn. Real-time protection làm chậm tốc độ tạo mục lục";
                buttonDeleteIndex.Text = "Xóa tập tin mục lục";
            }
        }

        void folderSearch(string dir)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                DirectoryInfo[] dir1 = di.GetDirectories("*" + "*.*");

                for (int i = 0; i < dir1.Count(); i++)
                {
                    if (stop)
                        return;
                    while (pause)
                    {
                        Thread.Sleep(1000);
                    }
                    File.AppendAllText(path + "\\indexFol", dir1[i].FullName + Environment.NewLine);
                    folderNum += 1;


                }
                labelFolderfound.Text = folderNum.ToString();
                //Scan recursively
                DirectoryInfo[] dirs = di.GetDirectories();
                if (dirs == null || dirs.Length < 1 || stop)
                    return;
                foreach (DirectoryInfo sdir in dirs)
                {

                    folderSearch(sdir.FullName);
                    Thread.Sleep((int)numberSearchInterval.Value * 100);
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
                DirectoryInfo di = new DirectoryInfo(dir);
                FileInfo[] files = di.GetFiles("*" + "*.*");

                for (int i = 0; i < files.Count(); i++)
                {
                    if (stop)
                        return;
                    while (pause)
                    {
                        Thread.Sleep(1000);
                    }
                    File.AppendAllText(path + "\\indexFil", files[i].FullName + Environment.NewLine);
                    fileNum += 1;


                }
                labelFilefound.Text = fileNum.ToString();
                //Scan recursively
                DirectoryInfo[] dirs = di.GetDirectories();
                if (dirs == null || dirs.Length < 1 || stop)
                    return;
                foreach (DirectoryInfo sdir in dirs)
                {
                    fileSearch(sdir.FullName);
                    Thread.Sleep((int)numberSearchInterval.Value * 100);
                }
            }
            catch
            {
                return;
            }
        }

        private void buttonBuildIndex_Click(object sender, EventArgs e)
        {
            if (buttonBuildIndex.Text == "Start")
            {
                stop = false;
                pause = false;
                buttonBuildIndex.Text = "Pause";
                BackgroundWorker buildIndex = new BackgroundWorker();
                buildIndex.DoWork += BuildIndex_DoWork;
                buildIndex.RunWorkerAsync();
            }
            else if (buttonBuildIndex.Text == "Pause")
            {
                pause = true;
                buttonBuildIndex.Text = "Resume";
            }
            else if (buttonBuildIndex.Text == "Resume")
            {
                pause = false;
                buttonBuildIndex.Text = "Pause";
            }
        }

        private void BuildIndex_DoWork(object sender, DoWorkEventArgs e)
        {
            int numdisk = 0;
            int percent = 0;
            int completed = 0;
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                numdisk++;
            }
            percent = 100 / numdisk / 2;
            buttonBuildIndexStop.Enabled = true;
            this.ControlBox = false;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                folderSearch(d.Name);
                completed += percent; labelPercent.Text = completed + "%";
                fileSearch(d.Name);
                completed += percent; labelPercent.Text = completed + "%";
                if (stop)
                    break;
                if (pause)
                    Thread.Sleep(1000);

            }
            labelPercent.Text = "100%";
            stop = true;
            pause = true;
            buttonBuildIndex.Text = "Start";
            buttonBuildIndexStop.Enabled = false;
            buttonBuildIndex.Enabled = false;
            this.ControlBox = true;
            this.Close();
        }

        private void buttonDeleteIndex_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete index files?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    File.Delete(path + "\\indexFol");
                    File.Delete(path + "\\indexFil");
                    buttonDeleteIndex.Visible = false;
                    labelHadIndex.Text = "Found no index files";
                    buttonBuildIndex.Enabled = true;
                    this.Height += panel1.Height;
                    panel1.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBuildIndexStop_Click(object sender, EventArgs e)
        {
            stop = true;
            pause = true;
            buttonBuildIndex.Text = "Start";
            buttonBuildIndexStop.Enabled = false;
            try
            {
                File.Delete(path + "\\indexFol");
                File.Delete(path + "\\indexFil");

            }
            catch
            {

            }
            this.Close();
        }


    }


}
