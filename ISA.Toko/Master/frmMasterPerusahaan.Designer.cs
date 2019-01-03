namespace ISA.Toko.Master
{
    partial class frmMasterPerusahaan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterPerusahaan));
            this.dataGridPerusahaan = new ISA.Toko.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitPerusahaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Propinsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Negara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodePos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPWP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPKP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipeLokasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton1 = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerusahaan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPerusahaan
            // 
            this.dataGridPerusahaan.AllowUserToAddRows = false;
            this.dataGridPerusahaan.AllowUserToDeleteRows = false;
            this.dataGridPerusahaan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPerusahaan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridPerusahaan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridPerusahaan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPerusahaan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.InitPerusahaan,
            this.Nama,
            this.Alamat,
            this.Kota,
            this.Propinsi,
            this.Negara,
            this.KodePos,
            this.Telp,
            this.Fax,
            this.Email,
            this.Website,
            this.NPWP,
            this.TglPKP,
            this.InitCabang,
            this.InitGudang,
            this.PartStation,
            this.TipeLokasi,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridPerusahaan.Location = new System.Drawing.Point(45, 69);
            this.dataGridPerusahaan.MultiSelect = false;
            this.dataGridPerusahaan.Name = "dataGridPerusahaan";
            this.dataGridPerusahaan.ReadOnly = true;
            this.dataGridPerusahaan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridPerusahaan.Size = new System.Drawing.Size(785, 296);
            this.dataGridPerusahaan.StandardTab = true;
            this.dataGridPerusahaan.TabIndex = 6;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // InitPerusahaan
            // 
            this.InitPerusahaan.DataPropertyName = "InitPerusahaan";
            this.InitPerusahaan.HeaderText = "InitPerusahaan";
            this.InitPerusahaan.Name = "InitPerusahaan";
            this.InitPerusahaan.ReadOnly = true;
            this.InitPerusahaan.Width = 114;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 62;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Width = 70;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            this.Kota.Width = 56;
            // 
            // Propinsi
            // 
            this.Propinsi.DataPropertyName = "Propinsi";
            this.Propinsi.HeaderText = "Propinsi";
            this.Propinsi.Name = "Propinsi";
            this.Propinsi.ReadOnly = true;
            this.Propinsi.Width = 78;
            // 
            // Negara
            // 
            this.Negara.DataPropertyName = "Negara";
            this.Negara.HeaderText = "Negara";
            this.Negara.Name = "Negara";
            this.Negara.ReadOnly = true;
            this.Negara.Width = 70;
            // 
            // KodePos
            // 
            this.KodePos.DataPropertyName = "KodePos";
            this.KodePos.HeaderText = "KodePos";
            this.KodePos.Name = "KodePos";
            this.KodePos.ReadOnly = true;
            this.KodePos.Width = 81;
            // 
            // Telp
            // 
            this.Telp.DataPropertyName = "Telp";
            this.Telp.HeaderText = "Telp";
            this.Telp.Name = "Telp";
            this.Telp.ReadOnly = true;
            this.Telp.Width = 55;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            this.Fax.Width = 50;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 61;
            // 
            // Website
            // 
            this.Website.DataPropertyName = "Website";
            this.Website.HeaderText = "Website";
            this.Website.Name = "Website";
            this.Website.ReadOnly = true;
            this.Website.Width = 77;
            // 
            // NPWP
            // 
            this.NPWP.DataPropertyName = "NPWP";
            this.NPWP.HeaderText = "NPWP";
            this.NPWP.Name = "NPWP";
            this.NPWP.ReadOnly = true;
            this.NPWP.Width = 63;
            // 
            // TglPKP
            // 
            this.TglPKP.DataPropertyName = "TglPKP";
            this.TglPKP.HeaderText = "TglPKP";
            this.TglPKP.Name = "TglPKP";
            this.TglPKP.ReadOnly = true;
            this.TglPKP.Width = 70;
            // 
            // InitCabang
            // 
            this.InitCabang.DataPropertyName = "InitCabang";
            this.InitCabang.HeaderText = "InitCabang";
            this.InitCabang.Name = "InitCabang";
            this.InitCabang.ReadOnly = true;
            this.InitCabang.Width = 90;
            // 
            // InitGudang
            // 
            this.InitGudang.DataPropertyName = "InitGudang";
            this.InitGudang.HeaderText = "InitGudang";
            this.InitGudang.Name = "InitGudang";
            this.InitGudang.ReadOnly = true;
            this.InitGudang.Width = 91;
            // 
            // PartStation
            // 
            this.PartStation.DataPropertyName = "PartStation";
            this.PartStation.HeaderText = "PartStation";
            this.PartStation.Name = "PartStation";
            this.PartStation.ReadOnly = true;
            this.PartStation.Width = 92;
            // 
            // TipeLokasi
            // 
            this.TipeLokasi.DataPropertyName = "TipeLokasi";
            this.TipeLokasi.HeaderText = "TipeLokasi";
            this.TipeLokasi.Name = "TipeLokasi";
            this.TipeLokasi.ReadOnly = true;
            this.TipeLokasi.Width = 93;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Width = 114;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm:ss";
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Width = 129;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(730, 407);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 7;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // frmMasterPerusahaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 479);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.dataGridPerusahaan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMasterPerusahaan";
            this.Text = "Perusahaan";
            this.Title = "Perusahaan";
            this.Load += new System.EventHandler(this.frmMasterPerusahaan_Load);
            this.Controls.SetChildIndex(this.dataGridPerusahaan, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerusahaan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridPerusahaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitPerusahaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Propinsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Negara;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodePos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPWP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPKP;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipeLokasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private ISA.Controls.CommandButton commandButton1;



    }
}