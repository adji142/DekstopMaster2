namespace ISA.Toko.Master
{
    partial class frmBankKotaBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankKotaBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdDelete = new ISA.Toko.Controls.CommandButton();
            this.cmdEdit = new ISA.Toko.Controls.CommandButton();
            this.cmdAdd = new ISA.Toko.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lokasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.NamaBank,
            this.Lokasi,
            this.SyncFlag,
            this.StatusAktif,
            this.CreatedBy,
            this.CreatedTime,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(781, 255);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionRowChanged += new System.EventHandler(this.dataGridView1_SelectionRowChanged);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
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
            this.cmdClose.TabIndex = 3;
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
            this.cmdDelete.TabIndex = 2;
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
            this.cmdEdit.TabIndex = 1;
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
            this.cmdAdd.TabIndex = 0;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.FillWeight = 50F;
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 66;
            // 
            // NamaBank
            // 
            this.NamaBank.DataPropertyName = "NamaBank";
            this.NamaBank.HeaderText = "Nama Bank";
            this.NamaBank.Name = "NamaBank";
            this.NamaBank.ReadOnly = true;
            this.NamaBank.Width = 92;
            // 
            // Lokasi
            // 
            this.Lokasi.DataPropertyName = "Lokasi";
            this.Lokasi.HeaderText = "Lokasi";
            this.Lokasi.Name = "Lokasi";
            this.Lokasi.ReadOnly = true;
            this.Lokasi.Width = 69;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            this.SyncFlag.Width = 80;
            // 
            // StatusAktif
            // 
            this.StatusAktif.DataPropertyName = "StatusAktif";
            this.StatusAktif.HeaderText = "StatusAktif";
            this.StatusAktif.Name = "StatusAktif";
            this.StatusAktif.ReadOnly = true;
            this.StatusAktif.Width = 93;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            this.CreatedBy.Width = 89;
            // 
            // CreatedTime
            // 
            this.CreatedTime.DataPropertyName = "CreatedTime";
            dataGridViewCellStyle1.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.CreatedTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreatedTime.HeaderText = "CreatedTime";
            this.CreatedTime.Name = "CreatedTime";
            this.CreatedTime.ReadOnly = true;
            this.CreatedTime.Width = 104;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatdBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Width = 114;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle2.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Width = 129;
            // 
            // frmBankKotaBrowse
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
            this.Name = "frmBankKotaBrowse";
            this.Text = "SC0218 - Bank Kota";
            this.Title = "Bank Kota";
            this.Load += new System.EventHandler(this.frmBankKotaBrowse_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lokasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}
