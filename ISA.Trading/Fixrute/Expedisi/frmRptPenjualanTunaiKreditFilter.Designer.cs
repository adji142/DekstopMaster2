namespace ISA.Trading.Expedisi
{
    partial class frmRptPenjualanTunaiKreditFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPenjualanTunaiKreditFilter));
            this.rgbTglSuratJalan = new ISA.Trading.Controls.RangeDateBox();
            this.rdoKredit = new System.Windows.Forms.RadioButton();
            this.rdoTunai = new System.Windows.Forms.RadioButton();
            this.rdoKreditTunai = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoShift1 = new System.Windows.Forms.RadioButton();
            this.rdoShift2 = new System.Windows.Forms.RadioButton();
            this.rdoSemuaShift = new System.Windows.Forms.RadioButton();
            this.cmdShow = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgbTglSuratJalan
            // 
            this.rgbTglSuratJalan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTglSuratJalan.FromDate = null;
            this.rgbTglSuratJalan.Location = new System.Drawing.Point(148, 66);
            this.rgbTglSuratJalan.Name = "rgbTglSuratJalan";
            this.rgbTglSuratJalan.Size = new System.Drawing.Size(257, 22);
            this.rgbTglSuratJalan.TabIndex = 0;
            this.rgbTglSuratJalan.ToDate = null;
            // 
            // rdoKredit
            // 
            this.rdoKredit.AutoSize = true;
            this.rdoKredit.Location = new System.Drawing.Point(7, 24);
            this.rdoKredit.Name = "rdoKredit";
            this.rdoKredit.Size = new System.Drawing.Size(67, 18);
            this.rdoKredit.TabIndex = 0;
            this.rdoKredit.TabStop = true;
            this.rdoKredit.Text = "Kredit";
            this.rdoKredit.UseVisualStyleBackColor = true;
            // 
            // rdoTunai
            // 
            this.rdoTunai.AutoSize = true;
            this.rdoTunai.Location = new System.Drawing.Point(113, 24);
            this.rdoTunai.Name = "rdoTunai";
            this.rdoTunai.Size = new System.Drawing.Size(60, 18);
            this.rdoTunai.TabIndex = 1;
            this.rdoTunai.TabStop = true;
            this.rdoTunai.Text = "Tunai";
            this.rdoTunai.UseVisualStyleBackColor = true;
            // 
            // rdoKreditTunai
            // 
            this.rdoKreditTunai.AutoSize = true;
            this.rdoKreditTunai.Location = new System.Drawing.Point(219, 24);
            this.rdoKreditTunai.Name = "rdoKreditTunai";
            this.rdoKreditTunai.Size = new System.Drawing.Size(60, 18);
            this.rdoKreditTunai.TabIndex = 2;
            this.rdoKreditTunai.TabStop = true;
            this.rdoKreditTunai.Text = "Semua";
            this.rdoKreditTunai.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoKredit);
            this.groupBox1.Controls.Add(this.rdoTunai);
            this.groupBox1.Controls.Add(this.rdoKreditTunai);
            this.groupBox1.Location = new System.Drawing.Point(31, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 48);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kredit / Tunai";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoShift1);
            this.groupBox2.Controls.Add(this.rdoShift2);
            this.groupBox2.Controls.Add(this.rdoSemuaShift);
            this.groupBox2.Location = new System.Drawing.Point(31, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 48);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shift";
            // 
            // rdoShift1
            // 
            this.rdoShift1.AutoSize = true;
            this.rdoShift1.Location = new System.Drawing.Point(7, 24);
            this.rdoShift1.Name = "rdoShift1";
            this.rdoShift1.Size = new System.Drawing.Size(67, 18);
            this.rdoShift1.TabIndex = 0;
            this.rdoShift1.TabStop = true;
            this.rdoShift1.Text = "Shift1";
            this.rdoShift1.UseVisualStyleBackColor = true;
            // 
            // rdoShift2
            // 
            this.rdoShift2.AutoSize = true;
            this.rdoShift2.Location = new System.Drawing.Point(113, 24);
            this.rdoShift2.Name = "rdoShift2";
            this.rdoShift2.Size = new System.Drawing.Size(67, 18);
            this.rdoShift2.TabIndex = 1;
            this.rdoShift2.TabStop = true;
            this.rdoShift2.Text = "Shift2";
            this.rdoShift2.UseVisualStyleBackColor = true;
            // 
            // rdoSemuaShift
            // 
            this.rdoSemuaShift.AutoSize = true;
            this.rdoSemuaShift.Location = new System.Drawing.Point(219, 24);
            this.rdoSemuaShift.Name = "rdoSemuaShift";
            this.rdoSemuaShift.Size = new System.Drawing.Size(60, 18);
            this.rdoSemuaShift.TabIndex = 2;
            this.rdoSemuaShift.TabStop = true;
            this.rdoSemuaShift.Text = "Semua";
            this.rdoSemuaShift.UseVisualStyleBackColor = true;
            // 
            // cmdShow
            // 
            this.cmdShow.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdShow.Image = ((System.Drawing.Image)(resources.GetObject("cmdShow.Image")));
            this.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShow.Location = new System.Drawing.Point(31, 240);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(117, 43);
            this.cmdShow.TabIndex = 1;
            this.cmdShow.Text = "YES";
            this.cmdShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(155, 240);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tanggal Surat Jalan:";
            // 
            // frmRptPenjualanTunaiKreditFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(414, 296);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rgbTglSuratJalan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptPenjualanTunaiKreditFilter";
            this.Text = "Laporan Penjualan Tunai/Kredit";
            this.Title = "Laporan Penjualan Tunai/Kredit";
            this.Load += new System.EventHandler(this.frmRptPenjualanTunaiKreditFilter_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdShow, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rgbTglSuratJalan, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rgbTglSuratJalan;
        private ISA.Trading.Controls.CommandButton cmdShow;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.RadioButton rdoKredit;
        private System.Windows.Forms.RadioButton rdoTunai;
        private System.Windows.Forms.RadioButton rdoKreditTunai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoShift1;
        private System.Windows.Forms.RadioButton rdoShift2;
        private System.Windows.Forms.RadioButton rdoSemuaShift;
        private System.Windows.Forms.Label label1;
    }
}
