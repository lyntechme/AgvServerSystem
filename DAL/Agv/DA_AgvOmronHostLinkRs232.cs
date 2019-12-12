using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DA_AgvOmronHostLinkRs232 : AgvConnect
    {
        #region Perproties
        /// <summary>
        /// agv通讯参数
        /// </summary>
        private MA_AgvComInfo AgvComm;
        /// <summary>
        /// PLC通讯接口
        /// </summary>
        private AgvPLCUtils.PlcConnect omronFins;
        /// <summary>
        /// 通讯最大重链次数
        /// </summary>
        private int linkMaxNumber = 20;
        /// <summary>
        /// 重链次数
        /// </summary>
        private int linkNo = 0;
        /// <summary>
        /// PLC的起始地址
        /// </summary>
        private int readOrginAddress = 100;
        /// <summary>
        /// PLC的读取长度
        /// </summary>
        private int readDataLength = 32;
        #endregion

        public DA_AgvOmronHostLinkRs232(MA_AgvComInfo _agvComm)
        {
            this.AgvComm = _agvComm;
            omronFins = new AgvPLCUtils.OmronHostLink(this.AgvComm.A_LocalPort);
        }
        /// <summary>
        /// 读取AGV数据
        /// </summary>
        /// <param name="agvInfo"></param>
        public bool ReadData(ref M_AgvInfo agvInfo)
        {
            bool isReadOk = false;
            try
            {
                byte[] data = this.omronFins.WReadAgv(this.AgvComm.A_NetNo, AgvPLCUtils.CFinsCmdCode.MAR, AgvPLCUtils.CMACode.WRw, this.readOrginAddress, this.readDataLength, this.AgvComm.A_IpAddress, this.AgvComm.A_DesPort);
                if (data.Length == this.readDataLength * 2 + 1 && data[0] == 1)   //判断是否读取Agv数据成功
                {
                    //数据解析
                    this.linkNo = 0;
                    isReadOk = true;
                }
                else
                {
                    this.linkNo++;
                }
                if (this.linkNo > this.linkMaxNumber)
                {
                    agvInfo.State = (int)Enumerations.AgvStatus.disConnection;
                }
            }
            catch { }
            return isReadOk;
        }
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
        /// <returns></returns>
        public bool AgvOperate(Enumerations.AgvOperate operate, params int[] station)
        {
            return false;
        }

        public bool WriteStation(int routeNo, RfidInfo rfidInfo)
        {
            throw new NotImplementedException();
        }
    }
}
