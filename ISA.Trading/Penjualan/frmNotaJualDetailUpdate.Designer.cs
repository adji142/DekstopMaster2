namespace ISA.Trading.Penjualan
{
    partial class frmNotaJualDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaJualDetailUpdate));
            this.lookupStock1 = new ISA.Trading.Controls.LookupStock();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.numericTextBox1 = new ISA.Trading.Controls.NumericTextBox();
            this.numericTextBox2 = new ISA.Trading.Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHrgJual = new ISA.Trading.Controls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDisc1 = new ISA.Trading.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDisc2 = new ISA.Trading.Controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDisc3 = new ISA.Trading.Controls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPot = new ISA.Trading.Controls.NumericTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJumlah = new ISA.Trading.Controls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lookupStock1
            // 
            this.lookupStock1.BarangID = "[CODE]";
            this.lookupStock1.Enabled = false;
            this.lookupStock1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock1.IsiKoli = 0;
            this.lookupStock1.Location = new System.Drawing.Point(120, 59);
            this.lookupStock1.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock1.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock1.NamaStock = "";
            this.lookupStock1.Name = "lookupStock1";
            this.lookupStock1.RecordID = null;
            this.lookupStock1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock1.Satuan = null;
            this.lookupStock1.Size = new System.Drawing.Size(515, 54);
            this.lookupStock1.TabIndex = 0;
            this.lookupStock1.TabStop = false;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(27, 306);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 9;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(535, 306);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "CANCEL";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(124, 119);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.ReadOnly = true;
            this.numericTextBox1.Size = new System.Drawing.Size(84, 20);
            this.numericTextBox1.TabIndex = 1;
            this.numericTextBox1.TabStop = false;
            this.numericTextBox1.Text = "0";
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(277, 120);
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.ReadOnly = true;
            this.numericTextBox2.Size = new System.Drawing.Size(84, 20);
            this.numericTextBox2.TabIndex = 2;
            this.numericTextBox2.TabStop = false;
            this.numericTextBox2.Text = "0";
            this.numericTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTextBox2.Validated += new System.EventHandler(this.numericTextBox2_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nama Stok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kode Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "QtyDO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "QtySJ";
            // 
            // txtHrgJual
            // 
            this.txtHrgJual.Location = new System.Drawing.Point(124, 152);
            this.txtHrgJual.Name = "txtHrgJual";
            this.txtHrgJual.Size = new System.Drawing.Size(84, 20);
            this.txtHrgJual.TabIndex = 3;
            this.txtHrgJual.Text = "0";
            this.txtHrgJual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHrgJual.Validating += new System.ComponentModel.CancelEventHandler(this.txtHrgJual_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Harga Jual";
            // 
            // txtDisc1
            // 
            this.txtDisc1.Format = "#,##.#0";
            this.txtDisc1.Location = new System.Drawing.Point(124, 178);
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.Size = new System.Drawing.Size(84, 20);
            this.txtDisc1.TabIndex = 4;
            this.txtDisc1.Text = ".00";
            this.txtDisc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc1.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc1_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Disc1";
            // 
            // txtDisc2
            // 
            this.txtDisc2.Format = "#,##.#0";
            this.txtDisc2.Location = new System.Drawing.Point(277, 178);
            this.txtDisc2.Name = "txtDisc2";
            this.txtDisc2.Size = new System.Drawing.Size(84, 20);
            this.txtDisc2.TabIndex = 5;
            this.txtDisc2.Text = "0";
            this.txtDisc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc2.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc2_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Disc2";
            // 
            // txtDisc3
            // 
            this.txtDisc3.Format = "#,##.#0";
            this.txtDisc3.Location = new System.Drawing.Point(437, 178);
            this.txtDisc3.Name = "txtDisc3";
            this.txtDisc3.Size = new System.Drawing.Size(84, 20);
            this.txtDisc3.TabIndex = 6;
            this.txtDisc3.Text = "0";
            this.txtDisc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc3.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisc3_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "Disc3";
            // 
            // txtPot
            // 
            this.txtPot.Location = new System.Drawing.Point(124, 204);
            this.txtPot.Name = "txtPot";
            this.txtPot.Size = new System.Drawing.Size(84, 20);
            this.txtPot.TabIndex = 7;
            this.txtPot.Text = "0";
            this.txtPot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPot.Validating += new System.ComponentModel.CancelEventHandler(this.txtPot_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = "Potongan";
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(124, 230);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.ReadOnly = true;
            this.txtJumlah.Size = new System.Drawing.Size(84, 20);
            this.txtJumlah.TabIndex = 8;
            this.txtJumlah.TabStop = false;
            this.txtJumlah.Text = "0";
            this.txtJumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 233);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 14);
            this.label10.TabIndex = 25;
            this.label10.Text = "Jumlah";
            // 
            // frmNotaJualDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(657, 359);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPot);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDisc3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDisc2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDisc1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHrgJual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupStock1);
            this.Controls.Add(this.numericTextBox2);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNotaJualDetailUpdate";
            this.Text = "Nota Detail";
            this.Title = "Nota Detail";
            this.Load += new System.EventHandler(this.frmNotaJualDetailUpdate_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.numericTextBox1, 0);
            this.Controls.SetChildIndex(this.numericTextBox2, 0);
            this.Controls.SetChildIndex(this.lookupStock1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtHrgJual, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDisc1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDisc2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtDisc3, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtPot, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtJumlah, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.LookupStock lookupStock1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.NumericTextBox numericTextBox1;
        private ISA.Trading.Controls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.NumericTextBox txtHrgJual;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.NumericTextBox txtDisc1;
        private System.Windows.Forms.Label label6;
        private ISA.Trading.Controls.NumericTextBox txtDisc2;
        private System.Windows.Forms.Label label7;
        private ISA.Trading.Controls.NumericTextBox txtDisc3;
        private System.Windows.Forms.Label label8;
        private ISA.Trading.Controls.NumericTextBox txtPot;
        private System.Windows.Forms.Label label9;
        private ISA.Trading.Controls.NumericTextBox txtJumlah;
        private System.Windows.Forms.Label label10;
    }
}
