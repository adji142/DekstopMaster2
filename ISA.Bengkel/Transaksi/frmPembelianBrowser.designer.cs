namespace ISA.Bengkel.Transaksi
{
    partial class frmPembelianBrowser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembelianBrowser));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDetail1 = new ISA.Controls.CustomGridView();
            this.RowIDDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j_nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h_beli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.potrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdgdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlagd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedByd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTimed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHeader = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_srv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kd_spm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatPemasok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_beli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rp_net = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tgl_trm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_disc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pot_rp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syncflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.rgbTglPembelian = new ISA.Controls.RangeDateBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.helpToolTipButton1 = new ISA.Controls.HelpToolTipButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvDetail1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvHeader, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 123);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(848, 449);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dgvDetail1
            // 
            this.dgvDetail1.AllowUserToAddRows = false;
            this.dgvDetail1.AllowUserToDeleteRows = false;
            this.dgvDetail1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDDetail,
            this.HeaderID,
            this.NamaStok,
            this.satuan,
            this.j_nota,
            this.j_sj,
            this.h_beli,
            this.RpBeli,
            this.RpNet,
            this.disc1,
            this.disc2,
            this.disc3,
            this.iddisc,
            this.potrp,
            this.ppnd,
            this.idbrg,
            this.catatand,
            this.kdgdg,
            this.SyncFlagd,
            this.LastUpdatedByd,
            this.LastUpdatedTimed});
            this.dgvDetail1.Location = new System.Drawing.Point(3, 227);
            this.dgvDetail1.MultiSelect = false;
            this.dgvDetail1.Name = "dgvDetail1";
            this.dgvDetail1.ReadOnly = true;
            this.dgvDetail1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail1.Size = new System.Drawing.Size(842, 219);
            this.dgvDetail1.StandardTab = true;
            this.dgvDetail1.TabIndex = 3;
            // 
            // RowIDDetail
            // 
            this.RowIDDetail.DataPropertyName = "RowID";
            this.RowIDDetail.HeaderText = "RowID";
            this.RowIDDetail.Name = "RowIDDetail";
            this.RowIDDetail.ReadOnly = true;
            this.RowIDDetail.Visible = false;
            // 
            // HeaderID
            // 
            this.HeaderID.DataPropertyName = "HeaderID";
            this.HeaderID.HeaderText = "HeaderID";
            this.HeaderID.Name = "HeaderID";
            this.HeaderID.ReadOnly = true;
            this.HeaderID.Visible = false;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "NAMA BARANG";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 300;
            // 
            // satuan
            // 
            this.satuan.DataPropertyName = "Satuan";
            this.satuan.HeaderText = "SAT";
            this.satuan.Name = "satuan";
            this.satuan.ReadOnly = true;
            this.satuan.Width = 40;
            // 
            // j_nota
            // 
            this.j_nota.DataPropertyName = "j_nota";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.j_nota.DefaultCellStyle = dataGridViewCellStyle1;
            this.j_nota.HeaderText = "J. NOTA";
            this.j_nota.Name = "j_nota";
            this.j_nota.ReadOnly = true;
            this.j_nota.Width = 80;
            // 
            // j_sj
            // 
            this.j_sj.DataPropertyName = "j_sj";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.j_sj.DefaultCellStyle = dataGridViewCellStyle2;
            this.j_sj.HeaderText = "J. TERIMA";
            this.j_sj.Name = "j_sj";
            this.j_sj.ReadOnly = true;
            this.j_sj.Width = 90;
            // 
            // h_beli
            // 
            this.h_beli.DataPropertyName = "h_beli";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.h_beli.DefaultCellStyle = dataGridViewCellStyle3;
            this.h_beli.HeaderText = "H. BELI";
            this.h_beli.Name = "h_beli";
            this.h_beli.ReadOnly = true;
            this.h_beli.Width = 90;
            // 
            // RpBeli
            // 
            this.RpBeli.DataPropertyName = "RpBeli";
            this.RpBeli.HeaderText = "Rp BELI";
            this.RpBeli.Name = "RpBeli";
            this.RpBeli.ReadOnly = true;
            // 
            // RpNet
            // 
            this.RpNet.DataPropertyName = "RpNet";
            this.RpNet.HeaderText = "Rp NET";
            this.RpNet.Name = "RpNet";
            this.RpNet.ReadOnly = true;
            // 
            // disc1
            // 
            this.disc1.DataPropertyName = "disc_1";
            this.disc1.HeaderText = "Disc1";
            this.disc1.Name = "disc1";
            this.disc1.ReadOnly = true;
            this.disc1.Width = 50;
            // 
            // disc2
            // 
            this.disc2.DataPropertyName = "disc_2";
            this.disc2.HeaderText = "Disc2";
            this.disc2.Name = "disc2";
            this.disc2.ReadOnly = true;
            this.disc2.Width = 50;
            // 
            // disc3
            // 
            this.disc3.DataPropertyName = "disc_3";
            this.disc3.HeaderText = "Disc3";
            this.disc3.Name = "disc3";
            this.disc3.ReadOnly = true;
            this.disc3.Width = 50;
            // 
            // iddisc
            // 
            this.iddisc.DataPropertyName = "id_disc";
            this.iddisc.HeaderText = "IdDisc";
            this.iddisc.Name = "iddisc";
            this.iddisc.ReadOnly = true;
            this.iddisc.Width = 50;
            // 
            // potrp
            // 
            this.potrp.DataPropertyName = "pot_rp";
            this.potrp.HeaderText = "Pot";
            this.potrp.Name = "potrp";
            this.potrp.ReadOnly = true;
            this.potrp.Width = 90;
            // 
            // ppnd
            // 
            this.ppnd.DataPropertyName = "ppn";
            this.ppnd.HeaderText = "Ppn";
            this.ppnd.Name = "ppnd";
            this.ppnd.ReadOnly = true;
            this.ppnd.Width = 50;
            // 
            // idbrg
            // 
            this.idbrg.DataPropertyName = "id_brg";
            this.idbrg.HeaderText = "IDBRG";
            this.idbrg.Name = "idbrg";
            this.idbrg.ReadOnly = true;
            this.idbrg.Width = 120;
            // 
            // catatand
            // 
            this.catatand.DataPropertyName = "catatan1";
            this.catatand.HeaderText = "Catatan";
            this.catatand.Name = "catatand";
            this.catatand.ReadOnly = true;
            this.catatand.Width = 150;
            // 
            // kdgdg
            // 
            this.kdgdg.DataPropertyName = "kd_gdg";
            this.kdgdg.HeaderText = "Gudang";
            this.kdgdg.Name = "kdgdg";
            this.kdgdg.ReadOnly = true;
            this.kdgdg.Width = 50;
            // 
            // SyncFlagd
            // 
            this.SyncFlagd.DataPropertyName = "SyncFlag";
            this.SyncFlagd.HeaderText = "SyncFlag";
            this.SyncFlagd.Name = "SyncFlagd";
            this.SyncFlagd.ReadOnly = true;
            this.SyncFlagd.Width = 70;
            // 
            // LastUpdatedByd
            // 
            this.LastUpdatedByd.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedByd.HeaderText = "LastUpdatedBy";
            this.LastUpdatedByd.Name = "LastUpdatedByd";
            this.LastUpdatedByd.ReadOnly = true;
            this.LastUpdatedByd.Width = 120;
            // 
            // LastUpdatedTimed
            // 
            this.LastUpdatedTimed.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTimed.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTimed.Name = "LastUpdatedTimed";
            this.LastUpdatedTimed.ReadOnly = true;
            this.LastUpdatedTimed.Width = 150;
            // 
            // dgvHeader
            // 
            this.dgvHeader.AllowUserToAddRows = false;
            this.dgvHeader.AllowUserToDeleteRows = false;
            this.dgvHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.tgl_srv,
            this.nomor,
            this.kd_spm,
            this.AlamatPemasok,
            this.rp_beli,
            this.rp_net,
            this.Tgl_trm,
            this.disc_1,
            this.disc_2,
            this.disc_3,
            this.id_disc,
            this.pot_rp,
            this.ppn,
            this.catatan1,
            this.syncflag,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dgvHeader.Location = new System.Drawing.Point(3, 3);
            this.dgvHeader.MultiSelect = false;
            this.dgvHeader.Name = "dgvHeader";
            this.dgvHeader.ReadOnly = true;
            this.dgvHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHeader.Size = new System.Drawing.Size(842, 218);
            this.dgvHeader.StandardTab = true;
            this.dgvHeader.TabIndex = 0;
            this.dgvHeader.SelectionRowChanged += new System.EventHandler(this.dataGridHeader_SelectionRowChanged);
            this.dgvHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridHeader_KeyDown);
            this.dgvHeader.Click += new System.EventHandler(this.dataGridHeader_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // tgl_srv
            // 
            this.tgl_srv.DataPropertyName = "tgl_srv";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.tgl_srv.DefaultCellStyle = dataGridViewCellStyle4;
            this.tgl_srv.HeaderText = "TGL. NOTA";
            this.tgl_srv.Name = "tgl_srv";
            this.tgl_srv.ReadOnly = true;
            this.tgl_srv.Width = 90;
            // 
            // nomor
            // 
            this.nomor.DataPropertyName = "nomor";
            this.nomor.HeaderText = "NO. NOTA";
            this.nomor.Name = "nomor";
            this.nomor.ReadOnly = true;
            this.nomor.Width = 90;
            // 
            // kd_spm
            // 
            this.kd_spm.DataPropertyName = "kd_spm";
            this.kd_spm.HeaderText = "PEMASOK";
            this.kd_spm.Name = "kd_spm";
            this.kd_spm.ReadOnly = true;
            this.kd_spm.Width = 150;
            // 
            // AlamatPemasok
            // 
            this.AlamatPemasok.DataPropertyName = "Alamat";
            this.AlamatPemasok.HeaderText = "ALAMAT";
            this.AlamatPemasok.Name = "AlamatPemasok";
            this.AlamatPemasok.ReadOnly = true;
            this.AlamatPemasok.Width = 310;
            // 
            // rp_beli
            // 
            this.rp_beli.DataPropertyName = "rp_beli";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.rp_beli.DefaultCellStyle = dataGridViewCellStyle5;
            this.rp_beli.HeaderText = "Rp. BELI";
            this.rp_beli.Name = "rp_beli";
            this.rp_beli.ReadOnly = true;
            this.rp_beli.Width = 80;
            // 
            // rp_net
            // 
            this.rp_net.DataPropertyName = "rp_net";
            this.rp_net.HeaderText = "Rp. NET";
            this.rp_net.Name = "rp_net";
            this.rp_net.ReadOnly = true;
            this.rp_net.Width = 80;
            // 
            // Tgl_trm
            // 
            this.Tgl_trm.DataPropertyName = "Tgl_trm";
            this.Tgl_trm.HeaderText = "TGL TERIMA";
            this.Tgl_trm.Name = "Tgl_trm";
            this.Tgl_trm.ReadOnly = true;
            // 
            // disc_1
            // 
            this.disc_1.DataPropertyName = "disc_1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.disc_1.DefaultCellStyle = dataGridViewCellStyle6;
            this.disc_1.HeaderText = "Disc1";
            this.disc_1.Name = "disc_1";
            this.disc_1.ReadOnly = true;
            this.disc_1.Visible = false;
            this.disc_1.Width = 40;
            // 
            // disc_2
            // 
            this.disc_2.DataPropertyName = "disc_2";
            this.disc_2.HeaderText = "Disc2";
            this.disc_2.Name = "disc_2";
            this.disc_2.ReadOnly = true;
            this.disc_2.Visible = false;
            this.disc_2.Width = 40;
            // 
            // disc_3
            // 
            this.disc_3.DataPropertyName = "disc_3";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.disc_3.DefaultCellStyle = dataGridViewCellStyle7;
            this.disc_3.HeaderText = "Disc3";
            this.disc_3.Name = "disc_3";
            this.disc_3.ReadOnly = true;
            this.disc_3.Visible = false;
            this.disc_3.Width = 40;
            // 
            // id_disc
            // 
            this.id_disc.DataPropertyName = "id_disc";
            this.id_disc.HeaderText = "ID. Disc";
            this.id_disc.Name = "id_disc";
            this.id_disc.ReadOnly = true;
            this.id_disc.Visible = false;
            this.id_disc.Width = 40;
            // 
            // pot_rp
            // 
            this.pot_rp.DataPropertyName = "pot_rp";
            this.pot_rp.HeaderText = "POT Rp";
            this.pot_rp.Name = "pot_rp";
            this.pot_rp.ReadOnly = true;
            this.pot_rp.Visible = false;
            this.pot_rp.Width = 80;
            // 
            // ppn
            // 
            this.ppn.DataPropertyName = "ppn";
            this.ppn.HeaderText = "PPn";
            this.ppn.Name = "ppn";
            this.ppn.ReadOnly = true;
            this.ppn.Visible = false;
            this.ppn.Width = 40;
            // 
            // catatan1
            // 
            this.catatan1.DataPropertyName = "catatan1";
            this.catatan1.HeaderText = "CATATAN";
            this.catatan1.Name = "catatan1";
            this.catatan1.ReadOnly = true;
            this.catatan1.Width = 150;
            // 
            // syncflag
            // 
            this.syncflag.DataPropertyName = "syncflag";
            this.syncflag.HeaderText = "SyncFlag";
            this.syncflag.Name = "syncflag";
            this.syncflag.ReadOnly = true;
            this.syncflag.Width = 70;
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
            this.LastUpdatedTime.Width = 150;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(364, 90);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rgbTglPembelian
            // 
            this.rgbTglPembelian.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglPembelian.FromDate = null;
            this.rgbTglPembelian.Location = new System.Drawing.Point(107, 92);
            this.rgbTglPembelian.Name = "rgbTglPembelian";
            this.rgbTglPembelian.Size = new System.Drawing.Size(263, 19);
            this.rgbTglPembelian.TabIndex = 0;
            this.rgbTglPembelian.ToDate = null;
            this.rgbTglPembelian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTglRQ_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 14);
            this.label5.TabIndex = 42;
            this.label5.Text = "Range tanggal :";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(334, 581);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 69;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(228, 581);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 68;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(122, 581);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 67;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(16, 581);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 66;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // helpToolTipButton1
            // 
            this.helpToolTipButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpToolTipButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("helpToolTipButton1.BackgroundImage")));
            this.helpToolTipButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpToolTipButton1.Location = new System.Drawing.Point(840, 93);
            this.helpToolTipButton1.Name = "helpToolTipButton1";
            this.helpToolTipButton1.Size = new System.Drawing.Size(23, 23);
            this.helpToolTipButton1.TabIndex = 53;
            this.helpToolTipButton1.Text = " ";
            this.toolTip1.SetToolTip(this.helpToolTipButton1, "F3                    Form order harian\r\nF4                    Ambil data dari BO" +
                    "\r\nF5                    Uploading purchasing order\r\nCtl+Shift+L     List detail");
            this.helpToolTipButton1.UseVisualStyleBackColor = true;
            this.helpToolTipButton1.Click += new System.EventHandler(this.helpToolTipButton1_Click);
            // 
            // frmPembelianBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(877, 683);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.helpToolTipButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rgbTglPembelian);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormID = "BKL0120";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPembelianBrowser";
            this.Text = "BKL0120 - PEMBELIAN";
            this.Title = "PEMBELIAN";
            this.Load += new System.EventHandler(this.frmPembelianBrowser_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.rgbTglPembelian, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.helpToolTipButton1, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView dgvHeader;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.RangeDateBox rgbTglPembelian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlHPPDO;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.CommandButton cmdClose;
        private Controls.CommandButton cmdDELETE;
        private Controls.CommandButton cmdEDIT;
        private Controls.CommandButton cmdADD;
        private Controls.CustomGridView dgvDetail1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_srv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomor;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_spm;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatPemasok;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_beli;
        private System.Windows.Forms.DataGridViewTextBoxColumn rp_net;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tgl_trm;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_disc;
        private System.Windows.Forms.DataGridViewTextBoxColumn pot_rp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncflag;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn j_nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn j_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn h_beli;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn potrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatand;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdgdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlagd;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedByd;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTimed;
        private ISA.Controls.HelpToolTipButton helpToolTipButton1;

    }
}
