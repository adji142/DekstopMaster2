namespace ISA.Toko.CommunicatorISA
{
    partial class frmPosDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosDownload));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCtr = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.cdmDownload = new ISA.Controls.CommandButton();
            this.cdmClose = new ISA.Controls.CommandButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 110);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(696, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Jumlah Table:";
            // 
            // lblCtr
            // 
            this.lblCtr.AutoSize = true;
            this.lblCtr.Location = new System.Drawing.Point(127, 198);
            this.lblCtr.Name = "lblCtr";
            this.lblCtr.Size = new System.Drawing.Size(28, 14);
            this.lblCtr.TabIndex = 15;
            this.lblCtr.Text = "0/30";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(28, 172);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(19, 14);
            this.LabelStatus.TabIndex = 14;
            this.LabelStatus.Text = "....";
            // 
            // cdmDownload
            // 
            this.cdmDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cdmDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cdmDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cdmDownload.Image = ((System.Drawing.Image)(resources.GetObject("cdmDownload.Image")));
            this.cdmDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cdmDownload.Location = new System.Drawing.Point(9, 257);
            this.cdmDownload.Name = "cdmDownload";
            this.cdmDownload.Size = new System.Drawing.Size(128, 40);
            this.cdmDownload.TabIndex = 17;
            this.cdmDownload.Text = "DOWNLOAD";
            this.cdmDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cdmDownload.UseVisualStyleBackColor = true;
            this.cdmDownload.Click += new System.EventHandler(this.cdmDownload_Click);
            // 
            // cdmClose
            // 
            this.cdmClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cdmClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cdmClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cdmClose.Image = ((System.Drawing.Image)(resources.GetObject("cdmClose.Image")));
            this.cdmClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cdmClose.Location = new System.Drawing.Point(605, 257);
            this.cdmClose.Name = "cdmClose";
            this.cdmClose.Size = new System.Drawing.Size(100, 40);
            this.cdmClose.TabIndex = 18;
            this.cdmClose.Text = "CLOSE";
            this.cdmClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cdmClose.UseVisualStyleBackColor = true;
            this.cdmClose.Click += new System.EventHandler(this.cdmClose_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmPosDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cdmClose);
            this.Controls.Add(this.cdmDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCtr);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.progressBar1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPosDownload";
            this.Text = "POS Download (ISA)";
            this.Title = "POS Download (ISA)";
            this.Load += new System.EventHandler(this.frmPosDownload_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.LabelStatus, 0);
            this.Controls.SetChildIndex(this.lblCtr, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cdmDownload, 0);
            this.Controls.SetChildIndex(this.cdmClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCtr;
        private System.Windows.Forms.Label LabelStatus;
        private ISA.Controls.CommandButton cdmDownload;
        private ISA.Controls.CommandButton cdmClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
