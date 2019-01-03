namespace ISA.Trading.Communicator
{
    partial class frmHPPRataRataDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHPPRataRataDownload));
            this.lblFileNameLocation = new System.Windows.Forms.Label();
            this.gvHPP = new ISA.Trading.Controls.CustomGridView();
            this.pbHPPDownload = new System.Windows.Forms.ProgressBar();
            this.lblDonloadInfo = new System.Windows.Forms.Label();
            this.lblInfoRecordCount = new System.Windows.Forms.Label();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDownload = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvHPP)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileNameLocation
            // 
            this.lblFileNameLocation.AutoSize = true;
            this.lblFileNameLocation.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNameLocation.Location = new System.Drawing.Point(6, 69);
            this.lblFileNameLocation.Name = "lblFileNameLocation";
            this.lblFileNameLocation.Size = new System.Drawing.Size(64, 16);
            this.lblFileNameLocation.TabIndex = 5;
            this.lblFileNameLocation.Text = "HPPATMP";
            // 
            // gvHPP
            // 
            this.gvHPP.AllowUserToAddRows = false;
            this.gvHPP.AllowUserToDeleteRows = false;
            this.gvHPP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvHPP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvHPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHPP.Location = new System.Drawing.Point(9, 87);
            this.gvHPP.MultiSelect = false;
            this.gvHPP.Name = "gvHPP";
            this.gvHPP.ReadOnly = true;
            this.gvHPP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvHPP.Size = new System.Drawing.Size(706, 334);
            this.gvHPP.StandardTab = true;
            this.gvHPP.TabIndex = 6;
            // 
            // pbHPPDownload
            // 
            this.pbHPPDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHPPDownload.Location = new System.Drawing.Point(9, 428);
            this.pbHPPDownload.Name = "pbHPPDownload";
            this.pbHPPDownload.Size = new System.Drawing.Size(706, 23);
            this.pbHPPDownload.TabIndex = 7;
            // 
            // lblDonloadInfo
            // 
            this.lblDonloadInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDonloadInfo.AutoSize = true;
            this.lblDonloadInfo.Location = new System.Drawing.Point(9, 458);
            this.lblDonloadInfo.Name = "lblDonloadInfo";
            this.lblDonloadInfo.Size = new System.Drawing.Size(135, 14);
            this.lblDonloadInfo.TabIndex = 8;
            this.lblDonloadInfo.Text = "HPPATMP downloaded: ";
            // 
            // lblInfoRecordCount
            // 
            this.lblInfoRecordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfoRecordCount.AutoSize = true;
            this.lblInfoRecordCount.Location = new System.Drawing.Point(149, 458);
            this.lblInfoRecordCount.Name = "lblInfoRecordCount";
            this.lblInfoRecordCount.Size = new System.Drawing.Size(22, 14);
            this.lblInfoRecordCount.TabIndex = 11;
            this.lblInfoRecordCount.Text = "0/0";
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cmdClose);
            this.pnlButton.Controls.Add(this.cmdDownload);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 478);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(723, 60);
            this.pnlButton.TabIndex = 12;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(615, 8);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(464, 8);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 11;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // frmHPPRataRataDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(723, 538);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.lblInfoRecordCount);
            this.Controls.Add(this.lblDonloadInfo);
            this.Controls.Add(this.pbHPPDownload);
            this.Controls.Add(this.gvHPP);
            this.Controls.Add(this.lblFileNameLocation);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHPPRataRataDownload";
            this.Text = "Download HPP rata-rata";
            this.Title = "Download HPP rata-rata";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmHPPRataRataDownload_Load);
            this.Controls.SetChildIndex(this.lblFileNameLocation, 0);
            this.Controls.SetChildIndex(this.gvHPP, 0);
            this.Controls.SetChildIndex(this.pbHPPDownload, 0);
            this.Controls.SetChildIndex(this.lblDonloadInfo, 0);
            this.Controls.SetChildIndex(this.lblInfoRecordCount, 0);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvHPP)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileNameLocation;
        private ISA.Trading.Controls.CustomGridView gvHPP;
        private System.Windows.Forms.ProgressBar pbHPPDownload;
        private System.Windows.Forms.Label lblDonloadInfo;
        private System.Windows.Forms.Label lblInfoRecordCount;
        private System.Windows.Forms.Panel pnlButton;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdDownload;
    }
}
