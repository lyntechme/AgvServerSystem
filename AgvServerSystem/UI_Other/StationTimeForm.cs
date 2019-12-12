using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace AgvServerSystem
{
    public partial class StationTimeForm : Form
    {
        public StationTimeForm()
        {
            InitializeComponent();
            txtStationTime.Text = Common.stationTime.ToString();
        }

        private void btnStationTimeCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStationTimeSet_Click(object sender, EventArgs e)
        {
            try
            {
                Common.stationTime = Convert.ToInt32(txtStationTime.Text);
                MessageBox.Show("设定成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("设定失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void StationTimeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
