namespace ISA.Finance.Hutang
{
    partial class frmPembayaranHutangHI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembayaranHutangHI));
            this.txtSaldoIdr = new ISA.Controls.NumericTextBox();
            this.txtHIDR = new ISA.Controls.NumericTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoInvoice = new ISA.Controls.CommonTextBox();
            this.txtTglInvoice = new ISA.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboPerusahaan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKet = new ISA.Controls.CommonTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.GBBukti = new System.Windows.Forms.GroupBox();
            this.txtNoBuktiKasir = new ISA.Controls.CommonTextBox();
            this.LableKas = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtNoPembayaran = new ISA.Controls.CommonTextBox();
            this.lblJnsPmb = new System.Windows.Forms.Label();
            this.cboJenisPembayaran = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTglPembayaran = new ISA.Controls.DateTextBox();
            this.txtTglRelasi = new ISA.Controls.DateTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPmbKasirIDR = new ISA.Controls.NumericTextBox();
            this.txtIden = new ISA.Controls.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.GBBukti.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSaldoIdr
            // 
            this.txtSaldoIdr.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtSaldoIdr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoIdr.Format = "N2";
            this.txtSaldoIdr.Location = new System.Drawing.Point(758, 79);
            this.txtSaldoIdr.Name = "txtSaldoIdr";
            this.txtSaldoIdr.ReadOnly = true;
            this.txtSaldoIdr.Size = new System.Drawing.Size(192, 20);
            this.txtSaldoIdr.TabIndex = 166;
            this.txtSaldoIdr.Text = "0,00";
            this.txtSaldoIdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHIDR
            // 
            this.txtHIDR.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtHIDR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHIDR.Format = "N2";
            this.txtHIDR.Location = new System.Drawing.Point(758, 50);
            this.txtHIDR.Name = "txtHIDR";
            this.txtHIDR.ReadOnly = true;
            this.txtHIDR.Size = new System.Drawing.Size(191, 20);
            this.txtHIDR.TabIndex = 165;
            this.txtHIDR.Text = "0,00";
            this.txtHIDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(599, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 14);
            this.label18.TabIndex = 170;
            this.label18.Text = "Saldo Hutang (IDR)";
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 14);
            this.label5.TabIndex = 169;
            this.label5.Text = "Nominal Hutang (IDR)";
            // 
            // txtNoInvoice
            // 
            this.txtNoInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoInvoice.Location = new System.Drawing.Point(133, 51);
            this.txtNoInvoice.Name = "txtNoInvoice";
            this.txtNoInvoice.ReadOnly = true;
            this.txtNoInvoice.Size = new System.Drawing.Size(182, 20);
            this.txtNoInvoice.TabIndex = 163;
            this.txtNoInvoice.TabStop = false;
            // 
            // txtTglInvoice
            // 
            this.txtTglInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTglInvoice.Location = new System.Drawing.Point(133, 80);
            this.txtTglInvoice.Name = "txtTglInvoice";
            this.txtTglInvoice.ReadOnly = true;
            this.txtTglInvoice.Size = new System.Drawing.Size(182, 20);
            this.txtTglInvoice.TabIndex = 164;
            this.txtTglInvoice.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 168;
            this.label2.Text = "Tgl Invoice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 167;
            this.label1.Text = "No. Invoice";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(22, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(934, 2);
            this.label19.TabIndex = 171;
            this.label19.Text = "line";
            // 
            // cboPerusahaan
            // 
            this.cboPerusahaan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerusahaan.FormattingEnabled = true;
            this.cboPerusahaan.Location = new System.Drawing.Point(209, 225);
            this.cboPerusahaan.Name = "cboPerusahaan";
            this.cboPerusahaan.Size = new System.Drawing.Size(264, 22);
            this.cboPerusahaan.TabIndex = 198;
            this.cboPerusahaan.SelectedIndexChanged += new System.EventHandler(this.cboPerusahaan_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 14);
            this.label3.TabIndex = 206;
            this.label3.Text = "Pembayaran untuk Perusahaan";
            // 
            // txtKet
            // 
            this.txtKet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKet.Location = new System.Drawing.Point(208, 311);
            this.txtKet.Multiline = true;
            this.txtKet.Name = "txtKet";
            this.txtKet.Size = new System.Drawing.Size(330, 40);
            this.txtKet.TabIndex = 199;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 311);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 205;
            this.label12.Text = "Keterangan";
            // 
            // GBBukti
            // 
            this.GBBukti.Controls.Add(this.txtNoBuktiKasir);
            this.GBBukti.Controls.Add(this.LableKas);
            this.GBBukti.Controls.Add(this.btnCari);
            this.GBBukti.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GBBukti.Location = new System.Drawing.Point(36, 250);
            this.GBBukti.Name = "GBBukti";
            this.GBBukti.Padding = new System.Windows.Forms.Padding(1);
            this.GBBukti.Size = new System.Drawing.Size(450, 52);
            this.GBBukti.TabIndex = 204;
            this.GBBukti.TabStop = false;
            // 
            // txtNoBuktiKasir
            // 
            this.txtNoBuktiKasir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoBuktiKasir.Location = new System.Drawing.Point(172, 17);
            this.txtNoBuktiKasir.Name = "txtNoBuktiKasir";
            this.txtNoBuktiKasir.ReadOnly = true;
            this.txtNoBuktiKasir.Size = new System.Drawing.Size(187, 20);
            this.txtNoBuktiKasir.TabIndex = 0;
            this.txtNoBuktiKasir.TabStop = false;
            // 
            // LableKas
            // 
            this.LableKas.AutoSize = true;
            this.LableKas.Location = new System.Drawing.Point(0, 16);
            this.LableKas.Name = "LableKas";
            this.LableKas.Size = new System.Drawing.Size(58, 14);
            this.LableKas.TabIndex = 108;
            this.LableKas.Text = "No. Bukti ";
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(370, 15);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(36, 24);
            this.btnCari.TabIndex = 104;
            this.btnCari.Text = "...";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtNoPembayaran
            // 
            this.txtNoPembayaran.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoPembayaran.Location = new System.Drawing.Point(208, 136);
            this.txtNoPembayaran.Name = "txtNoPembayaran";
            this.txtNoPembayaran.ReadOnly = true;
            this.txtNoPembayaran.Size = new System.Drawing.Size(264, 20);
            this.txtNoPembayaran.TabIndex = 194;
            this.txtNoPembayaran.TabStop = false;
            // 
            // lblJnsPmb
            // 
            this.lblJnsPmb.AutoSize = true;
            this.lblJnsPmb.Location = new System.Drawing.Point(26, 194);
            this.lblJnsPmb.Name = "lblJnsPmb";
            this.lblJnsPmb.Size = new System.Drawing.Size(108, 14);
            this.lblJnsPmb.TabIndex = 203;
            this.lblJnsPmb.Text = "Jenis Pembayaran";
            // 
            // cboJenisPembayaran
            // 
            this.cboJenisPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJenisPembayaran.FormattingEnabled = true;
            this.cboJenisPembayaran.Items.AddRange(new object[] {
            "",
            "Normal",
            "Uang Muka",
            "Potongan",
            "Sisa Invoice",
            "Retur Beli",
            "Koreksi Beli"});
            this.cboJenisPembayaran.Location = new System.Drawing.Point(209, 193);
            this.cboJenisPembayaran.Name = "cboJenisPembayaran";
            this.cboJenisPembayaran.Size = new System.Drawing.Size(158, 22);
            this.cboJenisPembayaran.TabIndex = 197;
            this.cboJenisPembayaran.SelectedIndexChanged += new System.EventHandler(this.cboJenisPembayaran_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 202;
            this.label7.Text = "Tgl Transaksi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 14);
            this.label6.TabIndex = 201;
            this.label6.Text = "No. Pembayaran";
            // 
            // txtTglPembayaran
            // 
            this.txtTglPembayaran.DateValue = null;
            this.txtTglPembayaran.Location = new System.Drawing.Point(208, 162);
            this.txtTglPembayaran.MaxLength = 10;
            this.txtTglPembayaran.Name = "txtTglPembayaran";
            this.txtTglPembayaran.ReadOnly = true;
            this.txtTglPembayaran.Size = new System.Drawing.Size(80, 20);
            this.txtTglPembayaran.TabIndex = 195;
            this.txtTglPembayaran.TabStop = false;
            // 
            // txtTglRelasi
            // 
            this.txtTglRelasi.DateValue = null;
            this.txtTglRelasi.Location = new System.Drawing.Point(392, 163);
            this.txtTglRelasi.MaxLength = 10;
            this.txtTglRelasi.Name = "txtTglRelasi";
            this.txtTglRelasi.Size = new System.Drawing.Size(80, 20);
            this.txtTglRelasi.TabIndex = 196;
            this.txtTglRelasi.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 14);
            this.label9.TabIndex = 200;
            this.label9.Text = "Tgl Identifikasi";
            // 
            // txtPmbKasirIDR
            // 
            this.txtPmbKasirIDR.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtPmbKasirIDR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPmbKasirIDR.Format = "N2";
            this.txtPmbKasirIDR.Location = new System.Drawing.Point(758, 136);
            this.txtPmbKasirIDR.Name = "txtPmbKasirIDR";
            this.txtPmbKasirIDR.ReadOnly = true;
            this.txtPmbKasirIDR.Size = new System.Drawing.Size(135, 20);
            this.txtPmbKasirIDR.TabIndex = 207;
            this.txtPmbKasirIDR.Text = "0,00";
            this.txtPmbKasirIDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIden
            // 
            this.txtIden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIden.Format = "N2";
            this.txtIden.Location = new System.Drawing.Point(758, 162);
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(135, 20);
            this.txtIden.TabIndex = 208;
            this.txtIden.Text = "0,00";
            this.txtIden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(599, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 14);
            this.label13.TabIndex = 210;
            this.label13.Text = "Identifikasi Pembayaran";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(599, 139);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(134, 14);
            this.label22.TabIndex = 209;
            this.label22.Text = "Pembayaran Kasir (IDR)";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(500, 411);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 212;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(382, 411);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 211;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmPembayaranHutangHI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(981, 478);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtPmbKasirIDR);
            this.Controls.Add(this.txtIden);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cboPerusahaan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.GBBukti);
            this.Controls.Add(this.txtNoPembayaran);
            this.Controls.Add(this.lblJnsPmb);
            this.Controls.Add(this.cboJenisPembayaran);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTglPembayaran);
            this.Controls.Add(this.txtTglRelasi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtSaldoIdr);
            this.Controls.Add(this.txtHIDR);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoInvoice);
            this.Controls.Add(this.txtTglInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPembayaranHutangHI";
            this.Text = "Pembayaran Hutang Antar PT";
            this.Title = "Pembayaran Hutang Antar PT";
            this.Load += new System.EventHandler(this.frmPembayaranHutangHI_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTglInvoice, 0);
            this.Controls.SetChildIndex(this.txtNoInvoice, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtHIDR, 0);
            this.Controls.SetChildIndex(this.txtSaldoIdr, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtTglRelasi, 0);
            this.Controls.SetChildIndex(this.txtTglPembayaran, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cboJenisPembayaran, 0);
            this.Controls.SetChildIndex(this.lblJnsPmb, 0);
            this.Controls.SetChildIndex(this.txtNoPembayaran, 0);
            this.Controls.SetChildIndex(this.GBBukti, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtKet, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboPerusahaan, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtIden, 0);
            this.Controls.SetChildIndex(this.txtPmbKasirIDR, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.GBBukti.ResumeLayout(false);
            this.GBBukti.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.NumericTextBox txtSaldoIdr;
        private ISA.Controls.NumericTextBox txtHIDR;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CommonTextBox txtNoInvoice;
        private ISA.Controls.CommonTextBox txtTglInvoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboPerusahaan;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox txtKet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox GBBukti;
        private ISA.Controls.CommonTextBox txtNoBuktiKasir;
        private System.Windows.Forms.Label LableKas;
        private System.Windows.Forms.Button btnCari;
        private ISA.Controls.CommonTextBox txtNoPembayaran;
        private System.Windows.Forms.Label lblJnsPmb;
        private System.Windows.Forms.ComboBox cboJenisPembayaran;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.DateTextBox txtTglPembayaran;
        private ISA.Controls.DateTextBox txtTglRelasi;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.NumericTextBox txtPmbKasirIDR;
        private ISA.Controls.NumericTextBox txtIden;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label22;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
    }
}
