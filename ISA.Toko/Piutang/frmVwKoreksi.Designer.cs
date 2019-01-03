namespace ISA.Toko.Piutang
{
    partial class frmVwKoreksi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVwKoreksi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.NoKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NilaiKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(435, 246);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoKoreksi,
            this.TglKoreksi,
            this.NilaiKoreksi,
            this.RecordID,
            this.RowID});
            this.customGridView1.Location = new System.Drawing.Point(28, 28);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(507, 195);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 5;
            this.customGridView1.DoubleClick += new System.EventHandler(this.customGridView1_DoubleClick_1);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown_1);
            // 
            // NoKoreksi
            // 
            this.NoKoreksi.DataPropertyName = "NoKoreksi";
            this.NoKoreksi.HeaderText = "NoKoreksi";
            this.NoKoreksi.Name = "NoKoreksi";
            this.NoKoreksi.ReadOnly = true;
            // 
            // TglKoreksi
            // 
            this.TglKoreksi.DataPropertyName = "TglKoreksi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "dd MMM yyyy";
            this.TglKoreksi.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglKoreksi.HeaderText = "TglKoreksi";
            this.TglKoreksi.Name = "TglKoreksi";
            this.TglKoreksi.ReadOnly = true;
            // 
            // NilaiKoreksi
            // 
            this.NilaiKoreksi.DataPropertyName = "NilaiKoreksi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            dataGridViewCellStyle4.NullValue = "0";
            this.NilaiKoreksi.DefaultCellStyle = dataGridViewCellStyle4;
            this.NilaiKoreksi.HeaderText = "Nilai Koreksi";
            this.NilaiKoreksi.Name = "NilaiKoreksi";
            this.NilaiKoreksi.ReadOnly = true;
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "RecordID";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            this.RecordID.Visible = false;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmVwKoreksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(544, 298);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.customGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVwKoreksi";
            this.Text = "Koreksi";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmVwKoreksi_Load);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NilaiKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
