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
    public partial class MESForm : Form
    {
        public MESForm()
        {
            InitializeComponent();
            try
            {
                txtRecTask.Text = Common.Instance.mesConnectTime.GetTaskTime.ToString();
                txtUpdateAgvState.Text = Common.Instance.mesConnectTime.UpdateAgvStateTime.ToString();
                txtUpdateTaskState.Text = Common.Instance.mesConnectTime.UpdateTaskTime.ToString();
                txtCurrentTaskIndex.Text = Common.Instance.taskIndex.ToString();
            }
            catch { }
        }

        private void MESForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            txtRecTask.Text = Common.Instance.mesConnectTime.GetTaskTime.ToString();
            txtUpdateAgvState.Text = Common.Instance.mesConnectTime.UpdateAgvStateTime.ToString();
            txtUpdateTaskState.Text = Common.Instance.mesConnectTime.UpdateTaskTime.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRecTask.Text.Trim() != string.Empty)
                {
                    Common.Instance.mesConnectTime.GetTaskTime = Convert.ToInt32(txtRecTask.Text);
                }
                if (txtUpdateAgvState.Text.Trim() != string.Empty)
                {
                    Common.Instance.mesConnectTime.UpdateAgvStateTime = Convert.ToInt32(txtUpdateAgvState.Text);
                }
                if (txtUpdateTaskState.Text.Trim() != string.Empty)
                {
                    Common.Instance.mesConnectTime.UpdateTaskTime = Convert.ToInt32(txtUpdateTaskState.Text);
                }
                ParametersOperate.ParametersSave(true);
                MessageBox.Show("更改成功!");
            }
            catch
            {
                MessageBox.Show("输入参数格式错误，请重新输入");
            }
        }

        private void btnRecTaskIndex_Click(object sender, EventArgs e)
        {
            txtCurrentTaskIndex.Text = Common.Instance.taskIndex.ToString();
        }

        private void btnUpdateTaskIndex_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Instance.taskIndex = Convert.ToInt32(txtCurrentTaskIndex.Text);
                ParametersOperate.ParametersSave(true);
                MessageBox.Show("更改成功!");
            }
            catch
            {
                MessageBox.Show("输入参数格式错误，请重新输入");
            }
        }

    }
}
