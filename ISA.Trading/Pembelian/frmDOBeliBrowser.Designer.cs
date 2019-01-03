namespace ISA.Trading.Pembelian
{
    partial class frmDOBeliBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDOBeliBrowser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridHeader = new ISA.Trading.Controls.CustomGridView();
            this.Gudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglDO11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderSyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstHrgJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstHrgJualAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstHPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstHppAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JadwalKrmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKrmFROM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKrmTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderRecID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridDetail = new ISA.Trading.Controls.CustomGridView();
            this.cmdDELETE = new ISA.Trading.Controls.CommandButton();
            this.cmdEDIT = new ISA.Trading.Controls.CommandButton();
            this.cmdADD = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.rgbTglRQ = new ISA.Trading.Controls.RangeDateBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.helpToolTipButton1 = new ISA.Trading.Controls.HelpToolTipButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtInit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DateFromExpedisi = new ISA.Trading.Controls.DateTextBox();
            this.DateToExpedisi = new ISA.Trading.Controls.DateTextBox();
            this.cmdADDfromBO = new System.Windows.Forms.Button();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyTambahan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyDO11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyRealisasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyBO11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HPPSolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HPPSoloAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailRecID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridDetail, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 123);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.57143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.42857F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(847, 341);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridHeader
            // 
            this.dataGridHeader.AllowUserToAddRows = false;
            this.dataGridHeader.AllowUserToDeleteRows = false;
            this.dataGridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Gudang,
            this.NoACC,
            this.Supplier,
            this.NoRequest,
            this.TglRequest,
            this.TglDO11,
            this.HeaderSyncFlag,
            this.EstHrgJual,
            this.EstHrgJualAck,
            this.EstHPP,
            this.EstHppAck,
            this.Catatan,
            this.JadwalKrmID,
            this.TglKrmFROM,
            this.TglKrmTO,
            this.HeaderRowID,
            this.HeaderRecID});
            this.dataGridHeader.Location = new System.Drawing.Point(3, 3);
            this.dataGridHeader.MultiSelect = false;
            this.dataGridHeader.Name = "dataGridHeader";
            this.dataGridHeader.ReadOnly = true;
            this.dataGridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridHeader.Size = new System.Drawing.Size(841, 164);
            this.dataGridHeader.StandardTab = true;
            this.dataGridHeader.TabIndex = 0;
            this.dataGridHeader.SelectionRowChanged += new System.EventHandler(this.dataGridHeader_SelectionRowChanged);
            this.dataGridHeader.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridHeader_CellFormatting);
            this.dataGridHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridHeader_KeyDown);
            this.dataGridHeader.Click += new System.EventHandler(this.dataGridHeader_Click);
            // 
            // Gudang
            // 
            this.Gudang.DataPropertyName = "Gudang";
            this.Gudang.HeaderText = "Gdg";
            this.Gudang.Name = "Gudang";
            this.Gudang.ReadOnly = true;
            this.Gudang.Width = 35;
            // 
            // NoACC
            // 
            this.NoACC.DataPropertyName = "NoACC";
            this.NoACC.HeaderText = "No.ACC";
            this.NoACC.Name = "NoACC";
            this.NoACC.ReadOnly = true;
            this.NoACC.Visible = false;
            this.NoACC.Width = 50;
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "Pemasok";
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            this.Supplier.Width = 120;
            // 
            // NoRequest
            // 
            this.NoRequest.DataPropertyName = "NoRequest";
            this.NoRequest.HeaderText = "No.RQ";
            this.NoRequest.Name = "NoRequest";
            this.NoRequest.ReadOnly = true;
            // 
            // TglRequest
            // 
            this.TglRequest.DataPropertyName = "TglRequest";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglRequest.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglRequest.HeaderText = "Tgl.RQ";
            this.TglRequest.Name = "TglRequest";
            this.TglRequest.ReadOnly = true;
            // 
            // TglDO11
            // 
            this.TglDO11.DataPropertyName = "TglDO11";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.TglDO11.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglDO11.HeaderText = "Tgl DO 11";
            this.TglDO11.Name = "TglDO11";
            this.TglDO11.ReadOnly = true;
            this.TglDO11.Visible = false;
            // 
            // HeaderSyncFlag
            // 
            this.HeaderSyncFlag.DataPropertyName = "SyncFlag";
            this.HeaderSyncFlag.HeaderText = "M";
            this.HeaderSyncFlag.Name = "HeaderSyncFlag";
            this.HeaderSyncFlag.ReadOnly = true;
            this.HeaderSyncFlag.Width = 20;
            // 
            // EstHrgJual
            // 
            this.EstHrgJual.DataPropertyName = "EstHrgJual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EstHrgJual.DefaultCellStyle = dataGridViewCellStyle3;
            this.EstHrgJual.HeaderText = "Rp Est Jual";
            this.EstHrgJual.Name = "EstHrgJual";
            this.EstHrgJual.ReadOnly = true;
            this.EstHrgJual.Visible = false;
            this.EstHrgJual.Width = 130;
            // 
            // EstHrgJualAck
            // 
            this.EstHrgJualAck.DataPropertyName = "EstHrgJualAck";
            this.EstHrgJualAck.HeaderText = "Rp Est Jual";
            this.EstHrgJualAck.Name = "EstHrgJualAck";
            this.EstHrgJualAck.ReadOnly = true;
            this.EstHrgJualAck.Visible = false;
            this.EstHrgJualAck.Width = 130;
            // 
            // EstHPP
            // 
            this.EstHPP.DataPropertyName = "EstHPP";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EstHPP.DefaultCellStyle = dataGridViewCellStyle4;
            this.EstHPP.HeaderText = "Rp Est HPP";
            this.EstHPP.Name = "EstHPP";
            this.EstHPP.ReadOnly = true;
            this.EstHPP.Visible = false;
            this.EstHPP.Width = 130;
            // 
            // EstHppAck
            // 
            this.EstHppAck.DataPropertyName = "EstHppAck";
            this.EstHppAck.HeaderText = "Rp Est HPP";
            this.EstHppAck.Name = "EstHppAck";
            this.EstHppAck.ReadOnly = true;
            this.EstHppAck.Visible = false;
            this.EstHppAck.Width = 130;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.ReadOnly = true;
            this.Catatan.Width = 130;
            // 
            // JadwalKrmID
            // 
            this.JadwalKrmID.DataPropertyName = "JadwalKrmID";
            this.JadwalKrmID.HeaderText = "Jdwl Krm ID";
            this.JadwalKrmID.Name = "JadwalKrmID";
            this.JadwalKrmID.ReadOnly = true;
            this.JadwalKrmID.Visible = false;
            // 
            // TglKrmFROM
            // 
            this.TglKrmFROM.DataPropertyName = "DateFromExpedisi";
            this.TglKrmFROM.HeaderText = "TglKrmFROM";
            this.TglKrmFROM.Name = "TglKrmFROM";
            this.TglKrmFROM.ReadOnly = true;
            this.TglKrmFROM.Visible = false;
            // 
            // TglKrmTO
            // 
            this.TglKrmTO.DataPropertyName = "DateToExpedisi";
            this.TglKrmTO.HeaderText = "TglKrmTO";
            this.TglKrmTO.Name = "TglKrmTO";
            this.TglKrmTO.ReadOnly = true;
            this.TglKrmTO.Visible = false;
            // 
            // HeaderRowID
            // 
            this.HeaderRowID.DataPropertyName = "RowID";
            this.HeaderRowID.HeaderText = "RowID";
            this.HeaderRowID.Name = "HeaderRowID";
            this.HeaderRowID.ReadOnly = true;
            this.HeaderRowID.Visible = false;
            // 
            // HeaderRecID
            // 
            this.HeaderRecID.DataPropertyName = "RecordID";
            this.HeaderRecID.HeaderText = "RecordID";
            this.HeaderRecID.Name = "HeaderRecID";
            this.HeaderRecID.ReadOnly = true;
            this.HeaderRecID.Visible = false;
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.AllowUserToAddRows = false;
            this.dataGridDetail.AllowUserToDeleteRows = false;
            this.dataGridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaBarang,
            this.Satuan,
            this.QtyBO,
            this.QtyRequest,
            this.QtyTambahan,
            this.QtyMax,
            this.QtyMin,
            this.QtyAkhir,
            this.QtyDO11,
            this.QtyJual,
            this.QtyRealisasi,
            this.QtyBO11,
            this.HPPSolo,
            this.HPPSoloAck,
            this.BarangID,
            this.DetailRowID,
            this.HeaderID,
            this.DetailRecID,
            this.Keterangan11});
            this.dataGridDetail.Location = new System.Drawing.Point(3, 182);
            this.dataGridDetail.MultiSelect = false;
            this.dataGridDetail.Name = "dataGridDetail";
            this.dataGridDetail.ReadOnly = true;
            this.dataGridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDetail.Size = new System.Drawing.Size(841, 146);
            this.dataGridDetail.StandardTab = true;
            this.dataGridDetail.TabIndex = 1;
            this.dataGridDetail.SelectionRowChanged += new System.EventHandler(this.dataGridDetail_SelectionRowChanged);
            this.dataGridDetail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridDetail_CellFormatting);
            this.dataGridDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridDetail_KeyDown);
            this.dataGridDetail.Click += new System.EventHandler(this.dataGridDetail_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdDELETE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(263, 491);
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
            this.cmdEDIT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdEDIT.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(140, 491);
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
            this.cmdADD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdADD.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(23, 490);
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
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(760, 490);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(384, 85);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rgbTglRQ
            // 
            this.rgbTglRQ.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglRQ.FromDate = null;
            this.rgbTglRQ.Location = new System.Drawing.Point(121, 87);
            this.rgbTglRQ.Name = "rgbTglRQ";
            this.rgbTglRQ.Size = new System.Drawing.Size(257, 22);
            this.rgbTglRQ.TabIndex = 0;
            this.rgbTglRQ.ToDate = null;
            this.rgbTglRQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTglRQ_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 42;
            this.label5.Text = "Range tanggal RQ:";
            // 
            // lblNamaBarang
            // 
            this.lblNamaBarang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNamaBarang.AutoSize = true;
            this.lblNamaBarang.Location = new System.Drawing.Point(21, 467);
            this.lblNamaBarang.Name = "lblNamaBarang";
            this.lblNamaBarang.Size = new System.Drawing.Size(55, 14);
            this.lblNamaBarang.TabIndex = 52;
            this.lblNamaBarang.Text = "\"Barang\"";
            // 
            // helpToolTipButton1
            // 
            this.helpToolTipButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpToolTipButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("helpToolTipButton1.BackgroundImage")));
            this.helpToolTipButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpToolTipButton1.Location = new System.Drawing.Point(841, 70);
            this.helpToolTipButton1.Name = "helpToolTipButton1";
            this.helpToolTipButton1.Size = new System.Drawing.Size(23, 23);
            this.helpToolTipButton1.TabIndex = 53;
            this.helpToolTipButton1.Text = " ";
            this.toolTip1.SetToolTip(this.helpToolTipButton1, "F3                    Form order harian\r\nF4                    Ambil data dari BO" +
                    "\r\nF5                    Uploading purchasing order\r\nCtl+Shift+L     List detail");
            this.helpToolTipButton1.UseVisualStyleBackColor = true;
            this.helpToolTipButton1.Click += new System.EventHandler(this.helpToolTipButton1_Click);
            // 
            // txtInit
            // 
            this.txtInit.Location = new System.Drawing.Point(828, 96);
            this.txtInit.MaxLength = 3;
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(36, 20);
            this.txtInit.TabIndex = 55;
            this.txtInit.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(731, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 54;
            this.label3.Text = "Init Perusahaan";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 56;
            this.label1.Text = "Rencana Kirim";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(615, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 59;
            this.label2.Text = "s/d";
            this.label2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(496, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 60;
            this.label4.Text = "dari";
            this.label4.Visible = false;
            // 
            // DateFromExpedisi
            // 
            this.DateFromExpedisi.DateValue = null;
            this.DateFromExpedisi.Location = new System.Drawing.Point(531, 42);
            this.DateFromExpedisi.MaxLength = 10;
            this.DateFromExpedisi.Name = "DateFromExpedisi";
            this.DateFromExpedisi.Size = new System.Drawing.Size(80, 20);
            this.DateFromExpedisi.TabIndex = 61;
            this.DateFromExpedisi.Visible = false;
            // 
            // DateToExpedisi
            // 
            this.DateToExpedisi.DateValue = null;
            this.DateToExpedisi.Location = new System.Drawing.Point(647, 42);
            this.DateToExpedisi.MaxLength = 10;
            this.DateToExpedisi.Name = "DateToExpedisi";
            this.DateToExpedisi.Size = new System.Drawing.Size(80, 20);
            this.DateToExpedisi.TabIndex = 62;
            this.DateToExpedisi.Visible = false;
            // 
            // cmdADDfromBO
            // 
            this.cmdADDfromBO.Location = new System.Drawing.Point(736, 41);
            this.cmdADDfromBO.Name = "cmdADDfromBO";
            this.cmdADDfromBO.Size = new System.Drawing.Size(129, 23);
            this.cmdADDfromBO.TabIndex = 63;
            this.cmdADDfromBO.Text = "Order Otomatis";
            this.cmdADDfromBO.UseVisualStyleBackColor = true;
            this.cmdADDfromBO.Visible = false;
            this.cmdADDfromBO.Click += new System.EventHandler(this.cmdADDfromBO_Click);
            // 
            // NamaBarang
            // 
            this.NamaBarang.DataPropertyName = "NamaBarang";
            this.NamaBarang.HeaderText = "Nama Persediaan";
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
            // QtyBO
            // 
            this.QtyBO.DataPropertyName = "QtyBO";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyBO.DefaultCellStyle = dataGridViewCellStyle5;
            this.QtyBO.HeaderText = "J.BO";
            this.QtyBO.Name = "QtyBO";
            this.QtyBO.ReadOnly = true;
            this.QtyBO.Width = 70;
            // 
            // QtyRequest
            // 
            this.QtyRequest.DataPropertyName = "QtyRequest";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyRequest.DefaultCellStyle = dataGridViewCellStyle6;
            this.QtyRequest.HeaderText = "J.RQ";
            this.QtyRequest.Name = "QtyRequest";
            this.QtyRequest.ReadOnly = true;
            this.QtyRequest.Width = 70;
            // 
            // QtyTambahan
            // 
            this.QtyTambahan.DataPropertyName = "QtyTambahan";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyTambahan.DefaultCellStyle = dataGridViewCellStyle7;
            this.QtyTambahan.HeaderText = "J.DI+";
            this.QtyTambahan.Name = "QtyTambahan";
            this.QtyTambahan.ReadOnly = true;
            this.QtyTambahan.Width = 70;
            // 
            // QtyMax
            // 
            this.QtyMax.DataPropertyName = "QtyMaximum";
            this.QtyMax.HeaderText = "Qty.Max";
            this.QtyMax.Name = "QtyMax";
            this.QtyMax.ReadOnly = true;
            // 
            // QtyMin
            // 
            this.QtyMin.DataPropertyName = "QtyMinimum";
            this.QtyMin.HeaderText = "Qty.Min";
            this.QtyMin.Name = "QtyMin";
            this.QtyMin.ReadOnly = true;
            // 
            // QtyAkhir
            // 
            this.QtyAkhir.DataPropertyName = "LastQty";
            this.QtyAkhir.HeaderText = "Qty.Akhir";
            this.QtyAkhir.Name = "QtyAkhir";
            this.QtyAkhir.ReadOnly = true;
            // 
            // QtyDO11
            // 
            this.QtyDO11.DataPropertyName = "QtyDO11";
            this.QtyDO11.HeaderText = "Qty.DO11";
            this.QtyDO11.Name = "QtyDO11";
            this.QtyDO11.ReadOnly = true;
            this.QtyDO11.Visible = false;
            // 
            // QtyJual
            // 
            this.QtyJual.DataPropertyName = "AVGJual";
            this.QtyJual.HeaderText = "Qty.Jual";
            this.QtyJual.Name = "QtyJual";
            this.QtyJual.ReadOnly = true;
            // 
            // QtyRealisasi
            // 
            this.QtyRealisasi.DataPropertyName = "QtyRealisasi";
            this.QtyRealisasi.HeaderText = "Qty.Realisasi";
            this.QtyRealisasi.Name = "QtyRealisasi";
            this.QtyRealisasi.ReadOnly = true;
            // 
            // QtyBO11
            // 
            this.QtyBO11.DataPropertyName = "QtyBO11";
            this.QtyBO11.HeaderText = "Qty.BO11";
            this.QtyBO11.Name = "QtyBO11";
            this.QtyBO11.ReadOnly = true;
            // 
            // HPPSolo
            // 
            this.HPPSolo.DataPropertyName = "HPPSolo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HPPSolo.DefaultCellStyle = dataGridViewCellStyle8;
            this.HPPSolo.HeaderText = "Rp.Jual.DO";
            this.HPPSolo.Name = "HPPSolo";
            this.HPPSolo.ReadOnly = true;
            this.HPPSolo.Visible = false;
            this.HPPSolo.Width = 130;
            // 
            // HPPSoloAck
            // 
            this.HPPSoloAck.DataPropertyName = "HPPSoloAck";
            this.HPPSoloAck.HeaderText = "Rp.Jual.DO";
            this.HPPSoloAck.Name = "HPPSoloAck";
            this.HPPSoloAck.ReadOnly = true;
            this.HPPSoloAck.Width = 130;
            // 
            // BarangID
            // 
            this.BarangID.DataPropertyName = "BarangID";
            this.BarangID.HeaderText = "Kode Barang";
            this.BarangID.Name = "BarangID";
            this.BarangID.ReadOnly = true;
            this.BarangID.Width = 130;
            // 
            // DetailRowID
            // 
            this.DetailRowID.DataPropertyName = "RowID";
            this.DetailRowID.HeaderText = "RowID";
            this.DetailRowID.Name = "DetailRowID";
            this.DetailRowID.ReadOnly = true;
            this.DetailRowID.Visible = false;
            // 
            // HeaderID
            // 
            this.HeaderID.DataPropertyName = "HeaderID";
            this.HeaderID.HeaderText = "HeaderID";
            this.HeaderID.Name = "HeaderID";
            this.HeaderID.ReadOnly = true;
            this.HeaderID.Visible = false;
            // 
            // DetailRecID
            // 
            this.DetailRecID.DataPropertyName = "RecordID";
            this.DetailRecID.HeaderText = "RecordID";
            this.DetailRecID.Name = "DetailRecID";
            this.DetailRecID.ReadOnly = true;
            this.DetailRecID.Visible = false;
            // 
            // Keterangan11
            // 
            this.Keterangan11.HeaderText = "Keterangan 11";
            this.Keterangan11.Name = "Keterangan11";
            this.Keterangan11.ReadOnly = true;
            this.Keterangan11.Visible = false;
            // 
            // frmDOBeliBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(876, 539);
            this.Controls.Add(this.cmdADDfromBO);
            this.Controls.Add(this.DateToExpedisi);
            this.Controls.Add(this.DateFromExpedisi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.helpToolTipButton1);
            this.Controls.Add(this.lblNamaBarang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rgbTglRQ);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDOBeliBrowser";
            this.Text = "DO";
            this.Title = "DO";
            this.Load += new System.EventHandler(this.frmDOBeliBrowser_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.rgbTglRQ, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblNamaBarang, 0);
            this.Controls.SetChildIndex(this.helpToolTipButton1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtInit, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.DateFromExpedisi, 0);
            this.Controls.SetChildIndex(this.DateToExpedisi, 0);
            this.Controls.SetChildIndex(this.cmdADDfromBO, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Trading.Controls.CustomGridView dataGridHeader;
        private ISA.Trading.Controls.CustomGridView dataGridDetail;
        private ISA.Trading.Controls.CommandButton cmdDELETE;
        private ISA.Trading.Controls.CommandButton cmdEDIT;
        private ISA.Trading.Controls.CommandButton cmdADD;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private ISA.Trading.Controls.RangeDateBox rgbTglRQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlHPPDO;
        private System.Windows.Forms.Label lblNamaBarang;
        private ISA.Trading.Controls.HelpToolTipButton helpToolTipButton1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtInit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.DateTextBox DateFromExpedisi;
        private ISA.Trading.Controls.DateTextBox DateToExpedisi;
        private System.Windows.Forms.Button cmdADDfromBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglDO11;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderSyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstHrgJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstHrgJualAck;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstHPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstHppAck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn JadwalKrmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKrmFROM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKrmTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderRecID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyTambahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyDO11;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyRealisasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyBO11;
        private System.Windows.Forms.DataGridViewTextBoxColumn HPPSolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HPPSoloAck;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailRecID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan11;

    }
}
