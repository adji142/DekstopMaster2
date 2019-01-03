namespace ISA.Toko.Communicator
{
    partial class frmPOSDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOSDownload));
            this.pbSyncDownload = new System.Windows.Forms.ProgressBar();
            this.cmdCancel = new ISA.Toko.Controls.CommandButton();
            this.cmdStartUpload = new ISA.Toko.Controls.CommandButton();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.lblCtr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbSyncDownload
            // 
            this.pbSyncDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncDownload.Location = new System.Drawing.Point(13, 86);
            this.pbSyncDownload.Name = "pbSyncDownload";
            this.pbSyncDownload.Size = new System.Drawing.Size(687, 23);
            this.pbSyncDownload.TabIndex = 8;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(600, 289);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdStartUpload
            // 
            this.cmdStartUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Download;
            this.cmdStartUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdStartUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdStartUpload.Image")));
            this.cmdStartUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStartUpload.Location = new System.Drawing.Point(466, 289);
            this.cmdStartUpload.Name = "cmdStartUpload";
            this.cmdStartUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdStartUpload.TabIndex = 9;
            this.cmdStartUpload.Text = "DOWNLOAD";
            this.cmdStartUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStartUpload.UseVisualStyleBackColor = true;
            this.cmdStartUpload.Click += new System.EventHandler(this.cmdStartUpload_Click);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(10, 124);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(19, 14);
            this.LabelStatus.TabIndex = 11;
            this.LabelStatus.Text = "....";
            // 
            // lblCtr
            // 
            this.lblCtr.AutoSize = true;
            this.lblCtr.Location = new System.Drawing.Point(109, 150);
            this.lblCtr.Name = "lblCtr";
            this.lblCtr.Size = new System.Drawing.Size(28, 14);
            this.lblCtr.TabIndex = 12;
            this.lblCtr.Text = "0/34";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Jumlah Table:";
            // 
            // frmPOSDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCtr);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdStartUpload);
            this.Controls.Add(this.pbSyncDownload);
            this.Controls.Add(this.LabelStatus);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPOSDownload";
            this.Text = "POS Download";
            this.Title = "POS Download";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPOSDownload_Load);
            this.Controls.SetChildIndex(this.LabelStatus, 0);
            this.Controls.SetChildIndex(this.pbSyncDownload, 0);
            this.Controls.SetChildIndex(this.cmdStartUpload, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.lblCtr, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdCancel;
        private ISA.Toko.Controls.CommandButton cmdStartUpload;
        private System.Windows.Forms.ProgressBar pbSyncDownload;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Label lblCtr;
        private System.Windows.Forms.Label label1;
    }
}
