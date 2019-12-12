using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgvServerSystem
{
    static class DataConvert
    {
        public static string IntToTimeString(int i)
        {
            if (i > 0)
            {
                int hours = i / 3600;
                int minutes = i % 3600 / 60;
                int seconds = i % 3600 % 60;
                StringBuilder str = new StringBuilder();
                str.Append(hours.ToString() + ":");
                str.Append(minutes.ToString("D2") + ":");
                str.Append(seconds.ToString("D2"));
                return str.ToString();
            }
            else
            {
                return "00:00:00";
            }
        }
        public static string StringToTimeString(string s)
        {
            try
            {
                int i = Convert.ToInt32(s);
                if (i > 0)
                {
                    int hours = i / 3600;
                    int minutes = i % 3600 / 60;
                    int seconds = i % 3600 % 60;
                    StringBuilder str = new StringBuilder();
                    str.Append(hours.ToString() + ":");
                    str.Append(minutes.ToString("D2") + ":");
                    str.Append(seconds.ToString("D2"));
                    return str.ToString();
                }
                else
                {
                    return "00:00:00";
                }
            }
            catch (Exception ex)
            {
                return "时间出错";
            }
        }
    }
}
