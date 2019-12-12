using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace DAL
{
    public class DA_AgvTaskInfo
    {
        /// <summary>
        /// 删除总数量
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int QueryAgvTaskInfocount()
        {
            StringBuilder strSql = new StringBuilder();
            int count = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Select count(*) from AgvTaskInfo");
                    //SqlHelper sqlHelper = new SqlHelper();
                    count = SqlHelper.ExecuteNonQuery(strSql.ToString());
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Select count(*) from AgvTaskInfo");
                    DataSet ds = SqlLiteHelper.ExecuteDataset(strSql.ToString());
                    count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    break;
                default: break;
            }
            return count;
        }
        /// <summary>
        /// 删除前n条任务记录
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int DeleteAgvTaskInfo(int nCount)
        {
            StringBuilder strSql = new StringBuilder();
            int count = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete from AgvTaskInfo where T_Id in (select T_Id from AgvTaskInfo order by T_Id limit 0," + nCount.ToString() + ")");
                    //SqlHelper sqlHelper = new SqlHelper();
                    count = SqlHelper.ExecuteNonQuery(strSql.ToString());
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete from AgvTaskInfo where T_Id in (select T_Id from AgvTaskInfo order by T_Id limit 0," + nCount.ToString() + ")");
                    count = SqlLiteHelper.ExecuteNonQuery(strSql.ToString());
                    break;
                default: break;
            }
            return count;
        }
        /// <summary>
        /// 删除指定时间段前的数据(一个月前)
        /// </summary>
        /// <returns></returns>
        public int DeleteTimeAgvTaskInfo(string time1, string time2)
        {
            DateTime datetTime1 = Convert.ToDateTime(time1);
            DateTime dateTime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            int count = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete from AgvTaskInfo where T_BeginTime > @time1 and T_BeginTime < @time2");
                    SqlParameter[] param = {
                                       new SqlParameter("@time1", SqlDbType.DateTime),
                                       new SqlParameter("@time2", SqlDbType.DateTime)
                                   };
                    param[0].Value = datetTime1;
                    param[1].Value = dateTime2;
                    //SqlHelper sqlHelper = new SqlHelper();
                    count = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete from AgvTaskInfo where T_UpdateTime >  @time1 and T_UpdateTime < @time2");
                    SQLiteParameter[] p = {
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime)
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    count = SqlLiteHelper.ExecuteNonQuery(strSql.ToString(), p);
                    break;
                default: break;
            }
            return count;

        }
        /// <summary>
        /// 读取所有任务数据数据
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllAgvTaskInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvTaskInfo");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    ds = SqlHelper.DataSet(strSql.ToString());
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString());
                    break;
                default: break;
            }
            return ds;
        }
        /// <summary>
        /// 查询两个时间之间的信息
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvTaskInfo(string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvTaskInfo ");
            strSql.Append("where T_UpdateTime > @time1 and ");
            strSql.Append("T_UpdateTime < @time2");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                       new SqlParameter("@time1", SqlDbType.DateTime),
                                       new SqlParameter("@time2", SqlDbType.DateTime)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = {
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime)
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        /// <summary>
        /// 查询指定Agv和时间的数据
        /// </summary>
        /// <param name="AgvNo"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public DataSet QueryConditionAgvTaskInfo(int AgvNo, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvTaskInfo ");
            strSql.Append("where T_UpdateTime > @time1 and ");
            strSql.Append("T_UpdateTime < @time2 and ");
            strSql.Append("T_AgvNo = @AgvNo");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                       new SqlParameter("@time1", SqlDbType.DateTime),
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@AgvNo",SqlDbType.Int,4)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = AgvNo;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = {
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@AgvNo", DbType.Int32,4)
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = AgvNo;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询指定线别的数据
        public DataSet QueryConditionAgvTaskInfo(string description, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvTaskInfo ");
            strSql.Append("where T_UpdateTime > @time1 and ");
            strSql.Append("T_UpdateTime < @time2 and ");
            strSql.Append("T_Name like '%" + description + "%'");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                       new SqlParameter("@time1", SqlDbType.DateTime),
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@description",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = description;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = {
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@description", DbType.String)
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = description;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询指定Agv、线别的数据
        public DataSet QueryConditionAgvTaskInfo(int AgvNo, string description, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvTaskInfo ");
            strSql.Append("where T_UpdateTime > @time1 and ");
            strSql.Append("T_UpdateTime < @time2 and ");
            strSql.Append("T_AgvNo = @AgvNo and ");
            strSql.Append("T_Name like '%" + description + "%'");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                       new SqlParameter("@time1", SqlDbType.DateTime),
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@AgvNo",SqlDbType.Int,4),
                                       new SqlParameter("@description",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = AgvNo;
                    param[3].Value = description;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = {
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@AgvNo", DbType.Int32,4),
                                              new SQLiteParameter("@description", DbType.String)
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = AgvNo;
                    p[3].Value = description;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询具体类型任务的数量
        public int QueryAgvTaskInfoTypeCount(string description)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                int count = 0;
                string time1 = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
                string time2 = DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                switch (Common.dataSaveType)
                {
                    case (int)Enumerations.DataType.MsSql:
                        strSql.Remove(0, strSql.Length);
                        strSql.Append("Select count(*) from AgvTaskInfo");
                        //SqlHelper sqlHelper = new SqlHelper();
                        count = SqlHelper.ExecuteNonQuery(strSql.ToString());
                        break;
                    case (int)Enumerations.DataType.SqlLite:
                        strSql.Remove(0, strSql.Length);
                        strSql.Append("Select count(*) from AgvTaskInfo ");
                        strSql.Append("where T_UpdateTime > @time1 and ");
                        strSql.Append("T_UpdateTime < @time2 and ");
                        strSql.Append("T_Name like '%" + description + "[%'");
                        SQLiteParameter[] p = {
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@description", DbType.String)
                                          };
                        p[0].Value = time1;
                        p[1].Value = time2;
                        p[2].Value = description;
                        DataSet ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                        count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        break;
                    default: break;
                }
                return count;
            }
            catch
            {
                return 0;
            }
        }
        //插入任务信息
        public int InsertAgvTaskInfo(MA_AgvTaskInfo mati)
        {
            if (mati != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Insert into AgvTaskInfo (");
                strSql.Append("T_Key,T_AgvNo,T_Type,T_level,T_State,T_Name,T_Description,T_CreateTime,T_StartTime,T_FinishTime,T_UpdateTime)values(");
                strSql.Append("@T_Key,@T_AgvNo,@T_Type,@T_level,@T_State,@T_Name,@T_Description,@T_CreateTime,@T_StartTime,@T_FinishTime,@T_UpdateTime)");

                object obj = new object();
                switch (Common.dataSaveType)
                {
                    case (int)Enumerations.DataType.MsSql:
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] param = {
                                   new SqlParameter("@T_Key",SqlDbType.VarChar,50),
                                   new SqlParameter("@T_AgvNo",SqlDbType.Int,4),
                                   new SqlParameter("@T_Type",SqlDbType.Int,4),
                                   new SqlParameter("@T_level",SqlDbType.Int,4),
                                   new SqlParameter("@T_State",SqlDbType.VarChar,50),
                                   new SqlParameter("@T_Name",SqlDbType.VarChar,50),
                                   new SqlParameter("@T_Description",SqlDbType.VarChar,50),
                                   new SqlParameter("@T_CreateTime",SqlDbType.DateTime),
                                   new SqlParameter("@T_StartTime",SqlDbType.DateTime),
                                   new SqlParameter("@T_FinishTime",SqlDbType.DateTime),
                                   new SqlParameter("@T_UpdateTime",SqlDbType.DateTime)
                                   };
                        param[0].Value = mati.T_Id;
                        param[1].Value = mati.T_AgvNo;
                        param[2].Value = mati.T_Type;
                        param[3].Value = mati.T_Level;
                        param[4].Value = mati.T_State;
                        param[5].Value = mati.T_TaskName;
                        param[6].Value = mati.T_Description;
                        param[7].Value = mati.T_CreateTime;
                        param[8].Value = mati.T_StartTime;
                        param[9].Value = mati.T_FinishTime;
                        param[10].Value = DateTime.Now;
                        obj = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                        break;
                    case (int)Enumerations.DataType.SqlLite:
                        SQLiteParameter[] p = {
                                              new SQLiteParameter("@T_Key", DbType.String),
                                              new SQLiteParameter("@T_AgvNo", DbType.Int32,4),
                                              new SQLiteParameter("@T_Type", DbType.Int32,4),
                                              new SQLiteParameter("@T_level", DbType.Int32,4),
                                              new SQLiteParameter("@T_State", DbType.String),
                                              new SQLiteParameter("@T_Name", DbType.String),
                                              new SQLiteParameter("@T_Description", DbType.String),
                                              new SQLiteParameter("@T_CreateTime", DbType.DateTime),
                                              new SQLiteParameter("@T_StartTime", DbType.DateTime),
                                              new SQLiteParameter("@T_FinishTime", DbType.DateTime),
                                              new SQLiteParameter("@T_UpdateTime", DbType.DateTime)
                                          };
                        p[0].Value = mati.T_Id;
                        p[1].Value = mati.T_AgvNo;
                        p[2].Value = mati.T_Type;
                        p[3].Value = mati.T_Level;
                        p[4].Value = mati.T_State;
                        p[5].Value = mati.T_TaskName;
                        p[6].Value = mati.T_Description;
                        p[7].Value = mati.T_CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        p[8].Value = mati.T_StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                        p[9].Value = mati.T_FinishTime.ToString("yyyy-MM-dd HH:mm:ss");
                        p[10].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        obj = SqlLiteHelper.ExecuteNonQuery(strSql.ToString(), p);
                        break;
                    default: break;
                }
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }

            }
            else
            {
                return 0;
            }
        }
    }
}
