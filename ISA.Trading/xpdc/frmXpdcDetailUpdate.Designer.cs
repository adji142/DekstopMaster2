namespace ISA.Trading.xpdc
{
    partial class frmXpdcDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXpdcDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTglNota = new ISA.Controls.DateTextBox();
            this.txtNoNota = new ISA.Controls.CommonTextBox();
            this.txtNamaToko = new ISA.Controls.CommonTextBox();
            this.txtAlamat = new ISA.Controls.CommonTextBox();
            this.txtKota = new ISA.Controls.CommonTextBox();
            this.txtBarcode = new ISA.Controls.CommonTextBox();
            this.txtJmlKoli = new ISA.Controls.NumericTextBox();
            this.txtJmlPcs = new ISA.Controls.NumericTextBox();
            this.txtKeteranganKoli = new ISA.Controls.CommonTextBox();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tgl. Nota";
            // 
            // txtTglNota
            // 
            this.txtTglNota.DateValue = null;
            this.txtTglNota.Location = new System.Drawing.Point(137, 63);
            this.txtTglNota.MaxLength = 10;
            this.txtTglNota.Name = "txtTglNota";
            this.txtTglNota.ReadOnly = true;
            this.txtTglNota.Size = new System.Drawing.Size(94, 20);
            this.txtTglNota.TabIndex = 7;
            this.txtTglNota.TabStop = false;
            // 
            // txtNoNota
            // 
            this.txtNoNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoNota.Location = new System.Drawing.Point(137, 89);
            this.txtNoNota.Name = "txtNoNota";
            this.txtNoNota.ReadOnly = true;
            this.txtNoNota.Size = new System.Drawing.Size(74, 20);
            this.txtNoNota.TabIndex = 8;
            this.txtNoNota.TabStop = false;
            // 
            // txtNamaToko
            // 
            this.txtNamaToko.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaToko.Location = new System.Drawing.Point(137, 115);
            this.txtNamaToko.Name = "txtNamaToko";
            this.txtNamaToko.ReadOnly = true;
            this.txtNamaToko.Size = new System.Drawing.Size(212, 20);
            this.txtNamaToko.TabIndex = 9;
            this.txtNamaToko.TabStop = false;
            // 
            // txtAlamat
            // 
            this.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat.Location = new System.Drawing.Point(137, 141);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(393, 20);
            this.txtAlamat.TabIndex = 10;
            this.txtAlamat.TabStop = false;
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Location = new System.Drawing.Point(137, 167);
            this.txtKota.Name = "txtKota";
            this.txtKota.ReadOnly = true;
            this.txtKota.Size = new System.Drawing.Size(141, 20);
            this.txtKota.TabIndex = 11;
            this.txtKota.TabStop = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Location = new System.Drawing.Point(137, 193);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 20);
            this.txtBarcode.TabIndex = 0;
            // 
            // txtJmlKoli
            // 
            this.txtJmlKoli.Location = new System.Drawing.Point(137, 219);
            this.txtJmlKoli.Name = "txtJmlKoli";
            this.txtJmlKoli.Size = new System.Drawing.Size(64, 20);
            this.txtJmlKoli.TabIndex = 1;
            this.txtJmlKoli.Text = "0";
            // 
            // txtJmlPcs
            // 
            this.txtJmlPcs.Location = new System.Drawing.Point(137, 245);
            this.txtJmlPcs.Name = "txtJmlPcs";
            this.txtJmlPcs.Size = new System.Drawing.Size(64, 20);
            this.txtJmlPcs.TabIndex = 2;
            this.txtJmlPcs.Text = "0";
            // 
            // txtKeteranganKoli
            // 
            this.txtKeteranganKoli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeteranganKoli.Location = new System.Drawing.Point(137, 271);
            this.txtKeteranganKoli.Name = "txtKeteranganKoli";
            this.txtKeteranganKoli.Size = new System.Drawing.Size(152, 20);
            this.txtKeteranganKoli.TabIndex = 3;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(324, 309);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(430, 309);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "No. Nota";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nama Toko";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Alamat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "Kota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "Barcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "Jml. Koli";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "Jml. Pcs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "Keterangan Koli";
            // 
            // frmXpdcDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(561, 368);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTglNota);
            this.Controls.Add(this.txtNoNota);
            this.Controls.Add(this.txtKeteranganKoli);
            this.Controls.Add(this.txtJmlPcs);
            this.Controls.Add(this.txtJmlKoli);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNamaToko);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "frmXpdcDetailUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit Detail Pengiriman Barang";
            this.Title = "Edit Detail Pengiriman Barang";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmXpdcDetailUpdate_Load);
            this.Controls.SetChildIndex(this.txtNamaToko, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.txtJmlKoli, 0);
            this.Controls.SetChildIndex(this.txtJmlPcs, 0);
            this.Controls.SetChildIndex(this.txtKeteranganKoli, 0);
            this.Controls.SetChildIndex(this.txtNoNota, 0);
            this.Controls.SetChildIndex(this.txtTglNota, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.DateTextBox txtTglNota;
        private ISA.Controls.CommonTextBox txtNoNota;
        private ISA.Controls.CommonTextBox txtNamaToko;
        private ISA.Controls.CommonTextBox txtAlamat;
        private ISA.Controls.CommonTextBox txtKota;
        private ISA.Controls.CommonTextBox txtBarcode;
        private ISA.Controls.NumericTextBox txtJmlKoli;
        private ISA.Controls.NumericTextBox txtJmlPcs;
        private ISA.Controls.CommonTextBox txtKeteranganKoli;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

    }
}
