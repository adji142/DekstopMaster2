namespace ISA.Finance.Kasir.Budget
{
    partial class frmAccBiaya
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccBiaya));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTransAccBiaya = new ISA.Controls.CustomGridView();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTABEL = new System.Windows.Forms.Button();
            this.cmdUPLOAD = new ISA.Controls.CommandButton();
            this.cmdDOWNLOAD = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.cmdDownloadClose = new ISA.Controls.CommandButton();
            this.cmdDownloadGo = new ISA.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFiles = new System.Windows.Forms.ComboBox();
            this.CabangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPengajuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadKe11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadKe00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransAccBiaya)).BeginInit();
            this.panelDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTransAccBiaya
            // 
            this.dgTransAccBiaya.AllowUserToAddRows = false;
            this.dgTransAccBiaya.AllowUserToDeleteRows = false;
            this.dgTransAccBiaya.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTransAccBiaya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransAccBiaya.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CabangID,
            this.TglPengajuan,
            this.Transaksi,
            this.NoBukti,
            this.Uraian,
            this.Jumlah,
            this.NoAcc,
            this.TglAcc,
            this.Keterangan,
            this.UploadKe11,
            this.UploadKe00,
            this.RowID});
            this.dgTransAccBiaya.Location = new System.Drawing.Point(9, 67);
            this.dgTransAccBiaya.MultiSelect = false;
            this.dgTransAccBiaya.Name = "dgTransAccBiaya";
            this.dgTransAccBiaya.ReadOnly = true;
            this.dgTransAccBiaya.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgTransAccBiaya.Size = new System.Drawing.Size(955, 205);
            this.dgTransAccBiaya.StandardTab = true;
            this.dgTransAccBiaya.TabIndex = 5;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(139, 38);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(253, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            this.rangeDateBox1.Leave += new System.EventHandler(this.rangeDateBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tanggal pengajuan";
            // 
            // cmdTABEL
            // 
            this.cmdTABEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTABEL.Location = new System.Drawing.Point(671, 281);
            this.cmdTABEL.Name = "cmdTABEL";
            this.cmdTABEL.Size = new System.Drawing.Size(157, 40);
            this.cmdTABEL.TabIndex = 8;
            this.cmdTABEL.Text = "TABEL ACC BIAYA";
            this.cmdTABEL.UseVisualStyleBackColor = true;
            this.cmdTABEL.Click += new System.EventHandler(this.btnTABEL_Click);
            // 
            // cmdUPLOAD
            // 
            this.cmdUPLOAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUPLOAD.CommandType = ISA.Controls.CommandButton.enCommandType.Upload;
            this.cmdUPLOAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUPLOAD.Image = ((System.Drawing.Image)(resources.GetObject("cmdUPLOAD.Image")));
            this.cmdUPLOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUPLOAD.Location = new System.Drawing.Point(403, 281);
            this.cmdUPLOAD.Name = "cmdUPLOAD";
            this.cmdUPLOAD.Size = new System.Drawing.Size(128, 40);
            this.cmdUPLOAD.TabIndex = 9;
            this.cmdUPLOAD.Text = "UPLOAD";
            this.cmdUPLOAD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUPLOAD.UseVisualStyleBackColor = true;
            this.cmdUPLOAD.Click += new System.EventHandler(this.cmdUPLOAD_Click);
            // 
            // cmdDOWNLOAD
            // 
            this.cmdDOWNLOAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDOWNLOAD.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdDOWNLOAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDOWNLOAD.Image = ((System.Drawing.Image)(resources.GetObject("cmdDOWNLOAD.Image")));
            this.cmdDOWNLOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDOWNLOAD.Location = new System.Drawing.Point(537, 281);
            this.cmdDOWNLOAD.Name = "cmdDOWNLOAD";
            this.cmdDOWNLOAD.Size = new System.Drawing.Size(128, 40);
            this.cmdDOWNLOAD.TabIndex = 10;
            this.cmdDOWNLOAD.Text = "DOWNLOAD";
            this.cmdDOWNLOAD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDOWNLOAD.UseVisualStyleBackColor = true;
            this.cmdDOWNLOAD.Click += new System.EventHandler(this.cmdDOWNLOAD_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(861, 281);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 11;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // panelDownload
            // 
            this.panelDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDownload.Controls.Add(this.cmdDownloadClose);
            this.panelDownload.Controls.Add(this.cmdDownloadGo);
            this.panelDownload.Controls.Add(this.label3);
            this.panelDownload.Controls.Add(this.cboFiles);
            this.panelDownload.Location = new System.Drawing.Point(284, 120);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(404, 130);
            this.panelDownload.TabIndex = 25;
            // 
            // cmdDownloadClose
            // 
            this.cmdDownloadClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdDownloadClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownloadClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownloadClose.Image")));
            this.cmdDownloadClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownloadClose.Location = new System.Drawing.Point(285, 77);
            this.cmdDownloadClose.Name = "cmdDownloadClose";
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
            this.cmdDownloadGo.Location = new System.Drawing.Point(15, 77);
            this.cmdDownloadGo.Name = "cmdDownloadGo";
            this.cmdDownloadGo.Size = new System.Drawing.Size(128, 40);
            this.cmdDownloadGo.TabIndex = 2;
            this.cmdDownloadGo.Text = "DOWNLOAD";
            this.cmdDownloadGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownloadGo.UseVisualStyleBackColor = true;
            this.cmdDownloadGo.Click += new System.EventHandler(this.cmdDownloadGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nama file yang akan diDownload";
            // 
            // cboFiles
            // 
            this.cboFiles.FormattingEnabled = true;
            this.cboFiles.Location = new System.Drawing.Point(15, 43);
            this.cboFiles.Name = "cboFiles";
            this.cboFiles.Size = new System.Drawing.Size(370, 22);
            this.cboFiles.TabIndex = 0;
            // 
            // CabangID
            // 
            this.CabangID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CabangID.DataPropertyName = "CabangID";
            this.CabangID.HeaderText = "CabangID";
            this.CabangID.Name = "CabangID";
            this.CabangID.ReadOnly = true;
            this.CabangID.Width = 83;
            // 
            // TglPengajuan
            // 
            this.TglPengajuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglPengajuan.DataPropertyName = "Tgl_pengajuan";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.TglPengajuan.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglPengajuan.HeaderText = "Tanggal Pengajuan";
            this.TglPengajuan.Name = "TglPengajuan";
            this.TglPengajuan.ReadOnly = true;
            this.TglPengajuan.Width = 123;
            // 
            // Transaksi
            // 
            this.Transaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transaksi.DataPropertyName = "Transaksi";
            this.Transaksi.HeaderText = "Transaksi";
            this.Transaksi.Name = "Transaksi";
            this.Transaksi.ReadOnly = true;
            this.Transaksi.Width = 86;
            // 
            // NoBukti
            // 
            this.NoBukti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            this.NoBukti.Width = 74;
            // 
            // Uraian
            // 
            this.Uraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 66;
            // 
            // Jumlah
            // 
            this.Jumlah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Jumlah.DataPropertyName = "Rp";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.Jumlah.HeaderText = "Jumlah";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            this.Jumlah.Width = 72;
            // 
            // NoAcc
            // 
            this.NoAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoAcc.DataPropertyName = "NoAcc";
            this.NoAcc.HeaderText = "No Acc";
            this.NoAcc.Name = "NoAcc";
            this.NoAcc.ReadOnly = true;
            this.NoAcc.Width = 64;
            // 
            // TglAcc
            // 
            this.TglAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglAcc.DataPropertyName = "TglAcc";
            dataGridViewCellStyle3.Format = "dd-MM-yyyy";
            this.TglAcc.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglAcc.HeaderText = "Tanggal ACC";
            this.TglAcc.Name = "TglAcc";
            this.TglAcc.ReadOnly = true;
            this.TglAcc.Width = 93;
            // 
            // Keterangan
            // 
            this.Keterangan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            // 
            // UploadKe11
            // 
            this.UploadKe11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UploadKe11.DataPropertyName = "UploadKe11";
            dataGridViewCellStyle4.Format = "dd-MM-yyyy";
            this.UploadKe11.DefaultCellStyle = dataGridViewCellStyle4;
            this.UploadKe11.HeaderText = "Upload ke 11";
            this.UploadKe11.Name = "UploadKe11";
            this.UploadKe11.ReadOnly = true;
            this.UploadKe11.Width = 82;
            // 
            // UploadKe00
            // 
            this.UploadKe00.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UploadKe00.DataPropertyName = "UploadKe00";
            dataGridViewCellStyle5.Format = "dd-MM-yyyy";
            this.UploadKe00.DefaultCellStyle = dataGridViewCellStyle5;
            this.UploadKe00.HeaderText = "Upload ke 00";
            this.UploadKe00.Name = "UploadKe00";
            this.UploadKe00.ReadOnly = true;
            this.UploadKe00.Width = 82;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmAccBiaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(973, 341);
            this.Controls.Add(this.panelDownload);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.dgTransAccBiaya);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdTABEL);
            this.Controls.Add(this.cmdDOWNLOAD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdUPLOAD);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAccBiaya";
            this.Text = "Proses ACC Biaya";
            this.Title = "Proses ACC Biaya";
            this.Load += new System.EventHandler(this.frmAccBiaya_Load);
            this.Controls.SetChildIndex(this.cmdUPLOAD, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdDOWNLOAD, 0);
            this.Controls.SetChildIndex(this.cmdTABEL, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.dgTransAccBiaya, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.panelDownload, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransAccBiaya)).EndInit();
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgTransAccBiaya;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdTABEL;
        private ISA.Controls.CommandButton cmdUPLOAD;
        private ISA.Controls.CommandButton cmdDOWNLOAD;
        private ISA.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.Panel panelDownload;
        private ISA.Controls.CommandButton cmdDownloadClose;
        private ISA.Controls.CommandButton cmdDownloadGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPengajuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadKe11;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadKe00;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
