namespace ISA.Toko.Communicator
{
    partial class frmNotaPenjualanDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaPenjualanDownload));
            this.label1 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Toko.Controls.LookupGudang();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.cmdUpload = new ISA.Toko.Controls.CommandButton();
            this.cmdDownload = new ISA.Toko.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dari Gudang";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[Code]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(118, 64);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(392, 54);
            this.lookupGudang1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(693, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // cmdUpload
            // 
            this.cmdUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(598, 289);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(100, 40);
            this.cmdUpload.TabIndex = 3;
            this.cmdUpload.Text = "CLOSE";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            // 
            // cmdDownload
            // 
            this.cmdDownload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(446, 289);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 2;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            // 
            // frmNotaPenjualanDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.cmdDownload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNotaPenjualanDownload";
            this.Text = "\'";
            this.Title = "\'";
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.LookupGudang lookupGudang1;
        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private ISA.Toko.Controls.CommandButton cmdUpload;
        private ISA.Toko.Controls.CommandButton cmdDownload;
    }
}
