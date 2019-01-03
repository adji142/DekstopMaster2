namespace ISA.Toko.Pembelian
{
    partial class frmKoreksiReturBeliBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKoreksiReturBeliBrowser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.NoKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potongan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNotaKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgBeliKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cmdClose.Location = new System.Drawing.Point(581, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(136, 289);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 2;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 289);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
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
            this.NoKoreksi,
            this.TglKoreksi,
            this.NamaBarang,
            this.KodeBarang,
            this.QtyNota,
            this.HrgBeli,
            this.Satuan,
            this.Potongan,
            this.Disc1,
            this.Disc2,
            this.Disc3,
            this.QtyNotaKoreksi,
            this.HrgBeliKoreksi,
            this.QtyTerima,
            this.RpOrder,
            this.Catatan,
            this.LinkID,
            this.RowID});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(715, 197);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // NoKoreksi
            // 
            this.NoKoreksi.DataPropertyName = "NoKoreksi";
            this.NoKoreksi.HeaderText = "No. Koreksi";
            this.NoKoreksi.Name = "NoKoreksi";
            this.NoKoreksi.ReadOnly = true;
            this.NoKoreksi.Width = 110;
            // 
            // TglKoreksi
            // 
            this.TglKoreksi.DataPropertyName = "TglKoreksi";
            this.TglKoreksi.HeaderText = "Tanggal";
            this.TglKoreksi.Name = "TglKoreksi";
            this.TglKoreksi.ReadOnly = true;
            this.TglKoreksi.Width = 80;
            // 
            // NamaBarang
            // 
            this.NamaBarang.DataPropertyName = "NamaBarang";
            this.NamaBarang.HeaderText = "Nama Barang";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            this.NamaBarang.Width = 300;
            // 
            // KodeBarang
            // 
            this.KodeBarang.DataPropertyName = "BarangID";
            this.KodeBarang.HeaderText = "Kode Barang";
            this.KodeBarang.Name = "KodeBarang";
            this.KodeBarang.ReadOnly = true;
            this.KodeBarang.Width = 130;
            // 
            // QtyNota
            // 
            this.QtyNota.DataPropertyName = "QtyNotaBaru";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyNota.DefaultCellStyle = dataGridViewCellStyle1;
            this.QtyNota.HeaderText = "Q. Nota";
            this.QtyNota.Name = "QtyNota";
            this.QtyNota.ReadOnly = true;
            this.QtyNota.Visible = false;
            this.QtyNota.Width = 90;
            // 
            // HrgBeli
            // 
            this.HrgBeli.DataPropertyName = "HrgBeliBaru";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HrgBeli.DefaultCellStyle = dataGridViewCellStyle2;
            this.HrgBeli.HeaderText = "H. Beli";
            this.HrgBeli.Name = "HrgBeli";
            this.HrgBeli.ReadOnly = true;
            this.HrgBeli.Visible = false;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "Satuan";
            this.Satuan.HeaderText = "Sat";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Width = 40;
            // 
            // Potongan
            // 
            this.Potongan.DataPropertyName = "Pot";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Potongan.DefaultCellStyle = dataGridViewCellStyle3;
            this.Potongan.HeaderText = "Potongan";
            this.Potongan.Name = "Potongan";
            this.Potongan.ReadOnly = true;
            this.Potongan.Visible = false;
            this.Potongan.Width = 80;
            // 
            // Disc1
            // 
            this.Disc1.DataPropertyName = "Disc1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0.00";
            this.Disc1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Disc1.HeaderText = "Disc1";
            this.Disc1.Name = "Disc1";
            this.Disc1.ReadOnly = true;
            this.Disc1.Visible = false;
            this.Disc1.Width = 50;
            // 
            // Disc2
            // 
            this.Disc2.DataPropertyName = "Disc2";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0.00";
            this.Disc2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Disc2.HeaderText = "Disc2";
            this.Disc2.Name = "Disc2";
            this.Disc2.ReadOnly = true;
            this.Disc2.Visible = false;
            this.Disc2.Width = 50;
            // 
            // Disc3
            // 
            this.Disc3.DataPropertyName = "Disc3";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0.00";
            this.Disc3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Disc3.HeaderText = "Disc3";
            this.Disc3.Name = "Disc3";
            this.Disc3.ReadOnly = true;
            this.Disc3.Visible = false;
            this.Disc3.Width = 50;
            // 
            // QtyNotaKoreksi
            // 
            this.QtyNotaKoreksi.DataPropertyName = "QtyNotaKoreksi";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyNotaKoreksi.DefaultCellStyle = dataGridViewCellStyle7;
            this.QtyNotaKoreksi.HeaderText = "N. Koreksi";
            this.QtyNotaKoreksi.Name = "QtyNotaKoreksi";
            this.QtyNotaKoreksi.ReadOnly = true;
            // 
            // HrgBeliKoreksi
            // 
            this.HrgBeliKoreksi.DataPropertyName = "HrgBeliKoreksi";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HrgBeliKoreksi.DefaultCellStyle = dataGridViewCellStyle8;
            this.HrgBeliKoreksi.HeaderText = "H. Koreksi";
            this.HrgBeliKoreksi.Name = "HrgBeliKoreksi";
            this.HrgBeliKoreksi.ReadOnly = true;
            // 
            // QtyTerima
            // 
            this.QtyTerima.DataPropertyName = "QtyTerima";
            this.QtyTerima.HeaderText = "Qty Terima";
            this.QtyTerima.Name = "QtyTerima";
            this.QtyTerima.ReadOnly = true;
            // 
            // RpOrder
            // 
            this.RpOrder.DataPropertyName = "RpOrder";
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.RpOrder.DefaultCellStyle = dataGridViewCellStyle9;
            this.RpOrder.HeaderText = "Rp Order";
            this.RpOrder.Name = "RpOrder";
            this.RpOrder.ReadOnly = true;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.ReadOnly = true;
            this.Catatan.Width = 200;
            // 
            // LinkID
            // 
            this.LinkID.DataPropertyName = "LinkID";
            this.LinkID.HeaderText = "Link2Api";
            this.LinkID.Name = "LinkID";
            this.LinkID.ReadOnly = true;
            this.LinkID.Visible = false;
            this.LinkID.Width = 200;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmKoreksiReturBeliBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKoreksiReturBeliBrowser";
            this.Text = "Koreksi Retur Pembelian";
            this.Title = "Koreksi Retur Pembelian";
            this.Load += new System.EventHandler(this.frmKoreksiReturBeliBrowser_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private ISA.Toko.Controls.CommandButton cmdAdd;
        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNotaKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgBeliKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
