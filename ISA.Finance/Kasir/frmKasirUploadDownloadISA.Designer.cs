namespace ISA.Finance.Kasir
{
    partial class frmKasirUploadDownloadISA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasirUploadDownloadISA));
            this.pbSyncUpload = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdUpload = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.rgbTanggal = new ISA.Controls.RangeDateBox();
            this.SuspendLayout();
            // 
            // pbSyncUpload
            // 
            this.pbSyncUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncUpload.Location = new System.Drawing.Point(6, 212);
            this.pbSyncUpload.Name = "pbSyncUpload";
            this.pbSyncUpload.Size = new System.Drawing.Size(764, 23);
            this.pbSyncUpload.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 41;
            this.label3.Text = "Tujuan";
            // 
            // lblUploadCount
            // 
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Location = new System.Drawing.Point(627, 265);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(40, 14);
            this.lblUploadCount.TabIndex = 40;
            this.lblUploadCount.Text = "Count";
            this.lblUploadCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(166, 265);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(28, 14);
            this.lblUpload.TabIndex = 39;
            this.lblUpload.Text = "0/24";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "Table Upload:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tanggal";
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpload.CommandType = ISA.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(6, 327);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 2;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(670, 327);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 22);
            this.label4.TabIndex = 45;
            this.label4.Text = "UPLOAD KASIR ISA";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.InitPerusahaan = null;
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(86, 132);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 1;
            // 
            // rgbTanggal
            // 
            this.rgbTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTanggal.FromDate = null;
            this.rgbTanggal.Location = new System.Drawing.Point(86, 80);
            this.rgbTanggal.Name = "rgbTanggal";
            this.rgbTanggal.Size = new System.Drawing.Size(257, 22);
            this.rgbTanggal.TabIndex = 0;
            this.rgbTanggal.ToDate = null;
            // 
            // frmKasirUploadDownloadISA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(773, 379);
            this.Controls.Add(this.rgbTanggal);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.pbSyncUpload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "frmKasirUploadDownloadISA";
            this.Text = "UPLOAD KASIR ISA";
            this.Load += new System.EventHandler(this.frmKasirUploadDownloadISA_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUpload, 0);
            this.Controls.SetChildIndex(this.lblUploadCount, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pbSyncUpload, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.rgbTanggal, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbSyncUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUploadCount;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommandButton cmdUpload;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.LookupGudang lookupGudang1;
        private ISA.Controls.RangeDateBox rgbTanggal;
    }
}
