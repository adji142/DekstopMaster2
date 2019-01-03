namespace ISA.Toko.CommunicatorISA
{
    partial class frmDownloadDataISA_Manual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadDataISA_Manual));
            this.cboxData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.cmdDownload = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.lblDownload = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxData
            // 
            this.cboxData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxData.FormattingEnabled = true;
            this.cboxData.Items.AddRange(new object[] {
            "Antar Gudang",
            "DO Antar Cabang",
            "Nota Antar Cabang",
            "POS",
            "Potongan",
            "HPPA",
            "Nota Pembelian Antar Cabang",
            "RSOPAC"});
            this.cboxData.Location = new System.Drawing.Point(83, 109);
            this.cboxData.Name = "cboxData";
            this.cboxData.Size = new System.Drawing.Size(183, 22);
            this.cboxData.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Data";
            // 
            // pbDownload
            // 
            this.pbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDownload.Location = new System.Drawing.Point(9, 205);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(694, 23);
            this.pbDownload.TabIndex = 7;
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDownload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(9, 325);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 8;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(603, 326);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(6, 243);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(94, 14);
            this.lblDownload.TabIndex = 10;
            this.lblDownload.Text = "Table Download";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(7, 261);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(36, 14);
            this.lblProgress.TabIndex = 11;
            this.lblProgress.Text = "TASK";
            // 
            // frmDownloadDataISA_Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 378);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxData);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDownloadDataISA_Manual";
            this.Text = "Download Data ISA Manual";
            this.Title = "Download Data ISA Manual";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmDownloadDataISA_Manual_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.pbDownload, 0);
            this.Controls.SetChildIndex(this.cboxData, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.lblDownload, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbDownload;
        private ISA.Toko.Controls.CommandButton cmdDownload;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label lblProgress;
    }
}
