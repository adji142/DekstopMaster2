namespace ISA.Trading.Fixrute
{
    partial class frmMonitoringFixrute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitoringFixrute));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rp_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.cbSave = new ISA.Trading.Controls.CommandButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 132);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(987, 278);
            this.tableLayoutPanel1.TabIndex = 5;
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
            this.Tanggal,
            this.KodeSales,
            this.NamaToko,
            this.Alamat,
            this.Kota,
            this.Rp_Order,
            this.SKU,
            this.Keterangan,
            this.Catatan});
            this.customGridView1.Location = new System.Drawing.Point(3, 3);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(981, 272);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 0;
            this.customGridView1.SelectionRowChanged += new System.EventHandler(this.customGridView1_SelectionRowChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.Visible = false;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "tmt1";
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "kd_sales";
            this.KodeSales.HeaderText = "Kode Sales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "namatoko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // Rp_Order
            // 
            this.Rp_Order.DataPropertyName = "rp_order";
            this.Rp_Order.HeaderText = "Rp. Order";
            this.Rp_Order.Name = "Rp_Order";
            // 
            // SKU
            // 
            this.SKU.DataPropertyName = "sku";
            this.SKU.HeaderText = "SKU";
            this.SKU.Name = "SKU";
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Items.AddRange(new object[] {
            "Toko tutup",
            "Pemilik tidak ditempat",
            "Barang masih banyak",
            "Masih ada tagihan",
            "Order",
            "Toko sepi",
            "Toko belum mo order"});
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Keterangan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "catatan";
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(913, 455);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 87;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cbSave
            // 
            this.cbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cbSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cbSave.Image = ((System.Drawing.Image)(resources.GetObject("cbSave.Image")));
            this.cbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSave.Location = new System.Drawing.Point(26, 455);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(100, 40);
            this.cbSave.TabIndex = 86;
            this.cbSave.Text = "SAVE";
            this.cbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSave.UseVisualStyleBackColor = true;
            this.cbSave.Click += new System.EventHandler(this.cbSave_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 88;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(262, 79);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 89;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(485, 79);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 90;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 91;
            this.label1.Text = "[Alamat]";
            // 
            // frmMonitoringFixrute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 507);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMonitoringFixrute";
            this.Text = "Monitoring Fixrute";
            this.Title = "Monitoring Fixrute";
            this.Load += new System.EventHandler(this.frmMonitoringFixrute_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cbSave, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.dateTimePicker2, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Trading.Controls.CustomGridView customGridView1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton cbSave;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rp_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewComboBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
    }
}