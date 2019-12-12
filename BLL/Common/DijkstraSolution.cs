using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DijkstraSolution
    {
        /// <summary>
        /// rfid阵列
        /// </summary>
        public static int[,] graph = new int[1, 1];
        public void RouteArray()
        {
            int max = 1000000;
            List<MA_RfidPoint> lsrfd = Common.rfidDt.Values.ToList();
            graph = new int[lsrfd.Count, lsrfd.Count];
            DateTime dt = DateTime.Now;
            for (int i = 0; i < lsrfd.Count; i++)
            {
                for (int j = 0; j < lsrfd.Count; j++)
                {
                    if (lsrfd[i].RfidInfos.Any(o => o.EdgeRfidNum == lsrfd[j].RfidNo))
                    {
                        try
                        {
                            graph[i, j] = lsrfd[i].RfidInfos.Find(o => o.EdgeRfidNum == lsrfd[j].RfidNo).EdgeLength;
                        }
                        catch { }
                    }
                    else
                    {
                        graph[i, j] = max;
                    }
                }
            }
            Debug.Print(DateTime.Now.Subtract(dt).TotalSeconds.ToString());
        }
        /// <summary>
        /// 查找最短路径
        /// </summary>
        /// <param name="_begin"></param>
        /// <param name="_end"></param>
        /// <param name="type0"></param>
        /// <returns></returns>
        public List<KeyValuePair<int, RfidInfo>> FindRoute(int _begin, int _end)
        {
            List<KeyValuePair<int, RfidInfo>> lsRoutes = new List<KeyValuePair<int, RfidInfo>>();
            try
            {
                if (_begin != _end)
                {
                    List<int> ls = FindRfid(_begin, _end);
                    for (int i = 0; i < ls.Count; i++)
                    {
                        if ((i + 1) < ls.Count)
                        {
                            RfidInfo rfidInfo = Common.rfidDt[ls[i]].RfidInfos.Find(o => o.EdgeRfidNum == ls[i + 1]);
                            KeyValuePair<int, RfidInfo> kv = new KeyValuePair<int, RfidInfo>(ls[i], rfidInfo);
                            lsRoutes.Add(kv);
                        }
                    }
                }
            }
            catch { }
            return lsRoutes;
        }
        /// <summary>
        /// 查找最短路径
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<int> FindRfid(int begin_, int end_)
        {
            try
            {
                int max = 1000000;
                List<MA_RfidPoint> lsrfd = Common.rfidDt.Values.ToList();
                //int[,] graph = new int[lsrfd.Count, lsrfd.Count];
                //DateTime dt = DateTime.Now;
                //for (int i = 0; i < lsrfd.Count; i++)
                //{
                //    for (int j = 0; j < lsrfd.Count; j++)
                //    {
                //        if (lsrfd[i].RfidInfos.Any(o => o.EdgeRfidNum == lsrfd[j].RfidNo))
                //        {
                //            try
                //            {
                //                graph[i, j] = lsrfd[i].RfidInfos.Find(o => o.EdgeRfidNum == lsrfd[j].RfidNo).EdgeLength;
                //            }
                //            catch { }
                //        }
                //        else
                //        {
                //            graph[i, j] = max;
                //        }
                //    }
                //}
                //Debug.Print(DateTime.Now.Subtract(dt).TotalSeconds.ToString());
                int begin = lsrfd.FindIndex(o => o.RfidNo == begin_);
                int end = lsrfd.FindIndex(o => o.RfidNo == end_);
                int[] path = new int[lsrfd.Count];
                int[] cost = new int[lsrfd.Count];
                FindShortestPath(graph, begin, path, cost, max);
                List<int> lsPoints = new List<int>();
                int find = end;
                //List<int> rValueLs = new List<int>(new int[] { 2, 3 });
                while (path[find] != -1 && path[find] != begin)
                {
                    lsPoints.Add(lsrfd[path[find]].RfidNo);
                    find = path[find];
                }
                //while (path[find] != -1 && path[find] != begin) ; // && path[find] != 0);
                lsPoints.Reverse();
                lsPoints.Insert(0, begin_);
                lsPoints.Add(end_);
                return lsPoints;
            }
            catch
            {
                return new List<int>();
            }
        }
        /*
       * 求解各节点最短路径，获取path，和cost数组，
       * path[i]表示vi节点的前继节点索引，一直追溯到起点。
       * cost[i]表示vi节点的花费
       */
        private void FindShortestPath(int[,] graph, int startIndex, int[] path, int[] cost, int max)
        {
            int nodeCount = graph.GetLength(0);
            bool[] v = new bool[nodeCount];
            //初始化 path，cost，V
            for (int i = 0; i < nodeCount; i++)
            {
                if (i == startIndex)//如果是出发点
                {
                    v[i] = true;//
                }
                else
                {
                    cost[i] = graph[startIndex, i];
                    if (cost[i] < max) path[i] = startIndex;
                    else path[i] = -1;
                    v[i] = false;
                }
            }
            //
            for (int i = 1; i < nodeCount; i++)//求解nodeCount-1个
            {
                int minCost = max;
                int curNode = -1;
                for (int w = 0; w < nodeCount; w++)
                {
                    if (!v[w])//未在V集合中
                    {
                        if (cost[w] < minCost)
                        {
                            minCost = cost[w];
                            curNode = w;
                        }
                    }
                }//for  获取最小权值的节点
                if (curNode == -1) break;//剩下都是不可通行的节点，跳出循环
                v[curNode] = true;
                for (int w = 0; w < nodeCount; w++)
                {
                    if (!v[w] && (graph[curNode, w] + cost[curNode] < cost[w]))
                    {
                        cost[w] = graph[curNode, w] + cost[curNode];//更新权值
                        path[w] = curNode;//更新路径
                    }
                }//for 更新其他节点的权值（距离）和路径
            }//
        }
    }
}
