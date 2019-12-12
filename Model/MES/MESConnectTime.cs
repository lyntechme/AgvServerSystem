using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 与MES通讯的接口刷新时间   单位:s
    /// </summary>
    public class MESConnectTime
    {
        /// <summary>
        /// 获取任务时间
        /// </summary>
        public int GetTaskTime { get; set; }
        /// <summary>
        /// 更新AGV状态至MES时间
        /// </summary>
        public int UpdateAgvStateTime { get; set; }
        /// <summary>
        /// 刷新任务时间
        /// </summary>
        public int UpdateTaskTime { get; set; }
    }
}
