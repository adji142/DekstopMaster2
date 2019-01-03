namespace ISA.Trading.Expedisi
{
    partial class frmRptExpDalamKotaFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptExpDalamKotaFilter));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoShift1 = new System.Windows.Forms.RadioButton();
            this.rdoShift2 = new System.Windows.Forms.RadioButton();
            this.rdoSemuaShift = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoKantor = new System.Windows.Forms.RadioButton();
            this.rdoGudang = new System.Windows.Forms.RadioButton();
            this.rdoKantorGudang = new System.Windows.Forms.RadioButton();
            this.rdbTglSuratJalan = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdShow = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoShift1);
            this.groupBox2.Controls.Add(this.rdoShift2);
            this.groupBox2.Controls.Add(this.rdoSemuaShift);
            this.groupBox2.Location = new System.Drawing.Point(31, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 48);
            this.groupBox2.TabIndex = 26;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoKantor);
            this.groupBox1.Controls.Add(this.rdoGudang);
            this.groupBox1.Controls.Add(this.rdoKantorGudang);
            this.groupBox1.Location = new System.Drawing.Point(31, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 48);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kredit / Tunai";
            // 
            // rdoKantor
            // 
            this.rdoKantor.AutoSize = true;
            this.rdoKantor.Location = new System.Drawing.Point(7, 24);
            this.rdoKantor.Name = "rdoKantor";
            this.rdoKantor.Size = new System.Drawing.Size(67, 18);
            this.rdoKantor.TabIndex = 0;
            this.rdoKantor.TabStop = true;
            this.rdoKantor.Text = "Kantor";
            this.rdoKantor.UseVisualStyleBackColor = true;
            // 
            // rdoGudang
            // 
            this.rdoGudang.AutoSize = true;
            this.rdoGudang.Location = new System.Drawing.Point(113, 24);
            this.rdoGudang.Name = "rdoGudang";
            this.rdoGudang.Size = new System.Drawing.Size(67, 18);
            this.rdoGudang.TabIndex = 1;
            this.rdoGudang.TabStop = true;
            this.rdoGudang.Text = "Gudang";
            this.rdoGudang.UseVisualStyleBackColor = true;
            // 
            // rdoKantorGudang
            // 
            this.rdoKantorGudang.AutoSize = true;
            this.rdoKantorGudang.Location = new System.Drawing.Point(219, 24);
            this.rdoKantorGudang.Name = "rdoKantorGudang";
            this.rdoKantorGudang.Size = new System.Drawing.Size(60, 18);
            this.rdoKantorGudang.TabIndex = 2;
            this.rdoKantorGudang.TabStop = true;
            this.rdoKantorGudang.Text = "Semua";
            this.rdoKantorGudang.UseVisualStyleBackColor = true;
            // 
            // rdbTglSuratJalan
            // 
            this.rdbTglSuratJalan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTglSuratJalan.FromDate = null;
            this.rdbTglSuratJalan.Location = new System.Drawing.Point(126, 66);
            this.rdbTglSuratJalan.Name = "rdbTglSuratJalan";
            this.rdbTglSuratJalan.Size = new System.Drawing.Size(257, 22);
            this.rdbTglSuratJalan.TabIndex = 0;
            this.rdbTglSuratJalan.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tanggal Kirim:";
            // 
            // cmdShow
            // 
            this.cmdShow.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdShow.Image = ((System.Drawing.Image)(resources.GetObject("cmdShow.Image")));
            this.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShow.Location = new System.Drawing.Point(31, 246);
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
            this.cmdClose.Location = new System.Drawing.Point(155, 246);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRptExpDalamKotaFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(444, 302);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rdbTglSuratJalan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptExpDalamKotaFilter";
            this.Text = "Laporan Form Ekspedisi Dalam Kota";
            this.Title = "Laporan Form Ekspedisi Dalam Kota";
            this.Load += new System.EventHandler(this.frmRptExpDalamKotaFilter_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdShow, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rdbTglSuratJalan, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoShift1;
        private System.Windows.Forms.RadioButton rdoShift2;
        private System.Windows.Forms.RadioButton rdoSemuaShift;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoKantor;
        private System.Windows.Forms.RadioButton rdoGudang;
        private System.Windows.Forms.RadioButton rdoKantorGudang;
        private ISA.Trading.Controls.RangeDateBox rdbTglSuratJalan;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdShow;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
