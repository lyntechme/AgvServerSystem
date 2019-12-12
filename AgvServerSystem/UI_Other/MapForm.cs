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
    public partial class MapForm : Form
    {
        Timer tmr;
        public MapForm(Timer _tmr)
        {
            InitializeComponent();
            this.tmr = _tmr;
            if (Common.isMapChange)
            {
                chbMapChange.Checked = true;
            }
            else
            {
                chbMapChange.Checked = false;
            }
            txtMapChangeTime.Text = (Common.mapChangeTime / 1000).ToString();
        }

        private void btnMapObtain_Click(object sender, EventArgs e)
        {
            try
            {
                dgvMapInfo.Rows.Clear();
                foreach (int item in Common.mapInfo.Keys)
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    dr.CreateCells(dgvMapInfo);
                    dr.Cells[0].Value = item;
                    dr.Cells[1].Value = Common.mapInfo[item];
                    dgvMapInfo.Rows.Add(dr);
                }
            }
            catch
            { }
        }

        private void btnMapAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMapName.Text.Contains('|') || txtMapName.Text.Contains(','))
                {
                    MessageBox.Show("Illegal character", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        int id = Convert.ToInt32(txtMapId.Text);
                        if (Common.mapInfo.ContainsKey(id))
                        {
                            MessageBox.Show("The id already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Common.mapInfo[id] = txtMapName.Text;
                            MessageBox.Show("Add successully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void txtMapId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvMapInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rows = e.RowIndex;
                if (e.ColumnIndex == 2)
                {
                    if (MessageBox.Show("Whether to delete the map?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Common.mapInfo.Remove((int)dgvMapInfo.Rows[rows].Cells[0].Value);
                            MessageBox.Show("Delete successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch
                        {
                            MessageBox.Show("Delete failed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    if (MessageBox.Show("Whether to modify the map?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Common.mapInfo[(int)dgvMapInfo.Rows[rows].Cells[0].Value] = dgvMapInfo.Rows[rows].Cells[1].Value.ToString();
                            MessageBox.Show("Modify successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch
                        {
                            MessageBox.Show("Modify failed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            catch
            { }
        }

        private void btnMapChangeSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbMapChange.Checked)
                {
                    int second = Convert.ToInt32(txtMapChangeTime.Text);
                    Common.mapChangeTime = second * 1000;
                    Common.isMapChange = true;
                    this.tmr.Interval = Common.mapChangeTime;
                    this.tmr.Enabled = true;
                }
                else
                {
                    Common.isMapChange = false;
                    this.tmr.Enabled = false;
                }
                MessageBox.Show("Set successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Unknown error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
