namespace ISA.Trading.Persediaan
    {
    partial class frmRptGudangPosisiStok
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptGudangPosisiStok));
                ISA.Trading.Properties.Settings settings1 = new ISA.Trading.Properties.Settings();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.rdbB3 = new System.Windows.Forms.RadioButton();
                this.rdbB2 = new System.Windows.Forms.RadioButton();
                this.rdbB1 = new System.Windows.Forms.RadioButton();
                this.groupBox3 = new System.Windows.Forms.GroupBox();
                this.rdbA2 = new System.Windows.Forms.RadioButton();
                this.rdbA1 = new System.Windows.Forms.RadioButton();
                this.cmdYes = new ISA.Trading.Controls.CommandButton();
                this.cmdNo = new ISA.Trading.Controls.CommandButton();
                this.groupBox4 = new System.Windows.Forms.GroupBox();
                this.rdbD2 = new System.Windows.Forms.RadioButton();
                this.rdbD1 = new System.Windows.Forms.RadioButton();
                this.lookupGudang1 = new ISA.Trading.Controls.LookupGudang();
                this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
                this.cboKel = new System.Windows.Forms.ComboBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.label6 = new System.Windows.Forms.Label();
                this.lookupStock = new ISA.Trading.Controls.LookupStock();
                this.cboPen = new System.Windows.Forms.ComboBox();
                this.label7 = new System.Windows.Forms.Label();
                this.txtNama = new ISA.Controls.CommonTextBox();
                this.groupBox2.SuspendLayout();
                this.groupBox3.SuspendLayout();
                this.groupBox4.SuspendLayout();
                this.SuspendLayout();
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.rdbB3);
                this.groupBox2.Controls.Add(this.rdbB2);
                this.groupBox2.Controls.Add(this.rdbB1);
                this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.groupBox2.Location = new System.Drawing.Point(31, 115);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(259, 42);
                this.groupBox2.TabIndex = 0;
                this.groupBox2.TabStop = false;
                // 
                // rdbB3
                // 
                this.rdbB3.AutoSize = true;
                this.rdbB3.Location = new System.Drawing.Point(159, 18);
                this.rdbB3.Name = "rdbB3";
                this.rdbB3.Size = new System.Drawing.Size(52, 18);
                this.rdbB3.TabIndex = 2;
                this.rdbB3.TabStop = true;
                this.rdbB3.Text = "Pasif";
                this.rdbB3.UseVisualStyleBackColor = true;
                // 
                // rdbB2
                // 
                this.rdbB2.AutoSize = true;
                this.rdbB2.Location = new System.Drawing.Point(73, 19);
                this.rdbB2.Name = "rdbB2";
                this.rdbB2.Size = new System.Drawing.Size(51, 18);
                this.rdbB2.TabIndex = 1;
                this.rdbB2.TabStop = true;
                this.rdbB2.Text = "Aktif";
                this.rdbB2.UseVisualStyleBackColor = true;
                // 
                // rdbB1
                // 
                this.rdbB1.AutoSize = true;
                this.rdbB1.Location = new System.Drawing.Point(7, 19);
                this.rdbB1.Name = "rdbB1";
                this.rdbB1.Size = new System.Drawing.Size(63, 18);
                this.rdbB1.TabIndex = 0;
                this.rdbB1.TabStop = true;
                this.rdbB1.Text = "Semua";
                this.rdbB1.UseVisualStyleBackColor = true;
                // 
                // groupBox3
                // 
                this.groupBox3.Controls.Add(this.rdbA2);
                this.groupBox3.Controls.Add(this.rdbA1);
                this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.groupBox3.Location = new System.Drawing.Point(31, 69);
                this.groupBox3.Name = "groupBox3";
                this.groupBox3.Size = new System.Drawing.Size(205, 42);
                this.groupBox3.TabIndex = 6;
                this.groupBox3.TabStop = false;
                // 
                // rdbA2
                // 
                this.rdbA2.AutoSize = true;
                this.rdbA2.Location = new System.Drawing.Point(73, 18);
                this.rdbA2.Name = "rdbA2";
                this.rdbA2.Size = new System.Drawing.Size(67, 18);
                this.rdbA2.TabIndex = 1;
                this.rdbA2.TabStop = true;
                this.rdbA2.Text = "Contain";
                this.rdbA2.UseVisualStyleBackColor = true;
                this.rdbA2.CheckedChanged += new System.EventHandler(this.rdbA2_CheckedChanged);
                // 
                // rdbA1
                // 
                this.rdbA1.AutoSize = true;
                this.rdbA1.Location = new System.Drawing.Point(6, 18);
                this.rdbA1.Name = "rdbA1";
                this.rdbA1.Size = new System.Drawing.Size(54, 18);
                this.rdbA1.TabIndex = 0;
                this.rdbA1.TabStop = true;
                this.rdbA1.Text = "Fixed";
                this.rdbA1.UseVisualStyleBackColor = true;
                this.rdbA1.CheckedChanged += new System.EventHandler(this.rdbA1_CheckedChanged);
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(12, 529);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.ReportName = "";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 5;
                this.cmdYes.Text = "PRINT";
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
                this.cmdNo.Location = new System.Drawing.Point(633, 529);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.ReportName = "";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 6;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // groupBox4
                // 
                this.groupBox4.Controls.Add(this.rdbD2);
                this.groupBox4.Controls.Add(this.rdbD1);
                this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.groupBox4.Location = new System.Drawing.Point(31, 162);
                this.groupBox4.Name = "groupBox4";
                this.groupBox4.Size = new System.Drawing.Size(200, 42);
                this.groupBox4.TabIndex = 9;
                this.groupBox4.TabStop = false;
                // 
                // rdbD2
                // 
                this.rdbD2.AutoSize = true;
                this.rdbD2.Location = new System.Drawing.Point(73, 18);
                this.rdbD2.Name = "rdbD2";
                this.rdbD2.Size = new System.Drawing.Size(59, 18);
                this.rdbD2.TabIndex = 1;
                this.rdbD2.TabStop = true;
                this.rdbD2.Text = "Minus";
                this.rdbD2.UseVisualStyleBackColor = true;
                // 
                // rdbD1
                // 
                this.rdbD1.AutoSize = true;
                this.rdbD1.Location = new System.Drawing.Point(6, 19);
                this.rdbD1.Name = "rdbD1";
                this.rdbD1.Size = new System.Drawing.Size(63, 18);
                this.rdbD1.TabIndex = 0;
                this.rdbD1.TabStop = true;
                this.rdbD1.Text = "Semua";
                this.rdbD1.UseVisualStyleBackColor = true;
                // 
                // lookupGudang1
                // 
                settings1.AppFont = new System.Drawing.Font("Courier New", 8.25F);
                settings1.DBFDownload = "C:\\Temp";
                settings1.DBFinance = "ISAFinance";
                settings1.DBFUpload = "C:\\Temp";
                settings1.Host = "JKTDEV";
                //settings1.ISADBDepoNonRetailConnectionString = resources.GetString("settings1.ISADBDepoNonRetailConnectionString");
                settings1.OutputFile = "C:\\Temp";
                settings1.SASdb = "C:\\Temp";
                settings1.SettingsKey = "";
                this.lookupGudang1.DataBindings.Add(new System.Windows.Forms.Binding("Font", settings1, "AppFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.lookupGudang1.GudangID = "";
                this.lookupGudang1.InitPerusahaan = null;
                this.lookupGudang1.KodeCabang = null;
                this.lookupGudang1.Location = new System.Drawing.Point(143, 331);
                this.lookupGudang1.NamaGudang = "";
                this.lookupGudang1.Name = "lookupGudang1";
                this.lookupGudang1.Size = new System.Drawing.Size(324, 54);
                this.lookupGudang1.TabIndex = 2;
                this.lookupGudang1.Leave += new System.EventHandler(this.lookupGudang1_Leave);
                // 
                // rangeDateBox1
                // 
                this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.rangeDateBox1.FromDate = null;
                this.rangeDateBox1.Location = new System.Drawing.Point(108, 427);
                this.rangeDateBox1.Name = "rangeDateBox1";
                this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
                this.rangeDateBox1.TabIndex = 4;
                this.rangeDateBox1.ToDate = null;
                // 
                // cboKel
                // 
                this.cboKel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.cboKel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
                this.cboKel.Location = new System.Drawing.Point(146, 296);
                this.cboKel.Name = "cboKel";
                this.cboKel.Size = new System.Drawing.Size(121, 22);
                this.cboKel.TabIndex = 1;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(28, 262);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(76, 14);
                this.label1.TabIndex = 13;
                this.label1.Text = "Kode Barang";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(28, 338);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(81, 14);
                this.label2.TabIndex = 14;
                this.label2.Text = "Nama gudang";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(28, 304);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(63, 14);
                this.label3.TabIndex = 15;
                this.label3.Text = "Kelompok";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(28, 427);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(49, 14);
                this.label4.TabIndex = 16;
                this.label4.Text = "Tanggal";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(28, 224);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(65, 14);
                this.label5.TabIndex = 17;
                this.label5.Text = "Nama Stok";
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(28, 371);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(80, 14);
                this.label6.TabIndex = 18;
                this.label6.Text = "Kode Gudang";
                // 
                // lookupStock
                // 
                this.lookupStock.BarangID = "";
                this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.lookupStock.IsiKoli = 0;
                this.lookupStock.Location = new System.Drawing.Point(143, 226);
                this.lookupStock.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
                this.lookupStock.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
                this.lookupStock.NamaStock = "";
                this.lookupStock.Name = "lookupStock";
                this.lookupStock.RecordID = null;
                this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
                this.lookupStock.Satuan = null;
                this.lookupStock.Size = new System.Drawing.Size(336, 50);
                this.lookupStock.TabIndex = 0;
                this.lookupStock.Leave += new System.EventHandler(this.lookupStock_Leave);
                // 
                // cboPen
                // 
                this.cboPen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.cboPen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
                this.cboPen.FormattingEnabled = true;
                this.cboPen.Location = new System.Drawing.Point(146, 396);
                this.cboPen.Name = "cboPen";
                this.cboPen.Size = new System.Drawing.Size(121, 22);
                this.cboPen.TabIndex = 3;
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Location = new System.Drawing.Point(28, 399);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(99, 14);
                this.label7.TabIndex = 21;
                this.label7.Text = "Peng. Jawab Rak";
                // 
                // txtNama
                // 
                this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtNama.Location = new System.Drawing.Point(143, 224);
                this.txtNama.Name = "txtNama";
                this.txtNama.Size = new System.Drawing.Size(292, 20);
                this.txtNama.TabIndex = 22;
                // 
                // frmRptGudangPosisiStok
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(745, 581);
                this.Controls.Add(this.txtNama);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.cboPen);
                this.Controls.Add(this.lookupStock);
                this.Controls.Add(this.label6);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.cboKel);
                this.Controls.Add(this.rangeDateBox1);
                this.Controls.Add(this.groupBox4);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.groupBox3);
                this.Controls.Add(this.lookupGudang1);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.cmdYes);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptGudangPosisiStok";
                this.Text = "Laporan Posisi Stok";
                this.Title = "Laporan Posisi Stok";
                this.Load += new System.EventHandler(this.frmRptGudangPosisiStok_Load);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.groupBox2, 0);
                this.Controls.SetChildIndex(this.lookupGudang1, 0);
                this.Controls.SetChildIndex(this.groupBox3, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.groupBox4, 0);
                this.Controls.SetChildIndex(this.rangeDateBox1, 0);
                this.Controls.SetChildIndex(this.cboKel, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.label3, 0);
                this.Controls.SetChildIndex(this.label4, 0);
                this.Controls.SetChildIndex(this.label5, 0);
                this.Controls.SetChildIndex(this.label6, 0);
                this.Controls.SetChildIndex(this.lookupStock, 0);
                this.Controls.SetChildIndex(this.cboPen, 0);
                this.Controls.SetChildIndex(this.label7, 0);
                this.Controls.SetChildIndex(this.txtNama, 0);
                this.groupBox2.ResumeLayout(false);
                this.groupBox2.PerformLayout();
                this.groupBox3.ResumeLayout(false);
                this.groupBox3.PerformLayout();
                this.groupBox4.ResumeLayout(false);
                this.groupBox4.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private System.Windows.Forms.RadioButton rdbB3;
        private System.Windows.Forms.RadioButton rdbB2;
        private System.Windows.Forms.RadioButton rdbB1;
        private System.Windows.Forms.RadioButton rdbA2;
        private System.Windows.Forms.RadioButton rdbA1;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbD2;
        private System.Windows.Forms.RadioButton rdbD1;
        private ISA.Trading.Controls.LookupGudang lookupGudang1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.ComboBox cboKel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ISA.Trading.Controls.LookupStock lookupStock;
        private System.Windows.Forms.ComboBox cboPen;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.CommonTextBox txtNama;
        }
    }
