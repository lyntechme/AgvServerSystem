using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ElevatorInfo
    {
        /// <summary>
        /// 电梯信息初始化
        /// </summary>
        /// <param name="floor1">1楼是否开门到位</param>
        /// <param name="floor2">2楼是否开门到位</param>
        /// <param name="agvNo">绑定AGV编号，0为不绑定</param>
        public ElevatorInfo(int _floorNumber, int _agvNo)
        {
            this.BindAgv = _agvNo;
            this.FloorNumber = _floorNumber;
            this.OpenFloor = 0;
            this.ButtonStatus = new List<KeyValuePair<int, bool>>();
            for (int i = 0; i < _floorNumber; i++)
            {
                this.ButtonStatus.Add(new KeyValuePair<int, bool>(i + 1, false));
            }
            this.state = ElevatorStatus.init;
            this.BeginFloor = 0;
            this.EndFloor = 0;
        }
        public ElevatorInfo(int _floorNumber)
        {
            this.FloorNumber = _floorNumber;
            this.OpenFloor = 0;
            this.ButtonStatus = new List<KeyValuePair<int, bool>>();
            for (int i = 0; i < _floorNumber; i++)
            {
                this.ButtonStatus.Add(new KeyValuePair<int, bool>(i + 1, false));
            }
            this.BindAgv = 0;
            this.state = ElevatorStatus.init;
            this.BeginFloor = 0;
            this.EndFloor = 0;
        }
        public ElevatorInfo()
        {
            this.FloorNumber = 2;
            this.OpenFloor = 0;
            this.ButtonStatus = new List<KeyValuePair<int, bool>>();
            for (int i = 0; i < 2; i++)
            {
                this.ButtonStatus.Add(new KeyValuePair<int, bool>(i + 1, false));
            }
            this.BindAgv = 0;
            this.state = ElevatorStatus.init;
            this.BeginFloor = 0;
            this.EndFloor = 0;
        }
        /// <summary>
        /// 电梯编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电梯状态
        /// </summary>
        public ElevatorStatus state { get; set; }
        /// <summary>
        /// 电梯当前绑定AGV
        /// </summary>
        public int BindAgv { get; set; }
        /// <summary>
        /// 电梯门开楼层，0表示关闭，对应数字表示对应楼层电梯门开
        /// </summary>
        public int OpenFloor { get; set; }
        /// <summary>
        /// 按钮信号 1楼，2楼
        /// </summary>
        public List<KeyValuePair<int, bool>> ButtonStatus = new List<KeyValuePair<int, bool>>();
        /// <summary>
        /// 电梯里面的RFID
        /// </summary>
        public int Rfid { get; set; }
        /// <summary>
        /// 楼层数量
        /// </summary>
        public int FloorNumber { get; set; }
        /// <summary>
        /// 开始楼层
        /// </summary>
        public int BeginFloor { get; set; }
        /// <summary>
        /// 结束楼层
        /// </summary>
        public int EndFloor { get; set; }
        /// <summary>
        /// 可使用电梯RFID集合(用于到达房门旁边，执行门开命令)
        /// </summary>
        public List<int> CallRfids = new List<int>();
        /// <summary>
        /// 电梯停止RFID集合（用于当房门没开时，停止AGV运行，等待门开）
        /// </summary>
        public List<int> StopRfids = new List<int>();
        /// <summary>
        /// 通讯信息
        /// </summary>
        public ElevatorCommunication ElevatorComm { get; set; }
    }
    /// <summary>
    /// 电梯工作状态
    /// </summary>
    public enum ElevatorStatus
    {
        /// <summary>
        /// 初始化
        /// </summary>
        init = 0,
        ///// <summary>
        ///// 楼层选择完毕
        ///// </summary>
        //selFloor = 1,
        /// <summary>
        /// 起始楼层电梯门开
        /// </summary>
        elevatorBeginOpen = 2,
        /// <summary>
        /// Agv进入电梯完毕
        /// </summary>
        agvInFinish = 3,
        /// <summary>
        /// 到达楼层电梯开
        /// </summary>
        elevatorEndOpen = 4,
        /// <summary>
        /// Agv出电梯完毕
        /// </summary>
        agvOutFinish = 5,
        /// <summary>
        /// 通讯异常
        /// </summary>
        Line=6,
    };
}
