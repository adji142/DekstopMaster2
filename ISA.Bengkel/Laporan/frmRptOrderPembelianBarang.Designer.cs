namespace ISA.Bengkel.Laporan
{
    partial class frmRptOrderPembelianBarang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOrderPembelianBarang));
            this.cmdCetak = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCetak
            // 
            this.cmdCetak.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdCetak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCetak.Image = ((System.Drawing.Image)(resources.GetObject("cmdCetak.Image")));
            this.cmdCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCetak.Location = new System.Drawing.Point(101, 143);
            this.cmdCetak.Name = "cmdCetak";
            this.cmdCetak.Size = new System.Drawing.Size(100, 40);
            this.cmdCetak.TabIndex = 5;
            this.cmdCetak.Text = "PRINT";
            this.cmdCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCetak.UseVisualStyleBackColor = true;
            this.cmdCetak.Click += new System.EventHandler(this.cmdCetak_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(207, 143);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cetak Form Order Barang";
            // 
            // frmRptOrderPembelianBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(408, 209);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdCetak);
            this.Location = new System.Drawing.Point(500, 150);
            this.Name = "frmRptOrderPembelianBarang";
            this.Text = "";
            this.Title = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptOrderPembelianBarang_Load);
            this.Controls.SetChildIndex(this.cmdCetak, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCetak;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label1;
    }
}
