using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MS_BufferStorage
    {
        public MS_BufferStorage()
        { }
        public MS_BufferStorage(int _id,string _info,string _order,int _number,int _flag,DateTime _time)
        {
            this.S_Id = _id;
            this.S_Info = _info;
            this.S_Order = _order;
            this.S_Number = _number;
            this.S_Flag = _flag;
            this.S_UpdateTime = _time;
        }
        /// <summary>
        /// 暂存点编号
        /// </summary>
        public int S_Id { get; set; }
        /// <summary>
        /// 暂存点当前物料信息
        /// </summary>
        public string S_Info { get; set; }
        /// <summary>
        /// 暂存点当前订单号
        /// </summary>
        public string S_Order { get; set; }
        /// <summary>
        /// 暂存点物料数量
        /// </summary>
        public int S_Number { get; set; }
        /// <summary>
        /// 暂存点标志位 0:无小车绑定该点；1:有小车已绑定该点
        /// </summary>
        public int S_Flag { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime S_UpdateTime { get; set; }
    }
}
