namespace ISA.Trading.CommunicatorISA
{
    partial class frmPosUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosUpload));
            this.rgbTanggal = new ISA.Trading.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new ISA.Trading.Controls.CommandButton();
            this.cmdStartUpload = new ISA.Trading.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pbSyncUpload = new System.Windows.Forms.ProgressBar();
            this.lookupGudang1 = new ISA.Trading.Controls.LookupGudang();
            this.SuspendLayout();
            // 
            // rgbTanggal
            // 
            this.rgbTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTanggal.FromDate = null;
            this.rgbTanggal.Location = new System.Drawing.Point(78, 101);
            this.rgbTanggal.Name = "rgbTanggal";
            this.rgbTanggal.Size = new System.Drawing.Size(257, 22);
            this.rgbTanggal.TabIndex = 27;
            this.rgbTanggal.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tanggal";
            // 
            // lblUploadCount
            // 
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Location = new System.Drawing.Point(630, 270);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(40, 14);
            this.lblUploadCount.TabIndex = 33;
            this.lblUploadCount.Text = "Count";
            this.lblUploadCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(170, 270);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(28, 14);
            this.lblUpload.TabIndex = 32;
            this.lblUpload.Text = "0/36";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Table Upload:";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(633, 332);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 30;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdStartUpload
            // 
            this.cmdStartUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdStartUpload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Upload;
            this.cmdStartUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdStartUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdStartUpload.Image")));
            this.cmdStartUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStartUpload.Location = new System.Drawing.Point(9, 332);
            this.cmdStartUpload.Name = "cmdStartUpload";
            this.cmdStartUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdStartUpload.TabIndex = 29;
            this.cmdStartUpload.Text = "UPLOAD";
            this.cmdStartUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStartUpload.UseVisualStyleBackColor = true;
            this.cmdStartUpload.Click += new System.EventHandler(this.cmdStartUpload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tujuan";
            // 
            // pbSyncUpload
            // 
            this.pbSyncUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncUpload.Location = new System.Drawing.Point(9, 225);
            this.pbSyncUpload.Name = "pbSyncUpload";
            this.pbSyncUpload.Size = new System.Drawing.Size(724, 23);
            this.pbSyncUpload.TabIndex = 36;
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(78, 153);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 37;
            // 
            // frmPosUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(739, 395);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.pbSyncUpload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdStartUpload);
            this.Controls.Add(this.rgbTanggal);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPosUpload";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "POS Upload (ISA)";
            this.Title = "POS Upload (ISA)";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPosUpload_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rgbTanggal, 0);
            this.Controls.SetChildIndex(this.cmdStartUpload, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUpload, 0);
            this.Controls.SetChildIndex(this.lblUploadCount, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pbSyncUpload, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rgbTanggal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUploadCount;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdCancel;
        private ISA.Trading.Controls.CommandButton cmdStartUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbSyncUpload;
        private ISA.Trading.Controls.LookupGudang lookupGudang1;
    }
}
