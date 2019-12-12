using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StationConnectInfo
    {
        /// <summary>
        /// 通讯端口号
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        public string ipAddress { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descirbe { get; set; }
    }
}
