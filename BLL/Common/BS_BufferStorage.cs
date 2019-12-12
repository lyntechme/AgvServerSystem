using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Model;

namespace BLL
{
    public class BS_BufferStorage
    {
        DS_BufferStorage dsbs = new DS_BufferStorage();
        /// <summary>
        /// 重置设置暂存点个数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool RefBufferStoragePoint(int number)
        {
            return dsbs.RefBufferStoragePoint(number);
        }
        /// <summary>
        /// 获取所有暂存点信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllBufferPoint()
        {
            return dsbs.QueryAllBufferPoint();
        }
        /// <summary>
        /// 获取指定订单号暂存点信息,限制查寻区域
        /// </summary>
        /// <param name="begin">查询开始点</param>
        /// <param name="end">查询结束点</param>
        /// <param name="Order">物料订单号</param>
        /// <returns></returns>
        public DataSet QueryOrderBufferPoint(string Order, int begin, int end)
        {
            return dsbs.QueryOrderBufferPoint(Order, begin, end);
        }
        /// <summary>
        /// 更新暂存点数据
        /// </summary>
        /// <param name="mbs"></param>
        /// <returns></returns>
        public int UpdateBufferPoint(MS_BufferStorage mbs)
        {
            return dsbs.UpdateBufferPoint(mbs);
        }
        /// <summary>
        /// 更新标志位
        /// </summary>
        /// <param name="id">暂存点ID号</param>
        /// <param name="flag">标志位</param>
        /// <returns></returns>
        public int UpdateBufferPoint(int id, int flag)
        {
            return dsbs.UpdateBufferPoint(id, flag);
        }
        /// <summary>
        /// 查询暂存点个数
        /// </summary>
        /// <returns></returns>
        public int QueryDataCount()
        {
            DataSet ds = dsbs.QueryDataCount();
            try
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
