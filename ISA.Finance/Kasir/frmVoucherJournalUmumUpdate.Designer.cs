namespace ISA.Finance.Kasir
{
    partial class frmVoucherJournalUmumUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherJournalUmumUpdate));
            this.lookupPerkiraanKoneksi1 = new ISA.Finance.Controls.LookupPerkiraanKoneksi();
            this.tbUraian = new ISA.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNoAcc = new ISA.Controls.CommonTextBox();
            this.tbNilai = new ISA.Controls.NumericTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lookupPerkiraanKoneksi1
            // 
            this.lookupPerkiraanKoneksi1.Kode = "VJU";
            this.lookupPerkiraanKoneksi1.Location = new System.Drawing.Point(127, 26);
            this.lookupPerkiraanKoneksi1.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraanKoneksi1.NamaPerkiraan = "";
            this.lookupPerkiraanKoneksi1.Name = "lookupPerkiraanKoneksi1";
            this.lookupPerkiraanKoneksi1.NoPerkiraan = "[CODE]";
            this.lookupPerkiraanKoneksi1.Size = new System.Drawing.Size(252, 43);
            this.lookupPerkiraanKoneksi1.TabIndex = 1;
            this.lookupPerkiraanKoneksi1.TipeForm = ISA.Finance.Controls.LookupPerkiraanKoneksi.enTipeForm.form1;
            // 
            // tbUraian
            // 
            this.tbUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUraian.Location = new System.Drawing.Point(89, 84);
            this.tbUraian.Name = "tbUraian";
            this.tbUraian.Size = new System.Drawing.Size(415, 20);
            this.tbUraian.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama Perkiraan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Uraian";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nilai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "No Acc";
            // 
            // tbNoAcc
            // 
            this.tbNoAcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoAcc.Location = new System.Drawing.Point(432, 31);
            this.tbNoAcc.Name = "tbNoAcc";
            this.tbNoAcc.Size = new System.Drawing.Size(110, 20);
            this.tbNoAcc.TabIndex = 0;
            // 
            // tbNilai
            // 
            this.tbNilai.Location = new System.Drawing.Point(89, 117);
            this.tbNilai.Name = "tbNilai";
            this.tbNilai.Size = new System.Drawing.Size(100, 20);
            this.tbNilai.TabIndex = 3;
            this.tbNilai.Text = "0";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(334, 200);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(440, 200);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "No Perkiraan";
            // 
            // frmVoucherJournalUmumUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(570, 270);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tbNilai);
            this.Controls.Add(this.tbNoAcc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupPerkiraanKoneksi1);
            this.Controls.Add(this.tbUraian);
            this.Name = "frmVoucherJournalUmumUpdate";
            this.Text = "Voucher Journal Umum Update";
            this.Load += new System.EventHandler(this.frmVoucherJournalUmumUpdate_Load);
            this.Controls.SetChildIndex(this.tbUraian, 0);
            this.Controls.SetChildIndex(this.lookupPerkiraanKoneksi1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbNoAcc, 0);
            this.Controls.SetChildIndex(this.tbNilai, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Finance.Controls.LookupPerkiraanKoneksi lookupPerkiraanKoneksi1;
        private ISA.Controls.CommonTextBox tbUraian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox tbNoAcc;
        private ISA.Controls.NumericTextBox tbNilai;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label5;
    }
}
