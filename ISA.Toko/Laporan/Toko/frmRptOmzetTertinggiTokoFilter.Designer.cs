namespace ISA.Toko.Laporan.Toko
{
    partial class frmRptOmzetTertinggiTokoFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOmzetTertinggiTokoFilter));
            this.rdbTgl = new ISA.Toko.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lookupSales = new ISA.Toko.Controls.LookupSales();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWilID = new ISA.Toko.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKota = new ISA.Toko.Controls.CommonTextBox();
            this.cabangComboBox = new ISA.Toko.Controls.CabangComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtWilayah = new ISA.Toko.Controls.NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbTgl
            // 
            this.rdbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl.FromDate = null;
            this.rdbTgl.Location = new System.Drawing.Point(103, 66);
            this.rdbTgl.Name = "rdbTgl";
            this.rdbTgl.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl.TabIndex = 0;
            this.rdbTgl.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "Tanggal";
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(110, 96);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "";
            this.lookupSales.Size = new System.Drawing.Size(276, 54);
            this.lookupSales.TabIndex = 1;
            this.lookupSales.Leave += new System.EventHandler(this.lookupSales_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 45;
            this.label2.Text = "Salesman";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 49;
            this.label5.Text = "Id.Wil";
            // 
            // txtWilID
            // 
            this.txtWilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWilID.Location = new System.Drawing.Point(113, 150);
            this.txtWilID.MaxLength = 7;
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.Size = new System.Drawing.Size(60, 20);
            this.txtWilID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 51;
            this.label3.Text = "Wilayah";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 53;
            this.label4.Text = "Kota";
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Location = new System.Drawing.Point(113, 202);
            this.txtKota.MaxLength = 20;
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(150, 20);
            this.txtKota.TabIndex = 4;
            // 
            // cabangComboBox
            // 
            this.cabangComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cabangComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cabangComboBox.CabangID = "";
            this.cabangComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.cabangComboBox.DisplayMember = "Concatenated";
            this.cabangComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cabangComboBox.Font = new System.Drawing.Font("Courier New", 8F);
            this.cabangComboBox.FormattingEnabled = true;
            this.cabangComboBox.Location = new System.Drawing.Point(113, 228);
            this.cabangComboBox.Name = "cabangComboBox";
            this.cabangComboBox.Size = new System.Drawing.Size(180, 22);
            this.cabangComboBox.TabIndex = 5;
            this.cabangComboBox.ValueMember = "CabangID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 54;
            this.label6.Text = "C1";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(209, 272);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
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
            this.cmdYES.Location = new System.Drawing.Point(100, 272);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 6;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtWilayah
            // 
            this.txtWilayah.Location = new System.Drawing.Point(113, 176);
            this.txtWilayah.MaxLength = 2;
            this.txtWilayah.Name = "txtWilayah";
            this.txtWilayah.Size = new System.Drawing.Size(35, 20);
            this.txtWilayah.TabIndex = 3;
            this.txtWilayah.Text = "0";
            this.txtWilayah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmRptOmzetTertinggiTokoFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(410, 324);
            this.Controls.Add(this.txtWilayah);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.cabangComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWilID);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbTgl);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptOmzetTertinggiTokoFilter";
            this.Text = "Omzet Tertinggi Toko";
            this.Title = "Omzet Tertinggi Toko";
            this.Load += new System.EventHandler(this.frmRptOmzetTertinggiTokoFilter_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rdbTgl, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.txtWilID, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cabangComboBox, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtWilayah, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.RangeDateBox rdbTgl;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.LookupSales lookupSales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommonTextBox txtWilID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.CommonTextBox txtKota;
        private ISA.Toko.Controls.CabangComboBox cabangComboBox;
        private System.Windows.Forms.Label label6;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Toko.Controls.NumericTextBox txtWilayah;
    }
}
