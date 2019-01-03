namespace ISA.Trading.Laporan.Toko
{
    partial class frmRptAnalisaKunjunganSalesFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAnalisaKunjunganSalesFilter));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rdbTgl1 = new ISA.Trading.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdYES = new ISA.Trading.Controls.CommandButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lookupSales = new ISA.Trading.Controls.LookupSales();
            this.txtKota = new ISA.Trading.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNota = new System.Windows.Forms.RadioButton();
            this.rdoDO = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoNetto = new System.Windows.Forms.RadioButton();
            this.rdoBruto = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoKota = new System.Windows.Forms.RadioButton();
            this.rdoSales = new System.Windows.Forms.RadioButton();
            this.rdoToko = new System.Windows.Forms.RadioButton();
            this.cboPos = new System.Windows.Forms.ComboBox();
            this.rdbTgl2 = new ISA.Trading.Controls.RangeDateBox();
            this.txtWilayah = new ISA.Trading.Controls.NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // rdbTgl1
            // 
            this.rdbTgl1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl1.FromDate = null;
            this.rdbTgl1.Location = new System.Drawing.Point(73, 86);
            this.rdbTgl1.Name = "rdbTgl1";
            this.rdbTgl1.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl1.TabIndex = 0;
            this.rdbTgl1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 30;
            this.label2.Text = "Periode I";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 31;
            this.label3.Text = "Periode II";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 34;
            this.label5.Text = "Salesman";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 35;
            this.label6.Text = "Pos";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(235, 465);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.ReportName = "";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(126, 465);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.ReportName = "";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 6;
            this.cmdYES.Text = "PRINT";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 38;
            this.label7.Text = "Wilayah";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 14);
            this.label8.TabIndex = 39;
            this.label8.Text = "Jenis Laporan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(98, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 14);
            this.label9.TabIndex = 40;
            this.label9.Text = "Kota";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(77, 377);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 14);
            this.label10.TabIndex = 41;
            this.label10.Text = "Nominal";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(98, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 14);
            this.label11.TabIndex = 42;
            this.label11.Text = "Urut";
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(150, 182);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "";
            this.lookupSales.Size = new System.Drawing.Size(276, 54);
            this.lookupSales.TabIndex = 2;
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Location = new System.Drawing.Point(154, 299);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(235, 20);
            this.txtKota.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoNota);
            this.groupBox1.Controls.Add(this.rdoDO);
            this.groupBox1.Location = new System.Drawing.Point(154, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 38);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // rdoNota
            // 
            this.rdoNota.AutoSize = true;
            this.rdoNota.Location = new System.Drawing.Point(72, 14);
            this.rdoNota.Name = "rdoNota";
            this.rdoNota.Size = new System.Drawing.Size(49, 18);
            this.rdoNota.TabIndex = 1;
            this.rdoNota.Text = "Nota";
            this.rdoNota.UseVisualStyleBackColor = true;
            // 
            // rdoDO
            // 
            this.rdoDO.AutoSize = true;
            this.rdoDO.Checked = true;
            this.rdoDO.Location = new System.Drawing.Point(7, 14);
            this.rdoDO.Name = "rdoDO";
            this.rdoDO.Size = new System.Drawing.Size(40, 18);
            this.rdoDO.TabIndex = 0;
            this.rdoDO.TabStop = true;
            this.rdoDO.Text = "DO";
            this.rdoDO.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoNetto);
            this.groupBox2.Controls.Add(this.rdoBruto);
            this.groupBox2.Location = new System.Drawing.Point(154, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 38);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // rdoNetto
            // 
            this.rdoNetto.AutoSize = true;
            this.rdoNetto.Location = new System.Drawing.Point(73, 14);
            this.rdoNetto.Name = "rdoNetto";
            this.rdoNetto.Size = new System.Drawing.Size(54, 18);
            this.rdoNetto.TabIndex = 1;
            this.rdoNetto.Text = "Netto";
            this.rdoNetto.UseVisualStyleBackColor = true;
            // 
            // rdoBruto
            // 
            this.rdoBruto.AutoSize = true;
            this.rdoBruto.Checked = true;
            this.rdoBruto.Location = new System.Drawing.Point(7, 14);
            this.rdoBruto.Name = "rdoBruto";
            this.rdoBruto.Size = new System.Drawing.Size(55, 18);
            this.rdoBruto.TabIndex = 0;
            this.rdoBruto.TabStop = true;
            this.rdoBruto.Text = "Bruto";
            this.rdoBruto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoKota);
            this.groupBox3.Controls.Add(this.rdoSales);
            this.groupBox3.Controls.Add(this.rdoToko);
            this.groupBox3.Location = new System.Drawing.Point(154, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 38);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            // 
            // rdoKota
            // 
            this.rdoKota.AutoSize = true;
            this.rdoKota.Location = new System.Drawing.Point(139, 14);
            this.rdoKota.Name = "rdoKota";
            this.rdoKota.Size = new System.Drawing.Size(49, 18);
            this.rdoKota.TabIndex = 2;
            this.rdoKota.Text = "Kota";
            this.rdoKota.UseVisualStyleBackColor = true;
            // 
            // rdoSales
            // 
            this.rdoSales.AutoSize = true;
            this.rdoSales.Location = new System.Drawing.Point(73, 14);
            this.rdoSales.Name = "rdoSales";
            this.rdoSales.Size = new System.Drawing.Size(55, 18);
            this.rdoSales.TabIndex = 1;
            this.rdoSales.Text = "Sales";
            this.rdoSales.UseVisualStyleBackColor = true;
            // 
            // rdoToko
            // 
            this.rdoToko.AutoSize = true;
            this.rdoToko.Checked = true;
            this.rdoToko.Location = new System.Drawing.Point(7, 14);
            this.rdoToko.Name = "rdoToko";
            this.rdoToko.Size = new System.Drawing.Size(52, 18);
            this.rdoToko.TabIndex = 0;
            this.rdoToko.TabStop = true;
            this.rdoToko.Text = "Toko";
            this.rdoToko.UseVisualStyleBackColor = true;
            // 
            // cboPos
            // 
            this.cboPos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPos.FormattingEnabled = true;
            this.cboPos.Location = new System.Drawing.Point(154, 235);
            this.cboPos.Name = "cboPos";
            this.cboPos.Size = new System.Drawing.Size(45, 22);
            this.cboPos.TabIndex = 3;
            // 
            // rdbTgl2
            // 
            this.rdbTgl2.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl2.FromDate = null;
            this.rdbTgl2.Location = new System.Drawing.Point(73, 137);
            this.rdbTgl2.Name = "rdbTgl2";
            this.rdbTgl2.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl2.TabIndex = 1;
            this.rdbTgl2.ToDate = null;
            // 
            // txtWilayah
            // 
            this.txtWilayah.Location = new System.Drawing.Point(154, 269);
            this.txtWilayah.MaxLength = 2;
            this.txtWilayah.Name = "txtWilayah";
            this.txtWilayah.Size = new System.Drawing.Size(25, 20);
            this.txtWilayah.TabIndex = 4;
            this.txtWilayah.Text = "0";
            // 
            // frmRptAnalisaKunjunganSalesFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(462, 517);
            this.Controls.Add(this.txtWilayah);
            this.Controls.Add(this.rdbTgl2);
            this.Controls.Add(this.cboPos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbTgl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptAnalisaKunjunganSalesFilter";
            this.Text = "Analisa Kunjungan Sales";
            this.Title = "Analisa Kunjungan Sales";
            this.Load += new System.EventHandler(this.frmRptAnalisaKunjunganSalesFilter_Load);
            this.Controls.SetChildIndex(this.rdbTgl1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.cboPos, 0);
            this.Controls.SetChildIndex(this.rdbTgl2, 0);
            this.Controls.SetChildIndex(this.txtWilayah, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.RangeDateBox rdbTgl1;
        private System.Windows.Forms.Label label6;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdYES;
        private ISA.Trading.Controls.CommonTextBox txtKota;
        private ISA.Trading.Controls.LookupSales lookupSales;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSales;
        private System.Windows.Forms.RadioButton rdoToko;
        private System.Windows.Forms.RadioButton rdoNetto;
        private System.Windows.Forms.RadioButton rdoBruto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoNota;
        private System.Windows.Forms.RadioButton rdoDO;
        private System.Windows.Forms.RadioButton rdoKota;
        private System.Windows.Forms.ComboBox cboPos;
        private ISA.Trading.Controls.RangeDateBox rdbTgl2;
        private ISA.Trading.Controls.NumericTextBox txtWilayah;
    }
}
