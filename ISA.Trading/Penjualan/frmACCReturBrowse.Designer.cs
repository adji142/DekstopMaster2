namespace ISA.Trading.Penjualan
{
    partial class frmACCReturBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmACCReturBrowse));
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.dataGridDO = new ISA.Trading.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACCSPV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wilayah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NilaiRet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BagPenj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.rdbTglMPR = new ISA.Trading.Controls.RangeDateBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDO)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(670, 503);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 46;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(828, 503);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 47;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dataGridDO
            // 
            this.dataGridDO.AllowUserToAddRows = false;
            this.dataGridDO.AllowUserToDeleteRows = false;
            this.dataGridDO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDO.BackgroundColor = System.Drawing.Color.White;
            this.dataGridDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NoACC,
            this.NoACCSPV,
            this.NoMemo,
            this.TglMemo,
            this.NamaToko,
            this.Alamat,
            this.Kota,
            this.Wilayah,
            this.NilaiRet,
            this.BagPenj});
            this.dataGridDO.Location = new System.Drawing.Point(20, 117);
            this.dataGridDO.MultiSelect = false;
            this.dataGridDO.Name = "dataGridDO";
            this.dataGridDO.ReadOnly = true;
            this.dataGridDO.RowHeadersVisible = false;
            this.dataGridDO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDO.Size = new System.Drawing.Size(916, 371);
            this.dataGridDO.StandardTab = true;
            this.dataGridDO.TabIndex = 45;
            this.dataGridDO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridDO_KeyDown);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NoACC
            // 
            this.NoACC.DataPropertyName = "NoACC";
            this.NoACC.HeaderText = "NoACCPusat";
            this.NoACC.Name = "NoACC";
            this.NoACC.ReadOnly = true;
            // 
            // NoACCSPV
            // 
            this.NoACCSPV.DataPropertyName = "ACCSPV";
            this.NoACCSPV.HeaderText = "NoAccSPV";
            this.NoACCSPV.Name = "NoACCSPV";
            this.NoACCSPV.ReadOnly = true;
            // 
            // NoMemo
            // 
            this.NoMemo.DataPropertyName = "NoMPR";
            this.NoMemo.HeaderText = "No Memo";
            this.NoMemo.Name = "NoMemo";
            this.NoMemo.ReadOnly = true;
            // 
            // TglMemo
            // 
            this.TglMemo.DataPropertyName = "TglMPR";
            this.TglMemo.HeaderText = "Tgl MPR";
            this.TglMemo.Name = "TglMemo";
            this.TglMemo.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 200;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Width = 250;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // Wilayah
            // 
            this.Wilayah.DataPropertyName = "WilID";
            this.Wilayah.HeaderText = "Wilayah";
            this.Wilayah.Name = "Wilayah";
            this.Wilayah.ReadOnly = true;
            // 
            // NilaiRet
            // 
            this.NilaiRet.DataPropertyName = "NilaiRetur1";
            this.NilaiRet.HeaderText = "Nilai Ret";
            this.NilaiRet.Name = "NilaiRet";
            this.NilaiRet.ReadOnly = true;
            // 
            // BagPenj
            // 
            this.BagPenj.DataPropertyName = "BagPenjualan";
            this.BagPenj.HeaderText = "Bag Penjualan";
            this.BagPenj.Name = "BagPenj";
            this.BagPenj.ReadOnly = true;
            this.BagPenj.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 14);
            this.label5.TabIndex = 48;
            this.label5.Text = "Range tanggal MPR :";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(419, 69);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 44;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rdbTglMPR
            // 
            this.rdbTglMPR.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTglMPR.FromDate = null;
            this.rdbTglMPR.Location = new System.Drawing.Point(166, 69);
            this.rdbTglMPR.Name = "rdbTglMPR";
            this.rdbTglMPR.Size = new System.Drawing.Size(257, 22);
            this.rdbTglMPR.TabIndex = 43;
            this.rdbTglMPR.ToDate = null;
            this.rdbTglMPR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbTglMPR_KeyDown);
            // 
            // frmACCReturBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 568);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridDO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rdbTglMPR);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmACCReturBrowse";
            this.Text = "ACC Retur Supervisor";
            this.Title = "ACC Retur Supervisor";
            this.Load += new System.EventHandler(this.frmACCReturBrowse_Load);
            this.Controls.SetChildIndex(this.rdbTglMPR, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dataGridDO, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CustomGridView dataGridDO;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private ISA.Trading.Controls.RangeDateBox rdbTglMPR;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACCSPV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wilayah;
        private System.Windows.Forms.DataGridViewTextBoxColumn NilaiRet;
        private System.Windows.Forms.DataGridViewTextBoxColumn BagPenj;

    }
}