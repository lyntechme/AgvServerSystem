using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 尺寸类
    /// </summary>
    public class SizeScale
    {
        /// <summary>
        /// 宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 宽比例
        /// </summary>
        public float widthScale { get; set; }
        /// <summary>
        /// 高比例
        /// </summary>
        public float heightScale { get; set; }
    }
}
