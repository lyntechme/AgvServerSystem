using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InventoryLocationInfo
    {
        #region Properties
        public string Name { get; set; }

        /// <summary>
        /// 站点ID
        /// </summary>
        public int Id { get; set; }
        public int InvLocId { get; set; }
        
        public point Location { get; set; }
        public point Size { get; set; }
        
        
        /// <summary>
        /// 地图编号
        /// </summary>
        public int aisleNo { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public int slotNo { get; set; }


        public string invType { get; set; }
        /// <summary>
        /// Rfid编号
        /// </summary>
        public List<int> RfidLs = new List<int>();

        /// <summary>
        /// 站点类型
        /// </summary>
        public string WordAddress { get; set; }
        /// <summary>
        /// 站点使能
        /// </summary>
        public int bitAddress { get; set; }
        /// <summary>
        /// 通讯信息
        /// </summary>
        //  public StationConnectInfo ConnectInfo { get; set; }
        /// <summary>
        /// 创建的控件参数
        /// </summary>
        //   public StationLayoutInfo LayoutInfo { get; set; }
        #endregion
        public InventoryLocationInfo()
        {
            // this.ConnectInfo = new StationConnectInfo();
            this.LayoutInfo = new InventoryLocationLayoutInfo();
        }
        /// <summary>
        /// 站点初始化
        /// </summary>

        public InventoryLocationInfo(int id, string name,int aisleNo, int slotNo,point location,point size, string invType, string wordAddr,int bitAddr, int[] rfids, InventoryLocationLayoutInfo layoutInfo)
        {
            this.Id = id;
            this.InvLocId = id;
            this.Location = location;
            this.Size = size;
            this.Name = name;
            this.RfidLs.Clear();
            this.RfidLs.AddRange(rfids);
            this.aisleNo = aisleNo;
            this.slotNo = slotNo;
            this.InvType = InvType;
            this.LayoutInfo = layoutInfo;
            this.WordAddress = wordAddr;
            this.bitAddress = bitAddr;

        }

        public InventoryLocationLayoutInfo LayoutInfo
        { get; set; }


        /// <summary>
        /// 站点类型
        /// </summary>
        public String InvType
        {
            get; set;
            ///// <summary>
            ///// 上料点
            ///// </summary>
            //Load = 0,
            ///// <summary>
            ///// 下料点
            ///// </summary>
            //Unload = 1,
            ///// <summary>
            ///// 上下料点
            ///// </summary>
            //Load_Unload = 2,
            ///// <summary>
            ///// 充电桩
            ///// </summary>
            //Charge = 3,
            ///// <summary>
            ///// 其它类型
            ///// </summary>
            //Other = 4,
        }
        public int MapNo { get; set; }
    }
}
