namespace ISA.Trading.Laporan.Analisa
{
    partial class frmRptPerformanceSalesman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPerformanceSalesman));
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTgl = new ISA.Trading.Controls.RangeDateBox();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdYES = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 33;
            this.label1.Text = "Tanggal:";
            // 
            // rdbTgl
            // 
            this.rdbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl.FromDate = null;
            this.rdbTgl.Location = new System.Drawing.Point(130, 86);
            this.rdbTgl.Name = "rdbTgl";
            this.rdbTgl.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl.TabIndex = 32;
            this.rdbTgl.ToDate = null;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(222, 194);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.ReportName = "";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 35;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(113, 194);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.ReportName = "";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 34;
            this.cmdYES.Text = "PRINT";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // frmRptPerformanceSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(430, 264);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbTgl);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptPerformanceSalesman";
            this.Text = "Lap Performance Salesman";
            this.Title = "Lap Performance Salesman";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptPerformanceSalesman_Load);
            this.Controls.SetChildIndex(this.rdbTgl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rdbTgl;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdYES;
    }
}
