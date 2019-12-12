using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BS_InventoryLocationInfo
    {
        DS_InventoryLocationInfo dsai = new DS_InventoryLocationInfo();
        /// <summary>
        /// 根据条形码获取对应的物料信息
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public DataSet QureyInventoryLocationInfo(string aisleNo, string slotNo)
        {
            return this.dsai.QureyInventoryLocationInfo(aisleNo, slotNo);
        }
        /// <summary>
        /// 查询所有StationAddressInfo信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllInventoryLocationInfo()
        {
            return this.dsai.QueryAllInventoryLocationInfo();
        }
        /// <summary>
        /// 删除重置所有的地址对应
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool RefInventoryLocationInfo(DataSet ds)
        {
            return this.dsai.RefInventoryLocationInfo(ds);
        }
    }
}
