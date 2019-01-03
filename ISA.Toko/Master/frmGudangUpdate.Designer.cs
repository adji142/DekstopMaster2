namespace ISA.Toko.Master
{
    partial class frmGudangUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGudangUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGudangID = new ISA.Toko.Controls.CommonTextBox();
            this.txtNamaGudang = new ISA.Toko.Controls.CommonTextBox();
            this.txtAlamat = new ISA.Toko.Controls.CommonTextBox();
            this.txtAlamat2 = new ISA.Toko.Controls.CommonTextBox();
            this.txtAlamat3 = new ISA.Toko.Controls.CommonTextBox();
            this.txtTelp = new ISA.Toko.Controls.CommonTextBox();
            this.txtFax = new ISA.Toko.Controls.CommonTextBox();
            this.txtModem = new ISA.Toko.Controls.CommonTextBox();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.cbCabang = new ISA.Toko.Controls.CabangComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cabang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gudang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Alamat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Telp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Fax";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Modem";
            // 
            // txtGudangID
            // 
            this.txtGudangID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGudangID.Location = new System.Drawing.Point(167, 66);
            this.txtGudangID.MaxLength = 4;
            this.txtGudangID.Name = "txtGudangID";
            this.txtGudangID.Size = new System.Drawing.Size(46, 20);
            this.txtGudangID.TabIndex = 0;
            // 
            // txtNamaGudang
            // 
            this.txtNamaGudang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaGudang.Location = new System.Drawing.Point(167, 122);
            this.txtNamaGudang.MaxLength = 25;
            this.txtNamaGudang.Name = "txtNamaGudang";
            this.txtNamaGudang.Size = new System.Drawing.Size(159, 20);
            this.txtNamaGudang.TabIndex = 2;
            // 
            // txtAlamat
            // 
            this.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat.Location = new System.Drawing.Point(167, 150);
            this.txtAlamat.MaxLength = 40;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(453, 20);
            this.txtAlamat.TabIndex = 3;
            // 
            // txtAlamat2
            // 
            this.txtAlamat2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat2.Location = new System.Drawing.Point(167, 178);
            this.txtAlamat2.MaxLength = 40;
            this.txtAlamat2.Name = "txtAlamat2";
            this.txtAlamat2.Size = new System.Drawing.Size(453, 20);
            this.txtAlamat2.TabIndex = 4;
            // 
            // txtAlamat3
            // 
            this.txtAlamat3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat3.Location = new System.Drawing.Point(167, 206);
            this.txtAlamat3.MaxLength = 40;
            this.txtAlamat3.Name = "txtAlamat3";
            this.txtAlamat3.Size = new System.Drawing.Size(453, 20);
            this.txtAlamat3.TabIndex = 5;
            // 
            // txtTelp
            // 
            this.txtTelp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelp.Location = new System.Drawing.Point(167, 234);
            this.txtTelp.MaxLength = 15;
            this.txtTelp.Name = "txtTelp";
            this.txtTelp.Size = new System.Drawing.Size(159, 20);
            this.txtTelp.TabIndex = 6;
            // 
            // txtFax
            // 
            this.txtFax.AcceptsTab = true;
            this.txtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFax.Location = new System.Drawing.Point(167, 262);
            this.txtFax.MaxLength = 15;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(159, 20);
            this.txtFax.TabIndex = 7;
            // 
            // txtModem
            // 
            this.txtModem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModem.Location = new System.Drawing.Point(167, 290);
            this.txtModem.MaxLength = 15;
            this.txtModem.Name = "txtModem";
            this.txtModem.Size = new System.Drawing.Size(159, 20);
            this.txtModem.TabIndex = 8;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(303, 327);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 10;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(167, 327);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 9;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // cbCabang
            // 
            this.cbCabang.CabangID = "";
            this.cbCabang.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbCabang.DisplayMember = "Concatenated";
            this.cbCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCabang.Font = new System.Drawing.Font("Courier New", 8F);
            this.cbCabang.FormattingEnabled = true;
            this.cbCabang.Location = new System.Drawing.Point(167, 94);
            this.cbCabang.Name = "cbCabang";
            this.cbCabang.Size = new System.Drawing.Size(180, 22);
            this.cbCabang.TabIndex = 1;
            this.cbCabang.ValueMember = "CabangID";
            // 
            // frmGudangUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(648, 399);
            this.Controls.Add(this.cbCabang);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.txtModem);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTelp);
            this.Controls.Add(this.txtAlamat3);
            this.Controls.Add(this.txtAlamat2);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNamaGudang);
            this.Controls.Add(this.txtGudangID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormID = "SC0205";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGudangUpdate";
            this.Text = "SC0205 - Gudang";
            this.Title = "Gudang";
            this.Load += new System.EventHandler(this.frmGudangUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGudangUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtGudangID, 0);
            this.Controls.SetChildIndex(this.txtNamaGudang, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.txtAlamat2, 0);
            this.Controls.SetChildIndex(this.txtAlamat3, 0);
            this.Controls.SetChildIndex(this.txtTelp, 0);
            this.Controls.SetChildIndex(this.txtFax, 0);
            this.Controls.SetChildIndex(this.txtModem, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cbCabang, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ISA.Toko.Controls.CommonTextBox txtGudangID;
        private ISA.Toko.Controls.CommonTextBox txtNamaGudang;
        private ISA.Toko.Controls.CommonTextBox txtAlamat;
        private ISA.Toko.Controls.CommonTextBox txtAlamat2;
        private ISA.Toko.Controls.CommonTextBox txtAlamat3;
        private ISA.Toko.Controls.CommonTextBox txtTelp;
        private ISA.Toko.Controls.CommonTextBox txtFax;
        private ISA.Toko.Controls.CommonTextBox txtModem;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private ISA.Toko.Controls.CabangComboBox cbCabang;
    }
}
