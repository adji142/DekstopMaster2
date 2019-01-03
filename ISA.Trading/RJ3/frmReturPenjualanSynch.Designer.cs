namespace ISA.Trading.RJ3
{
    partial class frmReturPenjualanSynch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturPenjualanSynch));
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GVHeader = new System.Windows.Forms.DataGridView();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.progbProgress = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new ISA.Trading.Controls.CommandButton();
            this.btnDownload = new ISA.Trading.Controls.CommandButton();
            this.btnClose = new ISA.Trading.Controls.CommandButton();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoMPR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMPR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNotaRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglNotaRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTolak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTolak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BagPenjualan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCSPV = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Cabang1,
            this.Cabang2,
            this.NoMPR,
            this.TglMPR,
            this.NoNotaRetur,
            this.TglNotaRetur,
            this.TglTolak,
            this.NamaToko,
            this.KodeToko,
            this.NoTolak,
            this.BagPenjualan,
            this.Penerima,
            this.SyncFlag,
            this.LinkID,
            this.NPrint,
            this.LastUpdatedBy,
            this.LastUpdatedTime,
            this.ACCSPV});
            this.GVHeader.Location = new System.Drawing.Point(12, 87);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RowHeadersVisible = false;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(806, 298);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 7;
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
            this.colid.DataPropertyName = "wiserid";
            this.colid.HeaderText = "id";
            this.colid.Name = "colid";
            this.colid.ReadOnly = true;
            this.colid.Width = 42;
            // 
            // Cabang1
            // 
            this.Cabang1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cabang1.DataPropertyName = "Cabang1";
            this.Cabang1.HeaderText = "C1";
            this.Cabang1.Name = "Cabang1";
            this.Cabang1.ReadOnly = true;
            this.Cabang1.Width = 46;
            // 
            // Cabang2
            // 
            this.Cabang2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cabang2.DataPropertyName = "Cabang2";
            this.Cabang2.HeaderText = "C2";
            this.Cabang2.Name = "Cabang2";
            this.Cabang2.ReadOnly = true;
            this.Cabang2.Width = 46;
            // 
            // NoMPR
            // 
            this.NoMPR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoMPR.DataPropertyName = "NoMPR";
            this.NoMPR.HeaderText = "No MPR";
            this.NoMPR.Name = "NoMPR";
            this.NoMPR.ReadOnly = true;
            this.NoMPR.Width = 73;
            // 
            // TglMPR
            // 
            this.TglMPR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglMPR.DataPropertyName = "TglMPR";
            this.TglMPR.HeaderText = "Tgl MPR";
            this.TglMPR.Name = "TglMPR";
            this.TglMPR.ReadOnly = true;
            this.TglMPR.Width = 76;
            // 
            // NoNotaRetur
            // 
            this.NoNotaRetur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoNotaRetur.DataPropertyName = "NoNotaRetur";
            this.NoNotaRetur.HeaderText = "No Nota Retur";
            this.NoNotaRetur.Name = "NoNotaRetur";
            this.NoNotaRetur.ReadOnly = true;
            this.NoNotaRetur.Width = 106;
            // 
            // TglNotaRetur
            // 
            this.TglNotaRetur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglNotaRetur.DataPropertyName = "TglNotaRetur";
            this.TglNotaRetur.HeaderText = "Tgl Nota Retur";
            this.TglNotaRetur.Name = "TglNotaRetur";
            this.TglNotaRetur.ReadOnly = true;
            // 
            // TglTolak
            // 
            this.TglTolak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglTolak.DataPropertyName = "TglTolak";
            this.TglTolak.HeaderText = "Tgl Tolak";
            this.TglTolak.Name = "TglTolak";
            this.TglTolak.ReadOnly = true;
            this.TglTolak.Width = 75;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
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
            // NoTolak
            // 
            this.NoTolak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoTolak.DataPropertyName = "NoTolak";
            this.NoTolak.HeaderText = "No Tolak";
            this.NoTolak.Name = "NoTolak";
            this.NoTolak.ReadOnly = true;
            this.NoTolak.Width = 72;
            // 
            // BagPenjualan
            // 
            this.BagPenjualan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BagPenjualan.DataPropertyName = "BagPenjualan";
            this.BagPenjualan.HeaderText = "Bag Penjualan";
            this.BagPenjualan.Name = "BagPenjualan";
            this.BagPenjualan.ReadOnly = true;
            this.BagPenjualan.Width = 99;
            // 
            // Penerima
            // 
            this.Penerima.DataPropertyName = "Penerima";
            this.Penerima.HeaderText = "Penerima";
            this.Penerima.Name = "Penerima";
            this.Penerima.ReadOnly = true;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            // 
            // LinkID
            // 
            this.LinkID.DataPropertyName = "LinkID";
            this.LinkID.HeaderText = "LinkID";
            this.LinkID.Name = "LinkID";
            this.LinkID.ReadOnly = true;
            // 
            // NPrint
            // 
            this.NPrint.DataPropertyName = "NPrint";
            this.NPrint.HeaderText = "NPrint";
            this.NPrint.Name = "NPrint";
            this.NPrint.ReadOnly = true;
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
            // 
            // ACCSPV
            // 
            this.ACCSPV.DataPropertyName = "ACCSPV";
            this.ACCSPV.HeaderText = "ACCSPV";
            this.ACCSPV.Name = "ACCSPV";
            this.ACCSPV.ReadOnly = true;
            // 
            // frmReturPenjualanSynch
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
            this.Name = "frmReturPenjualanSynch";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoMPR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMPR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNotaRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNotaRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTolak;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTolak;
        private System.Windows.Forms.DataGridViewTextBoxColumn BagPenjualan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCSPV;
    }
}