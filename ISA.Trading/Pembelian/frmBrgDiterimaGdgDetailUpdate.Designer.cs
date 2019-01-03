namespace ISA.Trading.Pembelian
{
    partial class frmBrgDiterimaGdgDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrgDiterimaGdgDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKodeBarang = new ISA.Trading.Controls.CommonTextBox();
            this.txtQtySJ = new ISA.Trading.Controls.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNamaBarang = new ISA.Trading.Controls.CommonTextBox();
            this.txtSatuan = new ISA.Trading.Controls.CommonTextBox();
            this.txtQtyNota = new ISA.Trading.Controls.NumericTextBox();
            this.txtHrgBeli = new ISA.Trading.Controls.NumericTextBox();
            this.txtJmlHrgBeli = new ISA.Trading.Controls.NumericTextBox();
            this.txtJmlHrgNet = new ISA.Trading.Controls.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDisc3 = new ISA.Trading.Controls.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDisc2 = new ISA.Trading.Controls.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDisc1 = new ISA.Trading.Controls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPPN = new ISA.Trading.Controls.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kode Barang";
            // 
            // txtKodeBarang
            // 
            this.txtKodeBarang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeBarang.Enabled = false;
            this.txtKodeBarang.Location = new System.Drawing.Point(147, 66);
            this.txtKodeBarang.Name = "txtKodeBarang";
            this.txtKodeBarang.ReadOnly = true;
            this.txtKodeBarang.Size = new System.Drawing.Size(90, 20);
            this.txtKodeBarang.TabIndex = 0;
            this.txtKodeBarang.TabStop = false;
            // 
            // txtQtySJ
            // 
            this.txtQtySJ.Location = new System.Drawing.Point(147, 144);
            this.txtQtySJ.Name = "txtQtySJ";
            this.txtQtySJ.Size = new System.Drawing.Size(45, 20);
            this.txtQtySJ.TabIndex = 3;
            this.txtQtySJ.Text = "0";
            this.txtQtySJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtySJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtySJ_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nama Stok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Satuan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Qty Terima";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Qty Nota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hrg Satuan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Juml RP.Beli";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Hrg Beli Net";
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaBarang.Enabled = false;
            this.txtNamaBarang.Location = new System.Drawing.Point(147, 92);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.ReadOnly = true;
            this.txtNamaBarang.Size = new System.Drawing.Size(515, 20);
            this.txtNamaBarang.TabIndex = 1;
            this.txtNamaBarang.TabStop = false;
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Enabled = false;
            this.txtSatuan.Location = new System.Drawing.Point(147, 118);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(35, 20);
            this.txtSatuan.TabIndex = 2;
            this.txtSatuan.TabStop = false;
            // 
            // txtQtyNota
            // 
            this.txtQtyNota.Enabled = false;
            this.txtQtyNota.Location = new System.Drawing.Point(147, 170);
            this.txtQtyNota.Name = "txtQtyNota";
            this.txtQtyNota.ReadOnly = true;
            this.txtQtyNota.Size = new System.Drawing.Size(45, 20);
            this.txtQtyNota.TabIndex = 4;
            this.txtQtyNota.TabStop = false;
            this.txtQtyNota.Text = "0";
            this.txtQtyNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHrgBeli
            // 
            this.txtHrgBeli.Enabled = false;
            this.txtHrgBeli.Location = new System.Drawing.Point(147, 196);
            this.txtHrgBeli.Name = "txtHrgBeli";
            this.txtHrgBeli.ReadOnly = true;
            this.txtHrgBeli.Size = new System.Drawing.Size(45, 20);
            this.txtHrgBeli.TabIndex = 5;
            this.txtHrgBeli.TabStop = false;
            this.txtHrgBeli.Text = "0";
            this.txtHrgBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtJmlHrgBeli
            // 
            this.txtJmlHrgBeli.Enabled = false;
            this.txtJmlHrgBeli.Location = new System.Drawing.Point(147, 222);
            this.txtJmlHrgBeli.Name = "txtJmlHrgBeli";
            this.txtJmlHrgBeli.ReadOnly = true;
            this.txtJmlHrgBeli.Size = new System.Drawing.Size(100, 20);
            this.txtJmlHrgBeli.TabIndex = 6;
            this.txtJmlHrgBeli.TabStop = false;
            this.txtJmlHrgBeli.Text = "0";
            this.txtJmlHrgBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtJmlHrgNet
            // 
            this.txtJmlHrgNet.Enabled = false;
            this.txtJmlHrgNet.Location = new System.Drawing.Point(147, 274);
            this.txtJmlHrgNet.Name = "txtJmlHrgNet";
            this.txtJmlHrgNet.ReadOnly = true;
            this.txtJmlHrgNet.Size = new System.Drawing.Size(100, 20);
            this.txtJmlHrgNet.TabIndex = 10;
            this.txtJmlHrgNet.TabStop = false;
            this.txtJmlHrgNet.Text = "0";
            this.txtJmlHrgNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(361, 251);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 14);
            this.label13.TabIndex = 38;
            this.label13.Text = "%";
            // 
            // txtDisc3
            // 
            this.txtDisc3.Enabled = false;
            this.txtDisc3.Format = "#,##0.00";
            this.txtDisc3.Location = new System.Drawing.Point(303, 248);
            this.txtDisc3.MaxLength = 6;
            this.txtDisc3.Name = "txtDisc3";
            this.txtDisc3.ReadOnly = true;
            this.txtDisc3.Size = new System.Drawing.Size(55, 20);
            this.txtDisc3.TabIndex = 9;
            this.txtDisc3.TabStop = false;
            this.txtDisc3.Text = "0.00";
            this.txtDisc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(283, 251);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 14);
            this.label12.TabIndex = 36;
            this.label12.Text = "%";
            // 
            // txtDisc2
            // 
            this.txtDisc2.Enabled = false;
            this.txtDisc2.Format = "#,##0.00";
            this.txtDisc2.Location = new System.Drawing.Point(225, 248);
            this.txtDisc2.MaxLength = 6;
            this.txtDisc2.Name = "txtDisc2";
            this.txtDisc2.ReadOnly = true;
            this.txtDisc2.Size = new System.Drawing.Size(55, 20);
            this.txtDisc2.TabIndex = 8;
            this.txtDisc2.TabStop = false;
            this.txtDisc2.Text = "0.00";
            this.txtDisc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(205, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 34;
            this.label11.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "Discount";
            // 
            // txtDisc1
            // 
            this.txtDisc1.Enabled = false;
            this.txtDisc1.Format = "#,##0.00";
            this.txtDisc1.Location = new System.Drawing.Point(147, 248);
            this.txtDisc1.MaxLength = 6;
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.ReadOnly = true;
            this.txtDisc1.Size = new System.Drawing.Size(55, 20);
            this.txtDisc1.TabIndex = 7;
            this.txtDisc1.TabStop = false;
            this.txtDisc1.Text = "0.00";
            this.txtDisc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(253, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 40;
            this.label10.Text = "+ PPN";
            // 
            // txtPPN
            // 
            this.txtPPN.Enabled = false;
            this.txtPPN.Location = new System.Drawing.Point(301, 274);
            this.txtPPN.MaxLength = 3;
            this.txtPPN.Name = "txtPPN";
            this.txtPPN.ReadOnly = true;
            this.txtPPN.Size = new System.Drawing.Size(35, 20);
            this.txtPPN.TabIndex = 11;
            this.txtPPN.TabStop = false;
            this.txtPPN.Text = "0";
            this.txtPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(344, 277);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 14);
            this.label14.TabIndex = 41;
            this.label14.Text = "%";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(253, 317);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 13;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(147, 317);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 12;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // frmBrgDiterimaGdgDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 382);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPPN);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDisc3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDisc2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDisc1);
            this.Controls.Add(this.txtJmlHrgNet);
            this.Controls.Add(this.txtJmlHrgBeli);
            this.Controls.Add(this.txtHrgBeli);
            this.Controls.Add(this.txtQtyNota);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQtySJ);
            this.Controls.Add(this.txtKodeBarang);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBrgDiterimaGdgDetailUpdate";
            this.Text = "Barang Diterima di Gudang";
            this.Title = "Barang Diterima di Gudang";
            this.Load += new System.EventHandler(this.frmBrgDiterimaGdgDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBrgDiterimaGdgDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtKodeBarang, 0);
            this.Controls.SetChildIndex(this.txtQtySJ, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtNamaBarang, 0);
            this.Controls.SetChildIndex(this.txtSatuan, 0);
            this.Controls.SetChildIndex(this.txtQtyNota, 0);
            this.Controls.SetChildIndex(this.txtHrgBeli, 0);
            this.Controls.SetChildIndex(this.txtJmlHrgBeli, 0);
            this.Controls.SetChildIndex(this.txtJmlHrgNet, 0);
            this.Controls.SetChildIndex(this.txtDisc1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtDisc2, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtDisc3, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtPPN, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommonTextBox txtKodeBarang;
        private ISA.Trading.Controls.NumericTextBox txtQtySJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ISA.Trading.Controls.CommonTextBox txtNamaBarang;
        private ISA.Trading.Controls.CommonTextBox txtSatuan;
        private ISA.Trading.Controls.NumericTextBox txtQtyNota;
        private ISA.Trading.Controls.NumericTextBox txtHrgBeli;
        private ISA.Trading.Controls.NumericTextBox txtJmlHrgBeli;
        private ISA.Trading.Controls.NumericTextBox txtJmlHrgNet;
        private System.Windows.Forms.Label label13;
        private ISA.Trading.Controls.NumericTextBox txtDisc3;
        private System.Windows.Forms.Label label12;
        private ISA.Trading.Controls.NumericTextBox txtDisc2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private ISA.Trading.Controls.NumericTextBox txtDisc1;
        private System.Windows.Forms.Label label10;
        private ISA.Trading.Controls.NumericTextBox txtPPN;
        private System.Windows.Forms.Label label14;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
    }
}
