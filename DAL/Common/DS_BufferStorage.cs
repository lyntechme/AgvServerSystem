using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class DS_BufferStorage
    {
        /// <summary>
        /// 重置更新暂存点的个数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool RefBufferStoragePoint(int number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BufferStorage");
            if (SqlHelper.ExecuteNonQuery(strSql.ToString()) >= 0)
            {
                strSql.Remove(0, strSql.Length);
                strSql.Append("declare @i int set @i=1 while @i<= " + number.ToString() + " begin insert into BufferStorage(S_Id,S_Info,S_Order,S_Number,S_Flag)values(@i,'','',8,0) set @i=@i+1 end");
                int i = SqlHelper.ExecuteNonQuery(strSql.ToString());
                if (i == number)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取所有暂存点信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllBufferPoint()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from BufferStorage");
            return SqlHelper.DataSet(strSql.ToString());
        }
        /// <summary>
        /// 获取指定订单号暂存点信息,限制查寻区域
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        public DataSet QueryOrderBufferPoint(string Order,int begin,int end)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select Top 1 * from BufferStorage where S_Order = @S_Order and (S_Id >= @begin and S_Id< @end)");
            SqlParameter[] param = { 
                                       new SqlParameter("@S_Order", SqlDbType.VarChar, 50), 
                                       new SqlParameter("@begin", SqlDbType.Int, 4),
                                       new SqlParameter("@end", SqlDbType.Int, 4)
                                   };
            param[0].Value = Order;
            param[1].Value = begin;
            param[2].Value = end;
            return SqlHelper.DataSet(strSql.ToString(), param);
        }
        /// <summary>
        /// 更新暂存点数据
        /// </summary>
        /// <param name="mbs"></param>
        /// <returns></returns>
        public int UpdateBufferPoint(MS_BufferStorage mbs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update BufferStorage set S_Info = @S_Info,S_Order = @S_Order,S_Number = @S_Number,S_Flag = @S_Flag,S_UpdateTime = @S_UpdateTime ");
            strSql.Append("where S_Id = @S_Id");
            SqlParameter[] param = { 
                                       new SqlParameter("@S_Id",SqlDbType.Int,4),
                                       new SqlParameter("@S_Info",SqlDbType.VarChar,50),
                                       new SqlParameter("@S_Order",SqlDbType.VarChar,50),
                                       new SqlParameter("@S_Number",SqlDbType.Int,4),
                                       new SqlParameter("@S_Flag",SqlDbType.Int,4),
                                       new  SqlParameter("@S_UpdateTime",SqlDbType.DateTime)
                                   };
            param[0].Value = mbs.S_Id;
            param[1].Value = mbs.S_Info;
            param[2].Value = mbs.S_Order;
            param[3].Value = mbs.S_Number;
            param[4].Value = mbs.S_Flag;
            param[5].Value = mbs.S_UpdateTime;
            return SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
        }
        /// <summary>
        /// 更新标志位
        /// </summary>
        /// <param name="id">暂存点ID号</param>
        /// <param name="flag">标志位</param>
        /// <returns></returns>
        public int UpdateBufferPoint(int id, int flag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update BufferStorage set S_Flag = @S_Flag where S_Id = @S_Id");
            SqlParameter[] param = {
                                       new  SqlParameter("@S_Id",SqlDbType.Int,4),
                                       new  SqlParameter("@S_Flag",SqlDbType.Int,4)
                                   };
            param[0].Value = id;
            param[1].Value = flag;
            return SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
        }
        /// <summary>
        /// 查询暂存点个数
        /// </summary>
        /// <returns></returns>
        public DataSet QueryDataCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(S_Id) from BufferStorage");
            return SqlHelper.DataSet(strSql.ToString());
        }
    }
}
