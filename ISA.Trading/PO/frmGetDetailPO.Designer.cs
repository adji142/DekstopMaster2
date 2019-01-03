namespace ISA.Trading.PO
{
    partial class frmGetDetailPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetDetailPO));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTglFrom = new System.Windows.Forms.TextBox();
            this.txtTglTo = new System.Windows.Forms.TextBox();
            this.txtNoPo = new System.Windows.Forms.TextBox();
            this.txtKelompok = new System.Windows.Forms.TextBox();
            this.txtNamaStok = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxStok = new System.Windows.Forms.CheckBox();
            this.cmdProses = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIDBarang = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdValidation = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.SpikeOrder = new System.Windows.Forms.Button();
            this.klmpk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Refil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stokk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bufer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fisk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spikee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cek = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periode Refill";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nomer PO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kelompok";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(14, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nama Stok";
            // 
            // txtTglFrom
            // 
            this.txtTglFrom.Enabled = false;
            this.txtTglFrom.Location = new System.Drawing.Point(126, 8);
            this.txtTglFrom.Name = "txtTglFrom";
            this.txtTglFrom.Size = new System.Drawing.Size(116, 20);
            this.txtTglFrom.TabIndex = 4;
            this.txtTglFrom.TextChanged += new System.EventHandler(this.txtTglFrom_TextChanged);
            // 
            // txtTglTo
            // 
            this.txtTglTo.Enabled = false;
            this.txtTglTo.Location = new System.Drawing.Point(290, 8);
            this.txtTglTo.Name = "txtTglTo";
            this.txtTglTo.Size = new System.Drawing.Size(116, 20);
            this.txtTglTo.TabIndex = 5;
            // 
            // txtNoPo
            // 
            this.txtNoPo.Enabled = false;
            this.txtNoPo.Location = new System.Drawing.Point(126, 44);
            this.txtNoPo.Name = "txtNoPo";
            this.txtNoPo.Size = new System.Drawing.Size(281, 20);
            this.txtNoPo.TabIndex = 6;
            // 
            // txtKelompok
            // 
            this.txtKelompok.Enabled = false;
            this.txtKelompok.Location = new System.Drawing.Point(126, 76);
            this.txtKelompok.Name = "txtKelompok";
            this.txtKelompok.Size = new System.Drawing.Size(116, 20);
            this.txtKelompok.TabIndex = 7;
            // 
            // txtNamaStok
            // 
            this.txtNamaStok.Enabled = false;
            this.txtNamaStok.Location = new System.Drawing.Point(126, 111);
            this.txtNamaStok.Name = "txtNamaStok";
            this.txtNamaStok.Size = new System.Drawing.Size(116, 20);
            this.txtNamaStok.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(250, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "s/d";
            // 
            // cbxStok
            // 
            this.cbxStok.AutoSize = true;
            this.cbxStok.Location = new System.Drawing.Point(126, 148);
            this.cbxStok.Name = "cbxStok";
            this.cbxStok.Size = new System.Drawing.Size(111, 18);
            this.cbxStok.TabIndex = 10;
            this.cbxStok.Text = "Stock Sampling";
            this.cbxStok.UseVisualStyleBackColor = true;
            this.cbxStok.Visible = false;
            // 
            // cmdProses
            // 
            this.cmdProses.Image = ((System.Drawing.Image)(resources.GetObject("cmdProses.Image")));
            this.cmdProses.Location = new System.Drawing.Point(290, 75);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(117, 47);
            this.cmdProses.TabIndex = 11;
            this.cmdProses.Text = "PROSES";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIDBarang);
            this.panel1.Controls.Add(this.cmdProses);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxStok);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNamaStok);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtKelompok);
            this.panel1.Controls.Add(this.txtTglFrom);
            this.panel1.Controls.Add(this.txtNoPo);
            this.panel1.Controls.Add(this.txtTglTo);
            this.panel1.Location = new System.Drawing.Point(87, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 190);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtIDBarang
            // 
            this.txtIDBarang.Location = new System.Drawing.Point(290, 140);
            this.txtIDBarang.Name = "txtIDBarang";
            this.txtIDBarang.Size = new System.Drawing.Size(100, 20);
            this.txtIDBarang.TabIndex = 21;
            this.txtIDBarang.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(716, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 190);
            this.panel2.TabIndex = 13;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(446, 14);
            this.label13.TabIndex = 15;
            this.label13.Text = "tekan tombol Auto Validation untuk validasi semua item barang secara otomatis";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(14, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(400, 14);
            this.label12.TabIndex = 14;
            this.label12.Text = "Barang yang akan di Order Harus di Hitung & di Input di Sampling Opname";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(14, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Perhatian !!!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(392, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "4. Tekan F3 untuk melakukan Spike Order (Permintaan diluar standart)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(432, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "3. Tekan SPACEBAR pada item untuk melakukan validasi per item barang, atau";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(472, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "2. Setelah proses selesai,akan muncul item yg terjadi refill & BO sesuai periode " +
                "diatas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(420, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "1. Lakukan proses \'pengecekan Refill dengan mengClick tombol \" Proses \"";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label6.Location = new System.Drawing.Point(14, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cara Pengisian PO";
            // 
            // cmdValidation
            // 
            this.cmdValidation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdValidation.Location = new System.Drawing.Point(85, 529);
            this.cmdValidation.Name = "cmdValidation";
            this.cmdValidation.Size = new System.Drawing.Size(159, 50);
            this.cmdValidation.TabIndex = 15;
            this.cmdValidation.Text = "Auto Validation";
            this.cmdValidation.UseVisualStyleBackColor = true;
            this.cmdValidation.Click += new System.EventHandler(this.cmdValidation_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Image = global::ISA.Trading.Properties.Resources.Printer32;
            this.cmdPrint.Location = new System.Drawing.Point(896, 535);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(87, 44);
            this.cmdPrint.TabIndex = 16;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Visible = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Image = global::ISA.Trading.Properties.Resources.Save32;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(1062, 535);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(87, 44);
            this.cmdSave.TabIndex = 17;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdExit.Image = global::ISA.Trading.Properties.Resources.Close32;
            this.cmdExit.Location = new System.Drawing.Point(1205, 535);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(102, 44);
            this.cmdExit.TabIndex = 18;
            this.cmdExit.Text = "CLOSE";
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.klmpk,
            this.namaStok,
            this.Sat,
            this.Refil,
            this.backorder,
            this.stokk,
            this.bufer,
            this.fisk,
            this.spikee,
            this.poo,
            this.ket,
            this.cek,
            this.Keterangan});
            this.customGridView1.Location = new System.Drawing.Point(63, 280);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(1202, 243);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 19;
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // SpikeOrder
            // 
            this.SpikeOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SpikeOrder.Location = new System.Drawing.Point(750, 535);
            this.SpikeOrder.Name = "SpikeOrder";
            this.SpikeOrder.Size = new System.Drawing.Size(87, 44);
            this.SpikeOrder.TabIndex = 20;
            this.SpikeOrder.Text = "Spike Order";
            this.SpikeOrder.UseVisualStyleBackColor = true;
            this.SpikeOrder.Click += new System.EventHandler(this.SpikeOrder_Click);
            // 
            // klmpk
            // 
            this.klmpk.DataPropertyName = "BarangID";
            this.klmpk.HeaderText = "Kode Barang";
            this.klmpk.Name = "klmpk";
            this.klmpk.ReadOnly = true;
            // 
            // namaStok
            // 
            this.namaStok.DataPropertyName = "NamaStok";
            this.namaStok.HeaderText = "Nama Stok";
            this.namaStok.Name = "namaStok";
            this.namaStok.ReadOnly = true;
            this.namaStok.Width = 300;
            // 
            // Sat
            // 
            this.Sat.DataPropertyName = "SatJual";
            this.Sat.HeaderText = "Satuan";
            this.Sat.Name = "Sat";
            this.Sat.ReadOnly = true;
            this.Sat.Width = 50;
            // 
            // Refil
            // 
            this.Refil.DataPropertyName = "nQrefil";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.Refil.DefaultCellStyle = dataGridViewCellStyle1;
            this.Refil.HeaderText = "Refil";
            this.Refil.Name = "Refil";
            this.Refil.ReadOnly = true;
            this.Refil.Width = 50;
            // 
            // backorder
            // 
            this.backorder.DataPropertyName = "nQbo";
            this.backorder.HeaderText = "BO";
            this.backorder.Name = "backorder";
            this.backorder.ReadOnly = true;
            this.backorder.Width = 50;
            // 
            // stokk
            // 
            this.stokk.DataPropertyName = "nQStok";
            this.stokk.HeaderText = "Stok";
            this.stokk.Name = "stokk";
            this.stokk.ReadOnly = true;
            this.stokk.Width = 50;
            // 
            // bufer
            // 
            this.bufer.DataPropertyName = "nqbufer";
            this.bufer.HeaderText = "Buffer";
            this.bufer.Name = "bufer";
            this.bufer.ReadOnly = true;
            this.bufer.Width = 50;
            // 
            // fisk
            // 
            this.fisk.DataPropertyName = "nQFisik";
            this.fisk.HeaderText = "Fisik";
            this.fisk.Name = "fisk";
            this.fisk.ReadOnly = true;
            this.fisk.Width = 50;
            // 
            // spikee
            // 
            this.spikee.DataPropertyName = "nQSpike";
            this.spikee.HeaderText = "Spike";
            this.spikee.Name = "spikee";
            this.spikee.ReadOnly = true;
            this.spikee.Width = 50;
            // 
            // poo
            // 
            this.poo.DataPropertyName = "nQPO";
            this.poo.HeaderText = "P/O";
            this.poo.Name = "poo";
            this.poo.ReadOnly = true;
            this.poo.Width = 50;
            // 
            // ket
            // 
            this.ket.DataPropertyName = "alasan";
            this.ket.HeaderText = "Catatan";
            this.ket.Name = "ket";
            this.ket.ReadOnly = true;
            this.ket.Width = 150;
            // 
            // cek
            // 
            this.cek.DividerWidth = 1;
            this.cek.FalseValue = "0";
            this.cek.HeaderText = "Chek";
            this.cek.Name = "cek";
            this.cek.ReadOnly = true;
            this.cek.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cek.TrueValue = "1";
            this.cek.Width = 50;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 150;
            // 
            // frmGetDetailPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 591);
            this.Controls.Add(this.SpikeOrder);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdValidation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGetDetailPO";
            this.Text = "frmGetDetailPO";
            this.Load += new System.EventHandler(this.frmGetDetailPO_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.cmdValidation, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdExit, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.SpikeOrder, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTglFrom;
        private System.Windows.Forms.TextBox txtTglTo;
        private System.Windows.Forms.TextBox txtNoPo;
        private System.Windows.Forms.TextBox txtKelompok;
        private System.Windows.Forms.TextBox txtNamaStok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxStok;
        private System.Windows.Forms.Button cmdProses;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdValidation;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdExit;
        private ISA.Trading.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.Button SpikeOrder;
        private System.Windows.Forms.TextBox txtIDBarang;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn klmpk;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Refil;
        private System.Windows.Forms.DataGridViewTextBoxColumn backorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokk;
        private System.Windows.Forms.DataGridViewTextBoxColumn bufer;
        private System.Windows.Forms.DataGridViewTextBoxColumn fisk;
        private System.Windows.Forms.DataGridViewTextBoxColumn spikee;
        private System.Windows.Forms.DataGridViewTextBoxColumn poo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ket;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
    }
}