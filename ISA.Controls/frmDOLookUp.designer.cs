namespace ISA.Controls
{
    partial class frmDOLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDOLookUp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HtrID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACCPusat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCPiutangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACCPiutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglACCPiutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusBatal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HariKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pot1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pot2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pot3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDOBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglReorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expedisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HariKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HariSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.HtrID,
            this.Cabang1,
            this.Cabang2,
            this.Cabang3,
            this.NamaToko,
            this.AlamatKirim,
            this.NoRequest,
            this.TglRequest,
            this.NoDO,
            this.TglDO,
            this.NoACCPusat,
            this.ACCPiutangID,
            this.NoACCPiutang,
            this.TglACCPiutang,
            this.StatusBatal,
            this.HariKredit,
            this.KodeToko,
            this.SalesName,
            this.KodeSales,
            this.Kota,
            this.DiscFormula,
            this.Disc1,
            this.Disc2,
            this.Disc3,
            this.Pot1,
            this.Pot2,
            this.Pot3,
            this.Fee1,
            this.Fee2,
            this.isClosed,
            this.Catatan1,
            this.Catatan2,
            this.Catatan3,
            this.Catatan4,
            this.Catatan5,
            this.NoDOBO,
            this.TglReorder,
            this.StatusBO,
            this.SyncFlag,
            this.LinkID,
            this.TransactionType,
            this.Expedisi,
            this.HariKirim,
            this.HariSales,
            this.NPrint,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(611, 172);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nomor DO";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(96, 61);
            this.txtNama.MaxLength = 73;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(220, 20);
            this.txtNama.TabIndex = 19;
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(322, 59);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 20;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(497, 265);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 21;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // HtrID
            // 
            this.HtrID.DataPropertyName = "HtrID";
            this.HtrID.HeaderText = "Htr ID";
            this.HtrID.Name = "HtrID";
            this.HtrID.ReadOnly = true;
            this.HtrID.Visible = false;
            // 
            // Cabang1
            // 
            this.Cabang1.DataPropertyName = "Cabang1";
            this.Cabang1.HeaderText = "Cabang 1";
            this.Cabang1.Name = "Cabang1";
            this.Cabang1.ReadOnly = true;
            // 
            // Cabang2
            // 
            this.Cabang2.DataPropertyName = "Cabang2";
            this.Cabang2.HeaderText = "Cabang 2";
            this.Cabang2.Name = "Cabang2";
            this.Cabang2.ReadOnly = true;
            // 
            // Cabang3
            // 
            this.Cabang3.DataPropertyName = "Cabang3";
            this.Cabang3.HeaderText = "Cabang 3";
            this.Cabang3.Name = "Cabang3";
            this.Cabang3.ReadOnly = true;
            this.Cabang3.Visible = false;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "NamaToko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // AlamatKirim
            // 
            this.AlamatKirim.DataPropertyName = "AlamatKirim";
            this.AlamatKirim.HeaderText = "Alm Kirim";
            this.AlamatKirim.Name = "AlamatKirim";
            this.AlamatKirim.ReadOnly = true;
            // 
            // NoRequest
            // 
            this.NoRequest.DataPropertyName = "NoRequest";
            this.NoRequest.HeaderText = "No Request";
            this.NoRequest.Name = "NoRequest";
            this.NoRequest.ReadOnly = true;
            // 
            // TglRequest
            // 
            this.TglRequest.DataPropertyName = "TglRequest";
            this.TglRequest.HeaderText = "Tgl Request";
            this.TglRequest.Name = "TglRequest";
            this.TglRequest.ReadOnly = true;
            // 
            // NoDO
            // 
            this.NoDO.DataPropertyName = "NoDO";
            this.NoDO.HeaderText = "No DO";
            this.NoDO.Name = "NoDO";
            this.NoDO.ReadOnly = true;
            // 
            // TglDO
            // 
            this.TglDO.DataPropertyName = "TglDO";
            this.TglDO.HeaderText = "Tgl DO";
            this.TglDO.Name = "TglDO";
            this.TglDO.ReadOnly = true;
            // 
            // NoACCPusat
            // 
            this.NoACCPusat.DataPropertyName = "NoACCPusat";
            this.NoACCPusat.HeaderText = "No ACC Pusat";
            this.NoACCPusat.Name = "NoACCPusat";
            this.NoACCPusat.ReadOnly = true;
            // 
            // ACCPiutangID
            // 
            this.ACCPiutangID.DataPropertyName = "ACCPiutangID";
            this.ACCPiutangID.HeaderText = "ACC PiutangID";
            this.ACCPiutangID.Name = "ACCPiutangID";
            this.ACCPiutangID.ReadOnly = true;
            // 
            // NoACCPiutang
            // 
            this.NoACCPiutang.DataPropertyName = "NoACCPiutang";
            this.NoACCPiutang.HeaderText = "No ACC Piutang";
            this.NoACCPiutang.Name = "NoACCPiutang";
            this.NoACCPiutang.ReadOnly = true;
            // 
            // TglACCPiutang
            // 
            this.TglACCPiutang.DataPropertyName = "TglACCPiutang";
            this.TglACCPiutang.HeaderText = "TglACCPiutang";
            this.TglACCPiutang.Name = "TglACCPiutang";
            this.TglACCPiutang.ReadOnly = true;
            // 
            // StatusBatal
            // 
            this.StatusBatal.DataPropertyName = "StatusBatal";
            this.StatusBatal.HeaderText = "Status Batal";
            this.StatusBatal.Name = "StatusBatal";
            this.StatusBatal.ReadOnly = true;
            // 
            // HariKredit
            // 
            this.HariKredit.DataPropertyName = "HariKredit";
            this.HariKredit.HeaderText = "Hr Kredit";
            this.HariKredit.Name = "HariKredit";
            this.HariKredit.ReadOnly = true;
            // 
            // KodeToko
            // 
            this.KodeToko.DataPropertyName = "KodeToko";
            this.KodeToko.HeaderText = "Kd Toko";
            this.KodeToko.Name = "KodeToko";
            this.KodeToko.ReadOnly = true;
            // 
            // SalesName
            // 
            this.SalesName.DataPropertyName = "NamaSales";
            this.SalesName.HeaderText = "Nama Sales";
            this.SalesName.Name = "SalesName";
            this.SalesName.ReadOnly = true;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "KodeSales";
            this.KodeSales.HeaderText = "Kd Sales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // DiscFormula
            // 
            this.DiscFormula.DataPropertyName = "DiscFormula";
            this.DiscFormula.HeaderText = "Disc Formula";
            this.DiscFormula.Name = "DiscFormula";
            this.DiscFormula.ReadOnly = true;
            // 
            // Disc1
            // 
            this.Disc1.DataPropertyName = "Disc1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Disc1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Disc1.HeaderText = "Disc1";
            this.Disc1.Name = "Disc1";
            this.Disc1.ReadOnly = true;
            // 
            // Disc2
            // 
            this.Disc2.DataPropertyName = "Disc2";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Disc2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Disc2.HeaderText = "Disc2";
            this.Disc2.Name = "Disc2";
            this.Disc2.ReadOnly = true;
            // 
            // Disc3
            // 
            this.Disc3.DataPropertyName = "Disc3";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Disc3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Disc3.HeaderText = "Disc3";
            this.Disc3.Name = "Disc3";
            this.Disc3.ReadOnly = true;
            // 
            // Pot1
            // 
            this.Pot1.DataPropertyName = "Pot1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.Pot1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Pot1.HeaderText = "Pot 1";
            this.Pot1.Name = "Pot1";
            this.Pot1.ReadOnly = true;
            // 
            // Pot2
            // 
            this.Pot2.DataPropertyName = "Pot2";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.Pot2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Pot2.HeaderText = "Pot 2";
            this.Pot2.Name = "Pot2";
            this.Pot2.ReadOnly = true;
            // 
            // Pot3
            // 
            this.Pot3.DataPropertyName = "Pot3";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            this.Pot3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Pot3.HeaderText = "Pot 3";
            this.Pot3.Name = "Pot3";
            this.Pot3.ReadOnly = true;
            // 
            // Fee1
            // 
            this.Fee1.DataPropertyName = "Fee1";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0";
            this.Fee1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Fee1.HeaderText = "Fee 1";
            this.Fee1.Name = "Fee1";
            this.Fee1.ReadOnly = true;
            // 
            // Fee2
            // 
            this.Fee2.DataPropertyName = "Fee2";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "#,##0";
            this.Fee2.DefaultCellStyle = dataGridViewCellStyle8;
            this.Fee2.HeaderText = "Fee 2";
            this.Fee2.Name = "Fee2";
            this.Fee2.ReadOnly = true;
            // 
            // isClosed
            // 
            this.isClosed.DataPropertyName = "isClosed";
            this.isClosed.HeaderText = "isClosed";
            this.isClosed.Name = "isClosed";
            this.isClosed.ReadOnly = true;
            // 
            // Catatan1
            // 
            this.Catatan1.DataPropertyName = "Catatan1";
            this.Catatan1.HeaderText = "Catatan 1";
            this.Catatan1.Name = "Catatan1";
            this.Catatan1.ReadOnly = true;
            // 
            // Catatan2
            // 
            this.Catatan2.DataPropertyName = "Catatan2";
            this.Catatan2.HeaderText = "Catatan 2";
            this.Catatan2.Name = "Catatan2";
            this.Catatan2.ReadOnly = true;
            // 
            // Catatan3
            // 
            this.Catatan3.DataPropertyName = "Catatan3";
            this.Catatan3.HeaderText = "Catatan 3";
            this.Catatan3.Name = "Catatan3";
            this.Catatan3.ReadOnly = true;
            // 
            // Catatan4
            // 
            this.Catatan4.DataPropertyName = "Catatan4";
            this.Catatan4.HeaderText = "Catatan 4";
            this.Catatan4.Name = "Catatan4";
            this.Catatan4.ReadOnly = true;
            // 
            // Catatan5
            // 
            this.Catatan5.DataPropertyName = "Catatan5";
            this.Catatan5.HeaderText = "Catatan 5";
            this.Catatan5.Name = "Catatan5";
            this.Catatan5.ReadOnly = true;
            // 
            // NoDOBO
            // 
            this.NoDOBO.DataPropertyName = "NoDOBO";
            this.NoDOBO.HeaderText = "No DOBO";
            this.NoDOBO.Name = "NoDOBO";
            this.NoDOBO.ReadOnly = true;
            // 
            // TglReorder
            // 
            this.TglReorder.DataPropertyName = "TglReorder";
            this.TglReorder.HeaderText = "Tgl Reorder";
            this.TglReorder.Name = "TglReorder";
            this.TglReorder.ReadOnly = true;
            // 
            // StatusBO
            // 
            this.StatusBO.DataPropertyName = "StatusBO";
            this.StatusBO.HeaderText = "Status BO";
            this.StatusBO.Name = "StatusBO";
            this.StatusBO.ReadOnly = true;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "Sync Flag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            // 
            // LinkID
            // 
            this.LinkID.DataPropertyName = "LinkID";
            this.LinkID.HeaderText = "Link ID";
            this.LinkID.Name = "LinkID";
            this.LinkID.ReadOnly = true;
            // 
            // TransactionType
            // 
            this.TransactionType.DataPropertyName = "TransactionType";
            this.TransactionType.HeaderText = "Trans Type";
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.ReadOnly = true;
            // 
            // Expedisi
            // 
            this.Expedisi.DataPropertyName = "Expedisi";
            this.Expedisi.HeaderText = "Expedisi";
            this.Expedisi.Name = "Expedisi";
            this.Expedisi.ReadOnly = true;
            // 
            // HariKirim
            // 
            this.HariKirim.DataPropertyName = "HariKirim";
            this.HariKirim.HeaderText = "Hr Kirim";
            this.HariKirim.Name = "HariKirim";
            this.HariKirim.ReadOnly = true;
            // 
            // HariSales
            // 
            this.HariSales.DataPropertyName = "HariSales";
            this.HariSales.HeaderText = "Hr Sales";
            this.HariSales.Name = "HariSales";
            this.HariSales.ReadOnly = true;
            // 
            // NPrint
            // 
            this.NPrint.DataPropertyName = "NPrint";
            this.NPrint.HeaderText = "NPrint";
            this.NPrint.Name = "NPrint";
            this.NPrint.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // frmDOLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(609, 317);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDOLookUp";
            this.Text = "DO";
            this.Title = "DO";
            this.Load += new System.EventHandler(this.frmDOLookUp_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNama;
        private CommandButton cmdSearch;
        private CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HtrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACCPusat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCPiutangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACCPiutang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglACCPiutang;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusBatal;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pot1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pot2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pot3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn isClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan5;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDOBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglReorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expedisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn HariSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}
