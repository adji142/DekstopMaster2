namespace ISA.Toko.Kasir
{
    partial class frmIndenDetailPiutangBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndenDetailPiutangBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.TglTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJTGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBuktiKasMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglTransaksi,
            this.KodeTransaksi,
            this.Debet,
            this.Kredit,
            this.TglJTGiro,
            this.Uraian,
            this.NoBuktiKasMasuk,
            this.NoGiro,
            this.Bank,
            this.NoACC});
            this.customGridView1.Location = new System.Drawing.Point(28, 28);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(669, 219);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(597, 253);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // TglTransaksi
            // 
            this.TglTransaksi.DataPropertyName = "TglTransaksi";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.TglTransaksi.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglTransaksi.HeaderText = "TGL. TRAN";
            this.TglTransaksi.Name = "TglTransaksi";
            this.TglTransaksi.ReadOnly = true;
            // 
            // KodeTransaksi
            // 
            this.KodeTransaksi.DataPropertyName = "KodeTransaksi";
            this.KodeTransaksi.HeaderText = "KD. TR";
            this.KodeTransaksi.Name = "KodeTransaksi";
            this.KodeTransaksi.ReadOnly = true;
            // 
            // Debet
            // 
            this.Debet.DataPropertyName = "Debet";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.Debet.DefaultCellStyle = dataGridViewCellStyle2;
            this.Debet.HeaderText = "DEBET";
            this.Debet.Name = "Debet";
            this.Debet.ReadOnly = true;
            // 
            // Kredit
            // 
            this.Kredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.Kredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.Kredit.HeaderText = "KREDIT";
            this.Kredit.Name = "Kredit";
            this.Kredit.ReadOnly = true;
            // 
            // TglJTGiro
            // 
            this.TglJTGiro.DataPropertyName = "TglJTGiro";
            dataGridViewCellStyle4.Format = "dd-MM-yyyy";
            this.TglJTGiro.DefaultCellStyle = dataGridViewCellStyle4;
            this.TglJTGiro.HeaderText = "CBG-JT";
            this.TglJTGiro.Name = "TglJTGiro";
            this.TglJTGiro.ReadOnly = true;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "URAIAN";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            // 
            // NoBuktiKasMasuk
            // 
            this.NoBuktiKasMasuk.DataPropertyName = "NoBuktiKasMasuk";
            this.NoBuktiKasMasuk.HeaderText = "NO. BKM";
            this.NoBuktiKasMasuk.Name = "NoBuktiKasMasuk";
            this.NoBuktiKasMasuk.ReadOnly = true;
            // 
            // NoGiro
            // 
            this.NoGiro.DataPropertyName = "NoGiro";
            this.NoGiro.HeaderText = "NO. BG";
            this.NoGiro.Name = "NoGiro";
            this.NoGiro.ReadOnly = true;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Bank";
            this.Bank.HeaderText = "BANK";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            // 
            // NoACC
            // 
            this.NoACC.DataPropertyName = "NoACC";
            this.NoACC.HeaderText = "NO. ACC";
            this.NoACC.Name = "NoACC";
            this.NoACC.ReadOnly = true;
            // 
            // frmIndenDetailPiutangBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(724, 298);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmIndenDetailPiutangBrowse";
            this.Text = "Detail Piutang";
            this.Load += new System.EventHandler(this.frmIndenDetailPiutangBrowse_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJTGiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBuktiKasMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoGiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACC;
    }
}
