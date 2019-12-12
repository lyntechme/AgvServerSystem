using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //坐标类
    public class point
    {
        public point()
        { }
        public point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { set; get; }
        public int Y { set; get; }
    }
}
