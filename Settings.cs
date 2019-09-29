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

        private void changeLang(bool en)
        {
            if (!en)
            {
                checkBox1.Text = "Khởi động cùng Windows";
                checkBox2.Text = "Ẩn cửa sổ khi mở";
                checkBox3.Text = "Tự động tìm kiếm nếu không có dữ liệu";
                checkBox4.Text = "Phân biệt hoa - thường";
                checkBox5.Text = "Ẩn biểu tượng khay";
                checkBox6.Text = "Tự động chạy trình tạo mục lục";
                checkBox7.Text = "Tự động phát hiện lối tắt không khả dụng";
                checkBox8.Text = "Không tải danh sách chính khi mở";

                radioButton1.Text = "Tiếng Anh";
                radioButton2.Text = "Tiếng Việt";
                radioButton3.Text = "Tối";
                radioButton4.Text = "Sáng";
                radioButton5.Text = "Tự động";

                buttonClose.Text = "Đóng";
                button14.Text = "Áp dụng";
                button15.Text = "Hủy";

                groupBox1.Text = "Chung";
                groupBox2.Text = "Ngôn ngữ";
                groupBox3.Text = "Nền";
                labelHotKeyConfig.Text = "Cài đặt phím tắt XShort Run";
                linkLabel1.Text = "Nâng cao";

            }
            else
            {
                checkBox1.Text = "Run at Windows startup";
                checkBox2.Text = "Hide dialog box at startup";
                checkBox3.Text = "Automatically search if no data";
                checkBox4.Text = "Case-sensitive";
                checkBox5.Text = "Hide tray icon";
                checkBox6.Text = "Automatically run indexing";
                checkBox7.Text = "Automatically detect invalid shortcuts";
                checkBox8.Text = "Don't load main list at startup";

                radioButton1.Text = "English";
                radioButton2.Text = "Vietnamese";
                radioButton3.Text = "Dark";
                radioButton4.Text = "Light";
                radioButton5.Text = "Auto";

                buttonClose.Text = "Close";
                button14.Text = "Apply";
                button15.Text = "Cancel";

                groupBox1.Text = "General";
                groupBox2.Text = "Languages";
                groupBox3.Text = "Skin";
                labelHotKeyConfig.Text = "XShort Run Hotkey Configuration";
                linkLabel1.Text = "Advanced";
            }
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
            if (r.GetValue("Indexing") != null)
                checkBox6.Checked = true;
            if (r.GetValue("DontLoad") != null)
                checkBox8.Checked = true;

            if (r.GetValue("Dark") != null)
            {
                radioButton3.Checked = true;


            }
            else if (r.GetValue("Light") != null)
            {
                radioButton4.Checked = true;
            }
            else
            {
                radioButton5.Checked = true;
            }

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


            //never put this to top, must create form before check language!
            r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);

            if (r.GetValue("EN") != null)
            {
                radioButton1.Checked = true;
                changeLang(true);
            }
            else
            {
                radioButton2.Checked = true;
                changeLang(false);
            }
            r.Close();
            r.Dispose();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButton3.Checked)
            {
                r1.SetValue("Dark", true);
                r1.DeleteValue("Light", false);
                r1.DeleteValue("DaL", false);
            }
            r1.Close();
            r1.Dispose();

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButton4.Checked)
            {
                r1.SetValue("Light", true);
                r1.DeleteValue("Dark", false);
                r1.DeleteValue("DaL", false);
            }

            r1.Close();
            r1.Dispose();

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButton5.Checked)
            {
                r1.SetValue("DaL", true);
                r1.DeleteValue("Dark", false);
                r1.DeleteValue("Light", false);
            }


            r1.Close();
            r1.Dispose();

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButton1.Checked)
            {
                r1.SetValue("EN", true);
                changeLang(true);
            }

            r1.Close();
            r1.Dispose();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (radioButton2.Checked)
            {
                r1.DeleteValue("EN", false);
                changeLang(false);
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

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\Data", true);
            if (checkBox6.Checked)
            {
                r1.SetValue("Indexing", true);

            }
            else
            {
                r1.DeleteValue("Indexing", false);
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
