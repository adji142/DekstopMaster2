namespace ISA.Toko.Kasir
{
    partial class frmIndenDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndenDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cbCara = new System.Windows.Forms.ComboBox();
            this.tbJenisGiro = new ISA.Controls.CommonTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbNominal = new ISA.Controls.NumericTextBox();
            this.tbNoBGC = new ISA.Controls.CommonTextBox();
            this.tbTglGiro = new ISA.Controls.DateTextBox();
            this.tbTglJTempo = new ISA.Controls.DateTextBox();
            this.tbTglRK = new ISA.Controls.DateTextBox();
            this.lookupBankAsal1 = new ISA.Toko.Controls.LookupBankAsal();
            this.lookupBankTujuan = new ISA.Toko.Controls.LookupBank();
            this.tbKet = new ISA.Controls.CommonTextBox();
            this.lookupAccountToko1 = new ISA.Toko.Controls.LookupAccountToko();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblGiroPT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cara Pembayaran";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jenis Giro";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nominal";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "BANK Tujuan";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tanggal Giro";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "No BGC";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(387, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tanggal RK";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(387, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "J-Tempo";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(387, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "No. Account";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(387, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "BANK Asal";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 14;
            this.label12.Text = "Keterangan";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(217, 347);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 11;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(323, 347);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cbCara
            // 
            this.cbCara.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbCara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCara.FormattingEnabled = true;
            this.cbCara.Items.AddRange(new object[] {
            "CASH",
            "TRN",
            "GIRO",
            "CRD",
            "DBT"});
            this.cbCara.Location = new System.Drawing.Point(154, 56);
            this.cbCara.Name = "cbCara";
            this.cbCara.Size = new System.Drawing.Size(84, 22);
            this.cbCara.TabIndex = 0;
            this.cbCara.SelectedIndexChanged += new System.EventHandler(this.cbCara_SelectedIndexChanged);
            this.cbCara.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCara_KeyDown);
            // 
            // tbJenisGiro
            // 
            this.tbJenisGiro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbJenisGiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbJenisGiro.Enabled = false;
            this.tbJenisGiro.Location = new System.Drawing.Point(154, 88);
            this.tbJenisGiro.MaxLength = 1;
            this.tbJenisGiro.Name = "tbJenisGiro";
            this.tbJenisGiro.Size = new System.Drawing.Size(30, 20);
            this.tbJenisGiro.TabIndex = 1;
            this.tbJenisGiro.TextChanged += new System.EventHandler(this.tbJenisGiro_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(195, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 14);
            this.label13.TabIndex = 19;
            this.label13.Text = "[C] Cheque   [G] Giro/Bilyet   [S] Slip";
            // 
            // tbNominal
            // 
            this.tbNominal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNominal.Enabled = false;
            this.tbNominal.Location = new System.Drawing.Point(154, 117);
            this.tbNominal.Name = "tbNominal";
            this.tbNominal.Size = new System.Drawing.Size(100, 20);
            this.tbNominal.TabIndex = 2;
            this.tbNominal.Text = "0";
            // 
            // tbNoBGC
            // 
            this.tbNoBGC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNoBGC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoBGC.Enabled = false;
            this.tbNoBGC.Location = new System.Drawing.Point(154, 229);
            this.tbNoBGC.Name = "tbNoBGC";
            this.tbNoBGC.Size = new System.Drawing.Size(163, 20);
            this.tbNoBGC.TabIndex = 5;
            // 
            // tbTglGiro
            // 
            this.tbTglGiro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTglGiro.DateValue = null;
            this.tbTglGiro.Enabled = false;
            this.tbTglGiro.Location = new System.Drawing.Point(154, 200);
            this.tbTglGiro.MaxLength = 10;
            this.tbTglGiro.Name = "tbTglGiro";
            this.tbTglGiro.Size = new System.Drawing.Size(163, 20);
            this.tbTglGiro.TabIndex = 4;
            // 
            // tbTglJTempo
            // 
            this.tbTglJTempo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTglJTempo.DateValue = null;
            this.tbTglJTempo.Enabled = false;
            this.tbTglJTempo.Location = new System.Drawing.Point(477, 148);
            this.tbTglJTempo.MaxLength = 10;
            this.tbTglJTempo.Name = "tbTglJTempo";
            this.tbTglJTempo.Size = new System.Drawing.Size(163, 20);
            this.tbTglJTempo.TabIndex = 7;
            // 
            // tbTglRK
            // 
            this.tbTglRK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTglRK.DateValue = null;
            this.tbTglRK.Enabled = false;
            this.tbTglRK.Location = new System.Drawing.Point(477, 121);
            this.tbTglRK.MaxLength = 10;
            this.tbTglRK.Name = "tbTglRK";
            this.tbTglRK.Size = new System.Drawing.Size(163, 20);
            this.tbTglRK.TabIndex = 6;
            // 
            // lookupBankAsal1
            // 
            this.lookupBankAsal1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookupBankAsal1.Enabled = false;
            this.lookupBankAsal1.Location = new System.Drawing.Point(477, 208);
            this.lookupBankAsal1.Lokasi = "[LOKASI]";
            this.lookupBankAsal1.NamaBank = "";
            this.lookupBankAsal1.Name = "lookupBankAsal1";
            this.lookupBankAsal1.Size = new System.Drawing.Size(163, 45);
            this.lookupBankAsal1.TabIndex = 9;
            // 
            // lookupBankTujuan
            // 
            this.lookupBankTujuan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookupBankTujuan.BankID = "[CODE]";
            this.lookupBankTujuan.Enabled = false;
            this.lookupBankTujuan.Location = new System.Drawing.Point(154, 149);
            this.lookupBankTujuan.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lookupBankTujuan.NamaBank = "";
            this.lookupBankTujuan.Name = "lookupBankTujuan";
            this.lookupBankTujuan.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupBankTujuan.Size = new System.Drawing.Size(163, 51);
            this.lookupBankTujuan.TabIndex = 3;
            // 
            // tbKet
            // 
            this.tbKet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbKet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKet.Enabled = false;
            this.tbKet.Location = new System.Drawing.Point(154, 289);
            this.tbKet.Name = "tbKet";
            this.tbKet.Size = new System.Drawing.Size(486, 20);
            this.tbKet.TabIndex = 10;
            // 
            // lookupAccountToko1
            // 
            this.lookupAccountToko1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookupAccountToko1.Enabled = false;
            this.lookupAccountToko1.KodeToko = null;
            this.lookupAccountToko1.Location = new System.Drawing.Point(477, 176);
            this.lookupAccountToko1.Name = "lookupAccountToko1";
            this.lookupAccountToko1.NoAccount = "";
            this.lookupAccountToko1.Size = new System.Drawing.Size(163, 26);
            this.lookupAccountToko1.TabIndex = 8;
            this.lookupAccountToko1.Validating += new System.ComponentModel.CancelEventHandler(this.lookupAccountToko1_Validating);
            this.lookupAccountToko1.SelectData += new System.EventHandler(this.lookupAccountToko1_SelectData);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblGiroPT
            // 
            this.lblGiroPT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGiroPT.AutoSize = true;
            this.lblGiroPT.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiroPT.Location = new System.Drawing.Point(26, 332);
            this.lblGiroPT.Name = "lblGiroPT";
            this.lblGiroPT.Size = new System.Drawing.Size(93, 32);
            this.lblGiroPT.TabIndex = 20;
            this.lblGiroPT.Text = "label7";
            // 
            // frmIndenDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(661, 424);
            this.Controls.Add(this.lblGiroPT);
            this.Controls.Add(this.lookupAccountToko1);
            this.Controls.Add(this.tbKet);
            this.Controls.Add(this.lookupBankTujuan);
            this.Controls.Add(this.lookupBankAsal1);
            this.Controls.Add(this.tbTglRK);
            this.Controls.Add(this.tbTglJTempo);
            this.Controls.Add(this.tbTglGiro);
            this.Controls.Add(this.tbNoBGC);
            this.Controls.Add(this.tbNominal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbJenisGiro);
            this.Controls.Add(this.cbCara);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmIndenDetailUpdate";
            this.Text = "Penerimaan Uang Detail Update";
            this.Title = "Penerimaan Uang Detail Update";
            this.Load += new System.EventHandler(this.frmIndenDetailUpdate_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cbCara, 0);
            this.Controls.SetChildIndex(this.tbJenisGiro, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.tbNominal, 0);
            this.Controls.SetChildIndex(this.tbNoBGC, 0);
            this.Controls.SetChildIndex(this.tbTglGiro, 0);
            this.Controls.SetChildIndex(this.tbTglJTempo, 0);
            this.Controls.SetChildIndex(this.tbTglRK, 0);
            this.Controls.SetChildIndex(this.lookupBankAsal1, 0);
            this.Controls.SetChildIndex(this.lookupBankTujuan, 0);
            this.Controls.SetChildIndex(this.tbKet, 0);
            this.Controls.SetChildIndex(this.lookupAccountToko1, 0);
            this.Controls.SetChildIndex(this.lblGiroPT, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ComboBox cbCara;
        private ISA.Controls.CommonTextBox tbJenisGiro;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.NumericTextBox tbNominal;
        private ISA.Controls.CommonTextBox tbNoBGC;
        private ISA.Controls.DateTextBox tbTglGiro;
        private ISA.Controls.DateTextBox tbTglJTempo;
        private ISA.Controls.DateTextBox tbTglRK;
        private ISA.Toko.Controls.LookupBankAsal lookupBankAsal1;
        private ISA.Toko.Controls.LookupBank lookupBankTujuan;
        private ISA.Controls.CommonTextBox tbKet;
        private ISA.Toko.Controls.LookupAccountToko lookupAccountToko1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblGiroPT;
    }
}
