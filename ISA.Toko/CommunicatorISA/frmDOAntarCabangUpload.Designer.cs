namespace ISA.Toko.CommunicatorISA
{
    partial class frmDOAntarCabangUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDOAntarCabangUpload));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Toko.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.gridViewNotaPembelianDetail = new ISA.Toko.Controls.CustomGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pbUpload2 = new System.Windows.Forms.ProgressBar();
            this.gridViewNotaPembelian = new ISA.Toko.Controls.CustomGridView();
            this.pbUpload1 = new System.Windows.Forms.ProgressBar();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdUpload = new ISA.Toko.Controls.CommandButton();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotaPembelianDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotaPembelian)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal DO";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(102, 87);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ke Gudang";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.InitPerusahaan = null;
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(102, 130);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.gridViewNotaPembelianDetail, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbUpload2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.gridViewNotaPembelian, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbUpload1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 178);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.79812F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.20188F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 413);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Order Penjualan Detail";
            // 
            // gridViewNotaPembelianDetail
            // 
            this.gridViewNotaPembelianDetail.AllowUserToAddRows = false;
            this.gridViewNotaPembelianDetail.AllowUserToDeleteRows = false;
            this.gridViewNotaPembelianDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewNotaPembelianDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridViewNotaPembelianDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewNotaPembelianDetail.Location = new System.Drawing.Point(3, 230);
            this.gridViewNotaPembelianDetail.MultiSelect = false;
            this.gridViewNotaPembelianDetail.Name = "gridViewNotaPembelianDetail";
            this.gridViewNotaPembelianDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridViewNotaPembelianDetail.Size = new System.Drawing.Size(857, 153);
            this.gridViewNotaPembelianDetail.StandardTab = true;
            this.gridViewNotaPembelianDetail.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Order Penjualan";
            // 
            // pbUpload2
            // 
            this.pbUpload2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUpload2.Location = new System.Drawing.Point(3, 389);
            this.pbUpload2.Name = "pbUpload2";
            this.pbUpload2.Size = new System.Drawing.Size(857, 21);
            this.pbUpload2.TabIndex = 3;
            // 
            // gridViewNotaPembelian
            // 
            this.gridViewNotaPembelian.AllowUserToAddRows = false;
            this.gridViewNotaPembelian.AllowUserToDeleteRows = false;
            this.gridViewNotaPembelian.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewNotaPembelian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridViewNotaPembelian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewNotaPembelian.Location = new System.Drawing.Point(3, 21);
            this.gridViewNotaPembelian.MultiSelect = false;
            this.gridViewNotaPembelian.Name = "gridViewNotaPembelian";
            this.gridViewNotaPembelian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridViewNotaPembelian.Size = new System.Drawing.Size(857, 149);
            this.gridViewNotaPembelian.StandardTab = true;
            this.gridViewNotaPembelian.TabIndex = 0;
            // 
            // pbUpload1
            // 
            this.pbUpload1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUpload1.Location = new System.Drawing.Point(3, 176);
            this.pbUpload1.Name = "pbUpload1";
            this.pbUpload1.Size = new System.Drawing.Size(857, 25);
            this.pbUpload1.TabIndex = 2;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(772, 612);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(9, 612);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 12;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchL;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(766, 104);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(100, 40);
            this.cmdSearch.TabIndex = 10;
            this.cmdSearch.Text = "SEARCH";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // frmDOAntarCabangUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(878, 677);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDOAntarCabangUpload";
            this.Text = "Upload DO Antar Cabang";
            this.Title = "Upload DO Antar Cabang";
            this.Load += new System.EventHandler(this.frmDOAntarCabangUpload_Load);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotaPembelianDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotaPembelian)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Toko.Controls.CustomGridView gridViewNotaPembelian;
        private ISA.Toko.Controls.CustomGridView gridViewNotaPembelianDetail;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.ProgressBar pbUpload1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbUpload2;
        private ISA.Toko.Controls.CommandButton cmdUpload;
        private ISA.Toko.Controls.CommandButton cmdClose;
    }
}
