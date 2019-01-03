namespace ISA.Trading.Laporan.Analisa
{
    partial class frmRptAnalisaABE_BengkeldanPos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAnalisaABE_BengkeldanPos));
            this.rangeOmzet = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdProses = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // rangeOmzet
            // 
            this.rangeOmzet.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeOmzet.FromDate = null;
            this.rangeOmzet.Location = new System.Drawing.Point(116, 94);
            this.rangeOmzet.Name = "rangeOmzet";
            this.rangeOmzet.Size = new System.Drawing.Size(257, 22);
            this.rangeOmzet.TabIndex = 6;
            this.rangeOmzet.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tanggal";
            // 
            // cmdProses
            // 
            this.cmdProses.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdProses.Image = ((System.Drawing.Image)(resources.GetObject("cmdProses.Image")));
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(106, 198);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.ReportName = "";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 8;
            this.cmdProses.Text = "PRINT";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(212, 198);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRptAnalisaABE_BengkeldanPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(412, 265);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProses);
            this.Controls.Add(this.rangeOmzet);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptAnalisaABE_BengkeldanPos";
            this.Text = "Laporan ABE Bengkel dan POS";
            this.Title = "Laporan ABE Bengkel dan POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptAnalisaABE_BengkeldanPos_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeOmzet, 0);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rangeOmzet;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdProses;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
