using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RfidInfo
    {
        /// <summary>
        /// 初始RFID类型
        /// </summary>
        public static RfidType pRfidType = RfidType.type1;
        public RfidInfo()
        { }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="_edgeNum">编号</param>
        /// <param name="_edgeRfidNum">RFID</param>
        public RfidInfo(int _edgeNum, int _edgeRfidNum)
        {
            this.EdgeNum = _edgeNum;
            this.EdgeRfidNum = _edgeRfidNum;
            this.EdgeLength = 1;
            this.LineStopType = 2;
            this.rfidType = RfidType.type1;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="_edgeNum">编号</param>
        /// <param name="_edgeRfidNum">RFID</param>
        /// <param name="_edgeLength">距离</param>
        /// <param name="_edgeCrossroad">岔道指令</param>
        /// <param name="_direction">方向</param>
        /// <param name="_obstacleType">障碍</param>
        /// <param name="_speed">速度</param>
        /// <param name="_operate">动作</param>
        /// <param name="_stopType">停车类型</param>
        /// <param name="_stopNumber">停车时长</param>
        /// <param name="_default1">预留1 重启时长</param>
        /// <param name="_default2">预留2 启动方向</param>
        /// <param name="_nextLineStop">掉线停车类型</param>
        /// <param name="_rfidType">类型</param>
        public RfidInfo(int _edgeNum, int _edgeRfidNum, int _edgeLength, int _edgeCrossroad, int _direction, int _obstacleType, int _speed, int _operate, int _stopType, int _stopNumber, int _default1, int _default2, int _nextLineStop, RfidType _rfidType)
        {
            this.EdgeNum = _edgeNum;
            this.EdgeRfidNum = _edgeRfidNum;
            this.EdgeLength = _edgeLength;
            this.EdgeCrossroad = _edgeCrossroad;
            this.Direction = _direction;
            this.ObstacleType = _obstacleType;
            this.Speed = _speed;
            this.Operate = _operate;
            this.StopType = _stopType;
            this.StopTime = _stopNumber;
            this.Default1 = _default1;
            this.Default2 = _default2;
            this.LineStopType = _nextLineStop;
            this.rfidType = _rfidType;
        }
        /// <summary>
        /// 路段编号
        /// </summary>
        public int EdgeNum { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int EdgeRfidNum { get; set; }
        /// <summary>
        /// 边线长度/路段长度/
        /// </summary>
        public int EdgeLength { get; set; }
        /// <summary>
        /// 岔道指令/行驶角度
        /// </summary>
        public int EdgeCrossroad { get; set; }
        /// <summary>
        /// 下一站点自启方向/航向
        /// </summary>
        public int Direction { get; set; }
        /// <summary>
        /// 障碍指令/磁点间距
        /// </summary>
        public int ObstacleType { get; set; }
        /// <summary>
        /// 速度指令/行驶速度
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// 动作指令/动作指令
        /// </summary>
        public int Operate { get; set; }
        /// <summary>
        /// 停车类型/默认
        /// </summary>
        public int StopType { get; set; }
        /// <summary>
        /// 停车时长/默认
        /// </summary>
        public int StopTime { get; set; }
        /// <summary>
        /// 预留1 重启时长/默认
        /// </summary>
        public int Default1 { get; set; }
        /// <summary>
        /// 预留2 启动方向/定点距离
        /// </summary>
        public int Default2 { get; set; }
        /// <summary>
        /// 掉线停车方式，1：按时间停车，2：按地标停车/默认
        /// </summary>
        public int LineStopType { get; set; }
        /// <summary>
        /// 路段类型
        /// </summary>
        public RfidType rfidType { get; set; }
    }
    /// <summary>
    /// 路段类型
    /// </summary>
    public enum RfidType
    {
        /// <summary>
        /// 磁导航
        /// </summary>
        type1,
        /// <summary>
        /// 惯性导航
        /// </summary>
        type2,
        /// <summary>
        /// 二维码
        /// </summary>
        type3,
    };
}
