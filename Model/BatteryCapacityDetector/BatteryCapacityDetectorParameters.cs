using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 分容柜参数
    /// </summary>
    public class BatteryCapacityDetectorParameters
    {
        public BatteryCapacityDetectorParameters()
        { }
        /// <summary>
        /// 分容柜参数
        /// </summary>
        /// <param name="_no">编号</param>
        /// <param name="_c1">隔板1 x:左，y:右</param>
        /// <param name="_c2">隔板2 x:左，y:右</param>
        /// <param name="_c3">隔板3 x:左，y:右</param>
        /// <param name="_c4">隔板4 x:左，y:右</param>
        /// <param name="_h">整体高度</param>
        public BatteryCapacityDetectorParameters(string _no, point _c1, point _c2, point _c3, point _c4, int _h)
        {
            this.DetectorNo = _no;
            this.Clapboard1 = _c1;
            this.Clapboard2 = _c2;
            this.Clapboard3 = _c3;
            this.Clapboard4 = _c4;
            this.High = _h;
        }
        /// <summary>
        /// 分容柜编号
        /// </summary>
        public string DetectorNo { get; set; }
        /// <summary>
        /// 隔板1高度
        /// </summary>
        public point Clapboard1 { get; set; }
        /// <summary>
        /// 隔板2高度
        /// </summary>
        public point Clapboard2 { get; set; }
        /// <summary>
        /// 隔板3高度
        /// </summary>
        public point Clapboard3 { get; set; }
        /// <summary>
        /// 隔板4高度
        /// </summary>
        public point Clapboard4 { get; set; }
        /// <summary>
        /// 整体高度
        /// </summary>
        public int High { get; set; }
    }
}
