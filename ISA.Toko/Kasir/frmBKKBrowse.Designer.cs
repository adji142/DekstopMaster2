namespace ISA.Toko.Kasir
{
    partial class frmBKKBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBKKBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDetailBKK = new ISA.Controls.CustomGridView();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedByD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedByD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdHI = new ISA.Controls.CommandButton();
            this.rdBKM = new ISA.Controls.RangeDateBox();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.dgHeaderBKK = new ISA.Controls.CustomGridView();
            this.pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JmlKas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jmlBKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lampiran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JmlBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pembukuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kasir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JmlBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LbrBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodePenerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSeacrh = new ISA.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHeaderBKK)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(26, 679);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 3;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Range Tanggal";
            // 
            // dgDetailBKK
            // 
            this.dgDetailBKK.AllowUserToAddRows = false;
            this.dgDetailBKK.AllowUserToDeleteRows = false;
            this.dgDetailBKK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetailBKK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDetailBKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetailBKK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoPerkiraan,
            this.Uraian,
            this.Jumlah,
            this.RowIDD,
            this.Kode,
            this.Sub,
            this.NoACCD,
            this.SyncFlag,
            this.RecordIDD,
            this.CreatedByD,
            this.CreatedTimeD,
            this.LastUpdatedByD,
            this.LastUpdatedTimeD});
            this.dgDetailBKK.Location = new System.Drawing.Point(3, 302);
            this.dgDetailBKK.MultiSelect = false;
            this.dgDetailBKK.Name = "dgDetailBKK";
            this.dgDetailBKK.ReadOnly = true;
            this.dgDetailBKK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDetailBKK.Size = new System.Drawing.Size(999, 293);
            this.dgDetailBKK.StandardTab = true;
            this.dgDetailBKK.TabIndex = 1;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "NO. PERK";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            this.NoPerkiraan.Visible = false;
            this.NoPerkiraan.Width = 150;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "URAIAN";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 400;
            // 
            // Jumlah
            // 
            this.Jumlah.DataPropertyName = "Jumlah";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle1;
            this.Jumlah.HeaderText = "JUMLAH";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            // 
            // RowIDD
            // 
            this.RowIDD.DataPropertyName = "RowID";
            this.RowIDD.HeaderText = "RowID";
            this.RowIDD.Name = "RowIDD";
            this.RowIDD.ReadOnly = true;
            this.RowIDD.Visible = false;
            // 
            // Kode
            // 
            this.Kode.DataPropertyName = "Kode";
            this.Kode.HeaderText = "#";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.Visible = false;
            this.Kode.Width = 50;
            // 
            // Sub
            // 
            this.Sub.DataPropertyName = "Sub";
            this.Sub.HeaderText = "!";
            this.Sub.Name = "Sub";
            this.Sub.ReadOnly = true;
            this.Sub.Visible = false;
            this.Sub.Width = 50;
            // 
            // NoACCD
            // 
            this.NoACCD.DataPropertyName = "NoACC";
            this.NoACCD.HeaderText = "NoACC";
            this.NoACCD.Name = "NoACCD";
            this.NoACCD.ReadOnly = true;
            this.NoACCD.Visible = false;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // RecordIDD
            // 
            this.RecordIDD.DataPropertyName = "RecordID";
            this.RecordIDD.HeaderText = "RecordID";
            this.RecordIDD.Name = "RecordIDD";
            this.RecordIDD.ReadOnly = true;
            this.RecordIDD.Visible = false;
            // 
            // CreatedByD
            // 
            this.CreatedByD.DataPropertyName = "CreatedBy";
            this.CreatedByD.HeaderText = "CreatedBy";
            this.CreatedByD.Name = "CreatedByD";
            this.CreatedByD.ReadOnly = true;
            // 
            // CreatedTimeD
            // 
            this.CreatedTimeD.DataPropertyName = "CreatedTime";
            dataGridViewCellStyle2.Format = "dd-MM-yyyy hh:mm:ss";
            this.CreatedTimeD.DefaultCellStyle = dataGridViewCellStyle2;
            this.CreatedTimeD.HeaderText = "CreatedTime";
            this.CreatedTimeD.Name = "CreatedTimeD";
            this.CreatedTimeD.ReadOnly = true;
            this.CreatedTimeD.Width = 150;
            // 
            // LastUpdatedByD
            // 
            this.LastUpdatedByD.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedByD.HeaderText = "LastUpdatedBy";
            this.LastUpdatedByD.Name = "LastUpdatedByD";
            this.LastUpdatedByD.ReadOnly = true;
            // 
            // LastUpdatedTimeD
            // 
            this.LastUpdatedTimeD.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle3.Format = "dd-MM-yyyy hh:mm:ss";
            this.LastUpdatedTimeD.DefaultCellStyle = dataGridViewCellStyle3;
            this.LastUpdatedTimeD.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTimeD.Name = "LastUpdatedTimeD";
            this.LastUpdatedTimeD.ReadOnly = true;
            this.LastUpdatedTimeD.Width = 150;
            // 
            // cmdHI
            // 
            this.cmdHI.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdHI.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdHI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdHI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHI.Location = new System.Drawing.Point(642, 679);
            this.cmdHI.Name = "cmdHI";
            this.cmdHI.Size = new System.Drawing.Size(100, 40);
            this.cmdHI.TabIndex = 7;
            this.cmdHI.Text = "HI";
            this.cmdHI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdHI.UseVisualStyleBackColor = true;
            this.cmdHI.Visible = false;
            this.cmdHI.Click += new System.EventHandler(this.cmdHI_Click);
            // 
            // rdBKM
            // 
            this.rdBKM.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdBKM.FromDate = null;
            this.rdBKM.Location = new System.Drawing.Point(130, 47);
            this.rdBKM.Name = "rdBKM";
            this.rdBKM.Size = new System.Drawing.Size(257, 22);
            this.rdBKM.TabIndex = 0;
            this.rdBKM.ToDate = null;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(931, 679);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(399, 679);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(748, 679);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 5;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Visible = false;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(505, 679);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // dgHeaderBKK
            // 
            this.dgHeaderBKK.AllowUserToAddRows = false;
            this.dgHeaderBKK.AllowUserToDeleteRows = false;
            this.dgHeaderBKK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHeaderBKK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgHeaderBKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHeaderBKK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pos,
            this.tglBukti,
            this.noBukti,
            this.dari,
            this.JmlKas,
            this.jmlBKM,
            this.Lampiran,
            this.JmlBS,
            this.JenisBukti,
            this.RecordID,
            this.RowID,
            this.Pembukuan,
            this.NoACC,
            this.Kasir,
            this.Penerima,
            this.JmlBG,
            this.LbrBG,
            this.NPrint,
            this.Src,
            this.CreatedBy,
            this.CreatedTime,
            this.LastUpdatedBy,
            this.LastUpdatedTime,
            this.KodePenerima});
            this.dgHeaderBKK.Location = new System.Drawing.Point(3, 3);
            this.dgHeaderBKK.MultiSelect = false;
            this.dgHeaderBKK.Name = "dgHeaderBKK";
            this.dgHeaderBKK.ReadOnly = true;
            this.dgHeaderBKK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgHeaderBKK.Size = new System.Drawing.Size(999, 293);
            this.dgHeaderBKK.StandardTab = true;
            this.dgHeaderBKK.TabIndex = 0;
            this.dgHeaderBKK.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgHeaderBKK_CellFormatting);
            this.dgHeaderBKK.SelectionChanged += new System.EventHandler(this.dgHeaderBKK_SelectionChanged);
            this.dgHeaderBKK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHeaderBKK_CellContentClick);
            // 
            // pos
            // 
            this.pos.DataPropertyName = "pos";
            this.pos.HeaderText = "POS";
            this.pos.MaxInputLength = 3;
            this.pos.MinimumWidth = 3;
            this.pos.Name = "pos";
            this.pos.ReadOnly = true;
            this.pos.Visible = false;
            this.pos.Width = 50;
            // 
            // tglBukti
            // 
            this.tglBukti.DataPropertyName = "TglBukti";
            dataGridViewCellStyle4.Format = "dd-MM-yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.tglBukti.DefaultCellStyle = dataGridViewCellStyle4;
            this.tglBukti.HeaderText = "TGL BUKTI";
            this.tglBukti.Name = "tglBukti";
            this.tglBukti.ReadOnly = true;
            // 
            // noBukti
            // 
            this.noBukti.DataPropertyName = "NoBukti";
            this.noBukti.HeaderText = "NO BUKTI";
            this.noBukti.Name = "noBukti";
            this.noBukti.ReadOnly = true;
            this.noBukti.Width = 150;
            // 
            // dari
            // 
            this.dari.DataPropertyName = "Kepada";
            this.dari.HeaderText = "DARI";
            this.dari.Name = "dari";
            this.dari.ReadOnly = true;
            this.dari.Width = 150;
            // 
            // JmlKas
            // 
            this.JmlKas.DataPropertyName = "Jumlah";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.JmlKas.DefaultCellStyle = dataGridViewCellStyle5;
            this.JmlKas.HeaderText = "JUMLAH";
            this.JmlKas.Name = "JmlKas";
            this.JmlKas.ReadOnly = true;
            this.JmlKas.Width = 115;
            // 
            // jmlBKM
            // 
            this.jmlBKM.DataPropertyName = "Jumlah";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.jmlBKM.DefaultCellStyle = dataGridViewCellStyle6;
            this.jmlBKM.HeaderText = "Rp. JML BKK";
            this.jmlBKM.Name = "jmlBKM";
            this.jmlBKM.ReadOnly = true;
            this.jmlBKM.Width = 115;
            // 
            // Lampiran
            // 
            this.Lampiran.DataPropertyName = "Lampiran";
            this.Lampiran.HeaderText = "L";
            this.Lampiran.Name = "Lampiran";
            this.Lampiran.ReadOnly = true;
            this.Lampiran.Visible = false;
            this.Lampiran.Width = 25;
            // 
            // JmlBS
            // 
            this.JmlBS.DataPropertyName = "JumlahBS";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.JmlBS.DefaultCellStyle = dataGridViewCellStyle7;
            this.JmlBS.HeaderText = "Rp. ALOKASI BS";
            this.JmlBS.Name = "JmlBS";
            this.JmlBS.ReadOnly = true;
            this.JmlBS.Visible = false;
            this.JmlBS.Width = 115;
            // 
            // JenisBukti
            // 
            this.JenisBukti.DataPropertyName = "JenisBukti";
            this.JenisBukti.HeaderText = "J";
            this.JenisBukti.Name = "JenisBukti";
            this.JenisBukti.ReadOnly = true;
            this.JenisBukti.Visible = false;
            this.JenisBukti.Width = 20;
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "IDTR";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            this.RecordID.Visible = false;
            this.RecordID.Width = 150;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Pembukuan
            // 
            this.Pembukuan.DataPropertyName = "Pembukuan";
            this.Pembukuan.HeaderText = "Pembukuan";
            this.Pembukuan.Name = "Pembukuan";
            this.Pembukuan.ReadOnly = true;
            this.Pembukuan.Visible = false;
            // 
            // NoACC
            // 
            this.NoACC.DataPropertyName = "NoACC";
            this.NoACC.HeaderText = "NoACC";
            this.NoACC.Name = "NoACC";
            this.NoACC.ReadOnly = true;
            this.NoACC.Visible = false;
            // 
            // Kasir
            // 
            this.Kasir.DataPropertyName = "Kasir";
            this.Kasir.HeaderText = "Kasir";
            this.Kasir.Name = "Kasir";
            this.Kasir.ReadOnly = true;
            this.Kasir.Visible = false;
            // 
            // Penerima
            // 
            this.Penerima.DataPropertyName = "Penerima";
            this.Penerima.HeaderText = "Penerima";
            this.Penerima.Name = "Penerima";
            this.Penerima.ReadOnly = true;
            this.Penerima.Visible = false;
            // 
            // JmlBG
            // 
            this.JmlBG.DataPropertyName = "JmlBG";
            this.JmlBG.HeaderText = "JmlBG";
            this.JmlBG.Name = "JmlBG";
            this.JmlBG.ReadOnly = true;
            this.JmlBG.Visible = false;
            // 
            // LbrBG
            // 
            this.LbrBG.DataPropertyName = "LbrBG";
            this.LbrBG.HeaderText = "LbrBG";
            this.LbrBG.Name = "LbrBG";
            this.LbrBG.ReadOnly = true;
            this.LbrBG.Visible = false;
            // 
            // NPrint
            // 
            this.NPrint.DataPropertyName = "NPrint";
            this.NPrint.HeaderText = "NPrint";
            this.NPrint.Name = "NPrint";
            this.NPrint.ReadOnly = true;
            this.NPrint.Visible = false;
            // 
            // Src
            // 
            this.Src.DataPropertyName = "Src";
            this.Src.HeaderText = "Src";
            this.Src.Name = "Src";
            this.Src.ReadOnly = true;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // CreatedTime
            // 
            this.CreatedTime.DataPropertyName = "CreatedTime";
            dataGridViewCellStyle8.Format = "dd-MM-yyyy hh:mm:ss";
            this.CreatedTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.CreatedTime.HeaderText = "CreatedTime";
            this.CreatedTime.Name = "CreatedTime";
            this.CreatedTime.ReadOnly = true;
            this.CreatedTime.Width = 150;
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
            dataGridViewCellStyle9.Format = "dd-MM-yyyy hh:mm:ss";
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle9;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Width = 150;
            // 
            // KodePenerima
            // 
            this.KodePenerima.DataPropertyName = "KodePenerima";
            this.KodePenerima.HeaderText = "KodePenerima";
            this.KodePenerima.Name = "KodePenerima";
            this.KodePenerima.ReadOnly = true;
            // 
            // cmdSeacrh
            // 
            this.cmdSeacrh.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSeacrh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSeacrh.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeacrh.Image")));
            this.cmdSeacrh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSeacrh.Location = new System.Drawing.Point(393, 45);
            this.cmdSeacrh.Name = "cmdSeacrh";
            this.cmdSeacrh.Size = new System.Drawing.Size(80, 23);
            this.cmdSeacrh.TabIndex = 1;
            this.cmdSeacrh.Text = "Search";
            this.cmdSeacrh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSeacrh.UseVisualStyleBackColor = true;
            this.cmdSeacrh.Click += new System.EventHandler(this.cmdSeacrh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgHeaderBKK, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgDetailBKK, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1005, 598);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // frmBKKBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1053, 741);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdHI);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.rdBKM);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSeacrh);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBKKBrowse";
            this.Text = "Bukti Kas Keluar";
            this.Title = "Bukti Kas Keluar";
            this.Load += new System.EventHandler(this.frmBKKBrowse_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBKKBrowse_KeyDown);
            this.Controls.SetChildIndex(this.cmdSeacrh, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.rdBKM, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdHI, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHeaderBKK)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdPrint;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView dgDetailBKK;
        private ISA.Controls.CommandButton cmdHI;
        private ISA.Controls.RangeDateBox rdBKM;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CustomGridView dgHeaderBKK;
        private ISA.Controls.CommandButton cmdSeacrh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedByD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTimeD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedByD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTimeD;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn noBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn dari;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlKas;
        private System.Windows.Forms.DataGridViewTextBoxColumn jmlBKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lampiran;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pembukuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kasir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn JmlBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn LbrBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodePenerima;



    }
}
