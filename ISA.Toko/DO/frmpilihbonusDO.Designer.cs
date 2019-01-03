namespace ISA.Toko.DO
{
    partial class frmpilihbonusDO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpilihbonusDO));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.datagridviewBarangPromo = new ISA.Toko.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h_jual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDbarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.datagridviewpromotetap = new ISA.Toko.Controls.CustomGridView();
            this.datagridviewpromokelompok = new ISA.Toko.Controls.CustomGridView();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdbarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hr_jual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtybunus1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cek = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSave = new ISA.Toko.Controls.CommandButton();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.PromoTetap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hrg_jual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kd_brg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyBonus2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pilihTetap = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewBarangPromo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewpromotetap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewpromokelompok)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.datagridviewBarangPromo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.datagridviewpromotetap, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.datagridviewpromokelompok, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 69);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.91228F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.08772F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 320);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // datagridviewBarangPromo
            // 
            this.datagridviewBarangPromo.AllowUserToAddRows = false;
            this.datagridviewBarangPromo.AllowUserToDeleteRows = false;
            this.datagridviewBarangPromo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridviewBarangPromo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridviewBarangPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewBarangPromo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.h_jual,
            this.sat,
            this.IDbarang,
            this.BarangP,
            this.QtyBonus,
            this.pilih});
            this.datagridviewBarangPromo.Location = new System.Drawing.Point(3, 19);
            this.datagridviewBarangPromo.MultiSelect = false;
            this.datagridviewBarangPromo.Name = "datagridviewBarangPromo";
            this.datagridviewBarangPromo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagridviewBarangPromo.Size = new System.Drawing.Size(646, 87);
            this.datagridviewBarangPromo.StandardTab = true;
            this.datagridviewBarangPromo.TabIndex = 0;
            this.datagridviewBarangPromo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridviewBarangPromo_CellClick);
            this.datagridviewBarangPromo.CurrentCellDirtyStateChanged += new System.EventHandler(this.datagridviewBarangPromo_CurrentCellDirtyStateChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "PromoDetailRowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.Visible = false;
            // 
            // h_jual
            // 
            this.h_jual.DataPropertyName = "h_jual";
            this.h_jual.HeaderText = "Harga Jual";
            this.h_jual.Name = "h_jual";
            this.h_jual.Visible = false;
            // 
            // sat
            // 
            this.sat.DataPropertyName = "satuan";
            this.sat.HeaderText = "satuan";
            this.sat.Name = "sat";
            this.sat.Visible = false;
            // 
            // IDbarang
            // 
            this.IDbarang.DataPropertyName = "id_brg";
            this.IDbarang.HeaderText = "BarangID";
            this.IDbarang.Name = "IDbarang";
            this.IDbarang.Visible = false;
            // 
            // BarangP
            // 
            this.BarangP.DataPropertyName = "nama_stok";
            this.BarangP.HeaderText = "Nama Barang Promo";
            this.BarangP.Name = "BarangP";
            this.BarangP.ReadOnly = true;
            this.BarangP.Width = 400;
            // 
            // QtyBonus
            // 
            this.QtyBonus.HeaderText = "Qty Bonus";
            this.QtyBonus.Name = "QtyBonus";
            this.QtyBonus.ReadOnly = true;
            // 
            // pilih
            // 
            this.pilih.HeaderText = "Pilih";
            this.pilih.Name = "pilih";
            // 
            // datagridviewpromotetap
            // 
            this.datagridviewpromotetap.AllowUserToAddRows = false;
            this.datagridviewpromotetap.AllowUserToDeleteRows = false;
            this.datagridviewpromotetap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridviewpromotetap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridviewpromotetap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewpromotetap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PromoTetap,
            this.hrg_jual,
            this.Satuan,
            this.kd_brg,
            this.idRow,
            this.QtyBonus2,
            this.pilihTetap});
            this.datagridviewpromotetap.Location = new System.Drawing.Point(3, 237);
            this.datagridviewpromotetap.MultiSelect = false;
            this.datagridviewpromotetap.Name = "datagridviewpromotetap";
            this.datagridviewpromotetap.ReadOnly = true;
            this.datagridviewpromotetap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagridviewpromotetap.Size = new System.Drawing.Size(646, 80);
            this.datagridviewpromotetap.StandardTab = true;
            this.datagridviewpromotetap.TabIndex = 1;
            this.datagridviewpromotetap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridviewpromotetap_CellClick);
            // 
            // datagridviewpromokelompok
            // 
            this.datagridviewpromokelompok.AllowUserToAddRows = false;
            this.datagridviewpromokelompok.AllowUserToDeleteRows = false;
            this.datagridviewpromokelompok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridviewpromokelompok.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridviewpromokelompok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewpromokelompok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.stuan,
            this.kdbarang,
            this.NamaBarang,
            this.hr_jual,
            this.qtybunus1,
            this.cek});
            this.datagridviewpromokelompok.Location = new System.Drawing.Point(3, 128);
            this.datagridviewpromokelompok.MultiSelect = false;
            this.datagridviewpromokelompok.Name = "datagridviewpromokelompok";
            this.datagridviewpromokelompok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagridviewpromokelompok.Size = new System.Drawing.Size(646, 88);
            this.datagridviewpromokelompok.StandardTab = true;
            this.datagridviewpromokelompok.TabIndex = 2;
            this.datagridviewpromokelompok.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridviewpromokelompok_CellClick);
            this.datagridviewpromokelompok.CurrentCellDirtyStateChanged += new System.EventHandler(this.datagridviewpromokelompok_CurrentCellDirtyStateChanged);
            // 
            // Row
            // 
            this.Row.DataPropertyName = "PromoDetailRowID";
            this.Row.HeaderText = "RowID";
            this.Row.Name = "Row";
            this.Row.Visible = false;
            // 
            // stuan
            // 
            this.stuan.DataPropertyName = "satuan";
            this.stuan.HeaderText = "satuan";
            this.stuan.Name = "stuan";
            this.stuan.Visible = false;
            // 
            // kdbarang
            // 
            this.kdbarang.DataPropertyName = "id_brg";
            this.kdbarang.HeaderText = "Barang ID";
            this.kdbarang.Name = "kdbarang";
            this.kdbarang.Visible = false;
            // 
            // NamaBarang
            // 
            this.NamaBarang.DataPropertyName = "nama_stok";
            this.NamaBarang.HeaderText = "Nama Barang Promo";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            this.NamaBarang.Width = 400;
            // 
            // hr_jual
            // 
            this.hr_jual.DataPropertyName = "h_jual";
            this.hr_jual.HeaderText = "Harga Jual";
            this.hr_jual.Name = "hr_jual";
            this.hr_jual.Visible = false;
            // 
            // qtybunus1
            // 
            this.qtybunus1.HeaderText = "Qty Bonus";
            this.qtybunus1.Name = "qtybunus1";
            // 
            // cek
            // 
            this.cek.HeaderText = "Pilih";
            this.cek.Name = "cek";
            this.cek.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Promo Barang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Promo Kelompok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Promo Tetap";
            // 
            // cbSave
            // 
            this.cbSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cbSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cbSave.Image = ((System.Drawing.Image)(resources.GetObject("cbSave.Image")));
            this.cbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSave.Location = new System.Drawing.Point(382, 404);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(100, 40);
            this.cbSave.TabIndex = 28;
            this.cbSave.Text = "SAVE";
            this.cbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSave.UseVisualStyleBackColor = true;
            this.cbSave.Click += new System.EventHandler(this.cbSave_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(511, 404);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 29;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // PromoTetap
            // 
            this.PromoTetap.DataPropertyName = "nama_stok";
            this.PromoTetap.HeaderText = "Nama Barang Promo";
            this.PromoTetap.Name = "PromoTetap";
            this.PromoTetap.ReadOnly = true;
            this.PromoTetap.Width = 400;
            // 
            // hrg_jual
            // 
            this.hrg_jual.DataPropertyName = "h_jual";
            this.hrg_jual.HeaderText = "Harga Jual";
            this.hrg_jual.Name = "hrg_jual";
            this.hrg_jual.ReadOnly = true;
            this.hrg_jual.Visible = false;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "satuan";
            this.Satuan.HeaderText = "satuan";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Visible = false;
            // 
            // kd_brg
            // 
            this.kd_brg.DataPropertyName = "id_brg";
            this.kd_brg.HeaderText = "Barang ID";
            this.kd_brg.Name = "kd_brg";
            this.kd_brg.ReadOnly = true;
            this.kd_brg.Visible = false;
            // 
            // idRow
            // 
            this.idRow.DataPropertyName = "PromoDetailRowID";
            this.idRow.HeaderText = "Row ID";
            this.idRow.Name = "idRow";
            this.idRow.ReadOnly = true;
            this.idRow.Visible = false;
            // 
            // QtyBonus2
            // 
            this.QtyBonus2.DataPropertyName = "qtypromo";
            this.QtyBonus2.HeaderText = "Qty Bonus";
            this.QtyBonus2.Name = "QtyBonus2";
            this.QtyBonus2.ReadOnly = true;
            // 
            // pilihTetap
            // 
            this.pilihTetap.FalseValue = "";
            this.pilihTetap.HeaderText = "Pilih";
            this.pilihTetap.Name = "pilihTetap";
            this.pilihTetap.ReadOnly = true;
            this.pilihTetap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pilihTetap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.pilihTetap.ThreeState = true;
            this.pilihTetap.TrueValue = "";
            // 
            // frmpilihbonusDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 462);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmpilihbonusDO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Barang Bonus DO";
            this.Title = "Barang Bonus DO";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmpilihbonus_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cbSave, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewBarangPromo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewpromotetap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewpromokelompok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Toko.Controls.CustomGridView datagridviewBarangPromo;
        private ISA.Toko.Controls.CustomGridView datagridviewpromotetap;
        private ISA.Toko.Controls.CustomGridView datagridviewpromokelompok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommandButton cbSave;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn h_jual;
        private System.Windows.Forms.DataGridViewTextBoxColumn sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDbarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangP;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyBonus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn stuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdbarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn hr_jual;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtybunus1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cek;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromoTetap;
        private System.Windows.Forms.DataGridViewTextBoxColumn hrg_jual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_brg;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyBonus2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pilihTetap;
    }
}