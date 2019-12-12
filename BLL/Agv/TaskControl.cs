using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaskControl
    {
        #region Properties

        #endregion

        private static TaskControl taskControl = null;
        /// <summary>
        /// 当前需要分配的任务
        /// </summary>
        private string task = string.Empty;
        public static TaskControl Instance
        {
            get
            {
                if (taskControl == null)
                    taskControl = new TaskControl();
                return taskControl;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private TaskControl()
        {

        }
        /// <summary>
        /// 任务调度
        /// </summary>
        /// <returns></returns>
        public bool TaskControlFunction(string task)
        {
            try
            {
                this.task = task;
                if (Common.taskDt[(int)Enumerations.agvType.type_1].ContainsKey(task))
                {
                    bool isAllocationOk = false;
                    int agvNo = -1;
                    if (agvNo > 0)
                    {
                        lock (Common.taskDt[(int)Enumerations.agvType.type_1])
                        {
                            Common.taskDt[(int)Enumerations.agvType.type_1][task].T_AgvNo = agvNo;
                        }
                        lock (Common.maiDict[agvNo])
                        {
                            Common.maiDict[agvNo].Task2 = task;
                        }
                        isAllocationOk = true;
                    }
                    return isAllocationOk;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断在某范围内是否有AGV
        /// </summary>
        /// <param name="type"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int QueryAgv(Enumerations.agvType type, int begin, int end)
        {
            int agvNo = -1;
            try
            {
                agvNo = Common.maiDict.FirstOrDefault(o => o.Value.Type == type && o.Value.Task1 == string.Empty && o.Value.Task2 == string.Empty && (o.Value.Rfid >= begin && o.Value.Rfid <= end) && o.Value.Default6 == 1 && o.Value.Default1 == 0 && o.Value.Default2 == 0 && o.Value.VoltageStatus == Enumerations.voltageStatus.normal && (o.Value.State == (int)Enumerations.AgvStatus.fixPosition || o.Value.State == (int)Enumerations.AgvStatus.stop)).Key;
            }
            catch { }
            return agvNo;
        }
    }
}
