namespace AgvServerSystem
{
    partial class StationTimeForm
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
            this.btnStationTimeSet = new System.Windows.Forms.Button();
            this.lblStationTimeSet = new System.Windows.Forms.Label();
            this.txtStationTime = new System.Windows.Forms.TextBox();
            this.lblStationSeconds = new System.Windows.Forms.Label();
            this.btnStationTimeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStationTimeSet
            // 
            this.btnStationTimeSet.Location = new System.Drawing.Point(26, 110);
            this.btnStationTimeSet.Name = "btnStationTimeSet";
            this.btnStationTimeSet.Size = new System.Drawing.Size(75, 23);
            this.btnStationTimeSet.TabIndex = 0;
            this.btnStationTimeSet.Text = "确定";
            this.btnStationTimeSet.UseVisualStyleBackColor = true;
            this.btnStationTimeSet.Click += new System.EventHandler(this.btnStationTimeSet_Click);
            // 
            // lblStationTimeSet
            // 
            this.lblStationTimeSet.AutoSize = true;
            this.lblStationTimeSet.Location = new System.Drawing.Point(24, 58);
            this.lblStationTimeSet.Name = "lblStationTimeSet";
            this.lblStationTimeSet.Size = new System.Drawing.Size(59, 12);
            this.lblStationTimeSet.TabIndex = 1;
            this.lblStationTimeSet.Text = "时间长度:";
            // 
            // txtStationTime
            // 
            this.txtStationTime.Location = new System.Drawing.Point(100, 55);
            this.txtStationTime.Name = "txtStationTime";
            this.txtStationTime.Size = new System.Drawing.Size(100, 21);
            this.txtStationTime.TabIndex = 2;
            // 
            // lblStationSeconds
            // 
            this.lblStationSeconds.AutoSize = true;
            this.lblStationSeconds.Location = new System.Drawing.Point(219, 58);
            this.lblStationSeconds.Name = "lblStationSeconds";
            this.lblStationSeconds.Size = new System.Drawing.Size(17, 12);
            this.lblStationSeconds.TabIndex = 3;
            this.lblStationSeconds.Text = "秒";
            // 
            // btnStationTimeCancel
            // 
            this.btnStationTimeCancel.Location = new System.Drawing.Point(139, 110);
            this.btnStationTimeCancel.Name = "btnStationTimeCancel";
            this.btnStationTimeCancel.Size = new System.Drawing.Size(75, 23);
            this.btnStationTimeCancel.TabIndex = 4;
            this.btnStationTimeCancel.Text = "取消";
            this.btnStationTimeCancel.UseVisualStyleBackColor = true;
            this.btnStationTimeCancel.Click += new System.EventHandler(this.btnStationTimeCancel_Click);
            // 
            // StationTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.Controls.Add(this.btnStationTimeCancel);
            this.Controls.Add(this.lblStationSeconds);
            this.Controls.Add(this.txtStationTime);
            this.Controls.Add(this.lblStationTimeSet);
            this.Controls.Add(this.btnStationTimeSet);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StationTimeForm";
            this.Text = "点位定位时间长度";
            this.Load += new System.EventHandler(this.StationTimeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStationTimeSet;
        private System.Windows.Forms.Label lblStationTimeSet;
        private System.Windows.Forms.TextBox txtStationTime;
        private System.Windows.Forms.Label lblStationSeconds;
        private System.Windows.Forms.Button btnStationTimeCancel;
    }
}