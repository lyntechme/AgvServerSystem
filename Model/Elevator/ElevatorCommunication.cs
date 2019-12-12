using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model
{
    public class ElevatorCommunication
    {
        public ElevatorCommunication()
        { }
        /// <summary>
        /// 电梯通讯编号
        /// </summary>
        public int ElevatorNo { get; set; }
        /// <summary>
        /// 通讯ip地址
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 通讯使能
        /// </summary>
        public bool Enable { get; set; }

    }
}