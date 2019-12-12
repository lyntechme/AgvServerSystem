using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace AgvServerSystem
{
    public partial class AgvShowForm : Form
    {
        private Dictionary<int, CheckBox> cbDict = new Dictionary<int, CheckBox>();
        public AgvShowForm(List<MA_AgvComInfo> maaciList)
        {
            InitializeComponent();
            try
            {
                cbDict.Clear();
                foreach (MA_AgvComInfo item in maaciList)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = "Agv" + item.A_Id.ToString("D2");
                    cb.Name = "Agv" + item.A_Id.ToString();
                    if (item.A_IsUsing)
                    {
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.Checked = false;
                    }
                    cb.Parent = tlpAgvShowCheck;
                    cbDict[item.A_Id] = cb;
                }
            }
            catch (Exception ex)
            { }
        }

        private void AgvShowForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgvShowConfirm_Click(object sender, EventArgs e)
        {
            Dictionary<int, bool> isUsing = new Dictionary<int, bool>();
            foreach (int item in cbDict.Keys)
            {
                isUsing[item] = cbDict[item].Checked;
            }
            BA_AgvComInfo baci = new BA_AgvComInfo();
            if (baci.UpdateIsUsing(isUsing))
            {
                MessageBox.Show("Set successfully,please restart software.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("Set failed！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void btnAgvShowCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
