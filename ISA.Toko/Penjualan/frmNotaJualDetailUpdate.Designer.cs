namespace ISA.Toko.Penjualan
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
            this.lookupStock1 = new ISA.Toko.Controls.LookupStock();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.numericTextBox1 = new ISA.Toko.Controls.NumericTextBox();
            this.numericTextBox2 = new ISA.Toko.Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lookupStock1
            // 
            this.lookupStock1.BarangID = "[CODE]";
            this.lookupStock1.Enabled = false;
            this.lookupStock1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock1.IsiKoli = 0;
            this.lookupStock1.Location = new System.Drawing.Point(120, 59);
            this.lookupStock1.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock1.NamaStock = "";
            this.lookupStock1.Name = "lookupStock1";
            this.lookupStock1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock1.Satuan = null;
            this.lookupStock1.Size = new System.Drawing.Size(515, 54);
            this.lookupStock1.TabIndex = 5;
            this.lookupStock1.TabStop = false;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 256);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 1;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(535, 256);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CANCEL";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(120, 130);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.ReadOnly = true;
            this.numericTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox1.TabIndex = 8;
            this.numericTextBox1.TabStop = false;
            this.numericTextBox1.Text = "0";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(120, 169);
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox2.TabIndex = 0;
            this.numericTextBox2.Text = "0";
            this.numericTextBox2.Validated += new System.EventHandler(this.numericTextBox2_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nama Stok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kode Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "QtyDO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "QtySJ";
            // 
            // frmNotaJualDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(657, 308);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.LookupStock lookupStock1;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.NumericTextBox numericTextBox1;
        private ISA.Toko.Controls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
