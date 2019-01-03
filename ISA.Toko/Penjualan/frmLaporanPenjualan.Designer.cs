namespace ISA.Toko.Penjualan
{
    partial class frmLaporanPenjualan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanPenjualan));
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRangeDate = new ISA.Toko.Controls.RangeDateBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDetail = new System.Windows.Forms.RadioButton();
            this.cboRekap = new System.Windows.Forms.RadioButton();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lookupStock1 = new ISA.Toko.Controls.LookupStock();
            this.lookup_TipeTransaksi1 = new ISA.Toko.Controls.Lookup_TipeTransaksi();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(454, 277);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 6;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(34, 277);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 5;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Jenis Transaksi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Jenis Laporan";
            // 
            // txtRangeDate
            // 
            this.txtRangeDate.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtRangeDate.FromDate = null;
            this.txtRangeDate.Location = new System.Drawing.Point(143, 79);
            this.txtRangeDate.Name = "txtRangeDate";
            this.txtRangeDate.Size = new System.Drawing.Size(257, 22);
            this.txtRangeDate.TabIndex = 0;
            this.txtRangeDate.ToDate = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDetail);
            this.groupBox1.Controls.Add(this.cboRekap);
            this.groupBox1.Location = new System.Drawing.Point(132, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 33);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // cboDetail
            // 
            this.cboDetail.AutoSize = true;
            this.cboDetail.Location = new System.Drawing.Point(98, 7);
            this.cboDetail.Name = "cboDetail";
            this.cboDetail.Size = new System.Drawing.Size(55, 18);
            this.cboDetail.TabIndex = 4;
            this.cboDetail.TabStop = true;
            this.cboDetail.Text = "Detail";
            this.cboDetail.UseVisualStyleBackColor = true;
            // 
            // cboRekap
            // 
            this.cboRekap.AutoSize = true;
            this.cboRekap.Location = new System.Drawing.Point(6, 7);
            this.cboRekap.Name = "cboRekap";
            this.cboRekap.Size = new System.Drawing.Size(59, 18);
            this.cboRekap.TabIndex = 3;
            this.cboRekap.TabStop = true;
            this.cboRekap.Text = "Rekap";
            this.cboRekap.UseVisualStyleBackColor = true;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "ALL",
            "LUNAS",
            "BELUM LUNAS"});
            this.cbStatus.Location = new System.Drawing.Point(468, 157);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(86, 22);
            this.cbStatus.TabIndex = 15;
            this.cbStatus.Text = "ALL";
            this.cbStatus.Visible = false;
            // 
            // lookupStock1
            // 
            this.lookupStock1.BarangID = "[CODE]";
            this.lookupStock1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock1.IsiKoli = 0;
            this.lookupStock1.Location = new System.Drawing.Point(143, 107);
            this.lookupStock1.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock1.LPasif = ISA.Toko.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock1.NamaStock = "";
            this.lookupStock1.Name = "lookupStock1";
            this.lookupStock1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock1.Satuan = null;
            this.lookupStock1.Size = new System.Drawing.Size(308, 50);
            this.lookupStock1.TabIndex = 1;
            // 
            // lookup_TipeTransaksi1
            // 
            this.lookup_TipeTransaksi1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookup_TipeTransaksi1.JS = 0;
            this.lookup_TipeTransaksi1.JW = 0;
            this.lookup_TipeTransaksi1.Keterangan = "";
            this.lookup_TipeTransaksi1.Kode = "";
            this.lookup_TipeTransaksi1.Location = new System.Drawing.Point(143, 157);
            this.lookup_TipeTransaksi1.Name = "lookup_TipeTransaksi1";
            this.lookup_TipeTransaksi1.Size = new System.Drawing.Size(300, 52);
            this.lookup_TipeTransaksi1.TabIndex = 2;
            this.lookup_TipeTransaksi1.SelectData += new System.EventHandler(this.lookup_TipeTransaksi1_SelectData);
            // 
            // frmLaporanPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 341);
            this.Controls.Add(this.lookup_TipeTransaksi1);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRangeDate);
            this.Controls.Add(this.lookupStock1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdYES);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanPenjualan";
            this.Text = "Laporan Penjualan";
            this.Title = "Laporan Penjualan";
            this.Load += new System.EventHandler(this.frmLaporanPenjualan_Load);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lookupStock1, 0);
            this.Controls.SetChildIndex(this.txtRangeDate, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cbStatus, 0);
            this.Controls.SetChildIndex(this.lookup_TipeTransaksi1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.RangeDateBox txtRangeDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cboDetail;
        private System.Windows.Forms.RadioButton cboRekap;
        private System.Windows.Forms.ComboBox cbStatus;
        private ISA.Toko.Controls.LookupStock lookupStock1;
        private ISA.Toko.Controls.Lookup_TipeTransaksi lookup_TipeTransaksi1;
    }
}