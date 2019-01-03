namespace ISA.Finance.DKNForm
{
    partial class frmDownloadDKNPilih
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadDKNPilih));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new ISA.Controls.CommonTextBox();
            this.cmdDownload = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdBrowseFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pilih File Download";
            // 
            // txtFileName
            // 
            this.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFileName.Location = new System.Drawing.Point(154, 25);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(343, 20);
            this.txtFileName.TabIndex = 0;
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(317, 118);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(100, 40);
            this.cmdDownload.TabIndex = 2;
            this.cmdDownload.Text = "YES";
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
            this.cmdClose.Location = new System.Drawing.Point(423, 118);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdBrowseFile
            // 
            this.cmdBrowseFile.Location = new System.Drawing.Point(503, 24);
            this.cmdBrowseFile.Name = "cmdBrowseFile";
            this.cmdBrowseFile.Size = new System.Drawing.Size(29, 23);
            this.cmdBrowseFile.TabIndex = 1;
            this.cmdBrowseFile.Text = "...";
            this.cmdBrowseFile.UseVisualStyleBackColor = true;
            this.cmdBrowseFile.Click += new System.EventHandler(this.cmdBrowseFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmDownloadDKNPilih
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(535, 170);
            this.Controls.Add(this.cmdBrowseFile);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Name = "frmDownloadDKNPilih";
            this.Text = "Download DKN";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtFileName, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdBrowseFile, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtFileName;
        private ISA.Controls.CommandButton cmdDownload;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Button cmdBrowseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
