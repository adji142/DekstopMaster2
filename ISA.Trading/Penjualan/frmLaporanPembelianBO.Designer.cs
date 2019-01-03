namespace ISA.Trading.Penjualan
{
    partial class frmLaporanPembelianBO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanPembelianBO));
            this.rangeDateBoxPembelian = new ISA.Trading.Controls.RangeDateBox();
            this.rangeDateBoxPenjualan = new ISA.Trading.Controls.RangeDateBox();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rangeDateBoxPembelian
            // 
            this.rangeDateBoxPembelian.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBoxPembelian.FromDate = null;
            this.rangeDateBoxPembelian.Location = new System.Drawing.Point(148, 61);
            this.rangeDateBoxPembelian.Name = "rangeDateBoxPembelian";
            this.rangeDateBoxPembelian.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBoxPembelian.TabIndex = 5;
            this.rangeDateBoxPembelian.ToDate = null;
            // 
            // rangeDateBoxPenjualan
            // 
            this.rangeDateBoxPenjualan.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBoxPenjualan.FromDate = null;
            this.rangeDateBoxPenjualan.Location = new System.Drawing.Point(148, 103);
            this.rangeDateBoxPenjualan.Name = "rangeDateBoxPenjualan";
            this.rangeDateBoxPenjualan.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBoxPenjualan.TabIndex = 6;
            this.rangeDateBoxPenjualan.ToDate = null;
            this.rangeDateBoxPenjualan.Load += new System.EventHandler(this.rangeDateBoxPenjualan_Load);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 156);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 7;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(350, 156);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 8;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tanggal Pembelian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tanggal DO";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmLaporanPembelianBO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(462, 208);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.rangeDateBoxPembelian);
            this.Controls.Add(this.rangeDateBoxPenjualan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanPembelianBO";
            this.Text = "BO DARI PEMBELIAN";
            this.Title = "BO DARI PEMBELIAN";
            this.Load += new System.EventHandler(this.frmLaporanPembelianBO_Load);
            this.Controls.SetChildIndex(this.rangeDateBoxPenjualan, 0);
            this.Controls.SetChildIndex(this.rangeDateBoxPembelian, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rangeDateBoxPembelian;
        private ISA.Trading.Controls.RangeDateBox rangeDateBoxPenjualan;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
