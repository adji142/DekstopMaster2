namespace ISA.Toko.Kasir
{
    partial class frmBuktiTransferMasukDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuktiTransferMasukDetailUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoPerkiraan = new ISA.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbTglBank = new ISA.Controls.DateTextBox();
            this.txtNamaBank = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomorTransfer = new ISA.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ntbTransfer = new ISA.Controls.NumericTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.dbTglTransfer = new ISA.Controls.DateTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nomor Perkiraan";
            // 
            // txtNoPerkiraan
            // 
            this.txtNoPerkiraan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoPerkiraan.Enabled = false;
            this.txtNoPerkiraan.Location = new System.Drawing.Point(175, 45);
            this.txtNoPerkiraan.Name = "txtNoPerkiraan";
            this.txtNoPerkiraan.ReadOnly = true;
            this.txtNoPerkiraan.Size = new System.Drawing.Size(145, 20);
            this.txtNoPerkiraan.TabIndex = 4;
            this.txtNoPerkiraan.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tanggal Bank";
            // 
            // dbTglBank
            // 
            this.dbTglBank.DateValue = null;
            this.dbTglBank.Enabled = false;
            this.dbTglBank.Location = new System.Drawing.Point(175, 71);
            this.dbTglBank.MaxLength = 10;
            this.dbTglBank.Name = "dbTglBank";
            this.dbTglBank.ReadOnly = true;
            this.dbTglBank.Size = new System.Drawing.Size(80, 20);
            this.dbTglBank.TabIndex = 6;
            this.dbTglBank.TabStop = false;
            // 
            // txtNamaBank
            // 
            this.txtNamaBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaBank.Location = new System.Drawing.Point(175, 97);
            this.txtNamaBank.Name = "txtNamaBank";
            this.txtNamaBank.Size = new System.Drawing.Size(145, 20);
            this.txtNamaBank.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nama Bank";
            // 
            // txtNomorTransfer
            // 
            this.txtNomorTransfer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomorTransfer.Location = new System.Drawing.Point(175, 123);
            this.txtNomorTransfer.Name = "txtNomorTransfer";
            this.txtNomorTransfer.Size = new System.Drawing.Size(145, 20);
            this.txtNomorTransfer.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nomor Transfer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tanggal Transfer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nominal Transfer";
            // 
            // ntbTransfer
            // 
            this.ntbTransfer.Location = new System.Drawing.Point(175, 175);
            this.ntbTransfer.Name = "ntbTransfer";
            this.ntbTransfer.Size = new System.Drawing.Size(100, 20);
            this.ntbTransfer.TabIndex = 3;
            this.ntbTransfer.Text = "0";
            this.ntbTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(70, 238);
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
            this.cmdClose.Location = new System.Drawing.Point(245, 238);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dbTglTransfer
            // 
            this.dbTglTransfer.DateValue = null;
            this.dbTglTransfer.Location = new System.Drawing.Point(175, 149);
            this.dbTglTransfer.MaxLength = 10;
            this.dbTglTransfer.Name = "dbTglTransfer";
            this.dbTglTransfer.Size = new System.Drawing.Size(80, 20);
            this.dbTglTransfer.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmBuktiTransferMasukDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(436, 308);
            this.Controls.Add(this.dbTglTransfer);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.ntbTransfer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNomorTransfer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNamaBank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dbTglBank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNoPerkiraan);
            this.Controls.Add(this.label1);
            this.Name = "frmBuktiTransferMasukDetailUpdate";
            this.Text = "Bukti Transfer Masuk Detail Update";
            this.Load += new System.EventHandler(this.frmBuktiTransferMasukDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBuktiTransferMasukDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNoPerkiraan, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dbTglBank, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtNamaBank, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNomorTransfer, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.ntbTransfer, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dbTglTransfer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtNoPerkiraan;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.DateTextBox dbTglBank;
        private ISA.Controls.CommonTextBox txtNamaBank;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox txtNomorTransfer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.NumericTextBox ntbTransfer;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.DateTextBox dbTglTransfer;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
