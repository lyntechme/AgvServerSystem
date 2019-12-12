using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MatchStationInfo
    {
        public MatchStationInfo()
        { }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="agvNo">agv编号</param>
        /// <param name="rfid">站点RFID号</param>
        /// <param name="matchValue">匹配值</param>
        /// <param name="rfid">站点编号</param>
        /// <param name="stationCount">站点数量</param>
        /// <param name="stationCommand">站点操作命令</param>
        /// <param name="enable">使能</param>
        public MatchStationInfo(int agvNo, string matchValue,int rfid,  int stationCount, int stationCommand,bool enable,string groupValue)
        {
            this.AgvNo = agvNo;
            this.MatchValue = matchValue;
            this.StationCount = stationCount;
            this.StationCommand = stationCommand;
            this.StationRfid = rfid;
            this.Enable = enable;
            this.GroupValue = groupValue;
        }
        /// <summary>
        /// agv编号
        /// </summary>
        public int AgvNo { get; set; }
        /// <summary>
        /// 站点匹配值
        /// </summary>
        public string MatchValue { get; set; }
        /// <summary>
        /// 站点数量
        /// </summary>
        public int StationCount { get; set; }
        /// <summary>
        /// 站点操作命令
        /// </summary>
        public int StationCommand { get; set; }
        /// <summary>
        /// 站点RFID
        /// </summary>
        public int StationRfid { get; set; }
        /// <summary>
        /// 使能
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// 站点组别以及南北边
        /// </summary>
        public string GroupValue { get; set; }

    }
}
