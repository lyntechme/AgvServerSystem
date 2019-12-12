namespace AgvServerSystem
{
    partial class AddUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.txtAddUserPwd2 = new System.Windows.Forms.TextBox();
            this.lblAddUserPwd2 = new System.Windows.Forms.Label();
            this.btnAddUserCancel = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtAddUserPwd1 = new System.Windows.Forms.TextBox();
            this.txtAddUser = new System.Windows.Forms.TextBox();
            this.lblAddUserPwd1 = new System.Windows.Forms.Label();
            this.lblAddUser = new System.Windows.Forms.Label();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAddUserPwd2
            // 
            this.txtAddUserPwd2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddUserPwd2.Location = new System.Drawing.Point(109, 116);
            this.txtAddUserPwd2.MaxLength = 16;
            this.txtAddUserPwd2.Name = "txtAddUserPwd2";
            this.txtAddUserPwd2.PasswordChar = '*';
            this.txtAddUserPwd2.Size = new System.Drawing.Size(150, 23);
            this.txtAddUserPwd2.TabIndex = 3;
            // 
            // lblAddUserPwd2
            // 
            this.lblAddUserPwd2.AutoSize = true;
            this.lblAddUserPwd2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddUserPwd2.Location = new System.Drawing.Point(31, 119);
            this.lblAddUserPwd2.Name = "lblAddUserPwd2";
            this.lblAddUserPwd2.Size = new System.Drawing.Size(91, 14);
            this.lblAddUserPwd2.TabIndex = 18;
            this.lblAddUserPwd2.Text = "Enter again:";
            // 
            // btnAddUserCancel
            // 
            this.btnAddUserCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddUserCancel.Location = new System.Drawing.Point(184, 212);
            this.btnAddUserCancel.Name = "btnAddUserCancel";
            this.btnAddUserCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAddUserCancel.TabIndex = 6;
            this.btnAddUserCancel.Text = "Cancel";
            this.btnAddUserCancel.UseVisualStyleBackColor = true;
            this.btnAddUserCancel.Click += new System.EventHandler(this.btnAddUserCancel_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddUser.Location = new System.Drawing.Point(33, 212);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 5;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtAddUserPwd1
            // 
            this.txtAddUserPwd1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddUserPwd1.Location = new System.Drawing.Point(109, 71);
            this.txtAddUserPwd1.MaxLength = 16;
            this.txtAddUserPwd1.Name = "txtAddUserPwd1";
            this.txtAddUserPwd1.PasswordChar = '*';
            this.txtAddUserPwd1.Size = new System.Drawing.Size(150, 23);
            this.txtAddUserPwd1.TabIndex = 2;
            // 
            // txtAddUser
            // 
            this.txtAddUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddUser.Location = new System.Drawing.Point(109, 26);
            this.txtAddUser.Name = "txtAddUser";
            this.txtAddUser.Size = new System.Drawing.Size(150, 23);
            this.txtAddUser.TabIndex = 1;
            // 
            // lblAddUserPwd1
            // 
            this.lblAddUserPwd1.AutoSize = true;
            this.lblAddUserPwd1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddUserPwd1.Location = new System.Drawing.Point(31, 74);
            this.lblAddUserPwd1.Name = "lblAddUserPwd1";
            this.lblAddUserPwd1.Size = new System.Drawing.Size(77, 14);
            this.lblAddUserPwd1.TabIndex = 14;
            this.lblAddUserPwd1.Text = "Password：";
            // 
            // lblAddUser
            // 
            this.lblAddUser.AutoSize = true;
            this.lblAddUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddUser.Location = new System.Drawing.Point(31, 29);
            this.lblAddUser.Name = "lblAddUser";
            this.lblAddUser.Size = new System.Drawing.Size(49, 14);
            this.lblAddUser.TabIndex = 13;
            this.lblAddUser.Text = "Name：";
            // 
            // cbLevel
            // 
            this.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Items.AddRange(new object[] {
            "Normal",
            "Administrator"});
            this.cbLevel.Location = new System.Drawing.Point(138, 161);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(121, 22);
            this.cbLevel.TabIndex = 4;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLevel.Location = new System.Drawing.Point(31, 164);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(56, 14);
            this.lblLevel.TabIndex = 19;
            this.lblLevel.Text = "Level：";
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.cbLevel);
            this.Controls.Add(this.txtAddUserPwd2);
            this.Controls.Add(this.lblAddUserPwd2);
            this.Controls.Add(this.btnAddUserCancel);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtAddUserPwd1);
            this.Controls.Add(this.txtAddUser);
            this.Controls.Add(this.lblAddUserPwd1);
            this.Controls.Add(this.lblAddUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add user";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddUserPwd2;
        private System.Windows.Forms.Label lblAddUserPwd2;
        private System.Windows.Forms.Button btnAddUserCancel;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtAddUserPwd1;
        private System.Windows.Forms.TextBox txtAddUser;
        private System.Windows.Forms.Label lblAddUserPwd1;
        private System.Windows.Forms.Label lblAddUser;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.Label lblLevel;
    }
}