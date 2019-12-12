using System;
using System.Collections.Generic;
using System.Text;

namespace AgvPLCUtils
{
    public static class CheckHelper
    {
        /// <summary>
        /// ASCII字符串异或
        /// </summary>
        /// <param name="ascii"></param>
        /// <param name="cmdIndex"></param>
        /// <returns></returns>
        public static string AsciiXorToString(string ascii, int cmdIndex)
        {
            //byte[] checkByte = Encoding.Default.GetBytes(ascii);
            char[] check = ascii.ToCharArray();
            int k = 0;
            for (int i = cmdIndex; i < check.Length; i++)
            {
                if (i == cmdIndex)
                {
                    k = check[i];
                }
                else if (i > cmdIndex)
                {
                    k = k ^ check[i];
                }

            }
            string hexResult = string.Format("{0:X}", k % 256);//保证得到一个字节长度的值
            if (hexResult.Length == 1)
            {
                hexResult = string.Format("0{0}", hexResult);
            }
            return hexResult;
        }
    }
}
