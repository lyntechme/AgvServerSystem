using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 充电桩信息
    /// </summary>
    public class ChargeInfo
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public ChargeInfo()
        {
            this.BeginTime = new DateTime();
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int ChargeNo { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ChargeName { get; set; }
        /// <summary>
        /// 充电桩类型
        /// </summary>
        public EChargeType ChargeType { get; set; }
        /// <summary>
        /// 充电桩通讯参数
        /// </summary>
        public ChargeCommunication ChargeComm { get; set; }
        /// <summary>
        /// 充电桩对应RFID编号
        /// </summary>
        public int Rfid { get; set; }
        /// <summary>
        /// 充电桩状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 充电开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 组别
        /// </summary>
        public int Group { get; set; }
        /// <summary>
        /// 绑定agv
        /// </summary>
        public int BindAgv { get; set; }
    }
    /// <summary>
    /// 充电桩类型
    /// </summary>
    public enum EChargeType
    {
        /// <summary>
        /// 充电桩类型1
        /// </summary>
        CapacityTest = 0,
        /// <summary>
        /// 充电桩类型2
        /// </summary>
        PreAging = 1,
        /// <summary>
        /// 充电桩类型3
        /// </summary>
        CapacityAging = 2,
    }
    /// <summary>
    /// 充电桩状态
    /// </summary>
    public enum EChargeCommState
    {
        /// <summary>
        /// 连接断开
        /// </summary>
        OffLine = 0,
        /// <summary>
        /// 伸出
        /// </summary>
        Output = 1,
        /// <summary>
        /// 缩进
        /// </summary>
        Input = 2,
        /// <summary>
        /// 未到位
        /// </summary>
        Loading = 3,
    }
}
