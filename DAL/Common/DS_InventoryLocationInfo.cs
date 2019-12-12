using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;

namespace DAL
{
    public class DS_InventoryLocationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public DataSet QureyInventoryLocationInfo(string aisleNo, string slotNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from InventoryLocationInfo where aisleNumber =" + aisleNo + " and slotNumber = " + slotNo);
            DataSet ds = new DataSet();
            return ds = SqlLiteHelper.ExecuteDataset(strSql.ToString());
        }
        /// <summary>
        /// 查询所有StationAddressInfo信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllInventoryLocationInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aisleNumber,slotNumber,inventoryType,wordAddress,bitAddress,rfid from InentoryLocationInfo");
            return SqlLiteHelper.ExecuteDataset(strSql.ToString());
        }
        /// <summary>
        /// 删除重置所有的地址对应
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool RefInventoryLocationInfo(DataSet ds)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Delete from InventoryLocationInfo");
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
                                cmd.CommandText = "INSERT INTO InventoryLocationInfo(aisleNumber,slotNumber,inventoryType,wordAddress,bitAddress,rfid) VALUES(@aisleNo,@slotNo,@invType,@wordAddress,@bitAddress,@rfid)";
                                SQLiteParameter[] p = {
                                              new SQLiteParameter("@aisleNo", DbType.Int32 ,4),
                                              new SQLiteParameter("@sotNo", DbType.Int32,4),
                                              new SQLiteParameter("@invType",DbType.String),
                                              new SQLiteParameter("@wordAddress", DbType.Int32,4),
                                              new SQLiteParameter("@bitAddress", DbType.Int32,4),
                                              new SQLiteParameter("@rfid",DbType.Int32,4)
                                          };
                                cmd.Parameters.AddRange(p);
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    try
                                    {
                                        int _aisleNo = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                                        int _slotNo = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                                        string _invType = Convert.ToString(ds.Tables[0].Rows[i][2].ToString());
                                        int _wordAddress = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                                        int _bitAddress = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                                        int _rfid = Convert.ToInt32(ds.Tables[0].Rows[i][5].ToString());
                                        p[0].Value = _aisleNo;
                                        p[1].Value = _slotNo;
                                        p[2].Value = _invType;
                                        p[3].Value = _wordAddress;
                                        p[4].Value = _bitAddress;
                                        p[5].Value = _rfid;
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
