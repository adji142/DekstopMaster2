namespace ISA.Toko.Kasir
{
    partial class frmBuktiTransferMasuk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuktiTransferMasuk));
            this.gridUtm = new ISA.Controls.CustomGridView();
            this.POS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglBBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dibukukan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diketahui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kasir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penyetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedByH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTimeH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedByH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTimeH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDetail = new ISA.Controls.CustomGridView();
            this.NoPerk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsalTransfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAsal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTransfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedByD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedByD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridUtm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUtm
            // 
            this.gridUtm.AllowUserToAddRows = false;
            this.gridUtm.AllowUserToDeleteRows = false;
            this.gridUtm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUtm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridUtm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUtm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POS,
            this.TglBBM,
            this.NoBBM,
            this.NamaBank,
            this.Nominal,
            this.Dibukukan,
            this.Diketahui,
            this.Kasir,
            this.Penyetor,
            this.RowID,
            this.NPrint,
            this.CreatedByH,
            this.CreatedTimeH,
            this.LastUpdatedByH,
            this.LastUpdatedTimeH});
            this.gridUtm.Location = new System.Drawing.Point(6, 56);
            this.gridUtm.MultiSelect = false;
            this.gridUtm.Name = "gridUtm";
            this.gridUtm.ReadOnly = true;
            this.gridUtm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridUtm.Size = new System.Drawing.Size(946, 268);
            this.gridUtm.StandardTab = true;
            this.gridUtm.TabIndex = 3;
            this.gridUtm.Enter += new System.EventHandler(this.gridUtm_Enter);
            this.gridUtm.Validated += new System.EventHandler(this.gridUtm_Validated);
            this.gridUtm.Leave += new System.EventHandler(this.gridUtm_Leave);
            this.gridUtm.SelectionChanged += new System.EventHandler(this.gridUtm_SelectionChanged);
            this.gridUtm.Click += new System.EventHandler(this.gridUtm_Click);
            // 
            // POS
            // 
            this.POS.DataPropertyName = "POS";
            this.POS.HeaderText = "POS";
            this.POS.Name = "POS";
            this.POS.ReadOnly = true;
            this.POS.Visible = false;
            this.POS.Width = 45;
            // 
            // TglBBM
            // 
            this.TglBBM.DataPropertyName = "TglBBM";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.TglBBM.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglBBM.HeaderText = "Tgl.BBM";
            this.TglBBM.Name = "TglBBM";
            this.TglBBM.ReadOnly = true;
            // 
            // NoBBM
            // 
            this.NoBBM.DataPropertyName = "NoBBM";
            this.NoBBM.HeaderText = "No.BBM";
            this.NoBBM.Name = "NoBBM";
            this.NoBBM.ReadOnly = true;
            // 
            // NamaBank
            // 
            this.NamaBank.DataPropertyName = "NamaBank";
            this.NamaBank.HeaderText = "Nama Bank";
            this.NamaBank.Name = "NamaBank";
            this.NamaBank.ReadOnly = true;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Jumlah";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nominal.HeaderText = "Jumlah";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // Dibukukan
            // 
            this.Dibukukan.DataPropertyName = "Dibukukan";
            this.Dibukukan.HeaderText = "Dibukukan";
            this.Dibukukan.Name = "Dibukukan";
            this.Dibukukan.ReadOnly = true;
            // 
            // Diketahui
            // 
            this.Diketahui.DataPropertyName = "Diketahui";
            this.Diketahui.HeaderText = "Diketahui";
            this.Diketahui.Name = "Diketahui";
            this.Diketahui.ReadOnly = true;
            // 
            // Kasir
            // 
            this.Kasir.DataPropertyName = "Kasir";
            this.Kasir.HeaderText = "Kasir";
            this.Kasir.Name = "Kasir";
            this.Kasir.ReadOnly = true;
            // 
            // Penyetor
            // 
            this.Penyetor.DataPropertyName = "Penyetor";
            this.Penyetor.HeaderText = "Penyetor";
            this.Penyetor.Name = "Penyetor";
            this.Penyetor.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "Column1";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NPrint
            // 
            this.NPrint.DataPropertyName = "NPrint";
            this.NPrint.HeaderText = "NPrint";
            this.NPrint.Name = "NPrint";
            this.NPrint.ReadOnly = true;
            this.NPrint.Visible = false;
            // 
            // CreatedByH
            // 
            this.CreatedByH.DataPropertyName = "CreatedBy";
            this.CreatedByH.HeaderText = "CreatedBy";
            this.CreatedByH.Name = "CreatedByH";
            this.CreatedByH.ReadOnly = true;
            // 
            // CreatedTimeH
            // 
            this.CreatedTimeH.DataPropertyName = "CreatedTime";
            this.CreatedTimeH.HeaderText = "CreatedTime";
            this.CreatedTimeH.Name = "CreatedTimeH";
            this.CreatedTimeH.ReadOnly = true;
            // 
            // LastUpdatedByH
            // 
            this.LastUpdatedByH.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedByH.HeaderText = "LastUpdatedBy";
            this.LastUpdatedByH.Name = "LastUpdatedByH";
            this.LastUpdatedByH.ReadOnly = true;
            // 
            // LastUpdatedTimeH
            // 
            this.LastUpdatedTimeH.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTimeH.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTimeH.Name = "LastUpdatedTimeH";
            this.LastUpdatedTimeH.ReadOnly = true;
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoPerk,
            this.AsalTransfer,
            this.BankAsal,
            this.TglBank,
            this.TglTransfer,
            this.Jumlah,
            this.CreatedByD,
            this.CreatedTimeD,
            this.LastUpdatedByD,
            this.LastUpdatedTimeD});
            this.gridDetail.Location = new System.Drawing.Point(6, 342);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetail.Size = new System.Drawing.Size(946, 223);
            this.gridDetail.StandardTab = true;
            this.gridDetail.TabIndex = 4;
            this.gridDetail.Enter += new System.EventHandler(this.gridDetail_Enter);
            this.gridDetail.Click += new System.EventHandler(this.gridDetail_Click);
            // 
            // NoPerk
            // 
            this.NoPerk.DataPropertyName = "NoPerkiraan";
            this.NoPerk.HeaderText = "No.Perk";
            this.NoPerk.Name = "NoPerk";
            this.NoPerk.ReadOnly = true;
            this.NoPerk.Visible = false;
            // 
            // AsalTransfer
            // 
            this.AsalTransfer.DataPropertyName = "AsalTransfer";
            this.AsalTransfer.HeaderText = "Asal Transfer";
            this.AsalTransfer.Name = "AsalTransfer";
            this.AsalTransfer.ReadOnly = true;
            this.AsalTransfer.Width = 300;
            // 
            // BankAsal
            // 
            this.BankAsal.DataPropertyName = "KeBank";
            this.BankAsal.HeaderText = "Bank Asal";
            this.BankAsal.Name = "BankAsal";
            this.BankAsal.ReadOnly = true;
            this.BankAsal.Width = 150;
            // 
            // TglBank
            // 
            this.TglBank.DataPropertyName = "TglBank";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.TglBank.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglBank.HeaderText = "Tgl.Bank";
            this.TglBank.Name = "TglBank";
            this.TglBank.ReadOnly = true;
            // 
            // TglTransfer
            // 
            this.TglTransfer.DataPropertyName = "TglTransfer";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            this.TglTransfer.DefaultCellStyle = dataGridViewCellStyle4;
            this.TglTransfer.HeaderText = "Tgl.Transfer";
            this.TglTransfer.Name = "TglTransfer";
            this.TglTransfer.ReadOnly = true;
            // 
            // Jumlah
            // 
            this.Jumlah.DataPropertyName = "Nominal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle5;
            this.Jumlah.HeaderText = "Nominal";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            // 
            // CreatedByD
            // 
            this.CreatedByD.DataPropertyName = "CreatedBy";
            this.CreatedByD.HeaderText = "CreatdBy";
            this.CreatedByD.Name = "CreatedByD";
            this.CreatedByD.ReadOnly = true;
            // 
            // CreatedTimeD
            // 
            this.CreatedTimeD.DataPropertyName = "CreatedTime";
            this.CreatedTimeD.HeaderText = "CreatedTime";
            this.CreatedTimeD.Name = "CreatedTimeD";
            this.CreatedTimeD.ReadOnly = true;
            // 
            // LastUpdatedByD
            // 
            this.LastUpdatedByD.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedByD.HeaderText = "LastUpdatedBy";
            this.LastUpdatedByD.Name = "LastUpdatedByD";
            this.LastUpdatedByD.ReadOnly = true;
            // 
            // LastUpdatedTimeD
            // 
            this.LastUpdatedTimeD.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTimeD.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTimeD.Name = "LastUpdatedTimeD";
            this.LastUpdatedTimeD.ReadOnly = true;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Enabled = false;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(28, 594);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 5;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(82, 28);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(345, 23);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 7;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(843, 594);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmBuktiTransferMasuk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(955, 658);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.gridUtm);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBuktiTransferMasuk";
            this.Text = "Bukti Transfer Masuk";
            this.Title = "Bukti Transfer Masuk";
            this.Load += new System.EventHandler(this.frmBuktiTransferMasuk_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.gridDetail, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.gridUtm, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridUtm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView gridUtm;
        private ISA.Controls.CustomGridView gridDetail;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglBBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dibukukan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diketahui;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kasir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penyetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedByH;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTimeH;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedByH;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTimeH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerk;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsalTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAsal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedByD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTimeD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedByD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTimeD;
    }
}
