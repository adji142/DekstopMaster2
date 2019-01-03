namespace ISA.Finance.Piutang
{
    partial class frmKartuPiutangDetailUpdate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKartuPiutangDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tglTrans = new ISA.Controls.DateTextBox();
            this.cboTrans = new System.Windows.Forms.ComboBox();
            this.txtTglBGC = new ISA.Controls.DateTextBox();
            this.txtNoBGC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDebet = new ISA.Controls.NumericTextBox();
            this.txtKredit = new ISA.Controls.NumericTextBox();
            this.txtNoACC = new System.Windows.Forms.TextBox();
            this.txtNamaBank = new System.Windows.Forms.TextBox();
            this.txtNoBKM = new System.Windows.Forms.TextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdCLose = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtUraian = new ISA.Controls.CommonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tgl Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kode Transaksi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tgl BGC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nomor BGC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nomor BKM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nama Bank";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Nomor ACC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Uraian";
            // 
            // tglTrans
            // 
            this.tglTrans.DateValue = null;
            this.tglTrans.Location = new System.Drawing.Point(137, 28);
            this.tglTrans.MaxLength = 10;
            this.tglTrans.Name = "tglTrans";
            this.tglTrans.Size = new System.Drawing.Size(141, 20);
            this.tglTrans.TabIndex = 0;
            // 
            // cboTrans
            // 
            this.cboTrans.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboTrans.FormattingEnabled = true;
            this.cboTrans.Location = new System.Drawing.Point(137, 58);
            this.cboTrans.Name = "cboTrans";
            this.cboTrans.Size = new System.Drawing.Size(141, 22);
            this.cboTrans.TabIndex = 1;
            this.cboTrans.SelectedValueChanged += new System.EventHandler(this.cboTrans_SelectedValueChanged);
            // 
            // txtTglBGC
            // 
            this.txtTglBGC.DateValue = null;
            this.txtTglBGC.Location = new System.Drawing.Point(137, 90);
            this.txtTglBGC.MaxLength = 10;
            this.txtTglBGC.Name = "txtTglBGC";
            this.txtTglBGC.ReadOnly = true;
            this.txtTglBGC.Size = new System.Drawing.Size(141, 20);
            this.txtTglBGC.TabIndex = 4;
            this.txtTglBGC.TabStop = false;
            // 
            // txtNoBGC
            // 
            this.txtNoBGC.Location = new System.Drawing.Point(137, 120);
            this.txtNoBGC.Name = "txtNoBGC";
            this.txtNoBGC.ReadOnly = true;
            this.txtNoBGC.Size = new System.Drawing.Size(141, 20);
            this.txtNoBGC.TabIndex = 5;
            this.txtNoBGC.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Debet";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "Kredit";
            // 
            // txtDebet
            // 
            this.txtDebet.Location = new System.Drawing.Point(399, 31);
            this.txtDebet.Name = "txtDebet";
            this.txtDebet.Size = new System.Drawing.Size(100, 20);
            this.txtDebet.TabIndex = 2;
            this.txtDebet.Text = "0";
            this.txtDebet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDebet.Validating += new System.ComponentModel.CancelEventHandler(this.txtDebet_Validating);
            // 
            // txtKredit
            // 
            this.txtKredit.Location = new System.Drawing.Point(399, 60);
            this.txtKredit.Name = "txtKredit";
            this.txtKredit.Size = new System.Drawing.Size(100, 20);
            this.txtKredit.TabIndex = 3;
            this.txtKredit.Text = "0";
            this.txtKredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKredit.Validating += new System.ComponentModel.CancelEventHandler(this.txtKredit_Validating);
            // 
            // txtNoACC
            // 
            this.txtNoACC.Location = new System.Drawing.Point(137, 210);
            this.txtNoACC.Name = "txtNoACC";
            this.txtNoACC.ReadOnly = true;
            this.txtNoACC.Size = new System.Drawing.Size(141, 20);
            this.txtNoACC.TabIndex = 8;
            this.txtNoACC.TabStop = false;
            // 
            // txtNamaBank
            // 
            this.txtNamaBank.Location = new System.Drawing.Point(137, 180);
            this.txtNamaBank.Name = "txtNamaBank";
            this.txtNamaBank.ReadOnly = true;
            this.txtNamaBank.Size = new System.Drawing.Size(141, 20);
            this.txtNamaBank.TabIndex = 7;
            this.txtNamaBank.TabStop = false;
            // 
            // txtNoBKM
            // 
            this.txtNoBKM.Location = new System.Drawing.Point(137, 150);
            this.txtNoBKM.Name = "txtNoBKM";
            this.txtNoBKM.ReadOnly = true;
            this.txtNoBKM.Size = new System.Drawing.Size(141, 20);
            this.txtNoBKM.TabIndex = 6;
            this.txtNoBKM.TabStop = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(279, 288);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCLose
            // 
            this.cmdCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLose.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLose.Image")));
            this.cmdCLose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLose.Location = new System.Drawing.Point(400, 288);
            this.cmdCLose.Name = "cmdCLose";
            this.cmdCLose.Size = new System.Drawing.Size(100, 40);
            this.cmdCLose.TabIndex = 11;
            this.cmdCLose.TabStop = false;
            this.cmdCLose.Text = "CLOSE";
            this.cmdCLose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLose.UseVisualStyleBackColor = true;
            this.cmdCLose.Click += new System.EventHandler(this.cmdCLose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(137, 246);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(342, 20);
            this.txtUraian.TabIndex = 9;
            // 
            // frmKartuPiutangDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(512, 337);
            this.Controls.Add(this.txtUraian);
            this.Controls.Add(this.cmdCLose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtNoBKM);
            this.Controls.Add(this.txtNamaBank);
            this.Controls.Add(this.txtNoACC);
            this.Controls.Add(this.txtKredit);
            this.Controls.Add(this.txtDebet);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNoBGC);
            this.Controls.Add(this.txtTglBGC);
            this.Controls.Add(this.cboTrans);
            this.Controls.Add(this.tglTrans);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKartuPiutangDetailUpdate";
            this.Text = "Tambah Piutang Detail";
            this.Load += new System.EventHandler(this.frmKartuPiutangDetailUpdate_Load);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tglTrans, 0);
            this.Controls.SetChildIndex(this.cboTrans, 0);
            this.Controls.SetChildIndex(this.txtTglBGC, 0);
            this.Controls.SetChildIndex(this.txtNoBGC, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtDebet, 0);
            this.Controls.SetChildIndex(this.txtKredit, 0);
            this.Controls.SetChildIndex(this.txtNoACC, 0);
            this.Controls.SetChildIndex(this.txtNamaBank, 0);
            this.Controls.SetChildIndex(this.txtNoBKM, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdCLose, 0);
            this.Controls.SetChildIndex(this.txtUraian, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private ISA.Controls.DateTextBox tglTrans;
        private System.Windows.Forms.ComboBox cboTrans;
        private ISA.Controls.DateTextBox txtTglBGC;
        private System.Windows.Forms.TextBox txtNoBGC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private ISA.Controls.NumericTextBox txtDebet;
        private ISA.Controls.NumericTextBox txtKredit;
        private System.Windows.Forms.TextBox txtNoACC;
        private System.Windows.Forms.TextBox txtNamaBank;
        private System.Windows.Forms.TextBox txtNoBKM;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdCLose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Controls.CommonTextBox txtUraian;
    }
}
