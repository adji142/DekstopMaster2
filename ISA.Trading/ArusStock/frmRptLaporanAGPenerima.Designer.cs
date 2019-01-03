namespace ISA.Trading.ArusStock
{
    partial class frmRptLaporanAGPenerima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptLaporanAGPenerima));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.label3 = new System.Windows.Forms.Label();
            this.lookupGudang2 = new ISA.Controls.LookupGudang();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Periode Kirim";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(141, 72);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gudang Pengirim";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.InitPerusahaan = null;
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(141, 100);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gudang Penerima";
            // 
            // lookupGudang2
            // 
            this.lookupGudang2.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang2.GudangID = "[CODE]";
            this.lookupGudang2.InitPerusahaan = null;
            this.lookupGudang2.KodeCabang = null;
            this.lookupGudang2.Location = new System.Drawing.Point(141, 152);
            this.lookupGudang2.NamaGudang = "";
            this.lookupGudang2.Name = "lookupGudang2";
            this.lookupGudang2.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang2.TabIndex = 10;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(32, 236);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.ReportName = "";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 11;
            this.commandButton1.Text = "PRINT";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(310, 236);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.ReportName = "";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 12;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // frmRptLaporanAGPenerima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 312);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang2);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.rangeDateBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptLaporanAGPenerima";
            this.Text = "Laporan Pengiriman Antar Gudang";
            this.Title = "Laporan Pengiriman Antar Gudang";
            this.Load += new System.EventHandler(this.frmRptLaporanAGPenerima_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.lookupGudang2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.LookupGudang lookupGudang2;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton commandButton2;
    }
}