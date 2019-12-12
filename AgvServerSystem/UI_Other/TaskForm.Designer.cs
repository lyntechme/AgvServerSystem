using System.Drawing;
using System.Windows.Forms;
namespace AgvServerSystem
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panAreaTaskType = new System.Windows.Forms.Panel();
            this.rbtnCapAging = new System.Windows.Forms.RadioButton();
            this.rbtnPreAging = new System.Windows.Forms.RadioButton();
            this.rbtnCapTest = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panTaskType = new System.Windows.Forms.Panel();
            this.cbTaskType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSourceStatoin = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSourceGroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbTargetStatoin = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTargetGroup = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chbIsRobot = new System.Windows.Forms.CheckBox();
            this.txtCapTestSubCount = new System.Windows.Forms.TextBox();
            this.lblCapTestSubCount = new System.Windows.Forms.Label();
            this.cbTaskBindAgv = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTasksCount = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnTasksAdd = new System.Windows.Forms.Button();
            this.btnCalcel = new System.Windows.Forms.Button();
            this.btnTaskAdd = new System.Windows.Forms.Button();
            this.panAreaTaskType.SuspendLayout();
            this.panTaskType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "模拟任务";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panAreaTaskType
            // 
            this.panAreaTaskType.BackColor = System.Drawing.Color.Azure;
            this.panAreaTaskType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panAreaTaskType.Controls.Add(this.rbtnCapAging);
            this.panAreaTaskType.Controls.Add(this.rbtnPreAging);
            this.panAreaTaskType.Controls.Add(this.rbtnCapTest);
            this.panAreaTaskType.Controls.Add(this.label2);
            this.panAreaTaskType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panAreaTaskType.Location = new System.Drawing.Point(0, 30);
            this.panAreaTaskType.Name = "panAreaTaskType";
            this.panAreaTaskType.Size = new System.Drawing.Size(406, 28);
            this.panAreaTaskType.TabIndex = 1;
            // 
            // rbtnCapAging
            // 
            this.rbtnCapAging.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnCapAging.Location = new System.Drawing.Point(234, 0);
            this.rbtnCapAging.Name = "rbtnCapAging";
            this.rbtnCapAging.Size = new System.Drawing.Size(80, 26);
            this.rbtnCapAging.TabIndex = 3;
            this.rbtnCapAging.Text = "分容老化";
            this.rbtnCapAging.UseVisualStyleBackColor = true;
            this.rbtnCapAging.CheckedChanged += new System.EventHandler(this.rbtnCapAging_CheckedChanged);
            // 
            // rbtnPreAging
            // 
            this.rbtnPreAging.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPreAging.Location = new System.Drawing.Point(154, 0);
            this.rbtnPreAging.Name = "rbtnPreAging";
            this.rbtnPreAging.Size = new System.Drawing.Size(80, 26);
            this.rbtnPreAging.TabIndex = 2;
            this.rbtnPreAging.Text = "预充老化";
            this.rbtnPreAging.UseVisualStyleBackColor = true;
            this.rbtnPreAging.CheckedChanged += new System.EventHandler(this.rbtnPreAging_CheckedChanged);
            // 
            // rbtnCapTest
            // 
            this.rbtnCapTest.Checked = true;
            this.rbtnCapTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnCapTest.Location = new System.Drawing.Point(74, 0);
            this.rbtnCapTest.Name = "rbtnCapTest";
            this.rbtnCapTest.Size = new System.Drawing.Size(80, 26);
            this.rbtnCapTest.TabIndex = 1;
            this.rbtnCapTest.TabStop = true;
            this.rbtnCapTest.Text = "分容测试";
            this.rbtnCapTest.UseVisualStyleBackColor = true;
            this.rbtnCapTest.CheckedChanged += new System.EventHandler(this.rbtnCapTest_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "区域任务";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panTaskType
            // 
            this.panTaskType.BackColor = System.Drawing.Color.Azure;
            this.panTaskType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTaskType.Controls.Add(this.cbTaskType);
            this.panTaskType.Controls.Add(this.label3);
            this.panTaskType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTaskType.Location = new System.Drawing.Point(0, 58);
            this.panTaskType.Name = "panTaskType";
            this.panTaskType.Size = new System.Drawing.Size(406, 28);
            this.panTaskType.TabIndex = 2;
            // 
            // cbTaskType
            // 
            this.cbTaskType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTaskType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTaskType.FormattingEnabled = true;
            this.cbTaskType.Location = new System.Drawing.Point(74, 0);
            this.cbTaskType.Name = "cbTaskType";
            this.cbTaskType.Size = new System.Drawing.Size(140, 24);
            this.cbTaskType.TabIndex = 1;
            this.cbTaskType.SelectedIndexChanged += new System.EventHandler(this.cbTaskType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "任务类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbSourceStatoin);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbSourceGroup);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 28);
            this.panel1.TabIndex = 3;
            // 
            // cbSourceStatoin
            // 
            this.cbSourceStatoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSourceStatoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceStatoin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSourceStatoin.FormattingEnabled = true;
            this.cbSourceStatoin.Location = new System.Drawing.Point(248, 0);
            this.cbSourceStatoin.Name = "cbSourceStatoin";
            this.cbSourceStatoin.Size = new System.Drawing.Size(156, 24);
            this.cbSourceStatoin.TabIndex = 4;
            this.cbSourceStatoin.SelectedIndexChanged += new System.EventHandler(this.cbSourceStatoin_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(200, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "站点";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbSourceGroup
            // 
            this.cbSourceGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbSourceGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceGroup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSourceGroup.FormattingEnabled = true;
            this.cbSourceGroup.Location = new System.Drawing.Point(122, 0);
            this.cbSourceGroup.Name = "cbSourceGroup";
            this.cbSourceGroup.Size = new System.Drawing.Size(78, 24);
            this.cbSourceGroup.TabIndex = 2;
            this.cbSourceGroup.SelectedIndexChanged += new System.EventHandler(this.cbSourceGroup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(74, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "组别";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "起始站点";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 28);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Azure;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cbTargetStatoin);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.cbTargetGroup);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(406, 28);
            this.panel3.TabIndex = 5;
            // 
            // cbTargetStatoin
            // 
            this.cbTargetStatoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTargetStatoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetStatoin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTargetStatoin.FormattingEnabled = true;
            this.cbTargetStatoin.Location = new System.Drawing.Point(248, 0);
            this.cbTargetStatoin.Name = "cbTargetStatoin";
            this.cbTargetStatoin.Size = new System.Drawing.Size(156, 24);
            this.cbTargetStatoin.TabIndex = 4;
            this.cbTargetStatoin.SelectedIndexChanged += new System.EventHandler(this.cbTargetStatoin_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(200, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 26);
            this.label10.TabIndex = 3;
            this.label10.Text = "站点";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTargetGroup
            // 
            this.cbTargetGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTargetGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetGroup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTargetGroup.FormattingEnabled = true;
            this.cbTargetGroup.Location = new System.Drawing.Point(122, 0);
            this.cbTargetGroup.Name = "cbTargetGroup";
            this.cbTargetGroup.Size = new System.Drawing.Size(78, 24);
            this.cbTargetGroup.TabIndex = 2;
            this.cbTargetGroup.SelectedIndexChanged += new System.EventHandler(this.cbTargetGroup_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(74, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 26);
            this.label11.TabIndex = 1;
            this.label11.Text = "组别";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 26);
            this.label12.TabIndex = 0;
            this.label12.Text = "目标站点";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Azure;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(406, 28);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Azure;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 198);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(406, 28);
            this.panel5.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Azure;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.chbIsRobot);
            this.panel6.Controls.Add(this.txtCapTestSubCount);
            this.panel6.Controls.Add(this.lblCapTestSubCount);
            this.panel6.Controls.Add(this.cbTaskBindAgv);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 226);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(406, 28);
            this.panel6.TabIndex = 8;
            // 
            // chbIsRobot
            // 
            this.chbIsRobot.AutoSize = true;
            this.chbIsRobot.Checked = true;
            this.chbIsRobot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIsRobot.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbIsRobot.Location = new System.Drawing.Point(296, 0);
            this.chbIsRobot.Name = "chbIsRobot";
            this.chbIsRobot.Size = new System.Drawing.Size(84, 26);
            this.chbIsRobot.TabIndex = 6;
            this.chbIsRobot.Text = "执行机械臂";
            this.chbIsRobot.UseVisualStyleBackColor = true;
            // 
            // txtCapTestSubCount
            // 
            this.txtCapTestSubCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCapTestSubCount.Location = new System.Drawing.Point(248, 0);
            this.txtCapTestSubCount.Multiline = true;
            this.txtCapTestSubCount.Name = "txtCapTestSubCount";
            this.txtCapTestSubCount.Size = new System.Drawing.Size(48, 26);
            this.txtCapTestSubCount.TabIndex = 5;
            this.txtCapTestSubCount.Text = "5";
            // 
            // lblCapTestSubCount
            // 
            this.lblCapTestSubCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCapTestSubCount.Location = new System.Drawing.Point(166, 0);
            this.lblCapTestSubCount.Name = "lblCapTestSubCount";
            this.lblCapTestSubCount.Size = new System.Drawing.Size(82, 26);
            this.lblCapTestSubCount.TabIndex = 4;
            this.lblCapTestSubCount.Text = "分容柜数量";
            this.lblCapTestSubCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTaskBindAgv
            // 
            this.cbTaskBindAgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTaskBindAgv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTaskBindAgv.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTaskBindAgv.FormattingEnabled = true;
            this.cbTaskBindAgv.Location = new System.Drawing.Point(74, 0);
            this.cbTaskBindAgv.Name = "cbTaskBindAgv";
            this.cbTaskBindAgv.Size = new System.Drawing.Size(92, 24);
            this.cbTaskBindAgv.TabIndex = 3;
            this.cbTaskBindAgv.SelectedIndexChanged += new System.EventHandler(this.cbTaskBindAgv_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 26);
            this.label7.TabIndex = 1;
            this.label7.Text = "指派AGV";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Azure;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.txtTasksCount);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 254);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(406, 28);
            this.panel7.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(267, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 26);
            this.label8.TabIndex = 4;
            this.label8.Text = "数量";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Visible = false;
            // 
            // txtTasksCount
            // 
            this.txtTasksCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTasksCount.Location = new System.Drawing.Point(317, 0);
            this.txtTasksCount.Multiline = true;
            this.txtTasksCount.Name = "txtTasksCount";
            this.txtTasksCount.Size = new System.Drawing.Size(87, 26);
            this.txtTasksCount.TabIndex = 3;
            this.txtTasksCount.Text = "90";
            this.txtTasksCount.Visible = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Azure;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnTasksAdd);
            this.panel8.Controls.Add(this.btnCalcel);
            this.panel8.Controls.Add(this.btnTaskAdd);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 282);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(406, 37);
            this.panel8.TabIndex = 10;
            // 
            // btnTasksAdd
            // 
            this.btnTasksAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTasksAdd.Location = new System.Drawing.Point(294, 0);
            this.btnTasksAdd.Name = "btnTasksAdd";
            this.btnTasksAdd.Size = new System.Drawing.Size(110, 35);
            this.btnTasksAdd.TabIndex = 2;
            this.btnTasksAdd.Text = "一键添加";
            this.btnTasksAdd.UseVisualStyleBackColor = true;
            this.btnTasksAdd.Visible = false;
            this.btnTasksAdd.Click += new System.EventHandler(this.btnTasksAdd_Click);
            // 
            // btnCalcel
            // 
            this.btnCalcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCalcel.Location = new System.Drawing.Point(120, 0);
            this.btnCalcel.Name = "btnCalcel";
            this.btnCalcel.Size = new System.Drawing.Size(110, 35);
            this.btnCalcel.TabIndex = 1;
            this.btnCalcel.Text = "取消";
            this.btnCalcel.UseVisualStyleBackColor = true;
            this.btnCalcel.Click += new System.EventHandler(this.btnCalcel_Click);
            // 
            // btnTaskAdd
            // 
            this.btnTaskAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTaskAdd.Location = new System.Drawing.Point(0, 0);
            this.btnTaskAdd.Name = "btnTaskAdd";
            this.btnTaskAdd.Size = new System.Drawing.Size(120, 35);
            this.btnTaskAdd.TabIndex = 0;
            this.btnTaskAdd.Text = "添加任务";
            this.btnTaskAdd.UseVisualStyleBackColor = true;
            this.btnTaskAdd.Click += new System.EventHandler(this.btnTaskAdd_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 319);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panTaskType);
            this.Controls.Add(this.panAreaTaskType);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskForm";
            this.Text = " 模拟任务";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.panAreaTaskType.ResumeLayout(false);
            this.panTaskType.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Panel panAreaTaskType;
        private Label label2;
        private RadioButton rbtnCapAging;
        private RadioButton rbtnPreAging;
        private RadioButton rbtnCapTest;
        private Panel panTaskType;
        private Label label3;
        private ComboBox cbTaskType;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private ComboBox cbSourceStatoin;
        private Label label6;
        private ComboBox cbSourceGroup;
        private Panel panel2;
        private Panel panel3;
        private ComboBox cbTargetStatoin;
        private Label label10;
        private ComboBox cbTargetGroup;
        private Label label11;
        private Label label12;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label7;
        private ComboBox cbTaskBindAgv;
        private Panel panel7;
        private Panel panel8;
        private Button btnCalcel;
        private Button btnTaskAdd;
        private Label label8;
        private TextBox txtTasksCount;
        private Button btnTasksAdd;
        private Label lblCapTestSubCount;
        private TextBox txtCapTestSubCount;
        private CheckBox chbIsRobot;


    }

    public partial class TextPanel : Panel
    {
        private Label lblText = new Label();
        private TextBox txtContent = new TextBox();

        public TextPanel()
        {
            this.Size = new Size(160, 30);
            lblText.Dock = DockStyle.Left;
            txtContent.Dock = DockStyle.Fill;
            lblText.Size = new Size(80, 30);
            this.Controls.Add(txtContent);
            this.Controls.Add(lblText);
        }
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return txtContent.Enabled;
            }
            set
            {
                txtContent.Enabled = value;
            }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get
            {
                return txtContent.Text;
            }
            set
            {

                txtContent.Text = value;
            }
        }
    }
}