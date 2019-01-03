namespace ISA.Toko.Kasir
{
    partial class frmPenerimaanTunai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenerimaanTunai));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeTanggal = new ISA.Controls.RangeDateBox();
            this.cmdSeacrh = new ISA.Controls.CommandButton();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDInden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomorTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalIsiPin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdMintaPin = new ISA.Controls.CommandButton();
            this.cmdIsiPin = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Range Tanggal";
            // 
            // rangeTanggal
            // 
            this.rangeTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTanggal.FromDate = null;
            this.rangeTanggal.Location = new System.Drawing.Point(104, 20);
            this.rangeTanggal.Name = "rangeTanggal";
            this.rangeTanggal.Size = new System.Drawing.Size(257, 22);
            this.rangeTanggal.TabIndex = 28;
            this.rangeTanggal.ToDate = null;
            this.rangeTanggal.Leave += new System.EventHandler(this.rangeTanggal_Leave);
            // 
            // cmdSeacrh
            // 
            this.cmdSeacrh.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSeacrh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSeacrh.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeacrh.Image")));
            this.cmdSeacrh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSeacrh.Location = new System.Drawing.Point(367, 18);
            this.cmdSeacrh.Name = "cmdSeacrh";
            this.cmdSeacrh.Size = new System.Drawing.Size(80, 23);
            this.cmdSeacrh.TabIndex = 29;
            this.cmdSeacrh.Text = "Search";
            this.cmdSeacrh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSeacrh.UseVisualStyleBackColor = true;
            this.cmdSeacrh.Click += new System.EventHandler(this.cmdSeacrh_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.SyncFlag,
            this.LastUpdatedBy,
            this.LastUpdatedTime,
            this.RowIDInden,
            this.TanggalTerima,
            this.NomorTransaksi,
            this.CollectorID,
            this.Nama,
            this.Nominal,
            this.Keterangan,
            this.PublicKey,
            this.TanggalIsiPin,
            this.Pin});
            this.customGridView1.Location = new System.Drawing.Point(6, 48);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(843, 274);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 1;
            this.customGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellContentClick);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // RowIDInden
            // 
            this.RowIDInden.DataPropertyName = "RowIDInden";
            this.RowIDInden.HeaderText = "RowIDInden";
            this.RowIDInden.Name = "RowIDInden";
            this.RowIDInden.ReadOnly = true;
            this.RowIDInden.Visible = false;
            // 
            // TanggalTerima
            // 
            this.TanggalTerima.DataPropertyName = "TanggalTerima";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.TanggalTerima.DefaultCellStyle = dataGridViewCellStyle1;
            this.TanggalTerima.HeaderText = "Tgl Terima";
            this.TanggalTerima.Name = "TanggalTerima";
            this.TanggalTerima.ReadOnly = true;
            // 
            // NomorTransaksi
            // 
            this.NomorTransaksi.DataPropertyName = "NomorTransaksi";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NomorTransaksi.DefaultCellStyle = dataGridViewCellStyle2;
            this.NomorTransaksi.HeaderText = "No Transaksi";
            this.NomorTransaksi.Name = "NomorTransaksi";
            this.NomorTransaksi.ReadOnly = true;
            this.NomorTransaksi.Width = 120;
            // 
            // CollectorID
            // 
            this.CollectorID.DataPropertyName = "CollectorID";
            this.CollectorID.HeaderText = "CollectorID";
            this.CollectorID.Name = "CollectorID";
            this.CollectorID.ReadOnly = true;
            this.CollectorID.Visible = false;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Collector";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 150;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            this.Nominal.Width = 115;
            // 
            // Keterangan
            // 
            this.Keterangan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 95;
            // 
            // PublicKey
            // 
            this.PublicKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PublicKey.DataPropertyName = "PublicKey";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PublicKey.DefaultCellStyle = dataGridViewCellStyle4;
            this.PublicKey.HeaderText = "Public Key";
            this.PublicKey.Name = "PublicKey";
            this.PublicKey.ReadOnly = true;
            this.PublicKey.Width = 88;
            // 
            // TanggalIsiPin
            // 
            this.TanggalIsiPin.DataPropertyName = "TanggalIsiPin";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd-MM-yyyy";
            this.TanggalIsiPin.DefaultCellStyle = dataGridViewCellStyle5;
            this.TanggalIsiPin.HeaderText = "Tgl Isi Pin";
            this.TanggalIsiPin.Name = "TanggalIsiPin";
            this.TanggalIsiPin.ReadOnly = true;
            // 
            // Pin
            // 
            this.Pin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Pin.DataPropertyName = "Pin";
            this.Pin.HeaderText = "Pin";
            this.Pin.Name = "Pin";
            this.Pin.ReadOnly = true;
            this.Pin.Width = 49;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(6, 328);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 32;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(112, 328);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 33;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(749, 328);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 34;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdMintaPin
            // 
            this.cmdMintaPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdMintaPin.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdMintaPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdMintaPin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMintaPin.Location = new System.Drawing.Point(324, 329);
            this.cmdMintaPin.Name = "cmdMintaPin";
            this.cmdMintaPin.Size = new System.Drawing.Size(100, 40);
            this.cmdMintaPin.TabIndex = 35;
            this.cmdMintaPin.Text = "PERMINTAAN PIN";
            this.cmdMintaPin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdMintaPin.UseVisualStyleBackColor = true;
            this.cmdMintaPin.Click += new System.EventHandler(this.cmdMintaPin_Click);
            // 
            // cmdIsiPin
            // 
            this.cmdIsiPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdIsiPin.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdIsiPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdIsiPin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdIsiPin.Location = new System.Drawing.Point(218, 329);
            this.cmdIsiPin.Name = "cmdIsiPin";
            this.cmdIsiPin.Size = new System.Drawing.Size(100, 40);
            this.cmdIsiPin.TabIndex = 36;
            this.cmdIsiPin.Text = "ISI PIN";
            this.cmdIsiPin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdIsiPin.UseVisualStyleBackColor = true;
            this.cmdIsiPin.Click += new System.EventHandler(this.cmdIsiPin_Click);
            // 
            // frmPenerimaanTunai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 379);
            this.Controls.Add(this.cmdIsiPin);
            this.Controls.Add(this.cmdMintaPin);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeTanggal);
            this.Controls.Add(this.cmdSeacrh);
            this.Name = "frmPenerimaanTunai";
            this.Text = "Penerimaan Tunai";
            this.Load += new System.EventHandler(this.frmPenerimaanTunai_Load);
            this.Controls.SetChildIndex(this.cmdSeacrh, 0);
            this.Controls.SetChildIndex(this.rangeTanggal, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdMintaPin, 0);
            this.Controls.SetChildIndex(this.cmdIsiPin, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeTanggal;
        private ISA.Controls.CommandButton cmdSeacrh;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdMintaPin;
        private ISA.Controls.CommandButton cmdIsiPin;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDInden;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomorTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalIsiPin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pin;
    }
}