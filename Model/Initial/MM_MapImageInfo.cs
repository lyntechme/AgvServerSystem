using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MM_MapImageInfo
    {
        /// <summary>
        /// 电子地图编号
        /// </summary>
        public int M_Id { get; set; }
        /// <summary>
        /// 电子地图背景图
        /// </summary>
        public List<byte> M_Image { get; set; }
        /// <summary>
        /// 序列化为xml的Rfid坐标
        /// </summary>
        public string M_RfidPoingXml { get; set; }
        /// <summary>
        /// 电子地图Rfid坐标
        /// </summary>
        public List<int[]> M_RfidPoint { get; set; }
    }
}
