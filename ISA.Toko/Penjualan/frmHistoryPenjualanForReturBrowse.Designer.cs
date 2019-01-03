namespace ISA.Toko.Penjualan
{
    partial class frmHistoryPenjualanForReturBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoryPenjualanForReturBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.Cabang1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtySisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cabang1,
            this.Cabang2,
            this.NoNota,
            this.TglTerima,
            this.KodeSales,
            this.NamaStok,
            this.HrgJual,
            this.QtyNota,
            this.QtyRetur,
            this.QtyMemo,
            this.QtySisa,
            this.Satuan});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(713, 193);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(583, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Cabang1
            // 
            this.Cabang1.DataPropertyName = "Cabang1";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cabang1.DefaultCellStyle = dataGridViewCellStyle13;
            this.Cabang1.HeaderText = "C1";
            this.Cabang1.Name = "Cabang1";
            this.Cabang1.ReadOnly = true;
            this.Cabang1.Width = 30;
            // 
            // Cabang2
            // 
            this.Cabang2.DataPropertyName = "Cabang2";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cabang2.DefaultCellStyle = dataGridViewCellStyle14;
            this.Cabang2.HeaderText = "C2";
            this.Cabang2.Name = "Cabang2";
            this.Cabang2.ReadOnly = true;
            this.Cabang2.Width = 30;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "No.Nota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle15.Format = "dd-MMM-yyyy";
            this.TglTerima.DefaultCellStyle = dataGridViewCellStyle15;
            this.TglTerima.HeaderText = "Tgl.Terima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "KodeSales";
            this.KodeSales.HeaderText = "Kd.Sales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Barang-Barang yang Pernah Dibeli";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 400;
            // 
            // HrgJual
            // 
            this.HrgJual.DataPropertyName = "HrgJual";
            dataGridViewCellStyle16.Format = "#,##0";
            dataGridViewCellStyle16.NullValue = "0";
            this.HrgJual.DefaultCellStyle = dataGridViewCellStyle16;
            this.HrgJual.HeaderText = "Harga Jual";
            this.HrgJual.Name = "HrgJual";
            this.HrgJual.ReadOnly = true;
            // 
            // QtyNota
            // 
            this.QtyNota.DataPropertyName = "QtyNota";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyNota.DefaultCellStyle = dataGridViewCellStyle17;
            this.QtyNota.HeaderText = "Qty.Nota";
            this.QtyNota.Name = "QtyNota";
            this.QtyNota.ReadOnly = true;
            this.QtyNota.Width = 70;
            // 
            // QtyRetur
            // 
            this.QtyRetur.DataPropertyName = "QtyRetur";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyRetur.DefaultCellStyle = dataGridViewCellStyle18;
            this.QtyRetur.HeaderText = "Qty.Ret";
            this.QtyRetur.Name = "QtyRetur";
            this.QtyRetur.ReadOnly = true;
            this.QtyRetur.Width = 70;
            // 
            // QtyMemo
            // 
            this.QtyMemo.DataPropertyName = "QtyMemo";
            this.QtyMemo.HeaderText = "QtyMemo";
            this.QtyMemo.Name = "QtyMemo";
            this.QtyMemo.ReadOnly = true;
            // 
            // QtySisa
            // 
            this.QtySisa.DataPropertyName = "QtySisa";
            this.QtySisa.HeaderText = "QtySisa";
            this.QtySisa.Name = "QtySisa";
            this.QtySisa.ReadOnly = true;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "Satuan";
            this.Satuan.HeaderText = "Sat";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Width = 50;
            // 
            // frmHistoryPenjualanForReturBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(714, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHistoryPenjualanForReturBrowse";
            this.Text = "Penjualan";
            this.Title = "Penjualan";
            this.Load += new System.EventHandler(this.frmHistoryPenjualanForReturBrowser_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtySisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
    }
}
