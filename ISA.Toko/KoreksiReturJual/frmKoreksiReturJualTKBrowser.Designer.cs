namespace ISA.Toko.KoreksiReturJual
{
    partial class frmKoreksiReturJualTKBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKoreksiReturJualTKBrowser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rgbTglNotaRetur = new ISA.Toko.Controls.RangeDateBox();
            this.customGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.btnCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.TglNotaRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNotaRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NilaiRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tgl. Retur:";
            // 
            // rgbTglNotaRetur
            // 
            this.rgbTglNotaRetur.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglNotaRetur.FromDate = null;
            this.rgbTglNotaRetur.Location = new System.Drawing.Point(110, 67);
            this.rgbTglNotaRetur.Name = "rgbTglNotaRetur";
            this.rgbTglNotaRetur.Size = new System.Drawing.Size(257, 22);
            this.rgbTglNotaRetur.TabIndex = 6;
            this.rgbTglNotaRetur.ToDate = null;
            this.rgbTglNotaRetur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTglNotaRetur_KeyPress);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BackgroundColor = System.Drawing.Color.White;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglNotaRetur,
            this.NoNotaRetur,
            this.TglGudang,
            this.NamaToko,
            this.AlamatKirim,
            this.Kota,
            this.NilaiRetur,
            this.Penerima,
            this.TK,
            this.RowID,
            this.ReturID});
            this.customGridView1.Location = new System.Drawing.Point(9, 95);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(693, 221);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 7;
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // btnCLOSE
            // 
            this.btnCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.btnCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("btnCLOSE.Image")));
            this.btnCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLOSE.Location = new System.Drawing.Point(598, 328);
            this.btnCLOSE.Name = "btnCLOSE";
            this.btnCLOSE.Size = new System.Drawing.Size(100, 40);
            this.btnCLOSE.TabIndex = 8;
            this.btnCLOSE.Text = "CLOSE";
            this.btnCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCLOSE.UseVisualStyleBackColor = true;
            this.btnCLOSE.Click += new System.EventHandler(this.btnCLOSE_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(351, 66);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 9;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // TglNotaRetur
            // 
            this.TglNotaRetur.DataPropertyName = "TglNotaRetur";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.TglNotaRetur.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglNotaRetur.HeaderText = "Tgl.Retur";
            this.TglNotaRetur.Name = "TglNotaRetur";
            // 
            // NoNotaRetur
            // 
            this.NoNotaRetur.DataPropertyName = "NoNotaRetur";
            this.NoNotaRetur.HeaderText = "No.Retur";
            this.NoNotaRetur.Name = "NoNotaRetur";
            // 
            // TglGudang
            // 
            this.TglGudang.DataPropertyName = "TglGudang";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.TglGudang.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglGudang.HeaderText = "Tgl.Msk.Gdg";
            this.TglGudang.Name = "TglGudang";
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.Width = 250;
            // 
            // AlamatKirim
            // 
            this.AlamatKirim.DataPropertyName = "AlamatKirim";
            this.AlamatKirim.HeaderText = "Alamat Kirim";
            this.AlamatKirim.Name = "AlamatKirim";
            this.AlamatKirim.ReadOnly = true;
            this.AlamatKirim.Width = 350;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // NilaiRetur
            // 
            this.NilaiRetur.DataPropertyName = "NilaiRetur";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.NilaiRetur.DefaultCellStyle = dataGridViewCellStyle3;
            this.NilaiRetur.HeaderText = "Nilai Ret";
            this.NilaiRetur.Name = "NilaiRetur";
            this.NilaiRetur.ReadOnly = true;
            // 
            // Penerima
            // 
            this.Penerima.DataPropertyName = "Penerima";
            this.Penerima.HeaderText = "Penerima Barang";
            this.Penerima.Name = "Penerima";
            this.Penerima.ReadOnly = true;
            this.Penerima.Width = 150;
            // 
            // TK
            // 
            this.TK.DataPropertyName = "TK";
            this.TK.HeaderText = "T/K";
            this.TK.Name = "TK";
            this.TK.ReadOnly = true;
            this.TK.Width = 50;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // ReturID
            // 
            this.ReturID.DataPropertyName = "ReturID";
            this.ReturID.HeaderText = "ReturID";
            this.ReturID.Name = "ReturID";
            this.ReturID.ReadOnly = true;
            this.ReturID.Visible = false;
            // 
            // frmKoreksiReturJualTKBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 380);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.btnCLOSE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgbTglNotaRetur);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKoreksiReturJualTKBrowser";
            this.Load += new System.EventHandler(this.frmKoreksiReturJualTKBrowser_Load);
            this.Controls.SetChildIndex(this.rgbTglNotaRetur, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnCLOSE, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rgbTglNotaRetur;
        private ISA.Toko.Controls.CustomGridView customGridView1;
        private ISA.Toko.Controls.CommandButton btnCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNotaRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNotaRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NilaiRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn TK;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturID;
    }
}
