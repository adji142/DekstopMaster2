namespace ISA.Trading.Expedisi
{
    partial class frmRptRekapExpedisiFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRekapExpedisiFilter));
            this.rgbTglSuratJalan = new ISA.Trading.Controls.RangeDateBox();
            this.cmdShow = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rgbTglSuratJalan
            // 
            this.rgbTglSuratJalan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglSuratJalan.FromDate = null;
            this.rgbTglSuratJalan.Location = new System.Drawing.Point(43, 96);
            this.rgbTglSuratJalan.Name = "rgbTglSuratJalan";
            this.rgbTglSuratJalan.Size = new System.Drawing.Size(257, 22);
            this.rgbTglSuratJalan.TabIndex = 0;
            this.rgbTglSuratJalan.ToDate = null;
            // 
            // cmdShow
            // 
            this.cmdShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdShow.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdShow.Image = ((System.Drawing.Image)(resources.GetObject("cmdShow.Image")));
            this.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShow.Location = new System.Drawing.Point(12, 171);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(100, 40);
            this.cmdShow.TabIndex = 1;
            this.cmdShow.Text = "YES";
            this.cmdShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(217, 171);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 14);
            this.label2.TabIndex = 31;
            this.label2.Text = "Tanggal Surat Jalan:";
            // 
            // frmRptRekapExpedisiFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(329, 223);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rgbTglSuratJalan);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptRekapExpedisiFilter";
            this.Text = "Laporan Rekap Ekspedisi";
            this.Title = "Laporan Rekap Ekspedisi";
            this.Load += new System.EventHandler(this.frmRptRekapExpedisiFilter_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdShow, 0);
            this.Controls.SetChildIndex(this.rgbTglSuratJalan, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rgbTglSuratJalan;
        private ISA.Trading.Controls.CommandButton cmdShow;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
    }
}
