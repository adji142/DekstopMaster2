namespace ISA.Toko.Bonus
{
    partial class frmRptPerhitunganBonusFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPerhitunganBonusFilter));
            this.cboGroupBrg = new System.Windows.Forms.ComboBox();
            this.lookupToko = new ISA.Toko.Controls.LookupToko();
            this.lookupSales = new ISA.Toko.Controls.LookupSales();
            this.rgbPeriode = new ISA.Toko.Controls.RangeDateBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKlp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboGroupBrg
            // 
            this.cboGroupBrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroupBrg.FormattingEnabled = true;
            this.cboGroupBrg.Location = new System.Drawing.Point(188, 213);
            this.cboGroupBrg.Name = "cboGroupBrg";
            this.cboGroupBrg.Size = new System.Drawing.Size(224, 22);
            this.cboGroupBrg.TabIndex = 21;
            // 
            // lookupToko
            // 
            this.lookupToko.Alamat = null;
            this.lookupToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko.KodeToko = "[CODE]";
            this.lookupToko.Kota = null;
            this.lookupToko.Location = new System.Drawing.Point(185, 155);
            this.lookupToko.NamaToko = "";
            this.lookupToko.Name = "lookupToko";
            this.lookupToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko.Size = new System.Drawing.Size(300, 54);
            this.lookupToko.TabIndex = 20;
            this.lookupToko.TokoID = null;
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(183, 95);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "[CODE]";
            this.lookupSales.Size = new System.Drawing.Size(276, 54);
            this.lookupSales.TabIndex = 19;
            // 
            // rgbPeriode
            // 
            this.rgbPeriode.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbPeriode.FromDate = null;
            this.rgbPeriode.Location = new System.Drawing.Point(180, 66);
            this.rgbPeriode.Name = "rgbPeriode";
            this.rgbPeriode.Size = new System.Drawing.Size(257, 22);
            this.rgbPeriode.TabIndex = 18;
            this.rgbPeriode.ToDate = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Group Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Toko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Salesman";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Periode";
            // 
            // cboKlp
            // 
            this.cboKlp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKlp.FormattingEnabled = true;
            this.cboKlp.Location = new System.Drawing.Point(188, 245);
            this.cboKlp.Name = "cboKlp";
            this.cboKlp.Size = new System.Drawing.Size(58, 22);
            this.cboKlp.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Kelompok";
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(188, 292);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 24;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(312, 292);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 25;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRptPerhitunganBonusFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(504, 344);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cboKlp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboGroupBrg);
            this.Controls.Add(this.lookupToko);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.rgbPeriode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptPerhitunganBonusFilter";
            this.Load += new System.EventHandler(this.frmRptPerhitunganBonusFilter_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.rgbPeriode, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.lookupToko, 0);
            this.Controls.SetChildIndex(this.cboGroupBrg, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cboKlp, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGroupBrg;
        private ISA.Toko.Controls.LookupToko lookupToko;
        private ISA.Toko.Controls.LookupSales lookupSales;
        private ISA.Toko.Controls.RangeDateBox rgbPeriode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKlp;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
