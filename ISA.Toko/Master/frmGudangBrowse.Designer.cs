namespace ISA.Toko.Master
{
    partial class frmGudangBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGudangBrowse));
            this.dataGridView1 = new ISA.Toko.Controls.CustomGridView();
            this.GudangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDELETE = new ISA.Toko.Controls.CommandButton();
            this.cmdEDIT = new ISA.Toko.Controls.CommandButton();
            this.cmdADD = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GudangID,
            this.KodeCabang,
            this.NamaGudang,
            this.Alamat,
            this.Telp,
            this.Fax,
            this.Modem,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.dataGridView1.Location = new System.Drawing.Point(9, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(733, 281);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // GudangID
            // 
            this.GudangID.DataPropertyName = "GudangID";
            this.GudangID.FillWeight = 13.82224F;
            this.GudangID.HeaderText = "Gudang ID";
            this.GudangID.Name = "GudangID";
            this.GudangID.ReadOnly = true;
            this.GudangID.Width = 95;
            // 
            // KodeCabang
            // 
            this.KodeCabang.DataPropertyName = "KodeCabang";
            this.KodeCabang.FillWeight = 13.82224F;
            this.KodeCabang.HeaderText = "Kd Cabang";
            this.KodeCabang.Name = "KodeCabang";
            this.KodeCabang.ReadOnly = true;
            this.KodeCabang.Width = 95;
            // 
            // NamaGudang
            // 
            this.NamaGudang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaGudang.DataPropertyName = "NamaGudang";
            this.NamaGudang.FillWeight = 204.4929F;
            this.NamaGudang.HeaderText = "Nm Gudang";
            this.NamaGudang.Name = "NamaGudang";
            this.NamaGudang.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.FillWeight = 426.396F;
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // Telp
            // 
            this.Telp.DataPropertyName = "Telp";
            this.Telp.FillWeight = 13.82224F;
            this.Telp.HeaderText = "Telp";
            this.Telp.Name = "Telp";
            this.Telp.ReadOnly = true;
            this.Telp.Width = 60;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.FillWeight = 13.82224F;
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            this.Fax.Width = 53;
            // 
            // Modem
            // 
            this.Modem.DataPropertyName = "Modem";
            this.Modem.FillWeight = 13.82224F;
            this.Modem.HeaderText = "Modem";
            this.Modem.Name = "Modem";
            this.Modem.ReadOnly = true;
            this.Modem.Width = 67;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            this.LastUpdatedBy.Width = 123;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            this.LastUpdatedTime.Width = 137;
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(261, 374);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 3;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Visible = false;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(138, 374);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 2;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Visible = false;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(12, 374);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 1;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Visible = false;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(642, 374);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmGudangBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(750, 430);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dataGridView1);
            this.FormID = "SC0204";
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGudangBrowse";
            this.Text = "SC0204 - Gudang";
            this.Title = "Gudang";
            this.Load += new System.EventHandler(this.frmGudangBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView dataGridView1;
        private ISA.Toko.Controls.CommandButton cmdDELETE;
        private ISA.Toko.Controls.CommandButton cmdEDIT;
        private ISA.Toko.Controls.CommandButton cmdADD;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn GudangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modem;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}
