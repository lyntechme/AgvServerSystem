/*=============================================================================*/
//fins读写PLC区域命令
//创建：2014-12-18
//修改：
//简介：
//欧姆龙PLC的fins控制指令
/*=============================================================================*/


using System;

namespace AgvPLCUtils
{
    /// <summary>
    /// Agv控制命令
    /// </summary>
    public class CFinsCmdCode
    {
        #region 读写PLC数据指令字符串
        /// <summary>
        /// 读取PLC数据指令字符
        /// </summary>
       public static readonly string  MAR = "0101";
        /// <summary>
        /// 向PLC写入数据指令字符
        /// </summary>
       public static readonly string  MAW = "0102";
       public static readonly string  MAF = "0103";
       public static readonly string  MMAR = "0104";
       public static readonly string  MAT = "0105";
       public static readonly string  PAAR = "0201";
       public static readonly string  PAAW = "0202";
       public static readonly string  PAAC = "0203";
       public static readonly string  PRAR = "0306";
       public static readonly string  PRAW = "0307";
       public static readonly string  PRAC = "0308";
       public static readonly string  RUN = "0401";
       public static readonly string  STOP = "0402";
       public static readonly string  CUDR = "0501";
       public static readonly string  CDR = "0502";
       public static readonly string  CUSR = "0601";
       public static readonly string  CTR = "0620";
       public static readonly string  CR = "0701";
       public static readonly string  CW = "0702";
       public static readonly string  MR = "0920";
       public static readonly string  MC = "0920";
       public static readonly string  FR = "0920";
       public static readonly string  ARA = "0C01";
       public static readonly string  ARFA = "0C02";
       public static readonly string  ARR = "0C03";
       public static readonly string  EC = "2101";
       public static readonly string  ELR = "2102";
       public static readonly string  ELC = "2103";
       public static readonly string  FWALR = "2140";
       public static readonly string  FWALC = "2141";
       public static readonly string  FNR = "2201";
       public static readonly string  SFR = "2202";
       public static readonly string  SFW = "2203";
       public static readonly string  FMF = "2204";
       public static readonly string  FD = "2205";
       public static readonly string  FC = "2207";
       public static readonly string  FNC = "2208";
       public static readonly string  MAFT = "220A";
       public static readonly string  PAFT = "2208";
       public static readonly string  PRAFT = "220C";
       public static readonly string  CDD = "2215";
       public static readonly string  MCT = "2220";
       public static readonly string  FSR = "2301";
       public static readonly string  FSRC = "2302";
       public static readonly string  CTCC = "2803";
       public static readonly string  CTMRC = "2804";
       public static readonly string  CTMAC = "2805";
        #endregion
    }
}