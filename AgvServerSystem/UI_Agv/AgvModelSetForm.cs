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
    public partial class AgvModelSetForm : Form
    {
        public AgvModelSetForm()
        {
            InitializeComponent();
            txtAgvModelSet.Text = Common.agvModelScale.ToString();
        }

        private void btnAgvModelSet_Click(object sender, EventArgs e)
        {
            try
            {
                double d = Convert.ToDouble(txtAgvModelSet.Text);
                if (d > 0)
                {
                    Common.agvModelScale = d;
                    MessageBox.Show("Set successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
            }
            catch { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
