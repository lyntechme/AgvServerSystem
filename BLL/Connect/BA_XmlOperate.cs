using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.IO;

namespace BLL
{
    public class BA_XmlOperate
    {
        public static bool saveParamterBuffer = false;
        public static bool saveTaskBuffer = false;

        private static string path = Common.Instance.SourcePath + @"\Information\rfidPoint.xml";
        private static string pathParameter = Common.Instance.SourcePath + @"\Information\ConfigParameter.xml";
        private static string pathParameter2 = Common.Instance.SourcePath + @"\Information\ConfigParameter_Buffer.xml";

        private static string pathStationLabel = Common.Instance.SourcePath + @"\Information\StationLabel.xml";
        private static string pathDoorInfo = Common.Instance.SourcePath + @"\Information\DoorInfo.xml";
        private static string pathElevatorInfo = Common.Instance.SourcePath + @"\Information\ElevatorInfo.xml";
        private static string pathChargeInfo = Common.Instance.SourcePath + @"\Information\ChargeInfo.xml";
        private static string pathStationInfo = Common.Instance.SourcePath + @"\Information\StationInfo.xml";
        private static string pathDetectorInfo = Common.Instance.SourcePath + @"\Information\DetectorInfo.xml";
        private static string pathTaskInfo = Common.Instance.SourcePath + @"\Information\TaskInfo.xml";
        private static string pathTaskInfo2 = Common.Instance.SourcePath + @"\Information\TaskInfo_Buffer.xml";
        private static string pathMatchStationInfo = Common.Instance.SourcePath + @"\Information\MatchStationInfo.xml";

        /// <summary>
        /// 读取Rfid坐标参数
        /// </summary>
        /// <returns></returns>
        public static List<MA_RfidPoint> AgvRfidPointRead()
        {
            List<MA_RfidPoint> lmr = new List<MA_RfidPoint>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.Rfid, path, typeof(List<MA_RfidPoint>), new Type[] { typeof(RfidInfo) });
            if (obj != null)
            {
                lmr = (List<MA_RfidPoint>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存Rfid坐标参数
        /// </summary>
        /// <returns></returns>
        public static bool AgvRfidPointSave(List<MA_RfidPoint> rfidLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.Rfid, path, typeof(List<MA_RfidPoint>), rfidLs, new Type[] { typeof(RfidInfo) });
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取指定匹配参数
        /// </summary>
        /// <returns></returns>
        public static List<MatchStationInfo> MatchStationRead()
        {
            List<MatchStationInfo> lmr = new List<MatchStationInfo>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.MatchStation, pathMatchStationInfo, typeof(List<MatchStationInfo>));
            if (obj != null)
            {
                lmr = (List<MatchStationInfo>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存指定匹配参数
        /// </summary>
        /// <returns></returns>
        public static bool MatchStationSave(List<MatchStationInfo> matchStationLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.MatchStation, pathMatchStationInfo, typeof(List<MatchStationInfo>), matchStationLs);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取配置参数信息
        /// </summary>
        /// <returns></returns>
        public static List<KeyValue> ParameterRead()
        {

            FileInfo fi = new FileInfo(pathParameter);
            DateTime dt = fi.LastWriteTime;
            fi = new FileInfo(pathParameter2);
            DateTime dt2 = fi.LastWriteTime;
            List<KeyValue> lkv = new List<KeyValue>();

            string pathString = dt > dt2 ? pathParameter : pathParameter2;

            bool isReadOK = false;//是否读取成功

            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.InitParameter, pathString, typeof(List<KeyValue>));
            if (obj != null)
            {
                lkv = (List<KeyValue>)obj;
                if (lkv.Count > 0)
                {
                    saveParamterBuffer = true;
                    isReadOK = true;
                }
            }
            if (isReadOK == false)
            {
                pathString = dt > dt2 ? pathParameter2 : pathParameter;
                obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.InitParameter, pathString, typeof(List<KeyValue>));
                if (obj != null)
                {
                    saveParamterBuffer = false;
                    lkv = (List<KeyValue>)obj;
                }
            }
            return lkv;
        }
        /// <summary>
        /// 保存配置参数信息
        /// </summary>
        /// <returns></returns>
        public static bool ParameterSave(List<KeyValue> dtParameter)
        {
            try
            {
                string pathString = saveParamterBuffer ? pathParameter2 : pathParameter;
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.InitParameter, pathString, typeof(List<KeyValue>), dtParameter);
                saveParamterBuffer = !saveParamterBuffer;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取站点坐标参数
        /// </summary>
        /// <returns></returns>
        public static List<StationInfo> StationLabelInfoRead()
        {
            List<StationInfo> lmr = new List<StationInfo>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.StationLabel, pathStationLabel, typeof(List<StationInfo>), new Type[] { typeof(int) });
            if (obj != null)
            {
                lmr = (List<StationInfo>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存站点坐标参数
        /// </summary>
        /// <returns></returns>
        public static bool StationLabelInfoSave(List<StationInfo> stationlabelInfoLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.StationLabel, pathStationLabel, typeof(List<StationInfo>), stationlabelInfoLs, new Type[] { typeof(int) });
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取房门参数
        /// </summary>
        /// <returns></returns>
        public static List<DoorInfo> DoorInfoRead()
        {
            List<DoorInfo> lmr = new List<DoorInfo>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.Door, pathDoorInfo, typeof(List<DoorInfo>), new Type[] { typeof(int), typeof(DoorCommunication) });
            if (obj != null)
            {
                lmr = (List<DoorInfo>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存房门参数
        /// </summary>
        /// <returns></returns>
        public static bool DoorInfoSave(List<DoorInfo> doorLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.Door, pathDoorInfo, typeof(List<DoorInfo>), doorLs, new Type[] { typeof(int), typeof(DoorCommunication) });
                return true;
            }
            catch
            {
                return false;
            }
        } /// <summary>
        /// 读取电梯参数
        /// </summary>
        /// <returns></returns>
        public static List<ElevatorInfo> ElevatorInfoRead()
        {
            List<ElevatorInfo> lmr = new List<ElevatorInfo>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.ElevatorInfo, pathElevatorInfo, typeof(List<ElevatorInfo>), new Type[] { typeof(int), typeof(ElevatorCommunication) });
            if (obj != null)
            {
                lmr = (List<ElevatorInfo>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存电梯参数
        /// </summary>
        /// <returns></returns>
        public static bool ElevatorInfoSave(List<ElevatorInfo> elevatorLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.ElevatorInfo, pathElevatorInfo, typeof(List<ElevatorInfo>), elevatorLs, new Type[] { typeof(int), typeof(ElevatorCommunication) });
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取充电桩参数
        /// </summary>
        /// <returns></returns>
        public static List<ChargeInfo> ChargeInfoRead()
        {
            List<ChargeInfo> lmr = new List<ChargeInfo>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.Charge, pathChargeInfo, typeof(List<ChargeInfo>), new Type[] { typeof(int), typeof(ChargeCommunication) });
            if (obj != null)
            {
                lmr = (List<ChargeInfo>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存充电桩参数
        /// </summary>
        /// <returns></returns>
        public static bool ChargeInfoSave(List<ChargeInfo> chargeLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.Charge, pathChargeInfo, typeof(List<ChargeInfo>), chargeLs, new Type[] { typeof(int), typeof(ChargeCommunication) });
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取站点参数
        /// </summary>
        /// <returns></returns>
        public static List<StationInformation> StationInfoRead()
        {
            List<StationInformation> lmr = new List<StationInformation>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.Statoin, pathStationInfo, typeof(List<StationInformation>), new Type[] { typeof(int) });
            if (obj != null)
            {
                lmr = (List<StationInformation>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存站点参数
        /// </summary>
        /// <returns></returns>
        public static bool StationInfoSave(List<StationInformation> stationLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.Statoin, pathStationInfo, typeof(List<StationInformation>), stationLs, new Type[] { typeof(int) });
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取分容柜参数
        /// </summary>
        /// <returns></returns>
        public static List<BatteryCapacityDetectorParameters> DectectorInfoRead()
        {
            List<BatteryCapacityDetectorParameters> lmr = new List<BatteryCapacityDetectorParameters>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.Detector, pathDetectorInfo, typeof(List<BatteryCapacityDetectorParameters>));
            if (obj != null)
            {
                lmr = (List<BatteryCapacityDetectorParameters>)obj;
            }
            return lmr;
        }
        /// <summary>
        /// 保存分容柜参数
        /// </summary>
        /// <returns></returns>
        public static bool DetectorInfoSave(List<BatteryCapacityDetectorParameters> DetectorLs)
        {
            try
            {
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.Detector, pathDetectorInfo, typeof(List<BatteryCapacityDetectorParameters>), DetectorLs);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取尚未完成任务
        /// </summary>
        /// <returns></returns>
        public static List<MA_AgvTaskInfo> TaskInfoRead()
        {
            FileInfo fi = new FileInfo(pathTaskInfo);
            DateTime dt = fi.LastWriteTime;
            fi = new FileInfo(pathTaskInfo2);
            DateTime dt2 = fi.LastWriteTime;

            string taskPathString = dt > dt2 ? pathTaskInfo : pathTaskInfo2;

            List<MA_AgvTaskInfo> lmr = new List<MA_AgvTaskInfo>();
            object obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.Task, taskPathString, typeof(List<MA_AgvTaskInfo>), new Type[] { typeof(RouteInfo) });
            if (obj != null)
            {
                lmr = (List<MA_AgvTaskInfo>)obj;
                saveTaskBuffer = true;
            }
            else
            {
                taskPathString = dt > dt2 ? pathTaskInfo2 : pathTaskInfo;
                obj = BX_XmlFile.readXml(BX_XmlFile.ESerializerType.Task, taskPathString, typeof(List<MA_AgvTaskInfo>), new Type[] { typeof(RouteInfo) });
                if (obj != null)
                {
                    lmr = (List<MA_AgvTaskInfo>)obj;
                    saveTaskBuffer = false;
                }
            }
            return lmr;
        }
        /// <summary>
        /// 保存在线任务
        /// </summary>
        /// <returns></returns>
        public static bool TaskInfoSave(List<MA_AgvTaskInfo> taskLs)
        {
            try
            {
                string taskPathString = saveTaskBuffer ? pathTaskInfo2 : pathTaskInfo;
                BX_XmlFile.saveXml(BX_XmlFile.ESerializerType.Task, taskPathString, typeof(List<MA_AgvTaskInfo>), taskLs, new Type[] { typeof(RouteInfo) });
                saveTaskBuffer = !saveTaskBuffer;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
