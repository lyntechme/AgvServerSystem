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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.BringToFront();
            //this.Opacity = 0;
        }
        private delegate void SetTextHandler(string text);
        public void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                this.Invoke(new SetTextHandler(SetText), text);
            }
            else
            {
                this.label1.Text = text;
            }
            //if (this.InvokeRequired)
            //{ }
            //else
            //{
            //    this.Opacity = 1;
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
