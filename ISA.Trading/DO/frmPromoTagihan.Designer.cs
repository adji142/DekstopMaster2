namespace ISA.Trading.DO
{
    partial class frmPromoTagihan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromoTagihan));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.datagridviewBarangPromo = new ISA.Trading.Controls.CustomGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.cbSave = new ISA.Trading.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKasir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h_jual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDbarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewBarangPromo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.datagridviewBarangPromo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.91228F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.08772F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 159);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // datagridviewBarangPromo
            // 
            this.datagridviewBarangPromo.AllowUserToAddRows = false;
            this.datagridviewBarangPromo.AllowUserToDeleteRows = false;
            this.datagridviewBarangPromo.AllowUserToResizeRows = false;
            this.datagridviewBarangPromo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridviewBarangPromo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridviewBarangPromo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridviewBarangPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewBarangPromo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.TglKasir,
            this.h_jual,
            this.sat,
            this.IDbarang,
            this.BarangP,
            this.QtyBonus,
            this.pilih});
            this.datagridviewBarangPromo.Location = new System.Drawing.Point(3, 26);
            this.datagridviewBarangPromo.MultiSelect = false;
            this.datagridviewBarangPromo.Name = "datagridviewBarangPromo";
            this.datagridviewBarangPromo.RowHeadersVisible = false;
            this.datagridviewBarangPromo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagridviewBarangPromo.Size = new System.Drawing.Size(646, 130);
            this.datagridviewBarangPromo.StandardTab = true;
            this.datagridviewBarangPromo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Promo Tagihan";
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(532, 268);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 31;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cbSave
            // 
            this.cbSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cbSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cbSave.Image = ((System.Drawing.Image)(resources.GetObject("cbSave.Image")));
            this.cbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSave.Location = new System.Drawing.Point(403, 268);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(100, 40);
            this.cbSave.TabIndex = 30;
            this.cbSave.Text = "SAVE";
            this.cbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSave.UseVisualStyleBackColor = true;
            this.cbSave.Click += new System.EventHandler(this.cbSave_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "PromoDetailRowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.Visible = false;
            // 
            // TglKasir
            // 
            this.TglKasir.DataPropertyName = "tglKasir";
            this.TglKasir.HeaderText = "Tanggal Transaksi";
            this.TglKasir.Name = "TglKasir";
            this.TglKasir.ReadOnly = true;
            // 
            // h_jual
            // 
            this.h_jual.DataPropertyName = "h_jual";
            this.h_jual.HeaderText = "Harga Jual";
            this.h_jual.Name = "h_jual";
            this.h_jual.ReadOnly = true;
            this.h_jual.Visible = false;
            // 
            // sat
            // 
            this.sat.DataPropertyName = "satuan";
            this.sat.HeaderText = "satuan";
            this.sat.Name = "sat";
            this.sat.ReadOnly = true;
            this.sat.Visible = false;
            // 
            // IDbarang
            // 
            this.IDbarang.DataPropertyName = "id_brg";
            this.IDbarang.HeaderText = "BarangID";
            this.IDbarang.Name = "IDbarang";
            this.IDbarang.ReadOnly = true;
            this.IDbarang.Visible = false;
            // 
            // BarangP
            // 
            this.BarangP.DataPropertyName = "nama_stok";
            this.BarangP.HeaderText = "Nama Stok Promo";
            this.BarangP.Name = "BarangP";
            this.BarangP.ReadOnly = true;
            // 
            // QtyBonus
            // 
            this.QtyBonus.DataPropertyName = "qtybonus";
            this.QtyBonus.HeaderText = "Qty Bonus";
            this.QtyBonus.Name = "QtyBonus";
            // 
            // pilih
            // 
            this.pilih.HeaderText = "Pilih";
            this.pilih.Name = "pilih";
            this.pilih.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmPromoTagihan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 332);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPromoTagihan";
            this.Text = "Promo Tagihan";
            this.Title = "Promo Tagihan";
            this.Load += new System.EventHandler(this.frmPromoTagihan_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cbSave, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewBarangPromo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Trading.Controls.CustomGridView datagridviewBarangPromo;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton cbSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKasir;
        private System.Windows.Forms.DataGridViewTextBoxColumn h_jual;
        private System.Windows.Forms.DataGridViewTextBoxColumn sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDbarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangP;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyBonus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pilih;
    }
}