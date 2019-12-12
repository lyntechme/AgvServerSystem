using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace AgvServerSystem
{
    public class ImageToByteOperate
    {
        public List<byte> ImageToByte(string titleStr)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = titleStr;
            ofd.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP|*.PNG|*.PNG";
            List<byte> lsB = new List<byte>();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fullpath = ofd.FileName;//文件路径

                FileStream fs = new FileStream(fullpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                byte[] imagebytes = new byte[fs.Length];

                BinaryReader br = new BinaryReader(fs);

                imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                lsB.AddRange(imagebytes);
            }
            else
            {
                lsB = null;
            }
            return lsB;
        }
    }
}
