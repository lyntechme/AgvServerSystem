namespace AgvServerSystem
{
    partial class AgvShowForm
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
            this.btnAgvShowConfirm = new System.Windows.Forms.Button();
            this.btnAgvShowCancel = new System.Windows.Forms.Button();
            this.tlpAgvShowCheck = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // btnAgvShowConfirm
            // 
            this.btnAgvShowConfirm.Location = new System.Drawing.Point(44, 214);
            this.btnAgvShowConfirm.Name = "btnAgvShowConfirm";
            this.btnAgvShowConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnAgvShowConfirm.TabIndex = 0;
            this.btnAgvShowConfirm.Text = "OK";
            this.btnAgvShowConfirm.UseVisualStyleBackColor = true;
            this.btnAgvShowConfirm.Click += new System.EventHandler(this.btnAgvShowConfirm_Click);
            // 
            // btnAgvShowCancel
            // 
            this.btnAgvShowCancel.Location = new System.Drawing.Point(174, 214);
            this.btnAgvShowCancel.Name = "btnAgvShowCancel";
            this.btnAgvShowCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAgvShowCancel.TabIndex = 1;
            this.btnAgvShowCancel.Text = "Cancel";
            this.btnAgvShowCancel.UseVisualStyleBackColor = true;
            this.btnAgvShowCancel.Click += new System.EventHandler(this.btnAgvShowCancel_Click);
            // 
            // tlpAgvShowCheck
            // 
            this.tlpAgvShowCheck.AutoSize = true;
            this.tlpAgvShowCheck.BackColor = System.Drawing.Color.White;
            this.tlpAgvShowCheck.ColumnCount = 2;
            this.tlpAgvShowCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAgvShowCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAgvShowCheck.Location = new System.Drawing.Point(27, 36);
            this.tlpAgvShowCheck.Name = "tlpAgvShowCheck";
            this.tlpAgvShowCheck.RowCount = 2;
            this.tlpAgvShowCheck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAgvShowCheck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAgvShowCheck.Size = new System.Drawing.Size(200, 100);
            this.tlpAgvShowCheck.TabIndex = 2;
            // 
            // AgvShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tlpAgvShowCheck);
            this.Controls.Add(this.btnAgvShowCancel);
            this.Controls.Add(this.btnAgvShowConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AgvShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agv visible";
            this.Load += new System.EventHandler(this.AgvShowForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgvShowConfirm;
        private System.Windows.Forms.Button btnAgvShowCancel;
        private System.Windows.Forms.TableLayoutPanel tlpAgvShowCheck;
    }
}