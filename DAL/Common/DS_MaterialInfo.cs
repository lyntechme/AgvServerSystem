using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.Data.Common;
using System.Data.SQLite;

namespace DAL
{
    public class DS_MaterialInfo
    {
        /// <summary>
        /// 根据条形码获取对应的物料信息
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public DataSet QureyMaterialInfo(string BarCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from MaterialInfo where barCode ='" + BarCode + "'");
            DataSet ds = new DataSet();
            return ds = SqlLiteHelper.ExecuteDataset(strSql.ToString());
        }
        /// <summary>
        /// 查询所有MaterialInfo信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllMaterialInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select lineNo,barCode,materialName,stationNo from MaterialInfo");
            return SqlLiteHelper.ExecuteDataset(strSql.ToString());
        }
        /// <summary>
        /// 删除物料表数据，并重新全部写入
        /// </summary>
        /// <returns></returns>
        public bool RefMaterialInfo(DataSet ds)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Delete from MaterialInfo");
                if (SqlLiteHelper.ExecuteNonQuery(strSql.ToString()) >= 0)
                {
                    using (SQLiteConnection conn = SqlLiteHelper.GetSQLiteConnection())
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        using (DbTransaction dbTrans = conn.BeginTransaction())
                        {
                            using (DbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = "INSERT INTO MaterialInfo(lineNo,barCode,materialName,stationNo) VALUES(@lineNo,@barCode,@materialName,@stationNo)";
                                SQLiteParameter[] p = { 
                                              new SQLiteParameter("@lineNo", DbType.Int32 ,4),
                                              new SQLiteParameter("@barCode", DbType.String),
                                              new SQLiteParameter("@materialName", DbType.String),
                                              new SQLiteParameter("@stationNo", DbType.Int32,4)
                                          };
                                cmd.Parameters.AddRange(p);
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    try
                                    {
                                        int _lineNo = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                                        string _barCode = ds.Tables[0].Rows[i][1].ToString();
                                        string _materialName = ds.Tables[0].Rows[i][2].ToString();
                                        int _stationNo = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                                        p[0].Value = _lineNo;
                                        p[1].Value = _barCode;
                                        p[2].Value = _materialName;
                                        p[3].Value = _stationNo;
                                    }
                                    catch (Exception e)
                                    { }
                                    int count = cmd.ExecuteNonQuery();
                                    if (count < 1)
                                    {
                                        return false;
                                    }
                                    //Thread.Sleep(1);
                                }
                                dbTrans.Commit();
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
