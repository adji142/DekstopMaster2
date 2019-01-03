namespace ISA.Toko.Penjualan
{
    partial class frmFTagihBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFTagihBrowser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rangeTagihan = new ISA.Toko.Controls.RangeDateBox();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.commandButton2 = new ISA.Toko.Controls.CommandButton();
            this.commandButton3 = new ISA.Toko.Controls.CommandButton();
            this.gvTagih = new ISA.Toko.Controls.CustomGridView();
            this.gvKodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvTglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvNoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvJenisTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvHariKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvKodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvNamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvWilID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAlamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvKota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvRpNet3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvTagih)).BeginInit();
            this.SuspendLayout();
            // 
            // rangeTagihan
            // 
            this.rangeTagihan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTagihan.FromDate = null;
            this.rangeTagihan.Location = new System.Drawing.Point(27, 69);
            this.rangeTagihan.Name = "rangeTagihan";
            this.rangeTagihan.Size = new System.Drawing.Size(257, 22);
            this.rangeTagihan.TabIndex = 0;
            this.rangeTagihan.ToDate = null;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.commandButton1.Location = new System.Drawing.Point(290, 66);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(80, 23);
            this.commandButton1.TabIndex = 1;
            this.commandButton1.Text = "Search";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Print;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(546, 363);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 2;
            this.commandButton2.Text = "PRINT";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton3
            // 
            this.commandButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton3.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton3.Image = ((System.Drawing.Image)(resources.GetObject("commandButton3.Image")));
            this.commandButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton3.Location = new System.Drawing.Point(664, 363);
            this.commandButton3.Name = "commandButton3";
            this.commandButton3.Size = new System.Drawing.Size(100, 40);
            this.commandButton3.TabIndex = 3;
            this.commandButton3.Text = "CLOSE";
            this.commandButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton3.UseVisualStyleBackColor = true;
            this.commandButton3.Click += new System.EventHandler(this.commandButton3_Click);
            // 
            // gvTagih
            // 
            this.gvTagih.AllowUserToAddRows = false;
            this.gvTagih.AllowUserToDeleteRows = false;
            this.gvTagih.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvTagih.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTagih.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvKodeToko,
            this.gvTglTerima,
            this.gvNoNota,
            this.gvJenisTransaction,
            this.gvHariKredit,
            this.gvKodeSales,
            this.gvNamaToko,
            this.gvWilID,
            this.gvAlamat,
            this.gvKota,
            this.gvRpNet3});
            this.gvTagih.Location = new System.Drawing.Point(12, 97);
            this.gvTagih.MultiSelect = false;
            this.gvTagih.Name = "gvTagih";
            this.gvTagih.ReadOnly = true;
            this.gvTagih.RowHeadersVisible = false;
            this.gvTagih.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvTagih.Size = new System.Drawing.Size(752, 257);
            this.gvTagih.StandardTab = true;
            this.gvTagih.TabIndex = 5;
            // 
            // gvKodeToko
            // 
            this.gvKodeToko.DataPropertyName = "KodeToko";
            this.gvKodeToko.HeaderText = "KODE TOKO";
            this.gvKodeToko.Name = "gvKodeToko";
            this.gvKodeToko.ReadOnly = true;
            this.gvKodeToko.Visible = false;
            // 
            // gvTglTerima
            // 
            this.gvTglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.gvTglTerima.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvTglTerima.HeaderText = "TGL.TERIMA";
            this.gvTglTerima.Name = "gvTglTerima";
            this.gvTglTerima.ReadOnly = true;
            this.gvTglTerima.Width = 80;
            // 
            // gvNoNota
            // 
            this.gvNoNota.DataPropertyName = "NoNota";
            this.gvNoNota.HeaderText = "NO.NOTA";
            this.gvNoNota.Name = "gvNoNota";
            this.gvNoNota.ReadOnly = true;
            this.gvNoNota.Width = 70;
            // 
            // gvJenisTransaction
            // 
            this.gvJenisTransaction.DataPropertyName = "TransactionType";
            this.gvJenisTransaction.HeaderText = "J.TR";
            this.gvJenisTransaction.Name = "gvJenisTransaction";
            this.gvJenisTransaction.ReadOnly = true;
            this.gvJenisTransaction.Width = 40;
            // 
            // gvHariKredit
            // 
            this.gvHariKredit.DataPropertyName = "HariKredit";
            this.gvHariKredit.HeaderText = "JKW";
            this.gvHariKredit.Name = "gvHariKredit";
            this.gvHariKredit.ReadOnly = true;
            this.gvHariKredit.Width = 40;
            // 
            // gvKodeSales
            // 
            this.gvKodeSales.DataPropertyName = "KodeSales";
            this.gvKodeSales.HeaderText = "KD.SALES";
            this.gvKodeSales.Name = "gvKodeSales";
            this.gvKodeSales.ReadOnly = true;
            // 
            // gvNamaToko
            // 
            this.gvNamaToko.DataPropertyName = "NamaToko";
            this.gvNamaToko.HeaderText = "NAMA TOKO";
            this.gvNamaToko.Name = "gvNamaToko";
            this.gvNamaToko.ReadOnly = true;
            this.gvNamaToko.Width = 200;
            // 
            // gvWilID
            // 
            this.gvWilID.DataPropertyName = "WilID";
            this.gvWilID.HeaderText = "IDWIL";
            this.gvWilID.Name = "gvWilID";
            this.gvWilID.ReadOnly = true;
            this.gvWilID.Width = 75;
            // 
            // gvAlamat
            // 
            this.gvAlamat.DataPropertyName = "AlamatKirim";
            this.gvAlamat.HeaderText = "A L A M A T";
            this.gvAlamat.Name = "gvAlamat";
            this.gvAlamat.ReadOnly = true;
            this.gvAlamat.Width = 350;
            // 
            // gvKota
            // 
            this.gvKota.DataPropertyName = "Kota";
            this.gvKota.HeaderText = "K O T A";
            this.gvKota.Name = "gvKota";
            this.gvKota.ReadOnly = true;
            this.gvKota.Width = 150;
            // 
            // gvRpNet3
            // 
            this.gvRpNet3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvRpNet3.DataPropertyName = "RpNet3";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.gvRpNet3.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvRpNet3.HeaderText = "NOMINAL NETT";
            this.gvRpNet3.Name = "gvRpNet3";
            this.gvRpNet3.ReadOnly = true;
            // 
            // frmFTagihBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(776, 412);
            this.Controls.Add(this.gvTagih);
            this.Controls.Add(this.rangeTagihan);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.commandButton3);
            this.Controls.Add(this.commandButton2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmFTagihBrowser";
            this.Text = "DATA MASTER TAGIHAN";
            this.Title = "DATA MASTER TAGIHAN";
            this.Load += new System.EventHandler(this.frmFTagihBrowser_Load);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.commandButton3, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.rangeTagihan, 0);
            this.Controls.SetChildIndex(this.gvTagih, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvTagih)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.RangeDateBox rangeTagihan;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton commandButton2;
        private ISA.Toko.Controls.CommandButton commandButton3;
        private ISA.Toko.Controls.CustomGridView gvTagih;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvKodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvTglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvNoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvJenisTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvHariKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvKodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvNamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvWilID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAlamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvKota;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvRpNet3;
    }
}
