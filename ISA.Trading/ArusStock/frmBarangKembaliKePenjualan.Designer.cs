namespace ISA.Trading.ArusStock
{
    partial class frmBarangKembaliKePenjualan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarangKembaliKePenjualan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDelete = new ISA.Trading.Controls.CommandButton();
            this.cmdEdit = new ISA.Trading.Controls.CommandButton();
            this.cmdAdd = new ISA.Trading.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rgbTglDO = new ISA.Trading.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridHeader = new ISA.Trading.Controls.CustomGridView();
            this.nobukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglkembalipj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglkembaligdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodesales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridDetail = new ISA.Trading.Controls.CustomGridView();
            this.namastok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nopinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtykembali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatanD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowidD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headeridD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peminjamanid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordidD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlagD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(740, 470);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(283, 470);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(154, 470);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 3;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(19, 470);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "Range Tgl Pengembalian Peminjaman Barang";
            // 
            // rgbTglDO
            // 
            this.rgbTglDO.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglDO.FromDate = null;
            this.rgbTglDO.Location = new System.Drawing.Point(297, 60);
            this.rgbTglDO.Name = "rgbTglDO";
            this.rgbTglDO.Size = new System.Drawing.Size(237, 22);
            this.rgbTglDO.TabIndex = 0;
            this.rgbTglDO.ToDate = null;
            this.rgbTglDO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTglDO_KeyPress);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(540, 56);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridDetail, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 88);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 328);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // dataGridHeader
            // 
            this.dataGridHeader.AllowUserToAddRows = false;
            this.dataGridHeader.AllowUserToDeleteRows = false;
            this.dataGridHeader.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nobukti,
            this.tglkembalipj,
            this.sales,
            this.catatan,
            this.NPrint,
            this.rowid,
            this.recordid,
            this.tglkembaligdg,
            this.kodesales,
            this.SyncFlag});
            this.dataGridHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHeader.Location = new System.Drawing.Point(3, 3);
            this.dataGridHeader.MultiSelect = false;
            this.dataGridHeader.Name = "dataGridHeader";
            this.dataGridHeader.ReadOnly = true;
            this.dataGridHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridHeader.RowHeadersVisible = false;
            this.dataGridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridHeader.Size = new System.Drawing.Size(834, 147);
            this.dataGridHeader.StandardTab = true;
            this.dataGridHeader.TabIndex = 0;
            this.dataGridHeader.SelectionRowChanged += new System.EventHandler(this.dataGridHeader_SelectionRowChanged);
            this.dataGridHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridHeader_KeyDown);
            this.dataGridHeader.Click += new System.EventHandler(this.dataGridHeader_Click);
            // 
            // nobukti
            // 
            this.nobukti.DataPropertyName = "NoBukti";
            this.nobukti.HeaderText = "NoBukti";
            this.nobukti.Name = "nobukti";
            this.nobukti.ReadOnly = true;
            // 
            // tglkembalipj
            // 
            this.tglkembalipj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tglkembalipj.DataPropertyName = "TglKembaliPenjualan";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.tglkembalipj.DefaultCellStyle = dataGridViewCellStyle1;
            this.tglkembalipj.HeaderText = "Tgl. Kembali";
            this.tglkembalipj.Name = "tglkembalipj";
            this.tglkembalipj.ReadOnly = true;
            this.tglkembalipj.Width = 99;
            // 
            // sales
            // 
            this.sales.DataPropertyName = "NamaSales";
            this.sales.HeaderText = "Sales";
            this.sales.Name = "sales";
            this.sales.ReadOnly = true;
            // 
            // catatan
            // 
            this.catatan.DataPropertyName = "Catatan";
            this.catatan.HeaderText = "Catatan";
            this.catatan.Name = "catatan";
            this.catatan.ReadOnly = true;
            // 
            // NPrint
            // 
            this.NPrint.DataPropertyName = "NPrint";
            this.NPrint.HeaderText = "Print";
            this.NPrint.Name = "NPrint";
            this.NPrint.ReadOnly = true;
            // 
            // rowid
            // 
            this.rowid.DataPropertyName = "RowID";
            this.rowid.HeaderText = "RowID";
            this.rowid.Name = "rowid";
            this.rowid.ReadOnly = true;
            this.rowid.Visible = false;
            // 
            // recordid
            // 
            this.recordid.DataPropertyName = "RecordID";
            this.recordid.HeaderText = "RecordID";
            this.recordid.Name = "recordid";
            this.recordid.ReadOnly = true;
            this.recordid.Visible = false;
            // 
            // tglkembaligdg
            // 
            this.tglkembaligdg.DataPropertyName = "TglKembaliGudang";
            this.tglkembaligdg.HeaderText = "Tanggal Kembali Gudang";
            this.tglkembaligdg.Name = "tglkembaligdg";
            this.tglkembaligdg.ReadOnly = true;
            this.tglkembaligdg.Visible = false;
            // 
            // kodesales
            // 
            this.kodesales.DataPropertyName = "KodeSales";
            this.kodesales.HeaderText = "Kode Sales";
            this.kodesales.Name = "kodesales";
            this.kodesales.ReadOnly = true;
            this.kodesales.Visible = false;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.AllowUserToAddRows = false;
            this.dataGridDetail.AllowUserToDeleteRows = false;
            this.dataGridDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.namastok,
            this.satuan,
            this.nopinjam,
            this.qtykembali,
            this.catatanD,
            this.rowidD,
            this.headeridD,
            this.peminjamanid,
            this.recordidD,
            this.transactionid,
            this.idpinjam,
            this.SyncFlagD});
            this.dataGridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDetail.Location = new System.Drawing.Point(3, 178);
            this.dataGridDetail.MultiSelect = false;
            this.dataGridDetail.Name = "dataGridDetail";
            this.dataGridDetail.ReadOnly = true;
            this.dataGridDetail.RowHeadersVisible = false;
            this.dataGridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDetail.Size = new System.Drawing.Size(834, 147);
            this.dataGridDetail.StandardTab = true;
            this.dataGridDetail.TabIndex = 1;
            this.dataGridDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridDetail_KeyDown);
            this.dataGridDetail.Click += new System.EventHandler(this.dataGridDetail_Click);
            // 
            // namastok
            // 
            this.namastok.DataPropertyName = "NamaStok";
            this.namastok.HeaderText = "Nama Stok";
            this.namastok.Name = "namastok";
            this.namastok.ReadOnly = true;
            // 
            // satuan
            // 
            this.satuan.DataPropertyName = "SatJual";
            this.satuan.HeaderText = "Satuan";
            this.satuan.Name = "satuan";
            this.satuan.ReadOnly = true;
            // 
            // nopinjam
            // 
            this.nopinjam.DataPropertyName = "NoBukti";
            this.nopinjam.HeaderText = "Nomor Pinjam";
            this.nopinjam.Name = "nopinjam";
            this.nopinjam.ReadOnly = true;
            // 
            // qtykembali
            // 
            this.qtykembali.DataPropertyName = "QtyKembali";
            this.qtykembali.HeaderText = "Q. Kembali";
            this.qtykembali.Name = "qtykembali";
            this.qtykembali.ReadOnly = true;
            // 
            // catatanD
            // 
            this.catatanD.DataPropertyName = "Catatan";
            this.catatanD.HeaderText = "Catatan";
            this.catatanD.Name = "catatanD";
            this.catatanD.ReadOnly = true;
            // 
            // rowidD
            // 
            this.rowidD.DataPropertyName = "RowID";
            this.rowidD.HeaderText = "RowID";
            this.rowidD.Name = "rowidD";
            this.rowidD.ReadOnly = true;
            this.rowidD.Visible = false;
            // 
            // headeridD
            // 
            this.headeridD.DataPropertyName = "HeaderID";
            this.headeridD.HeaderText = "HeaderID";
            this.headeridD.Name = "headeridD";
            this.headeridD.ReadOnly = true;
            this.headeridD.Visible = false;
            // 
            // peminjamanid
            // 
            this.peminjamanid.DataPropertyName = "PeminjamanID";
            this.peminjamanid.HeaderText = "PeminjamanID";
            this.peminjamanid.Name = "peminjamanid";
            this.peminjamanid.ReadOnly = true;
            this.peminjamanid.Visible = false;
            // 
            // recordidD
            // 
            this.recordidD.DataPropertyName = "RecordID";
            this.recordidD.HeaderText = "RecordID";
            this.recordidD.Name = "recordidD";
            this.recordidD.ReadOnly = true;
            this.recordidD.Visible = false;
            // 
            // transactionid
            // 
            this.transactionid.DataPropertyName = "TransactionID";
            this.transactionid.HeaderText = "TransactionID";
            this.transactionid.Name = "transactionid";
            this.transactionid.ReadOnly = true;
            this.transactionid.Visible = false;
            // 
            // idpinjam
            // 
            this.idpinjam.DataPropertyName = "IDPinjam";
            this.idpinjam.HeaderText = "IDPinjam";
            this.idpinjam.Name = "idpinjam";
            this.idpinjam.ReadOnly = true;
            this.idpinjam.Visible = false;
            // 
            // SyncFlagD
            // 
            this.SyncFlagD.DataPropertyName = "SyncFlag";
            this.SyncFlagD.HeaderText = "SyncFlag";
            this.SyncFlagD.Name = "SyncFlagD";
            this.SyncFlagD.ReadOnly = true;
            this.SyncFlagD.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "F3 - Cetak Bukti Pengembalian Pinjaman";
            // 
            // txtInit
            // 
            this.txtInit.Location = new System.Drawing.Point(757, 55);
            this.txtInit.MaxLength = 3;
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(100, 20);
            this.txtInit.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 31;
            this.label3.Text = "Init Perusahaan";
            // 
            // frmBarangKembaliKePenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(866, 526);
            this.Controls.Add(this.txtInit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgbTglDO);
            this.Controls.Add(this.cmdSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBarangKembaliKePenjualan";
            this.Text = "Pengembalian Pinjaman Barang";
            this.Title = "Pengembalian Pinjaman Barang";
            this.Load += new System.EventHandler(this.frmBarangKembaliKePenjualan_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rgbTglDO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtInit, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdDelete;
        private ISA.Trading.Controls.CommandButton cmdEdit;
        private ISA.Trading.Controls.CommandButton cmdAdd;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rgbTglDO;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Trading.Controls.CustomGridView dataGridHeader;
        private ISA.Trading.Controls.CustomGridView dataGridDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn namastok;
        private System.Windows.Forms.DataGridViewTextBoxColumn satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn nopinjam;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtykembali;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatanD;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowidD;
        private System.Windows.Forms.DataGridViewTextBoxColumn headeridD;
        private System.Windows.Forms.DataGridViewTextBoxColumn peminjamanid;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordidD;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpinjam;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlagD;
        private System.Windows.Forms.DataGridViewTextBoxColumn nobukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglkembalipj;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowid;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglkembaligdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodesales;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.Label label3;

    }
}
