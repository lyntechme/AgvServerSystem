namespace AgvServerSystem
{
    partial class AgvModelSetForm
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
            this.btnAgvModelSet = new System.Windows.Forms.Button();
            this.txtAgvModelSet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAgvModelSet
            // 
            this.btnAgvModelSet.Location = new System.Drawing.Point(212, 54);
            this.btnAgvModelSet.Name = "btnAgvModelSet";
            this.btnAgvModelSet.Size = new System.Drawing.Size(75, 23);
            this.btnAgvModelSet.TabIndex = 0;
            this.btnAgvModelSet.Text = "Set";
            this.btnAgvModelSet.UseVisualStyleBackColor = true;
            this.btnAgvModelSet.Click += new System.EventHandler(this.btnAgvModelSet_Click);
            // 
            // txtAgvModelSet
            // 
            this.txtAgvModelSet.Location = new System.Drawing.Point(67, 56);
            this.txtAgvModelSet.Name = "txtAgvModelSet";
            this.txtAgvModelSet.Size = new System.Drawing.Size(94, 21);
            this.txtAgvModelSet.TabIndex = 1;
            this.txtAgvModelSet.Text = "1";
            this.txtAgvModelSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // AgvModelSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 140);
            this.Controls.Add(this.txtAgvModelSet);
            this.Controls.Add(this.btnAgvModelSet);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgvModelSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agv Model";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgvModelSet;
        private System.Windows.Forms.TextBox txtAgvModelSet;
    }
}