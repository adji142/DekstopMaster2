namespace ISA.Finance.Kasir
{
    partial class frmVoucherGiroTitipUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucherGiroTitipUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTipe = new ISA.Controls.CommonTextBox();
            this.tbNoVch = new ISA.Controls.CommonTextBox();
            this.tbUraian1 = new ISA.Controls.CommonTextBox();
            this.tbUraian3 = new ISA.Controls.CommonTextBox();
            this.tbUraian2 = new ISA.Controls.CommonTextBox();
            this.lookupBank1 = new ISA.Finance.Controls.LookupBank();
            this.tbDibuat = new ISA.Controls.CommonTextBox();
            this.tbMengetahui = new ISA.Controls.CommonTextBox();
            this.tbDibukukan = new ISA.Controls.CommonTextBox();
            this.tbNominal = new ISA.Controls.NumericTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.tbTanggal = new ISA.Controls.DateTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ke Bank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Uraian #1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Uraian #2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Uraian #3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mengetahui";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Dibukukan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Dibuat";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "Nominal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "Tanggal Vch";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(446, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "No Vch";
            // 
            // tbTipe
            // 
            this.tbTipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTipe.Enabled = false;
            this.tbTipe.Location = new System.Drawing.Point(90, 25);
            this.tbTipe.Name = "tbTipe";
            this.tbTipe.Size = new System.Drawing.Size(54, 20);
            this.tbTipe.TabIndex = 0;
            this.tbTipe.Text = "TT";
            // 
            // tbNoVch
            // 
            this.tbNoVch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoVch.Enabled = false;
            this.tbNoVch.Location = new System.Drawing.Point(513, 25);
            this.tbNoVch.Name = "tbNoVch";
            this.tbNoVch.Size = new System.Drawing.Size(117, 20);
            this.tbNoVch.TabIndex = 2;
            // 
            // tbUraian1
            // 
            this.tbUraian1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUraian1.Location = new System.Drawing.Point(90, 112);
            this.tbUraian1.Name = "tbUraian1";
            this.tbUraian1.Size = new System.Drawing.Size(540, 20);
            this.tbUraian1.TabIndex = 4;
            // 
            // tbUraian3
            // 
            this.tbUraian3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUraian3.Location = new System.Drawing.Point(90, 176);
            this.tbUraian3.Name = "tbUraian3";
            this.tbUraian3.Size = new System.Drawing.Size(540, 20);
            this.tbUraian3.TabIndex = 6;
            // 
            // tbUraian2
            // 
            this.tbUraian2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUraian2.Location = new System.Drawing.Point(90, 146);
            this.tbUraian2.Name = "tbUraian2";
            this.tbUraian2.Size = new System.Drawing.Size(540, 20);
            this.tbUraian2.TabIndex = 5;
            // 
            // lookupBank1
            // 
            this.lookupBank1.BankID = "[CODE]";
            this.lookupBank1.Location = new System.Drawing.Point(90, 55);
            this.lookupBank1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lookupBank1.NamaBank = "";
            this.lookupBank1.Name = "lookupBank1";
            this.lookupBank1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupBank1.Size = new System.Drawing.Size(168, 51);
            this.lookupBank1.TabIndex = 3;
            // 
            // tbDibuat
            // 
            this.tbDibuat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDibuat.Enabled = false;
            this.tbDibuat.Location = new System.Drawing.Point(28, 246);
            this.tbDibuat.Name = "tbDibuat";
            this.tbDibuat.Size = new System.Drawing.Size(139, 20);
            this.tbDibuat.TabIndex = 7;
            // 
            // tbMengetahui
            // 
            this.tbMengetahui.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbMengetahui.Location = new System.Drawing.Point(491, 246);
            this.tbMengetahui.Name = "tbMengetahui";
            this.tbMengetahui.Size = new System.Drawing.Size(139, 20);
            this.tbMengetahui.TabIndex = 9;
            // 
            // tbDibukukan
            // 
            this.tbDibukukan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDibukukan.Location = new System.Drawing.Point(257, 246);
            this.tbDibukukan.Name = "tbDibukukan";
            this.tbDibukukan.Size = new System.Drawing.Size(139, 20);
            this.tbDibukukan.TabIndex = 8;
            // 
            // tbNominal
            // 
            this.tbNominal.Enabled = false;
            this.tbNominal.Location = new System.Drawing.Point(28, 304);
            this.tbNominal.Name = "tbNominal";
            this.tbNominal.Size = new System.Drawing.Size(100, 20);
            this.tbNominal.TabIndex = 10;
            this.tbNominal.Text = "0";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(424, 343);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 11;
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
            this.cmdClose.Location = new System.Drawing.Point(530, 343);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tbTanggal
            // 
            this.tbTanggal.DateValue = null;
            this.tbTanggal.Enabled = false;
            this.tbTanggal.Location = new System.Drawing.Point(298, 25);
            this.tbTanggal.MaxLength = 10;
            this.tbTanggal.Name = "tbTanggal";
            this.tbTanggal.Size = new System.Drawing.Size(80, 20);
            this.tbTanggal.TabIndex = 1;
            // 
            // frmVoucherGiroTitipUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(659, 395);
            this.Controls.Add(this.tbTanggal);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tbNominal);
            this.Controls.Add(this.tbDibukukan);
            this.Controls.Add(this.tbMengetahui);
            this.Controls.Add(this.tbDibuat);
            this.Controls.Add(this.lookupBank1);
            this.Controls.Add(this.tbUraian2);
            this.Controls.Add(this.tbUraian3);
            this.Controls.Add(this.tbUraian1);
            this.Controls.Add(this.tbNoVch);
            this.Controls.Add(this.tbTipe);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVoucherGiroTitipUpdate";
            this.Text = "Voucher Titipan Giro Update";
            this.Load += new System.EventHandler(this.frmVoucherGiroTitipUpdate_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.tbTipe, 0);
            this.Controls.SetChildIndex(this.tbNoVch, 0);
            this.Controls.SetChildIndex(this.tbUraian1, 0);
            this.Controls.SetChildIndex(this.tbUraian3, 0);
            this.Controls.SetChildIndex(this.tbUraian2, 0);
            this.Controls.SetChildIndex(this.lookupBank1, 0);
            this.Controls.SetChildIndex(this.tbDibuat, 0);
            this.Controls.SetChildIndex(this.tbMengetahui, 0);
            this.Controls.SetChildIndex(this.tbDibukukan, 0);
            this.Controls.SetChildIndex(this.tbNominal, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tbTanggal, 0);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private ISA.Controls.CommonTextBox tbTipe;
        private ISA.Controls.CommonTextBox tbNoVch;
        private ISA.Controls.CommonTextBox tbUraian1;
        private ISA.Controls.CommonTextBox tbUraian3;
        private ISA.Controls.CommonTextBox tbUraian2;
        private ISA.Finance.Controls.LookupBank lookupBank1;
        private ISA.Controls.CommonTextBox tbDibuat;
        private ISA.Controls.CommonTextBox tbMengetahui;
        private ISA.Controls.CommonTextBox tbDibukukan;
        private ISA.Controls.NumericTextBox tbNominal;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.DateTextBox tbTanggal;
    }
}
