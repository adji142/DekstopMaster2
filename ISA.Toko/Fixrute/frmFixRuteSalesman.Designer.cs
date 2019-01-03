namespace ISA.Toko.Fixrute
{
    partial class frmFixRuteSalesman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFixRuteSalesman));
            this.cbSalesCabang = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.Nama_Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode_Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbFilter = new System.Windows.Forms.CheckBox();
            this.txtTglFrom = new System.Windows.Forms.TextBox();
            this.txtTglTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdKunjunganBaru = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rgbTglKunjungan = new ISA.Toko.Controls.RangeDateBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.helpToolTipButton1 = new ISA.Toko.Controls.HelpToolTipButton();
            this.cmdProses = new System.Windows.Forms.Button();
            this.cbOutletAktif = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDaerah = new System.Windows.Forms.TextBox();
            this.txtKota = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbHari = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKodeSales = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.cmdPrintRegisterKunjungan = new ISA.Toko.Controls.CommandButton();
            this.commandButton2 = new ISA.Toko.Controls.CommandButton();
            this.commandButton3 = new ISA.Toko.Controls.CommandButton();
            this.commandButton4 = new ISA.Toko.Controls.CommandButton();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.cmdEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.Mg5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Mg4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Mg3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Mg2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Mg1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AreaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kecamatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daerah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tmt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tmt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kd_Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSalesCabang
            // 
            this.cbSalesCabang.AutoSize = true;
            this.cbSalesCabang.Location = new System.Drawing.Point(27, 68);
            this.cbSalesCabang.Name = "cbSalesCabang";
            this.cbSalesCabang.Size = new System.Drawing.Size(100, 18);
            this.cbSalesCabang.TabIndex = 5;
            this.cbSalesCabang.Text = "Sales Cabang";
            this.cbSalesCabang.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 92);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(445, 154);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nama_Sales,
            this.Kode_Sales});
            this.customGridView1.Location = new System.Drawing.Point(3, 3);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(439, 148);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 0;
            this.customGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellClick);
            this.customGridView1.Click += new System.EventHandler(this.customGridView1_CellClick);
            // 
            // Nama_Sales
            // 
            this.Nama_Sales.DataPropertyName = "nm_sales";
            this.Nama_Sales.HeaderText = "Nama Sales";
            this.Nama_Sales.Name = "Nama_Sales";
            this.Nama_Sales.ReadOnly = true;
            this.Nama_Sales.Width = 250;
            // 
            // Kode_Sales
            // 
            this.Kode_Sales.DataPropertyName = "kd_sales";
            this.Kode_Sales.HeaderText = "Kode Sales";
            this.Kode_Sales.Name = "Kode_Sales";
            this.Kode_Sales.ReadOnly = true;
            this.Kode_Sales.Width = 150;
            // 
            // cbFilter
            // 
            this.cbFilter.AutoSize = true;
            this.cbFilter.Location = new System.Drawing.Point(27, 263);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(106, 18);
            this.cbFilter.TabIndex = 7;
            this.cbFilter.Text = "Filter Periode :";
            this.cbFilter.UseVisualStyleBackColor = true;
            this.cbFilter.CheckedChanged += new System.EventHandler(this.cbFilter_CheckedChanged);
            // 
            // txtTglFrom
            // 
            this.txtTglFrom.Enabled = false;
            this.txtTglFrom.Location = new System.Drawing.Point(140, 263);
            this.txtTglFrom.Name = "txtTglFrom";
            this.txtTglFrom.Size = new System.Drawing.Size(135, 20);
            this.txtTglFrom.TabIndex = 8;
            // 
            // txtTglTo
            // 
            this.txtTglTo.Enabled = false;
            this.txtTglTo.Location = new System.Drawing.Point(324, 263);
            this.txtTglTo.Name = "txtTglTo";
            this.txtTglTo.Size = new System.Drawing.Size(138, 20);
            this.txtTglTo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "s/d";
            // 
            // cmdKunjunganBaru
            // 
            this.cmdKunjunganBaru.Location = new System.Drawing.Point(499, 145);
            this.cmdKunjunganBaru.Name = "cmdKunjunganBaru";
            this.cmdKunjunganBaru.Size = new System.Drawing.Size(117, 57);
            this.cmdKunjunganBaru.TabIndex = 11;
            this.cmdKunjunganBaru.Text = "&Buat Kunjungan Baru";
            this.cmdKunjunganBaru.UseVisualStyleBackColor = true;
            this.cmdKunjunganBaru.Click += new System.EventHandler(this.cmdKunjunganBaru_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rgbTglKunjungan);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(22, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 59);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kunjungan Bulan Lalu";
            // 
            // rgbTglKunjungan
            // 
            this.rgbTglKunjungan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglKunjungan.FromDate = null;
            this.rgbTglKunjungan.Location = new System.Drawing.Point(130, 24);
            this.rgbTglKunjungan.Name = "rgbTglKunjungan";
            this.rgbTglKunjungan.Size = new System.Drawing.Size(291, 22);
            this.rgbTglKunjungan.TabIndex = 58;
            this.rgbTglKunjungan.ToDate = null;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(103, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kunj Bulan Lalu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.helpToolTipButton1);
            this.panel1.Controls.Add(this.cmdProses);
            this.panel1.Controls.Add(this.cbOutletAktif);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.cbHari);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtKodeSales);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(625, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 229);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // helpToolTipButton1
            // 
            this.helpToolTipButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("helpToolTipButton1.BackgroundImage")));
            this.helpToolTipButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpToolTipButton1.Location = new System.Drawing.Point(474, 199);
            this.helpToolTipButton1.Name = "helpToolTipButton1";
            this.helpToolTipButton1.Size = new System.Drawing.Size(23, 23);
            this.helpToolTipButton1.TabIndex = 20;
            this.helpToolTipButton1.Text = " ";
            this.helpToolTipButton1.UseVisualStyleBackColor = true;
            // 
            // cmdProses
            // 
            this.cmdProses.Location = new System.Drawing.Point(241, 195);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(92, 26);
            this.cmdProses.TabIndex = 19;
            this.cmdProses.Text = "PROSES";
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // cbOutletAktif
            // 
            this.cbOutletAktif.AutoSize = true;
            this.cbOutletAktif.Location = new System.Drawing.Point(23, 200);
            this.cbOutletAktif.Name = "cbOutletAktif";
            this.cbOutletAktif.Size = new System.Drawing.Size(149, 18);
            this.cbOutletAktif.TabIndex = 18;
            this.cbOutletAktif.Text = "Ambil Data Outlet Aktif";
            this.cbOutletAktif.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDaerah);
            this.groupBox2.Controls.Add(this.txtKota);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(22, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 76);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Area";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtDaerah
            // 
            this.txtDaerah.Enabled = false;
            this.txtDaerah.Location = new System.Drawing.Point(102, 44);
            this.txtDaerah.Name = "txtDaerah";
            this.txtDaerah.Size = new System.Drawing.Size(218, 20);
            this.txtDaerah.TabIndex = 5;
            // 
            // txtKota
            // 
            this.txtKota.Enabled = false;
            this.txtKota.Location = new System.Drawing.Point(102, 19);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(218, 20);
            this.txtKota.TabIndex = 4;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(65, 48);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(65, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Daerah";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Kota";
            // 
            // cbHari
            // 
            this.cbHari.FormattingEnabled = true;
            this.cbHari.Items.AddRange(new object[] {
            "MINGGU",
            "SENIN",
            "SELASA",
            "RABU",
            "KAMIS",
            "JUMAT",
            "SABTU",
            "ALL"});
            this.cbHari.Location = new System.Drawing.Point(324, 13);
            this.cbHari.Name = "cbHari";
            this.cbHari.Size = new System.Drawing.Size(173, 22);
            this.cbHari.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hari";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Kode Sales";
            // 
            // txtKodeSales
            // 
            this.txtKodeSales.Enabled = false;
            this.txtKodeSales.Location = new System.Drawing.Point(102, 16);
            this.txtKodeSales.Name = "txtKodeSales";
            this.txtKodeSales.Size = new System.Drawing.Size(155, 20);
            this.txtKodeSales.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.customGridView2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(30, 306);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1115, 254);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // customGridView2
            // 
            this.customGridView2.AllowUserToAddRows = false;
            this.customGridView2.AllowUserToDeleteRows = false;
            this.customGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.kd_Sales,
            this.Tmt1,
            this.Tmt2,
            this.Jenis,
            this.NamaToko,
            this.Alamat,
            this.Kota,
            this.Daerah,
            this.Kecamatan,
            this.AreaCode,
            this.Mg1,
            this.Mg2,
            this.Mg3,
            this.Mg4,
            this.Mg5});
            this.customGridView2.Location = new System.Drawing.Point(3, 3);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(1109, 248);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 0;
            this.customGridView2.Click += new System.EventHandler(this.customGridView2_Click);
            // 
            // cmdPrintRegisterKunjungan
            // 
            this.cmdPrintRegisterKunjungan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrintRegisterKunjungan.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.None;
            this.cmdPrintRegisterKunjungan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdPrintRegisterKunjungan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrintRegisterKunjungan.Location = new System.Drawing.Point(27, 580);
            this.cmdPrintRegisterKunjungan.Name = "cmdPrintRegisterKunjungan";
            this.cmdPrintRegisterKunjungan.Size = new System.Drawing.Size(100, 40);
            this.cmdPrintRegisterKunjungan.TabIndex = 51;
            this.cmdPrintRegisterKunjungan.Text = "Print Register Kunjungan";
            this.cmdPrintRegisterKunjungan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrintRegisterKunjungan.UseVisualStyleBackColor = true;
            this.cmdPrintRegisterKunjungan.Click += new System.EventHandler(this.cmdPrintRegisterKunjungan_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton2.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.None;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(141, 580);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 52;
            this.commandButton2.Text = "Link Fixrute";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton3
            // 
            this.commandButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton3.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.None;
            this.commandButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commandButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton3.Location = new System.Drawing.Point(255, 580);
            this.commandButton3.Name = "commandButton3";
            this.commandButton3.Size = new System.Drawing.Size(100, 40);
            this.commandButton3.TabIndex = 53;
            this.commandButton3.Text = "Print Jadwal Kunjungan";
            this.commandButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton3.UseVisualStyleBackColor = true;
            this.commandButton3.Click += new System.EventHandler(this.commandButton3_Click);
            // 
            // commandButton4
            // 
            this.commandButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton4.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.None;
            this.commandButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commandButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton4.Location = new System.Drawing.Point(372, 580);
            this.commandButton4.Name = "commandButton4";
            this.commandButton4.Size = new System.Drawing.Size(100, 40);
            this.commandButton4.TabIndex = 54;
            this.commandButton4.Text = "Fixrute";
            this.commandButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton4.UseVisualStyleBackColor = true;
            this.commandButton4.Click += new System.EventHandler(this.commandButton4_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(702, 581);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 57;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(596, 581);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 56;
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
            this.cmdAdd.Location = new System.Drawing.Point(490, 581);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 55;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1042, 580);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 50;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Mg5
            // 
            this.Mg5.FalseValue = "0";
            this.Mg5.HeaderText = "Mg5";
            this.Mg5.Name = "Mg5";
            this.Mg5.ReadOnly = true;
            this.Mg5.TrueValue = "1";
            // 
            // Mg4
            // 
            this.Mg4.HeaderText = "Mg4";
            this.Mg4.Name = "Mg4";
            this.Mg4.ReadOnly = true;
            // 
            // Mg3
            // 
            this.Mg3.FalseValue = "0";
            this.Mg3.HeaderText = "Mg3";
            this.Mg3.Name = "Mg3";
            this.Mg3.ReadOnly = true;
            this.Mg3.TrueValue = "1";
            // 
            // Mg2
            // 
            this.Mg2.FalseValue = "0";
            this.Mg2.HeaderText = "Mg2";
            this.Mg2.Name = "Mg2";
            this.Mg2.ReadOnly = true;
            this.Mg2.TrueValue = "1";
            // 
            // Mg1
            // 
            this.Mg1.FalseValue = "0";
            this.Mg1.HeaderText = "Mg1";
            this.Mg1.Name = "Mg1";
            this.Mg1.ReadOnly = true;
            this.Mg1.TrueValue = "1";
            // 
            // AreaCode
            // 
            this.AreaCode.DataPropertyName = "areacode";
            this.AreaCode.HeaderText = "Area Code";
            this.AreaCode.Name = "AreaCode";
            this.AreaCode.ReadOnly = true;
            // 
            // Kecamatan
            // 
            this.Kecamatan.DataPropertyName = "kecamatan";
            this.Kecamatan.HeaderText = "Kecamatan";
            this.Kecamatan.Name = "Kecamatan";
            this.Kecamatan.ReadOnly = true;
            // 
            // Daerah
            // 
            this.Daerah.DataPropertyName = "daerah";
            this.Daerah.HeaderText = "Daerah";
            this.Daerah.Name = "Daerah";
            this.Daerah.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "namatoko";
            this.NamaToko.HeaderText = "NamaToko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // Jenis
            // 
            this.Jenis.DataPropertyName = "jenis";
            this.Jenis.HeaderText = "Jenis";
            this.Jenis.Name = "Jenis";
            this.Jenis.ReadOnly = true;
            // 
            // Tmt2
            // 
            this.Tmt2.DataPropertyName = "tmt2";
            this.Tmt2.HeaderText = "Tmt2";
            this.Tmt2.Name = "Tmt2";
            this.Tmt2.ReadOnly = true;
            // 
            // Tmt1
            // 
            this.Tmt1.DataPropertyName = "tmt1";
            this.Tmt1.HeaderText = "Tmt1";
            this.Tmt1.Name = "Tmt1";
            this.Tmt1.ReadOnly = true;
            // 
            // kd_Sales
            // 
            this.kd_Sales.DataPropertyName = "kd_sales";
            this.kd_Sales.HeaderText = "Kode Sales";
            this.kd_Sales.Name = "kd_Sales";
            this.kd_Sales.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmFixRuteSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 634);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.commandButton4);
            this.Controls.Add(this.commandButton3);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.cmdPrintRegisterKunjungan);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTglTo);
            this.Controls.Add(this.txtTglFrom);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.cbSalesCabang);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdKunjunganBaru);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmFixRuteSalesman";
            this.Text = "FIXRUTE Salesman";
            this.Title = "FIXRUTE Salesman";
            this.Load += new System.EventHandler(this.frmFixRuteSalesman_Load);
            this.Click += new System.EventHandler(this.frmFixRuteSalesman_Click);
            this.Controls.SetChildIndex(this.cmdKunjunganBaru, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cbSalesCabang, 0);
            this.Controls.SetChildIndex(this.cbFilter, 0);
            this.Controls.SetChildIndex(this.txtTglFrom, 0);
            this.Controls.SetChildIndex(this.txtTglTo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdPrintRegisterKunjungan, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.commandButton3, 0);
            this.Controls.SetChildIndex(this.commandButton4, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSalesCabang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.CheckBox cbFilter;
        private System.Windows.Forms.TextBox txtTglFrom;
        private System.Windows.Forms.TextBox txtTglTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdKunjunganBaru;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbHari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKodeSales;
        private System.Windows.Forms.Button cmdProses;
        private System.Windows.Forms.CheckBox cbOutletAktif;
        private ISA.Toko.Controls.HelpToolTipButton helpToolTipButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDaerah;
        private System.Windows.Forms.TextBox txtKota;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ISA.Controls.CustomGridView customGridView2;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdPrintRegisterKunjungan;
        private ISA.Toko.Controls.CommandButton commandButton2;
        private ISA.Toko.Controls.CommandButton commandButton3;
        private ISA.Toko.Controls.CommandButton commandButton4;
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private ISA.Toko.Controls.CommandButton cmdEdit;
        private ISA.Toko.Controls.CommandButton cmdAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama_Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode_Sales;
        private ISA.Toko.Controls.RangeDateBox rgbTglKunjungan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tmt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tmt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenis;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daerah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kecamatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mg1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mg2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mg3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mg4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mg5;
    }
}