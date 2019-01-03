namespace ISA.Toko.ArusStock
{
    partial class frmBarangKembaliKePenjualanHistory2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvHistory = new System.Windows.Forms.DataGridView();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyKeluarGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyKembali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // gvHistory
            // 
            this.gvHistory.AllowUserToAddRows = false;
            this.gvHistory.AllowUserToDeleteRows = false;
            this.gvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaBarang,
            this.NoPinjam,
            this.QtyKeluarGudang,
            this.QtyKembali,
            this.Sisa,
            this.RowID});
            this.gvHistory.Location = new System.Drawing.Point(9, 10);
            this.gvHistory.Name = "gvHistory";
            this.gvHistory.ReadOnly = true;
            this.gvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvHistory.Size = new System.Drawing.Size(751, 251);
            this.gvHistory.TabIndex = 5;
            this.gvHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // NamaBarang
            // 
            this.NamaBarang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NamaBarang.DataPropertyName = "NamaStok";
            this.NamaBarang.Frozen = true;
            this.NamaBarang.HeaderText = "Nama Barang";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            this.NamaBarang.Width = 103;
            // 
            // NoPinjam
            // 
            this.NoPinjam.DataPropertyName = "NoBukti";
            this.NoPinjam.HeaderText = "No.Pinjam";
            this.NoPinjam.Name = "NoPinjam";
            this.NoPinjam.ReadOnly = true;
            // 
            // QtyKeluarGudang
            // 
            this.QtyKeluarGudang.DataPropertyName = "QtyKeluarGudang";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyKeluarGudang.DefaultCellStyle = dataGridViewCellStyle1;
            this.QtyKeluarGudang.HeaderText = "QtyPinjam";
            this.QtyKeluarGudang.Name = "QtyKeluarGudang";
            this.QtyKeluarGudang.ReadOnly = true;
            // 
            // QtyKembali
            // 
            this.QtyKembali.DataPropertyName = "QtyKembali";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtyKembali.DefaultCellStyle = dataGridViewCellStyle2;
            this.QtyKembali.HeaderText = "QtyKembali";
            this.QtyKembali.Name = "QtyKembali";
            this.QtyKembali.ReadOnly = true;
            this.QtyKembali.Width = 70;
            // 
            // Sisa
            // 
            this.Sisa.DataPropertyName = "Sisa";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.Sisa.DefaultCellStyle = dataGridViewCellStyle3;
            this.Sisa.HeaderText = "Sisa";
            this.Sisa.Name = "Sisa";
            this.Sisa.ReadOnly = true;
            this.Sisa.Width = 50;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmBarangKembaliKePenjualanHistory2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(770, 270);
            this.Controls.Add(this.gvHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBarangKembaliKePenjualanHistory2";
            this.Text = "Peminjaman Barang";
            this.Title = "Peminjaman Barang";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmBarangKembaliKePenjualanHistory2_Load);
            this.Controls.SetChildIndex(this.gvHistory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPinjam;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyKeluarGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyKembali;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
