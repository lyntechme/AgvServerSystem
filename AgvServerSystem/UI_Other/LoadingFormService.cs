using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgvServerSystem
{
    public class LoadingFormService
    {
        public static LoadingFormService Instance
        {
            get
            {
                if (LoadingFormService._instance == null)
                {
                    lock (sysncLock)
                    {
                        if (LoadingFormService._instance == null)
                        {
                            LoadingFormService._instance = new LoadingFormService();
                        }
                    }
                }
                return LoadingFormService._instance;
            }
        }
        private LoadingFormService()
        { }
        private static LoadingFormService _instance;
        private static readonly object sysncLock = new object();
        private Thread loadingThread;
        private static LoadingForm loadingForm;
        /// <summary>
        /// 显示等待窗口
        /// </summary>
        public static void Show()
        {
            LoadingFormService.Instance._CreateForm();
        }
        /// <summary>
        /// 关闭等待窗口
        /// </summary>
        public static void Close()
        {
            Thread.Sleep(100);
            LoadingFormService.Instance._CloseForm();
        }
        /// <summary>
        /// 设置等待窗体标题
        /// </summary>
        /// <param name="text"></param>
        public static void SetText(string text)
        {
            LoadingFormService.Instance.SetLoadingeText(text);
        }
        /// <summary>
        /// 创建等待窗体
        /// </summary>
        public void _CreateForm()
        {
            loadingForm = null;
            loadingThread = new Thread(new ThreadStart(this._ShowLoadingForm));
            loadingThread.Start();
            Thread.Sleep(100);
        }
        private void _ShowLoadingForm()
        {
            try
            {
                loadingForm = new LoadingForm();
                try
                {
                    loadingForm.ShowDialog();
                    //Application.Run();
                }
                finally {
                    loadingForm.Dispose();
                }
            }
            catch (ThreadAbortException e)
            {
                loadingForm.Close();
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
            if (loadingThread != null)
            {
                loadingForm.Close();
            }

        }
        /// <summary>
        /// 设置窗体标题
        /// </summary>
        /// <param name="text"></param>
        public void SetLoadingeText(string text)
        {
            if (loadingForm != null)
            {
                try
                {
                    loadingForm.Show();
                    loadingForm.SetText(text);
                }
                catch (Exception ex)
                { }

            }
        }
    }
}
