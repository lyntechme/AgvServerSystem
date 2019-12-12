using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AgvPLCUtils
{
    public class LogUtils
    {
        /// <summary>
        /// 日志文件对象锁
        /// </summary>
        public static object objLog = new object();
        public static string SourcePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        /// <summary>
        /// 系统日志
        /// </summary>
        /// <param name="fileMsg">写入日志的信息</param>
        public static void SaveLog(string fileMsg)
        {
            try
            {
                using (FileStream _fStream = new FileStream(GetFilePath(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter _sWrite = new StreamWriter(_fStream))
                    {
                        _sWrite.WriteLine(GetCurrentTimeString() + fileMsg);
                        _sWrite.Close();
                        _fStream.Close();
                    }
                }
            }
            catch (Exception e)
            {
                SaveLog(fileMsg);
            }
        }

        /// <summary>
        /// 错误日志信息
        /// </summary>
        /// <param name="fileMsg">写入错误日志的内容</param>
        public static void SaveLog1(string fileMsg)
        {
            try
            {
                using (FileStream _fStream = new FileStream(GetFilePath1(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter _sWrite = new StreamWriter(_fStream))
                    {
                        _sWrite.WriteLine(GetCurrentTimeString() + fileMsg);
                        _sWrite.Close();
                        _fStream.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                SaveLog1(fileMsg);
            }
        }

        /// <summary>
        /// AGV异常信息
        /// </summary>
        /// <param name="fileMsg">写入异常日志的内容</param>
        public static void SaveLog2(string fileMsg)
        {
            try
            {
                using (FileStream _fStream = new FileStream(GetFilePath2(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter _sWrite = new StreamWriter(_fStream))
                    {
                        _sWrite.WriteLine(GetCurrentTimeString() + fileMsg);
                        _sWrite.Close();
                        _fStream.Close();
                    }
                }
            }
            catch (Exception)
            {
                SaveLog2(fileMsg);
            }
        }
        private static string GetCurrentTimeString()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "." + DateTime.Now.Millisecond.ToString("000") + "     ";
        }

        private static string GetFilePath()
        {
            string path = SourcePath + @"\SystemLog";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + @"\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Uitls.log";
            //return Application.StartupPath + @"\SystemLog\" + DateTime.Now.ToString() + "_.log";
        }

        private static string GetFilePath1()
        {
            string path = SourcePath + @"\Error";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //string pa = Application.StartupPath + @"\Error\" + DateTime.Now.ToString("yyyyMMdd");
            //if (!Directory.Exists(pa))
            //{
            //    Directory.CreateDirectory(pa);
            //}
            return path + @"\" + DateTime.Now.ToString("yyyy_MM_dd") + "_.log";
            //return Application.StartupPath + @"\SystemLog\" + DateTime.Now.ToString() + "_.log";
        }

        private static string GetFilePath2()
        {
            string path = SourcePath + @"\Abnormal";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + @"\" + DateTime.Now.ToString("yyyy_MM_dd") + "_PLC.log";
            //return Application.StartupPath + @"\SystemLog\" + DateTime.Now.ToString() + "_.log";
        }
    }
}