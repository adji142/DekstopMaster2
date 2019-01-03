namespace ISA.Trading.Penjualan
{
    partial class frmRptLaporanPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptLaporanPOS));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBoxPenjualan = new ISA.Trading.Controls.RangeDateBox();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.cmdPrint = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tanggal Penjualan";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rangeDateBoxPenjualan
            // 
            this.rangeDateBoxPenjualan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBoxPenjualan.FromDate = null;
            this.rangeDateBoxPenjualan.Location = new System.Drawing.Point(168, 88);
            this.rangeDateBoxPenjualan.Name = "rangeDateBoxPenjualan";
            this.rangeDateBoxPenjualan.Size = new System.Drawing.Size(255, 24);
            this.rangeDateBoxPenjualan.TabIndex = 10;
            this.rangeDateBoxPenjualan.ToDate = null;
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(266, 192);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.ReportName = "";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 13;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(93, 192);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.ReportName = "";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 14;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // frmRptLaporanPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 282);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBoxPenjualan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptLaporanPOS";
            this.Text = "Laporan POS";
            this.Title = "Laporan POS";
            this.Load += new System.EventHandler(this.frmRptLaporanPOS_Load);
            this.Controls.SetChildIndex(this.rangeDateBoxPenjualan, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBoxPenjualan;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private ISA.Trading.Controls.CommandButton cmdPrint;
    }
}