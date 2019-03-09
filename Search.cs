using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XShort
{
    public partial class Search : Form
    {
        bool typing = false;
        BackgroundWorker bw = new BackgroundWorker();
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
        ImageList img = new ImageList();
        public Search(string kw)
        {
            
            InitializeComponent();
            textBoxSearch.Text = kw;
            listView1.SmallImageList = img;
            img.ImageSize = new Size(40, 40);
            img.ColorDepth = ColorDepth.Depth32Bit;
            this.Left = 0;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;


            buttonSearchInternet.Text = kw + " - See web result";

            
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();

            panelDetails.Hide();
            this.Width = panelResult.Width + 20;
        }

        

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            listView1.Items.Clear();
            img.Images.Clear();
            img.Dispose();
            img = new ImageList();
            img.ImageSize = new Size(40, 40);
            img.ColorDepth = ColorDepth.Depth32Bit;
            listView1.SmallImageList = img;
            indexSearch(textBoxSearch.Text);
        }

        

        

        private void indexSearch(string keyword)
        {
            
            labelStatus.Text = "Searching...";
            if (typing)
                return;
            StreamReader sr = new StreamReader(path + "\\indexFol");
            while (!sr.EndOfStream)
            {
                string read = sr.ReadLine();
                if (read.Substring(read.LastIndexOf("\\") + 1).ToLower().Contains(keyword.ToLower()))
                {
                    DirectoryInfo info = new DirectoryInfo(read);
                    listView1.Items.Add(new ListViewItem(new string[] { info.Name}));
                    if (Directory.Exists(read))
                    {
                        img.Images.Add(Properties.Resources.dir);
                    }
                    else if (File.Exists(read))
                    {
                        img.Images.Add(Icon.ExtractAssociatedIcon(read));
                    }
                    else
                    {
                        img.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }
                    listView1.Items[listView1.Items.Count - 1].ImageIndex = img.Images.Count - 1;
                    listView1.Items[listView1.Items.Count - 1].ToolTipText = info.FullName;
                }
                if (typing)
                    goto toend;
            }
            sr.Close();
            sr.Dispose();

            //
            sr = new StreamReader(path + "\\indexFil");
            while (!sr.EndOfStream)
            {
                string read = sr.ReadLine();
                if (read.Substring(read.LastIndexOf("\\") + 1).ToLower().Contains(keyword.ToLower()))
                {
                    FileInfo files = new FileInfo(read);
                    listView1.Items.Add(new ListViewItem(new string[] { files.Name }));
                    if (Directory.Exists(read))
                    {
                        img.Images.Add(Properties.Resources.dir);
                    }
                    else if (File.Exists(read))
                    {
                        img.Images.Add(Icon.ExtractAssociatedIcon(read));
                    }
                    else
                    {
                        img.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }
                    listView1.Items[listView1.Items.Count - 1].ImageIndex = img.Images.Count - 1;
                    listView1.Items[listView1.Items.Count - 1].ToolTipText = files.FullName;

                }
                if (typing)
                    goto toend;
            }

            toend:
            sr.Close();
            sr.Dispose();

            labelStatus.Text = "Done";
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            typing = true;
            listView1.Items.Clear();
            labelStatus.Text = "Done";
            if (panelDetails.Visible)
            {
                panelDetails.Hide();
                this.Width = panelResult.Width + 20;
            }

        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxSearch.Text != String.Empty)
            {
                typing = false;
                
                buttonSearchInternet.Text = textBoxSearch.Text + " - See web result";
                bw = new BackgroundWorker();
                bw.DoWork += Bw_DoWork;
                bw.RunWorkerAsync();
                
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
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

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == String.Empty)
            {
                panelDetails.Hide();
                this.Width = panelResult.Width + 20;
                listView1.Items.Clear();
                img.Images.Clear();
                img.Dispose();
                img = new ImageList();
                img.ImageSize = new Size(40, 40);
                img.ColorDepth = ColorDepth.Depth32Bit;
                listView1.SmallImageList = img;
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
    }
}
