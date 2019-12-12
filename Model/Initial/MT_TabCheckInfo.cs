using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MT_TabCheckInfo
    {
        /// <summary>
        /// 选卡id
        /// </summary>
        public int T_Id { get; set; }
        /// <summary>
        /// 选卡名称
        /// </summary>
        public string T_Name { get; set; }
        /// <summary>
        /// 选卡是否选中
        /// </summary>
        public int T_Checked { get; set; }

    }
}
