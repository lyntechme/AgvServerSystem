using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    public class InventoryLocationLayoutInfo
    {
        public InventoryLocationLayoutInfo()
        { }
        public InventoryLocationLayoutInfo(string name,int aisleNo, int slotNo, point location, point size, int id, int[] rfids)
        {
            this.Name = name;
            this.aisle = aisleNo;
            this.slot = slotNo;
            this.location = location;
            this.size = size;
            this.Id = id;
            this.RfidLs.Clear();
            this.RfidLs.AddRange(rfids);
        }
        public string Name { get; set; }
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
        public int aisle { get; set; }
        /// <summary>
        /// 站点尺寸
        /// </summary>
        public int slot { get; set; }

        public point location { get; set; }
        public point size { get; set; }
        //public object Location { get; set; }
    }
}
