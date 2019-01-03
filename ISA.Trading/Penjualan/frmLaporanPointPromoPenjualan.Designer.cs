namespace ISA.Trading.Penjualan
{
    partial class frmLaporanPointPromoPenjualan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanPointPromoPenjualan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDetail = new System.Windows.Forms.RadioButton();
            this.rbRekap = new System.Windows.Forms.RadioButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdProses = new ISA.Trading.Controls.CommandButton();
            this.rangePeriode = new ISA.Trading.Controls.RangeDateBox();
            this.lkptoko = new ISA.Trading.Controls.LookupToko();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Periode Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Model Laporan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDetail);
            this.groupBox1.Controls.Add(this.rbRekap);
            this.groupBox1.Location = new System.Drawing.Point(172, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 47);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rbDetail
            // 
            this.rbDetail.AutoSize = true;
            this.rbDetail.Location = new System.Drawing.Point(90, 16);
            this.rbDetail.Name = "rbDetail";
            this.rbDetail.Size = new System.Drawing.Size(55, 18);
            this.rbDetail.TabIndex = 1;
            this.rbDetail.Text = "Detail";
            this.rbDetail.UseVisualStyleBackColor = true;
            // 
            // rbRekap
            // 
            this.rbRekap.AutoSize = true;
            this.rbRekap.Checked = true;
            this.rbRekap.Location = new System.Drawing.Point(6, 16);
            this.rbRekap.Name = "rbRekap";
            this.rbRekap.Size = new System.Drawing.Size(59, 18);
            this.rbRekap.TabIndex = 0;
            this.rbRekap.TabStop = true;
            this.rbRekap.Text = "Rekap";
            this.rbRekap.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(274, 237);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // cmdProses
            // 
            this.cmdProses.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdProses.Image = ((System.Drawing.Image)(resources.GetObject("cmdProses.Image")));
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(168, 237);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 3;
            this.cmdProses.Text = "YES";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // rangePeriode
            // 
            this.rangePeriode.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangePeriode.FromDate = null;
            this.rangePeriode.Location = new System.Drawing.Point(137, 78);
            this.rangePeriode.Name = "rangePeriode";
            this.rangePeriode.Size = new System.Drawing.Size(257, 22);
            this.rangePeriode.TabIndex = 0;
            this.rangePeriode.ToDate = null;
            // 
            // lkptoko
            // 
            this.lkptoko.Alamat = null;
            this.lkptoko.Daerah = null;
            this.lkptoko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lkptoko.HariKirim = 0;
            this.lkptoko.HariSales = 0;
            this.lkptoko.KodeToko = "";
            this.lkptoko.Kota = null;
            this.lkptoko.Location = new System.Drawing.Point(170, 102);
            this.lkptoko.NamaToko = "";
            this.lkptoko.Name = "lkptoko";
            this.lkptoko.Propinsi = null;
            this.lkptoko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkptoko.Size = new System.Drawing.Size(300, 54);
            this.lkptoko.TabIndex = 1;
            this.lkptoko.TokoID = null;
            this.lkptoko.WilID = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "N a m a   T o k o";
            // 
            // frmLaporanPointPromoPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(513, 306);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lkptoko);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProses);
            this.Controls.Add(this.rangePeriode);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanPointPromoPenjualan";
            this.Text = "Laporan Point Promo Penjualan";
            this.Title = "Laporan Point Promo Penjualan";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLaporanPointPromoPenjualan_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangePeriode, 0);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lkptoko, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rangePeriode;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdProses;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDetail;
        private System.Windows.Forms.RadioButton rbRekap;
        private ISA.Trading.Controls.LookupToko lkptoko;
        private System.Windows.Forms.Label label3;
    }
}
