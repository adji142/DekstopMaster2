namespace ISA.Toko.Master
{
    partial class frmStokBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokBarcode));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSebutanBengkel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bundle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kendaraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KelompokTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaTertera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merek1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dibungkus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumberDr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProsesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDREC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pasif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrediksiLamaKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HariRataRata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsiKoli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastHPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new ISA.Toko.Controls.CustomGridView();
            this.Nama_stok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kendaraaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedByD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.cmdEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.txtSearch = new ISA.Toko.Controls.CommonTextBox();
            this.CMDGenerate = new ISA.Toko.Controls.CommandButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.46734F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.532663F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1298, 367);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NamaStok,
            this.IDBarang,
            this.NamaSebutanBengkel,
            this.Satuan,
            this.Bundle,
            this.kendaraan,
            this.KelompokTransaksi,
            this.klpp,
            this.KodeSolo,
            this.NamaTertera,
            this.PartNo,
            this.Merek1,
            this.Dibungkus,
            this.SumberDr,
            this.ProsesID,
            this.Material,
            this.SatJual,
            this.KodeRak,
            this.KodeRak1,
            this.KodeRak2,
            this.JB,
            this.IDREC,
            this.Pasif,
            this.StatusAktif,
            this.SyncFlag,
            this.PrediksiLamaKirim,
            this.HariRataRata,
            this.StokMin,
            this.StokMax,
            this.IsiKoli,
            this.LastUpdatedBy,
            this.LastUpdatedTime,
            this.Sts,
            this.LastHPP,
            this.HrgJual,
            this.IDM});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1292, 180);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 500;
            // 
            // IDBarang
            // 
            this.IDBarang.DataPropertyName = "BarangID";
            this.IDBarang.HeaderText = "ID Barang";
            this.IDBarang.Name = "IDBarang";
            this.IDBarang.ReadOnly = true;
            this.IDBarang.Width = 200;
            // 
            // NamaSebutanBengkel
            // 
            this.NamaSebutanBengkel.DataPropertyName = "NamaSebutanBengkel";
            this.NamaSebutanBengkel.HeaderText = " Nama Sebutan Bengkel";
            this.NamaSebutanBengkel.Name = "NamaSebutanBengkel";
            this.NamaSebutanBengkel.ReadOnly = true;
            this.NamaSebutanBengkel.Width = 350;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "SatJual";
            this.Satuan.HeaderText = "Satuan";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Width = 75;
            // 
            // Bundle
            // 
            this.Bundle.DataPropertyName = "Bundle";
            this.Bundle.HeaderText = "Bundle";
            this.Bundle.Name = "Bundle";
            this.Bundle.ReadOnly = true;
            // 
            // kendaraan
            // 
            this.kendaraan.DataPropertyName = "Kendaraan";
            this.kendaraan.HeaderText = "kendaraan";
            this.kendaraan.Name = "kendaraan";
            this.kendaraan.ReadOnly = true;
            // 
            // KelompokTransaksi
            // 
            this.KelompokTransaksi.DataPropertyName = "KelompokTransaksi";
            this.KelompokTransaksi.HeaderText = "KelompokTransaksi";
            this.KelompokTransaksi.Name = "KelompokTransaksi";
            this.KelompokTransaksi.ReadOnly = true;
            this.KelompokTransaksi.Width = 200;
            // 
            // klpp
            // 
            this.klpp.DataPropertyName = "KodeBarang";
            this.klpp.HeaderText = "KLP";
            this.klpp.Name = "klpp";
            this.klpp.ReadOnly = true;
            this.klpp.Visible = false;
            this.klpp.Width = 75;
            // 
            // KodeSolo
            // 
            this.KodeSolo.DataPropertyName = "KodeSolo";
            this.KodeSolo.HeaderText = "KodeSolo";
            this.KodeSolo.Name = "KodeSolo";
            this.KodeSolo.ReadOnly = true;
            this.KodeSolo.Visible = false;
            // 
            // NamaTertera
            // 
            this.NamaTertera.DataPropertyName = "NamaTertera";
            this.NamaTertera.HeaderText = "NamaTertera";
            this.NamaTertera.Name = "NamaTertera";
            this.NamaTertera.ReadOnly = true;
            this.NamaTertera.Visible = false;
            // 
            // PartNo
            // 
            this.PartNo.DataPropertyName = "PartNo";
            this.PartNo.HeaderText = "PartNo";
            this.PartNo.Name = "PartNo";
            this.PartNo.ReadOnly = true;
            this.PartNo.Visible = false;
            // 
            // Merek1
            // 
            this.Merek1.DataPropertyName = "Merek";
            this.Merek1.HeaderText = "Merek";
            this.Merek1.Name = "Merek1";
            this.Merek1.ReadOnly = true;
            this.Merek1.Visible = false;
            // 
            // Dibungkus
            // 
            this.Dibungkus.DataPropertyName = "Dibungkus";
            this.Dibungkus.HeaderText = "Dibungkus";
            this.Dibungkus.Name = "Dibungkus";
            this.Dibungkus.ReadOnly = true;
            this.Dibungkus.Visible = false;
            // 
            // SumberDr
            // 
            this.SumberDr.DataPropertyName = "SumberDr";
            this.SumberDr.HeaderText = "SumberDr";
            this.SumberDr.Name = "SumberDr";
            this.SumberDr.ReadOnly = true;
            this.SumberDr.Visible = false;
            // 
            // ProsesID
            // 
            this.ProsesID.DataPropertyName = "ProsesID";
            this.ProsesID.HeaderText = "ProsesID";
            this.ProsesID.Name = "ProsesID";
            this.ProsesID.ReadOnly = true;
            this.ProsesID.Visible = false;
            // 
            // Material
            // 
            this.Material.DataPropertyName = "Material";
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Visible = false;
            // 
            // SatJual
            // 
            this.SatJual.DataPropertyName = "SatJual";
            this.SatJual.HeaderText = "SatJual";
            this.SatJual.Name = "SatJual";
            this.SatJual.ReadOnly = true;
            this.SatJual.Visible = false;
            // 
            // KodeRak
            // 
            this.KodeRak.DataPropertyName = "KodeRak";
            this.KodeRak.HeaderText = "Kode Rak";
            this.KodeRak.Name = "KodeRak";
            this.KodeRak.ReadOnly = true;
            // 
            // KodeRak1
            // 
            this.KodeRak1.DataPropertyName = "KodeRak1";
            this.KodeRak1.HeaderText = "KodeRak1";
            this.KodeRak1.Name = "KodeRak1";
            this.KodeRak1.ReadOnly = true;
            this.KodeRak1.Visible = false;
            // 
            // KodeRak2
            // 
            this.KodeRak2.DataPropertyName = "KodeRak2";
            this.KodeRak2.HeaderText = "KodeRak2";
            this.KodeRak2.Name = "KodeRak2";
            this.KodeRak2.ReadOnly = true;
            this.KodeRak2.Visible = false;
            // 
            // JB
            // 
            this.JB.DataPropertyName = "JB";
            this.JB.HeaderText = "JB";
            this.JB.Name = "JB";
            this.JB.ReadOnly = true;
            this.JB.Visible = false;
            // 
            // IDREC
            // 
            this.IDREC.DataPropertyName = "RecordID";
            this.IDREC.HeaderText = "IDREC";
            this.IDREC.Name = "IDREC";
            this.IDREC.ReadOnly = true;
            this.IDREC.Visible = false;
            this.IDREC.Width = 200;
            // 
            // Pasif
            // 
            this.Pasif.DataPropertyName = "StatusPasif";
            this.Pasif.HeaderText = "Pasif";
            this.Pasif.Name = "Pasif";
            this.Pasif.ReadOnly = true;
            this.Pasif.Visible = false;
            // 
            // StatusAktif
            // 
            this.StatusAktif.DataPropertyName = "StatusAktif";
            this.StatusAktif.HeaderText = "StatusAktif";
            this.StatusAktif.Name = "StatusAktif";
            this.StatusAktif.ReadOnly = true;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // PrediksiLamaKirim
            // 
            this.PrediksiLamaKirim.DataPropertyName = "PrediksiLamaKirim";
            this.PrediksiLamaKirim.HeaderText = "PrediksiLamaKirim";
            this.PrediksiLamaKirim.Name = "PrediksiLamaKirim";
            this.PrediksiLamaKirim.ReadOnly = true;
            this.PrediksiLamaKirim.Visible = false;
            // 
            // HariRataRata
            // 
            this.HariRataRata.DataPropertyName = "HariRataRata";
            this.HariRataRata.HeaderText = "HariRataRata";
            this.HariRataRata.Name = "HariRataRata";
            this.HariRataRata.ReadOnly = true;
            this.HariRataRata.Visible = false;
            // 
            // StokMin
            // 
            this.StokMin.DataPropertyName = "StokMin";
            this.StokMin.HeaderText = "StokMin";
            this.StokMin.Name = "StokMin";
            this.StokMin.ReadOnly = true;
            this.StokMin.Visible = false;
            // 
            // StokMax
            // 
            this.StokMax.DataPropertyName = "StokMax";
            this.StokMax.HeaderText = "StokMax";
            this.StokMax.Name = "StokMax";
            this.StokMax.ReadOnly = true;
            this.StokMax.Visible = false;
            // 
            // IsiKoli
            // 
            this.IsiKoli.DataPropertyName = "IsiKoli";
            this.IsiKoli.HeaderText = "IsiKoli";
            this.IsiKoli.Name = "IsiKoli";
            this.IsiKoli.ReadOnly = true;
            this.IsiKoli.Visible = false;
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
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // Sts
            // 
            this.Sts.DataPropertyName = "Sts";
            this.Sts.HeaderText = "Sts";
            this.Sts.Name = "Sts";
            this.Sts.ReadOnly = true;
            this.Sts.Visible = false;
            // 
            // LastHPP
            // 
            this.LastHPP.DataPropertyName = "LastHPP";
            this.LastHPP.HeaderText = "LastHPP";
            this.LastHPP.Name = "LastHPP";
            this.LastHPP.ReadOnly = true;
            this.LastHPP.Visible = false;
            // 
            // HrgJual
            // 
            this.HrgJual.DataPropertyName = "HrgJual";
            this.HrgJual.HeaderText = "HrgJual";
            this.HrgJual.Name = "HrgJual";
            this.HrgJual.ReadOnly = true;
            this.HrgJual.Visible = false;
            // 
            // IDM
            // 
            this.IDM.DataPropertyName = "IDM";
            this.IDM.HeaderText = "IDM";
            this.IDM.Name = "IDM";
            this.IDM.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nama_stok,
            this.row,
            this.BarangID,
            this.barcode,
            this.GroupBC,
            this.Kendaraaan,
            this.PartNumber,
            this.CreatedBy,
            this.CreatedOn,
            this.LastUpdatedByD,
            this.LastUpdatedTimeD});
            this.dataGridView2.Location = new System.Drawing.Point(3, 202);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1292, 162);
            this.dataGridView2.StandardTab = true;
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Nama_stok
            // 
            this.Nama_stok.DataPropertyName = "NamaStok";
            this.Nama_stok.HeaderText = "Nama Stok";
            this.Nama_stok.Name = "Nama_stok";
            this.Nama_stok.Width = 500;
            // 
            // row
            // 
            this.row.DataPropertyName = "RowID";
            this.row.HeaderText = "row";
            this.row.Name = "row";
            this.row.Visible = false;
            // 
            // BarangID
            // 
            this.BarangID.DataPropertyName = "id_brgdg";
            this.BarangID.HeaderText = "Barang ID";
            this.BarangID.Name = "BarangID";
            this.BarangID.Width = 200;
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "Barcode";
            this.barcode.Name = "barcode";
            // 
            // GroupBC
            // 
            this.GroupBC.DataPropertyName = "groupbc";
            this.GroupBC.HeaderText = "Group BC";
            this.GroupBC.Name = "GroupBC";
            this.GroupBC.Visible = false;
            // 
            // Kendaraaan
            // 
            this.Kendaraaan.DataPropertyName = "kendaraan";
            this.Kendaraaan.HeaderText = "Kendaraan";
            this.Kendaraaan.Name = "Kendaraaan";
            this.Kendaraaan.Visible = false;
            // 
            // PartNumber
            // 
            this.PartNumber.DataPropertyName = "partno";
            this.PartNumber.HeaderText = "Part Number";
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.Visible = false;
            // 
            // CreatedBy
            // 
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            // 
            // CreatedOn
            // 
            this.CreatedOn.HeaderText = "CreatedOn";
            this.CreatedOn.Name = "CreatedOn";
            // 
            // LastUpdatedByD
            // 
            this.LastUpdatedByD.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedByD.HeaderText = "LastUpdatedBy";
            this.LastUpdatedByD.Name = "LastUpdatedByD";
            // 
            // LastUpdatedTimeD
            // 
            this.LastUpdatedTimeD.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTimeD.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTimeD.Name = "LastUpdatedTimeD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nama Stok";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(329, 51);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 29;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblNamaBarang
            // 
            this.lblNamaBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNamaBarang.AutoSize = true;
            this.lblNamaBarang.Location = new System.Drawing.Point(28, 476);
            this.lblNamaBarang.Name = "lblNamaBarang";
            this.lblNamaBarang.Size = new System.Drawing.Size(88, 14);
            this.lblNamaBarang.TabIndex = 32;
            this.lblNamaBarang.Text = "\"Nama Barang\"";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(393, 517);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 35;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(147, 518);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 34;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(28, 518);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 33;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1219, 518);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 36;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(98, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(225, 20);
            this.txtSearch.TabIndex = 37;
            // 
            // CMDGenerate
            // 
            this.CMDGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CMDGenerate.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.None;
            this.CMDGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMDGenerate.Location = new System.Drawing.Point(269, 518);
            this.CMDGenerate.Name = "CMDGenerate";
            this.CMDGenerate.Size = new System.Drawing.Size(100, 40);
            this.CMDGenerate.TabIndex = 38;
            this.CMDGenerate.Text = "GENERATE";
            this.CMDGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CMDGenerate.UseVisualStyleBackColor = true;
            this.CMDGenerate.Click += new System.EventHandler(this.CMDGenerate_Click);
            // 
            // frmStokBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 570);
            this.Controls.Add(this.CMDGenerate);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblNamaBarang);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStokBarcode";
            this.Text = "Stock Barcode";
            this.Title = "Stock Barcode";
            this.Load += new System.EventHandler(this.frmStokBarcode_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.lblNamaBarang, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.CMDGenerate, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.CustomGridView dataGridView2;
        private System.Windows.Forms.Label lblNamaBarang;
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private ISA.Toko.Controls.CommandButton cmdEdit;
        private ISA.Toko.Controls.CommandButton cmdAdd;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommonTextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSebutanBengkel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bundle;
        private System.Windows.Forms.DataGridViewTextBoxColumn kendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn KelompokTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn klpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaTertera;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merek1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dibungkus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumberDr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProsesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak2;
        private System.Windows.Forms.DataGridViewTextBoxColumn JB;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDREC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pasif;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrediksiLamaKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariRataRata;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsiKoli;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sts;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastHPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama_stok;
        private System.Windows.Forms.DataGridViewTextBoxColumn row;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedByD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTimeD;
        private ISA.Toko.Controls.CommandButton CMDGenerate;
    }
}