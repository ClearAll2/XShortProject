using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace XShort
{
    public partial class Settings : Form
    {
        RegistryKey r;
        RegistryKey r1;
        global::ModifierKeys gmk;
        Keys k;
        public Settings()
        {
            InitializeComponent();
            loadSettings();
        }

        private void loadSettings()
        {
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (r == null)
                r = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\Data");

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));

            //new register hook key
            if (r.GetValue("HKey") != null)
            {
                string hkey = (string)r.GetValue("HKey");
                k = (Keys)converter.ConvertFromString(hkey);
                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (comboBox2.Items[i].ToString() == hkey)
                    {
                        comboBox2.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                k = Keys.A;
                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (comboBox2.Items[i].ToString() == "A")
                    {
                        comboBox2.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (r.GetValue("Alt") != null)
            {
                radioButtonAlt.Checked = true;
                // hook.RegisterHotKey(global::ModifierKeys.Alt, k);
                gmk = global::ModifierKeys.Alt;
            }
            else if (r.GetValue("Shift") != null)
            {
                radioButtonShift.Checked = true;
                //hook.RegisterHotKey(global::ModifierKeys.Shift, k);
                gmk = global::ModifierKeys.Shift;
            }
            else if (r.GetValue("Ctrl") != null)
            {
                radioButtonControl.Checked = true;
                //hook.RegisterHotKey(global::ModifierKeys.Control, k);
                gmk = global::ModifierKeys.Control;
            }
            else //default value
            {
                radioButtonAlt.Checked = true;
                // hook.RegisterHotKey(global::ModifierKeys.Alt, k);
                gmk = global::ModifierKeys.Alt;
            }
            //
            if (r.GetValue("Hide") != null)
                checkBox2.Checked = true;
            if (r.GetValue("ggSearch") != null)
                checkBox3.Checked = true;
            if (r.GetValue("Case-sen") != null)
                checkBox4.Checked = true;
            if (r.GetValue("Tray") != null)
                checkBox5.Checked = true;
            if (r.GetValue("Detect") != null)
                checkBox7.Checked = true;
            if (r.GetValue("DontLoad") != null)
                checkBox8.Checked = true;

            

            r.Close();
            r.Dispose();


            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (r.GetValue("XShort") != null)
            {
                if (r.GetValue("XShort").ToString().Contains(Application.ExecutablePath))
                {
                    checkBox1.Checked = true;
                }
            }
            r.Close();
            r.Dispose();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.Animate(panelHotkey, Util.Effect.Slide, 100, 180);
            panelHotkey.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Util.Animate(panelHotkey, Util.Effect.Slide, 100, 180);
            panelHotkey.Visible = false;
        }

        private void radioButtonAlt_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButtonAlt.Checked)
            {
                r1.SetValue("Alt", true);
                r1.DeleteValue("Ctrl", false);
                r1.DeleteValue("Shift", false);
            }

            r1.Close();
            r1.Dispose();
        }

        private void radioButtonControl_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButtonControl.Checked)
            {
                r1.SetValue("Ctrl", true);
                r1.DeleteValue("Alt", false);
                r1.DeleteValue("Shift", false);
            }

            r1.Close();
            r1.Dispose();
        }

        private void radioButtonShift_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButtonShift.Checked)
            {
                r1.SetValue("Shift", true);
                r1.DeleteValue("Ctrl", false);
                r1.DeleteValue("Alt", false);
            }

            r1.Close();
            r1.Dispose();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);


            r1.SetValue("HKey", comboBox2.Text);


            r1.Close();
            r1.Dispose();

            panelHotkey.Hide();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string cmd = Application.ExecutablePath + " startup";
            if (checkBox1.Checked)
            {
                r1.SetValue("XShort", cmd);
            }
            else
            {
                r1.DeleteValue("XShort", false);

            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox2.Checked)
            {
                r1.SetValue("Hide", true);
            }
            else
            {
                r1.DeleteValue("Hide", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox3.Checked)
            {
                r1.SetValue("ggSearch", true);
            }
            else
            {
                r1.DeleteValue("ggSearch", false);
            }
            r1.Close();
            r1.Dispose();

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox4.Checked)
            {
                r1.SetValue("Case-sen", true);
            }
            else
            {
                r1.DeleteValue("Case-sen", false);
            }
            r1.Close();
            r1.Dispose();

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox5.Checked)
            {
                //notifyIcon1.Visible = false;
                r1.SetValue("Tray", true);
            }
            else
            {
                //notifyIcon1.Visible = true;
                r1.DeleteValue("Tray", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox7.Checked)
            {
                r1.SetValue("Detect", true);

            }
            else
            {
                r1.DeleteValue("Detect", false);
            }
            r1.Close();
            r1.Dispose();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox8.Checked)
            {
                r1.SetValue("DontLoad", true);

            }
            else
            {
                r1.DeleteValue("DontLoad", false);
            }
            r1.Close();
            r1.Dispose();
        }
    }
}
