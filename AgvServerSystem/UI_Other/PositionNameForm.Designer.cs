namespace AgvServerSystem
{
    partial class PositionNameForm
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
            this.dgvPosition = new System.Windows.Forms.DataGridView();
            this.btnPositionCancel = new System.Windows.Forms.Button();
            this.btnPositionSet = new System.Windows.Forms.Button();
            this.cPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPosition
            // 
            this.dgvPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPositionName,
            this.cRfid});
            this.dgvPosition.Location = new System.Drawing.Point(12, 12);
            this.dgvPosition.Name = "dgvPosition";
            this.dgvPosition.RowTemplate.Height = 23;
            this.dgvPosition.Size = new System.Drawing.Size(548, 289);
            this.dgvPosition.TabIndex = 4;
            // 
            // btnPositionCancel
            // 
            this.btnPositionCancel.Location = new System.Drawing.Point(183, 329);
            this.btnPositionCancel.Name = "btnPositionCancel";
            this.btnPositionCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPositionCancel.TabIndex = 6;
            this.btnPositionCancel.Text = "Cancel";
            this.btnPositionCancel.UseVisualStyleBackColor = true;
            this.btnPositionCancel.Click += new System.EventHandler(this.btnPositionCancel_Click);
            // 
            // btnPositionSet
            // 
            this.btnPositionSet.Location = new System.Drawing.Point(38, 329);
            this.btnPositionSet.Name = "btnPositionSet";
            this.btnPositionSet.Size = new System.Drawing.Size(75, 23);
            this.btnPositionSet.TabIndex = 5;
            this.btnPositionSet.Text = "Set";
            this.btnPositionSet.UseVisualStyleBackColor = true;
            this.btnPositionSet.Click += new System.EventHandler(this.btnPositionSet_Click);
            // 
            // cPositionName
            // 
            this.cPositionName.HeaderText = "Name";
            this.cPositionName.Name = "cPositionName";
            // 
            // cRfid
            // 
            this.cRfid.HeaderText = "Rfids";
            this.cRfid.Name = "cRfid";
            this.cRfid.Width = 400;
            // 
            // PositionNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 364);
            this.Controls.Add(this.btnPositionCancel);
            this.Controls.Add(this.btnPositionSet);
            this.Controls.Add(this.dgvPosition);
            this.Name = "PositionNameForm";
            this.Text = "Position Name";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPosition;
        private System.Windows.Forms.Button btnPositionCancel;
        private System.Windows.Forms.Button btnPositionSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRfid;
    }
}