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
            label1.Text = "XShort Core v" + Application.ProductVersion + " build " + this.AssemblyDescription + "\nCopyright © 2021\nXShort Project\nFreedom Software";
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
    }
}
