namespace ISA.Toko.Penjualan
{
    partial class frmDODetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDODetailUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.lookupStock = new ISA.Toko.Controls.LookupStock();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQtyRQ = new ISA.Toko.Controls.NumericTextBox();
            this.txtQtyDO = new ISA.Toko.Controls.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSelisih = new ISA.Toko.Controls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHrgJual = new ISA.Toko.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtJmlHrg = new ISA.Toko.Controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoACC = new ISA.Toko.Controls.CommonTextBox();
            this.txtSatuan = new ISA.Toko.Controls.CommonTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisc1 = new ISA.Toko.Controls.NumericTextBox();
            this.txtDisc2 = new ISA.Toko.Controls.NumericTextBox();
            this.txtDisc3 = new ISA.Toko.Controls.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPotongan = new ISA.Toko.Controls.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDisc = new ISA.Toko.Controls.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalPotongan = new ISA.Toko.Controls.NumericTextBox();
            this.txtNetto = new ISA.Toko.Controls.NumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCatatan = new ISA.Toko.Controls.CommonTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDiscKompensasi = new ISA.Toko.Controls.NumericTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblBMK = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nama Barang";
            // 
            // lookupStock
            // 
            this.lookupStock.BarangID = "[CODE]";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(118, 62);
            this.lookupStock.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Toko.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(392, 54);
            this.lookupStock.TabIndex = 0;
            this.lookupStock.Load += new System.EventHandler(this.lookupStock_Load);
            this.lookupStock.Validating += new System.ComponentModel.CancelEventHandler(this.lookupStock_Validating);
            this.lookupStock.SelectData += new System.EventHandler(this.lookupStock_SelectData);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Qty. RQ";
            // 
            // txtQtyRQ
            // 
            this.txtQtyRQ.Location = new System.Drawing.Point(15, 30);
            this.txtQtyRQ.MaxLength = 10;
            this.txtQtyRQ.Name = "txtQtyRQ";
            this.txtQtyRQ.Size = new System.Drawing.Size(81, 20);
            this.txtQtyRQ.TabIndex = 1;
            this.txtQtyRQ.TextChanged += new System.EventHandler(this.txtQtyRQ_TextChanged);
            this.txtQtyRQ.Validated += new System.EventHandler(this.txtQtyRQ_Validated);
            // 
            // txtQtyDO
            // 
            this.txtQtyDO.Enabled = false;
            this.txtQtyDO.Location = new System.Drawing.Point(104, 30);
            this.txtQtyDO.MaxLength = 5;
            this.txtQtyDO.Name = "txtQtyDO";
            this.txtQtyDO.Size = new System.Drawing.Size(81, 20);
            this.txtQtyDO.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Qty. DO";
            // 
            // txtSelisih
            // 
            this.txtSelisih.Enabled = false;
            this.txtSelisih.Location = new System.Drawing.Point(192, 30);
            this.txtSelisih.MaxLength = 5;
            this.txtSelisih.Name = "txtSelisih";
            this.txtSelisih.Size = new System.Drawing.Size(81, 20);
            this.txtSelisih.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "Selisih";
            // 
            // txtHrgJual
            // 
            this.txtHrgJual.Location = new System.Drawing.Point(330, 30);
            this.txtHrgJual.MaxLength = 20;
            this.txtHrgJual.Name = "txtHrgJual";
            this.txtHrgJual.Size = new System.Drawing.Size(98, 20);
            this.txtHrgJual.TabIndex = 5;
            this.txtHrgJual.Leave += new System.EventHandler(this.txtHrgJual_Leave);
            this.txtHrgJual.Validating += new System.ComponentModel.CancelEventHandler(this.txtHrgJual_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Hrg. Satuan";
            // 
            // txtJmlHrg
            // 
            this.txtJmlHrg.Enabled = false;
            this.txtJmlHrg.Format = "#,##0.00";
            this.txtJmlHrg.Location = new System.Drawing.Point(436, 30);
            this.txtJmlHrg.Name = "txtJmlHrg";
            this.txtJmlHrg.Size = new System.Drawing.Size(98, 20);
            this.txtJmlHrg.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "Jml. Hrg.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 19;
            this.label8.Text = "No. ACC";
            // 
            // txtNoACC
            // 
            this.txtNoACC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoACC.Enabled = false;
            this.txtNoACC.Location = new System.Drawing.Point(15, 30);
            this.txtNoACC.MaxLength = 7;
            this.txtNoACC.Name = "txtNoACC";
            this.txtNoACC.Size = new System.Drawing.Size(98, 20);
            this.txtNoACC.TabIndex = 7;
            this.txtNoACC.TabStop = false;
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(282, 30);
            this.txtSatuan.MaxLength = 3;
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.Size = new System.Drawing.Size(40, 20);
            this.txtSatuan.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Sat";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 14);
            this.label10.TabIndex = 23;
            this.label10.Text = "Discount (%)";
            // 
            // txtDisc1
            // 
            this.txtDisc1.Location = new System.Drawing.Point(104, 10);
            this.txtDisc1.MaxLength = 5;
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.ReadOnly = true;
            this.txtDisc1.Size = new System.Drawing.Size(58, 20);
            this.txtDisc1.TabIndex = 8;
            this.txtDisc1.TabStop = false;
            this.txtDisc1.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc1_Validating);
            // 
            // txtDisc2
            // 
            this.txtDisc2.Location = new System.Drawing.Point(191, 10);
            this.txtDisc2.MaxLength = 5;
            this.txtDisc2.Name = "txtDisc2";
            this.txtDisc2.ReadOnly = true;
            this.txtDisc2.Size = new System.Drawing.Size(58, 20);
            this.txtDisc2.TabIndex = 9;
            this.txtDisc2.TabStop = false;
            this.txtDisc2.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc2_Validating);
            // 
            // txtDisc3
            // 
            this.txtDisc3.Location = new System.Drawing.Point(279, 10);
            this.txtDisc3.MaxLength = 5;
            this.txtDisc3.Name = "txtDisc3";
            this.txtDisc3.ReadOnly = true;
            this.txtDisc3.Size = new System.Drawing.Size(58, 20);
            this.txtDisc3.TabIndex = 10;
            this.txtDisc3.TabStop = false;
            this.txtDisc3.Validated += new System.EventHandler(this.txtDisc3_Validated);
            this.txtDisc3.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc3_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 14);
            this.label11.TabIndex = 27;
            this.label11.Text = "+";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(257, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "+";
            // 
            // txtPotongan
            // 
            this.txtPotongan.Enabled = false;
            this.txtPotongan.Location = new System.Drawing.Point(104, 43);
            this.txtPotongan.Name = "txtPotongan";
            this.txtPotongan.ReadOnly = true;
            this.txtPotongan.Size = new System.Drawing.Size(81, 20);
            this.txtPotongan.TabIndex = 12;
            this.txtPotongan.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 14);
            this.label13.TabIndex = 29;
            this.label13.Text = "Potongan";
            // 
            // txtDisc
            // 
            this.txtDisc.Enabled = false;
            this.txtDisc.Format = "#,##0.00";
            this.txtDisc.Location = new System.Drawing.Point(436, 10);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(98, 20);
            this.txtDisc.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(391, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 14);
            this.label14.TabIndex = 32;
            this.label14.Text = "Disc";
            // 
            // txtTotalPotongan
            // 
            this.txtTotalPotongan.Enabled = false;
            this.txtTotalPotongan.Format = "#,##0.00";
            this.txtTotalPotongan.Location = new System.Drawing.Point(436, 43);
            this.txtTotalPotongan.Name = "txtTotalPotongan";
            this.txtTotalPotongan.Size = new System.Drawing.Size(98, 20);
            this.txtTotalPotongan.TabIndex = 13;
            // 
            // txtNetto
            // 
            this.txtNetto.Enabled = false;
            this.txtNetto.Format = "#,##0.00";
            this.txtNetto.Location = new System.Drawing.Point(436, 94);
            this.txtNetto.Name = "txtNetto";
            this.txtNetto.Size = new System.Drawing.Size(98, 20);
            this.txtNetto.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(391, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 14);
            this.label15.TabIndex = 35;
            this.label15.Text = "Netto";
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(104, 136);
            this.txtCatatan.MaxLength = 23;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(326, 20);
            this.txtCatatan.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 14);
            this.label16.TabIndex = 23;
            this.label16.Text = "Catatan";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNoACC);
            this.panel1.Location = new System.Drawing.Point(581, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 64);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtQtyRQ);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtJmlHrg);
            this.panel2.Controls.Add(this.txtQtyDO);
            this.panel2.Controls.Add(this.txtSatuan);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtSelisih);
            this.panel2.Controls.Add(this.txtHrgJual);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(31, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 64);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtDisc2);
            this.panel3.Controls.Add(this.txtDisc);
            this.panel3.Controls.Add(this.txtDisc3);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtCatatan);
            this.panel3.Controls.Add(this.txtDisc1);
            this.panel3.Controls.Add(this.txtTotalPotongan);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtPotongan);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtNetto);
            this.panel3.Location = new System.Drawing.Point(31, 191);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 167);
            this.panel3.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(430, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 14);
            this.label18.TabIndex = 37;
            this.label18.Text = "_______________";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtDiscKompensasi);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Location = new System.Drawing.Point(581, 191);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(129, 167);
            this.panel4.TabIndex = 40;
            // 
            // txtDiscKompensasi
            // 
            this.txtDiscKompensasi.Enabled = false;
            this.txtDiscKompensasi.Format = "#,##0.00";
            this.txtDiscKompensasi.Location = new System.Drawing.Point(15, 94);
            this.txtDiscKompensasi.Name = "txtDiscKompensasi";
            this.txtDiscKompensasi.Size = new System.Drawing.Size(98, 20);
            this.txtDiscKompensasi.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 14);
            this.label17.TabIndex = 19;
            this.label17.Text = "Kompensasi (%)";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(168, 426);
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
            this.cmdSAVE.Location = new System.Drawing.Point(31, 426);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 17;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblBMK
            // 
            this.lblBMK.AutoSize = true;
            this.lblBMK.Location = new System.Drawing.Point(114, 375);
            this.lblBMK.Name = "lblBMK";
            this.lblBMK.Size = new System.Drawing.Size(124, 14);
            this.lblBMK.TabIndex = 42;
            this.lblBMK.Text = "B: 0.00  M: 0.00  K: 0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 43;
            this.label1.Text = "Harga BMK:";
            // 
            // frmDODetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(741, 504);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBMK);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookupStock);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDODetailUpdate";
            this.Text = "Detail DO";
            this.Title = "Detail DO";
            this.Load += new System.EventHandler(this.frmDODetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDODetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lookupStock, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.lblBMK, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.LookupStock lookupStock;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.NumericTextBox txtQtyRQ;
        private ISA.Toko.Controls.NumericTextBox txtQtyDO;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.NumericTextBox txtSelisih;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.NumericTextBox txtHrgJual;
        private System.Windows.Forms.Label label6;
        private ISA.Toko.Controls.NumericTextBox txtJmlHrg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ISA.Toko.Controls.CommonTextBox txtNoACC;
        private ISA.Toko.Controls.CommonTextBox txtSatuan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private ISA.Toko.Controls.NumericTextBox txtDisc1;
        private ISA.Toko.Controls.NumericTextBox txtDisc2;
        private ISA.Toko.Controls.NumericTextBox txtDisc3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private ISA.Toko.Controls.NumericTextBox txtPotongan;
        private System.Windows.Forms.Label label13;
        private ISA.Toko.Controls.NumericTextBox txtDisc;
        private System.Windows.Forms.Label label14;
        private ISA.Toko.Controls.NumericTextBox txtTotalPotongan;
        private ISA.Toko.Controls.NumericTextBox txtNetto;
        private System.Windows.Forms.Label label15;
        private ISA.Toko.Controls.CommonTextBox txtCatatan;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private ISA.Toko.Controls.NumericTextBox txtDiscKompensasi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblBMK;
        private System.Windows.Forms.Label label1;
    }
}
