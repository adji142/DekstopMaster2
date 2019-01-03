namespace ISA.Bengkel.Transaksi
{
    partial class frmPembelianUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembelianUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJmlBeli = new ISA.Controls.NumericTextBox();
            this.txtDisc1 = new ISA.Controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDisc2 = new ISA.Controls.NumericTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDisc3 = new ISA.Controls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtJWKredit = new ISA.Controls.NumericTextBox();
            this.txtExpedisi = new ISA.Controls.NumericTextBox();
            this.txtPPn = new ISA.Controls.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCatatan = new ISA.Controls.CommonTextBox();
            this.dtpTglNota = new System.Windows.Forms.DateTimePicker();
            this.dtpTglTerima = new System.Windows.Forms.DateTimePicker();
            this.txtNoNota = new ISA.Controls.CommonTextBox();
            this.txtJmlNetto = new ISA.Controls.NumericTextBox();
            this.txtPemasok = new ISA.Controls.CommonTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPemasokID = new ISA.Controls.CommonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "NO. NOTA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "TGL. TERIMA";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(323, 374);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 15;
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
            this.cmdSAVE.Location = new System.Drawing.Point(194, 374);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 14;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(424, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "TGL. NOTA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(424, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "JW. KREDIT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "EXPEDISI";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "JML. BELI";
            // 
            // txtJmlBeli
            // 
            this.txtJmlBeli.Enabled = false;
            this.txtJmlBeli.Location = new System.Drawing.Point(136, 178);
            this.txtJmlBeli.Name = "txtJmlBeli";
            this.txtJmlBeli.ReadOnly = true;
            this.txtJmlBeli.Size = new System.Drawing.Size(100, 20);
            this.txtJmlBeli.TabIndex = 7;
            this.txtJmlBeli.Text = "0";
            this.txtJmlBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDisc1
            // 
            this.txtDisc1.Enabled = false;
            this.txtDisc1.Location = new System.Drawing.Point(136, 201);
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.ReadOnly = true;
            this.txtDisc1.Size = new System.Drawing.Size(60, 20);
            this.txtDisc1.TabIndex = 8;
            this.txtDisc1.Text = "0";
            this.txtDisc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "DISC 1";
            // 
            // txtDisc2
            // 
            this.txtDisc2.Enabled = false;
            this.txtDisc2.Location = new System.Drawing.Point(272, 201);
            this.txtDisc2.Name = "txtDisc2";
            this.txtDisc2.ReadOnly = true;
            this.txtDisc2.Size = new System.Drawing.Size(60, 20);
            this.txtDisc2.TabIndex = 9;
            this.txtDisc2.Text = "0";
            this.txtDisc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(225, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 14);
            this.label9.TabIndex = 35;
            this.label9.Text = "DISC 2";
            // 
            // txtDisc3
            // 
            this.txtDisc3.Enabled = false;
            this.txtDisc3.Location = new System.Drawing.Point(406, 201);
            this.txtDisc3.Name = "txtDisc3";
            this.txtDisc3.ReadOnly = true;
            this.txtDisc3.Size = new System.Drawing.Size(60, 20);
            this.txtDisc3.TabIndex = 10;
            this.txtDisc3.Text = "0";
            this.txtDisc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 14);
            this.label10.TabIndex = 37;
            this.label10.Text = "DISC 3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 14);
            this.label11.TabIndex = 39;
            this.label11.Text = "JML. NETTO";
            // 
            // txtJWKredit
            // 
            this.txtJWKredit.Location = new System.Drawing.Point(494, 97);
            this.txtJWKredit.Name = "txtJWKredit";
            this.txtJWKredit.Size = new System.Drawing.Size(111, 20);
            this.txtJWKredit.TabIndex = 3;
            this.txtJWKredit.Text = "0";
            this.txtJWKredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExpedisi
            // 
            this.txtExpedisi.Location = new System.Drawing.Point(494, 123);
            this.txtExpedisi.Name = "txtExpedisi";
            this.txtExpedisi.Size = new System.Drawing.Size(111, 20);
            this.txtExpedisi.TabIndex = 4;
            this.txtExpedisi.Text = "0";
            this.txtExpedisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpedisi.Visible = false;
            // 
            // txtPPn
            // 
            this.txtPPn.Enabled = false;
            this.txtPPn.Location = new System.Drawing.Point(136, 224);
            this.txtPPn.Name = "txtPPn";
            this.txtPPn.ReadOnly = true;
            this.txtPPn.Size = new System.Drawing.Size(60, 20);
            this.txtPPn.TabIndex = 11;
            this.txtPPn.Text = "0";
            this.txtPPn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 14);
            this.label12.TabIndex = 45;
            this.label12.Text = "PPn";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 282);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 47;
            this.label13.Text = "CATATAN";
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(136, 279);
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(468, 57);
            this.txtCatatan.TabIndex = 13;
            // 
            // dtpTglNota
            // 
            this.dtpTglNota.CustomFormat = "dd MMM yyyy";
            this.dtpTglNota.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTglNota.Location = new System.Drawing.Point(494, 71);
            this.dtpTglNota.Name = "dtpTglNota";
            this.dtpTglNota.Size = new System.Drawing.Size(110, 20);
            this.dtpTglNota.TabIndex = 1;
            // 
            // dtpTglTerima
            // 
            this.dtpTglTerima.CustomFormat = "dd MMM yyyy";
            this.dtpTglTerima.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTglTerima.Location = new System.Drawing.Point(136, 99);
            this.dtpTglTerima.Name = "dtpTglTerima";
            this.dtpTglTerima.Size = new System.Drawing.Size(110, 20);
            this.dtpTglTerima.TabIndex = 2;
            // 
            // txtNoNota
            // 
            this.txtNoNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoNota.Enabled = false;
            this.txtNoNota.Location = new System.Drawing.Point(136, 71);
            this.txtNoNota.Name = "txtNoNota";
            this.txtNoNota.ReadOnly = true;
            this.txtNoNota.Size = new System.Drawing.Size(110, 20);
            this.txtNoNota.TabIndex = 0;
            this.txtNoNota.TabStop = false;
            // 
            // txtJmlNetto
            // 
            this.txtJmlNetto.BackColor = System.Drawing.SystemColors.Control;
            this.txtJmlNetto.Enabled = false;
            this.txtJmlNetto.Location = new System.Drawing.Point(136, 247);
            this.txtJmlNetto.Name = "txtJmlNetto";
            this.txtJmlNetto.Size = new System.Drawing.Size(100, 20);
            this.txtJmlNetto.TabIndex = 12;
            this.txtJmlNetto.Text = "0";
            this.txtJmlNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPemasok
            // 
            this.txtPemasok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPemasok.Location = new System.Drawing.Point(136, 146);
            this.txtPemasok.Name = "txtPemasok";
            this.txtPemasok.Size = new System.Drawing.Size(237, 20);
            this.txtPemasok.TabIndex = 5;
            this.txtPemasok.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPemasok_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 14);
            this.label14.TabIndex = 54;
            this.label14.Text = "PEMASOK";
            // 
            // txtPemasokID
            // 
            this.txtPemasokID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPemasokID.Enabled = false;
            this.txtPemasokID.Location = new System.Drawing.Point(379, 146);
            this.txtPemasokID.Name = "txtPemasokID";
            this.txtPemasokID.ReadOnly = true;
            this.txtPemasokID.Size = new System.Drawing.Size(54, 20);
            this.txtPemasokID.TabIndex = 6;
            // 
            // frmPembelianUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(628, 435);
            this.Controls.Add(this.txtPemasokID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPemasok);
            this.Controls.Add(this.txtJmlNetto);
            this.Controls.Add(this.txtNoNota);
            this.Controls.Add(this.dtpTglTerima);
            this.Controls.Add(this.dtpTglNota);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPPn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtExpedisi);
            this.Controls.Add(this.txtJWKredit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDisc3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDisc2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDisc1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtJmlBeli);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormID = "BKL0121";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPembelianUpdate";
            this.Text = "BKL0121 - Pembelian";
            this.Title = "Pembelian";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPembelianUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPembelianUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtJmlBeli, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDisc1, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtDisc2, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtDisc3, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtJWKredit, 0);
            this.Controls.SetChildIndex(this.txtExpedisi, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtPPn, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtCatatan, 0);
            this.Controls.SetChildIndex(this.dtpTglNota, 0);
            this.Controls.SetChildIndex(this.dtpTglTerima, 0);
            this.Controls.SetChildIndex(this.txtNoNota, 0);
            this.Controls.SetChildIndex(this.txtJmlNetto, 0);
            this.Controls.SetChildIndex(this.txtPemasok, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtPemasokID, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private Controls.NumericTextBox txtExpedisi;
        private Controls.NumericTextBox txtJWKredit;
        private System.Windows.Forms.Label label11;
        private Controls.NumericTextBox txtDisc3;
        private System.Windows.Forms.Label label10;
        private Controls.NumericTextBox txtDisc2;
        private System.Windows.Forms.Label label9;
        private Controls.NumericTextBox txtDisc1;
        private System.Windows.Forms.Label label7;
        private Controls.NumericTextBox txtJmlBeli;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Controls.NumericTextBox txtPPn;
        private System.Windows.Forms.Label label12;
        private Controls.CommonTextBox txtCatatan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpTglTerima;
        private System.Windows.Forms.DateTimePicker dtpTglNota;
        private Controls.CommonTextBox txtNoNota;
        private Controls.NumericTextBox txtJmlNetto;
        private System.Windows.Forms.Label label14;
        private ISA.Controls.CommonTextBox txtPemasok;
        private ISA.Controls.CommonTextBox txtPemasokID;
    }
}
