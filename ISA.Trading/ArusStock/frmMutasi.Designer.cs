namespace ISA.Trading.ArusStock
{
    partial class frmMutasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMutasi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rgbTglDO = new ISA.Trading.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridMutasiHeader = new ISA.Trading.Controls.CustomGridView();
            this.TglMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomorMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MutasiPlus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MutasiMinus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeteranganMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MutasiID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridMutasiDetail = new ISA.Trading.Controls.CustomGridView();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tambah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kurang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMutasiD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hppSolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipeArahMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlagD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAdd = new ISA.Trading.Controls.CommandButton();
            this.cmdEdit = new ISA.Trading.Controls.CommandButton();
            this.cmdDelete = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.lblNamaStok = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPlus = new System.Windows.Forms.TextBox();
            this.txtTotalMinus = new System.Windows.Forms.TextBox();
            this.txtInit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMutasiHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMutasiDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Range Tgl Mutasi";
            // 
            // rgbTglDO
            // 
            this.rgbTglDO.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglDO.FromDate = null;
            this.rgbTglDO.Location = new System.Drawing.Point(142, 66);
            this.rgbTglDO.Name = "rgbTglDO";
            this.rgbTglDO.Size = new System.Drawing.Size(240, 22);
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
            this.cmdSearch.Location = new System.Drawing.Point(388, 63);
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
            this.tableLayoutPanel1.Controls.Add(this.dataGridMutasiHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridMutasiDetail, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 352);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dataGridMutasiHeader
            // 
            this.dataGridMutasiHeader.AllowUserToAddRows = false;
            this.dataGridMutasiHeader.AllowUserToDeleteRows = false;
            this.dataGridMutasiHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMutasiHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglMutasi,
            this.NomorMutasi,
            this.Type,
            this.MutasiPlus,
            this.MutasiMinus,
            this.KeteranganMutasi,
            this.M,
            this.MutasiID,
            this.RowID,
            this.LAudit,
            this.SyncFlag});
            this.dataGridMutasiHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMutasiHeader.Location = new System.Drawing.Point(3, 3);
            this.dataGridMutasiHeader.MultiSelect = false;
            this.dataGridMutasiHeader.Name = "dataGridMutasiHeader";
            this.dataGridMutasiHeader.ReadOnly = true;
            this.dataGridMutasiHeader.RowHeadersVisible = false;
            this.dataGridMutasiHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridMutasiHeader.Size = new System.Drawing.Size(870, 159);
            this.dataGridMutasiHeader.StandardTab = true;
            this.dataGridMutasiHeader.TabIndex = 3;
            this.dataGridMutasiHeader.SelectionRowChanged += new System.EventHandler(this.dataGridMutasiHeader_SelectionRowChanged);
            this.dataGridMutasiHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridMutasiHeader_KeyDown);
            this.dataGridMutasiHeader.Click += new System.EventHandler(this.dataGridMutasiHeader_Click);
            // 
            // TglMutasi
            // 
            this.TglMutasi.DataPropertyName = "TglMutasi";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.TglMutasi.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglMutasi.FillWeight = 380.7107F;
            this.TglMutasi.HeaderText = "Tgl Mutasi";
            this.TglMutasi.Name = "TglMutasi";
            this.TglMutasi.ReadOnly = true;
            this.TglMutasi.Width = 120;
            // 
            // NomorMutasi
            // 
            this.NomorMutasi.DataPropertyName = "NomorMutasi";
            this.NomorMutasi.FillWeight = 43.85787F;
            this.NomorMutasi.HeaderText = "Nomor Mutasi";
            this.NomorMutasi.Name = "NomorMutasi";
            this.NomorMutasi.ReadOnly = true;
            this.NomorMutasi.Width = 150;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "TipeMutasi";
            this.Type.FillWeight = 43.85787F;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 57;
            // 
            // MutasiPlus
            // 
            this.MutasiPlus.DataPropertyName = "MutasiPlus";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MutasiPlus.DefaultCellStyle = dataGridViewCellStyle2;
            this.MutasiPlus.FillWeight = 43.85787F;
            this.MutasiPlus.HeaderText = "MutasiPlus";
            this.MutasiPlus.Name = "MutasiPlus";
            this.MutasiPlus.ReadOnly = true;
            // 
            // MutasiMinus
            // 
            this.MutasiMinus.DataPropertyName = "MutasiMinus";
            this.MutasiMinus.FillWeight = 43.85787F;
            this.MutasiMinus.HeaderText = "MutasiMinus";
            this.MutasiMinus.Name = "MutasiMinus";
            this.MutasiMinus.ReadOnly = true;
            // 
            // KeteranganMutasi
            // 
            this.KeteranganMutasi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KeteranganMutasi.DataPropertyName = "KeteranganMutasi";
            this.KeteranganMutasi.FillWeight = 43.85787F;
            this.KeteranganMutasi.HeaderText = "Keterangan Mutasi";
            this.KeteranganMutasi.Name = "KeteranganMutasi";
            this.KeteranganMutasi.ReadOnly = true;
            // 
            // M
            // 
            this.M.DataPropertyName = "M";
            this.M.HeaderText = "M";
            this.M.Name = "M";
            this.M.ReadOnly = true;
            this.M.Width = 20;
            // 
            // MutasiID
            // 
            this.MutasiID.DataPropertyName = "MutasiID";
            this.MutasiID.HeaderText = "MutasiID";
            this.MutasiID.Name = "MutasiID";
            this.MutasiID.ReadOnly = true;
            this.MutasiID.Visible = false;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // LAudit
            // 
            this.LAudit.DataPropertyName = "LAudit";
            this.LAudit.HeaderText = "LAudit";
            this.LAudit.Name = "LAudit";
            this.LAudit.ReadOnly = true;
            this.LAudit.Visible = false;
            this.LAudit.Width = 20;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SyncFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SyncFlag.Visible = false;
            this.SyncFlag.Width = 30;
            // 
            // dataGridMutasiDetail
            // 
            this.dataGridMutasiDetail.AllowUserToAddRows = false;
            this.dataGridMutasiDetail.AllowUserToDeleteRows = false;
            this.dataGridMutasiDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMutasiDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaStok,
            this.Tambah,
            this.Kurang,
            this.Sat,
            this.Keterangan,
            this.TglMutasiD,
            this.hppSolo,
            this.RowIDD,
            this.KodeBarang,
            this.QtyMutasi,
            this.Gudang,
            this.TipeArahMutasi,
            this.SyncFlagD});
            this.dataGridMutasiDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMutasiDetail.Location = new System.Drawing.Point(3, 190);
            this.dataGridMutasiDetail.MultiSelect = false;
            this.dataGridMutasiDetail.Name = "dataGridMutasiDetail";
            this.dataGridMutasiDetail.ReadOnly = true;
            this.dataGridMutasiDetail.RowHeadersVisible = false;
            this.dataGridMutasiDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridMutasiDetail.Size = new System.Drawing.Size(870, 159);
            this.dataGridMutasiDetail.StandardTab = true;
            this.dataGridMutasiDetail.TabIndex = 4;
            this.dataGridMutasiDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridMutasiDetail_KeyDown);
            this.dataGridMutasiDetail.Click += new System.EventHandler(this.dataGridMutasiDetail_Click);
            // 
            // NamaStok
            // 
            this.NamaStok.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            // 
            // Tambah
            // 
            this.Tambah.DataPropertyName = "Tambah";
            this.Tambah.HeaderText = "Tambah";
            this.Tambah.Name = "Tambah";
            this.Tambah.ReadOnly = true;
            this.Tambah.Width = 113;
            // 
            // Kurang
            // 
            this.Kurang.DataPropertyName = "Kurang";
            this.Kurang.HeaderText = "Kurang";
            this.Kurang.Name = "Kurang";
            this.Kurang.ReadOnly = true;
            this.Kurang.Width = 112;
            // 
            // Sat
            // 
            this.Sat.DataPropertyName = "Satuan";
            this.Sat.HeaderText = "Sat";
            this.Sat.Name = "Sat";
            this.Sat.ReadOnly = true;
            this.Sat.Width = 113;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Visible = false;
            this.Keterangan.Width = 112;
            // 
            // TglMutasiD
            // 
            this.TglMutasiD.DataPropertyName = "TglMutasi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.TglMutasiD.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglMutasiD.HeaderText = "Tgl Mutasi";
            this.TglMutasiD.Name = "TglMutasiD";
            this.TglMutasiD.ReadOnly = true;
            this.TglMutasiD.Visible = false;
            // 
            // hppSolo
            // 
            this.hppSolo.DataPropertyName = "HPPSolo";
            dataGridViewCellStyle4.Format = "#,##0";
            dataGridViewCellStyle4.NullValue = null;
            this.hppSolo.DefaultCellStyle = dataGridViewCellStyle4;
            this.hppSolo.HeaderText = "HPPSolo";
            this.hppSolo.Name = "hppSolo";
            this.hppSolo.ReadOnly = true;
            this.hppSolo.Width = 113;
            // 
            // RowIDD
            // 
            this.RowIDD.DataPropertyName = "RowID";
            this.RowIDD.HeaderText = "RowID";
            this.RowIDD.Name = "RowIDD";
            this.RowIDD.ReadOnly = true;
            this.RowIDD.Visible = false;
            // 
            // KodeBarang
            // 
            this.KodeBarang.DataPropertyName = "KodeBarang";
            this.KodeBarang.HeaderText = "KodeBarang";
            this.KodeBarang.Name = "KodeBarang";
            this.KodeBarang.ReadOnly = true;
            this.KodeBarang.Visible = false;
            // 
            // QtyMutasi
            // 
            this.QtyMutasi.DataPropertyName = "QtyMutasi";
            this.QtyMutasi.HeaderText = "QtyMutasi";
            this.QtyMutasi.Name = "QtyMutasi";
            this.QtyMutasi.ReadOnly = true;
            this.QtyMutasi.Visible = false;
            // 
            // Gudang
            // 
            this.Gudang.DataPropertyName = "Gudang";
            this.Gudang.HeaderText = "KodeGudang";
            this.Gudang.Name = "Gudang";
            this.Gudang.ReadOnly = true;
            this.Gudang.Visible = false;
            // 
            // TipeArahMutasi
            // 
            this.TipeArahMutasi.DataPropertyName = "TipeArahMutasi";
            this.TipeArahMutasi.HeaderText = "TipeArahMutasi";
            this.TipeArahMutasi.Name = "TipeArahMutasi";
            this.TipeArahMutasi.ReadOnly = true;
            this.TipeArahMutasi.Visible = false;
            this.TipeArahMutasi.Width = 112;
            // 
            // SyncFlagD
            // 
            this.SyncFlagD.DataPropertyName = "SyncFlag";
            this.SyncFlagD.HeaderText = "SyncFlag";
            this.SyncFlagD.Name = "SyncFlagD";
            this.SyncFlagD.ReadOnly = true;
            this.SyncFlagD.Visible = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(9, 503);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(125, 503);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 6;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(243, 503);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 7;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click_1);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(366, 503);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click_1);
            // 
            // lblNamaStok
            // 
            this.lblNamaStok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNamaStok.AutoSize = true;
            this.lblNamaStok.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaStok.Location = new System.Drawing.Point(9, 453);
            this.lblNamaStok.Name = "lblNamaStok";
            this.lblNamaStok.Size = new System.Drawing.Size(0, 16);
            this.lblNamaStok.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total Mutasi (+)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(630, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total Mutasi (-)";
            // 
            // txtTotalPlus
            // 
            this.txtTotalPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPlus.Location = new System.Drawing.Point(754, 475);
            this.txtTotalPlus.Name = "txtTotalPlus";
            this.txtTotalPlus.ReadOnly = true;
            this.txtTotalPlus.Size = new System.Drawing.Size(120, 20);
            this.txtTotalPlus.TabIndex = 12;
            this.txtTotalPlus.TabStop = false;
            this.txtTotalPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalMinus
            // 
            this.txtTotalMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalMinus.Location = new System.Drawing.Point(754, 512);
            this.txtTotalMinus.Name = "txtTotalMinus";
            this.txtTotalMinus.ReadOnly = true;
            this.txtTotalMinus.Size = new System.Drawing.Size(120, 20);
            this.txtTotalMinus.TabIndex = 13;
            this.txtTotalMinus.TabStop = false;
            this.txtTotalMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInit
            // 
            this.txtInit.Location = new System.Drawing.Point(774, 63);
            this.txtInit.MaxLength = 3;
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(100, 20);
            this.txtInit.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(646, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Init Perusahaan";
            // 
            // frmMutasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(880, 556);
            this.Controls.Add(this.txtInit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalMinus);
            this.Controls.Add(this.txtTotalPlus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNamaStok);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgbTglDO);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMutasi";
            this.Text = "Mutasi";
            this.Title = "Mutasi";
            this.Load += new System.EventHandler(this.frmMutasi_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rgbTglDO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lblNamaStok, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTotalPlus, 0);
            this.Controls.SetChildIndex(this.txtTotalMinus, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtInit, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMutasiHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMutasiDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rgbTglDO;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Trading.Controls.CustomGridView dataGridMutasiHeader;
        private ISA.Trading.Controls.CustomGridView dataGridMutasiDetail;
        private ISA.Trading.Controls.CommandButton cmdAdd;
        private ISA.Trading.Controls.CommandButton cmdEdit;
        private ISA.Trading.Controls.CommandButton cmdDelete;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomorMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn MutasiPlus;
        private System.Windows.Forms.DataGridViewTextBoxColumn MutasiMinus;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeteranganMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn MutasiID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAudit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tambah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kurang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMutasiD;
        private System.Windows.Forms.DataGridViewTextBoxColumn hppSolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipeArahMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlagD;
        private System.Windows.Forms.Label lblNamaStok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalPlus;
        private System.Windows.Forms.TextBox txtTotalMinus;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.Label label4;
    }
}
