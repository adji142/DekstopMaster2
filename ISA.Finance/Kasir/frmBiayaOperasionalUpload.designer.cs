namespace ISA.Finance.Kasir
{
    partial class frmBiayaOperasionalUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiayaOperasionalUpload));
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewHeader = new ISA.Controls.CustomGridView();
            this.dataGridViewDetail = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(12, 27);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 80;
            this.cmdSearch.TabStop = false;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewHeader, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewDetail, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.81768F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.182321F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1084, 408);
            this.tableLayoutPanel2.TabIndex = 79;
            // 
            // dataGridViewHeader
            // 
            this.dataGridViewHeader.AllowUserToAddRows = false;
            this.dataGridViewHeader.AllowUserToDeleteRows = false;
            this.dataGridViewHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHeader.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewHeader.MultiSelect = false;
            this.dataGridViewHeader.Name = "dataGridViewHeader";
            this.dataGridViewHeader.ReadOnly = true;
            this.dataGridViewHeader.RowHeadersVisible = false;
            this.dataGridViewHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewHeader.Size = new System.Drawing.Size(1078, 162);
            this.dataGridViewHeader.StandardTab = true;
            this.dataGridViewHeader.TabIndex = 1;
            this.dataGridViewHeader.TabStop = false;
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(3, 184);
            this.dataGridViewDetail.MultiSelect = false;
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.RowHeadersVisible = false;
            this.dataGridViewDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewDetail.Size = new System.Drawing.Size(1078, 189);
            this.dataGridViewDetail.StandardTab = true;
            this.dataGridViewDetail.TabIndex = 2;
            this.dataGridViewDetail.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(997, 495);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 78;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Location = new System.Drawing.Point(12, 494);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(100, 40);
            this.cmdUpload.TabIndex = 77;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // frmBiayaOperasionalUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1108, 562);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdUpload);
            this.Name = "frmBiayaOperasionalUpload";
            this.Text = "Upload Biaya Operasional";
            this.Load += new System.EventHandler(this.frmBiayaOperasionalUpload_Load);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ISA.Controls.CustomGridView dataGridViewHeader;
        private ISA.Controls.CustomGridView dataGridViewDetail;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Button cmdUpload;
    }
}
