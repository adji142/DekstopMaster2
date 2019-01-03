namespace ISA.Toko.Master
{
    partial class frmStafSalesUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStafSalesUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamaSales = new ISA.Toko.Controls.CommonTextBox();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAlamat = new ISA.Toko.Controls.CommonTextBox();
            this.Kode = new System.Windows.Forms.Label();
            this.TxtKode = new ISA.Toko.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtDateMasuk = new ISA.Controls.DateTextBox();
            this.TxtDateKeluar = new ISA.Controls.DateTextBox();
            this.txtdateLahir = new ISA.Controls.DateTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama";
            // 
            // txtNamaSales
            // 
            this.txtNamaSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaSales.Location = new System.Drawing.Point(111, 35);
            this.txtNamaSales.MaxLength = 100;
            this.txtNamaSales.Name = "txtNamaSales";
            this.txtNamaSales.Size = new System.Drawing.Size(237, 20);
            this.txtNamaSales.TabIndex = 0;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(111, 225);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(232, 225);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tanggal Keluar";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TxtAlamat
            // 
            this.TxtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAlamat.Location = new System.Drawing.Point(111, 114);
            this.TxtAlamat.MaxLength = 150;
            this.TxtAlamat.Name = "TxtAlamat";
            this.TxtAlamat.Size = new System.Drawing.Size(478, 20);
            this.TxtAlamat.TabIndex = 3;
            this.TxtAlamat.TextChanged += new System.EventHandler(this.TxtKeterangan_TextChanged);
            // 
            // Kode
            // 
            this.Kode.AutoSize = true;
            this.Kode.Location = new System.Drawing.Point(390, 38);
            this.Kode.Name = "Kode";
            this.Kode.Size = new System.Drawing.Size(35, 14);
            this.Kode.TabIndex = 13;
            this.Kode.Text = "Kode";
            this.Kode.Visible = false;
            this.Kode.Click += new System.EventHandler(this.Kode_Click);
            // 
            // TxtKode
            // 
            this.TxtKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtKode.Enabled = false;
            this.TxtKode.Location = new System.Drawing.Point(444, 35);
            this.TxtKode.MaxLength = 10;
            this.TxtKode.Name = "TxtKode";
            this.TxtKode.Size = new System.Drawing.Size(136, 20);
            this.TxtKode.TabIndex = 0;
            this.TxtKode.Visible = false;
            this.TxtKode.TextChanged += new System.EventHandler(this.TxtKode_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.TxtDateMasuk);
            this.groupBox1.Controls.Add(this.TxtDateKeluar);
            this.groupBox1.Controls.Add(this.txtdateLahir);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.txtNamaSales);
            this.groupBox1.Controls.Add(this.Kode);
            this.groupBox1.Controls.Add(this.TxtAlamat);
            this.groupBox1.Controls.Add(this.TxtKode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(31, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TxtDateMasuk
            // 
            this.TxtDateMasuk.DateValue = null;
            this.TxtDateMasuk.Location = new System.Drawing.Point(111, 149);
            this.TxtDateMasuk.MaxLength = 10;
            this.TxtDateMasuk.Name = "TxtDateMasuk";
            this.TxtDateMasuk.Size = new System.Drawing.Size(132, 20);
            this.TxtDateMasuk.TabIndex = 4;
            // 
            // TxtDateKeluar
            // 
            this.TxtDateKeluar.DateValue = null;
            this.TxtDateKeluar.Location = new System.Drawing.Point(111, 187);
            this.TxtDateKeluar.MaxLength = 10;
            this.TxtDateKeluar.Name = "TxtDateKeluar";
            this.TxtDateKeluar.Size = new System.Drawing.Size(132, 20);
            this.TxtDateKeluar.TabIndex = 5;
            // 
            // txtdateLahir
            // 
            this.txtdateLahir.DateValue = null;
            this.txtdateLahir.Location = new System.Drawing.Point(111, 73);
            this.txtdateLahir.MaxLength = 10;
            this.txtdateLahir.Name = "txtdateLahir";
            this.txtdateLahir.Size = new System.Drawing.Size(132, 20);
            this.txtdateLahir.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tanggal Lahir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "Alamat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tanggal Masuk";
            // 
            // frmStafSalesUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(667, 371);
            this.Controls.Add(this.groupBox1);
            this.FormID = "SC0223";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStafSalesUpdate";
            this.Text = "SC0223 - Salesman";
            this.Title = "Salesman";
            this.Load += new System.EventHandler(this.frmStafSalesUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStafSalesUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox txtNamaSales;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox TxtAlamat;
        private System.Windows.Forms.Label Kode;
        private ISA.Toko.Controls.CommonTextBox TxtKode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.DateTextBox TxtDateMasuk;
        private ISA.Controls.DateTextBox TxtDateKeluar;
        private ISA.Controls.DateTextBox txtdateLahir;
    }
}
