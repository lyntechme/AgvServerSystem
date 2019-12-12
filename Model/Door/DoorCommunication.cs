using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 房门通讯参数信息
    /// </summary>
    public class DoorCommunication
    {
        public DoorCommunication()
        { }
        /// <summary>
        /// 编号
        /// </summary>
        public int DoorNo { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 源/目的端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 通讯使能
        /// </summary>
        public bool Enable { get; set; }
    }
}
