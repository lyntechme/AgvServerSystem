using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 文件夹操作类
    /// </summary>
    public static class FolderHelper
    {
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="sourceFolderName">源文件夹目录</param>
        /// <param name="targetFolderName">目标文件夹目录</param>
        public static bool Copy(string sourceFolderName, string targetFolderName)
        {
            return Copy(sourceFolderName, targetFolderName, false);
        }
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="sourceFolderName">源文件夹目录</param>
        /// <param name="targetFolderName">目标文件夹目录</param>
        /// <param name="overwrite">允许覆盖文件</param>
        public static bool Copy(string sourceFolderName, string targetFolderName, bool overwrite)
        {
            bool isOK = false;
            try
            {
                var sourceFilesPath = Directory.GetFileSystemEntries(sourceFolderName);
                for (int i = 0; i < sourceFilesPath.Length; i++)
                {
                    var sourceFilePath = sourceFilesPath[i];
                    var directoryName = Path.GetDirectoryName(sourceFilePath);
                    var forlders = directoryName.Split('\\');
                    var lastDirectory = forlders[forlders.Length - 1];
                    var dest = Path.Combine(targetFolderName, lastDirectory);
                    if (File.Exists(sourceFilePath))
                    {
                        var sourceFileName = Path.GetFileName(sourceFilePath);
                        if (!Directory.Exists(dest))
                        {
                            Directory.CreateDirectory(dest);
                        }
                        File.Copy(sourceFilePath, Path.Combine(dest, sourceFileName), overwrite);
                    }
                    else
                    {
                        //Copy(
                    }
                }
                isOK = true;
            }
            catch { }
            return isOK;
        }
    }
}
