using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XShort
{
    public partial class Search : Form
    {
        int pos = 0;
        bool typing, exit = false;
        BackgroundWorker bw;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
        string[] appsExt = { ".exe", ".inf", ".isu", ".msi", ".wsf" };
        string[] docsExt = { ".doc", ".docx", ".docm", ".dotx", ".dotm", ".docb", ".xls", ".xlt", ".xlm", ".xlsx", ".xlsm", ".xltx", ".xltm", ".xlsb", ".xla", ".xlam", ".xll", ".xlw", ".ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx", ".potm", ".ppam", ".ppsx", ".ppsm", ".sldx", ".sldm", ".adn", ".accdb", ".accdr", ".accdt", ".accda", ".accde", ".pdf", ".rtf", ".wpd", ".wks", ".wps" };
        string[] photosExt = { ".ai", ".bmp", ".gif", ".ico", ".jpeg", ".jpg", ".png", ".ps", ".psd", ".svg", ".tif", ".tiff" };
        string[] musicExt = { ".aif", ".cda", ".mid", ".midi", ".mp3", ".m4a", ".ogg", ".wav", ".wma", ".wpl" };
        string[] videosExt = { ".3g2", ".3gp", ".avi", ".flv", ".h264", ".m4v", ".mkv", ".mov", ".mp4", ".mpg", ".mpeg", ".rm", ".swf", ".vob", ".wmv" };
        string[] othersExt = { ".7z", ".rar", ".zip", ".tar.gz", ".z", ".pkg", ".deb", ".arj", ".rpm", ".bin", ".dmg", ".iso", ".toast", ".bat", ".db", ".txt", ".log", ".sql", ".xml", ".asp", ".aspx", ".htm", ".html", ".js", ".c", ".cpp", ".php", ".py", ".class", ".cs", ".h", ".vb", ".java", ".swift" };
        public Search(string kw, bool en)
        {

            InitializeComponent();
            textBoxSearch.Text = kw;


            this.Left = 0;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;


            buttonSearchInternet.Text = kw + " - See web result";

            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            panelDetails.Hide();
            this.Width = panelResult.Width + 20;
            textBoxSearch.Focus();
            textBoxSearch.Select();

            ChangeLang(en);
        }

        private void ChangeLang(bool en)
        {
            if (en)
            {
                buttonOpen.Text = "Open";
                buttonOpenFileLoc.Text = "Open file location";
                buttonProperties.Text = "Properties";
                buttonCopy.Text = "Copy";
                buttonCut.Text = "Cut";
                buttonDelete.Text = "Delete";
                label4.Text = "File type:";
                label2.Text = "Date created:";
                label3.Text = "Date modified:";
                label5.Text = "Las accessed:";
                label6.Text = "Press enter to search, press again to stop";
                label1.Text = "Search on the web";
            }
            else
            {
                buttonOpen.Text = "Mở";
                buttonOpenFileLoc.Text = "Mở thư mục chứa";
                buttonProperties.Text = "Thông tin chi tiết";
                buttonCopy.Text = "Chép";
                buttonCut.Text = "Cắt";
                buttonDelete.Text = "Xóa";
                label4.Text = "Loại tập tin:";
                label2.Text = "Ngày tạo:";
                label3.Text = "Ngày chỉnh sửa:";
                label5.Text = "Lần truy cập cuối:";
                label6.Text = "Nhấn enter để tìm, nhấn lại để dừng";
                label1.Text = "Tìm trên mạng";
            }
        }

        public static int LevenshteinCompute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        private int FindClosest(ListView listView)
        {
            if (listView.Items.Count > 1)
            {
                int[] diff = new int[listView.Items.Count];
                for (int i = 0; i < listView.Items.Count; i++)
                {
                    diff[i] = LevenshteinCompute(listView.Items[i].Text, textBoxSearch.Text);
                }
                int index = diff[0];
                int min = 0;
                for (int i = 0; i < diff.Length; i++)
                {
                    if (diff[i] < index)
                    {
                        index = diff[i];
                        min = i;
                    }
                }
                return min;
            }
            return 0;
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!exit)
            {
                if (listViewFolders.Items.Count > 0)
                {
                    createNewField("Folders");
                    if (listViewFolders.Items.Count <= 30)
                    {
                        int closest = FindClosest(listViewFolders);
                        createNewItem(listViewFolders.Items[closest].ToolTipText);
                    }
                    else
                        createNewItem(listViewFolders.Items[0].ToolTipText);
                }
                if (listViewApps.Items.Count > 0)
                {
                    createNewField("Applications");
                    if (listViewApps.Items.Count <= 30)
                    {
                        int closest = FindClosest(listViewApps);
                        createNewItem(listViewApps.Items[closest].ToolTipText);
                    }
                    else
                        createNewItem(listViewApps.Items[0].ToolTipText);
                }
                if (listViewDocs.Items.Count > 0)
                {
                    createNewField("Documents");
                    if (listViewDocs.Items.Count <= 30)
                    {
                        int closest = FindClosest(listViewDocs);
                        createNewItem(listViewDocs.Items[closest].ToolTipText);
                    }
                    else
                        createNewItem(listViewDocs.Items[0].ToolTipText);
                }
                if (listViewPhotos.Items.Count > 0)
                {
                    createNewField("Photos");
                    if (listViewPhotos.Items.Count <= 30)
                    {
                        int closest = FindClosest(listViewPhotos);
                        createNewItem(listViewPhotos.Items[closest].ToolTipText);
                    }
                    else
                        createNewItem(listViewPhotos.Items[0].ToolTipText);
                }
                if (listViewMusic.Items.Count > 0)
                {
                    createNewField("Music");
                    if (listViewMusic.Items.Count <= 30)
                    {
                        int closest = FindClosest(listViewMusic);
                        createNewItem(listViewMusic.Items[closest].ToolTipText);
                    }
                    else
                        createNewItem(listViewMusic.Items[0].ToolTipText);
                }
                if (listViewVideos.Items.Count > 0)
                {
                    createNewField("Videos");
                    if (listViewVideos.Items.Count <= 30)
                    {
                        int closest = FindClosest(listViewVideos);
                        createNewItem(listViewVideos.Items[closest].ToolTipText);
                    }
                    else
                        createNewItem(listViewVideos.Items[0].ToolTipText);
                }
                if (listViewOthers.Items.Count > 0)
                {
                    createNewField("Others");
                    if (listViewOthers.Items.Count <= 30)
                    {
                        int closest = FindClosest(listViewOthers);
                        createNewItem(listViewOthers.Items[closest].ToolTipText);
                    }
                    else
                        createNewItem(listViewOthers.Items[0].ToolTipText);
                }
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            listViewFolders.Items.Clear();
            listViewApps.Items.Clear();
            listViewDocs.Items.Clear();
            listViewPhotos.Items.Clear();
            listViewMusic.Items.Clear();
            listViewVideos.Items.Clear();
            listViewOthers.Items.Clear();
            imageListFolder.Images.Clear();
            imageListApps.Images.Clear();
            imageListDocs.Images.Clear();
            imageListPhotos.Images.Clear();
            imageListMusic.Images.Clear();
            imageListOthers.Images.Clear();
            imageListVideos.Images.Clear();
            for (int i = 0; i < panelAll.Controls.Count; i++)
            {
                panelAll.Controls[i].Dispose();

            }
            pos = 0;
            panelAll.Controls.Clear();

            IndexSearch();
        }

        private void createNewField(string type)
        {
            Button btt = new Button();
            btt.FlatStyle = FlatStyle.Flat;
            btt.FlatAppearance.BorderSize = 0;
            btt.TextAlign = ContentAlignment.MiddleLeft;

            btt.ForeColor = SystemColors.Control;
            btt.Font = new Font(btt.Font.FontFamily, 10, FontStyle.Bold);
            btt.Text = type;
            btt.Width = panelAll.Width - 20;
            btt.Height = 40;
            btt.Top = pos * 40;
            btt.Click += Btt_Click;
            panelAll.Controls.Add(btt);
            pos += 1;

            toolTip1.SetToolTip(btt, "Find results in " + type);
        }

        private void createNewItem(string loc)
        {
            ImageList img = new ImageList();
            img.ColorDepth = ColorDepth.Depth32Bit;
            img.ImageSize = new Size(35, 35);
            if (Directory.Exists(loc))
                img.Images.Add(Properties.Resources.dir);
            else if (File.Exists(loc))
                img.Images.Add(Icon.ExtractAssociatedIcon(loc));
            else
                img.Images.Add(Properties.Resources.question_help_mark_balloon_512);

            Button btt = new Button();
            btt.FlatStyle = FlatStyle.Flat;
            btt.FlatAppearance.BorderSize = 0;
            btt.AutoEllipsis = true;
            btt.ImageList = img;
            btt.ImageIndex = 0;
            btt.ForeColor = Color.White;
            btt.ImageAlign = ContentAlignment.MiddleLeft;
            btt.Text = loc.Substring(loc.LastIndexOf("\\") + 1);
            btt.Width = panelAll.Width - 20;
            btt.Height = 40;
            btt.Top = pos * 40;
            btt.Click += Btt_Click2;
            panelAll.Controls.Add(btt);
            pos += 1;
            toolTip1.SetToolTip(btt, loc);

            Button details = new Button();
            details.FlatStyle = FlatStyle.Flat;
            details.FlatAppearance.BorderSize = 0;
            details.Font = new Font(details.Font.FontFamily, 12, FontStyle.Bold);
            details.Height = 40;
            details.Width = 40;
            details.Text = "?";
            details.Left = btt.Width - 35;
            details.Click += Details_Click;
            toolTip1.SetToolTip(details, "Details");

            btt.Controls.Add(details);




        }

        private void Details_Click(object sender, EventArgs e)
        {
            Button btt = (Button)sender;
            Button owner = (Button)btt.Parent;
            if (!panelDetails.Visible)
            {
                this.Width += panelDetails.Width;
                panelDetails.Show();
            }
            labelName.Text = owner.Text;
            labelPath.Text = toolTip1.GetToolTip(owner);
            if (Directory.Exists(labelPath.Text))
            {
                pictureBox1.Image = global::XShort.Properties.Resources.dir;
                DirectoryInfo info = new DirectoryInfo(labelPath.Text);
                labelType.Text = "File folder";
                labelDateCreated.Text = info.CreationTime.ToLongDateString();
                labelDateMod.Text = info.LastWriteTime.ToLongDateString();
                labelDateAccess.Text = info.LastAccessTime.ToLongDateString();
            }
            else if (File.Exists(labelPath.Text))
            {
                pictureBox1.Image = Icon.ExtractAssociatedIcon(labelPath.Text).ToBitmap();
                FileInfo info = new FileInfo(labelPath.Text);
                labelType.Text = info.Extension;
                labelDateCreated.Text = info.CreationTime.ToLongDateString();
                labelDateMod.Text = info.LastWriteTime.ToLongDateString();
                labelDateAccess.Text = info.LastAccessTime.ToLongDateString();
            }
            else
            {
                pictureBox1.Image = global::XShort.Properties.Resources.question_help_mark_balloon_512;

                labelType.Text = "This file is deleted or moved";
                labelDateCreated.Text = "N/A";
                labelDateMod.Text = "N/A";
                labelDateAccess.Text = "N/A";
            }
            pictureBox1.Refresh();
        }

        private void Btt_Click2(object sender, EventArgs e)
        {
            Button btt = (Button)sender;
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = toolTip1.GetToolTip(btt);
                proc.WorkingDirectory = Path.GetDirectoryName(toolTip1.GetToolTip(btt));
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btt_Click(object sender, EventArgs e)
        {
            Button btt = (Button)sender;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (btt.Text == tabControl1.TabPages[i].Text)
                    tabControl1.SelectedIndex = i;
            }
        }



        private void IndexSearch()
        {
            string keyword = textBoxSearch.Text;
            labelStatus.Text = "Searching...";

            if (typing || exit)
                return;

            StreamReader sr = new StreamReader(path + "\\indexFol");
            while (!sr.EndOfStream)
            {
                string read = sr.ReadLine();
                string cut = read.Substring(read.LastIndexOf("\\") + 1).ToLower();
                if (cut.Contains(keyword.ToLower()))
                {
                    DirectoryInfo info = new DirectoryInfo(read);
                    listViewFolders.Items.Add(new ListViewItem(new string[] { info.Name, "Folder" }));
                    listViewFolders.Items[listViewFolders.Items.Count - 1].ToolTipText = info.FullName;
                    Image temp;
                    if (Directory.Exists(read))
                        temp = Properties.Resources.dir;
                    else
                        temp = Properties.Resources.question_help_mark_balloon_512;
                    imageListFolder.Images.Add(temp);
                    listViewFolders.Items[listViewFolders.Items.Count - 1].ImageIndex = imageListFolder.Images.Count - 1;

                    temp.Dispose();

                }
                if (typing || exit)
                    goto toend;
            }
            sr.Close();
            sr.Dispose();


            //
            sr = new StreamReader(path + "\\indexFil");
            while (!sr.EndOfStream)
            {
                string read = sr.ReadLine();
                string cut = read.Substring(read.LastIndexOf("\\") + 1).ToLower();
                if (cut.Contains(keyword.ToLower()))
                {

                    FileInfo files = new FileInfo(read);
                    Image temp;
                    if (File.Exists(read))
                        temp = Icon.ExtractAssociatedIcon(read).ToBitmap();
                    else
                        temp = Properties.Resources.question_help_mark_balloon_512;

                    AddNewListViewItem(temp, files);
                    temp.Dispose();


                }

                if (typing || exit)
                    goto toend;
            }
        //RemoveDup(listViewFolders);
        //RemoveDup(listViewApps);
        //RemoveDup(listViewDocs);
        //RemoveDup(listViewPhotos);
        //RemoveDup(listViewMusic);
        //RemoveDup(listViewVideos);
        //RemoveDup(listViewOthers);


        toend:

            sr.Close();
            sr.Dispose();

            labelStatus.Text = "Done";
        }

        private void AddNewListViewItem(Image temp, FileInfo files)
        {
            if (appsExt.Contains(files.Extension.ToLower()))
            {
                listViewApps.Items.Add(new ListViewItem(new string[] { files.Name, files.Extension }));
                listViewApps.Items[listViewApps.Items.Count - 1].ToolTipText = files.FullName;
                imageListApps.Images.Add(temp);
                listViewApps.Items[listViewApps.Items.Count - 1].ImageIndex = imageListApps.Images.Count - 1;
            }
            if (photosExt.Contains(files.Extension.ToLower()))
            {
                listViewPhotos.Items.Add(new ListViewItem(new string[] { files.Name, files.Extension }));
                listViewPhotos.Items[listViewPhotos.Items.Count - 1].ToolTipText = files.FullName;
                imageListPhotos.Images.Add(temp);
                listViewPhotos.Items[listViewPhotos.Items.Count - 1].ImageIndex = imageListPhotos.Images.Count - 1;
            }
            if (musicExt.Contains(files.Extension.ToLower()))
            {
                listViewMusic.Items.Add(new ListViewItem(new string[] { files.Name, files.Extension }));
                listViewMusic.Items[listViewMusic.Items.Count - 1].ToolTipText = files.FullName;
                imageListMusic.Images.Add(temp);
                listViewMusic.Items[listViewMusic.Items.Count - 1].ImageIndex = imageListMusic.Images.Count - 1;
            }
            if (docsExt.Contains(files.Extension.ToLower()))
            {
                listViewDocs.Items.Add(new ListViewItem(new string[] { files.Name, files.Extension }));
                listViewDocs.Items[listViewDocs.Items.Count - 1].ToolTipText = files.FullName;
                imageListDocs.Images.Add(temp);
                listViewDocs.Items[listViewDocs.Items.Count - 1].ImageIndex = imageListDocs.Images.Count - 1;
            }
            if (videosExt.Contains(files.Extension.ToLower()))
            {
                listViewVideos.Items.Add(new ListViewItem(new string[] { files.Name, files.Extension }));
                listViewVideos.Items[listViewVideos.Items.Count - 1].ToolTipText = files.FullName;
                imageListVideos.Images.Add(temp);
                listViewVideos.Items[listViewVideos.Items.Count - 1].ImageIndex = imageListVideos.Images.Count - 1;
            }
            if (othersExt.Contains(files.Extension.ToLower()))//others
            {
                listViewOthers.Items.Add(new ListViewItem(new string[] { files.Name, files.Extension }));
                listViewOthers.Items[listViewOthers.Items.Count - 1].ToolTipText = files.FullName;
                imageListOthers.Images.Add(temp);
                listViewOthers.Items[listViewOthers.Items.Count - 1].ImageIndex = imageListOthers.Images.Count - 1;
            }
        }

        private ListView RemoveDup(ListView listView)
        {
            for (int i = 0; i < listView.Items.Count; i++)
            {
                for (int j = i + 1; j < listView.Items.Count; j++)
                {
                    if (listView.Items[i].ToolTipText == listView.Items[j].ToolTipText)
                    {
                        listView.Items.RemoveAt(j);
                    }
                }
            }
            return listView;
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxSearch.Text != String.Empty)
                {
                    if (labelStatus.Text != "Done")
                    {
                        typing = true;
                        return;
                    }
                    typing = false;

                    bw = new BackgroundWorker();//prevent do twice
                    bw.DoWork += Bw_DoWork;
                    bw.RunWorkerAsync();
                    bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

                }
            }
            else
            {
                typing = true;

                //listViewFolders.Items.Clear();
                //listViewApps.Items.Clear();
                //listViewDocs.Items.Clear();
                //listViewPhotos.Items.Clear();
                //listViewMusic.Items.Clear();
                //listViewVideos.Items.Clear();
                //listViewOthers.Items.Clear();
                //labelStatus.Text = "Done";
                if (panelDetails.Visible)
                {
                    panelDetails.Hide();
                    this.Width = panelResult.Width + 20;
                }
                //for (int i = 0; i < panelAll.Controls.Count; i++)
                //{
                //    panelAll.Controls[i].Dispose();

                //}
                //pos = 0;
                //panelAll.Controls.Clear();
            }
        }



        private void listViewAll_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView1 = (ListView)sender;
            try
            {
                if (listView1.FocusedItem != null)
                {
                    if (!panelDetails.Visible)
                    {
                        this.Width += panelDetails.Width;
                        panelDetails.Show();
                    }
                    labelName.Text = listView1.FocusedItem.Text;
                    labelPath.Text = listView1.FocusedItem.ToolTipText;
                    if (Directory.Exists(labelPath.Text))
                    {
                        pictureBox1.Image = global::XShort.Properties.Resources.dir;
                        DirectoryInfo info = new DirectoryInfo(labelPath.Text);
                        labelType.Text = "File folder";
                        labelDateCreated.Text = info.CreationTime.ToLongDateString();
                        labelDateMod.Text = info.LastWriteTime.ToLongDateString();
                        labelDateAccess.Text = info.LastAccessTime.ToLongDateString();
                    }
                    else if (File.Exists(labelPath.Text))
                    {
                        pictureBox1.Image = Icon.ExtractAssociatedIcon(labelPath.Text).ToBitmap();
                        FileInfo info = new FileInfo(labelPath.Text);
                        labelType.Text = info.Extension;
                        labelDateCreated.Text = info.CreationTime.ToLongDateString();
                        labelDateMod.Text = info.LastWriteTime.ToLongDateString();
                        labelDateAccess.Text = info.LastAccessTime.ToLongDateString();
                    }
                    else
                    {
                        pictureBox1.Image = global::XShort.Properties.Resources.question_help_mark_balloon_512;

                        labelType.Text = "This file is deleted or moved";
                        labelDateCreated.Text = "N/A";
                        labelDateMod.Text = "N/A";
                        labelDateAccess.Text = "N/A";
                    }
                    pictureBox1.Refresh();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView1 = (ListView)sender;
            if (listView1.FocusedItem != null)
            {
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listView1.FocusedItem.ToolTipText;
                    proc.WorkingDirectory = Path.GetDirectoryName(listView1.FocusedItem.ToolTipText);
                    Process.Start(proc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = labelPath.Text;
                proc.WorkingDirectory = Path.GetDirectoryName(labelPath.Text);
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenFileLoc_Click(object sender, EventArgs e)
        {
            string argument = "/select, \"" + labelPath.Text + "\"";
            Process.Start("explorer.exe", argument);
        }

        private void buttonProperties_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.ShowFileProperties(labelPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonSearchInternet_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/search?q=" + textBoxSearch.Text);
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            System.Collections.Specialized.StringCollection collection = new System.Collections.Specialized.StringCollection();
            collection.Add(labelPath.Text);
            Clipboard.SetFileDropList(collection);
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            byte[] moveEffect = new byte[] { 2, 0, 0, 0 };
            MemoryStream dropEffect = new MemoryStream();
            dropEffect.Write(moveEffect, 0, moveEffect.Length);

            System.Collections.Specialized.StringCollection collection = new System.Collections.Specialized.StringCollection();
            collection.Add(labelPath.Text);
            DataObject data = new DataObject();
            data.SetFileDropList(collection);
            data.SetData("Preferred DropEffect", dropEffect);

            Clipboard.Clear();
            Clipboard.SetDataObject(data, true);

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (File.Exists(labelPath.Text))
            {
                if (MessageBox.Show("Are you sure want to permanently delete this file?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(labelPath.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            typing = true;
            listViewFolders.Items.Clear();
            listViewApps.Items.Clear();
            listViewDocs.Items.Clear();
            listViewPhotos.Items.Clear();
            listViewMusic.Items.Clear();
            listViewVideos.Items.Clear();
            listViewOthers.Items.Clear();
            imageListFolder.Images.Clear();
            imageListApps.Images.Clear();
            imageListDocs.Images.Clear();
            imageListPhotos.Images.Clear();
            imageListMusic.Images.Clear();
            imageListOthers.Images.Clear();
            imageListVideos.Images.Clear();
            labelStatus.Text = "Done";
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewAll_MouseClick(sender, null);
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listViewAll_MouseDoubleClick(sender, null);
            }
        }

        private int sortColumn = -1;
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listView.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView.Sorting == SortOrder.Ascending)
                    listView.Sorting = SortOrder.Descending;
                else
                    listView.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            listView.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listView.Sorting);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            buttonSearchInternet.Text = textBoxSearch.Text + " - See web result";
        }
    }


}
