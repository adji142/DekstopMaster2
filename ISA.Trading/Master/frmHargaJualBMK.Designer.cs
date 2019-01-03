namespace ISA.Trading.Master
{
    partial class frmHargaJualBMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHargaJualBMK));
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHarga = new ISA.Controls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtTglBerlaku = new ISA.Controls.RangeDateBox();
            this.txtKeterangan = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lookupStock1 = new ISA.Trading.Controls.LookupStock();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 289);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(598, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Barang";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Harga Jual";
            // 
            // txtHarga
            // 
            this.txtHarga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHarga.Format = "N0";
            this.txtHarga.Location = new System.Drawing.Point(219, 147);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(100, 20);
            this.txtHarga.TabIndex = 10;
            this.txtHarga.Text = "0,00";
            this.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHarga.TextChanged += new System.EventHandler(this.txtHarga_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tgl Berlaku";
            // 
            // rtTglBerlaku
            // 
            this.rtTglBerlaku.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtTglBerlaku.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rtTglBerlaku.FromDate = null;
            this.rtTglBerlaku.Location = new System.Drawing.Point(218, 195);
            this.rtTglBerlaku.Name = "rtTglBerlaku";
            this.rtTglBerlaku.Size = new System.Drawing.Size(257, 22);
            this.rtTglBerlaku.TabIndex = 12;
            this.rtTglBerlaku.ToDate = null;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(225, 242);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(374, 20);
            this.txtKeterangan.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Keterangan";
            // 
            // lookupStock1
            // 
            this.lookupStock1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lookupStock1.BarangID = "[CODE]";
            this.lookupStock1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock1.IsiKoli = 0;
            this.lookupStock1.Location = new System.Drawing.Point(219, 69);
            this.lookupStock1.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock1.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock1.NamaStock = "";
            this.lookupStock1.Name = "lookupStock1";
            this.lookupStock1.RecordID = null;
            this.lookupStock1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock1.Satuan = null;
            this.lookupStock1.Size = new System.Drawing.Size(380, 54);
            this.lookupStock1.TabIndex = 7;
            // 
            // frmHargaJualBMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.rtTglBerlaku);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupStock1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHargaJualBMK";
            this.Text = "Harga Jual ";
            this.Title = "Harga Jual ";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmHargaJualBMK_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.lookupStock1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtHarga, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.rtTglBerlaku, 0);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.LookupStock lookupStock1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.NumericTextBox txtHarga;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.RangeDateBox rtTglBerlaku;
        private ISA.Controls.CommonTextBox txtKeterangan;
        private System.Windows.Forms.Label label4;
    }
}
