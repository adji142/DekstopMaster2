namespace ISA.Finance.Hutang
{
    partial class frmLinkInvoiceKeHutangManualLokal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkInvoiceKeHutangManualLokal));
            this.txtTglInvoice = new ISA.Controls.DateTextBox();
            this.txtOri = new ISA.Controls.NumericTextBox();
            this.txtNoInvoice = new ISA.Controls.CommonTextBox();
            this.tbTglInvoice = new ISA.Controls.DateTextBox();
            this.tbSaldoHutang = new ISA.Controls.NumericTextBox();
            this.tbNoInvoice = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTglInvoice
            // 
            this.txtTglInvoice.DateValue = null;
            this.txtTglInvoice.Location = new System.Drawing.Point(183, 176);
            this.txtTglInvoice.MaxLength = 10;
            this.txtTglInvoice.Name = "txtTglInvoice";
            this.txtTglInvoice.ReadOnly = true;
            this.txtTglInvoice.Size = new System.Drawing.Size(182, 20);
            this.txtTglInvoice.TabIndex = 176;
            this.txtTglInvoice.TabStop = false;
            // 
            // txtOri
            // 
            this.txtOri.Format = "N4";
            this.txtOri.Location = new System.Drawing.Point(668, 142);
            this.txtOri.Name = "txtOri";
            this.txtOri.Size = new System.Drawing.Size(202, 20);
            this.txtOri.TabIndex = 171;
            this.txtOri.Text = "0.0000";
            this.txtOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNoInvoice
            // 
            this.txtNoInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoInvoice.Location = new System.Drawing.Point(0, 0);
            this.txtNoInvoice.Name = "txtNoInvoice";
            this.txtNoInvoice.Size = new System.Drawing.Size(100, 20);
            this.txtNoInvoice.TabIndex = 0;
            // 
            // tbTglInvoice
            // 
            this.tbTglInvoice.DateValue = null;
            this.tbTglInvoice.Location = new System.Drawing.Point(185, 97);
            this.tbTglInvoice.MaxLength = 10;
            this.tbTglInvoice.Name = "tbTglInvoice";
            this.tbTglInvoice.ReadOnly = true;
            this.tbTglInvoice.Size = new System.Drawing.Size(182, 20);
            this.tbTglInvoice.TabIndex = 176;
            this.tbTglInvoice.TabStop = false;
            // 
            // tbSaldoHutang
            // 
            this.tbSaldoHutang.Format = "N4";
            this.tbSaldoHutang.Location = new System.Drawing.Point(626, 69);
            this.tbSaldoHutang.Name = "tbSaldoHutang";
            this.tbSaldoHutang.Size = new System.Drawing.Size(202, 20);
            this.tbSaldoHutang.TabIndex = 171;
            this.tbSaldoHutang.Text = "0.0000";
            this.tbSaldoHutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbNoInvoice
            // 
            this.tbNoInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoInvoice.Location = new System.Drawing.Point(185, 72);
            this.tbNoInvoice.Name = "tbNoInvoice";
            this.tbNoInvoice.ReadOnly = true;
            this.tbNoInvoice.Size = new System.Drawing.Size(182, 20);
            this.tbNoInvoice.TabIndex = 172;
            this.tbNoInvoice.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 14);
            this.label3.TabIndex = 175;
            this.label3.Text = "Saldo Hutang (IDR)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 174;
            this.label2.Text = "Tgl Invoice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 173;
            this.label1.Text = "No. Invoice";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(705, 424);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 178;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(583, 424);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 177;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(28, 133);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(800, 2);
            this.label19.TabIndex = 179;
            this.label19.Text = "line";
            // 
            // frmLinkInvoiceKeHutangManualLokal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(875, 477);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.tbTglInvoice);
            this.Controls.Add(this.tbSaldoHutang);
            this.Controls.Add(this.tbNoInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLinkInvoiceKeHutangManualLokal";
            this.Text = "Link Invoice ke Hutang Lokal";
            this.Title = "Link Invoice ke Hutang Lokal";
            this.Load += new System.EventHandler(this.frmLinkInvoiceKeHutangManualLokal_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbNoInvoice, 0);
            this.Controls.SetChildIndex(this.tbSaldoHutang, 0);
            this.Controls.SetChildIndex(this.tbTglInvoice, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.DateTextBox txtTglInvoice;
        private ISA.Controls.NumericTextBox txtOri;
        private ISA.Controls.CommonTextBox txtNoInvoice;
        private ISA.Controls.DateTextBox tbTglInvoice;
        private ISA.Controls.NumericTextBox tbSaldoHutang;
        private ISA.Controls.CommonTextBox tbNoInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label19;

    }
}
