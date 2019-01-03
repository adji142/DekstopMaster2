namespace ISA.Toko.xpdc
{
    partial class frm_barcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_barcode));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NoNota = new ISA.Toko.Controls.CommonTextBox();
            this.NamaToko = new ISA.Toko.Controls.CommonTextBox();
            this.Alamat = new ISA.Toko.Controls.CommonTextBox();
            this.Kota = new ISA.Toko.Controls.CommonTextBox();
            this.Nominal = new ISA.Toko.Controls.CommonTextBox();
            this.KodeBarcode = new ISA.Toko.Controls.CommonTextBox();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.TglNota = new ISA.Toko.Controls.DateTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "TGL SURAT JALAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "NO SURAT JALAN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "NAMA TOKO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "ALAMAT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "KOTA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "NOMINAL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "BARCODE";
            // 
            // NoNota
            // 
            this.NoNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NoNota.Enabled = false;
            this.NoNota.Location = new System.Drawing.Point(173, 90);
            this.NoNota.Name = "NoNota";
            this.NoNota.Size = new System.Drawing.Size(89, 20);
            this.NoNota.TabIndex = 1;
            // 
            // NamaToko
            // 
            this.NamaToko.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NamaToko.Enabled = false;
            this.NamaToko.Location = new System.Drawing.Point(173, 116);
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.Size = new System.Drawing.Size(195, 20);
            this.NamaToko.TabIndex = 2;
            // 
            // Alamat
            // 
            this.Alamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Alamat.Enabled = false;
            this.Alamat.Location = new System.Drawing.Point(173, 142);
            this.Alamat.Name = "Alamat";
            this.Alamat.Size = new System.Drawing.Size(520, 20);
            this.Alamat.TabIndex = 3;
            // 
            // Kota
            // 
            this.Kota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Kota.Enabled = false;
            this.Kota.Location = new System.Drawing.Point(173, 168);
            this.Kota.Name = "Kota";
            this.Kota.Size = new System.Drawing.Size(150, 20);
            this.Kota.TabIndex = 4;
            // 
            // Nominal
            // 
            this.Nominal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nominal.Enabled = false;
            this.Nominal.Location = new System.Drawing.Point(173, 194);
            this.Nominal.Name = "Nominal";
            this.Nominal.Size = new System.Drawing.Size(89, 20);
            this.Nominal.TabIndex = 5;
            // 
            // KodeBarcode
            // 
            this.KodeBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.KodeBarcode.Location = new System.Drawing.Point(173, 245);
            this.KodeBarcode.Name = "KodeBarcode";
            this.KodeBarcode.Size = new System.Drawing.Size(195, 20);
            this.KodeBarcode.TabIndex = 6;
            this.KodeBarcode.TextChanged += new System.EventHandler(this.KodeBarcode_TextChanged);
            this.KodeBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cek_barcode);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(40, 312);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 19;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // TglNota
            // 
            this.TglNota.DateValue = null;
            this.TglNota.Enabled = false;
            this.TglNota.Location = new System.Drawing.Point(173, 64);
            this.TglNota.MaxLength = 10;
            this.TglNota.Name = "TglNota";
            this.TglNota.Size = new System.Drawing.Size(89, 20);
            this.TglNota.TabIndex = 0;
            // 
            // frm_barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 370);
            this.Controls.Add(this.TglNota);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.KodeBarcode);
            this.Controls.Add(this.Nominal);
            this.Controls.Add(this.Kota);
            this.Controls.Add(this.Alamat);
            this.Controls.Add(this.NamaToko);
            this.Controls.Add(this.NoNota);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_barcode";
            this.Text = "Scan Barcode";
            this.Title = "Scan Barcode";
            this.Load += new System.EventHandler(this.Barcode_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.NoNota, 0);
            this.Controls.SetChildIndex(this.NamaToko, 0);
            this.Controls.SetChildIndex(this.Alamat, 0);
            this.Controls.SetChildIndex(this.Kota, 0);
            this.Controls.SetChildIndex(this.Nominal, 0);
            this.Controls.SetChildIndex(this.KodeBarcode, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.TglNota, 0);
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
        private System.Windows.Forms.Label label7;
        private ISA.Toko.Controls.CommonTextBox NoNota;
        private ISA.Toko.Controls.CommonTextBox NamaToko;
        private ISA.Toko.Controls.CommonTextBox Alamat;
        private ISA.Toko.Controls.CommonTextBox Kota;
        private ISA.Toko.Controls.CommonTextBox Nominal;
        private ISA.Toko.Controls.CommonTextBox KodeBarcode;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.DateTextBox TglNota;
    }
}
