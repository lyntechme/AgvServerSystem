using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MA_AgvTaskInfo
    {
        public MA_AgvTaskInfo()
        {
            this.T_AgvNo = -1;
            this.IsUpdate = false;
            this.IsTest = false;
            this.CodeIndex = -1;
            this.isAutoTask = false;
            this.taskOperate = (int)ETaskOperate.init;
            this.IsCanComplete = true;
            this.IsWriteComplete = true;
            this.IsWriteSQL = false;
        }
        //public MA_AgvTaskInfo(int id,int agvNo,string lineNo,string workTime,DateTime time)
        //{
        //    this.T_Id = id;
        //    this.T_AgvNo = agvNo;
        //    this.T_LineNo = lineNo;
        //    this.T_WorkTime = workTime;
        //    this.T_UpdateTime = time;
        //}
        /// <summary>
        /// 任务编号
        /// </summary>
        public string T_Id { get; set; }
        /// <summary>
        /// 绑定Agv编号
        /// </summary>
        public int T_AgvNo { get; set; }
        /// <summary>
        /// 任务等级 2:最高，1：普通，0：最低
        /// </summary>
        public int T_Level { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public Enumerations.TaskType T_Type { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public Enumerations.TaskStatus T_State { get; set; }
        /// <summary>
        /// 上料点
        /// </summary>
        public int T_Load { get; set; }
        /// <summary>
        /// 用于软件重启后，开始路段编号
        /// </summary>
        public int T_RestRfid { get; set; }
        /// <summary>
        /// 记录任务时使用，任务名称
        /// </summary>
        public string T_TaskName { get; set; }
        /// <summary>
        /// 记录任务时使用，任务描述
        /// </summary>
        public string T_Description { get; set; }
        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTime T_CreateTime { get; set; }
        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime T_StartTime { get; set; }
        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime T_FinishTime { get; set; }
        /// <summary>
        /// 物料信息
        /// </summary>
        public string T_MaterialInfo { get; set; }
        /// <summary>
        /// 站点集合
        /// </summary>
        public List<RouteInfo> T_Process = new List<RouteInfo>();
        /// <summary>
        /// 站点当前索引
        /// </summary>
        public int ProcessIndex { get; set; }
        /// <summary>
        /// 是否为测试任务 true:测试任务，false:mes任务
        /// </summary>
        public bool IsTest { get; set; }
        /// <summary>
        /// 是否任务完成且回传mes成功
        /// </summary>
        public bool IsUpdate { get; set; }
        /// <summary>
        /// 任务组别
        /// </summary>
        public int Group { get; set; }
        /// <summary>
        /// 分容测试二维码集合
        /// </summary>
        public List<string> CodeStrings = new List<string>();
        /// <summary>
        /// 二维码回传索引
        /// </summary>
        public int CodeIndex { get; set; }
        /// <summary>
        /// 是否为自动任务
        /// </summary>
        public bool isAutoTask { get; set; }
        ///// <summary>
        ///// 是否为mes任务
        ///// </summary>
        //public bool isMessTask { get; set; }
        /// <summary>
        /// 是否执行删除任务操作
        /// </summary>
        public int taskOperate { get; set; }
        /// <summary>
        /// 中间缓冲RFID,用于转接路段
        /// </summary>
        public int BufferRfid { get; set; }
        /// <summary>
        /// mes任务是否可完成
        /// </summary>
        public bool IsCanComplete { get; set; }
        /// <summary>
        /// 前往上下料区的任务，是否处于已向mes写入完成状态
        /// </summary>
        public bool IsWriteComplete { get; set; }
        /// <summary>
        /// 是否已经写入数据库
        /// </summary>
        public bool IsWriteSQL { get; set; }
    }
    public enum ETaskOperate
    {
        /// <summary>
        /// 初始状态
        /// </summary>
        init = 0,
        /// <summary>
        /// 请求删除任务
        /// </summary>
        delete = 1,
        /// <summary>
        /// 删除任务完成
        /// </summary>
        deleteComplete,
    };
}
