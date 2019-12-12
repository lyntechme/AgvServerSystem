using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public partial class WaitForm : Form
    {
        public static int pValue = 0;
        public static bool IsOpen = false;
        private double count = 0.4;
        private bool isAdd = true;//
        public WaitForm()
        {
            InitializeComponent();
            this.circularProgressBar1.Text = string.Empty;
            CheckForIllegalCrossThreadCalls = false;
            this.BringToFront();
            label2.BringToFront();
        }

        private delegate void SetTextHandler(string text);
        private delegate void SetParameterHandler(string contents);
        public void SetText(string text)
        {
            try
            {
                if (this.label1.InvokeRequired)
                {
                    this.Invoke(new SetTextHandler(SetText), text);
                }
                else
                {
                    //this.label1.Text = text;
                }
            }
            catch { }
        }
        public void SetParameter(string contents)
        {
            try
            {
                if (this.label2.InvokeRequired)
                {
                    this.Invoke(new SetParameterHandler(SetParameter), contents);
                }
                else
                {
                    this.label2.Text = "Agv central control system\r\nLoading...";
                    if (pValue > 100) pValue = 100;
                    this.circularProgressBar1.Text = string.Format("{0}%", pValue);
                    this.circularProgressBar1.Value = pValue;
                }
            }
            catch { }
        }
        private void LoginBufferForm_Load(object sender, EventArgs e)
        {

        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                //pbLogin.Value = pValue;
                double d = (double)(((double)pValue) / 100);
                if (d < 0.4) d = 0.6;
                //this.Opacity = d;
                if (this.Opacity != count)
                    this.Opacity = count;
                if (count >= 1)
                    isAdd = false;
                else if (count <= 0.4)
                    isAdd = true;
                if (isAdd)
                {
                    count += 0.02;
                }
                else
                {
                    count -= 0.02;
                }
                //if (pValue < 10) this.circularProgressBar1.ProgressColor = Color.Silver;
                //else if (pValue >= 10 && pValue < 20) this.circularProgressBar1.ProgressColor = Color.Black;
                //else if (pValue >= 20 && pValue < 30) this.circularProgressBar1.ProgressColor = Color.White;
                //else if (pValue >= 30 && pValue < 40) this.circularProgressBar1.ProgressColor = Color.Violet;
                //else if (pValue >= 40 && pValue < 50) this.circularProgressBar1.ProgressColor = Color.Blue;
                //else if (pValue >= 50 && pValue < 60) this.circularProgressBar1.ProgressColor = Color.Cyan;
                //else if (pValue >= 60 && pValue < 70) this.circularProgressBar1.ProgressColor = Color.Green;
                //else if (pValue >= 70 && pValue < 80) this.circularProgressBar1.ProgressColor = Color.Yellow;
                //else if (pValue >= 80 && pValue < 0) this.circularProgressBar1.ProgressColor = Color.Orange;
                //else if (pValue >= 90) this.circularProgressBar1.ProgressColor = Color.Red;
            }
            catch { }
        }

    }
}
