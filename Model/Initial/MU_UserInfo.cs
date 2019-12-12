using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class MU_UserInfo
    {
        public MU_UserInfo()
        { }
        public MU_UserInfo(int _id,string _name,string _pwd,int _level,DateTime _time)
        {
            this.U_Id = _id;
            this.U_Name = _name;
            this.U_Password = _pwd;
            this.U_Level = _level;
            this.U_LoginTime = _time;
        }
        /// <summary>
        /// 用户id
        /// </summary>
        public int U_Id
        {
            get;
            set;
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string U_Name
        {
            get;
            set;
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string U_Password
        {
            get;
            set;
        }
        /// <summary>
        /// 用户权限级别
        /// </summary>
        public int U_Level
        {
            get;
            set;
        }
        /// <summary>
        /// U_LoginTime
        /// </summary>
        public DateTime U_LoginTime
        {
            get;
            set;
        }
    }
}
