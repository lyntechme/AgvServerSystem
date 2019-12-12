using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// agv类型参数
    /// </summary>
    public class AgvTypeInfo
    {
        public AgvTypeInfo()
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type">类型</param>
        /// <param name="_taskEnable">任务刷新使能</param>
        /// <param name="_taskTime">任务刷新间隔时间</param>
        public AgvTypeInfo(Enumerations.agvType _type, bool _taskEnable, int _taskTime)
        {
            this.Type = _type;
            this.TaskRefreshEnable = _taskEnable;
            this.TaskRefreshTime = _taskTime;
        }
        /// <summary>
        /// agv类型
        /// </summary>
        public Enumerations.agvType Type { get; set; }
        /// <summary>
        /// 任务刷新使能
        /// </summary>
        public bool TaskRefreshEnable { get; set; }
        /// <summary>
        /// 任务刷新间隔时间
        /// </summary>
        public int TaskRefreshTime { get; set; }
        /// <summary>
        /// 最近一次刷新时间
        /// </summary>
        public DateTime TaskRefreshLastTime { get; set; }
    }
}
