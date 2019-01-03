namespace ISA.Toko.Communicator
{
    partial class frmPenjualanDODownload00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenjualanDODownload00));
            this.label1 = new System.Windows.Forms.Label();
            this.lookupGudang = new ISA.Toko.Controls.LookupGudang();
            this.gvDownload1 = new ISA.Toko.Controls.CustomGridView();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.gvDownload2 = new ISA.Toko.Controls.CustomGridView();
            this.cmdDownload = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.gbStatus1 = new System.Windows.Forms.GroupBox();
            this.lblDownloadCount1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbDownload1 = new System.Windows.Forms.ProgressBar();
            this.gbStatus2 = new System.Windows.Forms.GroupBox();
            this.lblDownloadCount2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbDownload2 = new System.Windows.Forms.ProgressBar();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload2)).BeginInit();
            this.gbStatus1.SuspendLayout();
            this.gbStatus2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dari Gudang";
            // 
            // lookupGudang
            // 
            this.lookupGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang.GudangID = "";
            this.lookupGudang.InitPerusahaan = null;
            this.lookupGudang.KodeCabang = null;
            this.lookupGudang.Location = new System.Drawing.Point(116, 48);
            this.lookupGudang.NamaGudang = "";
            this.lookupGudang.Name = "lookupGudang";
            this.lookupGudang.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang.TabIndex = 0;
            // 
            // gvDownload1
            // 
            this.gvDownload1.AllowUserToAddRows = false;
            this.gvDownload1.AllowUserToDeleteRows = false;
            this.gvDownload1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDownload1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvDownload1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDownload1.Location = new System.Drawing.Point(9, 117);
            this.gvDownload1.MultiSelect = false;
            this.gvDownload1.Name = "gvDownload1";
            this.gvDownload1.ReadOnly = true;
            this.gvDownload1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvDownload1.Size = new System.Drawing.Size(893, 150);
            this.gvDownload1.StandardTab = true;
            this.gvDownload1.TabIndex = 7;
            this.gvDownload1.TabStop = false;
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Location = new System.Drawing.Point(9, 98);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(53, 14);
            this.lblInfo1.TabIndex = 8;
            this.lblInfo1.Text = "Hhtransj";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(7, 271);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(53, 14);
            this.lblInfo2.TabIndex = 10;
            this.lblInfo2.Text = "Dhtransj";
            // 
            // gvDownload2
            // 
            this.gvDownload2.AllowUserToAddRows = false;
            this.gvDownload2.AllowUserToDeleteRows = false;
            this.gvDownload2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDownload2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvDownload2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDownload2.Location = new System.Drawing.Point(9, 288);
            this.gvDownload2.MultiSelect = false;
            this.gvDownload2.Name = "gvDownload2";
            this.gvDownload2.ReadOnly = true;
            this.gvDownload2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvDownload2.Size = new System.Drawing.Size(893, 150);
            this.gvDownload2.StandardTab = true;
            this.gvDownload2.TabIndex = 11;
            this.gvDownload2.TabStop = false;
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Enabled = false;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(651, 557);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 2;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDonwload_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(800, 557);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // gbStatus1
            // 
            this.gbStatus1.Controls.Add(this.lblDownloadCount1);
            this.gbStatus1.Controls.Add(this.label4);
            this.gbStatus1.Controls.Add(this.label3);
            this.gbStatus1.Controls.Add(this.pbDownload1);
            this.gbStatus1.Location = new System.Drawing.Point(10, 447);
            this.gbStatus1.Name = "gbStatus1";
            this.gbStatus1.Size = new System.Drawing.Size(438, 100);
            this.gbStatus1.TabIndex = 15;
            this.gbStatus1.TabStop = false;
            this.gbStatus1.Text = "Download Status";
            // 
            // lblDownloadCount1
            // 
            this.lblDownloadCount1.AutoSize = true;
            this.lblDownloadCount1.Location = new System.Drawing.Point(152, 67);
            this.lblDownloadCount1.Name = "lblDownloadCount1";
            this.lblDownloadCount1.Size = new System.Drawing.Size(22, 14);
            this.lblDownloadCount1.TabIndex = 17;
            this.lblDownloadCount1.Text = "0/0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Hhtransj Dowloaded:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hhtransj";
            // 
            // pbDownload1
            // 
            this.pbDownload1.Location = new System.Drawing.Point(75, 28);
            this.pbDownload1.Name = "pbDownload1";
            this.pbDownload1.Size = new System.Drawing.Size(357, 23);
            this.pbDownload1.TabIndex = 13;
            // 
            // gbStatus2
            // 
            this.gbStatus2.Controls.Add(this.lblDownloadCount2);
            this.gbStatus2.Controls.Add(this.label5);
            this.gbStatus2.Controls.Add(this.label2);
            this.gbStatus2.Controls.Add(this.pbDownload2);
            this.gbStatus2.Location = new System.Drawing.Point(460, 447);
            this.gbStatus2.Name = "gbStatus2";
            this.gbStatus2.Size = new System.Drawing.Size(438, 100);
            this.gbStatus2.TabIndex = 16;
            this.gbStatus2.TabStop = false;
            this.gbStatus2.Text = "Download Status";
            // 
            // lblDownloadCount2
            // 
            this.lblDownloadCount2.AutoSize = true;
            this.lblDownloadCount2.Location = new System.Drawing.Point(147, 67);
            this.lblDownloadCount2.Name = "lblDownloadCount2";
            this.lblDownloadCount2.Size = new System.Drawing.Size(22, 14);
            this.lblDownloadCount2.TabIndex = 19;
            this.lblDownloadCount2.Text = "0/0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Dhtransj Dowloaded:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Dhtransj";
            // 
            // pbDownload2
            // 
            this.pbDownload2.Location = new System.Drawing.Point(74, 28);
            this.pbDownload2.Name = "pbDownload2";
            this.pbDownload2.Size = new System.Drawing.Size(357, 23);
            this.pbDownload2.TabIndex = 16;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchL;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(801, 52);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(100, 40);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "SEARCH";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // frmPenjualanDODownload00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(912, 636);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.gbStatus1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.lookupGudang);
            this.Controls.Add(this.gbStatus2);
            this.Controls.Add(this.gvDownload1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.gvDownload2);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.cmdDownload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenjualanDODownload00";
            this.Text = "Download Transaksi Dari 00";
            this.Title = "Download Transaksi Dari 00";
            this.Load += new System.EventHandler(this.frmPenjualanDODownload00_Load);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.lblInfo2, 0);
            this.Controls.SetChildIndex(this.gvDownload2, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.gvDownload1, 0);
            this.Controls.SetChildIndex(this.gbStatus2, 0);
            this.Controls.SetChildIndex(this.lookupGudang, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.gbStatus1, 0);
            this.Controls.SetChildIndex(this.lblInfo1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload2)).EndInit();
            this.gbStatus1.ResumeLayout(false);
            this.gbStatus1.PerformLayout();
            this.gbStatus2.ResumeLayout(false);
            this.gbStatus2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.LookupGudang lookupGudang;
        private ISA.Toko.Controls.CustomGridView gvDownload1;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private ISA.Toko.Controls.CustomGridView gvDownload2;
        private ISA.Toko.Controls.CommandButton cmdDownload;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.GroupBox gbStatus1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbDownload1;
        private System.Windows.Forms.GroupBox gbStatus2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbDownload2;
        private System.Windows.Forms.Label lblDownloadCount1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDownloadCount2;
        private ISA.Toko.Controls.CommandButton cmdSearch;
    }
}
