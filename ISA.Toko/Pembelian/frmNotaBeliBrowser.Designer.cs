namespace ISA.Toko.Pembelian
{
    partial class frmNotaBeliBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaBeliBrowser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.rgbTglNota = new ISA.Toko.Controls.RangeDateBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridHeader = new ISA.Toko.Controls.CustomGridView();
            this.dataGridDetail = new ISA.Toko.Controls.CustomGridView();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgBeliAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailSyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JmlHrgBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDELETE = new ISA.Toko.Controls.CommandButton();
            this.cmdEDIT = new ISA.Toko.Controls.CommandButton();
            this.cmdADD = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.txtInit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Gudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pemasok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBeliAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expedisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderSyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 14);
            this.label5.TabIndex = 45;
            this.label5.Text = "Range tgl Nota:";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(389, 65);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rgbTglNota
            // 
            this.rgbTglNota.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglNota.FromDate = null;
            this.rgbTglNota.Location = new System.Drawing.Point(149, 66);
            this.rgbTglNota.Name = "rgbTglNota";
            this.rgbTglNota.Size = new System.Drawing.Size(257, 22);
            this.rgbTglNota.TabIndex = 0;
            this.rgbTglNota.ToDate = null;
            this.rgbTglNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTglNota_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridDetail, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 168);
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // dataGridHeader
            // 
            this.dataGridHeader.AllowUserToAddRows = false;
            this.dataGridHeader.AllowUserToDeleteRows = false;
            this.dataGridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Gudang,
            this.NoRequest,
            this.TglRequest,
            this.TglNota,
            this.Pemasok,
            this.RpBeli,
            this.RpBeliAck,
            this.Disc1,
            this.Disc2,
            this.Disc3,
            this.PPN,
            this.Expedisi,
            this.HeaderSyncFlag,
            this.HeaderRowID,
            this.TglTerima,
            this.RowIDop});
            this.dataGridHeader.Location = new System.Drawing.Point(3, 3);
            this.dataGridHeader.MultiSelect = false;
            this.dataGridHeader.Name = "dataGridHeader";
            this.dataGridHeader.ReadOnly = true;
            this.dataGridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridHeader.Size = new System.Drawing.Size(831, 78);
            this.dataGridHeader.StandardTab = true;
            this.dataGridHeader.TabIndex = 0;
            this.dataGridHeader.SelectionRowChanged += new System.EventHandler(this.dataGridHeader_SelectionRowChanged);
            this.dataGridHeader.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridHeader_CellFormatting);
            this.dataGridHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridHeader_KeyDown);
            this.dataGridHeader.Click += new System.EventHandler(this.dataGridHeader_Click);
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.AllowUserToAddRows = false;
            this.dataGridDetail.AllowUserToDeleteRows = false;
            this.dataGridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaBarang,
            this.Satuan,
            this.QtyNota,
            this.HrgBeli,
            this.HrgBeliAck,
            this.Catatan,
            this.DetailSyncFlag,
            this.DetailRowID,
            this.KodeGudang,
            this.JmlHrgBeli});
            this.dataGridDetail.Location = new System.Drawing.Point(3, 87);
            this.dataGridDetail.MultiSelect = false;
            this.dataGridDetail.Name = "dataGridDetail";
            this.dataGridDetail.ReadOnly = true;
            this.dataGridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDetail.Size = new System.Drawing.Size(831, 78);
            this.dataGridDetail.StandardTab = true;
            this.dataGridDetail.TabIndex = 1;
            this.dataGridDetail.SelectionRowChanged += new System.EventHandler(this.dataGridDetail_SelectionRowChanged);
            this.dataGridDetail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridDetail_CellFormatting);
            this.dataGridDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridDetail_KeyDown);
            this.dataGridDetail.Click += new System.EventHandler(this.dataGridDetail_Click);
            // 
            // NamaBarang
            // 
            this.NamaBarang.DataPropertyName = "NamaBarang";
            this.NamaBarang.HeaderText = "Nama Stok";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            this.NamaBarang.Width = 500;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "Satuan";
            this.Satuan.HeaderText = "Sat";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Width = 30;
            // 
            // QtyNota
            // 
            this.QtyNota.DataPropertyName = "QtyNota";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyNota.DefaultCellStyle = dataGridViewCellStyle7;
            this.QtyNota.HeaderText = "Q.Nota";
            this.QtyNota.Name = "QtyNota";
            this.QtyNota.ReadOnly = true;
            this.QtyNota.Width = 50;
            // 
            // HrgBeli
            // 
            this.HrgBeli.DataPropertyName = "HrgBeli";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HrgBeli.DefaultCellStyle = dataGridViewCellStyle8;
            this.HrgBeli.HeaderText = "Harga Beli";
            this.HrgBeli.Name = "HrgBeli";
            this.HrgBeli.ReadOnly = true;
            this.HrgBeli.Visible = false;
            this.HrgBeli.Width = 130;
            // 
            // HrgBeliAck
            // 
            this.HrgBeliAck.DataPropertyName = "HrgBeliAck";
            this.HrgBeliAck.HeaderText = "Harga Beli";
            this.HrgBeliAck.Name = "HrgBeliAck";
            this.HrgBeliAck.ReadOnly = true;
            this.HrgBeliAck.Width = 130;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.ReadOnly = true;
            // 
            // DetailSyncFlag
            // 
            this.DetailSyncFlag.DataPropertyName = "SyncFlag";
            this.DetailSyncFlag.HeaderText = "Match";
            this.DetailSyncFlag.Name = "DetailSyncFlag";
            this.DetailSyncFlag.ReadOnly = true;
            this.DetailSyncFlag.Width = 50;
            // 
            // DetailRowID
            // 
            this.DetailRowID.DataPropertyName = "RowID";
            this.DetailRowID.HeaderText = "RowID";
            this.DetailRowID.Name = "DetailRowID";
            this.DetailRowID.ReadOnly = true;
            this.DetailRowID.Visible = false;
            // 
            // KodeGudang
            // 
            this.KodeGudang.DataPropertyName = "KodeGudang";
            this.KodeGudang.HeaderText = "KodeGudang";
            this.KodeGudang.Name = "KodeGudang";
            this.KodeGudang.ReadOnly = true;
            this.KodeGudang.Visible = false;
            // 
            // JmlHrgBeli
            // 
            this.JmlHrgBeli.DataPropertyName = "JmlHrgBeli";
            this.JmlHrgBeli.HeaderText = "JmlHrgBeli";
            this.JmlHrgBeli.Name = "JmlHrgBeli";
            this.JmlHrgBeli.ReadOnly = true;
            this.JmlHrgBeli.Visible = false;
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(259, 289);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 4;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(136, 289);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 3;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(12, 289);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 2;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(746, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblNamaBarang
            // 
            this.lblNamaBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNamaBarang.AutoSize = true;
            this.lblNamaBarang.Location = new System.Drawing.Point(12, 265);
            this.lblNamaBarang.Name = "lblNamaBarang";
            this.lblNamaBarang.Size = new System.Drawing.Size(55, 14);
            this.lblNamaBarang.TabIndex = 51;
            this.lblNamaBarang.Text = "\"Barang\"";
            // 
            // txtInit
            // 
            this.txtInit.Location = new System.Drawing.Point(743, 67);
            this.txtInit.MaxLength = 3;
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(100, 20);
            this.txtInit.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 52;
            this.label3.Text = "Init Perusahaan";
            // 
            // Gudang
            // 
            this.Gudang.DataPropertyName = "Gudang";
            this.Gudang.HeaderText = "Gdg";
            this.Gudang.Name = "Gudang";
            this.Gudang.ReadOnly = true;
            this.Gudang.Width = 30;
            // 
            // NoRequest
            // 
            this.NoRequest.DataPropertyName = "NoRequest";
            this.NoRequest.HeaderText = "No.RQ";
            this.NoRequest.Name = "NoRequest";
            this.NoRequest.ReadOnly = true;
            this.NoRequest.Width = 80;
            // 
            // TglRequest
            // 
            this.TglRequest.DataPropertyName = "TglRequest";
            this.TglRequest.HeaderText = "Tgl.RQ";
            this.TglRequest.Name = "TglRequest";
            this.TglRequest.ReadOnly = true;
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglNota";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglNota.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglNota.HeaderText = "Tgl.Nota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            // 
            // Pemasok
            // 
            this.Pemasok.DataPropertyName = "Pemasok";
            this.Pemasok.HeaderText = "Pemasok";
            this.Pemasok.Name = "Pemasok";
            this.Pemasok.ReadOnly = true;
            // 
            // RpBeli
            // 
            this.RpBeli.DataPropertyName = "RpBeli";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RpBeli.DefaultCellStyle = dataGridViewCellStyle2;
            this.RpBeli.HeaderText = "Rp.Beli";
            this.RpBeli.Name = "RpBeli";
            this.RpBeli.ReadOnly = true;
            this.RpBeli.Visible = false;
            this.RpBeli.Width = 120;
            // 
            // RpBeliAck
            // 
            this.RpBeliAck.DataPropertyName = "RpBeliAck";
            this.RpBeliAck.HeaderText = "Rp.Beli";
            this.RpBeliAck.Name = "RpBeliAck";
            this.RpBeliAck.ReadOnly = true;
            this.RpBeliAck.Width = 120;
            // 
            // Disc1
            // 
            this.Disc1.DataPropertyName = "Disc1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Disc1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Disc1.HeaderText = "Disc #1";
            this.Disc1.Name = "Disc1";
            this.Disc1.ReadOnly = true;
            // 
            // Disc2
            // 
            this.Disc2.DataPropertyName = "Disc2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Disc2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Disc2.HeaderText = "Disc #2";
            this.Disc2.Name = "Disc2";
            this.Disc2.ReadOnly = true;
            // 
            // Disc3
            // 
            this.Disc3.DataPropertyName = "Disc3";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Disc3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Disc3.HeaderText = "Disc #3";
            this.Disc3.Name = "Disc3";
            this.Disc3.ReadOnly = true;
            // 
            // PPN
            // 
            this.PPN.DataPropertyName = "PPN";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PPN.DefaultCellStyle = dataGridViewCellStyle6;
            this.PPN.HeaderText = "PPN";
            this.PPN.Name = "PPN";
            this.PPN.ReadOnly = true;
            // 
            // Expedisi
            // 
            this.Expedisi.DataPropertyName = "Expedisi";
            this.Expedisi.HeaderText = "Expedisi";
            this.Expedisi.Name = "Expedisi";
            this.Expedisi.ReadOnly = true;
            // 
            // HeaderSyncFlag
            // 
            this.HeaderSyncFlag.DataPropertyName = "SyncFlag";
            this.HeaderSyncFlag.HeaderText = "Match";
            this.HeaderSyncFlag.Name = "HeaderSyncFlag";
            this.HeaderSyncFlag.ReadOnly = true;
            this.HeaderSyncFlag.Width = 50;
            // 
            // HeaderRowID
            // 
            this.HeaderRowID.DataPropertyName = "RowID";
            this.HeaderRowID.HeaderText = "RowID";
            this.HeaderRowID.Name = "HeaderRowID";
            this.HeaderRowID.ReadOnly = true;
            this.HeaderRowID.Visible = false;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            this.TglTerima.HeaderText = "TglTerima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            this.TglTerima.Visible = false;
            // 
            // RowIDop
            // 
            this.RowIDop.DataPropertyName = "RowIDop";
            this.RowIDop.HeaderText = "Row ID2";
            this.RowIDop.Name = "RowIDop";
            this.RowIDop.ReadOnly = true;
            this.RowIDop.Visible = false;
            // 
            // frmNotaBeliBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(858, 341);
            this.Controls.Add(this.txtInit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNamaBarang);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rgbTglNota);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNotaBeliBrowser";
            this.Text = "Nota Pembelian";
            this.Title = "Nota Pembelian";
            this.Load += new System.EventHandler(this.frmNotaBeliBrowser_Load);
            this.Controls.SetChildIndex(this.rgbTglNota, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lblNamaBarang, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtInit, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.RangeDateBox rgbTglNota;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Toko.Controls.CustomGridView dataGridHeader;
        private ISA.Toko.Controls.CustomGridView dataGridDetail;
        private ISA.Toko.Controls.CommandButton cmdDELETE;
        private ISA.Toko.Controls.CommandButton cmdEDIT;
        private ISA.Toko.Controls.CommandButton cmdADD;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label lblNamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgBeliAck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailSyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlHrgBeli;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pemasok;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBeliAck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expedisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderSyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDop;
    }
}
