using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Model
{
    public class MitsubishiPLC
    {
        #region 变量
        /// <summary>
        /// 是否开始读取数据
        /// </summary>
        private bool isReadData = false;
        /// <summary>
        /// udp通讯
        /// </summary>
        private UdpClient udpPlc;
        /// <summary>
        /// 网络节点
        /// </summary>
        private IPEndPoint ipendpoint;
        /// <summary>
        /// 接收网络节点
        /// </summary>
        private IPEndPoint recIpEndPoint;
        /// <summary>
        /// ip地址
        /// </summary>
        private string ipStr = "192.168.3.38";
        /// <summary>
        /// 端口号
        /// </summary>
        private int port = 10050;
        /// <summary>
        /// 读写互斥锁
        /// </summary>
        public static object lockObj = new object();
        /// <summary>
        /// 在线判断时间
        /// </summary>
        private DateTime lineTime;
        /// <summary>
        /// 在线判断计数，大于10000重置
        /// </summary>
        private int lineCount = 0;
        /// <summary>
        /// connect
        /// </summary>
        private int connectCount = 0;
        /*
         * 50 00 00 ff ff 03 00 0c 00 10 00 	01 04 00 00 01 00 00 a8 02 00
           01 04 读字
           a8   D区
           01 00 00  //第一个字
           02 00 读D1后两个字

           D0 00 00 ff ff 03 00 06 00 【00 00 01 00 02 00】
           06 00 是响应数据长度【】里的字节
           00 00 是结束代码
           01 00 读取的第一个字
           02 00 读取的第二个字 


           50 00 00 ff ff 03 00 0e 00 【 10 00 	01 14 00 00 03 00 00 a8 01 00 05 00 】往D3写入5  
                     ↓
           0e 00  数据长度【】里的字节
           01 14  写字
           01 00  往D3后写入的长度

           D0 00 00 ff ff 03 00 02 00 00 00
         */
        /// <summary>
        /// 读取数据命令串
        /// </summary>
        private List<byte> lsReadCmd = new List<byte>();
        /// <summary>
        /// 读取数据集合
        /// </summary>
        private List<int> lsReadData = new List<int>();
        /// <summary>
        /// 读取数据时的互斥锁，避免数据异常
        /// </summary>
        private object lockObjRead = new object();
        /// <summary>
        /// 写入数据命令串
        /// </summary>
        private List<byte> WriteCmd = new List<byte>();
        #endregion
        #region 初始化
        public MitsubishiPLC()
        {
            this.lineTime = DateTime.Now;
            string[] ss = new string[] { "192.168.1.1", "9600" };
            if (ss.Length == 2)
            {
                try
                {
                    IPAddress.Parse(ss[0]);
                    ipStr = ss[0];
                    port = Convert.ToInt32(ss[1]);
                }
                catch { }
            }
            udpPlc = new UdpClient(6000);
            ipendpoint = new IPEndPoint(IPAddress.Parse(ipStr), port);
            recIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            lsReadCmd.AddRange(new byte[] { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0c, 0x00, 0x10, 0x00, 0x01, 0x04, 0x00, 0x00, 0x01, 0x00, 0x00, 0xa8, 0x02, 0x00 });
            WriteCmd.AddRange(new byte[] { 0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 0x00, 0x0c, 0x00, 0x10, 0x00, 0x01, 0x14, 0x00, 0x00, 0x03, 0x00, 0x00, 0xa8, 0x01, 0x00 });

        }
        #endregion
        #region 读取操作
        /// <summary>
        /// 设定读取寄存器
        /// </summary>
        /// <param name="orea">寄存器类型</param>
        public void setReadOrea(oreaType orea)
        {
            try
            {
                lsReadCmd[18] = (byte)orea;
            }
            catch { }
        }
        /// <summary>
        /// 设定读取长度
        /// </summary>
        /// <param name="length">数据长度</param>
        public void setReadLength(int length)
        {
            try
            {
                byte lowBit = (byte)(length % 256);  //高位，当长度大于等于256时
                byte highBit = (byte)(length / 256);  //低位
                lsReadCmd[19] = lowBit;
                lsReadCmd[20] = highBit;
            }
            catch { }
        }
        /// <summary>
        /// 获取当前读取数据的长度
        /// </summary>
        /// <returns></returns>
        public int getReadLength()
        {
            try
            {
                return lsReadCmd[20] * 256 + lsReadCmd[19];
            }
            catch
            {
                return -1;
            }

        }
        /// <summary>
        /// 设定读取起始位
        /// </summary>
        /// <param name="orgin">起始地址</param>
        public void setReadOrgin(int orgin)
        {
            try
            {
                byte lowBit = (byte)(orgin % 256);  //高位
                byte highBit = (byte)(orgin / 256 % 256);  //低位
                byte hhighBit = (byte)(orgin / 256 / 256);
                lsReadCmd[15] = lowBit;
                lsReadCmd[16] = highBit;
                lsReadCmd[17] = hhighBit;
            }
            catch { }
        }
        /// <summary>
        /// 获取当前读取数据的起始地址
        /// </summary>
        /// <returns></returns>
        public int getReadOrgin()
        {
            try
            {
                return lsReadCmd[16] * 256 + lsReadCmd[15];
            }
            catch { return -1; }
        }
        /// <summary>
        /// 执行循环读取数据
        /// </summary>
        public void setReadStart()
        {
            if (isReadData == false)
            {
                isReadData = true;
                ReadMitsubishiPLCData();
            }
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="orea">寄存器类型</param>
        /// <param name="orgin">起始地址</param>
        /// <param name="length">读取长度</param>
        public void setReadStart(oreaType orea, int orgin, int length)
        {
            try
            {
                if (isReadData == false)
                {
                    isReadData = true;
                    lsReadCmd[18] = (byte)orea;

                    byte highBitO = (byte)(orgin % 256);  //高位
                    byte lowBitO = (byte)(orgin / 256);  //低位
                    lsReadCmd[15] = lowBitO;
                    lsReadCmd[16] = highBitO;

                    byte highBit = (byte)(length % 256);  //高位，当长度大于等于256时
                    byte lowBit = (byte)(length / 256);  //低位
                    lsReadCmd[19] = lowBit;
                    lsReadCmd[20] = highBit;

                    ReadMitsubishiPLCData();
                }
            }
            catch { }
        }
        /// <summary>
        /// 停止读取数据
        /// </summary>
        public void setReadStop()
        {
            isReadData = false;
        }
        /// <summary>
        /// 获取当前读取状态（true为正在循环读取）
        /// </summary>
        /// <returns></returns>
        public bool getReadState()
        {
            return isReadData;
        }
        /// <summary>
        /// 谋取数据数组
        /// </summary>
        /// <returns></returns>
        public int[] getReadData()
        {
            try
            {
                lock (lockObjRead)
                    return lsReadData.ToArray();
            }
            catch { return new int[] { -1 }; }
        }
        /// <summary>
        /// 读取三菱PLC数据
        /// </summary>
        public void ReadMitsubishiPLCData()
        {
            bool connect = false;
            while (isReadData)
            {
                try
                {
                    byte[] readCmdBytes = lsReadCmd.ToArray();

                    lock (lockObj)
                    {
                        #region 在线判断
                        if (DateTime.Now.Subtract(lineTime).TotalSeconds > 30)  //在线判断
                        {
                            if (lineCount > 10000) lineCount = 0;
                            else lineCount++;
                            setWriteOrea(oreaType.OreaD);
                            setWriteData(new int[] { lineCount });
                            setWriteOrgin(210);
                            WriteMitsubishiPLC();
                            lineTime = DateTime.Now;
                            Thread.Sleep(50);
                        }
                        #endregion
                        udpPlc.Send(readCmdBytes, readCmdBytes.Length, ipendpoint);
                        string ss = string.Empty;
                        foreach (int item in readCmdBytes)
                        {
                            ss += item.ToString("X2") + ",";
                        }
                        Thread.Sleep(50);
                        if (udpPlc.Available > 0)
                        {
                            byte[] data = udpPlc.Receive(ref recIpEndPoint);
                            if (data[0] == 0xd0 && data[1] == 0x00 && data[2] == 0x00 && data[3] == 0xff && data[4] == 0xff && data[5] == 0x03 && data[6] == 0x00)
                            {
                                connect = true;
                                int length = data[8] * 256 + data[7];
                                if (length > 2)
                                {
                                    if (data[9] == 0x00 && data[10] == 0x00)//错误代码,0x00,0x00为回传正确
                                    {
                                        if (data.Length == length + 9) //判断长度是否正确
                                        {
                                            lock (lockObjRead)
                                            {
                                                lsReadData.Clear();
                                                for (int i = 11; i < data.Length; i = i + 2)
                                                {
                                                    lsReadData.Add(data[i + 1] * 256 + data[i]);
                                                }
                                                #region 数据解析 现长度为50，即从D200-D249
                                                if (Common.Instance.passEnable)
                                                {
                                                    Common.Instance.dtRoutePass[RouteType.CapacityLoad].InEnable = true;
                                                }
                                                else
                                                {
                                                    Common.Instance.dtRoutePass[RouteType.CapacityLoad].InEnable = lsReadData[11] == 1 ? true : false;
                                                    Common.Instance.dtRoutePass[RouteType.CapacityLoad].OutPass = lsReadData[12] == 1 ? true : false;
                                                }
                                                Common.Instance.dtRoutePass[RouteType.CapacityLoad].QueryBack = lsReadData[4] == 1 ? true : false;
                                                Common.Instance.dtRoutePass[RouteType.CapacityLoad].TaskBask = lsReadData[0];
                                                Common.Instance.dtRoutePass[RouteType.CapacityLoad].stationNo = lsReadData[2];
                                                if (Common.Instance.passEnable)
                                                {
                                                    Common.Instance.dtRoutePass[RouteType.CapacityUnload].InEnable = true;
                                                }
                                                else
                                                {
                                                    Common.Instance.dtRoutePass[RouteType.CapacityUnload].InEnable = lsReadData[13] == 1 ? true : false;
                                                    Common.Instance.dtRoutePass[RouteType.CapacityUnload].OutPass = lsReadData[14] == 1 ? true : false;
                                                }
                                                Common.Instance.dtRoutePass[RouteType.CapacityUnload].QueryBack = lsReadData[5] == 1 ? true : false;
                                                Common.Instance.dtRoutePass[RouteType.CapacityUnload].TaskBask = lsReadData[1];
                                                Common.Instance.dtRoutePass[RouteType.CapacityUnload].stationNo = lsReadData[3];
                                                for (int i = 0; i < 16; i++)  //工位允许状态
                                                {
                                                    //int j = i + 16;
                                                    //if (Common.Instance.passEnable)
                                                    //{
                                                    //    Common.Instance.dtBatteryTestWorkStationState[i + 1] = true;
                                                    //}
                                                    //else
                                                    //{
                                                    //    Common.Instance.dtBatteryTestWorkStationState[i + 1] = ((lsReadData[40] >> i) & 1) == 1 ? false : true;
                                                    //}
                                                    //if (j + 1 <= 30)
                                                    //{
                                                    //    if (Common.Instance.passEnable)
                                                    //    {
                                                    //        Common.Instance.dtBatteryTestWorkStationState[j + 1] = true;
                                                    //    }
                                                    //    else
                                                    //    {
                                                    //        Common.Instance.dtBatteryTestWorkStationState[j + 1] = ((lsReadData[41] >> i) & 1) == 1 ? false : true;
                                                    //    }
                                                    //}
                                                }

                                                #endregion
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(20);
                }
                catch { }
                if (connect == false)
                {
                    if (connectCount > 10000)
                    {
                        connectCount = 100;
                    }
                    else
                        connectCount++;
                }
                //if (connectCount > 30)
                //{
                //    Common.Instance.isConnectMes = false;
                //}
                //else
                //{
                //    Common.Instance.isConnectMes = true;
                //}
            }
        }
        #endregion
        #region 写入操作
        /// <summary>
        /// 设定写入寄存器
        /// </summary>
        /// <param name="orea">寄存器类型</param>
        public void setWriteOrea(oreaType orea)
        {
            try
            {
                WriteCmd[18] = (byte)orea;
            }
            catch { }
        }
        /// <summary>
        /// 设定写入数据数组
        /// </summary>
        /// <param name="length">数据数组</param>
        public void setWriteData(int[] data)
        {
            try
            {
                int length = data.Length;
                byte lowBit = (byte)(length % 256);  //高位，当长度大于等于256时
                byte highBit = (byte)(length / 256);  //低位
                WriteCmd[19] = lowBit;
                WriteCmd[20] = highBit;
                int lengthByte = data.Length * 2 + 12;
                byte lowByteBit = (byte)(lengthByte % 256);  //字节长度，高位
                byte highByteBit = (byte)(lengthByte / 256);
                WriteCmd[7] = lowByteBit;
                WriteCmd[8] = highByteBit;
                List<byte> ls = new List<byte>();
                for (int i = 0; i < data.Length; i++)
                {
                    byte low = (byte)(data[i] % 256);
                    byte high = (byte)(data[i] / 256);
                    ls.Add(low);
                    ls.Add(high);
                }
                if (WriteCmd.Count > 21)
                {
                    WriteCmd.RemoveRange(21, WriteCmd.Count - 21);
                }
                WriteCmd.AddRange(ls.ToArray());
            }
            catch { }
        }
        ///// <summary>
        ///// 获取当前读取数据的长度
        ///// </summary>
        ///// <returns></returns>
        //public int getReadLength()
        //{
        //    try
        //    {
        //        return lsReadCmd[20] * 256 + lsReadCmd[19];
        //    }
        //    catch
        //    {
        //        return -1;
        //    }

        //}
        /// <summary>
        /// 设定写入起始位
        /// </summary>
        /// <param name="orgin">起始地址</param>
        public void setWriteOrgin(int orgin)
        {
            try
            {
                byte lowBit = (byte)(orgin % 256);  //高位
                byte highBit = (byte)(orgin / 256);  //低位
                WriteCmd[15] = lowBit;
                WriteCmd[16] = highBit;
            }
            catch { }
        }
        /// <summary>
        /// 获取当前读取数据的起始地址
        /// </summary>
        /// <returns></returns>
        public int getWriteOrgin()
        {
            try
            {
                return WriteCmd[16] * 256 + WriteCmd[15];
            }
            catch { return -1; }
        }
        /// <summary>
        /// 向PLC写入数据
        /// </summary>
        /// <returns></returns>
        public bool WriteMitsubishiPLC()
        {
            bool isOk = false;
            try
            {
                byte[] writeCmdBytes = WriteCmd.ToArray();
                string ss = string.Empty;
                foreach (int item in writeCmdBytes)
                {
                    ss += item.ToString("X2") + ",";
                }
                lock (lockObj)
                {
                    udpPlc.Send(writeCmdBytes, writeCmdBytes.Length, ipendpoint);
                    Thread.Sleep(50);
                    if (udpPlc.Available > 0)
                    {
                        byte[] data = udpPlc.Receive(ref recIpEndPoint);
                        if (data.Length == 11)
                        {
                            if (data[0] == 0xd0 && data[1] == 0x00 && data[2] == 0x00 && data[3] == 0xff && data[4] == 0xff && data[5] == 0x03 && data[6] == 0x00 && data[7] == 0x02 && data[8] == 0x00 && data[9] == 0x00 && data[10] == 0x00)
                            {
                                isOk = true;
                            }
                        }
                    }
                }
            }
            catch { }
            return isOk;
        }
        /// <summary>
        /// 向PLC写入数据 
        /// </summary>
        /// <param name="orea">寄存器类型</param>
        /// <param name="origin">起始地址</param>
        /// <param name="data">写入数据（从起始地址开始的字信息）</param>
        /// <returns></returns>
        public bool WriteMitsubishiPLC(oreaType orea, int origin, int[] data)
        {
            bool isOK = false;
            try
            {
                setWriteOrea(orea);
                setWriteOrgin(origin);
                setWriteData(data);
                isOK = WriteMitsubishiPLC();
            }
            catch { }
            return isOK;
        }
        #endregion
        /// <summary>
        /// 写入任务状态 通过状态判断该写入到哪个地址
        /// </summary>
        /// <param name="state">写入的值</param>
        /// <returns></returns>
        public bool WriteState(int state)
        {
            return false;
        }
        /// <summary>
        /// 当AGV开始执行下一路段时，清除上一路段的状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool ClearSate(int state)
        {
            return false;
        }
        /// <summary>
        /// 寄存器类型
        /// </summary>
        public enum oreaType : byte
        {
            /// <summary>
            /// D寄存器
            /// </summary>
            OreaD = 0xa8,
        }
    }
}
