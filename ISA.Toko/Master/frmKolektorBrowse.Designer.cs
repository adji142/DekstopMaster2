namespace ISA.Toko.Master
{
    partial class frmKolektorBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKolektorBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.cmdEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatasOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarangE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Kode,
            this.Nama,
            this.TglLahir,
            this.Alamat,
            this.Target,
            this.BatasOD,
            this.TglMasuk,
            this.TglKeluar,
            this.BarangA,
            this.BarangB,
            this.BarangC,
            this.BarangE,
            this.LastUpdatedBy,
            this.LastUpdatedTime,
            this.CollectorID});
            this.dataGridView1.Location = new System.Drawing.Point(9, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(900, 223);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(257, 316);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(134, 316);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(10, 316);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(809, 316);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Kode
            // 
            this.Kode.DataPropertyName = "Kode";
            this.Kode.Frozen = true;
            this.Kode.HeaderText = "Kode";
            this.Kode.MaxInputLength = 11;
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.Frozen = true;
            this.Nama.HeaderText = "Nama";
            this.Nama.MaxInputLength = 23;
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 200;
            // 
            // TglLahir
            // 
            this.TglLahir.DataPropertyName = "TglLahir";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglLahir.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglLahir.Frozen = true;
            this.TglLahir.HeaderText = "Tgl Lahir";
            this.TglLahir.MaxInputLength = 10;
            this.TglLahir.Name = "TglLahir";
            this.TglLahir.ReadOnly = true;
            this.TglLahir.Width = 110;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.Frozen = true;
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.MaxInputLength = 30;
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Width = 250;
            // 
            // Target
            // 
            this.Target.DataPropertyName = "Target";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.Target.DefaultCellStyle = dataGridViewCellStyle2;
            this.Target.Frozen = true;
            this.Target.HeaderText = "Target";
            this.Target.MaxInputLength = 14;
            this.Target.Name = "Target";
            this.Target.ReadOnly = true;
            // 
            // BatasOD
            // 
            this.BatasOD.DataPropertyName = "BatasOD";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.BatasOD.DefaultCellStyle = dataGridViewCellStyle3;
            this.BatasOD.Frozen = true;
            this.BatasOD.HeaderText = "BatasOD";
            this.BatasOD.MaxInputLength = 14;
            this.BatasOD.Name = "BatasOD";
            this.BatasOD.ReadOnly = true;
            // 
            // TglMasuk
            // 
            this.TglMasuk.DataPropertyName = "TglMasuk";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.TglMasuk.DefaultCellStyle = dataGridViewCellStyle4;
            this.TglMasuk.Frozen = true;
            this.TglMasuk.HeaderText = "Tgl Masuk";
            this.TglMasuk.MaxInputLength = 10;
            this.TglMasuk.Name = "TglMasuk";
            this.TglMasuk.ReadOnly = true;
            this.TglMasuk.Width = 110;
            // 
            // TglKeluar
            // 
            this.TglKeluar.DataPropertyName = "TglKeluar";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.TglKeluar.DefaultCellStyle = dataGridViewCellStyle5;
            this.TglKeluar.Frozen = true;
            this.TglKeluar.HeaderText = "Tgl Keluar";
            this.TglKeluar.MaxInputLength = 10;
            this.TglKeluar.Name = "TglKeluar";
            this.TglKeluar.ReadOnly = true;
            this.TglKeluar.Width = 110;
            // 
            // BarangA
            // 
            this.BarangA.DataPropertyName = "BarangA";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            this.BarangA.DefaultCellStyle = dataGridViewCellStyle6;
            this.BarangA.Frozen = true;
            this.BarangA.HeaderText = "Barang A";
            this.BarangA.MaxInputLength = 10;
            this.BarangA.Name = "BarangA";
            this.BarangA.ReadOnly = true;
            // 
            // BarangB
            // 
            this.BarangB.DataPropertyName = "BarangB";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0";
            this.BarangB.DefaultCellStyle = dataGridViewCellStyle7;
            this.BarangB.Frozen = true;
            this.BarangB.HeaderText = "Barang B";
            this.BarangB.MaxInputLength = 10;
            this.BarangB.Name = "BarangB";
            this.BarangB.ReadOnly = true;
            // 
            // BarangC
            // 
            this.BarangC.DataPropertyName = "BarangC";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "#,##0";
            this.BarangC.DefaultCellStyle = dataGridViewCellStyle8;
            this.BarangC.Frozen = true;
            this.BarangC.HeaderText = "Barang C";
            this.BarangC.MaxInputLength = 10;
            this.BarangC.Name = "BarangC";
            this.BarangC.ReadOnly = true;
            // 
            // BarangE
            // 
            this.BarangE.DataPropertyName = "BarangE";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "#,##0";
            this.BarangE.DefaultCellStyle = dataGridViewCellStyle9;
            this.BarangE.Frozen = true;
            this.BarangE.HeaderText = "Barang E";
            this.BarangE.MaxInputLength = 10;
            this.BarangE.Name = "BarangE";
            this.BarangE.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.Frozen = true;
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle10.Format = "(dd/MM/yyyy)";
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle10;
            this.LastUpdatedTime.Frozen = true;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // CollectorID
            // 
            this.CollectorID.DataPropertyName = "CollectorID";
            this.CollectorID.Frozen = true;
            this.CollectorID.HeaderText = "Collector ID";
            this.CollectorID.MaxInputLength = 23;
            this.CollectorID.Name = "CollectorID";
            this.CollectorID.ReadOnly = true;
            this.CollectorID.Visible = false;
            this.CollectorID.Width = 150;
            // 
            // frmKolektorBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(917, 372);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.dataGridView1);
            this.FormID = "SC0231";
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = true;
            this.Name = "frmKolektorBrowse";
            this.Text = "SC0231 - Collector";
            this.Title = "Collector";
            this.Load += new System.EventHandler(this.frmKolektorBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private ISA.Toko.Controls.CommandButton cmdAdd;
        private ISA.Toko.Controls.CommandButton cmdEdit;
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatasOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangA;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangB;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangC;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarangE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectorID;
    }
}
