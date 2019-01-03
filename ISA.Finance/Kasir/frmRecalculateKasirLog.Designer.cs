namespace ISA.Finance.Kasir
{
    partial class frmRecalculateKasirLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecalculateKasirLog));
            this.label1 = new System.Windows.Forms.Label();
            this.tbFromDate = new ISA.Controls.DateTextBox();
            this.tbToDate = new ISA.Controls.DateTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tanggal";
            // 
            // tbFromDate
            // 
            this.tbFromDate.DateValue = null;
            this.tbFromDate.Location = new System.Drawing.Point(102, 25);
            this.tbFromDate.MaxLength = 10;
            this.tbFromDate.Name = "tbFromDate";
            this.tbFromDate.Size = new System.Drawing.Size(80, 20);
            this.tbFromDate.TabIndex = 0;
            // 
            // tbToDate
            // 
            this.tbToDate.DateValue = null;
            this.tbToDate.Enabled = false;
            this.tbToDate.Location = new System.Drawing.Point(240, 25);
            this.tbToDate.MaxLength = 10;
            this.tbToDate.Name = "tbToDate";
            this.tbToDate.Size = new System.Drawing.Size(80, 20);
            this.tbToDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "S/D";
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(82, 87);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 1;
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
            this.cmdClose.Location = new System.Drawing.Point(188, 87);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRecalculateKasirLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(361, 157);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbToDate);
            this.Controls.Add(this.tbFromDate);
            this.Controls.Add(this.label1);
            this.Name = "frmRecalculateKasirLog";
            this.Text = "Recalculate KasirLog";
            this.Load += new System.EventHandler(this.frmRecalculateKasirLog_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbFromDate, 0);
            this.Controls.SetChildIndex(this.tbToDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.DateTextBox tbFromDate;
        private ISA.Controls.DateTextBox tbToDate;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
    }
}
