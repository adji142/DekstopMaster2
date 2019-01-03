namespace ISA.Toko.Kasir
{
    partial class frmIndenSubDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndenSubDetailUpdate));
            this.cbNonPiut = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.tbNoBPP = new ISA.Controls.CommonTextBox();
            this.tbNoRegister = new ISA.Controls.CommonTextBox();
            this.tbTglBPP = new ISA.Controls.DateTextBox();
            this.tbTglKasir = new ISA.Controls.DateTextBox();
            this.tbSisaPiutang = new ISA.Controls.NumericTextBox();
            this.tbPembayaran = new ISA.Controls.NumericTextBox();
            this.tbTeidentifikasi = new ISA.Controls.NumericTextBox();
            this.tbTotalTagihan = new ISA.Controls.NumericTextBox();
            this.lookupToko = new ISA.Controls.LookupToko();
            this.tbNamaToko = new ISA.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbNonPiut
            // 
            this.cbNonPiut.AutoSize = true;
            this.cbNonPiut.Location = new System.Drawing.Point(142, 19);
            this.cbNonPiut.Name = "cbNonPiut";
            this.cbNonPiut.Size = new System.Drawing.Size(91, 18);
            this.cbNonPiut.TabIndex = 0;
            this.cbNonPiut.Text = "Non Piutang";
            this.cbNonPiut.UseVisualStyleBackColor = true;
            this.cbNonPiut.CheckedChanged += new System.EventHandler(this.cbNonPiut_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nama Toko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sisa Piutang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pembayaran Berjalan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total Tagihan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tgl. Kasir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "No. BPP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tgl. BPP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "No. Register";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 14);
            this.label9.TabIndex = 12;
            this.label9.Text = "Teridentifikasi";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(142, 293);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(248, 293);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tbNoBPP
            // 
            this.tbNoBPP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoBPP.Location = new System.Drawing.Point(142, 258);
            this.tbNoBPP.Name = "tbNoBPP";
            this.tbNoBPP.Size = new System.Drawing.Size(110, 20);
            this.tbNoBPP.TabIndex = 4;
            this.tbNoBPP.Leave += new System.EventHandler(this.tbNoBPP_Leave);
            // 
            // tbNoRegister
            // 
            this.tbNoRegister.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoRegister.Location = new System.Drawing.Point(372, 206);
            this.tbNoRegister.Name = "tbNoRegister";
            this.tbNoRegister.Size = new System.Drawing.Size(110, 20);
            this.tbNoRegister.TabIndex = 5;
            this.tbNoRegister.Leave += new System.EventHandler(this.tbNoRegister_Leave);
            // 
            // tbTglBPP
            // 
            this.tbTglBPP.DateValue = null;
            this.tbTglBPP.Location = new System.Drawing.Point(142, 232);
            this.tbTglBPP.MaxLength = 10;
            this.tbTglBPP.Name = "tbTglBPP";
            this.tbTglBPP.Size = new System.Drawing.Size(110, 20);
            this.tbTglBPP.TabIndex = 3;
            // 
            // tbTglKasir
            // 
            this.tbTglKasir.DateValue = null;
            this.tbTglKasir.Enabled = false;
            this.tbTglKasir.Location = new System.Drawing.Point(142, 206);
            this.tbTglKasir.MaxLength = 10;
            this.tbTglKasir.Name = "tbTglKasir";
            this.tbTglKasir.Size = new System.Drawing.Size(110, 20);
            this.tbTglKasir.TabIndex = 2;
            // 
            // tbSisaPiutang
            // 
            this.tbSisaPiutang.Enabled = false;
            this.tbSisaPiutang.Location = new System.Drawing.Point(142, 106);
            this.tbSisaPiutang.Name = "tbSisaPiutang";
            this.tbSisaPiutang.Size = new System.Drawing.Size(100, 20);
            this.tbSisaPiutang.TabIndex = 20;
            this.tbSisaPiutang.Text = "0";
            // 
            // tbPembayaran
            // 
            this.tbPembayaran.Enabled = false;
            this.tbPembayaran.Location = new System.Drawing.Point(142, 132);
            this.tbPembayaran.Name = "tbPembayaran";
            this.tbPembayaran.Size = new System.Drawing.Size(100, 20);
            this.tbPembayaran.TabIndex = 21;
            this.tbPembayaran.Text = "0";
            // 
            // tbTeidentifikasi
            // 
            this.tbTeidentifikasi.Location = new System.Drawing.Point(372, 232);
            this.tbTeidentifikasi.Name = "tbTeidentifikasi";
            this.tbTeidentifikasi.Size = new System.Drawing.Size(110, 20);
            this.tbTeidentifikasi.TabIndex = 6;
            this.tbTeidentifikasi.Text = "0";
            // 
            // tbTotalTagihan
            // 
            this.tbTotalTagihan.Enabled = false;
            this.tbTotalTagihan.Location = new System.Drawing.Point(142, 158);
            this.tbTotalTagihan.Name = "tbTotalTagihan";
            this.tbTotalTagihan.Size = new System.Drawing.Size(100, 20);
            this.tbTotalTagihan.TabIndex = 23;
            this.tbTotalTagihan.Text = "0";
            // 
            // lookupToko
            // 
            this.lookupToko.Alamat = null;
            this.lookupToko.Catatan = "";
            this.lookupToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko.Grade = "";
            this.lookupToko.HariKirim = 0;
            this.lookupToko.HariSales = 0;
            this.lookupToko.KodeToko = "[CODE]";
            this.lookupToko.Kota = null;
            this.lookupToko.Location = new System.Drawing.Point(139, 50);
            this.lookupToko.LookUpType = ISA.Controls.LookupToko.EnumLookUpType.All;
            this.lookupToko.NamaToko = "";
            this.lookupToko.Name = "lookupToko";
            this.lookupToko.Pasif = false;
            this.lookupToko.Penanggungjawab = "";
            this.lookupToko.Plafon = 0;
            this.lookupToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko.Size = new System.Drawing.Size(300, 54);
            this.lookupToko.TabIndex = 1;
            this.lookupToko.Telp = "";
            this.lookupToko.TokoID = null;
            this.lookupToko.WilID = null;
            this.lookupToko.SelectData += new System.EventHandler(this.lookupToko_SelectData);
            // 
            // tbNamaToko
            // 
            this.tbNamaToko.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNamaToko.Location = new System.Drawing.Point(142, 52);
            this.tbNamaToko.Name = "tbNamaToko";
            this.tbNamaToko.Size = new System.Drawing.Size(259, 20);
            this.tbNamaToko.TabIndex = 1;
            this.tbNamaToko.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cbNonPiut);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNamaToko);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lookupToko);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbTotalTagihan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbTeidentifikasi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbPembayaran);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbSisaPiutang);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbTglKasir);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.tbTglBPP);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Controls.Add(this.tbNoRegister);
            this.groupBox1.Controls.Add(this.tbNoBPP);
            this.groupBox1.Location = new System.Drawing.Point(75, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 351);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // frmIndenSubDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(691, 432);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmIndenSubDetailUpdate";
            this.Text = "Penerimaan Uang Sub-Detail Update";
            this.Title = "Penerimaan Uang Sub-Detail Update";
            this.Load += new System.EventHandler(this.frmIndenSubDetailUpdate_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNonPiut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommonTextBox tbNoBPP;
        private ISA.Controls.CommonTextBox tbNoRegister;
        private ISA.Controls.DateTextBox tbTglBPP;
        private ISA.Controls.DateTextBox tbTglKasir;
        private ISA.Controls.NumericTextBox tbSisaPiutang;
        private ISA.Controls.NumericTextBox tbPembayaran;
        private ISA.Controls.NumericTextBox tbTeidentifikasi;
        private ISA.Controls.NumericTextBox tbTotalTagihan;
        private ISA.Controls.LookupToko lookupToko;
        private ISA.Controls.CommonTextBox tbNamaToko;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
