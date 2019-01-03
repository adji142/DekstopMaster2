namespace ISA.Toko.Laporan.Salesman
{
    partial class frmRptPenjualanDiBawahHPP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
        if(disposing&&(components!=null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPenjualanDiBawahHPP));
            this.rangeDateBox1 = new ISA.Toko.Controls.RangeDateBox();
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdNo = new ISA.Toko.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCab = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(88, 65);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 245);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 2;
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
            this.cmdNo.Location = new System.Drawing.Point(411, 245);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 3;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tanggal";
            // 
            // cboCab
            // 
            this.cboCab.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCab.FormattingEnabled = true;
            this.cboCab.Location = new System.Drawing.Point(130, 111);
            this.cboCab.MaxDropDownItems = 12;
            this.cboCab.Name = "cboCab";
            this.cboCab.Size = new System.Drawing.Size(215, 22);
            this.cboCab.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cabang";
            // 
            // frmRptPenjualanDiBawahHPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(523, 297);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCab);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.rangeDateBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptPenjualanDiBawahHPP";
            this.Text = "Penjualan Di Bawah HPP";
            this.Title = "Penjualan Di Bawah HPP";
            this.Load += new System.EventHandler(this.frmRptPenjualanDiBawahHPP_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboCab, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.RangeDateBox rangeDateBox1;
        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCab;
        private System.Windows.Forms.Label label2;
    }
}
