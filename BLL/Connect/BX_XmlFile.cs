using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Model;

namespace BLL
{
    class BX_XmlFile
    {
        public static XmlSerializer xsInit = new XmlSerializer(typeof(List<KeyValue>));
        public static XmlSerializer xsStation = new XmlSerializer(typeof(List<StationInformation>));
        public static XmlSerializer xsRfid = new XmlSerializer(typeof(List<MA_RfidPoint>), new Type[] { typeof(RfidInfo) });
        public static XmlSerializer xsDoor = new XmlSerializer(typeof(List<DoorInfo>), new Type[] { typeof(int), typeof(DoorCommunication) });
        public static XmlSerializer xsElevator = new XmlSerializer(typeof(List<ElevatorInfo>), new Type[] { typeof(int), typeof(ElevatorCommunication) });
        public static XmlSerializer xsCharge = new XmlSerializer(typeof(List<ChargeInfo>), new Type[] { typeof(int), typeof(ChargeCommunication) });
        public static XmlSerializer xsDectector = new XmlSerializer(typeof(List<BatteryCapacityDetectorParameters>));
        public static XmlSerializer xsTask = new XmlSerializer(typeof(List<MA_AgvTaskInfo>), new Type[] { typeof(RouteInfo) });
        public static XmlSerializer xsStationLabel = new XmlSerializer(typeof(List<StationInfo>));
        public static XmlSerializer xsMatchStation = new XmlSerializer(typeof(List<MatchStationInfo>));
        public static void saveXml(ESerializerType serializerType, string filePath, Type type, object ob, params Type[] t)
        {
            //xs = new XmlSerializer(type, t);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
            using (Stream stream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite))
            {
                switch (serializerType)
                {
                    case ESerializerType.InitParameter:
                        xsInit.Serialize(stream, ob);
                        break;
                    case ESerializerType.Rfid:
                        xsRfid.Serialize(stream, ob);
                        break;
                    case ESerializerType.Statoin:
                        xsStation.Serialize(stream, ob);
                        break;
                    case ESerializerType.Door:
                        xsDoor.Serialize(stream, ob);
                        break;
                    case ESerializerType.ElevatorInfo:
                        xsElevator.Serialize(stream, ob);
                        break;
                    case ESerializerType.Charge:
                        xsCharge.Serialize(stream, ob);
                        break;
                    case ESerializerType.Detector:
                        xsDectector.Serialize(stream, ob);
                        break;
                    case ESerializerType.Task:
                        xsTask.Serialize(stream, ob);
                        break;
                    case ESerializerType.StationLabel:
                        xsStationLabel.Serialize(stream, ob);
                        break;
                    case ESerializerType.MatchStation:
                        xsMatchStation.Serialize(stream, ob);
                        break;
                }
                stream.Flush();
                stream.Close();
                //stream.Dispose();
            }
        }
        public static object readXml(ESerializerType serializerType, String filePath, Type type, params Type[] t)
        {
            object ob = new object();
            try
            {
                using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    switch (serializerType)
                    {
                        case ESerializerType.InitParameter:
                            ob = xsInit.Deserialize(stream);
                            break;
                        case ESerializerType.Rfid:
                            ob = xsRfid.Deserialize(stream);
                            break;
                        case ESerializerType.Statoin:
                            ob = xsStation.Deserialize(stream);
                            break;
                        case ESerializerType.Door:
                            ob = xsDoor.Deserialize(stream);
                            break;
                        case ESerializerType.ElevatorInfo:
                            ob = xsElevator.Deserialize(stream);
                            break;
                        case ESerializerType.Charge:
                            ob = xsCharge.Deserialize(stream);
                            break;
                        case ESerializerType.Detector:
                            ob = xsDectector.Deserialize(stream);
                            break;
                        case ESerializerType.Task:
                            ob = xsTask.Deserialize(stream);
                            break;
                        case ESerializerType.StationLabel:
                            ob = xsStationLabel.Deserialize(stream);
                            break;
                        case ESerializerType.MatchStation:
                            ob = xsMatchStation.Deserialize(stream);
                            break;
                    }
                    //ob = xs.Deserialize(stream);
                    stream.Flush();
                    stream.Close();
                    //stream.Dispose();
                }
            }
            catch
            {
                ob = null;
            }
            return ob;

        }
        public enum ESerializerType
        {
            /// <summary>
            /// 配置参数
            /// </summary>
            InitParameter = 1,
            /// <summary>
            /// 房门
            /// </summary>
            Door = 2,
            /// <summary>
            /// 充电桩
            /// </summary>
            Charge = 3,
            /// <summary>
            /// 站点
            /// </summary>
            Statoin = 4,
            /// <summary>
            /// RFID
            /// </summary>
            Rfid = 5,
            /// <summary>
            /// 分容柜机械臂参数
            /// </summary>
            Detector = 6,
            /// <summary>
            /// 任务
            /// </summary>
            Task = 7,
            /// <summary>
            /// 
            /// </summary>
            StationLabel = 8,
            /// <summary>
            /// 指定匹配
            /// </summary>
            MatchStation = 9,
            /// <summary>
            /// 电梯
            /// </summary>
            ElevatorInfo = 10,
        }
    }
}
