using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BM_MapImageInfo
    {
        DM_MapImageInfo dmii = new DM_MapImageInfo();
        /// <summary>
        /// 查询该电子地图信息是否存在
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public int ExistsId(int M_Id)
        {
            return dmii.ExistsId(M_Id);
        }
        /// <summary>
        /// 添加一个新的电子地图信息
        /// </summary>
        /// <param name="mmii"></param>
        /// <returns></returns>
        public int AddMapImageInfo(MM_MapImageInfo mmii)
        {
            return dmii.AddMapImageInfo(mmii);
        }
        /// <summary>
        /// 更新一个电子地图对象
        /// </summary>
        /// <param name="mmii"></param>
        /// <returns></returns>
        public bool UpdateMapImageInfo(MM_MapImageInfo mmii)
        {
            return dmii.UpdateMapImageInfo(mmii);
        }
        /// <summary>
        /// 查询一个电子地图对象
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAllMapImageInfo(int M_Id)
        {
            return dmii.QueryAllMapImageInfo(M_Id);
        }
    }
}
