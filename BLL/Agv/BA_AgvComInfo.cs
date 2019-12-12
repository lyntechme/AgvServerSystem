using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BA_AgvComInfo
    {
        DA_AgvComInfo daaci = new DA_AgvComInfo();

        /// <summary>
        /// 查询该小车编号是否已经存在
        /// </summary>
        /// <param name="A_Id"></param>
        /// <returns></returns>
        public int ExistsId(int A_Id)
        {
            return daaci.ExistsId(A_Id);
        }
        /// <summary>
        /// 添加一个Agv对象
        /// </summary>
        /// <param name="maci"></param>
        /// <returns></returns>
        public int AddAgvComInfo(MA_AgvComInfo maci)
        {
            return daaci.AddAgvComInfo(maci);
        }
        /// <summary>
        /// 更新一个Agv对象
        /// </summary>
        /// <param name="maci"></param>
        /// <returns></returns>
        public bool UpdateAgvComInfo(MA_AgvComInfo maci)
        {
            return daaci.UpdateAgvComInfo(maci);
        }
        /// <summary>
        /// 删除一个Agv对象
        /// </summary>
        /// <param name="A_Id"></param>
        /// <returns></returns>
        public bool DeleteAgvComInfo(int A_Id)
        {
            return daaci.DeleteAgvComInfo(A_Id);
        }
        /// <summary>
        /// 查询所有的Agv对象
        /// </summary>
        /// <returns></returns>
        public List<MA_AgvComInfo> QueryAllAgvComInfo()
        {
            List<MA_AgvComInfo> maciList = new List<MA_AgvComInfo>(); ;
            DataSet ds = daaci.QueryAllAgvComInfo();
            try
            {
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    MA_AgvComInfo maci = new MA_AgvComInfo();
                    for (int i = 0; i < count; i++)
                    {
                        maci = new MA_AgvComInfo();
                        maci.A_Id = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                        maci.A_Description = ds.Tables[0].Rows[i][1].ToString();
                        maci.A_IpAddress = ds.Tables[0].Rows[i][2].ToString();
                        maci.A_NetNo = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                        maci.A_LocalPort = Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString());
                        maci.A_DesPort = Convert.ToInt32(ds.Tables[0].Rows[i][5].ToString());
                        string[] typeStr = ds.Tables[0].Rows[i][6].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        maci.A_AgvConnectType = typeStr[0];
                        maci.A_AgvCommonType=0;
                        try
                        {
                        if (typeStr.Length > 1)
                        {
                            maci.A_AgvCommonType = Convert.ToInt32(typeStr[1]);
                        }
                        }
                        catch{}
                        maci.A_IsUsing = Convert.ToBoolean(ds.Tables[0].Rows[i][7].ToString());
                        maciList.Add(maci);
                    }
                }
            }
            catch (Exception e)
            {
                maciList.Clear();
            }
            return maciList;
        }/// <summary>
        /// 更新A_IsUsing值
        /// </summary>
        /// <param name="isUsing"></param>
        /// <returns></returns>
        public bool UpdateIsUsing(Dictionary<int, bool> isUsing)
        {
            return daaci.UpdateIsUsing(isUsing);
        }
    }
}
