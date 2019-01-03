namespace ISA.Finance.Kasir.Budget
{
    partial class frmBudgetMingguan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetMingguan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.rangePriode = new ISA.Controls.MonthYearBox();
            this.GVHeader = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MingguKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalMulai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalSelesai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalNominalRencana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVDetail = new System.Windows.Forms.DataGridView();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BudgetMingguanRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBiaya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalRencana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeteranganD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SynchFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 76;
            this.label1.Text = "Periode";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(404, 67);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 75;
            this.cmdSearch.TabStop = false;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rangePriode
            // 
            this.rangePriode.Location = new System.Drawing.Point(117, 68);
            this.rangePriode.Month = 1;
            this.rangePriode.Name = "rangePriode";
            this.rangePriode.Size = new System.Drawing.Size(345, 40);
            this.rangePriode.TabIndex = 74;
            this.rangePriode.Year = 2016;
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.MingguKe,
            this.TanggalMulai,
            this.TanggalSelesai,
            this.TotalNominalRencana,
            this.Keterangan});
            this.GVHeader.Location = new System.Drawing.Point(26, 110);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(1306, 183);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 77;
            this.GVHeader.SelectionRowChanged += new System.EventHandler(this.GVHeader_SelectionRowChanged);
            this.GVHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GVHeader_KeyDown);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // MingguKe
            // 
            this.MingguKe.DataPropertyName = "MingguKe";
            this.MingguKe.HeaderText = "Minggu Ke";
            this.MingguKe.Name = "MingguKe";
            this.MingguKe.ReadOnly = true;
            // 
            // TanggalMulai
            // 
            this.TanggalMulai.DataPropertyName = "TanggalMulai";
            dataGridViewCellStyle6.Format = "dd-MM-yyyy";
            this.TanggalMulai.DefaultCellStyle = dataGridViewCellStyle6;
            this.TanggalMulai.HeaderText = "Tanggal Mulai";
            this.TanggalMulai.Name = "TanggalMulai";
            this.TanggalMulai.ReadOnly = true;
            this.TanggalMulai.Width = 150;
            // 
            // TanggalSelesai
            // 
            this.TanggalSelesai.DataPropertyName = "TanggalSelesai";
            dataGridViewCellStyle7.Format = "dd-MM-yyyy";
            this.TanggalSelesai.DefaultCellStyle = dataGridViewCellStyle7;
            this.TanggalSelesai.HeaderText = "Tanggal Selesai";
            this.TanggalSelesai.Name = "TanggalSelesai";
            this.TanggalSelesai.ReadOnly = true;
            this.TanggalSelesai.Width = 150;
            // 
            // TotalNominalRencana
            // 
            this.TotalNominalRencana.DataPropertyName = "TotalNominalRencana";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.TotalNominalRencana.DefaultCellStyle = dataGridViewCellStyle8;
            this.TotalNominalRencana.HeaderText = "Total Nominal Rencana";
            this.TotalNominalRencana.Name = "TotalNominalRencana";
            this.TotalNominalRencana.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 300;
            // 
            // GVDetail
            // 
            this.GVDetail.AllowUserToAddRows = false;
            this.GVDetail.AllowUserToDeleteRows = false;
            this.GVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDD,
            this.BudgetMingguanRowID,
            this.NoPerkiraan,
            this.GroupBiaya,
            this.NominalRencana,
            this.KeteranganD,
            this.KodeGudang,
            this.SynchFlag});
            this.GVDetail.Location = new System.Drawing.Point(26, 299);
            this.GVDetail.Name = "GVDetail";
            this.GVDetail.Size = new System.Drawing.Size(1306, 262);
            this.GVDetail.TabIndex = 78;
            // 
            // RowIDD
            // 
            this.RowIDD.DataPropertyName = "RowID";
            this.RowIDD.HeaderText = "RowID";
            this.RowIDD.Name = "RowIDD";
            this.RowIDD.ReadOnly = true;
            this.RowIDD.Visible = false;
            // 
            // BudgetMingguanRowID
            // 
            this.BudgetMingguanRowID.DataPropertyName = "BudgetMingguanRowID";
            this.BudgetMingguanRowID.HeaderText = "BudgetMingguanRowID";
            this.BudgetMingguanRowID.Name = "BudgetMingguanRowID";
            this.BudgetMingguanRowID.ReadOnly = true;
            this.BudgetMingguanRowID.Visible = false;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "No Perkiraan";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            this.NoPerkiraan.Width = 150;
            // 
            // GroupBiaya
            // 
            this.GroupBiaya.DataPropertyName = "GroupBiaya";
            this.GroupBiaya.HeaderText = "Group Biaya";
            this.GroupBiaya.Name = "GroupBiaya";
            this.GroupBiaya.ReadOnly = true;
            this.GroupBiaya.Width = 300;
            // 
            // NominalRencana
            // 
            this.NominalRencana.DataPropertyName = "NominalRencana";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.NominalRencana.DefaultCellStyle = dataGridViewCellStyle9;
            this.NominalRencana.HeaderText = "Nominal Rencana";
            this.NominalRencana.Name = "NominalRencana";
            // 
            // KeteranganD
            // 
            this.KeteranganD.DataPropertyName = "Keterangan";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KeteranganD.DefaultCellStyle = dataGridViewCellStyle10;
            this.KeteranganD.HeaderText = "Keterangan";
            this.KeteranganD.Name = "KeteranganD";
            // 
            // KodeGudang
            // 
            this.KodeGudang.DataPropertyName = "KodeGudang";
            this.KodeGudang.HeaderText = "Kode Gudang";
            this.KodeGudang.Name = "KodeGudang";
            this.KodeGudang.ReadOnly = true;
            this.KodeGudang.Width = 120;
            // 
            // SynchFlag
            // 
            this.SynchFlag.DataPropertyName = "SynchFlag";
            this.SynchFlag.HeaderText = "SynchFlag";
            this.SynchFlag.Name = "SynchFlag";
            this.SynchFlag.ReadOnly = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1232, 678);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 82;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(263, 678);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 81;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(142, 678);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 80;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(26, 678);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 79;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmBudgetMingguan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.GVDetail);
            this.Controls.Add(this.GVHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rangePriode);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBudgetMingguan";
            this.Text = "Budget Mingguan";
            this.Title = "Budget Mingguan";
            this.Load += new System.EventHandler(this.frmBudgetMingguan_Load);
            this.Controls.SetChildIndex(this.rangePriode, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.GVHeader, 0);
            this.Controls.SetChildIndex(this.GVDetail, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.MonthYearBox rangePriode;
        private ISA.Controls.CustomGridView GVHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MingguKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalMulai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalSelesai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNominalRencana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridView GVDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn BudgetMingguanRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupBiaya;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalRencana;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeteranganD;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SynchFlag;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdAdd;

    }
}
