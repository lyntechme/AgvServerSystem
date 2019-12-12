namespace AgvServerSystem
{
    partial class ManualQRCode
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
            this.btnQRCodeOK = new System.Windows.Forms.Button();
            this.btnQRCodeCancel = new System.Windows.Forms.Button();
            this.txtQrCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAgvNo = new System.Windows.Forms.Label();
            this.lblTaskId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "二维码：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQRCodeOK
            // 
            this.btnQRCodeOK.Location = new System.Drawing.Point(30, 122);
            this.btnQRCodeOK.Name = "btnQRCodeOK";
            this.btnQRCodeOK.Size = new System.Drawing.Size(75, 23);
            this.btnQRCodeOK.TabIndex = 1;
            this.btnQRCodeOK.Text = "确定";
            this.btnQRCodeOK.UseVisualStyleBackColor = true;
            this.btnQRCodeOK.Click += new System.EventHandler(this.btnQRCodeOK_Click);
            // 
            // btnQRCodeCancel
            // 
            this.btnQRCodeCancel.Location = new System.Drawing.Point(172, 122);
            this.btnQRCodeCancel.Name = "btnQRCodeCancel";
            this.btnQRCodeCancel.Size = new System.Drawing.Size(75, 23);
            this.btnQRCodeCancel.TabIndex = 2;
            this.btnQRCodeCancel.Text = "取消";
            this.btnQRCodeCancel.UseVisualStyleBackColor = true;
            this.btnQRCodeCancel.Click += new System.EventHandler(this.btnQRCodeCancel_Click);
            // 
            // txtQrCode
            // 
            this.txtQrCode.Location = new System.Drawing.Point(127, 80);
            this.txtQrCode.Multiline = true;
            this.txtQrCode.Name = "txtQrCode";
            this.txtQrCode.Size = new System.Drawing.Size(131, 28);
            this.txtQrCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "任务ID：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(28, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Agv编号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAgvNo
            // 
            this.lblAgvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAgvNo.Location = new System.Drawing.Point(127, 6);
            this.lblAgvNo.Name = "lblAgvNo";
            this.lblAgvNo.Size = new System.Drawing.Size(131, 28);
            this.lblAgvNo.TabIndex = 6;
            this.lblAgvNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTaskId
            // 
            this.lblTaskId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTaskId.Location = new System.Drawing.Point(127, 43);
            this.lblTaskId.Name = "lblTaskId";
            this.lblTaskId.Size = new System.Drawing.Size(131, 28);
            this.lblTaskId.TabIndex = 7;
            this.lblTaskId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManualQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 189);
            this.Controls.Add(this.lblTaskId);
            this.Controls.Add(this.lblAgvNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQrCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQRCodeCancel);
            this.Controls.Add(this.btnQRCodeOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualQRCode";
            this.Text = "手动添加二维码";
            this.Load += new System.EventHandler(this.ManualQRCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQRCodeOK;
        private System.Windows.Forms.Button btnQRCodeCancel;
        private System.Windows.Forms.TextBox txtQrCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAgvNo;
        private System.Windows.Forms.Label lblTaskId;
    }
}