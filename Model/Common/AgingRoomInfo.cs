using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 老化房信息参数
    /// </summary>
    public class AgingRoomInfo
    {
        public AgingRoomInfo()
        { }
        /// <summary>
        /// 老化房任务类型
        /// </summary>
        public Enumerations.agvType TaskType { get; set; }
        /// <summary>
        /// 上料区待机位RFID
        /// </summary>
        public int LoadRfid { get; set; }
        /// <summary>
        /// 静置区任务位1
        /// </summary>
        public int StaticArea1Rfid { get; set; }
        /// <summary>
        /// 静置区任务位2
        /// </summary>
        public int StaticArea2Rfid { get; set; }
        /// <summary>
        /// 下料区待机位RFID
        /// </summary>
        public int UnloadRfid { get; set; }
    }
}
