namespace ISA.Trading.Master
{
    partial class frmStokBarcodeUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokBarcodeUpdate));
            this.txtKodeBarang = new System.Windows.Forms.TextBox();
            this.txtNamaBarang = new System.Windows.Forms.TextBox();
            this.txtKodeBarcode = new System.Windows.Forms.TextBox();
            this.txtGroupBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // txtKodeBarang
            // 
            this.txtKodeBarang.Enabled = false;
            this.txtKodeBarang.Location = new System.Drawing.Point(147, 106);
            this.txtKodeBarang.Name = "txtKodeBarang";
            this.txtKodeBarang.Size = new System.Drawing.Size(152, 20);
            this.txtKodeBarang.TabIndex = 0;
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.Enabled = false;
            this.txtNamaBarang.Location = new System.Drawing.Point(147, 145);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.Size = new System.Drawing.Size(261, 20);
            this.txtNamaBarang.TabIndex = 1;
            // 
            // txtKodeBarcode
            // 
            this.txtKodeBarcode.Location = new System.Drawing.Point(147, 180);
            this.txtKodeBarcode.Name = "txtKodeBarcode";
            this.txtKodeBarcode.Size = new System.Drawing.Size(152, 20);
            this.txtKodeBarcode.TabIndex = 2;
            this.txtKodeBarcode.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtGroupBarcode
            // 
            this.txtGroupBarcode.Location = new System.Drawing.Point(147, 215);
            this.txtGroupBarcode.Name = "txtGroupBarcode";
            this.txtGroupBarcode.Size = new System.Drawing.Size(152, 20);
            this.txtGroupBarcode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kode Barang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nama Barang";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kode Barcode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Group Barcode";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(233, 286);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(76, 286);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmStokBarcodeUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 352);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.txtKodeBarang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKodeBarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGroupBarcode);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStokBarcodeUpdate";
            this.Text = "Stok Barcode Update";
            this.Title = "Stok Barcode Update";
            this.Load += new System.EventHandler(this.frmStokBarcodeUpdate_Load);
            this.Controls.SetChildIndex(this.txtGroupBarcode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtKodeBarcode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtKodeBarang, 0);
            this.Controls.SetChildIndex(this.txtNamaBarang, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKodeBarang;
        private System.Windows.Forms.TextBox txtNamaBarang;
        private System.Windows.Forms.TextBox txtKodeBarcode;
        private System.Windows.Forms.TextBox txtGroupBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdSave;
    }
}