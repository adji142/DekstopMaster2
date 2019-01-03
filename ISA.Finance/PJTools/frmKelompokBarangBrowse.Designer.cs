namespace ISA.Finance.PJTools
{
    partial class frmKelompokBarangBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKelompokBarangBrowse));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cKelompokBrgID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKeterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKelompok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMainAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSubAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoPerk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNopRj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNopStk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cKelompokBrgID,
            this.cKeterangan,
            this.cKelompok,
            this.cMainAcc,
            this.cSubAcc,
            this.cNoPerk,
            this.cNopRj,
            this.cNopStk});
            this.customGridView1.Location = new System.Drawing.Point(6, 12);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(703, 261);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            // 
            // cKelompokBrgID
            // 
            this.cKelompokBrgID.DataPropertyName = "KelompokBrgID";
            this.cKelompokBrgID.HeaderText = "Klp";
            this.cKelompokBrgID.Name = "cKelompokBrgID";
            this.cKelompokBrgID.ReadOnly = true;
            this.cKelompokBrgID.Width = 40;
            // 
            // cKeterangan
            // 
            this.cKeterangan.DataPropertyName = "Keterangan";
            this.cKeterangan.HeaderText = "Keterangan";
            this.cKeterangan.Name = "cKeterangan";
            this.cKeterangan.ReadOnly = true;
            // 
            // cKelompok
            // 
            this.cKelompok.DataPropertyName = "Kelompok";
            this.cKelompok.HeaderText = "Kd";
            this.cKelompok.Name = "cKelompok";
            this.cKelompok.ReadOnly = true;
            this.cKelompok.Width = 40;
            // 
            // cMainAcc
            // 
            this.cMainAcc.DataPropertyName = "MainAcc";
            this.cMainAcc.HeaderText = "MainAcc";
            this.cMainAcc.Name = "cMainAcc";
            this.cMainAcc.ReadOnly = true;
            // 
            // cSubAcc
            // 
            this.cSubAcc.DataPropertyName = "SubAcc";
            this.cSubAcc.HeaderText = "SubAcc";
            this.cSubAcc.Name = "cSubAcc";
            this.cSubAcc.ReadOnly = true;
            // 
            // cNoPerk
            // 
            this.cNoPerk.DataPropertyName = "NoPerk";
            this.cNoPerk.HeaderText = "No Perk Penjualan";
            this.cNoPerk.Name = "cNoPerk";
            this.cNoPerk.ReadOnly = true;
            this.cNoPerk.Width = 150;
            // 
            // cNopRj
            // 
            this.cNopRj.DataPropertyName = "NopRj";
            this.cNopRj.HeaderText = "No Perk ReturJual";
            this.cNopRj.Name = "cNopRj";
            this.cNopRj.ReadOnly = true;
            this.cNopRj.Width = 150;
            // 
            // cNopStk
            // 
            this.cNopStk.DataPropertyName = "NopStk";
            this.cNopStk.HeaderText = "No Perk Persediaan";
            this.cNopStk.Name = "cNopStk";
            this.cNopStk.ReadOnly = true;
            this.cNopStk.Width = 150;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 289);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(609, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(136, 289);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 5;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(260, 289);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmKelompokBarangBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(712, 341);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Name = "frmKelompokBarangBrowse";
            this.Load += new System.EventHandler(this.frmKelompokBarangBrowse_Load);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKelompokBrgID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKeterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKelompok;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMainAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSubAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoPerk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNopRj;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNopStk;
    }
}
