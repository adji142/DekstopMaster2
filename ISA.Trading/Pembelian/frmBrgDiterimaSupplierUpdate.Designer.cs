namespace ISA.Trading.Pembelian
{
    partial class frmBrgDiterimaSupplierUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrgDiterimaSupplierUpdate));
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPenerima = new ISA.Trading.Controls.CommonTextBox();
            this.txtTglKirim = new ISA.Trading.Controls.DateTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPengirim = new ISA.Trading.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoMPR = new ISA.Trading.Controls.CommonTextBox();
            this.txtTglRetur = new ISA.Trading.Controls.DateTextBox();
            this.txtTglKeluar = new ISA.Trading.Controls.DateTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoRetur = new ISA.Trading.Controls.CommonTextBox();
            this.txtPemasok = new ISA.Trading.Controls.CommonTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(286, 315);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 9;
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
            this.cmdSAVE.Location = new System.Drawing.Point(161, 315);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 8;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 51;
            this.label9.Text = "Oleh";
            // 
            // txtPenerima
            // 
            this.txtPenerima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPenerima.Location = new System.Drawing.Point(344, 268);
            this.txtPenerima.Name = "txtPenerima";
            this.txtPenerima.Size = new System.Drawing.Size(150, 20);
            this.txtPenerima.TabIndex = 7;
            // 
            // txtTglKirim
            // 
            this.txtTglKirim.DateValue = null;
            this.txtTglKirim.Enabled = false;
            this.txtTglKirim.Location = new System.Drawing.Point(181, 268);
            this.txtTglKirim.MaxLength = 10;
            this.txtTglKirim.Name = "txtTglKirim";
            this.txtTglKirim.ReadOnly = true;
            this.txtTglKirim.Size = new System.Drawing.Size(80, 20);
            this.txtTglKirim.TabIndex = 6;
            this.txtTglKirim.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 14);
            this.label8.TabIndex = 48;
            this.label8.Text = "Telah diperiksa Tgl.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 14);
            this.label7.TabIndex = 47;
            this.label7.Text = "Isian Untuk Cross Check Div.Penjualan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(490, 14);
            this.label6.TabIndex = 46;
            this.label6.Text = "---------------------------------------------------------------------";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 14);
            this.label5.TabIndex = 45;
            this.label5.Text = "Nama Pengirim SAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "Tgl. Nota  Retur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "Tgl. Memo Retur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "Nomor Memo Retur";
            // 
            // txtPengirim
            // 
            this.txtPengirim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPengirim.Enabled = false;
            this.txtPengirim.Location = new System.Drawing.Point(181, 196);
            this.txtPengirim.Name = "txtPengirim";
            this.txtPengirim.ReadOnly = true;
            this.txtPengirim.Size = new System.Drawing.Size(150, 20);
            this.txtPengirim.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nama Pemasok";
            // 
            // txtNoMPR
            // 
            this.txtNoMPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoMPR.Enabled = false;
            this.txtNoMPR.Location = new System.Drawing.Point(181, 92);
            this.txtNoMPR.MaxLength = 7;
            this.txtNoMPR.Name = "txtNoMPR";
            this.txtNoMPR.ReadOnly = true;
            this.txtNoMPR.Size = new System.Drawing.Size(60, 20);
            this.txtNoMPR.TabIndex = 1;
            // 
            // txtTglRetur
            // 
            this.txtTglRetur.DateValue = null;
            this.txtTglRetur.Location = new System.Drawing.Point(181, 170);
            this.txtTglRetur.MaxLength = 10;
            this.txtTglRetur.Name = "txtTglRetur";
            this.txtTglRetur.Size = new System.Drawing.Size(80, 20);
            this.txtTglRetur.TabIndex = 4;
            // 
            // txtTglKeluar
            // 
            this.txtTglKeluar.DateValue = null;
            this.txtTglKeluar.Enabled = false;
            this.txtTglKeluar.Location = new System.Drawing.Point(181, 118);
            this.txtTglKeluar.MaxLength = 10;
            this.txtTglKeluar.Name = "txtTglKeluar";
            this.txtTglKeluar.ReadOnly = true;
            this.txtTglKeluar.Size = new System.Drawing.Size(80, 20);
            this.txtTglKeluar.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 14);
            this.label10.TabIndex = 55;
            this.label10.Text = "Nomor Nota Retur";
            // 
            // txtNoRetur
            // 
            this.txtNoRetur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoRetur.Location = new System.Drawing.Point(181, 144);
            this.txtNoRetur.MaxLength = 7;
            this.txtNoRetur.Name = "txtNoRetur";
            this.txtNoRetur.Size = new System.Drawing.Size(60, 20);
            this.txtNoRetur.TabIndex = 3;
            // 
            // txtPemasok
            // 
            this.txtPemasok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPemasok.Enabled = false;
            this.txtPemasok.Location = new System.Drawing.Point(181, 66);
            this.txtPemasok.MaxLength = 7;
            this.txtPemasok.Name = "txtPemasok";
            this.txtPemasok.ReadOnly = true;
            this.txtPemasok.Size = new System.Drawing.Size(120, 20);
            this.txtPemasok.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmBrgDiterimaSupplierUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(547, 383);
            this.Controls.Add(this.txtPemasok);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNoRetur);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPenerima);
            this.Controls.Add(this.txtTglKirim);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPengirim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoMPR);
            this.Controls.Add(this.txtTglRetur);
            this.Controls.Add(this.txtTglKeluar);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(555, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(555, 410);
            this.Name = "frmBrgDiterimaSupplierUpdate";
            this.Text = "Barang diterima Supplier";
            this.Title = "Barang diterima Supplier";
            this.Load += new System.EventHandler(this.frmBrgDiterimaSupplierUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBrgDiterimaSupplierUpdate_FormClosed);
            this.Controls.SetChildIndex(this.txtTglKeluar, 0);
            this.Controls.SetChildIndex(this.txtTglRetur, 0);
            this.Controls.SetChildIndex(this.txtNoMPR, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtPengirim, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtTglKirim, 0);
            this.Controls.SetChildIndex(this.txtPenerima, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtNoRetur, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtPemasok, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label9;
        private ISA.Trading.Controls.CommonTextBox txtPenerima;
        private ISA.Trading.Controls.DateTextBox txtTglKirim;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommonTextBox txtPengirim;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommonTextBox txtNoMPR;
        private ISA.Trading.Controls.DateTextBox txtTglRetur;
        private ISA.Trading.Controls.DateTextBox txtTglKeluar;
        private System.Windows.Forms.Label label10;
        private ISA.Trading.Controls.CommonTextBox txtNoRetur;
        private ISA.Trading.Controls.CommonTextBox txtPemasok;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}
