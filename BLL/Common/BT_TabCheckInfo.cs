using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class BT_TabCheckInfo
    {
        DT_TabCheckInfo dti = new DT_TabCheckInfo();
        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="T_Name"></param>
        /// <returns></returns>
        public int ExistsName(string T_Name)
        {
            return dti.ExistsName(T_Name);
        }
        /// <summary>
        /// 查询选卡是否被选中
        /// </summary>
        /// <param name="T_Name"></param>
        /// <returns></returns>
        public int ExistsChecked(string T_Name)
        {
            return dti.ExistsChecked(T_Name);
        }
        /// <summary>
        /// 更新选卡是否被选中状态
        /// </summary>
        /// <param name="T_Name"></param>
        /// <returns></returns>
        public bool UpdateChecked(string T_Name, int T_Checked)
        {
            return dti.UpdateChecked(T_Name, T_Checked);
        }
        /// <summary>
        /// 添加一选卡信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int AddChecked(MT_TabCheckInfo tabCheckInfo)
        {
            return dti.AddChecked(tabCheckInfo);
        }
    }
}
