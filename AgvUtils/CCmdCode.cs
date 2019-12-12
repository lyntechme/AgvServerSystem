/*=============================================================================*/
//fins读写PLC命令字符串
//创建：2014-12-22
//修改：
//简介：
//欧姆龙PLC的fins控制命令字符串，定义fins命令字符串格式
/*=============================================================================*/




namespace AgvPLCUtils
{
    class CCmdCode
    {
        #region 命令字符串定义
        /// <summary>
        /// 信息控制域
        /// </summary>
        public static string icf = "80";
        /// <summary>
        /// 系统保留，常为"00"
        /// </summary>
        public static string rsv = "00";
        /// <summary>
        /// 网关允许数目
        /// </summary>
         public static string gct = "02";                //网关允许数目
        /// <summary>
        /// 目的网络号
        /// </summary>
         public static string dna = "00";                //目的网络号
        /// <summary>
        /// 目的节点号
        /// </summary>
         public static string da1 = "00";                //目的节点号
        /// <summary>
        /// 目的单元号
        /// </summary>
         public static string da2 = "00";                //目的单元号
        /// <summary>
        /// 源网络号
        /// </summary>
         public static string sna = "00";                //源网络号
        /// <summary>
        ///源节点号 
        /// </summary>
         public static string sa1 = "00";                //源节点号
        /// <summary>
        /// 源单元号
        /// </summary>
         public static string sa2 = "00";                //源单元号
        /// <summary>
        /// 服务和响应的标识号，可任意配置，指令和响应对应相同
        /// </summary>
         public static string sid = "00";                //服务和响应的标识号，可任意配置，指令和响应对应相同
        /// <summary>
        /// fins读写指令
        /// </summary>
         public static string m_s_rc = "0101";
        // public static string mrc = "01";            
        // public static string src = "01";                
        /// <summary>
        /// 读写数据的类型：ICO、D(82)、W(B1)等
        /// </summary>
         public static string datatype = "82";           //读写数据的类型：ICO、D(82)、W(B1)
        /// <summary>
        /// 读写起始地址
        /// </summary>
         public static string beginaddress = "000000";
        // public static string friadrh = "00";            //读写起始地址(两字节)高位
        // public static string friadrl = "00";            //低位
        // public static string dnknow = "00";             //比特号,00为字数据
        /// <summary>
        /// 读写数据数目
        /// </summary>
         public static string datalength = "0000";
        // public static string rwcounth = "00";            //读写字数(两字节)高位
        // public static string rwcountl = "00";            //低位
        /// <summary>
        /// fins命令字符串
        /// </summary>
         public static string cmdstring;

        /// <summary>
        /// fins命令函数
        /// </summary>
        /// <returns>fins命令字符串</returns>
         public static string CmdString()
        {
            cmdstring = icf + rsv + gct + dna + da1 + da2 + sna + sa1 + sa2 + sid + m_s_rc + datatype + beginaddress + datalength;
            return cmdstring;
        }
        #endregion

    }
}
