namespace ISA.Trading.Communicator
{
    partial class frmPotonganDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPotonganDownload));
            this.cmdDownload = new ISA.Trading.Controls.CommandButton();
            this.cmdCLose = new ISA.Trading.Controls.CommandButton();
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.lblDownloadStatus1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDownload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(12, 314);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 5;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdCLose
            // 
            this.cmdCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLose.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLose.Image")));
            this.cmdCLose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLose.Location = new System.Drawing.Point(486, 314);
            this.cmdCLose.Name = "cmdCLose";
            this.cmdCLose.Size = new System.Drawing.Size(100, 40);
            this.cmdCLose.TabIndex = 6;
            this.cmdCLose.Text = "CLOSE";
            this.cmdCLose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLose.UseVisualStyleBackColor = true;
            this.cmdCLose.Click += new System.EventHandler(this.cmdCLose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(577, 112);
            this.dataGridView1.TabIndex = 7;
            // 
            // lblDownloadStatus1
            // 
            this.lblDownloadStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDownloadStatus1.AutoSize = true;
            this.lblDownloadStatus1.Location = new System.Drawing.Point(151, 242);
            this.lblDownloadStatus1.Name = "lblDownloadStatus1";
            this.lblDownloadStatus1.Size = new System.Drawing.Size(28, 14);
            this.lblDownloadStatus1.TabIndex = 25;
            this.lblDownloadStatus1.Text = "0/0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "FileTemp Downloaded:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 204);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(574, 25);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 26;
            // 
            // frmPotonganDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblDownloadStatus1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdCLose);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPotonganDownload";
            this.Text = "Download Potongan";
            this.Title = "Download Potongan";
            this.Load += new System.EventHandler(this.frmPotonganDownload_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdCLose, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblDownloadStatus1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdDownload;
        private ISA.Trading.Controls.CommandButton cmdCLose;
        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.Label lblDownloadStatus1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
