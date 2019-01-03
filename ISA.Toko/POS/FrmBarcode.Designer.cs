namespace ISA.Toko.POS
{
    partial class FrmBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBarcode));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBStok = new System.Windows.Forms.CheckBox();
            this.lblBMK = new System.Windows.Forms.Label();
            this.lblKet = new System.Windows.Forms.Label();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StokAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.NamaStok,
            this.KodeBarang,
            this.KodeBarcode,
            this.StokAkhir});
            this.customGridView1.Location = new System.Drawing.Point(25, 79);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(981, 383);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 6;
            this.customGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellDoubleClick);
            this.customGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellClick);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cari...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCari
            // 
            this.txtCari.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtCari.Location = new System.Drawing.Point(91, 52);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(364, 20);
            this.txtCari.TabIndex = 11;
            this.txtCari.Text = "Nama Stok, Barcode, ID Barang";
            this.txtCari.Click += new System.EventHandler(this.txtCari_Click);
            this.txtCari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCari_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kata Kunci";
            // 
            // CBStok
            // 
            this.CBStok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBStok.AutoSize = true;
            this.CBStok.Location = new System.Drawing.Point(937, 55);
            this.CBStok.Name = "CBStok";
            this.CBStok.Size = new System.Drawing.Size(69, 18);
            this.CBStok.TabIndex = 13;
            this.CBStok.Text = "Stok > 0";
            this.CBStok.UseVisualStyleBackColor = true;
            this.CBStok.CheckedChanged += new System.EventHandler(this.CBStok_CheckedChanged);
            // 
            // lblBMK
            // 
            this.lblBMK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBMK.Location = new System.Drawing.Point(499, 483);
            this.lblBMK.Name = "lblBMK";
            this.lblBMK.Size = new System.Drawing.Size(387, 14);
            this.lblBMK.TabIndex = 44;
            this.lblBMK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKet
            // 
            this.lblKet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKet.AutoSize = true;
            this.lblKet.Location = new System.Drawing.Point(22, 483);
            this.lblKet.Name = "lblKet";
            this.lblKet.Size = new System.Drawing.Size(0, 14);
            this.lblKet.TabIndex = 45;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 600;
            // 
            // KodeBarang
            // 
            this.KodeBarang.DataPropertyName = "BarangID";
            this.KodeBarang.HeaderText = "Kode Barang";
            this.KodeBarang.Name = "KodeBarang";
            this.KodeBarang.ReadOnly = true;
            this.KodeBarang.Width = 200;
            // 
            // KodeBarcode
            // 
            this.KodeBarcode.DataPropertyName = "barcode";
            this.KodeBarcode.HeaderText = "Kode Barcode";
            this.KodeBarcode.Name = "KodeBarcode";
            this.KodeBarcode.ReadOnly = true;
            this.KodeBarcode.Width = 200;
            // 
            // StokAkhir
            // 
            this.StokAkhir.DataPropertyName = "StokAkhirGudang";
            this.StokAkhir.HeaderText = "Stok Akhir";
            this.StokAkhir.Name = "StokAkhir";
            this.StokAkhir.ReadOnly = true;
            // 
            // FrmBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 512);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.lblKet);
            this.Controls.Add(this.lblBMK);
            this.Controls.Add(this.CBStok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commandButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBarcode";
            this.Text = "PERSEDIAAN BARANG";
            this.Title = "PERSEDIAAN BARANG";
            this.Load += new System.EventHandler(this.FrmBarcode_Load);
            this.Activated += new System.EventHandler(this.FrmBarcode_Activated);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.txtCari, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CBStok, 0);
            this.Controls.SetChildIndex(this.lblBMK, 0);
            this.Controls.SetChildIndex(this.lblKet, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokBarang;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CBStok;
        private System.Windows.Forms.Label lblBMK;
        private System.Windows.Forms.Label lblKet;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokAkhir;
    }
}