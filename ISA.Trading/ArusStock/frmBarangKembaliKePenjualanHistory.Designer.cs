namespace ISA.Trading.ArusStock
{
    partial class frmBarangKembaliKePenjualanHistory
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
            this.gvHistory = new System.Windows.Forms.DataGridView();
            this.NamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Sisa});
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
            this.NamaBarang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaBarang.DataPropertyName = "NamaStok";
            this.NamaBarang.HeaderText = "Nama Barang";
            this.NamaBarang.Name = "NamaBarang";
            this.NamaBarang.ReadOnly = true;
            // 
            // NoPinjam
            // 
            this.NoPinjam.DataPropertyName = "NoBukti";
            this.NoPinjam.HeaderText = "No.Pinjam";
            this.NoPinjam.Name = "NoPinjam";
            this.NoPinjam.ReadOnly = true;
            // 
            // Sisa
            // 
            this.Sisa.DataPropertyName = "Sisa";
            this.Sisa.HeaderText = "Sisa";
            this.Sisa.Name = "Sisa";
            this.Sisa.ReadOnly = true;
            this.Sisa.Width = 50;
            // 
            // frmBarangKembaliKePenjualanHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(770, 270);
            this.Controls.Add(this.gvHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBarangKembaliKePenjualanHistory";
            this.Text = "Peminjaman Barang";
            this.Title = "Peminjaman Barang";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmBarangKembaliKePenjualanHistory_Load);
            this.Controls.SetChildIndex(this.gvHistory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPinjam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sisa;
        private System.Windows.Forms.DataGridView gvHistory;
    }
}
