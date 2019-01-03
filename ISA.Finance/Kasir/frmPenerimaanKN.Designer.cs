namespace ISA.Finance.Kasir
{
    partial class frmPenerimaanKN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenerimaanKN));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeTanggal = new ISA.Controls.RangeDateBox();
            this.cmdSeacrh = new ISA.Controls.CommandButton();
            this.cgvPenerimaanKN = new ISA.Controls.CustomGridView();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdPin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDInden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomorKN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglIsiPin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cgvPenerimaanKN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 33;
            this.label1.Text = "Range Tanggal";
            // 
            // rangeTanggal
            // 
            this.rangeTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTanggal.FromDate = null;
            this.rangeTanggal.Location = new System.Drawing.Point(104, 20);
            this.rangeTanggal.Name = "rangeTanggal";
            this.rangeTanggal.Size = new System.Drawing.Size(257, 22);
            this.rangeTanggal.TabIndex = 1;
            this.rangeTanggal.ToDate = null;
            // 
            // cmdSeacrh
            // 
            this.cmdSeacrh.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSeacrh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSeacrh.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeacrh.Image")));
            this.cmdSeacrh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSeacrh.Location = new System.Drawing.Point(363, 19);
            this.cmdSeacrh.Name = "cmdSeacrh";
            this.cmdSeacrh.Size = new System.Drawing.Size(80, 23);
            this.cmdSeacrh.TabIndex = 32;
            this.cmdSeacrh.Text = "Search";
            this.cmdSeacrh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSeacrh.UseVisualStyleBackColor = true;
            this.cmdSeacrh.Click += new System.EventHandler(this.cmdSeacrh_Click);
            // 
            // cgvPenerimaanKN
            // 
            this.cgvPenerimaanKN.AllowUserToAddRows = false;
            this.cgvPenerimaanKN.AllowUserToDeleteRows = false;
            this.cgvPenerimaanKN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cgvPenerimaanKN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cgvPenerimaanKN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cgvPenerimaanKN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.RowIDInden,
            this.Tanggal,
            this.NomorKN,
            this.Nominal,
            this.Nama,
            this.CollectorID,
            this.Bank,
            this.BankID,
            this.Keterangan,
            this.PublicKey,
            this.TglIsiPin,
            this.Pin,
            this.SyncFlag,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.cgvPenerimaanKN.Location = new System.Drawing.Point(8, 50);
            this.cgvPenerimaanKN.MultiSelect = false;
            this.cgvPenerimaanKN.Name = "cgvPenerimaanKN";
            this.cgvPenerimaanKN.ReadOnly = true;
            this.cgvPenerimaanKN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cgvPenerimaanKN.Size = new System.Drawing.Size(839, 274);
            this.cgvPenerimaanKN.StandardTab = true;
            this.cgvPenerimaanKN.TabIndex = 0;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(112, 333);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(6, 332);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(443, 333);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdPin
            // 
            this.cmdPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPin.Image = global::ISA.Finance.Properties.Resources.Ok32;
            this.cmdPin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPin.Location = new System.Drawing.Point(337, 333);
            this.cmdPin.Name = "cmdPin";
            this.cmdPin.Size = new System.Drawing.Size(100, 40);
            this.cmdPin.TabIndex = 5;
            this.cmdPin.Text = "     ISI PIN";
            this.cmdPin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ISA.Finance.Properties.Resources.Key32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(218, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "       AJUAN PIN";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 200;
            // 
            // RowIDInden
            // 
            this.RowIDInden.DataPropertyName = "RowIDInden";
            this.RowIDInden.HeaderText = "RowIDInden";
            this.RowIDInden.Name = "RowIDInden";
            this.RowIDInden.ReadOnly = true;
            this.RowIDInden.Visible = false;
            this.RowIDInden.Width = 200;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            this.Tanggal.Width = 80;
            // 
            // NomorKN
            // 
            this.NomorKN.DataPropertyName = "NomorKN";
            this.NomorKN.HeaderText = "Nomor KN";
            this.NomorKN.Name = "NomorKN";
            this.NomorKN.ReadOnly = true;
            this.NomorKN.Width = 150;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Collector";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            // 
            // CollectorID
            // 
            this.CollectorID.DataPropertyName = "CollectorID";
            this.CollectorID.HeaderText = "CollectorID";
            this.CollectorID.Name = "CollectorID";
            this.CollectorID.ReadOnly = true;
            this.CollectorID.Visible = false;
            this.CollectorID.Width = 200;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Bank";
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            this.Bank.Width = 150;
            // 
            // BankID
            // 
            this.BankID.DataPropertyName = "BankID";
            this.BankID.HeaderText = "BankID";
            this.BankID.Name = "BankID";
            this.BankID.ReadOnly = true;
            this.BankID.Visible = false;
            this.BankID.Width = 150;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 300;
            // 
            // PublicKey
            // 
            this.PublicKey.DataPropertyName = "PublicKey";
            this.PublicKey.HeaderText = "PublicKey";
            this.PublicKey.Name = "PublicKey";
            this.PublicKey.ReadOnly = true;
            this.PublicKey.Width = 200;
            // 
            // TglIsiPin
            // 
            this.TglIsiPin.DataPropertyName = "TglIsiPin";
            this.TglIsiPin.HeaderText = "Tgl isi Pin";
            this.TglIsiPin.Name = "TglIsiPin";
            this.TglIsiPin.ReadOnly = true;
            // 
            // Pin
            // 
            this.Pin.DataPropertyName = "Pin";
            this.Pin.HeaderText = "Pin";
            this.Pin.Name = "Pin";
            this.Pin.ReadOnly = true;
            this.Pin.Width = 200;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            // 
            // frmPenerimaanKN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(856, 385);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdPin);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cgvPenerimaanKN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeTanggal);
            this.Controls.Add(this.cmdSeacrh);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenerimaanKN";
            this.Text = "";
            this.Title = "";
            this.Load += new System.EventHandler(this.frmPenerimaanKN_Load);
            this.Controls.SetChildIndex(this.cmdSeacrh, 0);
            this.Controls.SetChildIndex(this.rangeTanggal, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cgvPenerimaanKN, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdPin, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cgvPenerimaanKN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeTanggal;
        private ISA.Controls.CommandButton cmdSeacrh;
        private ISA.Controls.CustomGridView cgvPenerimaanKN;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Button cmdPin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDInden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomorKN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglIsiPin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pin;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}
