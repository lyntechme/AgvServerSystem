using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StationInfo
    {
        #region Properties
        /// <summary>
        /// 站点ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 地图编号
        /// </summary>
        public int MapNo { get; set; }
        /// <summary>
        /// Rfid编号
        /// </summary>
        public List<int> RfidLs = new List<int>();
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 站点类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 站点使能
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// 通讯信息
        /// </summary>
        public StationConnectInfo ConnectInfo { get; set; }
        /// <summary>
        /// 创建的控件参数
        /// </summary>
        public StationLayoutInfo LayoutInfo { get; set; }
        #endregion
        public StationInfo()
        {
            this.ConnectInfo = new StationConnectInfo();
            this.LayoutInfo = new StationLayoutInfo();
        }
        /// <summary>
        /// 站点初始化
        /// </summary>
        /// <param name="id">站点ID</param>
        /// <param name="rfids">站点RFID</param>
        /// <param name="name">站点名称</param>
        /// <param name="type">站点类型</param>
        /// <param name="enable">站点使能</param>
        /// <param name="connectInfo">连接信息</param>
        /// <param name="layoutInfo">layout信息</param>
        public StationInfo(int id, int[] rfids, string name, int type, bool enable, StationConnectInfo connectInfo, StationLayoutInfo layoutInfo, int mapNo)
        {
            this.Id = id;
            this.RfidLs.Clear();
            this.RfidLs.AddRange(rfids);
            this.Name = name;
            this.Type = type;
            this.Enable = enable;
            this.ConnectInfo = connectInfo;
            this.LayoutInfo = layoutInfo;
            this.MapNo = MapNo;
        }

        /// <summary>
        /// 站点类型
        /// </summary>
        public enum StationType
        {
            /// <summary>
            /// 上料点
            /// </summary>
            Load = 0,
            /// <summary>
            /// 下料点
            /// </summary>
            Unload = 1,
            /// <summary>
            /// 上下料点
            /// </summary>
            Load_Unload = 2,
            /// <summary>
            /// 充电桩
            /// </summary>
            Charge = 3,
            /// <summary>
            /// 其它类型
            /// </summary>
            Other = 4,
        }
    }
}
