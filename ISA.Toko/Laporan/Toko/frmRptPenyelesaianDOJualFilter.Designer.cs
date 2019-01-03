namespace ISA.Toko.Laporan.Toko
{
    partial class frmRptPenyelesaianDOJualFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPenyelesaianDOJualFilter));
            this.rdoContain = new System.Windows.Forms.RadioButton();
            this.rdoFixed = new System.Windows.Forms.RadioButton();
            this.txtStok = new ISA.Toko.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbTglDO = new ISA.Toko.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWilID = new ISA.Toko.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboKelBrg = new System.Windows.Forms.ComboBox();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.lookupSales = new ISA.Toko.Controls.LookupSales();
            this.lookupToko = new ISA.Toko.Controls.LookupToko();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cabangComboBox1 = new ISA.Toko.Controls.CabangComboBox();
            this.cabangComboBox2 = new ISA.Toko.Controls.CabangComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCab = new ISA.Toko.Controls.CommonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoContain
            // 
            this.rdoContain.AutoSize = true;
            this.rdoContain.Location = new System.Drawing.Point(201, 344);
            this.rdoContain.Name = "rdoContain";
            this.rdoContain.Size = new System.Drawing.Size(67, 18);
            this.rdoContain.TabIndex = 8;
            this.rdoContain.TabStop = true;
            this.rdoContain.Text = "Contain";
            this.rdoContain.UseVisualStyleBackColor = true;
            // 
            // rdoFixed
            // 
            this.rdoFixed.AutoSize = true;
            this.rdoFixed.Location = new System.Drawing.Point(113, 344);
            this.rdoFixed.Name = "rdoFixed";
            this.rdoFixed.Size = new System.Drawing.Size(54, 18);
            this.rdoFixed.TabIndex = 7;
            this.rdoFixed.TabStop = true;
            this.rdoFixed.Text = "Fixed";
            this.rdoFixed.UseVisualStyleBackColor = true;
            // 
            // txtStok
            // 
            this.txtStok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStok.Location = new System.Drawing.Point(113, 320);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(346, 20);
            this.txtStok.TabIndex = 6;
            this.txtStok.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStok_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nama Stok";
            // 
            // rdbTglDO
            // 
            this.rdbTglDO.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTglDO.FromDate = null;
            this.rdbTglDO.Location = new System.Drawing.Point(103, 66);
            this.rdbTglDO.Name = "rdbTglDO";
            this.rdbTglDO.Size = new System.Drawing.Size(257, 22);
            this.rdbTglDO.TabIndex = 0;
            this.rdbTglDO.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 39;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 43;
            this.label2.Text = "Salesman";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 45;
            this.label4.Text = "Toko";
            // 
            // txtWilID
            // 
            this.txtWilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWilID.Location = new System.Drawing.Point(113, 287);
            this.txtWilID.MaxLength = 7;
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.Size = new System.Drawing.Size(60, 20);
            this.txtWilID.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 47;
            this.label5.Text = "Wilayah";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 48;
            this.label6.Text = "C1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 50;
            this.label7.Text = "C2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 51;
            this.label8.Text = "Kelompok";
            // 
            // cboKelBrg
            // 
            this.cboKelBrg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKelBrg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKelBrg.FormattingEnabled = true;
            this.cboKelBrg.Location = new System.Drawing.Point(113, 373);
            this.cboKelBrg.Name = "cboKelBrg";
            this.cboKelBrg.Size = new System.Drawing.Size(45, 22);
            this.cboKelBrg.TabIndex = 9;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(375, 436);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 11;
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
            this.cmdYES.Location = new System.Drawing.Point(260, 436);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 10;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(110, 167);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "[CODE]";
            this.lookupSales.Size = new System.Drawing.Size(276, 54);
            this.lookupSales.TabIndex = 3;
            // 
            // lookupToko
            // 
            this.lookupToko.Alamat = null;
            this.lookupToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko.HariKirim = 0;
            this.lookupToko.HariSales = 0;
            this.lookupToko.KodeToko = "[CODE]";
            this.lookupToko.Kota = null;
            this.lookupToko.Location = new System.Drawing.Point(110, 227);
            this.lookupToko.NamaToko = "";
            this.lookupToko.Name = "lookupToko";
            this.lookupToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko.Size = new System.Drawing.Size(300, 54);
            this.lookupToko.TabIndex = 4;
            this.lookupToko.TokoID = null;
            this.lookupToko.WilID = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cabangComboBox1
            // 
            this.cabangComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cabangComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cabangComboBox1.CabangID = "";
            this.cabangComboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cabangComboBox1.DisplayMember = "Concatenated";
            this.cabangComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cabangComboBox1.Font = new System.Drawing.Font("Courier New", 8F);
            this.cabangComboBox1.FormattingEnabled = true;
            this.cabangComboBox1.Location = new System.Drawing.Point(113, 100);
            this.cabangComboBox1.Name = "cabangComboBox1";
            this.cabangComboBox1.Size = new System.Drawing.Size(180, 22);
            this.cabangComboBox1.TabIndex = 1;
            this.cabangComboBox1.ValueMember = "CabangID";
            // 
            // cabangComboBox2
            // 
            this.cabangComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cabangComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cabangComboBox2.CabangID = "";
            this.cabangComboBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.cabangComboBox2.DisplayMember = "Concatenated";
            this.cabangComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cabangComboBox2.Font = new System.Drawing.Font("Courier New", 8F);
            this.cabangComboBox2.FormattingEnabled = true;
            this.cabangComboBox2.Location = new System.Drawing.Point(113, 136);
            this.cabangComboBox2.Name = "cabangComboBox2";
            this.cabangComboBox2.Size = new System.Drawing.Size(180, 22);
            this.cabangComboBox2.TabIndex = 2;
            this.cabangComboBox2.ValueMember = "CabangID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 405);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 14);
            this.label9.TabIndex = 53;
            this.label9.Text = "Init Cabang";
            // 
            // txtCab
            // 
            this.txtCab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCab.Location = new System.Drawing.Point(113, 402);
            this.txtCab.MaxLength = 3;
            this.txtCab.Name = "txtCab";
            this.txtCab.Size = new System.Drawing.Size(60, 20);
            this.txtCab.TabIndex = 52;
            // 
            // frmRptPenyelesaianDOJualFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(487, 488);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCab);
            this.Controls.Add(this.cabangComboBox2);
            this.Controls.Add(this.cabangComboBox1);
            this.Controls.Add(this.lookupToko);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.cboKelBrg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdoContain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rdoFixed);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWilID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbTglDO);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(495, 515);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(495, 515);
            this.Name = "frmRptPenyelesaianDOJualFilter";
            this.Text = "Penyelesaian Order Penjualan";
            this.Title = "Penyelesaian Order Penjualan";
            this.Load += new System.EventHandler(this.frmRptPenyelesaianDOJualFilter_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rdbTglDO, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtWilID, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtStok, 0);
            this.Controls.SetChildIndex(this.rdoFixed, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.rdoContain, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboKelBrg, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.lookupToko, 0);
            this.Controls.SetChildIndex(this.cabangComboBox1, 0);
            this.Controls.SetChildIndex(this.cabangComboBox2, 0);
            this.Controls.SetChildIndex(this.txtCab, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoContain;
        private System.Windows.Forms.RadioButton rdoFixed;
        private ISA.Toko.Controls.CommonTextBox txtStok;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.RangeDateBox rdbTglDO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.CommonTextBox txtWilID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboKelBrg;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private ISA.Toko.Controls.LookupSales lookupSales;
        private ISA.Toko.Controls.LookupToko lookupToko;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Toko.Controls.CabangComboBox cabangComboBox2;
        private ISA.Toko.Controls.CabangComboBox cabangComboBox1;
        private System.Windows.Forms.Label label9;
        private ISA.Toko.Controls.CommonTextBox txtCab;
    }
}
