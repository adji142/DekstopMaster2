namespace ISA.Trading.Persediaan
    {
    partial class frmRptKartuStok
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptKartuStok));
                ISA.Trading.Properties.Settings settings1 = new ISA.Trading.Properties.Settings();
                this.cmdYes = new ISA.Trading.Controls.CommandButton();
                this.cmdNo = new ISA.Trading.Controls.CommandButton();
                this.lookupStock = new ISA.Trading.Controls.LookupStock();
                this.lookupGudang = new ISA.Trading.Controls.LookupGudang();
                this.rangeDateBox = new ISA.Trading.Controls.RangeDateBox();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.rdb2 = new System.Windows.Forms.RadioButton();
                this.rdb1 = new System.Windows.Forms.RadioButton();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(12, 337);
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
                this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(404, 337);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 4;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // lookupStock
                // 
                this.lookupStock.BarangID = "";
                this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.lookupStock.IsiKoli = 0;
                this.lookupStock.Location = new System.Drawing.Point(118, 60);
                this.lookupStock.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
                this.lookupStock.NamaStock = "";
                this.lookupStock.Name = "lookupStock";
                this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
                this.lookupStock.Satuan = null;
                this.lookupStock.Size = new System.Drawing.Size(336, 50);
                this.lookupStock.TabIndex = 0;
                this.lookupStock.Leave += new System.EventHandler(this.lookupStock_Leave);
                // 
                // lookupGudang
                // 
                settings1.AppFont = new System.Drawing.Font("Courier New", 8.25F);
                settings1.DBFDownload = "C:\\Temp";
                settings1.DBFUpload = "C:\\Temp";
                settings1.Host = "JKTDEV";
                settings1.OutputFile = "C:\\Temp";
                settings1.SASdb = "C:\\Temp";
                settings1.SettingsKey = "";
                this.lookupGudang.DataBindings.Add(new System.Windows.Forms.Binding("Font", settings1, "AppFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.lookupGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.lookupGudang.GudangID = "";
                this.lookupGudang.KodeCabang = null;
                this.lookupGudang.Location = new System.Drawing.Point(118, 160);
                this.lookupGudang.NamaGudang = "";
                this.lookupGudang.Name = "lookupGudang";
                this.lookupGudang.Size = new System.Drawing.Size(382, 53);
                this.lookupGudang.TabIndex = 2;
                // 
                // rangeDateBox
                // 
                this.rangeDateBox.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.rangeDateBox.FromDate = null;
                this.rangeDateBox.Location = new System.Drawing.Point(90, 122);
                this.rangeDateBox.Name = "rangeDateBox";
                this.rangeDateBox.Size = new System.Drawing.Size(257, 22);
                this.rangeDateBox.TabIndex = 1;
                this.rangeDateBox.ToDate = null;
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.rdb2);
                this.groupBox1.Controls.Add(this.rdb1);
                this.groupBox1.Location = new System.Drawing.Point(118, 219);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(317, 33);
                this.groupBox1.TabIndex = 10;
                this.groupBox1.TabStop = false;
                // 
                // rdb2
                // 
                this.rdb2.AutoSize = true;
                this.rdb2.Location = new System.Drawing.Point(163, 9);
                this.rdb2.Name = "rdb2";
                this.rdb2.Size = new System.Drawing.Size(130, 18);
                this.rdb2.TabIndex = 1;
                this.rdb2.Text = "HPP Rata - Rata";
                this.rdb2.UseVisualStyleBackColor = true;
                // 
                // rdb1
                // 
                this.rdb1.AutoSize = true;
                this.rdb1.Checked = true;
                this.rdb1.Location = new System.Drawing.Point(24, 9);
                this.rdb1.Name = "rdb1";
                this.rdb1.Size = new System.Drawing.Size(95, 18);
                this.rdb1.TabIndex = 0;
                this.rdb1.TabStop = true;
                this.rdb1.Text = "Harga Beli";
                this.rdb1.UseVisualStyleBackColor = true;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(28, 69);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(70, 14);
                this.label1.TabIndex = 11;
                this.label1.Text = "Nama Stok";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(28, 126);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(56, 14);
                this.label2.TabIndex = 12;
                this.label2.Text = "Tanggal";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(28, 160);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(49, 14);
                this.label3.TabIndex = 13;
                this.label3.Text = "Gudang";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(28, 199);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(63, 14);
                this.label4.TabIndex = 14;
                this.label4.Text = "GudangID";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(28, 96);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(84, 14);
                this.label5.TabIndex = 15;
                this.label5.Text = "Kode Barang";
                // 
                // frmRptKartuStok
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(516, 389);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.cmdYes);
                this.Controls.Add(this.lookupGudang);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.lookupStock);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.rangeDateBox);
                this.Controls.Add(this.groupBox1);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptKartuStok";
                this.Text = "Laporan Kartu Stok";
                this.Title = "Laporan Kartu Stok";
                this.Load += new System.EventHandler(this.frmRptKartuStok_Load);
                this.Controls.SetChildIndex(this.groupBox1, 0);
                this.Controls.SetChildIndex(this.rangeDateBox, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.lookupStock, 0);
                this.Controls.SetChildIndex(this.label4, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.lookupGudang, 0);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.label3, 0);
                this.Controls.SetChildIndex(this.label5, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.LookupStock lookupStock;
        private ISA.Trading.Controls.LookupGudang lookupGudang;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        }
    }
