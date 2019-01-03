namespace ISA.Toko.AKC
{
    partial class frmMasterCollector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterCollector));
            this.btnAdd = new ISA.Controls.CommandButton();
            this.btnEdit = new ISA.Controls.CommandButton();
            this.btnDelete = new ISA.Controls.CommandButton();
            this.btnClose = new ISA.Controls.CommandButton();
            this.DGVCollection = new ISA.Toko.Controls.CustomGridView();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(58, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(183, 272);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(320, 272);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(719, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DGVCollection
            // 
            this.DGVCollection.AllowUserToAddRows = false;
            this.DGVCollection.AllowUserToDeleteRows = false;
            this.DGVCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCollection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kode,
            this.Nama,
            this.TglLahir,
            this.Alamat,
            this.CollectorID});
            this.DGVCollection.Location = new System.Drawing.Point(49, 38);
            this.DGVCollection.MultiSelect = false;
            this.DGVCollection.Name = "DGVCollection";
            this.DGVCollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGVCollection.Size = new System.Drawing.Size(770, 216);
            this.DGVCollection.StandardTab = true;
            this.DGVCollection.TabIndex = 10;
            // 
            // Kode
            // 
            this.Kode.DataPropertyName = "Kode";
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            // 
            // TglLahir
            // 
            this.TglLahir.DataPropertyName = "TglLahir";
            this.TglLahir.HeaderText = "Tgl Lahir";
            this.TglLahir.Name = "TglLahir";
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            // 
            // CollectorID
            // 
            this.CollectorID.DataPropertyName = "CollectorID";
            this.CollectorID.HeaderText = "CollectorID";
            this.CollectorID.Name = "CollectorID";
            this.CollectorID.Visible = false;
            // 
            // frmMasterCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(867, 341);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.DGVCollection);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMasterCollector";
            this.Load += new System.EventHandler(this.frmMasterCollection_Load);
            this.Controls.SetChildIndex(this.DGVCollection, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton btnAdd;
        private ISA.Controls.CommandButton btnEdit;
        private ISA.Controls.CommandButton btnDelete;
        private ISA.Controls.CommandButton btnClose;
        private ISA.Toko.Controls.CustomGridView DGVCollection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectorID;

    }
}
