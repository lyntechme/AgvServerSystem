using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class DA_AgvStm32Ins : AgvConnect
    {
        #region Perproties
        /// <summary>
        /// 通信异常日志保存地址
        /// </summary>
        private string LogSavePath = @"D:\AgvLog";
        /// <summary>
        /// 最新AGV信息
        /// </summary>
        private M_AgvInfo mai = new M_AgvInfo(); //agv信息
        /// <summary>
        /// agv通讯参数
        /// </summary>
        private MA_AgvComInfo AgvComm;
        /// <summary>
        /// 返回数据计数
        /// </summary>
        private int recOutCount = 0;
        /// <summary>
        /// 返回数据计数最大判断值
        /// </summary>
        private const int recOutMaxCount = 50;
        /// <summary>
        /// 缓冲数据上一条
        /// </summary>
        private string dataBeforeBufferStr = string.Empty;
        /// <summary>
        /// 读取数据缓存
        /// </summary>
        private List<byte> dataBuffer = new List<byte>();
        /// <summary>
        /// 对缓存数据操作锁
        /// </summary>
        private object lockDataObj = new object();
        /// <summary>
        /// 发送数据句柄
        /// </summary>
        private Socket socketClient = null;
        /// <summary>
        /// 本地接收端口号
        /// </summary>
        private int myPort = 0;
        /// <summary>
        /// 本地接收句柄
        /// </summary>
        private Socket agvSocket;
        /// <summary>
        /// TCP连接是否断掉
        /// </summary>
        private bool tcpError = false; //Tcp连接是否断掉
        /// <summary>
        /// 是否与agv进行连接
        /// </summary>
        private bool isContinue = true; //是否与agv进行连接
        /// <summary>
        /// 监听的客户端
        /// </summary>
        private Dictionary<string, Socket> cAgvSocketDict = new Dictionary<string, Socket>();//监听的客户端
        /// <summary>
        /// 监控客户端的线程
        /// </summary>
        private Dictionary<string, Thread> cAgvThreadDict = new Dictionary<string, Thread>();//监听客户端的线程
        /// <summary>
        /// CRC校验
        /// </summary>
        private CRC16 crc = new CRC16();
        /// <summary>
        /// 通讯连续掉线累计次数
        /// </summary>
        private int linkNum = 0;
        /// <summary>
        /// 最大连接判断次数
        /// </summary>
        private int linkMaxCount = 20;
        /// <summary>
        /// 是否进入管制标志位
        /// </summary>
        private bool isControlFlag = false;
        /// <summary>
        /// 速度写入成功标志位
        /// </summary>
        private int setSpeedOk = -1;
        /// <summary>
        /// 当前agv是否开始记录路径信息
        /// </summary>
        private bool isRouteInfo = false;  //当前Agv是否开始记录路径信息
        #endregion

        #region 变量对应
        /// <summary>
        /// 充电时间设置
        /// </summary>
        private const string chargingTimeStr = "SC";
        /// <summary>
        /// 速度设置
        /// </summary>
        private const string speedStr = "SV";
        /// <summary>
        /// 路段设置
        /// </summary>
        private const string segmentData = "SD";
        /// <summary>
        /// 自动模式
        /// </summary>
        private const string autoMode = "M2";
        /// <summary>
        /// 手动模式
        /// </summary>
        private const string manualMode = "M0";
        private const string stateData = "STD";
        private const string setOk = "ACK"; //设置正确
        private const string setErr = "ERR"; //设置错误 
        private const string musicVolume = "MV";  //
        #endregion

        /// <summary>
        /// 惯性导航AGV通讯初始化
        /// </summary>
        /// <param name="_agvComm">AGV初始通讯参数</param>
        public DA_AgvStm32Ins(MA_AgvComInfo _agvComm)
        {
            this.mai = new M_AgvInfo();
            this.AgvComm = _agvComm;
            this.myPort = _agvComm.A_LocalPort;
            Thread thrListen = new Thread(new ThreadStart(ListenClientConnect));
            //ListenClientConnect();
            thrListen.IsBackground = true;
            thrListen.Start();
        }
        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private void ListenClientConnect()
        {
            agvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, myPort);
            try
            {
                agvSocket.Bind(iep);
            }
            catch (Exception ex)
            {
                if (!tcpError)
                {
                    tcpError = true;
                }
                ListenClientConnect();
            }
            tcpError = false;
            agvSocket.Listen(10);
            while (true)
            {
                try
                {
                    socketClient = agvSocket.Accept();
                    //socketClient.SendTimeout = 20000;
                    socketClient.ReceiveTimeout = 1000;
                    socketClient.ReceiveBufferSize = 1024 * 1024 * 2;
                    Thread thr = new Thread(TcpComm);
                    thr.Name = socketClient.RemoteEndPoint.ToString();
                    thr.IsBackground = true;
                    thr.Start(socketClient);
                    TcpConnectLog(string.Format("AGV{0} 新连接，终结点：{1}", this.AgvComm.A_Id, thr.Name), this.AgvComm.A_Id);
                    //if (cAgvSocketDict.ContainsKey(socketClient.RemoteEndPoint.ToString()))
                    //{
                    //    cAgvSocketDict.Remove(socketClient.RemoteEndPoint.ToString());
                    //}
                    //cAgvSocketDict[socketClient.RemoteEndPoint.ToString()] = socketClient;
                    //if (cAgvThreadDict.ContainsKey(socketClient.RemoteEndPoint.ToString()))
                    //{
                    //    try
                    //    {
                    //        cAgvThreadDict[socketClient.RemoteEndPoint.ToString()].Abort();
                    //    }
                    //    catch { }
                    //    cAgvThreadDict.Remove(socketClient.RemoteEndPoint.ToString());
                    //}
                    //cAgvThreadDict[socketClient.RemoteEndPoint.ToString()] = thr;
                    if (!cAgvSocketDict.ContainsKey(socketClient.RemoteEndPoint.ToString()))
                    {
                        cAgvSocketDict[socketClient.RemoteEndPoint.ToString()] = socketClient;
                        cAgvThreadDict[socketClient.RemoteEndPoint.ToString()] = thr;
                        TcpConnectLog(string.Format("AGV{0} 线程集合添加，终结点：{1}", this.AgvComm.A_Id, thr.Name), this.AgvComm.A_Id);
                    }
                }
                catch { }
            }
        }
        #region Tcp通讯处理
        private void TcpComm(object socket)
        {
            //Socket socketClient = socket as Socket;
            //int countS = 0;
            while (true)
            {
                if (isContinue)
                {
                    byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                    int length = -1;
                    try
                    {
                        socketClient.Blocking = true;
                        length = socketClient.Receive(arrMsgRec, arrMsgRec.Length, 0);
                        if (length == 0)
                        {
                            socketClient.Disconnect(true);//关闭连接
                            cAgvSocketDict.Remove(socketClient.RemoteEndPoint.ToString());
                            cAgvThreadDict.Remove(socketClient.RemoteEndPoint.ToString());
                            TcpConnectLog(string.Format("AGV{0} 请求断开连接，终结点：{1}", this.AgvComm.A_Id, socketClient.RemoteEndPoint.ToString()), this.AgvComm.A_Id);
                            lock (Common.maiDict[this.AgvComm.A_Id])
                            {
                                Common.maiDict[this.AgvComm.A_Id].State = (int)Enumerations.AgvStatus.disConnection;
                                this.mai.State = (int)Enumerations.AgvStatus.disConnection;
                            }
                            break;
                        }
                        this.recOutCount = 0;
                        //Thread.Sleep(100);
                        byte[] reallData = new byte[length];
                        Array.Copy(arrMsgRec, reallData, reallData.Length);
                        lock (lockDataObj)
                        {//将最新数据存放在缓存区内
                            if (dataBuffer.Count > 65535 || dataBuffer.Count < 0)
                            {
                                dataBuffer.Clear();
                            }
                            dataBuffer.AddRange(reallData);
                        }
                        Thread.Sleep(10);
                    }
                    catch (SocketException exSocket)
                    {
                        if (exSocket.SocketErrorCode == SocketError.TimedOut)   //当连接尝试超时连续5次时，抛出异常
                        {
                            //this.mai.Status = (int)Enumerations.AgvStatus.disConnection;
                            TcpConnectLog(string.Format("AGV{0} 连接尝试超时连续{1}次，终结点：{2}", this.AgvComm.A_Id, recOutCount, socketClient.RemoteEndPoint.ToString()), this.AgvComm.A_Id);
                            if (this.recOutCount >= recOutMaxCount)
                            {
                                this.recOutCount = 0;
                                socketClient.Disconnect(true);//关闭连接
                                cAgvSocketDict.Remove(socketClient.RemoteEndPoint.ToString());
                                cAgvThreadDict.Remove(socketClient.RemoteEndPoint.ToString());
                                this.mai.State = (int)Enumerations.AgvStatus.disConnection;
                                TcpConnectLog(string.Format("AGV{0} 连接尝试超时连续{1}次，调度系统自动断开连接，终结点：{2}", this.AgvComm.A_Id, recOutCount, socketClient.RemoteEndPoint.ToString()), this.AgvComm.A_Id);
                                break;
                            }
                            else
                            {
                                this.recOutCount += 1;
                                continue;
                            }
                        }
                        else
                        {
                            this.recOutCount = 0;
                            socketClient.Disconnect(true);//关闭连接
                            TcpConnectLog(string.Format("AGV{0} 套接字异常，异常信息：{1}", this.AgvComm.A_Id, exSocket.Message), this.AgvComm.A_Id);
                            cAgvSocketDict.Remove(socketClient.RemoteEndPoint.ToString());
                            cAgvThreadDict.Remove(socketClient.RemoteEndPoint.ToString());
                            this.mai.State = (int)Enumerations.AgvStatus.disConnection;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        socketClient.Disconnect(true);//关闭连接
                        cAgvSocketDict.Remove(socketClient.RemoteEndPoint.ToString());
                        cAgvThreadDict.Remove(socketClient.RemoteEndPoint.ToString());
                        TcpConnectLog(string.Format("AGV{0} 其他异常，异常信息：{1}", this.AgvComm.A_Id, ex.Message), this.AgvComm.A_Id);
                        //CheckReceive(arrMsgRec, length, socketClient);
                        dataBuffer.Clear();
                        lock (Common.maiDict[this.AgvComm.A_Id])
                        {
                            Common.maiDict[this.AgvComm.A_Id].State = (int)Enumerations.AgvStatus.disConnection;
                            this.mai.State = (int)Enumerations.AgvStatus.disConnection;
                        }
                        break;
                    }
                }
            }
        }
        #endregion //Tcp通讯处理
        #region 处理接收数据
        #region 获取最新数据
        bool AgvConnect.ReadData(ref M_AgvInfo agvInfo)
        {
            try
            {
                List<byte> _dataLs = new List<byte>();
                lock (this.lockDataObj)
                {
                    if (this.dataBuffer.Count <= 0)
                    {//无缓存数据，返回获取数据失败
                        return false;
                    }
                    else
                    {
                        int _d0x23 = this.dataBuffer.IndexOf(0x23);
                        int _d0x0d = this.dataBuffer.LastIndexOf(0x0d);
                        if (_d0x0d > _d0x23 && _d0x23 >= 0)
                        {
                            int count = this.dataBuffer.Count;
                            _dataLs.AddRange(this.dataBuffer.Take(_d0x0d + 1));
                            do
                            {//确保移除成功
                                this.dataBuffer.RemoveRange(0, _d0x0d + 1);//移除已拿数据
                            }
                            while (this.dataBuffer.Count >= count);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (_dataLs.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return CheckReceive(_dataLs.ToArray(), _dataLs.Count, ref agvInfo);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region 数据解析
        /// <summary>
        /// 判断接收数据是否正确，若正确对其进行处理
        /// </summary>
        /// <param name="receiveStr">接收到的字符串</param>
        /// <param name="length">有效长度</param>
        /// <param name="agvInfo">需要更新的AGV</param>
        /// <returns>字符串是否正确</returns>
        private bool CheckReceive(byte[] receiveData, int length, ref M_AgvInfo agvInfo)
        {
            bool isCheckOk = false;
            try
            {
                if (length < 1)
                {
                    this.linkNum += 1;
                }
                else
                {
                    #region 数据解析
                    //若数据正确，则将linkNum置0,否则linkNum += 1                    
                    string recStr_ = Encoding.Default.GetString(receiveData);
                    string recStr = recStr_.Substring(0, length);
                    //lock (Common.recAgvDataString)
                    //{
                    //    Common.recAgvDataString[this.maci.A_Id] = recStr;
                    //}
                    List<string> dataLs = new List<string>();  //读取全部数据,分隔开来                     
                    int begin = recStr.IndexOf('#');
                    while (begin >= 0)
                    {
                        int end = recStr.IndexOf('\r', begin);
                        if (end > begin)
                        {
                            dataLs.Add(recStr.Substring(begin + 1, end - begin - 1));
                            begin = recStr.IndexOf('#', end);
                        }
                        else break;
                    }
                    if (dataLs.Count > 0)
                    {
                        //bool isWritSpeedOk = false;
                        this.dataBeforeBufferStr = string.Empty;
                        for (int i = 0; i < dataLs.Count; i++)
                        {
                            //this.mai = new M_AgvInfo();
                            if (dataLs[i].Substring(0, 5) == "ACKMV")
                            {
                                try
                                {
                                    this.mai.Volume = Convert.ToInt32(dataLs[i].Substring(5, 1));
                                }
                                catch
                                { }
                            }
                            else
                            {
                                switch (dataLs[i].Substring(0, 2))
                                {
                                    case speedStr://判断是否处于判断管制状态
                                        if (dataLs[i] == "SVACK")
                                        {
                                            if (setSpeedOk == 0)
                                            {
                                                this.isControlFlag = true;
                                            }
                                            else if (setSpeedOk > 0)
                                            {
                                                this.isControlFlag = false;
                                            }
                                        }
                                        break;
                                    case chargingTimeStr:
                                        //if (dataLs[i] == "SCACK")
                                        //{
                                        //    this.isCharge = true;
                                        //}
                                        break;
                                    case segmentData:
                                        break;
                                    case manualMode:  //手动模式
                                    case autoMode:   //自动模式    读取状态信息
                                        if (dataLs[i] != this.dataBeforeBufferStr)
                                        {
                                            this.linkNum = 0;
                                            int check = 0;
                                            for (int j = 0; j < dataLs[i].Length - 3; j++)
                                            {
                                                check += (int)dataLs[i][j];
                                            }
                                            string c = check.ToString("D3").Substring(check.ToString("D3").Length - 3);//校验码，将所有的char值相加，总和取前3位
                                            string stateDataStr = string.Empty;
                                            if (c == dataLs[i].Substring(dataLs[i].Length - 3))  //判断校验是否正确
                                            {
                                                stateDataStr = "#" + stateData + setOk + "\r"; //接收数据正确，向AGV发送确认信号
                                                int beginIndex = 0;
                                                int endIndex = 0;
                                                try
                                                {
                                                    int rIndex = 0;
                                                    this.mai.LightType = ReceiveDataSelect(dataLs[i], "L", "H", ref rIndex);//灯光类型
                                                    int heading = ReceiveDataSelect(dataLs[i], "H", "VS", ref rIndex);//航向
                                                    switch (heading)
                                                    {
                                                        case 1:
                                                            this.mai.Direction = (int)AgvDirection.Forward;
                                                            break;
                                                        case 4:
                                                            this.mai.Direction = (int)AgvDirection.Behind;
                                                            break;
                                                    }
                                                    this.mai.Abnormal = ReceiveDataSelect(dataLs[i], "VS", "D", ref rIndex);//异常编号
                                                    this.mai.DragState = ReceiveDataSelect(dataLs[i], "D", "VO", ref rIndex);//牵引棒状态
                                                    this.mai.Voltage = ReceiveDataSelect(dataLs[i], "VO", "VE", ref rIndex);//电压值
                                                    this.mai.Speed = ReceiveDataSelect(dataLs[i], "VE", "C", ref rIndex);//速度
                                                    this.mai.Default4 = ReceiveDataSelect(dataLs[i], "C", "R", ref rIndex);//充电时长
                                                    int rouFlag = ReceiveDataSelect(dataLs[i], "R", "SN", ref rIndex);//当前AGV是否开始记录路段信息
                                                    if (rouFlag == 0)
                                                    {
                                                        this.isRouteInfo = false;
                                                    }
                                                    else if (rouFlag == 1)
                                                    {
                                                        this.isRouteInfo = true;
                                                    }
                                                    if (this.mai.Speed > 0)
                                                    {
                                                        this.mai.ControlFlag = false;
                                                    }
                                                    else
                                                    {
                                                        this.mai.ControlFlag = true;
                                                    }
                                                    this.mai.CurrentMags = ReceiveDataSelect(dataLs[i], "SN", "RN", ref rIndex);//当前磁点索引号
                                                    int cruNo = ReceiveDataSelect(dataLs[i], "RN", "ID", ref rIndex);//已写入磁点索引号
                                                    this.mai.WritedMags = cruNo;
                                                    int seNo = cruNo - this.mai.CurrentMags;
                                                    if (seNo >= -1 && seNo < 1)
                                                    {
                                                        if (!this.isRouteInfo)
                                                            this.mai.Default1 = cruNo;
                                                        else
                                                            this.mai.Default1 = cruNo + 1;
                                                        this.mai.Default2 = 1;
                                                        if (this.mai.lsRoutes.Count > this.mai.CurrentMags)
                                                        {
                                                            this.mai.Default5 = this.mai.lsRoutes[this.mai.CurrentMags].Key;
                                                        }
                                                        else if (this.mai.lsRoutes.Count <= this.mai.CurrentMags)
                                                        {
                                                            this.mai.Default5 = this.mai.lsRoutes[this.mai.lsRoutes.Count - 1].Value.EdgeRfidNum;
                                                        }
                                                        this.mai.ShowRfid = this.mai.Default5;
                                                        this.mai.ControlRfid = this.mai.Default5;
                                                        this.mai.ControlRfid2 = this.mai.Default5;
                                                        this.mai.Rfid = this.mai.Default5;
                                                    }
                                                    else
                                                    {
                                                        this.mai.Default2 = 0;
                                                    }

                                                    //手动模式不执行动作
                                                    if (dataLs[i].Substring(0, 2) == manualMode)
                                                    {
                                                        this.mai.Volume = 5;
                                                        this.mai.Mode = (int)Enumerations.AgvMode.ManualOperation;
                                                        this.mai.Default2 = 0;  //手动模式下，不回答路径请求
                                                        //如果切换为手动模式，则任务清除，位置信息清除，需要回到等待点重新执行任务
                                                        this.mai.Default5 = -1;
                                                        //this.isAgvTest = true;  

                                                    }
                                                    else if (dataLs[i].Substring(0, 2) == autoMode)
                                                    {
                                                        this.mai.Mode = (int)Enumerations.AgvMode.AutoOperation;
                                                    }
                                                    beginIndex = endIndex;   //当前Rfid
                                                    this.mai.Default6 = ReceiveDataSelect(dataLs[i], "ID", string.Empty, ref rIndex);
                                                    isCheckOk = true;
                                                    #region 充电判断
                                                    if (this.mai.Default4 > 10)  //是否正在充电
                                                    {
                                                        this.mai.ChargeState = false;
                                                    }
                                                    else
                                                    {
                                                        this.mai.ChargeState = false;
                                                    }
                                                    if (this.mai.VoltageStatus == Enumerations.voltageStatus.chargVoltage)
                                                    {
                                                        if ((this.mai.Default4 + Common.Instance.dtChargeLimitedInfo[this.mai.Type].LimitedTime) < 9999 && this.mai.Default4 > 10)  //若充电时间大于充电时间阀值，则可进行任务派送
                                                        {
                                                            this.mai.VoltageStatus = Enumerations.voltageStatus.normal;
                                                        }
                                                        else if (this.mai.Voltage > Common.Instance.dtChargeLimitedInfo[this.mai.Type].LimitedEnable && this.mai.Default4 <= 10 && this.mai.Speed > 50)
                                                        {
                                                            this.mai.VoltageStatus = Enumerations.voltageStatus.normal;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //if ((this.mai.ChargeTime + Common.AgvChargeTimeLimited) > 9999 && this.mai.ChargeTime > 10)
                                                        //{
                                                        //    this.isNeedCharge = true;
                                                        //}
                                                        if (this.mai.Voltage < Common.Instance.dtChargeLimitedInfo[this.mai.Type].LimitedCharge && this.mai.Default4 <= 10 && this.mai.Speed > 50)
                                                        {
                                                            this.mai.VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                                                        }
                                                    }
                                                    #endregion
                                                    this.dataBeforeBufferStr = dataLs[i];
                                                }
                                                catch
                                                { }
                                            }
                                            else
                                            {//读取数据错误，向AGV反馈读取信息错误  
                                                stateDataStr = "#" + stateData + setErr + "\r";
                                            }
                                            if (stateDataStr != string.Empty)
                                            {
                                                socketClient.Send(Encoding.Default.GetBytes(stateDataStr));
                                            }
                                            lock (Common.maiDict[this.AgvComm.A_Id])
                                            {
                                                Common.maiDict[this.AgvComm.A_Id].State = (int)Enumerations.AgvStatus.running;
                                                this.mai.State = (int)Enumerations.AgvStatus.running;
                                            }
                                        }
                                        break;
                                    default: break;
                                }
                            }
                        }
                        agvInfo = this.mai;
                    }
                    #endregion
                }
                if (this.linkNum > this.linkMaxCount)
                {
                    lock (Common.maiDict[this.AgvComm.A_Id])
                    {
                        Common.maiDict[this.AgvComm.A_Id].State = (int)Enumerations.AgvStatus.disConnection;
                        this.mai.State = (int)Enumerations.AgvStatus.disConnection;
                    }
                }
            }
            catch { }
            return isCheckOk;
        }
        #endregion
        #region 数据筛选、转换
        /// <summary>
        /// 数据筛选、转换
        /// </summary>
        /// <param name="_data">源数据</param>
        /// <param name="_sBegin">起始</param>
        /// <param name="_sEnd">结束</param>
        /// <param name="_start">起始查询索引</param>
        /// <returns></returns>
        private int ReceiveDataSelect(string _data, string _sBegin, string _sEnd, ref int _start)
        {
            int value = -1;
            try
            {
                int begin = _data.IndexOf(_sBegin, _start);
                int end = _data.IndexOf(_sEnd, _start);
                if (_sEnd == string.Empty) end = _data.Length - 1;
                _start = end;
                value = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(_data.Substring(begin, end - begin), @"[^0-9]+", ""));
            }
            catch { }
            return value;
        }
        #endregion
        #endregion //处理接收数据
        #region Log File
        private void TcpConnectLog(string contents, int agvNo)
        {
            try
            {
                if (!Directory.Exists(LogSavePath))
                {
                    Directory.CreateDirectory(LogSavePath);
                }
                string FileName = LogSavePath + @"\TcpLog" + DateTime.Now.ToString("yyyy-MM-dd") + "_AGV" + agvNo + ".log";
                //if (File.Exists(FileName))
                //    File.Delete(FileName);
                string strLine = "";
                using (FileStream objFileStream = new FileStream(FileName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode))
                    {
                        strLine = contents + "   " + DateTime.Now.ToString("HH:mm:ss");
                        objStreamWriter.WriteLine(strLine);
                        objStreamWriter.Close();
                        objFileStream.Close();
                    }
                }
            }
            catch { }
        }
        #endregion
        /// <summary>
        /// 任务写入
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <returns></returns>
        public bool WriteTask(MA_AgvTaskInfo taskInfo) { return false; }
        /// <summary>
        /// agv交通锁定
        /// </summary>
        /// <returns></returns>
        public bool LockAgv() { return false; }
        /// <summary>
        /// agv交通解锁
        /// </summary>
        /// <returns></returns>
        public bool UnlockAgv() { return false; }
        /// <summary>
        /// agv停止
        /// </summary>
        /// <returns></returns>
        public bool AgvStop() { return false; }
        /// <summary>
        /// agv运行
        /// </summary>
        /// <returns></returns>
        public bool AgvRun() { return false; }
        /// <summary>
        /// agv复位
        /// </summary>
        /// <returns></returns>
        public bool AgvRest() { return false; }
        /// <summary>
        /// AGV操作
        /// </summary>
        /// <param name="operate">操作类型</param>
        /// <param name="station">站点信息</param>
        /// <returns></returns>
        public bool AgvOperate(Enumerations.AgvOperate operate, params int[] station)
        {
            try
            {
                byte[] data = new byte[19];
                byte agvNo = (byte)this.mai.AgvNo;
                switch (operate)
                {
                    case Enumerations.AgvOperate.Forward:
                        break;
                    case Enumerations.AgvOperate.Back:
                        break;
                    case Enumerations.AgvOperate.Rest:
                        break;
                    case Enumerations.AgvOperate.Stop:
                        break;
                    case Enumerations.AgvOperate.StationClear:
                        data = CMD(agvNo, "ST0000");
                        break;
                    case Enumerations.AgvOperate.QRCodeClear:
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
                        //data = CMD((byte)(this.AgvComm.A_Id), (byte)cmdCode.LeftRotate, 9, new byte[] { 0x00 });
                        break;
                    case Enumerations.AgvOperate.RightRotate:
                        break;
                    case Enumerations.AgvOperate.LeftTranslate:
                        break;
                    case Enumerations.AgvOperate.RightTranslate:
                        break;
                    case Enumerations.AgvOperate.ChargeOpen:
                        break;
                    case Enumerations.AgvOperate.ChargeClose:
                        break;
                    case Enumerations.AgvOperate.SupportUp:
                        break;
                    case Enumerations.AgvOperate.SupportBack:
                        break;
                    case Enumerations.AgvOperate.ObstacleClose:
                        break;
                    case Enumerations.AgvOperate.OperateComplete:
                        break;
                    case Enumerations.AgvOperate.AutoMode:
                        break;
                    case Enumerations.AgvOperate.ManualMode:
                        break;
                }
                if (socketClient.Poll(10, SelectMode.SelectWrite))
                {//发送操作命令
                    socketClient.Send(data);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("AGV{0}Rest:{1} {2}", this.AgvComm.A_Id, ex.Message, DateTime.Now));
                return false;
            }
        }

        private byte[] CMD(byte agvNo, string cmdStr, params string[] dataStr)
        {
            List<byte> data = new List<byte>();
            try
            {
                char[] dataChar = dataStr.ToString().ToCharArray();
                int check = 0;
                for (int i = 0; i < dataChar.Length; i++)
                {
                    check += (int)dataChar[i];
                }
                string checkStr = CutLastString(check.ToString("D3"), 3);
                string sendStr = "#" + dataStr.ToString() + checkStr + "\r";
                data = Encoding.Default.GetBytes(sendStr).ToList();
            }
            catch { }
            return data.ToArray();
        }

        public bool WriteStation(int routeNo, RfidInfo rfidInfo)
        {
            try
            {
                string sendStr = SendString(routeNo, rfidInfo);
                if (this.socketClient.Send(Encoding.Default.GetBytes(sendStr)) > 0) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        #region 发送字符串
        /// <summary>
        /// 返回发送字符长度
        /// </summary>
        /// <param name="segmentReceive">请求磁钉对数号</param>
        /// <returns>发送至Agv字符串口</returns>
        private string SendString(int routeNo, RfidInfo rfidInfo)
        {
            StringBuilder dataStr = new StringBuilder();
            dataStr.Append("SD");  //行走距离
            dataStr.Append(CutLastString(routeNo.ToString("D4"), 4));
            dataStr.Append("L");
            dataStr.Append(CutLastString(rfidInfo.EdgeLength.ToString("D4"), 4));
            dataStr.Append("M");  //磁钉间距
            dataStr.Append(CutLastString(rfidInfo.ObstacleType.ToString("D4"), 4));
            dataStr.Append("S");  //定点距离
            dataStr.Append(CutLastString(rfidInfo.Default2.ToString("D4"), 4));
            dataStr.Append("D"); //牵引动作
            dataStr.Append(CutLastString(rfidInfo.Operate.ToString("D1"), 1));
            dataStr.Append("C");
            dataStr.Append(CutLastString("0000", 4));  //充电时间
            dataStr.Append("H");   //方向
            dataStr.Append(CutLastString(rfidInfo.Direction.ToString("D1"), 4));
            dataStr.Append("A");  //旋转角度 
            dataStr.Append((rfidInfo.EdgeCrossroad > 0 ? "+" : "") + rfidInfo.EdgeCrossroad.ToString("D4"));
            dataStr.Append("V");  //速度
            dataStr.Append(CutLastString(rfidInfo.Speed.ToString("D4"), 4));
            //dataStr.Append("E");
            //dataStr.Append(this.agvToElevatorAction.ToString("D1").Substring(this.agvToElevatorAction.ToString("D1").Length - 1));
            char[] dataChar = dataStr.ToString().ToCharArray();
            int check = 0;
            for (int i = 0; i < dataChar.Length; i++)
            {
                check += (int)dataChar[i];
            }
            string c = check.ToString("D3");
            string checkStr = c.Substring(c.Length - 3);
            string sendStr = "#" + dataStr.ToString() + checkStr + "\r";
            return sendStr;

        }
        /// <summary>
        /// 截取字符串后几位
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        private string CutLastString(string s, int length)
        {
            return s.Substring(s.Length - length);
        }
        #endregion //发送字符串
    }
}
