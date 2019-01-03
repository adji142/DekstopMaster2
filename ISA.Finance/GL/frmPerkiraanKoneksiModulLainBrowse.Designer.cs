namespace ISA.Finance.GL
{
    partial class frmPerkiraanKoneksiModulLainBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerkiraanKoneksiModulLainBrowse));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.label1 = new System.Windows.Forms.Label();
            this.cRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMdl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKodeTrn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cRowID,
            this.cMdl,
            this.cKodeTrn,
            this.cNoPerkiraan,
            this.cUraian});
            this.customGridView1.Location = new System.Drawing.Point(6, 84);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(697, 199);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(599, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(79, 24);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 8;
            this.lookupGudang1.SelectData += new System.EventHandler(this.lookupGudang1_SelectData);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cabang";
            // 
            // cRowID
            // 
            this.cRowID.DataPropertyName = "RowID";
            this.cRowID.HeaderText = "RowID";
            this.cRowID.Name = "cRowID";
            this.cRowID.ReadOnly = true;
            this.cRowID.Visible = false;
            // 
            // cMdl
            // 
            this.cMdl.DataPropertyName = "Mdl";
            this.cMdl.HeaderText = "Modul";
            this.cMdl.Name = "cMdl";
            this.cMdl.ReadOnly = true;
            this.cMdl.Width = 60;
            // 
            // cKodeTrn
            // 
            this.cKodeTrn.DataPropertyName = "KodeTrn";
            this.cKodeTrn.HeaderText = "Kode";
            this.cKodeTrn.Name = "cKodeTrn";
            this.cKodeTrn.ReadOnly = true;
            this.cKodeTrn.Width = 75;
            // 
            // cNoPerkiraan
            // 
            this.cNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.cNoPerkiraan.HeaderText = "No Perkiraan";
            this.cNoPerkiraan.Name = "cNoPerkiraan";
            this.cNoPerkiraan.ReadOnly = true;
            this.cNoPerkiraan.Width = 150;
            // 
            // cUraian
            // 
            this.cUraian.DataPropertyName = "Uraian";
            this.cUraian.HeaderText = "Uraian";
            this.cUraian.Name = "cUraian";
            this.cUraian.ReadOnly = true;
            this.cUraian.Width = 350;
            // 
            // frmPerkiraanKoneksiModulLainBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(711, 341);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmPerkiraanKoneksiModulLainBrowse";
            this.Load += new System.EventHandler(this.frmPerkiraanKoneksiModulLainBrowse_Load);
            this.Shown += new System.EventHandler(this.frmPerkiraanKoneksiModulLainBrowse_Shown);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMdl;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKodeTrn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUraian;
    }
}
