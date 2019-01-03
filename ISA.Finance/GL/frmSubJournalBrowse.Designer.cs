namespace ISA.Finance.GL
{
    partial class frmSubJournalBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubJournalBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUraian = new System.Windows.Forms.Label();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.customGridView3 = new ISA.Controls.CustomGridView();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.subhRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subhJournalDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subhRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subhPartnerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subhKeterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subhPersen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subhAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdPartnerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdPartnerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdNamaPartner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdPersen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtUraian, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.customGridView2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.customGridView3, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 264);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // txtUraian
            // 
            this.txtUraian.AutoSize = true;
            this.txtUraian.Location = new System.Drawing.Point(3, 0);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(49, 14);
            this.txtUraian.TabIndex = 3;
            this.txtUraian.Text = "[Uraian]";
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hRowID,
            this.hRecordID,
            this.hHeaderID,
            this.hNoPerkiraan,
            this.hNamaPerkiraan,
            this.hUraian,
            this.hDebet,
            this.hKredit,
            this.hDK});
            this.customGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView1.Location = new System.Drawing.Point(3, 23);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(696, 74);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 0;
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
            this.customGridView1.Click += new System.EventHandler(this.customGridView1_Click);
            // 
            // customGridView2
            // 
            this.customGridView2.AllowUserToAddRows = false;
            this.customGridView2.AllowUserToDeleteRows = false;
            this.customGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subhRowID,
            this.subhJournalDetailID,
            this.subhRecordID,
            this.subhPartnerID,
            this.subhKeterangan,
            this.subhPersen,
            this.subhAmount});
            this.customGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView2.Location = new System.Drawing.Point(3, 103);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(696, 74);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 1;
            this.customGridView2.Enter += new System.EventHandler(this.customGridView2_Enter);
            this.customGridView2.SelectionChanged += new System.EventHandler(this.customGridView2_SelectionChanged);
            this.customGridView2.Click += new System.EventHandler(this.customGridView2_Click);
            // 
            // customGridView3
            // 
            this.customGridView3.AllowUserToAddRows = false;
            this.customGridView3.AllowUserToDeleteRows = false;
            this.customGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subdRowID,
            this.subdHeaderID,
            this.subdPartnerID,
            this.subdPartnerNo,
            this.subdNamaPartner,
            this.subdPersen,
            this.subdCurrency,
            this.subdAmount});
            this.customGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView3.Location = new System.Drawing.Point(3, 183);
            this.customGridView3.MultiSelect = false;
            this.customGridView3.Name = "customGridView3";
            this.customGridView3.ReadOnly = true;
            this.customGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView3.Size = new System.Drawing.Size(696, 78);
            this.customGridView3.StandardTab = true;
            this.customGridView3.TabIndex = 2;
            this.customGridView3.Enter += new System.EventHandler(this.customGridView3_Enter);
            this.customGridView3.Click += new System.EventHandler(this.customGridView3_Click);
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
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(131, 289);
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
            this.cmdDelete.Location = new System.Drawing.Point(250, 289);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(600, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // subhRowID
            // 
            this.subhRowID.DataPropertyName = "RowID";
            this.subhRowID.HeaderText = "RowID";
            this.subhRowID.Name = "subhRowID";
            this.subhRowID.ReadOnly = true;
            this.subhRowID.Visible = false;
            // 
            // subhJournalDetailID
            // 
            this.subhJournalDetailID.DataPropertyName = "JournalDetailID";
            this.subhJournalDetailID.HeaderText = "JournalDetailID";
            this.subhJournalDetailID.Name = "subhJournalDetailID";
            this.subhJournalDetailID.ReadOnly = true;
            this.subhJournalDetailID.Visible = false;
            // 
            // subhRecordID
            // 
            this.subhRecordID.DataPropertyName = "RecordID";
            this.subhRecordID.HeaderText = "RecordID";
            this.subhRecordID.Name = "subhRecordID";
            this.subhRecordID.ReadOnly = true;
            this.subhRecordID.Visible = false;
            // 
            // subhPartnerID
            // 
            this.subhPartnerID.DataPropertyName = "PartnerID";
            this.subhPartnerID.HeaderText = "PartnerID";
            this.subhPartnerID.Name = "subhPartnerID";
            this.subhPartnerID.ReadOnly = true;
            // 
            // subhKeterangan
            // 
            this.subhKeterangan.DataPropertyName = "Keterangan";
            this.subhKeterangan.HeaderText = "Keterangan";
            this.subhKeterangan.Name = "subhKeterangan";
            this.subhKeterangan.ReadOnly = true;
            // 
            // subhPersen
            // 
            this.subhPersen.DataPropertyName = "Persen";
            dataGridViewCellStyle3.Format = "#,##0.00";
            this.subhPersen.DefaultCellStyle = dataGridViewCellStyle3;
            this.subhPersen.HeaderText = "Persen";
            this.subhPersen.Name = "subhPersen";
            this.subhPersen.ReadOnly = true;
            // 
            // subhAmount
            // 
            this.subhAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.subhAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.subhAmount.HeaderText = "Amount";
            this.subhAmount.Name = "subhAmount";
            this.subhAmount.ReadOnly = true;
            // 
            // subdRowID
            // 
            this.subdRowID.DataPropertyName = "RowID";
            this.subdRowID.HeaderText = "RowID";
            this.subdRowID.Name = "subdRowID";
            this.subdRowID.ReadOnly = true;
            this.subdRowID.Visible = false;
            // 
            // subdHeaderID
            // 
            this.subdHeaderID.DataPropertyName = "HeaderID";
            this.subdHeaderID.HeaderText = "HeaderID";
            this.subdHeaderID.Name = "subdHeaderID";
            this.subdHeaderID.ReadOnly = true;
            this.subdHeaderID.Visible = false;
            // 
            // subdPartnerID
            // 
            this.subdPartnerID.DataPropertyName = "PartnerID";
            this.subdPartnerID.HeaderText = "PartnerID";
            this.subdPartnerID.Name = "subdPartnerID";
            this.subdPartnerID.ReadOnly = true;
            // 
            // subdPartnerNo
            // 
            this.subdPartnerNo.DataPropertyName = "PartnerNo";
            this.subdPartnerNo.HeaderText = "PartnerNo";
            this.subdPartnerNo.Name = "subdPartnerNo";
            this.subdPartnerNo.ReadOnly = true;
            // 
            // subdNamaPartner
            // 
            this.subdNamaPartner.DataPropertyName = "NamaPartner";
            this.subdNamaPartner.HeaderText = "NamaPartner";
            this.subdNamaPartner.Name = "subdNamaPartner";
            this.subdNamaPartner.ReadOnly = true;
            // 
            // subdPersen
            // 
            this.subdPersen.DataPropertyName = "Persen";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0.00";
            this.subdPersen.DefaultCellStyle = dataGridViewCellStyle5;
            this.subdPersen.HeaderText = "Persen";
            this.subdPersen.Name = "subdPersen";
            this.subdPersen.ReadOnly = true;
            // 
            // subdCurrency
            // 
            this.subdCurrency.DataPropertyName = "Currency";
            this.subdCurrency.HeaderText = "Currency";
            this.subdCurrency.Name = "subdCurrency";
            this.subdCurrency.ReadOnly = true;
            // 
            // subdAmount
            // 
            this.subdAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            this.subdAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.subdAmount.HeaderText = "Amount";
            this.subdAmount.Name = "subdAmount";
            this.subdAmount.ReadOnly = true;
            // 
            // hRowID
            // 
            this.hRowID.DataPropertyName = "RowID";
            this.hRowID.HeaderText = "RowID";
            this.hRowID.Name = "hRowID";
            this.hRowID.ReadOnly = true;
            this.hRowID.Visible = false;
            // 
            // hRecordID
            // 
            this.hRecordID.DataPropertyName = "RecordID";
            this.hRecordID.HeaderText = "RecordID";
            this.hRecordID.Name = "hRecordID";
            this.hRecordID.ReadOnly = true;
            this.hRecordID.Visible = false;
            // 
            // hHeaderID
            // 
            this.hHeaderID.DataPropertyName = "HeaderID";
            this.hHeaderID.HeaderText = "HeaderID";
            this.hHeaderID.Name = "hHeaderID";
            this.hHeaderID.ReadOnly = true;
            this.hHeaderID.Visible = false;
            // 
            // hNoPerkiraan
            // 
            this.hNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.hNoPerkiraan.HeaderText = "NoPerkiraan";
            this.hNoPerkiraan.Name = "hNoPerkiraan";
            this.hNoPerkiraan.ReadOnly = true;
            // 
            // hNamaPerkiraan
            // 
            this.hNamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.hNamaPerkiraan.HeaderText = "NamaPerkiraan";
            this.hNamaPerkiraan.Name = "hNamaPerkiraan";
            this.hNamaPerkiraan.ReadOnly = true;
            this.hNamaPerkiraan.Width = 200;
            // 
            // hUraian
            // 
            this.hUraian.DataPropertyName = "Uraian";
            this.hUraian.HeaderText = "Uraian";
            this.hUraian.Name = "hUraian";
            this.hUraian.ReadOnly = true;
            this.hUraian.Width = 300;
            // 
            // hDebet
            // 
            this.hDebet.DataPropertyName = "Debet";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            this.hDebet.DefaultCellStyle = dataGridViewCellStyle1;
            this.hDebet.HeaderText = "Debet";
            this.hDebet.Name = "hDebet";
            this.hDebet.ReadOnly = true;
            this.hDebet.Width = 125;
            // 
            // hKredit
            // 
            this.hKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.hKredit.DefaultCellStyle = dataGridViewCellStyle2;
            this.hKredit.HeaderText = "Kredit";
            this.hKredit.Name = "hKredit";
            this.hKredit.ReadOnly = true;
            this.hKredit.Width = 125;
            // 
            // hDK
            // 
            this.hDK.DataPropertyName = "DK";
            this.hDK.HeaderText = "DK";
            this.hDK.Name = "hDK";
            this.hDK.ReadOnly = true;
            this.hDK.Width = 30;
            // 
            // frmSubJournalBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(712, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Name = "frmSubJournalBrowse";
            this.Text = "SubJournal";
            this.Load += new System.EventHandler(this.frmSubJournalBrowse_Load);
            this.Shown += new System.EventHandler(this.frmSubJournalBrowse_Shown);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CustomGridView customGridView2;
        private ISA.Controls.CustomGridView customGridView3;
        private System.Windows.Forms.Label txtUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn hUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn subhRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subhJournalDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subhRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subhPartnerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subhKeterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn subhPersen;
        private System.Windows.Forms.DataGridViewTextBoxColumn subhAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdPartnerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdPartnerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdNamaPartner;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdPersen;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdAmount;

    }
}
