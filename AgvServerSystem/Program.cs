using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AgvServerSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]


        //[DllImport("coredll", EntryPoint = "FindWindow")]
        //public static extern int FindWindow(
        //    string IpWindowName,
        //    string IpClassName
        //    );
        //public const int SW_SHOW = 5;
        //public const int SW_HIDE = 0;
        //[DllImport("coredll", EntryPoint = "ShowWindow")]
        //public static extern int ShowWindow(
        //    int hwnd,
        //    int nCmdShow
        //    );

        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //int Hwnd = FindWindow("Shell_TrayWnd", null);
            //if (Hwnd != 0)
            //{
            //    ShowWindow(Hwnd, SW_HIDE);
            //    //Application.Run(new MainForm());

            bool fistApplicationInstance;
            string mutexName = Assembly.GetEntryAssembly().FullName;
            using (Mutex mutex = new Mutex(false, mutexName, out fistApplicationInstance))
            {
                if (fistApplicationInstance)
                {
                    Application.Run(new MainForm());
                    //Application.Run(new LoginBufferForm());
                }
                else
                {
                    MessageBox.Show("The soft has been opened. Please do not restart it again！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //    ShowWindow(Hwnd, SW_SHOW);
            //}
        }
    }
}
