namespace ISA.Trading.Penjualan
{
    partial class frmLaporanInsentifSalesdanDenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanInsentifSalesdanDenda));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdProses = new ISA.Trading.Controls.CommandButton();
            this.rangePeriode = new ISA.Trading.Controls.RangeDateBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Periode Tanggal";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(290, 204);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdProses
            // 
            this.cmdProses.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdProses.Image = ((System.Drawing.Image)(resources.GetObject("cmdProses.Image")));
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(184, 204);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 12;
            this.cmdProses.Text = "YES";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // rangePeriode
            // 
            this.rangePeriode.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangePeriode.FromDate = null;
            this.rangePeriode.Location = new System.Drawing.Point(222, 94);
            this.rangePeriode.Name = "rangePeriode";
            this.rangePeriode.Size = new System.Drawing.Size(257, 22);
            this.rangePeriode.TabIndex = 10;
            this.rangePeriode.ToDate = null;
            // 
            // frmLaporanInsentifSalesdanDenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(572, 285);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProses);
            this.Controls.Add(this.rangePeriode);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanInsentifSalesdanDenda";
            this.Text = "Laporan Insentif Sales dan Denda";
            this.Title = "Laporan Insentif Sales dan Denda";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLaporanInsentifSalesdanDenda_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangePeriode, 0);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rangePeriode;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdProses;
    }
}
