using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AgvServerSystem
{
    static class WinSleepCtr
    {
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        const uint ES_DISPLAY_QERUIRED = 0x00000002;
        const uint ES_CONTINUOUS = 0x80000000;

        /// <summary>
        /// sleep control 
        /// </summary>
        /// <param name="sleepOrNot">true:control false:Rest</param>
        public static void SleepCtr(bool sleepOrNot)
        {
            if (sleepOrNot)
            {
                SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_QERUIRED | ES_SYSTEM_REQUIRED);
            }
            else
            {
                SetThreadExecutionState(ES_CONTINUOUS);
            }
        }
    }
}
