using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CapacityTestWaitInfo
    {
        public CapacityTestWaitInfo()
        { }
        public CapacityTestWaitInfo(int _number, int _rfid, List<point> _stations, List<point> _rfids)
        {
            this.Number = _number;
            this.Rfid = _rfid;
            this.lsStations = _stations;
            this.lsRfids = _rfids;
            this.UpdateTime = new DateTime();
        }
        /// <summary>
        /// 待机点编号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 待机点RFID
        /// </summary>
        public int Rfid { get; set; }
        /// <summary>
        /// 返回该待机点的分容柜站点集合
        /// </summary>
        public List<point> lsStations = new List<point>();
        /// <summary>
        /// 返回该待机点的RFID集合
        /// </summary>
        public List<point> lsRfids = new List<point>();
        /// <summary>
        /// AGV最新到达该待机点的时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
