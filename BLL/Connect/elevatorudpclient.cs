using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BLL
{
    /// <summary>
    /// 电梯控制函数
    /// </summary>
    public class ElevatorUdpClient
    {
        /// <summary>
        /// 电梯通讯集合
        /// </summary>
        public static Dictionary<int, ElevatorUdpClient> dtElevatorUdp = new Dictionary<int, ElevatorUdpClient>();
        #region 属性
        /// <summary>
        /// 电梯编号
        /// </summary>
        private int ElevatorNo = 0;
        private UdpClient udpElevator;
        /// <summary>
        /// 设定目标网络端点
        /// </summary>
        private IPEndPoint desEndPoint;
        /// <summary>
        /// 回传目标网络端点
        /// </summary>
        private IPEndPoint refEndPoint;
        /// <summary>
        /// 发送命令数据的长度
        /// </summary>
        private byte length = 9;
        /// <summary>
        /// 发送互斥锁
        /// </summary>
        public object lockObj = new object();
        /// <summary>
        /// 获取的充电桩数据
        /// </summary>
        private List<byte> recDataBuffer = new List<byte>();
        /// <summary>
        /// 接收到数据长度
        /// </summary>
        private int dataLength = 19;
        /// <summary>
        /// 掉线判断计数
        /// </summary>
        private int lineCount = 0;
        /// <summary>
        /// 掉线判断最大计数
        /// </summary>
        private int lineTime = 15;
        /// <summary>
        /// 
        /// </summary>
        private DateTime lastRecDataTime = new DateTime();
        #endregion
        /// <summary>
        /// 电梯通讯初始化
        /// </summary>
        /// <param name="elevatorNo">电梯编号</param>
        public ElevatorUdpClient(int elevatorNo)
        {
            this.ElevatorNo = elevatorNo;
            if (Common.Instance.dtElevatorInfo.ContainsKey(this.ElevatorNo))
            {
                desEndPoint = new IPEndPoint(IPAddress.Parse(Common.Instance.dtElevatorInfo[this.ElevatorNo].ElevatorComm.Ip), Common.Instance.dtElevatorInfo[this.ElevatorNo].ElevatorComm.Port);
                udpElevator = new UdpClient(Common.Instance.dtElevatorInfo[this.ElevatorNo].ElevatorComm.Port);
            }
            refEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }
        /// <summary>
        /// 读取电梯数据
        /// </summary>
        public void ReadElevatorInformation()
        {
            while (true)
            {
                try
                {
                    #region 获取电梯最新数据

                    #endregion
                    #region 更新电梯控制状态
                    if (Common.Instance.dtElevatorInfo[this.ElevatorNo].BindAgv > 0 && Common.Instance.dtElevatorInfo[this.ElevatorNo].BeginFloor > 0 && Common.Instance.dtElevatorInfo[this.ElevatorNo].EndFloor > 0)
                    {
                        switch (Common.Instance.dtElevatorInfo[this.ElevatorNo].state)
                        {
                            case ElevatorStatus.Line:
                                break;
                            case ElevatorStatus.init://向电梯写入呼叫楼层信息

                                break;
                            case ElevatorStatus.elevatorBeginOpen://保持电梯处于门开状态
                                break;
                            case ElevatorStatus.agvInFinish://向电梯写入结束楼层呼叫
                                break;
                            case ElevatorStatus.elevatorEndOpen://
                                break;
                            case ElevatorStatus.agvOutFinish:

                                break;
                        }
                    }
                    else
                    {//电梯无agv，解除所有控制状态

                    }
                    #endregion
                }
                catch { }
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 向电梯写入操作命令
        /// </summary>
        /// <param name="eOperate">操作命令</param>
        /// <param name="value">操作参数</param>
        /// <returns></returns>
        public bool WriteElevatorOperate(EElevatorOperate eOperate, int value)
        {
            bool reState = false;
            try
            { }
            catch { }
            return reState;
        }
        public enum EElevatorOperate
        {
            /// <summary>
            /// 打开电梯门
            /// </summary>
            OpenElevator,
            /// <summary>
            /// 关闭电梯门
            /// </summary>
            CloseElevator,
            /// <summary>
            /// 呼叫电梯
            /// </summary>
            CallElevaotr,
        };
    }
}