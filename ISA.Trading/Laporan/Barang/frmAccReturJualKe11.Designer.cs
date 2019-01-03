namespace ISA.Trading.Laporan.Barang
{
    partial class frmAccReturJualKe11
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccReturJualKe11));
            this.rangeTglRetur = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCabang1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.plh1 = new System.Windows.Forms.RadioButton();
            this.plh2 = new System.Windows.Forms.RadioButton();
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rangeTglRetur
            // 
            this.rangeTglRetur.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTglRetur.FromDate = null;
            this.rangeTglRetur.Location = new System.Drawing.Point(123, 62);
            this.rangeTglRetur.Name = "rangeTglRetur";
            this.rangeTglRetur.Size = new System.Drawing.Size(257, 22);
            this.rangeTglRetur.TabIndex = 0;
            this.rangeTglRetur.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tanggal : ";
            // 
            // cboCabang1
            // 
            this.cboCabang1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCabang1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCabang1.FormattingEnabled = true;
            this.cboCabang1.Location = new System.Drawing.Point(122, 100);
            this.cboCabang1.Name = "cboCabang1";
            this.cboCabang1.Size = new System.Drawing.Size(140, 22);
            this.cboCabang1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "C1 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "Pilihan : ";
            // 
            // plh1
            // 
            this.plh1.AutoSize = true;
            this.plh1.Location = new System.Drawing.Point(123, 148);
            this.plh1.Name = "plh1";
            this.plh1.Size = new System.Drawing.Size(151, 18);
            this.plh1.TabIndex = 2;
            this.plh1.TabStop = true;
            this.plh1.Text = "Belum pernah diajukan";
            this.plh1.UseVisualStyleBackColor = true;
            // 
            // plh2
            // 
            this.plh2.AutoSize = true;
            this.plh2.Location = new System.Drawing.Point(123, 172);
            this.plh2.Name = "plh2";
            this.plh2.Size = new System.Drawing.Size(169, 18);
            this.plh2.TabIndex = 3;
            this.plh2.TabStop = true;
            this.plh2.Text = "Semua (Sudah dan Belum)";
            this.plh2.UseVisualStyleBackColor = true;
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 289);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 4;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(280, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAccReturJualKe11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(392, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.plh2);
            this.Controls.Add(this.plh1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCabang1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeTglRetur);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAccReturJualKe11";
            this.Load += new System.EventHandler(this.frmAccReturJualKe11_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeTglRetur, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboCabang1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.plh1, 0);
            this.Controls.SetChildIndex(this.plh2, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rangeTglRetur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCabang1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton plh1;
        private System.Windows.Forms.RadioButton plh2;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
