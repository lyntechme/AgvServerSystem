using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class BS_MaterialInfo
    {
        DS_MaterialInfo dmi = new DS_MaterialInfo();

        /// <summary>
        /// 根据条形码获取对应的物料信息
        /// </summary>
        /// <param name="BarCode"></param>
        /// <returns></returns>
        public DataSet QureyMaterialInfo(string BarCode)
        {
            return dmi.QureyMaterialInfo(BarCode);
        }
        /// <summary>
        /// 查询所有MaterialInfo信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllMaterialInfo()
        {
            return dmi.QueryAllMaterialInfo();
        }
        /// <summary>
        /// 删除物料表数据，并重新全部写入
        /// </summary>
        /// <returns></returns>
        public bool RefMaterialInfo(DataSet ds)
        {
            return dmi.RefMaterialInfo(ds);
        }
    }
}
