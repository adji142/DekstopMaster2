namespace ISA.Finance.Kasir
{
    partial class frmBiayaOperasionalBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiayaOperasionalBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.rdbTanggal = new ISA.Controls.RangeDateBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotalDAcc1 = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalD = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalHAcc1 = new ISA.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalH1 = new ISA.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHeader = new ISA.Controls.CustomGridView();
            this.dgvDetail = new ISA.Controls.CustomGridView();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBiaya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBiayaAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BiayaOperasionalRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBiayaACC11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SisaBudget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdLinkBKK = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdHapusPin = new System.Windows.Forms.Button();
            this.cmdPin = new System.Windows.Forms.Button();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDOWNLOAD = new ISA.Controls.CommandButton();
            this.cmdUPLOAD = new ISA.Controls.CommandButton();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblDownload = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.cmdDownloadClose = new ISA.Controls.CommandButton();
            this.cmdDownloadGo = new ISA.Controls.CommandButton();
            this.label5 = new System.Windows.Forms.Label();
            this.POS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitKerja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keperluan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBiaya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBiayaAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panelDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(21, 64);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(92, 14);
            this.lblTanggal.TabIndex = 74;
            this.lblTanggal.Text = "Range Tanggal  ";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(390, 59);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.ReportName2 = "";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 73;
            this.cmdSearch.TabStop = false;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rdbTanggal
            // 
            this.rdbTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTanggal.FromDate = null;
            this.rdbTanggal.Location = new System.Drawing.Point(139, 61);
            this.rdbTanggal.Name = "rdbTanggal";
            this.rdbTanggal.Size = new System.Drawing.Size(257, 22);
            this.rdbTanggal.TabIndex = 72;
            this.rdbTanggal.TabStop = false;
            this.rdbTanggal.ToDate = null;
            this.rdbTanggal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdbTanggal_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDetail, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 89);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.74138F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.25862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 417);
            this.tableLayoutPanel1.TabIndex = 71;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTotalDAcc1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtTotalD);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 27);
            this.panel2.TabIndex = 72;
            // 
            // txtTotalDAcc1
            // 
            this.txtTotalDAcc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalDAcc1.Location = new System.Drawing.Point(315, 4);
            this.txtTotalDAcc1.Name = "txtTotalDAcc1";
            this.txtTotalDAcc1.ReadOnly = true;
            this.txtTotalDAcc1.Size = new System.Drawing.Size(164, 20);
            this.txtTotalDAcc1.TabIndex = 73;
            this.txtTotalDAcc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 73;
            this.label3.Text = "Total Biaya";
            // 
            // txtTotalD
            // 
            this.txtTotalD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalD.Location = new System.Drawing.Point(67, 4);
            this.txtTotalD.Name = "txtTotalD";
            this.txtTotalD.ReadOnly = true;
            this.txtTotalD.Size = new System.Drawing.Size(139, 20);
            this.txtTotalD.TabIndex = 72;
            this.txtTotalD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 74;
            this.label4.Text = "Total Biaya ACC";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTotalHAcc1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTotalH1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 30);
            this.panel1.TabIndex = 72;
            // 
            // txtTotalHAcc1
            // 
            this.txtTotalHAcc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalHAcc1.Location = new System.Drawing.Point(315, 5);
            this.txtTotalHAcc1.Name = "txtTotalHAcc1";
            this.txtTotalHAcc1.ReadOnly = true;
            this.txtTotalHAcc1.Size = new System.Drawing.Size(164, 20);
            this.txtTotalHAcc1.TabIndex = 75;
            this.txtTotalHAcc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 73;
            this.label1.Text = "Total Biaya";
            // 
            // txtTotalH1
            // 
            this.txtTotalH1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalH1.Location = new System.Drawing.Point(67, 5);
            this.txtTotalH1.Name = "txtTotalH1";
            this.txtTotalH1.ReadOnly = true;
            this.txtTotalH1.Size = new System.Drawing.Size(139, 20);
            this.txtTotalH1.TabIndex = 72;
            this.txtTotalH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 74;
            this.label2.Text = "Total Biaya ACC";
            // 
            // dgvHeader
            // 
            this.dgvHeader.AllowUserToAddRows = false;
            this.dgvHeader.AllowUserToDeleteRows = false;
            this.dgvHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POS,
            this.KodeGudang,
            this.Tanggal,
            this.Nomor,
            this.Nama,
            this.UnitKerja,
            this.Keperluan,
            this.TotalBiaya,
            this.TotalBiayaAcc,
            this.PublicKey,
            this.PIN,
            this.Link,
            this.HeaderRowID,
            this.NIP,
            this.SyncFlag});
            this.dgvHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeader.Location = new System.Drawing.Point(3, 3);
            this.dgvHeader.MultiSelect = false;
            this.dgvHeader.Name = "dgvHeader";
            this.dgvHeader.ReadOnly = true;
            this.dgvHeader.RowHeadersVisible = false;
            this.dgvHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHeader.Size = new System.Drawing.Size(1078, 145);
            this.dgvHeader.StandardTab = true;
            this.dgvHeader.TabIndex = 1;
            this.dgvHeader.TabStop = false;
            this.dgvHeader.SelectionRowChanged += new System.EventHandler(this.dgvHeader_SelectionRowChanged);
            this.dgvHeader.SelectionChanged += new System.EventHandler(this.dgvHeader_SelectionChanged);
            this.dgvHeader.Click += new System.EventHandler(this.dgvHeader_Click);
            this.dgvHeader.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeader_CellContentClick);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Uraian,
            this.RpBiaya,
            this.RpBiayaAcc,
            this.Keterangan,
            this.DetailRowID,
            this.BiayaOperasionalRowID,
            this.RpBiayaACC11,
            this.Keterangan11,
            this.SisaBudget,
            this.NoPerkiraan,
            this.SyncFlag2});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 192);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1078, 189);
            this.dgvDetail.StandardTab = true;
            this.dgvDetail.TabIndex = 2;
            this.dgvDetail.TabStop = false;
            this.dgvDetail.Click += new System.EventHandler(this.dgvDetail_Click);
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 200;
            // 
            // RpBiaya
            // 
            this.RpBiaya.DataPropertyName = "RpBiaya";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.RpBiaya.DefaultCellStyle = dataGridViewCellStyle4;
            this.RpBiaya.HeaderText = "Rp Biaya";
            this.RpBiaya.Name = "RpBiaya";
            this.RpBiaya.ReadOnly = true;
            this.RpBiaya.Width = 120;
            // 
            // RpBiayaAcc
            // 
            this.RpBiayaAcc.DataPropertyName = "RpBiayaAcc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.RpBiayaAcc.DefaultCellStyle = dataGridViewCellStyle5;
            this.RpBiayaAcc.HeaderText = "Rp Biaya ACC 00";
            this.RpBiayaAcc.Name = "RpBiayaAcc";
            this.RpBiayaAcc.ReadOnly = true;
            this.RpBiayaAcc.Width = 120;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 150;
            // 
            // DetailRowID
            // 
            this.DetailRowID.DataPropertyName = "RowID";
            this.DetailRowID.HeaderText = "RowID";
            this.DetailRowID.Name = "DetailRowID";
            this.DetailRowID.ReadOnly = true;
            this.DetailRowID.Visible = false;
            // 
            // BiayaOperasionalRowID
            // 
            this.BiayaOperasionalRowID.DataPropertyName = "BiayaOperasionalRowID";
            this.BiayaOperasionalRowID.HeaderText = "BiayaOperasionalRowID";
            this.BiayaOperasionalRowID.Name = "BiayaOperasionalRowID";
            this.BiayaOperasionalRowID.ReadOnly = true;
            this.BiayaOperasionalRowID.Visible = false;
            // 
            // RpBiayaACC11
            // 
            this.RpBiayaACC11.DataPropertyName = "RpBiayaACC11";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            this.RpBiayaACC11.DefaultCellStyle = dataGridViewCellStyle6;
            this.RpBiayaACC11.HeaderText = "Rp Biaya ACC PSHO";
            this.RpBiayaACC11.Name = "RpBiayaACC11";
            this.RpBiayaACC11.ReadOnly = true;
            this.RpBiayaACC11.Width = 120;
            // 
            // Keterangan11
            // 
            this.Keterangan11.DataPropertyName = "Keterangan11";
            this.Keterangan11.HeaderText = "Keterangan 11";
            this.Keterangan11.Name = "Keterangan11";
            this.Keterangan11.ReadOnly = true;
            this.Keterangan11.Width = 150;
            // 
            // SisaBudget
            // 
            this.SisaBudget.DataPropertyName = "SisaBudget";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0";
            this.SisaBudget.DefaultCellStyle = dataGridViewCellStyle7;
            this.SisaBudget.HeaderText = "Rp Sisa Budget";
            this.SisaBudget.Name = "SisaBudget";
            this.SisaBudget.ReadOnly = true;
            this.SisaBudget.Width = 120;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "No Perkiraan";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            // 
            // SyncFlag2
            // 
            this.SyncFlag2.DataPropertyName = "SyncFlag";
            this.SyncFlag2.HeaderText = "SyncFlag";
            this.SyncFlag2.Name = "SyncFlag2";
            this.SyncFlag2.ReadOnly = true;
            // 
            // cmdLinkBKK
            // 
            this.cmdLinkBKK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdLinkBKK.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdLinkBKK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdLinkBKK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLinkBKK.Location = new System.Drawing.Point(542, 513);
            this.cmdLinkBKK.Name = "cmdLinkBKK";
            this.cmdLinkBKK.ReportName2 = "";
            this.cmdLinkBKK.Size = new System.Drawing.Size(100, 40);
            this.cmdLinkBKK.TabIndex = 81;
            this.cmdLinkBKK.Text = "Link BKK";
            this.cmdLinkBKK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLinkBKK.UseVisualStyleBackColor = true;
            this.cmdLinkBKK.Click += new System.EventHandler(this.cmdLinkBKK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(996, 512);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName2 = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 79;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 513);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.ReportName2 = "";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 75;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdHapusPin
            // 
            this.cmdHapusPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHapusPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdHapusPin.Location = new System.Drawing.Point(436, 513);
            this.cmdHapusPin.Name = "cmdHapusPin";
            this.cmdHapusPin.Size = new System.Drawing.Size(100, 40);
            this.cmdHapusPin.TabIndex = 80;
            this.cmdHapusPin.Text = "HAPUS PIN";
            this.cmdHapusPin.UseVisualStyleBackColor = true;
            this.cmdHapusPin.Click += new System.EventHandler(this.cmdHapusPin_Click);
            // 
            // cmdPin
            // 
            this.cmdPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPin.Location = new System.Drawing.Point(330, 513);
            this.cmdPin.Name = "cmdPin";
            this.cmdPin.Size = new System.Drawing.Size(100, 40);
            this.cmdPin.TabIndex = 78;
            this.cmdPin.Text = "ISI PIN";
            this.cmdPin.UseVisualStyleBackColor = true;
            this.cmdPin.Click += new System.EventHandler(this.cmdPin_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(224, 513);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.ReportName2 = "";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 77;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(118, 513);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.ReportName2 = "";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 76;
            this.cmdEdit.Text = "BIAYA ACC";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDOWNLOAD
            // 
            this.cmdDOWNLOAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDOWNLOAD.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdDOWNLOAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDOWNLOAD.Image = ((System.Drawing.Image)(resources.GetObject("cmdDOWNLOAD.Image")));
            this.cmdDOWNLOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDOWNLOAD.Location = new System.Drawing.Point(862, 512);
            this.cmdDOWNLOAD.Name = "cmdDOWNLOAD";
            this.cmdDOWNLOAD.ReportName2 = "";
            this.cmdDOWNLOAD.Size = new System.Drawing.Size(128, 40);
            this.cmdDOWNLOAD.TabIndex = 83;
            this.cmdDOWNLOAD.Text = "DOWNLOAD";
            this.cmdDOWNLOAD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDOWNLOAD.UseVisualStyleBackColor = true;
            this.cmdDOWNLOAD.Click += new System.EventHandler(this.cmdDOWNLOAD_Click);
            // 
            // cmdUPLOAD
            // 
            this.cmdUPLOAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUPLOAD.CommandType = ISA.Controls.CommandButton.enCommandType.Upload;
            this.cmdUPLOAD.Enabled = false;
            this.cmdUPLOAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUPLOAD.Image = ((System.Drawing.Image)(resources.GetObject("cmdUPLOAD.Image")));
            this.cmdUPLOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUPLOAD.Location = new System.Drawing.Point(728, 512);
            this.cmdUPLOAD.Name = "cmdUPLOAD";
            this.cmdUPLOAD.ReportName2 = "";
            this.cmdUPLOAD.Size = new System.Drawing.Size(128, 40);
            this.cmdUPLOAD.TabIndex = 82;
            this.cmdUPLOAD.Text = "UPLOAD";
            this.cmdUPLOAD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUPLOAD.UseVisualStyleBackColor = true;
            this.cmdUPLOAD.Click += new System.EventHandler(this.cmdUPLOAD_Click);
            // 
            // panelDownload
            // 
            this.panelDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDownload.Controls.Add(this.lblProgress);
            this.panelDownload.Controls.Add(this.lblDownload);
            this.panelDownload.Controls.Add(this.pbDownload);
            this.panelDownload.Controls.Add(this.cmdDownloadClose);
            this.panelDownload.Controls.Add(this.cmdDownloadGo);
            this.panelDownload.Controls.Add(this.label5);
            this.panelDownload.Location = new System.Drawing.Point(310, 187);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(488, 191);
            this.panelDownload.TabIndex = 84;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(15, 108);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(35, 14);
            this.lblProgress.TabIndex = 16;
            this.lblProgress.Text = "TASK";
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(15, 89);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(93, 14);
            this.lblDownload.TabIndex = 15;
            this.lblDownload.Text = "Table Download";
            // 
            // pbDownload
            // 
            this.pbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDownload.Location = new System.Drawing.Point(18, 49);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(457, 23);
            this.pbDownload.TabIndex = 12;
            // 
            // cmdDownloadClose
            // 
            this.cmdDownloadClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdDownloadClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownloadClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownloadClose.Image")));
            this.cmdDownloadClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownloadClose.Location = new System.Drawing.Point(375, 131);
            this.cmdDownloadClose.Name = "cmdDownloadClose";
            this.cmdDownloadClose.ReportName2 = "";
            this.cmdDownloadClose.Size = new System.Drawing.Size(100, 40);
            this.cmdDownloadClose.TabIndex = 3;
            this.cmdDownloadClose.Text = "CLOSE";
            this.cmdDownloadClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownloadClose.UseVisualStyleBackColor = true;
            this.cmdDownloadClose.Click += new System.EventHandler(this.cmdDownloadClose_Click);
            // 
            // cmdDownloadGo
            // 
            this.cmdDownloadGo.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdDownloadGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownloadGo.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownloadGo.Image")));
            this.cmdDownloadGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownloadGo.Location = new System.Drawing.Point(15, 131);
            this.cmdDownloadGo.Name = "cmdDownloadGo";
            this.cmdDownloadGo.ReportName2 = "";
            this.cmdDownloadGo.Size = new System.Drawing.Size(128, 40);
            this.cmdDownloadGo.TabIndex = 2;
            this.cmdDownloadGo.Text = "DOWNLOAD";
            this.cmdDownloadGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownloadGo.UseVisualStyleBackColor = true;
            this.cmdDownloadGo.Click += new System.EventHandler(this.cmdDownloadGo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nama file yang akan diDownload";
            // 
            // POS
            // 
            this.POS.DataPropertyName = "POS";
            this.POS.HeaderText = "POS";
            this.POS.Name = "POS";
            this.POS.ReadOnly = true;
            this.POS.Width = 60;
            // 
            // KodeGudang
            // 
            this.KodeGudang.DataPropertyName = "KodeGudang";
            this.KodeGudang.HeaderText = "Kode Gudang";
            this.KodeGudang.Name = "KodeGudang";
            this.KodeGudang.ReadOnly = true;
            this.KodeGudang.Width = 120;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // Nomor
            // 
            this.Nomor.DataPropertyName = "Nomor";
            this.Nomor.HeaderText = "Nomor";
            this.Nomor.Name = "Nomor";
            this.Nomor.ReadOnly = true;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 150;
            // 
            // UnitKerja
            // 
            this.UnitKerja.DataPropertyName = "UnitKerja";
            this.UnitKerja.HeaderText = "Unit Kerja";
            this.UnitKerja.Name = "UnitKerja";
            this.UnitKerja.ReadOnly = true;
            this.UnitKerja.Visible = false;
            // 
            // Keperluan
            // 
            this.Keperluan.DataPropertyName = "Keperluan";
            this.Keperluan.HeaderText = "Keperluan";
            this.Keperluan.Name = "Keperluan";
            this.Keperluan.ReadOnly = true;
            this.Keperluan.Width = 200;
            // 
            // TotalBiaya
            // 
            this.TotalBiaya.DataPropertyName = "TotalBiaya";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.TotalBiaya.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalBiaya.HeaderText = "Total Biaya";
            this.TotalBiaya.Name = "TotalBiaya";
            this.TotalBiaya.ReadOnly = true;
            // 
            // TotalBiayaAcc
            // 
            this.TotalBiayaAcc.DataPropertyName = "TotalBiayaAcc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.TotalBiayaAcc.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalBiayaAcc.HeaderText = "Total Biaya ACC";
            this.TotalBiayaAcc.Name = "TotalBiayaAcc";
            this.TotalBiayaAcc.ReadOnly = true;
            this.TotalBiayaAcc.Width = 120;
            // 
            // PublicKey
            // 
            this.PublicKey.DataPropertyName = "PublicKey";
            this.PublicKey.HeaderText = "PublicKey";
            this.PublicKey.Name = "PublicKey";
            this.PublicKey.ReadOnly = true;
            // 
            // PIN
            // 
            this.PIN.DataPropertyName = "PIN";
            this.PIN.HeaderText = "PIN";
            this.PIN.Name = "PIN";
            this.PIN.ReadOnly = true;
            // 
            // Link
            // 
            this.Link.DataPropertyName = "Link";
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            this.Link.ReadOnly = true;
            // 
            // HeaderRowID
            // 
            this.HeaderRowID.DataPropertyName = "RowID";
            this.HeaderRowID.HeaderText = "RowID";
            this.HeaderRowID.Name = "HeaderRowID";
            this.HeaderRowID.ReadOnly = true;
            this.HeaderRowID.Visible = false;
            // 
            // NIP
            // 
            this.NIP.DataPropertyName = "NIP";
            this.NIP.HeaderText = "NIP";
            this.NIP.Name = "NIP";
            this.NIP.ReadOnly = true;
            this.NIP.Visible = false;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            // 
            // frmBiayaOperasionalBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1108, 565);
            this.Controls.Add(this.panelDownload);
            this.Controls.Add(this.cmdDOWNLOAD);
            this.Controls.Add(this.cmdUPLOAD);
            this.Controls.Add(this.cmdLinkBKK);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdHapusPin);
            this.Controls.Add(this.cmdPin);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rdbTanggal);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBiayaOperasionalBrowse";
            this.Text = "Biaya Operasional";
            this.Title = "Biaya Operasional";
            this.Load += new System.EventHandler(this.frmBiayaOperasionalBrowse_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.rdbTanggal, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.lblTanggal, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdPin, 0);
            this.Controls.SetChildIndex(this.cmdHapusPin, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdLinkBKK, 0);
            this.Controls.SetChildIndex(this.cmdUPLOAD, 0);
            this.Controls.SetChildIndex(this.cmdDOWNLOAD, 0);
            this.Controls.SetChildIndex(this.panelDownload, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTanggal;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.RangeDateBox rdbTanggal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private ISA.Controls.CommonTextBox txtTotalDAcc1;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox txtTotalD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.CommonTextBox txtTotalHAcc1;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtTotalH1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CustomGridView dgvHeader;
        private ISA.Controls.CustomGridView dgvDetail;
        private ISA.Controls.CommandButton cmdLinkBKK;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdAdd;
        private System.Windows.Forms.Button cmdHapusPin;
        private System.Windows.Forms.Button cmdPin;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBiaya;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBiayaAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BiayaOperasionalRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBiayaACC11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan11;
        private System.Windows.Forms.DataGridViewTextBoxColumn SisaBudget;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag2;
        private ISA.Controls.CommandButton cmdDOWNLOAD;
        private ISA.Controls.CommandButton cmdUPLOAD;
        private System.Windows.Forms.Panel panelDownload;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.ProgressBar pbDownload;
        private ISA.Controls.CommandButton cmdDownloadClose;
        private ISA.Controls.CommandButton cmdDownloadGo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitKerja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keperluan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBiaya;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBiayaAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
    }
}
