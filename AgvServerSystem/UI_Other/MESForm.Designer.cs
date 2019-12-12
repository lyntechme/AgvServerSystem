namespace AgvServerSystem
{
    partial class MESForm
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
            this.tabMes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRec = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtUpdateTaskState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtUpdateAgvState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRecTask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnUpdateTaskIndex = new System.Windows.Forms.Button();
            this.btnRecTaskIndex = new System.Windows.Forms.Button();
            this.txtCurrentTaskIndex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabMes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMes
            // 
            this.tabMes.Controls.Add(this.tabPage1);
            this.tabMes.Controls.Add(this.tabPage2);
            this.tabMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMes.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMes.Location = new System.Drawing.Point(0, 0);
            this.tabMes.Name = "tabMes";
            this.tabMes.SelectedIndex = 0;
            this.tabMes.Size = new System.Drawing.Size(284, 281);
            this.tabMes.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "更新信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 240);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnUpdate);
            this.panel8.Controls.Add(this.btnRec);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 192);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(270, 48);
            this.panel8.TabIndex = 6;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Location = new System.Drawing.Point(123, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 48);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRec
            // 
            this.btnRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRec.Location = new System.Drawing.Point(0, 0);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(123, 48);
            this.btnRec.TabIndex = 0;
            this.btnRec.Text = "获取";
            this.btnRec.UseVisualStyleBackColor = true;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 160);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(270, 32);
            this.panel7.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 128);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(270, 32);
            this.panel6.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "时间单位：秒(s)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 96);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(270, 32);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtUpdateTaskState);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(270, 32);
            this.panel4.TabIndex = 2;
            // 
            // txtUpdateTaskState
            // 
            this.txtUpdateTaskState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUpdateTaskState.Location = new System.Drawing.Point(101, 0);
            this.txtUpdateTaskState.Multiline = true;
            this.txtUpdateTaskState.Name = "txtUpdateTaskState";
            this.txtUpdateTaskState.Size = new System.Drawing.Size(169, 32);
            this.txtUpdateTaskState.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "任务状态更新时间";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtUpdateAgvState);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 32);
            this.panel3.TabIndex = 1;
            // 
            // txtUpdateAgvState
            // 
            this.txtUpdateAgvState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUpdateAgvState.Location = new System.Drawing.Point(101, 0);
            this.txtUpdateAgvState.Multiline = true;
            this.txtUpdateAgvState.Name = "txtUpdateAgvState";
            this.txtUpdateAgvState.Size = new System.Drawing.Size(169, 32);
            this.txtUpdateAgvState.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "AGV状态更新时间";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtRecTask);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 32);
            this.panel2.TabIndex = 0;
            // 
            // txtRecTask
            // 
            this.txtRecTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecTask.Location = new System.Drawing.Point(101, 0);
            this.txtRecTask.Multiline = true;
            this.txtRecTask.Name = "txtRecTask";
            this.txtRecTask.Size = new System.Drawing.Size(169, 32);
            this.txtRecTask.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务获取刷新时间";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel9);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "任务信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel16);
            this.panel9.Controls.Add(this.panel15);
            this.panel9.Controls.Add(this.panel14);
            this.panel9.Controls.Add(this.panel13);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(270, 240);
            this.panel9.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(270, 32);
            this.panel10.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 32);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(270, 32);
            this.panel11.TabIndex = 4;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txtCurrentTaskIndex);
            this.panel12.Controls.Add(this.label5);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 64);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(270, 32);
            this.panel12.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 96);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(270, 32);
            this.panel13.TabIndex = 6;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 128);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(270, 32);
            this.panel14.TabIndex = 7;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 160);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(270, 32);
            this.panel15.TabIndex = 8;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btnUpdateTaskIndex);
            this.panel16.Controls.Add(this.btnRecTaskIndex);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(0, 192);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(270, 48);
            this.panel16.TabIndex = 9;
            // 
            // btnUpdateTaskIndex
            // 
            this.btnUpdateTaskIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateTaskIndex.Location = new System.Drawing.Point(123, 0);
            this.btnUpdateTaskIndex.Name = "btnUpdateTaskIndex";
            this.btnUpdateTaskIndex.Size = new System.Drawing.Size(147, 48);
            this.btnUpdateTaskIndex.TabIndex = 1;
            this.btnUpdateTaskIndex.Text = "更改";
            this.btnUpdateTaskIndex.UseVisualStyleBackColor = true;
            this.btnUpdateTaskIndex.Click += new System.EventHandler(this.btnUpdateTaskIndex_Click);
            // 
            // btnRecTaskIndex
            // 
            this.btnRecTaskIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRecTaskIndex.Location = new System.Drawing.Point(0, 0);
            this.btnRecTaskIndex.Name = "btnRecTaskIndex";
            this.btnRecTaskIndex.Size = new System.Drawing.Size(123, 48);
            this.btnRecTaskIndex.TabIndex = 0;
            this.btnRecTaskIndex.Text = "获取";
            this.btnRecTaskIndex.UseVisualStyleBackColor = true;
            this.btnRecTaskIndex.Click += new System.EventHandler(this.btnRecTaskIndex_Click);
            // 
            // txtCurrentTaskIndex
            // 
            this.txtCurrentTaskIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurrentTaskIndex.Location = new System.Drawing.Point(101, 0);
            this.txtCurrentTaskIndex.Multiline = true;
            this.txtCurrentTaskIndex.Name = "txtCurrentTaskIndex";
            this.txtCurrentTaskIndex.Size = new System.Drawing.Size(169, 32);
            this.txtCurrentTaskIndex.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 32);
            this.label5.TabIndex = 2;
            this.label5.Text = "当前任务索引号";
            // 
            // MESForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.tabMes);
            this.Name = "MESForm";
            this.Text = "MES通讯参数设定";
            this.Load += new System.EventHandler(this.MESForm_Load);
            this.tabMes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtRecTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtUpdateTaskState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtUpdateAgvState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnUpdateTaskIndex;
        private System.Windows.Forms.Button btnRecTaskIndex;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtCurrentTaskIndex;
        private System.Windows.Forms.Label label5;
    }
}