namespace ISA.Toko.Penjualan
{
    partial class frmRencKunjSalesUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRencKunjSalesUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.txtIdWil = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtDaerah = new System.Windows.Forms.TextBox();
            this.txtKota = new System.Windows.Forms.TextBox();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.lookupToko1 = new ISA.Toko.Controls.LookupToko();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toko";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id. Wil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alamat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Daerah";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kota";
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(158, 251);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 11;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // txtIdWil
            // 
            this.txtIdWil.Location = new System.Drawing.Point(478, 99);
            this.txtIdWil.Name = "txtIdWil";
            this.txtIdWil.Size = new System.Drawing.Size(85, 20);
            this.txtIdWil.TabIndex = 3;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(126, 155);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(437, 20);
            this.txtAlamat.TabIndex = 5;
            // 
            // txtDaerah
            // 
            this.txtDaerah.Location = new System.Drawing.Point(126, 185);
            this.txtDaerah.Name = "txtDaerah";
            this.txtDaerah.Size = new System.Drawing.Size(114, 20);
            this.txtDaerah.TabIndex = 7;
            // 
            // txtKota
            // 
            this.txtKota.Location = new System.Drawing.Point(440, 185);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(123, 20);
            this.txtKota.TabIndex = 9;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(42, 251);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Daerah = null;
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "[CODE]";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(124, 98);
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(300, 54);
            this.lookupToko1.TabIndex = 12;
            this.lookupToko1.TokoID = null;
            this.lookupToko1.WilID = "";
            this.lookupToko1.SelectData += new System.EventHandler(this.lookupToko1_SelectData);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Kode Toko";
            // 
            // frmRencKunjSalesUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 330);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.txtDaerah);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtIdWil);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRencKunjSalesUpdate";
            this.Text = "Rencana Kunjungan Salesman";
            this.Title = "Rencana Kunjungan Salesman";
            this.Load += new System.EventHandler(this.frmRencKunjSalesUpdate_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.txtIdWil, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.txtDaerah, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private System.Windows.Forms.TextBox txtIdWil;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtDaerah;
        private System.Windows.Forms.TextBox txtKota;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.LookupToko lookupToko1;
        private System.Windows.Forms.Label label6;
    }
}