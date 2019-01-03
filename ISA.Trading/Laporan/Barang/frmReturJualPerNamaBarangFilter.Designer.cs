namespace ISA.Trading.Laporan.Barang
{
    partial class frmReturJualPerNamaBarangFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturJualPerNamaBarangFilter));
            this.RngTextBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.cmbCabang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lkpGudang = new ISA.Trading.Controls.LookupGudang();
            this.label2 = new System.Windows.Forms.Label();
            this.lkpsales = new ISA.Trading.Controls.LookupSales();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbJenisRetur = new System.Windows.Forms.ComboBox();
            this.cmdcancel = new ISA.Trading.Controls.CommandButton();
            this.rbMPR = new System.Windows.Forms.RadioButton();
            this.rbTglNota = new System.Windows.Forms.RadioButton();
            this.cmdPrint = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // RngTextBox1
            // 
            this.RngTextBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.RngTextBox1.FromDate = null;
            this.RngTextBox1.Location = new System.Drawing.Point(62, 61);
            this.RngTextBox1.Name = "RngTextBox1";
            this.RngTextBox1.Size = new System.Drawing.Size(257, 22);
            this.RngTextBox1.TabIndex = 0;
            this.RngTextBox1.ToDate = null;
            // 
            // cmbCabang
            // 
            this.cmbCabang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCabang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCabang.FormattingEnabled = true;
            this.cmbCabang.Location = new System.Drawing.Point(99, 115);
            this.cmbCabang.Name = "cmbCabang";
            this.cmbCabang.Size = new System.Drawing.Size(235, 22);
            this.cmbCabang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cabang";
            // 
            // lkpGudang
            // 
            this.lkpGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lkpGudang.GudangID = "";
            this.lkpGudang.InitPerusahaan = null;
            this.lkpGudang.KodeCabang = null;
            this.lkpGudang.Location = new System.Drawing.Point(95, 144);
            this.lkpGudang.NamaGudang = "";
            this.lkpGudang.Name = "lkpGudang";
            this.lkpGudang.Size = new System.Drawing.Size(276, 54);
            this.lkpGudang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gudang";
            // 
            // lkpsales
            // 
            this.lkpsales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lkpsales.Location = new System.Drawing.Point(95, 205);
            this.lkpsales.NamaSales = "";
            this.lkpsales.Name = "lkpsales";
            this.lkpsales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkpsales.SalesID = "";
            this.lkpsales.Size = new System.Drawing.Size(276, 54);
            this.lkpsales.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Salesman";
            // 
            // cmbKategori
            // 
            this.cmbKategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(99, 266);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(235, 22);
            this.cmbKategori.TabIndex = 4;
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Location = new System.Drawing.Point(33, 269);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(53, 14);
            this.lblKategori.TabIndex = 13;
            this.lblKategori.Text = "Kategori";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Jenis Retur";
            // 
            // cmbJenisRetur
            // 
            this.cmbJenisRetur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbJenisRetur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJenisRetur.FormattingEnabled = true;
            this.cmbJenisRetur.Location = new System.Drawing.Point(99, 310);
            this.cmbJenisRetur.Name = "cmbJenisRetur";
            this.cmbJenisRetur.Size = new System.Drawing.Size(235, 22);
            this.cmbJenisRetur.TabIndex = 5;
            // 
            // cmdcancel
            // 
            this.cmdcancel.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdcancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdcancel.Image")));
            this.cmdcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdcancel.Location = new System.Drawing.Point(271, 352);
            this.cmdcancel.Name = "cmdcancel";
            this.cmdcancel.ReportName = "";
            this.cmdcancel.Size = new System.Drawing.Size(100, 40);
            this.cmdcancel.TabIndex = 7;
            this.cmdcancel.Text = "CANCEL";
            this.cmdcancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdcancel.UseVisualStyleBackColor = true;
            this.cmdcancel.Click += new System.EventHandler(this.cmdcancel_Click);
            // 
            // rbMPR
            // 
            this.rbMPR.AutoSize = true;
            this.rbMPR.Checked = true;
            this.rbMPR.Location = new System.Drawing.Point(99, 90);
            this.rbMPR.Name = "rbMPR";
            this.rbMPR.Size = new System.Drawing.Size(94, 18);
            this.rbMPR.TabIndex = 15;
            this.rbMPR.TabStop = true;
            this.rbMPR.Text = "Tanggal MPR";
            this.rbMPR.UseVisualStyleBackColor = true;
            // 
            // rbTglNota
            // 
            this.rbTglNota.AutoSize = true;
            this.rbTglNota.Location = new System.Drawing.Point(210, 90);
            this.rbTglNota.Name = "rbTglNota";
            this.rbTglNota.Size = new System.Drawing.Size(127, 18);
            this.rbTglNota.TabIndex = 16;
            this.rbTglNota.Text = "Tanggal Nota Retur";
            this.rbTglNota.UseVisualStyleBackColor = true;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(98, 353);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.ReportName = "";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 17;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // frmReturJualPerNamaBarangFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(443, 426);
            this.Controls.Add(this.rbTglNota);
            this.Controls.Add(this.rbMPR);
            this.Controls.Add(this.cmdcancel);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmbJenisRetur);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblKategori);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lkpsales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lkpGudang);
            this.Controls.Add(this.cmbCabang);
            this.Controls.Add(this.RngTextBox1);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmReturJualPerNamaBarangFilter";
            this.Text = "Retur Jual Per Nama Barang";
            this.Title = "Retur Jual Per Nama Barang";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmReturJualPerNamaBarangFilter_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.RngTextBox1, 0);
            this.Controls.SetChildIndex(this.cmbCabang, 0);
            this.Controls.SetChildIndex(this.lkpGudang, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lkpsales, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbKategori, 0);
            this.Controls.SetChildIndex(this.lblKategori, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbJenisRetur, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdcancel, 0);
            this.Controls.SetChildIndex(this.rbMPR, 0);
            this.Controls.SetChildIndex(this.rbTglNota, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox RngTextBox1;
        private System.Windows.Forms.ComboBox cmbCabang;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.LookupGudang lkpGudang;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.LookupSales lkpsales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbJenisRetur;
        private ISA.Trading.Controls.CommandButton cmdcancel;
        private System.Windows.Forms.RadioButton rbMPR;
        public System.Windows.Forms.RadioButton rbTglNota;
        private ISA.Trading.Controls.CommandButton cmdPrint;
    }
}
