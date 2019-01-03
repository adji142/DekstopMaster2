namespace ISA.Toko.Penjualan
{
    partial class frmMPRUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMPRUpdate));
            this.cboCabang1 = new System.Windows.Forms.ComboBox();
            this.cboCabang2 = new System.Windows.Forms.ComboBox();
            this.txtTglRQRetur = new ISA.Toko.Controls.DateTextBox();
            this.txtTglMemoRetur = new ISA.Toko.Controls.DateTextBox();
            this.txtNoMemoRetur = new ISA.Toko.Controls.CommonTextBox();
            this.txtAlamat = new ISA.Toko.Controls.CommonTextBox();
            this.txtKota = new ISA.Toko.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lookupToko = new ISA.Toko.Controls.LookupToko();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTglNotRet = new ISA.Toko.Controls.DateTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoNotaret = new ISA.Toko.Controls.CommonTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lookupStafAdm1 = new ISA.Toko.Controls.LookupStafAdm();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCabang1
            // 
            this.cboCabang1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCabang1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCabang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang1.FormattingEnabled = true;
            this.cboCabang1.Location = new System.Drawing.Point(141, 22);
            this.cboCabang1.Name = "cboCabang1";
            this.cboCabang1.Size = new System.Drawing.Size(195, 22);
            this.cboCabang1.TabIndex = 1;
            this.cboCabang1.Visible = false;
            // 
            // cboCabang2
            // 
            this.cboCabang2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCabang2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCabang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang2.FormattingEnabled = true;
            this.cboCabang2.Location = new System.Drawing.Point(141, 51);
            this.cboCabang2.Name = "cboCabang2";
            this.cboCabang2.Size = new System.Drawing.Size(195, 22);
            this.cboCabang2.TabIndex = 2;
            this.cboCabang2.Visible = false;
            // 
            // txtTglRQRetur
            // 
            this.txtTglRQRetur.DateValue = null;
            this.txtTglRQRetur.Location = new System.Drawing.Point(157, 21);
            this.txtTglRQRetur.MaxLength = 10;
            this.txtTglRQRetur.Name = "txtTglRQRetur";
            this.txtTglRQRetur.Size = new System.Drawing.Size(98, 20);
            this.txtTglRQRetur.TabIndex = 0;
            // 
            // txtTglMemoRetur
            // 
            this.txtTglMemoRetur.DateValue = null;
            this.txtTglMemoRetur.Location = new System.Drawing.Point(152, 13);
            this.txtTglMemoRetur.MaxLength = 10;
            this.txtTglMemoRetur.Name = "txtTglMemoRetur";
            this.txtTglMemoRetur.ReadOnly = true;
            this.txtTglMemoRetur.Size = new System.Drawing.Size(98, 20);
            this.txtTglMemoRetur.TabIndex = 3;
            this.txtTglMemoRetur.TabStop = false;
            // 
            // txtNoMemoRetur
            // 
            this.txtNoMemoRetur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoMemoRetur.Location = new System.Drawing.Point(152, 42);
            this.txtNoMemoRetur.Name = "txtNoMemoRetur";
            this.txtNoMemoRetur.Size = new System.Drawing.Size(79, 20);
            this.txtNoMemoRetur.TabIndex = 4;
            // 
            // txtAlamat
            // 
            this.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat.Location = new System.Drawing.Point(157, 229);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(473, 20);
            this.txtAlamat.TabIndex = 5;
            this.txtAlamat.TabStop = false;
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Location = new System.Drawing.Point(157, 257);
            this.txtKota.Name = "txtKota";
            this.txtKota.ReadOnly = true;
            this.txtKota.Size = new System.Drawing.Size(195, 20);
            this.txtKota.TabIndex = 6;
            this.txtKota.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "C1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "C2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tgl RQ Retur";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tgl Memo Retur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "No Memo Retur";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Adm. Penjualan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 17;
            this.label9.Text = "Nama Toko";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Alamat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Kota";
            // 
            // lookupToko
            // 
            this.lookupToko.Alamat = null;
            this.lookupToko.Daerah = null;
            this.lookupToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko.HariKirim = 0;
            this.lookupToko.HariSales = 0;
            this.lookupToko.KodeToko = "[CODE]";
            this.lookupToko.Kota = null;
            this.lookupToko.Location = new System.Drawing.Point(154, 169);
            this.lookupToko.NamaToko = "";
            this.lookupToko.Name = "lookupToko";
            this.lookupToko.Propinsi = null;
            this.lookupToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko.Size = new System.Drawing.Size(392, 54);
            this.lookupToko.TabIndex = 4;
            this.lookupToko.TokoID = null;
            this.lookupToko.WilID = "";
            this.lookupToko.SelectData += new System.EventHandler(this.lookupToko_SelectData);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboCabang1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboCabang2);
            this.groupBox1.Controls.Add(this.txtNoMemoRetur);
            this.groupBox1.Controls.Add(this.txtTglMemoRetur);
            this.groupBox1.Location = new System.Drawing.Point(703, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(11, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // txtTglNotRet
            // 
            this.txtTglNotRet.DateValue = null;
            this.txtTglNotRet.Enabled = false;
            this.txtTglNotRet.Location = new System.Drawing.Point(157, 48);
            this.txtTglNotRet.MaxLength = 10;
            this.txtTglNotRet.Name = "txtTglNotRet";
            this.txtTglNotRet.Size = new System.Drawing.Size(98, 20);
            this.txtTglNotRet.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "Tgl Nota Retur";
            // 
            // txtNoNotaret
            // 
            this.txtNoNotaret.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoNotaret.Enabled = false;
            this.txtNoNotaret.Location = new System.Drawing.Point(157, 79);
            this.txtNoNotaret.MaxLength = 7;
            this.txtNoNotaret.Name = "txtNoNotaret";
            this.txtNoNotaret.Size = new System.Drawing.Size(79, 20);
            this.txtNoNotaret.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "No Nota Retur";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.lookupStafAdm1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNoNotaret);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTglNotRet);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lookupToko);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmdClose);
            this.groupBox2.Controls.Add(this.txtTglRQRetur);
            this.groupBox2.Controls.Add(this.cmdSave);
            this.groupBox2.Controls.Add(this.txtKota);
            this.groupBox2.Controls.Add(this.txtAlamat);
            this.groupBox2.Location = new System.Drawing.Point(28, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 337);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lookupStafAdm1
            // 
            this.lookupStafAdm1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStafAdm1.Kode = "[CODE]";
            this.lookupStafAdm1.Location = new System.Drawing.Point(154, 109);
            this.lookupStafAdm1.Nama = "";
            this.lookupStafAdm1.Name = "lookupStafAdm1";
            this.lookupStafAdm1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStafAdm1.Size = new System.Drawing.Size(392, 54);
            this.lookupStafAdm1.TabIndex = 3;
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(542, 291);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(25, 291);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmMPRUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(726, 445);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMPRUpdate";
            this.Text = "Retur Jual (MPR)";
            this.Title = "Retur Jual (MPR)";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmMPRUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMPRUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCabang1;
        private System.Windows.Forms.ComboBox cboCabang2;
        private ISA.Toko.Controls.DateTextBox txtTglRQRetur;
        private ISA.Toko.Controls.DateTextBox txtTglMemoRetur;
        private ISA.Toko.Controls.CommonTextBox txtNoMemoRetur;
        private ISA.Toko.Controls.CommonTextBox txtAlamat;
        private ISA.Toko.Controls.CommonTextBox txtKota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.LookupToko lookupToko;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Toko.Controls.DateTextBox txtTglNotRet;
        private ISA.Toko.Controls.CommonTextBox txtNoNotaret;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private ISA.Toko.Controls.LookupStafAdm lookupStafAdm1;
    }
}
