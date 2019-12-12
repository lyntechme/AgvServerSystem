namespace AgvServerSystem
{
    partial class StationSetForm
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
            this.splitPanStation = new System.Windows.Forms.SplitContainer();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.txtStationRfid = new System.Windows.Forms.TextBox();
            this.cbbStationType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStationPort = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStationHight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStationWidth = new System.Windows.Forms.TextBox();
            this.txtStationIp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtStationLabelEnbale = new System.Windows.Forms.TextBox();
            this.cbbStationId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanStation)).BeginInit();
            this.splitPanStation.Panel1.SuspendLayout();
            this.splitPanStation.Panel2.SuspendLayout();
            this.splitPanStation.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitPanStation
            // 
            this.splitPanStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanStation.Location = new System.Drawing.Point(0, 0);
            this.splitPanStation.Name = "splitPanStation";
            this.splitPanStation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitPanStation.Panel1
            // 
            this.splitPanStation.Panel1.Controls.Add(this.cbbStationId);
            this.splitPanStation.Panel1.Controls.Add(this.txtStationLabelEnbale);
            this.splitPanStation.Panel1.Controls.Add(this.label15);
            this.splitPanStation.Panel1.Controls.Add(this.txtStationName);
            this.splitPanStation.Panel1.Controls.Add(this.txtStationRfid);
            this.splitPanStation.Panel1.Controls.Add(this.cbbStationType);
            this.splitPanStation.Panel1.Controls.Add(this.label9);
            this.splitPanStation.Panel1.Controls.Add(this.label14);
            this.splitPanStation.Panel1.Controls.Add(this.label13);
            this.splitPanStation.Panel1.Controls.Add(this.label12);
            this.splitPanStation.Panel1.Controls.Add(this.label8);
            this.splitPanStation.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitPanStation_Panel1_Paint);
            // 
            // splitPanStation.Panel2
            // 
            this.splitPanStation.Panel2.Controls.Add(this.txtStationPort);
            this.splitPanStation.Panel2.Controls.Add(this.label11);
            this.splitPanStation.Panel2.Controls.Add(this.txtStationHight);
            this.splitPanStation.Panel2.Controls.Add(this.label10);
            this.splitPanStation.Panel2.Controls.Add(this.txtStationWidth);
            this.splitPanStation.Panel2.Controls.Add(this.txtStationIp);
            this.splitPanStation.Panel2.Controls.Add(this.label7);
            this.splitPanStation.Panel2.Controls.Add(this.label4);
            this.splitPanStation.Panel2.Controls.Add(this.label6);
            this.splitPanStation.Panel2.Controls.Add(this.label1);
            this.splitPanStation.Panel2.Controls.Add(this.label2);
            this.splitPanStation.Panel2.Controls.Add(this.label5);
            this.splitPanStation.Panel2.Controls.Add(this.label3);
            this.splitPanStation.Panel2.Controls.Add(this.txtLeft);
            this.splitPanStation.Panel2.Controls.Add(this.txtTop);
            this.splitPanStation.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitPanStation_Panel2_Paint);
            this.splitPanStation.Size = new System.Drawing.Size(510, 427);
            this.splitPanStation.SplitterDistance = 193;
            this.splitPanStation.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(274, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "Enable";
            this.label15.Visible = false;
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(102, 90);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(126, 21);
            this.txtStationName.TabIndex = 40;
            this.txtStationName.Text = "Default";
            // 
            // txtStationRfid
            // 
            this.txtStationRfid.Location = new System.Drawing.Point(102, 132);
            this.txtStationRfid.Name = "txtStationRfid";
            this.txtStationRfid.ReadOnly = true;
            this.txtStationRfid.Size = new System.Drawing.Size(126, 21);
            this.txtStationRfid.TabIndex = 35;
            // 
            // cbbStationType
            // 
            this.cbbStationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStationType.FormattingEnabled = true;
            this.cbbStationType.Location = new System.Drawing.Point(335, 47);
            this.cbbStationType.Name = "cbbStationType";
            this.cbbStationType.Size = new System.Drawing.Size(121, 20);
            this.cbbStationType.TabIndex = 42;
            this.cbbStationType.SelectedIndexChanged += new System.EventHandler(this.cbbStationType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "Rfid";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(286, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 41;
            this.label14.Text = "Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "Base Information";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "Id";
            // 
            // txtStationPort
            // 
            this.txtStationPort.Location = new System.Drawing.Point(88, 101);
            this.txtStationPort.Name = "txtStationPort";
            this.txtStationPort.Size = new System.Drawing.Size(126, 21);
            this.txtStationPort.TabIndex = 38;
            this.txtStationPort.Text = "9600";
            this.txtStationPort.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 37;
            this.label11.Text = "Port";
            this.label11.Visible = false;
            // 
            // txtStationHight
            // 
            this.txtStationHight.Location = new System.Drawing.Point(453, 101);
            this.txtStationHight.Name = "txtStationHight";
            this.txtStationHight.Size = new System.Drawing.Size(52, 21);
            this.txtStationHight.TabIndex = 29;
            this.txtStationHight.Text = "3000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "Connect/Layout";
            // 
            // txtStationWidth
            // 
            this.txtStationWidth.Location = new System.Drawing.Point(345, 101);
            this.txtStationWidth.Name = "txtStationWidth";
            this.txtStationWidth.Size = new System.Drawing.Size(52, 21);
            this.txtStationWidth.TabIndex = 28;
            this.txtStationWidth.Text = "1000";
            // 
            // txtStationIp
            // 
            this.txtStationIp.Location = new System.Drawing.Point(88, 52);
            this.txtStationIp.Name = "txtStationIp";
            this.txtStationIp.Size = new System.Drawing.Size(126, 21);
            this.txtStationIp.TabIndex = 31;
            this.txtStationIp.Text = "192.168.1.";
            this.txtStationIp.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(408, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "IP";
            this.label4.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "Width";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Left";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "Size：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Top";
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(345, 52);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(52, 21);
            this.txtLeft.TabIndex = 23;
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(453, 52);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(52, 21);
            this.txtTop.TabIndex = 24;
            // 
            // txtStationLabelEnbale
            // 
            this.txtStationLabelEnbale.Location = new System.Drawing.Point(335, 87);
            this.txtStationLabelEnbale.Name = "txtStationLabelEnbale";
            this.txtStationLabelEnbale.ReadOnly = true;
            this.txtStationLabelEnbale.Size = new System.Drawing.Size(126, 21);
            this.txtStationLabelEnbale.TabIndex = 44;
            // 
            // cbbStationId
            // 
            this.cbbStationId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStationId.FormattingEnabled = true;
            this.cbbStationId.Location = new System.Drawing.Point(107, 44);
            this.cbbStationId.Name = "cbbStationId";
            this.cbbStationId.Size = new System.Drawing.Size(121, 20);
            this.cbbStationId.TabIndex = 45;
            this.cbbStationId.SelectedIndexChanged += new System.EventHandler(this.cbbStationId_SelectedIndexChanged);
            // 
            // StationSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 427);
            this.Controls.Add(this.splitPanStation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StationSetForm";
            this.Text = "Station Set";
            this.Load += new System.EventHandler(this.StationSetForm_Load);
            this.splitPanStation.Panel1.ResumeLayout(false);
            this.splitPanStation.Panel1.PerformLayout();
            this.splitPanStation.Panel2.ResumeLayout(false);
            this.splitPanStation.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanStation)).EndInit();
            this.splitPanStation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitPanStation;
        private System.Windows.Forms.TextBox txtStationRfid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStationIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStationHight;
        private System.Windows.Forms.TextBox txtStationWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStationPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbbStationType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStationLabelEnbale;
        private System.Windows.Forms.ComboBox cbbStationId;
    }
}