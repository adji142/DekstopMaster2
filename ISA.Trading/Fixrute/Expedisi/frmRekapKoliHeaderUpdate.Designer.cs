namespace ISA.Trading.Expedisi
{
    partial class frmRekapKoliHeaderUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRekapKoliHeaderUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBiayaExp1 = new ISA.Trading.Controls.NumericTextBox();
            this.txtBiayaExp2 = new ISA.Trading.Controls.NumericTextBox();
            this.txtBiayaExp3 = new ISA.Trading.Controls.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTglSJ = new ISA.Trading.Controls.DateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoSJ = new ISA.Trading.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlamatKirim = new ISA.Trading.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKota = new ISA.Trading.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTglKeluar = new ISA.Trading.Controls.DateTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboKodeExp1 = new System.Windows.Forms.ComboBox();
            this.cboKodeExp2 = new System.Windows.Forms.ComboBox();
            this.cboKodeExp3 = new System.Windows.Forms.ComboBox();
            this.cboShift = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lookupToko = new ISA.Trading.Controls.LookupToko();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Biaya Expedisi";
            // 
            // txtBiayaExp1
            // 
            this.txtBiayaExp1.Location = new System.Drawing.Point(134, 291);
            this.txtBiayaExp1.Name = "txtBiayaExp1";
            this.txtBiayaExp1.Size = new System.Drawing.Size(93, 20);
            this.txtBiayaExp1.TabIndex = 9;
            this.txtBiayaExp1.Text = "0";
            // 
            // txtBiayaExp2
            // 
            this.txtBiayaExp2.Location = new System.Drawing.Point(234, 291);
            this.txtBiayaExp2.Name = "txtBiayaExp2";
            this.txtBiayaExp2.Size = new System.Drawing.Size(93, 20);
            this.txtBiayaExp2.TabIndex = 10;
            this.txtBiayaExp2.Text = "0";
            // 
            // txtBiayaExp3
            // 
            this.txtBiayaExp3.Location = new System.Drawing.Point(335, 291);
            this.txtBiayaExp3.Name = "txtBiayaExp3";
            this.txtBiayaExp3.Size = new System.Drawing.Size(93, 20);
            this.txtBiayaExp3.TabIndex = 11;
            this.txtBiayaExp3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nomor SJ";
            // 
            // txtTglSJ
            // 
            this.txtTglSJ.DateValue = null;
            this.txtTglSJ.Location = new System.Drawing.Point(134, 94);
            this.txtTglSJ.MaxLength = 10;
            this.txtTglSJ.Name = "txtTglSJ";
            this.txtTglSJ.Size = new System.Drawing.Size(81, 20);
            this.txtTglSJ.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tanggal SJ";
            // 
            // txtNoSJ
            // 
            this.txtNoSJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoSJ.Enabled = false;
            this.txtNoSJ.Location = new System.Drawing.Point(134, 66);
            this.txtNoSJ.MaxLength = 7;
            this.txtNoSJ.Name = "txtNoSJ";
            this.txtNoSJ.Size = new System.Drawing.Size(116, 20);
            this.txtNoSJ.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nama Toko";
            // 
            // txtAlamatKirim
            // 
            this.txtAlamatKirim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamatKirim.Enabled = false;
            this.txtAlamatKirim.Location = new System.Drawing.Point(134, 177);
            this.txtAlamatKirim.Name = "txtAlamatKirim";
            this.txtAlamatKirim.Size = new System.Drawing.Size(402, 20);
            this.txtAlamatKirim.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Alamat Kirim";
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Enabled = false;
            this.txtKota.Location = new System.Drawing.Point(134, 205);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(233, 20);
            this.txtKota.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Kota";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tanggal Keluar";
            // 
            // txtTglKeluar
            // 
            this.txtTglKeluar.DateValue = null;
            this.txtTglKeluar.Location = new System.Drawing.Point(134, 233);
            this.txtTglKeluar.MaxLength = 10;
            this.txtTglKeluar.Name = "txtTglKeluar";
            this.txtTglKeluar.Size = new System.Drawing.Size(81, 20);
            this.txtTglKeluar.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "Expedisi";
            // 
            // cboKodeExp1
            // 
            this.cboKodeExp1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKodeExp1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKodeExp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKodeExp1.FormattingEnabled = true;
            this.cboKodeExp1.Location = new System.Drawing.Point(134, 261);
            this.cboKodeExp1.Name = "cboKodeExp1";
            this.cboKodeExp1.Size = new System.Drawing.Size(61, 22);
            this.cboKodeExp1.TabIndex = 6;
            // 
            // cboKodeExp2
            // 
            this.cboKodeExp2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKodeExp2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKodeExp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKodeExp2.FormattingEnabled = true;
            this.cboKodeExp2.Location = new System.Drawing.Point(203, 262);
            this.cboKodeExp2.Name = "cboKodeExp2";
            this.cboKodeExp2.Size = new System.Drawing.Size(61, 22);
            this.cboKodeExp2.TabIndex = 7;
            // 
            // cboKodeExp3
            // 
            this.cboKodeExp3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKodeExp3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKodeExp3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKodeExp3.FormattingEnabled = true;
            this.cboKodeExp3.Location = new System.Drawing.Point(272, 262);
            this.cboKodeExp3.Name = "cboKodeExp3";
            this.cboKodeExp3.Size = new System.Drawing.Size(61, 22);
            this.cboKodeExp3.TabIndex = 8;
            // 
            // cboShift
            // 
            this.cboShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShift.FormattingEnabled = true;
            this.cboShift.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cboShift.Location = new System.Drawing.Point(134, 319);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(61, 22);
            this.cboShift.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "Shift";
            // 
            // lookupToko
            // 
            this.lookupToko.Alamat = null;
            this.lookupToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko.KodeToko = "";
            this.lookupToko.Kota = null;
            this.lookupToko.Location = new System.Drawing.Point(131, 122);
            this.lookupToko.NamaToko = "";
            this.lookupToko.Name = "lookupToko";
            this.lookupToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko.Size = new System.Drawing.Size(392, 54);
            this.lookupToko.TabIndex = 2;
            this.lookupToko.TokoID = "[Code]";
            this.lookupToko.SelectData += new System.EventHandler(this.lookupToko_SelectData);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(271, 367);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(117, 43);
            this.cmdCLOSE.TabIndex = 14;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(134, 367);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(117, 43);
            this.cmdSAVE.TabIndex = 13;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRekapKoliHeaderUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 433);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.lookupToko);
            this.Controls.Add(this.cboShift);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboKodeExp3);
            this.Controls.Add(this.cboKodeExp2);
            this.Controls.Add(this.cboKodeExp1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTglKeluar);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlamatKirim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNoSJ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTglSJ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBiayaExp3);
            this.Controls.Add(this.txtBiayaExp2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBiayaExp1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRekapKoliHeaderUpdate";
            this.Text = "Rekap Koli Header";
            this.Title = "Rekap Koli Header";
            this.Load += new System.EventHandler(this.frmRekapKoliHeaderUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRekapKoliHeaderUpdate_FormClosed);
            this.Controls.SetChildIndex(this.txtBiayaExp1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBiayaExp2, 0);
            this.Controls.SetChildIndex(this.txtBiayaExp3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTglSJ, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNoSJ, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtAlamatKirim, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.txtTglKeluar, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboKodeExp1, 0);
            this.Controls.SetChildIndex(this.cboKodeExp2, 0);
            this.Controls.SetChildIndex(this.cboKodeExp3, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cboShift, 0);
            this.Controls.SetChildIndex(this.lookupToko, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.NumericTextBox txtBiayaExp1;
        private ISA.Trading.Controls.NumericTextBox txtBiayaExp2;
        private ISA.Trading.Controls.NumericTextBox txtBiayaExp3;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.DateTextBox txtTglSJ;
        private System.Windows.Forms.Label label3;
        private ISA.Trading.Controls.CommonTextBox txtNoSJ;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.CommonTextBox txtAlamatKirim;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.CommonTextBox txtKota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Trading.Controls.DateTextBox txtTglKeluar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboKodeExp1;
        private System.Windows.Forms.ComboBox cboKodeExp2;
        private System.Windows.Forms.ComboBox cboKodeExp3;
        private System.Windows.Forms.ComboBox cboShift;
        private System.Windows.Forms.Label label9;
        private ISA.Trading.Controls.LookupToko lookupToko;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
