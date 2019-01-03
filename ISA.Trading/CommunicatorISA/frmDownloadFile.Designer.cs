namespace ISA.Trading.CommunicatorISA
{
    partial class frmDownloadFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadFile));
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSyncUpload = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(446, 279);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(128, 40);
            this.commandButton1.TabIndex = 6;
            this.commandButton1.Text = "DOWNLOAD";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(602, 279);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 7;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileSize});
            this.customGridView1.Location = new System.Drawing.Point(9, 50);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(693, 162);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 8;
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
            // lblUploadCount
            // 
            this.lblUploadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Location = new System.Drawing.Point(626, 247);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(40, 14);
            this.lblUploadCount.TabIndex = 15;
            this.lblUploadCount.Text = "Count";
            // 
            // lblUpload
            // 
            this.lblUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(110, 247);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(22, 14);
            this.lblUpload.TabIndex = 14;
            this.lblUpload.Text = "0/0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Table Download:";
            // 
            // pbSyncUpload
            // 
            this.pbSyncUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncUpload.Location = new System.Drawing.Point(9, 218);
            this.pbSyncUpload.Name = "pbSyncUpload";
            this.pbSyncUpload.Size = new System.Drawing.Size(693, 23);
            this.pbSyncUpload.TabIndex = 12;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 261);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 14);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            // 
            // frmDownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(715, 341);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbSyncUpload);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDownloadFile";
            this.Text = "COCKPIT DOWNLOAD (ISA)";
            this.Title = "COCKPIT DOWNLOAD (ISA)";
            this.Load += new System.EventHandler(this.frmDownloadFile_Load);
            this.Shown += new System.EventHandler(this.frmDownloadFile_Shown);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.pbSyncUpload, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUpload, 0);
            this.Controls.SetChildIndex(this.lblUploadCount, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private ISA.Trading.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.Label lblUploadCount;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbSyncUpload;
        private System.Windows.Forms.Label lblStatus;
    }
}
