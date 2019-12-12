using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OPCAutomation;
using Model;
using System.Threading;

namespace BLL
{
    public class OPCClient
    {
        #region 全局变量
        /// <summary>
        /// OPC对应PLC的位置
        /// </summary>
        public static Dictionary<string, OPCItemParameter> dtOpcToPlc = new Dictionary<string, OPCItemParameter>();
        /// <summary>
        /// opc服务器信息
        /// </summary>
        public static OPCInformation opcInformation = new OPCInformation();
        #endregion
        /// <summary>
        /// 初始化
        /// </summary>
        public OPCClient()
        { }
        public static bool WriteOpc(object value, string stationKey)
        {
            try
            {
                int handle = Common.Instance.dtStationInformation[stationKey].Handle;
                if (handle > 0)
                {
                    OPCItemParameter opcItem = OPCClient.dtOpcToPlc.First(o => o.Value.ItemHandle == handle).Value;
                    LogFile.SaveLog(string.Format("向OPC 名称为{0} Handle {1},写入值为 {2}", opcItem.ParameterName, opcItem.ItemHandle, opcItem.Value));
                    return WriteOpc(value, opcItem);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 写OPC
        /// </summary>
        /// <param name="value">写入值</param>
        /// <param name="handle">句柄编号</param>
        /// <returns></returns>
        public static bool WriteOpc(object value, int handle)
        {
            OPCItemParameter opcItem = OPCClient.dtOpcToPlc.First(o => o.Value.ItemHandle == handle).Value;
            //LogFile.SaveLog(string.Format("向OPC 名称为{0} Handle {1},写入值为 {2}", opcItem.ParameterName, opcItem.ItemHandle, value));
            return WriteOpc(value, opcItem);
        }
        /// <summary>
        /// 向OPC对应项写入值
        /// </summary>
        /// <param name="value">需要写入的值</param>
        /// <param name="OPCItemParameter">item地址</param>
        /// <returns></returns>
        public static bool WriteOpc(object value, OPCItemParameter opcItem)
        {
            try
            {
                string key = dtOpcToPlc.First(o => o.Value.ItemHandle == opcItem.ItemHandle).Key;
                dtOpcToPlc[key].IsWriteOk = false;
                OPCItem bItem = opcInformation.KepItems.Item(opcItem.ParameterName);
                opcInformation.itmHandleServer = bItem.ServerHandle;
                int[] temp = new int[2] { 0, bItem.ServerHandle };
                Array serverHandles = (Array)temp;
                object[] valueTemp = new object[2] { "", value.ToString() };
                Array values = (Array)valueTemp;
                Array Errors;
                int cancelID;
                opcInformation.KepGroup.AsyncWrite(1, ref serverHandles, ref values, out Errors, 2009, out cancelID);
                //KepItem.Write(txtWriteTagValue.Text);//这句也可以写入，但并不触发写入事件
                GC.Collect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 对opc获取的数据进行业务处理
        /// </summary>
        public void OPCClientOperate()
        {
            int lineoffCount = 0;//掉线判断计数
            while (true)
            {
                try
                {
                    if (!opcInformation.ConnectState)
                    {//连接不成功，尝试重新连接
                        if (GetLocalServer())
                        {//获取OPC服务器信息成功
                            if (ConnectRemoteServer())
                            {//连接OPC成功 
                                opcInformation.ConnectState = true;
                                RecurBrowse(opcInformation.KepServer.CreateBrowser());
                            }
                        }
                        else
                        {
                            opcInformation.ConnectContents = "OPC disconnected";
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        if (!opcInformation.GroupsState)
                        {//创建组集合失败，尝试重新创建
                            opcInformation.GroupsState = CreateGroup();
                        }
                        else
                        {
                            if (opcInformation.KepItems.Count <= 0)
                            {//尚未添加通讯的参数
                                if (dtOpcToPlc.Count > 0)
                                {
                                    foreach (OPCItemParameter item in dtOpcToPlc.Values)
                                    {
                                        opcInformation.KepItems.AddItem(item.ParameterName, item.ItemHandle);
                                    }
                                }
                            }
                            else
                            {
                                int state = opcInformation.KepServer.ServerState;
                                switch (state)
                                {
                                    case (int)OPCServerState.OPCFailed:
                                        opcInformation.ConnectState = true;
                                        opcInformation.ConnectContents = "OPC failed";
                                        break;
                                    case (int)OPCServerState.OPCDisconnected:
                                        opcInformation.ConnectState = false;
                                        opcInformation.ConnectContents = "OPC disconnected";
                                        break;
                                    case (int)OPCServerState.OPCSuspended:
                                        opcInformation.ConnectState = true;
                                        opcInformation.ConnectContents = "OPC Suspended";
                                        break;
                                    case (int)OPCServerState.OPCNoconfig:
                                        opcInformation.ConnectState = true;
                                        opcInformation.ConnectContents = "OPC Noconfig";
                                        break;
                                    case (int)OPCServerState.OPCTest:
                                        opcInformation.ConnectState = true;
                                        opcInformation.ConnectContents = "OPC Test";
                                        break;
                                    case (int)OPCServerState.OPCRunning:
                                        opcInformation.ConnectState = true;
                                        opcInformation.ConnectContents = "OPC Running";
                                        break;
                                }
                                #region 通过品质判断和PLC通讯否正常
                                if (dtOpcToPlc.All(o => string.IsNullOrEmpty(o.Value.Qualities) == false && int.Parse(o.Value.Qualities) == 0))
                                {
                                    opcInformation.ConnectState = true;
                                    opcInformation.ConnectContents = "OPC bad";
                                    lineoffCount++;
                                    if (lineoffCount > 200)
                                    {
                                        opcInformation.ConnectState = false;
                                        opcInformation.ConnectContents = "OPC disconnected";
                                        opcInformation.GroupsState = false;
                                        try
                                        {
                                            opcInformation.KepServer.Disconnect();
                                        }
                                        catch { }
                                        lineoffCount = 0;
                                    }
                                }
                                else
                                {
                                    lineoffCount = 0;
                                }
                                #endregion

                                Thread.Sleep(10);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    opcInformation.ConnectState = false;
                    opcInformation.ConnectContents = "OPC disconnected";
                    opcInformation.GroupsState = false;
                    try
                    {
                        opcInformation.KepServer.Disconnect();
                    }
                    catch { }
                }
                //Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 创建组
        /// </summary>
        private bool CreateGroup()
        {
            try
            {
                opcInformation.KepGroups = opcInformation.KepServer.OPCGroups;
                opcInformation.KepGroup = opcInformation.KepGroups.Add("OPCDOTNETGROUP");
                SetGroupProperty();
                opcInformation.KepGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
                opcInformation.KepGroup.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(KepGroup_AsyncWriteComplete);
                opcInformation.KepItems = opcInformation.KepGroup.OPCItems;
            }
            catch (Exception err)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 设置组属性
        /// </summary>
        private void SetGroupProperty()
        {
            opcInformation.KepServer.OPCGroups.DefaultGroupIsActive = true;
            opcInformation.KepServer.OPCGroups.DefaultGroupDeadband = 0;
            opcInformation.KepGroup.UpdateRate = 100;
            opcInformation.KepGroup.IsActive = true;
            opcInformation.KepGroup.IsSubscribed = true;
        }

        private void KepGroup_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
            try
            {
                for (int i = 1; i <= NumItems; i++)
                {
                    int error = int.Parse(Errors.GetValue(i).ToString());
                    int handle = int.Parse(ClientHandles.GetValue(i).ToString());
                    string key = dtOpcToPlc.First(o => o.Value.ItemHandle == handle).Key;
                    if (error == 0)
                    {
                        dtOpcToPlc[key].IsWriteOk = true;
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 每当项数据有变化时执行的事件
        /// </summary>
        /// <param name="TransactionID">处理ID</param>
        /// <param name="NumItems">项个数</param>
        /// <param name="ClientHandles">项客户端句柄</param>
        /// <param name="ItemValues">TAG值</param>
        /// <param name="Qualities">品质</param>
        /// <param name="TimeStamps">时间戳</param>
        private void KepGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                try
                {
                    int index = int.Parse(ClientHandles.GetValue(i).ToString());
                    string key = dtOpcToPlc.FirstOrDefault(o => o.Value.ItemHandle == index).Key;
                    if (!string.IsNullOrEmpty(key))
                    {//需要判断类型，是int还是boolean
                        int value = -1;
                        try
                        {
                            value = int.Parse(ItemValues.GetValue(i).ToString());
                        }
                        catch { }
                        try
                        {
                            if (value == -1)
                            {
                                bool isTrue = bool.Parse(ItemValues.GetValue(i).ToString());
                                if (isTrue)
                                {
                                    value = 1;
                                }
                                else
                                {
                                    value = 0;
                                }
                            }
                        }
                        catch { }
                        if (value != dtOpcToPlc[key].Value)
                        {
                            dtOpcToPlc[key].Value = value;
                            dtOpcToPlc[key].ChangeTime = DateTime.Now;
                            //int handle = dtOpcToPlc[key].ItemHandle;
                            //int stationNo = handle / 9;
                            //int offset = handle % 9;
                            //if (handle < 80)
                            //{//站点信息
                            //    StationInformation s = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Handle > 0 && (o.Value.Handle / 9 == stationNo)).Value;
                            //    switch (offset)
                            //    {
                            //        case 1:
                            //            s.WriteValue = dtOpcToPlc[key].Value;
                            //            break;
                            //        case 2:
                            //            s.LoadReady = dtOpcToPlc[key].Value == 1 ? true : false;
                            //            break;
                            //        case 3:
                            //            s.UnloadReady = dtOpcToPlc[key].Value == 1 ? true : false;
                            //            break;
                            //        case 4:
                            //            s.Dock = dtOpcToPlc[key].Value == 1 ? true : false;
                            //            break;
                            //        case 5:
                            //            s.Undock = dtOpcToPlc[key].Value == 1 ? true : false;
                            //            break;
                            //    }
                            //    if (s.LoadReady == false && s.UnloadReady && s.Dock && s.Undock == false)
                            //    {
                            //        s.State = (int)EStationState.Busy;
                            //    }
                            //    else if (s.LoadReady && s.UnloadReady == false && s.Dock && s.Undock == false)
                            //    {
                            //        s.State = (int)EStationState.Busy;
                            //    }
                            //    else
                            //    {
                            //        s.State = (int)EStationState.Free;
                            //    }
                            //}
                            //else
                            //{//一键工作/收工信息
                            //    if (handle == 81)
                            //    {//Idle,请求收工
                            //        Common.Instance.opcIdleRequest = dtOpcToPlc[key].Value == 1 ? true : false;
                            //        if (Common.Instance.opcIdleRequest)
                            //        {//收工请求 
                            //            Common.Instance.isReceiveOpcTask = false;
                            //        }
                            //    }
                            //    else if (handle == 82)
                            //    {//
                            //        Common.Instance.opcStartRequest = dtOpcToPlc[key].Value == 1 ? true : false;
                            //        if (Common.Instance.opcStartRequest)
                            //        {//开始请求 
                            //            Common.Instance.isReceiveOpcTask = true;
                            //        }
                            //    }
                            //    else if (handle == 83)
                            //    {
                            //        Common.Instance.writeOpcReceiveState = dtOpcToPlc[key].Value == 1 ? true : false;
                            //    }
                            //}
                        }
                        dtOpcToPlc[key].Qualities = Qualities.GetValue(i).ToString();
                        dtOpcToPlc[key].TimeStamps = TimeStamps.GetValue(i).ToString();

                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 列出OPC服务器中所有节点
        /// </summary>
        /// <param name="oPCBrowser"></param>
        private void RecurBrowse(OPCBrowser oPCBrowser)
        {
            //展开分支
            oPCBrowser.ShowBranches();
            //展开叶子
            oPCBrowser.ShowLeafs(true);
            foreach (object turn in oPCBrowser)
            {
                //listBox1.Items.Add(turn.ToString());
            }
        }
        /// <summary>
        /// 获取opc服务器
        /// </summary>
        /// <returns></returns>
        private bool GetLocalServer()
        {
            try
            {
                opcInformation.KepServer = new OPCServer();
                object serverList = opcInformation.KepServer.GetOPCServers(opcInformation.HostName);
                foreach (string item in (Array)serverList)
                {
                    if (!string.IsNullOrEmpty(item.Trim()))
                    {
                        opcInformation.ServerName = item;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(opcInformation.ServerName))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 连接OPC服务器
        /// </summary>
        private bool ConnectRemoteServer()
        {
            try
            {
                opcInformation.KepServer.Connect(opcInformation.ServerName, opcInformation.Ip);

                if (opcInformation.KepServer.ServerState == (int)OPCServerState.OPCRunning)
                {
                    opcInformation.ConnectContents = "OPC Running";
                }
                else
                {
                    opcInformation.ConnectContents = opcInformation.KepServer.ServerState.ToString();
                }
            }
            catch (Exception err)
            {
                //MessageBox.Show("连接远程服务器出现错误：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                opcInformation.ConnectContents = "Opc Error";
                return false;
            }
            return true;
        }
    }
    #region OPC服务器类信息
    /// <summary>
    /// OPC服务器的参数信息
    /// </summary>
    public class OPCInformation
    {
        public OPCInformation()
        {
            this.Ip = string.Empty;
            this.HostName = string.Empty;
            this.ConnectState = false;
            this.GroupsState = false;
            this.ConnectContents = "Opc Failed";
        }
        /// <summary>
        /// ip地址
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// opc服务器名称
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 服务器句柄
        /// </summary>
        public int itmHandleServer { get; set; }
        /// <summary>
        /// opc服务器对象
        /// </summary>
        public OPCServer KepServer { get; set; }
        /// <summary>
        /// opc组别集合对象
        /// </summary>
        public OPCGroups KepGroups { get; set; }
        /// <summary>
        /// opc组别对象
        /// </summary>
        public OPCGroup KepGroup { get; set; }
        /// <summary>
        /// opc项集合对象
        /// </summary>
        public OPCItems KepItems { get; set; }
        /// <summary>
        /// opc项对象
        /// </summary>
        public OPCItem KepItem { get; set; }

        /// <summary>
        /// 连接状态
        /// </summary>
        public bool ConnectState { get; set; }
        /// <summary>
        /// 连接内容
        /// </summary>
        public string ConnectContents { get; set; }
        /// <summary>
        /// 创建群组是否成功
        /// </summary>
        public bool GroupsState { get; set; }
    }
    #endregion
    /// <summary>
    /// opc参数信息
    /// </summary>
    public class OPCItemParameter
    {
        public OPCItemParameter()
        {
            this.ChangeTime = DateTime.Now;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="pName">opc项名称</param>
        /// <param name="plcName">PLC命名</param>
        /// <param name="handle">客户端句柄</param>
        /// <param name="value">值</param>
        public OPCItemParameter(string pName, string plcName, int handle, int value)
        {
            this.ParameterName = pName;
            this.PLCName = plcName;
            this.ItemHandle = handle;
            this.Value = value;
            this.ChangeTime = DateTime.Now;
            this.IsWriteOk = false;
        }
        /// <summary>
        /// 客户端参数句柄
        /// </summary>
        public int ItemHandle { get; set; }
        /// <summary>
        /// 对应PLC值的参数名称(OPC server命名)
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// PLC位置名称
        /// </summary>
        public string PLCName { get; set; }
        /// <summary>
        /// 参数值 
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 品质
        /// </summary>
        public string Qualities { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamps { get; set; }
        /// <summary>
        /// 值发生变化的时间,用于后期任务优先级
        /// </summary>
        public DateTime ChangeTime { get; set; }
        /// <summary>
        /// 是否写入成功
        /// </summary>
        public bool IsWriteOk { get; set; }
    }
}