namespace ISA.Finance.VWil
{
    partial class frmProsesIDWilExecute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProsesIDWilExecute));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdOk = new ISA.Controls.CommandButton();
            this.hKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNoReff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.dKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(612, 432);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOk.Image = ((System.Drawing.Image)(resources.GetObject("cmdOk.Image")));
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(492, 432);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(100, 40);
            this.cmdOk.TabIndex = 21;
            this.cmdOk.Text = "SAVE";
            this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // hKredit
            // 
            this.hKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            this.hKredit.DefaultCellStyle = dataGridViewCellStyle1;
            this.hKredit.HeaderText = "Kredit";
            this.hKredit.Name = "hKredit";
            this.hKredit.ReadOnly = true;
            this.hKredit.Width = 125;
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
            // hUraian
            // 
            this.hUraian.DataPropertyName = "Uraian";
            this.hUraian.HeaderText = "Uraian";
            this.hUraian.Name = "hUraian";
            this.hUraian.ReadOnly = true;
            // 
            // hNoReff
            // 
            this.hNoReff.DataPropertyName = "NoReff";
            this.hNoReff.HeaderText = "NoReff";
            this.hNoReff.Name = "hNoReff";
            this.hNoReff.ReadOnly = true;
            // 
            // hSrc
            // 
            this.hSrc.DataPropertyName = "Src";
            this.hSrc.HeaderText = "Src";
            this.hSrc.Name = "hSrc";
            this.hSrc.ReadOnly = true;
            // 
            // hKodeGudang
            // 
            this.hKodeGudang.DataPropertyName = "KodeGudang";
            this.hKodeGudang.HeaderText = "Kd Gdg";
            this.hKodeGudang.Name = "hKodeGudang";
            this.hKodeGudang.ReadOnly = true;
            this.hKodeGudang.Width = 80;
            // 
            // hTanggal
            // 
            this.hTanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.hTanggal.DefaultCellStyle = dataGridViewCellStyle3;
            this.hTanggal.HeaderText = "Tanggal";
            this.hTanggal.Name = "hTanggal";
            this.hTanggal.ReadOnly = true;
            this.hTanggal.Width = 80;
            // 
            // hRecordID
            // 
            this.hRecordID.DataPropertyName = "RecordID";
            this.hRecordID.HeaderText = "RecordID";
            this.hRecordID.Name = "hRecordID";
            this.hRecordID.ReadOnly = true;
            this.hRecordID.Visible = false;
            // 
            // hRowID
            // 
            this.hRowID.DataPropertyName = "RowID";
            this.hRowID.HeaderText = "RowID";
            this.hRowID.Name = "hRowID";
            this.hRowID.ReadOnly = true;
            this.hRowID.Visible = false;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hRowID,
            this.hRecordID,
            this.hTanggal,
            this.hKodeGudang,
            this.hSrc,
            this.hNoReff,
            this.hUraian,
            this.hDebet,
            this.hKredit});
            this.customGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView1.Location = new System.Drawing.Point(3, 3);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(716, 186);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 23;
            this.customGridView1.FilterData += new System.EventHandler(this.gridPJH_FilterData);
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
            // 
            // dKredit
            // 
            this.dKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.dKredit.DefaultCellStyle = dataGridViewCellStyle4;
            this.dKredit.HeaderText = "Kredit";
            this.dKredit.Name = "dKredit";
            this.dKredit.ReadOnly = true;
            this.dKredit.Width = 125;
            // 
            // dDebet
            // 
            this.dDebet.DataPropertyName = "Debet";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.dDebet.DefaultCellStyle = dataGridViewCellStyle5;
            this.dDebet.HeaderText = "Debet";
            this.dDebet.Name = "dDebet";
            this.dDebet.ReadOnly = true;
            this.dDebet.Width = 125;
            // 
            // dDK
            // 
            this.dDK.DataPropertyName = "DK";
            this.dDK.HeaderText = "DK";
            this.dDK.Name = "dDK";
            this.dDK.ReadOnly = true;
            // 
            // dUraian
            // 
            this.dUraian.DataPropertyName = "Uraian";
            this.dUraian.HeaderText = "Uraian";
            this.dUraian.Name = "dUraian";
            this.dUraian.ReadOnly = true;
            this.dUraian.Width = 300;
            // 
            // dNoPerkiraan
            // 
            this.dNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.dNoPerkiraan.HeaderText = "NoPerkiraan";
            this.dNoPerkiraan.Name = "dNoPerkiraan";
            this.dNoPerkiraan.ReadOnly = true;
            // 
            // dHRecordID
            // 
            this.dHRecordID.DataPropertyName = "HRecordID";
            this.dHRecordID.HeaderText = "HRecordID";
            this.dHRecordID.Name = "dHRecordID";
            this.dHRecordID.ReadOnly = true;
            this.dHRecordID.Visible = false;
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
            // dRowID
            // 
            this.dRowID.DataPropertyName = "RowID";
            this.dRowID.HeaderText = "RowID";
            this.dRowID.Name = "dRowID";
            this.dRowID.ReadOnly = true;
            this.dRowID.Visible = false;
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
            this.dUraian,
            this.dDK,
            this.dDebet,
            this.dKredit});
            this.customGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView2.Location = new System.Drawing.Point(3, 215);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(716, 187);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 24;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 405);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "Perhatian : Data diatas tidak akan terbentuk di GL, data harus di entry secara ma" +
                "nual";
            // 
            // frmProsesIDWilExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(746, 493);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOk);
            this.Name = "frmProsesIDWilExecute";
            this.Text = "Link to GL";
            this.Shown += new System.EventHandler(this.frmProsesIDWilExecute_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProsesIDWilExecute_FormClosed);
            this.Controls.SetChildIndex(this.cmdOk, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn hUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNoReff;
        private System.Windows.Forms.DataGridViewTextBoxColumn hSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn hTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRowID;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRowID;
        private ISA.Controls.CustomGridView customGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;

    }
}
