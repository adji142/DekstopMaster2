namespace ISA.Trading.Master
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
            this.dataGridView2 = new ISA.Trading.Controls.CustomGridView();
            this.Nama_stok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kendaraaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bundle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kendaraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaTertera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merek1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dibungkus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumberDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProsesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idrec = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new ISA.Trading.Controls.CommonTextBox();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.cmdDelete = new ISA.Trading.Controls.CommandButton();
            this.cmdEdit = new ISA.Trading.Controls.CommandButton();
            this.cmdAdd = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.46734F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.532663F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1298, 367);
            this.tableLayoutPanel1.TabIndex = 31;
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
            this.PartNumber});
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
            // 
            // Kendaraaan
            // 
            this.Kendaraaan.DataPropertyName = "kendaraan";
            this.Kendaraaan.HeaderText = "Kendaraan";
            this.Kendaraaan.Name = "Kendaraaan";
            // 
            // PartNumber
            // 
            this.PartNumber.DataPropertyName = "partno";
            this.PartNumber.HeaderText = "Part Number";
            this.PartNumber.Name = "PartNumber";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NamaStok,
            this.IDBarang,
            this.Klpp,
            this.Bundle,
            this.KodeSolo,
            this.Kendaraan,
            this.NamaTertera,
            this.PartNo,
            this.Merek1,
            this.Dibungkus,
            this.SumberDR,
            this.ProsesID,
            this.Satuan,
            this.Material,
            this.SatJual,
            this.KodeRak,
            this.KodeRak1,
            this.KodeRak2,
            this.JB,
            this.Idrec,
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
            this.Sts});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1292, 180);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.SelectionRowChanged += new System.EventHandler(this.dataGridView1_SelectionRowChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 200;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 300;
            // 
            // IDBarang
            // 
            this.IDBarang.DataPropertyName = "BarangID";
            this.IDBarang.HeaderText = "BarangID";
            this.IDBarang.Name = "IDBarang";
            this.IDBarang.ReadOnly = true;
            // 
            // Klpp
            // 
            this.Klpp.DataPropertyName = "KodeBarang";
            this.Klpp.HeaderText = "Klp";
            this.Klpp.Name = "Klpp";
            this.Klpp.ReadOnly = true;
            this.Klpp.Width = 50;
            // 
            // Bundle
            // 
            this.Bundle.DataPropertyName = "Bundle";
            this.Bundle.HeaderText = "Bundle";
            this.Bundle.Name = "Bundle";
            this.Bundle.ReadOnly = true;
            // 
            // KodeSolo
            // 
            this.KodeSolo.DataPropertyName = "KodeSolo";
            this.KodeSolo.HeaderText = "KodeSolo";
            this.KodeSolo.Name = "KodeSolo";
            this.KodeSolo.ReadOnly = true;
            this.KodeSolo.Width = 75;
            // 
            // Kendaraan
            // 
            this.Kendaraan.DataPropertyName = "Kendaran";
            this.Kendaraan.HeaderText = "Kendaraan";
            this.Kendaraan.Name = "Kendaraan";
            this.Kendaraan.ReadOnly = true;
            // 
            // NamaTertera
            // 
            this.NamaTertera.DataPropertyName = "NamaTertera";
            this.NamaTertera.HeaderText = "Nama Tertera";
            this.NamaTertera.Name = "NamaTertera";
            this.NamaTertera.ReadOnly = true;
            this.NamaTertera.Width = 120;
            // 
            // PartNo
            // 
            this.PartNo.DataPropertyName = "PartNo";
            this.PartNo.HeaderText = "Part Number";
            this.PartNo.Name = "PartNo";
            this.PartNo.ReadOnly = true;
            // 
            // Merek1
            // 
            this.Merek1.DataPropertyName = "Merek";
            this.Merek1.HeaderText = "Merek";
            this.Merek1.Name = "Merek1";
            this.Merek1.ReadOnly = true;
            // 
            // Dibungkus
            // 
            this.Dibungkus.DataPropertyName = "Dibungkus";
            this.Dibungkus.HeaderText = "Dibungkus";
            this.Dibungkus.Name = "Dibungkus";
            this.Dibungkus.ReadOnly = true;
            // 
            // SumberDR
            // 
            this.SumberDR.DataPropertyName = "SumberDR";
            this.SumberDR.HeaderText = "SumberDR";
            this.SumberDR.Name = "SumberDR";
            this.SumberDR.ReadOnly = true;
            // 
            // ProsesID
            // 
            this.ProsesID.DataPropertyName = "ProsesID";
            this.ProsesID.HeaderText = "ProsesID";
            this.ProsesID.Name = "ProsesID";
            this.ProsesID.ReadOnly = true;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "SatSolo";
            this.Satuan.HeaderText = "Satuan";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            // 
            // Material
            // 
            this.Material.DataPropertyName = "Material";
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            // 
            // SatJual
            // 
            this.SatJual.DataPropertyName = "SatJual";
            this.SatJual.HeaderText = "SatJual";
            this.SatJual.Name = "SatJual";
            this.SatJual.ReadOnly = true;
            // 
            // KodeRak
            // 
            this.KodeRak.DataPropertyName = "KodeRak";
            this.KodeRak.HeaderText = "KodeRak";
            this.KodeRak.Name = "KodeRak";
            this.KodeRak.ReadOnly = true;
            // 
            // KodeRak1
            // 
            this.KodeRak1.DataPropertyName = "KodeRak1";
            this.KodeRak1.HeaderText = "KodeRak1";
            this.KodeRak1.Name = "KodeRak1";
            this.KodeRak1.ReadOnly = true;
            // 
            // KodeRak2
            // 
            this.KodeRak2.DataPropertyName = "KodeRak2";
            this.KodeRak2.HeaderText = "KodeRak2";
            this.KodeRak2.Name = "KodeRak2";
            this.KodeRak2.ReadOnly = true;
            // 
            // JB
            // 
            this.JB.DataPropertyName = "JB";
            this.JB.HeaderText = "JB";
            this.JB.Name = "JB";
            this.JB.ReadOnly = true;
            // 
            // Idrec
            // 
            this.Idrec.DataPropertyName = "RecordID";
            this.Idrec.HeaderText = "RecordID";
            this.Idrec.Name = "Idrec";
            this.Idrec.ReadOnly = true;
            // 
            // Pasif
            // 
            this.Pasif.DataPropertyName = "StatusPasif";
            this.Pasif.HeaderText = "Pasif";
            this.Pasif.Name = "Pasif";
            this.Pasif.ReadOnly = true;
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
            // 
            // PrediksiLamaKirim
            // 
            this.PrediksiLamaKirim.DataPropertyName = "PrediksiLamaKirim";
            this.PrediksiLamaKirim.HeaderText = "PrediksiLamaKirim";
            this.PrediksiLamaKirim.Name = "PrediksiLamaKirim";
            this.PrediksiLamaKirim.ReadOnly = true;
            // 
            // HariRataRata
            // 
            this.HariRataRata.DataPropertyName = "HariRatarata";
            this.HariRataRata.HeaderText = "HariRataRata";
            this.HariRataRata.Name = "HariRataRata";
            this.HariRataRata.ReadOnly = true;
            // 
            // StokMin
            // 
            this.StokMin.DataPropertyName = "StokMin";
            this.StokMin.HeaderText = "StokMin";
            this.StokMin.Name = "StokMin";
            this.StokMin.ReadOnly = true;
            // 
            // StokMax
            // 
            this.StokMax.DataPropertyName = "StokMax";
            this.StokMax.HeaderText = "StokMax";
            this.StokMax.Name = "StokMax";
            this.StokMax.ReadOnly = true;
            // 
            // IsiKoli
            // 
            this.IsiKoli.DataPropertyName = "IsiKoli";
            this.IsiKoli.HeaderText = "IsiKoli";
            this.IsiKoli.Name = "IsiKoli";
            this.IsiKoli.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            // 
            // Sts
            // 
            this.Sts.DataPropertyName = "Sts";
            this.Sts.HeaderText = "Sts";
            this.Sts.Name = "Sts";
            this.Sts.ReadOnly = true;
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
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(88, 53);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 20);
            this.txtSearch.TabIndex = 28;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(338, 50);
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
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(1114, 518);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 35;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(1008, 518);
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
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(902, 518);
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
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
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
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBarcode.Location = new System.Drawing.Point(96, 505);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(159, 20);
            this.txtBarcode.TabIndex = 37;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown_1);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "Barcode";
            // 
            // frmStokBarcode
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 570);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblNamaBarang);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStokBarcode";
            this.Text = "Stok Barcode";
            this.Title = "Stok Barcode";
            this.Load += new System.EventHandler(this.frmStokBarcode_Load);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.lblNamaBarang, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private ISA.Trading.Controls.CommonTextBox txtSearch;
        private ISA.Trading.Controls.CustomGridView dataGridView2;
        private System.Windows.Forms.Label lblNamaBarang;
        private ISA.Trading.Controls.CommandButton cmdDelete;
        private ISA.Trading.Controls.CommandButton cmdEdit;
        private ISA.Trading.Controls.CommandButton cmdAdd;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama_stok;
        private System.Windows.Forms.DataGridViewTextBoxColumn row;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bundle;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaTertera;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merek1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dibungkus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumberDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProsesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak2;
        private System.Windows.Forms.DataGridViewTextBoxColumn JB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idrec;
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
    }
}