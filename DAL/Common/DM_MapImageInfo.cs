using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DM_MapImageInfo
    {
        /// <summary>
        /// 查询该电子地图信息是否存在
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public int ExistsId(int M_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from MapImage ");
            strSql.Append("Where ");
            strSql.Append("M_Id = @M_Id");
            SqlParameter[] param = { new SqlParameter("@M_Id", SqlDbType.Int, 4) };
            param[0].Value = M_Id;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(strSql.ToString(), param));
        }
        /// <summary>
        /// 添加一个新的电子地图信息
        /// </summary>
        /// <param name="mmii"></param>
        /// <returns></returns>
        public int AddMapImageInfo(MM_MapImageInfo mmii)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Insert into MapImage(");
            strSql.Append("M_Id,M_Image,M_RfidPoint");
            strSql.Append(")values(");
            strSql.Append("@M_Id,@M_Image,@M_RfidPoint");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] param = { 
                                       new SqlParameter("@M_Id", SqlDbType.Int, 4), 
                                       new SqlParameter("@M_Image", SqlDbType.Image), 
                                       new SqlParameter("@M_RfidPoint", SqlDbType.Xml) 
                                   };
            param[0].Value = mmii.M_Id;
            param[1].Value = mmii.M_Image.ToArray();
            param[2].Value = mmii.M_RfidPoingXml;
            object obj = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
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
        /// 更新一个电子地图对象
        /// </summary>
        /// <param name="mmii"></param>
        /// <returns></returns>
        public bool UpdateMapImageInfo(MM_MapImageInfo mmii)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update MapImage set ");
            strSql.Append("M_Image = @M_Image,");
            strSql.Append("M_RfidPoint = @M_RfidPoint ");
            strSql.Append("where M_Id = @M_Id");
            SqlParameter[] param = {
                                   new SqlParameter("@M_Id",SqlDbType.Int,4),
                                   new SqlParameter("@M_Image",SqlDbType.Image),
                                   new SqlParameter("@M_RfidPoint",SqlDbType.Xml),
                                   };
            param[0].Value = mmii.M_Id;
            param[1].Value = mmii.M_Image.ToArray();
            param[2].Value = mmii.M_RfidPoingXml;
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), param);
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
        /// 查询一个电子地图对象
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllMapImageInfo(int M_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from MapImage where M_Id = @M_Id");
            SqlParameter[] param = { new SqlParameter("@M_Id", SqlDbType.Int, 4) };
            param[0].Value = M_Id;
            DataSet ds = SqlHelper.DataSet(strSql.ToString(), param);
            return ds;
        }
    }
}
