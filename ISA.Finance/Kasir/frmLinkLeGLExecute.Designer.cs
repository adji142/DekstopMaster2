namespace ISA.Finance.Kasir
{
    partial class frmLinkLeGLExecute
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkLeGLExecute));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.hRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNoReff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdOk = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.dRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTKredit = new ISA.Controls.NumericTextBox();
            this.txtTDebet = new ISA.Controls.NumericTextBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.hRowID,
            this.hRecordID,
            this.hSelected,
            this.hTanggal,
            this.hNoReff,
            this.hUraian,
            this.hSrc,
            this.hKodeGudang,
            this.hDebet,
            this.hKredit});
            this.customGridView1.Location = new System.Drawing.Point(3, 28);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(891, 129);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            this.customGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellEndEdit);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
            this.customGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellContentClick);
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
            // hSelected
            // 
            this.hSelected.DataPropertyName = "Selected";
            this.hSelected.HeaderText = "";
            this.hSelected.Name = "hSelected";
            this.hSelected.ReadOnly = true;
            this.hSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hSelected.Width = 25;
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
            // hUraian
            // 
            this.hUraian.DataPropertyName = "Uraian";
            this.hUraian.HeaderText = "Uraian";
            this.hUraian.Name = "hUraian";
            this.hUraian.ReadOnly = true;
            this.hUraian.Width = 250;
            // 
            // hSrc
            // 
            this.hSrc.DataPropertyName = "Src";
            this.hSrc.HeaderText = "Src";
            this.hSrc.Name = "hSrc";
            this.hSrc.ReadOnly = true;
            this.hSrc.Width = 50;
            // 
            // hKodeGudang
            // 
            this.hKodeGudang.DataPropertyName = "KodeGudang";
            this.hKodeGudang.HeaderText = "KodeGudang";
            this.hKodeGudang.Name = "hKodeGudang";
            this.hKodeGudang.ReadOnly = true;
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
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOk.Image = ((System.Drawing.Image)(resources.GetObject("cmdOk.Image")));
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(668, 417);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(100, 40);
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "SAVE";
            this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(800, 417);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // customGridView2
            // 
            this.customGridView2.AllowUserToAddRows = false;
            this.customGridView2.AllowUserToDeleteRows = false;
            this.customGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dRowID,
            this.dHeaderID,
            this.dRecordID,
            this.dHRecordID,
            this.dNoPerkiraan,
            this.dUraian,
            this.dDebet,
            this.dKredit,
            this.dDK});
            this.customGridView2.Location = new System.Drawing.Point(3, 3);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(891, 178);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 6;
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
            // dUraian
            // 
            this.dUraian.DataPropertyName = "Uraian";
            this.dUraian.HeaderText = "Uraian";
            this.dUraian.Name = "dUraian";
            this.dUraian.ReadOnly = true;
            this.dUraian.Width = 250;
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
            // dDK
            // 
            this.dDK.DataPropertyName = "DK";
            this.dDK.HeaderText = "DK";
            this.dDK.Name = "dDK";
            this.dDK.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 9);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtTKredit);
            this.splitContainer1.Panel1.Controls.Add(this.txtTDebet);
            this.splitContainer1.Panel1.Controls.Add(this.chkSelectAll);
            this.splitContainer1.Panel1.Controls.Add(this.customGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.customGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(897, 376);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 7;
            // 
            // txtTKredit
            // 
            this.txtTKredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTKredit.Location = new System.Drawing.Point(775, 163);
            this.txtTKredit.Name = "txtTKredit";
            this.txtTKredit.ReadOnly = true;
            this.txtTKredit.Size = new System.Drawing.Size(100, 20);
            this.txtTKredit.TabIndex = 6;
            this.txtTKredit.Text = "0";
            this.txtTKredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTDebet
            // 
            this.txtTDebet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTDebet.Location = new System.Drawing.Point(674, 163);
            this.txtTDebet.Name = "txtTDebet";
            this.txtTDebet.ReadOnly = true;
            this.txtTDebet.Size = new System.Drawing.Size(100, 20);
            this.txtTDebet.TabIndex = 5;
            this.txtTDebet.Text = "0";
            this.txtTDebet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.Location = new System.Drawing.Point(17, 6);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(77, 18);
            this.chkSelectAll.TabIndex = 4;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 388);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(888, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // frmLinkLeGLExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(907, 467);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOk);
            this.Name = "frmLinkLeGLExecute";
            this.Load += new System.EventHandler(this.frmLinkLeGLExecute_Load);
            this.Shown += new System.EventHandler(this.frmLinkLeGLExecute_Shown);
            this.Controls.SetChildIndex(this.cmdOk, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdOk;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CustomGridView customGridView2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDK;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRecordID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn hTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNoReff;
        private System.Windows.Forms.DataGridViewTextBoxColumn hUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKredit;
        private ISA.Controls.NumericTextBox txtTKredit;
        private ISA.Controls.NumericTextBox txtTDebet;
    }
}
