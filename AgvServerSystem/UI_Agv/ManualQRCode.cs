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
    public partial class ManualQRCode : Form
    {
        private int AgvNo;
        public ManualQRCode(int agvNo )
        {
            InitializeComponent();
            this.AgvNo = agvNo;
        }

        private void ManualQRCode_Load(object sender, EventArgs e)
        {
            lblAgvNo.Text = this.AgvNo.ToString();
            try
            {
                lblTaskId.Text = Common.maiDict[AgvNo].Task1;
            }
            catch { }
        }

        private void btnQRCodeOK_Click(object sender, EventArgs e)
        {
            string qrCode = txtQrCode.Text;
            if (qrCode.All(o => o >= '0' && o <= '9') == false)
            {
                MessageBox.Show("二维码只能为数值类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string task = Common.maiDict[AgvNo].Task1;
                if (Common.taskDt[(int)Enumerations.agvType.type_1].ContainsKey(task))
                {
                    if (Common.taskDt[(int)Enumerations.agvType.type_1][task].CodeStrings.Contains(qrCode) == false)
                    {
                        Common.taskDt[(int)Enumerations.agvType.type_1][task].CodeStrings.Add(qrCode);
                        MessageBox.Show("设定成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                }
            }
        }

        private void btnQRCodeCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
