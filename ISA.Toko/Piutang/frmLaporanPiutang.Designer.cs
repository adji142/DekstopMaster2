namespace ISA.Toko.Piutang
{
    partial class frmLaporanPiutang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanPiutang));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.txtRangeDate = new ISA.Toko.Controls.RangeDateBox();
            this.lookupSales1 = new ISA.Toko.Controls.LookupSales();
            this.lookupToko1 = new ISA.Toko.Controls.LookupToko();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tgl. Nota";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(257, 251);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 18;
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
            this.cmdYES.Location = new System.Drawing.Point(37, 251);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 17;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // txtRangeDate
            // 
            this.txtRangeDate.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtRangeDate.FromDate = null;
            this.txtRangeDate.Location = new System.Drawing.Point(114, 69);
            this.txtRangeDate.Name = "txtRangeDate";
            this.txtRangeDate.Size = new System.Drawing.Size(257, 22);
            this.txtRangeDate.TabIndex = 20;
            this.txtRangeDate.ToDate = null;
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(114, 114);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "[CODE]";
            this.lookupSales1.Size = new System.Drawing.Size(214, 53);
            this.lookupSales1.TabIndex = 21;
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Daerah = null;
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "[CODE]";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(114, 169);
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.Propinsi = null;
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(273, 48);
            this.lookupToko1.TabIndex = 22;
            this.lookupToko1.TokoID = null;
            this.lookupToko1.WilID = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Sales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Customer";
            // 
            // frmLaporanPiutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 304);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.txtRangeDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanPiutang";
            this.Text = "Laporan Piutang Belum Lunas";
            this.Title = "Laporan Piutang Belum Lunas";
            this.Load += new System.EventHandler(this.frmLaporanPiutang_Load);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtRangeDate, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private ISA.Toko.Controls.RangeDateBox txtRangeDate;
        public ISA.Toko.Controls.LookupSales lookupSales1;
        private ISA.Toko.Controls.LookupToko lookupToko1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}