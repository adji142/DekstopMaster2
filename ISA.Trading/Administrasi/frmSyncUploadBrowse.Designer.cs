namespace ISA.Trading.Administrasi
{
    partial class frmSyncUploadBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyncUploadBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rgbTgl = new ISA.Trading.Controls.RangeDateBox();
            this.txtKode = new ISA.Trading.Controls.KodeTextBox();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.dgv = new ISA.Trading.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglSync = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabangPengirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JumlahRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Range Tgl Sinkronisasi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kode Cabang Penerima";
            // 
            // rgbTgl
            // 
            this.rgbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTgl.FromDate = null;
            this.rgbTgl.Location = new System.Drawing.Point(205, 61);
            this.rgbTgl.Name = "rgbTgl";
            this.rgbTgl.Size = new System.Drawing.Size(257, 22);
            this.rgbTgl.TabIndex = 0;
            this.rgbTgl.ToDate = null;
            // 
            // txtKode
            // 
            this.txtKode.CodeType = ISA.Trading.Controls.KodeTextBox.enCodeType.KodeBarang;
            this.txtKode.Location = new System.Drawing.Point(237, 92);
            this.txtKode.MaxLength = 12;
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(200, 20);
            this.txtKode.TabIndex = 1;
            this.txtKode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKode_KeyPress);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(341, 120);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 2;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.BatchID,
            this.TglSync,
            this.CabangPengirim,
            this.JumlahRecord,
            this.SyncBy,
            this.FileName,
            this.FileSize,
            this.Status,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dgv.Location = new System.Drawing.Point(-1, 151);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(768, 153);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 3;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // BatchID
            // 
            this.BatchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BatchID.DataPropertyName = "BatchID";
            this.BatchID.HeaderText = "Batch ID";
            this.BatchID.Name = "BatchID";
            this.BatchID.ReadOnly = true;
            this.BatchID.Width = 69;
            // 
            // TglSync
            // 
            this.TglSync.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglSync.DataPropertyName = "TglSync";
            dataGridViewCellStyle1.Format = "(dd/MM/yyyy)";
            this.TglSync.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglSync.HeaderText = "Tgl Sinkronisasi";
            this.TglSync.Name = "TglSync";
            this.TglSync.ReadOnly = true;
            this.TglSync.Width = 132;
            // 
            // CabangPengirim
            // 
            this.CabangPengirim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CabangPengirim.DataPropertyName = "CabangPengirim";
            this.CabangPengirim.HeaderText = "Cabang Pengirim";
            this.CabangPengirim.Name = "CabangPengirim";
            this.CabangPengirim.ReadOnly = true;
            this.CabangPengirim.Width = 125;
            // 
            // JumlahRecord
            // 
            this.JumlahRecord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JumlahRecord.DataPropertyName = "JumlahRecord";
            this.JumlahRecord.HeaderText = "Jumlah Record";
            this.JumlahRecord.Name = "JumlahRecord";
            this.JumlahRecord.ReadOnly = true;
            this.JumlahRecord.Width = 75;
            // 
            // SyncBy
            // 
            this.SyncBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SyncBy.DataPropertyName = "SyncBy";
            this.SyncBy.HeaderText = "Syncronize By";
            this.SyncBy.Name = "SyncBy";
            this.SyncBy.ReadOnly = true;
            this.SyncBy.Width = 113;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 62;
            // 
            // FileSize
            // 
            this.FileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FileSize.DataPropertyName = "FileSize";
            this.FileSize.HeaderText = "File Size";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            this.FileSize.Width = 62;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 74;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle2.Format = "(dd/MM/yyyy)";
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(639, 310);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmSyncUploadBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(770, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rgbTgl);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cmdClose);
            this.FormID = "SC0114";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSyncUploadBrowse";
            this.Text = "SC0114 - Monitor Synchronization Batch (Data yang dikirim)";
            this.Title = "Monitor Synchronization Batch (Data yang dikirim)";
            this.Load += new System.EventHandler(this.frmSyncUploadBrowse_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.txtKode, 0);
            this.Controls.SetChildIndex(this.rgbTgl, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.RangeDateBox rgbTgl;
        private ISA.Trading.Controls.KodeTextBox txtKode;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private ISA.Trading.Controls.CustomGridView dgv;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglSync;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangPengirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn JumlahRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}
