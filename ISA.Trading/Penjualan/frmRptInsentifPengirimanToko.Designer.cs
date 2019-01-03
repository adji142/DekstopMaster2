namespace ISA.Trading.Penjualan
{
    partial class frmRptInsentifPengirimanToko
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptInsentifPengirimanToko));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.rdbTanggal = new ISA.Trading.Controls.RangeDateBox();
            this.cmdPrint = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Periode";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(246, 194);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // rdbTanggal
            // 
            this.rdbTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTanggal.FromDate = null;
            this.rdbTanggal.Location = new System.Drawing.Point(154, 86);
            this.rdbTanggal.Name = "rdbTanggal";
            this.rdbTanggal.Size = new System.Drawing.Size(257, 22);
            this.rdbTanggal.TabIndex = 7;
            this.rdbTanggal.ToDate = null;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(131, 194);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.ReportName = "";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 11;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // frmRptInsentifPengirimanToko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(479, 269);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbTanggal);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptInsentifPengirimanToko";
            this.Text = "Laporan Insentif Pengiriman Toko";
            this.Title = "Laporan Insentif Pengiriman Toko";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptInsentifPengirimanToko_Load);
            this.Controls.SetChildIndex(this.rdbTanggal, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rdbTanggal;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdPrint;
    }
}
