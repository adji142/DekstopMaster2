namespace ISA.Trading.Persediaan
{
    partial class frmRptStokTidakBergerak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptStokTidakBergerak));
            this.rdbTgl = new ISA.Controls.RangeDateBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbAG = new System.Windows.Forms.RadioButton();
            this.rbStok = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKlp = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbTgl
            // 
            this.rdbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl.FromDate = null;
            this.rdbTgl.Location = new System.Drawing.Point(141, 72);
            this.rdbTgl.Name = "rdbTgl";
            this.rdbTgl.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl.TabIndex = 0;
            this.rdbTgl.ToDate = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tanggal Penjualan";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbAG);
            this.panel1.Controls.Add(this.rbStok);
            this.panel1.Location = new System.Drawing.Point(178, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 54);
            this.panel1.TabIndex = 2;
            // 
            // rbAG
            // 
            this.rbAG.AutoSize = true;
            this.rbAG.Location = new System.Drawing.Point(8, 27);
            this.rbAG.Name = "rbAG";
            this.rbAG.Size = new System.Drawing.Size(155, 18);
            this.rbAG.TabIndex = 0;
            this.rbAG.TabStop = true;
            this.rbAG.Text = "Berdasarkan AG Terima";
            this.rbAG.UseVisualStyleBackColor = true;
            // 
            // rbStok
            // 
            this.rbStok.AutoSize = true;
            this.rbStok.Location = new System.Drawing.Point(8, 6);
            this.rbStok.Name = "rbStok";
            this.rbStok.Size = new System.Drawing.Size(149, 18);
            this.rbStok.TabIndex = 1;
            this.rbStok.TabStop = true;
            this.rbStok.Text = "Berdasarkan Data Stok";
            this.rbStok.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Model Laporan";
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(219, 253);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 4;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(113, 253);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 3;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Kelompok Barang";
            // 
            // cbKlp
            // 
            this.cbKlp.FormattingEnabled = true;
            this.cbKlp.Items.AddRange(new object[] {
            "FA2",
            "FA4",
            "FAB",
            "FB2",
            "FB4",
            "FC2",
            "FC4",
            "FE2",
            "FE4",
            "FX2",
            "FX4"});
            this.cbKlp.Location = new System.Drawing.Point(178, 105);
            this.cbKlp.Name = "cbKlp";
            this.cbKlp.Size = new System.Drawing.Size(81, 22);
            this.cbKlp.TabIndex = 1;
            // 
            // frmRptStokTidakBergerak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(418, 321);
            this.Controls.Add(this.cbKlp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdbTgl);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptStokTidakBergerak";
            this.Text = "Laporan Stok tidak Bergerak";
            this.Title = "Laporan Stok tidak Bergerak";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptStokTidakBergerak_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.rdbTgl, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbKlp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Controls.RangeDateBox rdbTgl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbAG;
        private System.Windows.Forms.RadioButton rbStok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbKlp;

    }
}
