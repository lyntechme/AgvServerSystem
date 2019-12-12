using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 路段信息（写入到AGV的每个路段的信息）
    /// </summary>
    public class RouteInfo
    {
        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public RouteInfo()
        {
            this.BackState = -1;
            this.Enable = true;
        }
        /// <summary>
        /// 路段信息初始化
        /// </summary>
        /// <param name="type">路段类型</param>
        /// <param name="station">站点号</param>
        /// <param name="operation">动作编号</param>
        /// <param name="descr">描述</param>
        public RouteInfo(RouteType type, int station, int operation, string descr)
        {
            this.Route = type;
            this.Station = station;
            this.Operation = operation;
            this.Description = descr;
            this.State = 0;
            this.BackState = -1;
            this.Enable = true;
        }
        /// <summary>
        /// 索引编号，0为不需要回传mes的路段
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 路段类型
        /// </summary>
        public RouteType Route { get; set; }
        /// <summary>
        /// 站点号
        /// </summary>
        public int Station { get; set; }
        /// <summary>
        /// 到达站点后执行的动作
        /// </summary>
        public int Operation { get; set; }
        /// <summary>
        /// 描述，对该路段的介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 路段状态 0:初始状态，1:路段进行状态,2:路段完成状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 路段起始点
        /// </summary>
        public int SourceStation { get; set; }
        /// <summary>
        /// 回传mes状态  当为-1时，该路段为不需要回传路段  0:尚未开始，100000：开始执行，999999：执行完毕
        /// </summary>
        public int BackState { get; set; }
        /// <summary>
        /// 该路段是否可执行
        /// </summary>
        public bool Enable { get; set; }
    }
    public enum EBackState
    {
        /// <summary>
        /// 接受，没未执行
        /// </summary>
        Accept = 0,
        /// <summary>
        /// 开始执行
        /// </summary>
        Start = 100000,
        /// <summary>
        /// 完成
        /// </summary>
        Complete = 999999,
        /// <summary>
        /// 空垛板
        /// </summary>
        NullTray = 101010,
        /// <summary>
        /// 取消
        /// </summary>
        Cancel = 888000,
        /// <summary>
        /// 异常
        /// </summary>
        Error = 777000,
        /// <summary>
        /// 等待完成
        /// </summary>
        WaitComplete = 999000,
    }
    /// <summary>
    /// 路段类型
    /// </summary>
    public enum RouteType
    {
        /// <summary>
        /// 前往待机点
        /// </summary>
        GoWait,
        /// <summary>
        /// 前往上下料区
        /// </summary>
        CapacityLoad,
        /// <summary>
        /// 前往分容柜
        /// </summary>
        CapacityUnload,
        /// <summary>
        /// 测试路段
        /// </summary>
        TestRoute,
        /// <summary>
        /// 预充老化上料点
        /// </summary>
        PreAgingLoadArea = 11,
        /// <summary>
        /// 预充老化房存储位置
        /// </summary>
        PreAgingRoom = 12,
        /// <summary>
        /// 预充老化静置区
        /// </summary>
        PreStaticArea = 13,
        /// <summary>
        /// 预充老化下料点
        /// </summary>
        PreAgingUnloadArea = 14,
        /// <summary>
        /// 预充老化房到静置区任务点
        /// </summary>
        PreAgingStaticWait = 15,
        /// <summary>
        /// 卸料区等待点
        /// </summary>
        PreUnloadWait = 16,
        /// <summary>
        /// 分容老化上料点
        /// </summary>
        DCapAgingLoadArea = 21,
        /// <summary>
        /// 分容老化房存储位置
        /// </summary>
        DCapAgingRoom = 22,
        /// <summary>
        /// 分容老化静置区
        /// </summary>
        DCapStaticArea = 23,
        /// <summary>
        /// 分容老化下料点
        /// </summary>
        DCapAgingUnloadArea = 24,
        /// <summary>
        /// 分容老化房到静置区任务点
        /// </summary>
        DCapAgingStaticWait = 25,
        /// <summary>
        /// 分容老化卸料区等待点
        /// </summary>
        DCapUnloadWait = 26,
        /// <summary>
        /// 分容测试充电区
        /// </summary>
        ChargeCap = 31,
        /// <summary>
        /// 预充老化充电区
        /// </summary>
        ChargePreAging = 32,
        /// <summary>
        /// 分容老化充电区
        /// </summary>
        ChargeCapAging = 33,
        /// <summary>
        /// 分容agv闲置点
        /// </summary>
        TestCapcityLeaveUnused = 41,
        /// <summary>
        /// A站点到F站点
        /// </summary>
        A_F = 101,
        /// <summary>
        /// E站点到A站点
        /// </summary>
        E_A = 102,
        /// <summary>
        /// A站点到C站点
        /// </summary>
        A_C = 103,
        /// <summary>
        /// C站点到F站点
        /// </summary>
        C_F = 104,
        /// <summary>
        /// 回待机点1
        /// </summary>
        GoWait1 = 105,
        /// <summary>
        /// B站点到E站点
        /// </summary>
        B_E = 106,
        /// <summary>
        /// F站点到B站点
        /// </summary>
        F_B = 107,
        /// <summary>
        /// B站点到D站点
        /// </summary>
        B_D = 108,
        /// <summary>
        /// D站点到E站点
        /// </summary>
        D_E = 109,
        /// <summary>
        /// 回待机点2
        /// </summary>
        GoWait2 = 110, 
        /// <summary>
        /// 前往充电
        /// </summary>
        GoCharge=111,   
        /// <summary>
        /// 离开充电桩
        /// </summary>
        LeaveCharge=112,
    }
}
