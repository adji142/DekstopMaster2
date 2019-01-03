namespace ISA.Toko.POS
{
    partial class FrmTabelPOS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTabelPOS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rangeDateBox1 = new ISA.Toko.Controls.RangeDateBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.txtJumlahHPP2 = new System.Windows.Forms.Label();
            this.txtHargaNett2 = new System.Windows.Forms.Label();
            this.txtJumlahPotongan2 = new System.Windows.Forms.Label();
            this.txtJumlahHarga2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DGVHeaderPenjualan = new ISA.Toko.Controls.CustomGridView();
            this.HeadC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadNoReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadTglReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadNoDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadTGLDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadNoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadTglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadTrm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadTokoCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadAlamatKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadRpJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadRpNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdAdd = new ISA.Toko.Controls.CustomGridView();
            this.DetNamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetQtyDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetQtyNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetHBMK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetHJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetJumHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetHNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdDel = new ISA.Toko.Controls.CommandButton();
            this.CmdEdit = new ISA.Toko.Controls.CommandButton();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.CmdKeluar = new ISA.Toko.Controls.CommandButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHeaderPenjualan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdAdd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(61, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 59);
            this.panel1.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(289, 29);
            this.label14.TabIndex = 8;
            this.label14.Text = "TABEL PENJUALAN";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(657, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rangeDateBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Location = new System.Drawing.Point(443, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 58);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(73, 19);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 71;
            this.rangeDateBox1.ToDate = null;
            this.rangeDateBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangeDateBox1_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(656, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 19);
            this.label8.TabIndex = 58;
            this.label8.Text = "label8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Range";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(332, 16);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 54;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(59, 300);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(63, 14);
            this.lblHeader.TabIndex = 18;
            this.lblHeader.Text = "LblHeader";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Location = new System.Drawing.Point(59, 531);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(54, 14);
            this.lblDetail.TabIndex = 19;
            this.lblDetail.Text = "LblDetail";
            // 
            // txtJumlahHPP2
            // 
            this.txtJumlahHPP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJumlahHPP2.BackColor = System.Drawing.SystemColors.Window;
            this.txtJumlahHPP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtJumlahHPP2.Location = new System.Drawing.Point(1013, 577);
            this.txtJumlahHPP2.Name = "txtJumlahHPP2";
            this.txtJumlahHPP2.Size = new System.Drawing.Size(116, 20);
            this.txtJumlahHPP2.TabIndex = 62;
            this.txtJumlahHPP2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHargaNett2
            // 
            this.txtHargaNett2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHargaNett2.BackColor = System.Drawing.SystemColors.Window;
            this.txtHargaNett2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHargaNett2.Location = new System.Drawing.Point(813, 578);
            this.txtHargaNett2.Name = "txtHargaNett2";
            this.txtHargaNett2.Size = new System.Drawing.Size(116, 20);
            this.txtHargaNett2.TabIndex = 61;
            this.txtHargaNett2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtJumlahPotongan2
            // 
            this.txtJumlahPotongan2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJumlahPotongan2.BackColor = System.Drawing.SystemColors.Window;
            this.txtJumlahPotongan2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtJumlahPotongan2.Location = new System.Drawing.Point(1013, 551);
            this.txtJumlahPotongan2.Name = "txtJumlahPotongan2";
            this.txtJumlahPotongan2.Size = new System.Drawing.Size(116, 20);
            this.txtJumlahPotongan2.TabIndex = 60;
            this.txtJumlahPotongan2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtJumlahHarga2
            // 
            this.txtJumlahHarga2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJumlahHarga2.BackColor = System.Drawing.SystemColors.Window;
            this.txtJumlahHarga2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtJumlahHarga2.Location = new System.Drawing.Point(813, 550);
            this.txtJumlahHarga2.Name = "txtJumlahHarga2";
            this.txtJumlahHarga2.Size = new System.Drawing.Size(116, 20);
            this.txtJumlahHarga2.TabIndex = 59;
            this.txtJumlahHarga2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(758, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 58;
            this.label3.Text = "Hrg Nett";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(758, 553);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 57;
            this.label4.Text = "Jml Hrg";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(960, 578);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 56;
            this.label5.Text = "Jml HPP";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(960, 550);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 55;
            this.label6.Text = "Jml Pot";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DGVHeaderPenjualan
            // 
            this.DGVHeaderPenjualan.AllowUserToAddRows = false;
            this.DGVHeaderPenjualan.AllowUserToDeleteRows = false;
            this.DGVHeaderPenjualan.AllowUserToResizeColumns = false;
            this.DGVHeaderPenjualan.AllowUserToResizeRows = false;
            this.DGVHeaderPenjualan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVHeaderPenjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHeaderPenjualan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeadC1,
            this.HeadC2,
            this.HeadNoReq,
            this.HeadTglReq,
            this.HeadNoDO,
            this.HeadTGLDO,
            this.HeadNoNota,
            this.HeadTglNota,
            this.HeadTrm,
            this.headSales,
            this.HeadTokoCust,
            this.HeadAlamatKirim,
            this.HeadRpJual,
            this.HeadRpNet,
            this.HeadRowID});
            this.DGVHeaderPenjualan.Location = new System.Drawing.Point(61, 77);
            this.DGVHeaderPenjualan.MultiSelect = false;
            this.DGVHeaderPenjualan.Name = "DGVHeaderPenjualan";
            this.DGVHeaderPenjualan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGVHeaderPenjualan.Size = new System.Drawing.Size(1193, 220);
            this.DGVHeaderPenjualan.StandardTab = true;
            this.DGVHeaderPenjualan.TabIndex = 63;
            this.DGVHeaderPenjualan.SelectionRowChanged += new System.EventHandler(this.DGVHeaderPenjualan_SelectionRowChanged);
            this.DGVHeaderPenjualan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHeaderPenjualan_CellContentClick);
            // 
            // HeadC1
            // 
            this.HeadC1.DataPropertyName = "cabang1";
            this.HeadC1.Frozen = true;
            this.HeadC1.HeaderText = "CABANG I";
            this.HeadC1.Name = "HeadC1";
            this.HeadC1.ReadOnly = true;
            // 
            // HeadC2
            // 
            this.HeadC2.DataPropertyName = "cabang2";
            this.HeadC2.Frozen = true;
            this.HeadC2.HeaderText = "CABANG II";
            this.HeadC2.Name = "HeadC2";
            this.HeadC2.ReadOnly = true;
            // 
            // HeadNoReq
            // 
            this.HeadNoReq.DataPropertyName = "NoRequest";
            this.HeadNoReq.Frozen = true;
            this.HeadNoReq.HeaderText = "NO REQUEST";
            this.HeadNoReq.Name = "HeadNoReq";
            this.HeadNoReq.ReadOnly = true;
            // 
            // HeadTglReq
            // 
            this.HeadTglReq.DataPropertyName = "TglRequest";
            this.HeadTglReq.Frozen = true;
            this.HeadTglReq.HeaderText = "TGL REQUEST";
            this.HeadTglReq.Name = "HeadTglReq";
            this.HeadTglReq.ReadOnly = true;
            // 
            // HeadNoDO
            // 
            this.HeadNoDO.DataPropertyName = "NoDO";
            this.HeadNoDO.Frozen = true;
            this.HeadNoDO.HeaderText = "NO DO";
            this.HeadNoDO.Name = "HeadNoDO";
            this.HeadNoDO.ReadOnly = true;
            // 
            // HeadTGLDO
            // 
            this.HeadTGLDO.DataPropertyName = "TglDO";
            this.HeadTGLDO.Frozen = true;
            this.HeadTGLDO.HeaderText = "TGL DO";
            this.HeadTGLDO.Name = "HeadTGLDO";
            this.HeadTGLDO.ReadOnly = true;
            // 
            // HeadNoNota
            // 
            this.HeadNoNota.DataPropertyName = "NoNota";
            this.HeadNoNota.Frozen = true;
            this.HeadNoNota.HeaderText = "NO NOTA";
            this.HeadNoNota.Name = "HeadNoNota";
            this.HeadNoNota.ReadOnly = true;
            // 
            // HeadTglNota
            // 
            this.HeadTglNota.DataPropertyName = "TglNota";
            this.HeadTglNota.HeaderText = "TGL NOTA";
            this.HeadTglNota.Name = "HeadTglNota";
            this.HeadTglNota.ReadOnly = true;
            // 
            // HeadTrm
            // 
            this.HeadTrm.DataPropertyName = "TglTerima";
            this.HeadTrm.HeaderText = "Tgl TERIMA";
            this.HeadTrm.Name = "HeadTrm";
            this.HeadTrm.ReadOnly = true;
            // 
            // headSales
            // 
            this.headSales.DataPropertyName = "NamaSales";
            this.headSales.HeaderText = "SALES";
            this.headSales.Name = "headSales";
            this.headSales.ReadOnly = true;
            // 
            // HeadTokoCust
            // 
            this.HeadTokoCust.DataPropertyName = "NamaToko";
            this.HeadTokoCust.HeaderText = "TOKO/CUSTOMER";
            this.HeadTokoCust.Name = "HeadTokoCust";
            this.HeadTokoCust.ReadOnly = true;
            this.HeadTokoCust.Width = 150;
            // 
            // HeadAlamatKirim
            // 
            this.HeadAlamatKirim.DataPropertyName = "AlamatKirim";
            this.HeadAlamatKirim.HeaderText = "Alamat Kirim";
            this.HeadAlamatKirim.Name = "HeadAlamatKirim";
            this.HeadAlamatKirim.ReadOnly = true;
            this.HeadAlamatKirim.Visible = false;
            // 
            // HeadRpJual
            // 
            this.HeadRpJual.DataPropertyName = "RpJual";
            this.HeadRpJual.HeaderText = "RP JUAL";
            this.HeadRpJual.Name = "HeadRpJual";
            this.HeadRpJual.ReadOnly = true;
            this.HeadRpJual.Visible = false;
            // 
            // HeadRpNet
            // 
            this.HeadRpNet.DataPropertyName = "RpNet";
            this.HeadRpNet.HeaderText = "RP NET";
            this.HeadRpNet.Name = "HeadRpNet";
            this.HeadRpNet.ReadOnly = true;
            this.HeadRpNet.Visible = false;
            // 
            // HeadRowID
            // 
            this.HeadRowID.DataPropertyName = "RowID";
            this.HeadRowID.HeaderText = "ROW ID";
            this.HeadRowID.Name = "HeadRowID";
            this.HeadRowID.ReadOnly = true;
            this.HeadRowID.Visible = false;
            // 
            // CmdAdd
            // 
            this.CmdAdd.AllowUserToAddRows = false;
            this.CmdAdd.AllowUserToDeleteRows = false;
            this.CmdAdd.AllowUserToResizeColumns = false;
            this.CmdAdd.AllowUserToResizeRows = false;
            this.CmdAdd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CmdAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CmdAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetNamaStok,
            this.DetQtyDO,
            this.DetQtyNota,
            this.DetSatuan,
            this.DetHBMK,
            this.DetHJual,
            this.DetJumHarga,
            this.DetHNet});
            this.CmdAdd.Location = new System.Drawing.Point(62, 328);
            this.CmdAdd.MultiSelect = false;
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.CmdAdd.Size = new System.Drawing.Size(1192, 200);
            this.CmdAdd.StandardTab = true;
            this.CmdAdd.TabIndex = 64;
            this.CmdAdd.SelectionRowChanged += new System.EventHandler(this.DGVDetail_SelectionRowChanged);
            this.CmdAdd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVDetail_CellFormatting);
            this.CmdAdd.Click += new System.EventHandler(this.DGVDetail_Click);
            this.CmdAdd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDetail_CellContentClick);
            // 
            // DetNamaStok
            // 
            this.DetNamaStok.DataPropertyName = "NamaSTok";
            this.DetNamaStok.HeaderText = "NAMA STOK";
            this.DetNamaStok.Name = "DetNamaStok";
            this.DetNamaStok.ReadOnly = true;
            this.DetNamaStok.Width = 250;
            // 
            // DetQtyDO
            // 
            this.DetQtyDO.DataPropertyName = "QtyDO";
            this.DetQtyDO.HeaderText = "QTY DO";
            this.DetQtyDO.Name = "DetQtyDO";
            this.DetQtyDO.ReadOnly = true;
            // 
            // DetQtyNota
            // 
            this.DetQtyNota.DataPropertyName = "QtyNota";
            this.DetQtyNota.HeaderText = "QTY NOTA";
            this.DetQtyNota.Name = "DetQtyNota";
            this.DetQtyNota.ReadOnly = true;
            // 
            // DetSatuan
            // 
            this.DetSatuan.DataPropertyName = "SatSolo";
            this.DetSatuan.HeaderText = "SATUAN";
            this.DetSatuan.Name = "DetSatuan";
            this.DetSatuan.ReadOnly = true;
            // 
            // DetHBMK
            // 
            this.DetHBMK.DataPropertyName = "HrgBMK";
            dataGridViewCellStyle1.Format = "N0";
            this.DetHBMK.DefaultCellStyle = dataGridViewCellStyle1;
            this.DetHBMK.HeaderText = "HARGA BMK";
            this.DetHBMK.Name = "DetHBMK";
            this.DetHBMK.ReadOnly = true;
            // 
            // DetHJual
            // 
            this.DetHJual.DataPropertyName = "HrgJual";
            dataGridViewCellStyle2.Format = "N0";
            this.DetHJual.DefaultCellStyle = dataGridViewCellStyle2;
            this.DetHJual.HeaderText = "HARGA JUAL";
            this.DetHJual.Name = "DetHJual";
            this.DetHJual.ReadOnly = true;
            // 
            // DetJumHarga
            // 
            this.DetJumHarga.DataPropertyName = "RpJual";
            dataGridViewCellStyle3.Format = "N0";
            this.DetJumHarga.DefaultCellStyle = dataGridViewCellStyle3;
            this.DetJumHarga.HeaderText = "JUMLAH HARGA";
            this.DetJumHarga.Name = "DetJumHarga";
            this.DetJumHarga.ReadOnly = true;
            // 
            // DetHNet
            // 
            this.DetHNet.DataPropertyName = "HrgNet";
            dataGridViewCellStyle4.Format = "N0";
            this.DetHNet.DefaultCellStyle = dataGridViewCellStyle4;
            this.DetHNet.HeaderText = "HARGA NET";
            this.DetHNet.Name = "DetHNet";
            this.DetHNet.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdDel);
            this.groupBox2.Controls.Add(this.CmdEdit);
            this.groupBox2.Controls.Add(this.commandButton1);
            this.groupBox2.Controls.Add(this.CmdKeluar);
            this.groupBox2.Location = new System.Drawing.Point(65, 548);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 69);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            // 
            // cmdDel
            // 
            this.cmdDel.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDel.Image = ((System.Drawing.Image)(resources.GetObject("cmdDel.Image")));
            this.cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDel.Location = new System.Drawing.Point(229, 15);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Size = new System.Drawing.Size(100, 40);
            this.cmdDel.TabIndex = 72;
            this.cmdDel.Text = "DELETE";
            this.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDel.UseVisualStyleBackColor = true;
            // 
            // CmdEdit
            // 
            this.CmdEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.CmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("CmdEdit.Image")));
            this.CmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdEdit.Location = new System.Drawing.Point(123, 15);
            this.CmdEdit.Name = "CmdEdit";
            this.CmdEdit.Size = new System.Drawing.Size(100, 40);
            this.CmdEdit.TabIndex = 71;
            this.CmdEdit.Text = "EDIT";
            this.CmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CmdEdit.UseVisualStyleBackColor = true;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(17, 15);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 70;
            this.commandButton1.Text = "ADD";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            // 
            // CmdKeluar
            // 
            this.CmdKeluar.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.CmdKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CmdKeluar.Image = ((System.Drawing.Image)(resources.GetObject("CmdKeluar.Image")));
            this.CmdKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdKeluar.Location = new System.Drawing.Point(337, 15);
            this.CmdKeluar.Name = "CmdKeluar";
            this.CmdKeluar.Size = new System.Drawing.Size(100, 40);
            this.CmdKeluar.TabIndex = 69;
            this.CmdKeluar.Text = "CLOSE";
            this.CmdKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CmdKeluar.UseVisualStyleBackColor = true;
            this.CmdKeluar.Click += new System.EventHandler(this.CmdKeluar_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(63, 559);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 60);
            this.panel2.TabIndex = 70;
            // 
            // FrmTabelPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 630);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.DGVHeaderPenjualan);
            this.Controls.Add(this.txtJumlahHPP2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtHargaNett2);
            this.Controls.Add(this.txtJumlahPotongan2);
            this.Controls.Add(this.txtJumlahHarga2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmTabelPOS";
            this.Text = "";
            this.Title = "";
            this.Load += new System.EventHandler(this.FrmTabelPOS_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblHeader, 0);
            this.Controls.SetChildIndex(this.lblDetail, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtJumlahHarga2, 0);
            this.Controls.SetChildIndex(this.txtJumlahPotongan2, 0);
            this.Controls.SetChildIndex(this.txtHargaNett2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtJumlahHPP2, 0);
            this.Controls.SetChildIndex(this.DGVHeaderPenjualan, 0);
            this.Controls.SetChildIndex(this.CmdAdd, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHeaderPenjualan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmdAdd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtJumlahHPP2;
        private System.Windows.Forms.Label txtHargaNett2;
        private System.Windows.Forms.Label txtJumlahPotongan2;
        private System.Windows.Forms.Label txtJumlahHarga2;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private ISA.Toko.Controls.CustomGridView DGVHeaderPenjualan;
        private ISA.Toko.Controls.CustomGridView CmdAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private ISA.Toko.Controls.CommandButton cmdDel;
        private ISA.Toko.Controls.CommandButton CmdEdit;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton CmdKeluar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetNamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetQtyDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetQtyNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetHBMK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetHJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetJumHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetHNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadNoReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadTglReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadNoDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadTGLDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadNoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadTglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadTrm;
        private System.Windows.Forms.DataGridViewTextBoxColumn headSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadTokoCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadAlamatKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadRpJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadRpNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadRowID;
        private ISA.Toko.Controls.RangeDateBox rangeDateBox1;
    }
}