using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MaterialInfo
    {
        public MaterialInfo(string _order, string _name, int _lineNo, int _stationNo)
        {
            this.order = _order;
            this.name = _name;
            this.lineNo = _lineNo;
            this.stationNo = _stationNo;
        }
        public MaterialInfo()
        { }
        /// <summary>
        /// 物料编号
        /// </summary>
        public string order { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 线别
        /// </summary>
        public int lineNo { get; set; }
        /// <summary>
        /// 点位
        /// </summary>
        public int stationNo { get; set; }
    }
}
