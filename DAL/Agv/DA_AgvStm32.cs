using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class DA_AgvStm32 : AgvConnect
    {

        #region Perproties
        private bool isWaitTime = false;
        /// <summary>
        /// agv通讯参数
        /// </summary>
        private MA_AgvComInfo AgvComm;
        /// <summary>
        /// stm32通讯接口
        /// </summary>
        private UdpClient stm32Udp;
        /// <summary>
        /// 通讯最大重链次数
        /// </summary>
        private int lineTime = 20;
        /// <summary>
        /// Line Clear Time
        /// </summary>
        private int lineClearTime = 240;
        /// <summary>
        /// stm32的读取长度
        /// </summary>
        private int dataLength = 23;
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
        /// <summary>
        /// 读取数据缓存
        /// </summary>
        private List<byte> recDataBuffer = new List<byte>();
        ///// <summary>
        ///// 请求返回数据报文
        ///// </summary>
        //private byte[] recQueryData;
        /// <summary>
        /// agv网络端点
        /// </summary>
        private IPEndPoint agvPoint;
        /// <summary>
        /// 接收到数据的网络端点
        /// </summary>
        private IPEndPoint recPoint;
        ///// <summary>
        ///// 发送的数据格式
        ///// </summary>
        //private byte[] sendData = new byte[] { 0xfc, 0x13, 0x00, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff, 0x00, 0x00, 0x00 };
        /// <summary>
        /// 充电时间
        /// </summary>
        private DateTime chargeTime = new DateTime();
        /// <summary>
        /// 最近一次获取的二维码信息
        /// </summary>
        private string lastQRCode = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private DateTime lastRecDataTime = DateTime.Now;
        /// <summary>
        /// 第一次通讯判断，用于判断是否将电压置为低电压
        /// </summary>
        private bool StartJudge = false;
        #endregion

        /// <summary>
        /// 初始化，写入AGV通讯配置
        /// </summary>
        /// <param name="_agvComm"></param>
        public DA_AgvStm32(MA_AgvComInfo _agvComm)
        {
            this.AgvComm = _agvComm;
            //this.recQueryData = new byte[] { 0xfd, 0x00, Convert.ToByte(this.AgvComm.A_Id), 0x00, 0x00, 0x00, 0xff };
            this.stm32Udp = new UdpClient(this.AgvComm.A_LocalPort);
            this.agvPoint = new IPEndPoint(IPAddress.Parse(this.AgvComm.A_IpAddress), this.AgvComm.A_DesPort);
            //this.sendData[3] = Convert.ToByte(this.AgvComm.A_Id);

        }
        /// <summary>
        /// 读取AGV数据
        /// </summary>
        /// <param name="agvInfo">agv信息</param>
        public bool ReadData(ref M_AgvInfo agvInfo)
        {
            bool isReadOk = false;
            try
            {
                if (Common.maiDict[this.AgvComm.A_Id].Type == Enumerations.agvType.type_1) this.dataLength = 31;//若为分容测试AGV，多4个字节，为二维码数据
                //List<int> lsAgvs = new List<int>(new int[] { 3, 10, 11, 15, 17, 18, 19, 21, 23, 24, 30, 31, 32, 33, 36, 37, 42, 44, 46, 49, 50, 53 });
                //if (lsAgvs.Contains(this.AgvComm.A_Id)) this.dataLength = 31;
                //this.dataLength = 31;
                int rfid = 0;
                if (agvInfo.Rfid > 0)
                {
                    rfid = agvInfo.Rfid;
                }
                byte[] sendData = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.query, 9, new byte[] { Convert.ToByte(rfid / 256), Convert.ToByte(rfid % 256) });

                this.stm32Udp.Send(sendData, sendData.Length, this.agvPoint);
                string ss = string.Empty;
                foreach (byte item in sendData)
                {
                    ss += item.ToString("X2") + " ";
                }
                Thread.Sleep(50);                
                #region 读取方式2
                //byte[] data__ = this.stm32Udp.Receive(ref this.recPoint);
                if (this.stm32Udp.Available > 0)
                {
                    //byte[] data = new byte[this.stm32Udp.Available];
                    //data = this.stm32Udp.Receive(ref this.recPoint);
                    //if (this.recDataBuffer.Count > 1000)
                    //{
                    //    this.recDataBuffer.Clear();
                    //}
                    //if (this.recPoint.Address.ToString() == this.AgvComm.A_IpAddress)
                    //{
                    //    this.recDataBuffer.AddRange(data);
                    //}
                    //if (this.recDataBuffer.Count > 1000)
                    //{
                    this.recDataBuffer.Clear();
                    //}
                    while (this.stm32Udp.Available > 0)
                    {
                        byte[] data = this.stm32Udp.Receive(ref this.recPoint);
                        this.recDataBuffer.AddRange(data);
                        Thread.Sleep(10);
                    }
                    if (recDataBuffer.Count >= this.dataLength)
                    {//数据判断解析，若正确则返回ture,错误则返回false  判断是要进行校验比对    
                        #region 打印信息
                        if (Common.printAgvNo == agvInfo.AgvNo)
                        {
                            try
                            {
                                List<string> ls = this.recDataBuffer.ConvertAll<string>(x => x.ToString("X2"));
                                Debug.Print(string.Format("{0}   {1}", string.Join(",", ls), agvInfo.AgvNo));
                            }
                            catch { }
                        }
                        #endregion
                        List<byte> _resultData = new List<byte>();
                        int d0xfc = -1;
                        while (this.recDataBuffer.Count > this.dataLength * 2)
                        {
                            this.recDataBuffer.RemoveRange(0, this.recDataBuffer.Count - this.dataLength * 2);
                        }
                        for (int i = 0; i < this.recDataBuffer.Count; i++)
                        {
                            if (this.recDataBuffer[i] == 0xfc && i <= this.recDataBuffer.Count - this.dataLength)
                            {
                                if (this.recDataBuffer[i + this.dataLength - 1] == 0x5a && this.recDataBuffer[i + 1] == this.dataLength)
                                {
                                    d0xfc = i;
                                }
                            }
                        }
                        if (d0xfc >= 0)
                        {
                            if (this.recDataBuffer[d0xfc + 4] * 256 + this.recDataBuffer[d0xfc + 5] == this.AgvComm.A_Id)
                            {
                                for (int j = d0xfc; j < d0xfc + this.dataLength; j++)
                                {
                                    _resultData.Add(this.recDataBuffer[j]);
                                }
                                this.recDataBuffer.RemoveRange(0, d0xfc + this.dataLength);
                            }
                            else
                            {
                                this.recDataBuffer.RemoveRange(0, d0xfc);
                            }
                        }
                        //else if (d0xfd != -1)
                        //{
                        //    try
                        //    {
                        //        this.recDataBuffer.RemoveRange(0, d0xfd - this.dataLength);
                        //        d0xfd = this.recDataBuffer.IndexOf(0xfd);
                        //        if (this.recDataBuffer[d0xfd + 3] == this.AgvComm.A_Id && this.recDataBuffer[d0xfd + 1] == this.dataLength) //&& this.recDataBuffer[d0xfd + 2] == 0xff
                        //        {
                        //            for (int j = d0xfd; j < d0xfd + this.dataLength; j++)
                        //            {
                        //                resultData.Add(this.recDataBuffer[j]);
                        //            }
                        //            this.recDataBuffer.RemoveRange(0, d0xfd + this.dataLength);
                        //        }
                        //        else
                        //        {
                        //            this.recDataBuffer.RemoveRange(0, d0xfd);
                        //        }
                        //    }
                        //    catch { }
                        //}                        

                        if (_resultData.Count == this.dataLength)  //读取正确
                        {
                            if (CRCRecData(_resultData.ToArray()))
                            {
                                byte[] recData = new byte[_resultData.Count - 10];
                                for (int i = 0; i < recData.Length; i++)
                                {
                                    recData[i] = _resultData[i + 7];
                                }
                                if (recData[0] > 0 || recData[1] > 0)
                                {
                                    agvInfo.Rfid = (int)(recData[0] * 256 + recData[1]);
                                    agvInfo.ShowRfid = agvInfo.Rfid;
                                }
                                else
                                {
                                    lock (LogFile.objLog)
                                        LogFile.SaveLog("agv" + agvInfo.AgvNo + ": Rfid " + agvInfo.Rfid + " error " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                agvInfo.Obstacle = (recData[8] & 1) == 0 ? false : true;
                                agvInfo.StationStopState = (recData[8] >> 1 & 1) == 0 ? false : true;
                                agvInfo.Mode = (recData[8] >> 2 & 1) == 0 ? 1 : 0;
                                agvInfo.OperateState = (recData[8] >> 3 & 1) == 0 ? false : true;
                                agvInfo.ChargeState = (recData[8] >> 4 & 1) == 0 ? false : true;
                                agvInfo.SupportState = (recData[8] >> 5 & 1) == 0 ? false : true;
                                if (recData[3] == 0) //异常信息
                                {
                                    //if (recData[8] == 0)//障碍异常
                                    //{
                                    if (recData[2] == 1)
                                    {
                                        agvInfo.State = (int)Enumerations.AgvStatus.running;
                                    }
                                    else if (recData[2] == 2)
                                    {
                                        agvInfo.State = (int)Enumerations.AgvStatus.stop;
                                    }
                                    //}
                                    //else
                                    //{
                                    //    agvInfo.Status = (int)Enumerations.AgvStatus.obstacle;
                                    //}
                                }
                                else
                                {
                                    agvInfo.State = (int)Enumerations.AgvStatus.abnormal;
                                    agvInfo.Abnormal = (int)recData[3];
                                }
                                agvInfo.Voltage = recData[4] * 256 + recData[5];//电压值
                                #region 电压阀值判断
                                this.voltageLimitedMaxNumber = Common.Instance.chargeVoltageCount;
                                int chargeVoltage = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedCharge;
                                if (ChargeLimitedInfo.dtAgvChargeVoltage.ContainsKey(agvInfo.AgvNo))
                                {
                                    if (ChargeLimitedInfo.dtAgvChargeVoltage[agvInfo.AgvNo] > 0)
                                    {
                                        chargeVoltage = Convert.ToInt32(ChargeLimitedInfo.dtAgvChargeVoltage[agvInfo.AgvNo] * 10);
                                    }
                                }
                                int rfid_ = agvInfo.Rfid;
                                int agvNo_ = agvInfo.AgvNo;
                                if (agvInfo.VoltageStatus != Enumerations.voltageStatus.lowVoltage)
                                {
                                    if (agvInfo.Voltage <= chargeVoltage)
                                    {
                                        if (agvInfo.Voltage <= Common.Instance.dtChargeLimitedInfo[agvInfo.Type].LimitedLow)
                                        {
                                            try
                                            {
                                                this.voltgeLowStopCount++;
                                                if (this.voltgeLowStopCount > this.voltageLimitedMaxNumber)
                                                {
                                                    agvInfo.VoltageStatus = Enumerations.voltageStatus.lowVoltage;
                                                    agvInfo.IsChargeFullTime = false;
                                                    this.voltgeLowStopCount = 0;
                                                }
                                            }
                                            catch { }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                this.voltgeLowStopCount++;
                                                if (this.voltgeLowStopCount > this.voltageLimitedMaxNumber)
                                                {
                                                    agvInfo.VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                                                    agvInfo.IsChargeFullTime = false;
                                                    this.voltgeLowStopCount = 0;
                                                }
                                            }
                                            catch { }
                                        }
                                    }
                                    else if (!Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == rfid_) && agvInfo.VoltageStatus == Enumerations.voltageStatus.normal)
                                    {
                                        agvInfo.VoltageStatus = Enumerations.voltageStatus.normal;
                                        this.voltgeLowStopCount = 0;
                                    }
                                }
                                else //以防把电池从AGV抽出外面充电
                                {
                                    if (agvInfo.Voltage > (chargeVoltage + 20) && !Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == rfid_))
                                    {//+20是为了防止电压回弹比较高
                                        try
                                        {
                                            this.voltgeLowStopCount++;
                                            if (this.voltgeLowStopCount > this.voltageLimitedMaxNumber + 50)
                                            {
                                                agvInfo.VoltageStatus = Enumerations.voltageStatus.normal;
                                                this.voltgeLowStopCount = 0;
                                            }
                                        }
                                        catch { }
                                    }
                                    else if (agvInfo.Voltage > Common.Instance.dtChargeLimitedInfo[agvInfo.Type].LimitedLow && !Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == rfid_))
                                    {
                                        try
                                        {
                                            this.voltgeLowStopCount++;
                                            if (this.voltgeLowStopCount > this.voltageLimitedMaxNumber)
                                            {
                                                agvInfo.VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                                                agvInfo.IsChargeFullTime = false;
                                                this.voltgeLowStopCount = 0;
                                            }
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        agvInfo.VoltageStatus = Enumerations.voltageStatus.lowVoltage;
                                        agvInfo.IsChargeFullTime = false;
                                        this.voltgeLowStopCount = 0;
                                    }
                                }
                                //agvInfo.VoltageStatus = Enumerations.voltageStatus.normal;
                                if (StartJudge == false)
                                {
                                    if (Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == rfid_) && agvInfo.State == (int)Enumerations.AgvStatus.stop && agvInfo.Task1 == string.Empty && agvInfo.Task2 == string.Empty)
                                    {
                                        agvInfo.VoltageStatus = Enumerations.voltageStatus.lowVoltage;
                                        agvInfo.IsChargeFullTime = false;
                                    }
                                    StartJudge = true;
                                }
                                if (Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == rfid) && agvInfo.Voltage <= Common.Instance.dtChargeLimitedInfo[agvInfo.Type].ChargeVoltage && agvInfo.VoltageStatus == Enumerations.voltageStatus.normal && agvInfo.Task1 == string.Empty && agvInfo.Task2 == string.Empty)  //在充电桩内，若电压低于某个值，则需要充电
                                {
                                    agvInfo.VoltageStatus = Enumerations.voltageStatus.lowVoltage;
                                    agvInfo.IsChargeFullTime = false;
                                }
                                #endregion
                                #region 充电完成判断  弃用
                                //int crfid = agvInfo.Rfid;
                                //int cagvNo = agvInfo.AgvNo;
                                //if (Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == crfid && o.Value.BindAgv == cagvNo)) //在充电区
                                //{
                                //    int chargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Rfid == crfid && o.Value.BindAgv == cagvNo).Key;
                                //    if (agvInfo.VoltageStatus == Enumerations.voltageStatus.lowVoltage)
                                //    {
                                //        if (agvInfo.Voltage >= Common.Instance.dtChargeLimitedInfo[agvInfo.Type].LimitedEnable)  //电压大于判断阀值
                                //        {
                                //            agvInfo.VoltageStatus = Enumerations.voltageStatus.normal;
                                //            this.chargeTime = new DateTime();
                                //        }
                                //        if (this.chargeTime == new DateTime())
                                //        {   
                                //            this.chargeTime = DateTime.Now;
                                //        }
                                //        else
                                //        {
                                //            if (DateTime.Now.Subtract(Common.Instance.dtChargeInfo[chargeNo].BeginTime).TotalSeconds >= Common.Instance.dtChargeLimitedInfo[agvInfo.Type].LimitedTime)
                                //            {  //超过一定的充电时间，则也判断为充电完成
                                //                agvInfo.VoltageStatus = Enumerations.voltageStatus.normal;
                                //                Common.Instance.dtChargeInfo[chargeNo].BeginTime = new DateTime();
                                //            }
                                //        }
                                //    }
                                //}
                                #endregion
                                agvInfo.Default1 = recData[6] * 256 + recData[7];//任务号
                                //agvInfo.ControlFlag = (recData[9] & 1) == 1 ? true : false;  //交通管制
                                agvInfo.Direction = (int)recData[10];
                                #region 控制rfid判断添加  弃用
                                //if (Common.Instance.RepeatRfids.Contains(agvInfo.Rfid) == false)  //判断是否为管制范围
                                //{
                                //    //if (agvInfo.ControlFlag == false)
                                //    //{
                                //    if (agvInfo.ControlRfid > 1000)
                                //    {
                                //        if ((agvInfo.ControlRfid - 1000) != agvInfo.Rfid)
                                //        {
                                //            agvInfo.ControlRfid = agvInfo.Rfid;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        agvInfo.ControlRfid = agvInfo.Rfid;
                                //    }
                                //    //}
                                //    if (agvInfo.ControlFlag)
                                //    {
                                //        if (agvInfo.Rfid > 0 && agvInfo.Rfid < 47)
                                //            agvInfo.ControlRfid = agvInfo.Rfid + 1000;
                                //    }
                                //} 
                                #endregion
                                agvInfo.Speed = recData[11];
                                agvInfo.Default2 = recData[12];
                                //agvInfo.Mode = (int)Enumerations.AgvMode.AutoOperation;//忽略AGV信息，指定为自动模式
                                //agvInfo.Default3 = 
                                #region 二维码
                                if (agvInfo.Type == Enumerations.agvType.type_1)
                                {//获取二维码信息 
                                    if (recData[13] == 0 && recData[14] == 0 && recData[15] == 0 && recData[16] == 0)
                                    {
                                        agvInfo.QRCode = string.Empty;
                                    }
                                    else
                                    {
                                        //if (agvInfo.Task1 == string.Empty)
                                        //{//若无任务，则二维码信息清空
                                        //    agvInfo.QRCode = string.Empty;
                                        //    lastQRCode = (((long)recData[13]) * 256 * 256 * 256 + ((long)recData[14]) * 256 * 256 + ((long)recData[15]) * 256 + recData[16]).ToString();          //将二维码信息存储至一局部变量，用于判断是否要更新
                                        //}
                                        //else
                                        //{
                                        //    string qrCode = (((long)recData[13]) * 256 * 256 * 256 + ((long)recData[14]) * 256 * 256 + ((long)recData[15]) * 256 + recData[16]).ToString();
                                        //    if (qrCode != lastQRCode)
                                        //    {
                                        //        agvInfo.QRCode = qrCode;
                                        //    }
                                        //}

                                        string tmpQr = (((long)recData[13]) * 256 * 256 * 256 + ((long)recData[14]) * 256 * 256 + ((long)recData[15]) * 256 + recData[16]).ToString();
                                        string qrCode = string.Empty;
                                        for (int i = tmpQr.Length; i < 10; i++)
                                        {
                                            qrCode += "0";
                                        }
                                        qrCode += tmpQr;
                                        if (qrCode != lastQRCode)
                                        {
                                            agvInfo.QRCode = qrCode;
                                            lastQRCode = qrCode;
                                        }
                                        if (Common.Instance.dtCapacityTestWait.Any(o => o.Value.Rfid == rfid))
                                        {
                                            AgvOperate(Enumerations.AgvOperate.QRCodeClear);
                                            Thread.Sleep(50);
                                        }

                                    }
                                }
                                #endregion
                                #region 机械臂
                                if (agvInfo.Type == Enumerations.agvType.type_1 && this.dataLength == 31)
                                {
                                    agvInfo.IsRobotArmOrigin = (recData[18] & 1) == 0 ? false : true;
                                    agvInfo.IsRobotArmScram = (recData[18] & 8) == 0 ? false : true;
                                    agvInfo.Default3 = recData[17];
                                    //agvInfo.State = (int)Enumerations.AgvStatus.abnormal;
                                    //agvInfo.Abnormal = 30 + agvInfo.RobotArmStu;
                                    agvInfo.RobotState = recData[20];
                                    agvInfo.RobotMode = (recData[18] & 4) == 0 ? false : true;
                                }
                                #endregion
                                if (Common.Instance.dtCapacityTestWait[1].Rfid == agvInfo.Rfid)
                                {
                                    if (isWaitTime == false)
                                    {
                                        Common.Instance.dtCapacityTestWait[1].UpdateTime = DateTime.Now;
                                        isWaitTime = true;
                                        agvInfo.isQRCodeRight = true;
                                    }
                                }
                                else if (Common.Instance.dtCapacityTestWait[2].Rfid == agvInfo.Rfid)
                                {
                                    if (isWaitTime == false)
                                    {
                                        Common.Instance.dtCapacityTestWait[2].UpdateTime = DateTime.Now;
                                        isWaitTime = true;
                                        agvInfo.isQRCodeRight = true;
                                    }
                                }
                                else
                                {
                                    isWaitTime = false;
                                }
                                this.lastRecDataTime = DateTime.Now;
                                isReadOk = true;
                            }
                        }
                    }
                }
                #endregion
                if (DateTime.Now.Subtract(lastRecDataTime).TotalSeconds > Common.Instance.AgvLineTime)
                {
                    agvInfo.State = (int)Enumerations.AgvStatus.disConnection;
                    if (DateTime.Now.Subtract(this.lastRecDataTime).TotalSeconds > Common.Instance.AgvClearLineTime)
                    {
                        //int rfid_ = agvInfo.Rfid;
                        //if (Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == rfid_) == false)
                        //    agvInfo.Rfid = -1;
                        //agvInfo.ControlRfid = -1;
                        //int agvNo = agvInfo.AgvNo;
                        //if (Common.controlPointsStatus.Any(o => o.Value == agvNo))
                        //{
                        //    try
                        //    {
                        //        int id = Common.controlPointsStatus.First(o => o.Value == agvNo).Key;
                        //        Common.controlPointsStatus[id] = -1;
                        //    }
                        //    catch { }
                        //}
                        //if (Common.controlPointAgvList.Any(o => o.Value.Contains(agvNo)))
                        //{
                        //    try
                        //    {
                        //        int id = Common.controlPointAgvList.First(o => o.Value.Contains(agvNo)).Key;
                        //        Common.controlPointAgvList[id].Remove(agvNo);
                        //    }
                        //    catch { }
                        //}
                        try
                        {
                            int cRfid = agvInfo.Rfid;
                            int cAgvNo = agvInfo.AgvNo;
                            int chargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Rfid == cRfid && o.Value.BindAgv == cAgvNo).Key;
                            if (chargeNo > 0)
                            {
                                Common.Instance.dtChargeInfo[chargeNo].BeginTime = new DateTime();
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }
            return isReadOk;
        }

        #region 任务写入
        /// <summary>
        /// 任务写入
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <returns></returns>
        public bool WriteTask(MA_AgvTaskInfo taskInfo)
        {
            try
            {
                RouteInfo routeInfo = taskInfo.T_Process[taskInfo.ProcessIndex];
                //try
                //{
                //    if (routeInfo.Station == 0)
                //    {
                //        routeInfo.Station = Common.Instance.dtRouteTypeToStation[routeInfo.Route];
                //    }
                //}
                //catch { }
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.taskAGV, 9, new byte[] { Convert.ToByte(routeInfo.Station / 256), Convert.ToByte(routeInfo.Station % 256), Convert.ToByte(routeInfo.Operation) });
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Task:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region 站点写入
        /// <summary>
        /// 向AGV写入最新站点动作信息
        /// </summary>
        /// <param name="routeNo">当前站点号</param>
        /// <param name="RfidInfo">AGV路段信息</param>
        /// <returns></returns>
        public bool WriteStation(int routeNo, RfidInfo rfidInfo)
        {
            try
            {
                byte[] data = new byte[12];
                data[0] = (byte)(routeNo / 256);
                data[1] = (byte)(routeNo % 256);
                data[2] = Convert.ToByte(rfidInfo.StopType);
                data[3] = Convert.ToByte(rfidInfo.Direction);
                data[4] = Convert.ToByte(rfidInfo.Default1);
                data[5] = Convert.ToByte(rfidInfo.Operate);
                data[6] = Convert.ToByte(rfidInfo.Speed);
                data[7] = Convert.ToByte(rfidInfo.StopTime);
                data[8] = Convert.ToByte(rfidInfo.EdgeCrossroad);
                data[9] = Convert.ToByte(rfidInfo.ObstacleType);
                data[10] = Convert.ToByte(rfidInfo.Default2);
                data[11] = Convert.ToByte(rfidInfo.LineStopType);
                byte[] sendData = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.stationWrite, Convert.ToByte(data.Length), data);
                string dataString = string.Format("Agv{0}  {1}\r", this.AgvComm.A_Id, string.Join(" ", sendData.ToList().ConvertAll<string>(o => o.ToString("X2"))));
                dataString = dataString + "  " + routeNo.ToString() + "\n";
                //foreach (byte item in sendData)
                //{
                //    dataString += item.ToString("X2") + " ";
                //}
                //dataString += "\r\n";
                if (Common.isSaveRoute)
                    LogFile.SaveLog(dataString);
                else
                    if (rfidInfo.Operate >= 21 && rfidInfo.Operate <= 26 && Common.isSaveRoute)
                        LogFile.SaveLog(dataString);
                this.stm32Udp.Send(sendData, sendData.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}: RFID {1}, Next RFID {2}, Error {3}, {4}", this.AgvComm.A_Id, routeNo, rfidInfo.EdgeRfidNum, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region AGV管制锁定
        /// <summary>
        /// agv交通锁定
        /// </summary>
        /// <returns></returns>
        public bool LockAgv()
        {
            try
            {
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.lockAgv, 9);
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Run:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region AGV管制解除
        /// <summary>
        /// agv交通解锁
        /// </summary>
        /// <returns></returns>
        public bool UnlockAgv()
        {
            try
            {
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.unlockAgv, 9);
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Unlock:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region AGV工位管制
        public bool StationLock()
        {
            try
            {
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.stationLock, 9, new byte[] { 1 });
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}StationLock:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region AGV工位管制解除
        public bool StationUnlock(byte dir)
        {
            try
            {
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.stationUnlock, 9, new byte[] { dir });
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}StationUnlock:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region AGV停止
        /// <summary>
        /// agv停止
        /// </summary>
        /// <returns></returns>
        public bool AgvStop()
        {
            try
            {
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.stopAGV, 9);
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Stop:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region AGV运行
        /// <summary>
        /// agv运行 前启
        /// </summary>
        /// <returns></returns>
        public bool AgvRun()
        {
            try
            {
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.startAGV, 9, new byte[] { 0x00 });
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Run:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion
        #region AGV复位
        /// <summary>
        /// agv复位
        /// </summary>
        /// <returns></returns>
        public bool AgvRest()
        {
            try
            {
                byte[] data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.restAGV, 9);
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Rest:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion

        #region AGV操作
        /// <summary>
        /// AGV操作
        /// </summary>
        /// <param name="operate">操作类型</param>
        /// <returns></returns>
        public bool AgvOperate(Enumerations.AgvOperate operate, params int[] station)
        {
            try
            {
                byte[] data = new byte[19];
                switch (operate)
                {
                    case Enumerations.AgvOperate.Forward:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.startAGV, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.Back:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.startAGV, 9, new byte[] { 0x01 });
                        break;
                    case Enumerations.AgvOperate.Rest:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.restAGV, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.Stop:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.stopAGV, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.StationClear:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.stationClear, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.QRCodeClear:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.QRCodeClear, 9, new byte[] { 0x00 });
                        break;
                    //case Enumerations.AgvOperate.PullUp:
                    //    data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.taskAGV, 9, new byte[] { 0x00, Convert.ToByte(station[0]), Convert.ToByte(station[1]) });
                    //    break;
                    //case Enumerations.AgvOperate.PullDown:
                    //    data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.taskAGV, 9, new byte[] { 0x00, Convert.ToByte(station[0]), Convert.ToByte(station[1]) });
                    //    break;
                    //case Enumerations.AgvOperate.GoWait:
                    //    if (station != null && station.Length > 0)
                    //    {
                    //        sendData[5] = 0x05;
                    //        sendData[6] = Convert.ToByte(station[0]);
                    //        sendData[7] = Convert.ToByte(station[0]);
                    //    }
                    //    break;

                    case Enumerations.AgvOperate.LeftRotate:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.LeftRotate, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.RightRotate:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.RightRotate, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.LeftTranslate:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.LeftTranslate, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.RightTranslate:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.RightTranslate, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.ChargeOpen:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.ChargeOpen, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.ChargeClose:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.ChargeClose, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.SupportUp:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.SupportUp, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.SupportBack:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.SupportBack, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.ObstacleClose:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.ObstacleClose, 9, new byte[] { Convert.ToByte(station[0]) });
                        break;
                    case Enumerations.AgvOperate.OperateComplete:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.OperateComplete, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.AutoMode:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.OperateMode, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.ManualMode:
                        data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.OperateMode, 9, new byte[] { 0x01 });
                        break;
                }
                //sendData[5] = (byte)operate;
                this.stm32Udp.Send(data, data.Length, this.agvPoint);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Rest:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }
        #endregion

        #region 写入AGV命令字节数组组合
        /// <summary>
        /// 命令码组合
        /// </summary>
        /// <param name="agvNo">需要通讯的AGV编号</param>
        /// <param name="cmdNo">命令码</param>
        /// <param name="length">数据长度</param>
        /// <param name="data">要发送的数据，与长度不匹配时自动填0x00</param>
        /// <returns></returns>
        private byte[] CMD(byte agvNo, byte cmdNo, byte length, params byte[] data)
        {
            List<byte> lsData = new List<byte>();
            try
            {
                lsData.Add(0xfc);
                byte lengthData = (byte)(10 + length);
                lsData.Add(lengthData);
                lsData.AddRange(new byte[] { (byte)(agvNo / 256), (byte)(agvNo % 256) });//目标地址
                lsData.AddRange(new byte[] { 0x00, 0x00 });//源地址
                lsData.Add(cmdNo);
                if (data.Length == length)
                {
                    lsData.AddRange(data);
                }
                else if (data.Length > length)
                {
                    for (int i = 0; i < length; i++)
                    {
                        lsData.Add(data[i]);
                    }
                }
                else
                {//不满，则自动填0x00
                    lsData.AddRange(data);
                    for (int i = 0; i < length - data.Length; i++)
                    {
                        lsData.Add(0x00);
                    }
                }
                string crcStr = (CRC16.GetCrc16(lsData.ToArray())).ToString("X4");
                lsData.AddRange(new Byte[] { Convert.ToByte(crcStr.Substring(0, 2), 16), Convert.ToByte(crcStr.Substring(2, 2), 16) });
                lsData.Add(0x5a);
            }
            catch { }
            return lsData.ToArray();
        }
        #endregion
        #region 接收数据校验
        /// <summary>
        /// 判断接收数据校验是否正确
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool CRCRecData(byte[] data)
        {
            bool isRight = false;
            try
            {
                byte[] crcData = new byte[data.Length - 3];
                byte high = data[data.Length - 3];
                byte low = data[data.Length - 2];
                for (int i = 0; i < data.Length - 3; i++)
                {
                    crcData[i] = data[i];
                }
                return CRC16.IsCrc16Good(crcData, high, low);
            }
            catch { }
            return isRight;
        }
        #endregion
        #region 命令码枚举
        /// <summary>
        /// 命令码
        /// </summary>
        public enum cmdCode : byte
        {
            /// <summary>
            /// 启动AGV data[0] 0:前启，1:后启
            /// </summary>
            startAGV = 0x01,
            /// <summary>
            /// 停止AGV
            /// </summary>
            stopAGV = 0x02,
            /// <summary>
            /// 复位AGV
            /// </summary>
            restAGV = 0x03,
            /// <summary>
            /// 执行任务  data[0]任务编号高位 data[1]任务编号低位  data[2] 动作:0 无动作，1 牵引棒上升，2 牵引棒下降
            /// </summary>
            taskAGV = 0x04,
            /// <summary>
            /// 查询AGV状态，data[0]当前RFID卡号
            /// </summary>
            query = 0x05,
            /// <summary>
            /// 交通锁定
            /// </summary>
            lockAgv = 0x10,
            /// <summary>
            /// 解除锁定
            /// </summary>
            unlockAgv = 0x11,
            /// <summary>
            /// 工位管制
            /// </summary>
            stationLock = 0x02,
            /// <summary>
            /// 工位管制解除
            /// </summary>
            stationUnlock = 0x01,
            /// <summary>
            /// 清除路段编号
            /// </summary>
            stationClear = 0x20,
            /// <summary>
            /// 站点写入
            /// </summary>
            stationWrite = 0x21,
            /// <summary>
            /// 清除二维码
            /// </summary>
            QRCodeClear = 0x22,
            /// <summary>
            /// 左转
            /// </summary>
            LeftRotate = 0x14,
            /// <summary>
            /// 右转
            /// </summary>
            RightRotate = 0x15,
            /// <summary>
            /// 左平移
            /// </summary>
            LeftTranslate = 0x08,
            /// <summary>
            /// 右平移
            /// </summary>
            RightTranslate = 0x09,
            /// <summary>
            /// 充电接触器开
            /// </summary>
            ChargeOpen = 0x1D,
            /// <summary>
            /// 充电接触器关
            /// </summary>
            ChargeClose = 0x1E,
            /// <summary>
            /// 支撑顶起
            /// </summary>
            SupportUp = 0x12,
            /// <summary>
            /// 支撑收回
            /// </summary>
            SupportBack = 0x13,
            /// <summary>
            /// 障碍关闭
            /// </summary>
            ObstacleClose = 0x07,
            /// <summary>
            /// 动作完成
            /// </summary>
            OperateComplete,
            /// <summary>
            /// 操作模式  0：自动模式 1：自动模式
            /// </summary>
            OperateMode = 0x1F,
        }
        #endregion
    }
}
