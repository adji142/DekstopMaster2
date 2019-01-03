namespace ISA.Toko.Master
{
    partial class frmMasterStokUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterStokUpdate));
            this.txtSatSolo = new ISA.Toko.Controls.CommonTextBox();
            this.txtSatJual = new ISA.Toko.Controls.CommonTextBox();
            this.txtKodeRak = new ISA.Toko.Controls.CommonTextBox();
            this.txtNamaStok = new ISA.Toko.Controls.CommonTextBox();
            this.txtBarangID = new ISA.Toko.Controls.CommonTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKendaraan = new ISA.Toko.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKodeRak1 = new ISA.Toko.Controls.CommonTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKodeRak2 = new ISA.Toko.Controls.CommonTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrediksiLamaKirim = new ISA.Toko.Controls.NumericTextBox();
            this.txtHariRataRata = new ISA.Toko.Controls.NumericTextBox();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.chkStatusAktif = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTglIsi = new ISA.Toko.Controls.DateTextBox();
            this.txtTglUpdate = new ISA.Toko.Controls.DateTextBox();
            this.txtSuplier = new ISA.Toko.Controls.CommonTextBox();
            this.txtSebutanBengkel = new ISA.Toko.Controls.CommonTextBox();
            this.txtCatatan = new ISA.Toko.Controls.CommonTextBox();
            this.cbTransactionType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAtribute = new ISA.Toko.Controls.CommonTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.RBOFAST = new System.Windows.Forms.RadioButton();
            this.RBOSLOW = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RBPasif = new System.Windows.Forms.RadioButton();
            this.RBAktif = new System.Windows.Forms.RadioButton();
            this.LblTempo = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbJenisBarang = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSatSolo
            // 
            this.txtSatSolo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatSolo.Location = new System.Drawing.Point(176, 72);
            this.txtSatSolo.MaxLength = 3;
            this.txtSatSolo.Name = "txtSatSolo";
            this.txtSatSolo.Size = new System.Drawing.Size(51, 20);
            this.txtSatSolo.TabIndex = 7;
            this.txtSatSolo.Visible = false;
            this.txtSatSolo.TextChanged += new System.EventHandler(this.txtSatSolo_TextChanged);
            // 
            // txtSatJual
            // 
            this.txtSatJual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatJual.Location = new System.Drawing.Point(162, 127);
            this.txtSatJual.MaxLength = 3;
            this.txtSatJual.Name = "txtSatJual";
            this.txtSatJual.Size = new System.Drawing.Size(51, 20);
            this.txtSatJual.TabIndex = 6;
            this.txtSatJual.TextChanged += new System.EventHandler(this.txtSatJual_TextChanged);
            // 
            // txtKodeRak
            // 
            this.txtKodeRak.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeRak.Location = new System.Drawing.Point(162, 99);
            this.txtKodeRak.MaxLength = 7;
            this.txtKodeRak.Name = "txtKodeRak";
            this.txtKodeRak.Size = new System.Drawing.Size(91, 20);
            this.txtKodeRak.TabIndex = 3;
            this.txtKodeRak.TextChanged += new System.EventHandler(this.txtKodeRak_TextChanged);
            // 
            // txtNamaStok
            // 
            this.txtNamaStok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaStok.Location = new System.Drawing.Point(162, 42);
            this.txtNamaStok.MaxLength = 150;
            this.txtNamaStok.Name = "txtNamaStok";
            this.txtNamaStok.Size = new System.Drawing.Size(223, 20);
            this.txtNamaStok.TabIndex = 1;
            // 
            // txtBarangID
            // 
            this.txtBarangID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarangID.Location = new System.Drawing.Point(162, 14);
            this.txtBarangID.MaxLength = 23;
            this.txtBarangID.Name = "txtBarangID";
            this.txtBarangID.Size = new System.Drawing.Size(223, 20);
            this.txtBarangID.TabIndex = 0;
            this.txtBarangID.Visible = false;
            this.txtBarangID.TextChanged += new System.EventHandler(this.txtBarangID_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 14);
            this.label9.TabIndex = 31;
            this.label9.Text = "Prediksi Lama Kirim";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "Status Aktif";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 29;
            this.label7.Text = "Satuan Beli";
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "Satuan Jual";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Lokasi Rak 1";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nama stok";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Kode Barang";
            this.label1.Visible = false;
            // 
            // txtKendaraan
            // 
            this.txtKendaraan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKendaraan.Location = new System.Drawing.Point(162, 215);
            this.txtKendaraan.MaxLength = 43;
            this.txtKendaraan.Name = "txtKendaraan";
            this.txtKendaraan.Size = new System.Drawing.Size(223, 20);
            this.txtKendaraan.TabIndex = 12;
            this.txtKendaraan.TextChanged += new System.EventHandler(this.txtKendaraan_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 45;
            this.label5.Text = "Kendaraan";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 14);
            this.label6.TabIndex = 44;
            this.label6.Text = "Fast/Slow Moving";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 14);
            this.label10.TabIndex = 43;
            this.label10.Text = "Hari Rata-rata";
            this.label10.Visible = false;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtKodeRak1
            // 
            this.txtKodeRak1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeRak1.Location = new System.Drawing.Point(367, 99);
            this.txtKodeRak1.MaxLength = 7;
            this.txtKodeRak1.Name = "txtKodeRak1";
            this.txtKodeRak1.Size = new System.Drawing.Size(91, 20);
            this.txtKodeRak1.TabIndex = 4;
            this.txtKodeRak1.TextChanged += new System.EventHandler(this.txtKodeRak1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(278, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 14);
            this.label11.TabIndex = 49;
            this.label11.Text = "Lokasi Rak 2";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtKodeRak2
            // 
            this.txtKodeRak2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeRak2.Location = new System.Drawing.Point(571, 99);
            this.txtKodeRak2.MaxLength = 7;
            this.txtKodeRak2.Name = "txtKodeRak2";
            this.txtKodeRak2.Size = new System.Drawing.Size(91, 20);
            this.txtKodeRak2.TabIndex = 5;
            this.txtKodeRak2.TextChanged += new System.EventHandler(this.txtKodeRak2_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(483, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 14);
            this.label12.TabIndex = 51;
            this.label12.Text = "Lokasi Rak 3";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txtPrediksiLamaKirim
            // 
            this.txtPrediksiLamaKirim.Location = new System.Drawing.Point(144, 100);
            this.txtPrediksiLamaKirim.MaxLength = 9;
            this.txtPrediksiLamaKirim.Name = "txtPrediksiLamaKirim";
            this.txtPrediksiLamaKirim.Size = new System.Drawing.Size(159, 20);
            this.txtPrediksiLamaKirim.TabIndex = 9;
            this.txtPrediksiLamaKirim.Visible = false;
            this.txtPrediksiLamaKirim.TextChanged += new System.EventHandler(this.txtPrediksiLamaKirim_TextChanged);
            this.txtPrediksiLamaKirim.Validated += new System.EventHandler(this.txtPrediksiLamaKirim_Validated);
            // 
            // txtHariRataRata
            // 
            this.txtHariRataRata.Location = new System.Drawing.Point(144, 127);
            this.txtHariRataRata.MaxLength = 9;
            this.txtHariRataRata.Name = "txtHariRataRata";
            this.txtHariRataRata.Size = new System.Drawing.Size(159, 20);
            this.txtHariRataRata.TabIndex = 10;
            this.txtHariRataRata.Visible = false;
            this.txtHariRataRata.TextChanged += new System.EventHandler(this.txtHariRataRata_TextChanged);
            this.txtHariRataRata.Validated += new System.EventHandler(this.txtHariRataRata_Validated);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(297, 362);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 18;
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
            this.cmdSAVE.Location = new System.Drawing.Point(162, 362);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 17;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // chkStatusAktif
            // 
            this.chkStatusAktif.AutoSize = true;
            this.chkStatusAktif.Checked = true;
            this.chkStatusAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatusAktif.Location = new System.Drawing.Point(18, 76);
            this.chkStatusAktif.Name = "chkStatusAktif";
            this.chkStatusAktif.Size = new System.Drawing.Size(15, 14);
            this.chkStatusAktif.TabIndex = 7;
            this.chkStatusAktif.UseVisualStyleBackColor = true;
            this.chkStatusAktif.CheckedChanged += new System.EventHandler(this.chkStatusAktif_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 14);
            this.label13.TabIndex = 55;
            this.label13.Text = "Nama Sebutan Bengkel";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 14);
            this.label14.TabIndex = 54;
            this.label14.Text = "Suplier";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 296);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 14);
            this.label15.TabIndex = 59;
            this.label15.Text = "Catatan";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 267);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 14);
            this.label16.TabIndex = 58;
            this.label16.Text = "Kelompok Transaksi";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 14);
            this.label17.TabIndex = 63;
            this.label17.Text = "Tgl Update";
            this.label17.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 14);
            this.label18.TabIndex = 62;
            this.label18.Text = "Tgl ISI";
            this.label18.Visible = false;
            // 
            // txtTglIsi
            // 
            this.txtTglIsi.DateValue = null;
            this.txtTglIsi.Location = new System.Drawing.Point(158, 19);
            this.txtTglIsi.MaxLength = 10;
            this.txtTglIsi.Name = "txtTglIsi";
            this.txtTglIsi.Size = new System.Drawing.Size(177, 20);
            this.txtTglIsi.TabIndex = 11;
            this.txtTglIsi.Visible = false;
            // 
            // txtTglUpdate
            // 
            this.txtTglUpdate.DateValue = null;
            this.txtTglUpdate.Location = new System.Drawing.Point(158, 48);
            this.txtTglUpdate.MaxLength = 10;
            this.txtTglUpdate.Name = "txtTglUpdate";
            this.txtTglUpdate.Size = new System.Drawing.Size(177, 20);
            this.txtTglUpdate.TabIndex = 12;
            this.txtTglUpdate.Visible = false;
            // 
            // txtSuplier
            // 
            this.txtSuplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSuplier.Location = new System.Drawing.Point(162, 241);
            this.txtSuplier.MaxLength = 64;
            this.txtSuplier.Name = "txtSuplier";
            this.txtSuplier.Size = new System.Drawing.Size(264, 20);
            this.txtSuplier.TabIndex = 13;
            this.txtSuplier.TextChanged += new System.EventHandler(this.txtSuplier_TextChanged);
            // 
            // txtSebutanBengkel
            // 
            this.txtSebutanBengkel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSebutanBengkel.Location = new System.Drawing.Point(162, 68);
            this.txtSebutanBengkel.MaxLength = 150;
            this.txtSebutanBengkel.Name = "txtSebutanBengkel";
            this.txtSebutanBengkel.Size = new System.Drawing.Size(223, 20);
            this.txtSebutanBengkel.TabIndex = 2;
            this.txtSebutanBengkel.TextChanged += new System.EventHandler(this.txtSebutanBengkel_TextChanged);
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(162, 293);
            this.txtCatatan.MaxLength = 100;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(355, 20);
            this.txtCatatan.TabIndex = 15;
            // 
            // cbTransactionType
            // 
            this.cbTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTransactionType.FormattingEnabled = true;
            this.cbTransactionType.Location = new System.Drawing.Point(162, 267);
            this.cbTransactionType.Name = "cbTransactionType";
            this.cbTransactionType.Size = new System.Drawing.Size(184, 22);
            this.cbTransactionType.TabIndex = 14;
            this.cbTransactionType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTglIsi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSatSolo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtTglUpdate);
            this.groupBox1.Controls.Add(this.txtPrediksiLamaKirim);
            this.groupBox1.Controls.Add(this.txtHariRataRata);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.chkStatusAktif);
            this.groupBox1.Location = new System.Drawing.Point(514, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 17);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Siapa Tau Besok Digunain";
            this.groupBox1.Visible = false;
            // 
            // txtAtribute
            // 
            this.txtAtribute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAtribute.Location = new System.Drawing.Point(300, 465);
            this.txtAtribute.MaxLength = 100;
            this.txtAtribute.Name = "txtAtribute";
            this.txtAtribute.Size = new System.Drawing.Size(355, 20);
            this.txtAtribute.TabIndex = 16;
            this.txtAtribute.Visible = false;
            this.txtAtribute.TextChanged += new System.EventHandler(this.commonTextBox1_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(161, 468);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 14);
            this.label19.TabIndex = 67;
            this.label19.Text = "Attribute";
            this.label19.Visible = false;
            // 
            // RBOFAST
            // 
            this.RBOFAST.AutoSize = true;
            this.RBOFAST.Checked = true;
            this.RBOFAST.Location = new System.Drawing.Point(6, 8);
            this.RBOFAST.Name = "RBOFAST";
            this.RBOFAST.Size = new System.Drawing.Size(52, 18);
            this.RBOFAST.TabIndex = 9;
            this.RBOFAST.TabStop = true;
            this.RBOFAST.Text = "FAST";
            this.RBOFAST.UseVisualStyleBackColor = true;
            this.RBOFAST.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RBOSLOW
            // 
            this.RBOSLOW.AutoSize = true;
            this.RBOSLOW.Location = new System.Drawing.Point(119, 8);
            this.RBOSLOW.Name = "RBOSLOW";
            this.RBOSLOW.Size = new System.Drawing.Size(57, 18);
            this.RBOSLOW.TabIndex = 10;
            this.RBOSLOW.Text = "SLOW";
            this.RBOSLOW.UseVisualStyleBackColor = true;
            this.RBOSLOW.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBOSLOW);
            this.groupBox2.Controls.Add(this.RBOFAST);
            this.groupBox2.Location = new System.Drawing.Point(162, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 27);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RBPasif);
            this.groupBox3.Controls.Add(this.RBAktif);
            this.groupBox3.Location = new System.Drawing.Point(162, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 26);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // RBPasif
            // 
            this.RBPasif.AutoSize = true;
            this.RBPasif.Location = new System.Drawing.Point(119, 7);
            this.RBPasif.Name = "RBPasif";
            this.RBPasif.Size = new System.Drawing.Size(55, 18);
            this.RBPasif.TabIndex = 8;
            this.RBPasif.Text = "PASIF";
            this.RBPasif.UseVisualStyleBackColor = true;
            // 
            // RBAktif
            // 
            this.RBAktif.AutoSize = true;
            this.RBAktif.Checked = true;
            this.RBAktif.Location = new System.Drawing.Point(6, 7);
            this.RBAktif.Name = "RBAktif";
            this.RBAktif.Size = new System.Drawing.Size(56, 18);
            this.RBAktif.TabIndex = 7;
            this.RBAktif.TabStop = true;
            this.RBAktif.Text = "AKTIF";
            this.RBAktif.UseVisualStyleBackColor = true;
            // 
            // LblTempo
            // 
            this.LblTempo.AutoSize = true;
            this.LblTempo.Location = new System.Drawing.Point(364, 270);
            this.LblTempo.Name = "LblTempo";
            this.LblTempo.Size = new System.Drawing.Size(72, 14);
            this.LblTempo.TabIndex = 68;
            this.LblTempo.Text = "Tempo       : ";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.cbJenisBarang);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.LblTempo);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtBarangID);
            this.groupBox4.Controls.Add(this.txtNamaStok);
            this.groupBox4.Controls.Add(this.cbTransactionType);
            this.groupBox4.Controls.Add(this.txtKodeRak);
            this.groupBox4.Controls.Add(this.txtCatatan);
            this.groupBox4.Controls.Add(this.txtSatJual);
            this.groupBox4.Controls.Add(this.txtSebutanBengkel);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtSuplier);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtKendaraan);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtKodeRak1);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.cmdCLOSE);
            this.groupBox4.Controls.Add(this.txtKodeRak2);
            this.groupBox4.Controls.Add(this.cmdSAVE);
            this.groupBox4.Location = new System.Drawing.Point(26, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(673, 427);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            // 
            // cbJenisBarang
            // 
            this.cbJenisBarang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbJenisBarang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbJenisBarang.FormattingEnabled = true;
            this.cbJenisBarang.Location = new System.Drawing.Point(162, 319);
            this.cbJenisBarang.Name = "cbJenisBarang";
            this.cbJenisBarang.Size = new System.Drawing.Size(355, 22);
            this.cbJenisBarang.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 319);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 14);
            this.label20.TabIndex = 70;
            this.label20.Text = "Jenis Barang";
            // 
            // frmMasterStokUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(722, 491);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtAtribute);
            this.FormID = "SC0237";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMasterStokUpdate";
            this.Text = "SC0237 - Master Stok";
            this.Title = "Master Stok";
            this.Load += new System.EventHandler(this.frmMasterStokUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMasterStokUpdate_FormClosed);
            this.Controls.SetChildIndex(this.txtAtribute, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
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

        private ISA.Toko.Controls.CommonTextBox txtSatSolo;
        private ISA.Toko.Controls.CommonTextBox txtSatJual;
        private ISA.Toko.Controls.CommonTextBox txtKodeRak;
        private ISA.Toko.Controls.CommonTextBox txtNamaStok;
        private ISA.Toko.Controls.CommonTextBox txtBarangID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox txtKendaraan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private ISA.Toko.Controls.CommonTextBox txtKodeRak1;
        private System.Windows.Forms.Label label11;
        private ISA.Toko.Controls.CommonTextBox txtKodeRak2;
        private System.Windows.Forms.Label label12;
        private ISA.Toko.Controls.NumericTextBox txtPrediksiLamaKirim;
        private ISA.Toko.Controls.NumericTextBox txtHariRataRata;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.CheckBox chkStatusAktif;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private ISA.Toko.Controls.DateTextBox txtTglUpdate;
        private ISA.Toko.Controls.DateTextBox txtTglIsi;
        private ISA.Toko.Controls.CommonTextBox txtCatatan;
        private ISA.Toko.Controls.CommonTextBox txtSebutanBengkel;
        private ISA.Toko.Controls.CommonTextBox txtSuplier;
        private System.Windows.Forms.ComboBox cbTransactionType;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Toko.Controls.CommonTextBox txtAtribute;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton RBOSLOW;
        private System.Windows.Forms.RadioButton RBOFAST;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RBPasif;
        private System.Windows.Forms.RadioButton RBAktif;
        private System.Windows.Forms.Label LblTempo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbJenisBarang;
        private System.Windows.Forms.Label label20;
    }
}
