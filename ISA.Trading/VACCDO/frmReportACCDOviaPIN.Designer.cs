namespace ISA.Trading.VACCDO
{
    partial class frmReportACCDOviaPIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportACCDOviaPIN));
            this.rdTanggal = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYes = new ISA.Trading.Controls.CommandButton();
            this.cmbNo = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // rdTanggal
            // 
            this.rdTanggal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdTanggal.FromDate = null;
            this.rdTanggal.Location = new System.Drawing.Point(164, 91);
            this.rdTanggal.Name = "rdTanggal";
            this.rdTanggal.Size = new System.Drawing.Size(243, 25);
            this.rdTanggal.TabIndex = 5;
            this.rdTanggal.ToDate = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tgl DO";
            // 
            // cmbYes
            // 
            this.cmbYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmbYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmbYes.Image = ((System.Drawing.Image)(resources.GetObject("cmbYes.Image")));
            this.cmbYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbYes.Location = new System.Drawing.Point(132, 150);
            this.cmbYes.Name = "cmbYes";
            this.cmbYes.Size = new System.Drawing.Size(100, 40);
            this.cmbYes.TabIndex = 7;
            this.cmbYes.Text = "YES";
            this.cmbYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbYes.UseVisualStyleBackColor = true;
            this.cmbYes.Click += new System.EventHandler(this.cmbYes_Click);
            // 
            // cmbNo
            // 
            this.cmbNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmbNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmbNo.Image = ((System.Drawing.Image)(resources.GetObject("cmbNo.Image")));
            this.cmbNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbNo.Location = new System.Drawing.Point(283, 150);
            this.cmbNo.Name = "cmbNo";
            this.cmbNo.Size = new System.Drawing.Size(100, 40);
            this.cmbNo.TabIndex = 8;
            this.cmbNo.Text = "CANCEL";
            this.cmbNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbNo.UseVisualStyleBackColor = true;
            this.cmbNo.Click += new System.EventHandler(this.cmbNo_Click);
            // 
            // frmReportACCDOviaPIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 288);
            this.Controls.Add(this.cmbYes);
            this.Controls.Add(this.rdTanggal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNo);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmReportACCDOviaPIN";
            this.Text = "DO ACC Via PIN";
            this.Title = "DO ACC Via PIN";
            this.Load += new System.EventHandler(this.frmReportACCDOviaPIN_Load);
            this.Controls.SetChildIndex(this.cmbNo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rdTanggal, 0);
            this.Controls.SetChildIndex(this.cmbYes, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rdTanggal;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmbYes;
        private ISA.Trading.Controls.CommandButton cmbNo;
    }
}