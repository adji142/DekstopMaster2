namespace ISA.Trading.Laporan.Salesman
{
    partial class frmRptKoreksiNotaJual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptKoreksiNotaJual));
            this.cmdyes = new ISA.Trading.Controls.CommandButton();
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWilID = new ISA.Trading.Controls.CommonTextBox();
            this.txtinit = new ISA.Trading.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdyes
            // 
            this.cmdyes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdyes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdyes.Image = ((System.Drawing.Image)(resources.GetObject("cmdyes.Image")));
            this.cmdyes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdyes.Location = new System.Drawing.Point(12, 294);
            this.cmdyes.Name = "cmdyes";
            this.cmdyes.ReportName = "";
            this.cmdyes.Size = new System.Drawing.Size(100, 40);
            this.cmdyes.TabIndex = 3;
            this.cmdyes.Text = "PRINT";
            this.cmdyes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdyes.UseVisualStyleBackColor = true;
            this.cmdyes.Click += new System.EventHandler(this.cmdyes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(603, 294);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
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
            this.rangeDateBox1.Location = new System.Drawing.Point(83, 65);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Wil ID";
            // 
            // txtWilID
            // 
            this.txtWilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWilID.Location = new System.Drawing.Point(121, 106);
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.Size = new System.Drawing.Size(100, 20);
            this.txtWilID.TabIndex = 1;
            // 
            // txtinit
            // 
            this.txtinit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtinit.Location = new System.Drawing.Point(121, 149);
            this.txtinit.Name = "txtinit";
            this.txtinit.Size = new System.Drawing.Size(100, 20);
            this.txtinit.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Init Pers";
            // 
            // frmRptKoreksiNotaJual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(715, 346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtinit);
            this.Controls.Add(this.txtWilID);
            this.Controls.Add(this.cmdyes);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptKoreksiNotaJual";
            this.Text = "Koreksi Nota Jual";
            this.Title = "Koreksi Nota Jual";
            this.Load += new System.EventHandler(this.frmRptKoreksiNotaJual_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.cmdyes, 0);
            this.Controls.SetChildIndex(this.txtWilID, 0);
            this.Controls.SetChildIndex(this.txtinit, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdyes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommonTextBox txtWilID;
        private ISA.Trading.Controls.CommonTextBox txtinit;
        private System.Windows.Forms.Label label3;
    }
}
