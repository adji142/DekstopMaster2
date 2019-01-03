namespace ISA.Trading.Communicator
{
    partial class frmCockpitDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCockpitDownload));
            this.pbSyncDownload = new System.Windows.Forms.ProgressBar();
            this.cmdCancel = new ISA.Trading.Controls.CommandButton();
            this.cmdStartDownload = new ISA.Trading.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDownload = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbSyncDownload
            // 
            this.pbSyncDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncDownload.Location = new System.Drawing.Point(12, 60);
            this.pbSyncDownload.Name = "pbSyncDownload";
            this.pbSyncDownload.Size = new System.Drawing.Size(687, 23);
            this.pbSyncDownload.TabIndex = 9;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(599, 289);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdStartDownload
            // 
            this.cmdStartDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartDownload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.cmdStartDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdStartDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdStartDownload.Image")));
            this.cmdStartDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStartDownload.Location = new System.Drawing.Point(465, 289);
            this.cmdStartDownload.Name = "cmdStartDownload";
            this.cmdStartDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdStartDownload.TabIndex = 11;
            this.cmdStartDownload.Text = "DOWNLOAD";
            this.cmdStartDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStartDownload.UseVisualStyleBackColor = true;
            this.cmdStartDownload.Click += new System.EventHandler(this.cmdStartDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 13;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(9, 129);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(28, 14);
            this.lblCount.TabIndex = 16;
            this.lblCount.Text = "0/0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Table Download:";
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(117, 86);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(35, 14);
            this.lblDownload.TabIndex = 18;
            this.lblDownload.Text = "0/38";
            // 
            // frmCockpitDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdStartDownload);
            this.Controls.Add(this.pbSyncDownload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCockpitDownload";
            this.Text = "Cockpit Download";
            this.Title = "Cockpit Download";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmCockpitDownload_Load);
            this.Controls.SetChildIndex(this.pbSyncDownload, 0);
            this.Controls.SetChildIndex(this.cmdStartDownload, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblDownload, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbSyncDownload;
        private ISA.Trading.Controls.CommandButton cmdCancel;
        private ISA.Trading.Controls.CommandButton cmdStartDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDownload;
    }
}
