using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public class ParametersOperate
    {
        /// <summary>
        /// 从xml读取参数
        /// </summary>
        public static void ParameterInit()
        {
            #region 读取设定初始参数
            if (!BS_CreateSqlLiteTables.CreateRfidPoint(Common.Instance.SourcePath + @"\Information\AgvData.db")) //判断文件是否存在，不存在则创建
            {
                MessageBox.Show("Local database initialization failed,Please restart the software.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            }
            lock (Common.lsXmlPParameter)
            {
                Common.lsXmlPParameter = BA_XmlOperate.ParameterRead();
                if (Common.lsXmlPParameter.Count <= 0)
                {
                    MessageBox.Show("Failed to read the initial parameters,Does the file 'ConfigParameter.xml' exist?", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                KeyValue kvsqlAddress = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.sqlAddress);
                KeyValue kvsqlDatabase = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.sqlDatabase);
                KeyValue kvsqlName = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.sqlUserName);
                KeyValue kvsqlPassward = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.sqlUserPwd);
                KeyValue kvagvLightColCount = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvLightColCount);
                KeyValue kvagvLightRowCount = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvLightRowCount);
                KeyValue kvagvLightX = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvLightX);
                KeyValue kvagvLightY = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvLightY);
                KeyValue kvdataType = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.dataSaveType);
                KeyValue kvlineName = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.lineName);
                KeyValue kvPositionName = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.positionName);
                KeyValue kvStationTime = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.stationTime);
                KeyValue kvAgvModelScale = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvModelScale);
                KeyValue kvcontrolPoints = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvControlPoints);
                KeyValue kvmapCount = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.mapCount);
                KeyValue kvmapChange = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.mapChange);
                KeyValue kvmapChangeTime = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.mapChangeTime);
                KeyValue kvchargeLimitedInfo = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.chargeLimitedInfo);
                KeyValue kvsplitStatusHeight = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.layoutHeightSplitStatus);
                KeyValue kvagvType = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvType);
                KeyValue kvrepeatRfids = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.repeatRfid);
                KeyValue kvstations = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.stations);
                KeyValue kvmitsubishiPlc = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.mitsubishiPlc);
                KeyValue kvsizeStation = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.sizeStatin);
                KeyValue kvpassEnable = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.passEnablePlc);
                KeyValue kvtestStation = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.testStationNo);
                KeyValue kvmesCt = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.mesCT);
                KeyValue kvtaskIndex = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.taskIndex);
                KeyValue kvcapacityTestWait = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.capacityTestWait);
                KeyValue kvsplitTask = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.splitTask);
                KeyValue kvagingRoom = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agingRoom);
                KeyValue kvagvTypeInfo = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvTypeInfo);
                KeyValue kvinsertCount = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.insertCount);
                KeyValue kvcapTestOperate = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.capTeatOperate);
                KeyValue kvcontrolAgvs = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.controlAgvs);
                KeyValue kvsubStayTime = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.subStayTime);
                KeyValue kvchargeVoltage = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.chargeVoltage);
                KeyValue kvreceiveMesTask = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.receiveMesTask);
                KeyValue kvlineTime = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.lineTime);
                KeyValue kvchargeVoltageCount = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.chargeVoltageCount);
                KeyValue kvisSaveRoute = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.isSaveRoute);
                KeyValue kvopcParameter = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.OpcParameters);
                KeyValue kvbufferGroup = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.bufferGroup);
                KeyValue kvloopCharge = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.loopCharge);
                KeyValue kvshowRfids = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.showRfids);
                KeyValue kvagvLimited = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.agvLimited);
                KeyValue kvisDynPwd = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.isDynPwd);
                KeyValue kvrfidType = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.rfidType);
                KeyValue kvopcConnect = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.opcConnect);
                KeyValue kvpanMapSplit = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.panMapSplit);
                KeyValue kvchargeTime = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.chargeTime);
                KeyValue kvstandbyChargeTime = Common.lsXmlPParameter.Find(s => (int)s.key == (int)ParameterList.standbyChargeTime);
                try
                {
                    if (kvsqlAddress != null) Common.sqlCommInfo.Address = (string)kvsqlAddress.value;
                    if (kvsqlDatabase != null) Common.sqlCommInfo.Database = (string)kvsqlDatabase.value;
                    if (kvsqlName != null) Common.sqlCommInfo.Name = (string)kvsqlName.value;
                    if (kvsqlPassward != null) Common.sqlCommInfo.Passward = (string)kvsqlPassward.value;
                    if (kvagvLightColCount != null) Common.agvstatusLayout.X = Convert.ToInt32((string)kvagvLightColCount.value);
                    if (kvagvLightRowCount != null) Common.agvstatusLayout.Y = Convert.ToInt32((string)kvagvLightRowCount.value);
                    if (kvagvLightX != null) Common.tlpPoint.X = Convert.ToInt32((string)kvagvLightX.value);
                    if (kvagvLightY != null) Common.tlpPoint.Y = Convert.ToInt32((string)kvagvLightY.value);
                    if (kvdataType != null) Common.dataSaveType = Convert.ToInt32((string)kvdataType.value); else Common.dataSaveType = (int)Enumerations.DataType.SqlLite;
                    if (kvlineName != null)
                    {
                        string _line = (string)kvlineName.value;
                        string[] _linel = _line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.lineNameDt.Clear();
                        foreach (string l in _linel)
                        {
                            string[] _l = l.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            Common.lineNameDt[_l[0]] = _l[1];
                        }
                    }
                    if (kvPositionName != null)
                    {
                        string _pos = (string)kvPositionName.value;
                        string[] _posN = _pos.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.pNameDt.Clear();
                        foreach (string p in _posN)
                        {
                            string[] _p = p.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            Common.pNameDt[_p[0]] = _p[1];
                        }
                    }
                    if (kvStationTime != null)
                    {
                        Common.stationTime = Convert.ToInt32((string)kvStationTime.value);
                    }
                    if (kvAgvModelScale != null)
                    {
                        Common.agvModelScale = Convert.ToDouble((string)kvAgvModelScale.value);
                    }
                }
                catch (Exception ep)
                { }
                if (kvcontrolPoints != null)
                {
                    try
                    {
                        string controlStr = (string)kvcontrolPoints.value;
                        string[] controlStrSplit = controlStr.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < controlStrSplit.Length; i++)
                        {
                            string[] controlStrSplitSplit = controlStrSplit[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int controlNo = Convert.ToInt32(controlStrSplitSplit[0]);
                            Common.controlPointsDict[controlNo] = new List<int>();
                            Common.controlPointsStatus[controlNo] = -1; //初始化
                            Common.controlPointAgvList[controlNo] = new List<int>();
                            Common.controlType[controlNo] = Enumerations.ControlType.InStation;
                            for (int j = 1; j < controlStrSplitSplit.Length; j++)
                            {
                                Common.controlPointsDict[controlNo].Add(Convert.ToInt32(controlStrSplitSplit[j]));
                            }
                        }
                    }
                    catch { }
                }
                if (kvcontrolAgvs != null)
                {
                    try
                    {
                        string controlStr = (string)kvcontrolAgvs.value;
                        string[] controlStrSplit = controlStr.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < controlStrSplit.Length; i++)
                        {
                            string[] controlStrSplitSplit = controlStrSplit[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int controlNo = Convert.ToInt32(controlStrSplitSplit[0]);
                            Common.controlPointAgvList[controlNo] = new List<int>();
                            for (int j = 1; j < controlStrSplitSplit.Length; j++)
                            {
                                Common.controlPointAgvList[controlNo].Add(Convert.ToInt32(controlStrSplitSplit[j]));
                            }
                        }
                    }
                    catch { }
                }
                if (kvmapCount != null)
                {
                    string sm = (string)kvmapCount.value;
                    string[] smc = sm.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < smc.Length; i++)
                    {
                        string[] sk = smc[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            Common.mapInfo[Convert.ToInt32(sk[0])] = sk[1];
                        }
                        catch { }
                    }
                }
                else
                {
                    Common.mapInfo[0] = "map1";
                }
                if (kvmapChange != null)
                {
                    try
                    {
                        Common.isMapChange = Convert.ToBoolean((string)kvmapChange.value);
                    }
                    catch { }
                }
                if (kvmapChangeTime != null)
                {
                    try
                    {
                        Common.mapChangeTime = Convert.ToInt32((string)kvmapChangeTime.value);
                    }
                    catch
                    {
                        Common.mapChangeTime = 10000;
                    }
                }
                if (kvchargeLimitedInfo != null)
                {
                    try
                    {
                        string chargeLimitedStr = (string)kvchargeLimitedInfo.value;
                        string[] chargeLimitedStrSplit = chargeLimitedStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (chargeLimitedStrSplit.Length == 3)
                        {
                            try
                            {
                                string[] s1 = chargeLimitedStrSplit[0].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedLow = Convert.ToInt32(s1[0]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedCharge = Convert.ToInt32(s1[1]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedTime = Convert.ToInt32(s1[2]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedEnable = Convert.ToInt32(s1[3]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimiteLowTime = Convert.ToInt32(s1[4]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].FullTime = Convert.ToInt32(s1[5]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].ChargeVoltage = Convert.ToInt32(s1[6]);
                            }
                            catch { }
                            try
                            {
                                string[] s2 = chargeLimitedStrSplit[1].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedLow = Convert.ToInt32(s2[0]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedCharge = Convert.ToInt32(s2[1]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedTime = Convert.ToInt32(s2[2]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedEnable = Convert.ToInt32(s2[3]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimiteLowTime = Convert.ToInt32(s2[4]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].FullTime = Convert.ToInt32(s2[5]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].ChargeVoltage = Convert.ToInt32(s2[6]);
                            }
                            catch { }
                            try
                            {
                                string[] s3 = chargeLimitedStrSplit[2].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedLow = Convert.ToInt32(s3[0]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedCharge = Convert.ToInt32(s3[1]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedTime = Convert.ToInt32(s3[2]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedEnable = Convert.ToInt32(s3[3]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimiteLowTime = Convert.ToInt32(s3[4]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].FullTime = Convert.ToInt32(s3[5]);
                                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].ChargeVoltage = Convert.ToInt32(s3[6]);
                            }
                            catch { }
                        }
                        ////分容测试
                        //Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedLow = Convert.ToInt32(chargeLimitedStrSplit[0]);
                        //Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedCharge = Convert.ToInt32(chargeLimitedStrSplit[1]);
                        //Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedTime = Convert.ToInt32(chargeLimitedStrSplit[2]);
                        //Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedEnable = Convert.ToInt32(chargeLimitedStrSplit[3]);
                        //if (chargeLimitedStrSplit.Length == 12)
                        //{
                        //    //预充老化
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedLow = Convert.ToInt32(chargeLimitedStrSplit[4]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedCharge = Convert.ToInt32(chargeLimitedStrSplit[5]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedTime = Convert.ToInt32(chargeLimitedStrSplit[6]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedEnable = Convert.ToInt32(chargeLimitedStrSplit[7]);
                        //    //分容老化
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedLow = Convert.ToInt32(chargeLimitedStrSplit[8]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedCharge = Convert.ToInt32(chargeLimitedStrSplit[9]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedTime = Convert.ToInt32(chargeLimitedStrSplit[10]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedEnable = Convert.ToInt32(chargeLimitedStrSplit[11]);
                        //}
                        //else
                        //{
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimiteLowTime = Convert.ToInt32(chargeLimitedStrSplit[4]);
                        //    //预充老化
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedLow = Convert.ToInt32(chargeLimitedStrSplit[5]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedCharge = Convert.ToInt32(chargeLimitedStrSplit[6]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedTime = Convert.ToInt32(chargeLimitedStrSplit[7]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedEnable = Convert.ToInt32(chargeLimitedStrSplit[8]);
                        //    //分容老化
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedLow = Convert.ToInt32(chargeLimitedStrSplit[9]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedCharge = Convert.ToInt32(chargeLimitedStrSplit[10]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedTime = Convert.ToInt32(chargeLimitedStrSplit[11]);
                        //    Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedEnable = Convert.ToInt32(chargeLimitedStrSplit[12]);
                        //}
                    }
                    catch { }
                }
                if (kvchargeVoltage != null)
                {
                    try
                    {
                        string[] schargevoltage = kvchargeVoltage.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in schargevoltage)
                        {
                            string[] scvs = item.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            if (scvs.Length == 2)
                            {
                                int agvNo = Convert.ToInt32(scvs[0]);
                                double vol = Convert.ToDouble(scvs[1]);
                                ChargeLimitedInfo.dtAgvChargeVoltage[agvNo] = vol;
                            }
                        }
                    }
                    catch { }
                }
                if (kvsplitStatusHeight != null)
                {
                    try
                    {
                        Common.splitStatusHeight = Convert.ToInt32((string)kvsplitStatusHeight.value);
                    }
                    catch { }
                }
                if (kvagvType != null)
                {
                    try
                    {
                        string[] types = ((string)kvagvType.value).Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            string[] type1 = types[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (type1.Length > 1)
                            {
                                for (int i = 1; i < type1.Length; i++)
                                {
                                    int agvNo = Convert.ToInt32(type1[i]);
                                    Common.Instance.agvType[agvNo] = Enumerations.agvType.type_1;
                                }
                            }
                        }
                        catch { }
                        try
                        {
                            string[] type2 = types[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (type2.Length > 1)
                            {
                                for (int i = 1; i < type2.Length; i++)
                                {
                                    int agvNo = Convert.ToInt32(type2[i]);
                                    Common.Instance.agvType[agvNo] = Enumerations.agvType.type_2;
                                }
                            }
                        }
                        catch { }
                    }
                    catch { }
                }
                if (kvrepeatRfids != null)
                {
                    try
                    {
                        string[] repeats = ((string)kvrepeatRfids.value).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < repeats.Length; i++)
                        {
                            Common.Instance.RepeatRfids.Add(Convert.ToInt32(repeats[i]));
                        }
                    }
                    catch { }
                }
                if (kvstations != null)
                {
                    try
                    {
                        string stations = (string)kvstations.value;
                        string[] stationsSplit = stations.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < stationsSplit.Length; i++)
                        {
                            string[] stationsSpitSpit = stationsSplit[i].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            int key = Convert.ToInt32(stationsSpitSpit[0]);
                            int value = Convert.ToInt32(stationsSpitSpit[1]);
                            Common.Instance.dtStationTransform[key] = value;
                        }

                    }
                    catch { }
                }
                if (kvsizeStation != null)
                {
                    try
                    {
                        string[] ss = kvsizeStation.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.sizeStationDefault = new point(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]));
                    }
                    catch { }
                }
                if (kvpassEnable != null)
                {
                    try
                    {
                        Common.Instance.passEnable = Convert.ToBoolean(kvpassEnable.value.ToString());
                    }
                    catch { }
                }
                if (kvtestStation != null)
                {
                    try
                    {
                        string[] ss = kvtestStation.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.Instance.dtRoutePass[RouteType.CapacityLoad].TestStationNo = Convert.ToInt32(ss[0]);
                        Common.Instance.dtRoutePass[RouteType.CapacityUnload].TestStationNo = Convert.ToInt32(ss[1]);
                    }
                    catch { }
                }
                if (kvmesCt != null)
                {
                    try
                    {
                        string[] ss = kvmesCt.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.Instance.mesConnectTime.GetTaskTime = Convert.ToInt32(ss[0]);
                        Common.Instance.mesConnectTime.UpdateAgvStateTime = Convert.ToInt32(ss[1]);
                        Common.Instance.mesConnectTime.UpdateTaskTime = Convert.ToInt32(ss[2]);
                    }
                    catch { }
                }
                if (kvtaskIndex != null)
                {
                    try
                    {
                        Common.Instance.taskIndex = Convert.ToInt32(kvtaskIndex.value.ToString());
                    }
                    catch { }
                }
                if (kvcapacityTestWait != null)
                {
                    try
                    {
                        string[] wStr = kvcapacityTestWait.value.ToString().Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] w1Str = wStr[0].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        int number1 = Convert.ToInt32(w1Str[0]);
                        int rfid1 = Convert.ToInt32(w1Str[1]);
                        string[] stationStrs = w1Str[2].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<point> stations = new List<point>();
                        foreach (string item in stationStrs)
                        {
                            string[] ss = item.Split('_');
                            point p = new point(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]));
                            stations.Add(p);
                        }
                        string[] rfidStrs = w1Str[3].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<point> rfids = new List<point>();
                        foreach (string item in rfidStrs)
                        {
                            string[] ss = item.Split('_');
                            point p = new point(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]));
                            rfids.Add(p);
                        }
                        Common.Instance.dtCapacityTestWait[number1] = new CapacityTestWaitInfo(number1, rfid1, stations, rfids);


                        string[] w2Str = wStr[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        int number2 = Convert.ToInt32(w2Str[0]);
                        int rfid2 = Convert.ToInt32(w2Str[1]);
                        string[] stationStrs2 = w2Str[2].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<point> stations2 = new List<point>();
                        foreach (string item in stationStrs2)
                        {
                            string[] ss = item.Split('_');
                            point p = new point(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]));
                            stations2.Add(p);
                        }
                        string[] rfidStrs2 = w2Str[3].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<point> rfids2 = new List<point>();
                        foreach (string item in rfidStrs2)
                        {
                            string[] ss = item.Split('_');
                            point p = new point(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]));
                            rfids2.Add(p);
                        }
                        Common.Instance.dtCapacityTestWait[number2] = new CapacityTestWaitInfo(number2, rfid2, stations2, rfids2);
                    }
                    catch { }
                }
                if (kvsplitTask != null)
                {
                    try
                    {
                        string[] sSPlitTask = kvsplitTask.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.splitTask.X = Convert.ToInt32(sSPlitTask[0]);
                        Common.splitTask.Y = Convert.ToInt32(sSPlitTask[1]);
                    }
                    catch { }
                }
                if (kvagingRoom != null)
                {
                    try
                    {
                        string[] sSplitAging = kvagingRoom.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] sPreAging = sSplitAging[0].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].LoadRfid = Convert.ToInt32(sPreAging[0]);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].StaticArea1Rfid = Convert.ToInt32(sPreAging[1]);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].StaticArea2Rfid = Convert.ToInt32(sPreAging[2]);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].UnloadRfid = Convert.ToInt32(sPreAging[3]);
                        string[] sCapAging = sSplitAging[1].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].LoadRfid = Convert.ToInt32(sCapAging[0]);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea1Rfid = Convert.ToInt32(sCapAging[1]);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea2Rfid = Convert.ToInt32(sCapAging[2]);
                        Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].UnloadRfid = Convert.ToInt32(sCapAging[3]);
                    }
                    catch { }
                }
                if (kvagvTypeInfo != null)
                {
                    try
                    {
                        string[] sAgvTypeInfo = kvagvTypeInfo.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < sAgvTypeInfo.Length; i++)
                        {
                            string[] sSplitAgvTypeInfo = sAgvTypeInfo[i].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            int type = Convert.ToInt32(sSplitAgvTypeInfo[0]);
                            Common.Instance.dtAgvTypeInfo[(Enumerations.agvType)type] = new AgvTypeInfo((Enumerations.agvType)type, Convert.ToBoolean(sSplitAgvTypeInfo[1]), Convert.ToInt32(sSplitAgvTypeInfo[2]));
                        }
                    }
                    catch { }
                }
                if (kvinsertCount != null)
                {
                    try
                    {
                        string[] insertCounts = kvinsertCount.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.insertCount[0] = Convert.ToInt32(insertCounts[0]);
                        Common.insertCount[1] = Convert.ToInt32(insertCounts[1]);
                    }
                    catch { }
                }
                if (kvcapTestOperate != null)
                {
                    try
                    {
                        string[] op = kvcapTestOperate.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftLoad] = Convert.ToInt32(op[0]);
                        Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightLoad] = Convert.ToInt32(op[1]);
                        Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftUnload] = Convert.ToInt32(op[2]);
                        Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightUnload] = Convert.ToInt32(op[3]);
                        Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftRefueling] = Convert.ToInt32(op[4]);
                        Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightRefueling] = Convert.ToInt32(op[5]);
                    }
                    catch { }
                }
                if (kvsubStayTime != null)
                {
                    try
                    {
                        Common.subStayTime = Convert.ToInt32(kvsubStayTime.value.ToString());
                    }
                    catch { }
                }
                if (kvreceiveMesTask != null)
                {
                    try
                    {
                        string[] s = kvreceiveMesTask.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.Instance.isReceiveOpcTask = Convert.ToBoolean(s[0]);
                        Common.Instance.isReceiveQRCode = Convert.ToBoolean(s[1]);
                    }
                    catch { }
                }
                if (kvlineTime != null)
                {
                    try
                    {
                        string[] s = kvlineTime.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.Instance.AgvLineTime = Convert.ToInt32(s[0]);
                        Common.Instance.AgvClearLineTime = Convert.ToInt32(s[1]);
                    }
                    catch { }
                }
                if (kvchargeVoltageCount != null)
                {
                    try
                    {
                        Common.Instance.chargeVoltageCount = Convert.ToInt32(kvchargeVoltageCount.value.ToString());
                    }
                    catch { }
                }
                if (kvisSaveRoute != null)
                {
                    try
                    {
                        Common.isSaveRoute = Convert.ToBoolean(kvisSaveRoute.value.ToString());
                    }
                    catch { }
                }
                if (kvopcParameter != null)
                {
                    try
                    {
                        string[] ss = kvopcParameter.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in ss)
                        {
                            try
                            {
                                string[] s1 = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                string _pName = s1[0];
                                string _plcName = s1[1];
                                int _handle = int.Parse(s1[2]);
                                OPCClient.dtOpcToPlc[_plcName] = new OPCItemParameter(_pName, _plcName, _handle, -1);
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
                if (kvbufferGroup != null)
                {
                    try
                    {
                        Common.bufferGroup = Convert.ToInt32(kvbufferGroup.value.ToString());
                    }
                    catch { }
                }
                if (kvloopCharge != null)
                {
                    try
                    {
                        Common.isLoopCharge = Convert.ToBoolean(kvloopCharge.value.ToString());
                    }
                    catch { }
                }
                if (kvshowRfids != null)
                {
                    try
                    {
                        string[] sshowRfids = kvshowRfids.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (sshowRfids.Length > 0)
                        {
                            foreach (string item in sshowRfids)
                            {
                                try
                                {
                                    string[] srfid = item.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (srfid.Length == 2)
                                    {
                                        int key = Convert.ToInt32(srfid[0]);
                                        int value = Convert.ToInt32(srfid[1]);
                                        Common.bufferShowRfidDt[key] = value;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }
                }
                if (kvagvLimited != null)
                {
                    try
                    {
                        string[] agvLimiteds = kvagvLimited.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (agvLimiteds.Length > 0)
                        {
                            foreach (string item in agvLimiteds)
                            {
                                try
                                {
                                    string[] sagvLimited = item.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (sagvLimited.Length > 1)
                                    {
                                        int key = Convert.ToInt32(sagvLimited[0]);
                                        if (Common.Instance.dtAgvLimited.ContainsKey(key) == false) Common.Instance.dtAgvLimited[key] = new List<int>();
                                        for (int i = 1; i < sagvLimited.Length; i++)
                                        {
                                            Common.Instance.dtAgvLimited[key].Add(Convert.ToInt32(sagvLimited[i]));
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }
                }
                if (kvisDynPwd != null)
                {
                    try
                    {
                        Common.isDynPwd = Convert.ToBoolean(kvisDynPwd.value.ToString());
                    }
                    catch { }
                }
                if (kvrfidType != null)
                {
                    try
                    {
                        RfidInfo.pRfidType = (RfidType)(Convert.ToInt32(kvrfidType.value));
                    }
                    catch { }
                }
                if (kvopcConnect != null)
                {
                    try
                    {
                        string[] _opcString = kvopcConnect.value.ToString().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        OPCClient.opcInformation.Ip = _opcString[0].Trim();
                        OPCClient.opcInformation.HostName = _opcString[1].Trim();
                    }
                    catch { }
                }
                if (kvpanMapSplit != null)
                {
                    try
                    {
                        string[] _panMapSplitString = kvpanMapSplit.value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.splitMap.X = int.Parse(_panMapSplitString[0]);
                        Common.splitMap.Y = int.Parse(_panMapSplitString[1]);
                    }
                    catch { }
                }
                if (kvchargeTime != null)
                {
                    try
                    {
                        Common.Instance.chargeTime = int.Parse(kvchargeTime.value.ToString());
                    }
                    catch { }
                }
                if (kvstandbyChargeTime != null)
                {
                    try
                    {
                        Common.Instance.standbyChargeTime = int.Parse(kvstandbyChargeTime.value.ToString());
                    }
                    catch { }
                }
            }
            #endregion //读取设定初始参数
        }
        /// <summary>
        /// 保存参数至xml
        /// </summary>
        public static void ParametersSave(bool isAllSave)
        {
            #region 保存参数
            lock (Common.lsXmlPParameter)
            {
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.sqlAddress);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.sqlAddress, Common.sqlCommInfo.Address));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.sqlDatabase);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.sqlDatabase, Common.sqlCommInfo.Database));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.sqlUserName);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.sqlUserName, Common.sqlCommInfo.Name));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.sqlUserPwd);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.sqlUserPwd, Common.sqlCommInfo.Passward));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.dataSaveType);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.dataSaveType, Common.dataSaveType.ToString()));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvLightX);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvLightX, Common.tlpPoint.X.ToString()));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvLightY);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvLightY, Common.tlpPoint.Y.ToString()));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvLightColCount);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvLightColCount, Common.agvstatusLayout.X.ToString()));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvLightRowCount);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvLightRowCount, Common.agvstatusLayout.Y.ToString()));
                string lineName = "";
                foreach (string item in Common.lineNameDt.Keys)
                {
                    lineName += item + "|" + Common.lineNameDt[item] + ",";
                }
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.lineName);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.lineName, lineName));
                string positionName = string.Empty;
                foreach (string item in Common.pNameDt.Keys)
                {
                    positionName += item + "|" + Common.pNameDt[item] + ",";
                }
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.positionName);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.positionName, positionName));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.stationTime);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.stationTime, Common.stationTime.ToString()));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvModelScale);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvModelScale, Common.agvModelScale.ToString()));
                string controlStr = string.Empty;
                string controlAgvStr = string.Empty;
                try
                {
                    foreach (int item in Common.controlPointsDict.Keys)
                    {
                        string pointstr = item.ToString() + ",";
                        pointstr += string.Join(",", Common.controlPointsDict[item]);
                        controlStr += pointstr + "_";

                        string pagvstr = item.ToString() + ",";
                        pagvstr += string.Join(",", Common.controlPointAgvList[item]);
                        controlAgvStr += pagvstr + "_";
                    }
                }
                catch { }
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvControlPoints);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvControlPoints, controlStr));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.controlAgvs);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.controlAgvs, controlAgvStr));
                try
                {
                    string mapStr = string.Empty;
                    foreach (int item in Common.mapInfo.Keys)
                    {
                        mapStr += item.ToString() + "|" + Common.mapInfo[item].ToString() + ",";
                    }

                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.mapCount);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.mapCount, mapStr));
                }
                catch { }
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.mapChange);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.mapChange, Common.isMapChange.ToString()));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.mapChangeTime);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.mapChangeTime, Common.mapChangeTime.ToString()));
                string strLimitedCharge = string.Empty;
                strLimitedCharge = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6},", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedLow, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedCharge, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedEnable, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimiteLowTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].FullTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].ChargeVoltage);
                strLimitedCharge += string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6},", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedLow, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedCharge, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedEnable, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimiteLowTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].FullTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].ChargeVoltage);
                strLimitedCharge += string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6},", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedLow, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedCharge, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedEnable, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimiteLowTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].FullTime, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].ChargeVoltage);
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.chargeLimitedInfo);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.chargeLimitedInfo, strLimitedCharge));
                string chargeVoltages = string.Empty;
                try
                {
                    List<int> cvLs = ChargeLimitedInfo.dtAgvChargeVoltage.Keys.ToList();
                    foreach (int item in cvLs)
                    {
                        chargeVoltages += string.Format("{0}_{1},", item, ChargeLimitedInfo.dtAgvChargeVoltage[item]);
                    }
                }
                catch { }
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.chargeVoltage);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.chargeVoltage, chargeVoltages));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.layoutHeightSplitStatus);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.layoutHeightSplitStatus, Common.splitStatusHeight.ToString()));
                //Agv类型
                string type1 = "1,";
                string type2 = "2,";
                foreach (int item in Common.Instance.agvType.Keys)
                {
                    if (Common.Instance.agvType[item] == Enumerations.agvType.type_1)
                    {
                        type1 += item.ToString() + ",";
                    }
                    else
                    {
                        type2 += item.ToString() + ",";
                    }
                }
                string type = string.Format("{0}_{1}", type1, type2);
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvType);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvType, type));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.repeatRfid);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.repeatRfid, string.Join(",", Common.Instance.RepeatRfids)));
                string stationStr = string.Empty;
                try
                {
                    foreach (int item in Common.Instance.dtStationTransform.Keys)
                    {
                        stationStr += string.Format("{0}_{1},", item, Common.Instance.dtStationTransform[item]);
                    }
                }
                catch { }
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.stations);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.stations, stationStr));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.sizeStatin);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.sizeStatin, string.Format("{0},{1}", Common.sizeStationDefault.X, Common.sizeStationDefault.Y)));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.passEnablePlc);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.passEnablePlc, Common.Instance.passEnable.ToString()));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.testStationNo);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.testStationNo, Common.Instance.dtRoutePass[RouteType.CapacityLoad].TestStationNo + "," + Common.Instance.dtRoutePass[RouteType.CapacityUnload].TestStationNo));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.mesCT);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.mesCT, string.Format("{0},{1},{2}", Common.Instance.mesConnectTime.GetTaskTime, Common.Instance.mesConnectTime.UpdateAgvStateTime, Common.Instance.mesConnectTime.UpdateTaskTime)));
                Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.taskIndex);
                Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.taskIndex, Common.Instance.taskIndex.ToString()));
                try
                {
                    string capacityTestWaitString = string.Empty;
                    foreach (CapacityTestWaitInfo item in Common.Instance.dtCapacityTestWait.Values)
                    {
                        string stationsStr = string.Empty;
                        foreach (point p in item.lsStations)
                        {
                            stationsStr += string.Format("{0}_{1},", p.X, p.Y);
                        }
                        string rfidsStr = string.Empty;
                        foreach (point p in item.lsRfids)
                        {
                            rfidsStr += string.Format("{0}_{1},", p.X, p.Y);
                        }
                        capacityTestWaitString += string.Format("{0}|{1}|{2}|{3}&", item.Number, item.Rfid, stationsStr, rfidsStr);
                    }
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.capacityTestWait);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.capacityTestWait, capacityTestWaitString));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.splitTask);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.splitTask, string.Format("{0},{1}", Common.splitTask.X, Common.splitTask.Y)));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agingRoom);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agingRoom, string.Format("{0}_{1}_{2}_{3},{4}_{5}_{6}_{7}", Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].LoadRfid, Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].StaticArea1Rfid, Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].StaticArea2Rfid, Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].UnloadRfid, Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].LoadRfid, Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea1Rfid, Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea2Rfid, Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].UnloadRfid)));
                    try
                    {
                        string sAgvTypeInfo = string.Empty;
                        foreach (var item in Common.Instance.dtAgvTypeInfo.Values)
                        {
                            sAgvTypeInfo += string.Format("{0}_{1}_{2},", ((int)item.Type).ToString(), item.TaskRefreshEnable.ToString(), item.TaskRefreshTime.ToString());
                        }
                        Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvTypeInfo);
                        Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvTypeInfo, sAgvTypeInfo));
                    }
                    catch { }
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.insertCount);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.insertCount, string.Format("{0},{1}", Common.insertCount[0], Common.insertCount[1])));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.capTeatOperate);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.capTeatOperate, string.Format("{0},{1},{2},{3},{4},{5}", Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftLoad], Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightLoad], Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftUnload], Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightUnload], Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftRefueling], Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightRefueling])));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.subStayTime);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.subStayTime, Common.subStayTime.ToString()));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.receiveMesTask);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.receiveMesTask, string.Format("{0},{1}", Common.Instance.isReceiveOpcTask.ToString(), Common.Instance.isReceiveQRCode.ToString())));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.lineTime);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.lineTime, string.Format("{0},{1}", Common.Instance.AgvLineTime, Common.Instance.AgvClearLineTime)));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.chargeVoltageCount);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.chargeVoltageCount, Common.Instance.chargeVoltageCount.ToString()));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.isSaveRoute);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.isSaveRoute, Common.isSaveRoute.ToString()));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.bufferGroup);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.bufferGroup, Common.bufferGroup.ToString()));
                    string _opcString = string.Empty;
                    try
                    {
                        foreach (OPCItemParameter item in OPCClient.dtOpcToPlc.Values)
                        {
                            _opcString += string.Format("{0}|{1}|{2},", item.ParameterName, item.PLCName, item.ItemHandle);
                        }
                    }
                    catch { }
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.OpcParameters);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.OpcParameters, _opcString));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.loopCharge);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.loopCharge, Common.isLoopCharge.ToString()));
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.loopCharge, Common.isDynPwd.ToString()));
                    string sshowRfids = string.Empty;
                    try
                    {
                        int[] keys = Common.maiDict.Keys.ToArray();
                        foreach (int item in keys)
                        {
                            sshowRfids += string.Format("{0}_{1},", item, Common.maiDict[item].ShowRfid);
                        }
                    }
                    catch { }
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.showRfids);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.showRfids, sshowRfids));
                    string sagvLimited = string.Empty;
                    try
                    {
                        int[] keys = Common.Instance.dtAgvLimited.Keys.ToArray();
                        foreach (int item in keys)
                        {
                            if (Common.Instance.dtAgvLimited[item].Count > 0)
                                sagvLimited += string.Format("{0}_{1},", item, string.Join("_", Common.Instance.dtAgvLimited[item]));
                        }
                    }
                    catch { }
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.agvLimited);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.agvLimited, sagvLimited));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.rfidType);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.rfidType, ((int)RfidInfo.pRfidType).ToString()));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.opcConnect);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.opcConnect, OPCClient.opcInformation.Ip + "_" + OPCClient.opcInformation.HostName));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.panMapSplit);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.panMapSplit, Common.splitMap.X.ToString() + "," + Common.splitMap.Y.ToString()));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.chargeTime);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.chargeTime, Common.Instance.chargeTime.ToString()));
                    Common.lsXmlPParameter.RemoveAll(s => (int)s.key == (int)ParameterList.standbyChargeTime);
                    Common.lsXmlPParameter.Add(new KeyValue((int)ParameterList.standbyChargeTime, Common.Instance.standbyChargeTime.ToString()));
                    BA_XmlOperate.ParameterSave(Common.lsXmlPParameter);
                }
                catch { }
            }
            try
            {
                if (isAllSave)
                    BA_XmlOperate.AgvRfidPointSave(Common.rfidDt.Values.ToList());
            }
            catch { }
            try
            {
                if (isAllSave)
                    BA_XmlOperate.StationLabelInfoSave(Common.dtStationInfo.Values.ToList());
            }
            catch { }
            try
            {
                if (isAllSave)
                    BA_XmlOperate.DoorInfoSave(Common.Instance.dtDoorInfo.Values.ToList());
            }
            catch { }
            try
            {
                if (isAllSave)
                    BA_XmlOperate.ElevatorInfoSave(Common.Instance.dtElevatorInfo.Values.ToList());
            }
            catch { };
            try
            {
                if (isAllSave)
                    BA_XmlOperate.ChargeInfoSave(Common.Instance.dtChargeInfo.Values.ToList());
            }
            catch { }
            try
            {
                if (isAllSave)
                    BA_XmlOperate.StationInfoSave(Common.Instance.dtStationInformation.Values.ToList());
            }
            catch { }
            try
            {
                if (isAllSave)
                    BA_XmlOperate.DetectorInfoSave(Common.Instance.dtBatteryCapcityDetector.Values.ToList());
            }
            catch { }
            try
            {
                List<MA_AgvTaskInfo> lsTask = new List<MA_AgvTaskInfo>();
                if (Common.taskDt[(int)Enumerations.agvType.type_1].Count > 0) lsTask.AddRange(Common.taskDt[(int)Enumerations.agvType.type_1].Values);
                if (Common.taskDt[(int)Enumerations.agvType.type_2].Count > 0) lsTask.AddRange(Common.taskDt[(int)Enumerations.agvType.type_2].Values);
                if (Common.taskDt[(int)Enumerations.agvType.type_3].Count > 0) lsTask.AddRange(Common.taskDt[(int)Enumerations.agvType.type_3].Values);
                BA_XmlOperate.TaskInfoSave(lsTask);
            }
            catch { }
            #endregion
        }
        public static void LoopSave()
        {
            while (true)
            {
                ParametersSave(false);
                Thread.Sleep(3000);
            }
        }
        /// <summary>
        /// Xml保存的参数
        /// </summary>
        public enum ParameterList
        {
            /// <summary>
            /// 预留，类型
            /// </summary>
            type = 0,
            /// <summary>
            /// 数据库地址
            /// </summary>
            sqlAddress = 1,
            /// <summary>
            /// 数据库登录用户名
            /// </summary>
            sqlUserName = 2,
            /// <summary>
            /// 数据库登录密码
            /// </summary>
            sqlUserPwd = 3,
            /// <summary>
            /// 数据库库名
            /// </summary>
            sqlDatabase = 4,
            /// <summary>
            /// agv状态灯X轴坐标
            /// </summary>
            agvLightX = 5,
            /// <summary>
            /// agv状态灯Y轴坐标
            /// </summary>
            agvLightY = 6,
            /// <summary>
            /// agv状态灯行数
            /// </summary>
            agvLightRowCount = 7,
            /// <summary>
            /// agv状态灯列数
            /// </summary>
            agvLightColCount = 8,
            /// <summary>
            /// 数据保存类型 SQL SERVER,SqlLite
            /// </summary>
            dataSaveType = 9,
            /// <summary>
            /// 路线对应名称保存
            /// </summary>
            lineName = 10,
            /// <summary>
            /// 地标卡对应名称
            /// </summary>
            positionName = 11,
            /// <summary>
            /// 点位定位时间长度
            /// </summary>
            stationTime = 12,
            /// <summary>
            /// AGV模型比例
            /// </summary>
            agvModelScale = 13,
            /// <summary>
            /// Agv管制点
            /// </summary>
            agvControlPoints = 14,
            /// <summary>
            /// 电子地图信息
            /// </summary>
            mapCount = 15,
            /// <summary>
            /// 电子地图自动切换
            /// </summary>
            mapChange = 16,
            /// <summary>
            /// 电子地图自动切换时间
            /// </summary>
            mapChangeTime = 17,
            /// <summary>
            /// 充电阀值信息
            /// </summary>
            chargeLimitedInfo = 18,
            /// <summary>
            /// 当前任务布局高度
            /// </summary>
            layoutHeightSplitStatus = 19,
            /// <summary>
            /// Agv使用类型
            /// </summary>
            agvType = 20,
            /// <summary>
            /// 管制排除点
            /// </summary>
            repeatRfid = 22,
            /// <summary>
            /// 站点匹配
            /// </summary>
            stations = 23,
            /// <summary>
            /// 三菱PLC通讯参数
            /// </summary>
            mitsubishiPlc = 24,
            /// <summary>
            /// 站点初始尺寸
            /// </summary>
            sizeStatin = 25,
            /// <summary>
            /// 放行使能
            /// </summary>
            passEnablePlc = 26,
            /// <summary>
            /// 任务测试工位编号（上料，下料）
            /// </summary>
            testStationNo = 27,
            /// <summary>
            /// mes信息刷新时间
            /// </summary>
            mesCT = 28,
            /// <summary>
            /// 任务编号存储
            /// </summary>
            taskIndex = 29,
            /// <summary>
            /// 分容测试agv待机位
            /// </summary>
            capacityTestWait = 30,
            /// <summary>
            /// 任务拆分器参数
            /// </summary>
            splitTask = 31,
            /// <summary>
            /// 老化房参数
            /// </summary>
            agingRoom = 32,
            /// <summary>
            /// agv类型信息
            /// </summary>
            agvTypeInfo = 33,
            /// <summary>
            /// 插入任务 、异常数量
            /// </summary>
            insertCount = 34,
            /// <summary>
            /// 分容柜站点 操作
            /// </summary>
            capTeatOperate = 35,
            /// <summary>
            /// 管制agv集合
            /// </summary>
            controlAgvs = 36,
            /// <summary>
            /// 分容柜停留时间
            /// </summary>
            subStayTime = 37,
            /// <summary>
            /// 充电电压
            /// </summary>
            chargeVoltage = 38,
            /// <summary>
            /// 是否接收mes任务
            /// </summary>
            receiveMesTask = 39,
            /// <summary>
            /// 掉线时长
            /// </summary>
            lineTime = 40,
            /// <summary>
            /// 充电判断计数
            /// </summary>
            chargeVoltageCount = 41,
            /// <summary>
            /// 是否保存写入agv路段
            /// </summary>
            isSaveRoute = 42,
            /// <summary>
            /// 机械臂状态参数对应
            /// </summary>
            OpcParameters = 43,
            /// <summary>
            /// 空车离开mes任务缓冲通道
            /// </summary>
            bufferGroup = 44,
            /// <summary>
            /// 循环充电记录
            /// </summary>
            loopCharge = 45,
            /// <summary>
            /// 展示RFID记录
            /// </summary>
            showRfids = 46,
            /// <summary>
            /// 上下料区AGV限定
            /// </summary>
            agvLimited = 47,
            /// <summary>
            /// 是否可以使用动态密码
            /// </summary>
            isDynPwd = 48,
            /// <summary>
            /// rfid类型
            /// </summary>
            rfidType = 49,
            /// <summary>
            /// opc通讯的ip地址，主机名称
            /// </summary>
            opcConnect = 50,
            /// <summary>
            /// 电子地图拆分器
            /// </summary>
            panMapSplit = 51,
            /// <summary>
            /// 充电时长
            /// </summary>
            chargeTime = 52,
            /// <summary>
            /// 待机模式下充电时长
            /// </summary>
            standbyChargeTime =53,
        };
    }
}
