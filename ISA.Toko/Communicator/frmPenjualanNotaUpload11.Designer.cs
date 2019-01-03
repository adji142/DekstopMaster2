namespace ISA.Toko.Communicator
{
    partial class frmPenjualanNotaUpload11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenjualanNotaUpload11));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeNota = new ISA.Toko.Controls.RangeDateBox();
            this.gvUpload1 = new ISA.Toko.Controls.CustomGridView();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdUpload = new ISA.Toko.Controls.CommandButton();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            this.gvUpload2 = new ISA.Toko.Controls.CustomGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bgStatus = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbUpload2 = new System.Windows.Forms.ProgressBar();
            this.pbUpload1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gvUpload1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUpload2)).BeginInit();
            this.bgStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal Nota";
            // 
            // rangeNota
            // 
            this.rangeNota.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeNota.FromDate = null;
            this.rangeNota.Location = new System.Drawing.Point(123, 66);
            this.rangeNota.Name = "rangeNota";
            this.rangeNota.Size = new System.Drawing.Size(257, 22);
            this.rangeNota.TabIndex = 1;
            this.rangeNota.ToDate = null;
            // 
            // gvUpload1
            // 
            this.gvUpload1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvUpload1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUpload1.Location = new System.Drawing.Point(9, 124);
            this.gvUpload1.Name = "gvUpload1";
            this.gvUpload1.Size = new System.Drawing.Size(838, 184);
            this.gvUpload1.TabIndex = 7;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(747, 574);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Enabled = false;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(606, 574);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 3;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(371, 64);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 2;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // gvUpload2
            // 
            this.gvUpload2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvUpload2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUpload2.Location = new System.Drawing.Point(9, 334);
            this.gvUpload2.Name = "gvUpload2";
            this.gvUpload2.Size = new System.Drawing.Size(838, 184);
            this.gvUpload2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Htransj";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Dtransj";
            // 
            // bgStatus
            // 
            this.bgStatus.Controls.Add(this.label5);
            this.bgStatus.Controls.Add(this.label4);
            this.bgStatus.Controls.Add(this.pbUpload2);
            this.bgStatus.Controls.Add(this.pbUpload1);
            this.bgStatus.Location = new System.Drawing.Point(9, 524);
            this.bgStatus.Name = "bgStatus";
            this.bgStatus.Size = new System.Drawing.Size(586, 91);
            this.bgStatus.TabIndex = 19;
            this.bgStatus.TabStop = false;
            this.bgStatus.Text = "Upload Status";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "Htransj Uploaded";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Dtransj Uploaded";
            // 
            // pbUpload2
            // 
            this.pbUpload2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbUpload2.Location = new System.Drawing.Point(138, 56);
            this.pbUpload2.Name = "pbUpload2";
            this.pbUpload2.Size = new System.Drawing.Size(432, 23);
            this.pbUpload2.TabIndex = 19;
            // 
            // pbUpload1
            // 
            this.pbUpload1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbUpload1.Location = new System.Drawing.Point(138, 19);
            this.pbUpload1.Name = "pbUpload1";
            this.pbUpload1.Size = new System.Drawing.Size(432, 23);
            this.pbUpload1.TabIndex = 18;
            // 
            // frmPenjualanNotaUpload11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(856, 624);
            this.Controls.Add(this.bgStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvUpload2);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.rangeNota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.gvUpload1);
            this.Controls.Add(this.cmdUpload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenjualanNotaUpload11";
            this.Text = "Upload Nota ke 11";
            this.Title = "Upload Nota ke 11";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPenjualanNotaUpload11_Load);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.gvUpload1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeNota, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.gvUpload2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.bgStatus, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvUpload1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUpload2)).EndInit();
            this.bgStatus.ResumeLayout(false);
            this.bgStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rangeNota;
        private ISA.Toko.Controls.CustomGridView gvUpload1;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdUpload;
        private ISA.Toko.Controls.CommandButton cmdSearch;
        private ISA.Toko.Controls.CustomGridView gvUpload2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox bgStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbUpload2;
        private System.Windows.Forms.ProgressBar pbUpload1;
    }
}
