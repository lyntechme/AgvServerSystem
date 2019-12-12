using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public partial class TestTask : Form
    {
        public TestTask()
        {
            InitializeComponent();
            try
            {
                List<int> ls = Common.maiDict.Keys.ToList();
                cbAgvNo.Items.AddRange(ls.ToArray().Select<int, object>(o => (object)o).ToArray());
                cbAgvNo.SelectedIndex = 0;
            }
            catch { }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                int load = int.Parse(txtLoad.Text);
                int unload = int.Parse(txtUnload.Text);
                int agvNo = int.Parse(cbAgvNo.SelectedItem.ToString());
                BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.LoadAndUnload, new int[] { load, unload });
                this.Close();
            }
            catch
            {
                MessageBox.Show("Parameters error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
