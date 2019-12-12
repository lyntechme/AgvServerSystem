using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.Data.SQLite;
using System.Data.Common;

namespace DAL
{
    public class DA_AgvComInfo
    {
        /// <summary>
        /// 查询该小车编号是否已经存在
        /// </summary>
        /// <param name="A_Id"></param>
        /// <returns></returns>
        public int ExistsId(int A_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Remove(0, strSql.Length);
            strSql.Append("Select count(1) from AgvComInfo ");
            strSql.Append("Where ");
            strSql.Append("A_Id = @A_Id");
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { new SqlParameter("@A_Id", SqlDbType.Int, 4) };
                    param[0].Value = A_Id;
                    return Convert.ToInt32(SqlHelper.ExecuteScalar(strSql.ToString(), param));
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { new SQLiteParameter("@A_Id", DbType.Int32, 4) };
                    p[0].Value = A_Id;
                    return Convert.ToInt32(SqlLiteHelper.ExecuteScalar(strSql.ToString(), p));
                default: return 0;
            }

        }
        /// <summary>
        /// 添加一个Agv对象
        /// </summary>
        /// <param name="maci"></param>
        /// <returns></returns>
        public int AddAgvComInfo(MA_AgvComInfo maci)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Insert into AgvComInfo(");
            strSql.Append("A_Id,A_Description,A_IPAddress,A_NetNo,A_LocalPort,A_DesPort,A_AgvType,A_IsUsing");
            strSql.Append(")values(");
            strSql.Append("@A_Id,@A_Description,@A_IPAddress,@A_NetNo,@A_LocalPort,@A_DesPort,@A_AgvType,@A_IsUsing");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                   new SqlParameter("@A_Id",SqlDbType.Int,4),
                                   new SqlParameter("@A_Description",SqlDbType.VarChar,50),
                                   new SqlParameter("@A_IPAddress",SqlDbType.VarChar,50),
                                   new SqlParameter("@A_NetNo",SqlDbType.Int,4),
                                   new SqlParameter("@A_LocalPort",SqlDbType.Int,4),
                                   new SqlParameter("@A_DesPort",SqlDbType.Int,4),
                                   new SqlParameter("@A_AgvType",SqlDbType.VarChar,50),
                                   new SqlParameter("@A_IsUsing",SqlDbType.Bit)
                                   };
                    param[0].Value = maci.A_Id;
                    param[1].Value = maci.A_Description;
                    param[2].Value = maci.A_IpAddress;
                    param[3].Value = maci.A_NetNo;
                    param[4].Value = maci.A_LocalPort;
                    param[5].Value = maci.A_DesPort;
                    param[6].Value = maci.A_AgvConnectType + "," + maci.A_AgvCommonType;
                    param[7].Value = maci.A_IsUsing.ToString();
                    object obj = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    if (obj == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(obj);
                    }
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Insert into AgvComInfo(");
                    strSql.Append("A_Id,A_Description,A_IPAddress,A_NetNo,A_LocalPort,A_DesPort,A_AgvType,A_IsUsing");
                    strSql.Append(")values(");
                    strSql.Append(maci.A_Id.ToString());
                    strSql.Append(",'");
                    strSql.Append(maci.A_Description);
                    strSql.Append("','");
                    strSql.Append(maci.A_IpAddress);
                    strSql.Append("',");
                    strSql.Append(maci.A_NetNo.ToString());
                    strSql.Append(",");
                    strSql.Append(maci.A_LocalPort.ToString());
                    strSql.Append(",");
                    strSql.Append(maci.A_DesPort.ToString());
                    strSql.Append(",'");
                    strSql.Append(maci.A_AgvConnectType + "," + maci.A_AgvCommonType);
                    strSql.Append("',");
                    strSql.Append(Convert.ToInt32(maci.A_IsUsing).ToString());
                    strSql.Append(")");
                    obj = SqlLiteHelper.ExecuteNonQuery(strSql.ToString());
                    if (obj == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(obj);
                    }
                default: return 0;
            }
        }
        /// <summary>
        /// 更新一个Agv对象
        /// </summary>
        /// <param name="maci"></param>
        /// <returns></returns>
        public bool UpdateAgvComInfo(MA_AgvComInfo maci)
        {
            StringBuilder strSql = new StringBuilder();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Update AgvComInfo set ");
                    strSql.Append("A_Description = @A_Description,");
                    strSql.Append("A_IPAddress = @A_IPAddress,");
                    strSql.Append("A_NetNo = @A_NetNo,");
                    strSql.Append("A_LocalPort = @A_LocalPort,");
                    strSql.Append("A_DesPort = @A_DesPort,");
                    strSql.Append("A_AgvType = @A_AgvType,");
                    strSql.Append("A_IsUsing = @A_IsUsing ");
                    strSql.Append("where A_Id = @A_Id");
                    SqlParameter[] param = {
                                   new SqlParameter("@A_Id",SqlDbType.Int,4),
                                   new SqlParameter("@A_Description",SqlDbType.VarChar,50),
                                   new SqlParameter("@A_IPAddress",SqlDbType.VarChar,50),
                                   new SqlParameter("@A_NetNo",SqlDbType.Int,4),
                                   new SqlParameter("@A_LocalPort",SqlDbType.Int,4),
                                   new SqlParameter("@A_DesPort",SqlDbType.Int,4),
                                   new SqlParameter("@A_AgvType",SqlDbType.VarChar,50),
                                   new SqlParameter("@A_IsUsing",SqlDbType.Bit)
                                   };
                    param[0].Value = maci.A_Id;
                    param[1].Value = maci.A_Description;
                    param[2].Value = maci.A_IpAddress;
                    param[3].Value = maci.A_NetNo;
                    param[4].Value = maci.A_LocalPort;
                    param[5].Value = maci.A_DesPort;
                    param[6].Value = maci.A_AgvConnectType + "," + maci.A_AgvCommonType;
                    param[7].Value = maci.A_IsUsing.ToString();
                    int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Update AgvComInfo set ");
                    strSql.Append("A_Description = '" + maci.A_Description + "',");
                    strSql.Append("A_IPAddress = '" + maci.A_IpAddress + "',");
                    strSql.Append("A_NetNo = " + maci.A_NetNo.ToString() + ",");
                    strSql.Append("A_LocalPort = " + maci.A_LocalPort.ToString() + ",");
                    strSql.Append("A_DesPort = " + maci.A_DesPort.ToString() + ",");
                    strSql.Append("A_AgvType = '" + maci.A_AgvConnectType + "," + maci.A_AgvCommonType + "',");
                    strSql.Append("A_IsUsing = " + Convert.ToInt32(maci.A_IsUsing).ToString() + " ");
                    strSql.Append("where A_Id = " + maci.A_Id.ToString());
                    rows = SqlLiteHelper.ExecuteNonQuery(strSql.ToString());
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default: return false;
            }
        }
        /// <summary>
        /// 删除一个Agv对象
        /// </summary>
        /// <param name="A_Id"></param>
        /// <returns></returns>
        public bool DeleteAgvComInfo(int A_Id)
        {
            StringBuilder strSql = new StringBuilder();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete From AgvComInfo ");
                    strSql.Append("where A_Id = @A_Id");

                    SqlParameter[] param = { new SqlParameter("@A_Id", SqlDbType.Int, 4) };
                    param[0].Value = A_Id;
                    int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Delete From AgvComInfo ");
                    strSql.Append("where A_Id = " + A_Id.ToString());
                    rows = SqlLiteHelper.ExecuteNonQuery(strSql.ToString());
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default: return false;
            }
        }
        /// <summary>
        /// 查询所有的Agv对象
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllAgvComInfo()
        {
            StringBuilder strSql = new StringBuilder();
            DataSet ds = new DataSet();
            strSql.Append("Select * from AgvComInfo");
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
        /// 更新A_IsUsing值
        /// </summary>
        /// <param name="isUsing"></param>
        /// <returns></returns>
        public bool UpdateIsUsing(Dictionary<int, bool> isUsing)
        {
            bool isOk = false;
            try
            {
                using (SQLiteConnection conn = SqlLiteHelper.GetSQLiteConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    using (DbTransaction dbTrans = conn.BeginTransaction())
                    {
                        using (DbCommand cmd = conn.CreateCommand())
                        {
                            foreach (int item in isUsing.Keys)
                            {
                                cmd.CommandText = "Update AgvComInfo set A_IsUsing = " + Convert.ToInt32(isUsing[item]).ToString() + " where A_Id = " + item.ToString();
                                int i = cmd.ExecuteNonQuery();
                                if (i < 1)
                                    isOk = false;
                            }
                        }
                        dbTrans.Commit();
                        isOk = true;
                    }
                }
            }
            catch (Exception exIsUsing)
            { }
            return isOk;
        }
    }
}
