namespace ISA.Finance.Kasir
{
    partial class frmBuktiTransferKeluarDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuktiTransferKeluarDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNoPerk = new ISA.Controls.CommonTextBox();
            this.lblKeterangan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdUtkPembayaran = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdTransferDari = new ISA.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdTransferKe = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdNmrTransfer = new ISA.Controls.CommonTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdNominal = new ISA.Controls.NumericTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdTglTransfer = new ISA.Controls.DateTextBox();
            this.cmdTglBank = new ISA.Controls.DateTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "No Perkiraan";
            // 
            // cmdNoPerk
            // 
            this.cmdNoPerk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdNoPerk.Location = new System.Drawing.Point(161, 22);
            this.cmdNoPerk.Name = "cmdNoPerk";
            this.cmdNoPerk.ReadOnly = true;
            this.cmdNoPerk.Size = new System.Drawing.Size(125, 20);
            this.cmdNoPerk.TabIndex = 4;
            this.cmdNoPerk.TabStop = false;
            // 
            // lblKeterangan
            // 
            this.lblKeterangan.AutoSize = true;
            this.lblKeterangan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeterangan.Location = new System.Drawing.Point(158, 45);
            this.lblKeterangan.Name = "lblKeterangan";
            this.lblKeterangan.Size = new System.Drawing.Size(38, 14);
            this.lblKeterangan.TabIndex = 5;
            this.lblKeterangan.Text = "label2";
            this.lblKeterangan.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Untuk Pembayaran";
            // 
            // cmdUtkPembayaran
            // 
            this.cmdUtkPembayaran.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdUtkPembayaran.Location = new System.Drawing.Point(161, 91);
            this.cmdUtkPembayaran.Name = "cmdUtkPembayaran";
            this.cmdUtkPembayaran.Size = new System.Drawing.Size(188, 20);
            this.cmdUtkPembayaran.TabIndex = 0;
            this.cmdUtkPembayaran.Validated += new System.EventHandler(this.cmdUtkPembayaran_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tanggal Transfer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Transfer Dari Bank";
            // 
            // cmdTransferDari
            // 
            this.cmdTransferDari.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdTransferDari.Location = new System.Drawing.Point(161, 166);
            this.cmdTransferDari.Name = "cmdTransferDari";
            this.cmdTransferDari.ReadOnly = true;
            this.cmdTransferDari.Size = new System.Drawing.Size(132, 20);
            this.cmdTransferDari.TabIndex = 2;
            this.cmdTransferDari.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Masuk Ke Bank";
            // 
            // cmdTransferKe
            // 
            this.cmdTransferKe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdTransferKe.Location = new System.Drawing.Point(161, 205);
            this.cmdTransferKe.Name = "cmdTransferKe";
            this.cmdTransferKe.Size = new System.Drawing.Size(132, 20);
            this.cmdTransferKe.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tanggal Bank";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nomor Transfer";
            // 
            // cmdNmrTransfer
            // 
            this.cmdNmrTransfer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdNmrTransfer.Location = new System.Drawing.Point(161, 291);
            this.cmdNmrTransfer.Name = "cmdNmrTransfer";
            this.cmdNmrTransfer.Size = new System.Drawing.Size(100, 20);
            this.cmdNmrTransfer.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Nominal";
            // 
            // cmdNominal
            // 
            this.cmdNominal.Location = new System.Drawing.Point(161, 322);
            this.cmdNominal.Name = "cmdNominal";
            this.cmdNominal.Size = new System.Drawing.Size(100, 20);
            this.cmdNominal.TabIndex = 3;
            this.cmdNominal.Text = "0";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(96, 385);
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
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(232, 385);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdTglTransfer
            // 
            this.cmdTglTransfer.DateValue = null;
            this.cmdTglTransfer.Location = new System.Drawing.Point(161, 123);
            this.cmdTglTransfer.MaxLength = 10;
            this.cmdTglTransfer.Name = "cmdTglTransfer";
            this.cmdTglTransfer.ReadOnly = true;
            this.cmdTglTransfer.Size = new System.Drawing.Size(80, 20);
            this.cmdTglTransfer.TabIndex = 19;
            // 
            // cmdTglBank
            // 
            this.cmdTglBank.DateValue = null;
            this.cmdTglBank.Location = new System.Drawing.Point(161, 247);
            this.cmdTglBank.MaxLength = 10;
            this.cmdTglBank.Name = "cmdTglBank";
            this.cmdTglBank.ReadOnly = true;
            this.cmdTglBank.Size = new System.Drawing.Size(80, 20);
            this.cmdTglBank.TabIndex = 20;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmBuktiTransferKeluarDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(395, 437);
            this.Controls.Add(this.cmdTglBank);
            this.Controls.Add(this.cmdTglTransfer);
            this.Controls.Add(this.cmdNominal);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdNmrTransfer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdTransferKe);
            this.Controls.Add(this.cmdUtkPembayaran);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdTransferDari);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblKeterangan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdNoPerk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "frmBuktiTransferKeluarDetailUpdate";
            this.Text = "Bukti Transfer Keluar Detail Update";
            this.Load += new System.EventHandler(this.frmBuktiTransferKeluarDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBuktiTransferKeluarDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdNoPerk, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblKeterangan, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmdTransferDari, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmdUtkPembayaran, 0);
            this.Controls.SetChildIndex(this.cmdTransferKe, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cmdNmrTransfer, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdNominal, 0);
            this.Controls.SetChildIndex(this.cmdTglTransfer, 0);
            this.Controls.SetChildIndex(this.cmdTglBank, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox cmdNoPerk;
        private System.Windows.Forms.Label lblKeterangan;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox cmdUtkPembayaran;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox cmdTransferDari;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CommonTextBox cmdTransferKe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.CommonTextBox cmdNmrTransfer;
        private System.Windows.Forms.Label label8;
        private ISA.Controls.NumericTextBox cmdNominal;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.DateTextBox cmdTglTransfer;
        private ISA.Controls.DateTextBox cmdTglBank;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
