namespace ISA.Toko.Controls
{
    partial class frmPerkiraanKoneksiLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerkiraanKoneksiLookup));
            this.label1 = new System.Windows.Forms.Label();
            this.cboHeader = new System.Windows.Forms.ComboBox();
            this.gridDetail = new ISA.Controls.CustomGridView();
            this.cRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Transaksi";
            // 
            // cboHeader
            // 
            this.cboHeader.FormattingEnabled = true;
            this.cboHeader.Location = new System.Drawing.Point(120, 25);
            this.cboHeader.Name = "cboHeader";
            this.cboHeader.Size = new System.Drawing.Size(244, 22);
            this.cboHeader.TabIndex = 4;
            this.cboHeader.SelectedIndexChanged += new System.EventHandler(this.cboHeader_SelectedIndexChanged);
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cRowID,
            this.cHeaderID,
            this.cNoPerkiraan,
            this.cUraian});
            this.gridDetail.Location = new System.Drawing.Point(6, 53);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetail.Size = new System.Drawing.Size(749, 214);
            this.gridDetail.StandardTab = true;
            this.gridDetail.TabIndex = 5;
            this.gridDetail.DoubleClick += new System.EventHandler(this.gridDetail_DoubleClick);
            this.gridDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDetail_KeyDown);
            // 
            // cRowID
            // 
            this.cRowID.DataPropertyName = "RowID";
            this.cRowID.HeaderText = "RowID";
            this.cRowID.Name = "cRowID";
            this.cRowID.ReadOnly = true;
            this.cRowID.Visible = false;
            // 
            // cHeaderID
            // 
            this.cHeaderID.DataPropertyName = "HeaderID";
            this.cHeaderID.HeaderText = "HeaderID";
            this.cHeaderID.Name = "cHeaderID";
            this.cHeaderID.ReadOnly = true;
            this.cHeaderID.Visible = false;
            // 
            // cNoPerkiraan
            // 
            this.cNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.cNoPerkiraan.HeaderText = "No Perkiraan";
            this.cNoPerkiraan.Name = "cNoPerkiraan";
            this.cNoPerkiraan.ReadOnly = true;
            this.cNoPerkiraan.Width = 150;
            // 
            // cUraian
            // 
            this.cUraian.DataPropertyName = "Uraian";
            this.cUraian.HeaderText = "Uraian";
            this.cUraian.Name = "cUraian";
            this.cUraian.ReadOnly = true;
            this.cUraian.Width = 350;
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(655, 291);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmPerkiraanKoneksiLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(762, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboHeader);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmPerkiraanKoneksiLookup";
            this.Load += new System.EventHandler(this.frmPerkiraanKoneksiLookup_Load);
            this.Shown += new System.EventHandler(this.frmPerkiraanKoneksiLookup_Shown);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.gridDetail, 0);
            this.Controls.SetChildIndex(this.cboHeader, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHeader;
        private ISA.Controls.CustomGridView gridDetail;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUraian;
    }
}
