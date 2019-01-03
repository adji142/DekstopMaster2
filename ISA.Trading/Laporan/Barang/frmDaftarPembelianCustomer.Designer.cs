namespace ISA.Trading.Laporan.Barang
{
    partial class frmDaftarPembelianCustomer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDaftarPembelianCustomer));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.cboKelompok = new System.Windows.Forms.ComboBox();
            this.rangeTglPembelian = new ISA.Trading.Controls.RangeDateBox();
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lookupToko1 = new ISA.Trading.Controls.LookupToko();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "00 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Toko ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kelompok";
            // 
            // cboCabang
            // 
            this.cboCabang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCabang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(122, 101);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(140, 22);
            this.cboCabang.TabIndex = 1;
            // 
            // cboKelompok
            // 
            this.cboKelompok.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKelompok.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKelompok.FormattingEnabled = true;
            this.cboKelompok.Location = new System.Drawing.Point(123, 212);
            this.cboKelompok.Name = "cboKelompok";
            this.cboKelompok.Size = new System.Drawing.Size(140, 22);
            this.cboKelompok.TabIndex = 3;
            // 
            // rangeTglPembelian
            // 
            this.rangeTglPembelian.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTglPembelian.FromDate = null;
            this.rangeTglPembelian.Location = new System.Drawing.Point(84, 65);
            this.rangeTglPembelian.Name = "rangeTglPembelian";
            this.rangeTglPembelian.Size = new System.Drawing.Size(257, 22);
            this.rangeTglPembelian.TabIndex = 0;
            this.rangeTglPembelian.ToDate = null;
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(427, 289);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 5;
            this.cmdNo.Text = "CLOSE";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(9, 289);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 4;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Daerah = null;
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(119, 139);
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.Propinsi = null;
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(392, 54);
            this.lookupToko1.TabIndex = 2;
            this.lookupToko1.TokoID = null;
            this.lookupToko1.WilID = "";
            this.lookupToko1.Leave += new System.EventHandler(this.lookupToko1_Leave);
            // 
            // frmDaftarPembelianCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(539, 341);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.rangeTglPembelian);
            this.Controls.Add(this.cboKelompok);
            this.Controls.Add(this.cboCabang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDaftarPembelianCustomer";
            this.Text = "Daftar Pembelian Customer";
            this.Title = "Daftar Pembelian Customer";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmDaftarPembelianCustomer_Load);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboCabang, 0);
            this.Controls.SetChildIndex(this.cboKelompok, 0);
            this.Controls.SetChildIndex(this.rangeTglPembelian, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCabang;
        private System.Windows.Forms.ComboBox cboKelompok;
        private ISA.Trading.Controls.RangeDateBox rangeTglPembelian;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Trading.Controls.LookupToko lookupToko1;
    }
}
