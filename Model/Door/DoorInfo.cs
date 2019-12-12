using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DoorInfo
    {
        public DoorInfo()
        { }
        /// <summary>
        /// 房门名称
        /// </summary>
        public string Name { get; set; }
        public int DoorNo { get; set; }
        /// <summary>
        /// 房门通讯参数
        /// </summary>
        public DoorCommunication DoorComm { get; set; }
        /// <summary>
        /// 房门停止RFID集合（用于当房门没开时，停止AGV运行，等待门开）
        /// </summary>
        public List<int> StopRfids = new List<int>();
        /// <summary>        
        /// 房门当前状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 可使用房门RFID集合(用于到达房门旁边，执行门开命令)
        /// </summary>
        public List<int> CallRfids = new List<int>();
        /// <summary>
        /// 房门关联 
        /// </summary>
        public int Relation { get; set; }
        /// <summary>
        /// 关联序号  即两个关联的房门的排序，房门1、房门2
        /// </summary>
        public byte RelationNumber { get; set; }
        /// <summary>
        /// 绑定AGV编号
        /// </summary>
        public int BindAgv { get; set; }
        /// <summary>
        /// 是否按住开门按钮
        /// </summary>
        public bool HoldSwitch { get; set; }
        /// <summary>
        /// 门状态
        /// </summary>
        public enum EDoorState
        {
            /// <summary>
            /// 连接断开
            /// </summary>
            OffLine = 0,
            /// <summary>
            /// 门开
            /// </summary>
            Open = 1,
            /// <summary>
            /// 门关闭
            /// </summary>
            Close = 2,
            /// <summary>
            /// 门未到位
            /// </summary>
            Loading =3,
        }
    }
}
