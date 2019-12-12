using System;
using System.Collections.Generic;
using System.Text;

namespace AgvPLCUtils
{
    /// <summary>
    /// omronPLC Fins通讯接口，实现字、位读写方法
    /// </summary>
    public interface PlcConnect
    {
        /// <summary>
        /// 读取Agv数据(Word)
        /// </summary>
        /// <param name="plcUnitNum">Plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据起始地址</param>
        /// <param name="length">数据长度</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>所读取数据，第一位数据为:1则读取成功</returns>
        Byte[] WReadAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, int length, string strIP, int port);
        /// <summary>
        /// 向Agv写入数据(Word)
        /// </summary>
        /// <param name="plcUnitNum">plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据起始地址</param>
        /// <param name="data">需要写入数组</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>true:写入成功
        ///          false:写入失败</returns>
        bool WWriteAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, int[] data, string strIP, int port);
        /// <summary>
        /// 读取Agv数据(Bit)
        /// </summary>
        /// <param name="plcUnitNum">plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据区地址</param>
        /// <param name="bit">数据位地址</param>
        /// <param name="length">数据长度</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>所读取数据，第一位数据为:1则读取成功</returns>
        Byte[] BReadAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, byte bit, int length, string strIP, int port);
        /// <summary>
        /// 向Agv写入数据(Bit)
        /// </summary>
        /// <param name="plcUnitNum">plc单元编号</param>
        /// <param name="strAgvControlCmd">Agv控制命令</param>
        /// <param name="strAgvRamCmd">Agv内存操作命令</param>
        /// <param name="origin">数据区地址</param>
        /// <param name="bit">数据位地址</param>
        /// <param name="data">需要写入数组</param>
        /// <param name="strIP">AgvIP地址</param>
        /// <param name="port">Agv端口号</param>
        /// <returns>true:写入成功
        ///          false:写入失败</returns>
        bool BWriteAgv(int plcUnitNum, string strAgvControlCmd, string strAgvRamCmd, int origin, byte bit, byte[] data, string strIP, int port);

    }
}
