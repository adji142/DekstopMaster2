namespace ISA.Toko.Pembelian
{
    partial class frmMPRBeliDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMPRBeliDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.cboKodeRetur = new System.Windows.Forms.ComboBox();
            this.lookupStock = new ISA.Toko.Controls.LookupStock();
            this.txtQtyGudang = new ISA.Toko.Controls.NumericTextBox();
            this.txtCatatan = new ISA.Toko.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cboKategori = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtHrgBeli = new ISA.Toko.Controls.NumericTextBox();
            this.txtJmlHrgRetur = new ISA.Toko.Controls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSatuan = new ISA.Toko.Controls.CommonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kode Retur";
            // 
            // cboKodeRetur
            // 
            this.cboKodeRetur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKodeRetur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKodeRetur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKodeRetur.FormattingEnabled = true;
            this.cboKodeRetur.Location = new System.Drawing.Point(155, 66);
            this.cboKodeRetur.Name = "cboKodeRetur";
            this.cboKodeRetur.Size = new System.Drawing.Size(75, 22);
            this.cboKodeRetur.TabIndex = 0;
            this.cboKodeRetur.SelectedIndexChanged += new System.EventHandler(this.cboKodeRetur_SelectedIndexChanged);
            // 
            // lookupStock
            // 
            this.lookupStock.BarangID = "[CODE]";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(152, 94);
            this.lookupStock.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Toko.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(336, 50);
            this.lookupStock.TabIndex = 1;
            this.lookupStock.Load += new System.EventHandler(this.lookupStock_Load);
            this.lookupStock.Leave += new System.EventHandler(this.lookupStock_Leave);
            this.lookupStock.SelectData += new System.EventHandler(this.lookupStock_SelectData);
            // 
            // txtQtyGudang
            // 
            this.txtQtyGudang.Location = new System.Drawing.Point(155, 150);
            this.txtQtyGudang.Name = "txtQtyGudang";
            this.txtQtyGudang.Size = new System.Drawing.Size(60, 20);
            this.txtQtyGudang.TabIndex = 2;
            this.txtQtyGudang.Text = "0";
            this.txtQtyGudang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyGudang.Click += new System.EventHandler(this.txtQtyGudang_Click);
            this.txtQtyGudang.Leave += new System.EventHandler(this.txtQtyGudang_Leave);
            this.txtQtyGudang.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyGudang_Validating);
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(155, 257);
            this.txtCatatan.MaxLength = 150;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(333, 20);
            this.txtCatatan.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "Qty MPRB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Harga (Rp)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "Harga Total (Rp)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "Kategori";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = "Catatan";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(279, 300);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(155, 299);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cboKategori
            // 
            this.cboKategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKategori.FormattingEnabled = true;
            this.cboKategori.Location = new System.Drawing.Point(155, 229);
            this.cboKategori.Name = "cboKategori";
            this.cboKategori.Size = new System.Drawing.Size(285, 22);
            this.cboKategori.TabIndex = 5;
            this.cboKategori.Tag = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtHrgBeli
            // 
            this.txtHrgBeli.Enabled = false;
            this.txtHrgBeli.Location = new System.Drawing.Point(155, 176);
            this.txtHrgBeli.Name = "txtHrgBeli";
            this.txtHrgBeli.Size = new System.Drawing.Size(100, 20);
            this.txtHrgBeli.TabIndex = 3;
            this.txtHrgBeli.Text = "0";
            this.txtHrgBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHrgBeli.Leave += new System.EventHandler(this.txtHrgBeli_Leave);
            // 
            // txtJmlHrgRetur
            // 
            this.txtJmlHrgRetur.Enabled = false;
            this.txtJmlHrgRetur.Location = new System.Drawing.Point(155, 203);
            this.txtJmlHrgRetur.Name = "txtJmlHrgRetur";
            this.txtJmlHrgRetur.Size = new System.Drawing.Size(100, 20);
            this.txtJmlHrgRetur.TabIndex = 4;
            this.txtJmlHrgRetur.Text = "0";
            this.txtJmlHrgRetur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 14);
            this.label8.TabIndex = 23;
            this.label8.Text = "Satuan";
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(409, 124);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(34, 20);
            this.txtSatuan.TabIndex = 24;
            this.txtSatuan.TabStop = false;
            // 
            // frmMPRBeliDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(504, 346);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtJmlHrgRetur);
            this.Controls.Add(this.txtHrgBeli);
            this.Controls.Add(this.cboKategori);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboKodeRetur);
            this.Controls.Add(this.lookupStock);
            this.Controls.Add(this.txtQtyGudang);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "frmMPRBeliDetailUpdate";
            this.Text = "MPRB Detail";
            this.Title = "MPRB Detail";
            this.Load += new System.EventHandler(this.frmMPRBeliDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMPRBeliDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.txtQtyGudang, 0);
            this.Controls.SetChildIndex(this.lookupStock, 0);
            this.Controls.SetChildIndex(this.cboKodeRetur, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCatatan, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cboKategori, 0);
            this.Controls.SetChildIndex(this.txtHrgBeli, 0);
            this.Controls.SetChildIndex(this.txtJmlHrgRetur, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtSatuan, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKodeRetur;
        private ISA.Toko.Controls.LookupStock lookupStock;
        private ISA.Toko.Controls.NumericTextBox txtQtyGudang;
        private ISA.Toko.Controls.CommonTextBox txtCatatan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private System.Windows.Forms.ComboBox cboKategori;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Toko.Controls.NumericTextBox txtJmlHrgRetur;
        private ISA.Toko.Controls.NumericTextBox txtHrgBeli;
        private System.Windows.Forms.Label label8;
        private ISA.Toko.Controls.CommonTextBox txtSatuan;
    }
}
