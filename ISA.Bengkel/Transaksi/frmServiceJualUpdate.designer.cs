namespace ISA.Bengkel.Transaksi
{
    partial class frmServiceJualUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceJualUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSatuan = new ISA.Controls.CommonTextBox();
            this.txtQty = new ISA.Controls.NumericTextBox();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtHargaSat = new ISA.Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJumlah = new ISA.Controls.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lkpStokBkl = new ISA.Bengkel.Lookup.LookupStokBkl();
            this.lookupToko1 = new ISA.Controls.LookupToko();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "NAMA STOK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Satuan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "QTY";
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(172, 175);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(40, 20);
            this.txtSatuan.TabIndex = 1;
            this.txtSatuan.TabStop = false;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(172, 201);
            this.txtQty.MaxLength = 5;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(96, 20);
            this.txtQty.TabIndex = 2;
            this.txtQty.Text = "0";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(274, 288);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.ReportName2 = "";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 6;
            this.cmdCLOSE.TabStop = false;
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
            this.cmdSAVE.Location = new System.Drawing.Point(168, 288);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.ReportName2 = "";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 5;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtHargaSat
            // 
            this.txtHargaSat.Location = new System.Drawing.Point(172, 227);
            this.txtHargaSat.MaxLength = 8;
            this.txtHargaSat.Name = "txtHargaSat";
            this.txtHargaSat.Size = new System.Drawing.Size(96, 20);
            this.txtHargaSat.TabIndex = 3;
            this.txtHargaSat.Text = "0";
            this.txtHargaSat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaSat.Leave += new System.EventHandler(this.txtHargaSat_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "HARGA SAT";
            // 
            // txtJumlah
            // 
            this.txtJumlah.BackColor = System.Drawing.SystemColors.Control;
            this.txtJumlah.Enabled = false;
            this.txtJumlah.Location = new System.Drawing.Point(172, 253);
            this.txtJumlah.MaxLength = 8;
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(96, 20);
            this.txtJumlah.TabIndex = 4;
            this.txtJumlah.Text = "0";
            this.txtJumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "JUMLAH";
            // 
            // lkpStokBkl
            // 
            this.lkpStokBkl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lkpStokBkl.KodeStokBkl = "[CODE]";
            this.lkpStokBkl.Location = new System.Drawing.Point(171, 69);
            this.lkpStokBkl.LookUpType = ISA.Bengkel.Lookup.LookupStokBkl.EnumLookUpType.Normal;
            this.lkpStokBkl.NamaStokBkl = "";
            this.lkpStokBkl.Name = "lkpStokBkl";
            this.lkpStokBkl.RowStokBkl = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkpStokBkl.Satuan = null;
            this.lkpStokBkl.Size = new System.Drawing.Size(442, 54);
            this.lkpStokBkl.TabIndex = 0;
            this.lkpStokBkl.SelectData += new System.EventHandler(this.lkpStokBkl_SelectData);
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Catatan = "";
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.Grade = "";
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "[CODE]";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(172, 115);
            this.lookupToko1.LookUpType = ISA.Controls.LookupToko.EnumLookUpType.Aktif;
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.Pasif = false;
            this.lookupToko1.Penanggungjawab = "";
            this.lookupToko1.Plafon = 0;
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(300, 54);
            this.lookupToko1.TabIndex = 18;
            this.lookupToko1.Telp = "";
            this.lookupToko1.TokoID = null;
            this.lookupToko1.Visible = false;
            this.lookupToko1.WilID = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "Customer";
            this.label6.Visible = false;
            // 
            // frmServiceJualUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(618, 356);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.lkpStokBkl);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHargaSat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormID = "BKL0114";
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServiceJualUpdate";
            this.Text = "BKL0114 - Entry Pengeluaran Sparepart";
            this.Title = "Entry Pengeluaran Sparepart";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmServiceJualUpdate_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtSatuan, 0);
            this.Controls.SetChildIndex(this.txtQty, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtHargaSat, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtJumlah, 0);
            this.Controls.SetChildIndex(this.lkpStokBkl, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CommonTextBox txtSatuan;
        private ISA.Controls.NumericTextBox txtQty;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controls.NumericTextBox txtJumlah;
        private System.Windows.Forms.Label label4;
        private Controls.NumericTextBox txtHargaSat;
        private System.Windows.Forms.Label label1;
        private Lookup.LookupStokBkl lkpStokBkl;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.LookupToko lookupToko1;
    }
}
