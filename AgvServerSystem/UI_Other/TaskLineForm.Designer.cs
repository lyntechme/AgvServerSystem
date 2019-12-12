namespace AgvServerSystem
{
    partial class TaskLineForm
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
            this.btnLineChange = new System.Windows.Forms.Button();
            this.btnLineCancel = new System.Windows.Forms.Button();
            this.dgvLine = new System.Windows.Forms.DataGridView();
            this.cLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLineChange
            // 
            this.btnLineChange.Location = new System.Drawing.Point(47, 269);
            this.btnLineChange.Name = "btnLineChange";
            this.btnLineChange.Size = new System.Drawing.Size(75, 23);
            this.btnLineChange.TabIndex = 1;
            this.btnLineChange.Text = "修改";
            this.btnLineChange.UseVisualStyleBackColor = true;
            this.btnLineChange.Click += new System.EventHandler(this.btnLineChange_Click);
            // 
            // btnLineCancel
            // 
            this.btnLineCancel.Location = new System.Drawing.Point(192, 269);
            this.btnLineCancel.Name = "btnLineCancel";
            this.btnLineCancel.Size = new System.Drawing.Size(75, 23);
            this.btnLineCancel.TabIndex = 2;
            this.btnLineCancel.Text = "取消";
            this.btnLineCancel.UseVisualStyleBackColor = true;
            this.btnLineCancel.Click += new System.EventHandler(this.btnLineCancel_Click);
            // 
            // dgvLine
            // 
            this.dgvLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cLineNo,
            this.cLineName});
            this.dgvLine.Location = new System.Drawing.Point(22, 12);
            this.dgvLine.Name = "dgvLine";
            this.dgvLine.RowTemplate.Height = 23;
            this.dgvLine.Size = new System.Drawing.Size(347, 232);
            this.dgvLine.TabIndex = 3;
            // 
            // cLineNo
            // 
            this.cLineNo.HeaderText = "线路编号";
            this.cLineNo.Name = "cLineNo";
            // 
            // cLineName
            // 
            this.cLineName.HeaderText = "线路名称";
            this.cLineName.Name = "cLineName";
            this.cLineName.Width = 200;
            // 
            // TaskLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 294);
            this.Controls.Add(this.dgvLine);
            this.Controls.Add(this.btnLineCancel);
            this.Controls.Add(this.btnLineChange);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskLineForm";
            this.Text = "设定路线对应名称";
            this.Load += new System.EventHandler(this.TaskLineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLineChange;
        private System.Windows.Forms.Button btnLineCancel;
        private System.Windows.Forms.DataGridView dgvLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLineName;
    }
}