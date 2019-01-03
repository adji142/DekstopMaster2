namespace ISA.Trading.Communicator
{
    partial class frmFoxproDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFoxproDownloader));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDownloadStatus = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.cmdImport = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 532);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(681, 25);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 560);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Downloaded:";
            // 
            // lblDownloadStatus
            // 
            this.lblDownloadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDownloadStatus.AutoSize = true;
            this.lblDownloadStatus.Location = new System.Drawing.Point(103, 560);
            this.lblDownloadStatus.Name = "lblDownloadStatus";
            this.lblDownloadStatus.Size = new System.Drawing.Size(22, 14);
            this.lblDownloadStatus.TabIndex = 11;
            this.lblDownloadStatus.Text = "0/0";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(9, 86);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(681, 440);
            this.dataGridView2.TabIndex = 12;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cmdImport);
            this.pnlButton.Controls.Add(this.cmdClose);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 585);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(694, 53);
            this.pnlButton.TabIndex = 13;
            // 
            // cmdImport
            // 
            this.cmdImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImport.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.cmdImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdImport.Image = ((System.Drawing.Image)(resources.GetObject("cmdImport.Image")));
            this.cmdImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImport.Location = new System.Drawing.Point(435, 6);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(128, 40);
            this.cmdImport.TabIndex = 9;
            this.cmdImport.Text = "DOWNLOAD";
            this.cmdImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(582, 6);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmFoxproDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(694, 638);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.lblDownloadStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmFoxproDownloader";
            this.Load += new System.EventHandler(this.frmFoxproDownloader_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFoxproDownloader_FormClosing);
            this.Controls.SetChildIndex(this.dataGridView2, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblDownloadStatus, 0);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDownloadStatus;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnlButton;
        private ISA.Trading.Controls.CommandButton cmdImport;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
