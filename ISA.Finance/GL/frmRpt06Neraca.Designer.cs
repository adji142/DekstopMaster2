namespace ISA.Finance.GL
{
    partial class frmRpt06Neraca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt06Neraca));
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdOk = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(115, 24);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(250, 21);
            this.monthYearBox1.TabIndex = 3;
            this.monthYearBox1.Year = 2012;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kode Cabang";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(110, 60);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 6;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(290, 169);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOk.Image = ((System.Drawing.Image)(resources.GetObject("cmdOk.Image")));
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(164, 169);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(100, 40);
            this.cmdOk.TabIndex = 7;
            this.cmdOk.Text = "YES";
            this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmRpt06Neraca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(402, 221);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.monthYearBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOk);
            this.Name = "frmRpt06Neraca";
            this.Text = "GL06 Neraca";
            this.Load += new System.EventHandler(this.frmRpt06LabaRugi_Load);
            this.Controls.SetChildIndex(this.cmdOk, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.LookupGudang lookupGudang1;
        private ISA.Controls.CommandButton cmdOk;
        private ISA.Controls.CommandButton cmdClose;
    }
}
