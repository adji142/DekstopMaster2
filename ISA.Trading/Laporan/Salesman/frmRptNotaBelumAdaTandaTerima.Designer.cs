namespace ISA.Trading.Laporan.Salesman
{
    partial class frmRptNotaBelumAdaTandaTerima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptNotaBelumAdaTandaTerima));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.lookupPostArea = new ISA.Trading.Controls.LookupPostArea();
            this.lookupSales = new ISA.Trading.Controls.LookupSales();
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "Kode Sales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nama Salesman";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tanggal";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(91, 69);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // lookupPostArea
            // 
            this.lookupPostArea.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupPostArea.Location = new System.Drawing.Point(133, 179);
            this.lookupPostArea.Name = "lookupPostArea";
            this.lookupPostArea.PostID = "";
            this.lookupPostArea.PostName = null;
            this.lookupPostArea.Size = new System.Drawing.Size(200, 26);
            this.lookupPostArea.TabIndex = 2;
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(133, 105);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "";
            this.lookupSales.Size = new System.Drawing.Size(392, 54);
            this.lookupSales.TabIndex = 1;
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(495, 327);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 4;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(13, 327);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 3;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "Pos";
            // 
            // frmRptNotaBelumAdaTandaTerima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(606, 376);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.lookupPostArea);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptNotaBelumAdaTandaTerima";
            this.Text = "Nota Belum Ada Tanda Terima";
            this.Title = "Nota Belum Ada Tanda Terima";
            this.Load += new System.EventHandler(this.frmRptNotaBelumAdaTandaTerima_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.lookupPostArea, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private ISA.Trading.Controls.LookupPostArea lookupPostArea;
        private ISA.Trading.Controls.LookupSales lookupSales;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private System.Windows.Forms.Label label4;
    }
}
