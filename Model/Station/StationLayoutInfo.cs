using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StationLayoutInfo
    {
        public StationLayoutInfo()
        { }
        public StationLayoutInfo(point location, point size, int id, int[] rfids)
        {
            this.Location = location;
            this.Size = size;
            this.Id = id;
            this.RfidLs.Clear();
            this.RfidLs.AddRange(rfids);
        }
        /// <summary>
        /// 站点编号 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 站点RFID编号 
        /// </summary>
        public List<int> RfidLs = new List<int>();
        /// <summary>
        /// 站点位置
        /// </summary>
        public point Location { get; set; }
        /// <summary>
        /// 站点尺寸
        /// </summary>
        public point Size { get; set; }
    }
}
