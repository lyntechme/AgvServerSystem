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
    public partial class TaskLineForm : Form
    {
        public TaskLineForm()
        {
            InitializeComponent();
            if (Common.lineNameDt.Count > 0)
            {
                dgvLine.Rows.Clear();
                foreach (string item in Common.lineNameDt.Keys)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dgvLine);
                    dgvr.Cells[0].Value = item;
                    dgvr.Cells[1].Value = Common.lineNameDt[item];
                    dgvLine.Rows.Add(dgvr);
                }
            }
        }

        private void TaskLineForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLineCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLineChange_Click(object sender, EventArgs e)
        {
            try
            {
                Common.lineNameDt.Clear();
                for (int i = 0; i < dgvLine.Rows.Count - 1; i++)
                {
                    string dd = dgvLine[0, i].Value.ToString().Trim();
                    if (dgvLine[0, i].Value.ToString().Trim() != "")
                    {
                        Common.lineNameDt[dgvLine[0, i].Value.ToString().Trim()] = dgvLine[1, i].Value.ToString().Trim();
                    }
                }
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
