using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MA_AgvComInfo
    {
        public MA_AgvComInfo()
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_id">小车编号</param>
        /// <param name="_des">描述</param>
        /// <param name="_ip">IP地址</param>
        /// <param name="_netNo">网络编号</param>
        /// <param name="_localPort">源端口号</param>
        /// <param name="_desPort">目标端口号</param>
        /// <param name="_type">小车类型</param>
        /// <param name="_isUsing">是滞启用</param>
        public MA_AgvComInfo(int _id,string _des,string _ip,int _netNo,int _localPort,int _desPort,string _type,bool _isUsing)
        {
            this.A_Id = _id;
            this.A_Description = _des;
            this.A_IpAddress = _ip;
            this.A_NetNo = _netNo;
            this.A_LocalPort = _localPort;
            this.A_DesPort = _desPort;
            this.A_AgvConnectType = _type;
            this.A_IsUsing = _isUsing;
        }

        /// <summary>
        /// agv编号
        /// </summary>
        public int A_Id { get; set; }
        /// <summary>
        /// Agv描述
        /// </summary>
        public string A_Description { get; set; }
        /// <summary>
        /// agvip地址
        /// </summary>
        public string A_IpAddress { get; set; }
        /// <summary>
        /// agv网络节点号
        /// </summary>
        public int A_NetNo { get; set; }
        /// <summary>
        /// 本地端口号
        /// </summary>
        public int A_LocalPort { get; set; }
        /// <summary>
        /// 目的端口号
        /// </summary>
        public int A_DesPort { get; set; }
        /// <summary>
        /// agv通讯类型
        /// </summary>
        public string A_AgvConnectType { get; set; }
        /// <summary>
        /// agv类型
        /// </summary>
        public int A_AgvCommonType { get; set; }
        /// <summary>
        /// 是否启用该Agv
        /// </summary>
        public bool A_IsUsing { get; set; }
    }
}
