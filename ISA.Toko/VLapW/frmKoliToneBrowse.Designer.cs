namespace ISA.Toko.VLapW
{
    partial class frmKoliToneBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKoliToneBrowse));
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.NamaStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Koli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeBrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.cmdEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.NamaStok,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Pcs,
            this.Koli,
            this.Jenis,
            this.KodeBrg,
            this.RowID});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(717, 193);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // NamaStok
            // 
            this.NamaStok.DataPropertyName = "NamaStok";
            this.NamaStok.HeaderText = "Nama Stok";
            this.NamaStok.Name = "NamaStok";
            this.NamaStok.ReadOnly = true;
            this.NamaStok.Width = 400;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "BrgID";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BarangID";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RecID";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Pcs
            // 
            this.Pcs.DataPropertyName = "Pcs";
            this.Pcs.HeaderText = "Pcs";
            this.Pcs.Name = "Pcs";
            this.Pcs.ReadOnly = true;
            // 
            // Koli
            // 
            this.Koli.DataPropertyName = "Koli";
            this.Koli.HeaderText = "Koli";
            this.Koli.Name = "Koli";
            this.Koli.ReadOnly = true;
            // 
            // Jenis
            // 
            this.Jenis.DataPropertyName = "Jenis";
            this.Jenis.HeaderText = "Jenis";
            this.Jenis.Name = "Jenis";
            this.Jenis.ReadOnly = true;
            // 
            // KodeBrg
            // 
            this.KodeBrg.DataPropertyName = "KodeBarang";
            this.KodeBrg.HeaderText = "Kode Barang";
            this.KodeBrg.Name = "KodeBrg";
            this.KodeBrg.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(608, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 289);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(138, 289);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(264, 289);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmKoliToneBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(720, 341);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKoliToneBrowse";
            this.Text = "KoliTone";
            this.Title = "KoliTone";
            this.Load += new System.EventHandler(this.frmKoliToneBrowse_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdAdd;
        private ISA.Toko.Controls.CommandButton cmdEdit;
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Koli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenis;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
