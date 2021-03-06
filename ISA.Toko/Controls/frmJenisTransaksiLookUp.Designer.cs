namespace ISA.Toko.Controls
{
    partial class frmJenisTransaksiLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJenisTransaksiLookUp));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Toko.Controls.CommonTextBox();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.KodeTr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaTr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KelompokTr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JwTr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JsTr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kode Transaksi";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(122, 66);
            this.txtNama.MaxLength = 31;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(321, 20);
            this.txtNama.TabIndex = 6;
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodeTr,
            this.NamaTr,
            this.KelompokTr,
            this.JwTr,
            this.JsTr});
            this.dataGridView1.Location = new System.Drawing.Point(-3, 94);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(736, 185);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(449, 64);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 7;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(605, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // KodeTr
            // 
            this.KodeTr.DataPropertyName = "id_tr";
            this.KodeTr.HeaderText = "Kode";
            this.KodeTr.Name = "KodeTr";
            this.KodeTr.ReadOnly = true;
            this.KodeTr.Width = 60;
            // 
            // NamaTr
            // 
            this.NamaTr.DataPropertyName = "keterangan";
            this.NamaTr.HeaderText = "Keterangan";
            this.NamaTr.Name = "NamaTr";
            this.NamaTr.ReadOnly = true;
            this.NamaTr.Width = 200;
            // 
            // KelompokTr
            // 
            this.KelompokTr.DataPropertyName = "kelompok";
            this.KelompokTr.HeaderText = "Kelompok";
            this.KelompokTr.Name = "KelompokTr";
            this.KelompokTr.ReadOnly = true;
            // 
            // JwTr
            // 
            this.JwTr.DataPropertyName = "jw";
            this.JwTr.HeaderText = "JW";
            this.JwTr.Name = "JwTr";
            this.JwTr.ReadOnly = true;
            // 
            // JsTr
            // 
            this.JsTr.DataPropertyName = "js";
            this.JsTr.HeaderText = "JS";
            this.JsTr.Name = "JsTr";
            this.JsTr.ReadOnly = true;
            // 
            // frmJenisTransaksiLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(736, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.cmdSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJenisTransaksiLookUp";
            this.Text = "Jenis Transaksi";
            this.Title = "Jenis Transaksi";
            this.Load += new System.EventHandler(this.frmJenisTransaksiLookUp_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox txtNama;
        private CommandButton cmdSearch;
        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeTr;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaTr;
        private System.Windows.Forms.DataGridViewTextBoxColumn KelompokTr;
        private System.Windows.Forms.DataGridViewTextBoxColumn JwTr;
        private System.Windows.Forms.DataGridViewTextBoxColumn JsTr;
    }
}
