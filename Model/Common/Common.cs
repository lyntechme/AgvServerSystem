using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Model
{
    public class Common
    {
        public static Common Instance
        {
            get
            {
                if (common == null)
                {
                    common = new Common();
                }
                return common;
            }
        }
        private static Common common = null;
        private Common()
        {
            #region Agv状态
            //0无错误，1无路径信号信息，2电源电量过低，3机械防撞，4驱动器报警，5路径设置出错，7急停， 8驱动升降感应异常，9牵引升降异常，10驱动升起状态，未能启动错误，11无法由当前站点寻找到目标站点的轨迹  12 站点无线IO通信异常，13 没有停车标志位， 14卸料点故障 15 小车方向 
            this.dtAgvAbnormal[0] = "Normal";
            this.dtAgvAbnormal[1] = "No signal";
            this.dtAgvAbnormal[2] = "Power low";
            this.dtAgvAbnormal[3] = "Break stop";
            this.dtAgvAbnormal[4] = "Motor driver";
            this.dtAgvAbnormal[5] = "Path signal abnormal";
            this.dtAgvAbnormal[6] = "Path error";
            this.dtAgvAbnormal[7] = "Emergency stop";
            this.dtAgvAbnormal[8] = "Driver up/down abnormal";
            this.dtAgvAbnormal[9] = "Stick up/down abnormal";
            this.dtAgvAbnormal[10] = "Drive stop";
            this.dtAgvAbnormal[11] = "No path";
            this.dtAgvAbnormal[12] = "io abnormal";
            this.dtAgvAbnormal[13] = "No stop flag";
            this.dtAgvAbnormal[14] = "Unload abnormal";
            this.dtAgvAbnormal[15] = "Direction abnormal";
            this.dtAgvAbnormal[16] = "Full abnormal";
            this.dtAgvAbnormal[17] = "Ohter abnormal";
            this.dtAgvAbnormal[18] = "Ohter abnormal";
            this.dtAgvAbnormal[19] = "Ohter abnormal";
            this.dtAgvAbnormal[20] = "Ohter abnormal";
            this.dtAgvAbnormal[21] = "Find-origin fault";
            this.dtAgvAbnormal[22] = "Front-rotating motor fault";
            this.dtAgvAbnormal[23] = "Behind-rotating motor fault";
            this.dtAgvAbnormal[24] = "Front-rotating motor connect timeout";
            this.dtAgvAbnormal[25] = "Front-running motor connect timeout";
            this.dtAgvAbnormal[26] = "Behind-rotating motor connect timeout";
            this.dtAgvAbnormal[27] = "Behind-running motor connect timeout";
            this.dtAgvAbnormal[28] = "Front-rotating Angle measure fault";
            this.dtAgvAbnormal[29] = "Behind-rotating Angle measure fault";
            this.dtAgvAbnormal[30] = "Front-running driver alarm";
            this.dtAgvAbnormal[31] = "Behind-rotating driver-3 alarm";
            this.dtAgvAbnormal[32] = "Behind-running driver-4 alarm";
            this.dtAgvAbnormal[33] = "Front-rotating driver-1 no feedback";
            this.dtAgvAbnormal[34] = "Front-running driver-1 no feedback";
            this.dtAgvAbnormal[35] = "Behind-rotating driver-1 no feedback";
            this.dtAgvAbnormal[35] = "Behind-running driver-1 no feedback";
            #endregion
            #region 站点转换
            dtStationTransform[1] = 1;
            dtStationTransform[2] = 2;
            dtStationTransform[3] = 3;
            dtStationTransform[4] = 3;
            dtStationTransform[5] = 5;
            dtStationTransform[6] = 5;
            dtStationTransform[7] = 5;
            dtStationTransform[8] = 6;
            dtStationTransform[9] = 6;
            dtStationTransform[10] = 6;
            dtStationTransform[11] = 19;
            dtStationTransform[12] = 7;
            dtStationTransform[13] = 19;
            dtStationTransform[14] = 8;
            dtStationTransform[15] = 8;
            dtStationTransform[16] = 9;
            dtStationTransform[17] = 9;
            dtStationTransform[18] = 10;
            dtStationTransform[19] = 10;
            dtStationTransform[20] = 10;
            dtStationTransform[21] = 11;
            dtStationTransform[22] = 11;
            dtStationTransform[23] = 11;
            dtStationTransform[24] = 12;
            dtStationTransform[25] = 12;
            dtStationTransform[26] = 12;
            dtStationTransform[27] = 13;
            dtStationTransform[28] = 12;
            dtStationTransform[29] = 13;
            dtStationTransform[30] = 20;
            dtStationTransform[31] = 21;
            dtStationTransform[32] = 21;
            dtStationTransform[33] = 22;
            dtStationTransform[34] = 23;
            dtStationTransform[35] = 24;
            dtStationTransform[36] = 25;
            dtStationTransform[37] = 26;
            dtStationTransform[38] = 27;
            dtStationTransform[39] = 28;
            dtStationTransform[40] = 29;
            dtStationTransform[41] = 30;
            dtStationTransform[42] = 31;
            dtStationTransform[43] = 32;
            dtStationTransform[44] = 32;
            dtStationTransform[45] = 32;
            dtStationTransform[46] = 33;
            dtStationTransform[47] = 33;
            dtStationTransform[48] = 35;
            dtStationTransform[49] = 36;
            dtStationTransform[50] = 37;
            #endregion
            #region 待机充电位状态初始化
            //this.dtOtherStations[Enumerations.OtherStation.charge] = new OtherStationsInfo(Enumerations.OtherStation.charge, 47, 0);
            //this.dtOtherStations[Enumerations.OtherStation.ChargeFloor1] = new OtherStationsInfo(Enumerations.OtherStation.ChargeFloor1, 48, 0);
            //this.dtOtherStations[Enumerations.OtherStation.WaitFloor2] = new OtherStationsInfo(Enumerations.OtherStation.WaitFloor2, 49, 0);
            //this.dtOtherStations[Enumerations.OtherStation.ChargeFloor2] = new OtherStationsInfo(Enumerations.OtherStation.ChargeFloor2, 50, 0);
            #endregion
            #region 路段名称
            dtRouteName[RouteType.GoWait] = "前往待机点";
            dtRouteName[RouteType.CapacityLoad] = "前往电池上下料位";
            dtRouteName[RouteType.CapacityUnload] = "前往分容柜";
            #endregion
            #region 任务类型名称
            //充电任务
            dtTaskTypeName[Enumerations.TaskType.Charge_Go] = "GoCharge";
            dtTaskTypeName[Enumerations.TaskType.Chareg_Leave] = "LeaveCharge";

            //type1 A站点任务
            dtTaskTypeName[Enumerations.TaskType.Transport_A_F] = "[A-F]";
            dtTaskTypeName[Enumerations.TaskType.Transport_A_C] = "[A-C]";
            dtTaskTypeName[Enumerations.TaskType.Transport_E_A] = "[E_A]";
            dtTaskTypeName[Enumerations.TaskType.Transport_C_F] = "[C-F]";
            //type1 B站点任务
            dtTaskTypeName[Enumerations.TaskType.Transport_B_E] = "[B-E]";
            dtTaskTypeName[Enumerations.TaskType.Transport_B_D] = "[B-D]";
            dtTaskTypeName[Enumerations.TaskType.Transport_F_B] = "[F-B]";
            dtTaskTypeName[Enumerations.TaskType.Transport_D_E] = "[D-E]";
            #endregion
            #region 额定路段放行信号
            dtRoutePass[RouteType.CapacityLoad] = new WorkEnableInfo(RouteType.CapacityLoad, false, false, true, 32, 0);
            dtRoutePass[RouteType.CapacityUnload] = new WorkEnableInfo(RouteType.CapacityUnload, false, false, true, 31, 0);
            #endregion
            #region MES信息刷新时间初始化
            mesConnectTime.GetTaskTime = 5;
            mesConnectTime.UpdateAgvStateTime = 5;
            mesConnectTime.UpdateTaskTime = 5;
            #endregion
            #region 老化房信息参数
            dtAgingRoomInfo[Enumerations.agvType.type_2] = new AgingRoomInfo();
            dtAgingRoomInfo[Enumerations.agvType.type_2].TaskType = Enumerations.agvType.type_2;
            dtAgingRoomInfo[Enumerations.agvType.type_3] = new AgingRoomInfo();
            dtAgingRoomInfo[Enumerations.agvType.type_3].TaskType = Enumerations.agvType.type_3;
            #endregion
            #region 充电阀值
            dtChargeLimitedInfo[Enumerations.agvType.type_1] = new ChargeLimitedInfo(240, 5, 245, 10, 280, 120);
            dtChargeLimitedInfo[Enumerations.agvType.type_2] = new ChargeLimitedInfo(240, 5, 245, 10, 280, 120);
            dtChargeLimitedInfo[Enumerations.agvType.type_3] = new ChargeLimitedInfo(240, 5, 245, 10, 280, 120);
            #endregion
            #region agv类型信息集体[任务刷新时间]
            dtAgvTypeInfo[Enumerations.agvType.type_1] = new AgvTypeInfo(Enumerations.agvType.type_1, true, 5);
            dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshLastTime = DateTime.Now;
            dtAgvTypeInfo[Enumerations.agvType.type_2] = new AgvTypeInfo(Enumerations.agvType.type_2, true, 5);
            dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshLastTime = DateTime.Now;
            dtAgvTypeInfo[Enumerations.agvType.type_3] = new AgvTypeInfo(Enumerations.agvType.type_3, true, 5);
            dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshLastTime = DateTime.Now;
            #endregion
            #region 站点 操作命令码
            dtStationOperate[StationInformation.EStationOperate.LeftLoad] = 0;
            dtStationOperate[StationInformation.EStationOperate.RightLoad] = 0;
            dtStationOperate[StationInformation.EStationOperate.LeftUnload] = 0;
            dtStationOperate[StationInformation.EStationOperate.RightUnload] = 0;
            dtStationOperate[StationInformation.EStationOperate.LeftRefueling] = 0;
            dtStationOperate[StationInformation.EStationOperate.RightRefueling] = 0;
            dtStationOperate[StationInformation.EStationOperate.DropUp] = 12;
            dtStationOperate[StationInformation.EStationOperate.DropDown] = 13;
            dtStationOperate[StationInformation.EStationOperate.DropUpAndDown] = 230;
            #endregion
            #region 机械臂状态
            //this.dtRobotState[0] = "正常";
            //this.dtRobotState[1] = "扫描建立用户坐标错误";
            //this.dtRobotState[2] = "料盘取电芯失败";
            //this.dtRobotState[3] = "中转台取电芯失败1";
            //this.dtRobotState[4] = "中转台取电芯失败2";
            //this.dtRobotState[5] = "预充柜取电芯失败";
            #endregion
            #region 上下料区AGV限定初始化
            dtAgvLimited[1] = new List<int>();
            dtAgvLimited[2] = new List<int>();
            dtAgvLimited[3] = new List<int>();
            dtAgvLimited[4] = new List<int>();
            #endregion
            SourcePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            #region 任务集合初始化
            taskDt[(int)Enumerations.agvType.type_1] = new Dictionary<string, MA_AgvTaskInfo>();
            taskDt[(int)Enumerations.agvType.type_2] = new Dictionary<string, MA_AgvTaskInfo>();
            taskDt[(int)Enumerations.agvType.type_3] = new Dictionary<string, MA_AgvTaskInfo>();
            #endregion
        }
        /// <summary>
        /// 充电时长
        /// </summary>
        public int chargeTime = 1200;
        /// <summary>
        /// 待机状态下充电时长
        /// </summary>
        public int standbyChargeTime = 7200;
        /// <summary>
        /// 根目录地址
        /// </summary>
        public string SourcePath { get; set; }
        /// <summary>
        /// 上下料区AGV限定
        /// </summary>
        public Dictionary<int, List<int>> dtAgvLimited = new Dictionary<int, List<int>>();
        /// <summary>
        /// 充电判断计数
        /// </summary>
        public int chargeVoltageCount = 100;
        /// <summary>
        /// 掉线时长
        /// </summary>
        public int AgvLineTime = 20;
        /// <summary>
        /// agv掉线清除时长
        /// </summary>
        public int AgvClearLineTime = 240;
        /// <summary>
        /// 站点 操作命令码
        /// </summary>
        public Dictionary<StationInformation.EStationOperate, int> dtStationOperate = new Dictionary<StationInformation.EStationOperate, int>();
        /// <summary>
        /// agv类型信息集体[任务刷新时间]
        /// </summary>
        public Dictionary<Enumerations.agvType, AgvTypeInfo> dtAgvTypeInfo = new Dictionary<Enumerations.agvType, AgvTypeInfo>();
        /// <summary>
        /// 老化房信息参数
        /// </summary>
        public Dictionary<Enumerations.agvType, AgingRoomInfo> dtAgingRoomInfo = new Dictionary<Enumerations.agvType, AgingRoomInfo>();
        /// <summary>
        /// 分容测试待机点集合
        /// </summary>
        public Dictionary<int, CapacityTestWaitInfo> dtCapacityTestWait = new Dictionary<int, CapacityTestWaitInfo>();
        /// <summary>
        /// 分容柜参数集合
        /// </summary>
        public Dictionary<string, BatteryCapacityDetectorParameters> dtBatteryCapcityDetector = new Dictionary<string, BatteryCapacityDetectorParameters>();
        /// <summary>
        /// 站点信息集合
        /// </summary>
        public Dictionary<string, StationInformation> dtStationInformation = new Dictionary<string, StationInformation>();

        public Dictionary<string, InventoryLocationInformation> dtInvLocInformation = new Dictionary<string, InventoryLocationInformation>();
        /// <summary>
        /// 当前选择测试AGV
        /// </summary>
        public int TestAgvNo = 0;
        /// <summary>
        /// 充电桩信息集合
        /// </summary>
        public Dictionary<int, ChargeInfo> dtChargeInfo = new Dictionary<int, ChargeInfo>();
        /// <summary>
        /// 房门信息集合
        /// </summary>
        public Dictionary<int, DoorInfo> dtDoorInfo = new Dictionary<int, DoorInfo>();
        /// <summary>
        /// 电梯信息集合
        /// </summary>
        public Dictionary<int, ElevatorInfo> dtElevatorInfo = new Dictionary<int, ElevatorInfo>();
        /// <summary>
        /// 任务最大编号索引
        /// </summary>
        public long taskIndex = 0;
        /// <summary>
        /// mes通讯刷新时间
        /// </summary>
        public MESConnectTime mesConnectTime = new MESConnectTime();
        /// <summary>
        /// 是否接收MES任务
        /// </summary>
        public bool isReceiveOpcTask = false;
        /// <summary>
        /// 当前已经写入到OPC的是否接收任务状态
        /// </summary>
        public bool writeOpcReceiveState = false;
        /// <summary>
        /// AGV收工请求
        /// </summary>
        public bool opcIdleRequest = false;
        /// <summary>
        /// AGV开始工作请求
        /// </summary>
        public bool opcStartRequest = false;
        /// <summary>
        /// 是否回传二维码
        /// </summary>
        public bool isReceiveQRCode = false;
        /// <summary>
        /// 放行使能
        /// </summary>
        public bool passEnable = false;
        /// <summary>
        /// 三菱PLC通讯类
        /// </summary>
        public MitsubishiPLC mitsubishiPLC;
        /// <summary>
        /// 额定路段放行判断
        /// </summary>
        public Dictionary<RouteType, WorkEnableInfo> dtRoutePass = new Dictionary<RouteType, WorkEnableInfo>();
        /// <summary>
        /// 任务类型名称
        /// </summary>
        public Dictionary<Enumerations.TaskType, string> dtTaskTypeName = new Dictionary<Enumerations.TaskType, string>();
        /// <summary>
        /// 任务类型
        /// </summary>
        public Dictionary<RouteType, string> dtRouteName = new Dictionary<RouteType, string>();
        /// <summary>
        /// 待机充电位状态 0：无AGV； 1-100：绑定AGV；100+AgvNo：预定AGV
        /// </summary>
        public Dictionary<Enumerations.OtherStation, OtherStationsInfo> dtOtherStations = new Dictionary<Enumerations.OtherStation, OtherStationsInfo>();
        /// <summary>
        /// 管制同排除点
        /// </summary>
        public List<int> RepeatRfids = new List<int>();
        /// <summary>
        /// Agv类型
        /// </summary>
        public Dictionary<int, Enumerations.agvType> agvType = new Dictionary<int, Enumerations.agvType>();
        /// <summary>
        /// 连接PLC是否正常
        /// </summary>
        public bool isConnectPLC = false;
        /// <summary>
        /// 充电阀值信息
        /// </summary>
        public Dictionary<Enumerations.agvType, ChargeLimitedInfo> dtChargeLimitedInfo = new Dictionary<Enumerations.agvType, ChargeLimitedInfo>();
        /// <summary>
        /// 站点转换，因为数据定义站点与实际站点并不相符
        /// </summary>
        public Dictionary<int, int> dtStationTransform = new Dictionary<int, int>();
        /// <summary>
        /// sql数据库连接参数
        /// </summary>
        public static SqlCommInfo sqlCommInfo = new SqlCommInfo();
        /// <summary>
        /// agv类型
        /// </summary>
        public static string[] agvTypeStr = { "OmronPlc", "OmronHostLink", "Stm32", "Stm32Cd" };   //Agv类型
        public static string[] agvIsUsingStr = { "Enable", "Disable" };  //是否启用监控该Agv
        public static string[] agvQueryContent = { "Task Info", "Abnormal Info", "Error Info", "Operation Info" };
        /// <summary>
        /// 异常状态
        /// </summary>
        public Dictionary<int, string> dtAgvAbnormal = new Dictionary<int, string>();
        /// <summary>
        /// 机械臂状态
        /// </summary>
        public Dictionary<int, string> dtRobotState = new Dictionary<int, string>();
        /// <summary>
        /// agv布局
        /// </summary>
        public static string[] agvLayout = { "Horizontal", "Vertical" };
        /// <summary>
        /// tab名称
        /// </summary>
        public static string[] tabName = { "Map", "Task record", "Error record", "Configuration" };
        public static string[] taskStatus = { "Untreated", "Executing" };
        public static string[] direction = { "Up", "Right", "Below", "Left" };
        /// <summary>
        /// 线程锁
        /// </summary>
        public static Dictionary<int, object> objLock = new Dictionary<int, object>();   //线程锁
        /// <summary>
        /// agv状态显示布局
        /// </summary>
        public static point agvstatusLayout = new point(0, 0);
        /// <summary>
        /// 与客户端通讯锁
        /// </summary>
        public static object tcpObj = new object(); //与客户端通讯锁
        /// <summary>
        /// Agv信息集合
        /// </summary>
        public static Dictionary<int, M_AgvInfo> maiDict = new Dictionary<int, M_AgvInfo>();  //连接的Agv信息集合
        /// <summary>
        /// 电子地图保存
        /// </summary>
        public static Dictionary<int, MM_MapImageInfo> mmiiDict = new Dictionary<int, MM_MapImageInfo>();  //电子地图保存
        /// <summary>
        /// rfid坐标对象集合
        /// </summary>
        public static Dictionary<int, MA_RfidPoint> rfidDt = new Dictionary<int, MA_RfidPoint>();  //rfid坐标对象集合
        /// <summary>
        /// 记录tlpAgvLight的坐标,相对电子地图的原始尺寸
        /// </summary>
        public static point tlpPoint = new point();  //记录tlpAgvLight的坐标,相对电子地图的原始尺寸
        /// <summary>
        /// 是否允许客户端连接至Server
        /// </summary>
        public static bool isTcpComm = true;  //是否允许客户端连接至Server
        /// <summary>
        /// 是否对AGV进行连接
        /// </summary>
        public static bool isComm = true;  //是否对agv进行连接
        /// <summary>
        /// 是否对Agv信息进行无限循环请求
        /// </summary>
        public static bool isLoop = true;  //是否对agv信息进行无限循环请求
        /// <summary>
        /// 最新添加的RFID编号
        /// </summary>
        public static int rfidAddNo = 1; //记录最新添加Rfid编号
        /// <summary>
        /// 当前RFID坐标的Label显示状态
        /// </summary>
        public static bool isRfidVisible = false; //记录当前Rfid坐标的label显示状态
        //public static SizeScale sizeMapImage = new SizeScale();
        /// <summary>
        /// 电子地图尺寸比例
        /// </summary>
        public static Dictionary<int, SizeScale> sizeMapImage = new Dictionary<int, SizeScale>();
        /// <summary>
        /// 电子地图信息
        /// </summary>
        public static Dictionary<int, string> mapInfo = new Dictionary<int, string>();
        /// <summary>
        /// 与上位机通讯的客户端集合
        /// </summary>
        public static Dictionary<string, Socket> clientDt = new Dictionary<string, Socket>();  //记录与服务器TCP通讯的客户端集合
        /// <summary>
        /// 与上位机通讯的客户端线程集合
        /// </summary>
        public static Dictionary<string, Thread> clientThreadDt = new Dictionary<string, Thread>(); //记录与服务器通讯的线程集合
        /// <summary>
        /// 任务类型1尚未完成任务
        /// </summary>
        public static Dictionary<int, Dictionary<string, MA_AgvTaskInfo>> taskDt = new Dictionary<int, Dictionary<string, MA_AgvTaskInfo>>();
        ///// <summary>
        ///// 任务类型2尚未完成任务
        ///// </summary>
        //public static Dictionary<string, MA_AgvTaskInfo> taskType2Dt = new Dictionary<string, MA_AgvTaskInfo>();
        ///// <summary>
        ///// 任务类型3尚未完成任务
        ///// </summary>
        //public static Dictionary<string, MA_AgvTaskInfo> taskType3Dt = new Dictionary<string, MA_AgvTaskInfo>();
        /// <summary>
        /// 测试任务
        /// </summary>
        public static MA_AgvTaskInfo taskTest = new MA_AgvTaskInfo();
        /// <summary>
        /// 测试任务是否执行循环操作
        /// </summary>
        public static bool IsTestLoop = false;
        /// <summary>
        /// 需要存储到xml的初始数据
        /// </summary>
        public static List<KeyValue> lsXmlPParameter = new List<KeyValue>();  //记录需要存储至XML的临时数据
        /// <summary>
        /// 数据类型
        /// </summary>
        public static List<KeyValuePair<int, string>> dataType = new List<KeyValuePair<int, string>>();
        /// <summary>
        /// xml保存类型
        /// </summary>
        public static int dataSaveType;  //数据保存类型

        public static Dictionary<string, string> lineNameDt = new Dictionary<string, string>(); //路线对应名称
        /// <summary>
        /// 位置名称对应
        /// </summary>
        public static Dictionary<string, string> pNameDt = new Dictionary<string, string>();  //位置名称对应
        /// <summary>
        /// 站点等待时间
        /// </summary>
        public static int stationTime = 120;
        /// <summary>
        /// 每一圈走过的RFID
        /// </summary>
        public static Dictionary<int, List<string>> rfidRecord = new Dictionary<int, List<string>>();  //记录每一圈走过的RFID
        /// <summary>
        /// agv模型比例
        /// </summary>
        public static double agvModelScale = 1;  //Agv 模型比例
        /// <summary>
        /// 电子地图切换时间（秒）
        /// </summary>
        public static int mapChangeTime = 0;
        /// <summary>
        /// 是否自动切换电子地图
        /// </summary>
        public static bool isMapChange = false;
        /// <summary>
        /// 向数据库写入工作状态锁
        /// </summary>
        public static object objLockOracle = new object();
        /// <summary>
        /// 布局高度
        /// </summary>
        public static int splitStatusHeight = 0;
        /// <summary>
        /// 任务拆分器宽度，X：task拆分器宽度,Y：taskBurnInRoom拆分器宽度
        /// </summary>
        public static point splitTask = new point();
        /// <summary>
        /// 电子地图整合拆分器宽度，X：panSplitAll宽度，Y：panSplitMap宽度
        /// </summary>
        public static point splitMap = new point(0, 0);
        /// <summary>
        /// 坐标点偏移量
        /// </summary>
        public static point excPoint = new point(10, 10);
        /// <summary>
        /// 是否窗体加载完毕
        /// </summary>
        public static bool isLoadedOk = false;
        /// <summary>
        /// 已插入任务 、异常数量
        /// </summary>
        public static int[] insertCount = new int[] { 0, 0 };
        /// <summary>
        /// 是否自动添加任务
        /// </summary>
        public static bool isAutoTask = false;
        /// <summary>
        /// 分容柜自动任务可使用agv
        /// </summary>
        public static List<int> subCabinetAutoTaskAgvLs = new List<int>();
        /// <summary>
        /// 上下料点可使用集合
        /// </summary>
        public static List<int> subLoadLs = new List<int>();
        /// <summary>
        /// 自动任务类型，初始为分容柜换料
        /// </summary>
        public static Enumerations.TaskType autoTaskType = Enumerations.TaskType.Init;
        /// <summary>
        /// 分容柜任务 站点 数
        /// </summary>
        public static int testStations = 5;
        /// <summary>
        /// 分容柜集合
        /// </summary>
        public static List<MatchStationInfo> subCabinetLs = new List<MatchStationInfo>();
        /// <summary>
        /// 分容柜集合索引编号
        /// </summary>
        public static int subIndex = 0;
        /// <summary>
        /// 是否随机选择分容柜
        /// </summary>
        public static bool isRandomSelect = false;
        /// <summary>
        /// 是否执行机械臂动作
        /// </summary>
        public static bool isRandomRobotOperate = true;
        /// <summary>
        /// 当前打印回传信息agv
        /// </summary>
        public static int printAgvNo = 0;
        /// <summary>
        /// 分容柜停留时间
        /// </summary>
        public static int subStayTime = 500;
        /// <summary>
        /// 是否保存写入Agv路段信息
        /// </summary>
        public static bool isSaveRoute = false;
        /// <summary>
        /// 是否启用低电压越站
        /// </summary>
        public static bool isLowVoltageStation = false;
        /// <summary>
        /// 空车回待机点通道号
        /// </summary>
        public static int bufferGroup = 78;
        /// <summary>
        /// 是否执行循环充电任务，当此项勾选，在充电桩内无任务的AGV，在充电完成状态下，会在指定通道循环跑，以将充电桩让出来，方便其它AGV可进行充电
        /// </summary>
        public static bool isLoopCharge = false;
        /// <summary>
        /// 初始缓存AGV的显示RFID
        /// </summary>
        public static Dictionary<int, int> bufferShowRfidDt = new Dictionary<int, int>();
        #region 交通管制参数
        /// <summary>
        /// 交通管制点
        /// </summary>
        public static Dictionary<int, List<int>> controlPointsDict = new Dictionary<int, List<int>>();  //交通管制点集合
        /// <summary>
        /// 每个管制点的状态
        /// </summary>
        public static Dictionary<int, int> controlPointsStatus = new Dictionary<int, int>();  //每个管制点的状态，是否有Agv，若无为-1，若有则为Agv编号 
        public static Dictionary<int, List<int>> controlPointAgvList = new Dictionary<int, List<int>>();//进入管制点的agv，按先后排序
        /// <summary>
        /// 每个管制范围的当前AGV通过方式
        /// </summary>
        public static Dictionary<int, Enumerations.ControlType> controlType = new Dictionary<int, Enumerations.ControlType>();
        #endregion
        #region 站点创建信息集合
        ///// <summary>
        ///// 站点Label信息集合
        ///// </summary>
        //public static Dictionary<int, StationLayoutInfo> dtStationLabelInfo = new Dictionary<int, StationLayoutInfo>();
        /// <summary>
        /// 初始站点尺寸
        /// </summary>
        public static point sizeStationDefault = new point(0, 0);

        public static point sizeInvLocDefault = new point(0, 0);
        /// <summary>
        /// 站点信息集合
        /// </summary>
        public static Dictionary<int, StationInfo> dtStationInfo = new Dictionary<int, StationInfo>();

        public static Dictionary<int, InventoryLocationInfo> dtInvLocInfo = new Dictionary<int, InventoryLocationInfo>();
        #endregion
        #region 指定AGV执行通道任务
        /// <summary>
        /// 是否执行指定agv通道任务
        /// </summary>
        public static bool isAgvMatchStationTask = false;

        public static bool isAgvMatchInvLocTask = false;
        /// <summary>
        /// 指定站点AGV集合
        /// </summary>
        public static Dictionary<int, MatchStationInfo> matchStations = new Dictionary<int, MatchStationInfo>();

        
        #endregion
        /// <summary>
        /// 是否可以使用动态密码
        /// </summary>
        public static bool isDynPwd = true;
        /// <summary>
        /// 动态密码用户名称
        /// </summary>
        public static string dynName = "dyntest";
    }
}
