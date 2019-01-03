namespace ISA.Trading.Fixrute
{
    partial class frmRencanaKunjunganSalesman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRencanaKunjunganSalesman));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKodeSales = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtKota = new System.Windows.Forms.TextBox();
            this.txtKecamatan = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.dateTextBox1 = new ISA.Trading.Controls.DateTextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dateTextBox2 = new ISA.Trading.Controls.DateTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbJenis = new System.Windows.Forms.ComboBox();
            this.cbHari = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cbSave = new ISA.Trading.Controls.CommandButton();
            this.lookupToko1 = new ISA.Trading.Controls.LookupToko();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kode Sales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nama Toko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Alamat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kota";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kecamatan";
            // 
            // txtKodeSales
            // 
            this.txtKodeSales.Location = new System.Drawing.Point(127, 69);
            this.txtKodeSales.Name = "txtKodeSales";
            this.txtKodeSales.Size = new System.Drawing.Size(107, 20);
            this.txtKodeSales.TabIndex = 0;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(129, 160);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(399, 20);
            this.txtAlamat.TabIndex = 2;
            this.txtAlamat.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtKota
            // 
            this.txtKota.Location = new System.Drawing.Point(129, 191);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(158, 20);
            this.txtKota.TabIndex = 3;
            this.txtKota.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtKecamatan
            // 
            this.txtKecamatan.Location = new System.Drawing.Point(129, 225);
            this.txtKecamatan.Name = "txtKecamatan";
            this.txtKecamatan.Size = new System.Drawing.Size(158, 20);
            this.txtKecamatan.TabIndex = 4;
            this.txtKecamatan.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.commandButton1);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.dateTextBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.dateTextBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cbJenis);
            this.groupBox1.Controls.Add(this.cbHari);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(25, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 127);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jadwal Kunjungan";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(510, 85);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(49, 18);
            this.checkBox6.TabIndex = 66;
            this.checkBox6.Text = "Mg6";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 65;
            this.label10.Text = "dari";
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(1041, 646);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 59;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(455, 85);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(49, 18);
            this.checkBox5.TabIndex = 9;
            this.checkBox5.Text = "Mg5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 14);
            this.label9.TabIndex = 64;
            this.label9.Text = "s/d";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(400, 85);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(49, 18);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "Mg4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(346, 85);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(49, 18);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "Mg3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(103, 26);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(80, 20);
            this.dateTextBox1.TabIndex = 63;
            this.dateTextBox1.TextChanged += new System.EventHandler(this.dateTextBox1_TextChanged);
            this.dateTextBox1.Leave += new System.EventHandler(this.dateTextBox1_Leave);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(294, 85);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(49, 18);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Mg2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // dateTextBox2
            // 
            this.dateTextBox2.DateValue = null;
            this.dateTextBox2.Location = new System.Drawing.Point(219, 27);
            this.dateTextBox2.MaxLength = 10;
            this.dateTextBox2.Name = "dateTextBox2";
            this.dateTextBox2.Size = new System.Drawing.Size(80, 20);
            this.dateTextBox2.TabIndex = 62;
            this.dateTextBox2.TextChanged += new System.EventHandler(this.dateTextBox_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(244, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 18);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Mg1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbJenis
            // 
            this.cbJenis.FormattingEnabled = true;
            this.cbJenis.Items.AddRange(new object[] {
            "W",
            "B",
            "M"});
            this.cbJenis.Location = new System.Drawing.Point(103, 83);
            this.cbJenis.Name = "cbJenis";
            this.cbJenis.Size = new System.Drawing.Size(121, 22);
            this.cbJenis.TabIndex = 6;
            this.cbJenis.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // cbHari
            // 
            this.cbHari.FormattingEnabled = true;
            this.cbHari.Items.AddRange(new object[] {
            "MINGGU",
            "SENIN",
            "SELASA",
            "RABU",
            "KAMIS",
            "JUMAT",
            "SABTU"});
            this.cbHari.Location = new System.Drawing.Point(103, 53);
            this.cbHari.Name = "cbHari";
            this.cbHari.Size = new System.Drawing.Size(121, 22);
            this.cbHari.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Jenis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hari";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "Berlaku";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(454, 424);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cbSave
            // 
            this.cbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cbSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cbSave.Image = ((System.Drawing.Image)(resources.GetObject("cbSave.Image")));
            this.cbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSave.Location = new System.Drawing.Point(129, 424);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(100, 40);
            this.cbSave.TabIndex = 6;
            this.cbSave.Text = "SAVE";
            this.cbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSave.UseVisualStyleBackColor = true;
            this.cbSave.Click += new System.EventHandler(this.cbSave_Click);
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Daerah = null;
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "[CODE]";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(124, 95);
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.Propinsi = null;
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(404, 54);
            this.lookupToko1.TabIndex = 1;
            this.lookupToko1.TokoID = null;
            this.lookupToko1.WilID = "";
            this.lookupToko1.Click += new System.EventHandler(this.lookupToko1_Click);
            this.lookupToko1.Validating += new System.ComponentModel.CancelEventHandler(this.lookupToko1_Validating);
            this.lookupToko1.Leave += new System.EventHandler(this.lookupToko1_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // frmRencanaKunjunganSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 490);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtKecamatan);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtKodeSales);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRencanaKunjunganSalesman";
            this.Text = "Rencana Kunjungan Salesman";
            this.Title = "Rencana Kunjungan Salesman";
            this.Load += new System.EventHandler(this.frmRencanaKunjunganSalesman_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtKodeSales, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.txtKecamatan, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cbSave, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKodeSales;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtKota;
        private System.Windows.Forms.TextBox txtKecamatan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbJenis;
        private System.Windows.Forms.ComboBox cbHari;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cbSave;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.LookupToko lookupToko1;
        private ISA.Trading.Controls.DateTextBox dateTextBox1;
        private ISA.Trading.Controls.DateTextBox dateTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.CheckBox checkBox6;
    }
}