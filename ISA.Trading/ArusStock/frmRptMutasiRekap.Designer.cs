namespace ISA.Trading.ArusStock
{
    partial class frmRptMutasiRekap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptMutasiRekap));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.lookupGudang1 = new ISA.Trading.Controls.LookupGudang();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tanggal Mutasi";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(124, 66);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(239, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            this.rangeDateBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangeDateBox1_KeyPress);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(31, 350);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 1;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(458, 350);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "";
            this.lookupGudang1.InitPerusahaan = null;
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(148, 119);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 10;
            this.lookupGudang1.Validated += new System.EventHandler(this.lookupGudang1_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Gudang";
            // 
            // frmRptMutasiRekap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(588, 406);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptMutasiRekap";
            this.Text = "Rekap Mutasi";
            this.Title = "Rekap Mutasi";
            this.Load += new System.EventHandler(this.frmRptRekapMutasi_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.Label label2;
    }
}
