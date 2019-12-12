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
    public class DU_UserInfo
    {
        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="U_Name">用户名称</param>
        /// <returns></returns>
        public int ExistsName(string U_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from UserInfo ");
            strSql.Append("Where ");
            strSql.Append("U_Name = @U_Name");
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { new SqlParameter("@U_Name", SqlDbType.VarChar, 50) };
                    param[0].Value = U_Name;
                    return Convert.ToInt32(SqlHelper.ExecuteScalar(strSql.ToString(), param));
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { new SQLiteParameter("@U_Name", DbType.String) };
                    p[0].Value = U_Name;
                    return Convert.ToInt32(SqlLiteHelper.ExecuteScalar(strSql.ToString(), p));
                default: return 0;
            }
        }
        /// <summary>
        /// 查询用户和密码是否存在
        /// </summary>
        /// <param name="U_Name">用户名称</param>
        /// <param name="U_Password">对应密码</param>
        /// <returns></returns>
        public DataSet ExistsPwd(string U_Name, string U_Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From UserInfo ");
            strSql.Append("Where ");
            strSql.Append("U_Name = @U_Name and U_Password = @U_Password");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                   new SqlParameter("@U_Name",SqlDbType.VarChar,50),
                                   new SqlParameter("@U_Password",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = U_Name;
                    param[1].Value = U_Password;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@U_Name", DbType.String),
                                              new SQLiteParameter("@U_Password",DbType.String)
                                          };
                    p[0].Value = U_Name;
                    p[1].Value = U_Password;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break; ;
            }
            return ds;
        }
        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int AddUser(MU_UserInfo userInfo)
        {
            StringBuilder strSql = new StringBuilder();
            object obj = new object();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Insert into UserInfo(");
                    strSql.Append("U_Name,U_Password,U_Level,U_LoginTime");
                    strSql.Append(")values(");
                    strSql.Append("@U_Name,@U_Password,@U_Level,@U_LoginTime");
                    strSql.Append(") ");
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] param = {
                                   new SqlParameter("@U_Name",SqlDbType.VarChar,50),
                                   new SqlParameter("@U_Password",SqlDbType.VarChar,50),
                                   new SqlParameter("@U_Level",SqlDbType.Int,4),
                                   new SqlParameter("@U_LoginTime",SqlDbType.DateTime)
                                   };
                    param[0].Value = userInfo.U_Name;
                    param[1].Value = userInfo.U_Password;
                    param[2].Value = userInfo.U_Level;
                    param[3].Value = userInfo.U_LoginTime;
                    obj = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    strSql.Remove(0, strSql.Length);
                    strSql.Append("Insert into UserInfo(U_Name,U_Password,U_Level,U_LoginTime)values('");
                    strSql.Append(userInfo.U_Name);
                    strSql.Append("','");
                    strSql.Append(userInfo.U_Password);
                    strSql.Append("',");
                    strSql.Append(userInfo.U_Level.ToString());
                    strSql.Append(",'");
                    strSql.Append(userInfo.U_LoginTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    strSql.Append("')");
                    obj = SqlLiteHelper.ExecuteNonQuery(strSql.ToString());
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
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool UpdatePassword(string pwd, long key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update UserInfo set ");
            strSql.Append("U_Password = @U_Password ");
            strSql.Append("where U_Id = @U_Id");
            int rows = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                   new SqlParameter("@U_Id",SqlDbType.Int,4),
                                   new SqlParameter("@U_Password",SqlDbType.VarChar,50)
                                   };
                    param[0].Value = key;
                    param[1].Value = pwd;
                    rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@U_Id", DbType.Int32,4),
                                              new SQLiteParameter("@U_Password",DbType.String)
                                          };
                    p[0].Value = key;
                    p[1].Value = pwd;
                    rows = SqlLiteHelper.ExecuteNonQuery(strSql.ToString(), p);
                    break;
                default: break; ;
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
        /// 更新用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdateUser(MU_UserInfo userInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update UserInfo set ");
            strSql.Append("U_Name = @U_Name,");
            strSql.Append("U_Password = @U_Password,");
            strSql.Append("U_Level = @U_Level ");
            strSql.Append("where U_Id = @U_Id");

            int rows = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = {
                                       new SqlParameter("@U_Id", SqlDbType.Int, 4), 
                                       new SqlParameter("@U_Name", SqlDbType.VarChar, 50), 
                                       new SqlParameter("@U_Password", SqlDbType.VarChar, 50), 
                                       new SqlParameter("@U_Level", SqlDbType.Int, 4) 
                                   };
                    param[0].Value = userInfo.U_Id;
                    param[1].Value = userInfo.U_Name;
                    param[2].Value = userInfo.U_Password;
                    param[3].Value = userInfo.U_Level;
                    rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { 
                                              new SQLiteParameter("@U_Id", DbType.Int32,4),
                                              new SQLiteParameter("@U_Name",DbType.String),
                                              new SQLiteParameter("@U_Password",DbType.String),
                                              new SQLiteParameter("@U_Level",DbType.Int32,4)
                                          };
                    p[0].Value = userInfo.U_Id;
                    p[1].Value = userInfo.U_Name;
                    p[2].Value = userInfo.U_Password;
                    p[3].Value = userInfo.U_Level;
                    rows = SqlLiteHelper.ExecuteNonQuery(strSql.ToString(), p);
                    break;
                default: break; ;
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
        /// 删除一个用户
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public bool DeleteUser(int U_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From UserInfo ");
            strSql.Append("where U_Id = @U_Id");
            int rows = 0;
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { new SqlParameter("@U_Id", SqlDbType.Int, 4) };
                    param[0].Value = U_Id;
                    rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { new SQLiteParameter("@U_Id", DbType.Int32, 4) };
                    p[0].Value = U_Id;
                    rows = SqlLiteHelper.ExecuteNonQuery(strSql.ToString(), p);
                    break;
                default: break; ;
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
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllUser()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from UserInfo");
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
        /// 查询各权限用户
        /// </summary>
        /// <param name="U_Level"></param>
        /// <returns></returns>
        public DataSet QueryLevelUser(int U_Level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from UserInfo ");
            strSql.Append("where U_Level = @U_Level");
            DataSet ds = new DataSet();
            switch (Common.dataSaveType)
            {
                case (int)Enumerations.DataType.MsSql:
                    SqlParameter[] param = { new SqlParameter("@U_Level", SqlDbType.Int, 4) };
                    param[0].Value = U_Level;
                    ds = SqlHelper.DataSet(strSql.ToString(), param);
                    break;
                case (int)Enumerations.DataType.SqlLite:
                    SQLiteParameter[] p = { new SQLiteParameter("@U_Level", DbType.Int32, 4) };
                    p[0].Value = U_Level;
                    ds = SqlLiteHelper.ExecuteDataset(strSql.ToString(), p);
                    break;
                default: break;
            }
            return ds;
        }
    }
}
