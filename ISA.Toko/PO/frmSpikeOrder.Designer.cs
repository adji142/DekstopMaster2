namespace ISA.Toko.PO
{
    partial class frmSpikeOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdBarang = new System.Windows.Forms.TextBox();
            this.txtNamaStok = new System.Windows.Forms.TextBox();
            this.txtSpikeOrder = new System.Windows.Forms.TextBox();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Barang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Stok";
            // 
            // txtIdBarang
            // 
            this.txtIdBarang.Location = new System.Drawing.Point(140, 50);
            this.txtIdBarang.Name = "txtIdBarang";
            this.txtIdBarang.ReadOnly = true;
            this.txtIdBarang.Size = new System.Drawing.Size(164, 20);
            this.txtIdBarang.TabIndex = 2;
            // 
            // txtNamaStok
            // 
            this.txtNamaStok.Location = new System.Drawing.Point(140, 87);
            this.txtNamaStok.Name = "txtNamaStok";
            this.txtNamaStok.ReadOnly = true;
            this.txtNamaStok.Size = new System.Drawing.Size(164, 20);
            this.txtNamaStok.TabIndex = 3;
            // 
            // txtSpikeOrder
            // 
            this.txtSpikeOrder.Location = new System.Drawing.Point(140, 129);
            this.txtSpikeOrder.Name = "txtSpikeOrder";
            this.txtSpikeOrder.Size = new System.Drawing.Size(164, 20);
            this.txtSpikeOrder.TabIndex = 4;
            this.txtSpikeOrder.Text = "0";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(140, 173);
            this.txtKeterangan.Multiline = true;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(164, 87);
            this.txtKeterangan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keterangan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Spike Order";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(31, 292);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(78, 26);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmSpikeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 342);
            this.Controls.Add(this.txtIdBarang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.txtSpikeOrder);
            this.Controls.Add(this.txtNamaStok);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSpikeOrder";
            this.Text = "Spike Order";
            this.Title = "Spike Order";
            this.Load += new System.EventHandler(this.frmSpikeOrder_Load);
            this.Controls.SetChildIndex(this.txtNamaStok, 0);
            this.Controls.SetChildIndex(this.txtSpikeOrder, 0);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtIdBarang, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdBarang;
        private System.Windows.Forms.TextBox txtNamaStok;
        private System.Windows.Forms.TextBox txtSpikeOrder;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdOK;
    }
}