using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class BS_StatioinAddressInfo
    {
        DS_StationAddressInfo dsai = new DS_StationAddressInfo();
        /// <summary>
        /// 根据条形码获取对应的物料信息
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public DataSet QureyStationAddressInfo(string lineNo, string stationNo)
        {
            return this.dsai.QureyStationAddressInfo(lineNo, stationNo);
        }
        /// <summary>
        /// 查询所有StationAddressInfo信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllStationAddressInfo()
        {
            return this.dsai.QueryAllStationAddressInfo();
        }
        /// <summary>
        /// 删除重置所有的地址对应
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool RefStationAddressInfo(DataSet ds)
        {
            return this.dsai.RefStationAddressInfo(ds);
        }
    }
}
