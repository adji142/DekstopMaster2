namespace ISA.Finance.VWil
{
    partial class frmRiwayatIDWilUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRiwayatIDWilUpload));
            this.cmdUpload = new ISA.Controls.CommandButton();
            this.cmdDownload = new ISA.Controls.CommandButton();
            this.lblCountRow = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInitPerusahaan = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpload.CommandType = ISA.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(201, 204);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 3;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(338, 204);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(100, 40);
            this.cmdDownload.TabIndex = 4;
            this.cmdDownload.Text = "CLOSE";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // lblCountRow
            // 
            this.lblCountRow.AutoSize = true;
            this.lblCountRow.Location = new System.Drawing.Point(409, 162);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(13, 14);
            this.lblCountRow.TabIndex = 24;
            this.lblCountRow.Text = "0";
            this.lblCountRow.Visible = false;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(230, 162);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(80, 14);
            this.lblTableName.TabIndex = 23;
            this.lblTableName.Text = "lblTableName";
            this.lblTableName.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(1, 136);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(451, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Init Perusahaan";
            // 
            // txtInitPerusahaan
            // 
            this.txtInitPerusahaan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInitPerusahaan.Location = new System.Drawing.Point(123, 63);
            this.txtInitPerusahaan.MaxLength = 3;
            this.txtInitPerusahaan.Name = "txtInitPerusahaan";
            this.txtInitPerusahaan.Size = new System.Drawing.Size(52, 20);
            this.txtInitPerusahaan.TabIndex = 26;
            // 
            // frmRiwayatIDWilUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(450, 256);
            this.Controls.Add(this.txtInitPerusahaan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCountRow);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdUpload);
            this.Name = "frmRiwayatIDWilUpload";
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.lblTableName, 0);
            this.Controls.SetChildIndex(this.lblCountRow, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtInitPerusahaan, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdUpload;
        private ISA.Controls.CommandButton cmdDownload;
        private System.Windows.Forms.Label lblCountRow;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtInitPerusahaan;
    }
}
