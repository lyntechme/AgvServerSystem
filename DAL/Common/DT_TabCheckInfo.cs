using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model;
using System.Data.SQLite;

namespace DAL
{
    public class DT_TabCheckInfo
    {
        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="T_Name"></param>
        /// <returns></returns>
        public int ExistsName(string T_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TabCheckInfo ");
            strSql.Append("where ");
            strSql.Append("T_Name = @T_Name");
            object obj = new object();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { new SqlParameter("@T_Name", SqlDbType.VarChar, 50) };
                    param[0].Value = T_Name;
                    obj = SqlHelper.ExecuteScalar(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { new SQLiteParameter("@T_Name", DbType.String), };
                    p[0].Value = T_Name;
                    obj = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 查询选卡是否被选中
        /// </summary>
        /// <param name="T_Name"></param>
        /// <returns></returns>
        public int ExistsChecked(string T_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select T_Checked from TabCheckInfo ");
            strSql.Append("where T_Name = @T_Name");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:

                    SqlParameter[] param = { new SqlParameter("@T_Name", SqlDbType.VarChar, 50) };
                    param[0].Value = T_Name;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { new SQLiteParameter("@T_Name", DbType.String), };
                    p[0].Value = T_Name;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 更新选卡是否被选中状态
        /// </summary>
        /// <param name="T_Name"></param>
        /// <returns></returns>
        public bool UpdateChecked(string T_Name,int T_Checked)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update TabCheckInfo set ");
            strSql.Append("T_Checked = @T_Checked ");
            strSql.Append("where ");
            strSql.Append("T_Name = @T_Name");
            int rows = -1;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:

                    SqlParameter[] param = { 
                                               new SqlParameter("@T_Name", SqlDbType.VarChar, 50), 
                                               new SqlParameter("@T_Checked", SqlDbType.Int) 
                                           };
                    param[0].Value = T_Name;
                    param[1].Value = T_Checked;
                    rows = SqlHelper.ProExecuteNonQuery(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@T_Name", DbType.String),
                                              new SQLiteParameter("@T_Checked", DbType.Int32,4)
                                          };
                    p[0].Value = T_Name;
                    p[1].Value = T_Checked;
                    rows = SqlLiteHelper.ExecuteNonQuery(strSql.ToString(), p);
                    break;
                default: break;
            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加一选卡信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int AddChecked(MT_TabCheckInfo tabCheckInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Insert into TabCheckInfo(");
            strSql.Append("T_Name,T_Checked");
            strSql.Append(")values(");
            strSql.Append("@U_Name,@T_Checked");
            strSql.Append(") ");
            object obj = new object();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] param = { 
                                               new SqlParameter("@T_Name", SqlDbType.VarChar, 50), 
                                               new SqlParameter("@T_Checked", SqlDbType.Int) 
                                           };
                    param[0].Value = tabCheckInfo.T_Name;
                    param[1].Value = tabCheckInfo.T_Checked;
                    obj = SqlHelper.ProExecuteNonQuery(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@T_Name", DbType.String),
                                              new SQLiteParameter("@T_Checked", DbType.Int32,4)
                                          };
                    p[0].Value = tabCheckInfo.T_Name;
                    p[1].Value = tabCheckInfo.T_Checked;
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
    }
}
