namespace ISA.Finance.Kasir
{
    partial class frmTransaksiPencairanGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransaksiPencairanGiro));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGiroBank = new ISA.Controls.CommonTextBox();
            this.txtNoGiro = new ISA.Controls.CommonTextBox();
            this.txtAsalGiro = new ISA.Controls.CommonTextBox();
            this.numNilaiGiro = new ISA.Controls.NumericTextBox();
            this.dbTglGiro = new ISA.Controls.DateTextBox();
            this.dbTglJTempo = new ISA.Controls.DateTextBox();
            this.cmbTrans = new System.Windows.Forms.ComboBox();
            this.txtAlasan = new ISA.Controls.CommonTextBox();
            this.dbTglCairBank = new ISA.Controls.DateTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Giro Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "No. Giro/CH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nilai Giro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tgl. Giro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tgl. JTempo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Asal Giro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Cair/Tolak (C-T-B)";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tgl. Cair Bank";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(151, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "TRANSAKSI PENCAIRAN GIRO";
            // 
            // txtGiroBank
            // 
            this.txtGiroBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGiroBank.Enabled = false;
            this.txtGiroBank.Location = new System.Drawing.Point(148, 72);
            this.txtGiroBank.Name = "txtGiroBank";
            this.txtGiroBank.ReadOnly = true;
            this.txtGiroBank.Size = new System.Drawing.Size(250, 20);
            this.txtGiroBank.TabIndex = 12;
            // 
            // txtNoGiro
            // 
            this.txtNoGiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoGiro.Enabled = false;
            this.txtNoGiro.Location = new System.Drawing.Point(148, 100);
            this.txtNoGiro.Name = "txtNoGiro";
            this.txtNoGiro.ReadOnly = true;
            this.txtNoGiro.Size = new System.Drawing.Size(133, 20);
            this.txtNoGiro.TabIndex = 13;
            // 
            // txtAsalGiro
            // 
            this.txtAsalGiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAsalGiro.Enabled = false;
            this.txtAsalGiro.Location = new System.Drawing.Point(148, 210);
            this.txtAsalGiro.Name = "txtAsalGiro";
            this.txtAsalGiro.ReadOnly = true;
            this.txtAsalGiro.Size = new System.Drawing.Size(193, 20);
            this.txtAsalGiro.TabIndex = 17;
            // 
            // numNilaiGiro
            // 
            this.numNilaiGiro.Enabled = false;
            this.numNilaiGiro.Location = new System.Drawing.Point(148, 126);
            this.numNilaiGiro.Name = "numNilaiGiro";
            this.numNilaiGiro.ReadOnly = true;
            this.numNilaiGiro.Size = new System.Drawing.Size(100, 20);
            this.numNilaiGiro.TabIndex = 18;
            this.numNilaiGiro.Text = "0";
            this.numNilaiGiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dbTglGiro
            // 
            this.dbTglGiro.DateValue = null;
            this.dbTglGiro.Enabled = false;
            this.dbTglGiro.Location = new System.Drawing.Point(148, 153);
            this.dbTglGiro.MaxLength = 10;
            this.dbTglGiro.Name = "dbTglGiro";
            this.dbTglGiro.ReadOnly = true;
            this.dbTglGiro.Size = new System.Drawing.Size(100, 20);
            this.dbTglGiro.TabIndex = 19;
            // 
            // dbTglJTempo
            // 
            this.dbTglJTempo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dbTglJTempo.DateValue = null;
            this.dbTglJTempo.Enabled = false;
            this.dbTglJTempo.Location = new System.Drawing.Point(148, 180);
            this.dbTglJTempo.MaxLength = 10;
            this.dbTglJTempo.Name = "dbTglJTempo";
            this.dbTglJTempo.ReadOnly = true;
            this.dbTglJTempo.Size = new System.Drawing.Size(100, 20);
            this.dbTglJTempo.TabIndex = 20;
            // 
            // cmbTrans
            // 
            this.cmbTrans.FormattingEnabled = true;
            this.cmbTrans.Items.AddRange(new object[] {
            "C",
            "T",
            "B"});
            this.cmbTrans.Location = new System.Drawing.Point(148, 238);
            this.cmbTrans.Name = "cmbTrans";
            this.cmbTrans.Size = new System.Drawing.Size(37, 22);
            this.cmbTrans.TabIndex = 21;
            this.cmbTrans.SelectedIndexChanged += new System.EventHandler(this.cmbTrans_SelectedIndexChanged);
            this.cmbTrans.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTrans_KeyDown);
            // 
            // txtAlasan
            // 
            this.txtAlasan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlasan.Location = new System.Drawing.Point(201, 240);
            this.txtAlasan.Name = "txtAlasan";
            this.txtAlasan.Size = new System.Drawing.Size(302, 20);
            this.txtAlasan.TabIndex = 22;
            // 
            // dbTglCairBank
            // 
            this.dbTglCairBank.DateValue = null;
            this.dbTglCairBank.Location = new System.Drawing.Point(148, 266);
            this.dbTglCairBank.MaxLength = 10;
            this.dbTglCairBank.Name = "dbTglCairBank";
            this.dbTglCairBank.Size = new System.Drawing.Size(100, 20);
            this.dbTglCairBank.TabIndex = 23;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(132, 308);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 24;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(338, 308);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 25;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmTransaksiPencairanGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(543, 369);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dbTglCairBank);
            this.Controls.Add(this.txtAlasan);
            this.Controls.Add(this.cmbTrans);
            this.Controls.Add(this.dbTglJTempo);
            this.Controls.Add(this.dbTglGiro);
            this.Controls.Add(this.numNilaiGiro);
            this.Controls.Add(this.txtAsalGiro);
            this.Controls.Add(this.txtNoGiro);
            this.Controls.Add(this.txtGiroBank);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmTransaksiPencairanGiro";
            this.Load += new System.EventHandler(this.frmTransaksiPencairanGiro_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTransaksiPencairanGiro_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtGiroBank, 0);
            this.Controls.SetChildIndex(this.txtNoGiro, 0);
            this.Controls.SetChildIndex(this.txtAsalGiro, 0);
            this.Controls.SetChildIndex(this.numNilaiGiro, 0);
            this.Controls.SetChildIndex(this.dbTglGiro, 0);
            this.Controls.SetChildIndex(this.dbTglJTempo, 0);
            this.Controls.SetChildIndex(this.cmbTrans, 0);
            this.Controls.SetChildIndex(this.txtAlasan, 0);
            this.Controls.SetChildIndex(this.dbTglCairBank, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
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
        private ISA.Controls.CommonTextBox txtGiroBank;
        private ISA.Controls.CommonTextBox txtNoGiro;
        private ISA.Controls.CommonTextBox txtAsalGiro;
        private ISA.Controls.NumericTextBox numNilaiGiro;
        private ISA.Controls.DateTextBox dbTglGiro;
        private ISA.Controls.DateTextBox dbTglJTempo;
        private System.Windows.Forms.ComboBox cmbTrans;
        private ISA.Controls.CommonTextBox txtAlasan;
        private ISA.Controls.DateTextBox dbTglCairBank;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
    }
}
