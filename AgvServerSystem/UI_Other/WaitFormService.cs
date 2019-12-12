using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public class WaitFormService
    {
        public static WaitFormService Instance
        {
            get
            {
                if (WaitFormService._instance == null)
                {
                    lock (sysncLock)
                    {
                        if (WaitFormService._instance == null)
                        {
                            WaitFormService._instance = new WaitFormService();
                        }
                    }
                }
                return WaitFormService._instance;
            }
        }
        private WaitFormService()
        { }
        private static WaitFormService _instance;
        private static readonly object sysncLock = new object();
        private Thread waitThread;
        private static WaitForm waitForm;
        /// <summary>
        /// 显示等待窗口
        /// </summary>
        public static void Show()
        {
            WaitFormService.Instance._CreateForm();
        }
        /// <summary>
        /// 关闭等待窗口
        /// </summary>
        public static void Close()
        {
            try
            {
                Thread.Sleep(1000);
                WaitFormService.Instance._CloseForm();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
        /// <summary>
        /// 设置等待窗体标题
        /// </summary>
        /// <param name="text"></param>
        public static void SetText(string text)
        {
            try
            {
                WaitFormService.Instance.SetWaitText(text);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
        public static void SetContents(string contents)
        {
            try
            {
                WaitFormService.Instance.SetWaitContents(contents);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
        /// <summary>
        /// 创建等待窗体
        /// </summary>
        public void _CreateForm()
        {
            waitForm = null;
            waitThread = new Thread(new ThreadStart(this._ShowWaitForm));
            waitThread.Start();
            Thread.Sleep(100);
        }
        private void _ShowWaitForm()
        {
            try
            {
                waitForm = new WaitForm();
                try
                {
                    waitForm.ShowDialog();
                    //Application.Run();
                }
                finally
                {
                    waitForm.Dispose();
                }
            }
            catch (ThreadAbortException e)
            {
                waitForm.Close();
                Thread.ResetAbort();
            }
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void _CloseForm()
        {
            //waitForm.Close();
            //waitForm = null;
            if (waitThread != null)
            {
                waitForm.Close();
            }

        }
        /// <summary>
        /// 设置窗体标题
        /// </summary>
        /// <param name="text"></param>
        public void SetWaitText(string text)
        {
            if (waitForm != null)
            {
                try
                {
                    waitForm.Show();
                    waitForm.SetText(text);
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }

            }
        }
        public void SetWaitContents(string contents)
        {
            if (waitForm != null)
            {
                try
                {
                    waitForm.Show();
                    waitForm.SetParameter(contents);
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }
        }
    }
}
