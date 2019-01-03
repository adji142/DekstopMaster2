namespace ISA.Toko.Master
{
    partial class frmJasaBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJasaBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView2 = new ISA.Toko.Controls.CustomGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.cmdEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.DRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DJasaRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHargaJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKeterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DLastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DLastUpdatedon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Kode,
            this.Nama,
            this.Status,
            this.Catatan,
            this.CreatedBy,
            this.CreatedOn,
            this.LastUpdatedBy,
            this.LastUpdatedOn});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(781, 124);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionRowChanged += new System.EventHandler(this.dataGridView1_SelectionRowChanged);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.FillWeight = 50F;
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 65;
            // 
            // Kode
            // 
            this.Kode.DataPropertyName = "Kode";
            this.Kode.FillWeight = 101.5228F;
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.Width = 60;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.FillWeight = 99.49239F;
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 62;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.FillWeight = 99.49239F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 67;
            // 
            // Catatan
            // 
            this.Catatan.DataPropertyName = "Catatan";
            this.Catatan.FillWeight = 99.49239F;
            this.Catatan.HeaderText = "Catatan";
            this.Catatan.Name = "Catatan";
            this.Catatan.ReadOnly = true;
            this.Catatan.Width = 73;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            this.CreatedBy.Width = 89;
            // 
            // CreatedOn
            // 
            this.CreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle1.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.CreatedOn.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreatedOn.HeaderText = "CreatedOn";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            this.CreatedOn.Width = 91;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Width = 114;
            // 
            // LastUpdatedOn
            // 
            this.LastUpdatedOn.DataPropertyName = "LastUpdatedon";
            dataGridViewCellStyle2.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.LastUpdatedOn.DefaultCellStyle = dataGridViewCellStyle2;
            this.LastUpdatedOn.HeaderText = "LastUpdatedTime";
            this.LastUpdatedOn.Name = "LastUpdatedOn";
            this.LastUpdatedOn.ReadOnly = true;
            this.LastUpdatedOn.Width = 129;
            // 
            // DataGridView2
            // 
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DRowID,
            this.DJasaRowID,
            this.DTanggal,
            this.DHargaJual,
            this.DKeterangan,
            this.DCreatedBy,
            this.DCreatedOn,
            this.DLastUpdatedBy,
            this.DLastUpdatedon});
            this.DataGridView2.Location = new System.Drawing.Point(3, 133);
            this.DataGridView2.MultiSelect = false;
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            this.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView2.Size = new System.Drawing.Size(781, 125);
            this.DataGridView2.StandardTab = true;
            this.DataGridView2.TabIndex = 1;
            this.DataGridView2.Click += new System.EventHandler(this.DataGridView2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DataGridView2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(787, 261);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(724, 336);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(262, 337);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(139, 337);
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
            this.cmdAdd.Location = new System.Drawing.Point(14, 337);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // DRowID
            // 
            this.DRowID.DataPropertyName = "RowID";
            this.DRowID.FillWeight = 50F;
            this.DRowID.HeaderText = "RowID";
            this.DRowID.Name = "DRowID";
            this.DRowID.ReadOnly = true;
            this.DRowID.Visible = false;
            this.DRowID.Width = 66;
            // 
            // DJasaRowID
            // 
            this.DJasaRowID.DataPropertyName = "JasaRowID";
            this.DJasaRowID.HeaderText = "JasaRowID";
            this.DJasaRowID.Name = "DJasaRowID";
            this.DJasaRowID.ReadOnly = true;
            this.DJasaRowID.Visible = false;
            this.DJasaRowID.Width = 91;
            // 
            // DTanggal
            // 
            this.DTanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.DTanggal.DefaultCellStyle = dataGridViewCellStyle3;
            this.DTanggal.HeaderText = "Tanggal";
            this.DTanggal.Name = "DTanggal";
            this.DTanggal.ReadOnly = true;
            this.DTanggal.Width = 74;
            // 
            // DHargaJual
            // 
            this.DHargaJual.DataPropertyName = "HargaJual";
            dataGridViewCellStyle4.Format = "N0";
            this.DHargaJual.DefaultCellStyle = dataGridViewCellStyle4;
            this.DHargaJual.HeaderText = "Harga Jual";
            this.DHargaJual.Name = "DHargaJual";
            this.DHargaJual.ReadOnly = true;
            this.DHargaJual.Width = 88;
            // 
            // DKeterangan
            // 
            this.DKeterangan.DataPropertyName = "Keterangan";
            this.DKeterangan.HeaderText = "Keterangan";
            this.DKeterangan.Name = "DKeterangan";
            this.DKeterangan.ReadOnly = true;
            this.DKeterangan.Width = 95;
            // 
            // DCreatedBy
            // 
            this.DCreatedBy.DataPropertyName = "CreatedBy";
            this.DCreatedBy.HeaderText = "CreatedBy";
            this.DCreatedBy.Name = "DCreatedBy";
            this.DCreatedBy.ReadOnly = true;
            this.DCreatedBy.Width = 89;
            // 
            // DCreatedOn
            // 
            this.DCreatedOn.DataPropertyName = "CreatedTime";
            dataGridViewCellStyle5.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.DCreatedOn.DefaultCellStyle = dataGridViewCellStyle5;
            this.DCreatedOn.HeaderText = "CreatedOn";
            this.DCreatedOn.Name = "DCreatedOn";
            this.DCreatedOn.ReadOnly = true;
            this.DCreatedOn.Width = 91;
            // 
            // DLastUpdatedBy
            // 
            this.DLastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.DLastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.DLastUpdatedBy.Name = "DLastUpdatedBy";
            this.DLastUpdatedBy.ReadOnly = true;
            this.DLastUpdatedBy.Width = 114;
            // 
            // DLastUpdatedon
            // 
            this.DLastUpdatedon.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle6.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.DLastUpdatedon.DefaultCellStyle = dataGridViewCellStyle6;
            this.DLastUpdatedon.HeaderText = "LastUpdatedTime";
            this.DLastUpdatedon.Name = "DLastUpdatedon";
            this.DLastUpdatedon.ReadOnly = true;
            this.DLastUpdatedon.Width = 129;
            // 
            // frmJasaBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(837, 393);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormID = "SC0218";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJasaBrowse";
            this.Text = "SC0218 - Jasa";
            this.Title = "Jasa";
            this.Load += new System.EventHandler(this.frmJasaBrowse_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdAdd;
        private ISA.Toko.Controls.CommandButton cmdEdit;
        private ISA.Toko.Controls.CommandButton cmdDelete;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedOn;
        private ISA.Toko.Controls.CustomGridView DataGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DJasaRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHargaJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DKeterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DLastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DLastUpdatedon;
    }
}
