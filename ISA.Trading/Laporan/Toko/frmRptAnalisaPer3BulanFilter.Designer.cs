namespace ISA.Trading.Laporan.Toko
{
    partial class frmRptAnalisaPer3BulanFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAnalisaPer3BulanFilter));
            this.lookupToko = new ISA.Trading.Controls.LookupToko();
            this.lookupSales = new ISA.Trading.Controls.LookupSales();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdYES = new ISA.Trading.Controls.CommandButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKota = new ISA.Trading.Controls.CommonTextBox();
            this.rdbTgl = new ISA.Trading.Controls.RangeDateBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lookupToko
            // 
            this.lookupToko.Alamat = null;
            this.lookupToko.Daerah = null;
            this.lookupToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko.HariKirim = 0;
            this.lookupToko.HariSales = 0;
            this.lookupToko.KodeToko = "";
            this.lookupToko.Kota = null;
            this.lookupToko.Location = new System.Drawing.Point(109, 97);
            this.lookupToko.NamaToko = "";
            this.lookupToko.Name = "lookupToko";
            this.lookupToko.Propinsi = null;
            this.lookupToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko.Size = new System.Drawing.Size(300, 54);
            this.lookupToko.TabIndex = 1;
            this.lookupToko.TokoID = null;
            this.lookupToko.WilID = "";
            this.lookupToko.Leave += new System.EventHandler(this.lookupToko_Leave);
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(107, 155);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "";
            this.lookupSales.Size = new System.Drawing.Size(276, 54);
            this.lookupSales.TabIndex = 2;
            this.lookupSales.Load += new System.EventHandler(this.lookupSales_Load);
            this.lookupSales.Leave += new System.EventHandler(this.lookupSales_Leave);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(323, 252);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.ReportName = "";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 5;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click_1);
            // 
            // cmdYES
            // 
            this.cmdYES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYES.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(12, 252);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.ReportName = "";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 4;
            this.cmdYES.Text = "PRINT";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 14);
            this.label4.TabIndex = 53;
            this.label4.Text = "Toko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 52;
            this.label2.Text = "Salesman";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 51;
            this.label1.Text = "Tanggal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 54;
            this.label3.Text = "Kota";
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Location = new System.Drawing.Point(109, 215);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(100, 20);
            this.txtKota.TabIndex = 3;
            // 
            // rdbTgl
            // 
            this.rdbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl.FromDate = null;
            this.rdbTgl.Location = new System.Drawing.Point(107, 65);
            this.rdbTgl.Name = "rdbTgl";
            this.rdbTgl.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl.TabIndex = 0;
            this.rdbTgl.ToDate = null;
            this.rdbTgl.Leave += new System.EventHandler(this.rdbTgl_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRptAnalisaPer3BulanFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(427, 292);
            this.Controls.Add(this.rdbTgl);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookupToko);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(443, 331);
            this.MinimumSize = new System.Drawing.Size(443, 331);
            this.Name = "frmRptAnalisaPer3BulanFilter";
            this.Text = "Analisa per 3 Bulan";
            this.Title = "Analisa per 3 Bulan";
            this.Load += new System.EventHandler(this.frmRptAnalisaPer3BulanFilter_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.lookupToko, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.rdbTgl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.LookupToko lookupToko;
        private ISA.Trading.Controls.LookupSales lookupSales;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdYES;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private ISA.Trading.Controls.CommonTextBox txtKota;
        private ISA.Trading.Controls.RangeDateBox rdbTgl;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
