namespace ISA.Toko.Penjualan
{
    partial class frmRptLaporanPerbarangNetto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptLaporanPerbarangNetto));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBoxPenjualan = new ISA.Toko.Controls.RangeDateBox();
            this.commandButton2 = new ISA.Toko.Controls.CommandButton();
            this.cmdyes = new ISA.Toko.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tanggal Penjualan";
            // 
            // rangeDateBoxPenjualan
            // 
            this.rangeDateBoxPenjualan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBoxPenjualan.FromDate = null;
            this.rangeDateBoxPenjualan.Location = new System.Drawing.Point(177, 84);
            this.rangeDateBoxPenjualan.Name = "rangeDateBoxPenjualan";
            this.rangeDateBoxPenjualan.Size = new System.Drawing.Size(255, 24);
            this.rangeDateBoxPenjualan.TabIndex = 14;
            this.rangeDateBoxPenjualan.ToDate = null;
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(348, 169);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 17;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // cmdyes
            // 
            this.cmdyes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdyes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdyes.Image = ((System.Drawing.Image)(resources.GetObject("cmdyes.Image")));
            this.cmdyes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdyes.Location = new System.Drawing.Point(12, 169);
            this.cmdyes.Name = "cmdyes";
            this.cmdyes.Size = new System.Drawing.Size(100, 40);
            this.cmdyes.TabIndex = 16;
            this.cmdyes.Text = "YES";
            this.cmdyes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdyes.UseVisualStyleBackColor = true;
            this.cmdyes.Click += new System.EventHandler(this.cmdyes_Click);
            // 
            // frmRptLaporanPerbarangNetto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 282);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.cmdyes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBoxPenjualan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptLaporanPerbarangNetto";
            this.Text = "Laporan Perbarang Netto";
            this.Title = "Laporan Perbarang Netto";
            this.Load += new System.EventHandler(this.frmRptLaporanPerbarangNetto_Load);
            this.Controls.SetChildIndex(this.rangeDateBoxPenjualan, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdyes, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton commandButton2;
        private ISA.Toko.Controls.CommandButton cmdyes;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rangeDateBoxPenjualan;
    }
}