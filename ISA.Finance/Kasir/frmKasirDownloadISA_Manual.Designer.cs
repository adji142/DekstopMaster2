namespace ISA.Finance.Kasir
{
    partial class frmKasirDownloadISA_Manual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasirDownloadISA_Manual));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxData = new System.Windows.Forms.ComboBox();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.cmdDownload = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.lblDownload = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "DOWNLOAD KASIR ISA MANUAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data";
            // 
            // cboxData
            // 
            this.cboxData.FormattingEnabled = true;
            this.cboxData.Items.AddRange(new object[] {
            "Kasir"});
            this.cboxData.Location = new System.Drawing.Point(59, 87);
            this.cboxData.Name = "cboxData";
            this.cboxData.Size = new System.Drawing.Size(184, 22);
            this.cboxData.TabIndex = 5;
            // 
            // pbDownload
            // 
            this.pbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDownload.Location = new System.Drawing.Point(6, 181);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(696, 23);
            this.pbDownload.TabIndex = 6;
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(6, 294);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 7;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(602, 294);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(3, 220);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(93, 14);
            this.lblDownload.TabIndex = 9;
            this.lblDownload.Text = "Table Download";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(6, 250);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(35, 14);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "TASK";
            // 
            // frmKasirDownloadISA_Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxData);
            this.Name = "frmKasirDownloadISA_Manual";
            this.Load += new System.EventHandler(this.frmKasirDownloadISA_Manual_Load);
            this.Controls.SetChildIndex(this.cboxData, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.pbDownload, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lblDownload, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxData;
        private System.Windows.Forms.ProgressBar pbDownload;
        private ISA.Controls.CommandButton cmdDownload;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label lblProgress;
    }
}
