namespace ISA.Trading.Pembelian
{
    partial class frmHistoryOrderPembelianBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoryOrderPembelianBrowse));
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.NoRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglRQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pemasok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyRealisasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoRQ,
            this.TglRQ,
            this.Pemasok,
            this.NamaStok,
            this.Satuan,
            this.QtyDO,
            this.QtyRealisasi,
            this.QtyBO});
            this.dataGridView1.Location = new System.Drawing.Point(8, 55);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(749, 225);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // NoRQ
            // 
            this.NoRQ.DataPropertyName = "NoRequest";
            this.NoRQ.HeaderText = "No RQ";
            this.NoRQ.Name = "NoRQ";
            this.NoRQ.ReadOnly = true;
            this.NoRQ.Width = 75;
            // 
            // TglRQ
            // 
            this.TglRQ.DataPropertyName = "TglRequest";
            this.TglRQ.HeaderText = "Tgl RQ";
            this.TglRQ.Name = "TglRQ";
            this.TglRQ.ReadOnly = true;
            this.TglRQ.Width = 85;
            // 
            // Pemasok
            // 
            this.Pemasok.DataPropertyName = "Pemasok";
            this.Pemasok.HeaderText = "Pemasok";
            this.Pemasok.Name = "Pemasok";
            this.Pemasok.ReadOnly = true;
            this.Pemasok.Width = 160;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Barang";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 300;
            // 
            // Satuan
            // 
            this.Satuan.DataPropertyName = "Satuan";
            this.Satuan.HeaderText = "Sat";
            this.Satuan.Name = "Satuan";
            this.Satuan.ReadOnly = true;
            this.Satuan.Width = 50;
            // 
            // QtyDO
            // 
            this.QtyDO.DataPropertyName = "QtyDO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.QtyDO.DefaultCellStyle = dataGridViewCellStyle3;
            this.QtyDO.HeaderText = "Qty DO";
            this.QtyDO.Name = "QtyDO";
            this.QtyDO.ReadOnly = true;
            this.QtyDO.Width = 70;
            // 
            // QtyRealisasi
            // 
            this.QtyRealisasi.DataPropertyName = "QtyRealisasi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.QtyRealisasi.DefaultCellStyle = dataGridViewCellStyle4;
            this.QtyRealisasi.HeaderText = "Qty Real";
            this.QtyRealisasi.Name = "QtyRealisasi";
            this.QtyRealisasi.ReadOnly = true;
            this.QtyRealisasi.Width = 70;
            // 
            // QtyBO
            // 
            this.QtyBO.DataPropertyName = "QtyBO";
            this.QtyBO.HeaderText = "Qty BO";
            this.QtyBO.Name = "QtyBO";
            this.QtyBO.ReadOnly = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(658, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmHistoryOrderPembelianBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(765, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHistoryOrderPembelianBrowse";
            this.Text = "History Order Pembelian";
            this.Title = "History Order Pembelian";
            this.Load += new System.EventHandler(this.frmHistoryOrderPembelianBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglRQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pemasok;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyRealisasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyBO;
    }
}
