namespace ISA.Toko.Bonus
{
    partial class frmPengajuanBonusBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPengajuanBonusBrowser));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridDetail = new ISA.Toko.Controls.CustomGridView();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtySJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgNetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACCDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglACCDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSalesDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridHeader = new ISA.Toko.Controls.CustomGridView();
            this.NoSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WilID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.rgbTglSJ = new ISA.Toko.Controls.RangeDateBox();
            this.lblNamaBrg = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridDetail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridHeader, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 217);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.AllowUserToAddRows = false;
            this.dataGridDetail.AllowUserToDeleteRows = false;
            this.dataGridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaStok,
            this.QtySJ,
            this.HrgNetto,
            this.NoACCDetail,
            this.TglACCDetail,
            this.KodeSalesDetail});
            this.dataGridDetail.Location = new System.Drawing.Point(3, 111);
            this.dataGridDetail.MultiSelect = false;
            this.dataGridDetail.Name = "dataGridDetail";
            this.dataGridDetail.ReadOnly = true;
            this.dataGridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDetail.Size = new System.Drawing.Size(713, 103);
            this.dataGridDetail.StandardTab = true;
            this.dataGridDetail.TabIndex = 1;
            this.dataGridDetail.SelectionChanged += new System.EventHandler(this.dataGridDetail_SelectionChanged);
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 500;
            // 
            // QtySJ
            // 
            this.QtySJ.DataPropertyName = "QtySuratJalan";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QtySJ.DefaultCellStyle = dataGridViewCellStyle1;
            this.QtySJ.HeaderText = "Q.SJ";
            this.QtySJ.Name = "QtySJ";
            this.QtySJ.ReadOnly = true;
            this.QtySJ.Width = 40;
            // 
            // HrgNetto
            // 
            this.HrgNetto.DataPropertyName = "HrgNetto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HrgNetto.DefaultCellStyle = dataGridViewCellStyle2;
            this.HrgNetto.HeaderText = "Jumlah";
            this.HrgNetto.Name = "HrgNetto";
            this.HrgNetto.ReadOnly = true;
            // 
            // NoACCDetail
            // 
            this.NoACCDetail.DataPropertyName = "NoACC";
            this.NoACCDetail.HeaderText = "No.ACC";
            this.NoACCDetail.Name = "NoACCDetail";
            this.NoACCDetail.ReadOnly = true;
            // 
            // TglACCDetail
            // 
            this.TglACCDetail.DataPropertyName = "TglACC";
            this.TglACCDetail.HeaderText = "Tgl.ACC";
            this.TglACCDetail.Name = "TglACCDetail";
            this.TglACCDetail.ReadOnly = true;
            // 
            // KodeSalesDetail
            // 
            this.KodeSalesDetail.DataPropertyName = "KodeSales";
            this.KodeSalesDetail.HeaderText = "Kd.Sales";
            this.KodeSalesDetail.Name = "KodeSalesDetail";
            this.KodeSalesDetail.ReadOnly = true;
            // 
            // dataGridHeader
            // 
            this.dataGridHeader.AllowUserToAddRows = false;
            this.dataGridHeader.AllowUserToDeleteRows = false;
            this.dataGridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoSJ,
            this.TglSJ,
            this.RowID,
            this.NamaToko,
            this.WilID,
            this.KodeSales,
            this.TglTerima,
            this.TglJT,
            this.RpSJ,
            this.NoACC,
            this.TglACC});
            this.dataGridHeader.Location = new System.Drawing.Point(3, 3);
            this.dataGridHeader.MultiSelect = false;
            this.dataGridHeader.Name = "dataGridHeader";
            this.dataGridHeader.ReadOnly = true;
            this.dataGridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridHeader.Size = new System.Drawing.Size(713, 102);
            this.dataGridHeader.StandardTab = true;
            this.dataGridHeader.TabIndex = 0;
            this.dataGridHeader.SelectionRowChanged += new System.EventHandler(this.dataGridHeader_SelectionRowChanged);
            // 
            // NoSJ
            // 
            this.NoSJ.DataPropertyName = "NoSuratJalan";
            this.NoSJ.HeaderText = "No.SJ";
            this.NoSJ.Name = "NoSJ";
            this.NoSJ.ReadOnly = true;
            // 
            // TglSJ
            // 
            this.TglSJ.DataPropertyName = "TglSuratJalan";
            this.TglSJ.HeaderText = "Tgl.SJ";
            this.TglSJ.Name = "TglSJ";
            this.TglSJ.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "NamaToko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 200;
            // 
            // WilID
            // 
            this.WilID.DataPropertyName = "WilID";
            this.WilID.HeaderText = "Wil";
            this.WilID.Name = "WilID";
            this.WilID.ReadOnly = true;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "KodeSales";
            this.KodeSales.HeaderText = "Kd.Sales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            this.TglTerima.HeaderText = "Tgl.Terima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            // 
            // TglJT
            // 
            this.TglJT.DataPropertyName = "TglJatuhTempo";
            this.TglJT.HeaderText = "Tgl.JT";
            this.TglJT.Name = "TglJT";
            this.TglJT.ReadOnly = true;
            // 
            // RpSJ
            // 
            this.RpSJ.DataPropertyName = "RpSuratJalan";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RpSJ.DefaultCellStyle = dataGridViewCellStyle3;
            this.RpSJ.HeaderText = "Jumlah";
            this.RpSJ.Name = "RpSJ";
            this.RpSJ.ReadOnly = true;
            // 
            // NoACC
            // 
            this.NoACC.DataPropertyName = "NoACC";
            this.NoACC.HeaderText = "No.ACC";
            this.NoACC.Name = "NoACC";
            this.NoACC.ReadOnly = true;
            // 
            // TglACC
            // 
            this.TglACC.DataPropertyName = "TglACC";
            this.TglACC.HeaderText = "Tgl.ACC";
            this.TglACC.Name = "TglACC";
            this.TglACC.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 14);
            this.label5.TabIndex = 72;
            this.label5.Text = "Range tgl SJ: ";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(365, 65);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 71;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rgbTglSJ
            // 
            this.rgbTglSJ.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglSJ.FromDate = null;
            this.rgbTglSJ.Location = new System.Drawing.Point(126, 66);
            this.rgbTglSJ.Name = "rgbTglSJ";
            this.rgbTglSJ.Size = new System.Drawing.Size(257, 22);
            this.rgbTglSJ.TabIndex = 70;
            this.rgbTglSJ.ToDate = null;
            this.rgbTglSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTglSJ_KeyPress);
            // 
            // lblNamaBrg
            // 
            this.lblNamaBrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNamaBrg.AutoSize = true;
            this.lblNamaBrg.Location = new System.Drawing.Point(6, 314);
            this.lblNamaBrg.Name = "lblNamaBrg";
            this.lblNamaBrg.Size = new System.Drawing.Size(88, 14);
            this.lblNamaBrg.TabIndex = 73;
            this.lblNamaBrg.Text = "\"Nama Barang\"";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(607, 342);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 74;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmPengajuanBonusBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(719, 391);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblNamaBrg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rgbTglSJ);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPengajuanBonusBrowser";
            this.Load += new System.EventHandler(this.frmPengajuanBonusBrowser_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.rgbTglSJ, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblNamaBrg, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.RangeDateBox rgbTglSJ;
        private ISA.Toko.Controls.CustomGridView dataGridHeader;
        private System.Windows.Forms.Label lblNamaBrg;
        private ISA.Toko.Controls.CustomGridView dataGridDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtySJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgNetto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACCDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglACCDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSalesDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn WilID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglACC;
        private ISA.Toko.Controls.CommandButton cmdClose;
    }
}
