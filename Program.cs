using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime;

namespace XShort
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static String _fileName = "";
        public static String FileName
        {
            set
            {
                _fileName = value;
            }
            get
            {
                return _fileName;
            }
        }
        private static Mutex m_Mutex;
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length > 0)
            {
                _fileName = args[0];
            }
            ProfileOptimization.SetProfileRoot(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort"));            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_Mutex = new Mutex(true, "XShort");

            if (m_Mutex.WaitOne(0, false))
            {
                Application.Run(new MainForm());
            }
            else
            {
                //MessageBox.Show("XShort is already running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                if (args.Length > 0)
                {
                    NativeMethods.PostMessage(
                        (IntPtr)NativeMethods.HWND_BROADCAST,
                        NativeMethods.WM_NEWSETTINGS,
                        IntPtr.Zero,
                        IntPtr.Zero);
                }
                else
                {
                    NativeMethods.PostMessage(
                        (IntPtr)NativeMethods.HWND_BROADCAST,
                        NativeMethods.WM_SHOWME,
                        IntPtr.Zero,
                        IntPtr.Zero);
                }
                return;
            }
        }
    }
}
