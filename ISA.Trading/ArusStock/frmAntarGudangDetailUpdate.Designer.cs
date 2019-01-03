namespace ISA.Trading.ArusStock
{
    partial class frmAntarGudangDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAntarGudangDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lookupStock = new ISA.Trading.Controls.LookupStock();
            this.txtQtyDO = new ISA.Trading.Controls.NumericTextBox();
            this.txtQtyKirim = new ISA.Trading.Controls.NumericTextBox();
            this.txtQtyTerima = new ISA.Trading.Controls.NumericTextBox();
            this.txtCatatan = new ISA.Trading.Controls.CommonTextBox();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama Stok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kode Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Qty DO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Qty Kirim";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Qty Terima";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Catatan";
            // 
            // lookupStock
            // 
            this.lookupStock.BarangID = "";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(126, 69);
            this.lookupStock.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(351, 54);
            this.lookupStock.TabIndex = 0;
            this.lookupStock.Leave += new System.EventHandler(this.lookupStock_Leave);
            // 
            // txtQtyDO
            // 
            this.txtQtyDO.Location = new System.Drawing.Point(126, 143);
            this.txtQtyDO.Name = "txtQtyDO";
            this.txtQtyDO.Size = new System.Drawing.Size(116, 20);
            this.txtQtyDO.TabIndex = 1;
            this.txtQtyDO.Text = "0";
            this.txtQtyDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyDO.TextChanged += new System.EventHandler(this.txtQtyDO_TextChanged);
            //this.txtQtyDO.Leave += new System.EventHandler(this.txtQtyDO_Leave);
            // 
            // txtQtyKirim
            // 
            this.txtQtyKirim.Location = new System.Drawing.Point(126, 172);
            this.txtQtyKirim.Name = "txtQtyKirim";
            this.txtQtyKirim.Size = new System.Drawing.Size(116, 20);
            this.txtQtyKirim.TabIndex = 2;
            this.txtQtyKirim.Text = "0";
            this.txtQtyKirim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtyTerima
            // 
            this.txtQtyTerima.Location = new System.Drawing.Point(126, 201);
            this.txtQtyTerima.Name = "txtQtyTerima";
            this.txtQtyTerima.Size = new System.Drawing.Size(116, 20);
            this.txtQtyTerima.TabIndex = 3;
            this.txtQtyTerima.Text = "0";
            this.txtQtyTerima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(126, 235);
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(312, 20);
            this.txtCatatan.TabIndex = 4;
            this.txtCatatan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCatatan_KeyPress);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(31, 310);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(360, 310);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmAntarGudangDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(495, 367);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.txtQtyTerima);
            this.Controls.Add(this.txtQtyKirim);
            this.Controls.Add(this.txtQtyDO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookupStock);
            this.Controls.Add(this.label3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAntarGudangDetailUpdate";
            this.Text = "Antar Gudang";
            this.Title = "Antar Gudang";
            this.Load += new System.EventHandler(this.frmAntarGudangDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAntarGudangDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lookupStock, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtQtyDO, 0);
            this.Controls.SetChildIndex(this.txtQtyKirim, 0);
            this.Controls.SetChildIndex(this.txtQtyTerima, 0);
            this.Controls.SetChildIndex(this.txtCatatan, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ISA.Trading.Controls.LookupStock lookupStock;
        private ISA.Trading.Controls.NumericTextBox txtQtyDO;
        private ISA.Trading.Controls.NumericTextBox txtQtyKirim;
        private ISA.Trading.Controls.NumericTextBox txtQtyTerima;
        private ISA.Trading.Controls.CommonTextBox txtCatatan;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
