using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.Data.SQLite;

namespace DAL
{
    public class DA_AgvErrorInfo
    {
        /// <summary>
        /// 删除总数量
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int QueryAgvErrorInfocount()
        {
            StringBuilder strSql = new StringBuilder();
            int count = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Select count(*) from AgvError");
                    //SqlHelper sqlHelper = new SqlHelper();
                    count = SqlHelper.ExecuteNonQuery(strSql.ToString());
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Select count(*) from AgvError");
                    DataSet ds = SqlLiteHelper.ExecuteDataset(strSql.ToString());
                    count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    break;
                default: break;
            }
            return count;
        }
        /// <summary>
        /// 删除前n条异常记录
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int DeleteAgvErrorInfo(int nCount)
        {
            StringBuilder strSql = new StringBuilder();
            int count = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete from AgvError where E_Id in (select E_Id from AgvError order by E_Id limit 0," + nCount.ToString() + ")");
                    //SqlHelper sqlHelper = new SqlHelper();
                    count = SqlHelper.ExecuteNonQuery(strSql.ToString());
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete from AgvError where E_Id in (select E_Id from AgvError order by E_Id limit 0," + nCount.ToString() + ")");
                    //strSql.Append("Delete from AgvError order by E_UpdateTime limit " + nCount.ToString());
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
        public int DeleteTimeAgvError(string time1, string time2)
        {
            DateTime datetTime1 = Convert.ToDateTime(time1);
            DateTime dateTime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            int count = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete from AgvError where E_UpdateTime > @time1 and E_UpdateTime < @time2");
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
                    strSql.Append("Delete from AgvError where E_UpdateTime >  @time1 and E_UpdateTime < @time2");
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
        /// 读取所有异常数据数据
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllAgvErrorInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError");
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
        public DataSet QueryConditionAgvErrorInfo(string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2");
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
        //查询指定Agv和时间的数据
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2 and ");
            strSql.Append("E_AgvNo = @AgvNo");
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
        //查询指定异常信息的数据
        public DataSet QueryConditionAgvErrorInfo(string Info, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2 and ");
            strSql.Append("E_Info = @Info");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { 
                                       new SqlParameter("@time1", SqlDbType.DateTime), 
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@Info",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = Info;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@Info", DbType.String) 
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = Info;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询指定Rfid编号的数据
        public DataSet QueryConditionAgvErrorInfo(bool isRfid, int AgvRfid, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2 and ");
            strSql.Append("E_AgvRfid = @AgvRfid");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { 
                                       new SqlParameter("@time1", SqlDbType.DateTime), 
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@AgvRfid",SqlDbType.Int,4)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = AgvRfid;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@AgvRfid", DbType.Int32,4) 
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = AgvRfid;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询指定Rfid编号、指定Agv编号的数据
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, int AgvRfid, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2 and ");
            strSql.Append("E_AgvNo = @AgvNo and ");
            strSql.Append("E_AgvRfid = @AgvRfid");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { 
                                       new SqlParameter("@time1", SqlDbType.DateTime), 
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@AgvNo",SqlDbType.Int,4),
                                       new SqlParameter("@AgvRfid",SqlDbType.Int,4)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = AgvNo;
                    param[3].Value = AgvRfid;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@AgvNo", DbType.Int32,4),
                                              new SQLiteParameter("@AgvRfid", DbType.Int32,4) 
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = AgvNo;
                    p[3].Value = AgvRfid;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询指定Agv、异常信息的数据
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, string Info, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2 and ");
            strSql.Append("E_AgvNo = @AgvNo and ");
            strSql.Append("E_Info = @Info");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { 
                                       new SqlParameter("@time1", SqlDbType.DateTime), 
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@AgvNo",SqlDbType.Int,4),
                                       new SqlParameter("@Info",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = AgvNo;
                    param[3].Value = Info;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@AgvNo", DbType.Int32,4),
                                              new SQLiteParameter("@Info", DbType.String) 
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = AgvNo;
                    p[3].Value = Info;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询指定Rfid、异常信息的数据
        public DataSet QueryConditionAgvErrorInfo(bool isRfid, int AgvRfid, string Info, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2 and ");
            strSql.Append("E_AgvRfid = @AgvRfid and ");
            strSql.Append("E_Info = @Info");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { 
                                       new SqlParameter("@time1", SqlDbType.DateTime), 
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@AgvRfid",SqlDbType.Int,4),
                                       new SqlParameter("@Info",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = AgvRfid;
                    param[3].Value = Info;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@AgvRfid", DbType.Int32,4),
                                              new SQLiteParameter("@Info", DbType.String) 
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = AgvRfid;
                    p[3].Value = Info;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //查询指定Agv、异常信息、Rfid的数据
        public DataSet QueryConditionAgvErrorInfo(int AgvNo, string Info, int AgvRfid, string time1, string time2)
        {
            DateTime dtime1 = Convert.ToDateTime(time1);
            DateTime dtime2 = Convert.ToDateTime(time2);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from AgvError ");
            strSql.Append("where E_UpdateTime > @time1 and ");
            strSql.Append("E_UpdateTime < @time2 and ");
            strSql.Append("E_AgvNo = @AgvNo and ");
            strSql.Append("E_Info = @Info and ");
            strSql.Append("E_AgvRfid = @AgvRfid");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { 
                                       new SqlParameter("@time1", SqlDbType.DateTime), 
                                       new SqlParameter("@time2", SqlDbType.DateTime),
                                       new SqlParameter("@AgvNo",SqlDbType.Int,4),
                                       new SqlParameter("@AgvRfid",SqlDbType.Int,4),
                                       new SqlParameter("@Info",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = dtime1;
                    param[1].Value = dtime2;
                    param[2].Value = AgvNo;
                    param[3].Value = AgvRfid;
                    param[4].Value = Info;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@time1", DbType.DateTime),
                                              new SQLiteParameter("@time2", DbType.DateTime),
                                              new SQLiteParameter("@AgvNo", DbType.Int32,4),
                                              new SQLiteParameter("@AgvRfid", DbType.Int32,4),
                                              new SQLiteParameter("@Info", DbType.String) 
                                          };
                    p[0].Value = time1;
                    p[1].Value = time2;
                    p[2].Value = AgvNo;
                    p[3].Value = AgvRfid;
                    p[4].Value = Info;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
        //插入异常信息
        public int InsertAgvErrorInfo(MA_AgvError mae)
        {
            if (mae != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Insert into AgvError (");
                strSql.Append("E_AgvNo,E_InfoNo,E_Info,E_LineNo,E_AgvRfid,E_Task,E_UpdateTime)values(");
                strSql.Append("@E_AgvNo,@E_InfoNo,@E_Info,@E_LineNo,@E_AgvRfid,@E_Task,@E_UpdateTime)");
                object obj = new object();
                switch (Common.dataSaveType)
                {
                    case (int)Enumerations.DataType.MsSql:
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] param = {
                                   new SqlParameter("@E_AgvNo",SqlDbType.Int,4),
                                   new SqlParameter("@E_InfoNo",SqlDbType.Int,4),
                                   new SqlParameter("@E_Info",SqlDbType.VarChar,50),
                                   new SqlParameter("@E_LineNo",SqlDbType.VarChar,50),
                                   new SqlParameter("@E_AgvRfid",SqlDbType.Int,4),
                                   new SqlParameter("@E_Task",SqlDbType.VarChar,50),
                                   new SqlParameter("@E_UpdateTime",SqlDbType.DateTime)
                                   };
                        param[0].Value = mae.E_AgvNo;
                        param[1].Value = mae.E_InfoNo;
                        param[2].Value = mae.E_Info;
                        param[3].Value = mae.E_LineNo;
                        param[4].Value = mae.E_AgvRfid;
                        param[5].Value = mae.E_Task;
                        param[6].Value = mae.E_UpdateTime;
                        obj = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                        break;
                    case (int)Enumerations.DataType.SqlLite:
                        SQLiteParameter[] p = { 
                                              new SQLiteParameter("@E_AgvNo", DbType.Int32 ,4),
                                              new SQLiteParameter("@E_InfoNo", DbType.Int32,4),
                                              new SQLiteParameter("@E_Info", DbType.String),
                                              new SQLiteParameter("@E_LineNo", DbType.String),
                                              new SQLiteParameter("@E_AgvRfid", DbType.Int32,4),
                                              new SQLiteParameter("@E_Task", DbType.String),
                                              new SQLiteParameter("@E_UpdateTime",DbType.DateTime)
                                          };
                        p[0].Value = mae.E_AgvNo;
                        p[1].Value = mae.E_InfoNo;
                        p[2].Value = mae.E_Info;
                        p[3].Value = mae.E_LineNo;
                        p[4].Value = mae.E_AgvRfid;
                        p[5].Value = mae.E_Task;
                        p[6].Value = mae.E_UpdateTime.ToString("yyyy-MM-dd HH:mm:ss");
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
