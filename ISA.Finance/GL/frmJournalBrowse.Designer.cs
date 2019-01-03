namespace ISA.Finance.GL
{
    partial class frmJournalBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.dRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNSubJournal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdGo = new ISA.Controls.CommandButton();
            this.cmdSubJournal = new System.Windows.Forms.Button();
            this.hTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNoReff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSyncFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(18, 384);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 5;
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
            this.cmdEdit.Location = new System.Drawing.Point(139, 384);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 6;
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
            this.cmdDelete.Location = new System.Drawing.Point(258, 384);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 7;
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
            this.cmdClose.Location = new System.Drawing.Point(598, 384);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.customGridView2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 300);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hTanggal,
            this.hNoReff,
            this.hKodeGudang,
            this.hSrc,
            this.hUraian,
            this.hDebet,
            this.hKredit,
            this.hRowID,
            this.hRecordID,
            this.hSyncFlag});
            this.customGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView1.Location = new System.Drawing.Point(3, 3);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(693, 134);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 0;
            this.customGridView1.Enter += new System.EventHandler(this.customGridView1_Enter);
            this.customGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_RowEnter);
            this.customGridView1.SelectionRowChanged += new System.EventHandler(this.customGridView1_SelectionRowChanged);
            this.customGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.customGridView1_CellFormatting);
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
            // 
            // customGridView2
            // 
            this.customGridView2.AllowUserToAddRows = false;
            this.customGridView2.AllowUserToDeleteRows = false;
            this.customGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dRowID,
            this.dHeaderID,
            this.dRecordID,
            this.dHRecordID,
            this.dNoPerkiraan,
            this.dNamaPerkiraan,
            this.dUraian,
            this.dDK,
            this.dDebet,
            this.dKredit,
            this.dNSubJournal});
            this.customGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView2.Location = new System.Drawing.Point(3, 163);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(693, 134);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 1;
            this.customGridView2.Enter += new System.EventHandler(this.customGridView2_Enter);
            this.customGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.customGridView2_CellFormatting);
            this.customGridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView2_KeyDown);
            // 
            // dRowID
            // 
            this.dRowID.DataPropertyName = "RowID";
            this.dRowID.HeaderText = "RowID";
            this.dRowID.Name = "dRowID";
            this.dRowID.ReadOnly = true;
            this.dRowID.Visible = false;
            // 
            // dHeaderID
            // 
            this.dHeaderID.DataPropertyName = "HeaderID";
            this.dHeaderID.HeaderText = "HeaderID";
            this.dHeaderID.Name = "dHeaderID";
            this.dHeaderID.ReadOnly = true;
            this.dHeaderID.Visible = false;
            // 
            // dRecordID
            // 
            this.dRecordID.DataPropertyName = "RecordID";
            this.dRecordID.HeaderText = "RecordID";
            this.dRecordID.Name = "dRecordID";
            this.dRecordID.ReadOnly = true;
            this.dRecordID.Visible = false;
            // 
            // dHRecordID
            // 
            this.dHRecordID.DataPropertyName = "HRecordID";
            this.dHRecordID.HeaderText = "HRecordID";
            this.dHRecordID.Name = "dHRecordID";
            this.dHRecordID.ReadOnly = true;
            this.dHRecordID.Visible = false;
            // 
            // dNoPerkiraan
            // 
            this.dNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.dNoPerkiraan.HeaderText = "NoPerkiraan";
            this.dNoPerkiraan.Name = "dNoPerkiraan";
            this.dNoPerkiraan.ReadOnly = true;
            // 
            // dNamaPerkiraan
            // 
            this.dNamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.dNamaPerkiraan.HeaderText = "NamaPerkiraan";
            this.dNamaPerkiraan.Name = "dNamaPerkiraan";
            this.dNamaPerkiraan.ReadOnly = true;
            this.dNamaPerkiraan.Width = 200;
            // 
            // dUraian
            // 
            this.dUraian.DataPropertyName = "Uraian";
            this.dUraian.HeaderText = "Uraian";
            this.dUraian.Name = "dUraian";
            this.dUraian.ReadOnly = true;
            this.dUraian.Width = 300;
            // 
            // dDK
            // 
            this.dDK.DataPropertyName = "DK";
            this.dDK.HeaderText = "DK";
            this.dDK.Name = "dDK";
            this.dDK.ReadOnly = true;
            this.dDK.Width = 30;
            // 
            // dDebet
            // 
            this.dDebet.DataPropertyName = "Debet";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.dDebet.DefaultCellStyle = dataGridViewCellStyle4;
            this.dDebet.HeaderText = "Debet";
            this.dDebet.Name = "dDebet";
            this.dDebet.ReadOnly = true;
            // 
            // dKredit
            // 
            this.dKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.dKredit.DefaultCellStyle = dataGridViewCellStyle5;
            this.dKredit.HeaderText = "Kredit";
            this.dKredit.Name = "dKredit";
            this.dKredit.ReadOnly = true;
            // 
            // dNSubJournal
            // 
            this.dNSubJournal.DataPropertyName = "NSubJournal";
            this.dNSubJournal.HeaderText = "NSubJournal";
            this.dNSubJournal.Name = "dNSubJournal";
            this.dNSubJournal.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tanggal";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(77, 25);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 11;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdGo
            // 
            this.cmdGo.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdGo.Image = ((System.Drawing.Image)(resources.GetObject("cmdGo.Image")));
            this.cmdGo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdGo.Location = new System.Drawing.Point(328, 23);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(80, 23);
            this.cmdGo.TabIndex = 12;
            this.cmdGo.Text = "Search";
            this.cmdGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // cmdSubJournal
            // 
            this.cmdSubJournal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSubJournal.Image = global::ISA.Finance.Properties.Resources.Download32;
            this.cmdSubJournal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSubJournal.Location = new System.Drawing.Point(430, 384);
            this.cmdSubJournal.Name = "cmdSubJournal";
            this.cmdSubJournal.Size = new System.Drawing.Size(124, 40);
            this.cmdSubJournal.TabIndex = 14;
            this.cmdSubJournal.Text = "SUB JOURNAL";
            this.cmdSubJournal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSubJournal.UseVisualStyleBackColor = true;
            this.cmdSubJournal.Click += new System.EventHandler(this.cmdSubJournal_Click);
            // 
            // hTanggal
            // 
            this.hTanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.hTanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.hTanggal.HeaderText = "Tanggal";
            this.hTanggal.Name = "hTanggal";
            this.hTanggal.ReadOnly = true;
            // 
            // hNoReff
            // 
            this.hNoReff.DataPropertyName = "NoReff";
            this.hNoReff.HeaderText = "NoReff";
            this.hNoReff.Name = "hNoReff";
            this.hNoReff.ReadOnly = true;
            // 
            // hKodeGudang
            // 
            this.hKodeGudang.DataPropertyName = "KodeGudang";
            this.hKodeGudang.HeaderText = "Cbg";
            this.hKodeGudang.Name = "hKodeGudang";
            this.hKodeGudang.ReadOnly = true;
            this.hKodeGudang.Width = 40;
            // 
            // hSrc
            // 
            this.hSrc.DataPropertyName = "Src";
            this.hSrc.HeaderText = "Src";
            this.hSrc.Name = "hSrc";
            this.hSrc.ReadOnly = true;
            this.hSrc.Width = 40;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.hDebet.DefaultCellStyle = dataGridViewCellStyle2;
            this.hDebet.HeaderText = "Debet";
            this.hDebet.Name = "hDebet";
            this.hDebet.ReadOnly = true;
            this.hDebet.Width = 125;
            // 
            // hKredit
            // 
            this.hKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.hKredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.hKredit.HeaderText = "Kredit";
            this.hKredit.Name = "hKredit";
            this.hKredit.ReadOnly = true;
            this.hKredit.Width = 125;
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
            // hSyncFlag
            // 
            this.hSyncFlag.DataPropertyName = "SyncFlag";
            this.hSyncFlag.HeaderText = "SyncFlag";
            this.hSyncFlag.Name = "hSyncFlag";
            this.hSyncFlag.ReadOnly = true;
            // 
            // frmJournalBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 436);
            this.Controls.Add(this.cmdSubJournal);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Name = "frmJournalBrowse";
            this.Text = "Journal";
            this.Load += new System.EventHandler(this.frmJournalBrowse_Load);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmdGo, 0);
            this.Controls.SetChildIndex(this.cmdSubJournal, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CustomGridView customGridView2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdGo;
        private System.Windows.Forms.Button cmdSubJournal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNSubJournal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNoReff;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn hSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn hUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRecordID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hSyncFlag;
    }
}
