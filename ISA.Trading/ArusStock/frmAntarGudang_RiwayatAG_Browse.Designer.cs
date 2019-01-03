namespace ISA.Trading.ArusStock
{
    partial class frmAntarGudang_RiwayatAG_Browse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAntarGudang_RiwayatAG_Browse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridHeader = new ISA.Trading.Controls.CustomGridView();
            this.DrGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrCheck1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrCheck2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeCheck1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeCheck2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expedisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoKendaraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSopir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KirimTerimaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.lookupStock = new ISA.Trading.Controls.LookupStock();
            this.dataGridDetail = new ISA.Trading.Controls.CustomGridView();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKirimD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerimaD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatatanD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrGudangD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeGudangD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlagD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "NAMA STOK: ";
            // 
            // dataGridHeader
            // 
            this.dataGridHeader.AllowUserToAddRows = false;
            this.dataGridHeader.AllowUserToDeleteRows = false;
            this.dataGridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DrGudang,
            this.TglKirim,
            this.KeGudang,
            this.TglTerima,
            this.Pengirim,
            this.NoAG,
            this.Penerima,
            this.DrCheck1,
            this.DrCheck2,
            this.KeCheck1,
            this.KeCheck2,
            this.Catatan,
            this.RowID,
            this.RecordID,
            this.Expedisi,
            this.NoKendaraan,
            this.NamaSopir,
            this.KirimTerimaID,
            this.SyncFlag});
            this.dataGridHeader.Location = new System.Drawing.Point(12, 120);
            this.dataGridHeader.MultiSelect = false;
            this.dataGridHeader.Name = "dataGridHeader";
            this.dataGridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridHeader.Size = new System.Drawing.Size(817, 150);
            this.dataGridHeader.StandardTab = true;
            this.dataGridHeader.TabIndex = 5;
            this.dataGridHeader.SelectionRowChanged += new System.EventHandler(this.dataGridHeader_SelectionRowChanged);
            // 
            // DrGudang
            // 
            this.DrGudang.DataPropertyName = "DrGudang";
            this.DrGudang.HeaderText = "Dr Gudang";
            this.DrGudang.Name = "DrGudang";
            this.DrGudang.Width = 88;
            // 
            // TglKirim
            // 
            this.TglKirim.DataPropertyName = "TglKirim";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.TglKirim.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglKirim.HeaderText = "Tgl Kirim";
            this.TglKirim.Name = "TglKirim";
            this.TglKirim.Width = 88;
            // 
            // KeGudang
            // 
            this.KeGudang.DataPropertyName = "KeGudang";
            this.KeGudang.HeaderText = "Ke Gudang";
            this.KeGudang.Name = "KeGudang";
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.TglTerima.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglTerima.HeaderText = "Tgl Terima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.Width = 88;
            // 
            // Pengirim
            // 
            this.Pengirim.DataPropertyName = "Pengirim";
            this.Pengirim.HeaderText = "Pengirim";
            this.Pengirim.Name = "Pengirim";
            this.Pengirim.Width = 88;
            // 
            // NoAG
            // 
            this.NoAG.DataPropertyName = "NoAG";
            this.NoAG.HeaderText = "No AG";
            this.NoAG.Name = "NoAG";
            this.NoAG.Width = 70;
            // 
            // Penerima
            // 
            this.Penerima.DataPropertyName = "Penerima";
            this.Penerima.HeaderText = "Penerima";
            this.Penerima.Name = "Penerima";
            this.Penerima.Width = 88;
            // 
            // DrCheck1
            // 
            this.DrCheck1.DataPropertyName = "DrCheck1";
            this.DrCheck1.HeaderText = "DrCheck1";
            this.DrCheck1.Name = "DrCheck1";
            this.DrCheck1.Width = 88;
            // 
            // DrCheck2
            // 
            this.DrCheck2.DataPropertyName = "DrCheck2";
            this.DrCheck2.HeaderText = "DrCheck2";
            this.DrCheck2.Name = "DrCheck2";
            this.DrCheck2.Width = 88;
            // 
            // KeCheck1
            // 
            this.KeCheck1.DataPropertyName = "KeCheck1";
            this.KeCheck1.HeaderText = "KeCheck1";
            this.KeCheck1.Name = "KeCheck1";
            this.KeCheck1.Width = 88;
            // 
            // KeCheck2
            // 
            this.KeCheck2.DataPropertyName = "KeCheck2";
            this.KeCheck2.HeaderText = "KeCheck2";
            this.KeCheck2.Name = "KeCheck2";
            this.KeCheck2.Width = 88;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.Visible = false;
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "RecordID";
            this.RecordID.Name = "RecordID";
            this.RecordID.Visible = false;
            // 
            // Expedisi
            // 
            this.Expedisi.DataPropertyName = "Expedisi";
            this.Expedisi.HeaderText = "Expedisi";
            this.Expedisi.Name = "Expedisi";
            // 
            // NoKendaraan
            // 
            this.NoKendaraan.DataPropertyName = "NoKendaraan";
            this.NoKendaraan.HeaderText = "NoKendaraan";
            this.NoKendaraan.Name = "NoKendaraan";
            // 
            // NamaSopir
            // 
            this.NamaSopir.DataPropertyName = "NamaSopir";
            this.NamaSopir.HeaderText = "NamaSopir";
            this.NamaSopir.Name = "NamaSopir";
            // 
            // KirimTerimaID
            // 
            this.KirimTerimaID.DataPropertyName = "KirimTerimaID";
            this.KirimTerimaID.HeaderText = "KirimTerimaID";
            this.KirimTerimaID.Name = "KirimTerimaID";
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(729, 581);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lookupStock
            // 
            this.lookupStock.BarangID = "[CODE]";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(106, 58);
            this.lookupStock.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(392, 54);
            this.lookupStock.TabIndex = 9;
            this.lookupStock.SelectData += new System.EventHandler(this.lookupStock_SelectData);
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.AllowUserToAddRows = false;
            this.dataGridDetail.AllowUserToDeleteRows = false;
            this.dataGridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaStok,
            this.QtyDO,
            this.QtyKirim,
            this.QtyTerima,
            this.TglKirimD,
            this.TglTerimaD,
            this.CatatanD,
            this.DrGudangD,
            this.KeGudangD,
            this.KodeBarang,
            this.TransactionIDD,
            this.HeaderIDD,
            this.SyncFlagD,
            this.RowIDD});
            this.dataGridDetail.Location = new System.Drawing.Point(12, 276);
            this.dataGridDetail.MultiSelect = false;
            this.dataGridDetail.Name = "dataGridDetail";
            this.dataGridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDetail.Size = new System.Drawing.Size(817, 299);
            this.dataGridDetail.StandardTab = true;
            this.dataGridDetail.TabIndex = 6;
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.Width = 370;
            // 
            // QtyDO
            // 
            this.QtyDO.DataPropertyName = "QtyDO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.QtyDO.DefaultCellStyle = dataGridViewCellStyle3;
            this.QtyDO.HeaderText = "QtyDO";
            this.QtyDO.Name = "QtyDO";
            this.QtyDO.Width = 75;
            // 
            // QtyKirim
            // 
            this.QtyKirim.DataPropertyName = "QtyKirim";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.QtyKirim.DefaultCellStyle = dataGridViewCellStyle4;
            this.QtyKirim.HeaderText = "QtyKirim";
            this.QtyKirim.Name = "QtyKirim";
            this.QtyKirim.Width = 75;
            // 
            // QtyTerima
            // 
            this.QtyTerima.DataPropertyName = "QtyTerima";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.QtyTerima.DefaultCellStyle = dataGridViewCellStyle5;
            this.QtyTerima.HeaderText = "QtyTerima";
            this.QtyTerima.Name = "QtyTerima";
            this.QtyTerima.Width = 75;
            // 
            // TglKirimD
            // 
            this.TglKirimD.DataPropertyName = "TglKirim";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.TglKirimD.DefaultCellStyle = dataGridViewCellStyle6;
            this.TglKirimD.HeaderText = "Tgl Kirim";
            this.TglKirimD.Name = "TglKirimD";
            this.TglKirimD.Width = 88;
            // 
            // TglTerimaD
            // 
            this.TglTerimaD.DataPropertyName = "TglTerima";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.TglTerimaD.DefaultCellStyle = dataGridViewCellStyle7;
            this.TglTerimaD.HeaderText = "Tgl Terima";
            this.TglTerimaD.Name = "TglTerimaD";
            this.TglTerimaD.Width = 88;
            // 
            // CatatanD
            // 
            this.CatatanD.HeaderText = "Catatan";
            this.CatatanD.Name = "CatatanD";
            // 
            // DrGudangD
            // 
            this.DrGudangD.DataPropertyName = "DrGudang";
            this.DrGudangD.HeaderText = "DrGudang";
            this.DrGudangD.Name = "DrGudangD";
            this.DrGudangD.Width = 88;
            // 
            // KeGudangD
            // 
            this.KeGudangD.DataPropertyName = "KeGudang";
            this.KeGudangD.HeaderText = "KeGudang";
            this.KeGudangD.Name = "KeGudangD";
            this.KeGudangD.Width = 88;
            // 
            // KodeBarang
            // 
            this.KodeBarang.DataPropertyName = "KodeBarang";
            this.KodeBarang.HeaderText = "KodeBarang";
            this.KodeBarang.Name = "KodeBarang";
            this.KodeBarang.Width = 88;
            // 
            // TransactionIDD
            // 
            this.TransactionIDD.DataPropertyName = "TransactionID";
            this.TransactionIDD.HeaderText = "TransactionID";
            this.TransactionIDD.Name = "TransactionIDD";
            this.TransactionIDD.Visible = false;
            // 
            // HeaderIDD
            // 
            this.HeaderIDD.DataPropertyName = "HeaderID";
            this.HeaderIDD.HeaderText = "HeaderID";
            this.HeaderIDD.Name = "HeaderIDD";
            this.HeaderIDD.Visible = false;
            // 
            // SyncFlagD
            // 
            this.SyncFlagD.DataPropertyName = "SyncFlag";
            this.SyncFlagD.HeaderText = "SyncFlag";
            this.SyncFlagD.Name = "SyncFlagD";
            this.SyncFlagD.Width = 75;
            // 
            // RowIDD
            // 
            this.RowIDD.DataPropertyName = "RowID";
            this.RowIDD.HeaderText = "RowID";
            this.RowIDD.Name = "RowIDD";
            this.RowIDD.Visible = false;
            // 
            // frmAntarGudang_RiwayatAG_Browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(838, 633);
            this.Controls.Add(this.dataGridHeader);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupStock);
            this.Controls.Add(this.dataGridDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAntarGudang_RiwayatAG_Browse";
            this.Text = "Riwayat Arus Stok - Antar Gudang";
            this.Title = "Riwayat Arus Stok - Antar Gudang";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmAntarGudang_RiwayatAG_Browse_Load);
            this.Controls.SetChildIndex(this.dataGridDetail, 0);
            this.Controls.SetChildIndex(this.lookupStock, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dataGridHeader, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView dataGridHeader;
        private ISA.Trading.Controls.CustomGridView dataGridDetail;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.LookupStock lookupStock;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pengirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrCheck1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrCheck2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeCheck1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeCheck2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expedisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoKendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSopir;
        private System.Windows.Forms.DataGridViewTextBoxColumn KirimTerimaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKirimD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerimaD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatatanD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrGudangD;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeGudangD;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlagD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;

    }
}
