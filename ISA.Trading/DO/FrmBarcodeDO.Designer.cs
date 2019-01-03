namespace ISA.Trading.DO
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
            this.SatSolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.CBStok = new System.Windows.Forms.CheckBox();
            this.lblNamaBarang = new System.Windows.Forms.Label();
            this.lblHarga = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ncash = new ISA.Controls.NumericTextBox();
            this.ntop10 = new ISA.Controls.NumericTextBox();
            this.nuser = new ISA.Controls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nhpp = new ISA.Controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nHet = new ISA.Controls.NumericTextBox();
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
            this.StokBarang,
            this.SatSolo});
            this.CGBarang.Location = new System.Drawing.Point(25, 82);
            this.CGBarang.MultiSelect = false;
            this.CGBarang.Name = "CGBarang";
            this.CGBarang.ReadOnly = true;
            this.CGBarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.CGBarang.Size = new System.Drawing.Size(981, 386);
            this.CGBarang.StandardTab = true;
            this.CGBarang.TabIndex = 6;
            this.CGBarang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellDoubleClick);
            this.CGBarang.SelectionRowChanged += new System.EventHandler(this.CGBarang_SelectionRowChanged);
            this.CGBarang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CGBarang_KeyDown);
            this.CGBarang.SelectionChanged += new System.EventHandler(this.CGBarang_SelectionChanged);
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
            // 
            // PartNo
            // 
            this.PartNo.DataPropertyName = "partno";
            this.PartNo.HeaderText = "PART NO";
            this.PartNo.Name = "PartNo";
            this.PartNo.ReadOnly = true;
            // 
            // GroupBC
            // 
            this.GroupBC.DataPropertyName = "groupbc";
            this.GroupBC.HeaderText = "GROUP BC";
            this.GroupBC.Name = "GroupBC";
            this.GroupBC.ReadOnly = true;
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
            // SatSolo
            // 
            this.SatSolo.DataPropertyName = "SatSolo";
            this.SatSolo.HeaderText = "SATUAN";
            this.SatSolo.Name = "SatSolo";
            this.SatSolo.ReadOnly = true;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(906, 474);
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
            this.CBStok.CheckedChanged += new System.EventHandler(this.CBStok_CheckedChanged);
            // 
            // lblNamaBarang
            // 
            this.lblNamaBarang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNamaBarang.AutoSize = true;
            this.lblNamaBarang.Location = new System.Drawing.Point(25, 474);
            this.lblNamaBarang.Name = "lblNamaBarang";
            this.lblNamaBarang.Size = new System.Drawing.Size(0, 14);
            this.lblNamaBarang.TabIndex = 17;
            // 
            // lblHarga
            // 
            this.lblHarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHarga.AutoSize = true;
            this.lblHarga.Location = new System.Drawing.Point(25, 489);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(0, 14);
            this.lblHarga.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Harga Jual";
            // 
            // ncash
            // 
            this.ncash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ncash.Enabled = false;
            this.ncash.Location = new System.Drawing.Point(227, 472);
            this.ncash.Name = "ncash";
            this.ncash.Size = new System.Drawing.Size(75, 20);
            this.ncash.TabIndex = 20;
            this.ncash.Text = "0";
            this.ncash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ntop10
            // 
            this.ntop10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ntop10.Enabled = false;
            this.ntop10.Location = new System.Drawing.Point(334, 471);
            this.ntop10.Name = "ntop10";
            this.ntop10.Size = new System.Drawing.Size(75, 20);
            this.ntop10.TabIndex = 21;
            this.ntop10.Text = "0";
            this.ntop10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nuser
            // 
            this.nuser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nuser.Enabled = false;
            this.nuser.Location = new System.Drawing.Point(469, 472);
            this.nuser.Name = "nuser";
            this.nuser.Size = new System.Drawing.Size(75, 20);
            this.nuser.TabIndex = 22;
            this.nuser.Text = "0";
            this.nuser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 475);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cash";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Top";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "Enduser";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 27;
            this.label6.Text = "Hpp";
            // 
            // nhpp
            // 
            this.nhpp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhpp.Enabled = false;
            this.nhpp.Location = new System.Drawing.Point(115, 494);
            this.nhpp.Name = "nhpp";
            this.nhpp.Size = new System.Drawing.Size(75, 20);
            this.nhpp.TabIndex = 26;
            this.nhpp.Text = "0";
            this.nhpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 14);
            this.label7.TabIndex = 29;
            this.label7.Text = "HET";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // nHet
            // 
            this.nHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nHet.Enabled = false;
            this.nHet.Location = new System.Drawing.Point(115, 472);
            this.nHet.Name = "nHet";
            this.nHet.Size = new System.Drawing.Size(75, 20);
            this.nHet.TabIndex = 28;
            this.nHet.Text = "0";
            this.nHet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmBarcodeDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1028, 518);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nHet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nhpp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nuser);
            this.Controls.Add(this.ntop10);
            this.Controls.Add(this.ncash);
            this.Controls.Add(this.label2);
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
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.ncash, 0);
            this.Controls.SetChildIndex(this.ntop10, 0);
            this.Controls.SetChildIndex(this.nuser, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.nhpp, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.nHet, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CGBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView CGBarang;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CBStok;
        private System.Windows.Forms.Label lblNamaBarang;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatSolo;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.NumericTextBox ncash;
        private ISA.Controls.NumericTextBox ntop10;
        private ISA.Controls.NumericTextBox nuser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.NumericTextBox nhpp;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.NumericTextBox nHet;
    }
}