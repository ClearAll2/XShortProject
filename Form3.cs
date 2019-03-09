using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XShort
{
    public partial class Form3 : Form
    {
        bool close = false;
        bool en = true;
        public Form3(bool lan)
        {
            InitializeComponent();
            en = lan;
            if (lan)
                circularProgressBar1.Text = "Loading...";
            else
                circularProgressBar1.Text = "Đang tải...";
            
        }

        public void changeLanguge(bool lan)
        {
            en = lan;
        }

        public void changeDisplay(int phase)
        {
            if (phase == 1)
            {
                if (en)
                    circularProgressBar1.Text = "Loading name";
                else
                    circularProgressBar1.Text = "Đang tải xíu";
            }
            else if (phase == 2)
            {
                if (en)
                    circularProgressBar1.Text = "Loading path";
                else
                    circularProgressBar1.Text = "Còn tí nữa";
            }
            else if (phase == 3)
            {
                if (en)
                    circularProgressBar1.Text = "Loading para";
                else
                    circularProgressBar1.Text = "Đang hoàn tất";
            }
            else if (phase == 4)
            {
                if (en)
                    circularProgressBar1.Text = "Saving...";
                else
                    circularProgressBar1.Text = "Đang lưu...";
            }
            else if (phase == 5)
            {
                if (en)
                    circularProgressBar1.Text = "Scanning...";
                else
                    circularProgressBar1.Text = "Đang dò...";
            }
            else if (phase == 6)
            {
                if (en)
                    circularProgressBar1.Text = "Checking...";
                else
                    circularProgressBar1.Text = "Đang kiểm tra...";
            }
        }

        public void closeForm()
        {
            close = true;
            this.Close();
            this.Dispose();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != true)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
