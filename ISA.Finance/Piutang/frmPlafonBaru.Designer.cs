namespace ISA.Finance.Piutang
{
    partial class frmPlafonBaru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlafonBaru));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GVHeader = new ISA.Controls.CustomGridView();
            this.TglProses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVDetail = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WilID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RataRataBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PotensiBerkembang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KemampuanBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plafon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlafonTambahan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPlafon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetOmset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mitra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.cmdRefresh = new ISA.Controls.CommandButton();
            this.cmdProses = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(28, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GVHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GVDetail);
            this.splitContainer1.Size = new System.Drawing.Size(651, 276);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 5;
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglProses});
            this.GVHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeader.Location = new System.Drawing.Point(0, 0);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(651, 138);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 2;
            this.GVHeader.SelectionRowChanged += new System.EventHandler(this.GVHeader_SelectionRowChanged);
            // 
            // TglProses
            // 
            this.TglProses.DataPropertyName = "TglProses";
            dataGridViewCellStyle1.Format = "dd MMM yyyy";
            this.TglProses.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglProses.HeaderText = "Tanggal Proses Plafon";
            this.TglProses.Name = "TglProses";
            this.TglProses.ReadOnly = true;
            this.TglProses.Width = 200;
            // 
            // GVDetail
            // 
            this.GVDetail.AllowUserToAddRows = false;
            this.GVDetail.AllowUserToDeleteRows = false;
            this.GVDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.TokoID,
            this.KodeToko,
            this.NamaToko,
            this.WilID,
            this.Alamat,
            this.TotalBayar,
            this.RataRataBayar,
            this.PotensiBerkembang,
            this.KemampuanBayar,
            this.Plafon,
            this.PlafonTambahan,
            this.TotalPlafon,
            this.TargetOmset,
            this.StatusPN,
            this.TW,
            this.JS,
            this.Keterangan,
            this.mitra});
            this.GVDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVDetail.Location = new System.Drawing.Point(0, 0);
            this.GVDetail.MultiSelect = false;
            this.GVDetail.Name = "GVDetail";
            this.GVDetail.ReadOnly = true;
            this.GVDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVDetail.Size = new System.Drawing.Size(651, 134);
            this.GVDetail.StandardTab = true;
            this.GVDetail.TabIndex = 3;
            this.GVDetail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GVDetail_CellFormatting);
            this.GVDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVDetail_CellEndEdit);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.Frozen = true;
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // TokoID
            // 
            this.TokoID.DataPropertyName = "TokoID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TokoID.DefaultCellStyle = dataGridViewCellStyle2;
            this.TokoID.Frozen = true;
            this.TokoID.HeaderText = "TokoID";
            this.TokoID.Name = "TokoID";
            this.TokoID.ReadOnly = true;
            this.TokoID.Width = 80;
            // 
            // KodeToko
            // 
            this.KodeToko.DataPropertyName = "KodeToko";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KodeToko.DefaultCellStyle = dataGridViewCellStyle3;
            this.KodeToko.Frozen = true;
            this.KodeToko.HeaderText = "Kode Toko";
            this.KodeToko.Name = "KodeToko";
            this.KodeToko.ReadOnly = true;
            this.KodeToko.Visible = false;
            this.KodeToko.Width = 120;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.Frozen = true;
            this.NamaToko.HeaderText = "NamaToko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 300;
            // 
            // WilID
            // 
            this.WilID.DataPropertyName = "WilID";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WilID.DefaultCellStyle = dataGridViewCellStyle4;
            this.WilID.Frozen = true;
            this.WilID.HeaderText = "WilID";
            this.WilID.Name = "WilID";
            this.WilID.ReadOnly = true;
            this.WilID.Width = 80;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Width = 300;
            // 
            // TotalBayar
            // 
            this.TotalBayar.DataPropertyName = "TotalBayar";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.TotalBayar.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalBayar.HeaderText = "Total Bayar";
            this.TotalBayar.Name = "TotalBayar";
            this.TotalBayar.ReadOnly = true;
            // 
            // RataRataBayar
            // 
            this.RataRataBayar.DataPropertyName = "RataRataBayar";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.RataRataBayar.DefaultCellStyle = dataGridViewCellStyle6;
            this.RataRataBayar.HeaderText = "Rata Rata Bayar";
            this.RataRataBayar.Name = "RataRataBayar";
            this.RataRataBayar.ReadOnly = true;
            // 
            // PotensiBerkembang
            // 
            this.PotensiBerkembang.DataPropertyName = "PotensiBerkembang";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.PotensiBerkembang.DefaultCellStyle = dataGridViewCellStyle7;
            this.PotensiBerkembang.HeaderText = "Potensi Berkembang";
            this.PotensiBerkembang.Name = "PotensiBerkembang";
            this.PotensiBerkembang.ReadOnly = true;
            // 
            // KemampuanBayar
            // 
            this.KemampuanBayar.DataPropertyName = "KemampuanBayar";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.KemampuanBayar.DefaultCellStyle = dataGridViewCellStyle8;
            this.KemampuanBayar.HeaderText = "Kemampuan Bayar";
            this.KemampuanBayar.Name = "KemampuanBayar";
            this.KemampuanBayar.ReadOnly = true;
            // 
            // Plafon
            // 
            this.Plafon.DataPropertyName = "Plafon";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.Plafon.DefaultCellStyle = dataGridViewCellStyle9;
            this.Plafon.HeaderText = "Plafon";
            this.Plafon.Name = "Plafon";
            this.Plafon.ReadOnly = true;
            this.Plafon.Width = 80;
            // 
            // PlafonTambahan
            // 
            this.PlafonTambahan.DataPropertyName = "PlafonTambahan";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.PlafonTambahan.DefaultCellStyle = dataGridViewCellStyle10;
            this.PlafonTambahan.HeaderText = "Plafon Tambahan";
            this.PlafonTambahan.Name = "PlafonTambahan";
            this.PlafonTambahan.ReadOnly = true;
            // 
            // TotalPlafon
            // 
            this.TotalPlafon.DataPropertyName = "TotalPlafon";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            this.TotalPlafon.DefaultCellStyle = dataGridViewCellStyle11;
            this.TotalPlafon.HeaderText = "Total Plafon";
            this.TotalPlafon.Name = "TotalPlafon";
            this.TotalPlafon.ReadOnly = true;
            // 
            // TargetOmset
            // 
            this.TargetOmset.DataPropertyName = "TargetOmset";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            this.TargetOmset.DefaultCellStyle = dataGridViewCellStyle12;
            this.TargetOmset.HeaderText = "TargetOmset";
            this.TargetOmset.Name = "TargetOmset";
            this.TargetOmset.ReadOnly = true;
            // 
            // StatusPN
            // 
            this.StatusPN.DataPropertyName = "StatusPN";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StatusPN.DefaultCellStyle = dataGridViewCellStyle13;
            this.StatusPN.HeaderText = "P/N";
            this.StatusPN.Name = "StatusPN";
            this.StatusPN.ReadOnly = true;
            // 
            // TW
            // 
            this.TW.DataPropertyName = "JS";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            this.TW.DefaultCellStyle = dataGridViewCellStyle14;
            this.TW.HeaderText = "Tenggang Waktu";
            this.TW.Name = "TW";
            this.TW.ReadOnly = true;
            // 
            // JS
            // 
            this.JS.DataPropertyName = "JS";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            this.JS.DefaultCellStyle = dataGridViewCellStyle15;
            this.JS.HeaderText = "JS Baru";
            this.JS.Name = "JS";
            this.JS.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Visible = false;
            this.Keterangan.Width = 300;
            // 
            // mitra
            // 
            this.mitra.DataPropertyName = "mitra";
            this.mitra.HeaderText = "mitra";
            this.mitra.Name = "mitra";
            this.mitra.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cmdPrint);
            this.groupBox1.Controls.Add(this.cmdRefresh);
            this.groupBox1.Controls.Add(this.cmdProses);
            this.groupBox1.Location = new System.Drawing.Point(28, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 51);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(112, 4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.ReportName2 = "";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 4;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRefresh.CommandType = ISA.Controls.CommandButton.enCommandType.Refresh;
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(218, 5);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.ReportName2 = "";
            this.cmdRefresh.Size = new System.Drawing.Size(120, 40);
            this.cmdRefresh.TabIndex = 5;
            this.cmdRefresh.Text = "REFRESH";
            this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdProses
            // 
            this.cmdProses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdProses.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(6, 5);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.ReportName2 = "";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 3;
            this.cmdProses.Text = "Proses";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(572, 312);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName2 = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmPlafonBaru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(712, 367);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPlafonBaru";
            this.Text = "";
            this.Title = "";
            this.Load += new System.EventHandler(this.frmPlafonBaru_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ISA.Controls.CustomGridView GVHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglProses;
        private ISA.Controls.CustomGridView GVDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.CommandButton cmdRefresh;
        private ISA.Controls.CommandButton cmdProses;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn WilID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn RataRataBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PotensiBerkembang;
        private System.Windows.Forms.DataGridViewTextBoxColumn KemampuanBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plafon;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlafonTambahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPlafon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetOmset;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TW;
        private System.Windows.Forms.DataGridViewTextBoxColumn JS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn mitra;
    }
}
