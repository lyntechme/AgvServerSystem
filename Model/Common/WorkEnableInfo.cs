using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 上下料点信息
    /// </summary>
    public class WorkEnableInfo
    {
        /// <summary>
        /// 上下料点信息初始化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="inEnable">进入使能</param>
        /// <param name="outPass">放行使能</param>
        /// <param name="arriveStation">到达料点</param>
        public WorkEnableInfo(RouteType type, bool inEnable, bool outPass, bool arriveStation, int routeNo, int testStationNo)
        {
            this.Type = type;
            this.InEnable = inEnable;
            this.OutPass = outPass;
            this.ArriveStation = arriveStation;
            this.RouteNo = routeNo;
            this.TestStationNo = testStationNo;
        }
        /// <summary>
        /// 类型
        /// </summary>
        public RouteType Type { get; set; }
        /// <summary>
        /// 进入使能
        /// </summary>
        public bool InEnable { get; set; }
        /// <summary>
        /// 料点放行
        /// </summary>
        public bool OutPass { get; set; }
        /// <summary>
        /// 料点请求回传
        /// </summary>
        public bool QueryBack { get; set; }
        /// <summary>
        /// 到达料点信号
        /// </summary>
        public bool ArriveStation { get; set; }
        /// <summary>
        /// 料点任务确认
        /// </summary>
        public int TaskBask { get; set; }
        /// <summary>
        /// 当前运送料架号
        /// </summary>
        public int stationNo { get; set; }
        /// <summary>
        /// 路段编号
        /// </summary>
        public int RouteNo { get; set; }
        /// <summary>
        /// 任务站点编号
        /// </summary>
        public int TestStationNo { get; set; }
    }
    /// <summary>
    /// 料点类型
    /// </summary>
    public enum LoadStationType
    {
        /// <summary>
        /// 上料点
        /// </summary>
        LoadType,
        /// <summary>
        /// 下料点
        /// </summary>
        UnloadType,
    }
}
