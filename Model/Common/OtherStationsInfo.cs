using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 待机充电位信息
    /// </summary>
    public class OtherStationsInfo
    {
        /// <summary>
        /// 待机充电位信息初始化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="rfid">RFID</param>
        /// <param name="status">状态</param>
        public OtherStationsInfo(Enumerations.OtherStation type, int rfid, int status)
        {
            this.Type = type;
            this.Rfid = rfid;
            this.Status = status;
        }
        /// <summary>
        /// 位置类型
        /// </summary>
        public Enumerations.OtherStation Type { get; set; }
        /// <summary>
        /// 位置RFID
        /// </summary>
        public int Rfid { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        public int Status { get; set; }
    }
}
