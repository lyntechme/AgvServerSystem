using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 充电桩通讯参数信息
    /// </summary>
    public class ChargeCommunication
    {
        public ChargeCommunication()
        {
            this.isLowComm = true;
        }
        ///// <summary>
        ///// 充电桩编号
        ///// </summary>
        //public int ChargeNo { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        public string IpString { get; set; }
        /// <summary>
        /// 源/目的端口号
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 低流量访问（即延长访问间隔时间，达到降低网络流量的效果），当有AGV请求状态时，将交互间隔时间缩短
        /// </summary>
        public bool isLowComm { get; set; }
        /// <summary>
        /// 通讯使能
        /// </summary>
        public bool Enable { get; set; }
    }
}
