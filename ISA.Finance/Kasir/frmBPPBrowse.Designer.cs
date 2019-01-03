namespace ISA.Finance.Kasir
{
    partial class frmBPPBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBPPBrowse));
            this.DataGridViewBPPDetail = new ISA.Controls.CustomGridView();
            this.HeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglBpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdWil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlagAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DataGridViewBpp = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBpp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaCollector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BanyakLembar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCollector = new ISA.Controls.CommonTextBox();
            this.cmbsearch = new ISA.Controls.CommandButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbClose = new ISA.Controls.CommandButton();
            this.cmbDownload = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBPPDetail)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBpp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridViewBPPDetail
            // 
            this.DataGridViewBPPDetail.AllowUserToAddRows = false;
            this.DataGridViewBPPDetail.AllowUserToDeleteRows = false;
            this.DataGridViewBPPDetail.AllowUserToResizeColumns = false;
            this.DataGridViewBPPDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.DataGridViewBPPDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewBPPDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewBPPDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewBPPDetail.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.DataGridViewBPPDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridViewBPPDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewBPPDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeaderID,
            this.RowIDDetail,
            this.NoBpp,
            this.TglBpp,
            this.NamaToko,
            this.IdWil,
            this.NoNota,
            this.TglNota,
            this.RpNota,
            this.JenisTransaksi,
            this.RpBayar,
            this.Keterangan,
            this.FlagAudit,
            this.KetAudit});
            this.DataGridViewBPPDetail.Location = new System.Drawing.Point(3, 190);
            this.DataGridViewBPPDetail.MultiSelect = false;
            this.DataGridViewBPPDetail.Name = "DataGridViewBPPDetail";
            this.DataGridViewBPPDetail.ReadOnly = true;
            this.DataGridViewBPPDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.DataGridViewBPPDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridViewBPPDetail.Size = new System.Drawing.Size(870, 182);
            this.DataGridViewBPPDetail.StandardTab = true;
            this.DataGridViewBPPDetail.TabIndex = 1;
            // 
            // HeaderID
            // 
            this.HeaderID.DataPropertyName = "HeaderID";
            this.HeaderID.HeaderText = "HeaderID";
            this.HeaderID.Name = "HeaderID";
            this.HeaderID.ReadOnly = true;
            this.HeaderID.Visible = false;
            // 
            // RowIDDetail
            // 
            this.RowIDDetail.DataPropertyName = "RowID";
            this.RowIDDetail.HeaderText = "RowID";
            this.RowIDDetail.Name = "RowIDDetail";
            this.RowIDDetail.ReadOnly = true;
            this.RowIDDetail.Visible = false;
            // 
            // NoBpp
            // 
            this.NoBpp.DataPropertyName = "NoBPP";
            this.NoBpp.HeaderText = "No BPP";
            this.NoBpp.Name = "NoBpp";
            this.NoBpp.ReadOnly = true;
            this.NoBpp.Width = 150;
            // 
            // TglBpp
            // 
            this.TglBpp.DataPropertyName = "TglBPP";
            this.TglBpp.HeaderText = "TanggalBPP";
            this.TglBpp.Name = "TglBpp";
            this.TglBpp.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 200;
            // 
            // IdWil
            // 
            this.IdWil.DataPropertyName = "WilID";
            this.IdWil.HeaderText = "Wil ID";
            this.IdWil.Name = "IdWil";
            this.IdWil.ReadOnly = true;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "No. Nota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglNota";
            this.TglNota.HeaderText = "Tgl Nota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            // 
            // RpNota
            // 
            this.RpNota.DataPropertyName = "RpNota";
            this.RpNota.HeaderText = "Rp. Nota";
            this.RpNota.Name = "RpNota";
            this.RpNota.ReadOnly = true;
            // 
            // JenisTransaksi
            // 
            this.JenisTransaksi.DataPropertyName = "JenisTransaksi";
            this.JenisTransaksi.HeaderText = "Jenis Transaksi";
            this.JenisTransaksi.Name = "JenisTransaksi";
            this.JenisTransaksi.ReadOnly = true;
            this.JenisTransaksi.Width = 150;
            // 
            // RpBayar
            // 
            this.RpBayar.DataPropertyName = "RpBayar";
            this.RpBayar.HeaderText = "Rp. Bayar";
            this.RpBayar.Name = "RpBayar";
            this.RpBayar.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 200;
            // 
            // FlagAudit
            // 
            this.FlagAudit.DataPropertyName = "FlagAudit";
            this.FlagAudit.HeaderText = "Flag Audit";
            this.FlagAudit.Name = "FlagAudit";
            this.FlagAudit.ReadOnly = true;
            // 
            // KetAudit
            // 
            this.KetAudit.DataPropertyName = "KetAudit";
            this.KetAudit.HeaderText = "Keterangan Audit";
            this.KetAudit.Name = "KetAudit";
            this.KetAudit.ReadOnly = true;
            this.KetAudit.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Collector";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DataGridViewBpp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.23958F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.76042F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(969, 425);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // DataGridViewBpp
            // 
            this.DataGridViewBpp.AllowUserToAddRows = false;
            this.DataGridViewBpp.AllowUserToDeleteRows = false;
            this.DataGridViewBpp.AllowUserToResizeColumns = false;
            this.DataGridViewBpp.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            this.DataGridViewBpp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewBpp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewBpp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewBpp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewBpp.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.DataGridViewBpp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridViewBpp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewBpp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NoBpp1,
            this.CollectorID,
            this.NamaCollector,
            this.KodeGudang,
            this.BanyakLembar,
            this.SyncFlag});
            this.DataGridViewBpp.Location = new System.Drawing.Point(3, 3);
            this.DataGridViewBpp.MultiSelect = false;
            this.DataGridViewBpp.Name = "DataGridViewBpp";
            this.DataGridViewBpp.ReadOnly = true;
            this.DataGridViewBpp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.DataGridViewBpp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridViewBpp.Size = new System.Drawing.Size(963, 152);
            this.DataGridViewBpp.StandardTab = true;
            this.DataGridViewBpp.TabIndex = 0;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NoBpp1
            // 
            this.NoBpp1.DataPropertyName = "NoBPPAwal";
            this.NoBpp1.HeaderText = "No BPP Awal";
            this.NoBpp1.Name = "NoBpp1";
            this.NoBpp1.ReadOnly = true;
            // 
            // CollectorID
            // 
            this.CollectorID.DataPropertyName = "KodeCollector";
            this.CollectorID.HeaderText = "Collector ID";
            this.CollectorID.Name = "CollectorID";
            this.CollectorID.ReadOnly = true;
            // 
            // NamaCollector
            // 
            this.NamaCollector.DataPropertyName = "Nama";
            this.NamaCollector.HeaderText = "Nama Collector";
            this.NamaCollector.Name = "NamaCollector";
            this.NamaCollector.ReadOnly = true;
            // 
            // KodeGudang
            // 
            this.KodeGudang.DataPropertyName = "GudangID";
            this.KodeGudang.HeaderText = "Kode Gudang";
            this.KodeGudang.Name = "KodeGudang";
            this.KodeGudang.ReadOnly = true;
            // 
            // BanyakLembar
            // 
            this.BanyakLembar.DataPropertyName = "BanyakLembar";
            this.BanyakLembar.HeaderText = "Lembar";
            this.BanyakLembar.Name = "BanyakLembar";
            this.BanyakLembar.ReadOnly = true;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.AllowUserToResizeColumns = false;
            this.customGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.customGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.customGridView1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.customGridView1.Location = new System.Drawing.Point(3, 161);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(963, 261);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "HeaderID";
            this.dataGridViewTextBoxColumn1.HeaderText = "HeaderID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RowID";
            this.dataGridViewTextBoxColumn2.HeaderText = "RowID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NoBPP";
            this.dataGridViewTextBoxColumn3.HeaderText = "No BPP";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TglBPP";
            this.dataGridViewTextBoxColumn4.HeaderText = "TanggalBPP";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NamaToko";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nama Toko";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "WilID";
            this.dataGridViewTextBoxColumn6.HeaderText = "Wil ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NoNota";
            this.dataGridViewTextBoxColumn7.HeaderText = "No. Nota";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TglNota";
            this.dataGridViewTextBoxColumn8.HeaderText = "Tgl Nota";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "RpNota";
            this.dataGridViewTextBoxColumn9.HeaderText = "Rp. Nota";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "JenisTransaksi";
            this.dataGridViewTextBoxColumn10.HeaderText = "Jenis Transaksi";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "RpBayar";
            this.dataGridViewTextBoxColumn11.HeaderText = "Rp. Bayar";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Keterangan";
            this.dataGridViewTextBoxColumn12.HeaderText = "Keterangan";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "FlagAudit";
            this.dataGridViewTextBoxColumn13.HeaderText = "Flag Audit";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "KetAudit";
            this.dataGridViewTextBoxColumn14.HeaderText = "Keterangan Audit";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // tbCollector
            // 
            this.tbCollector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCollector.Location = new System.Drawing.Point(94, 41);
            this.tbCollector.Name = "tbCollector";
            this.tbCollector.Size = new System.Drawing.Size(213, 20);
            this.tbCollector.TabIndex = 15;
            this.tbCollector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCollector_KeyDown);
            // 
            // cmbsearch
            // 
            this.cmbsearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmbsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbsearch.Image = ((System.Drawing.Image)(resources.GetObject("cmbsearch.Image")));
            this.cmbsearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmbsearch.Location = new System.Drawing.Point(328, 39);
            this.cmbsearch.Name = "cmbsearch";
            this.cmbsearch.Size = new System.Drawing.Size(80, 23);
            this.cmbsearch.TabIndex = 16;
            this.cmbsearch.Text = "Search";
            this.cmbsearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbsearch.UseVisualStyleBackColor = true;
            this.cmbsearch.Click += new System.EventHandler(this.cmbsearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbClose);
            this.panel1.Controls.Add(this.cmbDownload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 52);
            this.panel1.TabIndex = 17;
            // 
            // cmbClose
            // 
            this.cmbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmbClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmbClose.Image = ((System.Drawing.Image)(resources.GetObject("cmbClose.Image")));
            this.cmbClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbClose.Location = new System.Drawing.Point(915, 6);
            this.cmbClose.Name = "cmbClose";
            this.cmbClose.Size = new System.Drawing.Size(100, 40);
            this.cmbClose.TabIndex = 1;
            this.cmbClose.Text = "CLOSE";
            this.cmbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbClose.UseVisualStyleBackColor = true;
            this.cmbClose.Click += new System.EventHandler(this.cmbClose_Click);
            // 
            // cmbDownload
            // 
            this.cmbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmbDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmbDownload.Image")));
            this.cmbDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbDownload.Location = new System.Drawing.Point(34, 5);
            this.cmbDownload.Name = "cmbDownload";
            this.cmbDownload.Size = new System.Drawing.Size(128, 40);
            this.cmbDownload.TabIndex = 0;
            this.cmbDownload.Text = "DOWNLOAD";
            this.cmbDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbDownload.UseVisualStyleBackColor = true;
            this.cmbDownload.Click += new System.EventHandler(this.cmbDownload_Click);
            // 
            // frmBPPBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbsearch);
            this.Controls.Add(this.tbCollector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmBPPBrowse";
            this.Text = "frmBPPBrowse";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbCollector, 0);
            this.Controls.SetChildIndex(this.cmbsearch, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBPPDetail)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBpp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView DataGridViewBPPDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglBpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdWil;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlagAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetAudit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView DataGridViewBpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBpp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaCollector;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn BanyakLembar;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private ISA.Controls.CommonTextBox tbCollector;
        private ISA.Controls.CommandButton cmbsearch;
        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.CommandButton cmbDownload;
        private ISA.Controls.CommandButton cmbClose;
    }
}