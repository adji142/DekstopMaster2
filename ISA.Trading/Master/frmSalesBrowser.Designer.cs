namespace ISA.Trading.Master
{
    partial class frmSalesBrowser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesBrowser));
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.SalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatasOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Trading.Controls.CommonTextBox();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SalesName,
            this.SalesID,
            this.TglLahir,
            this.TglMasuk,
            this.TglKeluar,
            this.Alamat,
            this.Target,
            this.BatasOD,
            this.LastUpdatedBy,
            this.LastUpdatedTime,
            this.RowID});
            this.dataGridView1.Location = new System.Drawing.Point(9, 109);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(694, 248);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // SalesName
            // 
            this.SalesName.DataPropertyName = "NamaSales";
            this.SalesName.Frozen = true;
            this.SalesName.HeaderText = "Nama";
            this.SalesName.MaxInputLength = 23;
            this.SalesName.Name = "SalesName";
            this.SalesName.ReadOnly = true;
            this.SalesName.Width = 250;
            // 
            // SalesID
            // 
            this.SalesID.DataPropertyName = "SalesID";
            this.SalesID.Frozen = true;
            this.SalesID.HeaderText = "Kode";
            this.SalesID.MaxInputLength = 11;
            this.SalesID.Name = "SalesID";
            this.SalesID.ReadOnly = true;
            this.SalesID.Width = 82;
            // 
            // TglLahir
            // 
            this.TglLahir.DataPropertyName = "TglLahir";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.TglLahir.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglLahir.HeaderText = "Tgl Lahir";
            this.TglLahir.MaxInputLength = 20;
            this.TglLahir.Name = "TglLahir";
            this.TglLahir.ReadOnly = true;
            this.TglLahir.Width = 110;
            // 
            // TglMasuk
            // 
            this.TglMasuk.DataPropertyName = "TglMasuk";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.TglMasuk.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglMasuk.HeaderText = "Tgl Masuk";
            this.TglMasuk.MaxInputLength = 20;
            this.TglMasuk.Name = "TglMasuk";
            this.TglMasuk.ReadOnly = true;
            this.TglMasuk.Width = 110;
            // 
            // TglKeluar
            // 
            this.TglKeluar.DataPropertyName = "TglKeluar";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.TglKeluar.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglKeluar.HeaderText = "Tgl Keluar";
            this.TglKeluar.MaxInputLength = 20;
            this.TglKeluar.Name = "TglKeluar";
            this.TglKeluar.ReadOnly = true;
            this.TglKeluar.Width = 110;
            // 
            // Alamat
            // 
            this.Alamat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.MaxInputLength = 30;
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // Target
            // 
            this.Target.DataPropertyName = "Target";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.Target.DefaultCellStyle = dataGridViewCellStyle4;
            this.Target.HeaderText = "Target";
            this.Target.MaxInputLength = 16;
            this.Target.Name = "Target";
            this.Target.ReadOnly = true;
            this.Target.Width = 120;
            // 
            // BatasOD
            // 
            this.BatasOD.DataPropertyName = "BatasOD";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.BatasOD.DefaultCellStyle = dataGridViewCellStyle5;
            this.BatasOD.HeaderText = "Limit OD";
            this.BatasOD.MaxInputLength = 14;
            this.BatasOD.Name = "BatasOD";
            this.BatasOD.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle6.Format = "(dd/MM/yyyy)";
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nama Sales";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(106, 66);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(279, 20);
            this.txtNama.TabIndex = 0;
            this.txtNama.TextChanged += new System.EventHandler(this.txtNama_TextChanged);
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(393, 64);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click_1);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(603, 367);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmSalesBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(714, 419);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormID = "SC0224";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSalesBrowser";
            this.Text = "SC0224 - Sales";
            this.Title = "Sales";
            this.Load += new System.EventHandler(this.frmSalesBrowser_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommonTextBox txtNama;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatasOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
