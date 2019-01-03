namespace ISA.Toko.Master
{
    partial class frmBankKotaUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankKotaUpdate));
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Toko.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLokasi = new ISA.Toko.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbpasif = new System.Windows.Forms.RadioButton();
            this.cbaktif = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(47, 123);
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
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(393, 123);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(164, 27);
            this.txtNama.MaxLength = 20;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(298, 20);
            this.txtNama.TabIndex = 1;
            this.txtNama.TextChanged += new System.EventHandler(this.commonTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Lokasi";
            // 
            // txtLokasi
            // 
            this.txtLokasi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLokasi.Location = new System.Drawing.Point(164, 79);
            this.txtLokasi.MaxLength = 20;
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(298, 20);
            this.txtLokasi.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cbpasif);
            this.groupBox1.Controls.Add(this.cbaktif);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLokasi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Location = new System.Drawing.Point(76, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbpasif
            // 
            this.cbpasif.AutoSize = true;
            this.cbpasif.Location = new System.Drawing.Point(281, 54);
            this.cbpasif.Name = "cbpasif";
            this.cbpasif.Size = new System.Drawing.Size(52, 18);
            this.cbpasif.TabIndex = 3;
            this.cbpasif.TabStop = true;
            this.cbpasif.Text = "Pasif";
            this.cbpasif.UseVisualStyleBackColor = true;
            this.cbpasif.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // cbaktif
            // 
            this.cbaktif.AutoSize = true;
            this.cbaktif.Checked = true;
            this.cbaktif.Location = new System.Drawing.Point(164, 52);
            this.cbaktif.Name = "cbaktif";
            this.cbaktif.Size = new System.Drawing.Size(51, 18);
            this.cbaktif.TabIndex = 2;
            this.cbaktif.TabStop = true;
            this.cbaktif.Text = "Aktif";
            this.cbaktif.UseVisualStyleBackColor = true;
            // 
            // frmBankKotaUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 340);
            this.Controls.Add(this.groupBox1);
            this.FormID = "SC0220";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBankKotaUpdate";
            this.Text = "SC0220 - Bank Kota";
            this.Title = "Bank Kota";
            this.Load += new System.EventHandler(this.frmBankKotaUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBankKotaUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommonTextBox txtNama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommonTextBox txtLokasi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cbaktif;
        private System.Windows.Forms.RadioButton cbpasif;
    }
}
