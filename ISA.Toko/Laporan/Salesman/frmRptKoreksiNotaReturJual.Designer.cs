namespace ISA.Toko.Laporan.Salesman
{
    partial class frmRptKoreksiNotaReturJual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptKoreksiNotaReturJual));
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdNo = new ISA.Toko.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Toko.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWilID = new ISA.Toko.Controls.CommonTextBox();
            this.txtInit = new ISA.Toko.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 304);
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
            this.cmdNo.Location = new System.Drawing.Point(394, 305);
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
            this.rangeDateBox1.Location = new System.Drawing.Point(78, 69);
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
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID Wil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Init Pers";
            // 
            // txtWilID
            // 
            this.txtWilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWilID.Location = new System.Drawing.Point(118, 113);
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.Size = new System.Drawing.Size(143, 20);
            this.txtWilID.TabIndex = 1;
            // 
            // txtInit
            // 
            this.txtInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInit.Location = new System.Drawing.Point(118, 149);
            this.txtInit.Name = "txtInit";
            this.txtInit.Size = new System.Drawing.Size(143, 20);
            this.txtInit.TabIndex = 2;
            // 
            // frmRptKoreksiNotaReturJual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(506, 357);
            this.Controls.Add(this.txtWilID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInit);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptKoreksiNotaReturJual";
            this.Text = "Koreksi Nota retur Jual";
            this.Title = "Koreksi Nota retur Jual";
            this.Load += new System.EventHandler(this.frmRptKoreksiNotaReturJual_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.txtInit, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtWilID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommonTextBox txtWilID;
        private ISA.Toko.Controls.CommonTextBox txtInit;
    }
}
