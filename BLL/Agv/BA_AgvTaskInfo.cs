using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Model;

namespace BLL
{
    public class BA_AgvTaskInfo
    {
        private DA_AgvTaskInfo dati = new DA_AgvTaskInfo();
        /// <summary>
        /// 删除总数量
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int QueryAgvTaskInfocount()
        {
            return dati.QueryAgvTaskInfocount();
        }
        /// <summary>
        /// 删除前n条任务记录
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int DeleteAgvTaskInfo(int nCount)
        {
            return dati.DeleteAgvTaskInfo(nCount);
        }
        /// <summary>
        /// 删除指定时间段前的数据
        /// </summary>
        /// <returns></returns>
        public int DeleteTimeAgvTaskInfo(string time1, string time2)
        {
            return dati.DeleteTimeAgvTaskInfo(time1, time2);
        }
        /// <summary>
        /// 读取所有任务数据数据
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllAgvTaskInfo()
        {
            return dati.QueryAllAgvTaskInfo();
        }
        /// <summary>
        /// 查询两个时间之间的信息
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvTaskInfo(string time1, string time2)
        {
            return dati.QueryConditionAgvTaskInfo(time1, time2);
        }
        /// 查询指定Agv和时间的数据
        /// </summary>
        /// <param name="AgvNo"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvTaskInfo(int AgvNo, string time1, string time2)
        {
            return dati.QueryConditionAgvTaskInfo(AgvNo, time1, time2);
        }
        //查询指定线别的数据
        public DataSet QueryConditionAgvTaskInfo(string lineNo, string time1, string time2)
        {
            return dati.QueryConditionAgvTaskInfo(lineNo, time1, time2);
        }
        //查询指定Agv、线别的数据
        public DataSet QueryConditionAgvTaskInfo(int AgvNo, string lineNo, string time1, string time2)
        {
            return dati.QueryConditionAgvTaskInfo(AgvNo, lineNo, time1, time2);
        }
        //查询指定类型任务数量
        public int QueryAgvTaskInfoTypeCount(string lineNo)
        {
            return dati.QueryAgvTaskInfoTypeCount(lineNo);
        }
        /// <summary>
        /// 插入任务信息
        /// </summary>
        /// <param name="mati"></param>
        /// <returns></returns>
        public int InsertAgvTaskInfo(MA_AgvTaskInfo mati)
        {
            int i = dati.InsertAgvTaskInfo(mati);
            if (i > 0)
                Common.insertCount[0] += i;
            try//删除指定前n条数据
            {
                if (Common.insertCount[0] > 250000)
                {
                    int count = dati.QueryAgvTaskInfocount();
                    Common.insertCount[0] = count;
                    if (count > 250000)
                    {
                        int dCount = dati.DeleteAgvTaskInfo(count - 200000);
                        if (dCount > 0)
                        {
                            Common.insertCount[0] -= dCount;
                        }
                    }
                }
            }
            catch { }
            return i;
        }
    }
}
