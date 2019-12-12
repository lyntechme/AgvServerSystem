using DAL;
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

namespace BLL
{
    /// <summary>
    /// 充电桩通讯
    /// </summary>
    public class ChargeUdpClient
    {
        /// <summary>
        /// 充电桩通讯集合
        /// </summary>
        public static Dictionary<int, ChargeUdpClient> dtChargeUdp = new Dictionary<int, ChargeUdpClient>();
        #region 属性
        /// <summary>
        /// 
        /// </summary>
        private int count = 0;
        private UdpClient udpDoor;
        /// <summary>
        /// 设定目标网络端点
        /// </summary>
        private IPEndPoint desEndPoint;
        /// <summary>
        /// 回传目标网络端点
        /// </summary>
        private IPEndPoint refEndPoint;
        /// <summary>
        /// 充电桩编号
        /// </summary>
        private int ChargerNo;
        /// <summary>
        /// 发送命令数据的长度
        /// </summary>
        private byte length = 9;
        /// <summary>
        /// 发送互斥锁
        /// </summary>
        public object lockObj = new object();
        /// <summary>
        /// 获取的充电桩数据
        /// </summary>
        private List<byte> recDataBuffer = new List<byte>();
        /// <summary>
        /// 接收到数据长度
        /// </summary>
        private int dataLength = 19;
        /// <summary>
        /// 掉线判断计数
        /// </summary>
        private int lineCount = 0;
        /// <summary>
        /// 掉线判断最大计数
        /// </summary>
        private int lineTime = 15;
        /// <summary>
        /// 
        /// </summary>
        private DateTime lastRecDataTime = new DateTime();
        #endregion
        #region 初始化
        public ChargeUdpClient(int cahrgeNo)
        {
            this.ChargerNo = cahrgeNo;
            if (Common.Instance.dtChargeInfo.ContainsKey(this.ChargerNo))
            {
                desEndPoint = new IPEndPoint(IPAddress.Parse(Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.IpString), Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.Port);
                udpDoor = new UdpClient(Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.Port);
            }

            refEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }
        #endregion
        /// <summary>
        /// 读取充电桩当前状态信息
        /// </summary>
        public void ReadChargeInformation()
        {
            while (true)
            {
                #region 充电绑定解除判断
                if (Common.isLoadedOk)
                {
                    try
                    {
                        if (Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv > 0 && Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv < 100)
                        {
                            int agvNo = Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv;
                            if (Common.maiDict[agvNo].Rfid != Common.Instance.dtChargeInfo[this.ChargerNo].Rfid)
                            {
                                Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv = 0;
                                Common.Instance.dtChargeInfo[this.ChargerNo].BeginTime = new DateTime();
                            }
                        }
                        else if (Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv > 100)
                        {
                            int agvNo = Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv - 100;
                            if (Common.maiDict.ContainsKey(agvNo))
                            {
                                if (Common.maiDict[agvNo].Task1 == string.Empty && Common.maiDict[agvNo].Task2 == string.Empty)
                                {
                                    Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv = 0;
                                    Common.Instance.dtChargeInfo[this.ChargerNo].BeginTime = new DateTime();
                                }
                            }
                        }
                        if (Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv <= 0)
                        {
                            //int rfid = Common.Instance.dtChargeInfo[this.ChargerNo].Rfid;
                            //int agvNo = Common.taskDt[(int)Enumerations.agvType.type_1].FirstOrDefault(o => o.Value.T_TCharge_Gotions.TaskType.Charge_Type1_1 && o.Value.T_Process.Any(p => p.Station == rfid) && o.Value.T_AgvNo > 0).Value.T_AgvNo;
                            //if (agvNo < 0)
                            //{
                            //    agvNo = Common.taskDt[(int)Enumerations.agvType.type_3].FirstOrDefault(o => o.Value.T_Type == Enumerations.TaskType.Charge_Type2_1 && o.Value.T_Process.Any(p => p.Station == rfid) && o.Value.T_AgvNo > 0).Value.T_AgvNo;
                            //}
                            //if (agvNo < 0)
                            //{
                            //    agvNo = Common.taskDt[(int)Enumerations.agvType.type_2].FirstOrDefault(o => o.Value.T_Type == Enumerations.TaskType.Charge_Type2_2 && o.Value.T_Process.Any(p => p.Station == rfid) && o.Value.T_AgvNo > 0).Value.T_AgvNo;
                            //}
                            //if (agvNo > 0 && Common.maiDict.ContainsKey(agvNo))
                            //{
                            //    if (Common.maiDict[agvNo].Rfid != Common.Instance.dtChargeInfo[this.ChargerNo].Rfid) Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv = agvNo + 100;
                            //}
                        }
                    }
                    catch { }
                }
                #endregion
                try
                {
                    if (Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.Enable)//该充电桩是否启用
                    {
                        byte[] sendData = CmdData((byte)EChargeOperate.QueryData, length);
                        lock (lockObj)
                            udpDoor.Send(sendData, sendData.Length, this.desEndPoint);
                        Thread.Sleep(50);
                        //if (this.ChargerNo == 14)
                        //{
                        //    List<string> ls = sendData.ToList().ConvertAll<string>(x => x.ToString("X2"));
                        //    Debug.Print(string.Format("{0}   {1}_{2}", string.Join(",", ls), desEndPoint.Address.ToString(), desEndPoint.Port.ToString()));
                        //}
                        while (udpDoor.Available > 0)
                        {
                            byte[] data = udpDoor.Receive(ref refEndPoint);
                            if (refEndPoint.Address.ToString() == desEndPoint.Address.ToString())
                            {
                                recDataBuffer.AddRange(data);
                            }
                        }
                        #region 充电桩处的agv掉线处理
                        if (Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv > 0)
                        {
                            try
                            {
                                if (Common.maiDict[Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv].State == (int)Enumerations.AgvStatus.disConnection && Common.maiDict[Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv].Rfid < 0)
                                {
                                    if (Common.Instance.dtChargeInfo[this.ChargerNo].State == (int)EChargeCommState.Output)
                                        WriteChargeOperate(EChargeOperate.Input);
                                }
                            }
                            catch { }
                        }
                        #endregion
                        #region 解析数据尚未编写
                        if (recDataBuffer.Count >= this.dataLength)
                        {
                            List<byte> _resultData = new List<byte>();
                            int d0xfb = -1;
                            while (this.recDataBuffer.Count > this.dataLength * 2)
                            {
                                this.recDataBuffer.RemoveRange(0, this.recDataBuffer.Count - this.dataLength * 2);
                            }
                            for (int i = 0; i < this.recDataBuffer.Count; i++)
                            {
                                if (this.recDataBuffer[i] == 0xfb && i <= this.recDataBuffer.Count - this.dataLength)
                                {
                                    if (this.recDataBuffer[i + this.dataLength - 1] == 0x5a && this.recDataBuffer[i + 1] == this.dataLength)
                                    {
                                        d0xfb = i;
                                    }
                                }
                            }
                            if (d0xfb >= 0)
                            {
                                if (this.recDataBuffer[d0xfb + 4] * 256 + this.recDataBuffer[d0xfb + 5] == this.ChargerNo)
                                {
                                    for (int j = d0xfb; j < d0xfb + this.dataLength; j++)
                                    {
                                        _resultData.Add(this.recDataBuffer[j]);
                                    }
                                    this.recDataBuffer.RemoveRange(0, d0xfb + this.dataLength);
                                }
                                else
                                {
                                    this.recDataBuffer.RemoveRange(0, d0xfb);
                                }
                            }
                            if (_resultData.Count == this.dataLength)  //读取正确
                            {
                                if (CRCRecData(_resultData.ToArray()))
                                {
                                    byte[] recData = new byte[_resultData.Count - 10];
                                    for (int i = 0; i < recData.Length; i++)
                                    {
                                        recData[i] = _resultData[i + 7];
                                    }
                                    //解析数据 
                                    this.lastRecDataTime = DateTime.Now;
                                    switch (recData[2])
                                    {
                                        case 1:
                                            Common.Instance.dtChargeInfo[this.ChargerNo].State = (int)EChargeCommState.Output;
                                            break;
                                        case 2:
                                            Common.Instance.dtChargeInfo[this.ChargerNo].State = (int)EChargeCommState.Input;
                                            break;
                                        case 3:
                                            Common.Instance.dtChargeInfo[this.ChargerNo].State = (int)EChargeCommState.Loading;
                                            break;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region 处于启用状态下，若无绑定agv，将其缩回
                        if (Common.Instance.dtChargeInfo[this.ChargerNo].State == (int)EChargeCommState.Output && (Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv <= 0 || Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv > 100) && Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.Enable)
                        {
                            WriteChargeOperate(EChargeOperate.Input);
                        }
                        #endregion
                    }

                    if (DateTime.Now.Subtract(lastRecDataTime).TotalSeconds > lineTime)
                    {
                        try
                        {
                            Common.Instance.dtChargeInfo[this.ChargerNo].State = (int)EChargeCommState.OffLine;
                        }
                        catch { }
                    }
                    if (Common.Instance.dtChargeInfo[this.ChargerNo].BindAgv <= 0 && Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.isLowComm == false)
                    {
                        Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.isLowComm = true;
                    }
                    for (int i = 0; i < 25; i++)
                    {//判断是否要降低通讯频率
                        if (i > 0)
                        {
                            if (Common.Instance.dtChargeInfo[this.ChargerNo].ChargeComm.isLowComm) Thread.Sleep(200);
                            else break;
                        }
                        else
                        {
                            Thread.Sleep(200);
                        }
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 写充电桩操作命令
        /// </summary>
        /// <param name="eChargeOperate">操作</param>
        /// <returns></returns>
        public bool WriteChargeOperate(EChargeOperate eChargeOperate)
        {
            try
            {
                byte[] sendData = CmdData((byte)eChargeOperate, length, new byte[] { (byte)(this.ChargerNo / 256), (byte)(this.ChargerNo % 256) });
                lock (lockObj)
                    udpDoor.Send(sendData, sendData.Length, desEndPoint);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 命令码组合
        /// </summary>
        /// <param name="cmd">命令码</param>
        /// <param name="length">数据长度</param>
        /// <param name="data">数据数组</param>
        /// <returns></returns>
        private byte[] CmdData(byte cmd, byte length, params byte[] data)
        {

            List<byte> lsData = new List<byte>();
            try
            {
                lsData.Add(0xfb);
                byte lengthData = (byte)(10 + length);
                lsData.Add(lengthData);
                lsData.AddRange(new byte[] { (byte)(this.ChargerNo / 256), (byte)(this.ChargerNo % 256) });
                lsData.AddRange(new byte[] { 0x00, 0x00 });
                lsData.Add(cmd);
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
        /// <summary>
        /// 门操作命令
        /// </summary>
        public enum EChargeOperate
        {
            /// <summary>
            /// 请求充电桩信息
            /// </summary>
            QueryData = 0x09,
            /// <summary>
            /// 请求伸出
            /// </summary>
            Output = 0x07,
            /// <summary>
            /// 请求缩进
            /// </summary>
            Input = 0x08,
        }
    }
}
