using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// sql连接参数
    /// </summary>
    public class SqlCommInfo
    {
        /// <summary>
        /// 数据库地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Passward { get; set; }
        /// <summary>
        /// Database
        /// </summary>
        public string Database { get; set; }
    }
}
