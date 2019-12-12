using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class DA_AgvOmronFins : AgvConnect
    {
        #region Perproties
        /// <summary>
        /// agv通讯参数
        /// </summary>
        private MA_AgvComInfo AgvComm;
        /// <summary>
        /// PLC通讯接口
        /// </summary>
        private AgvPLCUtils.PlcConnect omronFins;
        /// <summary>
        /// 通讯最大重链次数
        /// </summary>
        private int linkMaxNumber = 20;
        /// <summary>
        /// 重链次数
        /// </summary>
        private int linkNo = 0;
        /// <summary>
        /// PLC的起始地址
        /// </summary>
        private int readOrginAddress = 800;
        /// <summary>
        /// PLC的读取长度
        /// </summary>
        private int readDataLength = 15;
        /// <summary>
        /// 活动心跳包
        /// </summary>
        private int activeIndex = 0;
        /// <summary>
        /// 充电电压判断计数
        /// </summary>
        private int voltageStopCount = 0;
        /// <summary>
        /// 低电压判断计数
        /// </summary>
        private int voltgeLowStopCount = 0;
        /// <summary>
        /// 低电压判断次数
        /// </summary>
        private int voltageLimitedMaxNumber = 100;
        #endregion

        public DA_AgvOmronFins(MA_AgvComInfo _agvComm)
        {
            this.AgvComm = _agvComm;
            omronFins = new AgvPLCUtils.OmronFins(this.AgvComm.A_LocalPort, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
            //omronFins = new AgvPLCUtils.OmronFins(this.AgvComm.A_LocalPort);
        }
        /// <summary>
        /// 读取AGV数据
        /// </summary>
        /// <param name="agvInfo"></param>
        public bool ReadData(ref M_AgvInfo agvInfo)
        {
            bool isReadOk = false;
            try
            {
                //AgvOperate(Enumerations.AgvOperate.Activity, new int[] { agvInfo.ActiveIndex });
                //Thread.Sleep(100);
                byte[] data = this.omronFins.WReadAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAR, AgvPLCUtils.CMACode.DMw, this.readOrginAddress, this.readDataLength, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                if (data.Length == this.readDataLength * 2 + 1 && data[0] == 1)   //判断是否读取Agv数据成功
                {
                    //数据解析
                    agvInfo.Default7 = data[1] * 256 + data[2];//上料点
                    agvInfo.Default8 = data[3] * 256 + data[4];//下料点
                    agvInfo.ActiveIndex = data[5] * 256 + data[6];//心路包
                    if (agvInfo.ActiveIndex >= 60000) agvInfo.ActiveIndex = 0;
                    else agvInfo.ActiveIndex++;

                    int signal = data[7] * 256 + data[8];//信号
                    agvInfo.Default6 = signal >> 3;//站点升降平台状态
                    if (!agvInfo.IsStart) agvInfo.IsStart = (signal & 1) == 1;//是否启动，当已经启动，直到任务结束，启动信号不改变
                    agvInfo.ControlFlag = ((signal >> 1) & 1) == 1;//交通管制
                    agvInfo.IsPass = ((signal >> 2) & 1) == 1;//是否已响应放行请求
                    agvInfo.IsPassPlatform = ((signal >> 7) & 1) == 1;//是否已响应升降平台允许离开请求

                    agvInfo.ControlRfid = agvInfo.ControlRfid2 = agvInfo.ShowRfid = agvInfo.Rfid = data[9] * 256 + data[10];//卡号 
                    int s = data[12];
                    if (agvInfo.State == (int)Enumerations.AgvStatus.disConnection)
                    {
                        agvInfo.isOnline = true;
                    }
                    switch (s)
                    {
                        case 0:
                            agvInfo.State = (int)Enumerations.AgvStatus.stop;
                            break;
                        case 1:
                            agvInfo.State = (int)Enumerations.AgvStatus.running;
                            break;
                    }
                    agvInfo.Abnormal = data[14];//异常编号
                    try
                    {
                        agvInfo.AbnormalMessage = Common.Instance.dtAgvAbnormal[agvInfo.Abnormal];//异常信息
                    }
                    catch { }
                    if (agvInfo.Abnormal > 0)
                        agvInfo.State = (int)Enumerations.AgvStatus.abnormal;
                    int signal2 = data[15] * 256 + data[16];
                    agvInfo.QuestPass = (signal2 & 1) == 1;//请求放行
                    agvInfo.Arrived = (signal2 >> 1 & 1) == 1;//AGV到达上料点或下料点
                    agvInfo.IsCanReceiveTask = (signal2 >> 2 & 1) == 1;//AGV是否可以接任务
                    agvInfo.DragState = signal2 >> 3 & 1;//牵引棒状态
                    agvInfo.VoltageStatus = (signal2 >> 4 & 1) == 1 ? Enumerations.voltageStatus.chargVoltage : Enumerations.voltageStatus.normal;
                    agvInfo.OperationComplete = (signal2 >> 5 & 1) == 1;//上下料完成
                    agvInfo.chargeAbnormal = (signal2 >> 6 & 1) == 1 ? true : false;
                    agvInfo.ChargeStation1Error = (signal2 >> 7 & 1) == 1 ? true : false;
                    agvInfo.ChargeStation2Error = (signal2 >> 8 & 1) == 1 ? true : false;
                    agvInfo.RouteError = (signal2 >> 9 & 1) == 1 ? true : false;
                    if (agvInfo.chargeAbnormal)
                    {
                        //agvInfo.ChargeAbnormalString = "ChargeAnomaly";
                    }
                    else
                    {
                        agvInfo.ChargeAbnormalString = string.Empty;
                    }
                    if (!agvInfo.RouteError)
                    {
                        agvInfo.RouteErrorString = string.Empty;
                    }
                    agvInfo.Speed = data[17] * 256 + data[18];//速度
                    agvInfo.Voltage = data[19] * 256 + data[20];//电压
                    agvInfo.Direction = data[22];//方向
                    agvInfo.Position = data[24];//agv指定工作区域编号      
                    agvInfo.ChargeSeconds = data[25] * 256 + data[26];//已经充电的秒数
                    if (agvInfo.Type == Enumerations.agvType.type_2)
                    {//设定为Back侧的AGV时，用虚拟卡形式
                        agvInfo.VirtualRfid = agvInfo.Rfid + 200;
                        agvInfo.ShowRfid = agvInfo.VirtualRfid;
                    }
                    else
                    {
                        agvInfo.VirtualRfid = agvInfo.Rfid;
                    }
                    try
                    {
                        if (agvInfo.Speed <= 0)
                        {
                            if (agvInfo.Task1 != string.Empty || agvInfo.Task2 != string.Empty)
                            {
                                if (agvInfo.StopTime != new DateTime())
                                {
                                    if (DateTime.Now.Subtract(agvInfo.StopTime).TotalMinutes > 10)
                                    {
                                        agvInfo.Retention = "Retention";
                                    }
                                }
                                else
                                {
                                    agvInfo.StopTime = DateTime.Now;
                                }
                            }
                            else
                            {
                                agvInfo.StopTime = new DateTime();
                                agvInfo.Retention = string.Empty;
                            }
                        }
                        else
                        {
                            agvInfo.StopTime = new DateTime();
                            agvInfo.Retention = string.Empty;
                        }
                    }
                    catch { }
                    this.linkNo = 0;
                    #region 电压判断
                    try
                    {
                        int _group = agvInfo.Type == Enumerations.agvType.type_1 ? 1 : 2;
                        int _virtualRifd = agvInfo.VirtualRfid;
                        string chargeStr = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Charge && o.Value.StationRfidLs.Contains(_virtualRifd)).Key;
                        if (!string.IsNullOrEmpty(chargeStr))
                        {//将充电站状态设定为忙
                            Common.Instance.dtStationInformation[chargeStr].State = (int)EStationState.Busy;
                            Common.Instance.dtStationInformation[chargeStr].bindAgvNo = agvInfo.AgvNo;
                            //try
                            //{
                            //    if (agvInfo.Voltage < 500)
                            //    {
                            //        if (agvInfo.LowChargeTime != new DateTime())
                            //        {
                            //            if (DateTime.Now.Subtract(agvInfo.LowChargeTime).TotalMinutes > 2)
                            //            {
                            //                agvInfo.ChargeAbnormalString = "ChargingAnomaly";
                            //            }
                            //        }
                            //        else
                            //        {
                            //            agvInfo.LowChargeTime = DateTime.Now;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        agvInfo.LowChargeTime = new DateTime();
                            //        agvInfo.ChargeAbnormalString = string.Empty;
                            //    }
                            //}
                            //catch { }
                        }
                    }
                    catch { }
                    #endregion
                    isReadOk = true;
                }
                else
                {
                    this.linkNo++;
                }
                if (this.linkNo > this.linkMaxNumber)
                {
                    this.linkNo = this.linkMaxNumber + 1;
                    agvInfo.isOnline = false;
                    agvInfo.State = (int)Enumerations.AgvStatus.disConnection;
                }
            }
            catch { }
            Thread.Sleep(100);
            return isReadOk;
        }
        /// <summary>
        /// 任务写入
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <returns></returns>
        public bool WriteTask(MA_AgvTaskInfo taskInfo)
        {
            try
            {
                int[] data = new int[] { taskInfo.T_Process[taskInfo.ProcessIndex].SourceStation, taskInfo.T_Process[taskInfo.ProcessIndex].Station };
                try
                {
                    LogFile.SaveLog(string.Format("Agv{0} Write Load:{1},Unload:{2}", taskInfo.T_AgvNo, data[0], data[1]));
                }
                catch { }
                return this.omronFins.WWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMw, 800, data, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);

            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 写入上料点和下料点
        /// </summary>
        /// <param name="load"></param>
        /// <param name="unload"></param>
        /// <returns></returns>
        public bool WriteLoadAndUnload(int load, int unload)
        {
            try
            {
                int[] data = new int[] { load, unload };
                return this.omronFins.WWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMw, 800, data, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);

            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// agv交通锁定
        /// </summary>
        /// <returns></returns>
        public bool LockAgv()
        {
            try
            {
                return this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 803, 1, new byte[] { 1 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
            }
            catch
            {

                return false;
            }
        }
        /// <summary>
        /// agv交通解锁
        /// </summary>
        /// <returns></returns>
        public bool UnlockAgv()
        {
            try
            {
                return this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 803, 1, new byte[] { 0 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
            }
            catch
            {

                return false;
            }
        }
        /// <summary>
        /// agv停止
        /// </summary>
        /// <returns></returns>
        public bool AgvStop()
        {
            try
            {
                return this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.WRb, 101, 0, new byte[] { 0 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
            }
            catch
            {

                return false;
            }
        }
        /// <summary>
        /// agv运行
        /// </summary>
        /// <returns></returns>
        public bool AgvRun()
        {
            try
            {
                return this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 101, 0, new byte[] { 1 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
            }
            catch
            {

                return false;
            }
        }
        /// <summary>
        /// agv复位
        /// </summary>
        /// <returns></returns>
        public bool AgvRest()
        {
            try
            {
                return this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.WRb, 102, 0, new byte[] { 1 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
            }
            catch
            {

                return false;
            }
        }
        /// <summary>
        /// AGV操作
        /// </summary>
        /// <param name="operate">操作类型</param>
        /// <returns></returns>
        public bool AgvOperate(Enumerations.AgvOperate operate, params int[] station)
        {
            try
            {
                bool isOk = false;
                switch (operate)
                {
                    case Enumerations.AgvOperate.Start:
                        isOk = this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 803, 0, new byte[] { 1 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                    case Enumerations.AgvOperate.Pass:
                        isOk = this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 803, 2, new byte[] { 1 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                    case Enumerations.AgvOperate.PlatformPass:
                        isOk = this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 803, 7, new byte[] { 1 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                    case Enumerations.AgvOperate.Activity:
                        isOk = this.omronFins.WWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMw, 802, station, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                    case Enumerations.AgvOperate.StationState:
                        byte[] data = station.Select<int, byte>(q => Convert.ToByte(q)).ToArray();
                        isOk = this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 803, 3, data, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                    case Enumerations.AgvOperate.LoadAndUnload:
                        isOk = this.omronFins.WWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMw, 800, station, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                    case Enumerations.AgvOperate.OperationCompleteClear:
                        isOk = this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.WRb, 400, 5, new byte[] { 0 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                    case Enumerations.AgvOperate.Init:
                        isOk = this.omronFins.BWriteAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAW, AgvPLCUtils.CMACode.DMb, 803, 8, new byte[] { 1 }, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                        break;
                }
                return isOk;
            }
            catch
            {
                return false;
            }
        }

        public bool WriteStation(int routeNo, RfidInfo rfidInfo)
        {
            throw new NotImplementedException();
        }
    }
}
