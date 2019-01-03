namespace ISA.Finance.Kasir
{
    partial class frmKasirDownloadISA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasirDownloadISA));
            this.label1 = new System.Windows.Forms.Label();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmdDownload = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "DOWNLOAD KASIR ISA";
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileSize});
            this.customGridView1.Location = new System.Drawing.Point(6, 93);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(696, 227);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 4;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 300;
            // 
            // FileSize
            // 
            this.FileSize.DataPropertyName = "ShortSize";
            this.FileSize.HeaderText = "Size (KB)";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 327);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(696, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(6, 397);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 6;
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
            this.cmdClose.Location = new System.Drawing.Point(602, 397);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(3, 370);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(43, 14);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "[TASK]";
            // 
            // frmKasirDownloadISA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(705, 449);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.label1);
            this.Name = "frmKasirDownloadISA";
            this.Text = "DOWNLOAD KASIR ISA";
            this.Shown += new System.EventHandler(this.frmKasirDownloadISA_Shown);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ISA.Controls.CommandButton cmdDownload;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label lblProgress;
        
    }
}
