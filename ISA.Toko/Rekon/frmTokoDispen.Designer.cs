namespace ISA.Toko.Rekon
{
    partial class frmTokoDispen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTokoDispen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKota = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDaerah = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdwil = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlasan1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAlasan2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txttmt2 = new ISA.Controls.DateTextBox();
            this.txttmt1 = new ISA.Controls.DateTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmdDownload = new ISA.Toko.Controls.CommandButton();
            this.cmdUpload = new ISA.Toko.Controls.CommandButton();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.txtNamaToko = new ISA.Toko.Controls.LookupToko();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.customGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.rowid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namatoko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idwil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatan2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama Toko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alamat";
            // 
            // txtAlamat
            // 
            this.txtAlamat.Enabled = false;
            this.txtAlamat.Location = new System.Drawing.Point(110, 81);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(417, 20);
            this.txtAlamat.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kota";
            // 
            // txtKota
            // 
            this.txtKota.Enabled = false;
            this.txtKota.Location = new System.Drawing.Point(110, 109);
            this.txtKota.Name = "txtKota";
            this.txtKota.ReadOnly = true;
            this.txtKota.Size = new System.Drawing.Size(236, 20);
            this.txtKota.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Daerah";
            // 
            // txtDaerah
            // 
            this.txtDaerah.Enabled = false;
            this.txtDaerah.Location = new System.Drawing.Point(109, 140);
            this.txtDaerah.Name = "txtDaerah";
            this.txtDaerah.ReadOnly = true;
            this.txtDaerah.Size = new System.Drawing.Size(236, 20);
            this.txtDaerah.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Id-Will ";
            // 
            // txtIdwil
            // 
            this.txtIdwil.Enabled = false;
            this.txtIdwil.Location = new System.Drawing.Point(109, 168);
            this.txtIdwil.Name = "txtIdwil";
            this.txtIdwil.ReadOnly = true;
            this.txtIdwil.Size = new System.Drawing.Size(94, 20);
            this.txtIdwil.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Alasan 1";
            // 
            // txtAlasan1
            // 
            this.txtAlasan1.Location = new System.Drawing.Point(109, 198);
            this.txtAlasan1.Name = "txtAlasan1";
            this.txtAlasan1.Size = new System.Drawing.Size(320, 20);
            this.txtAlasan1.TabIndex = 10;
            this.txtAlasan1.TextChanged += new System.EventHandler(this.txtAlasan1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Alasan 2";
            // 
            // txtAlasan2
            // 
            this.txtAlasan2.Enabled = false;
            this.txtAlasan2.Location = new System.Drawing.Point(109, 231);
            this.txtAlasan2.Name = "txtAlasan2";
            this.txtAlasan2.ReadOnly = true;
            this.txtAlasan2.Size = new System.Drawing.Size(320, 20);
            this.txtAlasan2.TabIndex = 12;
            this.txtAlasan2.TextChanged += new System.EventHandler(this.txtAlasan2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tmt1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "Tmt2";
            // 
            // txttmt2
            // 
            this.txttmt2.DateValue = null;
            this.txttmt2.Enabled = false;
            this.txttmt2.Location = new System.Drawing.Point(264, 257);
            this.txttmt2.MaxLength = 10;
            this.txttmt2.Name = "txttmt2";
            this.txttmt2.ReadOnly = true;
            this.txttmt2.Size = new System.Drawing.Size(93, 20);
            this.txttmt2.TabIndex = 18;
            this.txttmt2.TextChanged += new System.EventHandler(this.txttmt2_TextChanged);
            // 
            // txttmt1
            // 
            this.txttmt1.DateValue = null;
            this.txttmt1.Enabled = false;
            this.txttmt1.Location = new System.Drawing.Point(110, 257);
            this.txttmt1.MaxLength = 10;
            this.txttmt1.Name = "txttmt1";
            this.txttmt1.ReadOnly = true;
            this.txttmt1.Size = new System.Drawing.Size(93, 20);
            this.txttmt1.TabIndex = 17;
            this.txttmt1.TextChanged += new System.EventHandler(this.txttmt1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(24, 635);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1007, 13);
            this.progressBar1.TabIndex = 32;
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(881, 693);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 30;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click_1);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(747, 693);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 29;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click_1);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(140, 693);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 28;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // txtNamaToko
            // 
            this.txtNamaToko.Alamat = null;
            this.txtNamaToko.Daerah = null;
            this.txtNamaToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtNamaToko.HariKirim = 0;
            this.txtNamaToko.HariSales = 0;
            this.txtNamaToko.KodeToko = "[CODE]";
            this.txtNamaToko.Kota = null;
            this.txtNamaToko.Location = new System.Drawing.Point(109, 44);
            this.txtNamaToko.NamaToko = "";
            this.txtNamaToko.Name = "txtNamaToko";
            this.txtNamaToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtNamaToko.Size = new System.Drawing.Size(457, 30);
            this.txtNamaToko.TabIndex = 1;
            this.txtNamaToko.TokoID = null;
            this.txtNamaToko.WilID = "";
            this.txtNamaToko.Load += new System.EventHandler(this.txtNamaToko_Load);
            this.txtNamaToko.SelectData += new System.EventHandler(this.txtNamaToko_SelectData);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(245, 693);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 25;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSAVE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(34, 693);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 24;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowid,
            this.namatoko,
            this.alamat,
            this.kota,
            this.idwil,
            this.catatan1,
            this.catatan2});
            this.customGridView1.Location = new System.Drawing.Point(24, 283);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(1007, 346);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 14;
            // 
            // rowid
            // 
            this.rowid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rowid.DataPropertyName = "rowid";
            this.rowid.HeaderText = "ROWID";
            this.rowid.Name = "rowid";
            this.rowid.ReadOnly = true;
            // 
            // namatoko
            // 
            this.namatoko.DataPropertyName = "namatoko";
            this.namatoko.HeaderText = "NAMATOKO";
            this.namatoko.Name = "namatoko";
            this.namatoko.ReadOnly = true;
            this.namatoko.Width = 94;
            // 
            // alamat
            // 
            this.alamat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.alamat.DataPropertyName = "alamat";
            this.alamat.HeaderText = "ALAMAT";
            this.alamat.Name = "alamat";
            this.alamat.ReadOnly = true;
            // 
            // kota
            // 
            this.kota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kota.DataPropertyName = "kota";
            this.kota.HeaderText = "KOTA";
            this.kota.Name = "kota";
            this.kota.ReadOnly = true;
            // 
            // idwil
            // 
            this.idwil.DataPropertyName = "idwil";
            this.idwil.HeaderText = "IDWILL";
            this.idwil.Name = "idwil";
            this.idwil.ReadOnly = true;
            this.idwil.Width = 69;
            // 
            // catatan1
            // 
            this.catatan1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catatan1.DataPropertyName = "catatan1";
            this.catatan1.HeaderText = "ALASAN 1";
            this.catatan1.Name = "catatan1";
            this.catatan1.ReadOnly = true;
            // 
            // catatan2
            // 
            this.catatan2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catatan2.DataPropertyName = "catatan2";
            this.catatan2.HeaderText = "ALASAN 2";
            this.catatan2.Name = "catatan2";
            this.catatan2.ReadOnly = true;
            // 
            // frmTokoDispen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 746);
            this.Controls.Add(this.txtDaerah);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtNamaToko);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.txttmt2);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.txttmt1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAlasan2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlasan1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIdwil);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKota);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTokoDispen";
            this.Text = "Tabel Toko Dispensasi";
            this.Title = "Tabel Toko Dispensasi";
            this.Load += new System.EventHandler(this.frmTokoDispen_Load);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtIdwil, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtAlasan1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtAlasan2, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txttmt1, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.txttmt2, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.txtNamaToko, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDaerah, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDaerah;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdwil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlasan1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAlasan2;
        private ISA.Toko.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.DateTextBox txttmt1;
        private ISA.Controls.DateTextBox txttmt2;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private ISA.Toko.Controls.LookupToko txtNamaToko;
        
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private ISA.Toko.Controls.CommandButton cmdUpload;
        private ISA.Toko.Controls.CommandButton cmdDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowid;
        private System.Windows.Forms.DataGridViewTextBoxColumn namatoko;
        private System.Windows.Forms.DataGridViewTextBoxColumn alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn idwil;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatan2;
    }
}