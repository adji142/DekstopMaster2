namespace ISA.Trading.Master
{
    partial class frmPerusahaanBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerusahaanBrowse));
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDelete = new ISA.Trading.Controls.CommandButton();
            this.cmdEdit = new ISA.Trading.Controls.CommandButton();
            this.gvPerusahaan = new ISA.Trading.Controls.CustomGridView();
            this.InitCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.WebSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.npwp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPkp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAdd = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvPerusahaan)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(118, 252);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(572, 252);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 2;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(12, 252);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 1;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // gvPerusahaan
            // 
            this.gvPerusahaan.AllowUserToAddRows = false;
            this.gvPerusahaan.AllowUserToDeleteRows = false;
            this.gvPerusahaan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvPerusahaan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPerusahaan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InitCabang,
            this.InitGudang,
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
            this.WebSite,
            this.npwp,
            this.TglPkp,
            this.RowID});
            this.gvPerusahaan.Location = new System.Drawing.Point(12, 61);
            this.gvPerusahaan.MultiSelect = false;
            this.gvPerusahaan.Name = "gvPerusahaan";
            this.gvPerusahaan.ReadOnly = true;
            this.gvPerusahaan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvPerusahaan.Size = new System.Drawing.Size(766, 179);
            this.gvPerusahaan.StandardTab = true;
            this.gvPerusahaan.TabIndex = 4;
            // 
            // InitCabang
            // 
            this.InitCabang.DataPropertyName = "InitCabang";
            this.InitCabang.HeaderText = "Cabang";
            this.InitCabang.Name = "InitCabang";
            this.InitCabang.ReadOnly = true;
            this.InitCabang.Width = 60;
            // 
            // InitGudang
            // 
            this.InitGudang.DataPropertyName = "InitGudang";
            this.InitGudang.HeaderText = "Gudang";
            this.InitGudang.Name = "InitGudang";
            this.InitGudang.ReadOnly = true;
            this.InitGudang.Width = 60;
            // 
            // InitPerusahaan
            // 
            this.InitPerusahaan.DataPropertyName = "InitPerusahaan";
            this.InitPerusahaan.HeaderText = "InitPerusahaan";
            this.InitPerusahaan.Name = "InitPerusahaan";
            this.InitPerusahaan.ReadOnly = true;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama Perusahaan";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 250;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Width = 400;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            this.Kota.Width = 150;
            // 
            // Propinsi
            // 
            this.Propinsi.DataPropertyName = "Propinsi";
            this.Propinsi.HeaderText = "Propinsi";
            this.Propinsi.Name = "Propinsi";
            this.Propinsi.ReadOnly = true;
            this.Propinsi.Width = 150;
            // 
            // Negara
            // 
            this.Negara.DataPropertyName = "Negara";
            this.Negara.HeaderText = "Negara";
            this.Negara.Name = "Negara";
            this.Negara.ReadOnly = true;
            this.Negara.Width = 150;
            // 
            // KodePos
            // 
            this.KodePos.DataPropertyName = "KodePos";
            this.KodePos.HeaderText = "Kode Pos";
            this.KodePos.Name = "KodePos";
            this.KodePos.ReadOnly = true;
            // 
            // Telp
            // 
            this.Telp.DataPropertyName = "Telp";
            this.Telp.HeaderText = "Telepon";
            this.Telp.Name = "Telp";
            this.Telp.ReadOnly = true;
            this.Telp.Width = 150;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            this.Fax.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // WebSite
            // 
            this.WebSite.DataPropertyName = "WebSite";
            this.WebSite.HeaderText = "WebSite";
            this.WebSite.Name = "WebSite";
            this.WebSite.ReadOnly = true;
            this.WebSite.Width = 150;
            // 
            // npwp
            // 
            this.npwp.DataPropertyName = "npwp";
            this.npwp.HeaderText = "NPWP";
            this.npwp.Name = "npwp";
            this.npwp.ReadOnly = true;
            this.npwp.Width = 150;
            // 
            // TglPkp
            // 
            this.TglPkp.DataPropertyName = "TglPKP";
            this.TglPkp.HeaderText = "Tgl PKP";
            this.TglPkp.Name = "TglPkp";
            this.TglPkp.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Width = 200;
            // 
            // cmdAdd
            // 
            this.cmdAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(678, 252);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 0;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Visible = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmPerusahaanBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(791, 314);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.gvPerusahaan);
            this.Controls.Add(this.cmdAdd);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPerusahaanBrowse";
            this.Text = "Perusahaan";
            this.Title = "Perusahaan";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPerusahaanBrowse_Load);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.gvPerusahaan, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvPerusahaan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView gvPerusahaan;
        private ISA.Trading.Controls.CommandButton cmdAdd;
        private ISA.Trading.Controls.CommandButton cmdEdit;
        private ISA.Trading.Controls.CommandButton cmdDelete;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitGudang;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn WebSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn npwp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPkp;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
