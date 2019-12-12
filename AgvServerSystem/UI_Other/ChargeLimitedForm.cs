using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public class ChargeLimitedForm : Form
    {
        private Panel panel1;
        private GroupBox gbxCapAgingCharge;
        private Panel panel2;
        private Label label17;
        private TextBox txtCapAgingChargeEnable;
        private Label label18;
        private Button btnCapAgingChargeLimitedRef;
        private Button btnCapAgingChargeLimitedRec;
        private Label label19;
        private TextBox txtCapAgingChargeTime;
        private Label label20;
        private Label label21;
        private Label label22;
        private TextBox txtCapAgingChargeVoltage;
        private Label label23;
        private TextBox txtCapAgingLowVoltage;
        private Label label24;
        private GroupBox gbxPreAgingCharge;
        private Panel panel3;
        private Label label9;
        private TextBox txtPreAgingChargeEnable;
        private Label label10;
        private Button btnPreAgingChargeLimitedRef;
        private Button btnPreAgingChargeLimitedRec;
        private Label label11;
        private TextBox txtPreAgingChargeTime;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtPreAgingChargeVoltage;
        private Label label15;
        private TextBox txtPreAgingLowVoltage;
        private Label label16;
        private GroupBox gbxCapTestCharge;
        private Panel panAll;
        private Label label25;
        private Label label7;
        private TextBox txtCapTestLowChargeTime;
        private Label label26;
        private TextBox txtCapTestChargeEnable;
        private Label label8;
        private Button btnCapTestChargeLimitedRef;
        private Button btnCapTestChargeLimitedRec;
        private Label label5;
        private TextBox txtCapTestChargeTime;
        private Label label6;
        private Label label4;
        private Label label3;
        private TextBox txtCapTestChargeVoltage;
        private Label label2;
        private TextBox txtCapTestLowVoltage;
        private Panel panel4;
        private GroupBox groupBox1;
        private Panel panAgvChargeVoltage;
        private Button btnChargeVoltageRef;
        private Button btnAgvChargeVoltageRec;
        private Label label31;
        private TextBox txtCapAgingChargeFullTime;
        private Label label32;
        private Label label29;
        private TextBox txtPreAgingChargeFullTime;
        private Label label30;
        private Label label27;
        private TextBox txtCapTestChargeFullTime;
        private Label label28;
        private Label label35;
        private TextBox txtCapAgingLowChargeTime;
        private Label label36;
        private Label label33;
        private TextBox txtPreAgingLowChargeTime;
        private Label label34;
        private Panel panel5;
        private Label label37;
        private Button btnChargeVoltageCountRef;
        private Button btnChargeVoltageCountRec;
        private TextBox txtChargeVoltageCount;
        private Label label42;
        private TextBox txtCapAgingChargeStationVoltage;
        private Label label43;
        private Label label40;
        private TextBox txtPreAgingChargeStationVoltage;
        private Label label41;
        private Label label38;
        private TextBox txtCapTestChargeStationVoltage;
        private Label label39;
        private Label label1;
        #region Properties

        #endregion
        public ChargeLimitedForm()
        {
            InitializeComponent();
            RefTextBox();
            RefPreTextBox();
            RefCapTextBox();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxCapAgingCharge = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.txtCapAgingChargeStationVoltage = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCapAgingLowChargeTime = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCapAgingChargeFullTime = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtCapAgingChargeEnable = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCapAgingChargeLimitedRef = new System.Windows.Forms.Button();
            this.btnCapAgingChargeLimitedRec = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCapAgingChargeTime = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCapAgingChargeVoltage = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCapAgingLowVoltage = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.gbxPreAgingCharge = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtPreAgingChargeStationVoltage = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtPreAgingLowChargeTime = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtPreAgingChargeFullTime = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPreAgingChargeEnable = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPreAgingChargeLimitedRef = new System.Windows.Forms.Button();
            this.btnPreAgingChargeLimitedRec = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPreAgingChargeTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPreAgingChargeVoltage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPreAgingLowVoltage = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.gbxCapTestCharge = new System.Windows.Forms.GroupBox();
            this.panAll = new System.Windows.Forms.Panel();
            this.label38 = new System.Windows.Forms.Label();
            this.txtCapTestChargeStationVoltage = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtCapTestChargeFullTime = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCapTestLowChargeTime = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtCapTestChargeEnable = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCapTestChargeLimitedRef = new System.Windows.Forms.Button();
            this.btnCapTestChargeLimitedRec = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCapTestChargeTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCapTestChargeVoltage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCapTestLowVoltage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnChargeVoltageCountRef = new System.Windows.Forms.Button();
            this.btnChargeVoltageCountRec = new System.Windows.Forms.Button();
            this.txtChargeVoltageCount = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.btnChargeVoltageRef = new System.Windows.Forms.Button();
            this.btnAgvChargeVoltageRec = new System.Windows.Forms.Button();
            this.panAgvChargeVoltage = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.gbxCapAgingCharge.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbxPreAgingCharge.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbxCapTestCharge.SuspendLayout();
            this.panAll.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbxCapAgingCharge);
            this.panel1.Controls.Add(this.gbxPreAgingCharge);
            this.panel1.Controls.Add(this.gbxCapTestCharge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 314);
            this.panel1.TabIndex = 0;
            // 
            // gbxCapAgingCharge
            // 
            this.gbxCapAgingCharge.Controls.Add(this.panel2);
            this.gbxCapAgingCharge.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbxCapAgingCharge.Location = new System.Drawing.Point(576, 0);
            this.gbxCapAgingCharge.Name = "gbxCapAgingCharge";
            this.gbxCapAgingCharge.Size = new System.Drawing.Size(288, 314);
            this.gbxCapAgingCharge.TabIndex = 6;
            this.gbxCapAgingCharge.TabStop = false;
            this.gbxCapAgingCharge.Text = "AGV Type3";
            this.gbxCapAgingCharge.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.txtCapAgingChargeStationVoltage);
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.txtCapAgingLowChargeTime);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtCapAgingChargeFullTime);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.txtCapAgingChargeEnable);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.btnCapAgingChargeLimitedRef);
            this.panel2.Controls.Add(this.btnCapAgingChargeLimitedRec);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtCapAgingChargeTime);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txtCapAgingChargeVoltage);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.txtCapAgingLowVoltage);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 294);
            this.panel2.TabIndex = 1;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(246, 226);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(11, 12);
            this.label42.TabIndex = 25;
            this.label42.Text = "V";
            // 
            // txtCapAgingChargeStationVoltage
            // 
            this.txtCapAgingChargeStationVoltage.Location = new System.Drawing.Point(128, 223);
            this.txtCapAgingChargeStationVoltage.Name = "txtCapAgingChargeStationVoltage";
            this.txtCapAgingChargeStationVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtCapAgingChargeStationVoltage.TabIndex = 7;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(13, 226);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(101, 12);
            this.label43.TabIndex = 23;
            this.label43.Text = "Site Low Voltage";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(246, 56);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(23, 12);
            this.label35.TabIndex = 22;
            this.label35.Text = "sec";
            // 
            // txtCapAgingLowChargeTime
            // 
            this.txtCapAgingLowChargeTime.Location = new System.Drawing.Point(128, 53);
            this.txtCapAgingLowChargeTime.Name = "txtCapAgingLowChargeTime";
            this.txtCapAgingLowChargeTime.Size = new System.Drawing.Size(100, 21);
            this.txtCapAgingLowChargeTime.TabIndex = 2;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(13, 56);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(95, 12);
            this.label36.TabIndex = 20;
            this.label36.Text = "Low Charge Time";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(246, 190);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 12);
            this.label31.TabIndex = 19;
            this.label31.Text = "min";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(246, 159);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 13;
            this.label17.Text = "V";
            // 
            // txtCapAgingChargeFullTime
            // 
            this.txtCapAgingChargeFullTime.Location = new System.Drawing.Point(128, 187);
            this.txtCapAgingChargeFullTime.Name = "txtCapAgingChargeFullTime";
            this.txtCapAgingChargeFullTime.Size = new System.Drawing.Size(100, 21);
            this.txtCapAgingChargeFullTime.TabIndex = 6;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(13, 190);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(101, 12);
            this.label32.TabIndex = 17;
            this.label32.Text = "Full Charge TIme";
            // 
            // txtCapAgingChargeEnable
            // 
            this.txtCapAgingChargeEnable.Location = new System.Drawing.Point(128, 156);
            this.txtCapAgingChargeEnable.Name = "txtCapAgingChargeEnable";
            this.txtCapAgingChargeEnable.Size = new System.Drawing.Size(100, 21);
            this.txtCapAgingChargeEnable.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 159);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 11;
            this.label18.Text = "Full Voltage";
            // 
            // btnCapAgingChargeLimitedRef
            // 
            this.btnCapAgingChargeLimitedRef.Location = new System.Drawing.Point(141, 250);
            this.btnCapAgingChargeLimitedRef.Name = "btnCapAgingChargeLimitedRef";
            this.btnCapAgingChargeLimitedRef.Size = new System.Drawing.Size(75, 23);
            this.btnCapAgingChargeLimitedRef.TabIndex = 10;
            this.btnCapAgingChargeLimitedRef.Text = "Update";
            this.btnCapAgingChargeLimitedRef.UseVisualStyleBackColor = true;
            this.btnCapAgingChargeLimitedRef.Click += new System.EventHandler(this.btnCapAgingChargeLimitedRef_Click);
            // 
            // btnCapAgingChargeLimitedRec
            // 
            this.btnCapAgingChargeLimitedRec.Location = new System.Drawing.Point(15, 250);
            this.btnCapAgingChargeLimitedRec.Name = "btnCapAgingChargeLimitedRec";
            this.btnCapAgingChargeLimitedRec.Size = new System.Drawing.Size(75, 23);
            this.btnCapAgingChargeLimitedRec.TabIndex = 11;
            this.btnCapAgingChargeLimitedRec.Text = "Receive";
            this.btnCapAgingChargeLimitedRec.UseVisualStyleBackColor = true;
            this.btnCapAgingChargeLimitedRec.Click += new System.EventHandler(this.btnCapAgingChargeLimitedRec_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(246, 129);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 12);
            this.label19.TabIndex = 8;
            this.label19.Text = "min";
            // 
            // txtCapAgingChargeTime
            // 
            this.txtCapAgingChargeTime.Location = new System.Drawing.Point(128, 126);
            this.txtCapAgingChargeTime.Name = "txtCapAgingChargeTime";
            this.txtCapAgingChargeTime.Size = new System.Drawing.Size(100, 21);
            this.txtCapAgingChargeTime.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 6;
            this.label20.Text = "Charge Time";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(246, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 12);
            this.label21.TabIndex = 5;
            this.label21.Text = "V";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(246, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 4;
            this.label22.Text = "V";
            this.label22.Visible = false;
            // 
            // txtCapAgingChargeVoltage
            // 
            this.txtCapAgingChargeVoltage.Location = new System.Drawing.Point(128, 95);
            this.txtCapAgingChargeVoltage.Name = "txtCapAgingChargeVoltage";
            this.txtCapAgingChargeVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtCapAgingChargeVoltage.TabIndex = 3;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 98);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "Charge Voltage";
            // 
            // txtCapAgingLowVoltage
            // 
            this.txtCapAgingLowVoltage.Location = new System.Drawing.Point(128, 26);
            this.txtCapAgingLowVoltage.Name = "txtCapAgingLowVoltage";
            this.txtCapAgingLowVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtCapAgingLowVoltage.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(13, 29);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "Low Voltage";
            // 
            // gbxPreAgingCharge
            // 
            this.gbxPreAgingCharge.Controls.Add(this.panel3);
            this.gbxPreAgingCharge.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbxPreAgingCharge.Location = new System.Drawing.Point(288, 0);
            this.gbxPreAgingCharge.Name = "gbxPreAgingCharge";
            this.gbxPreAgingCharge.Size = new System.Drawing.Size(288, 314);
            this.gbxPreAgingCharge.TabIndex = 5;
            this.gbxPreAgingCharge.TabStop = false;
            this.gbxPreAgingCharge.Text = "AGV Type2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.label40);
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.txtPreAgingChargeStationVoltage);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.txtPreAgingLowChargeTime);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.label29);
            this.panel3.Controls.Add(this.txtPreAgingChargeFullTime);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtPreAgingChargeEnable);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.btnPreAgingChargeLimitedRef);
            this.panel3.Controls.Add(this.btnPreAgingChargeLimitedRec);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtPreAgingChargeTime);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtPreAgingChargeVoltage);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtPreAgingLowVoltage);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(282, 294);
            this.panel3.TabIndex = 1;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(243, 226);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(11, 12);
            this.label40.TabIndex = 22;
            this.label40.Text = "V";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(243, 56);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(23, 12);
            this.label33.TabIndex = 19;
            this.label33.Text = "sec";
            // 
            // txtPreAgingChargeStationVoltage
            // 
            this.txtPreAgingChargeStationVoltage.Location = new System.Drawing.Point(125, 223);
            this.txtPreAgingChargeStationVoltage.Name = "txtPreAgingChargeStationVoltage";
            this.txtPreAgingChargeStationVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtPreAgingChargeStationVoltage.TabIndex = 7;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(13, 226);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(101, 12);
            this.label41.TabIndex = 20;
            this.label41.Text = "Site Low Voltage";
            // 
            // txtPreAgingLowChargeTime
            // 
            this.txtPreAgingLowChargeTime.Location = new System.Drawing.Point(125, 53);
            this.txtPreAgingLowChargeTime.Name = "txtPreAgingLowChargeTime";
            this.txtPreAgingLowChargeTime.Size = new System.Drawing.Size(100, 21);
            this.txtPreAgingLowChargeTime.TabIndex = 2;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(13, 56);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(95, 12);
            this.label34.TabIndex = 17;
            this.label34.Text = "Low Charge Time";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(243, 190);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 12);
            this.label29.TabIndex = 16;
            this.label29.Text = "min";
            // 
            // txtPreAgingChargeFullTime
            // 
            this.txtPreAgingChargeFullTime.Location = new System.Drawing.Point(125, 187);
            this.txtPreAgingChargeFullTime.Name = "txtPreAgingChargeFullTime";
            this.txtPreAgingChargeFullTime.Size = new System.Drawing.Size(100, 21);
            this.txtPreAgingChargeFullTime.TabIndex = 6;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 190);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(101, 12);
            this.label30.TabIndex = 14;
            this.label30.Text = "Full Charge TIme";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "V";
            // 
            // txtPreAgingChargeEnable
            // 
            this.txtPreAgingChargeEnable.Location = new System.Drawing.Point(125, 156);
            this.txtPreAgingChargeEnable.Name = "txtPreAgingChargeEnable";
            this.txtPreAgingChargeEnable.Size = new System.Drawing.Size(100, 21);
            this.txtPreAgingChargeEnable.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "Full Voltage";
            // 
            // btnPreAgingChargeLimitedRef
            // 
            this.btnPreAgingChargeLimitedRef.Location = new System.Drawing.Point(141, 250);
            this.btnPreAgingChargeLimitedRef.Name = "btnPreAgingChargeLimitedRef";
            this.btnPreAgingChargeLimitedRef.Size = new System.Drawing.Size(75, 23);
            this.btnPreAgingChargeLimitedRef.TabIndex = 10;
            this.btnPreAgingChargeLimitedRef.Text = "Update";
            this.btnPreAgingChargeLimitedRef.UseVisualStyleBackColor = true;
            this.btnPreAgingChargeLimitedRef.Click += new System.EventHandler(this.btnPreAgingChargeLimitedRef_Click);
            // 
            // btnPreAgingChargeLimitedRec
            // 
            this.btnPreAgingChargeLimitedRec.Location = new System.Drawing.Point(15, 250);
            this.btnPreAgingChargeLimitedRec.Name = "btnPreAgingChargeLimitedRec";
            this.btnPreAgingChargeLimitedRec.Size = new System.Drawing.Size(75, 23);
            this.btnPreAgingChargeLimitedRec.TabIndex = 11;
            this.btnPreAgingChargeLimitedRec.Text = "Receive";
            this.btnPreAgingChargeLimitedRec.UseVisualStyleBackColor = true;
            this.btnPreAgingChargeLimitedRec.Click += new System.EventHandler(this.btnPreAgingChargeLimitedRec_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(243, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "min";
            // 
            // txtPreAgingChargeTime
            // 
            this.txtPreAgingChargeTime.Location = new System.Drawing.Point(125, 123);
            this.txtPreAgingChargeTime.Name = "txtPreAgingChargeTime";
            this.txtPreAgingChargeTime.Size = new System.Drawing.Size(100, 21);
            this.txtPreAgingChargeTime.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "Charge Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(243, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "V";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(243, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "V";
            this.label14.Visible = false;
            // 
            // txtPreAgingChargeVoltage
            // 
            this.txtPreAgingChargeVoltage.Location = new System.Drawing.Point(125, 95);
            this.txtPreAgingChargeVoltage.Name = "txtPreAgingChargeVoltage";
            this.txtPreAgingChargeVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtPreAgingChargeVoltage.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "Charge Voltage";
            // 
            // txtPreAgingLowVoltage
            // 
            this.txtPreAgingLowVoltage.Location = new System.Drawing.Point(125, 26);
            this.txtPreAgingLowVoltage.Name = "txtPreAgingLowVoltage";
            this.txtPreAgingLowVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtPreAgingLowVoltage.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "Low Voltage";
            // 
            // gbxCapTestCharge
            // 
            this.gbxCapTestCharge.Controls.Add(this.panAll);
            this.gbxCapTestCharge.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbxCapTestCharge.Location = new System.Drawing.Point(0, 0);
            this.gbxCapTestCharge.Name = "gbxCapTestCharge";
            this.gbxCapTestCharge.Size = new System.Drawing.Size(288, 314);
            this.gbxCapTestCharge.TabIndex = 4;
            this.gbxCapTestCharge.TabStop = false;
            this.gbxCapTestCharge.Text = "AGV Type1";
            // 
            // panAll
            // 
            this.panAll.BackColor = System.Drawing.Color.LightBlue;
            this.panAll.Controls.Add(this.label38);
            this.panAll.Controls.Add(this.txtCapTestChargeStationVoltage);
            this.panAll.Controls.Add(this.label39);
            this.panAll.Controls.Add(this.label27);
            this.panAll.Controls.Add(this.txtCapTestChargeFullTime);
            this.panAll.Controls.Add(this.label28);
            this.panAll.Controls.Add(this.label25);
            this.panAll.Controls.Add(this.label7);
            this.panAll.Controls.Add(this.txtCapTestLowChargeTime);
            this.panAll.Controls.Add(this.label26);
            this.panAll.Controls.Add(this.txtCapTestChargeEnable);
            this.panAll.Controls.Add(this.label8);
            this.panAll.Controls.Add(this.btnCapTestChargeLimitedRef);
            this.panAll.Controls.Add(this.btnCapTestChargeLimitedRec);
            this.panAll.Controls.Add(this.label5);
            this.panAll.Controls.Add(this.txtCapTestChargeTime);
            this.panAll.Controls.Add(this.label6);
            this.panAll.Controls.Add(this.label4);
            this.panAll.Controls.Add(this.label3);
            this.panAll.Controls.Add(this.txtCapTestChargeVoltage);
            this.panAll.Controls.Add(this.label2);
            this.panAll.Controls.Add(this.txtCapTestLowVoltage);
            this.panAll.Controls.Add(this.label1);
            this.panAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAll.Location = new System.Drawing.Point(3, 17);
            this.panAll.Name = "panAll";
            this.panAll.Size = new System.Drawing.Size(282, 294);
            this.panAll.TabIndex = 1;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(245, 226);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(11, 12);
            this.label38.TabIndex = 19;
            this.label38.Text = "V";
            // 
            // txtCapTestChargeStationVoltage
            // 
            this.txtCapTestChargeStationVoltage.Location = new System.Drawing.Point(127, 223);
            this.txtCapTestChargeStationVoltage.Name = "txtCapTestChargeStationVoltage";
            this.txtCapTestChargeStationVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtCapTestChargeStationVoltage.TabIndex = 7;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(13, 226);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(101, 12);
            this.label39.TabIndex = 17;
            this.label39.Text = "Site Low Voltage";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(245, 190);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(23, 12);
            this.label27.TabIndex = 16;
            this.label27.Text = "min";
            // 
            // txtCapTestChargeFullTime
            // 
            this.txtCapTestChargeFullTime.Location = new System.Drawing.Point(127, 187);
            this.txtCapTestChargeFullTime.Name = "txtCapTestChargeFullTime";
            this.txtCapTestChargeFullTime.Size = new System.Drawing.Size(100, 21);
            this.txtCapTestChargeFullTime.TabIndex = 6;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(13, 190);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 12);
            this.label28.TabIndex = 14;
            this.label28.Text = "Full Charge TIme";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(245, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(23, 12);
            this.label25.TabIndex = 8;
            this.label25.Text = "sec";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "V";
            // 
            // txtCapTestLowChargeTime
            // 
            this.txtCapTestLowChargeTime.Location = new System.Drawing.Point(127, 53);
            this.txtCapTestLowChargeTime.Name = "txtCapTestLowChargeTime";
            this.txtCapTestLowChargeTime.Size = new System.Drawing.Size(100, 21);
            this.txtCapTestLowChargeTime.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(95, 12);
            this.label26.TabIndex = 6;
            this.label26.Text = "Low Charge Time";
            // 
            // txtCapTestChargeEnable
            // 
            this.txtCapTestChargeEnable.Location = new System.Drawing.Point(127, 156);
            this.txtCapTestChargeEnable.Name = "txtCapTestChargeEnable";
            this.txtCapTestChargeEnable.Size = new System.Drawing.Size(100, 21);
            this.txtCapTestChargeEnable.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "Full Voltage";
            // 
            // btnCapTestChargeLimitedRef
            // 
            this.btnCapTestChargeLimitedRef.Location = new System.Drawing.Point(141, 250);
            this.btnCapTestChargeLimitedRef.Name = "btnCapTestChargeLimitedRef";
            this.btnCapTestChargeLimitedRef.Size = new System.Drawing.Size(75, 23);
            this.btnCapTestChargeLimitedRef.TabIndex = 10;
            this.btnCapTestChargeLimitedRef.Text = "Update";
            this.btnCapTestChargeLimitedRef.UseVisualStyleBackColor = true;
            this.btnCapTestChargeLimitedRef.Click += new System.EventHandler(this.btnChargeLimitedRef_Click);
            // 
            // btnCapTestChargeLimitedRec
            // 
            this.btnCapTestChargeLimitedRec.Location = new System.Drawing.Point(15, 250);
            this.btnCapTestChargeLimitedRec.Name = "btnCapTestChargeLimitedRec";
            this.btnCapTestChargeLimitedRec.Size = new System.Drawing.Size(75, 23);
            this.btnCapTestChargeLimitedRec.TabIndex = 11;
            this.btnCapTestChargeLimitedRec.Text = "Receive";
            this.btnCapTestChargeLimitedRec.UseVisualStyleBackColor = true;
            this.btnCapTestChargeLimitedRec.Click += new System.EventHandler(this.btnChargeLimitedRec_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "min";
            // 
            // txtCapTestChargeTime
            // 
            this.txtCapTestChargeTime.Location = new System.Drawing.Point(127, 123);
            this.txtCapTestChargeTime.Name = "txtCapTestChargeTime";
            this.txtCapTestChargeTime.Size = new System.Drawing.Size(100, 21);
            this.txtCapTestChargeTime.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Charge Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "V";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "V";
            // 
            // txtCapTestChargeVoltage
            // 
            this.txtCapTestChargeVoltage.Location = new System.Drawing.Point(127, 95);
            this.txtCapTestChargeVoltage.Name = "txtCapTestChargeVoltage";
            this.txtCapTestChargeVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtCapTestChargeVoltage.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Charge Voltage";
            // 
            // txtCapTestLowVoltage
            // 
            this.txtCapTestLowVoltage.Location = new System.Drawing.Point(127, 26);
            this.txtCapTestLowVoltage.Name = "txtCapTestLowVoltage";
            this.txtCapTestLowVoltage.Size = new System.Drawing.Size(100, 21);
            this.txtCapTestLowVoltage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Low Voltage";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 314);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(575, 202);
            this.panel4.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.btnChargeVoltageRef);
            this.groupBox1.Controls.Add(this.btnAgvChargeVoltageRec);
            this.groupBox1.Controls.Add(this.panAgvChargeVoltage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 202);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AGV Charge Voltage";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnChargeVoltageCountRef);
            this.panel5.Controls.Add(this.btnChargeVoltageCountRec);
            this.panel5.Controls.Add(this.txtChargeVoltageCount);
            this.panel5.Controls.Add(this.label37);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(456, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(116, 109);
            this.panel5.TabIndex = 3;
            // 
            // btnChargeVoltageCountRef
            // 
            this.btnChargeVoltageCountRef.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChargeVoltageCountRef.Location = new System.Drawing.Point(0, 75);
            this.btnChargeVoltageCountRef.Name = "btnChargeVoltageCountRef";
            this.btnChargeVoltageCountRef.Size = new System.Drawing.Size(116, 31);
            this.btnChargeVoltageCountRef.TabIndex = 3;
            this.btnChargeVoltageCountRef.Text = "Update";
            this.btnChargeVoltageCountRef.UseVisualStyleBackColor = true;
            this.btnChargeVoltageCountRef.Click += new System.EventHandler(this.btnChargeVoltageCountRef_Click);
            // 
            // btnChargeVoltageCountRec
            // 
            this.btnChargeVoltageCountRec.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChargeVoltageCountRec.Location = new System.Drawing.Point(0, 44);
            this.btnChargeVoltageCountRec.Name = "btnChargeVoltageCountRec";
            this.btnChargeVoltageCountRec.Size = new System.Drawing.Size(116, 31);
            this.btnChargeVoltageCountRec.TabIndex = 2;
            this.btnChargeVoltageCountRec.Text = "Receive";
            this.btnChargeVoltageCountRec.UseVisualStyleBackColor = true;
            this.btnChargeVoltageCountRec.Click += new System.EventHandler(this.btnChargeVoltageCountRec_Click);
            // 
            // txtChargeVoltageCount
            // 
            this.txtChargeVoltageCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtChargeVoltageCount.Location = new System.Drawing.Point(0, 23);
            this.txtChargeVoltageCount.Name = "txtChargeVoltageCount";
            this.txtChargeVoltageCount.Size = new System.Drawing.Size(116, 21);
            this.txtChargeVoltageCount.TabIndex = 1;
            // 
            // label37
            // 
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label37.Dock = System.Windows.Forms.DockStyle.Top;
            this.label37.Location = new System.Drawing.Point(0, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(116, 23);
            this.label37.TabIndex = 0;
            this.label37.Text = "Judge count";
            this.label37.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnChargeVoltageRef
            // 
            this.btnChargeVoltageRef.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChargeVoltageRef.Location = new System.Drawing.Point(456, 53);
            this.btnChargeVoltageRef.Name = "btnChargeVoltageRef";
            this.btnChargeVoltageRef.Size = new System.Drawing.Size(116, 30);
            this.btnChargeVoltageRef.TabIndex = 2;
            this.btnChargeVoltageRef.Text = "Update";
            this.btnChargeVoltageRef.UseVisualStyleBackColor = true;
            this.btnChargeVoltageRef.Click += new System.EventHandler(this.btnChargeVoltageRef_Click);
            // 
            // btnAgvChargeVoltageRec
            // 
            this.btnAgvChargeVoltageRec.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgvChargeVoltageRec.Location = new System.Drawing.Point(456, 17);
            this.btnAgvChargeVoltageRec.Name = "btnAgvChargeVoltageRec";
            this.btnAgvChargeVoltageRec.Size = new System.Drawing.Size(116, 36);
            this.btnAgvChargeVoltageRec.TabIndex = 1;
            this.btnAgvChargeVoltageRec.Text = "Receive";
            this.btnAgvChargeVoltageRec.UseVisualStyleBackColor = true;
            this.btnAgvChargeVoltageRec.Click += new System.EventHandler(this.btnAgvChargeVoltageRec_Click);
            // 
            // panAgvChargeVoltage
            // 
            this.panAgvChargeVoltage.AutoScroll = true;
            this.panAgvChargeVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panAgvChargeVoltage.Dock = System.Windows.Forms.DockStyle.Left;
            this.panAgvChargeVoltage.Location = new System.Drawing.Point(3, 17);
            this.panAgvChargeVoltage.Name = "panAgvChargeVoltage";
            this.panAgvChargeVoltage.Size = new System.Drawing.Size(453, 182);
            this.panAgvChargeVoltage.TabIndex = 0;
            // 
            // ChargeLimitedForm
            // 
            this.ClientSize = new System.Drawing.Size(575, 516);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChargeLimitedForm";
            this.Text = "Charge Limited";
            this.Load += new System.EventHandler(this.ChargeLimitedForm_Load);
            this.panel1.ResumeLayout(false);
            this.gbxCapAgingCharge.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbxPreAgingCharge.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbxCapTestCharge.ResumeLayout(false);
            this.panAll.ResumeLayout(false);
            this.panAll.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnChargeLimitedRec_Click(object sender, EventArgs e)
        {
            RefTextBox();
        }

        private void btnChargeLimitedRef_Click(object sender, EventArgs e)
        {
            try
            {
                int low = Convert.ToInt32(Convert.ToDouble(txtCapTestLowVoltage.Text) * 10);
                int lowTime = Convert.ToInt32(txtCapTestLowChargeTime.Text);
                int charge = Convert.ToInt32(Convert.ToDouble(txtCapTestChargeVoltage.Text) * 10);
                int time = Convert.ToInt32(txtCapTestChargeTime.Text) * 60;
                int enable = Convert.ToInt32(Convert.ToDouble(txtCapTestChargeEnable.Text) * 10);
                int fullTime = Convert.ToInt32(txtCapTestChargeFullTime.Text);
                int chargeVoltage = Convert.ToInt32(Convert.ToDouble(txtCapTestChargeStationVoltage.Text) * 10);
                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1] = new ChargeLimitedInfo(low, lowTime, charge, time, enable, fullTime);
                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].ChargeVoltage = chargeVoltage;
                MessageBox.Show("Update successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Format error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void RefTextBox()
        {

            try
            {
                txtCapTestLowVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedLow / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedLow % 10);
                txtCapTestLowChargeTime.Text = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimiteLowTime.ToString();
                txtCapTestChargeVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedCharge / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedCharge % 10);
                txtCapTestChargeTime.Text = (Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedTime / 60).ToString();
                txtCapTestChargeEnable.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedEnable / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].LimitedEnable % 10);
                txtCapTestChargeFullTime.Text = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].FullTime.ToString();
                txtCapTestChargeStationVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].ChargeVoltage / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_1].ChargeVoltage % 10);
            }
            catch { }
        }

        private void btnPreAgingChargeLimitedRec_Click(object sender, EventArgs e)
        {
            RefPreTextBox();
        }

        private void btnPreAgingChargeLimitedRef_Click(object sender, EventArgs e)
        {
            try
            {
                int low = Convert.ToInt32(Convert.ToDouble(txtPreAgingLowVoltage.Text) * 10);
                int lowTime = Convert.ToInt32(txtPreAgingLowChargeTime.Text);
                int charge = Convert.ToInt32(Convert.ToDouble(txtPreAgingChargeVoltage.Text) * 10);
                int time = Convert.ToInt32(txtPreAgingChargeTime.Text) * 60;
                int enable = Convert.ToInt32(Convert.ToDouble(txtPreAgingChargeEnable.Text) * 10);
                int fullTime = Convert.ToInt32(txtPreAgingChargeFullTime.Text);
                int chargeVoltage = Convert.ToInt32(Convert.ToDouble(txtPreAgingChargeStationVoltage.Text) * 10);
                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2] = new ChargeLimitedInfo(low, lowTime, charge, time, enable, fullTime);
                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].ChargeVoltage = chargeVoltage;
                MessageBox.Show("Update successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Format error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefPreTextBox()
        {

            try
            {
                txtPreAgingLowVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedLow / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedLow % 10);
                txtPreAgingLowChargeTime.Text = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimiteLowTime.ToString();
                txtPreAgingChargeVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedCharge / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedCharge % 10);
                txtPreAgingChargeTime.Text = (Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedTime / 60).ToString();
                txtPreAgingChargeEnable.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedEnable / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].LimitedEnable % 10);
                txtPreAgingChargeFullTime.Text = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].FullTime.ToString();
                txtPreAgingChargeStationVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].ChargeVoltage / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_2].ChargeVoltage % 10);
            }
            catch { }
        }
        private void btnCapAgingChargeLimitedRec_Click(object sender, EventArgs e)
        {
            RefCapTextBox();
        }

        private void btnCapAgingChargeLimitedRef_Click(object sender, EventArgs e)
        {
            try
            {
                int low = Convert.ToInt32(Convert.ToDouble(txtCapAgingLowVoltage.Text) * 10);
                int charge = Convert.ToInt32(Convert.ToDouble(txtCapAgingChargeVoltage.Text) * 10);
                int time = Convert.ToInt32(txtCapAgingChargeTime.Text) * 60;
                int enable = Convert.ToInt32(Convert.ToDouble(txtCapAgingChargeEnable.Text) * 10);
                int fullTime = Convert.ToInt32(txtCapAgingChargeFullTime.Text);
                int chargeVoltage = Convert.ToInt32(Convert.ToDouble(txtCapAgingChargeStationVoltage.Text) * 10);
                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3] = new ChargeLimitedInfo(low, 5, charge, time, enable, fullTime);
                Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].ChargeVoltage = chargeVoltage;
                MessageBox.Show("Update successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Format error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefCapTextBox()
        {

            try
            {
                txtCapAgingLowVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedLow / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedLow % 10);
                txtCapAgingLowChargeTime.Text = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimiteLowTime.ToString();
                txtCapAgingChargeVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedCharge / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedCharge % 10);
                txtCapAgingChargeTime.Text = (Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedTime / 60).ToString();
                txtCapAgingChargeEnable.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedEnable / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].LimitedEnable % 10);
                txtCapAgingChargeFullTime.Text = Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].FullTime.ToString();
                txtCapAgingChargeStationVoltage.Text = string.Format("{0}.{1}", Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].ChargeVoltage / 10, Common.Instance.dtChargeLimitedInfo[Enumerations.agvType.type_3].ChargeVoltage % 10);
            }
            catch { }
        }
        /// <summary>
        /// 充电电压设定
        /// </summary>
        private Dictionary<int, TextBox> dtChargeVoltageTextBox = new Dictionary<int, TextBox>();
        private void CreateAgvChargeVoltage()
        {
            try
            {
                while (true)
                {
                    int agvNo = ChargeLimitedInfo.dtAgvChargeVoltage.FirstOrDefault(o => Common.maiDict.ContainsKey(o.Key) == false).Key;
                    if (agvNo > 0)
                    {
                        try
                        {
                            ChargeLimitedInfo.dtAgvChargeVoltage.Remove(agvNo);
                        }
                        catch { }
                    }
                    else
                    {
                        break;
                    }
                }
                List<int> cls = Common.maiDict.Keys.ToList();
                for (int i = 0; i < cls.Count; i++)
                {
                    int item = cls[i];
                    if (ChargeLimitedInfo.dtAgvChargeVoltage.ContainsKey(item) == false)
                    {
                        ChargeLimitedInfo.dtAgvChargeVoltage[item] = 0;
                    }
                    Panel panCharge = new Panel();
                    panCharge.BorderStyle = BorderStyle.FixedSingle;
                    panCharge.Size = new Size(80, 30);
                    panCharge.Parent = panAgvChargeVoltage;
                    panCharge.Location = new Point(i / 3 * 85, i % 3 * 33);
                    //label 充电桩信息
                    Label lblChargerAgvNo = new Label();
                    lblChargerAgvNo.AutoSize = false;
                    lblChargerAgvNo.Size = new Size(40, 30);
                    lblChargerAgvNo.BackColor = Color.Azure;
                    lblChargerAgvNo.BorderStyle = BorderStyle.FixedSingle;
                    lblChargerAgvNo.Location = new Point(0, 0);
                    lblChargerAgvNo.TextAlign = ContentAlignment.MiddleLeft;
                    lblChargerAgvNo.Text = string.Format("Agv{0}", item);
                    lblChargerAgvNo.Parent = panCharge;
                    //label 充电桩状态
                    TextBox txtChargeVoltage = new TextBox();
                    txtChargeVoltage.AutoSize = false;
                    txtChargeVoltage.Size = new Size(40, 30);
                    txtChargeVoltage.BorderStyle = BorderStyle.FixedSingle;
                    txtChargeVoltage.Location = new Point(40, 0);
                    txtChargeVoltage.BackColor = Color.White;
                    txtChargeVoltage.Text = ChargeLimitedInfo.dtAgvChargeVoltage[item].ToString();
                    dtChargeVoltageTextBox[item] = txtChargeVoltage;
                    txtChargeVoltage.Parent = panCharge;
                }
            }
            catch { }
        }

        private void btnAgvChargeVoltageRec_Click(object sender, EventArgs e)
        {

        }
        private void ReceiveChargeVol()
        {
            try
            {
                List<int> ls = ChargeLimitedInfo.dtAgvChargeVoltage.Keys.ToList();
                foreach (int item in ls)
                {
                    dtChargeVoltageTextBox[item].Text = ChargeLimitedInfo.dtAgvChargeVoltage[item].ToString();
                }
            }
            catch { }
        }
        private void btnChargeVoltageRef_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> ls = ChargeLimitedInfo.dtAgvChargeVoltage.Keys.ToList();
                foreach (int item in ls)
                {
                    ChargeLimitedInfo.dtAgvChargeVoltage[item] = Convert.ToDouble(dtChargeVoltageTextBox[item].Text);
                }
                MessageBox.Show("Modify successfully！");
            }
            catch
            {
                MessageBox.Show("The voltage can only be of numerical type.");
            }
        }

        private void ChargeLimitedForm_Load(object sender, EventArgs e)
        {
            CreateAgvChargeVoltage();
            txtChargeVoltageCount.Text = Common.Instance.chargeVoltageCount.ToString();
        }

        private void btnChargeVoltageCountRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtChargeVoltageCount.Text = Common.Instance.chargeVoltageCount.ToString();
            }
            catch { }
        }

        private void btnChargeVoltageCountRef_Click(object sender, EventArgs e)
        {
            try
            {
                int c = Convert.ToInt32(txtChargeVoltageCount.Text);
                if (c > 0)
                {
                    Common.Instance.chargeVoltageCount = c;
                    MessageBox.Show("Modify successfully!");
                }
                else
                    MessageBox.Show("The count must be greater than zero");
            }
            catch
            {
                MessageBox.Show("The count can only be of numerical type.");
            }
        }
    }
}
