namespace ISA.Toko.Master
{
    partial class frmExpedisiBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedisiBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.cmdDELETE = new ISA.Toko.Controls.CommandButton();
            this.cmdEDIT = new ISA.Toko.Controls.CommandButton();
            this.cmdADD = new ISA.Toko.Controls.CommandButton();
            this.txtSearch = new ISA.Toko.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NamaExpedisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeExpedisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KotaTujuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.NamaExpedisi,
            this.KodeExpedisi,
            this.Alamat,
            this.Telp,
            this.KotaTujuan,
            this.SyncFlag,
            this.StatusAktif,
            this.CreatedBy,
            this.CreatedON,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridView1.Location = new System.Drawing.Point(14, 95);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(770, 288);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(28, 19);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 5;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(138, 389);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 4;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(14, 389);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 3;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(127, 67);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(181, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nama Expedisi";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(316, 65);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(684, 389);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdDELETE);
            this.groupBox1.Location = new System.Drawing.Point(493, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 47);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saya Tidak Kelihatan";
            this.groupBox1.Visible = false;
            // 
            // NamaExpedisi
            // 
            this.NamaExpedisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NamaExpedisi.DataPropertyName = "NamaExpedisi";
            this.NamaExpedisi.Frozen = true;
            this.NamaExpedisi.HeaderText = "Nama Expedisi";
            this.NamaExpedisi.Name = "NamaExpedisi";
            this.NamaExpedisi.ReadOnly = true;
            this.NamaExpedisi.Width = 250;
            // 
            // KodeExpedisi
            // 
            this.KodeExpedisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.KodeExpedisi.DataPropertyName = "KodeExpedisi";
            this.KodeExpedisi.Frozen = true;
            this.KodeExpedisi.HeaderText = "Kode Expedisi";
            this.KodeExpedisi.Name = "KodeExpedisi";
            this.KodeExpedisi.ReadOnly = true;
            this.KodeExpedisi.Width = 130;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Width = 500;
            // 
            // Telp
            // 
            this.Telp.DataPropertyName = "Telp";
            this.Telp.HeaderText = "Telp";
            this.Telp.Name = "Telp";
            this.Telp.ReadOnly = true;
            this.Telp.Width = 145;
            // 
            // KotaTujuan
            // 
            this.KotaTujuan.DataPropertyName = "KotaTujuan";
            this.KotaTujuan.HeaderText = "Kota Tujuan";
            this.KotaTujuan.Name = "KotaTujuan";
            this.KotaTujuan.ReadOnly = true;
            this.KotaTujuan.Width = 146;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "Sync Flag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // StatusAktif
            // 
            this.StatusAktif.DataPropertyName = "StatusAktifWord";
            this.StatusAktif.HeaderText = "Status Aktif";
            this.StatusAktif.Name = "StatusAktif";
            this.StatusAktif.ReadOnly = true;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // CreatedON
            // 
            this.CreatedON.DataPropertyName = "CreatedON";
            dataGridViewCellStyle1.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.CreatedON.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreatedON.HeaderText = "ColumnOn";
            this.CreatedON.Name = "CreatedON";
            this.CreatedON.ReadOnly = true;
            this.CreatedON.Width = 150;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            dataGridViewCellStyle2.Format = "(dd/MM/yyyy hh:mm:ss)";
            this.LastUpdatedTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Width = 150;
            // 
            // frmExpedisiBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(799, 445);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dataGridView1);
            this.FormID = "SC0212";
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmExpedisiBrowse";
            this.Text = "SC0212 - Expedisi";
            this.Title = "Expedisi";
            this.Load += new System.EventHandler(this.frmExpedisiBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private ISA.Toko.Controls.CommandButton cmdDELETE;
        private ISA.Toko.Controls.CommandButton cmdEDIT;
        private ISA.Toko.Controls.CommandButton cmdADD;
        private ISA.Toko.Controls.CommonTextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaExpedisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeExpedisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telp;
        private System.Windows.Forms.DataGridViewTextBoxColumn KotaTujuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedON;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}
