namespace ISA.Trading.Penjualan
{
    partial class frmRptPenjualanPotongan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPenjualanPotongan));
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.dateTextBox1 = new ISA.Trading.Controls.DateTextBox();
            this.lookupToko = new ISA.Trading.Controls.LookupToko();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 255);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 2;
            this.cmdYes.Text = "YES";
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
            this.cmdClose.Location = new System.Drawing.Point(309, 255);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(109, 69);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(80, 20);
            this.dateTextBox1.TabIndex = 0;
            //this.dateTextBox1.TextChanged += new System.EventHandler(this.dateTextBox1_TextChanged);
            // 
            // lookupToko
            // 
            this.lookupToko.Alamat = null;
            this.lookupToko.Daerah = null;
            this.lookupToko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko.HariKirim = 0;
            this.lookupToko.HariSales = 0;
            this.lookupToko.KodeToko = "";
            this.lookupToko.Kota = null;
            this.lookupToko.Location = new System.Drawing.Point(109, 95);
            this.lookupToko.NamaToko = "";
            this.lookupToko.Name = "lookupToko";
            this.lookupToko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko.Size = new System.Drawing.Size(300, 54);
            this.lookupToko.TabIndex = 1;
            this.lookupToko.TokoID = null;
            this.lookupToko.WilID = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tgl. Pot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nama Toko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kode Toko";
            // 
            // frmRptPenjualanPotongan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(421, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lookupToko);
            this.Controls.Add(this.dateTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptPenjualanPotongan";
            this.Text = "Laporan Penjualan Potongan";
            this.Title = "Laporan Penjualan Potongan";
            this.Load += new System.EventHandler(this.frmRptPenjualanPotongan_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dateTextBox1, 0);
            this.Controls.SetChildIndex(this.lookupToko, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.DateTextBox dateTextBox1;
        private ISA.Trading.Controls.LookupToko lookupToko;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
