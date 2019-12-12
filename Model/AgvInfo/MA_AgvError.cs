using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MA_AgvError
    {
        public MA_AgvError()
        { }
        public MA_AgvError(int _id,int _agvNo,string _info,int _infoNo,string _lineNo,int _rfid,string _task,DateTime _time)
        {
            this.E_Id = _id;
            this.E_AgvNo = _agvNo;
            this.E_Info = _info;
            this.E_InfoNo = _infoNo;
            this.E_LineNo = _lineNo;
            this.E_AgvRfid = _rfid;
            this.E_Task = _task;
            this.E_UpdateTime = _time;
        }
        /// <summary>
        /// 错误信息存储Id
        /// </summary>
        public int E_Id { get; set; }
        /// <summary>
        /// 小车编号
        /// </summary>
        public int E_AgvNo { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string E_Info { get; set; }
        /// <summary>
        /// 错误信息编号
        /// </summary>
        public int E_InfoNo { get; set; }
        /// <summary>
        /// 线路号
        /// </summary>
        public string E_LineNo { get; set; }
        /// <summary>
        /// 地标卡号
        /// </summary>
        public int E_AgvRfid { get; set; }
        /// <summary>
        /// 当前执行任务信息
        /// </summary>
        public string E_Task { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime E_UpdateTime { get; set; }
    }
}
