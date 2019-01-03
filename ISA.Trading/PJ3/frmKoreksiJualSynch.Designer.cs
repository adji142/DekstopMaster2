namespace ISA.Trading.PJ3
{
    partial class frmKoreksiJualSynch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKoreksiJualSynch));
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GVHeader = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNotaBaru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJualLama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJualBaru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJualKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNotaKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.progbProgress = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new ISA.Trading.Controls.CommandButton();
            this.btnDownload = new ISA.Trading.Controls.CommandButton();
            this.btnClose = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(63, 58);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(244, 23);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tgl SJ :";
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colid,
            this.TglKoreksi,
            this.NoKoreksi,
            this.NamaBarang,
            this.BarangID,
            this.QtyNotaBaru,
            this.HrgJualLama,
            this.HrgJualBaru,
            this.Catatan,
            this.NamaToko,
            this.KodeToko,
            this.Sumber,
            this.LinkID,
            this.HrgJualKoreksi,
            this.QtyNotaKoreksi,
            this.SyncFlag,
            this.LastUpdatedBy});
            this.GVHeader.Location = new System.Drawing.Point(12, 87);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RowHeadersVisible = false;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(806, 298);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 7;
            this.GVHeader.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVHeader_CellContentClick);
            // 
            // colCheck
            // 
            this.colCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCheck.DataPropertyName = "check";
            this.colCheck.HeaderText = "colCheck";
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Width = 64;
            // 
            // colid
            // 
            this.colid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colid.DataPropertyName = "NotaJualDetailWiserID";
            this.colid.HeaderText = "colid";
            this.colid.Name = "colid";
            this.colid.ReadOnly = true;
            this.colid.Width = 58;
            // 
            // TglKoreksi
            // 
            this.TglKoreksi.DataPropertyName = "TglKoreksi";
            this.TglKoreksi.HeaderText = "Tgl Koreksi";
            this.TglKoreksi.Name = "TglKoreksi";
            this.TglKoreksi.ReadOnly = true;
            // 
            // NoKoreksi
            // 
            this.NoKoreksi.DataPropertyName = "NoKoreksi";
            this.NoKoreksi.HeaderText = "No Koreksi";
            this.NoKoreksi.Name = "NoKoreksi";
            this.NoKoreksi.ReadOnly = true;
            // 
            // NamaBarang
            // 
            this.NamaBarang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamaBarang.DataPropertyName = "NamaBarang";
            this.NamaBarang.HeaderText = "Nama Barang";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            this.NamaBarang.Width = 95;
            // 
            // BarangID
            // 
            this.BarangID.DataPropertyName = "BarangID";
            this.BarangID.HeaderText = "BarangID";
            this.BarangID.Name = "BarangID";
            this.BarangID.ReadOnly = true;
            // 
            // QtyNotaBaru
            // 
            this.QtyNotaBaru.DataPropertyName = "QtyNotaBaru";
            this.QtyNotaBaru.HeaderText = "Qty Nota Baru";
            this.QtyNotaBaru.Name = "QtyNotaBaru";
            this.QtyNotaBaru.ReadOnly = true;
            this.QtyNotaBaru.Width = 125;
            // 
            // HrgJualLama
            // 
            this.HrgJualLama.DataPropertyName = "HrgJualLama";
            this.HrgJualLama.HeaderText = "Harga Jual Lama";
            this.HrgJualLama.Name = "HrgJualLama";
            this.HrgJualLama.ReadOnly = true;
            // 
            // HrgJualBaru
            // 
            this.HrgJualBaru.DataPropertyName = "HrgJualBaru";
            this.HrgJualBaru.HeaderText = "Harga Jual Baru";
            this.HrgJualBaru.Name = "HrgJualBaru";
            this.HrgJualBaru.ReadOnly = true;
            this.HrgJualBaru.Width = 125;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 85;
            // 
            // KodeToko
            // 
            this.KodeToko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KodeToko.DataPropertyName = "KodeToko";
            this.KodeToko.HeaderText = "Kode Toko";
            this.KodeToko.Name = "KodeToko";
            this.KodeToko.ReadOnly = true;
            this.KodeToko.Width = 83;
            // 
            // Sumber
            // 
            this.Sumber.DataPropertyName = "Sumber";
            this.Sumber.HeaderText = "Sumber";
            this.Sumber.Name = "Sumber";
            this.Sumber.ReadOnly = true;
            // 
            // LinkID
            // 
            this.LinkID.DataPropertyName = "LinkID";
            this.LinkID.HeaderText = "LinkID";
            this.LinkID.Name = "LinkID";
            this.LinkID.ReadOnly = true;
            // 
            // HrgJualKoreksi
            // 
            this.HrgJualKoreksi.DataPropertyName = "HrgJualKoreksi";
            this.HrgJualKoreksi.HeaderText = "Harga Jual Koreksi";
            this.HrgJualKoreksi.Name = "HrgJualKoreksi";
            this.HrgJualKoreksi.ReadOnly = true;
            // 
            // QtyNotaKoreksi
            // 
            this.QtyNotaKoreksi.DataPropertyName = "QtyNotaKoreksi";
            this.QtyNotaKoreksi.HeaderText = "Qty Nota Koreksi";
            this.QtyNotaKoreksi.Name = "QtyNotaKoreksi";
            this.QtyNotaKoreksi.ReadOnly = true;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.progbProgress);
            this.pnlProgress.Controls.Add(this.label2);
            this.pnlProgress.Location = new System.Drawing.Point(13, 62);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(294, 67);
            this.pnlProgress.TabIndex = 10;
            this.pnlProgress.Visible = false;
            // 
            // progbProgress
            // 
            this.progbProgress.Location = new System.Drawing.Point(15, 31);
            this.progbProgress.Name = "progbProgress";
            this.progbProgress.Size = new System.Drawing.Size(264, 23);
            this.progbProgress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Progress";
            // 
            // btnSearch
            // 
            this.btnSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSearch.Location = new System.Drawing.Point(307, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ReportName = "";
            this.btnSearch.Size = new System.Drawing.Size(80, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(584, 392);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.ReportName = "";
            this.btnDownload.Size = new System.Drawing.Size(128, 40);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "DOWNLOAD";
            this.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(718, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.ReportName = "";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // frmKoreksiJualSynch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 437);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.GVHeader);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKoreksiJualSynch";
            this.Text = "Retur Penjualan Wiser DC Synch";
            this.Title = "Retur Penjualan Wiser DC Synch";
            this.Load += new System.EventHandler(this.frmNotaPenjualanSynch_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.GVHeader, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnDownload, 0);
            this.Controls.SetChildIndex(this.pnlProgress, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GVHeader;
        private ISA.Trading.Controls.CommandButton btnClose;
        private ISA.Trading.Controls.CommandButton btnDownload;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar progbProgress;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommandButton btnSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNotaBaru;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJualLama;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJualBaru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJualKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNotaKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
    }
}