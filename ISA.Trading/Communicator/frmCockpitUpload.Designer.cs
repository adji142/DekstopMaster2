namespace ISA.Trading.Communicator
{
    partial class frmCockpitUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCockpitUpload));
            this.pbSyncUpload = new System.Windows.Forms.ProgressBar();
            this.cmdStartUpload = new ISA.Trading.Controls.CommandButton();
            this.cmdCancel = new ISA.Trading.Controls.CommandButton();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbSyncUpload
            // 
            this.pbSyncUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncUpload.Location = new System.Drawing.Point(9, 86);
            this.pbSyncUpload.Name = "pbSyncUpload";
            this.pbSyncUpload.Size = new System.Drawing.Size(687, 23);
            this.pbSyncUpload.TabIndex = 5;
            // 
            // cmdStartUpload
            // 
            this.cmdStartUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartUpload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Upload;
            this.cmdStartUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdStartUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdStartUpload.Image")));
            this.cmdStartUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStartUpload.Location = new System.Drawing.Point(464, 289);
            this.cmdStartUpload.Name = "cmdStartUpload";
            this.cmdStartUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdStartUpload.TabIndex = 6;
            this.cmdStartUpload.Text = "UPLOAD";
            this.cmdStartUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStartUpload.UseVisualStyleBackColor = true;
            this.cmdStartUpload.Click += new System.EventHandler(this.cmdStartUpload_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(598, 289);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(6, 135);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 14);
            this.lblProgress.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Table Upload:";
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(110, 115);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(28, 14);
            this.lblUpload.TabIndex = 10;
            this.lblUpload.Text = "0/38";
            // 
            // lblUploadCount
            // 
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Location = new System.Drawing.Point(626, 115);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(40, 14);
            this.lblUploadCount.TabIndex = 11;
            this.lblUploadCount.Text = "Count";
            // 
            // frmCockpitUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdStartUpload);
            this.Controls.Add(this.pbSyncUpload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCockpitUpload";
            this.Text = "Cockpit Upload";
            this.Title = "Cockpit Upload";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmSyncUpload_Load);
            this.Controls.SetChildIndex(this.pbSyncUpload, 0);
            this.Controls.SetChildIndex(this.cmdStartUpload, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUpload, 0);
            this.Controls.SetChildIndex(this.lblUploadCount, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbSyncUpload;
        private ISA.Trading.Controls.CommandButton cmdStartUpload;
        private ISA.Trading.Controls.CommandButton cmdCancel;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label lblUploadCount;
    }
}
