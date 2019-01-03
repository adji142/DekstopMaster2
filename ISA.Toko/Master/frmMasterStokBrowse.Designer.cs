﻿namespace ISA.Toko.Master
{
    partial class frmMasterStokBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterStokBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtSearch = new ISA.Toko.Controls.CommonTextBox();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdDownload = new ISA.Toko.Controls.CommandButton();
            this.cmdDELETE = new ISA.Toko.Controls.CommandButton();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdADD = new ISA.Toko.Controls.CommandButton();
            this.cmdEDIT = new System.Windows.Forms.Button();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSebutanBengkel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeRak2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatSolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bundle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KelompokTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusPasif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kendaraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaTertera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dibungkus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumberDr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrediksiLamaKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HariRataRata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsiKoli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.NamaStok,
            this.BarangID,
            this.NamaSebutanBengkel,
            this.KodeRak,
            this.KodeRak1,
            this.KodeRak2,
            this.JenisBarang,
            this.SatJual,
            this.SatSolo,
            this.Bundle,
            this.KelompokTransaksi,
            this.StatusPasif,
            this.KodeSolo,
            this.Kendaraan,
            this.RowID,
            this.IDRec,
            this.NamaTertera,
            this.PartNo,
            this.Merek,
            this.Dibungkus,
            this.SumberDr,
            this.IDProses,
            this.Material,
            this.JB,
            this.SyncFlag,
            this.PrediksiLamaKirim,
            this.HariRataRata,
            this.StokMin,
            this.StokMax,
            this.IsiKoli,
            this.CreatedBy,
            this.CreatedOn,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridView1.Location = new System.Drawing.Point(8, 98);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(701, 433);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(219, 67);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(87, 25);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(30, 69);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(181, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSeacrh_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.groupBox1);
            this.pnlButton.Controls.Add(this.lblNamaBarang);
            this.pnlButton.Controls.Add(this.cmdClose);
            this.pnlButton.Controls.Add(this.cmdADD);
            this.pnlButton.Controls.Add(this.cmdEDIT);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 537);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(718, 83);
            this.pnlButton.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdDownload);
            this.groupBox1.Controls.Add(this.cmdDELETE);
            this.groupBox1.Location = new System.Drawing.Point(355, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 64);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saya Tidak Kelihatan";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(5, 15);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 22;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDELETE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(139, 15);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 18;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // lblNamaBarang
            // 
            this.lblNamaBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNamaBarang.AutoSize = true;
            this.lblNamaBarang.Location = new System.Drawing.Point(6, 0);
            this.lblNamaBarang.Name = "lblNamaBarang";
            this.lblNamaBarang.Size = new System.Drawing.Size(88, 14);
            this.lblNamaBarang.TabIndex = 25;
            this.lblNamaBarang.Text = "\"Nama Barang\"";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(610, 20);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 24;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(9, 20);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 17;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEDIT.Image = global::ISA.Toko.Properties.Resources.Edit32;
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(124, 20);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 16;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.Frozen = true;
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 300;
            // 
            // BarangID
            // 
            this.BarangID.DataPropertyName = "BarangID";
            this.BarangID.HeaderText = "Kode Barang";
            this.BarangID.Name = "BarangID";
            this.BarangID.ReadOnly = true;
            this.BarangID.Width = 150;
            // 
            // NamaSebutanBengkel
            // 
            this.NamaSebutanBengkel.DataPropertyName = "NamaSebutanBengkel";
            this.NamaSebutanBengkel.HeaderText = " Nama Sebutan Bengkel";
            this.NamaSebutanBengkel.Name = "NamaSebutanBengkel";
            this.NamaSebutanBengkel.ReadOnly = true;
            this.NamaSebutanBengkel.Width = 300;
            // 
            // KodeRak
            // 
            this.KodeRak.DataPropertyName = "KodeRak";
            this.KodeRak.HeaderText = "Rak 1";
            this.KodeRak.Name = "KodeRak";
            this.KodeRak.ReadOnly = true;
            this.KodeRak.Width = 80;
            // 
            // KodeRak1
            // 
            this.KodeRak1.DataPropertyName = "KodeRak1";
            this.KodeRak1.HeaderText = "Rak 2";
            this.KodeRak1.Name = "KodeRak1";
            this.KodeRak1.ReadOnly = true;
            this.KodeRak1.Width = 80;
            // 
            // KodeRak2
            // 
            this.KodeRak2.DataPropertyName = "KodeRak2";
            this.KodeRak2.HeaderText = "Rak 3";
            this.KodeRak2.Name = "KodeRak2";
            this.KodeRak2.ReadOnly = true;
            this.KodeRak2.Width = 80;
            // 
            // JenisBarang
            // 
            this.JenisBarang.DataPropertyName = "JenisBarang";
            this.JenisBarang.HeaderText = "Jenis Barang";
            this.JenisBarang.Name = "JenisBarang";
            this.JenisBarang.ReadOnly = true;
            // 
            // SatJual
            // 
            this.SatJual.DataPropertyName = "SatJual";
            this.SatJual.HeaderText = "Satuan Jual";
            this.SatJual.Name = "SatJual";
            this.SatJual.ReadOnly = true;
            this.SatJual.Width = 50;
            // 
            // SatSolo
            // 
            this.SatSolo.DataPropertyName = "SatSolo";
            this.SatSolo.HeaderText = "Sat.B";
            this.SatSolo.Name = "SatSolo";
            this.SatSolo.ReadOnly = true;
            this.SatSolo.Visible = false;
            this.SatSolo.Width = 50;
            // 
            // Bundle
            // 
            this.Bundle.DataPropertyName = "Bundle";
            this.Bundle.HeaderText = "Moving";
            this.Bundle.Name = "Bundle";
            this.Bundle.ReadOnly = true;
            // 
            // KelompokTransaksi
            // 
            this.KelompokTransaksi.DataPropertyName = "KelompokTransaksi";
            this.KelompokTransaksi.HeaderText = "Kelompok Transaksi";
            this.KelompokTransaksi.Name = "KelompokTransaksi";
            this.KelompokTransaksi.ReadOnly = true;
            // 
            // StatusPasif
            // 
            this.StatusPasif.DataPropertyName = "Sts";
            this.StatusPasif.HeaderText = "Status Aktif";
            this.StatusPasif.Name = "StatusPasif";
            this.StatusPasif.ReadOnly = true;
            this.StatusPasif.Width = 120;
            // 
            // KodeSolo
            // 
            this.KodeSolo.DataPropertyName = "KodeSolo";
            this.KodeSolo.HeaderText = "Kel";
            this.KodeSolo.Name = "KodeSolo";
            this.KodeSolo.ReadOnly = true;
            this.KodeSolo.Visible = false;
            // 
            // Kendaraan
            // 
            this.Kendaraan.DataPropertyName = "Kendaraan";
            this.Kendaraan.HeaderText = "Kendaraan";
            this.Kendaraan.Name = "Kendaraan";
            this.Kendaraan.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "Row ID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // IDRec
            // 
            this.IDRec.DataPropertyName = "IDRec";
            this.IDRec.HeaderText = "ID Rec";
            this.IDRec.Name = "IDRec";
            this.IDRec.ReadOnly = true;
            this.IDRec.Visible = false;
            // 
            // NamaTertera
            // 
            this.NamaTertera.DataPropertyName = "NamaTertera";
            this.NamaTertera.HeaderText = "Nama Tertera";
            this.NamaTertera.Name = "NamaTertera";
            this.NamaTertera.ReadOnly = true;
            this.NamaTertera.Visible = false;
            // 
            // PartNo
            // 
            this.PartNo.DataPropertyName = "PartNo";
            this.PartNo.HeaderText = "Part No.";
            this.PartNo.Name = "PartNo";
            this.PartNo.ReadOnly = true;
            this.PartNo.Visible = false;
            // 
            // Merek
            // 
            this.Merek.DataPropertyName = "Merek";
            this.Merek.HeaderText = "Merek";
            this.Merek.Name = "Merek";
            this.Merek.ReadOnly = true;
            this.Merek.Visible = false;
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
            // IDProses
            // 
            this.IDProses.DataPropertyName = "IDProses";
            this.IDProses.HeaderText = "ID Proses";
            this.IDProses.Name = "IDProses";
            this.IDProses.ReadOnly = true;
            this.IDProses.Visible = false;
            // 
            // Material
            // 
            this.Material.DataPropertyName = "Material";
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Visible = false;
            // 
            // JB
            // 
            this.JB.DataPropertyName = "JB";
            this.JB.HeaderText = "JB";
            this.JB.Name = "JB";
            this.JB.ReadOnly = true;
            this.JB.Visible = false;
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
            this.PrediksiLamaKirim.HeaderText = "Prediksi Lama Kirim";
            this.PrediksiLamaKirim.Name = "PrediksiLamaKirim";
            this.PrediksiLamaKirim.ReadOnly = true;
            this.PrediksiLamaKirim.Visible = false;
            // 
            // HariRataRata
            // 
            this.HariRataRata.DataPropertyName = "HariRataRata";
            this.HariRataRata.HeaderText = "Hari Rata-rata";
            this.HariRataRata.Name = "HariRataRata";
            this.HariRataRata.ReadOnly = true;
            this.HariRataRata.Visible = false;
            // 
            // StokMin
            // 
            this.StokMin.DataPropertyName = "StokMin";
            this.StokMin.HeaderText = "Stok Min";
            this.StokMin.Name = "StokMin";
            this.StokMin.ReadOnly = true;
            this.StokMin.Visible = false;
            // 
            // StokMax
            // 
            this.StokMax.DataPropertyName = "StokMax";
            this.StokMax.HeaderText = "Stok Max";
            this.StokMax.Name = "StokMax";
            this.StokMax.ReadOnly = true;
            this.StokMax.Visible = false;
            // 
            // IsiKoli
            // 
            this.IsiKoli.DataPropertyName = "IsiKoli";
            this.IsiKoli.HeaderText = "Isi Koli";
            this.IsiKoli.Name = "IsiKoli";
            this.IsiKoli.ReadOnly = true;
            this.IsiKoli.Visible = false;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // CreatedOn
            // 
            this.CreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle1.Format = "(dd/MM/yyyy hh:mm:ss)";
            dataGridViewCellStyle1.NullValue = null;
            this.CreatedOn.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreatedOn.HeaderText = "CreatedOn";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            this.CreatedOn.Width = 200;
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
            dataGridViewCellStyle2.Format = "(dd/MM/yyyy hh:mm:ss)";
            dataGridViewCellStyle2.NullValue = null;
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Width = 200;
            // 
            // frmMasterStokBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(718, 620);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dataGridView1);
            this.FormID = "SC0235";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMasterStokBrowse";
            this.Text = "SC0235 - Master Stok";
            this.Title = "Master Stok";
            this.Load += new System.EventHandler(this.frmMasterStokBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.Button cmdSearch;
        private ISA.Toko.Controls.CommonTextBox txtSearch;
        private System.Windows.Forms.Panel pnlButton;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdDownload;
        private ISA.Toko.Controls.CommandButton cmdDELETE;
        private ISA.Toko.Controls.CommandButton cmdADD;
        private System.Windows.Forms.Button cmdEDIT;
        private System.Windows.Forms.Label lblNamaBarang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSebutanBengkel;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeRak2;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatSolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bundle;
        private System.Windows.Forms.DataGridViewTextBoxColumn KelompokTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusPasif;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaTertera;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dibungkus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumberDr;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn JB;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrediksiLamaKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariRataRata;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsiKoli;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}