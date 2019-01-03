namespace ISA.Finance.DKNForm
{
    partial class frmDebetKreditNotaBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebetKreditNotaBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.gridUtm = new ISA.Controls.CustomGridView();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_dkn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefNoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefTipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDetail = new ISA.Controls.CustomGridView();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_perk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTolak = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AlasanTolak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDel = new ISA.Controls.CommandButton();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdYes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridUtm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(4, 37);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 1;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(273, 36);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 2;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // gridUtm
            // 
            this.gridUtm.AllowUserToAddRows = false;
            this.gridUtm.AllowUserToDeleteRows = false;
            this.gridUtm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUtm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridUtm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUtm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal,
            this.RowID,
            this.RecordID,
            this.No_dkn,
            this.RefNoBukti,
            this.RefTipe,
            this.Cabang,
            this.Dk,
            this.Cd,
            this.Src,
            this.LastUpdatedBy,
            this.LastUpdatedTime,
            this.SyncFlag});
            this.gridUtm.Location = new System.Drawing.Point(5, 75);
            this.gridUtm.MultiSelect = false;
            this.gridUtm.Name = "gridUtm";
            this.gridUtm.ReadOnly = true;
            this.gridUtm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridUtm.Size = new System.Drawing.Size(894, 221);
            this.gridUtm.StandardTab = true;
            this.gridUtm.TabIndex = 4;
            this.gridUtm.Validated += new System.EventHandler(this.gridUtm_Validated);
            this.gridUtm.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridUtm_DataBindingComplete);
            this.gridUtm.SelectionChanged += new System.EventHandler(this.gridUtm_SelectionChanged);
            this.gridUtm.Click += new System.EventHandler(this.gridUtm_Click);
            this.gridUtm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUtm_CellContentClick);
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "RecordID";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            this.RecordID.Visible = false;
            // 
            // No_dkn
            // 
            this.No_dkn.DataPropertyName = "NoDKN";
            this.No_dkn.HeaderText = "No DKN";
            this.No_dkn.Name = "No_dkn";
            this.No_dkn.ReadOnly = true;
            this.No_dkn.Width = 150;
            // 
            // RefNoBukti
            // 
            this.RefNoBukti.DataPropertyName = "RefNoBukti";
            this.RefNoBukti.HeaderText = "Ref No.Bukti";
            this.RefNoBukti.Name = "RefNoBukti";
            this.RefNoBukti.ReadOnly = true;
            this.RefNoBukti.Width = 150;
            // 
            // RefTipe
            // 
            this.RefTipe.DataPropertyName = "RefTipe";
            this.RefTipe.HeaderText = "Ref Tipe";
            this.RefTipe.Name = "RefTipe";
            this.RefTipe.ReadOnly = true;
            this.RefTipe.Visible = false;
            this.RefTipe.Width = 80;
            // 
            // Cabang
            // 
            this.Cabang.DataPropertyName = "Cabang";
            this.Cabang.HeaderText = "Cabang";
            this.Cabang.Name = "Cabang";
            this.Cabang.ReadOnly = true;
            this.Cabang.Width = 70;
            // 
            // Dk
            // 
            this.Dk.DataPropertyName = "DK";
            this.Dk.HeaderText = "Dk";
            this.Dk.Name = "Dk";
            this.Dk.ReadOnly = true;
            this.Dk.Width = 50;
            // 
            // Cd
            // 
            this.Cd.DataPropertyName = "CD";
            this.Cd.HeaderText = "Cd";
            this.Cd.Name = "Cd";
            this.Cd.ReadOnly = true;
            this.Cd.Visible = false;
            // 
            // Src
            // 
            this.Src.DataPropertyName = "Src";
            this.Src.HeaderText = "Src";
            this.Src.Name = "Src";
            this.Src.ReadOnly = true;
            this.Src.Width = 50;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "User";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Width = 200;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdated";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "Sync";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Width = 50;
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDD,
            this.HeaderID,
            this.RecordIDD,
            this.HRecordID,
            this.RefRowID,
            this.Uraian,
            this.No_perk,
            this.NamaPerkiraan,
            this.Jumlah,
            this.cTolak,
            this.AlasanTolak,
            this.LastUpdateBy,
            this.LastUpdatedDetail});
            this.gridDetail.Location = new System.Drawing.Point(5, 302);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetail.Size = new System.Drawing.Size(894, 220);
            this.gridDetail.StandardTab = true;
            this.gridDetail.TabIndex = 5;
            this.gridDetail.Click += new System.EventHandler(this.gridDetail_Click);
            // 
            // RowIDD
            // 
            this.RowIDD.DataPropertyName = "RowID";
            this.RowIDD.HeaderText = "RowIDD";
            this.RowIDD.Name = "RowIDD";
            this.RowIDD.ReadOnly = true;
            this.RowIDD.Visible = false;
            // 
            // HeaderID
            // 
            this.HeaderID.DataPropertyName = "HeaderID";
            this.HeaderID.HeaderText = "HeaderID";
            this.HeaderID.Name = "HeaderID";
            this.HeaderID.ReadOnly = true;
            this.HeaderID.Visible = false;
            // 
            // RecordIDD
            // 
            this.RecordIDD.DataPropertyName = "RecordID";
            this.RecordIDD.HeaderText = "RecordID";
            this.RecordIDD.Name = "RecordIDD";
            this.RecordIDD.ReadOnly = true;
            this.RecordIDD.Visible = false;
            this.RecordIDD.Width = 150;
            // 
            // HRecordID
            // 
            this.HRecordID.DataPropertyName = "HRecordID";
            this.HRecordID.HeaderText = "HRecordID";
            this.HRecordID.Name = "HRecordID";
            this.HRecordID.ReadOnly = true;
            this.HRecordID.Visible = false;
            this.HRecordID.Width = 150;
            // 
            // RefRowID
            // 
            this.RefRowID.DataPropertyName = "RefRowID";
            this.RefRowID.HeaderText = "RefRowID";
            this.RefRowID.Name = "RefRowID";
            this.RefRowID.ReadOnly = true;
            this.RefRowID.Visible = false;
            this.RefRowID.Width = 200;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 400;
            // 
            // No_perk
            // 
            this.No_perk.DataPropertyName = "NoPerkiraan";
            this.No_perk.HeaderText = "No Perkiraan";
            this.No_perk.Name = "No_perk";
            this.No_perk.ReadOnly = true;
            this.No_perk.Width = 125;
            // 
            // NamaPerkiraan
            // 
            this.NamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.NamaPerkiraan.HeaderText = "Nama Perkiraan";
            this.NamaPerkiraan.Name = "NamaPerkiraan";
            this.NamaPerkiraan.ReadOnly = true;
            this.NamaPerkiraan.Width = 300;
            // 
            // Jumlah
            // 
            this.Jumlah.DataPropertyName = "Jumlah";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.Jumlah.HeaderText = "Jumlah";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            // 
            // cTolak
            // 
            this.cTolak.DataPropertyName = "Tolak";
            this.cTolak.HeaderText = "Tolak";
            this.cTolak.Name = "cTolak";
            this.cTolak.ReadOnly = true;
            this.cTolak.Visible = false;
            this.cTolak.Width = 40;
            // 
            // AlasanTolak
            // 
            this.AlasanTolak.DataPropertyName = "Alasan";
            this.AlasanTolak.HeaderText = "Alasan Tolak";
            this.AlasanTolak.Name = "AlasanTolak";
            this.AlasanTolak.ReadOnly = true;
            this.AlasanTolak.Visible = false;
            this.AlasanTolak.Width = 300;
            // 
            // LastUpdateBy
            // 
            this.LastUpdateBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdateBy.HeaderText = "User";
            this.LastUpdateBy.Name = "LastUpdateBy";
            this.LastUpdateBy.ReadOnly = true;
            this.LastUpdateBy.Width = 200;
            // 
            // LastUpdatedDetail
            // 
            this.LastUpdatedDetail.DataPropertyName = "LastUpdatedetail";
            this.LastUpdatedDetail.HeaderText = "LastUpdate";
            this.LastUpdatedDetail.Name = "LastUpdatedDetail";
            this.LastUpdatedDetail.ReadOnly = true;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(4, 528);
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
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(110, 528);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 8;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDel.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDel.Enabled = false;
            this.cmdDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDel.Image = ((System.Drawing.Image)(resources.GetObject("cmdDel.Image")));
            this.cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDel.Location = new System.Drawing.Point(216, 528);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Size = new System.Drawing.Size(100, 40);
            this.cmdDel.TabIndex = 9;
            this.cmdDel.Text = "DELETE";
            this.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDel.UseVisualStyleBackColor = true;
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(437, 528);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 10;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Visible = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(799, 528);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdYes.Image = global::ISA.Finance.Properties.Resources.Ok32;
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(322, 528);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(109, 40);
            this.cmdYes.TabIndex = 12;
            this.cmdYes.Text = "       ISI NO KN";
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Visible = false;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // frmDebetKreditNotaBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(906, 602);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdDel);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.gridUtm);
            this.Name = "frmDebetKreditNotaBrowse";
            this.Text = "Debet/Kredit Nota";
            this.Load += new System.EventHandler(this.frmDebetKreditNotaBrowse_Load);
            this.Controls.SetChildIndex(this.gridUtm, 0);
            this.Controls.SetChildIndex(this.gridDetail, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdDel, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridUtm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDel;
        private ISA.Controls.CommandButton cmdPrint;
        public ISA.Controls.CustomGridView gridUtm;
        public ISA.Controls.CustomGridView gridDetail;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Button cmdYes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_dkn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefNoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefTipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_perk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cTolak;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlasanTolak;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedDetail;
    }
}
