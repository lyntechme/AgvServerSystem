using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface AgvConnect
    {
        /// <summary>
        /// 读取AGV数据
        /// </summary>
        /// <param name="agvInfo"></param>
        /// <returns>返回值，true:读取成功；false:读取失败</returns>
        bool ReadData(ref M_AgvInfo agvInfo);
        /// <summary>
        /// 任务写入
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <returns></returns>
        bool WriteTask(MA_AgvTaskInfo taskInfo);
        /// <summary>
        /// agv交通锁定
        /// </summary>
        /// <returns></returns>
        bool LockAgv();
        /// <summary>
        /// agv交通解锁
        /// </summary>
        /// <returns></returns>
        bool UnlockAgv();
        /// <summary>
        /// agv停止
        /// </summary>
        /// <returns></returns>
        bool AgvStop();
        /// <summary>
        /// agv运行
        /// </summary>
        /// <returns></returns>
        bool AgvRun();
        /// <summary>
        /// agv复位
        /// </summary>
        /// <returns></returns>
        bool AgvRest();
        /// <summary>
        /// AGV操作
        /// </summary>
        /// <param name="operate">操作类型</param>
        /// <param name="station">站点信息</param>
        /// <returns></returns>
        bool AgvOperate(Enumerations.AgvOperate operate, params int[] station);
        /// <summary>
        /// 写入站点信息
        /// </summary>
        /// <param name="routeNo">路段编号</param>
        /// <param name="rfidInfo">路段属性</param>
        /// <returns></returns>
        bool WriteStation(int routeNo, RfidInfo rfidInfo);
    }
}
