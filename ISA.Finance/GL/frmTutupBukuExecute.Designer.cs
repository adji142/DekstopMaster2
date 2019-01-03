namespace ISA.Finance.GL
{
    partial class frmTutupBukuExecute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTutupBukuExecute));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.hRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNoReff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSyncFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.dRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridClosingGL = new ISA.Controls.CustomGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cPeriode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRpAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTglProses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClosingGL)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(555, 398);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(676, 398);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hRowID,
            this.hRecordID,
            this.hTanggal,
            this.hNoReff,
            this.hUraian,
            this.hSrc,
            this.hKodeGudang,
            this.hDebet,
            this.hKredit,
            this.hSyncFlag});
            this.customGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView1.Location = new System.Drawing.Point(3, 23);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(744, 140);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 6;
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
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
            this.hUraian.Width = 300;
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
            // hSyncFlag
            // 
            this.hSyncFlag.DataPropertyName = "SyncFlag";
            this.hSyncFlag.HeaderText = "SyncFlag";
            this.hSyncFlag.Name = "hSyncFlag";
            this.hSyncFlag.ReadOnly = true;
            this.hSyncFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hSyncFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hSyncFlag.Visible = false;
            this.hSyncFlag.Width = 50;
            // 
            // customGridView2
            // 
            this.customGridView2.AllowUserToAddRows = false;
            this.customGridView2.AllowUserToDeleteRows = false;
            this.customGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dRowID,
            this.dRecordID,
            this.dHeaderID,
            this.dHRecordID,
            this.dNoPerkiraan,
            this.dUraian,
            this.dDK,
            this.dDebet,
            this.dKredit});
            this.customGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView2.Location = new System.Drawing.Point(3, 189);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(744, 141);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 7;
            // 
            // dRowID
            // 
            this.dRowID.DataPropertyName = "RowID";
            this.dRowID.HeaderText = "RowID";
            this.dRowID.Name = "dRowID";
            this.dRowID.ReadOnly = true;
            this.dRowID.Visible = false;
            // 
            // dRecordID
            // 
            this.dRecordID.DataPropertyName = "RecordID";
            this.dRecordID.HeaderText = "RecordID";
            this.dRecordID.Name = "dRecordID";
            this.dRecordID.ReadOnly = true;
            this.dRecordID.Visible = false;
            // 
            // dHeaderID
            // 
            this.dHeaderID.DataPropertyName = "HeaderID";
            this.dHeaderID.HeaderText = "HeaderID";
            this.dHeaderID.Name = "dHeaderID";
            this.dHeaderID.ReadOnly = true;
            this.dHeaderID.Visible = false;
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
            this.dUraian.Width = 300;
            // 
            // dDK
            // 
            this.dDK.DataPropertyName = "DK";
            this.dDK.HeaderText = "DK";
            this.dDK.Name = "dDK";
            this.dDK.ReadOnly = true;
            this.dDK.Width = 50;
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
            this.dDebet.Width = 125;
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
            this.dKredit.Width = 125;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.customGridView2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(750, 333);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Journal";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Journal Detail";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 366);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridClosingGL);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(756, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Closing GL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridClosingGL
            // 
            this.gridClosingGL.AllowUserToAddRows = false;
            this.gridClosingGL.AllowUserToDeleteRows = false;
            this.gridClosingGL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClosingGL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPeriode,
            this.cKodeGudang,
            this.cNoPerkiraan,
            this.cNamaPerkiraan,
            this.cRpAkhir,
            this.cTglProses});
            this.gridClosingGL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClosingGL.Location = new System.Drawing.Point(3, 3);
            this.gridClosingGL.MultiSelect = false;
            this.gridClosingGL.Name = "gridClosingGL";
            this.gridClosingGL.ReadOnly = true;
            this.gridClosingGL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridClosingGL.Size = new System.Drawing.Size(750, 333);
            this.gridClosingGL.StandardTab = true;
            this.gridClosingGL.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(756, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Journal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cPeriode
            // 
            this.cPeriode.DataPropertyName = "Periode";
            this.cPeriode.HeaderText = "Periode";
            this.cPeriode.Name = "cPeriode";
            this.cPeriode.ReadOnly = true;
            // 
            // cKodeGudang
            // 
            this.cKodeGudang.DataPropertyName = "KodeGudang";
            this.cKodeGudang.HeaderText = "Kode Gdg";
            this.cKodeGudang.Name = "cKodeGudang";
            this.cKodeGudang.ReadOnly = true;
            // 
            // cNoPerkiraan
            // 
            this.cNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.cNoPerkiraan.HeaderText = "NoPerkiraan";
            this.cNoPerkiraan.Name = "cNoPerkiraan";
            this.cNoPerkiraan.ReadOnly = true;
            // 
            // cNamaPerkiraan
            // 
            this.cNamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.cNamaPerkiraan.HeaderText = "NmPerkiraan";
            this.cNamaPerkiraan.Name = "cNamaPerkiraan";
            this.cNamaPerkiraan.ReadOnly = true;
            this.cNamaPerkiraan.Width = 300;
            // 
            // cRpAkhir
            // 
            this.cRpAkhir.DataPropertyName = "RpAkhir";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            this.cRpAkhir.DefaultCellStyle = dataGridViewCellStyle6;
            this.cRpAkhir.HeaderText = "RpAkhir";
            this.cRpAkhir.Name = "cRpAkhir";
            this.cRpAkhir.ReadOnly = true;
            this.cRpAkhir.Width = 125;
            // 
            // cTglProses
            // 
            this.cTglProses.DataPropertyName = "TglProses";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy";
            this.cTglProses.DefaultCellStyle = dataGridViewCellStyle7;
            this.cTglProses.HeaderText = "TglProses";
            this.cTglProses.Name = "cTglProses";
            this.cTglProses.ReadOnly = true;
            // 
            // frmTutupBukuExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(788, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Name = "frmTutupBukuExecute";
            this.Text = "Confirm Tutup Buku";
            this.Shown += new System.EventHandler(this.frmTutupBukuPreview_Shown);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridClosingGL)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CustomGridView customGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNoReff;
        private System.Windows.Forms.DataGridViewTextBoxColumn hUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKredit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hSyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dKredit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ISA.Controls.CustomGridView gridClosingGL;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPeriode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRpAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTglProses;

    }
}
