using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MA_RfidPoint
    {
        public MA_RfidPoint()
        {
            this.RfidInfos = new List<RfidInfo>();
        }
        public MA_RfidPoint(int _rfidNo, int _rfidX, int _rfidY, int _mapNo, string _layout, int _group, List<RfidInfo> _rfidInfos)
        {
            this.RfidNo = _rfidNo;
            this.RfidX = _rfidX;
            this.RfidY = _rfidY;
            this.MapNo = _mapNo;
            this.RfidLayout = _layout;
            this.Group = _group;
            this.RfidInfos = _rfidInfos;
        }
        /// <summary>
        /// Rfid编号
        /// </summary>
        public int RfidNo { get; set; }
        /// <summary>
        /// Rfid的X轴坐标
        /// </summary>
        public int RfidX { get; set; }
        /// <summary>
        /// Rfid的Y轴坐标
        /// </summary>
        public int RfidY { get; set; }
        /// <summary>
        /// Rfid所处电子地图编号
        /// </summary>
        public int MapNo { get; set; }
        /// <summary>
        /// 组别
        /// </summary>
        public int Group { get; set; }
        /// <summary>
        /// Rfid点Agv的布局
        /// </summary>
        public string RfidLayout { get; set; }
        /// <summary>
        /// rfid路段分支集合
        /// </summary>
        public List<RfidInfo> RfidInfos;
    }
}
