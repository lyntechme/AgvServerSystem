namespace AgvServerSystem
{
    partial class ManageUserInfoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUserInfoForm));
            this.btnObainUserInfo = new System.Windows.Forms.Button();
            this.dgvUserInfo = new System.Windows.Forms.DataGridView();
            this.ctxtUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtUserLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCbUserDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cCbUserChange = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnObainUserInfo
            // 
            this.btnObainUserInfo.Location = new System.Drawing.Point(12, 12);
            this.btnObainUserInfo.Name = "btnObainUserInfo";
            this.btnObainUserInfo.Size = new System.Drawing.Size(176, 27);
            this.btnObainUserInfo.TabIndex = 0;
            this.btnObainUserInfo.Text = "获取用户信息";
            this.btnObainUserInfo.UseVisualStyleBackColor = true;
            this.btnObainUserInfo.Click += new System.EventHandler(this.btnObainUserInfo_Click);
            // 
            // dgvUserInfo
            // 
            this.dgvUserInfo.AllowUserToAddRows = false;
            this.dgvUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtUserId,
            this.ctxtUserName,
            this.ctxtUserPassword,
            this.ctxtUserLevel,
            this.cCbUserDelete,
            this.cCbUserChange});
            this.dgvUserInfo.Location = new System.Drawing.Point(10, 57);
            this.dgvUserInfo.Name = "dgvUserInfo";
            this.dgvUserInfo.RowTemplate.Height = 23;
            this.dgvUserInfo.Size = new System.Drawing.Size(638, 303);
            this.dgvUserInfo.TabIndex = 2;
            this.dgvUserInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserInfo_CellClick);
            // 
            // ctxtUserId
            // 
            this.ctxtUserId.HeaderText = "用户ID";
            this.ctxtUserId.Name = "ctxtUserId";
            this.ctxtUserId.ReadOnly = true;
            // 
            // ctxtUserName
            // 
            this.ctxtUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctxtUserName.DefaultCellStyle = dataGridViewCellStyle1;
            this.ctxtUserName.HeaderText = "用户名";
            this.ctxtUserName.MinimumWidth = 100;
            this.ctxtUserName.Name = "ctxtUserName";
            // 
            // ctxtUserPassword
            // 
            this.ctxtUserPassword.HeaderText = "密码";
            this.ctxtUserPassword.MaxInputLength = 16;
            this.ctxtUserPassword.Name = "ctxtUserPassword";
            this.ctxtUserPassword.Width = 150;
            // 
            // ctxtUserLevel
            // 
            this.ctxtUserLevel.HeaderText = "用户等级";
            this.ctxtUserLevel.MaxInputLength = 1;
            this.ctxtUserLevel.Name = "ctxtUserLevel";
            // 
            // cCbUserDelete
            // 
            this.cCbUserDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbUserDelete.HeaderText = "操作";
            this.cCbUserDelete.Name = "cCbUserDelete";
            this.cCbUserDelete.Text = "删除";
            this.cCbUserDelete.UseColumnTextForButtonValue = true;
            this.cCbUserDelete.Width = 60;
            // 
            // cCbUserChange
            // 
            this.cCbUserChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbUserChange.HeaderText = "更新";
            this.cCbUserChange.Name = "cCbUserChange";
            this.cCbUserChange.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cCbUserChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cCbUserChange.Text = "修改";
            this.cCbUserChange.UseColumnTextForButtonValue = true;
            this.cCbUserChange.Width = 60;
            // 
            // ManageUserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 381);
            this.Controls.Add(this.dgvUserInfo);
            this.Controls.Add(this.btnObainUserInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageUserInfoForm";
            this.Text = "管理用户信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnObainUserInfo;
        private System.Windows.Forms.DataGridView dgvUserInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUserPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtUserLevel;
        private System.Windows.Forms.DataGridViewButtonColumn cCbUserDelete;
        private System.Windows.Forms.DataGridViewButtonColumn cCbUserChange;
    }
}