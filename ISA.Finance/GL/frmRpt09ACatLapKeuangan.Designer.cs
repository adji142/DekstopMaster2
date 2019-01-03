namespace ISA.Finance.GL
{
    partial class frmRpt09ACatLapKeuangan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt09ACatLapKeuangan));
            this.label1 = new System.Windows.Forms.Label();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLabaRugiAkumulasi = new System.Windows.Forms.RadioButton();
            this.rbLabaRugi = new System.Windows.Forms.RadioButton();
            this.rbNeraca = new System.Windows.Forms.RadioButton();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Periode";
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(115, 59);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(278, 21);
            this.monthYearBox1.TabIndex = 0;
            this.monthYearBox1.Year = 2012;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kode Cabang";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(115, 101);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLabaRugiAkumulasi);
            this.groupBox1.Controls.Add(this.rbLabaRugi);
            this.groupBox1.Controls.Add(this.rbNeraca);
            this.groupBox1.Location = new System.Drawing.Point(28, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rbLabaRugiAkumulasi
            // 
            this.rbLabaRugiAkumulasi.AutoSize = true;
            this.rbLabaRugiAkumulasi.Location = new System.Drawing.Point(215, 38);
            this.rbLabaRugiAkumulasi.Name = "rbLabaRugiAkumulasi";
            this.rbLabaRugiAkumulasi.Size = new System.Drawing.Size(141, 18);
            this.rbLabaRugiAkumulasi.TabIndex = 2;
            this.rbLabaRugiAkumulasi.Text = "Laba-Rugi Akumulasi";
            this.rbLabaRugiAkumulasi.UseVisualStyleBackColor = true;
            // 
            // rbLabaRugi
            // 
            this.rbLabaRugi.AutoSize = true;
            this.rbLabaRugi.Location = new System.Drawing.Point(107, 38);
            this.rbLabaRugi.Name = "rbLabaRugi";
            this.rbLabaRugi.Size = new System.Drawing.Size(79, 18);
            this.rbLabaRugi.TabIndex = 1;
            this.rbLabaRugi.Text = "Laba-Rugi";
            this.rbLabaRugi.UseVisualStyleBackColor = true;
            // 
            // rbNeraca
            // 
            this.rbNeraca.AutoSize = true;
            this.rbNeraca.Checked = true;
            this.rbNeraca.Location = new System.Drawing.Point(6, 38);
            this.rbNeraca.Name = "rbNeraca";
            this.rbNeraca.Size = new System.Drawing.Size(62, 18);
            this.rbNeraca.TabIndex = 0;
            this.rbNeraca.TabStop = true;
            this.rbNeraca.Text = "Neraca";
            this.rbNeraca.UseVisualStyleBackColor = true;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(144, 322);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 2;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(293, 322);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRpt09ACatLapKeuangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(429, 383);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthYearBox1);
            this.Name = "frmRpt09ACatLapKeuangan";
            this.Text = "Catatan Atas Laporan Keuangan";
            this.Load += new System.EventHandler(this.frmRpt09ACatLapKeuangan_Load);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLabaRugiAkumulasi;
        private System.Windows.Forms.RadioButton rbLabaRugi;
        private System.Windows.Forms.RadioButton rbNeraca;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
    }
}
