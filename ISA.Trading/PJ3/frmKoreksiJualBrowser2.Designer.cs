namespace ISA.Trading.PJ3
{
    partial class frmKoreksiJualBrowser2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKoreksiJualBrowser2));
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.NoKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJualAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potongan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyNotaKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJualKoreksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgJualKoreksiAck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoKoreksi,
            this.TglKoreksi,
            this.NamaBarang,
            this.KodeBarang,
            this.QtyNota,
            this.HrgJual,
            this.HrgJualAck,
            this.Satuan,
            this.Potongan,
            this.Disc1,
            this.Disc2,
            this.Disc3,
            this.QtyNotaKoreksi,
            this.HrgJualKoreksi,
            this.HrgJualKoreksiAck,
            this.Catatan,
            this.LinkID,
            this.RowID});
            this.dataGridView1.Location = new System.Drawing.Point(31, 69);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(885, 229);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyNota.DefaultCellStyle = dataGridViewCellStyle9;
            this.QtyNota.HeaderText = "Q. Nota";
            this.QtyNota.Name = "QtyNota";
            this.QtyNota.ReadOnly = true;
            this.QtyNota.Width = 90;
            // 
            // HrgJual
            // 
            this.HrgJual.DataPropertyName = "HrgJualBaru";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HrgJual.DefaultCellStyle = dataGridViewCellStyle10;
            this.HrgJual.HeaderText = "H. Jual";
            this.HrgJual.Name = "HrgJual";
            this.HrgJual.ReadOnly = true;
            this.HrgJual.Visible = false;
            // 
            // HrgJualAck
            // 
            this.HrgJualAck.DataPropertyName = "HrgJualBaruAck";
            this.HrgJualAck.HeaderText = "H. Jual";
            this.HrgJualAck.Name = "HrgJualAck";
            this.HrgJualAck.ReadOnly = true;
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "#,##0";
            this.Potongan.DefaultCellStyle = dataGridViewCellStyle11;
            this.Potongan.HeaderText = "Potongan";
            this.Potongan.Name = "Potongan";
            this.Potongan.ReadOnly = true;
            this.Potongan.Width = 80;
            // 
            // Disc1
            // 
            this.Disc1.DataPropertyName = "Disc1";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "#,##0.00";
            this.Disc1.DefaultCellStyle = dataGridViewCellStyle12;
            this.Disc1.HeaderText = "Disc1";
            this.Disc1.Name = "Disc1";
            this.Disc1.ReadOnly = true;
            this.Disc1.Width = 50;
            // 
            // Disc2
            // 
            this.Disc2.DataPropertyName = "Disc2";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "#,##0.00";
            this.Disc2.DefaultCellStyle = dataGridViewCellStyle13;
            this.Disc2.HeaderText = "Disc2";
            this.Disc2.Name = "Disc2";
            this.Disc2.ReadOnly = true;
            this.Disc2.Width = 50;
            // 
            // Disc3
            // 
            this.Disc3.DataPropertyName = "Disc3";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "#,##0.00";
            this.Disc3.DefaultCellStyle = dataGridViewCellStyle14;
            this.Disc3.HeaderText = "Disc3";
            this.Disc3.Name = "Disc3";
            this.Disc3.ReadOnly = true;
            this.Disc3.Width = 50;
            // 
            // QtyNotaKoreksi
            // 
            this.QtyNotaKoreksi.DataPropertyName = "QtyNotaKoreksi";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyNotaKoreksi.DefaultCellStyle = dataGridViewCellStyle15;
            this.QtyNotaKoreksi.HeaderText = "N. Koreksi";
            this.QtyNotaKoreksi.Name = "QtyNotaKoreksi";
            this.QtyNotaKoreksi.ReadOnly = true;
            this.QtyNotaKoreksi.Width = 120;
            // 
            // HrgJualKoreksi
            // 
            this.HrgJualKoreksi.DataPropertyName = "HrgJualKoreksi";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HrgJualKoreksi.DefaultCellStyle = dataGridViewCellStyle16;
            this.HrgJualKoreksi.HeaderText = "H. Koreksi";
            this.HrgJualKoreksi.Name = "HrgJualKoreksi";
            this.HrgJualKoreksi.ReadOnly = true;
            this.HrgJualKoreksi.Visible = false;
            this.HrgJualKoreksi.Width = 120;
            // 
            // HrgJualKoreksiAck
            // 
            this.HrgJualKoreksiAck.DataPropertyName = "HrgJualKoreksiAck";
            this.HrgJualKoreksiAck.HeaderText = "H. Koreksi";
            this.HrgJualKoreksiAck.Name = "HrgJualKoreksiAck";
            this.HrgJualKoreksiAck.ReadOnly = true;
            this.HrgJualKoreksiAck.Width = 120;
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
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(816, 357);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmKoreksiJualBrowser2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(928, 409);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKoreksiJualBrowser2";
            this.Text = "Koreksi Jual ";
            this.Title = "Koreksi Jual ";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmKoreksiJualBrowser2_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJualAck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc3;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyNotaKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJualKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgJualKoreksiAck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
