using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace XShort
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            RegistryKey r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r.GetValue("Beta") != null)
            {
                button3.BackColor = Color.Red;
                button3.Text = "Leave the Beta Test Program";
            }
            r.Close();
            label1.Text = "XShort v" + Application.ProductVersion /*+ " build " + this.AssemblyDescription*/ + "\nCopyright © 2018 - 2019\nXShort Project\nFreedom Software";
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHomepage_Click(object sender, EventArgs e)
        {
            Process.Start("https://myfreedom.cf");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (button3.BackColor != Color.Red)
            {
                button3.BackColor = Color.Red;
                button3.Text = "Leave the Beta Test Program";
                r1.SetValue("Beta", true);
            }
            else
            {
                if (MessageBox.Show("Are you sure want to leave the Beta Test Program?", "What say you?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("We hope you will come back soon!", "So Sad!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button3.BackColor = Color.SlateBlue;
                    button3.Text = "Join the Beta Test Program";
                    r1.DeleteValue("Beta", false);
                }
            }
            r1.Close();
            r1.Dispose();
        }
    }
}
