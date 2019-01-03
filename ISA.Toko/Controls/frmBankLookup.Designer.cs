namespace ISA.Toko.Controls
{
    partial class frmBankLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankLookup));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cBankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNamaBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJRek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAlamat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(81, 22);
            this.txtSearch.MaxLength = 12;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(237, 20);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
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
            this.cBankID,
            this.cRowID,
            this.cNamaBank,
            this.cJRek,
            this.cNoAccount,
            this.cAlamat1,
            this.cKota});
            this.customGridView1.Location = new System.Drawing.Point(6, 57);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(698, 232);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 11;
            this.customGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellContentDoubleClick);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // cBankID
            // 
            this.cBankID.DataPropertyName = "BankID";
            this.cBankID.HeaderText = "BankID";
            this.cBankID.Name = "cBankID";
            this.cBankID.ReadOnly = true;
            this.cBankID.Visible = false;
            // 
            // cRowID
            // 
            this.cRowID.DataPropertyName = "RowID";
            this.cRowID.HeaderText = "RowID";
            this.cRowID.Name = "cRowID";
            this.cRowID.ReadOnly = true;
            this.cRowID.Visible = false;
            // 
            // cNamaBank
            // 
            this.cNamaBank.DataPropertyName = "NamaBank";
            this.cNamaBank.HeaderText = "NamaBank";
            this.cNamaBank.Name = "cNamaBank";
            this.cNamaBank.ReadOnly = true;
            this.cNamaBank.Width = 200;
            // 
            // cJRek
            // 
            this.cJRek.DataPropertyName = "JRek";
            this.cJRek.HeaderText = "J.Rek";
            this.cJRek.Name = "cJRek";
            this.cJRek.ReadOnly = true;
            // 
            // cNoAccount
            // 
            this.cNoAccount.DataPropertyName = "NoAccount";
            this.cNoAccount.HeaderText = "NoAccount";
            this.cNoAccount.Name = "cNoAccount";
            this.cNoAccount.ReadOnly = true;
            // 
            // cAlamat1
            // 
            this.cAlamat1.DataPropertyName = "Alamat";
            this.cAlamat1.HeaderText = "Alamat";
            this.cAlamat1.Name = "cAlamat1";
            this.cAlamat1.ReadOnly = true;
            this.cAlamat1.Width = 250;
            // 
            // cKota
            // 
            this.cKota.DataPropertyName = "Kota";
            this.cKota.HeaderText = "Kota";
            this.cKota.Name = "cKota";
            this.cKota.ReadOnly = true;
            this.cKota.Width = 200;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(324, 20);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 10;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(604, 295);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmBankLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmBankLookup";
            this.Load += new System.EventHandler(this.frmBankLookup_Load);
            this.Shown += new System.EventHandler(this.frmBankLookup_Shown);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNamaBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJRek;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlamat1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKota;
    }
}
