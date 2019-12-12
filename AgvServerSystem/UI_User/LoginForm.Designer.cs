namespace AgvServerSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lblLoginUser = new System.Windows.Forms.Label();
            this.lblLoginPwd = new System.Windows.Forms.Label();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.txtLoginPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLoginCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.AutoSize = true;
            this.lblLoginUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginUser.Location = new System.Drawing.Point(32, 41);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(49, 14);
            this.lblLoginUser.TabIndex = 0;
            this.lblLoginUser.Text = "Name：";
            // 
            // lblLoginPwd
            // 
            this.lblLoginPwd.AutoSize = true;
            this.lblLoginPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginPwd.Location = new System.Drawing.Point(32, 105);
            this.lblLoginPwd.Name = "lblLoginPwd";
            this.lblLoginPwd.Size = new System.Drawing.Size(77, 14);
            this.lblLoginPwd.TabIndex = 1;
            this.lblLoginPwd.Text = "Password：";
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginUser.Location = new System.Drawing.Point(101, 38);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.Size = new System.Drawing.Size(150, 23);
            this.txtLoginUser.TabIndex = 0;
            this.txtLoginUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoginUser_KeyPress);
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginPwd.Location = new System.Drawing.Point(101, 102);
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.PasswordChar = '*';
            this.txtLoginPwd.Size = new System.Drawing.Size(150, 23);
            this.txtLoginPwd.TabIndex = 1;
            this.txtLoginPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoginPwd_KeyPress);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(35, 162);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLoginCancel
            // 
            this.btnLoginCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoginCancel.Location = new System.Drawing.Point(176, 162);
            this.btnLoginCancel.Name = "btnLoginCancel";
            this.btnLoginCancel.Size = new System.Drawing.Size(75, 23);
            this.btnLoginCancel.TabIndex = 3;
            this.btnLoginCancel.Text = "Cancel";
            this.btnLoginCancel.UseVisualStyleBackColor = true;
            this.btnLoginCancel.Click += new System.EventHandler(this.btnLoginCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnLoginCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtLoginPwd);
            this.Controls.Add(this.txtLoginUser);
            this.Controls.Add(this.lblLoginPwd);
            this.Controls.Add(this.lblLoginUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginUser;
        private System.Windows.Forms.Label lblLoginPwd;
        private System.Windows.Forms.TextBox txtLoginUser;
        private System.Windows.Forms.TextBox txtLoginPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLoginCancel;
    }
}