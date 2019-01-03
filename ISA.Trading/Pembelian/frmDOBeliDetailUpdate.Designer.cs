namespace ISA.Trading.Pembelian
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
            this.txtQtyBO = new ISA.Trading.Controls.NumericTextBox();
            this.txtSatuan = new ISA.Trading.Controls.CommonTextBox();
            this.txtQtyTambahan = new ISA.Trading.Controls.NumericTextBox();
            this.txtJmlQtyRQ = new ISA.Trading.Controls.NumericTextBox();
            this.txtQtyAkhir = new ISA.Trading.Controls.NumericTextBox();
            this.txtQtyJual = new ISA.Trading.Controls.NumericTextBox();
            this.txtIsiKoli = new ISA.Trading.Controls.NumericTextBox();
            this.txtKet = new ISA.Trading.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.lookupStock = new ISA.Trading.Controls.LookupStock();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtQtyMin = new ISA.Trading.Controls.NumericTextBox();
            this.txtQtyMax = new ISA.Trading.Controls.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Satuan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Qty. BO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Qty. Tambahan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Jumlah Qty RQ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Qty Stok Akhir";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Qty Kemampuan Jual";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Keterangan";
            // 
            // txtQtyBO
            // 
            this.txtQtyBO.Enabled = false;
            this.txtQtyBO.Location = new System.Drawing.Point(171, 144);
            this.txtQtyBO.Name = "txtQtyBO";
            this.txtQtyBO.ReadOnly = true;
            this.txtQtyBO.Size = new System.Drawing.Size(80, 20);
            this.txtQtyBO.TabIndex = 3;
            this.txtQtyBO.TabStop = false;
            this.txtQtyBO.Text = "0";
            this.txtQtyBO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(171, 118);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(40, 20);
            this.txtSatuan.TabIndex = 1;
            this.txtSatuan.TabStop = false;
            // 
            // txtQtyTambahan
            // 
            this.txtQtyTambahan.Location = new System.Drawing.Point(171, 170);
            this.txtQtyTambahan.MaxLength = 5;
            this.txtQtyTambahan.Name = "txtQtyTambahan";
            this.txtQtyTambahan.Size = new System.Drawing.Size(80, 20);
            this.txtQtyTambahan.TabIndex = 4;
            this.txtQtyTambahan.Text = "0";
            this.txtQtyTambahan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyTambahan.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyTambahan_Validating);
            // 
            // txtJmlQtyRQ
            // 
            this.txtJmlQtyRQ.Enabled = false;
            this.txtJmlQtyRQ.Location = new System.Drawing.Point(171, 210);
            this.txtJmlQtyRQ.Name = "txtJmlQtyRQ";
            this.txtJmlQtyRQ.ReadOnly = true;
            this.txtJmlQtyRQ.Size = new System.Drawing.Size(80, 20);
            this.txtJmlQtyRQ.TabIndex = 5;
            this.txtJmlQtyRQ.TabStop = false;
            this.txtJmlQtyRQ.Text = "0";
            this.txtJmlQtyRQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtyAkhir
            // 
            this.txtQtyAkhir.Location = new System.Drawing.Point(171, 244);
            this.txtQtyAkhir.Name = "txtQtyAkhir";
            this.txtQtyAkhir.ReadOnly = true;
            this.txtQtyAkhir.Size = new System.Drawing.Size(80, 20);
            this.txtQtyAkhir.TabIndex = 6;
            this.txtQtyAkhir.TabStop = false;
            this.txtQtyAkhir.Text = "0";
            this.txtQtyAkhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtyJual
            // 
            this.txtQtyJual.Location = new System.Drawing.Point(171, 270);
            this.txtQtyJual.Name = "txtQtyJual";
            this.txtQtyJual.ReadOnly = true;
            this.txtQtyJual.Size = new System.Drawing.Size(80, 20);
            this.txtQtyJual.TabIndex = 7;
            this.txtQtyJual.TabStop = false;
            this.txtQtyJual.Text = "0";
            this.txtQtyJual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIsiKoli
            // 
            this.txtIsiKoli.Enabled = false;
            this.txtIsiKoli.Location = new System.Drawing.Point(313, 118);
            this.txtIsiKoli.Name = "txtIsiKoli";
            this.txtIsiKoli.ReadOnly = true;
            this.txtIsiKoli.Size = new System.Drawing.Size(80, 20);
            this.txtIsiKoli.TabIndex = 2;
            this.txtIsiKoli.TabStop = false;
            this.txtIsiKoli.Text = "0";
            this.txtIsiKoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKet
            // 
            this.txtKet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKet.Location = new System.Drawing.Point(171, 296);
            this.txtKet.MaxLength = 40;
            this.txtKet.Name = "txtKet";
            this.txtKet.Size = new System.Drawing.Size(280, 20);
            this.txtKet.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(166, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "____________(+)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(258, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 14);
            this.label10.TabIndex = 25;
            this.label10.Text = "1 Koli";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(258, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 14);
            this.label11.TabIndex = 26;
            this.label11.Text = "dari BO PJ2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(258, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 14);
            this.label12.TabIndex = 27;
            this.label12.Text = "dari kebutuhan gudang";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(399, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "Pcs";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(275, 343);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 10;
            this.cmdCLOSE.TabStop = false;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(169, 343);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 9;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // lookupStock
            // 
            this.lookupStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupStock.BarangID = "[CODE]";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(167, 62);
            this.lookupStock.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(619, 50);
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
            this.txtQtyMin.Location = new System.Drawing.Point(402, 273);
            this.txtQtyMin.Name = "txtQtyMin";
            this.txtQtyMin.ReadOnly = true;
            this.txtQtyMin.Size = new System.Drawing.Size(80, 20);
            this.txtQtyMin.TabIndex = 30;
            this.txtQtyMin.TabStop = false;
            this.txtQtyMin.Text = "0";
            this.txtQtyMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtyMax
            // 
            this.txtQtyMax.Location = new System.Drawing.Point(402, 247);
            this.txtQtyMax.Name = "txtQtyMax";
            this.txtQtyMax.ReadOnly = true;
            this.txtQtyMax.Size = new System.Drawing.Size(80, 20);
            this.txtQtyMax.TabIndex = 29;
            this.txtQtyMax.TabStop = false;
            this.txtQtyMax.Text = "0";
            this.txtQtyMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(259, 276);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 14);
            this.label14.TabIndex = 32;
            this.label14.Text = "Stok Minimum";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(259, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 14);
            this.label15.TabIndex = 31;
            this.label15.Text = "Stok Maksimum";
            // 
            // frmDOBeliDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(803, 394);
            this.Controls.Add(this.txtQtyMin);
            this.Controls.Add(this.txtQtyMax);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lookupStock);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKet);
            this.Controls.Add(this.txtIsiKoli);
            this.Controls.Add(this.txtQtyJual);
            this.Controls.Add(this.txtQtyAkhir);
            this.Controls.Add(this.txtJmlQtyRQ);
            this.Controls.Add(this.txtQtyTambahan);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.txtQtyBO);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDOBeliDetailUpdate";
            this.Text = "Order Pembelian Detail";
            this.Title = "Order Pembelian Detail";
            this.Load += new System.EventHandler(this.frmDOBeliDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDOBeliDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtQtyBO, 0);
            this.Controls.SetChildIndex(this.txtSatuan, 0);
            this.Controls.SetChildIndex(this.txtQtyTambahan, 0);
            this.Controls.SetChildIndex(this.txtJmlQtyRQ, 0);
            this.Controls.SetChildIndex(this.txtQtyAkhir, 0);
            this.Controls.SetChildIndex(this.txtQtyJual, 0);
            this.Controls.SetChildIndex(this.txtIsiKoli, 0);
            this.Controls.SetChildIndex(this.txtKet, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.lookupStock, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtQtyMax, 0);
            this.Controls.SetChildIndex(this.txtQtyMin, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private ISA.Trading.Controls.NumericTextBox txtQtyBO;
        private ISA.Trading.Controls.CommonTextBox txtSatuan;
        private ISA.Trading.Controls.NumericTextBox txtQtyTambahan;
        private ISA.Trading.Controls.NumericTextBox txtJmlQtyRQ;
        private ISA.Trading.Controls.NumericTextBox txtQtyAkhir;
        private ISA.Trading.Controls.NumericTextBox txtQtyJual;
        private ISA.Trading.Controls.NumericTextBox txtIsiKoli;
        private ISA.Trading.Controls.CommonTextBox txtKet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
        private ISA.Trading.Controls.LookupStock lookupStock;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Trading.Controls.NumericTextBox txtQtyMin;
        private ISA.Trading.Controls.NumericTextBox txtQtyMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}
