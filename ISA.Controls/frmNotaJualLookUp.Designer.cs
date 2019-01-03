namespace ISA.Controls
{
    partial class frmNotaJualLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaJualLookUp));
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NotaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HtrID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checker1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checker2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(521, 265);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 26;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nomor Nota";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(96, 61);
            this.txtNama.MaxLength = 73;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(220, 20);
            this.txtNama.TabIndex = 24;
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
            this.cmdSearch.TabIndex = 25;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
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
            this.NotaID,
            this.DOID,
            this.NoDO,
            this.NoNota,
            this.TglNota,
            this.NamaToko,
            this.AlamatKirim,
            this.KodeSales,
            this.NamaSales,
            this.HtrID,
            this.RecordID,
            this.NoSJ,
            this.TglSJ,
            this.TglTerima,
            this.Kota,
            this.isClosed,
            this.Catatan1,
            this.Catatan2,
            this.Catatan3,
            this.Catatan4,
            this.Catatan5,
            this.SyncFlag,
            this.LinkID,
            this.NPrint,
            this.Checker1,
            this.Checker2,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridView1.Location = new System.Drawing.Point(0, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(633, 172);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // NotaID
            // 
            this.NotaID.DataPropertyName = "RowID";
            this.NotaID.HeaderText = "Nota ID";
            this.NotaID.Name = "NotaID";
            this.NotaID.ReadOnly = true;
            this.NotaID.Visible = false;
            // 
            // DOID
            // 
            this.DOID.DataPropertyName = "DOID";
            this.DOID.HeaderText = "DO ID";
            this.DOID.Name = "DOID";
            this.DOID.ReadOnly = true;
            this.DOID.Visible = false;
            // 
            // NoDO
            // 
            this.NoDO.DataPropertyName = "NoDO";
            this.NoDO.HeaderText = "No DO";
            this.NoDO.Name = "NoDO";
            this.NoDO.ReadOnly = true;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "No Nota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglNota";
            this.TglNota.HeaderText = "Tgl Nota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 250;
            // 
            // AlamatKirim
            // 
            this.AlamatKirim.DataPropertyName = "AlamatKirim";
            this.AlamatKirim.HeaderText = "Alamat Kirim";
            this.AlamatKirim.Name = "AlamatKirim";
            this.AlamatKirim.ReadOnly = true;
            this.AlamatKirim.Width = 300;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "KodeSales";
            this.KodeSales.HeaderText = "Kode Sales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            this.KodeSales.Visible = false;
            // 
            // NamaSales
            // 
            this.NamaSales.DataPropertyName = "NamaSales";
            this.NamaSales.HeaderText = "Nama Sales";
            this.NamaSales.Name = "NamaSales";
            this.NamaSales.ReadOnly = true;
            this.NamaSales.Visible = false;
            // 
            // HtrID
            // 
            this.HtrID.DataPropertyName = "HtrID";
            this.HtrID.HeaderText = "Htr ID";
            this.HtrID.Name = "HtrID";
            this.HtrID.ReadOnly = true;
            this.HtrID.Visible = false;
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "RecordID";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            this.RecordID.Visible = false;
            // 
            // NoSJ
            // 
            this.NoSJ.DataPropertyName = "NoSuratJalan";
            this.NoSJ.HeaderText = "No SJ";
            this.NoSJ.Name = "NoSJ";
            this.NoSJ.ReadOnly = true;
            this.NoSJ.Visible = false;
            // 
            // TglSJ
            // 
            this.TglSJ.DataPropertyName = "TglSuratJalan";
            this.TglSJ.HeaderText = "Tgl SJ";
            this.TglSJ.Name = "TglSJ";
            this.TglSJ.ReadOnly = true;
            this.TglSJ.Visible = false;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            this.TglTerima.HeaderText = "Tgl Terima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            this.TglTerima.Visible = false;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            this.Kota.Visible = false;
            // 
            // isClosed
            // 
            this.isClosed.DataPropertyName = "isClosed";
            this.isClosed.HeaderText = "isClosed";
            this.isClosed.Name = "isClosed";
            this.isClosed.ReadOnly = true;
            this.isClosed.Visible = false;
            // 
            // Catatan1
            // 
            this.Catatan1.DataPropertyName = "Catatan1";
            this.Catatan1.HeaderText = "Catatan1";
            this.Catatan1.Name = "Catatan1";
            this.Catatan1.ReadOnly = true;
            this.Catatan1.Visible = false;
            // 
            // Catatan2
            // 
            this.Catatan2.DataPropertyName = "Catatan2";
            this.Catatan2.HeaderText = "Catatan2";
            this.Catatan2.Name = "Catatan2";
            this.Catatan2.ReadOnly = true;
            this.Catatan2.Visible = false;
            // 
            // Catatan3
            // 
            this.Catatan3.DataPropertyName = "Catatan3";
            this.Catatan3.HeaderText = "Catatan3";
            this.Catatan3.Name = "Catatan3";
            this.Catatan3.ReadOnly = true;
            this.Catatan3.Visible = false;
            // 
            // Catatan4
            // 
            this.Catatan4.DataPropertyName = "Catatan4";
            this.Catatan4.HeaderText = "Catatan4";
            this.Catatan4.Name = "Catatan4";
            this.Catatan4.ReadOnly = true;
            this.Catatan4.Visible = false;
            // 
            // Catatan5
            // 
            this.Catatan5.DataPropertyName = "Catatan5";
            this.Catatan5.HeaderText = "Catatan5";
            this.Catatan5.Name = "Catatan5";
            this.Catatan5.ReadOnly = true;
            this.Catatan5.Visible = false;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "Sync Flag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // LinkID
            // 
            this.LinkID.DataPropertyName = "LinkID";
            this.LinkID.HeaderText = "Link ID";
            this.LinkID.Name = "LinkID";
            this.LinkID.ReadOnly = true;
            this.LinkID.Visible = false;
            // 
            // NPrint
            // 
            this.NPrint.DataPropertyName = "NPrint";
            this.NPrint.HeaderText = "NPrint";
            this.NPrint.Name = "NPrint";
            this.NPrint.ReadOnly = true;
            this.NPrint.Visible = false;
            // 
            // Checker1
            // 
            this.Checker1.DataPropertyName = "Checker1";
            this.Checker1.HeaderText = "Checker1";
            this.Checker1.Name = "Checker1";
            this.Checker1.ReadOnly = true;
            this.Checker1.Visible = false;
            // 
            // Checker2
            // 
            this.Checker2.DataPropertyName = "Checker2";
            this.Checker2.HeaderText = "Checker2";
            this.Checker2.Name = "Checker2";
            this.Checker2.ReadOnly = true;
            this.Checker2.Visible = false;
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
            // frmNotaJualLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(631, 317);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNotaJualLookUp";
            this.Text = " - Nota Penjualan";
            this.Title = "Nota Penjualan";
            this.Load += new System.EventHandler(this.frmNotaJualLookUp_Load);
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

        private CommandButton cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNama;
        private CommandButton cmdSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn HtrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn isClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan5;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Checker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Checker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}
