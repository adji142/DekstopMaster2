namespace ISA.Bengkel.Transaksi
{
    partial class frmServiceDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceDetailUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBiaya = new ISA.Controls.NumericTextBox();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDisc = new ISA.Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPot = new ISA.Controls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNetto = new ISA.Controls.NumericTextBox();
            this.txtServiceDesc = new ISA.Controls.CommonTextBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeterangan = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chksasa = new System.Windows.Forms.CheckBox();
            this.chkother = new System.Windows.Forms.CheckBox();
            this.chkkry = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "SERVICE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "BIAYA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "NETTO";
            // 
            // txtBiaya
            // 
            this.txtBiaya.Location = new System.Drawing.Point(151, 94);
            this.txtBiaya.MaxLength = 6;
            this.txtBiaya.Name = "txtBiaya";
            this.txtBiaya.Size = new System.Drawing.Size(80, 20);
            this.txtBiaya.TabIndex = 2;
            this.txtBiaya.Text = "0";
            this.txtBiaya.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBiaya.Leave += new System.EventHandler(this.txtBiaya_Leave);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(362, 189);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.ReportName2 = "";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 8;
            this.cmdCLOSE.TabStop = false;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(257, 189);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.ReportName2 = "";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 7;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtDisc
            // 
            this.txtDisc.Enabled = false;
            this.txtDisc.Location = new System.Drawing.Point(308, 94);
            this.txtDisc.MaxLength = 5;
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.ReadOnly = true;
            this.txtDisc.Size = new System.Drawing.Size(80, 20);
            this.txtDisc.TabIndex = 3;
            this.txtDisc.Text = "0";
            this.txtDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisc.TextChanged += new System.EventHandler(this.txtDisc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "DISC.";
            // 
            // txtPot
            // 
            this.txtPot.Enabled = false;
            this.txtPot.Location = new System.Drawing.Point(459, 94);
            this.txtPot.MaxLength = 5;
            this.txtPot.Name = "txtPot";
            this.txtPot.ReadOnly = true;
            this.txtPot.Size = new System.Drawing.Size(80, 20);
            this.txtPot.TabIndex = 4;
            this.txtPot.Text = "0";
            this.txtPot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPot.TextChanged += new System.EventHandler(this.txtDisc_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "POT.";
            // 
            // txtNetto
            // 
            this.txtNetto.Enabled = false;
            this.txtNetto.Location = new System.Drawing.Point(151, 119);
            this.txtNetto.MaxLength = 5;
            this.txtNetto.Name = "txtNetto";
            this.txtNetto.ReadOnly = true;
            this.txtNetto.Size = new System.Drawing.Size(80, 20);
            this.txtNetto.TabIndex = 5;
            this.txtNetto.Text = "0";
            this.txtNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtServiceDesc
            // 
            this.txtServiceDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServiceDesc.Location = new System.Drawing.Point(395, 66);
            this.txtServiceDesc.MaxLength = 25;
            this.txtServiceDesc.Name = "txtServiceDesc";
            this.txtServiceDesc.Size = new System.Drawing.Size(261, 20);
            this.txtServiceDesc.TabIndex = 1;
            this.txtServiceDesc.TabStop = false;
            // 
            // cmbService
            // 
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(151, 66);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(237, 22);
            this.cmbService.TabIndex = 0;
            this.cmbService.SelectedValueChanged += new System.EventHandler(this.cmbService_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "KETERANGAN";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(151, 145);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(310, 20);
            this.txtKeterangan.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "Service Perusahaan";
            this.label6.Visible = false;
            // 
            // chksasa
            // 
            this.chksasa.AutoSize = true;
            this.chksasa.Location = new System.Drawing.Point(386, 122);
            this.chksasa.Name = "chksasa";
            this.chksasa.Size = new System.Drawing.Size(56, 18);
            this.chksasa.TabIndex = 22;
            this.chksasa.Text = "SASA";
            this.chksasa.UseVisualStyleBackColor = true;
            this.chksasa.Visible = false;
            this.chksasa.CheckedChanged += new System.EventHandler(this.chksasa_CheckedChanged);
            // 
            // chkother
            // 
            this.chkother.AutoSize = true;
            this.chkother.Location = new System.Drawing.Point(448, 122);
            this.chkother.Name = "chkother";
            this.chkother.Size = new System.Drawing.Size(117, 18);
            this.chkother.TabIndex = 23;
            this.chkother.Text = "Perusahaan Lain";
            this.chkother.UseVisualStyleBackColor = true;
            this.chkother.Visible = false;
            this.chkother.CheckedChanged += new System.EventHandler(this.chkother_CheckedChanged);
            // 
            // chkkry
            // 
            this.chkkry.AutoSize = true;
            this.chkkry.Location = new System.Drawing.Point(571, 122);
            this.chkkry.Name = "chkkry";
            this.chkkry.Size = new System.Drawing.Size(79, 18);
            this.chkkry.TabIndex = 24;
            this.chkkry.Text = "Karyawan";
            this.chkkry.UseVisualStyleBackColor = true;
            this.chkkry.Visible = false;
            this.chkkry.CheckedChanged += new System.EventHandler(this.chkkry_CheckedChanged);
            // 
            // frmServiceDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(712, 250);
            this.Controls.Add(this.chkkry);
            this.Controls.Add(this.chkother);
            this.Controls.Add(this.chksasa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServiceDesc);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.txtNetto);
            this.Controls.Add(this.txtPot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDisc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.txtBiaya);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.FormID = "BKL0112";
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServiceDetailUpdate";
            this.Text = "BKL0112 - Kategori Service";
            this.Title = "Kategori Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmServiceDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServiceDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtBiaya, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDisc, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPot, 0);
            this.Controls.SetChildIndex(this.txtNetto, 0);
            this.Controls.SetChildIndex(this.cmbService, 0);
            this.Controls.SetChildIndex(this.txtServiceDesc, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.chksasa, 0);
            this.Controls.SetChildIndex(this.chkother, 0);
            this.Controls.SetChildIndex(this.chkkry, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.NumericTextBox txtBiaya;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controls.NumericTextBox txtPot;
        private System.Windows.Forms.Label label3;
        private Controls.NumericTextBox txtDisc;
        private System.Windows.Forms.Label label1;
        private Controls.NumericTextBox txtNetto;
        private Controls.CommonTextBox txtServiceDesc;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox txtKeterangan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chksasa;
        private System.Windows.Forms.CheckBox chkother;
        private System.Windows.Forms.CheckBox chkkry;
    }
}
