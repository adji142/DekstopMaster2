namespace ISA.Trading.CommunicatorISA
{
    partial class frmUploadVcAccDOPos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadVcAccDOPos));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPOS = new ISA.Trading.Controls.CommonTextBox();
            this.gridVCAccDOPos = new ISA.Trading.Controls.CustomGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.cmdUpload = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridVCAccDOPos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal DO";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(133, 89);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Upload ACC POS";
            // 
            // txtPOS
            // 
            this.txtPOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPOS.Location = new System.Drawing.Point(133, 127);
            this.txtPOS.Name = "txtPOS";
            this.txtPOS.Size = new System.Drawing.Size(47, 20);
            this.txtPOS.TabIndex = 8;
            // 
            // gridVCAccDOPos
            // 
            this.gridVCAccDOPos.AllowUserToAddRows = false;
            this.gridVCAccDOPos.AllowUserToDeleteRows = false;
            this.gridVCAccDOPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVCAccDOPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVCAccDOPos.Location = new System.Drawing.Point(9, 164);
            this.gridVCAccDOPos.MultiSelect = false;
            this.gridVCAccDOPos.Name = "gridVCAccDOPos";
            this.gridVCAccDOPos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridVCAccDOPos.Size = new System.Drawing.Size(873, 333);
            this.gridVCAccDOPos.StandardTab = true;
            this.gridVCAccDOPos.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 503);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(873, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(782, 576);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchL;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(782, 108);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(100, 40);
            this.cmdSearch.TabIndex = 11;
            this.cmdSearch.Text = "SEARCH";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(9, 576);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 12;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // frmUploadVcAccDOPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(888, 628);
            this.Controls.Add(this.txtPOS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.gridVCAccDOPos);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.progressBar1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUploadVcAccDOPos";
            this.Text = "UPLOAD VACCDO POS";
            this.Title = "UPLOAD VACCDO POS";
            this.Load += new System.EventHandler(this.frmUploadVcAccDOPos_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.gridVCAccDOPos, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPOS, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridVCAccDOPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommonTextBox txtPOS;
        private ISA.Trading.Controls.CustomGridView gridVCAccDOPos;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private ISA.Trading.Controls.CommandButton cmdUpload;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
