namespace ISA.Finance.Kasir
{
    partial class frmBudget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudget));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalAjuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTotalACC = new ISA.Controls.NumericTextBox();
            this.tbTotalAjuan = new ISA.Controls.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(289, 50);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 72;
            this.cmdSearch.TabStop = false;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(9, 50);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(287, 34);
            this.monthYearBox1.TabIndex = 71;
            this.monthYearBox1.Year = 2016;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaPerkiraan,
            this.NoPerkiraan,
            this.NominalAjuan,
            this.NominalACC,
            this.Keterangan00,
            this.Keterangan11,
            this.KodeGudang,
            this.RowID,
            this.SyncFlag});
            this.dataGridView1.Location = new System.Drawing.Point(10, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1217, 275);
            this.dataGridView1.TabIndex = 73;
            // 
            // NamaPerkiraan
            // 
            this.NamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.NamaPerkiraan.HeaderText = "Group Biaya";
            this.NamaPerkiraan.Name = "NamaPerkiraan";
            this.NamaPerkiraan.ReadOnly = true;
            this.NamaPerkiraan.Width = 300;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "No.Perkiraan";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            this.NoPerkiraan.Width = 150;
            // 
            // NominalAjuan
            // 
            this.NominalAjuan.DataPropertyName = "NominalAjuan";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0";
            this.NominalAjuan.DefaultCellStyle = dataGridViewCellStyle7;
            this.NominalAjuan.HeaderText = "Nominal Ajuan";
            this.NominalAjuan.Name = "NominalAjuan";
            this.NominalAjuan.ReadOnly = true;
            // 
            // NominalACC
            // 
            this.NominalACC.DataPropertyName = "NominalACC";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "#,##0";
            this.NominalACC.DefaultCellStyle = dataGridViewCellStyle8;
            this.NominalACC.HeaderText = "Nominal ACC";
            this.NominalACC.Name = "NominalACC";
            this.NominalACC.ReadOnly = true;
            // 
            // Keterangan00
            // 
            this.Keterangan00.DataPropertyName = "Keterangan00";
            this.Keterangan00.HeaderText = "Keterangan 00";
            this.Keterangan00.Name = "Keterangan00";
            this.Keterangan00.ReadOnly = true;
            this.Keterangan00.Width = 200;
            // 
            // Keterangan11
            // 
            this.Keterangan11.DataPropertyName = "Keterangan11";
            this.Keterangan11.HeaderText = "Keterangan 11";
            this.Keterangan11.Name = "Keterangan11";
            this.Keterangan11.ReadOnly = true;
            this.Keterangan11.Width = 200;
            // 
            // KodeGudang
            // 
            this.KodeGudang.DataPropertyName = "KodeGudang";
            this.KodeGudang.HeaderText = "KodeGudang";
            this.KodeGudang.Name = "KodeGudang";
            this.KodeGudang.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // SyncFlag
            // 
            this.SyncFlag.DataPropertyName = "SyncFlag";
            this.SyncFlag.HeaderText = "SyncFlag";
            this.SyncFlag.Name = "SyncFlag";
            this.SyncFlag.ReadOnly = true;
            this.SyncFlag.Visible = false;
            // 
            // tbTotalACC
            // 
            this.tbTotalACC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbTotalACC.Enabled = false;
            this.tbTotalACC.Location = new System.Drawing.Point(542, 369);
            this.tbTotalACC.Name = "tbTotalACC";
            this.tbTotalACC.Size = new System.Drawing.Size(100, 20);
            this.tbTotalACC.TabIndex = 80;
            this.tbTotalACC.Text = "0";
            // 
            // tbTotalAjuan
            // 
            this.tbTotalAjuan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbTotalAjuan.Enabled = false;
            this.tbTotalAjuan.Location = new System.Drawing.Point(437, 369);
            this.tbTotalAjuan.Name = "tbTotalAjuan";
            this.tbTotalAjuan.Size = new System.Drawing.Size(100, 20);
            this.tbTotalAjuan.TabIndex = 79;
            this.tbTotalAjuan.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 78;
            this.label2.Text = "Total";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(115, 389);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 77;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(9, 389);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 76;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(1151, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 18);
            this.checkBox1.TabIndex = 81;
            this.checkBox1.Text = "SyncFlag";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1237, 441);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbTotalACC);
            this.Controls.Add(this.tbTotalAjuan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.monthYearBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBudget";
            this.Text = "Rencana Bulanan";
            this.Title = "Rencana Bulanan";
            this.Load += new System.EventHandler(this.frmBudget_Load);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbTotalAjuan, 0);
            this.Controls.SetChildIndex(this.tbTotalACC, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalAjuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan00;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan11;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncFlag;
        private ISA.Controls.NumericTextBox tbTotalACC;
        private ISA.Controls.NumericTextBox tbTotalAjuan;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
