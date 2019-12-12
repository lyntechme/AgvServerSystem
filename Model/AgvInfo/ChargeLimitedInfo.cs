using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChargeLimitedInfo
    {
        /// <summary>
        /// 充电桩充电电压
        /// </summary>
        public static Dictionary<int, double> dtAgvChargeVoltage = new Dictionary<int, double>();
        /// <summary>
        /// 充电阀值
        /// </summary>
        /// <param name="low">低电压阀值</param>
        /// <param name="charge">充电阀值</param>
        /// <param name="time">充电时间阀值</param>
        /// <param name="enable">可使用阀值</param>
        /// <param name="fullTime">满电时长</param>
        public ChargeLimitedInfo(int low,int lowTime, int charge, int time, int enable,int fullTime)
        {
            this.LimitedLow = low;
            this.LimiteLowTime = lowTime;
            this.LimitedCharge = charge;
            this.LimitedTime = time;
            this.LimitedEnable = enable;
            this.FullTime = fullTime;
            this.ChargeVoltage = 515;
        }
        /// <summary>
        /// 低电压阀值
        /// </summary>
        public int LimitedLow { get; set; }
        /// <summary>
        /// 低电压充电时间
        /// </summary>
        public int LimiteLowTime { get; set; }
        /// <summary>
        /// 充电电压阀值
        /// </summary>
        public int LimitedCharge { get; set; }
        /// <summary>
        /// 充电时间阀值
        /// </summary>
        public int LimitedTime { get; set; }
        /// <summary>
        /// 可使用阀值
        /// </summary>
        public int LimitedEnable { get; set; }
        /// <summary>
        /// 满电时长  分钟
        /// </summary>
        public int FullTime { get; set; }
        /// <summary>
        /// agv位于充电桩时充电电压判断
        /// </summary>
        public int ChargeVoltage { get; set; }
    }
}
