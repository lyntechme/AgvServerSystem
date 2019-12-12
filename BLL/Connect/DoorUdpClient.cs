using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 房门通讯
    /// </summary>
    public class DoorUdpClient
    {
        /// <summary>
        /// 房门通讯集合
        /// </summary>
        public static Dictionary<int, DoorUdpClient> dtDoorUdp = new Dictionary<int, DoorUdpClient>();
        #region 属性
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
        /// 房门编号
        /// </summary>
        private int DoorNo;
        /// <summary>
        /// 发送命令数据的长度
        /// </summary>
        private byte length = 9;
        /// <summary>
        /// 发送互斥锁
        /// </summary>
        public object lockObj = new object();
        /// <summary>
        /// 获取的房门数据
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
        /// 掉线判断Time   s
        /// </summary>
        private int lineTime = 15;
        /// <summary>
        /// 
        /// </summary>
        private DateTime lastRecDataTime = new DateTime();
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public DoorUdpClient(int doorNo)
        {
            this.DoorNo = doorNo;
            if (Common.Instance.dtDoorInfo.ContainsKey(doorNo))
            {
                desEndPoint = new IPEndPoint(IPAddress.Parse(Common.Instance.dtDoorInfo[doorNo].DoorComm.Ip), Common.Instance.dtDoorInfo[doorNo].DoorComm.Port);
                udpDoor = new UdpClient(Common.Instance.dtDoorInfo[doorNo].DoorComm.Port);
            }

            refEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }
        #endregion
        /// <summary>
        /// 读取房门当前状态信息
        /// </summary>
        public void ReadDoorInformation()
        {
            while (true)
            {
                try
                {
                    if (Common.Instance.dtDoorInfo[DoorNo].DoorComm.Enable)//该房门是否启用
                    {
                        byte[] sendData = CmdData((byte)EDoorOperate.QueryData, length);
                        lock (lockObj)
                            udpDoor.Send(sendData, sendData.Length, this.desEndPoint);
                        Thread.Sleep(50);
                        while (udpDoor.Available > 0)
                        {
                            byte[] data = udpDoor.Receive(ref refEndPoint);
                            if (refEndPoint.Address.ToString() == desEndPoint.Address.ToString())
                            {
                                recDataBuffer.AddRange(data);
                            }
                        }
                        #region 解析数据
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
                                if (this.recDataBuffer[d0xfb + 4] * 256 + this.recDataBuffer[d0xfb + 5] == this.DoorNo)
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
                                    if (Common.Instance.dtDoorInfo[DoorNo].Relation > 0)
                                    {
                                        int relationNo = Common.Instance.dtDoorInfo[DoorNo].Relation;
                                        if (Common.Instance.dtDoorInfo[DoorNo].RelationNumber == 1)
                                        {
                                            switch (recData[2])
                                            {
                                                case 0:
                                                    Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Loading;
                                                    break;
                                                case 1:
                                                    Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Close;
                                                    break;
                                                case 2:
                                                    Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Open;
                                                    break;
                                            }
                                            Common.Instance.dtDoorInfo[DoorNo].HoldSwitch = recData[3] == 0 ? false : true;
                                            try
                                            {
                                                switch (recData[4])
                                                {
                                                    case 0:
                                                        Common.Instance.dtDoorInfo[relationNo].State = (int)DoorInfo.EDoorState.Loading;
                                                        break;
                                                    case 1:
                                                        Common.Instance.dtDoorInfo[relationNo].State = (int)DoorInfo.EDoorState.Close;
                                                        break;
                                                    case 2:
                                                        Common.Instance.dtDoorInfo[relationNo].State = (int)DoorInfo.EDoorState.Open;
                                                        break;
                                                }
                                                Common.Instance.dtDoorInfo[relationNo].HoldSwitch = recData[5] == 0 ? false : true;
                                            }
                                            catch { }
                                        }
                                        else
                                        {
                                            switch (recData[4])
                                            {
                                                case 0:
                                                    Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Loading;
                                                    break;
                                                case 1:
                                                    Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Close;
                                                    break;
                                                case 2:
                                                    Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Open;
                                                    break;
                                            }
                                            Common.Instance.dtDoorInfo[DoorNo].HoldSwitch = recData[5] == 0 ? false : true;
                                            try
                                            {
                                                switch (recData[2])
                                                {
                                                    case 0:
                                                        Common.Instance.dtDoorInfo[relationNo].State = (int)DoorInfo.EDoorState.Loading;
                                                        break;
                                                    case 1:
                                                        Common.Instance.dtDoorInfo[relationNo].State = (int)DoorInfo.EDoorState.Close;
                                                        break;
                                                    case 2:
                                                        Common.Instance.dtDoorInfo[relationNo].State = (int)DoorInfo.EDoorState.Open;
                                                        break;
                                                }
                                                Common.Instance.dtDoorInfo[relationNo].HoldSwitch = recData[3] == 0 ? false : true;
                                            }
                                            catch { }
                                        }
                                    }
                                    else
                                    {
                                        switch (recData[2])
                                        {
                                            case 0:
                                                Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Loading;
                                                break;
                                            case 1:
                                                Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Close;
                                                break;
                                            case 2:
                                                Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.Open;
                                                break;
                                        }
                                        Common.Instance.dtDoorInfo[DoorNo].HoldSwitch = recData[3] == 0 ? false : true;
                                    }
                                    lastRecDataTime = DateTime.Now;
                                }
                            }
                        }
                        #endregion
                    }
                }
                catch { }
                if (DateTime.Now.Subtract(lastRecDataTime).TotalSeconds > lineTime)
                {
                    try
                    {
                        Common.Instance.dtDoorInfo[DoorNo].State = (int)DoorInfo.EDoorState.OffLine;
                        if (Common.Instance.dtDoorInfo[DoorNo].Relation > 0)
                        {
                            int relationNo = Common.Instance.dtDoorInfo[DoorNo].Relation;
                            Common.Instance.dtDoorInfo[relationNo].State = (int)DoorInfo.EDoorState.OffLine;
                        }
                    }
                    catch { }
                }
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// 写房门操作命令
        /// </summary>
        /// <param name="eDoorOperate">操作</param>
        /// <param name="relationNumber">有关联的门，是左门还是右门</param>
        /// <returns></returns>
        public bool WriteDoorOperate(EDoorOperate eDoorOperate, byte relationNumber)
        {
            try
            {
                byte[] sendData = CmdData((byte)eDoorOperate, length, new byte[] { (byte)(DoorNo / 256), (byte)(DoorNo % 256), relationNumber });
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
                lsData.AddRange(new byte[] { (byte)(DoorNo / 256), (byte)(DoorNo % 256) });
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
        public enum EDoorOperate
        {
            /// <summary>
            /// 请求房门信息
            /// </summary>
            QueryData = 0x05,
            /// <summary>
            /// 请求门开
            /// </summary>
            Open = 0x03,
            /// <summary>
            /// 请求门闭
            /// </summary>
            Close = 0x04,
        }
    }
}
