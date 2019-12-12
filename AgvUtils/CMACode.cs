/****************************************************************/
//fins读写PLC数据命令
//创建：2014-12-18
//修改：
//简介：
//欧姆龙PLC的fins控制指令
/****************************************************************/





namespace AgvPLCUtils
{
    /// <summary>
    /// Agv内存操作命令
    /// </summary>
    public class CMACode
    {
        #region MAC命令代码
        /// <summary>
        /// 对PLC的IO地址的读写操作命令（按位读写）
        /// </summary>
        public static readonly string CIOb = "30";
        /// <summary>
        /// 对PLC的work区的读写操作命令（按位读写）
        /// </summary>
       public static readonly string  WRb = "31";
        /// <summary>
        /// 对PLC的Holding区的读写操作命令（按位读写）
        /// </summary>
       public static readonly string  HRb = "32";
        /// <summary>
        /// 对PLC的Auxiliary区的读写操作命令（按位读写）
        /// </summary>
       public static readonly string  ARb = "33";
        /// <summary>
        /// 对PLC的IO地址的读写操作命令（按字读写）
        /// </summary>
       public static readonly string  CIOw = "B0";
        /// <summary>
        /// 对PLC的work区的读写操作命令（按字读写）
        /// </summary>
       public static readonly string  WRw = "B1";
        /// <summary>
        /// 对PLC的Holding区的读写操作命令（按字读写）
        /// </summary>
       public static readonly string  HRw = "B2";
        /// <summary>
        /// 对PLC的Auxiliary区的读写操作命令（按字读写） 
        /// </summary>
       public static readonly string  ARw = "B3";
        /// <summary>
        /// 对PLC的定时器的标志操作命令
        /// </summary>
       public static readonly string  TIM = "09";
        /// <summary>
        /// 对PLC的定时器的值操作命令
        /// </summary>
       public static readonly string  CNT = "89";
        /// <summary>
        /// 对PLC的D寄存器的读写操作命令（按位读写）
        /// </summary>
       public static readonly string  DMb = "02";
        /// <summary>
        /// 对PLC的D寄存器的读写操作命令（按字读写）
        /// </summary>
       public static readonly string  DMw = "82";
       public static readonly string  EMb0 = "20";
       public static readonly string  EMb1 = "21";
       public static readonly string  EMb2 = "22";
       public static readonly string  EMb3 = "23";
       public static readonly string  EMb4 = "24";
       public static readonly string  EMb5 = "25";
       public static readonly string  EMb6 = "26";
       public static readonly string  EMb7 = "27";
       public static readonly string  EMb8 = "28";
       public static readonly string  EMb9 = "29";
       public static readonly string  EMbA = "2A";
       public static readonly string  EMbB = "2B";
       public static readonly string  EMbC = "2C";
       public static readonly string  EMbD = "2D";
       public static readonly string  EMbE = "2E";
       public static readonly string  EMbF = "2F";
       public static readonly string  EMb10 = "E0";
       public static readonly string  EMb11 = "E1";
       public static readonly string  EMb12 = "E2";
       public static readonly string  EMb13 = "E3";
       public static readonly string  EMb14 = "E4";
       public static readonly string  EMb15 = "E5";
       public static readonly string  EMb16 = "E6";
       public static readonly string  EMb17 = "E7";
       public static readonly string  EMb18 = "E8";
       public static readonly string  EMw0 = "50";
       public static readonly string  EMw1 = "51";
       public static readonly string  EMw2 = "52";
       public static readonly string  EMw3 = "53";
       public static readonly string  EMw4 = "54";
       public static readonly string  EMw5 = "55";
       public static readonly string  EMw6 = "56";
       public static readonly string  EMw7 = "57";
       public static readonly string  EMw8 = "58";
       public static readonly string  EMw9 = "59";
       public static readonly string  EMwA = "5A";
       public static readonly string  EMwB = "5B";
       public static readonly string  EMwC = "5C";
       public static readonly string  EMwD = "5D";
       public static readonly string  EMwE = "5E";
       public static readonly string  EMwF = "5F";
       public static readonly string  EMw10 = "60";
       public static readonly string  EMw11 = "61";
       public static readonly string  EMw12 = "62";
       public static readonly string  EMw13 = "63";
       public static readonly string  EMw14 = "64";
       public static readonly string  EMw15 = "65";
       public static readonly string  EMw16 = "66";
       public static readonly string  EMw17 = "67";
       public static readonly string  EMw18 = "68";
       public static readonly string  EMcbb = "0A";
       public static readonly string  EMcbw = "98";
       public static readonly string  EMcbN = "BC";
       public static readonly string  TKb = "06";
       public static readonly string  TKS = "46";
       public static readonly string  IRP = "DC";
       public static readonly string  DRP = "BC";
        #endregion
    }
}
