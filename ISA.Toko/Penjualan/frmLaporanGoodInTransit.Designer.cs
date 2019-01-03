namespace ISA.Toko.Penjualan
{
    partial class frmLaporanGoodInTransit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanGoodInTransit));
            this.label1 = new System.Windows.Forms.Label();
            this.rangePeriode = new ISA.Toko.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdProses = new ISA.Toko.Controls.CommandButton();
            this.txtWilayah = new ISA.Toko.Controls.CommonTextBox();
            this.chkLaporan = new System.Windows.Forms.CheckBox();
            this.txtCabang1 = new ISA.Toko.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lookupGudang = new ISA.Toko.Controls.LookupGudang();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Periode Tanggal";
            // 
            // rangePeriode
            // 
            this.rangePeriode.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangePeriode.FromDate = null;
            this.rangePeriode.Location = new System.Drawing.Point(142, 66);
            this.rangePeriode.Name = "rangePeriode";
            this.rangePeriode.Size = new System.Drawing.Size(257, 22);
            this.rangePeriode.TabIndex = 0;
            this.rangePeriode.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Wilayah";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cab 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Model Laporan";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(376, 235);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdProses
            // 
            this.cmdProses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdProses.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdProses.Image = ((System.Drawing.Image)(resources.GetObject("cmdProses.Image")));
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(253, 235);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 5;
            this.cmdProses.Text = "YES";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // txtWilayah
            // 
            this.txtWilayah.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWilayah.Location = new System.Drawing.Point(178, 101);
            this.txtWilayah.MaxLength = 1;
            this.txtWilayah.Name = "txtWilayah";
            this.txtWilayah.Size = new System.Drawing.Size(40, 20);
            this.txtWilayah.TabIndex = 1;
            this.txtWilayah.TextChanged += new System.EventHandler(this.txtWilayah_TextChanged);
            // 
            // chkLaporan
            // 
            this.chkLaporan.AutoSize = true;
            this.chkLaporan.Location = new System.Drawing.Point(178, 189);
            this.chkLaporan.Name = "chkLaporan";
            this.chkLaporan.Size = new System.Drawing.Size(103, 18);
            this.chkLaporan.TabIndex = 4;
            this.chkLaporan.Text = "Laporan Audit";
            this.chkLaporan.UseVisualStyleBackColor = true;
            // 
            // txtCabang1
            // 
            this.txtCabang1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCabang1.Location = new System.Drawing.Point(295, 100);
            this.txtCabang1.MaxLength = 2;
            this.txtCabang1.Name = "txtCabang1";
            this.txtCabang1.Size = new System.Drawing.Size(45, 20);
            this.txtCabang1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kode Gudang";
            // 
            // lookupGudang
            // 
            this.lookupGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang.GudangID = "";
            this.lookupGudang.InitPerusahaan = null;
            this.lookupGudang.KodeCabang = null;
            this.lookupGudang.Location = new System.Drawing.Point(174, 133);
            this.lookupGudang.NamaGudang = "";
            this.lookupGudang.Name = "lookupGudang";
            this.lookupGudang.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang.TabIndex = 3;
            // 
            // frmLaporanGoodInTransit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(509, 306);
            this.Controls.Add(this.lookupGudang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCabang1);
            this.Controls.Add(this.chkLaporan);
            this.Controls.Add(this.txtWilayah);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rangePeriode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdProses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanGoodInTransit";
            this.ShowInTaskbar = false;
            this.Text = "Laporan Good In Transit";
            this.Title = "Laporan Good In Transit";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLaporanGoodInTransit_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rangePeriode, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtWilayah, 0);
            this.Controls.SetChildIndex(this.chkLaporan, 0);
            this.Controls.SetChildIndex(this.txtCabang1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lookupGudang, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rangePeriode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdProses;
        private ISA.Toko.Controls.CommonTextBox txtWilayah;
        private System.Windows.Forms.CheckBox chkLaporan;
        private ISA.Toko.Controls.CommonTextBox txtCabang1;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.LookupGudang lookupGudang;
    }
}
