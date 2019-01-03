namespace ISA.Finance.Kasir
{
    partial class frmBKMBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBKMBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rdBKM = new ISA.Controls.RangeDateBox();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.dgHeaderBKM = new ISA.Controls.CustomGridView();
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
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.dgDetailBKM = new ISA.Controls.CustomGridView();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSeacrh = new ISA.Controls.CommandButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgHeaderBKM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Range Tanggal";
            // 
            // rdBKM
            // 
            this.rdBKM.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdBKM.FromDate = null;
            this.rdBKM.Location = new System.Drawing.Point(132, 25);
            this.rdBKM.Name = "rdBKM";
            this.rdBKM.Size = new System.Drawing.Size(257, 22);
            this.rdBKM.TabIndex = 2;
            this.rdBKM.ToDate = null;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(908, 682);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 10;
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
            this.cmdAdd.Location = new System.Drawing.Point(239, 681);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(345, 681);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 8;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(451, 681);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 9;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // dgHeaderBKM
            // 
            this.dgHeaderBKM.AllowUserToAddRows = false;
            this.dgHeaderBKM.AllowUserToDeleteRows = false;
            this.dgHeaderBKM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHeaderBKM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgHeaderBKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHeaderBKM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Src});
            this.dgHeaderBKM.Location = new System.Drawing.Point(28, 72);
            this.dgHeaderBKM.MultiSelect = false;
            this.dgHeaderBKM.Name = "dgHeaderBKM";
            this.dgHeaderBKM.ReadOnly = true;
            this.dgHeaderBKM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgHeaderBKM.Size = new System.Drawing.Size(980, 247);
            this.dgHeaderBKM.StandardTab = true;
            this.dgHeaderBKM.TabIndex = 4;
            this.dgHeaderBKM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgHeaderBKM_CellFormatting);
            this.dgHeaderBKM.SelectionChanged += new System.EventHandler(this.dgHeaderBKM_SelectionChanged);
            // 
            // pos
            // 
            this.pos.DataPropertyName = "pos";
            this.pos.HeaderText = "POS";
            this.pos.MaxInputLength = 3;
            this.pos.MinimumWidth = 3;
            this.pos.Name = "pos";
            this.pos.ReadOnly = true;
            this.pos.Width = 50;
            // 
            // tglBukti
            // 
            this.tglBukti.DataPropertyName = "TglBukti";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.tglBukti.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.JmlKas.DefaultCellStyle = dataGridViewCellStyle2;
            this.JmlKas.HeaderText = "JUMLAH";
            this.JmlKas.Name = "JmlKas";
            this.JmlKas.ReadOnly = true;
            this.JmlKas.Width = 115;
            // 
            // jmlBKM
            // 
            this.jmlBKM.DataPropertyName = "Jumlah";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.jmlBKM.DefaultCellStyle = dataGridViewCellStyle3;
            this.jmlBKM.HeaderText = "Rp. JML BKM";
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
            this.Lampiran.Width = 25;
            // 
            // JmlBS
            // 
            this.JmlBS.DataPropertyName = "JumlahBS";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.JmlBS.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.JenisBukti.Width = 20;
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "IDTR";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
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
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(28, 681);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // dgDetailBKM
            // 
            this.dgDetailBKM.AllowUserToAddRows = false;
            this.dgDetailBKM.AllowUserToDeleteRows = false;
            this.dgDetailBKM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetailBKM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDetailBKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetailBKM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoPerkiraan,
            this.NamaPerkiraan,
            this.RecordIDD,
            this.Uraian,
            this.Jumlah,
            this.RowIDD,
            this.Kode,
            this.Sub,
            this.NoACCD,
            this.SyncFlag});
            this.dgDetailBKM.Location = new System.Drawing.Point(28, 325);
            this.dgDetailBKM.MultiSelect = false;
            this.dgDetailBKM.Name = "dgDetailBKM";
            this.dgDetailBKM.ReadOnly = true;
            this.dgDetailBKM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDetailBKM.Size = new System.Drawing.Size(980, 329);
            this.dgDetailBKM.StandardTab = true;
            this.dgDetailBKM.TabIndex = 5;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "NO. PERK";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            this.NoPerkiraan.Width = 150;
            // 
            // NamaPerkiraan
            // 
            this.NamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.NamaPerkiraan.HeaderText = "Nama Perkiraan";
            this.NamaPerkiraan.Name = "NamaPerkiraan";
            this.NamaPerkiraan.ReadOnly = true;
            this.NamaPerkiraan.Width = 300;
            // 
            // RecordIDD
            // 
            this.RecordIDD.DataPropertyName = "RecordID";
            this.RecordIDD.HeaderText = "RecordID";
            this.RecordIDD.Name = "RecordIDD";
            this.RecordIDD.ReadOnly = true;
            this.RecordIDD.Visible = false;
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
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle5;
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
            this.Kode.Width = 50;
            // 
            // Sub
            // 
            this.Sub.DataPropertyName = "Sub";
            this.Sub.HeaderText = "!";
            this.Sub.Name = "Sub";
            this.Sub.ReadOnly = true;
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
            // cmdSeacrh
            // 
            this.cmdSeacrh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdSeacrh.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSeacrh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSeacrh.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeacrh.Image")));
            this.cmdSeacrh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSeacrh.Location = new System.Drawing.Point(408, 22);
            this.cmdSeacrh.Name = "cmdSeacrh";
            this.cmdSeacrh.Size = new System.Drawing.Size(80, 23);
            this.cmdSeacrh.TabIndex = 3;
            this.cmdSeacrh.Text = "Search";
            this.cmdSeacrh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSeacrh.UseVisualStyleBackColor = true;
            this.cmdSeacrh.Click += new System.EventHandler(this.cmdSeacrh_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ISA.Finance.Properties.Resources.Logo32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(800, 682);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "   HI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmBKMBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1028, 742);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rdBKM);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.dgHeaderBKM);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.dgDetailBKM);
            this.Controls.Add(this.cmdSeacrh);
            this.Controls.Add(this.label1);
            this.Name = "frmBKMBrowse";
            this.Text = "BUKTI KAS MASUK";
            this.Load += new System.EventHandler(this.frmBKMBrowse_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSeacrh, 0);
            this.Controls.SetChildIndex(this.dgDetailBKM, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.dgHeaderBKM, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.rdBKM, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgHeaderBKM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgHeaderBKM;
        private ISA.Controls.CustomGridView dgDetailBKM;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdSeacrh;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.RangeDateBox rdBKM;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.Button button1;
    }
}
