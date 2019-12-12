using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_AgvInfo
    {
        public M_AgvInfo()
        {
            //this.State = (int)Enumerations.AgvStatus.stop;
            //this.VirtualRfid = 279;
            //this.ShowRfid = 279;
            this.VirtualRfid = -1;
            this.ShowRfid = -1;
            this.Rfid = -1;
            this.ControlRfid = -1;
            this.Direction = -1;
            this.Speed = 0;
            this.Voltage = 0;
            this.Abnormal = -1;
            this.Error = -1;
            this.ControlFlag = false;
            this.Task1 = string.Empty;
            this.Task2 = string.Empty;
            this.Task3 = string.Empty;
            this.Task4 = string.Empty;
            this.Task5 = string.Empty;
            this.Default1 = -1;
            this.Default2 = -1;
            this.Default3 = -1;
            this.Default4 = -1;
            this.Default5 = -1;
            this.Default6 = -1;
            this.VoltageStatus = Enumerations.voltageStatus.normal;
            this.Type = Enumerations.agvType.type_1;
            this.StationStopState = false;
            this.IsAgvTest = false;
            this.QRCode = string.Empty;
            this.IsChargeFullTime = false;
            this.isGoAwait = false;
            //this.ShowRfid = 0 - AgvNo;
            this.isQRCodeRight = true;
            this.RoutesIndex = 0;
            this.Position = -1;
            this.ChargeTime = new DateTime();
            this.StopTime = new DateTime();
            this.Retention = string.Empty;
            this.chargeAbnormal = false;
            this.ChargeAbnormalString = string.Empty;
            //this.QuestPass = true;
            //this.Voltage = 510;
        }
        /// <summary>
        /// Agv编号
        /// </summary>
        public int AgvNo { get; set; }
        /// <summary>
        /// 障碍物，true：有   false：无
        /// </summary>
        public bool Obstacle { get; set; }
        /// <summary>
        /// Agv状态
        /// </summary>
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// 状态具体信息
        /// </summary>
        public string StateMessage { get; set; }
        /// <summary>
        /// Rfid卡号
        /// </summary>
        public int Rfid
        {
            get;
            set;
        }
        /// <summary>
        /// 管制Rfid 进管制判断卡号
        /// </summary>
        public int ControlRfid { get; set; }
        /// <summary>
        /// 次级管制卡 出管制判断卡号
        /// </summary>
        public int ControlRfid2 { get; set; }
        /// <summary>
        /// 展示RFID
        /// </summary>
        public int ShowRfid { get; set; }
        /// <summary>
        /// 虚拟RFID
        /// </summary>
        public int VirtualRfid { get; set; }
        /// <summary>
        /// 方向 1:前向 2:后向 3:左向 4：右向
        /// </summary>
        public int Direction
        {
            get;
            set;
        }
        /// <summary>
        /// 当前速度
        /// </summary>
        public int Speed
        {
            get;
            set;
        }
        /// <summary>
        /// 电压值
        /// </summary>
        public int Voltage
        {
            get;
            set;
        }
        /// <summary>
        /// AGV到达上料点/下料点
        /// </summary>
        public bool Arrived { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public int Abnormal
        {
            get;
            set;
        }
        /// <summary>
        /// 异常具体信息
        /// </summary>
        public string AbnormalMessage { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public int Error
        {
            get;
            set;
        }
        /// <summary>
        /// 管制标志位
        /// </summary>
        public bool ControlFlag
        {
            get;
            set;
        }
        /// <summary>
        /// 任务1
        /// </summary>
        public string Task1
        {
            get;
            set;
        }
        /// <summary>
        /// 任务2
        /// </summary>
        public string Task2
        {
            get;
            set;
        }
        /// <summary>
        /// 任务3
        /// </summary>
        public string Task3
        {
            get;
            set;
        }
        /// <summary>
        /// 任务4
        /// </summary>
        public string Task4
        {
            get;
            set;
        }
        /// <summary>
        /// 任务5
        /// </summary>
        public string Task5
        {
            get;
            set;
        }
        /// <summary>
        /// 路径号（即站点号） 请求路段索引号
        /// </summary>
        public int Default1
        {
            get;
            set;
        }
        /// <summary>
        /// Default2     路段请求：0 无，1 有
        /// </summary>
        public int Default2
        {
            get;
            set;
        }
        /// <summary>
        /// Default3 
        /// </summary>
        public int Default3
        {
            get;
            set;
        }
        /// <summary>
        /// Default4 充电秒数
        /// </summary>
        public int Default4 //充电秒数
        {
            get;
            set;
        }
        /// <summary>
        /// Default5 磁点对应编号
        /// </summary>
        public int Default5
        {
            get;
            set;
        }
        /// <summary>
        /// default6/RFID
        /// </summary>
        public int Default6
        {
            get;
            set;
        }
        /// <summary>
        /// 已写入上料点
        /// </summary>
        public int Default7 { get; set; }
        /// <summary>
        /// 已写入下料点
        /// </summary>
        public int Default8 { get; set; }
        /// <summary>
        /// 电压状态
        /// </summary>
        public Enumerations.voltageStatus VoltageStatus { get; set; }
        /// <summary>
        /// 开始充电时间，不在充电则为 new DateTime
        /// </summary>
        public DateTime ChargeTime { get; set; }
        /// <summary>
        /// 已经充电的时间（秒）
        /// </summary>
        public int ChargeSeconds { get; set; }
        /// <summary>
        /// Agv类型
        /// </summary>
        public Enumerations.agvType Type { get; set; }
        ///// <summary>
        ///// AGV前往楼层
        ///// </summary>
        //public Enumerations.GoFloor Floor { get; set; }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string StatusInfo { get; set; }
        /// <summary>
        /// 工位停止状态  true:agv处于停止状态，等待放行，false:agv处于可运行状态，等待停止
        /// </summary>
        public bool StationStopState { get; set; }
        /// <summary>
        /// 路段集合
        /// </summary>
        public List<KeyValuePair<int, RfidInfo>> lsRoutes = new List<KeyValuePair<int, RfidInfo>>();
        /// <summary>
        /// 路段索引编号
        /// </summary>
        public int RoutesIndex { get; set; }
        /// <summary>
        /// AGV工作模式 0：手动，1：自动
        /// </summary>
        public int Mode { get; set; }
        /// <summary>
        /// 是否处于测试状态
        /// </summary>
        public bool IsAgvTest { get; set; }
        /// <summary>
        /// 动作状态 0:动作尚未完成 1：动作完成
        /// </summary>
        public bool OperateState { get; set; }
        /// <summary>
        /// 二维码
        /// </summary>
        public string QRCode { get; set; }
        /// <summary>
        /// 支撑脚状态
        /// </summary>
        public bool SupportState { get; set; }
        /// <summary>
        /// 充电接触器状态
        /// </summary>
        public bool ChargeState { get; set; }
        /// <summary>
        /// 是否充电完成
        /// </summary>
        public bool IsChargeFullTime { get; set; }
        /// <summary>
        /// 机械臂是否在原点位置
        /// </summary>
        public bool IsRobotArmOrigin { get; set; }
        /// <summary>
        /// 机械臂是否急停
        /// </summary>
        public bool IsRobotArmScram { get; set; }
        /// <summary>
        /// 机械臂状态
        /// </summary>
        public int RobotState { get; set; }
        /// <summary>
        /// 是否回待命点
        /// </summary>
        public bool isGoAwait { get; set; }
        /// <summary>
        /// 机械臂模式 true 自动  false 手动
        /// </summary>
        public bool RobotMode { get; set; }
        /// <summary>
        /// 是否二维码成功
        /// </summary>
        public bool isQRCodeRight { get; set; }
        /// <summary>
        /// 音量
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// 当前磁钉索引号
        /// </summary>
        public int CurrentMags { get; set; }
        /// <summary>
        /// 已写入磁钉索引号
        /// </summary>
        public int WritedMags { get; set; }
        /// <summary>
        /// 灯光模式
        /// </summary>
        public int LightType { get; set; }
        /// <summary>
        /// 牵引棒状态 0 尚未升起 1 已升起
        /// </summary>
        public int DragState { get; set; }
        /// <summary>
        /// 指定待机位置
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// AGV是否已经启动
        /// </summary>
        public bool IsStart { get; set; }
        /// <summary>
        /// 心跳包
        /// </summary>
        public int ActiveIndex { get; set; }
        /// <summary>
        /// 请求放行
        /// </summary>
        public bool QuestPass { get; set; }
        /// <summary>
        /// 是否已放行
        /// </summary>
        public bool IsPass { get; set; }
        /// <summary>
        /// 是否让AGV离开升降平台（站点）
        /// </summary>
        public bool IsPassPlatform { get; set; }
        /// <summary>
        /// AGV是否可以接受任务
        /// </summary>
        public bool IsCanReceiveTask { get; set; }
        /// <summary>
        /// 上下料完成
        /// </summary>
        public bool OperationComplete { get; set; }
        /// <summary>
        /// agv处于停止状态，且有任务的开始时间
        /// </summary>
        public DateTime StopTime { get; set; }
        /// <summary>
        /// 滞留
        /// </summary>
        public string Retention { get; set; }
        /// <summary>
        /// 充电异常标志
        /// </summary>
        public bool chargeAbnormal { get; set; }
        /// <summary>
        /// 充电异常
        /// </summary>
        public string ChargeAbnormalString { get; set; }
        /// <summary>
        /// 是否已经上线
        /// </summary>
        public bool isOnline { get; set; }
        /// <summary>
        /// 充电桩1感应异常
        /// </summary>
        public bool ChargeStation1Error { get; set; }
        /// <summary>
        /// 充电桩2感应异常
        /// </summary>
        public bool ChargeStation2Error { get; set; }
        /// <summary>
        /// 路径异常
        /// </summary>
        public bool RouteError { get; set; }
        /// <summary>
        /// 路径异常字符
        /// </summary>
        public string RouteErrorString { get; set; }
    }
    /// <summary>
    /// 指定agv只能在特定的待机点接收任务
    /// </summary>
    public enum EAgvPositionType
    {
        /// <summary>
        /// 待机点1
        /// </summary>
        wait1 = 1,
        /// <summary>
        /// 待机点2
        /// </summary>
        wait2 = 2,
        /// <summary>
        /// back面待机点1
        /// </summary>
        bwait1 = 3,
        /// <summary>
        /// back面待机点2
        /// </summary>
        bwait2 = 3,
    };
    /// <summary>
    /// Agv方向
    /// </summary>
    public enum AgvDirection
    {
        /// <summary>
        /// 前向
        /// </summary>
        Forward = 1,
        /// <summary>
        /// 后向
        /// </summary>
        Behind = 2,
        /// <summary>
        /// 左向
        /// </summary>
        Left = 3,
        /// <summary>
        /// 右向
        /// </summary>
        Right = 4,
    };
}
