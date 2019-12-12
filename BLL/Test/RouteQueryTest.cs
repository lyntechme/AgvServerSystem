using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class RouteQueryTest
    {
        int No = 0;
        public RouteQueryTest(int no)
        {
            this.No = no;
        }
        public void QueryRouteTest()
        {
            DijkstraSolution di = new DijkstraSolution();
            while (true)
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    List<KeyValuePair<int, RfidInfo>> ls = di.FindRoute(1, 30);
                    string ss = string.Empty;
                    for (int i = 0; i < ls.Count; i++)
                    {
                        ss += ls[i].Key.ToString() + "->";
                    }
                    Debug.Print(No.ToString() + ":        " + ss + "   " + DateTime.Now.Subtract(dt).TotalSeconds.ToString() + "      " + DateTime.Now.ToString());
                }
                catch { }
                Thread.Sleep(100);
            }
        }
    }
}
