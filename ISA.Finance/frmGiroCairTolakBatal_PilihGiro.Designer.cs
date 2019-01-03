namespace ISA.Finance
{
    partial class frmGiroCairTolakBatal_PilihGiro
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
            this.label1 = new System.Windows.Forms.Label();
            this.gridGiroTitip = new ISA.Controls.CustomGridView();
            this.CHBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgljtempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namabank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lokasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cairtolak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglkasir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infotoko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridGiroTitip)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "TABEL VOUCHER TITIPAN GIRO";
            // 
            // gridGiroTitip
            // 
            this.gridGiroTitip.AllowUserToAddRows = false;
            this.gridGiroTitip.AllowUserToDeleteRows = false;
            this.gridGiroTitip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridGiroTitip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGiroTitip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHBG,
            this.nomor,
            this.TglGiro,
            this.nominal,
            this.tgljtempo,
            this.namabank,
            this.lokasi,
            this.cairtolak,
            this.keterangan,
            this.tglkasir,
            this.infotoko});
            this.gridGiroTitip.Location = new System.Drawing.Point(6, 74);
            this.gridGiroTitip.MultiSelect = false;
            this.gridGiroTitip.Name = "gridGiroTitip";
            this.gridGiroTitip.ReadOnly = true;
            this.gridGiroTitip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridGiroTitip.Size = new System.Drawing.Size(701, 212);
            this.gridGiroTitip.StandardTab = true;
            this.gridGiroTitip.TabIndex = 4;
            // 
            // CHBG
            // 
            this.CHBG.HeaderText = "CHBG";
            this.CHBG.Name = "CHBG";
            this.CHBG.ReadOnly = true;
            // 
            // nomor
            // 
            this.nomor.HeaderText = " NOMOR";
            this.nomor.Name = "nomor";
            this.nomor.ReadOnly = true;
            // 
            // TglGiro
            // 
            this.TglGiro.HeaderText = "TGL. GIRO";
            this.TglGiro.Name = "TglGiro";
            this.TglGiro.ReadOnly = true;
            // 
            // nominal
            // 
            this.nominal.HeaderText = "NOMINAL";
            this.nominal.Name = "nominal";
            this.nominal.ReadOnly = true;
            // 
            // tgljtempo
            // 
            this.tgljtempo.HeaderText = "TGL.J/TMPO";
            this.tgljtempo.Name = "tgljtempo";
            this.tgljtempo.ReadOnly = true;
            // 
            // namabank
            // 
            this.namabank.HeaderText = "NAMA BANK";
            this.namabank.Name = "namabank";
            this.namabank.ReadOnly = true;
            // 
            // lokasi
            // 
            this.lokasi.HeaderText = "LOKASI";
            this.lokasi.Name = "lokasi";
            this.lokasi.ReadOnly = true;
            // 
            // cairtolak
            // 
            this.cairtolak.HeaderText = "CAIR TOLAK";
            this.cairtolak.Name = "cairtolak";
            this.cairtolak.ReadOnly = true;
            // 
            // keterangan
            // 
            this.keterangan.HeaderText = "KETERANGAN";
            this.keterangan.Name = "keterangan";
            this.keterangan.ReadOnly = true;
            // 
            // tglkasir
            // 
            this.tglkasir.HeaderText = "TGL. KASIR";
            this.tglkasir.Name = "tglkasir";
            this.tglkasir.ReadOnly = true;
            // 
            // infotoko
            // 
            this.infotoko.HeaderText = "INFO TOKO";
            this.infotoko.Name = "infotoko";
            this.infotoko.ReadOnly = true;
            // 
            // frmGiroCairTolakBatal_PilihGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.gridGiroTitip);
            this.Controls.Add(this.label1);
            this.Name = "frmGiroCairTolakBatal_PilihGiro";
            this.Text = "TABEL VOUCHER TITIPAN GIRO";
            this.Load += new System.EventHandler(this.frmGiroCairTolakBatal_PilihGiro_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.gridGiroTitip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridGiroTitip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView gridGiroTitip;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglGiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgljtempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn namabank;
        private System.Windows.Forms.DataGridViewTextBoxColumn lokasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cairtolak;
        private System.Windows.Forms.DataGridViewTextBoxColumn keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglkasir;
        private System.Windows.Forms.DataGridViewTextBoxColumn infotoko;
    }
}
