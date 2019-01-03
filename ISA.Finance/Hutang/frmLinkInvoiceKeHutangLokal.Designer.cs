namespace ISA.Finance.Hutang
{
    partial class frmLinkInvoiceKeHutangLokal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkInvoiceKeHutangLokal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.dgListInvoiceKeHutang = new ISA.Controls.CustomGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MataUangRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalMataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDRNominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.potongan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BiayaTambahanUSDPerPL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeteranganBiayaTambahan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMultyCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMultyVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new ISA.Controls.CommandButton();
            this.btnClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgListInvoiceKeHutang)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(1050, 472);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 39;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(-141, 472);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 38;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            // 
            // dgListInvoiceKeHutang
            // 
            this.dgListInvoiceKeHutang.AllowUserToAddRows = false;
            this.dgListInvoiceKeHutang.AllowUserToDeleteRows = false;
            this.dgListInvoiceKeHutang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgListInvoiceKeHutang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgListInvoiceKeHutang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListInvoiceKeHutang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.Checked,
            this.MataUangRowID,
            this.RowID,
            this.VendorRowID,
            this.TglInvoice,
            this.TglTerima,
            this.InvoiceNo,
            this.OriginalMataUang,
            this.IDRNominal,
            this.potongan,
            this.ppn,
            this.BiayaTambahanUSDPerPL,
            this.KeteranganBiayaTambahan,
            this.IsMultyCurrency,
            this.IsMultyVendor});
            this.dgListInvoiceKeHutang.Location = new System.Drawing.Point(5, 49);
            this.dgListInvoiceKeHutang.MultiSelect = false;
            this.dgListInvoiceKeHutang.Name = "dgListInvoiceKeHutang";
            this.dgListInvoiceKeHutang.ReadOnly = true;
            this.dgListInvoiceKeHutang.RowHeadersVisible = false;
            this.dgListInvoiceKeHutang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgListInvoiceKeHutang.Size = new System.Drawing.Size(998, 374);
            this.dgListInvoiceKeHutang.StandardTab = true;
            this.dgListInvoiceKeHutang.TabIndex = 40;
            this.dgListInvoiceKeHutang.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgListInvoiceKeHutang_CellValidating);

            // 
            // chk
            // 
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Visible = false;
            this.chk.Width = 20;
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "ok";
            this.Checked.HeaderText = "Checked";
            this.Checked.Name = "Checked";
            this.Checked.ReadOnly = true;
            this.Checked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MataUangRowID
            // 
            this.MataUangRowID.DataPropertyName = "MataUangRowID";
            this.MataUangRowID.HeaderText = "MataUangRowID";
            this.MataUangRowID.Name = "MataUangRowID";
            this.MataUangRowID.ReadOnly = true;
            this.MataUangRowID.Visible = false;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // VendorRowID
            // 
            this.VendorRowID.DataPropertyName = "VendorRowID";
            this.VendorRowID.HeaderText = "VendorRowID";
            this.VendorRowID.Name = "VendorRowID";
            this.VendorRowID.ReadOnly = true;
            this.VendorRowID.Visible = false;
            // 
            // TglInvoice
            // 
            this.TglInvoice.DataPropertyName = "TglInvoice";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.TglInvoice.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglInvoice.HeaderText = "Tgl Invoice";
            this.TglInvoice.Name = "TglInvoice";
            this.TglInvoice.ReadOnly = true;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle2.Format = "dd-MM-yyyy";
            this.TglTerima.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglTerima.HeaderText = "Tgl Terima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "InvoiceNo";
            this.InvoiceNo.HeaderText = "No Invoice";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // OriginalMataUang
            // 
            this.OriginalMataUang.DataPropertyName = "MataUangID";
            this.OriginalMataUang.HeaderText = "MataUang";
            this.OriginalMataUang.Name = "OriginalMataUang";
            this.OriginalMataUang.ReadOnly = true;
            // 
            // IDRNominal
            // 
            this.IDRNominal.DataPropertyName = "IDRNominalNetto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.IDRNominal.DefaultCellStyle = dataGridViewCellStyle3;
            this.IDRNominal.HeaderText = "IDR Nominal";
            this.IDRNominal.Name = "IDRNominal";
            this.IDRNominal.ReadOnly = true;
            // 
            // potongan
            // 
            this.potongan.DataPropertyName = "Potongan";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.potongan.DefaultCellStyle = dataGridViewCellStyle4;
            this.potongan.HeaderText = "Diskon";
            this.potongan.Name = "potongan";
            this.potongan.ReadOnly = true;
            // 
            // ppn
            // 
            this.ppn.DataPropertyName = "ppn";
            this.ppn.HeaderText = "PPN";
            this.ppn.Name = "ppn";
            this.ppn.ReadOnly = true;
            // 
            // BiayaTambahanUSDPerPL
            // 
            this.BiayaTambahanUSDPerPL.DataPropertyName = "BiayaTambahanUSDPerPL";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.BiayaTambahanUSDPerPL.DefaultCellStyle = dataGridViewCellStyle5;
            this.BiayaTambahanUSDPerPL.HeaderText = "BiayaTambahanUSDPerPL";
            this.BiayaTambahanUSDPerPL.Name = "BiayaTambahanUSDPerPL";
            this.BiayaTambahanUSDPerPL.ReadOnly = true;
            // 
            // KeteranganBiayaTambahan
            // 
            this.KeteranganBiayaTambahan.DataPropertyName = "KeteranganBiayaTambahan";
            this.KeteranganBiayaTambahan.HeaderText = "KeteranganBiayaTambahan";
            this.KeteranganBiayaTambahan.Name = "KeteranganBiayaTambahan";
            this.KeteranganBiayaTambahan.ReadOnly = true;
            // 
            // IsMultyCurrency
            // 
            this.IsMultyCurrency.DataPropertyName = "MultyCurrency";
            this.IsMultyCurrency.HeaderText = "IsMultyCurrency";
            this.IsMultyCurrency.Name = "IsMultyCurrency";
            this.IsMultyCurrency.ReadOnly = true;
            this.IsMultyCurrency.Visible = false;
            // 
            // IsMultyVendor
            // 
            this.IsMultyVendor.DataPropertyName = "MultyVendor";
            this.IsMultyVendor.HeaderText = "IsMultyVendor";
            this.IsMultyVendor.Name = "IsMultyVendor";
            this.IsMultyVendor.ReadOnly = true;
            this.IsMultyVendor.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(5, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(903, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLinkInvoiceKeHutangLokal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1009, 473);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgListInvoiceKeHutang);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLinkInvoiceKeHutangLokal";
            this.Text = "Link Invoice ke Hutang Lokal";
            this.Title = "Link Invoice ke Hutang Lokal";
            this.Load += new System.EventHandler(this.frmLinkInvoiceKeHutangLokal_Load);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.dgListInvoiceKeHutang, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgListInvoiceKeHutang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private ISA.Controls.CustomGridView dgListInvoiceKeHutang;
        private ISA.Controls.CommandButton btnSave;
        private ISA.Controls.CommandButton btnClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalMataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDRNominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn potongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BiayaTambahanUSDPerPL;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeteranganBiayaTambahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMultyCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMultyVendor;
    }
}
