using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public partial class DoubleLabel : UserControl
    {
        public DoubleLabel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// label1的高
        /// </summary>
        public int Label1Height
        {
            get
            {
                return label1.Height;
            }
            set
            {
                this.label1.Height = value;
            }
        }
        public Label Label1
        {
            get
            {
                return this.label1;
            }
            set
            {
                this.label1 = value;
            }
        }
        public Label Label2
        {
            get
            {
                return this.label2;
            }
            set
            {
                this.Label2 = value;
            }
        }
        /// <summary>
        /// label1的背景色
        /// </summary>
        public Color Label1BackColor
        {
            get
            {
                return this.label1.BackColor;
            }
            set
            {
                this.label1.BackColor = value;
            }
        }
        /// <summary>
        /// label1的背景色
        /// </summary>
        public Color BackColor
        {
            get
            {
                return this.label1.BackColor;
            }
            set
            {
                this.label1.BackColor = value;
            }
        }
        /// <summary>
        /// label2的背景色
        /// </summary>
        public Color Label2BackColor
        {
            get
            {
                return this.label2.BackColor;
            }
            set
            {
                this.label2.BackColor = value;
            }
        }
        /// <summary>
        /// label1的内容
        /// </summary>
        public string Text { get { return this.label1.Text; } set { this.label1.Text = value; } }
        /// <summary>
        /// label1的内容
        /// </summary>
        public string Label1Text { get { return this.label1.Text; } set { this.label1.Text = value; } }
        /// <summary>
        /// label2的内容
        /// </summary>
        public string Label2Text { get { return this.label2.Text; } set { this.label2.Text = value; } }
        /// <summary>
        /// label1的字体
        /// </summary>
        public Font Label1Font { get { return this.label1.Font; } set { this.label1.Font = value; } }
        /// <summary>
        /// label2的字体 
        /// </summary>
        public Font Label2Font { get { return this.label2.Font; } set { this.label2.Font = value; } }
        /// <summary>
        /// label1的TextAlign
        /// </summary>
        public ContentAlignment Label1TextAlign { get { return this.label1.TextAlign; } set { this.label1.TextAlign = value; } }
        /// <summary>
        /// label2的TextAlign 
        /// </summary>
        public ContentAlignment Label2TextAlign { get { return this.label2.TextAlign; } set { this.label2.TextAlign = value; } }
        /// <summary>
        /// label1的Image
        /// </summary>
        public Image Label1Image { get { return this.label1.Image; } set { this.label1.Image = value; } }
        /// <summary>
        /// label2的Image 
        /// </summary>
        public Image Label2Image { get { return this.label2.Image; } set { this.label2.Image = value; } }
        /// <summary>
        /// label1的ImageAlign
        /// </summary>
        public ContentAlignment Label1ImageAlign { get { return this.label1.ImageAlign; } set { this.label1.ImageAlign = value; } }
        /// <summary>
        /// label2的ImageAlign 
        /// </summary>
        public ContentAlignment Label2ImageAlign { get { return this.label2.ImageAlign; } set { this.label2.ImageAlign = value; } }
        /// <summary>
        /// label1的Margin
        /// </summary>
        public Padding Label1Margin { get { return this.label1.Padding; } set { this.label1.Padding = value; } }
        /// <summary>
        /// label2的Margin 
        /// </summary>
        public Padding Label2Margin { get { return this.label2.Padding; } set { this.label2.Padding = value; } }
    }
}
