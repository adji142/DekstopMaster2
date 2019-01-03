namespace ISA.Toko.xpdc
{
    partial class frm_batal_kirim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_batal_kirim));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.commandButton2 = new ISA.Toko.Controls.CommandButton();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.Catatan = new ISA.Toko.Controls.CommonTextBox();
            this.TransactionType = new ISA.Toko.Controls.CommonTextBox();
            this.Kota = new ISA.Toko.Controls.CommonTextBox();
            this.Alamat = new ISA.Toko.Controls.CommonTextBox();
            this.NamaToko = new ISA.Toko.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "NAMA TOKO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "ALAMAT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "KOTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "JENIS TRANSAKSI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "CATATAN BATAL";
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(132, 236);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 6;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click_1);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(28, 236);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 5;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // Catatan
            // 
            this.Catatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Catatan.Location = new System.Drawing.Point(136, 171);
            this.Catatan.Name = "Catatan";
            this.Catatan.Size = new System.Drawing.Size(520, 20);
            this.Catatan.TabIndex = 4;
            // 
            // TransactionType
            // 
            this.TransactionType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TransactionType.Enabled = false;
            this.TransactionType.Location = new System.Drawing.Point(136, 135);
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.Size = new System.Drawing.Size(40, 20);
            this.TransactionType.TabIndex = 3;
            // 
            // Kota
            // 
            this.Kota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Kota.Enabled = false;
            this.Kota.Location = new System.Drawing.Point(136, 112);
            this.Kota.Name = "Kota";
            this.Kota.Size = new System.Drawing.Size(150, 20);
            this.Kota.TabIndex = 2;
            // 
            // Alamat
            // 
            this.Alamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Alamat.Enabled = false;
            this.Alamat.Location = new System.Drawing.Point(136, 89);
            this.Alamat.Name = "Alamat";
            this.Alamat.Size = new System.Drawing.Size(520, 20);
            this.Alamat.TabIndex = 1;
            // 
            // NamaToko
            // 
            this.NamaToko.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NamaToko.Enabled = false;
            this.NamaToko.Location = new System.Drawing.Point(136, 66);
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.Size = new System.Drawing.Size(195, 20);
            this.NamaToko.TabIndex = 0;
            // 
            // frm_batal_kirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 302);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.Catatan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TransactionType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Kota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Alamat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NamaToko);
            this.Controls.Add(this.label3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_batal_kirim";
            this.Text = "Batal Pengiriman";
            this.Title = "Batal Pengiriman";
            this.Load += new System.EventHandler(this.frm_batal_kirim_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.NamaToko, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.Alamat, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.Kota, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TransactionType, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.Catatan, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommonTextBox NamaToko;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.CommonTextBox Alamat;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommonTextBox Kota;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox TransactionType;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox Catatan;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton commandButton2;
    }
}
