namespace ISA.Finance.Kasir
{
    partial class frmRptSaldoIdentBayar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSaldoIdentBayar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoTglTerima = new System.Windows.Forms.RadioButton();
            this.rdoJns = new System.Windows.Forms.RadioButton();
            this.rdoNoBukti = new System.Windows.Forms.RadioButton();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.txtPID = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "SALDO IDENTIFIKASI PEMBAYARAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "PERIODE";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(138, 102);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "DIURUTKAN PER";
            // 
            // rdoTglTerima
            // 
            this.rdoTglTerima.AutoSize = true;
            this.rdoTglTerima.Checked = true;
            this.rdoTglTerima.Location = new System.Drawing.Point(138, 200);
            this.rdoTglTerima.Name = "rdoTglTerima";
            this.rdoTglTerima.Size = new System.Drawing.Size(87, 18);
            this.rdoTglTerima.TabIndex = 7;
            this.rdoTglTerima.TabStop = true;
            this.rdoTglTerima.Text = "Tgl. Terima";
            this.rdoTglTerima.UseVisualStyleBackColor = true;
            // 
            // rdoJns
            // 
            this.rdoJns.AutoSize = true;
            this.rdoJns.Location = new System.Drawing.Point(231, 202);
            this.rdoJns.Name = "rdoJns";
            this.rdoJns.Size = new System.Drawing.Size(113, 18);
            this.rdoJns.TabIndex = 8;
            this.rdoJns.Text = "Jenis Transaksi";
            this.rdoJns.UseVisualStyleBackColor = true;
            // 
            // rdoNoBukti
            // 
            this.rdoNoBukti.AutoSize = true;
            this.rdoNoBukti.Location = new System.Drawing.Point(350, 200);
            this.rdoNoBukti.Name = "rdoNoBukti";
            this.rdoNoBukti.Size = new System.Drawing.Size(93, 18);
            this.rdoNoBukti.TabIndex = 9;
            this.rdoNoBukti.Text = "Nomor Bukti";
            this.rdoNoBukti.UseVisualStyleBackColor = true;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(80, 259);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 10;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(268, 259);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtPID
            // 
            this.txtPID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPID.Location = new System.Drawing.Point(138, 154);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(40, 20);
            this.txtPID.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "PERUSAHAAN ID";
            // 
            // frmRptSaldoIdentBayar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(471, 312);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoNoBukti);
            this.Controls.Add(this.rdoJns);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.rdoTglTerima);
            this.Controls.Add(this.cmdYes);
            this.Name = "frmRptSaldoIdentBayar";
            this.Text = "Saldo Identifikasi Pembayaran";
            this.Load += new System.EventHandler(this.frmRptSaldoIdentBayar_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.rdoTglTerima, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.rdoJns, 0);
            this.Controls.SetChildIndex(this.rdoNoBukti, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoTglTerima;
        private System.Windows.Forms.RadioButton rdoJns;
        private System.Windows.Forms.RadioButton rdoNoBukti;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommonTextBox txtPID;
        private System.Windows.Forms.Label label4;
    }
}
