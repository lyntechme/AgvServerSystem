namespace AgvServerSystem
{
    partial class PasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            this.btnPwdCancel = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtPwdNew1 = new System.Windows.Forms.TextBox();
            this.txtPwdOld = new System.Windows.Forms.TextBox();
            this.lblPwdNew1 = new System.Windows.Forms.Label();
            this.lblPwdOld = new System.Windows.Forms.Label();
            this.txtPwdNew2 = new System.Windows.Forms.TextBox();
            this.lblPwdNew2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPwdCancel
            // 
            this.btnPwdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPwdCancel.Location = new System.Drawing.Point(184, 203);
            this.btnPwdCancel.Name = "btnPwdCancel";
            this.btnPwdCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPwdCancel.TabIndex = 5;
            this.btnPwdCancel.Text = "Cancel";
            this.btnPwdCancel.UseVisualStyleBackColor = true;
            this.btnPwdCancel.Click += new System.EventHandler(this.btnPwdCancel_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangePassword.Location = new System.Drawing.Point(33, 203);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(75, 23);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "Modify";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtPwdNew1
            // 
            this.txtPwdNew1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwdNew1.Location = new System.Drawing.Point(109, 89);
            this.txtPwdNew1.MaxLength = 16;
            this.txtPwdNew1.Name = "txtPwdNew1";
            this.txtPwdNew1.PasswordChar = '*';
            this.txtPwdNew1.Size = new System.Drawing.Size(150, 23);
            this.txtPwdNew1.TabIndex = 2;
            // 
            // txtPwdOld
            // 
            this.txtPwdOld.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwdOld.Location = new System.Drawing.Point(109, 32);
            this.txtPwdOld.Name = "txtPwdOld";
            this.txtPwdOld.PasswordChar = '*';
            this.txtPwdOld.Size = new System.Drawing.Size(150, 23);
            this.txtPwdOld.TabIndex = 1;
            // 
            // lblPwdNew1
            // 
            this.lblPwdNew1.AutoSize = true;
            this.lblPwdNew1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPwdNew1.Location = new System.Drawing.Point(26, 92);
            this.lblPwdNew1.Name = "lblPwdNew1";
            this.lblPwdNew1.Size = new System.Drawing.Size(70, 14);
            this.lblPwdNew1.TabIndex = 6;
            this.lblPwdNew1.Text = "New pwd：";
            // 
            // lblPwdOld
            // 
            this.lblPwdOld.AutoSize = true;
            this.lblPwdOld.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPwdOld.Location = new System.Drawing.Point(26, 35);
            this.lblPwdOld.Name = "lblPwdOld";
            this.lblPwdOld.Size = new System.Drawing.Size(70, 14);
            this.lblPwdOld.TabIndex = 5;
            this.lblPwdOld.Text = "Old pwd：";
            // 
            // txtPwdNew2
            // 
            this.txtPwdNew2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwdNew2.Location = new System.Drawing.Point(109, 146);
            this.txtPwdNew2.MaxLength = 16;
            this.txtPwdNew2.Name = "txtPwdNew2";
            this.txtPwdNew2.PasswordChar = '*';
            this.txtPwdNew2.Size = new System.Drawing.Size(150, 23);
            this.txtPwdNew2.TabIndex = 3;
            // 
            // lblPwdNew2
            // 
            this.lblPwdNew2.AutoSize = true;
            this.lblPwdNew2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPwdNew2.Location = new System.Drawing.Point(12, 149);
            this.lblPwdNew2.Name = "lblPwdNew2";
            this.lblPwdNew2.Size = new System.Drawing.Size(84, 14);
            this.lblPwdNew2.TabIndex = 10;
            this.lblPwdNew2.Text = "Second pwd:";
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtPwdNew2);
            this.Controls.Add(this.lblPwdNew2);
            this.Controls.Add(this.btnPwdCancel);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtPwdNew1);
            this.Controls.Add(this.txtPwdOld);
            this.Controls.Add(this.lblPwdNew1);
            this.Controls.Add(this.lblPwdOld);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPwdCancel;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtPwdNew1;
        private System.Windows.Forms.TextBox txtPwdOld;
        private System.Windows.Forms.Label lblPwdNew1;
        private System.Windows.Forms.Label lblPwdOld;
        private System.Windows.Forms.TextBox txtPwdNew2;
        private System.Windows.Forms.Label lblPwdNew2;
    }
}