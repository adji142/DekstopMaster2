namespace ISA.Finance.Piutang
{
    partial class frmBarcodeTambahNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarcodeTambahNota));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoNota = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cmdclose = new ISA.Controls.CommandButton();
            this.cmdsave = new ISA.Controls.CommandButton();
            this.txtIDWill = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lookupToko1 = new ISA.Controls.LookupToko();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtKPID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtrpsisa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(33, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tanggal Nota";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(33, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "No Nota";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(31, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Barcode";
            // 
            // txtNoNota
            // 
            this.txtNoNota.Location = new System.Drawing.Point(133, 204);
            this.txtNoNota.Name = "txtNoNota";
            this.txtNoNota.Size = new System.Drawing.Size(200, 20);
            this.txtNoNota.TabIndex = 11;
            this.txtNoNota.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(133, 229);
            this.txtBarcode.MaxLength = 30;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(200, 20);
            this.txtBarcode.TabIndex = 1;
            // 
            // cmdclose
            // 
            this.cmdclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdclose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.Image = ((System.Drawing.Image)(resources.GetObject("cmdclose.Image")));
            this.cmdclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdclose.Location = new System.Drawing.Point(390, 351);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(100, 40);
            this.cmdclose.TabIndex = 3;
            this.cmdclose.Text = "CLOSE";
            this.cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // cmdsave
            // 
            this.cmdsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdsave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdsave.Enabled = false;
            this.cmdsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdsave.Image = ((System.Drawing.Image)(resources.GetObject("cmdsave.Image")));
            this.cmdsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsave.Location = new System.Drawing.Point(28, 351);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(100, 40);
            this.cmdsave.TabIndex = 2;
            this.cmdsave.Text = "SAVE";
            this.cmdsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdsave.UseVisualStyleBackColor = true;
            this.cmdsave.Click += new System.EventHandler(this.cmdsave_Click);
            // 
            // txtIDWill
            // 
            this.txtIDWill.Enabled = false;
            this.txtIDWill.Location = new System.Drawing.Point(133, 154);
            this.txtIDWill.Name = "txtIDWill";
            this.txtIDWill.ReadOnly = true;
            this.txtIDWill.Size = new System.Drawing.Size(200, 20);
            this.txtIDWill.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(33, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "IDWill";
            // 
            // txtAlamat
            // 
            this.txtAlamat.Enabled = false;
            this.txtAlamat.Location = new System.Drawing.Point(133, 87);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.Size = new System.Drawing.Size(326, 62);
            this.txtAlamat.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(33, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Alamat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "KodeToko";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nama Toko";
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Catatan = "";
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.Grade = "";
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(133, 19);
            this.lookupToko1.LookUpType = ISA.Controls.LookupToko.EnumLookUpType.All;
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.Pasif = false;
            this.lookupToko1.Penanggungjawab = "";
            this.lookupToko1.Plafon = 0;
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(363, 54);
            this.lookupToko1.TabIndex = 18;
            this.lookupToko1.Telp = "";
            this.lookupToko1.TokoID = null;
            this.lookupToko1.WilID = null;
            this.lookupToko1.SelectData += new System.EventHandler(this.lookupToko1_SelectData);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(133, 177);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // txtKPID
            // 
            this.txtKPID.Location = new System.Drawing.Point(135, 254);
            this.txtKPID.MaxLength = 30;
            this.txtKPID.Name = "txtKPID";
            this.txtKPID.ReadOnly = true;
            this.txtKPID.Size = new System.Drawing.Size(200, 20);
            this.txtKPID.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(33, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "KPID";
            // 
            // txtrpsisa
            // 
            this.txtrpsisa.Location = new System.Drawing.Point(135, 280);
            this.txtrpsisa.MaxLength = 30;
            this.txtrpsisa.Name = "txtrpsisa";
            this.txtrpsisa.ReadOnly = true;
            this.txtrpsisa.Size = new System.Drawing.Size(200, 20);
            this.txtrpsisa.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(33, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Rp Sisa";
            // 
            // button1
            // 
            this.button1.Image = global::ISA.Finance.Properties.Resources.Ok32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(223, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 36);
            this.button1.TabIndex = 29;
            this.button1.Text = "Cek Piutang";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmBarcodeTambahNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 432);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtrpsisa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtKPID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.cmdclose);
            this.Controls.Add(this.cmdsave);
            this.Controls.Add(this.txtIDWill);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtNoNota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.Name = "frmBarcodeTambahNota";
            this.Text = "Input Nota";
            this.Load += new System.EventHandler(this.frmBarcodeUpdate_Load);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNoNota, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtIDWill, 0);
            this.Controls.SetChildIndex(this.cmdsave, 0);
            this.Controls.SetChildIndex(this.cmdclose, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtKPID, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtrpsisa, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoNota;
        private System.Windows.Forms.TextBox txtBarcode;
        private ISA.Controls.CommandButton cmdclose;
        private ISA.Controls.CommandButton cmdsave;
        private System.Windows.Forms.TextBox txtIDWill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.LookupToko lookupToko1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtKPID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtrpsisa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
    }
}