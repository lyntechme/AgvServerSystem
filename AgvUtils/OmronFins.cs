using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections.Generic;

namespace AgvPLCUtils
{
    /// <summary>
    /// fins通信协议读取数据(使用了PLC以太网通讯接口)
    /// </summary>
    public class OmronFins : PlcConnect
    {
        #region 变量
        UdpClient _udp;
        /// <summary>
        /// 等待时间
        /// </summary>
        private static int sleeptime = 50;
        private int LocalPort = 0;
        /// <summary>
        /// 连接次数
        /// </summary>
        private int LinkNo = 0;
        private IPEndPoint ipEndPoint;
        #endregion //变量
        ///// <summary>
        ///// 释放该对象
        ///// </summary>
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        ////内部调用释放函数
        //private void Dispose(bool Disposing)
        //{
        //    //if (!IsDisposed)
        //    //{
        //    if (Disposing)
        //    {
        //        try
        //        {
        //            this._udp.Close();
        //        }
        //        catch
        //        { }
        //    }
        //    //}
        //    //IsDisposed = true;
        //}
        /// <summary>
        /// agv构造函数
        /// </summary>
        /// <param name="localPort">本地端口号</param>
        /// <param name="ipAddress">agv IP地址</param>
        /// <param name="desPort">agv 端口号</param>
        public OmronFins(int localPort, string ipAddress, int desPort)
        {
            this.LocalPort = localPort;
            this._udp = new UdpClient(this.LocalPort);
            this.ipEndPoint = UdpPoint(ipAddress, desPort);
        }
        ///// <summary>
        ///// 析构函数
        ///// </summary>
        //~OmronFins()
        //{
        //    Dispose(false);
        //}
        /// <summary>
        /// 读取Agv数据(Word)
        /// </summary>
        /// <param name="agvNetNum">Agv网络编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据起始地址</param>
        /// <param name="length">数据长度</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>所读取数据，第一位数据为:1则读取成功</returns>
        public Byte[] WReadAgv(int agvNetNum, string strAgvControlCmd, string strAgvRamCmd, int origin, int length, string strIP, int port)
        {
            string cmdStr = CCmdCode.icf + CCmdCode.rsv + CCmdCode.gct +
                            CCmdCode.dna + agvNetNum.ToString("X2") + CCmdCode.da2 +
                            CCmdCode.sna + "FB" + CCmdCode.sa2 +
                            CCmdCode.sid + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + "00" + length.ToString("X4");
            Byte[] data = RecFins(cmdStr, strIP, port);
            return data;
        }

        /// <summary>
        /// 向Agv写入数据(Word)
        /// </summary>
        /// <param name="agvNetNum">Agv网络编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据起始地址</param>
        /// <param name="data">需要写入数组</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>true:写入成功
        ///          false:写入失败</returns>
        public bool WWriteAgv(int agvNetNum, string strAgvControlCmd, string strAgvRamCmd, int origin, int[] data, string strIP, int port)
        {
            string strData = "";
            for (int i = 0; i < data.Length; i++)
            {
                strData += data[i].ToString("X4");
            }
            string cmdStr = CCmdCode.icf + CCmdCode.rsv + CCmdCode.gct +
                            CCmdCode.dna + agvNetNum.ToString("X2") + CCmdCode.da2 +
                            CCmdCode.sna + "FB" + CCmdCode.sa2 +
                            CCmdCode.sid + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + "00" + data.Length.ToString("X4") + strData;
            bool x = SendFins(cmdStr, strIP, port);
            return x;
        }

        /// <summary>
        /// 读取Agv数据(Bit)
        /// </summary>
        /// <param name="agvNetNum">Agv网络编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据区地址</param>
        /// <param name="bit">数据位地址</param>
        /// <param name="length">数据长度</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>所读取数据，第一位数据为:1则读取成功</returns>
        public Byte[] BReadAgv(int agvNetNum, string strAgvControlCmd, string strAgvRamCmd, int origin, byte bit, int length, string strIP, int port)
        {
            string cmdStr = CCmdCode.icf + CCmdCode.rsv + CCmdCode.gct +
                            CCmdCode.dna + agvNetNum.ToString("X2") + CCmdCode.da2 +
                            CCmdCode.sna + "10" + CCmdCode.sa2 +
                            CCmdCode.sid + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + bit.ToString("X2") + length.ToString("X4");
            Byte[] data = RecFins(cmdStr, strIP, port);
            return data;
        }

        /// <summary>
        /// 向Agv写入数据(Bit)
        /// </summary>
        /// <param name="agvNetNum">Agv网络编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据区地址</param>
        /// <param name="bit">数据位地址</param>
        /// <param name="data">需要写入数组</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>true:写入成功
        ///          false:写入失败</returns>
        public bool BWriteAgv(int agvNetNum, string strAgvControlCmd, string strAgvRamCmd, int origin, byte bit, byte[] data, string strIP, int port)
        {
            string strData = "";
            for (int i = 0; i < data.Length; i++)
            {
                strData += data[i].ToString("X2");
            }
            string cmdStr = CCmdCode.icf + CCmdCode.rsv + CCmdCode.gct +
                            CCmdCode.dna + agvNetNum.ToString("X2") + CCmdCode.da2 +
                            CCmdCode.sna + "10" + CCmdCode.sa2 +
                            CCmdCode.sid + strAgvControlCmd + strAgvRamCmd +
                            origin.ToString("X4") + bit.ToString("X2") + data.Length.ToString("X4") + strData;
            bool x = SendFins(cmdStr, strIP, port);
            return x;
        }

        #region udpFins
        #region fins读取数据函数
        /// <summary>
        /// fins读取PLC数据函数
        /// </summary>
        /// <param name="recCmd">读取命令字符串</param>
        /// <param name="ipadress">目的PLC的ip地址</param>
        /// <param name="port">目的PLC的端口号</param>
        /// <returns>反馈数据或读取失败提示码</returns>
        private Byte[] RecFins(string recCmd, string ipadress, int port)
        {
            Byte[] error = new Byte[1];
            error[0] = 0;
            try
            {
                Byte[] recData = UDPconnect(recCmd, ipadress, port);
                if (recData[1] == 255 && recData.Length == 2)
                {
                    return error;
                }
                else
                {

                    if (recData[12] == 0 && recData[13] == 0)
                    {
                        Byte[] data = new Byte[recData.Length - 13];
                        data[0] = 1;
                        for (int i = 1; i < (recData.Length - 13); i++)
                        {
                            data[i] = recData[13 + i];
                        }
                        return data;
                    }
                    else
                    {
                        try
                        {
                            LogUtils.SaveLog(BitConverter.ToString(recData) + " " + ipadress);
                        }
                        catch { }
                        return error;
                    }
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

        #region fins命令向PLC写入数据函数
        /// <summary>
        /// fins命令向PLC写入数据函数
        /// </summary>
        /// <param name="sendCmd">写入命令字符串</param>
        /// <param name="ipadress">目的PLC的ip地址</param>
        /// <param name="port">目的PLC的端口号</param>
        /// <returns>反馈写入是否成功</returns>
        private bool SendFins(string sendCmd, string ipadress, int port)
        {
            try
            {
                Byte[] recData = UDPconnect(sendCmd, ipadress, port);
                if (recData[1] == 255 && recData.Length == 2)
                {
                    return false;
                }
                else
                {
                    if ((recData[12] == 0) && (recData[13] == 0) && (recData.Length == 14))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
        /// <returns></returns>
        private Byte[] UDPconnect(string cmd, string ipaddress, int port)
        {
            Byte[] data;
            try
            {
                //this._udp = new UdpClient(this.LocalPort);
                if (UdpSend(cmd, ipaddress, port))
                {
                    Thread.Sleep(sleeptime);
                    Byte[] recData = UdpRecive(ipaddress);
                    data = recData;
                    //return recData;
                }
                else
                {
                    Byte[] error = { 0, 255 };
                    data = error;
                    //return error;
                }
            }
            catch
            {
                Byte[] error = { 0, 255 };
                data = error;
            }
            //this.Dispose();
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


        #region 使用UDP发送数据函数-重载字符串
        /// <summary>
        /// 使用UDP发送数据函数
        /// </summary>
        /// <param name="sendData">准备发送的字符串</param>
        /// <param name="ipadress">目的设备的ip地址</param>
        /// <param name="port">目的设备的端口号</param>
        /// <returns>是否发送成功</returns>
        private bool UdpSend(string sendData, string ipadress, int port)
        {
            //UdpClient sock = new UdpClient();
            try
            {
                //if (UdpConn(ipadress, port))
                //{
                Byte[] bytes = new Byte[sendData.Length / 2];
                for (int i = 0; i < sendData.Length; i += 2)
                {
                    bytes[i / 2] = (byte)Convert.ToByte(sendData.Substring(i, 2), 16);
                }
                _udp.Send(bytes, bytes.Length, this.ipEndPoint);
                return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (SocketException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                //UdpClose();
            }
        }
        #endregion

        #region 使用UDP接收外部数据
        /// <summary>
        /// 使用UDP接收外部数据
        /// </summary>
        /// <param name="ipadress">用于判断外部设备的ip地址是否与预期相同</param>
        /// <returns>接收到的数据或接收失败信号</returns>
        private Byte[] UdpRecive(string ipadress)//string ipadress,int port)
        {

            //UdpClient sock = new UdpClient();
            try
            {
                bool isRec = false;
                while (isRec == false)
                {
                    if (_udp.Available == 0)
                    {
                        if (this.LinkNo >= 5)
                        {
                            this.LinkNo = 0;
                            isRec = true;
                        }
                        else
                        {
                            this.LinkNo++;
                            Thread.Sleep(100);
                        }
                    }
                    else
                    {
                        this.LinkNo = 0;
                        Byte[] recData = new Byte[_udp.Available];
                        IPEndPoint remoteP = new IPEndPoint(IPAddress.Any, 0);
                        recData = _udp.Receive(ref remoteP);
                        if (remoteP.Address.ToString() == ipadress)
                        {
                            return recData;
                        }
                        else
                        {
                            Byte[] errorData = new Byte[2];
                            errorData[0] = (byte)Convert.ToByte("01", 16);
                            errorData[1] = (byte)Convert.ToByte("FF", 16);
                            return errorData;
                        }
                    }
                }
                Byte[] noData = new Byte[2];
                noData[0] = (byte)Convert.ToByte("00", 16);
                noData[1] = (byte)Convert.ToByte("FF", 16);
                return noData;
            }
            catch (SocketException ex)
            {
                //MessageBox.Show(ex.Message);
                Byte[] recError = new Byte[2];
                Byte ErrorCode = new Byte();
                ErrorCode = (byte)Convert.ToByte("FF", 16);
                recError[0] = ErrorCode;
                recError[1] = (byte)ex.ErrorCode;
                return recError;
            }
            finally
            {
                //UdpClose();
            }
        }
        #endregion

        #region 关闭UDP的socket句柄
        /// <summary>
        /// 关闭UDP的socket句柄
        /// </summary>
        private void UdpClose()
        {
            //UdpClient sock = new UdpClient();
            this._udp.Close();
        }
        #endregion
        #endregion //UDP
    }
}
