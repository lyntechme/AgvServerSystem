using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class BA_AgvErrorInfo
    {
        private DA_AgvErrorInfo dae = new DA_AgvErrorInfo();
        /// <summary>
        /// 删除总数量
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int QueryAgvErrorInfocount()
        {
            return dae.QueryAgvErrorInfocount();
        }
        /// <summary>
        /// 删除前n条异常记录
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int DeleteAgvTaskInfo(int nCount)
        {
            return dae.DeleteAgvErrorInfo(nCount);
        }
        /// <summary>
        /// 删除指定时间段前的数据
        /// </summary>
        /// <returns></returns>
        public int DeleteTimeAgvErrorInfo(string time1, string time2)
        {
            return dae.DeleteTimeAgvError(time1, time2);
        }
        /// <summary>
        /// 读取所有异常数据数据
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllAgvErroInfo()
        {
            return dae.QueryAllAgvErrorInfo();
        }
        /// <summary>
        /// 查询两个时间之间的信息
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(time1, time2);
        }
        /// <summary>
        /// 查询指定Agv和时间的数据
        /// </summary>
        /// <param name="AgvNo"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(AgvNo, time1, time2);
        }
        /// <summary>
        /// 查询指定异常信息的数据
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(string Info, string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(Info, time1, time2);
        }
        /// <summary>
        /// 查询指定Rfid编号的数据
        /// </summary>
        /// <param name="isRfid"></param>
        /// <param name="AgvRfid"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(bool isRfid, int AgvRfid, string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(isRfid, AgvRfid, time1, time2);
        }
        /// <summary>
        /// 查询指定Rfid编号、指定Agv编号的数据
        /// </summary>
        /// <param name="AgvNo"></param>
        /// <param name="AgvRfid"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, int AgvRfid, string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(AgvNo, AgvRfid, time1, time2);
        }
        /// <summary>
        /// 查询指定Agv、异常信息的数据
        /// </summary>
        /// <param name="AgvNo"></param>
        /// <param name="Info"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, string Info, string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(AgvNo, Info, time1, time2);
        }
        /// <summary>
        /// 查询指定Rfid、异常信息的数据
        /// </summary>
        /// <param name="isRfid"></param>
        /// <param name="AgvRfid"></param>
        /// <param name="Info"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(bool isRfid, int AgvRfid, string Info, string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(isRfid, AgvRfid, Info, time1, time2);
        }
        /// <summary>
        /// 查询指定Agv、异常信息、Rfid的数据
        /// </summary>
        /// <param name="AgvNo"></param>
        /// <param name="Info"></param>
        /// <param name="AgvRfid"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, string Info, int AgvRfid, string time1, string time2)
        {
            return dae.QueryConditionAgvErrorInfo(AgvNo, Info, AgvRfid, time1, time2);
        }
        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="mae"></param>
        /// <returns></returns>
        public int InsertAgvErrorInfo(MA_AgvError mae)
        {
            int i = dae.InsertAgvErrorInfo(mae);
            if (i > 0)
                Common.insertCount[1] += i;
            try//删除指定前n条数据
            {
                if (Common.insertCount[1] > 250000)
                {
                    int count = dae.QueryAgvErrorInfocount();
                    Common.insertCount[1] = count;
                    if (count > 250000)
                    {
                        int dCount = dae.DeleteAgvErrorInfo(count - 200000);
                        if (dCount > 0)
                        {
                            Common.insertCount[1] -= dCount;
                        }
                    }
                }
            }
            catch { }
            return i;
        }
    }
}
