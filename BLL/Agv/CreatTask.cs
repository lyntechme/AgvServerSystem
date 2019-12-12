using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CreatTask
    {
        /// <summary>
        /// 生成回待机点
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="agvNo"></param>
        /// <param name="group"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool CreateGoWaitTaskFuction(string taskName, int agvNo, int group, bool dir)
        {
            bool isCreateOk = true;
            try
            {
                //MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                //taskInfo.T_State = Enumerations.TaskStatus.Start;
                //taskInfo.IsUpdate = true;
                //taskInfo.T_Type = Enumerations.TaskType.Test_GoAwait;
                //taskInfo.IsTest = true;
                //RouteInfo re;
                //int waitNo = 0;
                //if (agvNo > 0)
                //{
                //    taskInfo.T_Load = Common.maiDict[agvNo].Rfid;
                //    int bufferRfid = -1;
                //    if ((Common.maiDict[agvNo].Rfid >= 6801 && Common.maiDict[agvNo].Rfid <= 6899) || (Common.maiDict[agvNo].Rfid >= 7001 && Common.maiDict[agvNo].Rfid <= 7099) || Common.maiDict[agvNo].Rfid <= 0)
                //    {
                //        isCreateOk = false;
                //    }
                //    waitNo = Common.Instance.dtCapacityTestWait.FirstOrDefault(o => o.Value.lsRfids.Any(p => taskInfo.T_Load >= p.X && taskInfo.T_Load <= p.Y)).Key;
                //    if (waitNo <= 0)
                //    {
                //        //int wait1Rfid = Common.Instance.dtCapacityTestWait[1].Rfid;
                //        //int countWait1 = Common.maiDict.Count(o => (o.Value.Rfid >= 5001 && o.Value.Rfid <= 5499) || (o.Value.Rfid >= 6801 && o.Value.Rfid <= 6899) || (o.Value.Rfid >= 6401 && o.Value.Rfid <= wait1Rfid));
                //        //int wait2Rfid = Common.Instance.dtCapacityTestWait[2].Rfid;
                //        //int countWait2 = Common.maiDict.Count(o => (o.Value.Rfid >= 5501 && o.Value.Rfid <= 6099) || (o.Value.Rfid >= 6901 && o.Value.Rfid <= 7099) || (o.Value.Rfid >= 6501 && o.Value.Rfid <= wait2Rfid));
                //        //if (countWait1 > (countWait2 - 10)) waitNo = 2; else waitNo = 1;
                //        if (dir) waitNo = 2;
                //        else waitNo = 1;
                //        if (waitNo == 1)
                //        {
                //            bufferRfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.SubCabinet && o.Value.Group == group && o.Value.StationRfid <= 5499).Value.StationRfid;
                //        }
                //        else { bufferRfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.SubCabinet && o.Value.Group == group && o.Value.StationRfid >= 5501).Value.StationRfid; }
                //    }
                //    taskInfo.BufferRfid = bufferRfid;
                //}
                //re = new RouteInfo(RouteType.GoWait, Common.Instance.dtCapacityTestWait[waitNo].Rfid, 0, string.Format("前往分容测试待机点{0}", waitNo));
                ////taskInfo.T_Load = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == 1 && o.Value.StationMatchValue == taskRelease.PlaceSource[0].Trim()).Value.StationNo;
                //taskInfo.T_Process.Add(re);
                //taskInfo.ProcessIndex = 0;
                //taskInfo.T_CreateTime = DateTime.Now;
                //taskInfo.T_Level = 0;
                //taskInfo.T_AgvNo = agvNo;
                //taskInfo.T_Id = taskName;
                //taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                //if (isCreateOk)
                //{
                //    if (agvNo > 0)
                //    {
                //        Common.maiDict[agvNo].Task1 = taskInfo.T_Id;
                //    }
                //    Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                //}
            }
            catch { }
            return isCreateOk;
        }
        /// <summary>
        /// 创建前往分容柜任务，但不执行机械臂动作
        /// </summary>
        /// <param name="waitNo">待机位编号</param>
        /// <param name="agvNo">小车编号</param>
        /// <param name="group">分容柜组别</param>
        /// <returns></returns>
        public static bool CreateCapTestNullOperate(int waitNo, int agvNo, int group)
        {
            bool isCreateOk = true;
            try
            {
                //MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                //taskInfo.T_State = Enumerations.TaskStatus.Accept;
                //StationInformation stationInformationTarget;
                //taskInfo.IsUpdate = true;
                //taskInfo.T_Type = Enumerations.TaskType.Test_FullCommparmentRefueling;
                //taskInfo.IsTest = true;
                //RouteInfo re;
                //RouteInfo rSource;
                //string sourceMatchValue = string.Empty;
                //string targetMatchValue = string.Empty;
                //if (waitNo == 1)
                //{
                //    stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == group && o.Value.StationType == (int)StationInformation.EStationType.SubCabinet && o.Value.StationRfid <= 5499).Value;
                //}
                //else
                //{
                //    stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == group && o.Value.StationType == (int)StationInformation.EStationType.SubCabinet && o.Value.StationRfid > 5499).Value;
                //}
                //int rfid = stationInformationTarget.StationRfid;
                ////string operate = Common.Instance.dtStationInformation.Values.ToList().Find(o => o.StationMatchValue == targetMatchValue && o.StationType == (int)StationInformation.EStationType.SubCabinet).StationOperate;

                //string mv = stationInformationTarget.StationMatchValue;

                //RouteInfo r = new RouteInfo(RouteType.CapacityUnload, stationInformationTarget.StationRfid, 0, string.Format("往分容柜{0}填料(无动作)", mv));
                ////r.BackState = (int)EBackState.Accept;
                //taskInfo.T_Process.Add(r);

                //re = new RouteInfo(RouteType.GoWait, Common.Instance.dtCapacityTestWait[waitNo].Rfid, 0, string.Format("前往分容测试待机点{0}", waitNo));
                ////taskInfo.T_Load = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == 1 && o.Value.StationMatchValue == taskRelease.PlaceSource[0].Trim()).Value.StationNo;
                //taskInfo.T_Process.Add(re);
                //taskInfo.ProcessIndex = 0;
                //taskInfo.T_CreateTime = DateTime.Now;
                //taskInfo.T_Level = 0;
                //taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff") + "Null";
                //taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                //taskInfo.T_Description = stationInformationTarget.StationMatchValue;
                //taskInfo.T_AgvNo = agvNo;
                //if (Common.maiDict[agvNo].Task2 == string.Empty)
                //    Common.maiDict[agvNo].Task2 = taskInfo.T_Id;
                //else
                //{
                //    isCreateOk = false;
                //}
                //taskInfo.T_State = Enumerations.TaskStatus.Accept;
                //if (isCreateOk)
                //    Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
            }
            catch
            {
                isCreateOk = false;
            }
            return isCreateOk;
        }
    }
}
