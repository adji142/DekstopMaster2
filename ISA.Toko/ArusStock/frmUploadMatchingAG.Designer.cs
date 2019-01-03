namespace ISA.Toko.ArusStock
{
    partial class frmUploadMatchingAG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadMatchingAG));
            this.rgbTanggal = new ISA.Toko.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbSyncUpload = new System.Windows.Forms.ProgressBar();
            this.lblUpload = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.cmdCancel = new ISA.Toko.Controls.CommandButton();
            this.cmdStartUpload = new ISA.Toko.Controls.CommandButton();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rgbTanggal
            // 
            this.rgbTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTanggal.FromDate = null;
            this.rgbTanggal.Location = new System.Drawing.Point(116, 82);
            this.rgbTanggal.Name = "rgbTanggal";
            this.rgbTanggal.Size = new System.Drawing.Size(300, 24);
            this.rgbTanggal.TabIndex = 21;
            this.rgbTanggal.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tanggal";
            // 
            // pbSyncUpload
            // 
            this.pbSyncUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncUpload.Location = new System.Drawing.Point(6, 145);
            this.pbSyncUpload.Name = "pbSyncUpload";
            this.pbSyncUpload.Size = new System.Drawing.Size(416, 24);
            this.pbSyncUpload.TabIndex = 22;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(138, 173);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(28, 14);
            this.lblUpload.TabIndex = 24;
            this.lblUpload.Text = "0/38";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Table Upload:";
            // 
            // lblUploadCount
            // 
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Location = new System.Drawing.Point(366, 173);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(40, 14);
            this.lblUploadCount.TabIndex = 25;
            this.lblUploadCount.Text = "Count";
            this.lblUploadCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(316, 233);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 27;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdStartUpload
            // 
            this.cmdStartUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Upload;
            this.cmdStartUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdStartUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdStartUpload.Image")));
            this.cmdStartUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStartUpload.Location = new System.Drawing.Point(182, 233);
            this.cmdStartUpload.Name = "cmdStartUpload";
            this.cmdStartUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdStartUpload.TabIndex = 26;
            this.cmdStartUpload.Text = "UPLOAD";
            this.cmdStartUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStartUpload.UseVisualStyleBackColor = true;
            this.cmdStartUpload.Click += new System.EventHandler(this.cmdStartUpload_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 199);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 14);
            this.lblProgress.TabIndex = 28;
            // 
            // frmUploadMatchingAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 285);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdStartUpload);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbSyncUpload);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.rgbTanggal);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUploadMatchingAG";
            this.Text = "Upload Matching AG";
            this.Title = "Upload Matching AG";
            this.Load += new System.EventHandler(this.frmUploadMatchingAG_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rgbTanggal, 0);
            this.Controls.SetChildIndex(this.lblUploadCount, 0);
            this.Controls.SetChildIndex(this.pbSyncUpload, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUpload, 0);
            this.Controls.SetChildIndex(this.cmdStartUpload, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.RangeDateBox rgbTanggal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbSyncUpload;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUploadCount;
        private ISA.Toko.Controls.CommandButton cmdCancel;
        private ISA.Toko.Controls.CommandButton cmdStartUpload;
        private System.Windows.Forms.Label lblProgress;
    }
}