namespace ISA.Toko.Laporan.Toko
{
    partial class frmTokoAktif2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTokoAktif2));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAll = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRat = new System.Windows.Forms.RadioButton();
            this.txtNominal1 = new ISA.Controls.NumericTextBox();
            this.txtNominal2 = new ISA.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cabangComboBox1 = new ISA.Controls.CabangComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWilID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lookupSales1 = new ISA.Controls.LookupSales();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.label2 = new System.Windows.Forms.Label();
            this.monthYearBox2 = new ISA.Controls.MonthYearBox();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.txtNamaToko = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 421);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(809, 23);
            this.progressBar1.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAll);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboRat);
            this.groupBox1.Controls.Add(this.txtNominal1);
            this.groupBox1.Controls.Add(this.txtNominal2);
            this.groupBox1.Location = new System.Drawing.Point(31, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 100);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Omset Rata-rata";
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Checked = true;
            this.cbAll.Location = new System.Drawing.Point(6, 56);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(63, 18);
            this.cbAll.TabIndex = 24;
            this.cbAll.TabStop = true;
            this.cbAll.Text = "Semua";
            this.cbAll.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "s/d";
            // 
            // cboRat
            // 
            this.cboRat.AutoSize = true;
            this.cboRat.Location = new System.Drawing.Point(6, 25);
            this.cboRat.Name = "cboRat";
            this.cboRat.Size = new System.Drawing.Size(57, 18);
            this.cboRat.TabIndex = 0;
            this.cboRat.Text = "range";
            this.cboRat.UseVisualStyleBackColor = true;
            // 
            // txtNominal1
            // 
            this.txtNominal1.Location = new System.Drawing.Point(86, 24);
            this.txtNominal1.Name = "txtNominal1";
            this.txtNominal1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNominal1.Size = new System.Drawing.Size(100, 20);
            this.txtNominal1.TabIndex = 11;
            this.txtNominal1.Text = "0";
            // 
            // txtNominal2
            // 
            this.txtNominal2.Location = new System.Drawing.Point(271, 23);
            this.txtNominal2.Name = "txtNominal2";
            this.txtNominal2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNominal2.Size = new System.Drawing.Size(100, 20);
            this.txtNominal2.TabIndex = 12;
            this.txtNominal2.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 14);
            this.label6.TabIndex = 37;
            this.label6.Text = "Sales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 36;
            this.label5.Text = "Gudang";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Periode";
            // 
            // cabangComboBox1
            // 
            this.cabangComboBox1.CabangID = "";
            this.cabangComboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cabangComboBox1.DisplayMember = "Concatenated";
            this.cabangComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cabangComboBox1.Font = new System.Drawing.Font("Arial", 8F);
            this.cabangComboBox1.FormattingEnabled = true;
            this.cabangComboBox1.Location = new System.Drawing.Point(84, 136);
            this.cabangComboBox1.Name = "cabangComboBox1";
            this.cabangComboBox1.Size = new System.Drawing.Size(180, 22);
            this.cabangComboBox1.TabIndex = 35;
            this.cabangComboBox1.ValueMember = "CabangID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "Cabang";
            // 
            // txtWilID
            // 
            this.txtWilID.Location = new System.Drawing.Point(84, 103);
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.Size = new System.Drawing.Size(100, 20);
            this.txtWilID.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 32;
            this.label3.Text = "Wilayah";
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(84, 236);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 29;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 462);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 24;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(721, 462);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 25;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(84, 67);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(297, 20);
            this.monthYearBox1.TabIndex = 26;
            this.monthYearBox1.Year = 2012;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 14);
            this.label2.TabIndex = 31;
            this.label2.Text = "s/d";
            // 
            // monthYearBox2
            // 
            this.monthYearBox2.Location = new System.Drawing.Point(428, 67);
            this.monthYearBox2.Month = 1;
            this.monthYearBox2.Name = "monthYearBox2";
            this.monthYearBox2.Size = new System.Drawing.Size(278, 20);
            this.monthYearBox2.TabIndex = 27;
            this.monthYearBox2.Year = 2012;
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(84, 176);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 28;
            // 
            // txtNamaToko
            // 
            this.txtNamaToko.AutoSize = true;
            this.txtNamaToko.Location = new System.Drawing.Point(12, 404);
            this.txtNamaToko.Name = "txtNamaToko";
            this.txtNamaToko.Size = new System.Drawing.Size(39, 14);
            this.txtNamaToko.TabIndex = 40;
            this.txtNamaToko.Text = "label8";
            // 
            // frmTokoAktif2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(833, 510);
            this.Controls.Add(this.txtNamaToko);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cabangComboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWilID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.monthYearBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthYearBox2);
            this.Controls.Add(this.lookupGudang1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTokoAktif2";
            this.Text = "Laporan Toko Aktif";
            this.Title = "Laporan Toko Aktif";
            this.Load += new System.EventHandler(this.frmTokoAktif2_Load);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.monthYearBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtWilID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cabangComboBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.txtNamaToko, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cbAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton cboRat;
        private ISA.Controls.NumericTextBox txtNominal1;
        private ISA.Controls.NumericTextBox txtNominal2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CabangComboBox cabangComboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWilID;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.LookupSales lookupSales1;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.MonthYearBox monthYearBox2;
        private ISA.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.Label txtNamaToko;
    }
}
