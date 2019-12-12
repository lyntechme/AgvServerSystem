using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OPCAutomation;

namespace BLL
{
    /// <summary>
    /// OPC客户端通讯(AbPlc数据查询及操作)
    /// </summary>
    public class OpcＣlient
    {
        #region 私有变量
        /// <summary>
        /// OPCServer Object OPC服务器对象
        /// </summary>
        OPCServer KepServer;
        /// <summary>
        /// OPCGroups Object opc Groups组别对象
        /// </summary>
        OPCGroups KepGroups;
        /// <summary>
        /// OPCGroup Object opc Group对象
        /// </summary>
        OPCGroup KepGroup;
        /// <summary>
        /// OPCItems Object OPC项组对象
        /// </summary>
        OPCItems KepItems;
        /// <summary>
        /// OPCItem Object OPC项对象
        /// </summary>
        OPCItem KepItem;
        /// <summary>
        /// 主机IP
        /// </summary>
        string strHostIP = "";
        /// <summary>
        /// 主机名称
        /// </summary>
        string strHostName = "";
        /// <summary>
        /// 连接状态
        /// </summary>
        bool opc_connected = false;
        /// <summary>
        /// 客户端句柄
        /// </summary>
        int itmHandleClient = 0;
        /// <summary>
        /// 服务端句柄
        /// </summary>
        int itmHandleServer = 0;
        #endregion
    }
}