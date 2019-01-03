namespace ISA.Trading.Penjualan
{
    partial class frmLaporanAccOverdue
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
            this.cmdProses = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdProses
            // 
            this.cmdProses.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProses.Image = global::ISA.Trading.Properties.Resources.Ok32;
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(130, 191);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(104, 40);
            this.cmdProses.TabIndex = 5;
            this.cmdProses.Text = "      PROSES";
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = global::ISA.Trading.Properties.Resources.Close32;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(240, 191);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(104, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "       CLOSE";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Periode";
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(144, 87);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 22);
            this.cboMonth.TabIndex = 28;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(319, 89);
            this.txtYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYear.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(59, 20);
            this.txtYear.TabIndex = 30;
            this.txtYear.Value = new decimal(new int[] {
            2012,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tahun";
            // 
            // frmLaporanAccOverdue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(466, 259);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProses);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanAccOverdue";
            this.Text = "Laporan History Acc Overdue";
            this.Title = "Laporan History Acc Overdue";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLaporanAccOverdue_Load);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtYear, 0);
            this.Controls.SetChildIndex(this.cboMonth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdProses;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.NumericUpDown txtYear;
        private System.Windows.Forms.Label label2;
    }
}
