namespace ISA.Toko.DO
{
    partial class FrmBarcodeDO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBarcodeDO));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CGBarang = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kendaraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.CBStok = new System.Windows.Forms.CheckBox();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.lblHarga = new System.Windows.Forms.Label();
            this.lblfilter = new System.Windows.Forms.Label();
            this.lbljw = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CGBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Kata Kunci";
            // 
            // txtCari
            // 
            this.txtCari.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtCari.Location = new System.Drawing.Point(93, 56);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(364, 20);
            this.txtCari.TabIndex = 14;
            this.txtCari.Text = "Nama Stok, Barcode, ID Barang";
            this.txtCari.Click += new System.EventHandler(this.txtCari_Click);
            this.txtCari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCari_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cari...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CGBarang
            // 
            this.CGBarang.AllowUserToAddRows = false;
            this.CGBarang.AllowUserToDeleteRows = false;
            this.CGBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CGBarang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CGBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CGBarang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.RowIDStok,
            this.NamaBarang,
            this.IdBarang,
            this.Barcode,
            this.Kendaraan,
            this.PartNo,
            this.GroupBC,
            this.StokBarang});
            this.CGBarang.Location = new System.Drawing.Point(25, 82);
            this.CGBarang.MultiSelect = false;
            this.CGBarang.Name = "CGBarang";
            this.CGBarang.ReadOnly = true;
            this.CGBarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.CGBarang.Size = new System.Drawing.Size(981, 380);
            this.CGBarang.StandardTab = true;
            this.CGBarang.TabIndex = 6;
            this.CGBarang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellDoubleClick);
            this.CGBarang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CGBarang_KeyDown);
            this.CGBarang.SelectionChanged += new System.EventHandler(this.CGBarang_SelectionChanged);
            this.CGBarang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CGBarang_CellContentClick);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "ROW ID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // RowIDStok
            // 
            this.RowIDStok.DataPropertyName = "RowIDStok";
            this.RowIDStok.HeaderText = "RowID Stok";
            this.RowIDStok.Name = "RowIDStok";
            this.RowIDStok.ReadOnly = true;
            this.RowIDStok.Visible = false;
            // 
            // NamaBarang
            // 
            this.NamaBarang.DataPropertyName = "NamaStok";
            this.NamaBarang.HeaderText = "NAMA BARANG";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            this.NamaBarang.Width = 425;
            // 
            // IdBarang
            // 
            this.IdBarang.DataPropertyName = "BarangID";
            this.IdBarang.HeaderText = "ID BARANG";
            this.IdBarang.Name = "IdBarang";
            this.IdBarang.ReadOnly = true;
            this.IdBarang.Width = 110;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "barcode";
            this.Barcode.HeaderText = "BARCODE";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Width = 110;
            // 
            // Kendaraan
            // 
            this.Kendaraan.DataPropertyName = "Kendaraan";
            this.Kendaraan.HeaderText = "KENDARAAN";
            this.Kendaraan.Name = "Kendaraan";
            this.Kendaraan.ReadOnly = true;
            this.Kendaraan.Visible = false;
            // 
            // PartNo
            // 
            this.PartNo.DataPropertyName = "partno";
            this.PartNo.HeaderText = "PART NO";
            this.PartNo.Name = "PartNo";
            this.PartNo.ReadOnly = true;
            this.PartNo.Visible = false;
            // 
            // GroupBC
            // 
            this.GroupBC.DataPropertyName = "groupbc";
            this.GroupBC.HeaderText = "GROUP BC";
            this.GroupBC.Name = "GroupBC";
            this.GroupBC.ReadOnly = true;
            this.GroupBC.Visible = false;
            // 
            // StokBarang
            // 
            this.StokBarang.DataPropertyName = "StokAkhirGudang";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StokBarang.DefaultCellStyle = dataGridViewCellStyle1;
            this.StokBarang.HeaderText = "STOK BARANG";
            this.StokBarang.Name = "StokBarang";
            this.StokBarang.ReadOnly = true;
            this.StokBarang.Width = 108;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(906, 468);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 9;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // CBStok
            // 
            this.CBStok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBStok.AutoSize = true;
            this.CBStok.Location = new System.Drawing.Point(934, 61);
            this.CBStok.Name = "CBStok";
            this.CBStok.Size = new System.Drawing.Size(69, 18);
            this.CBStok.TabIndex = 16;
            this.CBStok.Text = "Stok > 0";
            this.CBStok.UseVisualStyleBackColor = true;
            this.CBStok.Visible = false;
            this.CBStok.CheckedChanged += new System.EventHandler(this.CBStok_CheckedChanged);
            // 
            // lblNamaBarang
            // 
            this.lblNamaBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNamaBarang.AutoSize = true;
            this.lblNamaBarang.Location = new System.Drawing.Point(25, 468);
            this.lblNamaBarang.Name = "lblNamaBarang";
            this.lblNamaBarang.Size = new System.Drawing.Size(0, 14);
            this.lblNamaBarang.TabIndex = 17;
            // 
            // lblHarga
            // 
            this.lblHarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHarga.AutoSize = true;
            this.lblHarga.Location = new System.Drawing.Point(25, 483);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(0, 14);
            this.lblHarga.TabIndex = 18;
            // 
            // lblfilter
            // 
            this.lblfilter.AutoSize = true;
            this.lblfilter.Location = new System.Drawing.Point(561, 58);
            this.lblfilter.Name = "lblfilter";
            this.lblfilter.Size = new System.Drawing.Size(108, 14);
            this.lblfilter.TabIndex = 19;
            this.lblfilter.Text = "Filter Kredit Kode :";
            this.lblfilter.Visible = false;
            // 
            // lbljw
            // 
            this.lbljw.AutoSize = true;
            this.lbljw.Location = new System.Drawing.Point(668, 58);
            this.lbljw.Name = "lbljw";
            this.lbljw.Size = new System.Drawing.Size(34, 14);
            this.lbljw.TabIndex = 20;
            this.lbljw.Text = "txtjw";
            this.lbljw.Visible = false;
            // 
            // FrmBarcodeDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 512);
            this.Controls.Add(this.lbljw);
            this.Controls.Add(this.lblfilter);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.lblNamaBarang);
            this.Controls.Add(this.CBStok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.CGBarang);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBarcodeDO";
            this.Text = "PERSEDIAAN BARANG";
            this.Title = "PERSEDIAAN BARANG";
            this.Load += new System.EventHandler(this.FrmBarcode_Load);
            this.Activated += new System.EventHandler(this.FrmBarcodeDO_Activated);
            this.Controls.SetChildIndex(this.CGBarang, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.txtCari, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CBStok, 0);
            this.Controls.SetChildIndex(this.lblNamaBarang, 0);
            this.Controls.SetChildIndex(this.lblHarga, 0);
            this.Controls.SetChildIndex(this.lblfilter, 0);
            this.Controls.SetChildIndex(this.lbljw, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CGBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView CGBarang;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CBStok;
        private System.Windows.Forms.Label lblNamaBarang;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatSolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokBarang;
        private System.Windows.Forms.Label lblfilter;
        private System.Windows.Forms.Label lbljw;
    }
}