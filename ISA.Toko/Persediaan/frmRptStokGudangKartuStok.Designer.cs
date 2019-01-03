namespace ISA.Toko.Persediaan
    {
    partial class frmRptStokGudangKartuStok
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing&&(components!=null))
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptStokGudangKartuStok));
                ISA.Toko.Properties.Settings settings2 = new ISA.Toko.Properties.Settings();
                this.cmdYes = new ISA.Toko.Controls.CommandButton();
                this.cmdNo = new ISA.Toko.Controls.CommandButton();
                this.lookupGudang = new ISA.Toko.Controls.LookupGudang();
                this.lookupStock = new ISA.Toko.Controls.LookupStock();
                this.rangeDateBox = new ISA.Toko.Controls.RangeDateBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(9, 395);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 3;
                this.cmdYes.Text = "YES";
                this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdYes.UseVisualStyleBackColor = true;
                this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(452, 395);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 4;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // lookupGudang
                // 
                settings2.AppFont = new System.Drawing.Font("Courier New", 8.25F);
                settings2.DBFDownload = "C:\\Temp";
                settings2.DBFinance = "ISAFinance";
                settings2.DBFUpload = "C:\\Temp";
                settings2.Host = "JKTDEV";
                settings2.OutputFile = "C:\\Temp";
                settings2.SASdb = "C:\\Temp";
                settings2.SettingsKey = "";
                this.lookupGudang.DataBindings.Add(new System.Windows.Forms.Binding("Font", settings2, "AppFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.lookupGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.lookupGudang.GudangID = "";
                this.lookupGudang.KodeCabang = null;
                this.lookupGudang.Location = new System.Drawing.Point(120, 176);
                this.lookupGudang.NamaGudang = "";
                this.lookupGudang.Name = "lookupGudang";
                this.lookupGudang.Size = new System.Drawing.Size(417, 54);
                this.lookupGudang.TabIndex = 2;
                // 
                // lookupStock
                // 
                this.lookupStock.BarangID = "";
                this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.lookupStock.IsiKoli = 0;
                this.lookupStock.Location = new System.Drawing.Point(120, 64);
                this.lookupStock.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
                this.lookupStock.LPasif = ISA.Toko.Controls.LookupStock.EnumPasif.All;
                this.lookupStock.NamaStock = "";
                this.lookupStock.Name = "lookupStock";
                this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
                this.lookupStock.Satuan = null;
                this.lookupStock.Size = new System.Drawing.Size(336, 50);
                this.lookupStock.TabIndex = 0;
                // 
                // rangeDateBox
                // 
                this.rangeDateBox.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.rangeDateBox.FromDate = null;
                this.rangeDateBox.Location = new System.Drawing.Point(87, 130);
                this.rangeDateBox.Name = "rangeDateBox";
                this.rangeDateBox.Size = new System.Drawing.Size(257, 22);
                this.rangeDateBox.TabIndex = 1;
                this.rangeDateBox.ToDate = null;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(27, 68);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(65, 14);
                this.label1.TabIndex = 10;
                this.label1.Text = "Nama Stok";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(27, 100);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(76, 14);
                this.label2.TabIndex = 11;
                this.label2.Text = "Kode Barang";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(28, 130);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(50, 14);
                this.label3.TabIndex = 12;
                this.label3.Text = "Tanggal";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(27, 176);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(49, 14);
                this.label4.TabIndex = 13;
                this.label4.Text = "Gudang";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(31, 216);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(80, 14);
                this.label5.TabIndex = 14;
                this.label5.Text = "Kode Gudang";
                // 
                // frmRptStokGudangKartuStok
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(564, 447);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.rangeDateBox);
                this.Controls.Add(this.lookupStock);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.cmdYes);
                this.Controls.Add(this.lookupGudang);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptStokGudangKartuStok";
                this.Text = "Laporan Kartu Stok";
                this.Title = "Laporan Kartu Stok";
                this.Load += new System.EventHandler(this.frmStokGudangKartuStok_Load);
                this.Controls.SetChildIndex(this.lookupGudang, 0);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.lookupStock, 0);
                this.Controls.SetChildIndex(this.rangeDateBox, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.label3, 0);
                this.Controls.SetChildIndex(this.label4, 0);
                this.Controls.SetChildIndex(this.label5, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.LookupGudang lookupGudang;
        private ISA.Toko.Controls.LookupStock lookupStock;
        private ISA.Toko.Controls.RangeDateBox rangeDateBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        }
    }
