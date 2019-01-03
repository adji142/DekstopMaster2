namespace ISA.Finance.GL
{
    partial class frmRpt02BukuBesar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt02BukuBesar));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.cmdOK = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.chkCetakSaldoNol = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lookupPerkiraan2 = new ISA.Finance.Controls.LookupPerkiraan();
            this.lookupPerkiraan1 = new ISA.Finance.Controls.LookupPerkiraan();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Periode";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(126, 28);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 1;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "No Perkiraan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kode Cabang";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(123, 166);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 4;
            // 
            // cmdOK
            // 
            this.cmdOK.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(249, 291);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 40);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "YES";
            this.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(430, 291);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // chkCetakSaldoNol
            // 
            this.chkCetakSaldoNol.AutoSize = true;
            this.chkCetakSaldoNol.Location = new System.Drawing.Point(126, 251);
            this.chkCetakSaldoNol.Name = "chkCetakSaldoNol";
            this.chkCetakSaldoNol.Size = new System.Drawing.Size(15, 14);
            this.chkCetakSaldoNol.TabIndex = 5;
            this.chkCetakSaldoNol.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cetak Saldo Nol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "S/D";
            // 
            // lookupPerkiraan2
            // 
            this.lookupPerkiraan2.Location = new System.Drawing.Point(466, 96);
            this.lookupPerkiraan2.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraan2.NamaPerkiraan = "";
            this.lookupPerkiraan2.Name = "lookupPerkiraan2";
            this.lookupPerkiraan2.NoPerkiraan = "[CODE]";
            this.lookupPerkiraan2.Size = new System.Drawing.Size(279, 47);
            this.lookupPerkiraan2.TabIndex = 3;
            // 
            // lookupPerkiraan1
            // 
            this.lookupPerkiraan1.Location = new System.Drawing.Point(126, 96);
            this.lookupPerkiraan1.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraan1.NamaPerkiraan = "";
            this.lookupPerkiraan1.Name = "lookupPerkiraan1";
            this.lookupPerkiraan1.NoPerkiraan = "[CODE]";
            this.lookupPerkiraan1.Size = new System.Drawing.Size(282, 47);
            this.lookupPerkiraan1.TabIndex = 2;
            // 
            // frmRpt02BukuBesar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(806, 359);
            this.Controls.Add(this.lookupPerkiraan1);
            this.Controls.Add(this.lookupPerkiraan2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkCetakSaldoNol);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label2);
            this.Name = "frmRpt02BukuBesar";
            this.Text = "02 Buku Besar";
            this.Load += new System.EventHandler(this.frmRpt02BukuBesar_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.chkCetakSaldoNol, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lookupPerkiraan2, 0);
            this.Controls.SetChildIndex(this.lookupPerkiraan1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.LookupGudang lookupGudang1;
        private ISA.Controls.CommandButton cmdOK;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.CheckBox chkCetakSaldoNol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private ISA.Finance.Controls.LookupPerkiraan lookupPerkiraan2;
        private ISA.Finance.Controls.LookupPerkiraan lookupPerkiraan1;
    }
}
