namespace ISA.Trading.Communicator
{
    partial class frmPOSSUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOSSUpload));
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSyncUpload = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.rgbTanggal = new ISA.Trading.Controls.RangeDateBox();
            this.cmdCancel = new ISA.Trading.Controls.CommandButton();
            this.cmdStartUpload = new ISA.Trading.Controls.CommandButton();
            this.lblProgress = new System.Windows.Forms.Label();
            this.chkTokoToSales = new System.Windows.Forms.CheckBox();
            this.chkClosingStock = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblUploadCount
            // 
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Location = new System.Drawing.Point(654, 241);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(40, 14);
            this.lblUploadCount.TabIndex = 17;
            this.lblUploadCount.Text = "Count";
            this.lblUploadCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(116, 241);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(28, 14);
            this.lblUpload.TabIndex = 16;
            this.lblUpload.Text = "0/38";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Table Upload:";
            // 
            // pbSyncUpload
            // 
            this.pbSyncUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncUpload.Location = new System.Drawing.Point(9, 215);
            this.pbSyncUpload.Name = "pbSyncUpload";
            this.pbSyncUpload.Size = new System.Drawing.Size(687, 23);
            this.pbSyncUpload.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tanggal";
            // 
            // rgbTanggal
            // 
            this.rgbTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTanggal.FromDate = null;
            this.rgbTanggal.Location = new System.Drawing.Point(74, 89);
            this.rgbTanggal.Name = "rgbTanggal";
            this.rgbTanggal.Size = new System.Drawing.Size(257, 22);
            this.rgbTanggal.TabIndex = 19;
            this.rgbTanggal.ToDate = null;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(596, 289);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdStartUpload
            // 
            this.cmdStartUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartUpload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Upload;
            this.cmdStartUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdStartUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdStartUpload.Image")));
            this.cmdStartUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStartUpload.Location = new System.Drawing.Point(462, 289);
            this.cmdStartUpload.Name = "cmdStartUpload";
            this.cmdStartUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdStartUpload.TabIndex = 13;
            this.cmdStartUpload.Text = "UPLOAD";
            this.cmdStartUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStartUpload.UseVisualStyleBackColor = true;
            this.cmdStartUpload.Click += new System.EventHandler(this.cmdStartUpload_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 265);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 14);
            this.lblProgress.TabIndex = 20;
            // 
            // chkTokoToSales
            // 
            this.chkTokoToSales.AutoSize = true;
            this.chkTokoToSales.Location = new System.Drawing.Point(15, 138);
            this.chkTokoToSales.Name = "chkTokoToSales";
            this.chkTokoToSales.Size = new System.Drawing.Size(140, 18);
            this.chkTokoToSales.TabIndex = 22;
            this.chkTokoToSales.Text = "Upload Toko to Sales";
            this.chkTokoToSales.UseVisualStyleBackColor = true;
            // 
            // chkClosingStock
            // 
            this.chkClosingStock.AutoSize = true;
            this.chkClosingStock.Location = new System.Drawing.Point(208, 138);
            this.chkClosingStock.Name = "chkClosingStock";
            this.chkClosingStock.Size = new System.Drawing.Size(142, 18);
            this.chkClosingStock.TabIndex = 23;
            this.chkClosingStock.Text = "Upload Closing Stock";
            this.chkClosingStock.UseVisualStyleBackColor = true;
            // 
            // frmPOSSUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.chkClosingStock);
            this.Controls.Add(this.chkTokoToSales);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.rgbTanggal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdStartUpload);
            this.Controls.Add(this.pbSyncUpload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPOSSUpload";
            this.Text = "POS Upload";
            this.Title = "POS Upload";
            this.Load += new System.EventHandler(this.frmPOSSUpload_Load);
            this.Controls.SetChildIndex(this.pbSyncUpload, 0);
            this.Controls.SetChildIndex(this.cmdStartUpload, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUpload, 0);
            this.Controls.SetChildIndex(this.lblUploadCount, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rgbTanggal, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            this.Controls.SetChildIndex(this.chkTokoToSales, 0);
            this.Controls.SetChildIndex(this.chkClosingStock, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUploadCount;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdCancel;
        private ISA.Trading.Controls.CommandButton cmdStartUpload;
        private System.Windows.Forms.ProgressBar pbSyncUpload;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.RangeDateBox rgbTanggal;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox chkTokoToSales;
        private System.Windows.Forms.CheckBox chkClosingStock;
    }
}
