namespace AgvServerSystem
{
    partial class MapForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMapId = new System.Windows.Forms.TextBox();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMapAdd = new System.Windows.Forms.Button();
            this.dgvMapInfo = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMapObtain = new System.Windows.Forms.Button();
            this.chbMapChange = new System.Windows.Forms.CheckBox();
            this.txtMapChangeTime = new System.Windows.Forms.TextBox();
            this.btnMapChangeSet = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cTxtMapId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtMapName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCbDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cCbChange = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMapId
            // 
            this.txtMapId.Location = new System.Drawing.Point(65, 26);
            this.txtMapId.Name = "txtMapId";
            this.txtMapId.Size = new System.Drawing.Size(56, 21);
            this.txtMapId.TabIndex = 0;
            this.txtMapId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMapId_KeyPress);
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(192, 26);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(56, 21);
            this.txtMapName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // btnMapAdd
            // 
            this.btnMapAdd.Location = new System.Drawing.Point(270, 26);
            this.btnMapAdd.Name = "btnMapAdd";
            this.btnMapAdd.Size = new System.Drawing.Size(75, 23);
            this.btnMapAdd.TabIndex = 4;
            this.btnMapAdd.Text = "Add";
            this.btnMapAdd.UseVisualStyleBackColor = true;
            this.btnMapAdd.Click += new System.EventHandler(this.btnMapAdd_Click);
            // 
            // dgvMapInfo
            // 
            this.dgvMapInfo.AllowUserToAddRows = false;
            this.dgvMapInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMapInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMapInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTxtMapId,
            this.cTxtMapName,
            this.cCbDelete,
            this.cCbChange});
            this.dgvMapInfo.Location = new System.Drawing.Point(12, 90);
            this.dgvMapInfo.Name = "dgvMapInfo";
            this.dgvMapInfo.RowHeadersVisible = false;
            this.dgvMapInfo.RowTemplate.Height = 23;
            this.dgvMapInfo.Size = new System.Drawing.Size(372, 249);
            this.dgvMapInfo.TabIndex = 5;
            this.dgvMapInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMapInfo_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Map information";
            // 
            // btnMapObtain
            // 
            this.btnMapObtain.Location = new System.Drawing.Point(292, 61);
            this.btnMapObtain.Name = "btnMapObtain";
            this.btnMapObtain.Size = new System.Drawing.Size(75, 23);
            this.btnMapObtain.TabIndex = 7;
            this.btnMapObtain.Text = "Receive";
            this.btnMapObtain.UseVisualStyleBackColor = true;
            this.btnMapObtain.Click += new System.EventHandler(this.btnMapObtain_Click);
            // 
            // chbMapChange
            // 
            this.chbMapChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbMapChange.AutoSize = true;
            this.chbMapChange.Location = new System.Drawing.Point(12, 379);
            this.chbMapChange.Name = "chbMapChange";
            this.chbMapChange.Size = new System.Drawing.Size(144, 16);
            this.chbMapChange.TabIndex = 8;
            this.chbMapChange.Text = "Automatic Switchover";
            this.chbMapChange.UseVisualStyleBackColor = true;
            // 
            // txtMapChangeTime
            // 
            this.txtMapChangeTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMapChangeTime.Location = new System.Drawing.Point(219, 377);
            this.txtMapChangeTime.Name = "txtMapChangeTime";
            this.txtMapChangeTime.Size = new System.Drawing.Size(56, 21);
            this.txtMapChangeTime.TabIndex = 10;
            // 
            // btnMapChangeSet
            // 
            this.btnMapChangeSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMapChangeSet.Location = new System.Drawing.Point(311, 376);
            this.btnMapChangeSet.Name = "btnMapChangeSet";
            this.btnMapChangeSet.Size = new System.Drawing.Size(75, 23);
            this.btnMapChangeSet.TabIndex = 11;
            this.btnMapChangeSet.Text = "Set";
            this.btnMapChangeSet.UseVisualStyleBackColor = true;
            this.btnMapChangeSet.Click += new System.EventHandler(this.btnMapChangeSet_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "sec";
            // 
            // cTxtMapId
            // 
            this.cTxtMapId.HeaderText = "Id";
            this.cTxtMapId.Name = "cTxtMapId";
            this.cTxtMapId.ReadOnly = true;
            // 
            // cTxtMapName
            // 
            this.cTxtMapName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cTxtMapName.DefaultCellStyle = dataGridViewCellStyle2;
            this.cTxtMapName.HeaderText = "Name";
            this.cTxtMapName.MinimumWidth = 100;
            this.cTxtMapName.Name = "cTxtMapName";
            // 
            // cCbDelete
            // 
            this.cCbDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbDelete.HeaderText = "Operate";
            this.cCbDelete.Name = "cCbDelete";
            this.cCbDelete.Text = "Delete";
            this.cCbDelete.UseColumnTextForButtonValue = true;
            this.cCbDelete.Width = 60;
            // 
            // cCbChange
            // 
            this.cCbChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbChange.HeaderText = "Update";
            this.cCbChange.Name = "cCbChange";
            this.cCbChange.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cCbChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cCbChange.Text = "Change";
            this.cCbChange.UseColumnTextForButtonValue = true;
            this.cCbChange.Width = 60;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 431);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMapChangeSet);
            this.Controls.Add(this.txtMapChangeTime);
            this.Controls.Add(this.chbMapChange);
            this.Controls.Add(this.btnMapObtain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvMapInfo);
            this.Controls.Add(this.btnMapAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.txtMapId);
            this.Name = "MapForm";
            this.Text = "Map Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMapId;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMapAdd;
        private System.Windows.Forms.DataGridView dgvMapInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMapObtain;
        private System.Windows.Forms.CheckBox chbMapChange;
        private System.Windows.Forms.TextBox txtMapChangeTime;
        private System.Windows.Forms.Button btnMapChangeSet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtMapId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtMapName;
        private System.Windows.Forms.DataGridViewButtonColumn cCbDelete;
        private System.Windows.Forms.DataGridViewButtonColumn cCbChange;
    }
}