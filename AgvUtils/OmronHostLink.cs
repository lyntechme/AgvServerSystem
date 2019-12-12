using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace AgvPLCUtils
{
     /// <summary>
    /// HostLine标准fins通信协议读取数据(使用了串口转以太网的MOXA W2150A模块,RS232)
    /// </summary>
    public class OmronHostLink : PlcConnect
    {
        #region 变量
        UdpClient _udp;
        //TcpClient _tcpClient;
        /// <summary>
        /// 等待时间
        /// </summary>
        private static int sleeptime = 50;
        private static Mutex mut = new Mutex();
        private bool IsDisposed = false;
        private int LocalPort = 0;
        #endregion //变量
        /// <summary>
        /// 释放该对象
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //内部调用释放函数
        private void Dispose(bool Disposing)
        {
            //if (!IsDisposed)
            //{
            if (Disposing)
            {
                try
                {
                    this._udp.Close();
                }
                catch
                { }
            }
            //}
            //IsDisposed = true;
        }
        /// <summary>
        /// agv构造函数
        /// </summary>
        /// <param name="localPort">本地端口号</param>
        public OmronHostLink(int localPort)
        {
            this.LocalPort = localPort;
        }
        /// <summary>
        /// 析构函数
        /// </summary>
        ~OmronHostLink()
        {
            Dispose(false);
        }
        /// <summary>
        /// 读取Agv数据(Word)
        /// </summary>
        /// <param name="plcUnitNum">Plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据起始地址</param>
        /// <param name="length">数据长度</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>所读取数据，第一位数据为:1则读取成功</returns>
        public Byte[] WReadAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, int length, string strIP, int port)
        {
            string cmdStr = "@" + plcUnitNum.ToString("X2") +
                            "FA" + "F00000000" + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + "00" + length.ToString("X4");
            cmdStr += CheckHelper.AsciiXorToString(cmdStr, 0) + "*\r";
            int recDataLength = 27 + length * 4;
            Byte[] data = RecFins(cmdStr, strIP, port, recDataLength);
            return data;
        }

        /// <summary>
        /// 向Agv写入数据(Word)
        /// </summary>
        /// <param name="plcUnitNum">plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据起始地址</param>
        /// <param name="data">需要写入数组</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>true:写入成功
        ///          false:写入失败</returns>
        public bool WWriteAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, int[] data, string strIP, int port)
        {
            string strData = "";
            for (int i = 0; i < data.Length; i++)
            {
                strData += data[i].ToString("X4");
            }
            string cmdStr = "@" + plcUnitNum.ToString("X2") +
                            "FA" + "F00000000" + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + "00" + data.Length.ToString("X4") + strData;
            cmdStr += CheckHelper.AsciiXorToString(cmdStr, 0) + "*\r";
            bool x = SendFins(cmdStr, strIP, port);
            return x;
        }

        /// <summary>
        /// 读取Agv数据(Bit)
        /// </summary>
        /// <param name="plcUnitNum">plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据区地址</param>
        /// <param name="bit">数据位地址</param>
        /// <param name="length">数据长度</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>所读取数据，第一位数据为:1则读取成功</returns>
        public Byte[] BReadAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, byte bit, int length, string strIP, int port)
        {
            string cmdStr = "@" + plcUnitNum.ToString("X2") +
                            "FA" + "000000000" + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + bit.ToString("X2") + length.ToString("X4");
            cmdStr += CheckHelper.AsciiXorToString(cmdStr, 0) + "*\r";
            int recDataLength = 27 + length * 2;
            Byte[] data = RecFins(cmdStr, strIP, port, recDataLength);
            return data;
        }

        /// <summary>
        /// 向Agv写入数据(Bit)
        /// </summary>
        /// <param name="plcUnitNum">plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据区地址</param>
        /// <param name="bit">数据位地址</param>
        /// <param name="data">需要写入数组</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>true:写入成功
        ///          false:写入失败</returns>
        public bool BWriteAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, byte bit, byte[] data, string strIP, int port)
        {
            string strData = "";
            for (int i = 0; i < data.Length; i++)
            {
                strData += data[i].ToString("X2");
            }
            string cmdStr = "@" + plcUnitNum.ToString("X2") +
                            "FA" + "000000000" + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + bit.ToString("X2") + data.Length.ToString("X4") + strData;
            cmdStr += CheckHelper.AsciiXorToString(cmdStr, 0) + "*\r";
            bool x = SendFins(cmdStr, strIP, port);
            return x;
        }

        #region udpFins
        #region HostLink-Fins读取数据函数
        /// <summary>
        /// HostLink-Fins读取PLC数据函数
        /// </summary>
        /// <param name="recCmd">读取命令字符串</param>
        /// <param name="ipadress">目的PLC的ip地址</param>
        /// <param name="port">目的PLC的端口号</param>
        /// <returns>反馈数据或读取失败提示码</returns>
        private Byte[] RecFins(string recCmd, string ipadress, int port,int recDataLength)
        {
            Byte[] error = new Byte[1];
            error[0] = 0;
            try
            {
                //int recDataLength = 
                Byte[] recData = UDPconnect(recCmd, ipadress, port, recDataLength);
                if (recData[1] == 255 && recData.Length == 2)
                {
                    return error;
                }
                else
                {
                    string recStr = Encoding.Default.GetString(recData);   //字节转换string
                    string[] rec = recStr.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rec[0].Substring(rec[0].Length - 2, 2) != CheckHelper.AsciiXorToString(rec[0].Substring(0, rec[0].Length - 2), 0))  //校验判断
                    {
                        return error;
                    }
                    if (rec[0][0] != '@')  //标识符判断
                    {
                        return error;
                    }
                    if (rec[0].Substring(19, 4) != "0000")  //通讯是否正确判断
                    {
                        return error;
                    }
                    string data = rec[0].Substring(23, rec[0].Length - 25);  //提取反馈数据
                    if (data.Length % 2 != 0)
                    {
                        return error;
                    }
                    byte[] results = new byte[data.Length / 2 + 1];  //格式转换
                    results[0] = 1;
                    int j =1;
                    for (int i = 0; i < data.Length; i += 2)
                    {
                        byte item = Convert.ToByte(data.Substring(i, 2), 16);
                        results[j] = item;
                        j++;
                    }
                    return results;
                }
                //return recData;
            }
            catch
            {
                return error;
            }
            finally
            {
            }
        }
        #endregion

        #region HostLink-Fins命令向PLC写入数据函数
        /// <summary>
        /// HostLink-Fins命令向PLC写入数据函数
        /// </summary>
        /// <param name="sendCmd">写入命令字符串</param>
        /// <param name="ipadress">目的PLC的ip地址</param>
        /// <param name="port">目的PLC的端口号</param>
        /// <returns>反馈写入是否成功</returns>
        private bool SendFins(string sendCmd, string ipadress, int port)
        {
            try
            {
                int recDataLength = 27;
                Byte[] recData = UDPconnect(sendCmd, ipadress, port, recDataLength);
                if (recData[1] == 255 && recData.Length == 2)
                {
                    return false;
                }
                else
                {
                    string recStr = Encoding.Default.GetString(recData);
                    string[] rec = recStr.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rec[0].Substring(rec[0].Length - 2, 2) != CheckHelper.AsciiXorToString(rec[0].Substring(0, rec[0].Length - 2), 0))
                    {
                        return false;
                    }
                    if (rec[0].Substring(rec[0].Length - 6, 4) != "0000")
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 通过UDP与PLC通信，并接收反馈值
        /// <summary>
        /// 通过UDP与PLC通信，并接收反馈值
        /// </summary>
        /// <param name="cmd">通信命令字符串</param>
        /// <param name="ipaddress">目的ip地址</param>
        /// <param name="port">目的端口号</param>
        /// <param name="recDataLength">接收长度</param>
        /// <returns></returns>
        private Byte[] UDPconnect(string cmd, string ipaddress, int port,int recDataLength)
        {
            //Mutex mut = new Mutex();
            //mut.WaitOne();
            Byte[] data;
            try
            {
                this._udp = new UdpClient(this.LocalPort);                
                data = System.Text.Encoding.ASCII.GetBytes(cmd);
                IPEndPoint sIep = new IPEndPoint(IPAddress.Parse(ipaddress), port);
                this._udp.Connect(sIep);
                this._udp.Send(data, data.Length);
                DateTime now = DateTime.Now;
                bool isReadRight = true;
                List<byte> recls = new List<byte>();
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, 0);
                while (recls.Count < recDataLength)
                {
                    if (this._udp.Available > 0)
                    {
                        byte[] _data = this._udp.Receive(ref iep);
                        if (_data.Length > 0 && iep.ToString() == sIep.ToString())
                        {
                            recls.AddRange(_data);
                        }
                    }
                    Thread.Sleep(5);
                    if ((DateTime.Now - now).TotalSeconds > 1)
                    {
                        isReadRight = false;
                        break;
                    }
                }
                if (isReadRight)
                {
                    data = recls.ToArray();
                    recls.Clear();
                }
                else
                {
                    byte[] error = { 0, 255 };
                    data = error;
                }
                //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                this.Dispose();
            }
            catch
            {
                Thread.Sleep(300);
                this.Dispose();
                Byte[] error = { 0, 255 };
                data = error;
            }
            //mut.ReleaseMutex();
            return data;
        }
        #endregion
        #endregion //udpFins

        #region UDP
        #region 定义通讯地址
        private IPEndPoint UdpPoint(string ipadress, int port)
        {
            IPAddress myip = IPAddress.Parse(ipadress);
            IPEndPoint mypoint = new IPEndPoint(myip, port);
            return mypoint;
        }
        #endregion
        #endregion //UDP
    }
}
