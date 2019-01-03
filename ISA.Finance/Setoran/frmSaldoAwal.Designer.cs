namespace ISA.Finance.Setoran
{
    partial class frmSaldoAwal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldoAwal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericTextBox1 = new ISA.Controls.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCancel = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.MonthName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tahun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bulan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.AllowUserToResizeRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MonthName,
            this.Tahun,
            this.SaldoAwal,
            this.SaldoAkhir,
            this.rr,
            this.RowID,
            this.Bulan});
            this.customGridView1.Location = new System.Drawing.Point(12, 28);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(471, 169);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(11, 347);
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
            this.cmdEdit.Location = new System.Drawing.Point(117, 347);
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
            this.cmdDelete.Location = new System.Drawing.Point(223, 347);
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
            this.cmdClose.Location = new System.Drawing.Point(383, 347);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numericTextBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdCancel);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.monthYearBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(89, 47);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(139, 20);
            this.numericTextBox1.TabIndex = 5;
            this.numericTextBox1.Text = "0";
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saldo Awal";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(365, 91);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(6, 91);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bulan";
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(89, 9);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(310, 21);
            this.monthYearBox1.TabIndex = 0;
            this.monthYearBox1.Year = 2012;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(414, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 14);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Preference";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MonthName
            // 
            this.MonthName.DataPropertyName = "MonthName";
            this.MonthName.HeaderText = "Bulan";
            this.MonthName.Name = "MonthName";
            this.MonthName.ReadOnly = true;
            this.MonthName.Width = 62;
            // 
            // Tahun
            // 
            this.Tahun.DataPropertyName = "Tahun";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tahun.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tahun.HeaderText = "Tahun";
            this.Tahun.Name = "Tahun";
            this.Tahun.ReadOnly = true;
            this.Tahun.Width = 66;
            // 
            // SaldoAwal
            // 
            this.SaldoAwal.DataPropertyName = "RpAwal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.SaldoAwal.DefaultCellStyle = dataGridViewCellStyle2;
            this.SaldoAwal.HeaderText = "SaldoAwal";
            this.SaldoAwal.Name = "SaldoAwal";
            this.SaldoAwal.ReadOnly = true;
            this.SaldoAwal.Width = 89;
            // 
            // SaldoAkhir
            // 
            this.SaldoAkhir.DataPropertyName = "RpAkhir";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.SaldoAkhir.DefaultCellStyle = dataGridViewCellStyle3;
            this.SaldoAkhir.HeaderText = "SaldoAkhir";
            this.SaldoAkhir.Name = "SaldoAkhir";
            this.SaldoAkhir.ReadOnly = true;
            this.SaldoAkhir.Width = 92;
            // 
            // rr
            // 
            this.rr.DataPropertyName = "rr";
            this.rr.HeaderText = "rr";
            this.rr.Name = "rr";
            this.rr.ReadOnly = true;
            this.rr.Visible = false;
            this.rr.Width = 42;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 66;
            // 
            // Bulan
            // 
            this.Bulan.DataPropertyName = "Bulan";
            this.Bulan.HeaderText = "Bulan";
            this.Bulan.Name = "Bulan";
            this.Bulan.ReadOnly = true;
            this.Bulan.Visible = false;
            this.Bulan.Width = 62;
            // 
            // frmSaldoAwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(495, 399);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdClose);
            this.MaximizeBox = false;
            this.Name = "frmSaldoAwal";
            this.Text = "Setoran : Rencana Saldo Awal";
            this.Load += new System.EventHandler(this.frmSaldoAwal_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Controls.CommandButton cmdCancel;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tahun;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn rr;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bulan;
    }
}
