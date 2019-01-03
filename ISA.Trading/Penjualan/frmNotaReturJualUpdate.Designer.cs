namespace ISA.Trading.Penjualan
{
    partial class frmNotaReturJualUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaReturJualUpdate));
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.txtKota = new ISA.Trading.Controls.CommonTextBox();
            this.txtAlamat = new ISA.Trading.Controls.CommonTextBox();
            this.cboPenerimaBrg = new System.Windows.Forms.ComboBox();
            this.txtNoMPR = new ISA.Trading.Controls.CommonTextBox();
            this.txtTglMPR = new ISA.Trading.Controls.DateTextBox();
            this.txtTglRQRetur = new ISA.Trading.Controls.DateTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTglGudang = new ISA.Trading.Controls.DateTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoNotaRetur = new ISA.Trading.Controls.CommonTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBagPenjualan = new ISA.Trading.Controls.CommonTextBox();
            this.txtNilaiRetur = new ISA.Trading.Controls.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNamaToko = new ISA.Trading.Controls.CommonTextBox();
            this.txtCabang1 = new ISA.Trading.Controls.CommonTextBox();
            this.txtCabang2 = new ISA.Trading.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(287, 444);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 14;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(163, 443);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(117, 43);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Enabled = false;
            this.txtKota.Location = new System.Drawing.Point(163, 377);
            this.txtKota.Name = "txtKota";
            this.txtKota.ReadOnly = true;
            this.txtKota.Size = new System.Drawing.Size(195, 20);
            this.txtKota.TabIndex = 11;
            // 
            // txtAlamat
            // 
            this.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat.Enabled = false;
            this.txtAlamat.Location = new System.Drawing.Point(163, 349);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(473, 20);
            this.txtAlamat.TabIndex = 10;
            // 
            // cboPenerimaBrg
            // 
            this.cboPenerimaBrg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPenerimaBrg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPenerimaBrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPenerimaBrg.FormattingEnabled = true;
            this.cboPenerimaBrg.Location = new System.Drawing.Point(163, 292);
            this.cboPenerimaBrg.Name = "cboPenerimaBrg";
            this.cboPenerimaBrg.Size = new System.Drawing.Size(177, 22);
            this.cboPenerimaBrg.TabIndex = 8;
            // 
            // txtNoMPR
            // 
            this.txtNoMPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoMPR.Enabled = false;
            this.txtNoMPR.Location = new System.Drawing.Point(163, 208);
            this.txtNoMPR.Name = "txtNoMPR";
            this.txtNoMPR.ReadOnly = true;
            this.txtNoMPR.Size = new System.Drawing.Size(79, 20);
            this.txtNoMPR.TabIndex = 5;
            // 
            // txtTglMPR
            // 
            this.txtTglMPR.DateValue = null;
            this.txtTglMPR.Enabled = false;
            this.txtTglMPR.Location = new System.Drawing.Point(163, 152);
            this.txtTglMPR.MaxLength = 10;
            this.txtTglMPR.Name = "txtTglMPR";
            this.txtTglMPR.ReadOnly = true;
            this.txtTglMPR.Size = new System.Drawing.Size(98, 20);
            this.txtTglMPR.TabIndex = 3;
            // 
            // txtTglRQRetur
            // 
            this.txtTglRQRetur.DateValue = null;
            this.txtTglRQRetur.Enabled = false;
            this.txtTglRQRetur.Location = new System.Drawing.Point(163, 124);
            this.txtTglRQRetur.MaxLength = 10;
            this.txtTglRQRetur.Name = "txtTglRQRetur";
            this.txtTglRQRetur.ReadOnly = true;
            this.txtTglRQRetur.Size = new System.Drawing.Size(98, 20);
            this.txtTglRQRetur.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 82;
            this.label7.Text = "Kota";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 14);
            this.label8.TabIndex = 81;
            this.label8.Text = "Alamat Pengirim";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 80;
            this.label9.Text = "Nama Toko";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 14);
            this.label4.TabIndex = 79;
            this.label4.Text = "Nama Penerima Brg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 78;
            this.label5.Text = "No Memo Retur";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 14);
            this.label6.TabIndex = 77;
            this.label6.Text = "Tgl Memo Retur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 76;
            this.label3.Text = "Tgl RQ Retur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 75;
            this.label2.Text = "C2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 74;
            this.label1.Text = "C1";
            // 
            // txtTglGudang
            // 
            this.txtTglGudang.DateValue = null;
            this.txtTglGudang.Enabled = false;
            this.txtTglGudang.Location = new System.Drawing.Point(163, 180);
            this.txtTglGudang.MaxLength = 10;
            this.txtTglGudang.Name = "txtTglGudang";
            this.txtTglGudang.ReadOnly = true;
            this.txtTglGudang.Size = new System.Drawing.Size(98, 20);
            this.txtTglGudang.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 14);
            this.label10.TabIndex = 94;
            this.label10.Text = "Tgl Masuk Gudang";
            // 
            // txtNoNotaRetur
            // 
            this.txtNoNotaRetur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoNotaRetur.Enabled = false;
            this.txtNoNotaRetur.Location = new System.Drawing.Point(163, 236);
            this.txtNoNotaRetur.Name = "txtNoNotaRetur";
            this.txtNoNotaRetur.ReadOnly = true;
            this.txtNoNotaRetur.Size = new System.Drawing.Size(79, 20);
            this.txtNoNotaRetur.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 96;
            this.label11.Text = "No Nota Retur";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 14);
            this.label12.TabIndex = 98;
            this.label12.Text = "Nama Bag Penjualan";
            // 
            // txtBagPenjualan
            // 
            this.txtBagPenjualan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBagPenjualan.Enabled = false;
            this.txtBagPenjualan.Location = new System.Drawing.Point(163, 264);
            this.txtBagPenjualan.Name = "txtBagPenjualan";
            this.txtBagPenjualan.ReadOnly = true;
            this.txtBagPenjualan.Size = new System.Drawing.Size(177, 20);
            this.txtBagPenjualan.TabIndex = 7;
            // 
            // txtNilaiRetur
            // 
            this.txtNilaiRetur.Enabled = false;
            this.txtNilaiRetur.Format = "#,##0.00";
            this.txtNilaiRetur.Location = new System.Drawing.Point(163, 405);
            this.txtNilaiRetur.Name = "txtNilaiRetur";
            this.txtNilaiRetur.ReadOnly = true;
            this.txtNilaiRetur.Size = new System.Drawing.Size(116, 20);
            this.txtNilaiRetur.TabIndex = 12;
            this.txtNilaiRetur.Text = "0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 408);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 14);
            this.label13.TabIndex = 101;
            this.label13.Text = "Nilai Retur Rp.";
            // 
            // txtNamaToko
            // 
            this.txtNamaToko.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaToko.Enabled = false;
            this.txtNamaToko.Location = new System.Drawing.Point(163, 321);
            this.txtNamaToko.Name = "txtNamaToko";
            this.txtNamaToko.ReadOnly = true;
            this.txtNamaToko.Size = new System.Drawing.Size(268, 20);
            this.txtNamaToko.TabIndex = 9;
            // 
            // txtCabang1
            // 
            this.txtCabang1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCabang1.Enabled = false;
            this.txtCabang1.Location = new System.Drawing.Point(163, 66);
            this.txtCabang1.Name = "txtCabang1";
            this.txtCabang1.ReadOnly = true;
            this.txtCabang1.Size = new System.Drawing.Size(41, 20);
            this.txtCabang1.TabIndex = 0;
            // 
            // txtCabang2
            // 
            this.txtCabang2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCabang2.Enabled = false;
            this.txtCabang2.Location = new System.Drawing.Point(163, 95);
            this.txtCabang2.Name = "txtCabang2";
            this.txtCabang2.ReadOnly = true;
            this.txtCabang2.Size = new System.Drawing.Size(41, 20);
            this.txtCabang2.TabIndex = 1;
            // 
            // frmNotaReturJualUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(672, 512);
            this.Controls.Add(this.txtCabang2);
            this.Controls.Add(this.txtCabang1);
            this.Controls.Add(this.txtNamaToko);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNilaiRetur);
            this.Controls.Add(this.txtBagPenjualan);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNoNotaRetur);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTglGudang);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.cboPenerimaBrg);
            this.Controls.Add(this.txtNoMPR);
            this.Controls.Add(this.txtTglMPR);
            this.Controls.Add(this.txtTglRQRetur);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNotaReturJualUpdate";
            this.Text = "Retur Jual (Nota)";
            this.Title = "Retur Jual (Nota)";
            this.Load += new System.EventHandler(this.frmNotaReturJualUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNotaReturJualUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtTglRQRetur, 0);
            this.Controls.SetChildIndex(this.txtTglMPR, 0);
            this.Controls.SetChildIndex(this.txtNoMPR, 0);
            this.Controls.SetChildIndex(this.cboPenerimaBrg, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtTglGudang, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtNoNotaRetur, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtBagPenjualan, 0);
            this.Controls.SetChildIndex(this.txtNilaiRetur, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtNamaToko, 0);
            this.Controls.SetChildIndex(this.txtCabang1, 0);
            this.Controls.SetChildIndex(this.txtCabang2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommonTextBox txtKota;
        private ISA.Trading.Controls.CommonTextBox txtAlamat;
        private System.Windows.Forms.ComboBox cboPenerimaBrg;
        private ISA.Trading.Controls.CommonTextBox txtNoMPR;
        private ISA.Trading.Controls.DateTextBox txtTglMPR;
        private ISA.Trading.Controls.DateTextBox txtTglRQRetur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.DateTextBox txtTglGudang;
        private System.Windows.Forms.Label label10;
        private ISA.Trading.Controls.CommonTextBox txtNoNotaRetur;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private ISA.Trading.Controls.CommonTextBox txtBagPenjualan;
        private ISA.Trading.Controls.NumericTextBox txtNilaiRetur;
        private System.Windows.Forms.Label label13;
        private ISA.Trading.Controls.CommonTextBox txtNamaToko;
        private ISA.Trading.Controls.CommonTextBox txtCabang1;
        private ISA.Trading.Controls.CommonTextBox txtCabang2;
    }
}
