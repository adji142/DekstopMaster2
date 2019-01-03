namespace ISA.Toko.ArusStock
{
    partial class frmBarangKembaliKeGudang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarangKembaliKeGudang));
            this.dataGridPeminjamanDetail = new ISA.Toko.Controls.CustomGridView();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyKembali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyKeluarGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatatanD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridHeader = new ISA.Toko.Controls.CustomGridView();
            this.nobukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglkembalipj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglkembaligdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodesales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridDetail = new ISA.Toko.Controls.CustomGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nopinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peminjamanid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rgbTglDO = new ISA.Toko.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPeminjamanDetail)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPeminjamanDetail
            // 
            this.dataGridPeminjamanDetail.AllowUserToAddRows = false;
            this.dataGridPeminjamanDetail.AllowUserToDeleteRows = false;
            this.dataGridPeminjamanDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridPeminjamanDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPeminjamanDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaStok,
            this.Satuan,
            this.RowIDD,
            this.KodeBarang,
            this.QtyKembali,
            this.QtyKeluarGudang,
            this.QtyMemo,
            this.Sisa,
            this.CatatanD,
            this.TransactionIDD,
            this.RecordIDD,
            this.HeaderIDD});
            this.dataGridPeminjamanDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPeminjamanDetail.Location = new System.Drawing.Point(3, 163);
            this.dataGridPeminjamanDetail.MultiSelect = false;
            this.dataGridPeminjamanDetail.Name = "dataGridPeminjamanDetail";
            this.dataGridPeminjamanDetail.ReadOnly = true;
            this.dataGridPeminjamanDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPeminjamanDetail.Size = new System.Drawing.Size(699, 134);
            this.dataGridPeminjamanDetail.TabIndex = 1;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 85;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "Satuan";
            this.Satuan.HeaderText = "Satuan";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Width = 66;
            // 
            // RowIDD
            // 
            this.RowIDD.DataPropertyName = "RowID";
            this.RowIDD.HeaderText = "RowIDD";
            this.RowIDD.Name = "RowIDD";
            this.RowIDD.ReadOnly = true;
            this.RowIDD.Visible = false;
            this.RowIDD.Width = 73;
            // 
            // KodeBarang
            // 
            this.KodeBarang.DataPropertyName = "KodeBarang";
            this.KodeBarang.HeaderText = "KodeBarang";
            this.KodeBarang.Name = "KodeBarang";
            this.KodeBarang.ReadOnly = true;
            this.KodeBarang.Visible = false;
            this.KodeBarang.Width = 91;
            // 
            // QtyKembali
            // 
            this.QtyKembali.DataPropertyName = "QtyKembali";
            this.QtyKembali.HeaderText = "QtyKembali";
            this.QtyKembali.Name = "QtyKembali";
            this.QtyKembali.ReadOnly = true;
            this.QtyKembali.Width = 85;
            // 
            // QtyKeluarGudang
            // 
            this.QtyKeluarGudang.DataPropertyName = "QtyKeluarGudang";
            this.QtyKeluarGudang.HeaderText = "QtyKeluarGudang";
            this.QtyKeluarGudang.Name = "QtyKeluarGudang";
            this.QtyKeluarGudang.ReadOnly = true;
            this.QtyKeluarGudang.Width = 116;
            // 
            // QtyMemo
            // 
            this.QtyMemo.DataPropertyName = "QtyMemo";
            this.QtyMemo.HeaderText = "Qty Pinjam";
            this.QtyMemo.Name = "QtyMemo";
            this.QtyMemo.ReadOnly = true;
            this.QtyMemo.Width = 82;
            // 
            // Sisa
            // 
            this.Sisa.DataPropertyName = "Sisa";
            this.Sisa.HeaderText = "Sisa";
            this.Sisa.Name = "Sisa";
            this.Sisa.ReadOnly = true;
            this.Sisa.Width = 52;
            // 
            // CatatanD
            // 
            this.CatatanD.DataPropertyName = "Catatan";
            this.CatatanD.HeaderText = "Catatan";
            this.CatatanD.Name = "CatatanD";
            this.CatatanD.ReadOnly = true;
            this.CatatanD.Width = 69;
            // 
            // TransactionIDD
            // 
            this.TransactionIDD.DataPropertyName = "TransactionID";
            this.TransactionIDD.HeaderText = "TransactionID";
            this.TransactionIDD.Name = "TransactionIDD";
            this.TransactionIDD.ReadOnly = true;
            this.TransactionIDD.Visible = false;
            this.TransactionIDD.Width = 99;
            // 
            // RecordIDD
            // 
            this.RecordIDD.DataPropertyName = "RecordID";
            this.RecordIDD.HeaderText = "RecordID";
            this.RecordIDD.Name = "RecordIDD";
            this.RecordIDD.ReadOnly = true;
            this.RecordIDD.Visible = false;
            this.RecordIDD.Width = 78;
            // 
            // HeaderIDD
            // 
            this.HeaderIDD.DataPropertyName = "HeaderID";
            this.HeaderIDD.HeaderText = "HeaderID";
            this.HeaderIDD.Name = "HeaderIDD";
            this.HeaderIDD.ReadOnly = true;
            this.HeaderIDD.Visible = false;
            this.HeaderIDD.Width = 78;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 328);
            this.tableLayoutPanel1.TabIndex = 37;
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
            this.tglkembaligdg,
            this.sales,
            this.catatan,
            this.print,
            this.rowid,
            this.recordid,
            this.kodesales});
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
            this.nobukti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nobukti.DataPropertyName = "NoBukti";
            this.nobukti.HeaderText = "NoBukti";
            this.nobukti.Name = "nobukti";
            this.nobukti.ReadOnly = true;
            // 
            // tglkembalipj
            // 
            this.tglkembalipj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tglkembalipj.DataPropertyName = "TglKembaliPenjualan";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.tglkembalipj.DefaultCellStyle = dataGridViewCellStyle1;
            this.tglkembalipj.HeaderText = "Tgl. Kembali";
            this.tglkembalipj.Name = "tglkembalipj";
            this.tglkembalipj.ReadOnly = true;
            // 
            // tglkembaligdg
            // 
            this.tglkembaligdg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tglkembaligdg.DataPropertyName = "TglKembaliGudang";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.tglkembaligdg.DefaultCellStyle = dataGridViewCellStyle2;
            this.tglkembaligdg.HeaderText = "Tgl. Kembali Gudang";
            this.tglkembaligdg.Name = "tglkembaligdg";
            this.tglkembaligdg.ReadOnly = true;
            // 
            // sales
            // 
            this.sales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sales.DataPropertyName = "NamaSales";
            this.sales.HeaderText = "Sales";
            this.sales.Name = "sales";
            this.sales.ReadOnly = true;
            // 
            // catatan
            // 
            this.catatan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catatan.DataPropertyName = "Catatan";
            this.catatan.HeaderText = "Catatan";
            this.catatan.Name = "catatan";
            this.catatan.ReadOnly = true;
            // 
            // print
            // 
            this.print.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.print.DataPropertyName = "NPrint";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.print.DefaultCellStyle = dataGridViewCellStyle3;
            this.print.HeaderText = "Print";
            this.print.Name = "print";
            this.print.ReadOnly = true;
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
            this.recordid.HeaderText = "ReocrdID";
            this.recordid.Name = "recordid";
            this.recordid.ReadOnly = true;
            this.recordid.Visible = false;
            // 
            // kodesales
            // 
            this.kodesales.DataPropertyName = "KodeSales";
            this.kodesales.HeaderText = "Kode Sales";
            this.kodesales.Name = "kodesales";
            this.kodesales.ReadOnly = true;
            this.kodesales.Visible = false;
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.AllowUserToAddRows = false;
            this.dataGridDetail.AllowUserToDeleteRows = false;
            this.dataGridDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.nopinjam,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.peminjamanid,
            this.dataGridViewTextBoxColumn7,
            this.transactionid,
            this.idpinjam});
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
            this.dataGridDetail.Click += new System.EventHandler(this.dataGridDetail_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NamaStok";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nama Stok";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SatJual";
            this.dataGridViewTextBoxColumn2.HeaderText = "Satuan";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // nopinjam
            // 
            this.nopinjam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nopinjam.DataPropertyName = "NoBukti";
            this.nopinjam.HeaderText = "Nomor Pinjam";
            this.nopinjam.Name = "nopinjam";
            this.nopinjam.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "QtyKembali";
            this.dataGridViewTextBoxColumn3.HeaderText = "Q. Kembali";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Catatan";
            this.dataGridViewTextBoxColumn4.HeaderText = "Catatan";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RowID";
            this.dataGridViewTextBoxColumn5.HeaderText = "RowID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "HeaderID";
            this.dataGridViewTextBoxColumn6.HeaderText = "HeaderID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // peminjamanid
            // 
            this.peminjamanid.DataPropertyName = "PeminjamanID";
            this.peminjamanid.HeaderText = "PeminjamanID";
            this.peminjamanid.Name = "peminjamanid";
            this.peminjamanid.ReadOnly = true;
            this.peminjamanid.Visible = false;
            this.peminjamanid.Width = 116;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "RecordID";
            this.dataGridViewTextBoxColumn7.HeaderText = "RecordID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 88;
            // 
            // transactionid
            // 
            this.transactionid.DataPropertyName = "TransactionID";
            this.transactionid.HeaderText = "TransactionID";
            this.transactionid.Name = "transactionid";
            this.transactionid.ReadOnly = true;
            this.transactionid.Visible = false;
            this.transactionid.Width = 123;
            // 
            // idpinjam
            // 
            this.idpinjam.DataPropertyName = "IDPinjam";
            this.idpinjam.HeaderText = "IDPinjam";
            this.idpinjam.Name = "idpinjam";
            this.idpinjam.ReadOnly = true;
            this.idpinjam.Visible = false;
            this.idpinjam.Width = 88;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(742, 451);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tgl Pengembalian Peminjaman Barang";
            // 
            // rgbTglDO
            // 
            this.rgbTglDO.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglDO.FromDate = null;
            this.rgbTglDO.Location = new System.Drawing.Point(257, 66);
            this.rgbTglDO.Name = "rgbTglDO";
            this.rgbTglDO.Size = new System.Drawing.Size(237, 22);
            this.rgbTglDO.TabIndex = 0;
            this.rgbTglDO.ToDate = null;
            this.rgbTglDO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTglDO_KeyPress);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(500, 66);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "F12 - Isi Tanggal Kembali ke Gudang";
            // 
            // txtInit
            // 
            this.txtInit.Location = new System.Drawing.Point(756, 65);
            this.txtInit.MaxLength = 3;
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(100, 20);
            this.txtInit.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(628, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "Init Perusahaan";
            // 
            // frmBarangKembaliKeGudang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(866, 498);
            this.Controls.Add(this.txtInit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgbTglDO);
            this.Controls.Add(this.cmdSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBarangKembaliKeGudang";
            this.Text = "Pengembalian Pinjaman Barang";
            this.Title = "Pengembalian Pinjaman Barang";
            this.Load += new System.EventHandler(this.frmBarangKembaliKeGudang_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rgbTglDO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtInit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPeminjamanDetail)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridPeminjamanDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyKembali;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyKeluarGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatatanD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderIDD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Toko.Controls.CustomGridView dataGridHeader;
        private ISA.Toko.Controls.CustomGridView dataGridDetail;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rgbTglDO;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nobukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglkembalipj;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglkembaligdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn print;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowid;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordid;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodesales;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nopinjam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn peminjamanid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpinjam;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.Label label3;
    }
}
