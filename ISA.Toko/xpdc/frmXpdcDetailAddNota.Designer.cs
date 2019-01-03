namespace ISA.Toko.xpdc
{
    partial class frmXpdcDetailAddNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXpdcDetailAddNota));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.dgvNota = new ISA.Toko.Controls.CustomGridView();
            this.Cek = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TransacType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.txtNoNota = new ISA.Toko.Controls.CommonTextBox();
            this.rdbTgl = new ISA.Toko.Controls.RangeDateBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNota)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(395, 63);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cboSearch
            // 
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "No. Nota",
            "Tgl. Nota"});
            this.cboSearch.Location = new System.Drawing.Point(26, 65);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(121, 22);
            this.cboSearch.TabIndex = 0;
            this.cboSearch.SelectedIndexChanged += new System.EventHandler(this.cboSearch_SelectedIndexChanged);
            // 
            // dgvNota
            // 
            this.dgvNota.AllowUserToAddRows = false;
            this.dgvNota.AllowUserToDeleteRows = false;
            this.dgvNota.AllowUserToOrderColumns = true;
            this.dgvNota.AllowUserToResizeRows = false;
            this.dgvNota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cek,
            this.TransacType,
            this.Tanggal,
            this.Nomor,
            this.Nama,
            this.Alamat,
            this.Kota,
            this.Kode,
            this.RowID,
            this.Barcode});
            this.dgvNota.Location = new System.Drawing.Point(9, 93);
            this.dgvNota.MultiSelect = false;
            this.dgvNota.Name = "dgvNota";
            this.dgvNota.RowHeadersVisible = false;
            this.dgvNota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNota.Size = new System.Drawing.Size(1000, 411);
            this.dgvNota.StandardTab = true;
            this.dgvNota.TabIndex = 6;
            // 
            // Cek
            // 
            this.Cek.HeaderText = "Cek";
            this.Cek.Name = "Cek";
            this.Cek.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cek.Width = 50;
            // 
            // TransacType
            // 
            this.TransacType.DataPropertyName = "TransactionType";
            this.TransacType.HeaderText = "TR";
            this.TransacType.Name = "TransacType";
            this.TransacType.Width = 60;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            // 
            // Nomor
            // 
            this.Nomor.DataPropertyName = "Nomor";
            this.Nomor.HeaderText = "Nomor";
            this.Nomor.Name = "Nomor";
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Tujuan";
            this.Nama.Name = "Nama";
            this.Nama.Width = 200;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat Tujuan";
            this.Alamat.Name = "Alamat";
            this.Alamat.Width = 300;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.Width = 150;
            // 
            // Kode
            // 
            this.Kode.DataPropertyName = "Kode";
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.Width = 150;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.Visible = false;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.Visible = false;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(803, 520);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 4;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(909, 520);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtNoNota
            // 
            this.txtNoNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoNota.Location = new System.Drawing.Point(153, 66);
            this.txtNoNota.Name = "txtNoNota";
            this.txtNoNota.Size = new System.Drawing.Size(236, 20);
            this.txtNoNota.TabIndex = 2;
            this.txtNoNota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoNota_KeyDown);
            // 
            // rdbTgl
            // 
            this.rdbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl.FromDate = null;
            this.rdbTgl.Location = new System.Drawing.Point(153, 65);
            this.rdbTgl.Name = "rdbTgl";
            this.rdbTgl.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl.TabIndex = 1;
            this.rdbTgl.ToDate = null;
            this.rdbTgl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbTgl_KeyDown);
            // 
            // frmXpdcDetailAddNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1018, 572);
            this.Controls.Add(this.dgvNota);
            this.Controls.Add(this.cboSearch);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNoNota);
            this.Controls.Add(this.rdbTgl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "frmXpdcDetailAddNota";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Pilih Nota";
            this.Title = "Pilih Nota";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmXpdcDetailAddNota_Load);
            this.Controls.SetChildIndex(this.rdbTgl, 0);
            this.Controls.SetChildIndex(this.txtNoNota, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cboSearch, 0);
            this.Controls.SetChildIndex(this.dgvNota, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.RangeDateBox rdbTgl;
        private ISA.Toko.Controls.CommonTextBox txtNoNota;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ComboBox cboSearch;
        private ISA.Toko.Controls.CustomGridView dgvNota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cek;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransacType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
    }
}
