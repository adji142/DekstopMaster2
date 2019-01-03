namespace ISA.Toko.Pembelian
{
    partial class frmHistoryPembelianForReturBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoryPembelianForReturBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.DetailRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pemasok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgBeliNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyRetur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtySisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailRowID,
            this.NoNota,
            this.NamaBarang,
            this.Satuan,
            this.TglNota,
            this.TglTerima,
            this.Pemasok,
            this.HrgBeliNet,
            this.QtyTerima,
            this.QtyRetur,
            this.QtySisa});
            this.dataGridView1.Location = new System.Drawing.Point(9, 50);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(697, 229);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown_1);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // DetailRowID
            // 
            this.DetailRowID.DataPropertyName = "RowID";
            this.DetailRowID.HeaderText = "RowID";
            this.DetailRowID.Name = "DetailRowID";
            this.DetailRowID.ReadOnly = true;
            this.DetailRowID.Visible = false;
            this.DetailRowID.Width = 300;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "No Nota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            this.NoNota.Width = 80;
            // 
            // NamaBarang
            // 
            this.NamaBarang.DataPropertyName = "NamaBarang";
            this.NamaBarang.HeaderText = "Nama Barang";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            this.NamaBarang.Width = 200;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "Satuan";
            this.Satuan.HeaderText = "Satuan";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Width = 70;
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglNota";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglNota.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglNota.HeaderText = "Tgl Nota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.TglTerima.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglTerima.HeaderText = "Tgl Terima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            // 
            // Pemasok
            // 
            this.Pemasok.DataPropertyName = "NAMAPEMASOK";
            this.Pemasok.HeaderText = "Supplier";
            this.Pemasok.Name = "Pemasok";
            this.Pemasok.ReadOnly = true;
            this.Pemasok.Width = 150;
            // 
            // HrgBeliNet
            // 
            this.HrgBeliNet.DataPropertyName = "HrgBeliNet";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.HrgBeliNet.DefaultCellStyle = dataGridViewCellStyle3;
            this.HrgBeliNet.HeaderText = "Hrg Beli";
            this.HrgBeliNet.Name = "HrgBeliNet";
            this.HrgBeliNet.ReadOnly = true;
            // 
            // QtyTerima
            // 
            this.QtyTerima.DataPropertyName = "QtyTerima";
            this.QtyTerima.HeaderText = "Qty Terima";
            this.QtyTerima.Name = "QtyTerima";
            this.QtyTerima.ReadOnly = true;
            // 
            // QtyRetur
            // 
            this.QtyRetur.DataPropertyName = "QtyRetur";
            this.QtyRetur.HeaderText = "Qty Retur";
            this.QtyRetur.Name = "QtyRetur";
            this.QtyRetur.ReadOnly = true;
            // 
            // QtySisa
            // 
            this.QtySisa.DataPropertyName = "QtySisa";
            this.QtySisa.HeaderText = "Qty Sisa";
            this.QtySisa.Name = "QtySisa";
            this.QtySisa.ReadOnly = true;
            // 
            // frmHistoryPembelianForReturBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(714, 341);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHistoryPembelianForReturBrowse";
            this.Text = "History Pembelian";
            this.Title = "History Pembelian";
            this.Load += new System.EventHandler(this.frmHistoryPembelianForReturBrowser_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pemasok;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgBeliNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyRetur;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtySisa;
    }
}
