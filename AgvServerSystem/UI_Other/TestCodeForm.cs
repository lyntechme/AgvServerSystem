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
    public partial class TestCodeForm : Form
    {
        public static int pValue = 0;
        public static bool IsOpen = false;
        private double count = 0.4;
        private bool isAdd = true;//

        public TestCodeForm()
        {
            InitializeComponent();
            this.circularProgressBar1.Text = string.Empty;
            CheckForIllegalCrossThreadCalls = false;
            this.BringToFront();
        }
        private delegate void SetTextHandler(string text);
        private delegate void SetParameterHandler(string contents);

        private void TestCodeForm_Load(object sender, EventArgs e)
        {

        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                double d = (double)(((double)pValue) / 100);
                if (d < 0.4) d = 0.6;
                //this.Opacity = d;
                //if (this.Opacity != count)
                //    this.Opacity = count;
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
            }
            catch { }
        }
    }
}
