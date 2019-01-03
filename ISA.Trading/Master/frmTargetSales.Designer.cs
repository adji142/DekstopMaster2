namespace ISA.Trading.Master
{
    partial class frmTargetSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTargetSales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdBtnEDIT = new ISA.Trading.Controls.CommandButton();
            this.cmdBtnADD = new ISA.Trading.Controls.CommandButton();
            this.cgvTargetSls = new ISA.Trading.Controls.CustomGridView();
            this.tmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skur2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skur4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skulain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfe4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfb2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfb4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomflain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokoOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokoKunj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colrowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDownload = new ISA.Trading.Controls.CommandButton();
            this.gvTargetToko = new ISA.Trading.Controls.CustomGridView();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idwil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetBE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrgBE = new ISA.Trading.Controls.NumericTextBox();
            this.txtTrgFA = new ISA.Trading.Controls.NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cgvTargetSls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTargetToko)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdBtnEDIT
            // 
            this.cmdBtnEDIT.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdBtnEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnEDIT.Image")));
            this.cmdBtnEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnEDIT.Location = new System.Drawing.Point(563, 511);
            this.cmdBtnEDIT.Name = "cmdBtnEDIT";
            this.cmdBtnEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnEDIT.TabIndex = 7;
            this.cmdBtnEDIT.Text = "EDIT";
            this.cmdBtnEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnEDIT.UseVisualStyleBackColor = true;
            this.cmdBtnEDIT.Visible = false;
            this.cmdBtnEDIT.Click += new System.EventHandler(this.cmdBtnEDIT_Click);
            // 
            // cmdBtnADD
            // 
            this.cmdBtnADD.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdBtnADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnADD.Image")));
            this.cmdBtnADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnADD.Location = new System.Drawing.Point(459, 511);
            this.cmdBtnADD.Name = "cmdBtnADD";
            this.cmdBtnADD.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnADD.TabIndex = 6;
            this.cmdBtnADD.Text = "ADD";
            this.cmdBtnADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnADD.UseVisualStyleBackColor = true;
            this.cmdBtnADD.Visible = false;
            this.cmdBtnADD.Click += new System.EventHandler(this.cmdBtnADD_Click_1);
            // 
            // cgvTargetSls
            // 
            this.cgvTargetSls.AllowUserToAddRows = false;
            this.cgvTargetSls.AllowUserToDeleteRows = false;
            this.cgvTargetSls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cgvTargetSls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cgvTargetSls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmt,
            this.KodeSales,
            this.NamaSales,
            this.skur2,
            this.skur4,
            this.skulain,
            this.nomfe2,
            this.nomfe4,
            this.nomfb2,
            this.nomfb4,
            this.nomfa,
            this.nomflain,
            this.tokoOA,
            this.tokoKunj,
            this.colrowID,
            this.KodeGudang,
            this.SyncFlag});
            this.cgvTargetSls.Location = new System.Drawing.Point(8, 65);
            this.cgvTargetSls.MultiSelect = false;
            this.cgvTargetSls.Name = "cgvTargetSls";
            this.cgvTargetSls.ReadOnly = true;
            this.cgvTargetSls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cgvTargetSls.Size = new System.Drawing.Size(759, 134);
            this.cgvTargetSls.StandardTab = true;
            this.cgvTargetSls.TabIndex = 5;
            this.cgvTargetSls.SelectionRowChanged += new System.EventHandler(this.cgvTargetSls_SelectionRowChanged);
            // 
            // tmt
            // 
            this.tmt.DataPropertyName = "TglAktif";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.tmt.DefaultCellStyle = dataGridViewCellStyle1;
            this.tmt.HeaderText = "Tanggal";
            this.tmt.Name = "tmt";
            this.tmt.ReadOnly = true;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "SalesID";
            this.KodeSales.HeaderText = "KodeSales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            // 
            // NamaSales
            // 
            this.NamaSales.DataPropertyName = "NamaSales";
            this.NamaSales.HeaderText = "Nama Sales";
            this.NamaSales.Name = "NamaSales";
            this.NamaSales.ReadOnly = true;
            this.NamaSales.Width = 180;
            // 
            // skur2
            // 
            this.skur2.DataPropertyName = "SKUR2";
            this.skur2.HeaderText = "SKU R2";
            this.skur2.Name = "skur2";
            this.skur2.ReadOnly = true;
            this.skur2.Visible = false;
            this.skur2.Width = 60;
            // 
            // skur4
            // 
            this.skur4.DataPropertyName = "SKUR4";
            this.skur4.HeaderText = "SKU R4";
            this.skur4.Name = "skur4";
            this.skur4.ReadOnly = true;
            this.skur4.Visible = false;
            this.skur4.Width = 60;
            // 
            // skulain
            // 
            this.skulain.DataPropertyName = "SKULain";
            this.skulain.HeaderText = "SKU Lain";
            this.skulain.Name = "skulain";
            this.skulain.ReadOnly = true;
            this.skulain.Visible = false;
            this.skulain.Width = 60;
            // 
            // nomfe2
            // 
            this.nomfe2.DataPropertyName = "NomFE2";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.nomfe2.DefaultCellStyle = dataGridViewCellStyle2;
            this.nomfe2.HeaderText = "NOM. FE2";
            this.nomfe2.Name = "nomfe2";
            this.nomfe2.ReadOnly = true;
            this.nomfe2.Visible = false;
            // 
            // nomfe4
            // 
            this.nomfe4.DataPropertyName = "NomFE4";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.nomfe4.DefaultCellStyle = dataGridViewCellStyle3;
            this.nomfe4.HeaderText = "NOM. FE4";
            this.nomfe4.Name = "nomfe4";
            this.nomfe4.ReadOnly = true;
            this.nomfe4.Visible = false;
            // 
            // nomfb2
            // 
            this.nomfb2.DataPropertyName = "NomFB2";
            dataGridViewCellStyle4.Format = "N0";
            this.nomfb2.DefaultCellStyle = dataGridViewCellStyle4;
            this.nomfb2.HeaderText = "Target BE";
            this.nomfb2.Name = "nomfb2";
            this.nomfb2.ReadOnly = true;
            this.nomfb2.Width = 120;
            // 
            // nomfb4
            // 
            this.nomfb4.DataPropertyName = "NomFB4";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.nomfb4.DefaultCellStyle = dataGridViewCellStyle5;
            this.nomfb4.HeaderText = "NOM. FB4";
            this.nomfb4.Name = "nomfb4";
            this.nomfb4.ReadOnly = true;
            this.nomfb4.Visible = false;
            // 
            // nomfa
            // 
            this.nomfa.DataPropertyName = "NomFA";
            dataGridViewCellStyle6.Format = "N0";
            this.nomfa.DefaultCellStyle = dataGridViewCellStyle6;
            this.nomfa.HeaderText = "Target FA";
            this.nomfa.Name = "nomfa";
            this.nomfa.ReadOnly = true;
            this.nomfa.Width = 120;
            // 
            // nomflain
            // 
            this.nomflain.DataPropertyName = "NomFLain";
            dataGridViewCellStyle7.Format = "N0";
            this.nomflain.DefaultCellStyle = dataGridViewCellStyle7;
            this.nomflain.HeaderText = "NOM. F LAIN";
            this.nomflain.Name = "nomflain";
            this.nomflain.ReadOnly = true;
            this.nomflain.Visible = false;
            // 
            // tokoOA
            // 
            this.tokoOA.DataPropertyName = "OrderAktif";
            this.tokoOA.HeaderText = "TOKO OA";
            this.tokoOA.Name = "tokoOA";
            this.tokoOA.ReadOnly = true;
            this.tokoOA.Visible = false;
            this.tokoOA.Width = 70;
            // 
            // tokoKunj
            // 
            this.tokoKunj.DataPropertyName = "Kunjungan";
            this.tokoKunj.HeaderText = "TOKO KUNJ";
            this.tokoKunj.Name = "tokoKunj";
            this.tokoKunj.ReadOnly = true;
            this.tokoKunj.Visible = false;
            this.tokoKunj.Width = 70;
            // 
            // colrowID
            // 
            this.colrowID.DataPropertyName = "rowID";
            this.colrowID.HeaderText = "RowID";
            this.colrowID.Name = "colrowID";
            this.colrowID.ReadOnly = true;
            this.colrowID.Visible = false;
            // 
            // KodeGudang
            // 
            this.KodeGudang.DataPropertyName = "KodeGudang";
            this.KodeGudang.HeaderText = "Gudang";
            this.KodeGudang.Name = "KodeGudang";
            this.KodeGudang.ReadOnly = true;
            this.KodeGudang.Width = 75;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(667, 511);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(8, 511);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 9;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // gvTargetToko
            // 
            this.gvTargetToko.AllowUserToAddRows = false;
            this.gvTargetToko.AllowUserToDeleteRows = false;
            this.gvTargetToko.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvTargetToko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTargetToko.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaToko,
            this.KodeToko,
            this.Kota,
            this.Idwil,
            this.TargetBE,
            this.TargetFA});
            this.gvTargetToko.Location = new System.Drawing.Point(8, 211);
            this.gvTargetToko.MultiSelect = false;
            this.gvTargetToko.Name = "gvTargetToko";
            this.gvTargetToko.ReadOnly = true;
            this.gvTargetToko.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvTargetToko.Size = new System.Drawing.Size(759, 264);
            this.gvTargetToko.StandardTab = true;
            this.gvTargetToko.TabIndex = 14;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 225;
            // 
            // KodeToko
            // 
            this.KodeToko.DataPropertyName = "KodeToko";
            this.KodeToko.HeaderText = "Kode Toko";
            this.KodeToko.Name = "KodeToko";
            this.KodeToko.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // Idwil
            // 
            this.Idwil.DataPropertyName = "WilID";
            this.Idwil.HeaderText = "Idwil";
            this.Idwil.Name = "Idwil";
            this.Idwil.ReadOnly = true;
            this.Idwil.Width = 70;
            // 
            // TargetBE
            // 
            this.TargetBE.DataPropertyName = "TargetBE";
            dataGridViewCellStyle8.Format = "N0";
            this.TargetBE.DefaultCellStyle = dataGridViewCellStyle8;
            this.TargetBE.HeaderText = "Target BE";
            this.TargetBE.Name = "TargetBE";
            this.TargetBE.ReadOnly = true;
            // 
            // TargetFA
            // 
            this.TargetFA.DataPropertyName = "TargetFA";
            dataGridViewCellStyle9.Format = "N0";
            this.TargetFA.DefaultCellStyle = dataGridViewCellStyle9;
            this.TargetFA.HeaderText = "Target FA";
            this.TargetFA.Name = "TargetFA";
            this.TargetFA.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Jumlah";
            // 
            // txtTrgBE
            // 
            this.txtTrgBE.Location = new System.Drawing.Point(546, 481);
            this.txtTrgBE.Name = "txtTrgBE";
            this.txtTrgBE.ReadOnly = true;
            this.txtTrgBE.Size = new System.Drawing.Size(97, 20);
            this.txtTrgBE.TabIndex = 17;
            this.txtTrgBE.TabStop = false;
            this.txtTrgBE.Text = "0";
            this.txtTrgBE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTrgFA
            // 
            this.txtTrgFA.Location = new System.Drawing.Point(646, 481);
            this.txtTrgFA.Name = "txtTrgFA";
            this.txtTrgFA.ReadOnly = true;
            this.txtTrgFA.Size = new System.Drawing.Size(97, 20);
            this.txtTrgFA.TabIndex = 18;
            this.txtTrgFA.TabStop = false;
            this.txtTrgFA.Text = "0";
            this.txtTrgFA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmTargetSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 562);
            this.Controls.Add(this.txtTrgFA);
            this.Controls.Add(this.txtTrgBE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvTargetToko);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdBtnEDIT);
            this.Controls.Add(this.cmdBtnADD);
            this.Controls.Add(this.cgvTargetSls);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTargetSales";
            this.RightToLeftLayout = true;
            this.Text = "History Target Sales";
            this.Title = "History Target Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmTargetSales_Load);
            this.Controls.SetChildIndex(this.cgvTargetSls, 0);
            this.Controls.SetChildIndex(this.cmdBtnADD, 0);
            this.Controls.SetChildIndex(this.cmdBtnEDIT, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            this.Controls.SetChildIndex(this.gvTargetToko, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTrgBE, 0);
            this.Controls.SetChildIndex(this.txtTrgFA, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cgvTargetSls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTargetToko)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView cgvTargetSls;
        private ISA.Trading.Controls.CommandButton cmdBtnADD;
        private ISA.Trading.Controls.CommandButton cmdBtnEDIT;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdDownload;
        private ISA.Trading.Controls.CustomGridView gvTargetToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idwil;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetBE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn skur2;
        private System.Windows.Forms.DataGridViewTextBoxColumn skur4;
        private System.Windows.Forms.DataGridViewTextBoxColumn skulain;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfe4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfb2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfb4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomflain;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokoOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokoKunj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colrowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.NumericTextBox txtTrgBE;
        private ISA.Trading.Controls.NumericTextBox txtTrgFA;

    }
}