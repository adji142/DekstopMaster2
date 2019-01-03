namespace ISA.Trading.PSReport
{
    partial class frmLaporanAnalisaOA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanAnalisaOA));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.cmbOK = new ISA.Trading.Controls.CommandButton();
            this.cmbclose = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Periode Laporan";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(149, 88);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmbOK
            // 
            this.cmbOK.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmbOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmbOK.Image = ((System.Drawing.Image)(resources.GetObject("cmbOK.Image")));
            this.cmbOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbOK.Location = new System.Drawing.Point(45, 156);
            this.cmbOK.Name = "cmbOK";
            this.cmbOK.Size = new System.Drawing.Size(100, 40);
            this.cmbOK.TabIndex = 7;
            this.cmbOK.Text = "YES";
            this.cmbOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbOK.UseVisualStyleBackColor = true;
            this.cmbOK.Click += new System.EventHandler(this.cmbOK_Click);
            // 
            // cmbclose
            // 
            this.cmbclose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmbclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmbclose.Image = ((System.Drawing.Image)(resources.GetObject("cmbclose.Image")));
            this.cmbclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbclose.Location = new System.Drawing.Point(306, 155);
            this.cmbclose.Name = "cmbclose";
            this.cmbclose.Size = new System.Drawing.Size(100, 40);
            this.cmbclose.TabIndex = 8;
            this.cmbclose.Text = "CLOSE";
            this.cmbclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbclose.UseVisualStyleBackColor = true;
            this.cmbclose.Click += new System.EventHandler(this.cmbclose_Click);
            // 
            // frmLaporanAnalisaOA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 218);
            this.Controls.Add(this.cmbclose);
            this.Controls.Add(this.cmbOK);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanAnalisaOA";
            this.Text = "Laporan Analisa OA";
            this.Title = "Laporan Analisa OA";
            this.Load += new System.EventHandler(this.frmLaporanAnalisaOA_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmbOK, 0);
            this.Controls.SetChildIndex(this.cmbclose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private ISA.Trading.Controls.CommandButton cmbOK;
        private ISA.Trading.Controls.CommandButton cmbclose;
    }
}