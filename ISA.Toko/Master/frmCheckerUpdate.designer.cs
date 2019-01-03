namespace ISA.Toko.Master
{
    partial class frmCheckerUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckerUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstName = new ISA.Toko.Controls.CommonTextBox();
            this.txtLastName = new ISA.Toko.Controls.CommonTextBox();
            this.txtAlamat = new ISA.Toko.Controls.CommonTextBox();
            this.txtKota = new ISA.Toko.Controls.CommonTextBox();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.txtMasuk = new ISA.Toko.Controls.DateTextBox();
            this.txtKeluar = new ISA.Toko.Controls.DateTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nama Depan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nama Belakang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Alamat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tanggal Masuk";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tanggal Keluar";
            // 
            // txtFirstName
            // 
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Location = new System.Drawing.Point(139, 65);
            this.txtFirstName.MaxLength = 11;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(229, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(139, 98);
            this.txtLastName.MaxLength = 20;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(229, 20);
            this.txtLastName.TabIndex = 2;
            // 
            // txtAlamat
            // 
            this.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat.Location = new System.Drawing.Point(139, 132);
            this.txtAlamat.MaxLength = 40;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(510, 20);
            this.txtAlamat.TabIndex = 3;
            // 
            // txtKota
            // 
            this.txtKota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKota.Location = new System.Drawing.Point(139, 166);
            this.txtKota.MaxLength = 15;
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(229, 20);
            this.txtKota.TabIndex = 4;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(139, 276);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(262, 276);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtMasuk
            // 
            this.txtMasuk.DateValue = null;
            this.txtMasuk.Location = new System.Drawing.Point(139, 200);
            this.txtMasuk.MaxLength = 10;
            this.txtMasuk.Name = "txtMasuk";
            this.txtMasuk.Size = new System.Drawing.Size(229, 20);
            this.txtMasuk.TabIndex = 5;
            // 
            // txtKeluar
            // 
            this.txtKeluar.DateValue = null;
            this.txtKeluar.Location = new System.Drawing.Point(139, 234);
            this.txtKeluar.MaxLength = 10;
            this.txtKeluar.Name = "txtKeluar";
            this.txtKeluar.Size = new System.Drawing.Size(229, 20);
            this.txtKeluar.TabIndex = 6;
            // 
            // frmCheckerUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 470);
            this.Controls.Add(this.txtKeluar);
            this.Controls.Add(this.txtMasuk);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormID = "SC0217";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCheckerUpdate";
            this.Text = "SC0217 - Checker";
            this.Title = "Checker";
            this.Load += new System.EventHandler(this.frmCheckerUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCheckerUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtFirstName, 0);
            this.Controls.SetChildIndex(this.txtLastName, 0);
            this.Controls.SetChildIndex(this.txtAlamat, 0);
            this.Controls.SetChildIndex(this.txtKota, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.txtMasuk, 0);
            this.Controls.SetChildIndex(this.txtKeluar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Toko.Controls.CommonTextBox txtFirstName;
        private ISA.Toko.Controls.CommonTextBox txtLastName;
        private ISA.Toko.Controls.CommonTextBox txtAlamat;
        private ISA.Toko.Controls.CommonTextBox txtKota;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.DateTextBox txtMasuk;
        private ISA.Toko.Controls.DateTextBox txtKeluar;
    }
}
