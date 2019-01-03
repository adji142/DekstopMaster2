namespace ISA.Trading.Laporan.Salesman
{
    partial class frmRptPenyelesaianOrderSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPenyelesaianOrderSales));
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbSales = new System.Windows.Forms.RadioButton();
            this.rdbDO = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(74, 259);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 1;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(365, 259);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 2;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(170, 88);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tanggal";
            // 
            // rdbSales
            // 
            this.rdbSales.AutoSize = true;
            this.rdbSales.Location = new System.Drawing.Point(12, 40);
            this.rdbSales.Name = "rdbSales";
            this.rdbSales.Size = new System.Drawing.Size(114, 18);
            this.rdbSales.TabIndex = 9;
            this.rdbSales.TabStop = true;
            this.rdbSales.Text = "Rekap Per Sales";
            this.rdbSales.UseVisualStyleBackColor = true;
            // 
            // rdbDO
            // 
            this.rdbDO.AutoSize = true;
            this.rdbDO.Location = new System.Drawing.Point(12, 16);
            this.rdbDO.Name = "rdbDO";
            this.rdbDO.Size = new System.Drawing.Size(95, 18);
            this.rdbDO.TabIndex = 10;
            this.rdbDO.TabStop = true;
            this.rdbDO.Text = "Detail Per DO";
            this.rdbDO.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Model laporan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSales);
            this.groupBox1.Controls.Add(this.rdbDO);
            this.groupBox1.Location = new System.Drawing.Point(206, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 71);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            // 
            // frmRptPenyelesaianOrderSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(509, 335);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdNo);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptPenyelesaianOrderSales";
            this.Text = "Penyelesaian Order Sales";
            this.Title = "Penyelesaian Order Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptPenyelesaianOrderSales_Load);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbSales;
        private System.Windows.Forms.RadioButton rdbDO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
