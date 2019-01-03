namespace ISA.Toko.CSM
{
    partial class frmMasterMitraSAS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterMitraSAS));
            this.btnUpload = new ISA.Toko.Controls.CommandButton();
            this.btnDownload = new ISA.Toko.Controls.CommandButton();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.btnDelete = new ISA.Toko.Controls.CommandButton();
            this.dataGridCustomerDetail = new ISA.Toko.Controls.CustomGridView();
            this.idBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelToko = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.txtSearch = new ISA.Toko.Controls.CommonTextBox();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.btnEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdADD = new ISA.Toko.Controls.CommandButton();
            this.dataGridCustomerInti = new ISA.Toko.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daerah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Propinsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDWil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbangun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dkontrak1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dkontrak2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jnsjual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jkp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmplahirp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgllahirp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alamatp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notelpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nohpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.norekp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmbankp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lpasif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kd_toko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomerDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomerInti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Upload;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(647, 403);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(128, 40);
            this.btnUpload.TabIndex = 65;
            this.btnUpload.Text = "UPLOAD";
            this.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Download;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(499, 403);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(128, 40);
            this.btnDownload.TabIndex = 64;
            this.btnDownload.Text = "DOWNLOAD";
            this.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = true;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Print;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(380, 402);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 63;
            this.commandButton1.Text = "PRINT";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(262, 401);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 62;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridCustomerDetail
            // 
            this.dataGridCustomerDetail.AllowUserToAddRows = false;
            this.dataGridCustomerDetail.AllowUserToDeleteRows = false;
            this.dataGridCustomerDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCustomerDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridCustomerDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridCustomerDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idBarang,
            this.NamaStok,
            this.Sat,
            this.Klp,
            this.QJual,
            this.QRetur});
            this.dataGridCustomerDetail.Location = new System.Drawing.Point(18, 333);
            this.dataGridCustomerDetail.MultiSelect = false;
            this.dataGridCustomerDetail.Name = "dataGridCustomerDetail";
            this.dataGridCustomerDetail.ReadOnly = true;
            this.dataGridCustomerDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridCustomerDetail.Size = new System.Drawing.Size(1241, 61);
            this.dataGridCustomerDetail.StandardTab = true;
            this.dataGridCustomerDetail.TabIndex = 61;
            // 
            // idBarang
            // 
            this.idBarang.DataPropertyName = "id_brg";
            this.idBarang.HeaderText = "idBarang";
            this.idBarang.Name = "idBarang";
            this.idBarang.ReadOnly = true;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "nama_stock";
            this.NamaStok.HeaderText = "NamaStok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            // 
            // Sat
            // 
            this.Sat.DataPropertyName = "satuan";
            this.Sat.HeaderText = "Sat";
            this.Sat.Name = "Sat";
            this.Sat.ReadOnly = true;
            // 
            // Klp
            // 
            this.Klp.DataPropertyName = "klp";
            this.Klp.HeaderText = "Klp";
            this.Klp.Name = "Klp";
            this.Klp.ReadOnly = true;
            // 
            // QJual
            // 
            this.QJual.DataPropertyName = "qjual";
            this.QJual.HeaderText = "QJual";
            this.QJual.Name = "QJual";
            this.QJual.ReadOnly = true;
            // 
            // QRetur
            // 
            this.QRetur.DataPropertyName = "qretur";
            this.QRetur.HeaderText = "QRetur";
            this.QRetur.Name = "QRetur";
            this.QRetur.ReadOnly = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(493, 40);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(630, 23);
            this.progressBar1.TabIndex = 60;
            this.progressBar1.Visible = false;
            // 
            // labelToko
            // 
            this.labelToko.AutoSize = true;
            this.labelToko.Location = new System.Drawing.Point(43, 46);
            this.labelToko.Name = "labelToko";
            this.labelToko.Size = new System.Drawing.Size(67, 14);
            this.labelToko.TabIndex = 59;
            this.labelToko.Text = "Nama Toko";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(370, 41);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 58;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(120, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 20);
            this.txtSearch.TabIndex = 57;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1159, 403);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 56;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(136, 401);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 55;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(17, 401);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 54;
            this.cmdADD.TabStop = false;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            // 
            // dataGridCustomerInti
            // 
            this.dataGridCustomerInti.AllowUserToAddRows = false;
            this.dataGridCustomerInti.AllowUserToDeleteRows = false;
            this.dataGridCustomerInti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCustomerInti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridCustomerInti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridCustomerInti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.IDToko,
            this.NamaToko,
            this.Alamat,
            this.Kota,
            this.Daerah,
            this.Propinsi,
            this.IDWil,
            this.NoTelp,
            this.NoFax,
            this.Sts,
            this.dbangun,
            this.dkontrak1,
            this.dkontrak2,
            this.jnsjual,
            this.segment,
            this.namap,
            this.jkp,
            this.tmplahirp,
            this.tgllahirp,
            this.alamatp,
            this.notelpp,
            this.nohpp,
            this.emailp,
            this.norekp,
            this.nmbankp,
            this.lpasif,
            this.kd_toko,
            this.no_id,
            this.lastorder});
            this.dataGridCustomerInti.Location = new System.Drawing.Point(18, 82);
            this.dataGridCustomerInti.MultiSelect = false;
            this.dataGridCustomerInti.Name = "dataGridCustomerInti";
            this.dataGridCustomerInti.ReadOnly = true;
            this.dataGridCustomerInti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridCustomerInti.Size = new System.Drawing.Size(1241, 229);
            this.dataGridCustomerInti.StandardTab = true;
            this.dataGridCustomerInti.TabIndex = 53;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.Frozen = true;
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // IDToko
            // 
            this.IDToko.DataPropertyName = "IDToko";
            this.IDToko.HeaderText = "IDToko";
            this.IDToko.Name = "IDToko";
            this.IDToko.ReadOnly = true;
            this.IDToko.Visible = false;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // Daerah
            // 
            this.Daerah.DataPropertyName = "Daerah";
            this.Daerah.HeaderText = "Daerah";
            this.Daerah.Name = "Daerah";
            this.Daerah.ReadOnly = true;
            // 
            // Propinsi
            // 
            this.Propinsi.DataPropertyName = "Propinsi";
            this.Propinsi.HeaderText = "Propinsi";
            this.Propinsi.Name = "Propinsi";
            this.Propinsi.ReadOnly = true;
            // 
            // IDWil
            // 
            this.IDWil.DataPropertyName = "idwil";
            this.IDWil.HeaderText = "IDWil";
            this.IDWil.Name = "IDWil";
            this.IDWil.ReadOnly = true;
            // 
            // NoTelp
            // 
            this.NoTelp.DataPropertyName = "notelp";
            this.NoTelp.HeaderText = "NoTelp";
            this.NoTelp.Name = "NoTelp";
            this.NoTelp.ReadOnly = true;
            // 
            // NoFax
            // 
            this.NoFax.DataPropertyName = "nofax";
            this.NoFax.HeaderText = "No Fax";
            this.NoFax.Name = "NoFax";
            this.NoFax.ReadOnly = true;
            // 
            // Sts
            // 
            this.Sts.DataPropertyName = "status";
            this.Sts.HeaderText = "Status";
            this.Sts.Name = "Sts";
            this.Sts.ReadOnly = true;
            // 
            // dbangun
            // 
            this.dbangun.DataPropertyName = "dbangun";
            this.dbangun.HeaderText = "dbangun";
            this.dbangun.Name = "dbangun";
            this.dbangun.ReadOnly = true;
            // 
            // dkontrak1
            // 
            this.dkontrak1.DataPropertyName = "dkontrak1";
            this.dkontrak1.HeaderText = "dkontrak1";
            this.dkontrak1.Name = "dkontrak1";
            this.dkontrak1.ReadOnly = true;
            // 
            // dkontrak2
            // 
            this.dkontrak2.DataPropertyName = "dkontrak2";
            this.dkontrak2.HeaderText = "dkontrak2";
            this.dkontrak2.Name = "dkontrak2";
            this.dkontrak2.ReadOnly = true;
            // 
            // jnsjual
            // 
            this.jnsjual.DataPropertyName = "jnsjual";
            this.jnsjual.HeaderText = "jnsjual";
            this.jnsjual.Name = "jnsjual";
            this.jnsjual.ReadOnly = true;
            // 
            // segment
            // 
            this.segment.DataPropertyName = "segment";
            this.segment.HeaderText = "segment";
            this.segment.Name = "segment";
            this.segment.ReadOnly = true;
            // 
            // namap
            // 
            this.namap.DataPropertyName = "namap";
            this.namap.HeaderText = "namap";
            this.namap.Name = "namap";
            this.namap.ReadOnly = true;
            // 
            // jkp
            // 
            this.jkp.DataPropertyName = "jkp";
            this.jkp.HeaderText = "jkp";
            this.jkp.Name = "jkp";
            this.jkp.ReadOnly = true;
            // 
            // tmplahirp
            // 
            this.tmplahirp.DataPropertyName = "tmplahirp";
            this.tmplahirp.HeaderText = "tmplahirp";
            this.tmplahirp.Name = "tmplahirp";
            this.tmplahirp.ReadOnly = true;
            // 
            // tgllahirp
            // 
            this.tgllahirp.DataPropertyName = "tgllahirp";
            this.tgllahirp.HeaderText = "tgllahirp";
            this.tgllahirp.Name = "tgllahirp";
            this.tgllahirp.ReadOnly = true;
            // 
            // alamatp
            // 
            this.alamatp.DataPropertyName = "alamatp";
            this.alamatp.HeaderText = "alamatp";
            this.alamatp.Name = "alamatp";
            this.alamatp.ReadOnly = true;
            // 
            // notelpp
            // 
            this.notelpp.DataPropertyName = "notelpp";
            this.notelpp.HeaderText = "notelpp";
            this.notelpp.Name = "notelpp";
            this.notelpp.ReadOnly = true;
            // 
            // nohpp
            // 
            this.nohpp.DataPropertyName = "nohpp";
            this.nohpp.HeaderText = "nohpp";
            this.nohpp.Name = "nohpp";
            this.nohpp.ReadOnly = true;
            // 
            // emailp
            // 
            this.emailp.DataPropertyName = "emailp";
            this.emailp.HeaderText = "emailp";
            this.emailp.Name = "emailp";
            this.emailp.ReadOnly = true;
            // 
            // norekp
            // 
            this.norekp.DataPropertyName = "norekp";
            this.norekp.HeaderText = "norekp";
            this.norekp.Name = "norekp";
            this.norekp.ReadOnly = true;
            // 
            // nmbankp
            // 
            this.nmbankp.DataPropertyName = "nmbankp";
            this.nmbankp.HeaderText = "nmbankp";
            this.nmbankp.Name = "nmbankp";
            this.nmbankp.ReadOnly = true;
            // 
            // lpasif
            // 
            this.lpasif.DataPropertyName = "lpasif";
            this.lpasif.HeaderText = "lpasif";
            this.lpasif.Name = "lpasif";
            this.lpasif.ReadOnly = true;
            // 
            // kd_toko
            // 
            this.kd_toko.DataPropertyName = "kd_toko";
            this.kd_toko.HeaderText = "kd_toko";
            this.kd_toko.Name = "kd_toko";
            this.kd_toko.ReadOnly = true;
            // 
            // no_id
            // 
            this.no_id.DataPropertyName = "no_id";
            this.no_id.HeaderText = "no_id";
            this.no_id.Name = "no_id";
            this.no_id.ReadOnly = true;
            // 
            // lastorder
            // 
            this.lastorder.DataPropertyName = "lastorder";
            this.lastorder.HeaderText = "lastorder";
            this.lastorder.Name = "lastorder";
            this.lastorder.ReadOnly = true;
            // 
            // frmMasterMitraSAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 483);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridCustomerDetail);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelToko);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dataGridCustomerInti);
            this.FormID = "CMS.02";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMasterMitraSAS";
            this.Text = "CMS.02 - Title";
            this.Load += new System.EventHandler(this.MasterCustomerInti_Load);
            this.Controls.SetChildIndex(this.dataGridCustomerInti, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.labelToko, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.dataGridCustomerDetail, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.btnDownload, 0);
            this.Controls.SetChildIndex(this.btnUpload, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomerDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomerInti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton btnUpload;
        private ISA.Toko.Controls.CommandButton btnDownload;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton btnDelete;
        private ISA.Toko.Controls.CustomGridView dataGridCustomerDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klp;
        private System.Windows.Forms.DataGridViewTextBoxColumn QJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn QRetur;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelToko;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.CommonTextBox txtSearch;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton btnEdit;
        private ISA.Toko.Controls.CommandButton cmdADD;
        private ISA.Toko.Controls.CustomGridView dataGridCustomerInti;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daerah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Propinsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDWil;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbangun;
        private System.Windows.Forms.DataGridViewTextBoxColumn dkontrak1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dkontrak2;
        private System.Windows.Forms.DataGridViewTextBoxColumn jnsjual;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment;
        private System.Windows.Forms.DataGridViewTextBoxColumn namap;
        private System.Windows.Forms.DataGridViewTextBoxColumn jkp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmplahirp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgllahirp;
        private System.Windows.Forms.DataGridViewTextBoxColumn alamatp;
        private System.Windows.Forms.DataGridViewTextBoxColumn notelpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nohpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailp;
        private System.Windows.Forms.DataGridViewTextBoxColumn norekp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmbankp;
        private System.Windows.Forms.DataGridViewTextBoxColumn lpasif;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_toko;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastorder;


    }
}