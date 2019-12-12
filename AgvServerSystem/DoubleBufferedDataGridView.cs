using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public static class DoubleBufferedDataGridView
    {
        public static void DoubleBufferDataGridView(this DataGridView dgv, bool flag)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, flag, null);
        }
        public static void DoubleBufferListView(this ListView lv, bool flag)
        {
            Type lvType = lv.GetType();
            PropertyInfo pi = lvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(lv, flag, null);
        }
    }
}
