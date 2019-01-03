namespace ISA.Trading.RJ3
{
    partial class frmRptRekapReturJualDanPenyelesainya
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRekapReturJualDanPenyelesainya));
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lookupSales = new ISA.Trading.Controls.LookupSales();
            this.cboKategori = new System.Windows.Forms.ComboBox();
            this.cboCabang1 = new ISA.Trading.Controls.CabangComboBox();
            this.cboCabang2 = new ISA.Trading.Controls.CabangComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbTglNota = new System.Windows.Forms.RadioButton();
            this.rdbTglRq = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdPrint = new ISA.Trading.Controls.CommandButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(362, 392);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 7;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(133, 79);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tgl. Rq Retur";
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(166, 110);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "";
            this.lookupSales.Size = new System.Drawing.Size(276, 54);
            this.lookupSales.TabIndex = 1;
            this.lookupSales.Leave += new System.EventHandler(this.lookupSales_Leave);
            // 
            // cboKategori
            // 
            this.cboKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKategori.FormattingEnabled = true;
            this.cboKategori.Location = new System.Drawing.Point(166, 170);
            this.cboKategori.Name = "cboKategori";
            this.cboKategori.Size = new System.Drawing.Size(234, 22);
            this.cboKategori.TabIndex = 2;
            // 
            // cboCabang1
            // 
            this.cboCabang1.CabangID = "";
            this.cboCabang1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboCabang1.DisplayMember = "Concatenated";
            this.cboCabang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang1.Font = new System.Drawing.Font("Courier New", 8F);
            this.cboCabang1.FormattingEnabled = true;
            this.cboCabang1.Location = new System.Drawing.Point(166, 197);
            this.cboCabang1.Name = "cboCabang1";
            this.cboCabang1.Size = new System.Drawing.Size(180, 22);
            this.cboCabang1.TabIndex = 3;
            this.cboCabang1.ValueMember = "CabangID";
            // 
            // cboCabang2
            // 
            this.cboCabang2.CabangID = "";
            this.cboCabang2.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboCabang2.DisplayMember = "Concatenated";
            this.cboCabang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang2.Font = new System.Drawing.Font("Courier New", 8F);
            this.cboCabang2.FormattingEnabled = true;
            this.cboCabang2.Location = new System.Drawing.Point(166, 225);
            this.cboCabang2.Name = "cboCabang2";
            this.cboCabang2.Size = new System.Drawing.Size(180, 22);
            this.cboCabang2.TabIndex = 4;
            this.cboCabang2.ValueMember = "CabangID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nama Sales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Kode Sales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Kategori";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "Cabang1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cabang2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbTglNota);
            this.groupBox1.Controls.Add(this.rdbTglRq);
            this.groupBox1.Location = new System.Drawing.Point(166, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // rdbTglNota
            // 
            this.rdbTglNota.AutoSize = true;
            this.rdbTglNota.Location = new System.Drawing.Point(138, 20);
            this.rdbTglNota.Name = "rdbTglNota";
            this.rdbTglNota.Size = new System.Drawing.Size(66, 18);
            this.rdbTglNota.TabIndex = 1;
            this.rdbTglNota.TabStop = true;
            this.rdbTglNota.Text = "TglNota";
            this.rdbTglNota.UseVisualStyleBackColor = true;
            // 
            // rdbTglRq
            // 
            this.rdbTglRq.AutoSize = true;
            this.rdbTglRq.Location = new System.Drawing.Point(7, 20);
            this.rdbTglRq.Name = "rdbTglRq";
            this.rdbTglRq.Size = new System.Drawing.Size(62, 18);
            this.rdbTglRq.TabIndex = 0;
            this.rdbTglRq.TabStop = true;
            this.rdbTglRq.Text = "Tgl. Rq";
            this.rdbTglRq.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Periode Berdasarkan";
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(31, 393);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.ReportName = "";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 20;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // frmRptRekapReturJualDanPenyelesainya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(498, 471);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCabang2);
            this.Controls.Add(this.cboCabang1);
            this.Controls.Add(this.cboKategori);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.lookupSales);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptRekapReturJualDanPenyelesainya";
            this.Text = "Rekapitulasi Retur && Penyelesainya";
            this.Title = "Rekapitulasi Retur && Penyelesainya";
            this.Load += new System.EventHandler(this.frmRptRekapReturJualDanPenyelesainya_Load);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.cboKategori, 0);
            this.Controls.SetChildIndex(this.cboCabang1, 0);
            this.Controls.SetChildIndex(this.cboCabang2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.LookupSales lookupSales;
        private System.Windows.Forms.ComboBox cboKategori;
        private ISA.Trading.Controls.CabangComboBox cboCabang1;
        private ISA.Trading.Controls.CabangComboBox cboCabang2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTglNota;
        private System.Windows.Forms.RadioButton rdbTglRq;
        private System.Windows.Forms.Label label7;
        private ISA.Trading.Controls.CommandButton cmdPrint;
    }
}
