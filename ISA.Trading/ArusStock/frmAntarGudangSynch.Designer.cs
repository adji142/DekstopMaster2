namespace ISA.Trading.ArusStock
{
    partial class frmAntarGudangSynch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAntarGudangSynch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.progbProgress = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.btnClose = new ISA.Controls.CommandButton();
            this.btnDownload = new ISA.Controls.CommandButton();
            this.GVHeader = new ISA.Trading.Controls.CustomGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrCheck1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrCheck2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeCheck1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeCheck2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KirimTerimaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expedisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoKendaraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSopir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tgl.SO";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(309, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgress.Controls.Add(this.progbProgress);
            this.pnlProgress.Controls.Add(this.label2);
            this.pnlProgress.Location = new System.Drawing.Point(26, 12);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(301, 88);
            this.pnlProgress.TabIndex = 12;
            this.pnlProgress.Visible = false;
            // 
            // progbProgress
            // 
            this.progbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progbProgress.Location = new System.Drawing.Point(22, 38);
            this.progbProgress.Name = "progbProgress";
            this.progbProgress.Size = new System.Drawing.Size(256, 23);
            this.progbProgress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Progress";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(64, 60);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(239, 23);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(9, 362);
            this.btnClose.Name = "btnClose";
            this.btnClose.ReportName2 = "";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(687, 362);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.ReportName2 = "";
            this.btnDownload.Size = new System.Drawing.Size(128, 40);
            this.btnDownload.TabIndex = 10;
            this.btnDownload.Text = "DOWNLOAD";
            this.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btn_Clicked);
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
            this.DrGudang,
            this.TglKirim,
            this.KeGudang,
            this.TglTerima,
            this.Pengirim,
            this.NoAG,
            this.Penerima,
            this.DrCheck1,
            this.SyncFlag,
            this.DrCheck2,
            this.KeCheck1,
            this.KeCheck2,
            this.KirimTerimaID,
            this.Catatan,
            this.expedisi,
            this.NoKendaraan,
            this.NamaSopir});
            this.GVHeader.Location = new System.Drawing.Point(15, 89);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GVHeader.RowHeadersVisible = false;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(800, 267);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 13;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "check";
            this.colCheck.Frozen = true;
            this.colCheck.HeaderText = "colCheck";
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colid
            // 
            this.colid.DataPropertyName = "wiserid";
            this.colid.Frozen = true;
            this.colid.HeaderText = "id";
            this.colid.Name = "colid";
            this.colid.ReadOnly = true;
            // 
            // DrGudang
            // 
            this.DrGudang.DataPropertyName = "DrGudang";
            this.DrGudang.Frozen = true;
            this.DrGudang.HeaderText = "DrGudang";
            this.DrGudang.Name = "DrGudang";
            this.DrGudang.ReadOnly = true;
            this.DrGudang.Width = 88;
            // 
            // TglKirim
            // 
            this.TglKirim.DataPropertyName = "TglKirim";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglKirim.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglKirim.Frozen = true;
            this.TglKirim.HeaderText = "TglKirim";
            this.TglKirim.Name = "TglKirim";
            this.TglKirim.ReadOnly = true;
            this.TglKirim.Width = 88;
            // 
            // KeGudang
            // 
            this.KeGudang.DataPropertyName = "KeGudang";
            dataGridViewCellStyle2.NullValue = " - -";
            this.KeGudang.DefaultCellStyle = dataGridViewCellStyle2;
            this.KeGudang.Frozen = true;
            this.KeGudang.HeaderText = "KeGudang";
            this.KeGudang.Name = "KeGudang";
            this.KeGudang.ReadOnly = true;
            this.KeGudang.Width = 88;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.TglTerima.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglTerima.Frozen = true;
            this.TglTerima.HeaderText = "TglTerima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            this.TglTerima.Width = 95;
            // 
            // Pengirim
            // 
            this.Pengirim.DataPropertyName = "Pengirim";
            this.Pengirim.HeaderText = "Pengirim";
            this.Pengirim.Name = "Pengirim";
            this.Pengirim.ReadOnly = true;
            this.Pengirim.Width = 88;
            // 
            // NoAG
            // 
            this.NoAG.DataPropertyName = "NoAG";
            this.NoAG.HeaderText = "NoAG";
            this.NoAG.Name = "NoAG";
            this.NoAG.ReadOnly = true;
            this.NoAG.Width = 60;
            // 
            // Penerima
            // 
            this.Penerima.DataPropertyName = "Penerima";
            this.Penerima.HeaderText = "Penerima";
            this.Penerima.Name = "Penerima";
            this.Penerima.ReadOnly = true;
            this.Penerima.Width = 88;
            // 
            // DrCheck1
            // 
            this.DrCheck1.DataPropertyName = "DrCheck1";
            this.DrCheck1.HeaderText = "DrCheck1";
            this.DrCheck1.Name = "DrCheck1";
            this.DrCheck1.ReadOnly = true;
            this.DrCheck1.Width = 88;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            this.SyncFlag.Width = 76;
            // 
            // DrCheck2
            // 
            this.DrCheck2.DataPropertyName = "DrCheck2";
            this.DrCheck2.HeaderText = "DrCheck2";
            this.DrCheck2.Name = "DrCheck2";
            this.DrCheck2.ReadOnly = true;
            this.DrCheck2.Width = 88;
            // 
            // KeCheck1
            // 
            this.KeCheck1.DataPropertyName = "KeCheck1";
            this.KeCheck1.HeaderText = "KeCheck1";
            this.KeCheck1.Name = "KeCheck1";
            this.KeCheck1.ReadOnly = true;
            this.KeCheck1.Width = 88;
            // 
            // KeCheck2
            // 
            this.KeCheck2.DataPropertyName = "KeCheck2";
            this.KeCheck2.HeaderText = "KeCheck2";
            this.KeCheck2.Name = "KeCheck2";
            this.KeCheck2.ReadOnly = true;
            this.KeCheck2.Width = 88;
            // 
            // KirimTerimaID
            // 
            this.KirimTerimaID.DataPropertyName = "KirimTerimaID";
            this.KirimTerimaID.HeaderText = "KirimTerimaID";
            this.KirimTerimaID.Name = "KirimTerimaID";
            this.KirimTerimaID.ReadOnly = true;
            this.KirimTerimaID.Width = 97;
            // 
            // Catatan
            // 
            this.Catatan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.ReadOnly = true;
            // 
            // expedisi
            // 
            this.expedisi.DataPropertyName = "expedisi";
            this.expedisi.HeaderText = "expedisi";
            this.expedisi.Name = "expedisi";
            this.expedisi.ReadOnly = true;
            this.expedisi.Visible = false;
            this.expedisi.Width = 70;
            // 
            // NoKendaraan
            // 
            this.NoKendaraan.DataPropertyName = "NoKendaraan";
            this.NoKendaraan.HeaderText = "NoKendaraan";
            this.NoKendaraan.Name = "NoKendaraan";
            this.NoKendaraan.ReadOnly = true;
            this.NoKendaraan.Visible = false;
            this.NoKendaraan.Width = 98;
            // 
            // NamaSopir
            // 
            this.NamaSopir.DataPropertyName = "NamaSopir";
            this.NamaSopir.HeaderText = "NamaSopir";
            this.NamaSopir.Name = "NamaSopir";
            this.NamaSopir.ReadOnly = true;
            this.NamaSopir.Visible = false;
            this.NamaSopir.Width = 84;
            // 
            // frmAntarGudangSynch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(828, 414);
            this.Controls.Add(this.GVHeader);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDownload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAntarGudangSynch";
            this.Text = "Antar Gudang Wiser DC Synch";
            this.Title = "Antar Gudang Wiser DC Synch";
            this.Load += new System.EventHandler(this.frmSalesOrderSynch_Load);
            this.Controls.SetChildIndex(this.btnDownload, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.pnlProgress, 0);
            this.Controls.SetChildIndex(this.GVHeader, 0);
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private ISA.Controls.CommandButton btnDownload;
        private ISA.Controls.CommandButton btnClose;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar progbProgress;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CustomGridView GVHeader;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pengirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrCheck1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrCheck2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeCheck1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeCheck2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KirimTerimaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn expedisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoKendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSopir;
    }
}
