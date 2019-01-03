namespace ISA.Toko.Laporan.Salesman
{
    partial class frmRptEvaluasiOmzetPerSalesman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptEvaluasiOmzetPerSalesman));
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdNo = new ISA.Toko.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Toko.Controls.RangeDateBox();
            this.lookupSales = new ISA.Toko.Controls.LookupSales();
            this.lookupPostArea = new ISA.Toko.Controls.LookupPostArea();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDO = new System.Windows.Forms.RadioButton();
            this.rdbNota = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 404);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 3;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(598, 404);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 4;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(90, 68);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(126, 101);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "";
            this.lookupSales.Size = new System.Drawing.Size(392, 54);
            this.lookupSales.TabIndex = 1;
            this.lookupSales.Leave += new System.EventHandler(this.lookupSales_Leave);
            // 
            // lookupPostArea
            // 
            this.lookupPostArea.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupPostArea.Location = new System.Drawing.Point(126, 165);
            this.lookupPostArea.Name = "lookupPostArea";
            this.lookupPostArea.PostID = "";
            this.lookupPostArea.PostName = null;
            this.lookupPostArea.Size = new System.Drawing.Size(200, 26);
            this.lookupPostArea.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nama Sales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kode Sales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Pos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Berdasarkan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDO);
            this.groupBox1.Controls.Add(this.rdbNota);
            this.groupBox1.Location = new System.Drawing.Point(126, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 46);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // rdbDO
            // 
            this.rdbDO.AutoSize = true;
            this.rdbDO.Location = new System.Drawing.Point(6, 19);
            this.rdbDO.Name = "rdbDO";
            this.rdbDO.Size = new System.Drawing.Size(39, 18);
            this.rdbDO.TabIndex = 0;
            this.rdbDO.TabStop = true;
            this.rdbDO.Text = "DO";
            this.rdbDO.UseVisualStyleBackColor = true;
            // 
            // rdbNota
            // 
            this.rdbNota.AutoSize = true;
            this.rdbNota.Location = new System.Drawing.Point(60, 19);
            this.rdbNota.Name = "rdbNota";
            this.rdbNota.Size = new System.Drawing.Size(53, 18);
            this.rdbNota.TabIndex = 1;
            this.rdbNota.TabStop = true;
            this.rdbNota.Text = "Nota";
            this.rdbNota.UseVisualStyleBackColor = true;
            // 
            // frmRptEvaluasiOmzetPerSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 456);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupPostArea);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptEvaluasiOmzetPerSalesman";
            this.Text = "Evaluasi Omzet Per Sales";
            this.Title = "Evaluasi Omzet Per Sales";
            this.Load += new System.EventHandler(this.frmRptEvaluasiOmzetPerSalesman_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.lookupPostArea, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.RangeDateBox rangeDateBox1;
        private ISA.Toko.Controls.LookupSales lookupSales;
        private ISA.Toko.Controls.LookupPostArea lookupPostArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDO;
        private System.Windows.Forms.RadioButton rdbNota;
    }
}
