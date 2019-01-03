namespace ISA.Trading.Expedisi
{
    partial class frmRptBuktiPenyerahanBarang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptBuktiPenyerahanBarang));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoShift1 = new System.Windows.Forms.RadioButton();
            this.rdoShift2 = new System.Windows.Forms.RadioButton();
            this.cmdShow = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal Nota";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(126, 65);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Shift";
            // 
            // rdoShift1
            // 
            this.rdoShift1.AutoSize = true;
            this.rdoShift1.Location = new System.Drawing.Point(134, 99);
            this.rdoShift1.Name = "rdoShift1";
            this.rdoShift1.Size = new System.Drawing.Size(74, 18);
            this.rdoShift1.TabIndex = 0;
            this.rdoShift1.TabStop = true;
            this.rdoShift1.Text = "Shift 1";
            this.rdoShift1.UseVisualStyleBackColor = true;
            // 
            // rdoShift2
            // 
            this.rdoShift2.AutoSize = true;
            this.rdoShift2.Location = new System.Drawing.Point(205, 99);
            this.rdoShift2.Name = "rdoShift2";
            this.rdoShift2.Size = new System.Drawing.Size(74, 18);
            this.rdoShift2.TabIndex = 1;
            this.rdoShift2.TabStop = true;
            this.rdoShift2.Text = "Shift 2";
            this.rdoShift2.UseVisualStyleBackColor = true;
            // 
            // cmdShow
            // 
            this.cmdShow.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdShow.Image = ((System.Drawing.Image)(resources.GetObject("cmdShow.Image")));
            this.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShow.Location = new System.Drawing.Point(134, 138);
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
            this.cmdClose.Location = new System.Drawing.Point(258, 138);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRptBuktiPenyerahanBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.rdoShift1);
            this.Controls.Add(this.rdoShift2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptBuktiPenyerahanBarang";
            this.Text = "Laporan Bukti Penyerahan Barang";
            this.Title = "Laporan Bukti Penyerahan Barang";
            this.Load += new System.EventHandler(this.frmRptBuktiPenyerahanBarang_Load);
            this.Controls.SetChildIndex(this.rdoShift2, 0);
            this.Controls.SetChildIndex(this.rdoShift1, 0);
            this.Controls.SetChildIndex(this.cmdShow, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoShift1;
        private System.Windows.Forms.RadioButton rdoShift2;
        private ISA.Trading.Controls.CommandButton cmdShow;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
