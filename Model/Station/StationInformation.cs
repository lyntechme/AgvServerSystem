using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StationInformation
    {
        /// <summary>
        /// 站点信息初始化
        /// </summary>
        public StationInformation()
        {
            this.Dock = false;
        }
        /// <summary>
        /// 站点信息初始化
        /// </summary>
        /// <param name="_key">关键值</param>
        /// <param name="_type">站点类型</param>
        /// <param name="_typeName">类型名称</param>
        /// <param name="_no">站点编号</param>
        /// <param name="_name">站点名称</param>
        /// <param name="_rfids">站点rfid集合</param>
        /// <param name="_matchVlaue">站点匹配值</param>
        /// <param name="_operate">站点信息</param>
        /// <param name="_enable">站点使能</param>
        /// <param name="_describe">站点描述</param>
        /// <param name="_group">组别</param>
        public StationInformation(string _key, int _type, string _typeName, int _no, string _name, int[] _rfids, string _matchVlaue, string _operate, bool _enable, string _describe, int _group)
        {
            this.Key = _key;
            this.StationType = _type;
            this.TypeName = _typeName;
            this.StationNo = _no;
            this.StationName = _name;
            this.StationRfidLs.Clear();
            this.StationRfidLs.AddRange(_rfids.Distinct());
            this.StationMatchValue = _matchVlaue;
            this.StationOperate = _operate;
            this.StationEnable = _enable;
            this.StationDescribe = _describe;
            this.Group = _group;
            this.UpdateTime = new DateTime();
            this.State = (int)EStationState.Init;
            this.LastState = (int)EStationState.Init;
            this.PassRfid = -1;
            this.Dock = false;
            this.WriteValue = -1;
        }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 站点类型
        /// </summary>
        public int StationType { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int StationNo { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string StationName { get; set; }
        /// <summary>
        /// 站点RFID集合 可包含多个RFID
        /// </summary>
        public List<int> StationRfidLs = new List<int>();
        /// <summary>
        /// 站点匹配值
        /// </summary>
        public string StationMatchValue { get; set; }
        /// <summary>
        /// 站点操作
        /// </summary>
        public string StationOperate { get; set; }
        /// <summary>
        /// 站点使能
        /// </summary>
        public bool StationEnable { get; set; }
        /// <summary>
        /// 站点描述
        /// </summary>
        public string StationDescribe { get; set; }
        /// <summary>
        /// 对应OPC的handle
        /// </summary>
        public int Handle { get; set; }
        /// <summary>
        /// 绑定的AGV编号
        /// </summary>
        public int bindAgvNo { get; set; }
        private int _state;
        /// <summary>
        /// 站点状态
        /// </summary>
        public int State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    UpdateTime = DateTime.Now;
                }
            }
        }
        /// <summary>
        /// 上一次站点非预定状态
        /// </summary>
        public int LastState { get; set; }
        /// <summary>
        /// 允许进入RFID
        /// </summary>
        public int PassRfid { get; set; }
        /// <summary>
        /// 组别
        /// </summary>
        public int Group { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 可以停靠
        /// </summary>
        public bool Dock { get; set; }
        /// <summary>
        /// 可以不停靠
        /// </summary>
        public bool Undock { get; set; }
        /// <summary>
        /// 站点无物料，需要物料
        /// </summary>
        public bool LoadReady { get; set; }
        /// <summary>
        /// 站点有物料，需要拉走 
        /// </summary>
        public bool UnloadReady { get; set; }
        /// <summary>
        /// 已经写入对应OPC的值
        /// </summary>
        public int WriteValue { get; set; }
        /// <summary>
        /// 为Departed状态的时间
        /// </summary>
        public DateTime DepartedTime { get; set; }
        /// <summary>
        /// 站点操作
        /// </summary>
        public enum EStationOperate
        {
            /// <summary>
            /// 左上料 分容柜
            /// </summary>
            LeftLoad = 0,
            /// <summary>
            /// 左换料 分容柜
            /// </summary>
            LeftRefueling = 1,
            /// <summary>
            /// 左卸料 分容柜
            /// </summary>
            LeftUnload = 2,
            /// <summary>
            /// 右上料 分容柜
            /// </summary>
            RightLoad = 3,
            /// <summary>
            /// 右换料 分容柜
            /// </summary>
            RightRefueling = 4,
            /// <summary>
            /// 右卸料 分容柜
            /// </summary>
            RightUnload = 5,
            /// <summary>
            /// 平台上升 大精灵
            /// </summary>
            DropUp = 12,
            /// <summary>
            /// 平台下降 大精灵
            /// </summary>
            DropDown = 13,
            /// <summary>
            /// 平台下降后上升 大精灵
            /// </summary>
            DropUpAndDown = 230,

        };
        /// <summary>
        /// 站点类型
        /// </summary>
        public enum EStationType
        {
            /// <summary>
            /// F侧 待机点
            /// </summary>
            Wait = 1,
            /// <summary>
            /// F侧 A类型站点
            /// </summary>
            Type_A = 2,
            /// <summary>
            /// F侧 B类型站点
            /// </summary>
            Type_B = 3,
            /// <summary>
            /// F侧 C类型站点
            /// </summary>
            Type_C = 6,
            /// <summary>
            /// F侧 D类型站点
            /// </summary>
            Type_D = 7,
            /// <summary>
            /// F侧 E类型站点
            /// </summary>
            Type_E = 4,
            /// <summary>
            /// F侧 F类型站点
            /// </summary>
            Type_F = 5,
            /// <summary>
            /// F侧充电站点
            /// </summary>
            Charge = 8,

        };
    }
    public enum EStationState
    {
        /// <summary>
        /// 初始
        /// </summary>
        Init = 0,
        /// <summary>
        /// 空闲
        /// </summary>
        Free = 1,
        /// <summary>
        /// 忙碌
        /// </summary>
        Busy = 2,
        /// <summary>
        /// 预定
        /// </summary>
        Book = 3,

    };
}
