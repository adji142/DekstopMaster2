namespace ISA.Toko.Persediaan
    {
    partial class frmStandarStok
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing&&(components!=null))
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStandarStok));
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
                this.cmdSearch = new ISA.Toko.Controls.CommandButton();
                this.textBox1 = new ISA.Toko.Controls.CommonTextBox();
                this.label2 = new System.Windows.Forms.Label();
                this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.dataGridDetail2 = new ISA.Toko.Controls.CustomGridView();
                this.TglProses1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.QtyMaximum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.QtyMinimum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.QtyAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.QtyOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.TglLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.dataGridHeader = new ISA.Toko.Controls.CustomGridView();
                this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.KodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Bundle = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.PrediksiLamaKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.HariRataRata = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.StatusPasif = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.dataGridDetail1 = new ISA.Toko.Controls.CustomGridView();
                this.TglProses = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.AVGJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Var1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Var2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.QtyMinimum = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.QtyMaximum = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.RowID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.label1 = new System.Windows.Forms.Label();
                this.dgvStokBuffer = new ISA.Toko.Controls.CustomGridView();
                this.tmt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.QBuffer = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.AvgJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.label4 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.cmdUpload = new ISA.Toko.Controls.CommandButton();
                this.cmdNo = new ISA.Toko.Controls.CommandButton();
                this.tableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail2)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.dgvStokBuffer)).BeginInit();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // cmdSearch
                // 
                this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
                this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
                this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
                this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
                this.cmdSearch.Location = new System.Drawing.Point(377, 60);
                this.cmdSearch.Name = "cmdSearch";
                this.cmdSearch.Size = new System.Drawing.Size(80, 23);
                this.cmdSearch.TabIndex = 1;
                this.cmdSearch.Text = "Search";
                this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdSearch.UseVisualStyleBackColor = true;
                this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
                // 
                // textBox1
                // 
                this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.textBox1.Location = new System.Drawing.Point(115, 63);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(256, 20);
                this.textBox1.TabIndex = 0;
                this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(19, 67);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(78, 14);
                this.label2.TabIndex = 8;
                this.label2.Text = "Nama Barang";
                // 
                // tableLayoutPanel1
                // 
                this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.tableLayoutPanel1.ColumnCount = 1;
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.tableLayoutPanel1.Controls.Add(this.dataGridDetail2, 0, 5);
                this.tableLayoutPanel1.Controls.Add(this.dataGridHeader, 0, 0);
                this.tableLayoutPanel1.Controls.Add(this.dataGridDetail1, 0, 3);
                this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
                this.tableLayoutPanel1.Controls.Add(this.dgvStokBuffer, 0, 2);
                this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 89);
                this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                this.tableLayoutPanel1.RowCount = 6;
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 579);
                this.tableLayoutPanel1.TabIndex = 9;
                // 
                // dataGridDetail2
                // 
                this.dataGridDetail2.AllowUserToAddRows = false;
                this.dataGridDetail2.AllowUserToDeleteRows = false;
                this.dataGridDetail2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridDetail2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.dataGridDetail2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridDetail2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglProses1,
            this.QtyMaximum1,
            this.QtyMinimum1,
            this.QtyAkhir,
            this.QtyOrder,
            this.TglLink,
            this.LinkID});
                this.dataGridDetail2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dataGridDetail2.Location = new System.Drawing.Point(3, 493);
                this.dataGridDetail2.MultiSelect = false;
                this.dataGridDetail2.Name = "dataGridDetail2";
                this.dataGridDetail2.ReadOnly = true;
                this.dataGridDetail2.RowHeadersVisible = false;
                this.dataGridDetail2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                this.dataGridDetail2.Size = new System.Drawing.Size(877, 83);
                this.dataGridDetail2.StandardTab = true;
                this.dataGridDetail2.TabIndex = 10;
                this.dataGridDetail2.Visible = false;
                // 
                // TglProses1
                // 
                this.TglProses1.DataPropertyName = "TglProses";
                dataGridViewCellStyle13.Format = "dd/MM/yyyy";
                this.TglProses1.DefaultCellStyle = dataGridViewCellStyle13;
                this.TglProses1.HeaderText = "Tgl. Proses";
                this.TglProses1.Name = "TglProses1";
                this.TglProses1.ReadOnly = true;
                // 
                // QtyMaximum1
                // 
                this.QtyMaximum1.DataPropertyName = "QtyMaximum";
                this.QtyMaximum1.HeaderText = "Stok Max";
                this.QtyMaximum1.Name = "QtyMaximum1";
                this.QtyMaximum1.ReadOnly = true;
                // 
                // QtyMinimum1
                // 
                this.QtyMinimum1.DataPropertyName = "QtyMinimum";
                this.QtyMinimum1.HeaderText = "Stok Min";
                this.QtyMinimum1.Name = "QtyMinimum1";
                this.QtyMinimum1.ReadOnly = true;
                // 
                // QtyAkhir
                // 
                this.QtyAkhir.DataPropertyName = "QtyAkhir";
                this.QtyAkhir.HeaderText = "Stok Akhir";
                this.QtyAkhir.Name = "QtyAkhir";
                this.QtyAkhir.ReadOnly = true;
                // 
                // QtyOrder
                // 
                this.QtyOrder.DataPropertyName = "QtyOrder";
                this.QtyOrder.HeaderText = "Qty. Order";
                this.QtyOrder.Name = "QtyOrder";
                this.QtyOrder.ReadOnly = true;
                // 
                // TglLink
                // 
                this.TglLink.DataPropertyName = "TglLink";
                dataGridViewCellStyle14.Format = "dd/MM/yyyy";
                this.TglLink.DefaultCellStyle = dataGridViewCellStyle14;
                this.TglLink.HeaderText = "LinkToPBO";
                this.TglLink.Name = "TglLink";
                this.TglLink.ReadOnly = true;
                // 
                // LinkID
                // 
                this.LinkID.HeaderText = "LinkID";
                this.LinkID.Name = "LinkID";
                this.LinkID.ReadOnly = true;
                this.LinkID.Visible = false;
                // 
                // dataGridHeader
                // 
                this.dataGridHeader.AllowUserToAddRows = false;
                this.dataGridHeader.AllowUserToDeleteRows = false;
                this.dataGridHeader.AllowUserToResizeRows = false;
                this.dataGridHeader.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaStok,
            this.KodeBarang,
            this.Satuan,
            this.Bundle,
            this.PrediksiLamaKirim,
            this.HariRataRata,
            this.RowID,
            this.StatusPasif});
                this.dataGridHeader.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dataGridHeader.Location = new System.Drawing.Point(3, 3);
                this.dataGridHeader.MultiSelect = false;
                this.dataGridHeader.Name = "dataGridHeader";
                this.dataGridHeader.ReadOnly = true;
                this.dataGridHeader.RowHeadersVisible = false;
                this.dataGridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                this.dataGridHeader.Size = new System.Drawing.Size(877, 256);
                this.dataGridHeader.StandardTab = true;
                this.dataGridHeader.TabIndex = 0;
                this.dataGridHeader.SelectionRowChanged += new System.EventHandler(this.dataGridHeader_SelectionRowChanged);
                this.dataGridHeader.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridHeader_CellFormatting);
                this.dataGridHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridHeader_KeyDown);
                // 
                // NamaStok
                // 
                this.NamaStok.DataPropertyName = "NamaStok";
                this.NamaStok.HeaderText = "Nama Persediaan";
                this.NamaStok.Name = "NamaStok";
                this.NamaStok.ReadOnly = true;
                // 
                // KodeBarang
                // 
                this.KodeBarang.DataPropertyName = "BarangID";
                this.KodeBarang.HeaderText = "Kode Stok";
                this.KodeBarang.Name = "KodeBarang";
                this.KodeBarang.ReadOnly = true;
                // 
                // Satuan
                // 
                this.Satuan.DataPropertyName = "SatJual";
                this.Satuan.HeaderText = "Sat";
                this.Satuan.Name = "Satuan";
                this.Satuan.ReadOnly = true;
                // 
                // Bundle
                // 
                this.Bundle.DataPropertyName = "Bundle";
                this.Bundle.HeaderText = "FM";
                this.Bundle.Name = "Bundle";
                this.Bundle.ReadOnly = true;
                // 
                // PrediksiLamaKirim
                // 
                this.PrediksiLamaKirim.DataPropertyName = "PrediksiLamaKirim";
                this.PrediksiLamaKirim.HeaderText = "Lama Kirim";
                this.PrediksiLamaKirim.Name = "PrediksiLamaKirim";
                this.PrediksiLamaKirim.ReadOnly = true;
                this.PrediksiLamaKirim.Visible = false;
                // 
                // HariRataRata
                // 
                this.HariRataRata.DataPropertyName = "HariRataRata";
                this.HariRataRata.HeaderText = "Hr. Rata - Rata";
                this.HariRataRata.Name = "HariRataRata";
                this.HariRataRata.ReadOnly = true;
                this.HariRataRata.Visible = false;
                // 
                // RowID
                // 
                this.RowID.DataPropertyName = "RowID";
                this.RowID.HeaderText = "RowID";
                this.RowID.Name = "RowID";
                this.RowID.ReadOnly = true;
                this.RowID.Visible = false;
                // 
                // StatusPasif
                // 
                this.StatusPasif.DataPropertyName = "StatusPasif";
                this.StatusPasif.HeaderText = "StatusPasif";
                this.StatusPasif.Name = "StatusPasif";
                this.StatusPasif.ReadOnly = true;
                this.StatusPasif.Visible = false;
                // 
                // dataGridDetail1
                // 
                this.dataGridDetail1.AllowUserToAddRows = false;
                this.dataGridDetail1.AllowUserToDeleteRows = false;
                this.dataGridDetail1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridDetail1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.dataGridDetail1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridDetail1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglProses,
            this.AVGJual,
            this.Var1,
            this.Var2,
            this.QtyMinimum,
            this.QtyMaximum,
            this.RowID1});
                this.dataGridDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dataGridDetail1.Location = new System.Drawing.Point(3, 396);
                this.dataGridDetail1.MultiSelect = false;
                this.dataGridDetail1.Name = "dataGridDetail1";
                this.dataGridDetail1.ReadOnly = true;
                this.dataGridDetail1.RowHeadersVisible = false;
                this.dataGridDetail1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                this.dataGridDetail1.Size = new System.Drawing.Size(877, 81);
                this.dataGridDetail1.StandardTab = true;
                this.dataGridDetail1.TabIndex = 1;
                this.dataGridDetail1.Visible = false;
                // 
                // TglProses
                // 
                this.TglProses.DataPropertyName = "TglMT";
                dataGridViewCellStyle15.Format = "dd/MM/yyyy";
                this.TglProses.DefaultCellStyle = dataGridViewCellStyle15;
                this.TglProses.HeaderText = "Tgl. Proses";
                this.TglProses.Name = "TglProses";
                this.TglProses.ReadOnly = true;
                // 
                // AVGJual
                // 
                this.AVGJual.DataPropertyName = "AVGJual";
                this.AVGJual.HeaderText = "Rata - Rata Jual";
                this.AVGJual.Name = "AVGJual";
                this.AVGJual.ReadOnly = true;
                // 
                // Var1
                // 
                this.Var1.DataPropertyName = "Var1";
                this.Var1.HeaderText = "Var -";
                this.Var1.Name = "Var1";
                this.Var1.ReadOnly = true;
                // 
                // Var2
                // 
                this.Var2.DataPropertyName = "Var2";
                this.Var2.HeaderText = "Var +";
                this.Var2.Name = "Var2";
                this.Var2.ReadOnly = true;
                // 
                // QtyMinimum
                // 
                this.QtyMinimum.DataPropertyName = "QtyMinimum";
                this.QtyMinimum.HeaderText = "StokMin";
                this.QtyMinimum.Name = "QtyMinimum";
                this.QtyMinimum.ReadOnly = true;
                // 
                // QtyMaximum
                // 
                this.QtyMaximum.DataPropertyName = "QtyMaximum";
                this.QtyMaximum.HeaderText = "Stok Max";
                this.QtyMaximum.Name = "QtyMaximum";
                this.QtyMaximum.ReadOnly = true;
                // 
                // RowID1
                // 
                this.RowID1.DataPropertyName = "RowID";
                this.RowID1.HeaderText = "RowID";
                this.RowID1.Name = "RowID1";
                this.RowID1.ReadOnly = true;
                this.RowID1.Visible = false;
                // 
                // label1
                // 
                this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)));
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(3, 262);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(86, 30);
                this.label1.TabIndex = 8;
                this.label1.Text = "[Nama Barang]";
                this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // dgvStokBuffer
                // 
                this.dgvStokBuffer.AllowUserToAddRows = false;
                this.dgvStokBuffer.AllowUserToDeleteRows = false;
                this.dgvStokBuffer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvStokBuffer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.dgvStokBuffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dgvStokBuffer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmt1,
            this.QBuffer,
            this.AvgJ,
            this.Catatan});
                this.dgvStokBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dgvStokBuffer.Location = new System.Drawing.Point(3, 295);
                this.dgvStokBuffer.MultiSelect = false;
                this.dgvStokBuffer.Name = "dgvStokBuffer";
                this.dgvStokBuffer.ReadOnly = true;
                this.dgvStokBuffer.RowHeadersVisible = false;
                this.dgvStokBuffer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                this.dgvStokBuffer.Size = new System.Drawing.Size(877, 95);
                this.dgvStokBuffer.StandardTab = true;
                this.dgvStokBuffer.TabIndex = 11;
                // 
                // tmt1
                // 
                this.tmt1.DataPropertyName = "tmt1";
                this.tmt1.HeaderText = "Tgl Berlaku";
                this.tmt1.Name = "tmt1";
                this.tmt1.ReadOnly = true;
                // 
                // QBuffer
                // 
                this.QBuffer.DataPropertyName = "qbuffer";
                this.QBuffer.HeaderText = "Qty Buffer";
                this.QBuffer.Name = "QBuffer";
                this.QBuffer.ReadOnly = true;
                // 
                // AvgJ
                // 
                this.AvgJ.DataPropertyName = "avgjual";
                this.AvgJ.HeaderText = "Rata - Rata Jual";
                this.AvgJ.Name = "AvgJ";
                this.AvgJ.ReadOnly = true;
                // 
                // Catatan
                // 
                this.Catatan.DataPropertyName = "catatan";
                this.Catatan.HeaderText = "Catatan";
                this.Catatan.Name = "Catatan";
                this.Catatan.ReadOnly = true;
                // 
                // groupBox1
                // 
                this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.groupBox1.Controls.Add(this.label4);
                this.groupBox1.Controls.Add(this.label3);
                this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.groupBox1.Location = new System.Drawing.Point(12, 674);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(281, 50);
                this.groupBox1.TabIndex = 10;
                this.groupBox1.TabStop = false;
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label4.Location = new System.Drawing.Point(7, 30);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(258, 19);
                this.label4.TabIndex = 1;
                this.label4.Text = "F4 - Proses Generate Buffer Stok";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(7, 10);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(184, 14);
                this.label3.TabIndex = 0;
                this.label3.Text = "F3 - Proses Perhitungan Standar";
                this.label3.Visible = false;
                // 
                // cmdUpload
                // 
                this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Upload;
                this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
                this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdUpload.Location = new System.Drawing.Point(584, 675);
                this.cmdUpload.Name = "cmdUpload";
                this.cmdUpload.Size = new System.Drawing.Size(128, 40);
                this.cmdUpload.TabIndex = 52;
                this.cmdUpload.Text = "UPLOAD";
                this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdUpload.UseVisualStyleBackColor = true;
                this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(746, 675);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(128, 40);
                this.cmdNo.TabIndex = 53;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // frmStandarStok
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(905, 727);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.cmdUpload);
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.tableLayoutPanel1);
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.cmdSearch);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmStandarStok";
                this.Text = "Tabel Monitoring Buffer Stok";
                this.Title = "Tabel Monitoring Buffer Stok";
                this.Load += new System.EventHandler(this.frmStandarStok_Load);
                this.Controls.SetChildIndex(this.cmdSearch, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.textBox1, 0);
                this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
                this.Controls.SetChildIndex(this.groupBox1, 0);
                this.Controls.SetChildIndex(this.cmdUpload, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.tableLayoutPanel1.ResumeLayout(false);
                this.tableLayoutPanel1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.dgvStokBuffer)).EndInit();
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.CommonTextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Toko.Controls.CustomGridView dataGridHeader;
        private ISA.Toko.Controls.CustomGridView dataGridDetail1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglProses;
        private System.Windows.Forms.DataGridViewTextBoxColumn AVGJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Var1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Var2;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMinimum;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMaximum;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bundle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrediksiLamaKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariRataRata;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusPasif;
        private ISA.Toko.Controls.CustomGridView dataGridDetail2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglProses1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMaximum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMinimum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private ISA.Toko.Controls.CustomGridView dgvStokBuffer;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QBuffer;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private ISA.Toko.Controls.CommandButton cmdUpload;
        private ISA.Toko.Controls.CommandButton cmdNo;

        }
    }
