namespace ISA.Toko.Penjualan
{
    partial class frmPPCUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPPCUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarangID = new ISA.Toko.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamaBarang = new ISA.Toko.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.txtQtySisa = new ISA.Toko.Controls.NumericTextBox();
            this.txtQtyDO = new ISA.Toko.Controls.NumericTextBox();
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
            // txtBarangID
            // 
            this.txtBarangID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarangID.Enabled = false;
            this.txtBarangID.Location = new System.Drawing.Point(119, 66);
            this.txtBarangID.Name = "txtBarangID";
            this.txtBarangID.ReadOnly = true;
            this.txtBarangID.Size = new System.Drawing.Size(135, 20);
            this.txtBarangID.TabIndex = 0;
            this.txtBarangID.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nama Barang";
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaBarang.Enabled = false;
            this.txtNamaBarang.Location = new System.Drawing.Point(119, 94);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.ReadOnly = true;
            this.txtNamaBarang.Size = new System.Drawing.Size(548, 20);
            this.txtNamaBarang.TabIndex = 1;
            this.txtNamaBarang.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Qty Nota";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Qty DO";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(243, 178);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(117, 43);
            this.cmdCLOSE.TabIndex = 5;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSAVE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(119, 178);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(117, 43);
            this.cmdSAVE.TabIndex = 4;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // txtQtySisa
            // 
            this.txtQtySisa.Enabled = false;
            this.txtQtySisa.Location = new System.Drawing.Point(119, 122);
            this.txtQtySisa.Name = "txtQtySisa";
            this.txtQtySisa.ReadOnly = true;
            this.txtQtySisa.Size = new System.Drawing.Size(37, 20);
            this.txtQtySisa.TabIndex = 2;
            this.txtQtySisa.Text = "0";
            // 
            // txtQtyDO
            // 
            this.txtQtyDO.Location = new System.Drawing.Point(119, 150);
            this.txtQtyDO.Name = "txtQtyDO";
            this.txtQtyDO.Size = new System.Drawing.Size(37, 20);
            this.txtQtyDO.TabIndex = 3;
            this.txtQtyDO.Text = "0";
            this.txtQtyDO.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyDO_Validating);
            // 
            // frmPPCUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(699, 234);
            this.Controls.Add(this.txtQtyDO);
            this.Controls.Add(this.txtQtySisa);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarangID);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPPCUpdate";
            this.Text = "Pengambilan Bonus";
            this.Title = "Pengambilan Bonus";
            this.Load += new System.EventHandler(this.frmPPCUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPPCUpdate_FormClosed);
            this.Controls.SetChildIndex(this.txtBarangID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNamaBarang, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtQtySisa, 0);
            this.Controls.SetChildIndex(this.txtQtyDO, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox txtBarangID;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox txtNamaBarang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private ISA.Toko.Controls.NumericTextBox txtQtySisa;
        private ISA.Toko.Controls.NumericTextBox txtQtyDO;
    }
}
