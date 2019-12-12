using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;

namespace DAL
{
    public class DS_StationAddressInfo
    {
        /// <summary>
        /// 根据条形码获取对应的物料信息
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public DataSet QureyStationAddressInfo(string lineNo, string stationNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from StationAddressInfo where lineNo =" + lineNo + " and stationNo = " + stationNo);
            DataSet ds = new DataSet();
            return ds = SqlLiteHelper.ExecuteDataset(strSql.ToString());
        }
        /// <summary>
        /// 查询所有StationAddressInfo信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllStationAddressInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select lineNo,stationNo,wordAddress,bitAddress,rfid from StationAddressInfo");
            return SqlLiteHelper.ExecuteDataset(strSql.ToString());
        }
        /// <summary>
        /// 删除重置所有的地址对应
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool RefStationAddressInfo(DataSet ds)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Delete from StationAddressInfo");
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
                                cmd.CommandText = "INSERT INTO StationAddressInfo(lineNo,stationNo,wordAddress,bitAddress,rfid) VALUES(@lineNo,@stationNo,@wordAddress,@bitAddress,@rfid)";
                                SQLiteParameter[] p = { 
                                              new SQLiteParameter("@lineNo", DbType.Int32 ,4),
                                              new SQLiteParameter("@stationNo", DbType.Int32,4),
                                              new SQLiteParameter("@wordAddress", DbType.Int32,4),
                                              new SQLiteParameter("@bitAddress", DbType.Int32,4),
                                              new SQLiteParameter("@rfid",DbType.Int32,4)
                                          };
                                cmd.Parameters.AddRange(p);
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    try
                                    {
                                        int _lineNo = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                                        int _stationNo = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                                        int _wordAddress = Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString());
                                        int _bitAddress = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                                        int _rfid = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                                        p[0].Value = _lineNo;
                                        p[1].Value = _stationNo;
                                        p[2].Value = _wordAddress;
                                        p[3].Value = _bitAddress;
                                        p[4].Value = _rfid;
                                    }
                                    catch (Exception ex)
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
