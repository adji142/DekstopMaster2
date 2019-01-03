namespace ISA.Toko.Kasir
{
    partial class frmVoucherGiroMasukBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherGiroMasukBrowse));
            this.label1 = new System.Windows.Forms.Label();
            this.tbTanggal = new ISA.Controls.RangeDateBox();
            this.gridDetail = new ISA.Controls.CustomGridView();
            this.dtlNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsalGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lokasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainPiutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubPiutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroRecID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedByD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedByD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridHeader = new ISA.Controls.CustomGridView();
            this.hdrRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrPOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrTglVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrTipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrNoVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrNilai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrUraian2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrUraian3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrDibuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrDibukukan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrMengetahui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdrNPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.cmdPrint = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tanggal Voucher";
            // 
            // tbTanggal
            // 
            this.tbTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tbTanggal.FromDate = null;
            this.tbTanggal.Location = new System.Drawing.Point(129, 25);
            this.tbTanggal.Name = "tbTanggal";
            this.tbTanggal.Size = new System.Drawing.Size(257, 22);
            this.tbTanggal.TabIndex = 13;
            this.tbTanggal.ToDate = null;
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtlNoPerkiraan,
            this.AsalGiro,
            this.NamaBank,
            this.Lokasi,
            this.CHBG,
            this.Nomor,
            this.TglGiro,
            this.Nominal,
            this.TglJth,
            this.MainPiutang,
            this.SubPiutang,
            this.GiroRecID,
            this.GiroID,
            this.CreatedByD,
            this.CreatedTimeD,
            this.LastUpdatedByD,
            this.LastUpdatedTimeD});
            this.gridDetail.Location = new System.Drawing.Point(6, 258);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetail.Size = new System.Drawing.Size(701, 161);
            this.gridDetail.StandardTab = true;
            this.gridDetail.TabIndex = 16;
            this.gridDetail.Enter += new System.EventHandler(this.gridDetail_Enter);
            // 
            // dtlNoPerkiraan
            // 
            this.dtlNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.dtlNoPerkiraan.HeaderText = "No Perkiraan";
            this.dtlNoPerkiraan.Name = "dtlNoPerkiraan";
            this.dtlNoPerkiraan.ReadOnly = true;
            this.dtlNoPerkiraan.Visible = false;
            // 
            // AsalGiro
            // 
            this.AsalGiro.DataPropertyName = "AsalGiro";
            this.AsalGiro.HeaderText = "Asal Giro";
            this.AsalGiro.Name = "AsalGiro";
            this.AsalGiro.ReadOnly = true;
            // 
            // NamaBank
            // 
            this.NamaBank.DataPropertyName = "NamaBank";
            this.NamaBank.HeaderText = "Bank";
            this.NamaBank.Name = "NamaBank";
            this.NamaBank.ReadOnly = true;
            // 
            // Lokasi
            // 
            this.Lokasi.DataPropertyName = "Lokasi";
            this.Lokasi.HeaderText = "Kota";
            this.Lokasi.Name = "Lokasi";
            this.Lokasi.ReadOnly = true;
            // 
            // CHBG
            // 
            this.CHBG.DataPropertyName = "CHBG";
            this.CHBG.HeaderText = "G/C";
            this.CHBG.Name = "CHBG";
            this.CHBG.ReadOnly = true;
            // 
            // Nomor
            // 
            this.Nomor.DataPropertyName = "Nomor";
            this.Nomor.HeaderText = "Nomor";
            this.Nomor.Name = "Nomor";
            this.Nomor.ReadOnly = true;
            // 
            // TglGiro
            // 
            this.TglGiro.DataPropertyName = "TglGiro";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.TglGiro.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglGiro.HeaderText = "TglGiro";
            this.TglGiro.Name = "TglGiro";
            this.TglGiro.ReadOnly = true;
            this.TglGiro.Width = 120;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nominal.HeaderText = "Jumlah";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // TglJth
            // 
            this.TglJth.DataPropertyName = "TglJth";
            dataGridViewCellStyle3.Format = "dd-MM-yyyy";
            this.TglJth.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglJth.HeaderText = "Tgl. J.Tempo";
            this.TglJth.Name = "TglJth";
            this.TglJth.ReadOnly = true;
            this.TglJth.Width = 120;
            // 
            // MainPiutang
            // 
            this.MainPiutang.DataPropertyName = "MainPiutang";
            this.MainPiutang.HeaderText = "MainPiut";
            this.MainPiutang.Name = "MainPiutang";
            this.MainPiutang.ReadOnly = true;
            this.MainPiutang.Visible = false;
            // 
            // SubPiutang
            // 
            this.SubPiutang.DataPropertyName = "SubPiutang";
            this.SubPiutang.HeaderText = "SubPiut";
            this.SubPiutang.Name = "SubPiutang";
            this.SubPiutang.ReadOnly = true;
            this.SubPiutang.Visible = false;
            // 
            // GiroRecID
            // 
            this.GiroRecID.DataPropertyName = "GiroRecID";
            this.GiroRecID.HeaderText = "GiroRecID";
            this.GiroRecID.Name = "GiroRecID";
            this.GiroRecID.ReadOnly = true;
            this.GiroRecID.Visible = false;
            // 
            // GiroID
            // 
            this.GiroID.DataPropertyName = "GiroID";
            this.GiroID.HeaderText = "GiroID";
            this.GiroID.Name = "GiroID";
            this.GiroID.ReadOnly = true;
            this.GiroID.Visible = false;
            // 
            // CreatedByD
            // 
            this.CreatedByD.DataPropertyName = "CreatedBy";
            this.CreatedByD.HeaderText = "CreatedBy";
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
            this.LastUpdatedTimeD.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTimeD.Name = "LastUpdatedTimeD";
            this.LastUpdatedTimeD.ReadOnly = true;
            // 
            // gridHeader
            // 
            this.gridHeader.AllowUserToAddRows = false;
            this.gridHeader.AllowUserToDeleteRows = false;
            this.gridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hdrRowID,
            this.hdrPOS,
            this.hdrTglVoucher,
            this.hdrTipe,
            this.hdrNoVoucher,
            this.hdrUraian,
            this.hdrNilai,
            this.hdrUraian2,
            this.hdrUraian3,
            this.hdrDibuat,
            this.hdrDibukukan,
            this.hdrMengetahui,
            this.hdrNPrint,
            this.CreatedBy,
            this.CreatedTime,
            this.LastUpdatedTime,
            this.LastUpdatedBy});
            this.gridHeader.Location = new System.Drawing.Point(6, 65);
            this.gridHeader.MultiSelect = false;
            this.gridHeader.Name = "gridHeader";
            this.gridHeader.ReadOnly = true;
            this.gridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridHeader.Size = new System.Drawing.Size(701, 176);
            this.gridHeader.StandardTab = true;
            this.gridHeader.TabIndex = 15;
            this.gridHeader.Enter += new System.EventHandler(this.gridHeader_Enter);
            this.gridHeader.Leave += new System.EventHandler(this.gridHeader_Leave);
            this.gridHeader.Click += new System.EventHandler(this.gridHeader_Click);
            // 
            // hdrRowID
            // 
            this.hdrRowID.DataPropertyName = "RowID";
            this.hdrRowID.HeaderText = "RowID";
            this.hdrRowID.Name = "hdrRowID";
            this.hdrRowID.ReadOnly = true;
            this.hdrRowID.Visible = false;
            // 
            // hdrPOS
            // 
            this.hdrPOS.DataPropertyName = "POS";
            this.hdrPOS.HeaderText = "POS";
            this.hdrPOS.Name = "hdrPOS";
            this.hdrPOS.ReadOnly = true;
            this.hdrPOS.Visible = false;
            this.hdrPOS.Width = 50;
            // 
            // hdrTglVoucher
            // 
            this.hdrTglVoucher.DataPropertyName = "TglVoucher";
            dataGridViewCellStyle4.Format = "dd/MMM/yyyy";
            this.hdrTglVoucher.DefaultCellStyle = dataGridViewCellStyle4;
            this.hdrTglVoucher.HeaderText = "Tanggal";
            this.hdrTglVoucher.Name = "hdrTglVoucher";
            this.hdrTglVoucher.ReadOnly = true;
            // 
            // hdrTipe
            // 
            this.hdrTipe.DataPropertyName = "Tipe";
            this.hdrTipe.HeaderText = "Tipe";
            this.hdrTipe.Name = "hdrTipe";
            this.hdrTipe.ReadOnly = true;
            this.hdrTipe.Width = 60;
            // 
            // hdrNoVoucher
            // 
            this.hdrNoVoucher.DataPropertyName = "NoVoucher";
            this.hdrNoVoucher.HeaderText = "No Voucher";
            this.hdrNoVoucher.Name = "hdrNoVoucher";
            this.hdrNoVoucher.ReadOnly = true;
            // 
            // hdrUraian
            // 
            this.hdrUraian.DataPropertyName = "Uraian1";
            this.hdrUraian.HeaderText = "Uraian";
            this.hdrUraian.Name = "hdrUraian";
            this.hdrUraian.ReadOnly = true;
            this.hdrUraian.Width = 200;
            // 
            // hdrNilai
            // 
            this.hdrNilai.DataPropertyName = "Nilai";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.hdrNilai.DefaultCellStyle = dataGridViewCellStyle5;
            this.hdrNilai.HeaderText = "Nilai";
            this.hdrNilai.Name = "hdrNilai";
            this.hdrNilai.ReadOnly = true;
            // 
            // hdrUraian2
            // 
            this.hdrUraian2.DataPropertyName = "Uraian2";
            this.hdrUraian2.HeaderText = "Uraian2";
            this.hdrUraian2.Name = "hdrUraian2";
            this.hdrUraian2.ReadOnly = true;
            // 
            // hdrUraian3
            // 
            this.hdrUraian3.DataPropertyName = "Uraian3";
            this.hdrUraian3.HeaderText = "Uraian3";
            this.hdrUraian3.Name = "hdrUraian3";
            this.hdrUraian3.ReadOnly = true;
            // 
            // hdrDibuat
            // 
            this.hdrDibuat.DataPropertyName = "Dibuat";
            this.hdrDibuat.HeaderText = "Dibuat";
            this.hdrDibuat.Name = "hdrDibuat";
            this.hdrDibuat.ReadOnly = true;
            // 
            // hdrDibukukan
            // 
            this.hdrDibukukan.DataPropertyName = "Dibukukan";
            this.hdrDibukukan.HeaderText = "Dibukukan";
            this.hdrDibukukan.Name = "hdrDibukukan";
            this.hdrDibukukan.ReadOnly = true;
            // 
            // hdrMengetahui
            // 
            this.hdrMengetahui.DataPropertyName = "Mengetahui";
            this.hdrMengetahui.HeaderText = "Mengetahui";
            this.hdrMengetahui.Name = "hdrMengetahui";
            this.hdrMengetahui.ReadOnly = true;
            // 
            // hdrNPrint
            // 
            this.hdrNPrint.DataPropertyName = "NPrint";
            this.hdrNPrint.HeaderText = "NPrint";
            this.hdrNPrint.Name = "hdrNPrint";
            this.hdrNPrint.ReadOnly = true;
            this.hdrNPrint.Visible = false;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // CreatedTime
            // 
            this.CreatedTime.DataPropertyName = "CreatedTime";
            this.CreatedTime.HeaderText = "CreatedTime";
            this.CreatedTime.Name = "CreatedTime";
            this.CreatedTime.ReadOnly = true;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(607, 437);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 18;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(392, 23);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 14;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(6, 437);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 19;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // frmVoucherGiroMasukBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(713, 478);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tbTanggal);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.gridHeader);
            this.Controls.Add(this.cmdSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmVoucherGiroMasukBrowse";
            this.Text = "Voucher Penerimaan Giro";
            this.Title = "Voucher Penerimaan Giro";
            this.Load += new System.EventHandler(this.frmVoucherGiroMasukBrowse_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.gridHeader, 0);
            this.Controls.SetChildIndex(this.gridDetail, 0);
            this.Controls.SetChildIndex(this.tbTanggal, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.RangeDateBox tbTanggal;
        private ISA.Controls.CustomGridView gridDetail;
        private ISA.Controls.CustomGridView gridHeader;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CommandButton cmdPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrPOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrTglVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrTipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrNoVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrNilai;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrUraian2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrUraian3;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrDibuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrDibukukan;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrMengetahui;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdrNPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsalGiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lokasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglGiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJth;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainPiutang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubPiutang;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiroRecID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiroID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedByD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTimeD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedByD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTimeD;
    }
}
