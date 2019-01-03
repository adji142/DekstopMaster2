namespace ISA.Finance.Setoran
{
    partial class frmLibur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibur));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bulan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tahun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdCancel = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTanggal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanggal)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal,
            this.Bulan,
            this.Tahun,
            this.RowID});
            this.customGridView1.Location = new System.Drawing.Point(12, 26);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(215, 328);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
            // 
            // Tanggal
            // 
            this.Tanggal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // Bulan
            // 
            this.Bulan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Bulan.DataPropertyName = "Bulan";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Bulan.DefaultCellStyle = dataGridViewCellStyle2;
            this.Bulan.HeaderText = "Bulan";
            this.Bulan.Name = "Bulan";
            this.Bulan.ReadOnly = true;
            // 
            // Tahun
            // 
            this.Tahun.DataPropertyName = "Tahun";
            this.Tahun.HeaderText = "Tahun";
            this.Tahun.Name = "Tahun";
            this.Tahun.ReadOnly = true;
            this.Tahun.Visible = false;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(654, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 14);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Preference";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(250, 312);
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
            this.cmdEdit.Location = new System.Drawing.Point(367, 313);
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
            this.cmdDelete.Location = new System.Drawing.Point(484, 313);
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
            this.cmdClose.Location = new System.Drawing.Point(627, 313);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdCancel);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTanggal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(244, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 264);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(373, 218);
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
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(6, 218);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tanggal";
            // 
            // txtTanggal
            // 
            this.txtTanggal.Location = new System.Drawing.Point(142, 69);
            this.txtTanggal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(120, 20);
            this.txtTanggal.TabIndex = 0;
            this.txtTanggal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Bulan";
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(142, 104);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 22);
            this.cboMonth.TabIndex = 1;
            // 
            // frmLibur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(739, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.linkLabel1);
            this.MaximizeBox = false;
            this.Name = "frmLibur";
            this.Text = "Hari Libur";
            this.Load += new System.EventHandler(this.frmLibur_Load);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanggal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Controls.CommandButton cmdCancel;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtTanggal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bulan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tahun;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
