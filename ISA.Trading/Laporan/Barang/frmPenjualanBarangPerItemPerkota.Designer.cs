namespace ISA.Trading.Laporan.Barang
{
    partial class frmPenjualanBarangPerItemPerkota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenjualanBarangPerItemPerkota));
            this.label2 = new System.Windows.Forms.Label();
            this.StockBarang = new ISA.Trading.Controls.LookupStock();
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.cmdclose = new ISA.Trading.Controls.CommandButton();
            this.rangeDateBox_barang = new ISA.Trading.Controls.RangeDateBox();
            this.comboBox_cabang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nama Stok";
            // 
            // StockBarang
            // 
            this.StockBarang.BarangID = "";
            this.StockBarang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.StockBarang.IsiKoli = 0;
            this.StockBarang.Location = new System.Drawing.Point(115, 103);
            this.StockBarang.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
            this.StockBarang.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
            this.StockBarang.NamaStock = "";
            this.StockBarang.Name = "StockBarang";
            this.StockBarang.RecordID = null;
            this.StockBarang.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.StockBarang.Satuan = null;
            this.StockBarang.Size = new System.Drawing.Size(336, 50);
            this.StockBarang.TabIndex = 1;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(119, 231);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 3;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdclose
            // 
            this.cmdclose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.Image = ((System.Drawing.Image)(resources.GetObject("cmdclose.Image")));
            this.cmdclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdclose.Location = new System.Drawing.Point(237, 231);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.ReportName = "";
            this.cmdclose.Size = new System.Drawing.Size(100, 40);
            this.cmdclose.TabIndex = 4;
            this.cmdclose.Text = "CLOSE";
            this.cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // rangeDateBox_barang
            // 
            this.rangeDateBox_barang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox_barang.FromDate = null;
            this.rangeDateBox_barang.Location = new System.Drawing.Point(80, 61);
            this.rangeDateBox_barang.Name = "rangeDateBox_barang";
            this.rangeDateBox_barang.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox_barang.TabIndex = 0;
            this.rangeDateBox_barang.ToDate = null;
            this.rangeDateBox_barang.Load += new System.EventHandler(this.rangeDateBox_barang_Load);
            // 
            // comboBox_cabang
            // 
            this.comboBox_cabang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox_cabang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_cabang.FormattingEnabled = true;
            this.comboBox_cabang.Location = new System.Drawing.Point(119, 159);
            this.comboBox_cabang.Name = "comboBox_cabang";
            this.comboBox_cabang.Size = new System.Drawing.Size(121, 22);
            this.comboBox_cabang.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "C1";
            // 
            // frmPenjualanBarangPerItemPerkota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(479, 306);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_cabang);
            this.Controls.Add(this.rangeDateBox_barang);
            this.Controls.Add(this.cmdclose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.StockBarang);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenjualanBarangPerItemPerkota";
            this.Text = "Penjualan Barang PerItem PerBulan";
            this.Title = "Penjualan Barang PerItem PerBulan";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPenjualanBarangPerItemPerkota_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.StockBarang, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdclose, 0);
            this.Controls.SetChildIndex(this.rangeDateBox_barang, 0);
            this.Controls.SetChildIndex(this.comboBox_cabang, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.LookupStock StockBarang;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdclose;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox_barang;
        private System.Windows.Forms.ComboBox comboBox_cabang;
        private System.Windows.Forms.Label label1;
    }
}
