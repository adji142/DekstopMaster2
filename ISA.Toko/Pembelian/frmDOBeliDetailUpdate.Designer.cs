namespace ISA.Toko.Pembelian
{
    partial class frmDOBeliDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDOBeliDetailUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQtyBO = new ISA.Toko.Controls.NumericTextBox();
            this.txtSatuan = new ISA.Toko.Controls.CommonTextBox();
            this.txtQtyOrder = new ISA.Toko.Controls.NumericTextBox();
            this.txtJmlQtyRQ = new ISA.Toko.Controls.NumericTextBox();
            this.txtQtyAkhir = new ISA.Toko.Controls.NumericTextBox();
            this.txtQtyJual = new ISA.Toko.Controls.NumericTextBox();
            this.txtIsiKoli = new ISA.Toko.Controls.NumericTextBox();
            this.txtKet = new ISA.Toko.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.lookupStock = new ISA.Toko.Controls.LookupStock();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtQtyMin = new ISA.Toko.Controls.NumericTextBox();
            this.txtQtyMax = new ISA.Toko.Controls.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtRpTotal = new ISA.Toko.Controls.NumericTextBox();
            this.TxtHarga = new ISA.Toko.Controls.NumericTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtQtyRataJualBulan = new ISA.Toko.Controls.NumericTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Satuan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Qty. BO";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Qty. Order";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Jumlah Qty RQ";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Qty Stok Akhir";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Qty Kemampuan Jual";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Keterangan";
            // 
            // txtQtyBO
            // 
            this.txtQtyBO.Enabled = false;
            this.txtQtyBO.Location = new System.Drawing.Point(180, 43);
            this.txtQtyBO.Name = "txtQtyBO";
            this.txtQtyBO.ReadOnly = true;
            this.txtQtyBO.Size = new System.Drawing.Size(80, 20);
            this.txtQtyBO.TabIndex = 3;
            this.txtQtyBO.TabStop = false;
            this.txtQtyBO.Text = "0";
            this.txtQtyBO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyBO.Visible = false;
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(147, 68);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(40, 20);
            this.txtSatuan.TabIndex = 1;
            this.txtSatuan.TabStop = false;
            // 
            // txtQtyOrder
            // 
            this.txtQtyOrder.Location = new System.Drawing.Point(147, 130);
            this.txtQtyOrder.MaxLength = 5;
            this.txtQtyOrder.Name = "txtQtyOrder";
            this.txtQtyOrder.Size = new System.Drawing.Size(82, 20);
            this.txtQtyOrder.TabIndex = 2;
            this.txtQtyOrder.Text = "1";
            this.txtQtyOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyOrder.Validated += new System.EventHandler(this.txtQtyTambahan_Validated);
            this.txtQtyOrder.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyTambahan_Validating);
            // 
            // txtJmlQtyRQ
            // 
            this.txtJmlQtyRQ.Enabled = false;
            this.txtJmlQtyRQ.Location = new System.Drawing.Point(182, 108);
            this.txtJmlQtyRQ.Name = "txtJmlQtyRQ";
            this.txtJmlQtyRQ.ReadOnly = true;
            this.txtJmlQtyRQ.Size = new System.Drawing.Size(80, 20);
            this.txtJmlQtyRQ.TabIndex = 5;
            this.txtJmlQtyRQ.TabStop = false;
            this.txtJmlQtyRQ.Text = "0";
            this.txtJmlQtyRQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJmlQtyRQ.Visible = false;
            // 
            // txtQtyAkhir
            // 
            this.txtQtyAkhir.Location = new System.Drawing.Point(147, 213);
            this.txtQtyAkhir.Name = "txtQtyAkhir";
            this.txtQtyAkhir.ReadOnly = true;
            this.txtQtyAkhir.Size = new System.Drawing.Size(80, 20);
            this.txtQtyAkhir.TabIndex = 5;
            this.txtQtyAkhir.TabStop = false;
            this.txtQtyAkhir.Text = "0";
            this.txtQtyAkhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtyJual
            // 
            this.txtQtyJual.Location = new System.Drawing.Point(253, 196);
            this.txtQtyJual.Name = "txtQtyJual";
            this.txtQtyJual.ReadOnly = true;
            this.txtQtyJual.Size = new System.Drawing.Size(80, 20);
            this.txtQtyJual.TabIndex = 7;
            this.txtQtyJual.TabStop = false;
            this.txtQtyJual.Text = "0";
            this.txtQtyJual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyJual.Visible = false;
            // 
            // txtIsiKoli
            // 
            this.txtIsiKoli.Enabled = false;
            this.txtIsiKoli.Location = new System.Drawing.Point(94, 15);
            this.txtIsiKoli.Name = "txtIsiKoli";
            this.txtIsiKoli.ReadOnly = true;
            this.txtIsiKoli.Size = new System.Drawing.Size(80, 20);
            this.txtIsiKoli.TabIndex = 2;
            this.txtIsiKoli.TabStop = false;
            this.txtIsiKoli.Text = "0";
            this.txtIsiKoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIsiKoli.Visible = false;
            // 
            // txtKet
            // 
            this.txtKet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKet.Location = new System.Drawing.Point(147, 239);
            this.txtKet.MaxLength = 40;
            this.txtKet.Name = "txtKet";
            this.txtKet.Size = new System.Drawing.Size(280, 20);
            this.txtKet.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "____________(X)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 14);
            this.label10.TabIndex = 25;
            this.label10.Text = "1 Koli";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 14);
            this.label11.TabIndex = 26;
            this.label11.Text = "dari BO PJ2";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(145, -2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 14);
            this.label12.TabIndex = 27;
            this.label12.Text = "dari kebutuhan gudang";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(180, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "Pcs";
            this.label13.Visible = false;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(253, 290);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 8;
            this.cmdCLOSE.TabStop = false;
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
            this.cmdSAVE.Location = new System.Drawing.Point(147, 290);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 7;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // lookupStock
            // 
            this.lookupStock.BarangID = "[CODE]";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(145, 9);
            this.lookupStock.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Toko.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(282, 50);
            this.lookupStock.TabIndex = 0;
            this.lookupStock.Validated += new System.EventHandler(this.lookupStock_Validated);
            this.lookupStock.Leave += new System.EventHandler(this.lookupStock_Leave);
            this.lookupStock.SelectData += new System.EventHandler(this.lookupStock_SelectData);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtQtyMin
            // 
            this.txtQtyMin.Location = new System.Drawing.Point(253, 167);
            this.txtQtyMin.Name = "txtQtyMin";
            this.txtQtyMin.ReadOnly = true;
            this.txtQtyMin.Size = new System.Drawing.Size(80, 20);
            this.txtQtyMin.TabIndex = 30;
            this.txtQtyMin.TabStop = false;
            this.txtQtyMin.Text = "0";
            this.txtQtyMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyMin.Visible = false;
            // 
            // txtQtyMax
            // 
            this.txtQtyMax.Location = new System.Drawing.Point(479, 95);
            this.txtQtyMax.Name = "txtQtyMax";
            this.txtQtyMax.ReadOnly = true;
            this.txtQtyMax.Size = new System.Drawing.Size(80, 20);
            this.txtQtyMax.TabIndex = 29;
            this.txtQtyMax.TabStop = false;
            this.txtQtyMax.Text = "0";
            this.txtQtyMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyMax.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(110, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 14);
            this.label14.TabIndex = 32;
            this.label14.Text = "Stok Minimum";
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(110, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 14);
            this.label15.TabIndex = 31;
            this.label15.Text = "Stok Maksimum";
            this.label15.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtQtyMin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQtyBO);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtJmlQtyRQ);
            this.groupBox1.Controls.Add(this.txtQtyJual);
            this.groupBox1.Controls.Add(this.txtIsiKoli);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(494, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 16);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gak ke pake";
            this.groupBox1.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 14);
            this.label16.TabIndex = 34;
            this.label16.Text = "Rp Total";
            // 
            // TxtRpTotal
            // 
            this.TxtRpTotal.Enabled = false;
            this.TxtRpTotal.Location = new System.Drawing.Point(147, 158);
            this.TxtRpTotal.MaxLength = 5;
            this.TxtRpTotal.Name = "TxtRpTotal";
            this.TxtRpTotal.Size = new System.Drawing.Size(80, 20);
            this.TxtRpTotal.TabIndex = 3;
            this.TxtRpTotal.Text = "0";
            this.TxtRpTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtHarga
            // 
            this.TxtHarga.Location = new System.Drawing.Point(147, 98);
            this.TxtHarga.MaxLength = 20;
            this.TxtHarga.Name = "TxtHarga";
            this.TxtHarga.Size = new System.Drawing.Size(111, 20);
            this.TxtHarga.TabIndex = 1;
            this.TxtHarga.Text = "0";
            this.TxtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtHarga.Validated += new System.EventHandler(this.TxtHarga_Validated);
            this.TxtHarga.Enter += new System.EventHandler(this.TxtHarga_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 14);
            this.label17.TabIndex = 37;
            this.label17.Text = "Harga";
            // 
            // txtQtyRataJualBulan
            // 
            this.txtQtyRataJualBulan.Enabled = false;
            this.txtQtyRataJualBulan.Location = new System.Drawing.Point(147, 185);
            this.txtQtyRataJualBulan.MaxLength = 5;
            this.txtQtyRataJualBulan.Name = "txtQtyRataJualBulan";
            this.txtQtyRataJualBulan.Size = new System.Drawing.Size(80, 20);
            this.txtQtyRataJualBulan.TabIndex = 4;
            this.txtQtyRataJualBulan.Text = "0";
            this.txtQtyRataJualBulan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 188);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 14);
            this.label18.TabIndex = 39;
            this.label18.Text = "Qty Rata Jual/bulan";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtQtyRataJualBulan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtQtyMax);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtHarga);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtRpTotal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtSatuan);
            this.groupBox2.Controls.Add(this.txtQtyOrder);
            this.groupBox2.Controls.Add(this.lookupStock);
            this.groupBox2.Controls.Add(this.txtQtyAkhir);
            this.groupBox2.Controls.Add(this.cmdCLOSE);
            this.groupBox2.Controls.Add(this.txtKet);
            this.groupBox2.Controls.Add(this.cmdSAVE);
            this.groupBox2.Location = new System.Drawing.Point(26, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 342);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // frmDOBeliDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(632, 437);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDOBeliDetailUpdate";
            this.Text = "Order Pembelian Detail";
            this.Title = "Order Pembelian Detail";
            this.Load += new System.EventHandler(this.frmDOBeliDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDOBeliDetailUpdate_FormClosed);
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

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ISA.Toko.Controls.NumericTextBox txtQtyBO;
        private ISA.Toko.Controls.CommonTextBox txtSatuan;
        private ISA.Toko.Controls.NumericTextBox txtQtyOrder;
        private ISA.Toko.Controls.NumericTextBox txtJmlQtyRQ;
        private ISA.Toko.Controls.NumericTextBox txtQtyAkhir;
        private ISA.Toko.Controls.NumericTextBox txtQtyJual;
        private ISA.Toko.Controls.NumericTextBox txtIsiKoli;
        private ISA.Toko.Controls.CommonTextBox txtKet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private ISA.Toko.Controls.LookupStock lookupStock;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Toko.Controls.NumericTextBox txtQtyMin;
        private ISA.Toko.Controls.NumericTextBox txtQtyMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private ISA.Toko.Controls.NumericTextBox TxtHarga;
        private System.Windows.Forms.Label label17;
        private ISA.Toko.Controls.NumericTextBox TxtRpTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Toko.Controls.NumericTextBox txtQtyRataJualBulan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
