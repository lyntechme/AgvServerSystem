using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Model;

namespace BLL
{
    public class BU_UserInfo
    {
        DU_UserInfo userInfo = new DU_UserInfo();
        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="U_Name"></param>
        /// <returns></returns>
        public int ExistsName(string U_Name)
        {
            return userInfo.ExistsName(U_Name);
        }
        /// <summary>
        /// 查询用户密码是否存在
        /// </summary>
        /// <param name="U_Name"></param>
        /// <param name="U_Password"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string U_Name, string U_Password)
        {
            return userInfo.ExistsPwd(U_Name, U_Password);
        }
        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUser(MU_UserInfo model)
        {
            return userInfo.AddUser(model);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool UpdatePassword(string pwd, long key)
        {
            return userInfo.UpdatePassword(pwd, key);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateUser(MU_UserInfo model)
        {
            return userInfo.UpdateUser(model);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public bool DeleteUser(int U_Id)
        {
            return userInfo.DeleteUser(U_Id);
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<MU_UserInfo> QueryAllUser()
        {
            List<MU_UserInfo> muiList = new List<MU_UserInfo>();
            DataSet ds = userInfo.QueryAllUser();
            try
            {
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        MU_UserInfo mui = new MU_UserInfo();
                        mui.U_Id = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                        mui.U_Name = ds.Tables[0].Rows[i][1].ToString();
                        mui.U_Password = ds.Tables[0].Rows[i][2].ToString();
                        mui.U_Level = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                        if (ds.Tables[0].Rows[i][4] != null)
                        {
                            mui.U_LoginTime = Convert.ToDateTime(ds.Tables[0].Rows[i][4].ToString());
                        }
                        else
                        {
                            mui.U_LoginTime = DateTime.Now;
                        }
                        muiList.Add(mui);
                    }
                }
            }
            catch
            {
                muiList.Clear();
            }
            return muiList;
        }
        /// <summary>
        /// 查询权限用户
        /// </summary>
        /// <param name="U_Level"></param>
        /// <returns></returns>
        public List<MU_UserInfo> QueryLevelUser(int U_Level)
        {
            List<MU_UserInfo> muiList = new List<MU_UserInfo>();
            DataSet ds = userInfo.QueryLevelUser(U_Level);
            try
            {
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        MU_UserInfo mui = new MU_UserInfo();
                        mui.U_Id = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                        mui.U_Name = ds.Tables[0].Rows[i][1].ToString();
                        mui.U_Password = ds.Tables[0].Rows[i][2].ToString();
                        mui.U_Level = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                        if (ds.Tables[0].Rows[i][4] != null)
                        {
                            mui.U_LoginTime = Convert.ToDateTime(ds.Tables[0].Rows[i][4].ToString());
                        }
                        else
                        {
                            mui.U_LoginTime = DateTime.Now;
                        }
                        muiList.Add(mui);
                    }
                }
            }
            catch
            {
                muiList.Clear();
            }
            return muiList;
        }
    }
}
