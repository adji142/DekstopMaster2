namespace ISA.Toko.Kasir
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdNoAcountBank = new ISA.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "No Perkiraan";
            // 
            // cmdNoPerk
            // 
            this.cmdNoPerk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdNoPerk.Location = new System.Drawing.Point(142, 13);
            this.cmdNoPerk.Name = "cmdNoPerk";
            this.cmdNoPerk.ReadOnly = true;
            this.cmdNoPerk.Size = new System.Drawing.Size(125, 20);
            this.cmdNoPerk.TabIndex = 0;
            this.cmdNoPerk.TabStop = false;
            // 
            // lblKeterangan
            // 
            this.lblKeterangan.AutoSize = true;
            this.lblKeterangan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeterangan.Location = new System.Drawing.Point(139, 36);
            this.lblKeterangan.Name = "lblKeterangan";
            this.lblKeterangan.Size = new System.Drawing.Size(38, 14);
            this.lblKeterangan.TabIndex = 5;
            this.lblKeterangan.Text = "label2";
            this.lblKeterangan.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Untuk Pembayaran";
            // 
            // cmdUtkPembayaran
            // 
            this.cmdUtkPembayaran.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdUtkPembayaran.Location = new System.Drawing.Point(150, 10);
            this.cmdUtkPembayaran.Name = "cmdUtkPembayaran";
            this.cmdUtkPembayaran.Size = new System.Drawing.Size(188, 20);
            this.cmdUtkPembayaran.TabIndex = 1;
            this.cmdUtkPembayaran.Validated += new System.EventHandler(this.cmdUtkPembayaran_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tanggal Transfer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dari Bank";
            // 
            // cmdTransferDari
            // 
            this.cmdTransferDari.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdTransferDari.Location = new System.Drawing.Point(150, 88);
            this.cmdTransferDari.Name = "cmdTransferDari";
            this.cmdTransferDari.ReadOnly = true;
            this.cmdTransferDari.Size = new System.Drawing.Size(100, 20);
            this.cmdTransferDari.TabIndex = 3;
            this.cmdTransferDari.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ke Bank";
            // 
            // cmdTransferKe
            // 
            this.cmdTransferKe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdTransferKe.Location = new System.Drawing.Point(150, 155);
            this.cmdTransferKe.Name = "cmdTransferKe";
            this.cmdTransferKe.Size = new System.Drawing.Size(132, 20);
            this.cmdTransferKe.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tanggal Bank";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nomor Transfer";
            // 
            // cmdNmrTransfer
            // 
            this.cmdNmrTransfer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdNmrTransfer.Location = new System.Drawing.Point(150, 235);
            this.cmdNmrTransfer.Name = "cmdNmrTransfer";
            this.cmdNmrTransfer.Size = new System.Drawing.Size(100, 20);
            this.cmdNmrTransfer.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Nominal";
            // 
            // cmdNominal
            // 
            this.cmdNominal.Location = new System.Drawing.Point(150, 269);
            this.cmdNominal.Name = "cmdNominal";
            this.cmdNominal.Size = new System.Drawing.Size(100, 20);
            this.cmdNominal.TabIndex = 7;
            this.cmdNominal.Text = "0";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(130, 321);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 8;
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
            this.cmdClose.Location = new System.Drawing.Point(263, 321);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdTglTransfer
            // 
            this.cmdTglTransfer.DateValue = null;
            this.cmdTglTransfer.Location = new System.Drawing.Point(150, 49);
            this.cmdTglTransfer.MaxLength = 10;
            this.cmdTglTransfer.Name = "cmdTglTransfer";
            this.cmdTglTransfer.ReadOnly = true;
            this.cmdTglTransfer.Size = new System.Drawing.Size(80, 20);
            this.cmdTglTransfer.TabIndex = 2;
            this.cmdTglTransfer.TextChanged += new System.EventHandler(this.cmdTglTransfer_TextChanged);
            // 
            // cmdTglBank
            // 
            this.cmdTglBank.DateValue = null;
            this.cmdTglBank.Location = new System.Drawing.Point(150, 198);
            this.cmdTglBank.MaxLength = 10;
            this.cmdTglBank.Name = "cmdTglBank";
            this.cmdTglBank.ReadOnly = true;
            this.cmdTglBank.Size = new System.Drawing.Size(80, 20);
            this.cmdTglBank.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmdNoAcountBank);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmdSave);
            this.panel1.Controls.Add(this.cmdClose);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmdTglBank);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdTglTransfer);
            this.panel1.Controls.Add(this.cmdNominal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmdTransferDari);
            this.panel1.Controls.Add(this.cmdNmrTransfer);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmdUtkPembayaran);
            this.panel1.Controls.Add(this.cmdTransferKe);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(106, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 386);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 14);
            this.label9.TabIndex = 22;
            this.label9.Text = "Nomor Account Bank";
            // 
            // cmdNoAcountBank
            // 
            this.cmdNoAcountBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmdNoAcountBank.Location = new System.Drawing.Point(150, 123);
            this.cmdNoAcountBank.Name = "cmdNoAcountBank";
            this.cmdNoAcountBank.ReadOnly = true;
            this.cmdNoAcountBank.Size = new System.Drawing.Size(100, 20);
            this.cmdNoAcountBank.TabIndex = 21;
            this.cmdNoAcountBank.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblKeterangan);
            this.groupBox1.Controls.Add(this.cmdNoPerk);
            this.groupBox1.Location = new System.Drawing.Point(649, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(10, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TidakTerlihat";
            this.groupBox1.Visible = false;
            // 
            // frmBuktiTransferKeluarDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(671, 478);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBuktiTransferKeluarDetailUpdate";
            this.Text = "Bukti Transfer Keluar Detail";
            this.Title = "Bukti Transfer Keluar Detail";
            this.Load += new System.EventHandler(this.frmBuktiTransferKeluarDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBuktiTransferKeluarDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.CommonTextBox cmdNoAcountBank;
    }
}
