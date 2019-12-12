using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Threading;
using System.Diagnostics;

namespace BLL
{
    public class BA_AgvCommunicationThread
    {
        #region 公共变量
        /// <summary>
        /// Agv通讯类
        /// </summary>
        public static Dictionary<int, BA_AgvCommunicationThread> AgvCommuDt = new Dictionary<int, BA_AgvCommunicationThread>();
        #endregion

        #region Perproties
        /// <summary>
        /// 写入二维码次数
        /// </summary>
        private int QRCodeErrorCount = 0;
        /// <summary>
        /// 是否处于充满电状态
        /// </summary>
        private bool isFullTime = false;
        /// <summary>
        /// 当为agv需要写入路段时，该值为上一个管制rfid，用于在agv尚未回传前的ControlRfid更新判断
        /// </summary>
        private int lastControlRfid = 0;
        /// <summary>
        /// agv是否执行完上升和下降动作
        /// </summary>
        private bool isDownAdnUp = false;
        /// <summary>
        /// 是否进行通讯
        /// </summary>
        private bool isRun;
        /// <summary>
        /// AGV通讯参数
        /// </summary>
        private MA_AgvComInfo maci;
        /// <summary>
        /// agv通讯接口
        /// </summary>
        private AgvConnect agvConnect;
        /// <summary>
        /// 插入任务至数据库
        /// </summary>
        private DA_AgvTaskInfo inTask = new DA_AgvTaskInfo();
        /// <summary>
        /// AGV在等待点的等待时间
        /// </summary>
        private DateTime StationWaitTime = new DateTime();
        /// <summary>
        /// 在各站点延迟等待任务时间
        /// </summary>
        private DateTime TaskWaitTime = new DateTime();
        /// <summary>
        /// AGV开始工作时间(主要用于刚开机等待所有AGV上线)
        /// </summary>
        private DateTime WorkTime = new DateTime();
        /// <summary>
        /// 是否在等待点往充电点走的时候已经往AGV写入向前指令
        /// </summary>
        private bool isWriteForward = false;
        /// <summary>
        /// 是否前往充电位判断 时间
        /// </summary>
        private DateTime dtChargeJudge = new DateTime();
        /// <summary>
        /// 上料点请求是否清除
        /// </summary>
        private bool isClearLoadQuery = false;
        /// <summary>
        /// 下料点请求是否清除
        /// </summary>
        private bool isClearUnloadQuery = false;
        ///// <summary>
        ///// AGV当前可写入路段集合
        ///// </summary>
        //List<KeyValuePair<int, RfidInfo>> lsRoutes = new List<KeyValuePair<int, RfidInfo>>();
        #endregion //Perproties

        public BA_AgvCommunicationThread(MA_AgvComInfo _maaci, bool _isRun)
        {
            this.maci = _maaci;
            this.isRun = _isRun;
            this.maci = _maaci;
            if (_maaci.A_AgvConnectType == Common.agvTypeStr[0])
            {
                this.agvConnect = new DA_AgvOmronFins(this.maci);
            }
            else if (_maaci.A_AgvConnectType == Common.agvTypeStr[1])
            {
                this.agvConnect = new DA_AgvOmronHostLinkRs232(this.maci);
            }
            else if (_maaci.A_AgvConnectType == Common.agvTypeStr[2])
            {
                this.agvConnect = new DA_AgvStm32(this.maci);
            }
            else if (_maaci.A_AgvConnectType == Common.agvTypeStr[3])
            {
                this.agvConnect = new DA_AgvStm32Ins(this.maci);
            }
            this.WorkTime = DateTime.Now;
        }
        /// <summary>
        /// 读取Agv数据
        /// </summary>
        public void ReadAgvData()
        {
            try
            {
                bool isWork = false;    //是否开始 工作
                while (this.isRun)
                {
                    try
                    {
                        M_AgvInfo agvInfo = Common.maiDict[this.maci.A_Id];
                        //agvInfo.ControlRfid = agvInfo.AgvNo;
                        if (agvConnect.ReadData(ref agvInfo))  //读取成功
                        {
                            if (isWork == false)
                            {
                                if (DateTime.Now.Subtract(this.WorkTime).TotalSeconds > 30)
                                {
                                    isWork = true;
                                }
                            }
                            else
                            {
                                #region 升降台放行控制
                                //OPCClient.opcInformation.ConnectState = true;
                                if (agvInfo.QuestPass && agvInfo.IsPass == false && OPCClient.opcInformation.ConnectState)
                                {//AGV请求放行，判断AGV的位置 若opc连接失败，不放行
                                    if (agvInfo.Default7 > 0 || agvInfo.Default8 > 0)
                                    {//有任务 
                                        int _group = agvInfo.Type == Enumerations.agvType.type_1 ? 1 : 2;
                                        int _load = agvInfo.Default7;
                                        int _unload = agvInfo.Default8;
                                        int _rfid = agvInfo.VirtualRfid;
                                        bool isPass = false;
                                        StationInformation s = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && (o.Value.StationOperate.Trim() == _load.ToString() || o.Value.StationOperate.Trim() == _unload.ToString()) && (o.Value.StationType == (int)StationInformation.EStationType.Type_A || o.Value.StationType == (int)StationInformation.EStationType.Type_B) && o.Value.PassRfid == _rfid).Value;
                                        if (s != null)
                                        {
                                            if (s.LoadReady == false && s.UnloadReady && s.Dock && s.Undock == false && agvInfo.DragState == (int)Enumerations.EDragState.Decline)
                                            {//不带料车
                                                isPass = true;
                                            }
                                            else if (s.LoadReady && s.UnloadReady == false && s.Dock && s.Undock == false && agvInfo.DragState == (int)Enumerations.EDragState.LiftUp)
                                            {//带料车
                                                isPass = true;
                                            }
                                        }
                                        //isPass = true;
                                        if (isPass)
                                        {
                                            agvConnect.AgvOperate(Enumerations.AgvOperate.Pass);
                                            Thread.Sleep(100);
                                        }
                                    }
                                }
                                #endregion
                                #region 升降台允许离开
                                //OPCClient.opcInformation.ConnectState = true;
                                if (agvInfo.Arrived && agvInfo.IsPassPlatform == false && OPCClient.opcInformation.ConnectState)
                                {//AGV请求允许离开升降平台，判断AGV的位置 若opc连接失败，不放行
                                    if (agvInfo.Default7 > 0 || agvInfo.Default8 > 0)
                                    {//有任务 
                                        int _group = agvInfo.Type == Enumerations.agvType.type_1 ? 1 : 2;
                                        int _load = agvInfo.Default7;
                                        int _unload = agvInfo.Default8;
                                        int _rfid = agvInfo.VirtualRfid;
                                        bool isPlatformPass = false;
                                        StationInformation s = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && (o.Value.StationOperate.Trim() == _load.ToString() || o.Value.StationOperate.Trim() == _unload.ToString()) && (o.Value.StationType == (int)StationInformation.EStationType.Type_A || o.Value.StationType == (int)StationInformation.EStationType.Type_B)).Value;
                                        if (s != null)
                                        {
                                            try
                                            {
                                                bool isNoTask = false;
                                                if (!string.IsNullOrWhiteSpace(agvInfo.Task1))
                                                {
                                                    if (Common.taskDt[(int)agvInfo.Type].ContainsKey(agvInfo.Task1))
                                                    {
                                                        MA_AgvTaskInfo taskInfo = Common.taskDt[(int)agvInfo.Type][agvInfo.Task1];
                                                        if (taskInfo.T_Type == Enumerations.TaskType.Transport_A_C || taskInfo.T_Type == Enumerations.TaskType.Transport_A_F || taskInfo.T_Type == Enumerations.TaskType.Transport_B_D || taskInfo.T_Type == Enumerations.TaskType.Transport_B_E)
                                                        {//站点有料车，去拉料车
                                                            isNoTask = true;
                                                            if (s.LoadReady == false && s.UnloadReady && s.Dock == false && s.Undock)
                                                            {
                                                                isPlatformPass = true;
                                                            }
                                                        }
                                                        else if (taskInfo.T_Type == Enumerations.TaskType.Transport_E_A || taskInfo.T_Type == Enumerations.TaskType.Transport_F_B)
                                                        {//站点无料车，需要料车 
                                                            isNoTask = true;
                                                            if (s.LoadReady && s.UnloadReady == false && s.Dock == false && s.Undock)
                                                            {
                                                                isPlatformPass = true;
                                                            }
                                                        }
                                                    }
                                                }
                                                if (isNoTask == false)
                                                {
                                                    if (s.Dock == false && s.Undock)
                                                    {//没任务，不检测站点当前是需要料车或是有料车需要运送
                                                        isPlatformPass = true;
                                                    }
                                                }

                                            }
                                            catch { }
                                        }
                                        if (isPlatformPass)
                                        {
                                            agvConnect.AgvOperate(Enumerations.AgvOperate.PlatformPass);
                                            Thread.Sleep(100);
                                        }
                                    }
                                }
                                #endregion
                                #region 交通管制
                                //判断是否处于管制状态，再判断是否需要管制，或是需要解除管制                                
                                if (BA_AgvControl.IsControl(agvInfo.AgvNo))
                                {
                                    if (agvInfo.ControlFlag == false)
                                    {
                                        //agvInfo.ControlFlag = true;
                                        Debug.Print(string.Format("Agv{0} Write Lock {1}", agvInfo.AgvNo, DateTime.Now.ToString()));
                                        agvConnect.LockAgv();
                                    }
                                }
                                else
                                {
                                    if (agvInfo.ControlFlag)
                                    {
                                        //agvInfo.ControlFlag = false;
                                        Debug.Print(string.Format("Agv{0} Write Unlock {1}", agvInfo.AgvNo, DateTime.Now.ToString()));
                                        agvConnect.UnlockAgv();
                                    }
                                }
                                #endregion
                                #region 充电控制
                                //ChargeProcedure(ref agvInfo);
                                #endregion
                                #region 其它控制
                                //房门控制
                                //DoorControlProcedure(agvInfo);
                                //电梯控制
                                //ElevatorControlProcedure(agvInfo);
                                #endregion
                                #region 任务流程
                                TaskProcedure(ref agvInfo);
                                #endregion
                                #region 上下料完成状态
                                try
                                {
                                    if (agvInfo.OperationComplete)
                                    {
                                        AgvOperate(Enumerations.AgvOperate.OperationCompleteClear);
                                        Thread.Sleep(50);
                                    }
                                }
                                catch { }
                                #endregion
                                //Thread.Sleep(80);
                            }
                        }
                        else
                        {
                            Thread.Sleep(200);
                        }
                    }
                    catch
                    {
                        Thread.Sleep(50);
                    }
                }
            }
            catch { }
        }
        #region 充电流程
        private void ChargeProcedure(ref M_AgvInfo agvInfo)
        {
            #region 充电判断
            int agvNo = agvInfo.AgvNo;
            int bRfid = agvInfo.Rfid;
            int chargeSeconds = 0;  //充电秒数
            try
            {//充电桩绑定解除位于与充电桩通讯的线程中
                int bindChargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Rfid == bRfid).Key;//查询是否在某一充电区
                if (bindChargeNo > 0)
                {
                    int fullTime = Common.Instance.dtChargeLimitedInfo[agvInfo.Type].FullTime * 60;//满电时长
                    Common.Instance.dtChargeInfo[bindChargeNo].BindAgv = agvNo;
                    if (agvInfo.ChargeState == false && agvInfo.Mode == (int)Enumerations.AgvMode.AutoOperation && agvInfo.Task1 == string.Empty && agvInfo.Task2 == string.Empty && agvInfo.State == (int)Enumerations.AgvStatus.stop)
                    {//判断在充电位时，agv是否需要把充电接触器开关打开
                        AgvOperate(Enumerations.AgvOperate.ChargeOpen);
                        Thread.Sleep(20);
                    }
                    if (agvInfo.VoltageStatus != Enumerations.voltageStatus.normal && agvInfo.State == (int)Enumerations.AgvStatus.stop)
                    {//agv位于充电区，且处于低电压 
                        if (Common.Instance.dtChargeInfo[bindChargeNo].State != (int)EChargeCommState.Output && Common.Instance.dtChargeInfo[bindChargeNo].ChargeComm.Enable && agvInfo.IsChargeFullTime == false)
                        {//将充电桩伸出 
                            Common.Instance.dtChargeInfo[bindChargeNo].ChargeComm.isLowComm = true;
                            ChargeUdpClient.dtChargeUdp[bindChargeNo].WriteChargeOperate(ChargeUdpClient.EChargeOperate.Output);
                        }
                        else
                        {
                            Common.Instance.dtChargeInfo[bindChargeNo].ChargeComm.isLowComm = false;
                            if (Common.Instance.dtChargeInfo[bindChargeNo].BeginTime == new DateTime())
                            {//尚未开始计时 
                                Common.Instance.dtChargeInfo[bindChargeNo].BeginTime = DateTime.Now;
                            }
                            else
                            {
                                int chargeTime = Common.Instance.dtChargeLimitedInfo[agvInfo.Type].LimitedTime;
                                if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.lowVoltage)
                                    chargeTime = Common.Instance.dtChargeLimitedInfo[agvInfo.Type].LimiteLowTime;

                                if (DateTime.Now.Subtract(Common.Instance.dtChargeInfo[bindChargeNo].BeginTime).TotalSeconds > chargeTime)
                                {
                                    if (agvInfo.Voltage > Common.Instance.dtChargeLimitedInfo[agvInfo.Type].ChargeVoltage)
                                    {
                                        agvInfo.VoltageStatus = Enumerations.voltageStatus.normal;
                                    }
                                    else
                                    {//若当前电压小于充电桩充电电压，则必须要充电
                                        Common.Instance.dtChargeInfo[bindChargeNo].BeginTime = DateTime.Now;
                                    }
                                }
                                else if (agvInfo.Voltage >= Common.Instance.dtChargeLimitedInfo[agvInfo.Type].LimitedEnable)
                                {
                                    agvInfo.VoltageStatus = Enumerations.voltageStatus.normal;
                                }
                                if (DateTime.Now.Subtract(Common.Instance.dtChargeInfo[bindChargeNo].BeginTime).TotalSeconds > fullTime)
                                {//判断电压值是否低于充电电压，若低于，则将充电时长清除重新计数。若不为充电电压，则将充电桩缩回
                                    int chargeVoltage = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].ChargeVoltage;
                                    //if (ChargeLimitedInfo.dtAgvChargeVoltage.ContainsKey(agvInfo.AgvNo))
                                    //{
                                    //    if (ChargeLimitedInfo.dtAgvChargeVoltage[agvInfo.AgvNo] > 0)
                                    //    {
                                    //        chargeVoltage = Convert.ToInt32(ChargeLimitedInfo.dtAgvChargeVoltage[agvInfo.AgvNo] * 10);
                                    //    }
                                    //}
                                    if (agvInfo.Voltage < chargeVoltage)
                                    {
                                        agvInfo.IsChargeFullTime = false;
                                        agvInfo.VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                                        Common.Instance.dtChargeInfo[bindChargeNo].BeginTime = DateTime.Now;
                                    }
                                    else
                                    {//若电压高于充电电压，则将充电桩缩回                                      
                                        agvInfo.IsChargeFullTime = true;
                                        if (Common.Instance.dtChargeInfo[bindChargeNo].State == (int)EChargeCommState.Output)
                                            ChargeUdpClient.dtChargeUdp[bindChargeNo].WriteChargeOperate(ChargeUdpClient.EChargeOperate.Input);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (DateTime.Now.Subtract(Common.Instance.dtChargeInfo[bindChargeNo].BeginTime).TotalSeconds > fullTime)
                        {//判断电压值是否低于充电电压，若低于，则将充电时长清除重新计数。若不为充电电压，则将充电桩缩回
                            int chargeVoltage = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].ChargeVoltage;
                            if (agvInfo.Voltage < chargeVoltage)
                            {
                                agvInfo.IsChargeFullTime = false;
                                agvInfo.VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                                Common.Instance.dtChargeInfo[bindChargeNo].BeginTime = DateTime.Now;
                            }
                            if (DateTime.Now.Subtract(Common.Instance.dtChargeInfo[bindChargeNo].BeginTime).TotalSeconds > fullTime + 3600)
                            {//若距离充满电超过1小时，则可让AGV重新充电10
                                agvInfo.IsChargeFullTime = false;
                                agvInfo.VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                                Common.Instance.dtChargeInfo[bindChargeNo].BeginTime = DateTime.Now.AddSeconds(600 - Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedTime);
                            }
                        }
                    }
                    if (Common.Instance.dtChargeInfo[bindChargeNo].BeginTime != new DateTime())
                    {
                        chargeSeconds = Convert.ToInt32(DateTime.Now.Subtract(Common.Instance.dtChargeInfo[bindChargeNo].BeginTime).TotalSeconds);
                    }

                    #region 自动生成充电任务
                    //if (DateTime.Now.Subtract(Common.Instance.dtChargeInfo[bindChargeNo].BeginTime).TotalSeconds > fullTime && Common.isLoopCharge)
                    //{//如果大于满电时间，且电压处于正常状态，且已勾选循环充电选项，则将其驶出
                    //    int waitNo = Common.Instance.dtChargeInfo[bindChargeNo].Group;
                    //    if (waitNo > 0 && waitNo <= 2)
                    //    {
                    //        if (Common.Instance.dtChargeInfo.Any(o => o.Value.BindAgv <= 0 && o.Value.Group == waitNo) == false && Common.maiDict[agvNo].Type == Enumerations.agvType.type_1)//只针对分容测试AGV
                    //        {//当前组别的充电桩有空余位置，则不需要让出。若没有，则进行下一步判断
                    //            int waitRfid = Common.Instance.dtCapacityTestWait[waitNo].Rfid;
                    //            if (agvInfo.Task1 == string.Empty && agvInfo.Task2 == string.Empty)
                    //            {
                    //                if (Common.maiDict.Any(o => o.Value.Rfid == waitRfid && o.Value.Task1 == string.Empty && o.Value.Task2 == string.Empty && o.Value.Mode == (int)Enumerations.AgvMode.AutoOperation))
                    //                {//判断是否有AGV在待机点，若有,表明需要进入充电桩，则进行下一步判断
                    //                    if (Common.maiDict.Any(o => o.Value.AgvNo != agvNo && Common.Instance.dtChargeInfo.Any(p => p.Value.Rfid == o.Value.Rfid && p.Value.Group == waitNo) && (o.Value.Task1 != string.Empty || o.Value.Task2 != string.Empty)))
                    //                    {//判断是否有AGV处于该组别的充电桩内，且存在任务，若无，则生成任务
                    //                        lock (TaskAllocation.objLockCapcityLoad)
                    //                            CreatTask.CreateCapTestNullOperate(waitNo, agvInfo.AgvNo, Common.bufferGroup);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //} 
                    #endregion
                }
                else
                {
                    agvInfo.IsChargeFullTime = false;
                }
            }
            catch { }
            agvInfo.Default4 = chargeSeconds;
            #endregion
            #region 充电任务生成
            try
            {//任务类型1充电
                int _cRfid = agvInfo.Rfid;
                if (agvInfo.Task1 == string.Empty && agvInfo.Task2 == string.Empty && (agvInfo.VoltageStatus != Enumerations.voltageStatus.normal || ((Common.matchStations.Any(p => p.Value.AgvNo == agvNo && p.Value.Enable) == false || Common.isAgvMatchStationTask == false) && (Common.isAutoTask == false || (Common.isAutoTask == true && Common.subCabinetAutoTaskAgvLs.Contains(agvNo) == false))
                    && agvInfo.State == (int)Enumerations.AgvStatus.stop && Common.Instance.dtCapacityTestWait.Any(o => o.Value.Rfid == _cRfid))))//上侧agv电压过低，需要生成充电任务
                {
                    int waitNo = Common.Instance.dtCapacityTestWait.FirstOrDefault(o => o.Value.Rfid == _cRfid).Value.Number;
                    int chargeNo = 0;
                    //if (agvInfo.AgvNo == 7 || agvInfo.AgvNo == 38)
                    //    chargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Group == waitNo && o.Key != 11 && o.Value.ChargeComm.Enable == true && o.Value.BindAgv <= 0 && o.Value.ChargeType == EChargeType.CapacityTest && o.Value.State != (int)EChargeCommState.OffLine).Key;
                    //else
                    chargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Group == waitNo && o.Value.ChargeComm.Enable == true && o.Value.BindAgv <= 0 && o.Value.ChargeType == EChargeType.CapacityTest && o.Value.State != (int)EChargeCommState.OffLine).Key;
                    if (chargeNo > 0)
                    {
                        StationInformation st = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationRfidLs.Contains(Common.Instance.dtChargeInfo[chargeNo].Rfid) && o.Value.StationType == (int)StationInformation.EStationType.Charge).Value;
                        MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                        taskInfo.T_Type = Enumerations.TaskType.Charge_Go;
                        taskInfo.T_State = Enumerations.TaskStatus.Book;
                        taskInfo.T_Id = string.Format("{0}_{1}", st.StationMatchValue, DateTime.Now.ToString("HHmmfff"));
                        RouteInfo re = new RouteInfo(RouteType.ChargeCap, Common.Instance.dtChargeInfo[chargeNo].Rfid, Convert.ToInt32(st.StationOperate), string.Format("Go to Chage{0}", chargeNo));
                        taskInfo.T_Process.Add(re);
                        taskInfo.ProcessIndex = 0;
                        taskInfo.T_CreateTime = DateTime.Now;
                        taskInfo.T_Level = 0;
                        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        try
                        {
                            taskInfo.T_Description = st.StationMatchValue;
                            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        }
                        catch { }
                        taskInfo.T_AgvNo = agvInfo.AgvNo;
                        agvInfo.Task2 = taskInfo.T_Id;
                        Common.Instance.dtChargeInfo[chargeNo].BindAgv = agvInfo.AgvNo + 100;
                        Common.Instance.dtChargeInfo[chargeNo].BeginTime = new DateTime();
                        if (agvInfo.VoltageStatus == Enumerations.voltageStatus.normal)
                        {
                            if (agvInfo.Voltage < Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedLow)
                            {
                                agvInfo.VoltageStatus = Enumerations.voltageStatus.lowVoltage;
                                Common.Instance.dtChargeInfo[chargeNo].BeginTime = DateTime.Now.AddSeconds(60 - Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimiteLowTime);
                            }
                        }
                        Common.taskDt[(int)agvInfo.Type][taskInfo.T_Id] = taskInfo;
                    }
                }
            }
            catch { }
            #endregion
        }
        #endregion
        #region 房门控制流程
        private void DoorControlProcedure(M_AgvInfo agvInfo)
        {
            try
            {//清除房门控制标志 
                int doorNo = Common.Instance.dtDoorInfo.FirstOrDefault(o => o.Value.CallRfids.Contains(agvInfo.ControlRfid) == false).Key;
                if (doorNo > 0)
                {
                    if (Common.Instance.dtDoorInfo[doorNo].HoldSwitch)
                    {
                        byte relationNumber = 1;
                        if (Common.Instance.dtDoorInfo[doorNo].Relation > 0)
                        {
                            relationNumber = Common.Instance.dtDoorInfo[doorNo].RelationNumber;
                        }
                        DoorUdpClient.dtDoorUdp[doorNo].WriteDoorOperate(DoorUdpClient.EDoorOperate.Close, relationNumber);
                    }
                    else
                    {
                        Common.Instance.dtDoorInfo[doorNo].BindAgv = -1;
                    }
                }
                doorNo = Common.Instance.dtDoorInfo.FirstOrDefault(o => o.Value.CallRfids.Contains(agvInfo.ControlRfid)).Key;
                if (doorNo > 0)  //进入房门呼叫RFID
                {
                    if (Common.Instance.dtDoorInfo[doorNo].BindAgv == agvInfo.AgvNo || Common.Instance.dtDoorInfo[doorNo].BindAgv <= 0)
                    {//该房门无AGV绑定，或绑定AGV为当前AGV 
                        if (Common.Instance.dtDoorInfo[doorNo].HoldSwitch)//已经按住开门按钮
                        {
                            if (Common.Instance.dtDoorInfo[doorNo].State == (int)DoorInfo.EDoorState.Open)  //门已经开启
                            { //判断是否放行AGV，若没放行，则执行放行命令
                                if (agvInfo.StationStopState)
                                {
                                    ((DA_AgvStm32)agvConnect).StationUnlock(1);
                                }
                            }
                            else
                            {//执行AGV停止命令，直到门开，方可放行AGV 
                                if (agvInfo.StationStopState == false)
                                {
                                    ((DA_AgvStm32)agvConnect).StationLock();
                                }
                            }
                        }
                        else
                        {
                            byte relateionNumber = 1;
                            if (Common.Instance.dtDoorInfo[doorNo].Relation > 0)
                            {
                                relateionNumber = Common.Instance.dtDoorInfo[doorNo].RelationNumber;
                            }
                            DoorUdpClient.dtDoorUdp[doorNo].WriteDoorOperate(DoorUdpClient.EDoorOperate.Open, relateionNumber);
                        }
                    }
                }
            }
            catch { }
        }
        #endregion
        #region 电梯控制流程
        /// <summary>
        /// 判断是否受电梯控制
        /// </summary>
        /// <param name="agvInfo"></param>        
        /// <returns>返回电梯是否受控制，若受控制，则不写入路段</returns>
        private bool ElevatorControlProcedure(M_AgvInfo agvInfo)
        {
            try
            {
                int eleNo = Common.Instance.dtElevatorInfo.FirstOrDefault(o => o.Value.CallRfids.Contains(agvInfo.ControlRfid)).Key;
                if (eleNo <= 0)
                {
                    return false;
                }
                else
                {//判断该AGV是否要使用电梯
                    int eleRfid = Common.Instance.dtElevatorInfo[eleNo].Rfid;
                    if (!agvInfo.lsRoutes.Any(o => o.Value.EdgeRfidNum == eleRfid))
                    {//AGV的路段集合没有电梯RFID,则不需要使用电梯
                        return false;
                    }
                    else
                    {
                        if (Common.Instance.dtElevatorInfo[eleNo].BindAgv == agvInfo.AgvNo || Common.Instance.dtElevatorInfo[eleNo].BindAgv <= 0)
                        {
                            bool isControl = false;
                            try
                            {
                                //Common.Instance.dtElevatorInfo[eleNo].BindAgv = agvInfo.AgvNo;
                                switch (Common.Instance.dtElevatorInfo[eleNo].state)
                                {
                                    case ElevatorStatus.Line:
                                        isControl = true;//电梯异常，agv停止写入路段
                                        break;
                                    case ElevatorStatus.init://设置起始楼层及结束楼层
                                        int bGroup = Common.rfidDt[agvInfo.ControlRfid].Group;
                                        Common.Instance.dtElevatorInfo[eleNo].BeginFloor = bGroup;
                                        int eRfid = agvInfo.lsRoutes.Skip(agvInfo.RoutesIndex).ToList().Find(o => Common.rfidDt[o.Value.EdgeRfidNum].Group != 0 && Common.rfidDt[o.Value.EdgeRfidNum].Group != bGroup).Value.EdgeRfidNum;
                                        Common.Instance.dtElevatorInfo[eleNo].EndFloor = Common.rfidDt[eRfid].Group;
                                        Common.Instance.dtElevatorInfo[eleNo].BindAgv = agvInfo.AgvNo;//绑定agv
                                        if (!Common.Instance.dtElevatorInfo[eleNo].StopRfids.Contains(agvInfo.ControlRfid))
                                        {//可尚未到达停止的RFID，AGV可运行
                                            isControl = false;
                                        }
                                        else
                                        {//到达停止的rfid范围，AGV停止，等待电梯门开
                                            isControl = true;
                                        }
                                        break;
                                    case ElevatorStatus.elevatorBeginOpen:
                                        if (Common.Instance.dtElevatorInfo[eleNo].Rfid == agvInfo.ControlRfid)
                                        {//AGV进入电梯，且处于停止状态
                                            isControl = true;
                                            if (Common.Instance.dtElevatorInfo[eleNo].Rfid == agvInfo.Rfid)//若已到达电梯RFID，则判断AGV进入电梯完毕
                                            {
                                                Common.Instance.dtElevatorInfo[eleNo].state = ElevatorStatus.agvInFinish;
                                            }
                                        }
                                        else
                                        {//电梯门开，AGV进入电梯
                                            isControl = false;
                                        }
                                        break;
                                    case ElevatorStatus.agvInFinish:
                                        isControl = true;//已进入电梯，返回true，不可写入路段
                                        break;
                                    case ElevatorStatus.elevatorEndOpen:
                                        isControl = false;//电梯门开，AGV可写入路段
                                        if (Common.Instance.dtElevatorInfo[eleNo].Rfid != agvInfo.Rfid)
                                        {//AGV已移出电梯，更新状态
                                            Common.Instance.dtElevatorInfo[eleNo].state = ElevatorStatus.agvOutFinish;
                                        }
                                        break;
                                    case ElevatorStatus.agvOutFinish:
                                        isControl = false;
                                        break;
                                }
                                return isControl;
                            }
                            catch { return false; }
                        }
                        else
                        {//受管制
                            return true;
                        }
                    }
                }

            }
            catch
            {
                return true;
            }
        }
        #endregion
        #region 任务流程
        #region 总任务调度
        /// <summary>
        /// 任务执行流程（从任务开始到结束）
        /// </summary>
        private void TaskProcedure(ref M_AgvInfo agvInfo)
        {//为防止没任务时，需要去充电位或回待机点的路段集合生成，是否有任务放到各自AGV类型中去判断
            bool isWrite = false;
            try
            {
                agvInfo.Mode = (int)Enumerations.AgvMode.AutoOperation;
                if (string.IsNullOrEmpty(agvInfo.Task1) && string.IsNullOrEmpty(agvInfo.Task2))
                {//无任务时，启动信号清除
                    agvInfo.IsStart = false;
                }
                if (agvInfo.Mode == (int)Enumerations.AgvMode.AutoOperation)
                {//自动模式下方可执行写入路段信息操作
                    if (agvInfo.IsAgvTest == false)
                    {
                        //if (agvInfo.Task1 != string.Empty)
                        //{
                        //    if (Common.taskDt.ContainsKey(agvInfo.Task1))
                        //    {//任务存在
                        //switch (agvInfo.Type)
                        //{
                        //    case Enumerations.agvType.type_1:
                        //        isWrite = AgvType1Task(ref agvInfo);
                        //        break;
                        //    case Enumerations.agvType.type_2:
                        //        isWrite = AgvType2Task(ref agvInfo);
                        //        break;
                        //    case Enumerations.agvType.type_3:
                        //        isWrite = AgvType3Task(ref agvInfo);
                        //        break;
                        //}
                        isWrite = AgvTypeTask(ref agvInfo);
                        //    }
                        //}
                        //else
                        //{
                        //    if (agvInfo.Task2 != string.Empty)
                        //    {
                        //        if (Common.taskDt.ContainsKey(agvInfo.Task2))
                        //        {
                        //            agvInfo.Task1 = agvInfo.Task2;
                        //            agvInfo.Task2 = string.Empty;
                        //            Common.taskDt[agvInfo.Task1].T_Status = Enumerations.TaskStatus.Start;
                        //        }
                        //        else
                        //        {
                        //            agvInfo.Task2 = string.Empty;
                        //        }

                        //    }
                        //}
                    }
                    else
                    { //测试模式
                        isWrite = AgvTestTask(ref agvInfo);
                    }
                }
                else
                {//手动模式下，考虑是否要将当前所有路段集合清除

                }
            }
            catch { }
            #region 虚拟管制卡
            //VirtualControlRfid(ref agvInfo);
            #endregion
            //if (isWrite) WriteRoute(ref agvInfo);
        }
        #endregion
        #region 测试任务
        /// <summary>
        /// 测试任务
        /// </summary>
        /// <param name="agvInfo"></param>
        private bool AgvTestTask(ref M_AgvInfo agvInfo)
        {
            bool isWrite = false;
            try
            {

            }
            catch { }
            return isWrite;
        }
        #endregion
        #region 类型1
        /// <summary>
        /// 类型1AGV任务调度方式
        /// </summary>
        /// <param name="agvInfo"></param>
        private bool AgvTypeTask(ref M_AgvInfo agvInfo)
        {
            bool isWrite = true;
            try
            {
                if (string.IsNullOrEmpty(agvInfo.Task1))
                {
                    if (!string.IsNullOrEmpty(agvInfo.Task2))
                    {
                        if (Common.taskDt[(int)agvInfo.Type].ContainsKey(agvInfo.Task2))
                        {
                            if (Common.taskDt[(int)agvInfo.Type][agvInfo.Task2].T_AgvNo == agvInfo.AgvNo)
                            {
                                agvInfo.Task1 = agvInfo.Task2;
                                agvInfo.Task2 = string.Empty;
                                Common.taskDt[(int)agvInfo.Type][agvInfo.Task1].T_State = Enumerations.TaskStatus.Start;
                                Common.taskDt[(int)agvInfo.Type][agvInfo.Task1].T_StartTime = DateTime.Now;
                            }
                            else
                            {
                                agvInfo.Task2 = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        agvInfo.Task2 = string.Empty;
                    }
                }
                else
                {
                    if (Common.taskDt[(int)agvInfo.Type].ContainsKey(agvInfo.Task1))
                    {
                        MA_AgvTaskInfo taskInfo = Common.taskDt[(int)agvInfo.Type][agvInfo.Task1];
                        int indexRoute = taskInfo.ProcessIndex;
                        int _group = agvInfo.Type == Enumerations.agvType.type_1 ? 1 : 2;
                        int _Virtualrfid = agvInfo.VirtualRfid;
                        RouteInfo r = taskInfo.T_Process[indexRoute];
                        string setKey = string.Empty;
                        string setTargetKey = string.Empty;
                        switch (r.State)
                        {
                            case 0:
                                if (agvInfo.Default7 != r.SourceStation || agvInfo.Default8 != r.Station)
                                {//向AGV写入路段
                                    bool isNotInCorD = false;  //若AGV在C或D站点时，必须要回到待机才向AGV发路段
                                    int _rfidCorD = agvInfo.VirtualRfid;
                                    isNotInCorD = Common.Instance.dtStationInformation.Any(o => o.Value.StationRfidLs.Contains(_rfidCorD) && (o.Value.StationType == (int)StationInformation.EStationType.Charge
                                        || o.Value.StationType == (int)StationInformation.EStationType.Type_A
                                        || o.Value.StationType == (int)StationInformation.EStationType.Type_B
                                        || o.Value.StationType == (int)StationInformation.EStationType.Type_E
                                        || o.Value.StationType == (int)StationInformation.EStationType.Type_F
                                        || o.Value.StationType == (int)StationInformation.EStationType.Wait));
                                    if (isNotInCorD)
                                    {
                                        if (agvInfo.State == (int)Enumerations.AgvStatus.stop && agvInfo.IsCanReceiveTask)
                                        {
                                            agvConnect.WriteTask(taskInfo);
                                        }
                                    }
                                }
                                else
                                {//路段进入执行状态
                                    //判断上位机是否给AGV发送启动信号
                                    if (agvInfo.State == (int)Enumerations.AgvStatus.stop && !agvInfo.IsStart)
                                    {//发送启动信号 
                                        agvConnect.AgvOperate(Enumerations.AgvOperate.Start);
                                        Thread.Sleep(100);
                                    }
                                    switch (r.Route)
                                    {
                                        case RouteType.E_A://设定站点为预定状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E).Key;
                                            break;
                                        case RouteType.F_B://设定站点为预定状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F).Key;
                                            break;
                                        case RouteType.B_E:
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E).Key;
                                            break;
                                        case RouteType.A_F:
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F).Key;
                                            break;
                                        case RouteType.C_F://将对应的C、F站点都设定为预定状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_C && o.Value.StationOperate == r.SourceStation.ToString()).Key;
                                            setTargetKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F).Key;
                                            break;
                                        case RouteType.A_C://设定站点为预定状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_C && o.Value.StationOperate == r.Station.ToString()).Key;
                                            break;
                                        case RouteType.D_E://将对应的D、E站点都设定为预定状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_D && o.Value.StationOperate == r.SourceStation.ToString()).Key;
                                            setTargetKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E).Key;
                                            break;
                                        case RouteType.B_D://设定站点为预定状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_D && o.Value.StationOperate == r.Station.ToString()).Key;
                                            break;
                                        case RouteType.GoCharge:
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Charge && o.Value.StationOperate == r.Station.ToString()).Key;
                                            break;
                                    }
                                    if (!string.IsNullOrWhiteSpace(setKey))
                                    {
                                        Common.Instance.dtStationInformation[setKey].LastState = Common.Instance.dtStationInformation[setKey].State;
                                        Common.Instance.dtStationInformation[setKey].State = (int)EStationState.Book;
                                        Common.Instance.dtStationInformation[setKey].bindAgvNo = agvInfo.AgvNo;
                                    }
                                    if (!string.IsNullOrWhiteSpace(setTargetKey))
                                    {
                                        Common.Instance.dtStationInformation[setTargetKey].LastState = Common.Instance.dtStationInformation[setTargetKey].State;
                                        Common.Instance.dtStationInformation[setTargetKey].State = (int)EStationState.Book;
                                        Common.Instance.dtStationInformation[setTargetKey].bindAgvNo = agvInfo.AgvNo;
                                    }
                                    r.State = 1;
                                }
                                break;
                            case 1:
                                if (agvInfo.Default7 == 0 && agvInfo.Default8 != 0)
                                {
                                    switch (r.Route)
                                    {
                                        case RouteType.E_A://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E).Key;
                                            break;
                                        case RouteType.F_B://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F).Key;
                                            break;
                                        case RouteType.C_F://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_C && o.Value.StationOperate == r.SourceStation.ToString()).Key;
                                            break;
                                        case RouteType.D_E://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_D && o.Value.StationOperate == r.SourceStation.ToString()).Key;
                                            break;
                                    }
                                    if (!string.IsNullOrWhiteSpace(setKey))
                                    {
                                        if (Common.Instance.dtStationInformation[setKey].bindAgvNo == agvInfo.AgvNo)
                                        {
                                            Common.Instance.dtStationInformation[setKey].State = (int)EStationState.Free;
                                            Common.Instance.dtStationInformation[setKey].bindAgvNo = 0;
                                        }
                                    }
                                }
                                else if (agvInfo.Default7 == 0 && agvInfo.Default8 == 0 && agvInfo.Speed == 0)
                                {//该路段已执行完成，可将路段切换为完成状态，并更新相应的状态 
                                    bool isClearStationState = true;
                                    if (r.Station > 0)
                                    {
                                        int _route = r.Station;
                                        isClearLoadQuery = Common.Instance.dtStationInformation.FirstOrDefault(o => int.Parse(o.Value.StationOperate) == _route).Value.StationRfidLs.Contains(agvInfo.VirtualRfid);
                                    }
                                    //int _routeOperate = r.Station;
                                    //if (r.Station == 0) _routeOperate = r.SourceStation;
                                    //bool isUnload = false;
                                    //try
                                    //{
                                    //    isUnload = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && (int.Parse(o.Value.StationOperate) == _routeOperate)).Value.StationRfidLs.Contains(agvInfo.VirtualRfid);//判断是否在下料点
                                    //}
                                    //catch { }
                                    //if (isUnload)
                                    //{
                                    switch (r.Route)
                                    {
                                        case RouteType.A_F://设定站点为满状态
                                            if (isClearStationState)
                                                Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Type_F && o.Value.Group == _group).Value.State = (int)EStationState.Busy;
                                            break;
                                        case RouteType.A_C://设定站点为满状态
                                            if (isClearStationState)
                                                Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Type_C && o.Value.StationOperate == r.Station.ToString() && o.Value.Group == _group).Value.State = (int)EStationState.Busy;
                                            break;
                                        case RouteType.C_F://设定站点为满状态
                                            if (isClearStationState)
                                                Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Type_F && o.Value.StationOperate == r.Station.ToString() && o.Value.Group == _group).Value.State = (int)EStationState.Busy;
                                            break;
                                        case RouteType.B_E://设定站点为满状态
                                            if (isClearStationState)
                                                Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Type_E && o.Value.StationOperate == r.Station.ToString() && o.Value.Group == _group).Value.State = (int)EStationState.Busy;
                                            break;
                                        case RouteType.B_D://设定站点为满状态
                                            if (isClearStationState)
                                                Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Type_D && o.Value.StationOperate == r.Station.ToString() && o.Value.Group == _group).Value.State = (int)EStationState.Busy;
                                            break;
                                        case RouteType.D_E://设定站点为满状态
                                            if (isClearStationState)
                                                Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Type_E && o.Value.StationOperate == r.Station.ToString() && o.Value.Group == _group).Value.State = (int)EStationState.Busy;
                                            break;
                                        case RouteType.LeaveCharge:
                                            try
                                            {
                                                int _agvNo = agvInfo.AgvNo;
                                                string cKeyString = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Charge && o.Value.bindAgvNo == _agvNo).Key;
                                                Common.Instance.dtStationInformation[cKeyString].State = (int)EStationState.Free;
                                                Common.Instance.dtStationInformation[cKeyString].bindAgvNo = 0;
                                            }
                                            catch { }
                                            break;
                                    }
                                    switch (r.Route)
                                    {
                                        case RouteType.E_A://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E).Key;
                                            break;
                                        case RouteType.F_B://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F).Key;
                                            break;
                                        case RouteType.C_F://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_C && o.Value.StationOperate == r.SourceStation.ToString()).Key;
                                            break;
                                        case RouteType.D_E://设定站点为空闲状态
                                            setKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_D && o.Value.StationOperate == r.SourceStation.ToString()).Key;
                                            break;
                                    }
                                    if (!string.IsNullOrWhiteSpace(setKey))
                                    {
                                        if (Common.Instance.dtStationInformation[setKey].bindAgvNo == agvInfo.AgvNo)
                                        {
                                            Common.Instance.dtStationInformation[setKey].State = (int)EStationState.Free;
                                            Common.Instance.dtStationInformation[setKey].bindAgvNo = 0;
                                        }
                                    }
                                    //判断是否要往AB PLC写入A、B站点状态情况
                                    r.State = 2;
                                    //}
                                }
                                break;
                            case 2:
                                if (indexRoute >= taskInfo.T_Process.Count - 1)
                                {//任务完成，记录任务，并删除任务 
                                    taskInfo.T_State = Enumerations.TaskStatus.End;
                                    taskInfo.T_FinishTime = DateTime.Now;
                                    DA_AgvTaskInfo dati = new DA_AgvTaskInfo();
                                    dati.InsertAgvTaskInfo(taskInfo);
                                    while (Common.taskDt[(int)agvInfo.Type].ContainsKey(agvInfo.Task1))
                                    {
                                        Common.taskDt[(int)agvInfo.Type].Remove(agvInfo.Task1);
                                    }
                                    agvInfo.Task1 = string.Empty;
                                }
                                else
                                {//执行下一路段
                                    bool isCreatTask = false;
                                    try
                                    {
                                        if (taskInfo.T_Process[indexRoute].Route == RouteType.B_E || taskInfo.T_Process[indexRoute].Route == RouteType.D_E || taskInfo.T_Process[indexRoute].Route == RouteType.B_D)
                                        {
                                            StationInformation bStation = Common.Instance.dtStationInformation.OrderBy(o => o.Value.UpdateTime).ToDictionary(o => o.Key, p => p.Value).FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_B && o.Value.State == (int)EStationState.Busy && o.Value.LoadReady && o.Value.UnloadReady == false && o.Value.StationEnable).Value;
                                            if (bStation != null)
                                            {
                                                StationInformation fStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F && o.Value.State == (int)EStationState.Busy && o.Value.StationEnable).Value;//查询F点是否有物料
                                                if (fStation != null && Common.maiDict.Any(o => fStation.StationRfidLs.Contains(o.Value.VirtualRfid)) == false)
                                                {
                                                    lock (TaskAllocation.objLockTask)
                                                    {
                                                        #region Transport_F-B
                                                        MA_AgvTaskInfo taskInfoFB = InitTask(agvInfo.AgvNo, Enumerations.TaskType.Transport_F_B, bStation.Key, (int)agvInfo.Type);
                                                        taskInfoFB.ProcessIndex = 0;
                                                        string desc = string.Empty;
                                                        RouteInfo r1 = new RouteInfo();
                                                        r1.Index = 0;
                                                        r1.SourceStation = int.Parse(fStation.StationOperate);
                                                        r1.Station = int.Parse(bStation.StationOperate);
                                                        r1.Route = RouteType.F_B;
                                                        r1.Description = string.Format("{0}_{1}", fStation.StationName, bStation.StationName);
                                                        r1.Operation = 0;
                                                        r1.State = 0;
                                                        desc += r1.Description;
                                                        taskInfoFB.T_Process.Add(r1);

                                                        RouteInfo r2 = new RouteInfo();
                                                        r2.Index = 0;
                                                        r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait2").Value.StationOperate);
                                                        r2.Station = 0;
                                                        r2.Route = RouteType.GoWait2;
                                                        r2.Description = "Go wait2";
                                                        r2.Operation = 0;
                                                        r2.State = 0;
                                                        desc += "|" + r2.Description;
                                                        taskInfoFB.T_Process.Add(r2);
                                                        taskInfoFB.T_Description = desc;

                                                        //记录删除当前任务
                                                        taskInfo.T_State = Enumerations.TaskStatus.End;
                                                        taskInfo.T_FinishTime = DateTime.Now;
                                                        int lastRouteIndex = taskInfo.T_Description.LastIndexOf('|');
                                                        taskInfo.T_Description = taskInfo.T_Description.Remove(lastRouteIndex);
                                                        DA_AgvTaskInfo dati = new DA_AgvTaskInfo();
                                                        dati.InsertAgvTaskInfo(taskInfo);
                                                        while (Common.taskDt[(int)agvInfo.Type].ContainsKey(agvInfo.Task1))
                                                        {
                                                            Common.taskDt[(int)agvInfo.Type].Remove(agvInfo.Task1);
                                                        }
                                                        agvInfo.Task1 = string.Empty;

                                                        Common.taskDt[(int)agvInfo.Type][taskInfoFB.T_Id] = taskInfoFB;
                                                        agvInfo.Task2 = taskInfoFB.T_Id;
                                                        isCreatTask = true;
                                                        #endregion
                                                        Thread.Sleep(50);
                                                    }
                                                }
                                            }
                                        }
                                        else if (taskInfo.T_Process[indexRoute].Route == RouteType.A_F || taskInfo.T_Process[indexRoute].Route == RouteType.C_F || taskInfo.T_Process[indexRoute].Route == RouteType.A_C)
                                        {
                                            StationInformation aStation = Common.Instance.dtStationInformation.OrderBy(o => o.Value.UpdateTime).ToDictionary(o => o.Key, p => p.Value).FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_A && o.Value.State == (int)EStationState.Busy && o.Value.LoadReady && o.Value.UnloadReady == false && o.Value.StationEnable).Value;
                                            if (aStation != null)
                                            {
                                                StationInformation eStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E && o.Value.State == (int)EStationState.Busy && o.Value.StationEnable).Value;//查询E点是否有物料
                                                if (eStation != null && Common.maiDict.Any(o => eStation.StationRfidLs.Contains(o.Value.VirtualRfid)) == false)
                                                {
                                                    lock (TaskAllocation.objLockTask)
                                                    {
                                                        #region Transport_E-A
                                                        MA_AgvTaskInfo taskInfoEA = InitTask(agvInfo.AgvNo, Enumerations.TaskType.Transport_E_A, aStation.Key, (int)agvInfo.Type);
                                                        taskInfoEA.ProcessIndex = 0;
                                                        string desc = string.Empty;
                                                        RouteInfo r1 = new RouteInfo();
                                                        r1.Index = 0;
                                                        r1.SourceStation = int.Parse(eStation.StationOperate);
                                                        r1.Station = int.Parse(aStation.StationOperate);
                                                        r1.Route = RouteType.E_A;
                                                        r1.Description = string.Format("{0}_{1}", eStation.StationName, aStation.StationName);
                                                        r1.Operation = 0;
                                                        r1.State = 0;
                                                        desc += r1.Description;
                                                        taskInfoEA.T_Process.Add(r1);

                                                        RouteInfo r2 = new RouteInfo();
                                                        r2.Index = 0;
                                                        r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait1").Value.StationOperate);
                                                        r2.Station = 0;
                                                        r2.Route = RouteType.GoWait1;
                                                        r2.Description = "Go wait1";
                                                        r2.Operation = 0;
                                                        r2.State = 0;
                                                        desc += "|" + r2.Description;
                                                        taskInfoEA.T_Process.Add(r2);
                                                        taskInfoEA.T_Description = desc;

                                                        //记录删除当前任务
                                                        taskInfo.T_State = Enumerations.TaskStatus.End;
                                                        taskInfo.T_FinishTime = DateTime.Now;
                                                        int lastRouteIndex = taskInfo.T_Description.LastIndexOf('|');
                                                        taskInfo.T_Description = taskInfo.T_Description.Remove(lastRouteIndex);
                                                        DA_AgvTaskInfo dati = new DA_AgvTaskInfo();
                                                        dati.InsertAgvTaskInfo(taskInfo);
                                                        while (Common.taskDt[(int)agvInfo.Type].ContainsKey(agvInfo.Task1))
                                                        {
                                                            Common.taskDt[(int)agvInfo.Type].Remove(agvInfo.Task1);
                                                        }
                                                        agvInfo.Task1 = string.Empty;

                                                        Common.taskDt[(int)agvInfo.Type][taskInfoEA.T_Id] = taskInfoEA;
                                                        agvInfo.Task2 = taskInfoEA.T_Id;
                                                        isCreatTask = true;
                                                        #endregion
                                                        Thread.Sleep(50);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch { }
                                    if (!isCreatTask)
                                    {
                                        taskInfo.ProcessIndex++;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        agvInfo.Task1 = string.Empty;
                    }
                }
            }
            catch { }
            return isWrite;
        }
        /// <summary>
        /// 初始化任务
        /// </summary>
        /// <param name="agvNo">绑定agv编号</param>
        /// <param name="taskType">任务类型</param>
        /// <param name="callStationKey">呼叫站点</param>
        /// <returns></returns>
        private MA_AgvTaskInfo InitTask(int agvNo, Enumerations.TaskType taskType, string callStationKey, int group)
        {
            MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
            if (!string.IsNullOrEmpty(callStationKey))
                taskInfo.T_CreateTime = Common.Instance.dtStationInformation[callStationKey].UpdateTime;
            else
            {
                taskInfo.T_CreateTime = DateTime.Now;
            }
            taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmssfff");
            taskInfo.T_Type = taskType;
            taskInfo.T_Level = 1;
            taskInfo.T_State = Enumerations.TaskStatus.Book;
            taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskType];
            taskInfo.T_Type = taskType;
            taskInfo.T_AgvNo = agvNo;
            //taskInfo.IsTest = true;
            taskInfo.Group = group;
            return taskInfo;
        }
        #endregion
        #region 类型3
        /// <summary>
        /// 类型3AGV任务调度
        /// </summary>
        /// <param name="agvInfo"></param>
        private bool AgvType3Task(ref M_AgvInfo agvInfo)
        {
            bool isWrite = false;
            try
            {

            }
            catch { }
            return isWrite;
        }
        #endregion
        #region 路段写入
        private void WriteRoute(ref M_AgvInfo agvInfo)
        {//同时需要判断是否要将路段集合清除
            try
            {
                bool isWriteRoute = false;
                int rfid = agvInfo.Rfid;
                int routeNo = agvInfo.Default1;
                int agvNo = agvInfo.AgvNo;
                if (agvInfo.lsRoutes.Count > 0)
                {
                    if (agvInfo.Rfid == agvInfo.Default1 || agvInfo.Default1 == 0)
                    {//当卡号与路段号相同时，需要写入下一路段信息
                        isWriteRoute = true;
                        //routeNo = agvInfo.Rfid;
                    }
                    else
                    {//判断是否已经到达下一站点而没有发路段信息 
                        if (agvInfo.lsRoutes.Any(o => o.Key == routeNo && o.Value.EdgeRfidNum == rfid))
                        {
                            isWriteRoute = true;
                        }
                    }
                    #region 若在充电桩，需要离开时，需要判断充电桩是否已经缩进
                    try
                    {
                        int bindChargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Rfid == rfid && o.Value.BindAgv == agvNo).Key;
                        if (bindChargeNo > 0)
                        {
                            //if (Common.Instance.dtChargeInfo[bindChargeNo].State != (int)EChargeCommState.Input)
                            if (Common.Instance.dtChargeInfo[bindChargeNo].State == (int)EChargeCommState.Output)
                            {//若充电桩尚未缩进，不可写入路段
                                isWriteRoute = false;
                                if (agvInfo.VoltageStatus == Enumerations.voltageStatus.normal)
                                {//向充电桩写入缩进指令 
                                    Common.Instance.dtChargeInfo[bindChargeNo].ChargeComm.isLowComm = true;
                                    ChargeUdpClient.dtChargeUdp[bindChargeNo].WriteChargeOperate(ChargeUdpClient.EChargeOperate.Input);
                                }
                            }
                            else
                            {
                                Common.Instance.dtChargeInfo[bindChargeNo].ChargeComm.isLowComm = true;
                            }
                        }
                    }
                    catch { }
                    #endregion
                    int index = agvInfo.lsRoutes.FindIndex(o => o.Key == routeNo);
                    int wIndex = -1;
                    RfidInfo rfidInfoInit = new RfidInfo();
                    if (isWriteRoute)
                    {
                        if (index >= 0)
                        {
                            if (agvInfo.lsRoutes.Count > index + 1)
                            {
                                int wRfid = agvInfo.lsRoutes[index + 1].Key;
                                int nRfid = agvInfo.lsRoutes[index + 1].Value.EdgeRfidNum;
                                if (Common.maiDict.Any(o => o.Value.AgvNo != agvNo && (o.Value.Rfid == wRfid || o.Value.Rfid == nRfid)) == false)//要写入站点无其它agv
                                {
                                    lastControlRfid = agvInfo.ControlRfid;
                                    bool isTargetPoint = false;//是否为最后写入站点
                                    if ((nRfid >= 5510 && nRfid <= 6020 && nRfid % 10 == 0) || (nRfid >= 5009 && nRfid <= 5420 && nRfid % 10 == 0))
                                    {
                                        if (index + 2 == agvInfo.lsRoutes.Count || index + 3 == agvInfo.lsRoutes.Count)
                                        {
                                            isTargetPoint = true;
                                        }
                                    }
                                    if (isTargetPoint == false)
                                        agvInfo.ControlRfid = nRfid;
                                    else
                                        agvInfo.ControlRfid = 0;
                                    //agvInfo.ControlRfid = nRfid;
                                    wIndex = index + 1;
                                    rfidInfoInit = agvInfo.lsRoutes[index + 1].Value;
                                }
                            }
                        }
                        else
                        {//若不存在，则清除路段集合，重新生成

                            if (routeNo == 0)
                            {
                                int r = agvInfo.Rfid;
                                index = agvInfo.lsRoutes.FindIndex(o => o.Key == r);
                                if (index >= 0)
                                {
                                    if (agvInfo.lsRoutes.Count == 1)
                                    {
                                        rfidInfoInit = agvInfo.lsRoutes[index].Value;
                                    }
                                    else
                                    {
                                        rfidInfoInit.Default1 = 0;
                                        rfidInfoInit.Default2 = agvInfo.lsRoutes[index].Value.Default2;
                                        rfidInfoInit.Speed = 1;
                                        rfidInfoInit.Direction = agvInfo.lsRoutes[index].Value.Direction;
                                        rfidInfoInit.LineStopType = agvInfo.lsRoutes[index].Value.LineStopType;
                                    }
                                    int wRfid = agvInfo.lsRoutes[index].Key;
                                    int nRfid = agvInfo.lsRoutes[index].Value.EdgeRfidNum;
                                    if (Common.maiDict.Any(o => o.Value.AgvNo != agvNo && o.Value.Rfid == wRfid) == false)
                                    {
                                        lastControlRfid = agvInfo.ControlRfid;
                                        bool isTargetPoint = false;//是否为最后写入站点
                                        //if (nRfid >= 5510 && nRfid <= 6020 && nRfid % 10 == 0)
                                        if ((nRfid >= 5510 && nRfid <= 6020 && nRfid % 10 == 0) || (nRfid >= 5009 && nRfid <= 5420 && nRfid % 10 == 0))
                                        {
                                            if (index + 2 == agvInfo.lsRoutes.Count || index + 3 == agvInfo.lsRoutes.Count)
                                            {
                                                isTargetPoint = true;
                                            }
                                        }
                                        if (isTargetPoint == false)
                                            agvInfo.ControlRfid = nRfid;
                                        else
                                            agvInfo.ControlRfid = 0;
                                    }
                                    wIndex = index;
                                }
                            }
                            else
                            {
                                if (agvInfo.Task1 == string.Empty && agvInfo.IsAgvTest == false)//测试路段时候可清除，当为任务路段集合时，需要手动将AGV当前路段编号纠正或复位
                                    agvInfo.lsRoutes.Clear();
                            }
                        }
                    }
                    lock (BA_AgvControl.objControl)
                    {
                        int cnRfid = -1;
                        if (wIndex >= 0)
                        {//首先判断当前路段是否被管制，若被管制，则无需判断即将写入路段是否被管制
                            cnRfid = agvInfo.ControlRfid;
                        }
                        agvInfo.ControlRfid = lastControlRfid;
                        #region 交通管制
                        //判断是否处于管制状态，再判断是否需要管制，或是需要解除管制   
                        if (BA_AgvControl.IsControl(agvInfo.AgvNo))
                        {
                            if (agvInfo.ControlFlag == false)
                            {
                                agvInfo.ControlFlag = true;
                                //Debug.Print(string.Format("Agv{0} Write Lock {1}", agvInfo.AgvNo, DateTime.Now.ToString()));
                                //agvConnect.LockAgv();
                            }
                        }
                        else
                        {
                            if (agvInfo.ControlFlag)
                            {
                                agvInfo.ControlFlag = false;
                                //Debug.Print(string.Format("Agv{0} Write Unlock {1}", agvInfo.AgvNo, DateTime.Now.ToString()));
                                //agvConnect.UnlockAgv();
                            }
                        }
                        #endregion
                        if (agvInfo.ControlFlag == false && cnRfid >= 0)
                        {//即将写入路段是否被管制
                            agvInfo.ControlRfid = cnRfid;
                            #region 交通管制
                            //判断是否处于管制状态，再判断是否需要管制，或是需要解除管制   
                            if (BA_AgvControl.IsControl(agvInfo.AgvNo))
                            {
                                if (agvInfo.ControlFlag == false)
                                {
                                    agvInfo.ControlFlag = true;
                                    //Debug.Print(string.Format("Agv{0} Write Lock {1}", agvInfo.AgvNo, DateTime.Now.ToString()));
                                    //agvConnect.LockAgv();
                                }
                            }
                            else
                            {
                                if (agvInfo.ControlFlag)
                                {
                                    agvInfo.ControlFlag = false;
                                    //Debug.Print(string.Format("Agv{0} Write Unlock {1}", agvInfo.AgvNo, DateTime.Now.ToString()));
                                    //agvConnect.UnlockAgv();
                                }
                            }
                            #endregion
                            if (agvInfo.ControlFlag && wIndex >= 0)
                            {
                                agvInfo.ControlRfid = lastControlRfid;
                            }
                        }
                        BA_AgvControl.UnlockControl(agvInfo.AgvNo);
                    }
                    if (agvInfo.ControlFlag == false && wIndex >= 0 && isWriteRoute)
                    {
                        agvConnect.WriteStation(agvInfo.lsRoutes[wIndex].Key, rfidInfoInit);
                    }
                    //判断是否将路段集合清除
                    if (agvInfo.Task1 == string.Empty && agvInfo.IsAgvTest == false)
                    { //处于无任务状态时，才进行判断
                        if (agvInfo.Default1 == agvInfo.lsRoutes[agvInfo.lsRoutes.Count - 1].Key)
                        {
                            agvInfo.lsRoutes.Clear();
                        }
                    }
                }
            }
            catch { }
        }
        #endregion
        #region 任务调度
        /// <summary>
        /// agv清除路段信息判断操作
        /// </summary>
        /// <param name="agvInfo"></param>
        private void ClearStation(M_AgvInfo agvInfo)
        {
            try
            {
                bool isClear = false;

                if (isClear && agvInfo.State == (int)Enumerations.AgvStatus.stop)
                {
                    isDownAdnUp = false;
                    int time = 500;

                    Thread.Sleep(time);//做一延迟操作，避免agv动作判断尚未完成
                    agvConnect.AgvOperate(Enumerations.AgvOperate.StationClear);
                }
            }
            catch { }
        }
        #endregion
        #endregion  //任务调度
        #region 虚拟管制卡生成
        private void VirtualControlRfid(ref M_AgvInfo agvInfo)
        {
            #region 虚拟管制卡
            int cr2 = agvInfo.Rfid;
            int cr1 = agvInfo.Rfid;

            #endregion
            #region 手动模式下，交通管制将不受控制
            if (agvInfo.Mode != (int)Enumerations.AgvMode.AutoOperation)
            {
                cr1 = 0;
                cr2 = 0;
            }
            #endregion
            agvInfo.ControlRfid2 = cr2;
            if ((lastControlRfid == cr1 && cr1 > 0 && lastControlRfid > 0) == false)
                agvInfo.ControlRfid = cr1;
        }
        #endregion
        /// <summary>
        /// 交通锁定
        /// </summary>
        /// <returns></returns>
        public bool Lock()
        {
            return this.agvConnect.LockAgv();
        }
        /// <summary>
        /// 交通锁定解除
        /// </summary>
        /// <returns></returns>
        public bool Unlock()
        {
            return this.agvConnect.UnlockAgv();
        }
        /// <summary>
        /// AGV复位
        /// </summary>
        /// <returns></returns> 
        public bool Rest()
        {
            return this.agvConnect.AgvRest();
        }
        /// <summary>
        /// AGV停止
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            return this.agvConnect.AgvStop();
        }
        /// <summary>
        /// AGV启动
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            return this.agvConnect.AgvRun();
        }
        /// <summary>
        /// 写入任务
        /// </summary>
        /// <param name="taskInfo">任务信息</param>
        /// <returns></returns>
        public bool AddTask(MA_AgvTaskInfo taskInfo)
        {
            return this.agvConnect.WriteTask(taskInfo);
        }
        /// <summary>
        /// AGV操作
        /// </summary>
        /// <param name="operate">操作类型</param>
        /// <returns></returns>
        public bool AgvOperate(Enumerations.AgvOperate operate, params int[] station)
        {
            return this.agvConnect.AgvOperate(operate, station);
        }
    }
}
