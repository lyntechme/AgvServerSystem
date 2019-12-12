using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BA_AgvControl
    {
        public static object objControl = new object();


        /// <summary>
        /// 管制判断反馈 返回true则表示放行
        /// </summary>
        /// <param name="AgvNo">Agv编号</param>
        /// <returns>true:表示不放行        false:放行</returns>
        public static bool IsControl(int AgvNo)
        {
            bool isControl = false;
            try
            {
                //lock (objControl)
                //{
                //bool isInControl = false;
                int pointNo = -1;
                foreach (int item in Common.controlPointsDict.Keys)  //循环判断该Agv的Rfid是否进入管制范围
                {
                    #region 弃用
                    //if (Common.controlPointsStatus[item] == AgvNo)  //如果当前管制点的Agv为AgvNo，将其清除
                    //{
                    //    if (Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].Rfid) == false)
                    //        Common.controlPointsStatus[item] = -1;
                    //}
                    //if (Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid))  //当前管制点包含Agv所在的Rfid
                    //{
                    //    if (Common.controlPointsStatus[item] == -1 || Common.controlPointsStatus[item] == AgvNo)  //若当前管制点没有Agv，则将其分配给Agv
                    //    {
                    //        Common.controlPointsStatus[item] = AgvNo;
                    //    }
                    //    else                                      //若当前管制点有Agv，则对Agv进行管制
                    //    {
                    //        isControl = true;
                    //    }
                    //} 
                    #endregion
                    //if (Common.controlPointAgvList[item].Count > 0)
                    //{
                    //    if (Common.controlPointAgvList[item][0] == AgvNo)
                    //    {
                    //        if (Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid2) == false && Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid) == false)
                    //        {
                    //            while (Common.controlPointAgvList[item].Contains(AgvNo))
                    //                Common.controlPointAgvList[item].Remove(AgvNo);
                    //        }
                    //    }
                    //}
                    if (Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid) || Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid2))
                    {
                        if (Common.controlPointAgvList[item].Contains(AgvNo) == false)
                        {
                            Common.controlPointAgvList[item].Add(AgvNo);
                        }
                        if (Common.controlPointAgvList[item][0] != AgvNo)
                        {
                            isControl = true;
                        }
                    }
                }
                //}
            }
            catch { }
            return isControl;
        }
        /// <summary>
        /// 解除绑定
        /// </summary>
        /// <param name="AgvNo"></param>
        /// <returns></returns>
        public static void UnlockControl(int AgvNo)
        {
            try
            {
                //lock (objControl)
                //{
                //bool isInControl = false;
                int pointNo = -1;
                foreach (int item in Common.controlPointsDict.Keys)  //循环判断该Agv的Rfid是否进入管制范围
                {
                    if (Common.controlPointAgvList[item].Count > 0)
                    {
                        if (Common.controlPointAgvList[item][0] == AgvNo)
                        {
                            if (Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid2) == false && Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid) == false)
                            {
                                while (Common.controlPointAgvList[item].Contains(AgvNo))
                                    Common.controlPointAgvList[item].Remove(AgvNo);
                            }
                        }
                    }
                    //if (Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid) || Common.controlPointsDict[item].Contains(Common.maiDict[AgvNo].ControlRfid2))
                    //{
                    //    if (Common.controlPointAgvList[item].Contains(AgvNo) == false)
                    //    {
                    //        Common.controlPointAgvList[item].Add(AgvNo);
                    //    }
                    //    if (Common.controlPointAgvList[item][0] != AgvNo)
                    //    {
                    //        isControl = true;
                    //    }
                    //}
                }
                //}
            }
            catch { }
        }
    }
}
