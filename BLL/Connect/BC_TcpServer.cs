using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Model;

namespace BLL
{
    public class BC_TcpServer
    {

        #region 创建一个服务程序
        private static byte[] result = new byte[204800];
        private static int myProt = 8010;   //端口  
        static Socket serverSocket;

        public BC_TcpServer()
        {

        }


        public void Bc_BeginListen()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, myProt));  //绑定IP地址：端口  
            serverSocket.Listen(100);    //设定最多10个排队连接请求  
            //Debug.WriteLine(string.Format("启动监听{0}成功", serverSocket.LocalEndPoint));
            //通过Clientsoket发送数据  
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Name = "TcpServer";
            myThread.IsBackground = true;
            Common.clientDt.Add(serverSocket.LocalEndPoint.ToString(), serverSocket);
            Common.clientThreadDt.Add(serverSocket.LocalEndPoint.ToString(), myThread);
            myThread.Start();
        }
        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                //Common.clientDt.Add(clientSocket.RemoteEndPoint.ToString(), clientSocket);
                ////clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                //Thread receiveThread = new Thread(ReceiveMessage);
                //receiveThread.Start(clientSocket);
                //Common.clientThreadDt.Add(clientSocket.RemoteEndPoint.ToString(), receiveThread);
                string ipName = clientSocket.RemoteEndPoint.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
                if (Common.clientDt.ContainsKey(ipName))
                {
                    Common.clientDt.Remove(ipName);
                }
                if (Common.clientThreadDt.ContainsKey(ipName))
                {
                    try
                    {
                        Common.clientThreadDt[ipName].Abort();
                    }
                    catch { }
                    Common.clientThreadDt.Remove(ipName);
                }
                if (!Common.clientDt.ContainsKey(ipName))
                {
                    Common.clientDt[ipName] = clientSocket;
                    //clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.Start(clientSocket);
                    Common.clientThreadDt.Add(ipName, receiveThread);
                }
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            string ipName = string.Empty;
            try
            {
                ipName = myClientSocket.RemoteEndPoint.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            catch { }
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据  
                    int receiveNumber = myClientSocket.Receive(result);
                    if (receiveNumber == 0)
                    {
                        Common.clientDt.Remove(ipName);
                        Common.clientThreadDt.Remove(ipName);
                        break;
                    }
                    else
                    {
                        string receive_str = Encoding.UTF8.GetString(result, 0, receiveNumber);
                        lock (Common.tcpObj)
                        {
                            SendMessage(clientSocket, receive_str);
                        }
                    }
                }
                catch (SocketException se)
                {
                    try
                    {
                        Common.clientDt.Remove(ipName);
                        Common.clientThreadDt.Remove(ipName);
                        myClientSocket.Shutdown(SocketShutdown.Both);
                        myClientSocket.Close();
                    }
                    catch
                    { }
                    break;
                }
                catch (Exception ex)
                {
                    try
                    {
                        Common.clientDt.Remove(ipName);
                        Common.clientThreadDt.Remove(ipName);
                        myClientSocket.Shutdown(SocketShutdown.Both);
                        myClientSocket.Close();
                    }
                    catch
                    { }
                    break;
                }
            }
        }
        private void SendMessage(object clientSock, string msg)
        {
            try
            {
                Socket mycs = (Socket)clientSock;
                if (msg.Substring(0, 7) == "AddTask")
                {
                    //根据实际情况添加任务
                }
                else if (msg.Substring(0, 15) == "QueryPalletTask")
                {
                    try
                    {
                        string queryPalletTask = string.Empty;
                        List<string> taskLs = Common.taskDt[(int)Enumerations.agvType.type_1].Keys.ToList();
                        for (int i = 0; i < taskLs.Count; i++)
                        {
                            string taskStr = string.Empty;
                            string taskKey = taskLs[i];
                            try
                            {
                                //if (Common.taskDt[taskKey].T_Type == Enumerations.TaskType.Pallet)
                                //{
                                taskStr += Common.taskDt[(int)Enumerations.agvType.type_1][taskKey].T_Id + "|" + Common.taskDt[(int)Enumerations.agvType.type_1][taskKey].T_Load.ToString() + "|" + Common.taskDt[(int)Enumerations.agvType.type_1][taskKey].T_RestRfid.ToString() + "|" + Common.taskDt[(int)Enumerations.agvType.type_1][taskKey].T_AgvNo.ToString() + "|" + Common.taskDt[(int)Enumerations.agvType.type_1][taskKey].T_State.ToString() + "|" + Common.taskDt[(int)Enumerations.agvType.type_1][taskKey].T_MaterialInfo + ",";
                                //}
                            }
                            catch { }
                            queryPalletTask += taskStr;
                        }
                        if (queryPalletTask == string.Empty)
                            queryPalletTask = "null";
                        mycs.Send(Encoding.UTF8.GetBytes(queryPalletTask));
                    }
                    catch { }
                }
            }
            catch { }
        }
        #endregion //创建一个服务程序
    }
}
