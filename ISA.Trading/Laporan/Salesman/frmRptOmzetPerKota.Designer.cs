namespace ISA.Trading.Laporan.Salesman
{
    partial class frmRptOmzetPerKota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOmzetPerKota));
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCab = new ISA.Trading.Controls.CabangComboBox();
            this.lookupGudang1 = new ISA.Trading.Controls.LookupGudang();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 285);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 4;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(363, 285);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 4;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(80, 66);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tanggal";
            // 
            // cboKel
            // 
            this.cboKel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKel.FormattingEnabled = true;
            this.cboKel.Location = new System.Drawing.Point(118, 108);
            this.cboKel.Name = "cboKel";
            this.cboKel.Size = new System.Drawing.Size(99, 22);
            this.cboKel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kelompok";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cabang";
            // 
            // cboCab
            // 
            this.cboCab.CabangID = "";
            this.cboCab.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboCab.DisplayMember = "Concatenated";
            this.cboCab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCab.Font = new System.Drawing.Font("Courier New", 8F);
            this.cboCab.FormattingEnabled = true;
            this.cboCab.Location = new System.Drawing.Point(118, 155);
            this.cboCab.Name = "cboCab";
            this.cboCab.Size = new System.Drawing.Size(180, 22);
            this.cboCab.TabIndex = 2;
            this.cboCab.ValueMember = "CabangID";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "";
            this.lookupGudang1.InitPerusahaan = null;
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(118, 194);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Gudang";
            // 
            // frmRptOmzetPerKota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(475, 337);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.cboCab);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboKel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.rangeDateBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptOmzetPerKota";
            this.Text = "Omzet per Kota";
            this.Title = "Omzet per Kota";
            this.Load += new System.EventHandler(this.OmzetPerKota_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboKel, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboCab, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.CabangComboBox cboCab;
        private ISA.Trading.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.Label label2;
    }
}
