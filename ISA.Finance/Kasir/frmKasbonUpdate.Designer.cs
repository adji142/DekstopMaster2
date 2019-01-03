namespace ISA.Finance.Kasir
{
    partial class frmKasbonUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasbonUpdate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lookupPerkiraanKoneksi1 = new ISA.Finance.Controls.LookupPerkiraanKoneksi();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAcc = new ISA.Controls.CommonTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lookupPegawai1 = new ISA.Finance.Controls.LookupPegawai();
            this.tbNominal = new ISA.Controls.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNoBkk = new ISA.Controls.CommonTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbHari = new ISA.Controls.NumericTextBox();
            this.tbDue = new ISA.Controls.DateTextBox();
            this.tbDivisi = new ISA.Controls.CommonTextBox();
            this.tbTanggal = new ISA.Controls.DateTextBox();
            this.tbNip = new ISA.Controls.CommonTextBox();
            this.tbKeperluan = new ISA.Controls.CommonTextBox();
            this.TBNoKasbon = new ISA.Controls.CommonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridVoucher = new ISA.Controls.CustomGridView();
            this.TglVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSisa = new ISA.Controls.NumericTextBox();
            this.tbPengembalian = new ISA.Controls.NumericTextBox();
            this.tbTotal = new ISA.Controls.NumericTextBox();
            this.tbBKK = new ISA.Controls.NumericTextBox();
            this.tbRpTrm = new ISA.Controls.NumericTextBox();
            this.tbBKM = new ISA.Controls.NumericTextBox();
            this.cmdDetailTransfer = new System.Windows.Forms.LinkLabel();
            this.cbBkk = new System.Windows.Forms.CheckBox();
            this.cbTrm = new System.Windows.Forms.CheckBox();
            this.cbBkm = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmdLink = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lookupPerkiraanKoneksi1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtAcc);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lookupPegawai1);
            this.groupBox1.Controls.Add(this.tbNominal);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbNoBkk);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbHari);
            this.groupBox1.Controls.Add(this.tbDue);
            this.groupBox1.Controls.Add(this.tbDivisi);
            this.groupBox1.Controls.Add(this.tbTanggal);
            this.groupBox1.Controls.Add(this.tbNip);
            this.groupBox1.Controls.Add(this.tbKeperluan);
            this.groupBox1.Controls.Add(this.TBNoKasbon);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(28, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lookupPerkiraanKoneksi1
            // 
            this.lookupPerkiraanKoneksi1.Kode = null;
            this.lookupPerkiraanKoneksi1.Location = new System.Drawing.Point(107, 93);
            this.lookupPerkiraanKoneksi1.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraanKoneksi1.NamaPerkiraan = "";
            this.lookupPerkiraanKoneksi1.Name = "lookupPerkiraanKoneksi1";
            this.lookupPerkiraanKoneksi1.NoPerkiraan = "[CODE]";
            this.lookupPerkiraanKoneksi1.Size = new System.Drawing.Size(249, 43);
            this.lookupPerkiraanKoneksi1.TabIndex = 26;
            this.lookupPerkiraanKoneksi1.TipeForm = ISA.Finance.Controls.LookupPerkiraanKoneksi.enTipeForm.form1;
            this.lookupPerkiraanKoneksi1.Load += new System.EventHandler(this.lookupPerkiraanKoneksi1_Load);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 122);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 25;
            this.label17.Text = "No Perkiraan";
            // 
            // txtAcc
            // 
            this.txtAcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAcc.Enabled = false;
            this.txtAcc.Location = new System.Drawing.Point(346, 143);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.ReadOnly = true;
            this.txtAcc.Size = new System.Drawing.Size(34, 20);
            this.txtAcc.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(272, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 24;
            this.label16.Text = "Keterangan";
            this.label16.Visible = false;
            // 
            // lookupPegawai1
            // 
            this.lookupPegawai1.Alamat = null;
            this.lookupPegawai1.Jabatan = null;
            this.lookupPegawai1.Location = new System.Drawing.Point(107, 42);
            this.lookupPegawai1.LP = null;
            this.lookupPegawai1.Nama = "";
            this.lookupPegawai1.Name = "lookupPegawai1";
            this.lookupPegawai1.Nip = null;
            this.lookupPegawai1.Size = new System.Drawing.Size(154, 22);
            this.lookupPegawai1.TabIndex = 1;
            this.lookupPegawai1.Unitkerja = null;
            this.lookupPegawai1.SelectData += new System.EventHandler(this.lookupPegawai1_SelectData);
            // 
            // tbNominal
            // 
            this.tbNominal.Location = new System.Drawing.Point(593, 143);
            this.tbNominal.Name = "tbNominal";
            this.tbNominal.Size = new System.Drawing.Size(94, 20);
            this.tbNominal.TabIndex = 4;
            this.tbNominal.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(501, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = "Nominal";
            // 
            // tbNoBkk
            // 
            this.tbNoBkk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoBkk.Enabled = false;
            this.tbNoBkk.Location = new System.Drawing.Point(107, 143);
            this.tbNoBkk.Name = "tbNoBkk";
            this.tbNoBkk.ReadOnly = true;
            this.tbNoBkk.Size = new System.Drawing.Size(100, 20);
            this.tbNoBkk.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 14);
            this.label10.TabIndex = 20;
            this.label10.Text = "Nomor BKK";
            // 
            // tbHari
            // 
            this.tbHari.Location = new System.Drawing.Point(528, 13);
            this.tbHari.Name = "tbHari";
            this.tbHari.Size = new System.Drawing.Size(41, 20);
            this.tbHari.TabIndex = 0;
            this.tbHari.Text = "0";
            this.tbHari.TextChanged += new System.EventHandler(this.tbHari_TextChanged);
            // 
            // tbDue
            // 
            this.tbDue.DateValue = null;
            this.tbDue.Enabled = false;
            this.tbDue.Location = new System.Drawing.Point(609, 13);
            this.tbDue.MaxLength = 10;
            this.tbDue.Name = "tbDue";
            this.tbDue.ReadOnly = true;
            this.tbDue.Size = new System.Drawing.Size(78, 20);
            this.tbDue.TabIndex = 3;
            // 
            // tbDivisi
            // 
            this.tbDivisi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDivisi.Enabled = false;
            this.tbDivisi.Location = new System.Drawing.Point(528, 44);
            this.tbDivisi.Name = "tbDivisi";
            this.tbDivisi.ReadOnly = true;
            this.tbDivisi.Size = new System.Drawing.Size(159, 20);
            this.tbDivisi.TabIndex = 6;
            this.tbDivisi.Visible = false;
            // 
            // tbTanggal
            // 
            this.tbTanggal.DateValue = null;
            this.tbTanggal.Enabled = false;
            this.tbTanggal.Location = new System.Drawing.Point(345, 13);
            this.tbTanggal.MaxLength = 10;
            this.tbTanggal.Name = "tbTanggal";
            this.tbTanggal.ReadOnly = true;
            this.tbTanggal.Size = new System.Drawing.Size(100, 20);
            this.tbTanggal.TabIndex = 1;
            // 
            // tbNip
            // 
            this.tbNip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNip.Enabled = false;
            this.tbNip.Location = new System.Drawing.Point(345, 41);
            this.tbNip.Name = "tbNip";
            this.tbNip.ReadOnly = true;
            this.tbNip.Size = new System.Drawing.Size(100, 20);
            this.tbNip.TabIndex = 5;
            // 
            // tbKeperluan
            // 
            this.tbKeperluan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKeperluan.Location = new System.Drawing.Point(107, 71);
            this.tbKeperluan.Name = "tbKeperluan";
            this.tbKeperluan.Size = new System.Drawing.Size(580, 20);
            this.tbKeperluan.TabIndex = 2;
            // 
            // TBNoKasbon
            // 
            this.TBNoKasbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBNoKasbon.Enabled = false;
            this.TBNoKasbon.Location = new System.Drawing.Point(107, 13);
            this.TBNoKasbon.Name = "TBNoKasbon";
            this.TBNoKasbon.ReadOnly = true;
            this.TBNoKasbon.Size = new System.Drawing.Size(100, 20);
            this.TBNoKasbon.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(575, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "Due";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "NIP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tanggal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nama Perkiraan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Divisi";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Hari";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Keperluan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Pegawai";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor BS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridVoucher);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbSisa);
            this.groupBox2.Controls.Add(this.tbPengembalian);
            this.groupBox2.Controls.Add(this.tbTotal);
            this.groupBox2.Controls.Add(this.tbBKK);
            this.groupBox2.Controls.Add(this.tbRpTrm);
            this.groupBox2.Controls.Add(this.tbBKM);
            this.groupBox2.Controls.Add(this.cmdDetailTransfer);
            this.groupBox2.Controls.Add(this.cbBkk);
            this.groupBox2.Controls.Add(this.cbTrm);
            this.groupBox2.Controls.Add(this.cbBkm);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(711, 277);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PENYELESAIAN";
            // 
            // gridVoucher
            // 
            this.gridVoucher.AllowUserToAddRows = false;
            this.gridVoucher.AllowUserToDeleteRows = false;
            this.gridVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglVoucher,
            this.NoPerkiraan,
            this.Keterangan,
            this.NoAcc,
            this.Jumlah});
            this.gridVoucher.Location = new System.Drawing.Point(12, 19);
            this.gridVoucher.MultiSelect = false;
            this.gridVoucher.Name = "gridVoucher";
            this.gridVoucher.ReadOnly = true;
            this.gridVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridVoucher.Size = new System.Drawing.Size(675, 138);
            this.gridVoucher.StandardTab = true;
            this.gridVoucher.TabIndex = 16;
            this.gridVoucher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridVoucher_KeyDown_1);
            // 
            // TglVoucher
            // 
            this.TglVoucher.DataPropertyName = "TglVoucher";
            this.TglVoucher.HeaderText = "Tanggal";
            this.TglVoucher.Name = "TglVoucher";
            this.TglVoucher.ReadOnly = true;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "No. Perkiraan";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            this.NoPerkiraan.Width = 150;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 250;
            // 
            // NoAcc
            // 
            this.NoAcc.DataPropertyName = "NoAcc";
            this.NoAcc.HeaderText = "NoAcc";
            this.NoAcc.Name = "NoAcc";
            this.NoAcc.ReadOnly = true;
            this.NoAcc.Width = 120;
            // 
            // Jumlah
            // 
            this.Jumlah.DataPropertyName = "Debet";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle1;
            this.Jumlah.HeaderText = "Jumlah";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            this.Jumlah.Width = 120;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ISA.Finance.Properties.Resources.centang2;
            this.pictureBox1.Location = new System.Drawing.Point(333, 222);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 20);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(475, 240);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 14);
            this.label15.TabIndex = 14;
            this.label15.Text = "Sisa";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(475, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 14);
            this.label14.TabIndex = 13;
            this.label14.Text = "Pengembalian";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(475, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 14);
            this.label13.TabIndex = 12;
            this.label13.Text = "Total";
            // 
            // tbSisa
            // 
            this.tbSisa.Enabled = false;
            this.tbSisa.Location = new System.Drawing.Point(593, 237);
            this.tbSisa.Name = "tbSisa";
            this.tbSisa.ReadOnly = true;
            this.tbSisa.Size = new System.Drawing.Size(100, 20);
            this.tbSisa.TabIndex = 10;
            this.tbSisa.Text = "0";
            // 
            // tbPengembalian
            // 
            this.tbPengembalian.Enabled = false;
            this.tbPengembalian.Location = new System.Drawing.Point(593, 211);
            this.tbPengembalian.Name = "tbPengembalian";
            this.tbPengembalian.ReadOnly = true;
            this.tbPengembalian.Size = new System.Drawing.Size(100, 20);
            this.tbPengembalian.TabIndex = 9;
            this.tbPengembalian.Text = "0";
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Location = new System.Drawing.Point(593, 185);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(100, 20);
            this.tbTotal.TabIndex = 8;
            this.tbTotal.Text = "0";
            // 
            // tbBKK
            // 
            this.tbBKK.Location = new System.Drawing.Point(74, 222);
            this.tbBKK.Name = "tbBKK";
            this.tbBKK.Size = new System.Drawing.Size(100, 20);
            this.tbBKK.TabIndex = 2;
            this.tbBKK.Text = "0";
            this.tbBKK.TextChanged += new System.EventHandler(this.tbBKK_TextChanged);
            // 
            // tbRpTrm
            // 
            this.tbRpTrm.Location = new System.Drawing.Point(279, 198);
            this.tbRpTrm.Name = "tbRpTrm";
            this.tbRpTrm.Size = new System.Drawing.Size(100, 20);
            this.tbRpTrm.TabIndex = 3;
            this.tbRpTrm.Text = "0";
            this.tbRpTrm.TextChanged += new System.EventHandler(this.tbRpTrm_TextChanged);
            // 
            // tbBKM
            // 
            this.tbBKM.Location = new System.Drawing.Point(74, 198);
            this.tbBKM.Name = "tbBKM";
            this.tbBKM.Size = new System.Drawing.Size(100, 20);
            this.tbBKM.TabIndex = 1;
            this.tbBKM.Text = "0";
            this.tbBKM.TextChanged += new System.EventHandler(this.tbBKM_TextChanged);
            // 
            // cmdDetailTransfer
            // 
            this.cmdDetailTransfer.AutoSize = true;
            this.cmdDetailTransfer.Location = new System.Drawing.Point(242, 224);
            this.cmdDetailTransfer.Name = "cmdDetailTransfer";
            this.cmdDetailTransfer.Size = new System.Drawing.Size(85, 14);
            this.cmdDetailTransfer.TabIndex = 4;
            this.cmdDetailTransfer.TabStop = true;
            this.cmdDetailTransfer.Text = "detail transfer";
            this.cmdDetailTransfer.Click += new System.EventHandler(this.cmdDetailTransfer_Click);
            // 
            // cbBkk
            // 
            this.cbBkk.AutoSize = true;
            this.cbBkk.Location = new System.Drawing.Point(18, 224);
            this.cbBkk.Name = "cbBkk";
            this.cbBkk.Size = new System.Drawing.Size(47, 18);
            this.cbBkk.TabIndex = 5;
            this.cbBkk.Text = "BKK";
            this.cbBkk.UseVisualStyleBackColor = true;
            this.cbBkk.CheckedChanged += new System.EventHandler(this.cbBkk_CheckedChanged);
            // 
            // cbTrm
            // 
            this.cbTrm.AutoSize = true;
            this.cbTrm.Location = new System.Drawing.Point(223, 200);
            this.cbTrm.Name = "cbTrm";
            this.cbTrm.Size = new System.Drawing.Size(50, 18);
            this.cbTrm.TabIndex = 3;
            this.cbTrm.Text = "TRM";
            this.cbTrm.UseVisualStyleBackColor = true;
            this.cbTrm.CheckedChanged += new System.EventHandler(this.cbTrm_CheckedChanged);
            // 
            // cbBkm
            // 
            this.cbBkm.AutoSize = true;
            this.cbBkm.Location = new System.Drawing.Point(18, 200);
            this.cbBkm.Name = "cbBkm";
            this.cbBkm.Size = new System.Drawing.Size(50, 18);
            this.cbBkm.TabIndex = 1;
            this.cbBkm.Text = "BKM";
            this.cbBkm.UseVisualStyleBackColor = true;
            this.cbBkm.CheckedChanged += new System.EventHandler(this.cbBkm_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(253, 14);
            this.label12.TabIndex = 1;
            this.label12.Text = "Kelebihan / kekurangan diselesaikan dengan";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(621, 492);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName2 = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(515, 492);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.ReportName2 = "";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmdLink
            // 
            this.cmdLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdLink.Location = new System.Drawing.Point(409, 492);
            this.cmdLink.Name = "cmdLink";
            this.cmdLink.Size = new System.Drawing.Size(100, 40);
            this.cmdLink.TabIndex = 5;
            this.cmdLink.Text = "LINK";
            this.cmdLink.UseVisualStyleBackColor = true;
            this.cmdLink.Click += new System.EventHandler(this.cmdLink_Click);
            // 
            // frmKasbonUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(766, 538);
            this.Controls.Add(this.cmdLink);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmKasbonUpdate";
            this.Text = "Bon Sementara Update";
            this.Load += new System.EventHandler(this.frmKasbonUpdate_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdLink, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Controls.NumericTextBox tbHari;
        private ISA.Controls.DateTextBox tbDue;
        private ISA.Controls.CommonTextBox tbDivisi;
        private ISA.Controls.DateTextBox tbTanggal;
        private ISA.Controls.CommonTextBox tbNip;
        private ISA.Controls.CommonTextBox tbKeperluan;
        private ISA.Controls.CommonTextBox TBNoKasbon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.NumericTextBox tbNominal;
        private System.Windows.Forms.Label label11;
        private ISA.Controls.CommonTextBox tbNoBkk;
        private System.Windows.Forms.Label label10;
        private ISA.Finance.Controls.LookupPegawai lookupPegawai1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.NumericTextBox tbSisa;
        private ISA.Controls.NumericTextBox tbPengembalian;
        private ISA.Controls.NumericTextBox tbTotal;
        private ISA.Controls.NumericTextBox tbBKK;
        private ISA.Controls.NumericTextBox tbRpTrm;
        private ISA.Controls.NumericTextBox tbBKM;
        private System.Windows.Forms.LinkLabel cmdDetailTransfer;
        private System.Windows.Forms.CheckBox cbBkk;
        private System.Windows.Forms.CheckBox cbTrm;
        private System.Windows.Forms.CheckBox cbBkm;
        private System.Windows.Forms.Label label12;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Controls.CommonTextBox txtAcc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button cmdLink;
        private ISA.Controls.CustomGridView gridVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private ISA.Finance.Controls.LookupPerkiraanKoneksi lookupPerkiraanKoneksi1;
    }
}
