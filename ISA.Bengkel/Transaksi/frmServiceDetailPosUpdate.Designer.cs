namespace ISA.Bengkel.Transaksi
{
    partial class frmServiceDetailPosUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceDetailPosUpdate));
            this.txtNamaStok = new ISA.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarangID = new ISA.Controls.CommonTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSatuan = new ISA.Controls.CommonTextBox();
            this.txtJmlHrg = new ISA.Controls.NumericTextBox();
            this.txtHrgJual = new ISA.Controls.NumericTextBox();
            this.txtSelisih = new ISA.Controls.NumericTextBox();
            this.txtQtyDO = new ISA.Controls.NumericTextBox();
            this.txtQtyRQ = new ISA.Controls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoACC = new ISA.Controls.CommonTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCatatan = new ISA.Controls.CommonTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNetto = new ISA.Controls.NumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalPotongan = new ISA.Controls.NumericTextBox();
            this.txtPotongan = new ISA.Controls.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDisc = new ISA.Controls.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDisc3 = new ISA.Controls.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDisc2 = new ISA.Controls.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisc1 = new ISA.Controls.NumericTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDiscKompensasi = new ISA.Controls.NumericTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNamaStok
            // 
            this.txtNamaStok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaStok.Enabled = false;
            this.txtNamaStok.Location = new System.Drawing.Point(115, 68);
            this.txtNamaStok.Name = "txtNamaStok";
            this.txtNamaStok.ReadOnly = true;
            this.txtNamaStok.Size = new System.Drawing.Size(435, 20);
            this.txtNamaStok.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sparepart";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kode";
            // 
            // txtBarangID
            // 
            this.txtBarangID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarangID.Enabled = false;
            this.txtBarangID.Location = new System.Drawing.Point(115, 92);
            this.txtBarangID.Name = "txtBarangID";
            this.txtBarangID.ReadOnly = true;
            this.txtBarangID.Size = new System.Drawing.Size(147, 20);
            this.txtBarangID.TabIndex = 2;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(514, 355);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(620, 355);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSatuan);
            this.panel1.Controls.Add(this.txtJmlHrg);
            this.panel1.Controls.Add(this.txtHrgJual);
            this.panel1.Controls.Add(this.txtSelisih);
            this.panel1.Controls.Add(this.txtQtyDO);
            this.panel1.Controls.Add(this.txtQtyRQ);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(30, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 69);
            this.panel1.TabIndex = 3;
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(276, 30);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(39, 20);
            this.txtSatuan.TabIndex = 3;
            // 
            // txtJmlHrg
            // 
            this.txtJmlHrg.Enabled = false;
            this.txtJmlHrg.Location = new System.Drawing.Point(439, 30);
            this.txtJmlHrg.Name = "txtJmlHrg";
            this.txtJmlHrg.ReadOnly = true;
            this.txtJmlHrg.Size = new System.Drawing.Size(80, 20);
            this.txtJmlHrg.TabIndex = 5;
            this.txtJmlHrg.Text = "0";
            this.txtJmlHrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHrgJual
            // 
            this.txtHrgJual.Location = new System.Drawing.Point(333, 30);
            this.txtHrgJual.Name = "txtHrgJual";
            this.txtHrgJual.Size = new System.Drawing.Size(80, 20);
            this.txtHrgJual.TabIndex = 4;
            this.txtHrgJual.Text = "0";
            this.txtHrgJual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHrgJual.Validating += new System.ComponentModel.CancelEventHandler(this.txtHrgJual_Validating);
            // 
            // txtSelisih
            // 
            this.txtSelisih.Enabled = false;
            this.txtSelisih.Location = new System.Drawing.Point(190, 30);
            this.txtSelisih.Name = "txtSelisih";
            this.txtSelisih.ReadOnly = true;
            this.txtSelisih.Size = new System.Drawing.Size(80, 20);
            this.txtSelisih.TabIndex = 2;
            this.txtSelisih.Text = "0";
            this.txtSelisih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtyDO
            // 
            this.txtQtyDO.Location = new System.Drawing.Point(104, 30);
            this.txtQtyDO.Name = "txtQtyDO";
            this.txtQtyDO.Size = new System.Drawing.Size(80, 20);
            this.txtQtyDO.TabIndex = 1;
            this.txtQtyDO.Text = "0";
            this.txtQtyDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyDO.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyDO_Validating_1);
            // 
            // txtQtyRQ
            // 
            this.txtQtyRQ.Enabled = false;
            this.txtQtyRQ.Location = new System.Drawing.Point(18, 30);
            this.txtQtyRQ.Name = "txtQtyRQ";
            this.txtQtyRQ.ReadOnly = true;
            this.txtQtyRQ.Size = new System.Drawing.Size(80, 20);
            this.txtQtyRQ.TabIndex = 0;
            this.txtQtyRQ.Text = "0";
            this.txtQtyRQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "Qty. RQ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "Qty. DO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(282, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 14);
            this.label9.TabIndex = 27;
            this.label9.Text = "Sat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "Hrg. Satuan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(436, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "Jml. Hrg.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "Selisih";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtNoACC);
            this.panel2.Location = new System.Drawing.Point(570, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 69);
            this.panel2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "No. ACC";
            // 
            // txtNoACC
            // 
            this.txtNoACC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoACC.Enabled = false;
            this.txtNoACC.Location = new System.Drawing.Point(20, 30);
            this.txtNoACC.Name = "txtNoACC";
            this.txtNoACC.ReadOnly = true;
            this.txtNoACC.Size = new System.Drawing.Size(104, 20);
            this.txtNoACC.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtCatatan);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtNetto);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txtTotalPotongan);
            this.panel3.Controls.Add(this.txtPotongan);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtDisc);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtDisc3);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtDisc2);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtDisc1);
            this.panel3.Location = new System.Drawing.Point(30, 189);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 156);
            this.panel3.TabIndex = 4;
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(104, 120);
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(309, 20);
            this.txtCatatan.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 14);
            this.label19.TabIndex = 41;
            this.label19.Text = "Catatan";
            // 
            // txtNetto
            // 
            this.txtNetto.Enabled = false;
            this.txtNetto.Location = new System.Drawing.Point(438, 90);
            this.txtNetto.Name = "txtNetto";
            this.txtNetto.ReadOnly = true;
            this.txtNetto.Size = new System.Drawing.Size(82, 20);
            this.txtNetto.TabIndex = 6;
            this.txtNetto.Text = "0";
            this.txtNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(397, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 14);
            this.label15.TabIndex = 40;
            this.label15.Text = "Netto";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(428, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 14);
            this.label18.TabIndex = 39;
            this.label18.Text = "_______________";
            // 
            // txtTotalPotongan
            // 
            this.txtTotalPotongan.Enabled = false;
            this.txtTotalPotongan.Location = new System.Drawing.Point(439, 44);
            this.txtTotalPotongan.Name = "txtTotalPotongan";
            this.txtTotalPotongan.ReadOnly = true;
            this.txtTotalPotongan.Size = new System.Drawing.Size(80, 20);
            this.txtTotalPotongan.TabIndex = 5;
            this.txtTotalPotongan.Text = "0";
            this.txtTotalPotongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPotongan
            // 
            this.txtPotongan.Location = new System.Drawing.Point(104, 44);
            this.txtPotongan.Name = "txtPotongan";
            this.txtPotongan.Size = new System.Drawing.Size(80, 20);
            this.txtPotongan.TabIndex = 4;
            this.txtPotongan.Text = "0";
            this.txtPotongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPotongan.Validating += new System.ComponentModel.CancelEventHandler(this.txtPotongan_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 14);
            this.label13.TabIndex = 35;
            this.label13.Text = "Potongan";
            // 
            // txtDisc
            // 
            this.txtDisc.Enabled = false;
            this.txtDisc.Location = new System.Drawing.Point(440, 13);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.ReadOnly = true;
            this.txtDisc.Size = new System.Drawing.Size(79, 20);
            this.txtDisc.TabIndex = 3;
            this.txtDisc.Text = "0";
            this.txtDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(403, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 14);
            this.label14.TabIndex = 33;
            this.label14.Text = "Disc";
            // 
            // txtDisc3
            // 
            this.txtDisc3.Location = new System.Drawing.Point(276, 13);
            this.txtDisc3.Name = "txtDisc3";
            this.txtDisc3.Size = new System.Drawing.Size(58, 20);
            this.txtDisc3.TabIndex = 2;
            this.txtDisc3.Text = "0";
            this.txtDisc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc3.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc3_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(257, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 14);
            this.label12.TabIndex = 27;
            this.label12.Text = "+";
            // 
            // txtDisc2
            // 
            this.txtDisc2.Location = new System.Drawing.Point(190, 13);
            this.txtDisc2.Name = "txtDisc2";
            this.txtDisc2.Size = new System.Drawing.Size(58, 20);
            this.txtDisc2.TabIndex = 1;
            this.txtDisc2.Text = "0";
            this.txtDisc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc2.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc2_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 14);
            this.label11.TabIndex = 25;
            this.label11.Text = "+";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 14);
            this.label10.TabIndex = 24;
            this.label10.Text = "Discount (%)";
            // 
            // txtDisc1
            // 
            this.txtDisc1.Location = new System.Drawing.Point(104, 13);
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.Size = new System.Drawing.Size(58, 20);
            this.txtDisc1.TabIndex = 0;
            this.txtDisc1.Text = "0";
            this.txtDisc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc1.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc1_Validating);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtDiscKompensasi);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Location = new System.Drawing.Point(570, 189);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(150, 156);
            this.panel4.TabIndex = 6;
            // 
            // txtDiscKompensasi
            // 
            this.txtDiscKompensasi.Enabled = false;
            this.txtDiscKompensasi.Location = new System.Drawing.Point(20, 90);
            this.txtDiscKompensasi.Name = "txtDiscKompensasi";
            this.txtDiscKompensasi.ReadOnly = true;
            this.txtDiscKompensasi.Size = new System.Drawing.Size(104, 20);
            this.txtDiscKompensasi.TabIndex = 0;
            this.txtDiscKompensasi.Text = "0";
            this.txtDiscKompensasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 14);
            this.label17.TabIndex = 20;
            this.label17.Text = "Kompensasi (%)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 14);
            this.label16.TabIndex = 41;
            this.label16.Text = "Catatan";
            // 
            // frmServiceDetailPosUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(746, 416);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtBarangID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNamaStok);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServiceDetailPosUpdate";
            this.Text = "Edit Sparepart Bengkel";
            this.Title = "Edit Sparepart Bengkel";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmServiceDetailPosUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServiceDetailPosUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNamaStok, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtBarangID, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommonTextBox txtNamaStok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtBarangID;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.NumericTextBox txtJmlHrg;
        private ISA.Controls.NumericTextBox txtHrgJual;
        private ISA.Controls.NumericTextBox txtSelisih;
        private ISA.Controls.NumericTextBox txtQtyDO;
        private ISA.Controls.NumericTextBox txtQtyRQ;
        private ISA.Controls.CommonTextBox txtSatuan;
        private System.Windows.Forms.Panel panel2;
        private ISA.Controls.CommonTextBox txtNoACC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private ISA.Controls.NumericTextBox txtDisc1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private ISA.Controls.NumericTextBox txtDisc3;
        private System.Windows.Forms.Label label12;
        private ISA.Controls.NumericTextBox txtDisc2;
        private System.Windows.Forms.Label label14;
        private ISA.Controls.NumericTextBox txtDisc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label17;
        private ISA.Controls.NumericTextBox txtDiscKompensasi;
        private ISA.Controls.NumericTextBox txtPotongan;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.NumericTextBox txtTotalPotongan;
        private System.Windows.Forms.Label label18;
        private ISA.Controls.NumericTextBox txtNetto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private ISA.Controls.CommonTextBox txtCatatan;
        private System.Windows.Forms.Label label19;
    }
}
