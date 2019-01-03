namespace ISA.Trading.Controls
{
    partial class frmGudangLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGudangLookup));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Trading.Controls.CommonTextBox();
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.GudangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitPerusahaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nama Gudang";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(112, 66);
            this.txtNama.MaxLength = 73;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(256, 20);
            this.txtNama.TabIndex = 16;
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GudangID,
            this.KodeCabang,
            this.NamaGudang,
            this.InitPerusahaan,
            this.Alamat,
            this.Telp,
            this.Fax,
            this.Modem});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 95);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(717, 230);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(376, 64);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 17;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(580, 332);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 19;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // GudangID
            // 
            this.GudangID.DataPropertyName = "GudangID";
            this.GudangID.HeaderText = "ID";
            this.GudangID.Name = "GudangID";
            this.GudangID.ReadOnly = true;
            this.GudangID.Width = 50;
            // 
            // KodeCabang
            // 
            this.KodeCabang.DataPropertyName = "KodeCabang";
            this.KodeCabang.HeaderText = "Cabang";
            this.KodeCabang.Name = "KodeCabang";
            this.KodeCabang.ReadOnly = true;
            this.KodeCabang.Width = 50;
            // 
            // NamaGudang
            // 
            this.NamaGudang.DataPropertyName = "NamaGudang";
            this.NamaGudang.HeaderText = "Nama Gudang";
            this.NamaGudang.Name = "NamaGudang";
            this.NamaGudang.ReadOnly = true;
            this.NamaGudang.Width = 250;
            // 
            // InitPerusahaan
            // 
            this.InitPerusahaan.DataPropertyName = "InitPerusahaan";
            this.InitPerusahaan.HeaderText = "InitPerusahaan";
            this.InitPerusahaan.Name = "InitPerusahaan";
            this.InitPerusahaan.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // Telp
            // 
            this.Telp.DataPropertyName = "Telp";
            this.Telp.HeaderText = "Telp";
            this.Telp.Name = "Telp";
            this.Telp.ReadOnly = true;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            // 
            // Modem
            // 
            this.Modem.DataPropertyName = "Modem";
            this.Modem.HeaderText = "Modem";
            this.Modem.Name = "Modem";
            this.Modem.ReadOnly = true;
            // 
            // frmGudangLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(710, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGudangLookup";
            this.Text = "Gudang";
            this.Title = "Gudang";
            this.Load += new System.EventHandler(this.frmGudangLookUp_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommonTextBox txtNama;
        private CommandButton cmdSearch;
        private CommandButton cmdClose;
        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GudangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitPerusahaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modem;
    }
}
