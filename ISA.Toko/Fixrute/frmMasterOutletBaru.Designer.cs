namespace ISA.Toko.Fixrute
{
    partial class frmMasterOutletBaru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterOutletBaru));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daerah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kecamatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Propinsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idwil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pemilik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenanggungJawab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomerTelp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDownload = new System.Windows.Forms.Button();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.cmdEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 86);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1273, 367);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaToko,
            this.RowID,
            this.Alamat,
            this.Kota,
            this.Daerah,
            this.Kecamatan,
            this.Propinsi,
            this.Idwil,
            this.IdToko,
            this.NoTelp,
            this.Pemilik,
            this.PenanggungJawab,
            this.Alamat1,
            this.NomerTelp1,
            this.Cabang,
            this.Catatan,
            this.SyncFlag,
            this.KodeToko});
            this.customGridView1.Location = new System.Drawing.Point(3, 3);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(1267, 361);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 0;
            this.customGridView1.DoubleClick += new System.EventHandler(this.customGridView1_DoubleClick);
            this.customGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.customGridView1_CellFormatting);
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "namatoko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.Visible = false;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            // 
            // Daerah
            // 
            this.Daerah.DataPropertyName = "daerah";
            this.Daerah.HeaderText = "Daerah";
            this.Daerah.Name = "Daerah";
            // 
            // Kecamatan
            // 
            this.Kecamatan.DataPropertyName = "kecamatan";
            this.Kecamatan.HeaderText = "Kecamatan";
            this.Kecamatan.Name = "Kecamatan";
            // 
            // Propinsi
            // 
            this.Propinsi.DataPropertyName = "propinsi";
            this.Propinsi.HeaderText = "Propinsi";
            this.Propinsi.Name = "Propinsi";
            // 
            // Idwil
            // 
            this.Idwil.DataPropertyName = "idwil";
            this.Idwil.HeaderText = "ID Wilayah";
            this.Idwil.Name = "Idwil";
            // 
            // IdToko
            // 
            this.IdToko.DataPropertyName = "idtoko";
            this.IdToko.HeaderText = "ID Toko";
            this.IdToko.Name = "IdToko";
            // 
            // NoTelp
            // 
            this.NoTelp.DataPropertyName = "notelp";
            this.NoTelp.HeaderText = "Nomer Telp";
            this.NoTelp.Name = "NoTelp";
            // 
            // Pemilik
            // 
            this.Pemilik.DataPropertyName = "pemilik";
            this.Pemilik.HeaderText = "Pemilik";
            this.Pemilik.Name = "Pemilik";
            // 
            // PenanggungJawab
            // 
            this.PenanggungJawab.DataPropertyName = "pngjwb";
            this.PenanggungJawab.HeaderText = "Penanggung Jawab";
            this.PenanggungJawab.Name = "PenanggungJawab";
            // 
            // Alamat1
            // 
            this.Alamat1.DataPropertyName = "alamat1";
            this.Alamat1.HeaderText = "Alamat 1";
            this.Alamat1.Name = "Alamat1";
            // 
            // NomerTelp1
            // 
            this.NomerTelp1.DataPropertyName = "notelp1";
            this.NomerTelp1.HeaderText = "Nomer Telp1";
            this.NomerTelp1.Name = "NomerTelp1";
            // 
            // Cabang
            // 
            this.Cabang.DataPropertyName = "cabang";
            this.Cabang.HeaderText = "Cabang";
            this.Cabang.Name = "Cabang";
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            // 
            // KodeToko
            // 
            this.KodeToko.DataPropertyName = "kd_toko";
            this.KodeToko.HeaderText = "Kode Toko";
            this.KodeToko.Name = "KodeToko";
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = global::ISA.Toko.Properties.Resources.Download32;
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(149, 477);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(125, 40);
            this.cmdDownload.TabIndex = 62;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = global::ISA.Toko.Properties.Resources.Upload32;
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(17, 477);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(114, 40);
            this.cmdUpload.TabIndex = 61;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = global::ISA.Toko.Properties.Resources.Printer32;
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(290, 477);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 60;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1187, 477);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 59;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(645, 477);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 65;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(539, 477);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 64;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(433, 477);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 63;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmMasterOutletBaru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 529);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMasterOutletBaru";
            this.Text = "New Outlet";
            this.Title = "New Outlet";
            this.Load += new System.EventHandler(this.frmMasterOutletBaru_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Toko.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.Button cmdDownload;
        private System.Windows.Forms.Button cmdUpload;
        private System.Windows.Forms.Button cmdPrint;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daerah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kecamatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Propinsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idwil;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pemilik;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenanggungJawab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomerTelp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private ISA.Toko.Controls.CommandButton cmdEdit;
        private ISA.Toko.Controls.CommandButton cmdAdd;
    }
}