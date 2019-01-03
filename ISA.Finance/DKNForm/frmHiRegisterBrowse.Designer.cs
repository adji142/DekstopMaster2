namespace ISA.Finance.DKNForm
{
    partial class frmHiRegisterBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHiRegisterBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdDel = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.gridDetail = new ISA.Controls.CustomGridView();
            this.No_perk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTolak = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AlasanTolak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUtm = new ISA.Controls.CustomGridView();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_dkn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUtm)).BeginInit();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(24, 89);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 3;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(296, 89);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 4;
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
            this.cmdClose.Location = new System.Drawing.Point(757, 579);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 16;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDel.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDel.Enabled = false;
            this.cmdDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDel.Image = ((System.Drawing.Image)(resources.GetObject("cmdDel.Image")));
            this.cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDel.Location = new System.Drawing.Point(236, 579);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Size = new System.Drawing.Size(100, 40);
            this.cmdDel.TabIndex = 14;
            this.cmdDel.Text = "DELETE";
            this.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDel.UseVisualStyleBackColor = true;
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(130, 579);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 13;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(24, 579);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 12;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No_perk,
            this.RowIDD,
            this.HeaderID,
            this.Uraian,
            this.cTolak,
            this.AlasanTolak,
            this.Jumlah});
            this.gridDetail.Location = new System.Drawing.Point(24, 344);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetail.Size = new System.Drawing.Size(856, 220);
            this.gridDetail.StandardTab = true;
            this.gridDetail.TabIndex = 18;
            this.gridDetail.Click += new System.EventHandler(this.gridDetail_Click);
            // 
            // No_perk
            // 
            this.No_perk.DataPropertyName = "NoPerkiraan";
            this.No_perk.HeaderText = "No Perkiraan";
            this.No_perk.Name = "No_perk";
            this.No_perk.ReadOnly = true;
            this.No_perk.Width = 125;
            // 
            // RowIDD
            // 
            this.RowIDD.DataPropertyName = "RowID";
            this.RowIDD.HeaderText = "RowIDD";
            this.RowIDD.Name = "RowIDD";
            this.RowIDD.ReadOnly = true;
            this.RowIDD.Visible = false;
            // 
            // HeaderID
            // 
            this.HeaderID.DataPropertyName = "HeaderID";
            this.HeaderID.HeaderText = "HeaderID";
            this.HeaderID.Name = "HeaderID";
            this.HeaderID.ReadOnly = true;
            this.HeaderID.Visible = false;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 300;
            // 
            // cTolak
            // 
            this.cTolak.DataPropertyName = "Tolak";
            this.cTolak.HeaderText = "Tolak";
            this.cTolak.Name = "cTolak";
            this.cTolak.ReadOnly = true;
            this.cTolak.Width = 40;
            // 
            // AlasanTolak
            // 
            this.AlasanTolak.DataPropertyName = "Alasan";
            this.AlasanTolak.HeaderText = "Alasan Tolak";
            this.AlasanTolak.Name = "AlasanTolak";
            this.AlasanTolak.ReadOnly = true;
            this.AlasanTolak.Width = 300;
            // 
            // Jumlah
            // 
            this.Jumlah.DataPropertyName = "Jumlah";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.Jumlah.HeaderText = "Jumlah";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            // 
            // gridUtm
            // 
            this.gridUtm.AllowUserToAddRows = false;
            this.gridUtm.AllowUserToDeleteRows = false;
            this.gridUtm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUtm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridUtm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUtm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal,
            this.RowID,
            this.RecordID,
            this.No_dkn,
            this.Cabang,
            this.Dk,
            this.Cd,
            this.Src});
            this.gridUtm.Location = new System.Drawing.Point(24, 117);
            this.gridUtm.MultiSelect = false;
            this.gridUtm.Name = "gridUtm";
            this.gridUtm.ReadOnly = true;
            this.gridUtm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridUtm.Size = new System.Drawing.Size(856, 221);
            this.gridUtm.StandardTab = true;
            this.gridUtm.TabIndex = 17;
            this.gridUtm.Validated += new System.EventHandler(this.gridUtm_Validated);
            this.gridUtm.SelectionChanged += new System.EventHandler(this.gridUtm_SelectionChanged);
            this.gridUtm.Click += new System.EventHandler(this.gridUtm_Click);
            this.gridUtm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUtm_CellContentClick);
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "RecordID";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            this.RecordID.Visible = false;
            // 
            // No_dkn
            // 
            this.No_dkn.DataPropertyName = "NoDKN";
            this.No_dkn.HeaderText = "No_dkn";
            this.No_dkn.Name = "No_dkn";
            this.No_dkn.ReadOnly = true;
            // 
            // Cabang
            // 
            this.Cabang.DataPropertyName = "Cabang";
            this.Cabang.HeaderText = "Cabang";
            this.Cabang.Name = "Cabang";
            this.Cabang.ReadOnly = true;
            // 
            // Dk
            // 
            this.Dk.DataPropertyName = "DK";
            this.Dk.HeaderText = "Dk";
            this.Dk.Name = "Dk";
            this.Dk.ReadOnly = true;
            // 
            // Cd
            // 
            this.Cd.DataPropertyName = "CD";
            this.Cd.HeaderText = "Cd";
            this.Cd.Name = "Cd";
            this.Cd.ReadOnly = true;
            // 
            // Src
            // 
            this.Src.DataPropertyName = "Src";
            this.Src.HeaderText = "Src";
            this.Src.Name = "Src";
            this.Src.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 19;
            this.label1.Text = "HI Register";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmHiRegisterBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 643);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.gridUtm);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDel);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdSearch);
            this.Name = "frmHiRegisterBrowse";
            this.Text = "frmHiRegisterBrowse";
            this.Load += new System.EventHandler(this.frmHiRegisterBrowse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUtm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdDel;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdAdd;
        public ISA.Controls.CustomGridView gridDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_perk;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cTolak;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlasanTolak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        public ISA.Controls.CustomGridView gridUtm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_dkn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src;
        private System.Windows.Forms.Label label1;
    }
}