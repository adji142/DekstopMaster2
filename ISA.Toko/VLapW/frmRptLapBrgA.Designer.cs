namespace ISA.Toko.VLapW
{
    partial class frmRptLapBrgA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptLapBrgA));
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdNo = new ISA.Toko.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Toko.Controls.RangeDateBox();
            this.lookupGudang = new ISA.Toko.Controls.LookupGudang();
            this.txtNamaStok = new ISA.Toko.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbType = new System.Windows.Forms.RadioButton();
            this.rdbBarang = new System.Windows.Forms.RadioButton();
            this.rdbToko = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbNetto = new System.Windows.Forms.RadioButton();
            this.rdbBruto = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKelompok = new ISA.Toko.Controls.CommonTextBox();
            this.cabangComboBox1 = new ISA.Toko.Controls.CabangComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 471);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 7;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(483, 471);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 8;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(90, 72);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 24);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // lookupGudang
            // 
            this.lookupGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang.GudangID = "";
            this.lookupGudang.KodeCabang = null;
            this.lookupGudang.Location = new System.Drawing.Point(124, 132);
            this.lookupGudang.NamaGudang = "";
            this.lookupGudang.Name = "lookupGudang";
            this.lookupGudang.Size = new System.Drawing.Size(276, 58);
            this.lookupGudang.TabIndex = 2;
            this.lookupGudang.Leave += new System.EventHandler(this.lookupGudang_Leave);
            // 
            // txtNamaStok
            // 
            this.txtNamaStok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaStok.Location = new System.Drawing.Point(127, 232);
            this.txtNamaStok.Name = "txtNamaStok";
            this.txtNamaStok.Size = new System.Drawing.Size(244, 20);
            this.txtNamaStok.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbType);
            this.groupBox1.Controls.Add(this.rdbBarang);
            this.groupBox1.Controls.Add(this.rdbToko);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(137, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 91);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // rdbType
            // 
            this.rdbType.AutoSize = true;
            this.rdbType.Location = new System.Drawing.Point(7, 64);
            this.rdbType.Name = "rdbType";
            this.rdbType.Size = new System.Drawing.Size(81, 18);
            this.rdbType.TabIndex = 2;
            this.rdbType.TabStop = true;
            this.rdbType.Text = "Per Type";
            this.rdbType.UseVisualStyleBackColor = true;
            // 
            // rdbBarang
            // 
            this.rdbBarang.AutoSize = true;
            this.rdbBarang.Location = new System.Drawing.Point(7, 39);
            this.rdbBarang.Name = "rdbBarang";
            this.rdbBarang.Size = new System.Drawing.Size(95, 18);
            this.rdbBarang.TabIndex = 1;
            this.rdbBarang.TabStop = true;
            this.rdbBarang.Text = "Per Barang";
            this.rdbBarang.UseVisualStyleBackColor = true;
            // 
            // rdbToko
            // 
            this.rdbToko.AutoSize = true;
            this.rdbToko.Location = new System.Drawing.Point(7, 17);
            this.rdbToko.Name = "rdbToko";
            this.rdbToko.Size = new System.Drawing.Size(81, 18);
            this.rdbToko.TabIndex = 0;
            this.rdbToko.TabStop = true;
            this.rdbToko.Text = "Per Toko";
            this.rdbToko.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbNetto);
            this.groupBox2.Controls.Add(this.rdbBruto);
            this.groupBox2.Location = new System.Drawing.Point(137, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 68);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // rdbNetto
            // 
            this.rdbNetto.AutoSize = true;
            this.rdbNetto.Location = new System.Drawing.Point(7, 40);
            this.rdbNetto.Name = "rdbNetto";
            this.rdbNetto.Size = new System.Drawing.Size(60, 18);
            this.rdbNetto.TabIndex = 1;
            this.rdbNetto.TabStop = true;
            this.rdbNetto.Text = "Netto";
            this.rdbNetto.UseVisualStyleBackColor = true;
            // 
            // rdbBruto
            // 
            this.rdbBruto.AutoSize = true;
            this.rdbBruto.Location = new System.Drawing.Point(6, 15);
            this.rdbBruto.Name = "rdbBruto";
            this.rdbBruto.Size = new System.Drawing.Size(60, 18);
            this.rdbBruto.TabIndex = 0;
            this.rdbBruto.TabStop = true;
            this.rdbBruto.Text = "Bruto";
            this.rdbBruto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cabang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nama Gudang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kode Gudang";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nama Barang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "Pilihan Rekap";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Pilihan Harga";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "Kelompok";
            // 
            // txtKelompok
            // 
            this.txtKelompok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKelompok.Location = new System.Drawing.Point(127, 200);
            this.txtKelompok.MaxLength = 3;
            this.txtKelompok.Name = "txtKelompok";
            this.txtKelompok.Size = new System.Drawing.Size(48, 20);
            this.txtKelompok.TabIndex = 3;
            // 
            // cabangComboBox1
            // 
            this.cabangComboBox1.CabangID = "";
            this.cabangComboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cabangComboBox1.DisplayMember = "Concatenated";
            this.cabangComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cabangComboBox1.Font = new System.Drawing.Font("Courier New", 8F);
            this.cabangComboBox1.FormattingEnabled = true;
            this.cabangComboBox1.Location = new System.Drawing.Point(127, 102);
            this.cabangComboBox1.Name = "cabangComboBox1";
            this.cabangComboBox1.Size = new System.Drawing.Size(180, 22);
            this.cabangComboBox1.TabIndex = 1;
            this.cabangComboBox1.ValueMember = "CabangID";
            // 
            // frmRptLapBrgA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(595, 523);
            this.Controls.Add(this.cabangComboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKelompok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNamaStok);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookupGudang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptLapBrgA";
            this.Text = "Laporan Barang -  A";
            this.Title = "Laporan Barang -  A";
            this.Load += new System.EventHandler(this.frmRptLapBrgA_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lookupGudang, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNamaStok, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtKelompok, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cabangComboBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.RangeDateBox rangeDateBox1;
        private ISA.Toko.Controls.LookupGudang lookupGudang;
        private ISA.Toko.Controls.CommonTextBox txtNamaStok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbType;
        private System.Windows.Forms.RadioButton rdbBarang;
        private System.Windows.Forms.RadioButton rdbToko;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbNetto;
        private System.Windows.Forms.RadioButton rdbBruto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ISA.Toko.Controls.CommonTextBox txtKelompok;
        private ISA.Toko.Controls.CabangComboBox cabangComboBox1;
    }
}
