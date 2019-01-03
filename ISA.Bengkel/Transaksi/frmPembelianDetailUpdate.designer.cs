namespace ISA.Bengkel.Transaksi
{
    partial class frmPembelianDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembelianDetailUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSatuan = new ISA.Controls.CommonTextBox();
            this.txtQtyNota = new ISA.Controls.NumericTextBox();
            this.txtIsiKoli = new ISA.Controls.NumericTextBox();
            this.txtCatatan = new ISA.Controls.CommonTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtQtyTerima = new ISA.Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHargaSatuan = new ISA.Controls.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJmlBeli = new ISA.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBarcode = new ISA.Controls.CommonTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDisc1 = new ISA.Controls.NumericTextBox();
            this.txtDisc2 = new ISA.Controls.NumericTextBox();
            this.txtDisc3 = new ISA.Controls.NumericTextBox();
            this.txtPotongan = new ISA.Controls.NumericTextBox();
            this.txtJmlNetto = new ISA.Controls.NumericTextBox();
            this.txtPpn = new ISA.Controls.NumericTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lkpStokBkl = new ISA.Bengkel.Lookup.LookupStokBkl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Satuan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Qty. Nota";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Catatan";
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(119, 151);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(40, 20);
            this.txtSatuan.TabIndex = 2;
            this.txtSatuan.TabStop = false;
            // 
            // txtQtyNota
            // 
            this.txtQtyNota.Location = new System.Drawing.Point(119, 177);
            this.txtQtyNota.MaxLength = 5;
            this.txtQtyNota.Name = "txtQtyNota";
            this.txtQtyNota.Size = new System.Drawing.Size(80, 20);
            this.txtQtyNota.TabIndex = 4;
            this.txtQtyNota.Text = "0";
            this.txtQtyNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyNota.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyTambahan_Validating);
            // 
            // txtIsiKoli
            // 
            this.txtIsiKoli.Enabled = false;
            this.txtIsiKoli.Location = new System.Drawing.Point(243, 151);
            this.txtIsiKoli.Name = "txtIsiKoli";
            this.txtIsiKoli.ReadOnly = true;
            this.txtIsiKoli.Size = new System.Drawing.Size(80, 20);
            this.txtIsiKoli.TabIndex = 3;
            this.txtIsiKoli.TabStop = false;
            this.txtIsiKoli.Text = "0";
            this.txtIsiKoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIsiKoli.Visible = false;
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(119, 333);
            this.txtCatatan.MaxLength = 40;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(280, 20);
            this.txtCatatan.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 14);
            this.label10.TabIndex = 25;
            this.label10.Text = "1 Koli";
            this.label10.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(329, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "Pcs";
            this.label13.Visible = false;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(407, 383);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 16;
            this.cmdCLOSE.TabStop = false;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(301, 383);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 15;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtQtyTerima
            // 
            this.txtQtyTerima.Location = new System.Drawing.Point(331, 180);
            this.txtQtyTerima.MaxLength = 5;
            this.txtQtyTerima.Name = "txtQtyTerima";
            this.txtQtyTerima.Size = new System.Drawing.Size(80, 20);
            this.txtQtyTerima.TabIndex = 5;
            this.txtQtyTerima.Text = "0";
            this.txtQtyTerima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyTerima.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "Qty. Terima";
            this.label1.Visible = false;
            // 
            // txtHargaSatuan
            // 
            this.txtHargaSatuan.Location = new System.Drawing.Point(119, 203);
            this.txtHargaSatuan.MaxLength = 10;
            this.txtHargaSatuan.Name = "txtHargaSatuan";
            this.txtHargaSatuan.Size = new System.Drawing.Size(80, 20);
            this.txtHargaSatuan.TabIndex = 6;
            this.txtHargaSatuan.Text = "0";
            this.txtHargaSatuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaSatuan.Validating += new System.ComponentModel.CancelEventHandler(this.txtHargaSatuan_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 36;
            this.label4.Text = "Harga Satuan";
            // 
            // txtJmlBeli
            // 
            this.txtJmlBeli.Enabled = false;
            this.txtJmlBeli.Location = new System.Drawing.Point(119, 229);
            this.txtJmlBeli.MaxLength = 5;
            this.txtJmlBeli.Name = "txtJmlBeli";
            this.txtJmlBeli.ReadOnly = true;
            this.txtJmlBeli.Size = new System.Drawing.Size(80, 20);
            this.txtJmlBeli.TabIndex = 7;
            this.txtJmlBeli.Text = "0";
            this.txtJmlBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 38;
            this.label6.Text = "Jumlah Beli";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 14);
            this.label7.TabIndex = 46;
            this.label7.Text = "Disc 3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "Disc 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 14);
            this.label11.TabIndex = 42;
            this.label11.Text = "Disc 1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(532, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 14);
            this.label12.TabIndex = 48;
            this.label12.Text = "Potongan";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 310);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 14);
            this.label14.TabIndex = 51;
            this.label14.Text = "Jumlah Netto";
            // 
            // txtBarcode
            // 
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Location = new System.Drawing.Point(119, 69);
            this.txtBarcode.MaxLength = 40;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(204, 20);
            this.txtBarcode.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 14);
            this.label15.TabIndex = 53;
            this.label15.Text = "Barcode";
            // 
            // txtDisc1
            // 
            this.txtDisc1.Location = new System.Drawing.Point(119, 255);
            this.txtDisc1.MaxLength = 5;
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.Size = new System.Drawing.Size(80, 20);
            this.txtDisc1.TabIndex = 8;
            this.txtDisc1.Text = "0";
            this.txtDisc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc1.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc1_Validating);
            // 
            // txtDisc2
            // 
            this.txtDisc2.Location = new System.Drawing.Point(252, 255);
            this.txtDisc2.MaxLength = 5;
            this.txtDisc2.Name = "txtDisc2";
            this.txtDisc2.Size = new System.Drawing.Size(80, 20);
            this.txtDisc2.TabIndex = 9;
            this.txtDisc2.Text = "0";
            this.txtDisc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc2.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc2_Validating);
            // 
            // txtDisc3
            // 
            this.txtDisc3.Location = new System.Drawing.Point(391, 255);
            this.txtDisc3.MaxLength = 5;
            this.txtDisc3.Name = "txtDisc3";
            this.txtDisc3.Size = new System.Drawing.Size(80, 20);
            this.txtDisc3.TabIndex = 10;
            this.txtDisc3.Text = "0";
            this.txtDisc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc3.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc3_Validating);
            // 
            // txtPotongan
            // 
            this.txtPotongan.Location = new System.Drawing.Point(597, 255);
            this.txtPotongan.MaxLength = 5;
            this.txtPotongan.Name = "txtPotongan";
            this.txtPotongan.Size = new System.Drawing.Size(80, 20);
            this.txtPotongan.TabIndex = 11;
            this.txtPotongan.Text = "0";
            this.txtPotongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPotongan.Validating += new System.ComponentModel.CancelEventHandler(this.txtPotongan_Validating);
            // 
            // txtJmlNetto
            // 
            this.txtJmlNetto.BackColor = System.Drawing.SystemColors.Control;
            this.txtJmlNetto.Enabled = false;
            this.txtJmlNetto.Location = new System.Drawing.Point(119, 307);
            this.txtJmlNetto.MaxLength = 5;
            this.txtJmlNetto.Name = "txtJmlNetto";
            this.txtJmlNetto.Size = new System.Drawing.Size(80, 20);
            this.txtJmlNetto.TabIndex = 13;
            this.txtJmlNetto.TabStop = false;
            this.txtJmlNetto.Text = "0";
            this.txtJmlNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPpn
            // 
            this.txtPpn.Location = new System.Drawing.Point(119, 281);
            this.txtPpn.MaxLength = 5;
            this.txtPpn.Name = "txtPpn";
            this.txtPpn.Size = new System.Drawing.Size(80, 20);
            this.txtPpn.TabIndex = 12;
            this.txtPpn.Text = "0";
            this.txtPpn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPpn.Validating += new System.ComponentModel.CancelEventHandler(this.txtPpn_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 284);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 14);
            this.label16.TabIndex = 55;
            this.label16.Text = "Ppn";
            // 
            // lkpStokBkl
            // 
            this.lkpStokBkl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lkpStokBkl.KodeStokBkl = "[CODE]";
            this.lkpStokBkl.Location = new System.Drawing.Point(116, 92);
            this.lkpStokBkl.LookUpType = ISA.Bengkel.Lookup.LookupStokBkl.EnumLookUpType.Normal;
            this.lkpStokBkl.NamaStokBkl = "";
            this.lkpStokBkl.Name = "lkpStokBkl";
            this.lkpStokBkl.RowStokBkl = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkpStokBkl.Satuan = null;
            this.lkpStokBkl.Size = new System.Drawing.Size(665, 54);
            this.lkpStokBkl.TabIndex = 1;
            // 
            // frmPembelianDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(803, 441);
            this.Controls.Add(this.lkpStokBkl);
            this.Controls.Add(this.txtPpn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtJmlNetto);
            this.Controls.Add(this.txtPotongan);
            this.Controls.Add(this.txtDisc3);
            this.Controls.Add(this.txtDisc2);
            this.Controls.Add(this.txtDisc1);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtJmlBeli);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHargaSatuan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQtyTerima);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.txtIsiKoli);
            this.Controls.Add(this.txtQtyNota);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormID = "BKL0122";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPembelianDetailUpdate";
            this.Text = "BKL0122 - Pembelian Detail";
            this.Title = "Pembelian Detail";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPembelianDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPembelianDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtSatuan, 0);
            this.Controls.SetChildIndex(this.txtQtyNota, 0);
            this.Controls.SetChildIndex(this.txtIsiKoli, 0);
            this.Controls.SetChildIndex(this.txtCatatan, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtQtyTerima, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtHargaSatuan, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtJmlBeli, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.txtDisc1, 0);
            this.Controls.SetChildIndex(this.txtDisc2, 0);
            this.Controls.SetChildIndex(this.txtDisc3, 0);
            this.Controls.SetChildIndex(this.txtPotongan, 0);
            this.Controls.SetChildIndex(this.txtJmlNetto, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtPpn, 0);
            this.Controls.SetChildIndex(this.lkpStokBkl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.CommonTextBox txtSatuan;
        private ISA.Controls.NumericTextBox txtQtyNota;
        private ISA.Controls.NumericTextBox txtIsiKoli;
        private ISA.Controls.CommonTextBox txtCatatan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controls.NumericTextBox txtJmlBeli;
        private System.Windows.Forms.Label label6;
        private Controls.NumericTextBox txtHargaSatuan;
        private System.Windows.Forms.Label label4;
        private Controls.NumericTextBox txtQtyTerima;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private Controls.NumericTextBox txtPotongan;
        private Controls.NumericTextBox txtDisc3;
        private Controls.NumericTextBox txtDisc2;
        private Controls.NumericTextBox txtDisc1;
        private Controls.CommonTextBox txtBarcode;
        private System.Windows.Forms.Label label15;
        private Controls.NumericTextBox txtJmlNetto;
        private ISA.Controls.NumericTextBox txtPpn;
        private System.Windows.Forms.Label label16;
        private ISA.Bengkel.Lookup.LookupStokBkl lkpStokBkl;
    }
}
