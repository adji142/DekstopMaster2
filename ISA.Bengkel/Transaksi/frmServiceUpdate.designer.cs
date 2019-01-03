namespace ISA.Bengkel.Transaksi
{
    partial class frmServiceUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSPMTypeDesc = new ISA.Controls.CommonTextBox();
            this.txtSPMType = new ISA.Controls.CommonTextBox();
            this.txtKM = new ISA.Controls.CommonTextBox();
            this.txtNoPol = new ISA.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lookupSepedaMotor1 = new ISA.Bengkel.Lookup.LookupSepedaMotor();
            this.txtIDMember = new ISA.Controls.CommonTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTelp = new ISA.Controls.CommonTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNoKTP_SIM = new ISA.Controls.CommonTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAlamat = new ISA.Controls.CommonTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPemilik = new ISA.Controls.CommonTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTahun = new ISA.Controls.CommonTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWarna = new ISA.Controls.CommonTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKeluhan = new ISA.Controls.CommonTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxPerbaikan = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMekanik = new ISA.Controls.CommonTextBox();
            this.lkpMekanik = new ISA.Bengkel.Lookup.LookupMekanik();
            this.txtSaran2 = new ISA.Controls.CommonTextBox();
            this.txtSaran1 = new ISA.Controls.CommonTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lookupCustomerBengkel1 = new ISA.Bengkel.Lookup.LookupCustomerBengkel();
            this.txtNamaCust = new ISA.Controls.CommonTextBox();
            this.txtTglService = new ISA.Controls.DateTextBox();
            this.txtNoUrut = new ISA.Controls.CommonTextBox();
            this.txtShift = new ISA.Controls.CommonTextBox();
            this.txtNoDoc = new ISA.Controls.CommonTextBox();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtService = new ISA.Controls.CommonTextBox();
            this.lookupSales1 = new ISA.Bengkel.Lookup.LookupSales();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "TANGGAL SERVICE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "NOMOR URUT";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "NOMOR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "NAMA CUSTOMER";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "SHIFT";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSPMTypeDesc);
            this.groupBox1.Controls.Add(this.txtSPMType);
            this.groupBox1.Controls.Add(this.txtKM);
            this.groupBox1.Controls.Add(this.txtNoPol);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lookupSepedaMotor1);
            this.groupBox1.Controls.Add(this.txtIDMember);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtTelp);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtNoKTP_SIM);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtAlamat);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtPemilik);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtTahun);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtWarna);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(31, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 338);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEPEDA MOTOR";
            // 
            // txtSPMTypeDesc
            // 
            this.txtSPMTypeDesc.BackColor = System.Drawing.SystemColors.Window;
            this.txtSPMTypeDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSPMTypeDesc.Enabled = false;
            this.txtSPMTypeDesc.Location = new System.Drawing.Point(242, 122);
            this.txtSPMTypeDesc.Name = "txtSPMTypeDesc";
            this.txtSPMTypeDesc.ReadOnly = true;
            this.txtSPMTypeDesc.Size = new System.Drawing.Size(251, 20);
            this.txtSPMTypeDesc.TabIndex = 3;
            this.txtSPMTypeDesc.TabStop = false;
            // 
            // txtSPMType
            // 
            this.txtSPMType.BackColor = System.Drawing.SystemColors.Window;
            this.txtSPMType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSPMType.Enabled = false;
            this.txtSPMType.Location = new System.Drawing.Point(124, 122);
            this.txtSPMType.Name = "txtSPMType";
            this.txtSPMType.ReadOnly = true;
            this.txtSPMType.Size = new System.Drawing.Size(111, 20);
            this.txtSPMType.TabIndex = 2;
            this.txtSPMType.TabStop = false;
            // 
            // txtKM
            // 
            this.txtKM.BackColor = System.Drawing.SystemColors.Window;
            this.txtKM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKM.Location = new System.Drawing.Point(387, 148);
            this.txtKM.Name = "txtKM";
            this.txtKM.Size = new System.Drawing.Size(106, 20);
            this.txtKM.TabIndex = 2;
            // 
            // txtNoPol
            // 
            this.txtNoPol.BackColor = System.Drawing.SystemColors.Window;
            this.txtNoPol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoPol.Location = new System.Drawing.Point(124, 27);
            this.txtNoPol.MaxLength = 10;
            this.txtNoPol.Name = "txtNoPol";
            this.txtNoPol.Size = new System.Drawing.Size(136, 20);
            this.txtNoPol.TabIndex = 0;
            this.txtNoPol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoPol_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 28;
            this.label5.Text = "NO POLISI";
            // 
            // lookupSepedaMotor1
            // 
            this.lookupSepedaMotor1.Enabled = false;
            this.lookupSepedaMotor1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lookupSepedaMotor1.KodeSepedaMotor = "[CODE]";
            this.lookupSepedaMotor1.Location = new System.Drawing.Point(121, 52);
            this.lookupSepedaMotor1.NamaSepedaMotor = "";
            this.lookupSepedaMotor1.Name = "lookupSepedaMotor1";
            this.lookupSepedaMotor1.Size = new System.Drawing.Size(352, 54);
            this.lookupSepedaMotor1.TabIndex = 1;
            this.lookupSepedaMotor1.TabStop = false;
            this.lookupSepedaMotor1.SelectData += new System.EventHandler(this.lookupSepedaMotor1_SelectData);
            // 
            // txtIDMember
            // 
            this.txtIDMember.BackColor = System.Drawing.SystemColors.Window;
            this.txtIDMember.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDMember.Enabled = false;
            this.txtIDMember.Location = new System.Drawing.Point(124, 281);
            this.txtIDMember.Name = "txtIDMember";
            this.txtIDMember.ReadOnly = true;
            this.txtIDMember.Size = new System.Drawing.Size(212, 20);
            this.txtIDMember.TabIndex = 11;
            this.txtIDMember.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 284);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 14);
            this.label19.TabIndex = 25;
            this.label19.Text = "ID MEMBER";
            // 
            // txtTelp
            // 
            this.txtTelp.BackColor = System.Drawing.SystemColors.Window;
            this.txtTelp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelp.Enabled = false;
            this.txtTelp.Location = new System.Drawing.Point(408, 255);
            this.txtTelp.Name = "txtTelp";
            this.txtTelp.ReadOnly = true;
            this.txtTelp.Size = new System.Drawing.Size(99, 20);
            this.txtTelp.TabIndex = 10;
            this.txtTelp.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(347, 258);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 14);
            this.label18.TabIndex = 23;
            this.label18.Text = "NO. TELP";
            // 
            // txtNoKTP_SIM
            // 
            this.txtNoKTP_SIM.BackColor = System.Drawing.SystemColors.Window;
            this.txtNoKTP_SIM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoKTP_SIM.Enabled = false;
            this.txtNoKTP_SIM.Location = new System.Drawing.Point(124, 255);
            this.txtNoKTP_SIM.Name = "txtNoKTP_SIM";
            this.txtNoKTP_SIM.ReadOnly = true;
            this.txtNoKTP_SIM.Size = new System.Drawing.Size(212, 20);
            this.txtNoKTP_SIM.TabIndex = 9;
            this.txtNoKTP_SIM.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 258);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 14);
            this.label17.TabIndex = 21;
            this.label17.Text = "NO. KTP / SIM";
            // 
            // txtAlamat
            // 
            this.txtAlamat.BackColor = System.Drawing.SystemColors.Window;
            this.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat.Enabled = false;
            this.txtAlamat.Location = new System.Drawing.Point(124, 200);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(369, 49);
            this.txtAlamat.TabIndex = 8;
            this.txtAlamat.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 14);
            this.label16.TabIndex = 19;
            this.label16.Text = "ALAMAT";
            // 
            // txtPemilik
            // 
            this.txtPemilik.BackColor = System.Drawing.SystemColors.Window;
            this.txtPemilik.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPemilik.Enabled = false;
            this.txtPemilik.Location = new System.Drawing.Point(124, 174);
            this.txtPemilik.Name = "txtPemilik";
            this.txtPemilik.ReadOnly = true;
            this.txtPemilik.Size = new System.Drawing.Size(291, 20);
            this.txtPemilik.TabIndex = 7;
            this.txtPemilik.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 14);
            this.label15.TabIndex = 17;
            this.label15.Text = "PEMILIK";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(357, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 14);
            this.label14.TabIndex = 15;
            this.label14.Text = "KM";
            // 
            // txtTahun
            // 
            this.txtTahun.BackColor = System.Drawing.SystemColors.Window;
            this.txtTahun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTahun.Enabled = false;
            this.txtTahun.Location = new System.Drawing.Point(290, 148);
            this.txtTahun.Name = "txtTahun";
            this.txtTahun.ReadOnly = true;
            this.txtTahun.Size = new System.Drawing.Size(61, 20);
            this.txtTahun.TabIndex = 1;
            this.txtTahun.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(242, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 13;
            this.label13.Text = "TAHUN";
            // 
            // txtWarna
            // 
            this.txtWarna.BackColor = System.Drawing.SystemColors.Window;
            this.txtWarna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWarna.Enabled = false;
            this.txtWarna.Location = new System.Drawing.Point(124, 148);
            this.txtWarna.Name = "txtWarna";
            this.txtWarna.ReadOnly = true;
            this.txtWarna.Size = new System.Drawing.Size(111, 20);
            this.txtWarna.TabIndex = 4;
            this.txtWarna.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 14);
            this.label12.TabIndex = 11;
            this.label12.Text = "WARNA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 6;
            this.label10.Text = "JENIS SPM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 2;
            this.label7.Text = "SEPEDA MOTOR";
            // 
            // txtKeluhan
            // 
            this.txtKeluhan.BackColor = System.Drawing.SystemColors.Window;
            this.txtKeluhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeluhan.Location = new System.Drawing.Point(124, 94);
            this.txtKeluhan.Name = "txtKeluhan";
            this.txtKeluhan.Size = new System.Drawing.Size(291, 20);
            this.txtKeluhan.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 14);
            this.label11.TabIndex = 9;
            this.label11.Text = "KELUHAN";
            // 
            // cbxPerbaikan
            // 
            this.cbxPerbaikan.AutoSize = true;
            this.cbxPerbaikan.ForeColor = System.Drawing.Color.Red;
            this.cbxPerbaikan.Location = new System.Drawing.Point(300, 153);
            this.cbxPerbaikan.Name = "cbxPerbaikan";
            this.cbxPerbaikan.Size = new System.Drawing.Size(151, 18);
            this.cbxPerbaikan.TabIndex = 3;
            this.cbxPerbaikan.TabStop = false;
            this.cbxPerbaikan.Text = "PERBAIKAN INVENTARIS";
            this.cbxPerbaikan.UseVisualStyleBackColor = true;
            this.cbxPerbaikan.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMekanik);
            this.groupBox2.Controls.Add(this.lkpMekanik);
            this.groupBox2.Controls.Add(this.txtKeluhan);
            this.groupBox2.Controls.Add(this.txtSaran2);
            this.groupBox2.Controls.Add(this.txtSaran1);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(552, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 261);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SERVICE";
            // 
            // txtMekanik
            // 
            this.txtMekanik.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMekanik.Enabled = false;
            this.txtMekanik.Location = new System.Drawing.Point(288, 36);
            this.txtMekanik.Name = "txtMekanik";
            this.txtMekanik.ReadOnly = true;
            this.txtMekanik.Size = new System.Drawing.Size(255, 20);
            this.txtMekanik.TabIndex = 1;
            this.txtMekanik.TabStop = false;
            // 
            // lkpMekanik
            // 
            this.lkpMekanik.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lkpMekanik.KodeMekanik = "[CODE]";
            this.lkpMekanik.Location = new System.Drawing.Point(121, 34);
            this.lkpMekanik.NamaMekanik = "";
            this.lkpMekanik.Name = "lkpMekanik";
            this.lkpMekanik.Size = new System.Drawing.Size(161, 54);
            this.lkpMekanik.TabIndex = 0;
            this.lkpMekanik.SelectData += new System.EventHandler(this.lkpMekanik_SelectData);
            // 
            // txtSaran2
            // 
            this.txtSaran2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaran2.Location = new System.Drawing.Point(124, 169);
            this.txtSaran2.MaxLength = 60;
            this.txtSaran2.Multiline = true;
            this.txtSaran2.Name = "txtSaran2";
            this.txtSaran2.Size = new System.Drawing.Size(456, 43);
            this.txtSaran2.TabIndex = 3;
            // 
            // txtSaran1
            // 
            this.txtSaran1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaran1.Location = new System.Drawing.Point(124, 120);
            this.txtSaran1.MaxLength = 60;
            this.txtSaran1.Multiline = true;
            this.txtSaran1.Name = "txtSaran1";
            this.txtSaran1.Size = new System.Drawing.Size(456, 43);
            this.txtSaran1.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 14);
            this.label20.TabIndex = 14;
            this.label20.Text = "SARAN-SARAN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "MEKANIK";
            // 
            // lookupCustomerBengkel1
            // 
            this.lookupCustomerBengkel1.Alamat = null;
            this.lookupCustomerBengkel1.CustomerServiceRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupCustomerBengkel1.Daerah = null;
            this.lookupCustomerBengkel1.Enabled = false;
            this.lookupCustomerBengkel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lookupCustomerBengkel1.IdCust = null;
            this.lookupCustomerBengkel1.IdMember = null;
            this.lookupCustomerBengkel1.JnsSpm = null;
            this.lookupCustomerBengkel1.KodeCust = "[CODE]";
            this.lookupCustomerBengkel1.KodeSpm = null;
            this.lookupCustomerBengkel1.Kota = null;
            this.lookupCustomerBengkel1.Location = new System.Drawing.Point(138, 124);
            this.lookupCustomerBengkel1.MemberServiceRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupCustomerBengkel1.MotorServiceRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupCustomerBengkel1.NamaCust = "";
            this.lookupCustomerBengkel1.Name = "lookupCustomerBengkel1";
            this.lookupCustomerBengkel1.NoID = null;
            this.lookupCustomerBengkel1.NoMesin = null;
            this.lookupCustomerBengkel1.NoPol = null;
            this.lookupCustomerBengkel1.NoRangka = null;
            this.lookupCustomerBengkel1.NoTelp = null;
            this.lookupCustomerBengkel1.Pemilik = null;
            this.lookupCustomerBengkel1.Size = new System.Drawing.Size(153, 54);
            this.lookupCustomerBengkel1.Spm = null;
            this.lookupCustomerBengkel1.TabIndex = 1;
            this.lookupCustomerBengkel1.TabStop = false;
            this.lookupCustomerBengkel1.Tahun = null;
            this.lookupCustomerBengkel1.Warna = null;
            this.lookupCustomerBengkel1.SelectData += new System.EventHandler(this.lookupCustomerBengkel1_SelectData);
            // 
            // txtNamaCust
            // 
            this.txtNamaCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaCust.Enabled = false;
            this.txtNamaCust.Location = new System.Drawing.Point(300, 127);
            this.txtNamaCust.Name = "txtNamaCust";
            this.txtNamaCust.ReadOnly = true;
            this.txtNamaCust.Size = new System.Drawing.Size(311, 20);
            this.txtNamaCust.TabIndex = 6;
            this.txtNamaCust.TabStop = false;
            // 
            // txtTglService
            // 
            this.txtTglService.DateValue = null;
            this.txtTglService.Location = new System.Drawing.Point(141, 70);
            this.txtTglService.MaxLength = 10;
            this.txtTglService.Name = "txtTglService";
            this.txtTglService.Size = new System.Drawing.Size(111, 20);
            this.txtTglService.TabIndex = 0;
            // 
            // txtNoUrut
            // 
            this.txtNoUrut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoUrut.Enabled = false;
            this.txtNoUrut.Location = new System.Drawing.Point(141, 96);
            this.txtNoUrut.Name = "txtNoUrut";
            this.txtNoUrut.ReadOnly = true;
            this.txtNoUrut.Size = new System.Drawing.Size(111, 20);
            this.txtNoUrut.TabIndex = 3;
            this.txtNoUrut.TabStop = false;
            // 
            // txtShift
            // 
            this.txtShift.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShift.Enabled = false;
            this.txtShift.Location = new System.Drawing.Point(512, 96);
            this.txtShift.Name = "txtShift";
            this.txtShift.ReadOnly = true;
            this.txtShift.Size = new System.Drawing.Size(99, 20);
            this.txtShift.TabIndex = 4;
            this.txtShift.TabStop = false;
            // 
            // txtNoDoc
            // 
            this.txtNoDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoDoc.Enabled = false;
            this.txtNoDoc.Location = new System.Drawing.Point(512, 70);
            this.txtNoDoc.Name = "txtNoDoc";
            this.txtNoDoc.ReadOnly = true;
            this.txtNoDoc.Size = new System.Drawing.Size(100, 20);
            this.txtNoDoc.TabIndex = 1;
            this.txtNoDoc.TabStop = false;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(803, 464);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.ReportName2 = "";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
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
            this.cmdSAVE.Location = new System.Drawing.Point(674, 464);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.ReportName2 = "";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 6;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(563, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "SERVICE KE";
            // 
            // txtService
            // 
            this.txtService.BackColor = System.Drawing.SystemColors.Window;
            this.txtService.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtService.Enabled = false;
            this.txtService.Location = new System.Drawing.Point(675, 417);
            this.txtService.Name = "txtService";
            this.txtService.ReadOnly = true;
            this.txtService.Size = new System.Drawing.Size(47, 20);
            this.txtService.TabIndex = 5;
            this.txtService.TabStop = false;
            this.txtService.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.KodeSales = "[CODE]";
            this.lookupSales1.Location = new System.Drawing.Point(138, 16);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(115, 14);
            this.label21.TabIndex = 27;
            this.label21.Text = "CUSTOMER SERVICE";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lookupSales1);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Location = new System.Drawing.Point(675, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 73);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.cboService);
            this.groupBox4.Location = new System.Drawing.Point(675, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(462, 52);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 14);
            this.label23.TabIndex = 28;
            this.label23.Text = "KATEGORI SERVICE";
            // 
            // cboService
            // 
            this.cboService.FormattingEnabled = true;
            this.cboService.Items.AddRange(new object[] {
            "",
            "Umum",
            "Perbaikan Inventaris",
            "Perbaikan Karyawan",
            "Instansi",
            "Sekolah"});
            this.cboService.Location = new System.Drawing.Point(142, 19);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(232, 22);
            this.cboService.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.MediumBlue;
            this.label22.Location = new System.Drawing.Point(315, 169);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(295, 14);
            this.label22.TabIndex = 16;
            this.label22.Text = "Centang : hanya untuk service SPM milik SAS Group.";
            this.label22.Visible = false;
            // 
            // frmServiceUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1150, 535);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cbxPerbaikan);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtService);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lookupCustomerBengkel1);
            this.Controls.Add(this.txtNamaCust);
            this.Controls.Add(this.txtTglService);
            this.Controls.Add(this.txtNoUrut);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtShift);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoDoc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormID = "BKL0111";
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServiceUpdate";
            this.Text = "BKL0111 - Entry Data Service Sepeda Motor";
            this.Title = "Entry Data Service Sepeda Motor";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmServiceUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServiceUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNoDoc, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtShift, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtNoUrut, 0);
            this.Controls.SetChildIndex(this.txtTglService, 0);
            this.Controls.SetChildIndex(this.txtNamaCust, 0);
            this.Controls.SetChildIndex(this.lookupCustomerBengkel1, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtService, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.cbxPerbaikan, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private Controls.CommonTextBox txtNoDoc;
        private System.Windows.Forms.Label label8;
        private Controls.CommonTextBox txtShift;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private Controls.CommonTextBox txtTahun;
        private System.Windows.Forms.Label label13;
        private Controls.CommonTextBox txtWarna;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbxPerbaikan;
        private Controls.CommonTextBox txtTelp;
        private System.Windows.Forms.Label label18;
        private Controls.CommonTextBox txtNoKTP_SIM;
        private System.Windows.Forms.Label label17;
        private Controls.CommonTextBox txtAlamat;
        private System.Windows.Forms.Label label16;
        private Controls.CommonTextBox txtPemilik;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private Controls.CommonTextBox txtIDMember;
        private System.Windows.Forms.Label label19;
        private Controls.CommonTextBox txtSaran2;
        private Controls.CommonTextBox txtSaran1;
        private System.Windows.Forms.Label label20;
        private Controls.CommonTextBox txtNoUrut;
        private Lookup.LookupMekanik lkpMekanik;
        private Controls.DateTextBox txtTglService;
        private ISA.Bengkel.Lookup.LookupSepedaMotor lookupSepedaMotor1;
        private ISA.Controls.CommonTextBox txtNamaCust;
        private ISA.Controls.CommonTextBox txtMekanik;
        private ISA.Controls.CommonTextBox txtNoPol;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CommonTextBox txtKM;
        private ISA.Controls.CommonTextBox txtKeluhan;
        private ISA.Bengkel.Lookup.LookupCustomerBengkel lookupCustomerBengkel1;
        private ISA.Controls.CommonTextBox txtSPMTypeDesc;
        private ISA.Controls.CommonTextBox txtSPMType;
        private ISA.Controls.CommonTextBox txtService;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label21;
        private ISA.Bengkel.Lookup.LookupSales lookupSales1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboService;
    }
}
