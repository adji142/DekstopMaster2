namespace ISA.Trading.Communicator
{
    partial class frmPenjualanNotaDownloadC2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenjualanNotaDownloadC2));
            this.lookupGudang = new ISA.Trading.Controls.LookupGudang();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDownloadCount1 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDownload = new ISA.Trading.Controls.CommandButton();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.bgStatus = new System.Windows.Forms.GroupBox();
            this.lblDownloadCount2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbDownload2 = new System.Windows.Forms.ProgressBar();
            this.pbDownload1 = new System.Windows.Forms.ProgressBar();
            this.gvDownload2 = new ISA.Trading.Controls.CustomGridView();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.gvDownload1 = new ISA.Trading.Controls.CustomGridView();
            this.bgStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload1)).BeginInit();
            this.SuspendLayout();
            // 
            // lookupGudang
            // 
            this.lookupGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang.GudangID = "";
            this.lookupGudang.KodeCabang = null;
            this.lookupGudang.Location = new System.Drawing.Point(118, 59);
            this.lookupGudang.NamaGudang = "";
            this.lookupGudang.Name = "lookupGudang";
            this.lookupGudang.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dari Gudang";
            // 
            // lblDownloadCount1
            // 
            this.lblDownloadCount1.AutoSize = true;
            this.lblDownloadCount1.Location = new System.Drawing.Point(139, 45);
            this.lblDownloadCount1.Name = "lblDownloadCount1";
            this.lblDownloadCount1.Size = new System.Drawing.Size(28, 14);
            this.lblDownloadCount1.TabIndex = 19;
            this.lblDownloadCount1.Text = "0/0";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(760, 552);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Enabled = false;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(617, 552);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 3;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(400, 60);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 2;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // bgStatus
            // 
            this.bgStatus.Controls.Add(this.lblDownloadCount2);
            this.bgStatus.Controls.Add(this.label5);
            this.bgStatus.Controls.Add(this.label2);
            this.bgStatus.Controls.Add(this.pbDownload2);
            this.bgStatus.Controls.Add(this.pbDownload1);
            this.bgStatus.Controls.Add(this.lblDownloadCount1);
            this.bgStatus.Location = new System.Drawing.Point(9, 476);
            this.bgStatus.Name = "bgStatus";
            this.bgStatus.Size = new System.Drawing.Size(594, 116);
            this.bgStatus.TabIndex = 24;
            this.bgStatus.TabStop = false;
            this.bgStatus.Text = "Upload Status";
            // 
            // lblDownloadCount2
            // 
            this.lblDownloadCount2.AutoSize = true;
            this.lblDownloadCount2.Location = new System.Drawing.Point(138, 93);
            this.lblDownloadCount2.Name = "lblDownloadCount2";
            this.lblDownloadCount2.Size = new System.Drawing.Size(28, 14);
            this.lblDownloadCount2.TabIndex = 23;
            this.lblDownloadCount2.Text = "0/0";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "Hhtransj Uploaded";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "Dhtransj Uploaded";
            // 
            // pbDownload2
            // 
            this.pbDownload2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbDownload2.Location = new System.Drawing.Point(142, 68);
            this.pbDownload2.Name = "pbDownload2";
            this.pbDownload2.Size = new System.Drawing.Size(432, 23);
            this.pbDownload2.TabIndex = 19;
            // 
            // pbDownload1
            // 
            this.pbDownload1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbDownload1.Location = new System.Drawing.Point(142, 22);
            this.pbDownload1.Name = "pbDownload1";
            this.pbDownload1.Size = new System.Drawing.Size(432, 23);
            this.pbDownload1.TabIndex = 18;
            // 
            // gvDownload2
            // 
            this.gvDownload2.AllowUserToAddRows = false;
            this.gvDownload2.AllowUserToDeleteRows = false;
            this.gvDownload2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDownload2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDownload2.Location = new System.Drawing.Point(9, 308);
            this.gvDownload2.Name = "gvDownload2";
            this.gvDownload2.ReadOnly = true;
            this.gvDownload2.Size = new System.Drawing.Size(851, 153);
            this.gvDownload2.TabIndex = 23;
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(9, 288);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(56, 14);
            this.lblInfo2.TabIndex = 22;
            this.lblInfo2.Text = "Dtransj";
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Location = new System.Drawing.Point(9, 110);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(56, 14);
            this.lblInfo1.TabIndex = 21;
            this.lblInfo1.Text = "Htransj";
            // 
            // gvDownload1
            // 
            this.gvDownload1.AllowUserToAddRows = false;
            this.gvDownload1.AllowUserToDeleteRows = false;
            this.gvDownload1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDownload1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDownload1.Location = new System.Drawing.Point(9, 129);
            this.gvDownload1.Name = "gvDownload1";
            this.gvDownload1.ReadOnly = true;
            this.gvDownload1.Size = new System.Drawing.Size(851, 153);
            this.gvDownload1.TabIndex = 20;
            // 
            // frmPenjualanNotaDownloadC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(871, 604);
            this.Controls.Add(this.bgStatus);
            this.Controls.Add(this.gvDownload2);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.gvDownload1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenjualanNotaDownloadC2";
            this.Text = "Download Penjualan Antar Cabang";
            this.Title = "Download Penjualan Antar Cabang";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPenjualanNotaDownloadC2_Load);
            this.Controls.SetChildIndex(this.lookupGudang, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.gvDownload1, 0);
            this.Controls.SetChildIndex(this.lblInfo1, 0);
            this.Controls.SetChildIndex(this.lblInfo2, 0);
            this.Controls.SetChildIndex(this.gvDownload2, 0);
            this.Controls.SetChildIndex(this.bgStatus, 0);
            this.bgStatus.ResumeLayout(false);
            this.bgStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDownload1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.LookupGudang lookupGudang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDownloadCount1;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdDownload;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.GroupBox bgStatus;
        private System.Windows.Forms.Label lblDownloadCount2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbDownload2;
        private System.Windows.Forms.ProgressBar pbDownload1;
        private ISA.Trading.Controls.CustomGridView gvDownload2;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblInfo1;
        private ISA.Trading.Controls.CustomGridView gvDownload1;
    }
}
