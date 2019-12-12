using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Enumerations
    {
        /// <summary>
        /// agv通讯类型
        /// </summary>
        public enum AgvConnectType
        {
            /// <summary>
            /// PLC Fins 以太网 UDP
            /// </summary>
            OmronFins,
            /// <summary>
            /// PLC HostLink 232串口
            /// </summary>
            OmronHostLinkRs232,
            /// <summary>
            /// PLC HostLint 485串口
            /// </summary>
            OmronHostLinkRs485,
            /// <summary>
            /// 单片机 Stm32
            /// </summary>
            Stm32,
            /// <summary>
            /// 单片机 Stm32 惯性导航
            /// </summary>
            Stm32Ins,
        }
        /// <summary>
        /// 数据存储类型、本地SqlLite或MsSql
        /// </summary>
        public enum DataType
        {
            /// <summary>
            /// sqlLite本地数据库类型
            /// </summary>
            SqlLite = 1,
            /// <summary>
            /// MsSql数据库类型
            /// </summary>
            MsSql = 2,
        };
        /// <summary>
        /// Agv运行状态
        /// </summary>
        public enum AgvStatus
        {
            /// <summary>
            /// 初始化
            /// </summary>
            init = -1,
            /// <summary>
            /// 断线
            /// </summary>
            disConnection = 0,
            /// <summary>
            /// 停止
            /// </summary>
            stop = 1,
            /// <summary>
            /// 正在运行
            /// </summary>
            running = 2,
            /// <summary>
            /// 正在定位
            /// </summary>
            fixPosition = 4,
            /// <summary>
            /// 异常
            /// </summary>
            abnormal = 3,
            /// <summary>
            /// 障碍物异常
            /// </summary>
            obstacle = 5,
        };
        /// <summary>
        /// 任务类型
        /// </summary>
        public enum TaskType
        {
            /// <summary>
            /// Init
            /// </summary>
            Init = 0,
            /// <summary>
            /// 前往充电桩
            /// </summary>
            Charge_Go = 1,
            /// <summary>
            /// 离开充电桩
            /// </summary>
            Chareg_Leave = 2,
            /// <summary>
            /// 运输类型 A-F
            /// </summary>
            Transport_A_F = 5,
            /// <summary>
            /// 运输类型 A-C
            /// </summary>
            Transport_A_C = 6,
            /// <summary>
            /// 运输类型 E-A
            /// </summary>
            Transport_E_A = 7,
            /// <summary>
            /// 运输类型 C-F
            /// </summary>
            Transport_C_F = 8,
            /// <summary>
            /// 运输类型 B-E
            /// </summary>
            Transport_B_E = 9,
            /// <summary>
            /// 运输类型 B-D
            /// </summary>
            Transport_B_D = 10,
            /// <summary>
            /// 运输类型 F-B
            /// </summary>
            Transport_F_B = 12,
            /// <summary>
            /// 运输类型 D-E
            /// </summary>
            Transport_D_E = 13,
        };
        /// <summary>
        /// 任务状态
        /// </summary>
        public enum TaskStatus
        {
            /// <summary>
            /// 接受任务，尚未开始
            /// </summary>
            Accept = 1,
            /// <summary>
            /// 预定AGV
            /// </summary>
            Book = 2,
            /// <summary>
            /// 任务开始
            /// </summary>
            Start = 3,
            /// <summary>
            /// 前往上料点
            /// </summary>
            LoadMaterial = 4,
            /// <summary>
            /// 前往卸料点
            /// </summary>
            UnloadMaterial = 5,
            /// <summary>
            /// 任务结束
            /// </summary>
            End = 6,
            /// <summary>
            /// 取消任务
            /// </summary>
            Cancel = 7,
            /// <summary>
            /// 任务异常结束
            /// </summary>
            Error = 8,
        };
        /// <summary>
        /// 停靠方位
        /// </summary>
        public enum Berth
        {
            /// <summary>
            /// 上
            /// </summary>
            Top,
            /// <summary>
            /// 下
            /// </summary>
            Bottom,
            /// <summary>
            /// 左
            /// </summary>
            Left,
            /// <summary>
            /// 右
            /// </summary>
            Right,
        };
        /// <summary>
        /// 电压状态
        /// </summary>
        public enum voltageStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            normal,
            /// <summary>
            /// 低电压
            /// </summary>
            lowVoltage,
            /// <summary>
            /// 充电电压 
            /// </summary>
            chargVoltage,
        };
        /// <summary>
        /// AGV手动操作
        /// </summary>
        public enum AgvOperate
        {
            /// <summary>
            /// 前进
            /// </summary>
            Forward = 1,
            /// <summary>
            /// 后退
            /// </summary>
            Back = 2,
            /// <summary>
            /// 复位
            /// </summary>
            Rest = 3,
            /// <summary>
            /// 停止
            /// </summary>
            Stop = 4,
            /// <summary>
            /// 举升
            /// </summary>
            PullUp = 5,
            /// <summary>
            /// 下降
            /// </summary>
            PullDown = 6,
            /// <summary>
            /// 回待机点
            /// </summary>
            GoWait = 7,
            /// <summary>
            /// 清除当前路段编号
            /// </summary>
            StationClear = 8,
            /// <summary>
            /// 清除二维码
            /// </summary>
            QRCodeClear = 9,
            /// <summary>
            /// 左转
            /// </summary>
            LeftRotate = 0x31,
            /// <summary>
            /// 右转
            /// </summary>
            RightRotate = 0x32,
            /// <summary>
            /// 左平移
            /// </summary>
            LeftTranslate = 0x33,
            /// <summary>
            /// 右平移
            /// </summary>
            RightTranslate = 0x34,
            /// <summary>
            /// 充电接触器开
            /// </summary>
            ChargeOpen = 0x35,
            /// <summary>
            /// 充电接触器关
            /// </summary>
            ChargeClose = 0x36,
            /// <summary>
            /// 支撑顶起
            /// </summary>
            SupportUp = 0x37,
            /// <summary>
            /// 支撑收回
            /// </summary>
            SupportBack = 0x38,
            /// <summary>
            /// 障碍关闭
            /// </summary>
            ObstacleClose = 0x39,
            /// <summary>
            /// 动作完成
            /// </summary>
            OperateComplete,
            /// <summary>
            /// 自动 模式
            /// </summary>
            AutoMode,
            /// <summary>
            /// 手动模式
            /// </summary>
            ManualMode,
            /// <summary>
            /// 启动
            /// </summary>
            Start,
            /// <summary>
            /// 允许进入升降台
            /// </summary>
            Pass,
            /// <summary>
            /// 活动的，心跳包
            /// </summary>
            Activity,
            /// <summary>
            /// 站点升降平台状态
            /// </summary>
            StationState,
            /// <summary>
            /// 升降平台允许离开
            /// </summary>
            PlatformPass,
            /// <summary>
            /// 写入上料点和下料点
            /// </summary>
            LoadAndUnload,
            /// <summary>
            /// 上下料完成清除
            /// </summary>
            OperationCompleteClear,
            /// <summary>
            /// 初始化
            /// </summary>
            Init,
        };
        /// <summary>
        /// AGV类型
        /// </summary>
        public enum agvType
        {
            /// <summary>
            /// 类型1 Front侧
            /// </summary>
            type_1 = 0,
            /// <summary>
            /// 类型2 Back侧
            /// </summary>
            type_2 = 1,
            /// <summary>
            /// 类型3
            /// </summary>
            type_3 = 2,
        };
        /// <summary>
        /// Agv信息显示Label类型
        /// </summary>
        public enum LabelType
        {
            /// <summary>
            /// Agv状态显示灯
            /// </summary>
            AgvStatusLight,
            /// <summary>
            /// agv类型
            /// </summary>
            AgvType,
            /// <summary>
            /// RFID
            /// </summary>
            AgvRfid,
            /// <summary>
            /// Agv异常状态
            /// </summary>
            AgvStatus,
            /// <summary>
            /// 当前任务
            /// </summary>
            CurrentTask,
            /// <summary>
            /// 预定任务
            /// </summary>
            BookTask,
            /// <summary>
            /// 电量及牵引棒状态
            /// </summary>
            VolAndPull,
            /// <summary>
            /// 上下料点号
            /// </summary>
            Station,
            /// <summary>
            /// 方向及闲忙状态
            /// </summary>
            DirAndBusy,
        };
        /// <summary>
        /// Agv通过管制范围的方式
        /// </summary>
        public enum ControlType
        {
            /// <summary>
            /// 进入该管制范围的点
            /// </summary>
            InStation,
            /// <summary>
            /// 左边路过该管制范围
            /// </summary>
            PassStationLeft,
            /// <summary>
            /// 右边路过该管制范围
            /// </summary>
            PassStationRight,
        };
        /// <summary>
        /// 充电待机站点
        /// </summary>
        public enum OtherStation
        {
            /// <summary>
            /// 应急充电位
            /// </summary>
            charge,
            ///// <summary>
            ///// 1楼充电位
            ///// </summary>
            //ChargeFloor1,
            ///// <summary>
            ///// 2楼待机位
            ///// </summary>
            //WaitFloor2,
            ///// <summary>
            ///// 2楼充电位
            ///// </summary>
            //ChargeFloor2,
        };
        /// <summary>
        /// AGV操作模式
        /// </summary>
        public enum AgvMode
        {
            /// <summary>
            /// 手动模式
            /// </summary>
            ManualOperation = 0,
            /// <summary>
            /// 自动模式
            /// </summary>
            AutoOperation = 1,
        }
        public enum EOperate
        {
            /// <summary>
            /// 举升
            /// </summary>
            LiftUp = 12,
            /// <summary>
            /// 下降
            /// </summary>
            Decline = 13,
        }
        /// <summary>
        /// 分容测试等待位
        /// </summary>
        public enum ECapWait
        {
            /// <summary>
            /// 分容测试上侧等待位
            /// </summary>
            Top = 1,
            /// <summary>
            /// 分容测试下侧等待位
            /// </summary>
            Bottom = 2,
        }
        public enum EDragState
        {
            /// <summary>
            /// 下降
            /// </summary>
            Decline = 0,
            /// <summary>
            /// 举升
            /// </summary>
            LiftUp = 1,
        }
        public enum EAgvStateToPlc
        {
            /// <summary>
            /// agv处于空闲状态
            /// </summary>
            Idle = 0,
            /// <summary>
            /// agv正在前往站点
            /// </summary>
            Arriving = 1,
            /// <summary>
            /// Agv到达升降平台
            /// </summary>
            Present = 2,
            /// <summary>
            /// AGV正在离开升降平台
            /// </summary>
            Departing = 3,
            /// <summary>
            /// AGV已经离开升降平台
            /// </summary>
            Departed = 4,
            /// <summary>
            /// AGV正在转移
            /// </summary>
            Transferring = 5,
            /// <summary>
            /// AGV转移完成
            /// </summary>
            TransferComplete = 6,
            /// <summary>
            /// 没有空闲位置放置料车
            /// </summary>
            StationFull = 7,
            /// <summary>
            /// Agv异常
            /// </summary>
            Error = 99,
        }
    }
}
