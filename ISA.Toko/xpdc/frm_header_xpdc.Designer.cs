namespace ISA.Toko.xpdc
{
    partial class frm_header_xpdc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_header_xpdc));
            this.label1 = new System.Windows.Forms.Label();
            this.NoSj = new ISA.Toko.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NoPolisi = new ISA.Toko.Controls.CommonTextBox();
            this.cboTujuan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.JamKirim = new ISA.Toko.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Money = new ISA.Toko.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commonTextBox3 = new ISA.Toko.Controls.CommonTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.commonTextBox4 = new ISA.Toko.Controls.CommonTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.KmBerangkat = new ISA.Toko.Controls.CommonTextBox();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.Tglkrm = new ISA.Toko.Controls.DateTextBox();
            this.lookupStafAdm1 = new ISA.Toko.Controls.LookupStafAdm();
            this.lookupStafAdm2 = new ISA.Toko.Controls.LookupStafAdm();
            this.label12 = new System.Windows.Forms.Label();
            this.lookupArmadaKirim1 = new ISA.Toko.Controls.lookupArmadaKirim();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.TabIndex = 43;
            this.label1.Text = "Tanggal Pengiriman";
            // 
            // NoSj
            // 
            this.NoSj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NoSj.Location = new System.Drawing.Point(496, 69);
            this.NoSj.Name = "NoSj";
            this.NoSj.Size = new System.Drawing.Size(79, 20);
            this.NoSj.TabIndex = 2;
            this.NoSj.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 46;
            this.label2.Text = "No. Surat Jalan";
            this.label2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 14);
            this.label5.TabIndex = 48;
            this.label5.Text = "Nama Sopir";
            // 
            // NoPolisi
            // 
            this.NoPolisi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NoPolisi.Location = new System.Drawing.Point(178, 304);
            this.NoPolisi.Name = "NoPolisi";
            this.NoPolisi.ReadOnly = true;
            this.NoPolisi.Size = new System.Drawing.Size(140, 20);
            this.NoPolisi.TabIndex = 4;
            // 
            // cboTujuan
            // 
            this.cboTujuan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTujuan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTujuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTujuan.FormattingEnabled = true;
            this.cboTujuan.Location = new System.Drawing.Point(178, 213);
            this.cboTujuan.Name = "cboTujuan";
            this.cboTujuan.Size = new System.Drawing.Size(140, 22);
            this.cboTujuan.TabIndex = 3;
            this.cboTujuan.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 14);
            this.label8.TabIndex = 54;
            this.label8.Text = "No. Polisi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 14);
            this.label7.TabIndex = 53;
            this.label7.Text = "Tujuan ";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 52;
            this.label6.Text = "Nama Kernet";
            // 
            // JamKirim
            // 
            this.JamKirim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.JamKirim.Location = new System.Drawing.Point(178, 356);
            this.JamKirim.Name = "JamKirim";
            this.JamKirim.Size = new System.Drawing.Size(83, 20);
            this.JamKirim.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 14);
            this.label3.TabIndex = 56;
            this.label3.Text = "Jam Pengiriman";
            // 
            // Money
            // 
            this.Money.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Money.Location = new System.Drawing.Point(179, 383);
            this.Money.Name = "Money";
            this.Money.Size = new System.Drawing.Size(140, 20);
            this.Money.TabIndex = 7;
            this.Money.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 58;
            this.label4.Text = "Biaya Sementara";
            this.label4.Visible = false;
            // 
            // commonTextBox3
            // 
            this.commonTextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox3.Enabled = false;
            this.commonTextBox3.Location = new System.Drawing.Point(178, 409);
            this.commonTextBox3.Name = "commonTextBox3";
            this.commonTextBox3.Size = new System.Drawing.Size(140, 20);
            this.commonTextBox3.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 60;
            this.label9.Text = "Biaya";
            // 
            // commonTextBox4
            // 
            this.commonTextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox4.Enabled = false;
            this.commonTextBox4.Location = new System.Drawing.Point(178, 435);
            this.commonTextBox4.Name = "commonTextBox4";
            this.commonTextBox4.Size = new System.Drawing.Size(140, 20);
            this.commonTextBox4.TabIndex = 9;
            this.commonTextBox4.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 436);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 14);
            this.label10.TabIndex = 62;
            this.label10.Text = "Lebih / Kurang";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(62, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 14);
            this.label11.TabIndex = 64;
            this.label11.Text = "Km Berangkat";
            // 
            // KmBerangkat
            // 
            this.KmBerangkat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.KmBerangkat.Location = new System.Drawing.Point(178, 330);
            this.KmBerangkat.Name = "KmBerangkat";
            this.KmBerangkat.ReadOnly = true;
            this.KmBerangkat.Size = new System.Drawing.Size(83, 20);
            this.KmBerangkat.TabIndex = 5;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(259, 489);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 10;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.HeaderSave_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(362, 489);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 11;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // Tglkrm
            // 
            this.Tglkrm.DateValue = null;
            this.Tglkrm.Location = new System.Drawing.Point(181, 68);
            this.Tglkrm.MaxLength = 10;
            this.Tglkrm.Name = "Tglkrm";
            this.Tglkrm.ReadOnly = true;
            this.Tglkrm.Size = new System.Drawing.Size(106, 20);
            this.Tglkrm.TabIndex = 0;
            // 
            // lookupStafAdm1
            // 
            this.lookupStafAdm1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStafAdm1.Kode = "[CODE]";
            this.lookupStafAdm1.Location = new System.Drawing.Point(178, 94);
            this.lookupStafAdm1.Nama = "";
            this.lookupStafAdm1.Name = "lookupStafAdm1";
            this.lookupStafAdm1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStafAdm1.Size = new System.Drawing.Size(300, 54);
            this.lookupStafAdm1.TabIndex = 65;
            // 
            // lookupStafAdm2
            // 
            this.lookupStafAdm2.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStafAdm2.Kode = "[CODE]";
            this.lookupStafAdm2.Location = new System.Drawing.Point(178, 141);
            this.lookupStafAdm2.Nama = "";
            this.lookupStafAdm2.Name = "lookupStafAdm2";
            this.lookupStafAdm2.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStafAdm2.Size = new System.Drawing.Size(300, 54);
            this.lookupStafAdm2.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(63, 259);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 14);
            this.label12.TabIndex = 68;
            this.label12.Text = "Kendaraan";
            // 
            // lookupArmadaKirim1
            // 
            this.lookupArmadaKirim1.Kendaraan = null;
            this.lookupArmadaKirim1.KMPerLiter = null;
            this.lookupArmadaKirim1.KodeArmada = null;
            this.lookupArmadaKirim1.Location = new System.Drawing.Point(179, 259);
            this.lookupArmadaKirim1.Name = "lookupArmadaKirim1";
            this.lookupArmadaKirim1.NomorPolisi = null;
            this.lookupArmadaKirim1.Size = new System.Drawing.Size(154, 28);
            this.lookupArmadaKirim1.TabIndex = 69;
            this.lookupArmadaKirim1.TripMeterKM = null;
            this.lookupArmadaKirim1.SelectData += new System.EventHandler(this.lookupArmadaKirim1_SelectData);
            // 
            // frm_header_xpdc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(809, 532);
            this.Controls.Add(this.lookupArmadaKirim1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lookupStafAdm2);
            this.Controls.Add(this.lookupStafAdm1);
            this.Controls.Add(this.Tglkrm);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.KmBerangkat);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.commonTextBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.commonTextBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Money);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.JamKirim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NoPolisi);
            this.Controls.Add(this.cboTujuan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NoSj);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_header_xpdc";
            this.Text = "Tambah Pengiriman";
            this.Title = "Tambah Pengiriman";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.Header_xpdc_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.NoSj, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboTujuan, 0);
            this.Controls.SetChildIndex(this.NoPolisi, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.JamKirim, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.Money, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.commonTextBox3, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.commonTextBox4, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.KmBerangkat, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.Tglkrm, 0);
            this.Controls.SetChildIndex(this.lookupStafAdm1, 0);
            this.Controls.SetChildIndex(this.lookupStafAdm2, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lookupArmadaKirim1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox NoSj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommonTextBox NoPolisi;
        private System.Windows.Forms.ComboBox cboTujuan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ISA.Toko.Controls.CommonTextBox JamKirim;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommonTextBox Money;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.CommonTextBox commonTextBox3;
        private System.Windows.Forms.Label label9;
        private ISA.Toko.Controls.CommonTextBox commonTextBox4;
        private System.Windows.Forms.Label label10;
        private ISA.Toko.Controls.CommonTextBox KmBerangkat;
        private System.Windows.Forms.Label label11;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Toko.Controls.DateTextBox Tglkrm;
        private ISA.Toko.Controls.LookupStafAdm lookupStafAdm1;
        private ISA.Toko.Controls.LookupStafAdm lookupStafAdm2;
        private System.Windows.Forms.Label label12;
        private ISA.Toko.Controls.lookupArmadaKirim lookupArmadaKirim1;
    }
}
