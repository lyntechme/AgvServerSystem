using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Model;

namespace BLL
{
    /// <summary>
    /// 任务分配类
    /// </summary>
    public class TaskAllocation
    {
        /// <summary>
        /// 写入代码开始执行时间，只有当代码执行10S后，才开始调度任务
        /// </summary>
        private DateTime softwareStartTime;
        private static TaskAllocation taskAllocation = null;
        /// <summary>
        /// 分容上下料任务锁
        /// </summary>
        public static object objLockTask = new object();
        public static TaskAllocation Instance
        {
            get
            {
                if (taskAllocation == null) taskAllocation = new TaskAllocation();
                return taskAllocation;
            }
        }
        private TaskAllocation()
        {
            softwareStartTime = new DateTime();
        }
        /// <summary>
        /// 任务分配函数，当程序开始后，该函数会循环进行，查询是否有尚未分配任务，对其进行绑定AGV
        /// </summary>
        public void TaskAllocationFunction()
        {
            bool isCanAllocation = false;
            //WMSDataOperate wmsDataOperate = new WMSDataOperate();
            while (true)
            {
                if (Common.isLoadedOk)
                {
                    if (softwareStartTime == new DateTime())
                    {
                        softwareStartTime = DateTime.Now;
                    }
                    if (DateTime.Now.Subtract(softwareStartTime).TotalSeconds > 10)
                    {
                        isCanAllocation = true;
                    }
                    if (isCanAllocation)
                    {
                        if (Common.Instance.isReceiveOpcTask)
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                lock (objLockTask)
                                {
                                    CreateFrontTask(i);
                                    Thread.Sleep(50);
                                }
                                Thread.Sleep(50);
                            }
                        }
                        else
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                lock (objLockTask)
                                {
                                    CreateWaitTask(i);
                                    Thread.Sleep(50);
                                }
                                Thread.Sleep(50);
                            }
                        }
                        #region 任务分配 not used
                        try
                        {
                            //CapacityTestTask();
                            //Thread.Sleep(50);
                            //PreChargeBurnInRoomTask();
                            //Thread.Sleep(50);
                            //CapacityBurnInRoomTask();
                        }
                        catch { }
                        #endregion
                    }
                    Thread.Sleep(100);
                }
            }
        }
        #region 创建待机切换充电任务 Create go to wait task
        /// <summary>
        /// 创建待机切换充电任务
        /// </summary>
        /// <param name="_group"></param>
        private void CreateWaitTask(int _group)
        {
            try
            {
                int typeTask = (int)Enumerations.agvType.type_1;
                if (_group == 2)
                    typeTask = (int)Enumerations.agvType.type_2;
                #region 无任务，清除站点预定状态 no task,clear station state
                if (Common.taskDt[typeTask].Count <= 0)
                {//无任务，清除站点预定状态 
                    try
                    {
                        string clearKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.State == (int)EStationState.Book
                            && o.Value.Group == _group
                            && (o.Value.StationType == (int)StationInformation.EStationType.Type_A
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_B
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_C
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_D
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_E
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_F)).Key;
                        if (!string.IsNullOrWhiteSpace(clearKey))
                        {
                            Common.Instance.dtStationInformation[clearKey].State = int.Parse(Common.Instance.dtStationInformation[clearKey].LastState.ToString());
                        }
                    }
                    catch { }
                    try
                    {
                        string cKey = Common.Instance.dtStationInformation.FirstOrDefault(o => (o.Value.State == (int)EStationState.Busy || o.Value.State == (int)EStationState.Book) && o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Charge && Common.maiDict.Any(p => o.Value.StationRfidLs.Contains(p.Value.VirtualRfid)) == false).Key;
                        if (!string.IsNullOrWhiteSpace(cKey))
                        {
                            int _cagvNo = Common.Instance.dtStationInformation[cKey].bindAgvNo;
                            int _vritualRfid = Common.maiDict[_cagvNo].VirtualRfid;
                            if (Common.Instance.dtStationInformation[cKey].StationRfidLs.Contains(_vritualRfid) == false && Common.taskDt[typeTask].Any(o => o.Value.T_AgvNo == _cagvNo) == false)
                            {//agv不在该充电位，且当前没有该AGV的任务
                                Common.Instance.dtStationInformation[cKey].bindAgvNo = 0;
                                Common.Instance.dtStationInformation[cKey].State = (int)EStationState.Free;
                            }
                        }
                    }
                    catch { }
                }
                #endregion
                #region 查询充电桩是否有AGV，以及当前充电时长 Query 
                if (Common.taskDt[typeTask].Count <= 0)
                {//无任务，清除站点预定状态 
                    try
                    {
                        List<StationInformation> wait = Common.Instance.dtStationInformation.Values.ToList().FindAll(s => s.Group == _group && s.StationType == (int)StationInformation.EStationType.Wait).ToList();
                        List<StationInformation> charge = Common.Instance.dtStationInformation.Values.ToList().FindAll(s => s.Group == _group && s.StationType == (int)StationInformation.EStationType.Charge).ToList();

                        int chargeAgvCount = Common.Instance.dtStationInformation.Count(o => o.Value.State == (int)EStationState.Busy && o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Charge && Common.maiDict.Any(p => o.Value.StationRfidLs.Contains(p.Value.VirtualRfid) && p.Value.State == (int)Enumerations.AgvStatus.stop));
                        if (chargeAgvCount >= 2)
                        {//2个充电桩都有AGV
                            int maxChargeTimeAgvNo = Common.maiDict.OrderByDescending(o => o.Value.ChargeSeconds).FirstOrDefault(o => o.Value.State == (int)Enumerations.AgvStatus.stop && typeTask == (int)o.Value.Type && charge.Any(p => p.StationRfidLs.Contains(o.Value.VirtualRfid)) && o.Value.IsCanReceiveTask).Key;
                            int minChargeTimeAgvNo = Common.maiDict.OrderBy(o => o.Value.ChargeSeconds).FirstOrDefault(o => o.Value.State == (int)Enumerations.AgvStatus.stop && typeTask == (int)o.Value.Type && charge.Any(p => p.StationRfidLs.Contains(o.Value.VirtualRfid)) && o.Value.IsCanReceiveTask).Key;
                            if (maxChargeTimeAgvNo > 0 && minChargeTimeAgvNo > 0 && Common.maiDict[maxChargeTimeAgvNo].ChargeSeconds > Common.Instance.standbyChargeTime)
                            {
                                try
                                {
                                    if (Common.maiDict[minChargeTimeAgvNo].ChargeSeconds > Common.Instance.chargeTime)
                                    {//另外一个待机点的AGV充电时长大于正常充电时长，避免切换到工作模式时，不能及时将AGV转移到待机点
                                        string waitNo = Common.Instance.dtStationInformation.Values.ToList().FirstOrDefault(s => s.Group == _group && s.StationType == (int)StationInformation.EStationType.Wait && Common.maiDict.Any(o => s.StationRfidLs.Contains(o.Value.VirtualRfid)) == false).Key;//查询空闲的待机点
                                        if (!string.IsNullOrEmpty(waitNo))
                                        {
                                            MA_AgvTaskInfo taskInfo = CreateLeaveChargeTask(maxChargeTimeAgvNo, waitNo, typeTask);
                                            Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;//添加任务
                                            Common.maiDict[maxChargeTimeAgvNo].Task2 = taskInfo.T_Id;
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                        {//最多一个充电桩有AGV 
                            int minVoltageAgvNo = Common.maiDict.OrderBy(o => o.Value.Voltage).FirstOrDefault(o => o.Value.State == (int)Enumerations.AgvStatus.stop && typeTask == (int)o.Value.Type && wait.Any(p => p.StationRfidLs.Contains(o.Value.VirtualRfid)) && o.Value.IsCanReceiveTask).Key;
                            if (minVoltageAgvNo > 0)
                            {
                                try
                                {
                                    string chargeNo = charge.FirstOrDefault(o => o.State <= 1).Key;
                                    if (!string.IsNullOrEmpty(chargeNo))
                                    {//有空闲充电桩 
                                        MA_AgvTaskInfo taskInfo = CreatChargeTask(minVoltageAgvNo, chargeNo, typeTask);
                                        Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                        Common.maiDict[minVoltageAgvNo].Task2 = taskInfo.T_Id;
                                        Common.Instance.dtStationInformation[chargeNo].State = (int)EStationState.Book;
                                        Common.Instance.dtStationInformation[chargeNo].bindAgvNo = minVoltageAgvNo;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }
                }
                #endregion
            }
            catch { }
        }
        #endregion
        #region 创建正常工作任务
        /// <summary>
        /// 创建正常工作任务
        /// </summary>
        /// <param name="_group"></param>
        private void CreateFrontTask(int _group)
        {
            try
            {
                int typeTask = (int)Enumerations.agvType.type_1;
                if (_group == 2)
                    typeTask = (int)Enumerations.agvType.type_2;
                #region 无任务，清除站点预定状态
                if (Common.taskDt[typeTask].Count <= 0)
                {//无任务，清除站点预定状态 
                    try
                    {
                        string clearKey = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.State == (int)EStationState.Book
                            && o.Value.Group == _group
                            && (o.Value.StationType == (int)StationInformation.EStationType.Type_A
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_B
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_C
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_D
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_E
                            || o.Value.StationType == (int)StationInformation.EStationType.Type_F)).Key;
                        if (!string.IsNullOrWhiteSpace(clearKey))
                        {
                            Common.Instance.dtStationInformation[clearKey].State = int.Parse(Common.Instance.dtStationInformation[clearKey].LastState.ToString());
                        }
                    }
                    catch { }
                    try
                    {
                        string cKey = Common.Instance.dtStationInformation.FirstOrDefault(o => (o.Value.State == (int)EStationState.Busy || o.Value.State == (int)EStationState.Book) && o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Charge && Common.maiDict.Any(p => o.Value.StationRfidLs.Contains(p.Value.VirtualRfid)) == false).Key;
                        if (!string.IsNullOrWhiteSpace(cKey))
                        {
                            int _cagvNo = Common.Instance.dtStationInformation[cKey].bindAgvNo;
                            int _vritualRfid = Common.maiDict[_cagvNo].VirtualRfid;
                            if (Common.Instance.dtStationInformation[cKey].StationRfidLs.Contains(_vritualRfid) == false && Common.taskDt[typeTask].Any(o => o.Value.T_AgvNo == _cagvNo) == false)
                            {//agv不在该充电位，且当前没有该AGV的任务
                                Common.Instance.dtStationInformation[cKey].bindAgvNo = 0;
                                Common.Instance.dtStationInformation[cKey].State = (int)EStationState.Free;
                            }
                        }
                    }
                    catch { }
                }
                #endregion
                #region 创建充电任务
                if (Common.taskDt[typeTask].Count <= 0)
                {//当前AGV无任务 
                    List<StationInformation> wait = Common.Instance.dtStationInformation.Values.ToList().FindAll(s => s.Group == _group && s.StationType == (int)StationInformation.EStationType.Wait).ToList();
                    List<StationInformation> charge = Common.Instance.dtStationInformation.Values.ToList().FindAll(s => s.Group == _group && s.StationType == (int)StationInformation.EStationType.Charge).ToList();
                    foreach (var item in wait)
                    {
                        int agvNoWait = Common.maiDict.FirstOrDefault(o => (int)o.Value.Type == typeTask && item.StationRfidLs.Contains(o.Value.VirtualRfid)).Key;
                        if (agvNoWait <= 0)
                        {//待机点无AGV，查询充电点是否有空闲AGV 
                            try
                            {
                                if (Common.maiDict.Any(o => (int)o.Value.Type == typeTask && (o.Value.State == (int)Enumerations.AgvStatus.disConnection && o.Value.Rfid == -1)) || charge.Count(o => o.bindAgvNo > 0 && o.State == (int)EStationState.Busy) >= 2)
                                {//有agv已经掉线，并确认清除RFID号为-1，或是两个充电桩都有agv
                                    if (Common.maiDict.Any(o => (int)o.Value.Type == typeTask && (o.Value.Default7 != 0 || o.Value.Default8 != 0) && o.Value.State != (int)Enumerations.AgvStatus.disConnection) == false)
                                    {//所有同类型AGV都load,unload都为0
                                        int agvCharge = Common.maiDict.OrderByDescending(o => o.Value.ChargeSeconds).ToDictionary(o => o.Key, p => p.Value).FirstOrDefault(o => (int)o.Value.Type == typeTask && o.Value.VoltageStatus == Enumerations.voltageStatus.normal && o.Value.ChargeSeconds > Common.Instance.chargeTime && charge.Any(c => c.StationRfidLs.Contains(o.Value.VirtualRfid))).Key;
                                        if (agvCharge > 0)
                                        {//有可用AGV 
                                            MA_AgvTaskInfo taskInfo = CreateLeaveChargeTask(agvCharge, item.Key, typeTask);
                                            Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;//添加任务
                                            Common.maiDict[agvCharge].Task2 = taskInfo.T_Id;
                                            break;
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                        else
                        {//待机点有AGV
                            if (Common.maiDict[agvNoWait].VoltageStatus != Enumerations.voltageStatus.normal && Common.maiDict[agvNoWait].State == (int)Enumerations.AgvStatus.stop && Common.maiDict[agvNoWait].IsCanReceiveTask)
                            {//agv处于低电压状态
                                try
                                {
                                    string chargeNo = charge.FirstOrDefault(o => o.State <= 1).Key;
                                    if (!string.IsNullOrEmpty(chargeNo))
                                    {//有空闲充电桩 
                                        MA_AgvTaskInfo taskInfo = CreatChargeTask(agvNoWait, chargeNo, typeTask);
                                        Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                        Common.maiDict[agvNoWait].Task2 = taskInfo.T_Id;
                                        Common.Instance.dtStationInformation[chargeNo].State = (int)EStationState.Book;
                                        Common.Instance.dtStationInformation[chargeNo].bindAgvNo = agvNoWait;
                                        break;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
                #endregion
                if (!Common.taskDt[typeTask].Any(o => o.Value.T_Type == Enumerations.TaskType.Charge_Go || o.Value.T_Type == Enumerations.TaskType.Chareg_Leave))
                {//无充电任务，执行正常任务
                    //A类型
                    #region A 类型
                    try
                    {
                        int rfid = -1;
                        int agvNo = -1;
                        rfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationMatchValue.ToLowerInvariant().Contains("wait1")).Value.StationRfidLs[0];
                        agvNo = Common.maiDict.FirstOrDefault(o => (int)o.Value.Type == typeTask && o.Value.VirtualRfid == rfid && o.Value.VoltageStatus == Enumerations.voltageStatus.normal && o.Value.State == (int)Enumerations.AgvStatus.stop && o.Value.IsCanReceiveTask && string.IsNullOrEmpty(o.Value.Task1) && string.IsNullOrEmpty(o.Value.Task2) && o.Value.Default7 == 0 && o.Value.Default8 == 0).Key;
                        //agvNo = 1;
                        bool isHaveTask = Common.taskDt[typeTask].Any(o => o.Value.T_Type == Enumerations.TaskType.Transport_A_C || o.Value.T_Type == Enumerations.TaskType.Transport_A_F || o.Value.T_Type == Enumerations.TaskType.Transport_C_F || o.Value.T_Type == Enumerations.TaskType.Transport_E_A);//是否已存在A类型的任务
                        if (agvNo > 0 && !isHaveTask)
                        {//有可用AGV
                            bool isCreateTask_A = false;//是否已经生成任务
                            List<string> QueryStations = new List<string>();
                            StationInformation aStation = null;
                            do
                            {
                                aStation = Common.Instance.dtStationInformation.OrderBy(o => o.Value.UpdateTime).ToDictionary(o => o.Key, p => p.Value).FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_A && o.Value.State == (int)EStationState.Busy && QueryStations.Contains(o.Key) == false && o.Value.StationEnable).Value;
                                if (aStation != null)
                                {
                                    QueryStations.Add(aStation.Key);
                                    if (aStation.LoadReady && aStation.UnloadReady == false)
                                    {//需要物料,查询E点是否有物料
                                        StationInformation eStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E && o.Value.State == (int)EStationState.Busy && o.Value.StationEnable).Value;//查询E点是否有物料
                                        if (eStation != null && Common.maiDict.Any(o => eStation.StationRfidLs.Contains(o.Value.VirtualRfid)) == false)
                                        {
                                            #region Transport_E-A
                                            MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_E_A, aStation.Key, typeTask);
                                            taskInfo.ProcessIndex = 0;
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
                                            taskInfo.T_Process.Add(r1);

                                            RouteInfo r2 = new RouteInfo();
                                            r2.Index = 0;
                                            r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait1").Value.StationOperate);
                                            r2.Station = 0;
                                            r2.Route = RouteType.GoWait1;
                                            r2.Description = "Go wait1";
                                            r2.Operation = 0;
                                            r2.State = 0;
                                            desc += "|" + r2.Description;
                                            taskInfo.T_Process.Add(r2);

                                            taskInfo.T_Description = desc;
                                            Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                            Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                            isCreateTask_A = true;
                                            #endregion
                                        }
                                    }
                                    else if (aStation.LoadReady == false && aStation.UnloadReady)
                                    {//需要将物料拉走,查询F点是否空闲，若不空闲，则将其拉到C类型站点
                                        StationInformation fStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F && o.Value.State == (int)EStationState.Free && o.Value.StationEnable).Value;  //F站点无料车
                                        if (fStation == null)
                                        {
                                            StationInformation cStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_C && o.Value.State == (int)EStationState.Free && o.Value.StationEnable).Value;  //查找空闲的C类型缓存区 
                                            if (cStation == null)
                                            {//C类型缓存区没空位，向站点写入7状态(料位已满) 

                                            }
                                            else
                                            {
                                                #region Transport_A_C
                                                MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_A_C, aStation.Key, typeTask);
                                                taskInfo.ProcessIndex = 0;
                                                string desc = string.Empty;
                                                RouteInfo r1 = new RouteInfo();
                                                r1.Index = 0;
                                                r1.SourceStation = int.Parse(aStation.StationOperate);
                                                r1.Station = int.Parse(cStation.StationOperate);
                                                r1.Route = RouteType.A_C;
                                                r1.Description = string.Format("{0}_{1}", aStation.StationName, cStation.StationName);
                                                r1.Operation = 0;
                                                r1.State = 0;
                                                desc += r1.Description;
                                                taskInfo.T_Process.Add(r1);

                                                RouteInfo r2 = new RouteInfo();
                                                r2.Index = 0;
                                                r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait1").Value.StationOperate);
                                                r2.Station = 0;
                                                r2.Route = RouteType.GoWait1;
                                                r2.Description = "Go wait1";
                                                r2.Operation = 0;
                                                r2.State = 0;
                                                desc += "|" + r2.Description;
                                                taskInfo.T_Process.Add(r2);

                                                taskInfo.T_Description = desc;
                                                Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                                Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                                isCreateTask_A = true;
                                                #endregion
                                            }
                                        }
                                        else
                                        {
                                            #region Transport_A-F
                                            MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_A_F, aStation.Key, typeTask);
                                            taskInfo.ProcessIndex = 0;
                                            string desc = string.Empty;
                                            RouteInfo r1 = new RouteInfo();
                                            r1.Index = 0;
                                            r1.SourceStation = int.Parse(aStation.StationOperate);
                                            r1.Station = int.Parse(fStation.StationOperate);
                                            r1.Route = RouteType.A_F;
                                            r1.Description = string.Format("{0}_{1}", aStation.StationName, fStation.StationName);
                                            r1.Operation = 0;
                                            r1.State = 0;
                                            desc += r1.Description;
                                            taskInfo.T_Process.Add(r1);

                                            RouteInfo r2 = new RouteInfo();
                                            r2.Index = 0;
                                            r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait1").Value.StationOperate);
                                            r2.Station = 0;
                                            r2.Route = RouteType.GoWait1;
                                            r2.Description = "Go wait1";
                                            r2.Operation = 0;
                                            r2.State = 0;
                                            desc += "|" + r2.Description;
                                            taskInfo.T_Process.Add(r2);

                                            taskInfo.T_Description = desc;
                                            Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                            Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                            isCreateTask_A = true;
                                            #endregion
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {//无站点呼叫，则直接跳出循环
                                    break;
                                }
                            }
                            while (aStation != null);
                            if (isCreateTask_A == false)
                            {//没有站点任务，
                                StationInformation cStation = Common.Instance.dtStationInformation.OrderBy(o => o.Value.UpdateTime).ToDictionary(o => o.Key, p => p.Value).FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_C && o.Value.State == (int)EStationState.Busy && o.Value.StationEnable).Value;  //查询C站点是否有料车
                                if (cStation != null)
                                {
                                    StationInformation fStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F && o.Value.State == (int)EStationState.Free && o.Value.StationEnable).Value;//F站点无料车
                                    if (fStation != null)
                                    {
                                        #region Transport1_C-F
                                        MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_C_F, cStation.Key, typeTask);
                                        taskInfo.T_CreateTime = DateTime.Now;
                                        taskInfo.ProcessIndex = 0;
                                        string desc = string.Empty;

                                        RouteInfo r1 = new RouteInfo();
                                        r1.Index = 0;
                                        r1.SourceStation = int.Parse(cStation.StationOperate);
                                        r1.Station = int.Parse(fStation.StationOperate);
                                        r1.Route = RouteType.C_F;
                                        r1.Description = string.Format("{0}_{1}", cStation.StationName, fStation.StationName);
                                        r1.Operation = 0;
                                        r1.State = 0;
                                        desc += r1.Description;
                                        taskInfo.T_Process.Add(r1);

                                        RouteInfo r3 = new RouteInfo();
                                        r3.Index = 0;
                                        r3.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait1").Value.StationOperate);
                                        r3.Station = 0;
                                        r3.Route = RouteType.GoWait1;
                                        r3.Description = "Go wait1";
                                        r3.Operation = 0;
                                        r3.State = 0;
                                        desc += "|" + r3.Description;
                                        taskInfo.T_Process.Add(r3);

                                        taskInfo.T_Description = desc;
                                        Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                        Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                        isCreateTask_A = true;
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                    #endregion
                    //B类型
                    Thread.Sleep(50);
                    #region B 类型
                    try
                    {
                        int rfid = -1;
                        int agvNo = -1;
                        rfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationMatchValue.ToLowerInvariant().Contains("wait2")).Value.StationRfidLs[0];
                        agvNo = Common.maiDict.FirstOrDefault(o => (int)o.Value.Type == typeTask && o.Value.VirtualRfid == rfid && o.Value.VoltageStatus == Enumerations.voltageStatus.normal && o.Value.State == (int)Enumerations.AgvStatus.stop && o.Value.IsCanReceiveTask && string.IsNullOrEmpty(o.Value.Task1) && string.IsNullOrEmpty(o.Value.Task2) && o.Value.Default7 == 0 && o.Value.Default8 == 0).Key;
                        //agvNo = 1;
                        bool isHaveTask = Common.taskDt[typeTask].Any(o => o.Value.T_Type == Enumerations.TaskType.Transport_B_D || o.Value.T_Type == Enumerations.TaskType.Transport_B_E || o.Value.T_Type == Enumerations.TaskType.Transport_D_E || o.Value.T_Type == Enumerations.TaskType.Transport_F_B);//是否已存在B类型的任务
                        if (agvNo > 0 && !isHaveTask)
                        {//有可用AGV
                            bool isCreateTask_B = false;//是否已经生成任务
                            List<string> QueryStations = new List<string>();
                            StationInformation bStation = null;
                            do
                            {
                                bStation = Common.Instance.dtStationInformation.OrderBy(o => o.Value.UpdateTime).ToDictionary(o => o.Key, p => p.Value).FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_B && o.Value.State == (int)EStationState.Busy && QueryStations.Contains(o.Key) == false && o.Value.StationEnable).Value;
                                if (bStation != null)
                                {
                                    QueryStations.Add(bStation.Key);
                                    if (bStation.LoadReady && bStation.UnloadReady == false)
                                    {//需要物料,查询F点是否有物料
                                        StationInformation fStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_F && o.Value.State == (int)EStationState.Busy && o.Value.StationEnable).Value;//查询F点是否有物料
                                        if (fStation != null && Common.maiDict.Any(o => fStation.StationRfidLs.Contains(o.Value.VirtualRfid)) == false)
                                        {
                                            #region Transport_F-B
                                            MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_F_B, bStation.Key, typeTask);
                                            taskInfo.ProcessIndex = 0;
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
                                            taskInfo.T_Process.Add(r1);

                                            RouteInfo r2 = new RouteInfo();
                                            r2.Index = 0;
                                            r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait2").Value.StationOperate);
                                            r2.Station = 0;
                                            r2.Route = RouteType.GoWait2;
                                            r2.Description = "Go wait2";
                                            r2.Operation = 0;
                                            r2.State = 0;
                                            desc += "|" + r2.Description;
                                            taskInfo.T_Process.Add(r2);

                                            taskInfo.T_Description = desc;
                                            Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                            Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                            isCreateTask_B = true;
                                            #endregion
                                        }
                                    }
                                    else if (bStation.LoadReady == false && bStation.UnloadReady)
                                    {//需要将物料拉走,查询E点是否空闲，若不空闲，则将其拉到D类型站点
                                        StationInformation eStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E && o.Value.State == (int)EStationState.Free && o.Value.StationEnable).Value;  //E站点无料车
                                        if (eStation == null)
                                        {
                                            StationInformation dStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_D && o.Value.State == (int)EStationState.Free && o.Value.StationEnable).Value;  //查找空闲的D类型缓存区 
                                            if (dStation == null)
                                            {//D类型缓存区没空位，向站点写入7状态(料位已满) 

                                            }
                                            else
                                            {
                                                #region Transport_B_D
                                                MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_B_D, bStation.Key, typeTask);
                                                taskInfo.ProcessIndex = 0;
                                                string desc = string.Empty;
                                                RouteInfo r1 = new RouteInfo();
                                                r1.Index = 0;
                                                r1.SourceStation = int.Parse(bStation.StationOperate);
                                                r1.Station = int.Parse(dStation.StationOperate);
                                                r1.Route = RouteType.B_D;
                                                r1.Description = string.Format("{0}_{1}", bStation.StationName, dStation.StationName);
                                                r1.Operation = 0;
                                                r1.State = 0;
                                                desc += r1.Description;
                                                taskInfo.T_Process.Add(r1);

                                                RouteInfo r2 = new RouteInfo();
                                                r2.Index = 0;
                                                r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait2").Value.StationOperate);
                                                r2.Station = 0;
                                                r2.Route = RouteType.GoWait1;
                                                r2.Description = "Go wait2";
                                                r2.Operation = 0;
                                                r2.State = 0;
                                                desc += "|" + r2.Description;
                                                taskInfo.T_Process.Add(r2);

                                                taskInfo.T_Description = desc;
                                                Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                                Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                                isCreateTask_B = true;
                                                #endregion
                                            }
                                        }
                                        else
                                        {
                                            #region Transport_B_E
                                            MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_B_E, bStation.Key, typeTask);
                                            taskInfo.ProcessIndex = 0;
                                            string desc = string.Empty;
                                            RouteInfo r1 = new RouteInfo();
                                            r1.Index = 0;
                                            r1.SourceStation = int.Parse(bStation.StationOperate);
                                            r1.Station = int.Parse(eStation.StationOperate);
                                            r1.Route = RouteType.B_E;
                                            r1.Description = string.Format("{0}_{1}", bStation.StationName, eStation.StationName);
                                            r1.Operation = 0;
                                            r1.State = 0;
                                            desc += r1.Description;
                                            taskInfo.T_Process.Add(r1);

                                            RouteInfo r2 = new RouteInfo();
                                            r2.Index = 0;
                                            r2.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait2").Value.StationOperate);
                                            r2.Station = 0;
                                            r2.Route = RouteType.GoWait1;
                                            r2.Description = "Go wait2";
                                            r2.Operation = 0;
                                            r2.State = 0;
                                            desc += "|" + r2.Description;
                                            taskInfo.T_Process.Add(r2);

                                            taskInfo.T_Description = desc;
                                            Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                            Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                            isCreateTask_B = true;
                                            #endregion
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {//无站点呼叫，则直接跳出循环
                                    break;
                                }
                            }
                            while (bStation != null);
                            if (isCreateTask_B == false)
                            {//没有站点任务，
                                StationInformation dStation = Common.Instance.dtStationInformation.OrderBy(o => o.Value.UpdateTime).ToDictionary(o => o.Key, p => p.Value).FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_D && o.Value.State == (int)EStationState.Busy && o.Value.StationEnable).Value;  //查询D站点是否有料车
                                if (dStation != null)
                                {
                                    StationInformation eStation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Type_E && o.Value.State == (int)EStationState.Free).Value;//E站点无料车
                                    if (eStation != null)
                                    {
                                        #region Transport1_D-E
                                        MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Transport_D_E, dStation.Key, typeTask);
                                        taskInfo.T_CreateTime = DateTime.Now;
                                        taskInfo.ProcessIndex = 0;
                                        string desc = string.Empty;

                                        RouteInfo r1 = new RouteInfo();
                                        r1.Index = 0;
                                        r1.SourceStation = int.Parse(dStation.StationOperate);
                                        r1.Station = int.Parse(eStation.StationOperate);
                                        r1.Route = RouteType.D_E;
                                        r1.Description = string.Format("{0}_{1}", dStation.StationName, eStation.StationName);
                                        r1.Operation = 0;
                                        r1.State = 0;
                                        desc += r1.Description;
                                        taskInfo.T_Process.Add(r1);

                                        RouteInfo r3 = new RouteInfo();
                                        r3.Index = 0;
                                        r3.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == _group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationMatchValue.ToLowerInvariant() == "wait2").Value.StationOperate);
                                        r3.Station = 0;
                                        r3.Route = RouteType.GoWait1;
                                        r3.Description = "Go wait2";
                                        r3.Operation = 0;
                                        r3.State = 0;
                                        desc += "|" + r3.Description;
                                        taskInfo.T_Process.Add(r3);

                                        taskInfo.T_Description = desc;
                                        Common.taskDt[typeTask][taskInfo.T_Id] = taskInfo;
                                        Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                                        isCreateTask_B = true;
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                    #endregion
                }
            }
            catch { }
        }
        #endregion
        #region 初始化任务
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
        #region 创建由充电桩移往待机点任务
        /// <summary>
        /// 创建由充电桩移往待机点任务
        /// </summary>
        /// <param name="agvNo">agv编号</param>
        /// <param name="waitKey">待机点关键值</param>
        /// <param name="group">组别</param>
        /// <returns></returns>
        private MA_AgvTaskInfo CreateLeaveChargeTask(int agvNo, string waitKey, int group)
        {
            MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Chareg_Leave, string.Empty, group);
            taskInfo.ProcessIndex = 0;
            string desc = string.Empty;
            int rfid = Common.maiDict[agvNo].VirtualRfid;
            RouteInfo r1 = new RouteInfo();
            r1.Index = 0;
            r1.SourceStation = int.Parse(Common.Instance.dtStationInformation[waitKey].StationOperate);
            r1.Station = 0;
            r1.Route = RouteType.LeaveCharge;
            r1.Description = string.Format("Go {0}", Common.Instance.dtStationInformation[waitKey].StationName);
            r1.Operation = 0;
            r1.State = 0;
            desc += r1.Description;
            taskInfo.T_Process.Add(r1);
            taskInfo.T_Description = desc;
            return taskInfo;
        }
        #endregion
        #region 创建前往充电桩任务
        /// <summary>
        /// 创建前往充电桩任务
        /// </summary>
        /// <param name="agvNo">agv编号</param>
        /// <param name="chargeNo">充电桩编号</param>
        private MA_AgvTaskInfo CreatChargeTask(int agvNo, string chargeNo, int group)
        {
            MA_AgvTaskInfo taskInfo = InitTask(agvNo, Enumerations.TaskType.Charge_Go, string.Empty, group);
            taskInfo.ProcessIndex = 0;
            string desc = string.Empty;
            int rfid = Common.maiDict[agvNo].VirtualRfid;
            RouteInfo r1 = new RouteInfo();
            r1.Index = 0;
            r1.SourceStation = int.Parse(Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationRfidLs.Contains(rfid)).Value.StationOperate);
            r1.Station = int.Parse(Common.Instance.dtStationInformation[chargeNo].StationOperate);
            r1.Route = RouteType.GoCharge;
            r1.Description = string.Format("Go {0}", Common.Instance.dtStationInformation[chargeNo].StationName);
            r1.Operation = 0;
            r1.State = 0;
            desc += r1.Description;
            taskInfo.T_Process.Add(r1);
            taskInfo.T_Description = desc;
            return taskInfo;
        }
        #endregion
    }
}
