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
    public partial class PositionNameForm : Form
    {
        public PositionNameForm()
        {
            InitializeComponent();
            try
            {
                Dictionary<string, string> pls = new Dictionary<string, string>();
                foreach (string item in Common.pNameDt.Keys)
                {
                    if (pls.ContainsKey(Common.pNameDt[item]))
                    {
                        string ss = pls[Common.pNameDt[item]];
                        ss += item.ToString() + ",";
                        pls[Common.pNameDt[item]] = ss;
                    }
                    else
                    {
                        pls[Common.pNameDt[item]] = item + ",";
                    }
                }
                foreach (string item in pls.Keys)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(dgvPosition);
                    dgvr.Cells[0].Value = item;
                    dgvr.Cells[1].Value = pls[item];
                    dgvPosition.Rows.Add(dgvr);
                }
            }
            catch (Exception ex)
            { }
        }

        private void btnPositionSet_Click(object sender, EventArgs e)
        {
            try
            {
                Common.pNameDt.Clear();
                for (int i = 0; i < dgvPosition.Rows.Count - 1; i++)
                {
                    string[] positionLs = dgvPosition[1, i].Value.ToString().Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in positionLs)
                    {
                        Common.pNameDt[item] = dgvPosition[0, i].Value.ToString().Trim();
                    }
                }
                MessageBox.Show("Set successfully！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Set failed！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnPositionCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
