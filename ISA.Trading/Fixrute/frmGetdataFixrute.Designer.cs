﻿namespace ISA.Trading.Fixrute
{
    partial class frmGetdataFixrute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetdataFixrute));
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.dateTextBox1 = new ISA.Trading.Controls.DateTextBox();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.M1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tg1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tg2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tg3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tg4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tg5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tg6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Harii = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Jenis = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daerah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kecamatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kd_toko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = global::ISA.Trading.Properties.Resources.Printer32;
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(10, 453);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 58;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 63;
            this.label1.Text = "Tanggal Berlaku";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(1040, 453);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 66;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1146, 453);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 65;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(256, 465);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(126, 20);
            this.dateTextBox1.TabIndex = 64;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M1,
            this.Tg1,
            this.M2,
            this.Tg2,
            this.M3,
            this.Tg3,
            this.M4,
            this.Tg4,
            this.M5,
            this.Tg5,
            this.M6,
            this.Tg6,
            this.Harii,
            this.Jenis,
            this.NamaToko,
            this.Alamat,
            this.Kota,
            this.Daerah,
            this.Kecamatan,
            this.Flag,
            this.KodeSales,
            this.kd_toko});
            this.customGridView1.Location = new System.Drawing.Point(12, 70);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(1234, 365);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 5;
            // 
            // M1
            // 
            this.M1.DataPropertyName = "m1";
            this.M1.HeaderText = "M1";
            this.M1.Name = "M1";
            this.M1.ReadOnly = true;
            this.M1.Width = 50;
            // 
            // Tg1
            // 
            this.Tg1.DataPropertyName = "tgl1";
            this.Tg1.HeaderText = "Tg1";
            this.Tg1.Name = "Tg1";
            this.Tg1.ReadOnly = true;
            this.Tg1.Width = 40;
            // 
            // M2
            // 
            this.M2.DataPropertyName = "m2";
            this.M2.HeaderText = "M2";
            this.M2.Name = "M2";
            this.M2.ReadOnly = true;
            this.M2.Width = 50;
            // 
            // Tg2
            // 
            this.Tg2.DataPropertyName = "tgl2";
            this.Tg2.HeaderText = "Tg2";
            this.Tg2.Name = "Tg2";
            this.Tg2.ReadOnly = true;
            this.Tg2.Width = 40;
            // 
            // M3
            // 
            this.M3.DataPropertyName = "m3";
            this.M3.HeaderText = "M3";
            this.M3.Name = "M3";
            this.M3.ReadOnly = true;
            this.M3.Width = 50;
            // 
            // Tg3
            // 
            this.Tg3.DataPropertyName = "tgl3";
            this.Tg3.HeaderText = "Tg3";
            this.Tg3.Name = "Tg3";
            this.Tg3.ReadOnly = true;
            this.Tg3.Width = 40;
            // 
            // M4
            // 
            this.M4.DataPropertyName = "m4";
            this.M4.HeaderText = "M4";
            this.M4.Name = "M4";
            this.M4.ReadOnly = true;
            this.M4.Width = 50;
            // 
            // Tg4
            // 
            this.Tg4.DataPropertyName = "tgl4";
            this.Tg4.HeaderText = "Tg4";
            this.Tg4.Name = "Tg4";
            this.Tg4.ReadOnly = true;
            this.Tg4.Width = 40;
            // 
            // M5
            // 
            this.M5.DataPropertyName = "m5";
            this.M5.HeaderText = "M5";
            this.M5.Name = "M5";
            this.M5.ReadOnly = true;
            this.M5.Width = 50;
            // 
            // Tg5
            // 
            this.Tg5.DataPropertyName = "tgl5";
            this.Tg5.HeaderText = "Tg5";
            this.Tg5.Name = "Tg5";
            this.Tg5.ReadOnly = true;
            this.Tg5.Width = 40;
            // 
            // M6
            // 
            this.M6.DataPropertyName = "m6";
            this.M6.HeaderText = "M6";
            this.M6.Name = "M6";
            this.M6.ReadOnly = true;
            this.M6.Width = 50;
            // 
            // Tg6
            // 
            this.Tg6.DataPropertyName = "tgl6";
            this.Tg6.HeaderText = "Tg6";
            this.Tg6.Name = "Tg6";
            this.Tg6.ReadOnly = true;
            this.Tg6.Width = 40;
            // 
            // Harii
            // 
            this.Harii.DataPropertyName = "hari";
            this.Harii.HeaderText = "Hari";
            this.Harii.Items.AddRange(new object[] {
            "Senin",
            "Selasa",
            "Rabu",
            "Kamis",
            "Jumat",
            "Sabtu",
            "Minggu"});
            this.Harii.Name = "Harii";
            this.Harii.ReadOnly = true;
            this.Harii.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Harii.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Jenis
            // 
            this.Jenis.DataPropertyName = "jenis";
            this.Jenis.HeaderText = "Jenis";
            this.Jenis.Items.AddRange(new object[] {
            "W",
            "B",
            "M"});
            this.Jenis.Name = "Jenis";
            this.Jenis.ReadOnly = true;
            this.Jenis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Jenis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Jenis.Width = 60;
            // 
            // NamaToko
            // 
            this.NamaToko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaToko.DataPropertyName = "namatoko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Alamat.DataPropertyName = "alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kota.DataPropertyName = "kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // Daerah
            // 
            this.Daerah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Daerah.DataPropertyName = "daerah";
            this.Daerah.HeaderText = "Daerah";
            this.Daerah.Name = "Daerah";
            this.Daerah.ReadOnly = true;
            // 
            // Kecamatan
            // 
            this.Kecamatan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kecamatan.DataPropertyName = "kecamatan";
            this.Kecamatan.HeaderText = "Kecamatan";
            this.Kecamatan.Name = "Kecamatan";
            this.Kecamatan.ReadOnly = true;
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "SyncFlag";
            this.Flag.FalseValue = "0";
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.TrueValue = "1";
            this.Flag.Width = 50;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "kd_sales";
            this.KodeSales.HeaderText = "Kode Sales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            this.KodeSales.Visible = false;
            // 
            // kd_toko
            // 
            this.kd_toko.DataPropertyName = "kd_toko";
            this.kd_toko.HeaderText = "kd_toko";
            this.kd_toko.Name = "kd_toko";
            this.kd_toko.Visible = false;
            // 
            // frmGetdataFixrute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1262, 517);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dateTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.customGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGetdataFixrute";
            this.Text = "Get Data Fixrute";
            this.Title = "Get Data Fixrute";
            this.Load += new System.EventHandler(this.frmGetdataFixrute_Load);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dateTextBox1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.Button cmdPrint;
        private ISA.Trading.Controls.DateTextBox dateTextBox1;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn M1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tg1;
        private System.Windows.Forms.DataGridViewTextBoxColumn M2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tg2;
        private System.Windows.Forms.DataGridViewTextBoxColumn M3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tg3;
        private System.Windows.Forms.DataGridViewTextBoxColumn M4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tg4;
        private System.Windows.Forms.DataGridViewTextBoxColumn M5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tg5;
        private System.Windows.Forms.DataGridViewTextBoxColumn M6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tg6;
        private System.Windows.Forms.DataGridViewComboBoxColumn Harii;
        private System.Windows.Forms.DataGridViewComboBoxColumn Jenis;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daerah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kecamatan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_toko;
    }
}