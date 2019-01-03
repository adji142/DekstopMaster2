namespace ISA.Finance.Kasir
{
    partial class frmKasirLogModeBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasirLogModeBrowse));
            this.dgKasirLog = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KasAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KasMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KasKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGDAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGDMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGDKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGTAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGTMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGTKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGTolakMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGTolakKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGInternalMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BGInternalKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BSAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BSMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BSKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgKasirLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgKasirLog
            // 
            this.dgKasirLog.AllowUserToAddRows = false;
            this.dgKasirLog.AllowUserToDeleteRows = false;
            this.dgKasirLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKasirLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Tanggal,
            this.KasAwal,
            this.KasMasuk,
            this.KasKeluar,
            this.BGDAwal,
            this.BGDMasuk,
            this.BGDKeluar,
            this.BGTAwal,
            this.BGTMasuk,
            this.BGTKeluar,
            this.BGTolakMasuk,
            this.BGTolakKeluar,
            this.BGInternalMasuk,
            this.BGInternalKeluar,
            this.BankAwal,
            this.BankMasuk,
            this.BankKeluar,
            this.BSAwal,
            this.BSMasuk,
            this.BSKeluar,
            this.PKAwal,
            this.PKMasuk,
            this.PKKeluar});
            this.dgKasirLog.Location = new System.Drawing.Point(28, 28);
            this.dgKasirLog.MultiSelect = false;
            this.dgKasirLog.Name = "dgKasirLog";
            this.dgKasirLog.ReadOnly = true;
            this.dgKasirLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgKasirLog.Size = new System.Drawing.Size(752, 297);
            this.dgKasirLog.StandardTab = true;
            this.dgKasirLog.TabIndex = 3;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // KasAwal
            // 
            this.KasAwal.DataPropertyName = "KasAwal";
            this.KasAwal.HeaderText = "Kas Awal";
            this.KasAwal.Name = "KasAwal";
            this.KasAwal.ReadOnly = true;
            this.KasAwal.Width = 120;
            // 
            // KasMasuk
            // 
            this.KasMasuk.DataPropertyName = "KasMasuk";
            this.KasMasuk.HeaderText = "Kas ( + )";
            this.KasMasuk.Name = "KasMasuk";
            this.KasMasuk.ReadOnly = true;
            this.KasMasuk.Width = 120;
            // 
            // KasKeluar
            // 
            this.KasKeluar.DataPropertyName = "KasKeluar";
            this.KasKeluar.HeaderText = "Kas ( - )";
            this.KasKeluar.Name = "KasKeluar";
            this.KasKeluar.ReadOnly = true;
            this.KasKeluar.Width = 120;
            // 
            // BGDAwal
            // 
            this.BGDAwal.DataPropertyName = "BGDAwal";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.BGDAwal.DefaultCellStyle = dataGridViewCellStyle2;
            this.BGDAwal.HeaderText = "BG Awal";
            this.BGDAwal.Name = "BGDAwal";
            this.BGDAwal.ReadOnly = true;
            this.BGDAwal.Width = 120;
            // 
            // BGDMasuk
            // 
            this.BGDMasuk.DataPropertyName = "BGDMasuk";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.BGDMasuk.DefaultCellStyle = dataGridViewCellStyle3;
            this.BGDMasuk.HeaderText = "BG ( + )";
            this.BGDMasuk.Name = "BGDMasuk";
            this.BGDMasuk.ReadOnly = true;
            this.BGDMasuk.Width = 120;
            // 
            // BGDKeluar
            // 
            this.BGDKeluar.DataPropertyName = "BGDKeluar";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.BGDKeluar.DefaultCellStyle = dataGridViewCellStyle4;
            this.BGDKeluar.HeaderText = "BG ( - )";
            this.BGDKeluar.Name = "BGDKeluar";
            this.BGDKeluar.ReadOnly = true;
            this.BGDKeluar.Width = 120;
            // 
            // BGTAwal
            // 
            this.BGTAwal.DataPropertyName = "BGTAwal";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.BGTAwal.DefaultCellStyle = dataGridViewCellStyle5;
            this.BGTAwal.HeaderText = "BG Titip Awal";
            this.BGTAwal.Name = "BGTAwal";
            this.BGTAwal.ReadOnly = true;
            this.BGTAwal.Width = 120;
            // 
            // BGTMasuk
            // 
            this.BGTMasuk.DataPropertyName = "BGTMasuk";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.BGTMasuk.DefaultCellStyle = dataGridViewCellStyle6;
            this.BGTMasuk.HeaderText = "BG Titip ( + )";
            this.BGTMasuk.Name = "BGTMasuk";
            this.BGTMasuk.ReadOnly = true;
            this.BGTMasuk.Width = 120;
            // 
            // BGTKeluar
            // 
            this.BGTKeluar.DataPropertyName = "BGTKeluar";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.BGTKeluar.DefaultCellStyle = dataGridViewCellStyle7;
            this.BGTKeluar.HeaderText = "BG Titip ( - )";
            this.BGTKeluar.Name = "BGTKeluar";
            this.BGTKeluar.ReadOnly = true;
            this.BGTKeluar.Width = 120;
            // 
            // BGTolakMasuk
            // 
            this.BGTolakMasuk.DataPropertyName = "BGTolakMasuk";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.BGTolakMasuk.DefaultCellStyle = dataGridViewCellStyle8;
            this.BGTolakMasuk.HeaderText = "BG Tolak ( + )";
            this.BGTolakMasuk.Name = "BGTolakMasuk";
            this.BGTolakMasuk.ReadOnly = true;
            this.BGTolakMasuk.Width = 120;
            // 
            // BGTolakKeluar
            // 
            this.BGTolakKeluar.DataPropertyName = "BGTolakKeluar";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.BGTolakKeluar.DefaultCellStyle = dataGridViewCellStyle9;
            this.BGTolakKeluar.HeaderText = "BG Tolak ( - )";
            this.BGTolakKeluar.Name = "BGTolakKeluar";
            this.BGTolakKeluar.ReadOnly = true;
            this.BGTolakKeluar.Width = 120;
            // 
            // BGInternalMasuk
            // 
            this.BGInternalMasuk.DataPropertyName = "BGInternalMasuk";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = "0";
            this.BGInternalMasuk.DefaultCellStyle = dataGridViewCellStyle10;
            this.BGInternalMasuk.HeaderText = "BG Buka ( + )";
            this.BGInternalMasuk.Name = "BGInternalMasuk";
            this.BGInternalMasuk.ReadOnly = true;
            this.BGInternalMasuk.Width = 120;
            // 
            // BGInternalKeluar
            // 
            this.BGInternalKeluar.DataPropertyName = "BGInternalKeluar";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = "0";
            this.BGInternalKeluar.DefaultCellStyle = dataGridViewCellStyle11;
            this.BGInternalKeluar.HeaderText = "BG Buka ( - )";
            this.BGInternalKeluar.Name = "BGInternalKeluar";
            this.BGInternalKeluar.ReadOnly = true;
            this.BGInternalKeluar.Width = 120;
            // 
            // BankAwal
            // 
            this.BankAwal.DataPropertyName = "BankAwal";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = "0";
            this.BankAwal.DefaultCellStyle = dataGridViewCellStyle12;
            this.BankAwal.HeaderText = "Bank Awal";
            this.BankAwal.Name = "BankAwal";
            this.BankAwal.ReadOnly = true;
            this.BankAwal.Width = 120;
            // 
            // BankMasuk
            // 
            this.BankMasuk.DataPropertyName = "BankMasuk";
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = "0";
            this.BankMasuk.DefaultCellStyle = dataGridViewCellStyle13;
            this.BankMasuk.HeaderText = "Bank ( + )";
            this.BankMasuk.Name = "BankMasuk";
            this.BankMasuk.ReadOnly = true;
            this.BankMasuk.Width = 120;
            // 
            // BankKeluar
            // 
            this.BankKeluar.DataPropertyName = "BankKeluar";
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = "0";
            this.BankKeluar.DefaultCellStyle = dataGridViewCellStyle14;
            this.BankKeluar.HeaderText = "Bank ( - )";
            this.BankKeluar.Name = "BankKeluar";
            this.BankKeluar.ReadOnly = true;
            this.BankKeluar.Width = 120;
            // 
            // BSAwal
            // 
            this.BSAwal.DataPropertyName = "BSAwal";
            this.BSAwal.HeaderText = "BS Awal";
            this.BSAwal.Name = "BSAwal";
            this.BSAwal.ReadOnly = true;
            this.BSAwal.Width = 120;
            // 
            // BSMasuk
            // 
            this.BSMasuk.DataPropertyName = "BSMasuk";
            this.BSMasuk.HeaderText = "BS ( + )";
            this.BSMasuk.Name = "BSMasuk";
            this.BSMasuk.ReadOnly = true;
            this.BSMasuk.Width = 120;
            // 
            // BSKeluar
            // 
            this.BSKeluar.DataPropertyName = "BSKeluar";
            this.BSKeluar.HeaderText = "BS ( - )";
            this.BSKeluar.Name = "BSKeluar";
            this.BSKeluar.ReadOnly = true;
            this.BSKeluar.Width = 120;
            // 
            // PKAwal
            // 
            this.PKAwal.DataPropertyName = "PKAwal";
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = "0";
            this.PKAwal.DefaultCellStyle = dataGridViewCellStyle15;
            this.PKAwal.HeaderText = "Piutang Awal";
            this.PKAwal.Name = "PKAwal";
            this.PKAwal.ReadOnly = true;
            this.PKAwal.Width = 120;
            // 
            // PKMasuk
            // 
            this.PKMasuk.DataPropertyName = "PKMasuk";
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = "0";
            this.PKMasuk.DefaultCellStyle = dataGridViewCellStyle16;
            this.PKMasuk.HeaderText = "Piutang ( + )";
            this.PKMasuk.Name = "PKMasuk";
            this.PKMasuk.ReadOnly = true;
            this.PKMasuk.Width = 120;
            // 
            // PKKeluar
            // 
            this.PKKeluar.DataPropertyName = "PKKeluar";
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = "0";
            this.PKKeluar.DefaultCellStyle = dataGridViewCellStyle17;
            this.PKKeluar.HeaderText = "Piutang ( - )";
            this.PKKeluar.Name = "PKKeluar";
            this.PKKeluar.ReadOnly = true;
            this.PKKeluar.Width = 120;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(680, 343);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmKasirLogModeBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(806, 405);
            this.Controls.Add(this.dgKasirLog);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmKasirLogModeBrowse";
            this.Load += new System.EventHandler(this.frmKasirLogModeBrowse_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dgKasirLog, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgKasirLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgKasirLog;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn KasAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn KasMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn KasKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGDAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGDMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGDKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGTAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGTMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGTKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGTolakMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGTolakKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGInternalMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn BGInternalKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BSAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn BSMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn BSKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKKeluar;
    }
}
