using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Model;

namespace DAL
{
    public class SqlHelper
    {
        #region 获取数据库连接对象
        private static SqlConnection connection;
        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        public static SqlConnection GetConnection
        {
            get
            {
                string strConn;
                //判断使用什么参数来初始化数据库连接参数
                lock (Common.lsXmlPParameter)
                {
                    if (Common.sqlCommInfo.Address== string.Empty || Common.sqlCommInfo.Name == string.Empty || Common.sqlCommInfo.Passward ==string.Empty || Common.sqlCommInfo.Database == string.Empty)
                    {
                        strConn = ConfigurationManager.ConnectionStrings["AgvDB"].ConnectionString;                        
                        string[] strlist = strConn.Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        Common.sqlCommInfo.Address = strlist[1];
                        Common.sqlCommInfo.Database = strlist[3];
                        Common.sqlCommInfo.Name = strlist[5];
                        Common.sqlCommInfo.Passward = strlist[7];
                    }
                    else
                    {
                        StringBuilder str = new StringBuilder();
                        str.Append("server =");
                        str.Append(Common.sqlCommInfo.Address);
                        str.Append(";DataBase =");
                        str.Append(Common.sqlCommInfo.Database);
                        str.Append(";uid =");
                        str.Append(Common.sqlCommInfo.Name);
                        str.Append(";pwd=");
                        str.Append(Common.sqlCommInfo.Passward);
                        str.Append(";");
                        strConn = str.ToString();
                    }
                }
                if (connection == null)
                {
                    connection = new SqlConnection(strConn);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection = new SqlConnection(strConn);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        #endregion //获取数据库连接对象

        #region 简单SQL命令
        /// <summary>
        /// 创建SqlCommand对象，sql语句可以不带参数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static SqlCommand Command(string strSql)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, GetConnection))
            {
                return cmd;
            }
        }
        /// <summary>
        /// 创建SqlCommand对象，Sql语句可以带参数
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static SqlCommand Command(string strSql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, GetConnection))
            {
                if (values != null) cmd.Parameters.AddRange(values);
                return cmd;
            }
        }
        /// <summary>
        /// 返回前向只读的结果集对象 sql语句不带参数(查询)
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string strSql)
        {
            using (SqlCommand cmd = Command(strSql))
            {
                return cmd.ExecuteReader();
            }
        }
        /// <summary>
        /// 返回前向只读的结果集对象 sql语句带参数(查询)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string strSql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = Command(strSql, values))
            {
                return cmd.ExecuteReader();
            }
        }
        /// <summary>
        /// 返回第一行第一列的值 sql语句不带参数(查询)
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string strSql)
        {
            using (SqlCommand cmd = Command(strSql))
            {
                return cmd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 返回第一行第一列的值 sql语句带参数(查询)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string strSql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = Command(strSql, values))
            {
                return cmd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 返回受影响的行数 sql语句不带参数(更新 添加 删除)
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string strSql)
        {
            using (SqlCommand cmd = Command(strSql))
            {
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 返回受影响的行数 sql语句带参数(更新 添加 删除)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string strSql, params SqlParameter[] values)
        {
            using (SqlCommand cmd = Command(strSql, values))
            {
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 断开连接方式的结果集，sql语句不带参数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable DataTable(string strSql)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(strSql, GetConnection))
            {
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }
        /// <summary>
        /// 断开连接方式的结果集，sql语句带参数
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataTable DataTable(string strSql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(strSql, GetConnection))
            {
                adapter.SelectCommand.Parameters.AddRange(values);
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }
        /// <summary>
        /// 断开连接方式的结果集，sql语句不带参数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataSet DataSet(string strSql)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(strSql, GetConnection))
            {
                adapter.Fill(ds);
                return ds;
            }
        }
        /// <summary>
        /// 断开连接方式的结果集，sql语句带参数
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataSet DataSet(string strSql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(strSql, GetConnection))
            {
                adapter.SelectCommand.Parameters.AddRange(values);
                adapter.Fill(ds);
                return ds;
            }
        }
        #endregion //简单SQL命令

        #region 使用存储过程获取SqlCommand对象
        /// <summary>
        /// 使用不带参数存储过程的获得SQLCommand对象
        /// </summary>
        /// <param name="ProcName">存储过程名称</param>
        /// <returns></returns>
        public static SqlCommand ProCommand(string ProcName)
        {
            using (SqlCommand comm = new SqlCommand(ProcName, GetConnection))
            {
                comm.CommandType = CommandType.StoredProcedure;
                return comm;
            }
        }
        /// <summary>
        /// 使用不带参数存储过程的获得SQLCommand对象
        /// </summary>
        /// <param name="ProcName">存储过程名称</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public static SqlCommand ProCommand(string ProcName, params SqlParameter[] param)
        {
            using (SqlCommand comm = new SqlCommand(ProcName, GetConnection))
            {
                comm.Parameters.AddRange(param);
                comm.CommandType = CommandType.StoredProcedure;
                return comm;
            }
        }
        /// <summary>
        /// 存储过程返回一个前向只读的结果集
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static SqlDataReader ProExecuteReader(string ProName)
        {
            using (SqlCommand comd = ProCommand(ProName))
            {
                return comd.ExecuteReader();
            }
        }
        /// <summary>
        /// 带参数存储过程返回一个前向只读的结果集
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SqlDataReader ProExecuteReader(string ProName, params SqlParameter[] param)
        {
            using (SqlCommand comd = ProCommand(ProName, param))
            {
                return comd.ExecuteReader();
            }
        }
        /// <summary>
        /// 存储过程返回第一行第一列
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static object ProExecuteScalar(string ProName)
        {
            using (SqlCommand comd = ProCommand(ProName))
            {
                return comd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 带参数存储过程返回第一行第一列
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ProExecuteScalar(string ProName, params SqlParameter[] param)
        {
            using (SqlCommand comd = ProCommand(ProName, param))
            {
                return comd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 不带参数的存储过程的实现受影响行数
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public static int ProExecuteNonQuery(string ProName)
        {
            using (SqlCommand comd = ProCommand(ProName))
            {
                return comd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 带参数的存储过程的实现受影响行数
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ProExecuteNonQuery(string ProName, params SqlParameter[] param)
        {
            using (SqlCommand comd = ProCommand(ProName, param))
            {
                return comd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 使用不带参数存储过程获得DataSet对象
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public DataSet ProDataSet(string ProName)
        {
            DataSet ds = new DataSet();
            using (SqlCommand comd = ProCommand(ProName))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
                {
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        /// <summary>
        /// 使用带参数存储过程获得DataSet对象
        /// </summary>
        /// <param name="ProName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet ProDataSet(string ProName, params SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlCommand comd = ProCommand(ProName, param))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
                {
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //cmd属性赋值
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //是否需要用到事务处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion //使用存储过程获取SqlComman对象

        #region Access操作
        /// <summary>
        /// ACCESS高效分页：当表的主键是字符串类型时候
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页容量</param>
        /// <param name="strKey">主键</param>
        /// <param name="showString">显示的字段</param>
        /// <param name="queryString">查询字符串，支持联合查询</param>
        /// <param name="whereString">查询条件，若有条件限制则必须以where 开头</param>
        /// <param name="orderString">排序规则</param>
        /// <param name="pageCount">传出参数：总页数统计</param>
        /// <param name="recordCount">传出参数：总记录统计</param>
        /// <returns>装载记录的DataTable</returns>
        public static DataTable ExecutePagerWhenPrimaryIsString(int pageIndex, int pageSize, string strKey, string showString, string queryString, string whereString, string orderString, out int pageCount, out int recordCount)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            if (string.IsNullOrEmpty(showString)) showString = "*";
            if (string.IsNullOrEmpty(orderString)) orderString = strKey + " asc ";
            SqlConnection m_Conn = GetConnection;

            try
            {
                m_Conn.Open();
            }
            catch { }
            string myVw = string.Format(" ( {0} ) tempVw ", queryString);
            SqlCommand cmdCount = new SqlCommand(string.Format(" select count(*) as recordCount from {0} {1}", myVw, whereString), m_Conn);

            recordCount = Convert.ToInt32(cmdCount.ExecuteScalar());

            if ((recordCount % pageSize) > 0)
                pageCount = recordCount / pageSize + 1;
            else
                pageCount = recordCount / pageSize;
            SqlCommand cmdRecord;
            if (pageIndex == 1)//第一页
            {
                string sql = string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, whereString, orderString);
                cmdRecord = new SqlCommand(sql, m_Conn);
            }
            else if (pageIndex > pageCount)//超出总页数
            {
                string sql = string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, "where 1=2", orderString);
                cmdRecord = new SqlCommand(sql, m_Conn);
            }
            else
            {
                int pageLowerBound = pageSize * pageIndex;
                int pageUpperBound = pageLowerBound - pageSize;
                string recordIDs = recordIDString(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageLowerBound, strKey, myVw, whereString, orderString), pageUpperBound);
                string queryStringend = string.Format("select {0} from {1} where {2} in ({3}) order by {4} ", showString, myVw, strKey, recordIDs, orderString);
                cmdRecord = new SqlCommand(queryStringend, m_Conn);

            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdRecord);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            m_Conn.Close();
            m_Conn.Dispose();
            return dt;

        }

        /// <summary>
        /// 分页使用
        /// </summary>
        /// <param name="query"></param>
        /// <param name="passCount"></param>
        /// <returns></returns>
        private static string recordID(string query, int passCount)
        {
            SqlConnection m_Conn = GetConnection;

            try
            {
                m_Conn.Open();
            }
            catch { }
            SqlCommand cmd = new SqlCommand(query, m_Conn);
            string result = string.Empty;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (passCount < 1)
                    {
                        result += "," + dr.GetInt32(0);
                    }
                    passCount--;
                }
            }
            // m_Conn.Close();
            // m_Conn.Dispose();
            return result.Substring(1);

        }

        /// <summary>
        /// 分页使用:主键是字符串类型时候
        /// </summary>
        /// <param name="query"></param>
        /// <param name="passCount"></param>
        /// <returns></returns>
        private static string recordIDString(string query, int passCount)
        {
            SqlConnection m_Conn = GetConnection;

            try
            {
                m_Conn.Open();
            }
            catch { }
            SqlCommand cmd = new SqlCommand(query, m_Conn);
            string result = string.Empty;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (passCount < 1)
                    {
                        result += ",'" + dr.GetString(0) + "'";
                    }
                    passCount--;
                }
            }
            //  m_Conn.Close();
            // m_Conn.Dispose();
            return result.Substring(1);

        }
        #endregion //Access操作
    }
}
